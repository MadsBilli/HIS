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
    public partial class Preview : System.Web.UI.Page
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
            if (fcType == 1)
                FormatFCPrintForRollerBlind(fabricType, fabricCode, priceOption);
           
        }
        private void FormatFCPrintForRollerBlind(FabricTypeUIMapper fabricType, List<FabricCodeUIMapper> fabricCode, int priceOption)
        {
            ltlHeading.Text = "<u>Roller Blind Price List</u>";
            ltlHeader.Text = fabricType.fc_header;
            var html = @"<table class='reports'>
                <tr>
                    <th>Fabric Series</th>
                    <th>Chain</th>
                    <th>Spring</th>
                    <th>Spring<br />
                        Chain</th>
                    <th>Fixas stop<br />
                        spring</th>
                    <th>Max. Fabric<br />
                        Width</th>
                    <th>Material</th>
                </tr>" + FormatTable(fabricCode, priceOption) + @"
            </table>";
            ltlMain.Text = html;
        }

        private string FormatTable(List<FabricCodeUIMapper> fabricCode, int priceOption)
        {
            System.Globalization.CultureInfo localCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();

            int[] myNumberSizes = { 3, 3, 3 };
            localCulture.NumberFormat.CurrencyDecimalDigits = 2;
            localCulture.NumberFormat.CurrencyGroupSizes = myNumberSizes;
            localCulture.NumberFormat.CurrencySymbol = "$";
            
            var fcFiltered = fabricCode.Where(x => x.fc_unitprice != 0).OrderBy(x => x.fc_desc).ThenBy(x => x.fc_code);
            int tLN = 0;
            string tFCDesc = null;
            string tFCCode_End = "";
            string tField1 = null;
            string tField2 = null;
            string tField3 = null;
            string tField4 = null;
            string tField5 = null;
            string tField6 = null;
            string tField7 = null;
            string tField8 = null;
            string tField9 = null;
            string tField10 = null;
            bool tFirstRow = true;
            string str = string.Empty;
            string tfcCode_Start = "";
            string LastRow = string.Empty;
            foreach (var fc in fcFiltered)
            {
                if (tFCDesc != fc.fc_desc)
                {
                    tfcCode_Start = tFCCode_End = fc.fc_code;
                    if (LastRow != string.Empty)
                    {
                        str += LastRow;
                        LastRow = string.Empty;
                    }
                    if (!tFirstRow)
                    {
                        str += "<tr><td colspan='7' style='text-align: left; padding-left: 10px'></td></tr>";
                    }
                    str += "<tr><td colspan='7' style='text-align: left; padding-left: 10px'><b>" + fc.fc_desc + "</b></td></tr>";
                    LastRow = "<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td></tr>";
                    var fcCode = tfcCode_Start.Replace("RB-", "") + " - " + fc.fc_code.Replace("RB-", "");

                    if (priceOption == 1)
                    {
                        LastRow = String.Format(LastRow, fcCode, fc.fc_unitprice.ToString("C",localCulture), fc.fc_unitprice2.ToString("C",localCulture), fc.fc_unitprice3.ToString("C",localCulture), fc.fc_unitprice4.ToString("C",localCulture), fc.fc_width, fc.fc_rmk);
                    }
                    else
                    {
                        LastRow = String.Format(LastRow, fcCode, fc.fc_instprice.ToString("C",localCulture), fc.fc_instprice2.ToString("C",localCulture), fc.fc_instprice3.ToString("C",localCulture), fc.fc_instprice4.ToString("C",localCulture), fc.fc_width, fc.fc_rmk);
                    }
                }
                else
                {
                    if ((tField1 == fc.fc_unitprice.ToString() &&
                    tField2 == fc.fc_unitprice2.ToString() &&
                    tField3 == fc.fc_unitprice3.ToString() &&
                    tField4 == fc.fc_unitprice4.ToString() && priceOption == 1) ||
                    (tField5 == fc.fc_instprice.ToString() &&
                    tField6 == fc.fc_instprice2.ToString() &&
                    tField7 == fc.fc_instprice3.ToString() &&
                    tField8 == fc.fc_instprice4.ToString() &&
                    tField9 == fc.fc_width &&
                    tField10 == Convert.ToString(fc.fc_rmk) && priceOption == 2))
                    {
                        LastRow = "<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td></tr>";
                        var fcCode = tfcCode_Start.Replace("RB-", "") + " - " + fc.fc_code.Replace("RB-", "");
                        if (priceOption == 1)
                        {
                            LastRow = String.Format(LastRow, fcCode, fc.fc_unitprice.ToString("C", localCulture), fc.fc_unitprice2.ToString("C", localCulture), fc.fc_unitprice3.ToString("C", localCulture), fc.fc_unitprice4.ToString("C", localCulture), fc.fc_width, fc.fc_rmk);
                        }
                        else
                        {
                            LastRow = String.Format(LastRow, fcCode, fc.fc_instprice.ToString("C", localCulture), fc.fc_instprice2.ToString("C", localCulture), fc.fc_instprice3.ToString("C", localCulture), fc.fc_instprice4.ToString("C", localCulture), fc.fc_width, fc.fc_rmk);
                        }
                    }
                    else
                    {
                        tfcCode_Start = tFCCode_End = fc.fc_code;
                        if (LastRow != string.Empty)
                        {
                            str += LastRow;
                            LastRow = string.Empty;
                        }

                        LastRow = "<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td></tr>";
                        var fcCode = tfcCode_Start.Replace("RB-", "") + " - " + fc.fc_code.Replace("RB-", "");
                        if (priceOption == 1)
                        {
                            LastRow = String.Format(LastRow, fcCode, fc.fc_unitprice.ToString("C", localCulture), fc.fc_unitprice2.ToString("C", localCulture), fc.fc_unitprice3.ToString("C", localCulture), fc.fc_unitprice4.ToString("C", localCulture), fc.fc_width, fc.fc_rmk);
                        }
                        else
                        {
                            LastRow = String.Format(LastRow, fcCode, fc.fc_instprice.ToString("C", localCulture), fc.fc_instprice2.ToString("C", localCulture), fc.fc_instprice3.ToString("C", localCulture), fc.fc_instprice4.ToString("C", localCulture), fc.fc_width, fc.fc_rmk);
                        }
                    }
                }
                if (tFirstRow)
                {
                    tFirstRow = false;
                }
                tLN++;
                if (tLN == fcFiltered.Count())
                {
                    str += LastRow;
                }

                tFCDesc = fc.fc_desc;
                tField1 = fc.fc_unitprice.ToString();
                tField2 = fc.fc_unitprice2.ToString();
                tField3 = fc.fc_unitprice3.ToString();
                tField4 = fc.fc_unitprice4.ToString();
                tField5 = fc.fc_instprice.ToString();
                tField6 = fc.fc_instprice2.ToString();
                tField7 = fc.fc_instprice3.ToString();
                tField8 = fc.fc_instprice4.ToString();
                tField9 = fc.fc_width;
                tField10 = Convert.ToString(fc.fc_rmk);
            }
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