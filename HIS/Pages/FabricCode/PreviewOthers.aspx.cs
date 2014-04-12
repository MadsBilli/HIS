using HIS.UI.Assembler;
using HIS.UI.Common;
using HIS.UI.Mapper.FabricCode;
using HIS.UI.Mapper.Setup;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIS.Pages.FabricCode
{
    public partial class PreviewOthers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["fctype"]) && !string.IsNullOrEmpty(Request.QueryString["priceOpt"]))
            {
                var fcType = int.Parse(Request.QueryString["fctype"]);
                var priceOpt = int.Parse(Request.QueryString["priceOpt"]);
                GetFabricCodeAndFabricTypeDetails(fcType, priceOpt);

                //convertToPdf(html);
            }
        }

        //private void convertToPdf(string html)
        //{
        //    System.Web.HttpResponse Response = System.Web.HttpContext.Current.Response;
        //    try
        //    {
        //        // create an API client instance
        //        pdfcrowd.Client client = new pdfcrowd.Client("username", "apikey");

        //        // convert a web page and write the generated PDF to a memory stream
        //        MemoryStream Stream = new MemoryStream();
        //        client.convertHtml(html, Stream);

        //        // set HTTP response headers
        //        Response.Clear();
        //        Response.AddHeader("Content-Type", "application/pdf");
        //        Response.AddHeader("Cache-Control", "no-cache");
        //        Response.AddHeader("Accept-Ranges", "none");
        //        Response.AddHeader("Content-Disposition", "attachment; filename=google_com.pdf");

        //        // send the generated PDF
        //        Stream.WriteTo(Response.OutputStream);
        //        Stream.Close();
        //        Response.Flush();
        //        Response.End();
        //    }
        //    catch (pdfcrowd.Error why)
        //    {
        //        Response.Write(why.ToString());
        //    }
        //}

        private void GetFabricCodeAndFabricTypeDetails(int fcType, int priceOption)
        {
            var fabricType = new FabricCodeAssembler().GetSelectedFabricType(fcType);

            var fabricCode = new FabricCodeAssembler().GetFabricCodesList(fcType);
            if (fabricCode.Count == 0)
            {
                fabricCode.Add(new FabricCodeUIMapper());
            }
            var systemSetupDetails = new SystemSetupAssembler().GetSystemSetup();

            StringBuilder sb = new StringBuilder();
            var html = @"<h3 style='margin: 0pt;'>{0}</h3>{1}<br/>Tel: {2} Fax: {3}<br/>GST Reg No.: {4}<br/>";
            html = String.Format(html, GetSystemSetUpValueBySetUpText(systemSetupDetails, Constants.COMPANYNAME),
                 FormatAddress(GetSystemSetUpValueBySetUpText(systemSetupDetails, Constants.COMPANYADDRESS1),
                 GetSystemSetUpValueBySetUpText(systemSetupDetails, Constants.COMPANYADDRESS2),
                 GetSystemSetUpValueBySetUpText(systemSetupDetails, Constants.COMPANYADDRESS3), "", ""),
                 GetSystemSetUpValueBySetUpText(systemSetupDetails, Constants.COMPANYTELEPHONE),
                 GetSystemSetUpValueBySetUpText(systemSetupDetails, Constants.COMPANYFAX),
                 GetSystemSetUpValueBySetUpText(systemSetupDetails, Constants.GSTREGISTRATION));

            ltlCmpDetails.Text = sb.Append(html).ToString();

            FormatFCPrintForOthers(fabricType, fabricCode, priceOption);
            if (priceOption == 1)
            {
                txtFooter.Text = fabricType.fc_footer.Replace("@PRICE_OPTION", "Supply Only");
            }
            else
                txtFooter.Text = fabricType.fc_footer.Replace("@PRICE_OPTION", "Supply & Install");
        }

        private void FormatFCPrintForOthers(FabricTypeUIMapper fabricType, List<FabricCodeUIMapper> fabricCode, int priceOption)
        {
            ltlHeading.Text = @"<div style='width:70%'><div style='float:left'><u>" + fabricType.fc_header + "</u></div><div style='float:right'> Effective Date: " + fabricType.fc_eff_date.ToString("dd/MM/yyyy") + "</div></div>";
            var html = FormatTable(fabricType, fabricCode, priceOption);
            ltlMain.Text = html;
        }

        private string FormatTable(FabricTypeUIMapper fabricType, List<FabricCodeUIMapper> fabricCode, int priceOption)
        {
            var fcFiltered = fabricCode.Where(x => x.fc_unitprice != 0).OrderBy(x => x.fc_desc).ThenBy(x => x.fc_code);
            int tLN = 0;
            string tFCDesc = null;
            bool tFirstRow = true;
            string str = string.Empty;
            string LastRow = string.Empty;
            System.Globalization.CultureInfo localCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            int[] myNumberSizes = { 3, 3, 3 };
            localCulture.NumberFormat.CurrencyDecimalDigits = 2;
            localCulture.NumberFormat.CurrencyGroupSizes = myNumberSizes;
            localCulture.NumberFormat.CurrencySymbol = "$";

            foreach (var fc in fcFiltered)
            {
                var price1 = priceOption == 1 ? fc.fc_unitprice : fc.fc_instprice;
                var price2 = priceOption == 1 ? fc.fc_unitprice2 : fc.fc_instprice2;

                if (tFCDesc != fc.fc_desc)
                {
                    tLN = 1;
                    if (!tFirstRow)
                        str += "</table>";
                    if (tFirstRow)
                        tFirstRow = false;
                    str += @"<br/><table class='reports'>
                 <tr>
                        <th colspan = '8' style='text-align:center'>" + fc.fc_desc + @"</th>
                 </tr>
                 <tr>
                        <td>S/N</td>
                        <td>Color Code</td>
                        <td>Code No.</td>
                        <td>Size</td>
                        <td>Max Lengtd</td>
                        <td>Normal Cord String</td>
                        <td>1'' Ladder Tape</td>
                        <td>Additional Charges</td>
                </tr>
                <tr>
                        <td>" + tLN + @"</td>
                        <td>" + fc.fc_colour + @"</td>
                        <td>" + fc.fc_code + @"</td>
                        <td>" + fc.fc_size + @"</td>
                        <td>" + fc.fc_width + @"</td>
                        <td>" + price1.ToString("C", localCulture) + @" psf \ min " + fabricType.fc_minimum + @"</td>
                        <td>" + price2.ToString("C", localCulture) + @" psf \ min " + fabricType.fc_minimum + @"</td>
                        <td>" + fc.fc_rmk + @"</td>
                </tr>";

                }
                else
                {
                    str += @" <tr>
                        <td>" + tLN++ + @"</td>
                        <td>" + fc.fc_colour + @"</td>
                        <td>" + fc.fc_code + @"</td>
                        <td>" + fc.fc_size + @"</td>
                        <td>" + fc.fc_width + @"</td>
                        <td>" + price1.ToString("C", localCulture) + @" psf \ min " + fabricType.fc_minimum + @"</td>
                        <td>" + price2.ToString("C", localCulture) + @" psf \ min " + fabricType.fc_minimum + @"</td>
                        <td>" + fc.fc_rmk + @"</td>
                </tr>";
                }

                tFCDesc = fc.fc_desc;
            }
            if (fcFiltered.Count() > 0)
                str += "</table>";

            return str;
        }

        private string GetSystemSetUpValueBySetUpText(List<SystemSetupUIMapper> systemSetupDetails, string setupText)
        {
            return systemSetupDetails.Where(x => x.setup_txt == setupText).FirstOrDefault().setup_value;
        }

        private string FormatAddress(string tAdd1, string tAdd2, string tAdd3, string tAdd4, string tAdd5)
        {
            string tAddress = null;
            string FormatAddress = "";

            if (!string.IsNullOrEmpty(tAdd1) || !string.IsNullOrEmpty(tAdd2))
            {
                if ((string.IsNullOrEmpty(tAdd4) && string.IsNullOrEmpty(tAdd5)) || ((tAdd4 == "Singapore") || (tAdd5 == "Singapore")))
                {
                    if (!string.IsNullOrEmpty(tAdd3))
                    {
                        if (!string.IsNullOrEmpty(tAdd2))
                        {
                            FormatAddress = tAdd1 + "<br/>" + tAdd2 + "<br/>" + "Singapore " + tAdd3;
                        }
                        else
                        {
                            FormatAddress = tAdd1 + "<br/>" + "Singapore " + tAdd3;
                        }
                    }
                    else
                    {
                        FormatAddress = tAdd1 + "<br/>" + tAdd2;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(tAdd1))
                        tAddress = tAdd1;
                    if (!string.IsNullOrEmpty(tAdd2))
                    {
                        if (!string.IsNullOrEmpty(tAddress))
                        {
                            tAddress = tAddress + "<br/>" + tAdd2;
                        }
                        else
                        {
                            tAddress = tAdd2;
                        }
                    }
                    tAddress = tAddress + "<br/>";
                    if (!string.IsNullOrEmpty(tAdd3))
                    {
                        if (!string.IsNullOrEmpty(tAddress))
                        {
                            tAddress = tAddress + tAdd3;
                        }
                        else
                        {
                            tAddress = tAdd3;
                        }
                    }
                    if (!string.IsNullOrEmpty(tAdd4))
                    {
                        if (!string.IsNullOrEmpty(tAddress))
                        {
                            if (!string.IsNullOrEmpty(tAdd3))
                            {
                                tAddress = tAddress + " " + tAdd4;

                            }
                            else
                            {
                                tAddress = tAddress + tAdd4;
                            }
                        }
                        else
                        {
                            tAddress = tAdd4;
                        }
                    }
                    if (!string.IsNullOrEmpty(tAdd5))
                    {
                        if (!string.IsNullOrEmpty(tAddress))
                        {
                            if (!string.IsNullOrEmpty(tAdd4))
                            {
                                tAddress = tAddress + " " + tAdd5;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(tAdd3))
                                {
                                    tAddress = tAddress + " " + tAdd5;
                                }
                                else
                                {
                                    tAddress = tAddress + tAdd5;
                                }
                            }
                        }
                        else
                        {
                            tAddress = tAdd5;
                        }
                    }
                    FormatAddress = tAddress;
                }
            }
            else
            {
                FormatAddress = "";
            }

            return FormatAddress;
        }
    }
}


