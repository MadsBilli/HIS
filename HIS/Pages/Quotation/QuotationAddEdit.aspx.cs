using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using HIS.UI.SessionManagement;
using HIS.UI.Common;
using HIS.UI.Assembler.Quotation;
using HIS.UI.Mapper.Quotation;
using System.Web.Services;

namespace HIS.Pages.Quotation
{
    public partial class QuotationAddEdit : System.Web.UI.Page
    {
        private string taxRate = string.Empty;
        private string Quotedelivery = string.Empty;
        private string QuoteValidity = string.Empty;
        private string Quotedeposit = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    BindDropDownList();
                    //BindDataGrid();
                    InitialSetup();
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                //Do nothing.
            }
            catch (Exception ex)
            {
                string ErrorMessage = UI.ExceptionHandling.ExceptionMethodHandler.HandlesException(ex);
                ucValidationMessage.ErrorMessage = ErrorMessage;
                ucValidationMessage.Show();
            }
        }

        private void InitialSetup()
        {
            quote_date.Value = DateTime.Now;
            quote_cust_emp_name_seq.SelectedValue = Common.NameSequence.GFM.ToString();
            quote_curr.SelectedValue = "100";
            quote_by.SelectedValue = new SessionManager().GetSessionUserName();//check
            quote_statusid.SelectedValue = "0";
            quote_gst_pencentage.SelectedValue = taxRate;
            quote_deliver.Text = Quotedelivery;
            quote_validty.Text = QuoteValidity;
            quote_terms.Text = Quotedeposit;
            quote_deliver_sel.SelectedValue = "Weeks";
        }

        private void BindDropDownList()
        {
            CommonFunctions.BindEnumToddl<Common.NameSequence>(quote_cust_emp_name_seq, false, false);
            CommonFunctions.BindEnumToddl<Common.Salutation>(quote_cust_emp_name_salutation, false);
            CommonFunctions.BindEnumToddl<Common.DeliverySelection>(quote_deliver_sel, false, false);

            var res = new QuotationAssembler().GetQuotationScreenListValues();
            if (res.Tables.Count > 0 && res.Tables[0] != null && res.Tables[0].Rows.Count > 0)
            {
                //wty
                quote_wrty.DataSource = res.Tables[0].AsDataView();
                quote_wrty.DataValueField = "wtyID";
                quote_wrty.DataTextField = "wtyDesc";
                quote_wrty.DataBind();
                CommonFunctions.InsertEmptyValueToddl(quote_wrty);
            }
            if (res.Tables.Count > 1 && res.Tables[1] != null && res.Tables[1].Rows.Count > 0)
            {
                //tnc
                quote_tnc.DataSource = res.Tables[1].AsDataView();
                quote_tnc.DataValueField = "int_ID";
                quote_tnc.DataTextField = "txtDescription";
                quote_tnc.DataBind();
                CommonFunctions.InsertEmptyValueToddl(quote_tnc);
            }
            if (res.Tables.Count > 2 && res.Tables[2] != null && res.Tables[2].Rows.Count > 0)
            {
                quote_statusid.DataSource = res.Tables[2].AsDataView();
                quote_statusid.DataValueField = "quote_statusid";
                quote_statusid.DataTextField = "quote_statusdesc";
                quote_statusid.DataBind();
                CommonFunctions.InsertEmptyValueToddl(quote_statusid);
            }
            if (res.Tables.Count > 3 && res.Tables[3] != null && res.Tables[3].Rows.Count > 0)
            {
                quote_by.DataSource = res.Tables[3].AsDataView();
                quote_by.DataValueField = "emp_salesman_id";
                quote_by.DataTextField = "emp_name";
                quote_by.DataBind();
                CommonFunctions.InsertEmptyValueToddl(quote_by);
            }
            if (res.Tables.Count > 4 && res.Tables[4] != null && res.Tables[4].Rows.Count > 0)
            {
                quote_by2.DataSource = res.Tables[4].AsDataView();
                quote_by2.DataValueField = "emp_salesman_id";
                quote_by2.DataTextField = "emp_salesman_id";
                quote_by2.DataBind();
                CommonFunctions.InsertEmptyValueToddl(quote_by2);
            }
            if (res.Tables.Count > 5 && res.Tables[5] != null && res.Tables[5].Rows.Count > 0)
            {
                quote_curr.DataSource = res.Tables[5].AsDataView();
                quote_curr.DataValueField = "currency_id";
                quote_curr.DataTextField = "currency_type";
                quote_curr.DataBind();
                CommonFunctions.InsertEmptyValueToddl(quote_curr);
            }
            if (res.Tables.Count > 6 && res.Tables[6] != null && res.Tables[6].Rows.Count > 0)
            {
                quote_gst_pencentage.DataSource = res.Tables[6].AsDataView();
                quote_gst_pencentage.DataValueField = "tax_rate";
                quote_gst_pencentage.DataTextField = "tax_rate";
                quote_gst_pencentage.DataBind();
                CommonFunctions.InsertEmptyValueToddl(quote_gst_pencentage);
                taxRate = res.Tables[6].Rows[0][0].ToString();
            }
            if (res.Tables.Count > 7 && res.Tables[7] != null && res.Tables[7].Rows.Count > 0)
            {
                var val = (from r in res.Tables[7].AsEnumerable()
                           where r["setup_txt"] == "Quote_delivery"
                           select r["setup_value"]);
                Quotedelivery = val != null && val.Count() > 0 ? val.FirstOrDefault().ToString() : string.Empty;
                val = (from r in res.Tables[7].AsEnumerable()
                       where r["setup_txt"] == "Quote_Validity"
                       select r["setup_value"]);
                QuoteValidity = val != null && val.Count() > 0 ? val.FirstOrDefault().ToString() : string.Empty;
                val = (from r in res.Tables[7].AsEnumerable()
                       where r["setup_txt"] == "Quote_deposit"
                       select r["setup_value"]);
                Quotedeposit = val != null && val.Count() > 0 ? val.FirstOrDefault().ToString() : string.Empty;
            }
            if (res.Tables.Count > 9 && res.Tables[9] != null && res.Tables[9].Rows.Count > 0)
            {
                //Country
                quote_des_add5.DataSource = res.Tables[9].AsDataView();
                quote_des_add5.DataValueField = "city_code";
                quote_des_add5.DataTextField = "city_desc";
                quote_des_add5.DataBind();
                CommonFunctions.InsertEmptyValueToddl(quote_des_add5);
                quote_site_add5.DataSource = res.Tables[9].AsDataView();
                quote_site_add5.DataValueField = "city_code";
                quote_site_add5.DataTextField = "city_desc";
                quote_site_add5.DataBind();
                CommonFunctions.InsertEmptyValueToddl(quote_site_add5);
            }
            if (res.Tables.Count > 10 && res.Tables[10] != null && res.Tables[10].Rows.Count > 0)
            {
                //Unit
                f_measurement.DataSource = res.Tables[10].AsDataView();
                f_measurement.DataValueField = "unit_id";
                f_measurement.DataTextField = "unit_type";
                f_measurement.DataBind();
                CommonFunctions.InsertEmptyValueToddl(f_measurement);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            QuotationUIMapper quote = new QuotationUIMapper();
            quote.quote_id = hdnQuote_id.Value;
            quote.quote_cust_id = quote_cust_id.Text.Trim();
            quote.quote_cust_name = quote_cust_name.Text.Trim();
            quote.quote_cust_emp_name_seq = Convert.ToString(quote_cust_emp_name_seq.SelectedValue);
            quote.quote_cust_emp_name_salutation = Convert.ToString(quote_cust_emp_name_salutation.SelectedValue);
            quote.quote_cust_emp_name_given = quote_cust_emp_name_given.Text.Trim();
            quote.quote_cust_emp_name_middle = quote_cust_emp_name_middle.Text.Trim();
            quote.quote_cust_emp_name_family = quote_cust_emp_name_family.Text.Trim();
            quote.quote_cust_emp_name = quote_cust_emp_name.Text.Trim();
            quote.quote_cust_emp_tel = quote_cust_emp_tel.Text.Trim();
            quote.quote_cust_emp_tel_ext = quote_cust_emp_tel_ext.Text.Trim();
            quote.quote_cust_emp_hp = quote_cust_emp_hp.Text.Trim();
            quote.quote_cust_emp_fax = quote_cust_emp_fax.Text.Trim();
            quote.quote_cust_emp_email = quote_cust_emp_email.Text.Trim();
            quote.quote_subject = quote_subject.Text.Trim();
            quote.quote_date = quote_date.Value;
            quote.quote_reminder1 = quote_reminder1.Value;
            quote.quote_reminder2 = quote_reminder2.Value;
            quote.quote_statusid = CommonFunctions.ConvertToInt16(Convert.ToString(quote_statusid.SelectedValue));
            quote.quote_replieddate = quote_replieddate.Value;
            quote.quote_validty = CommonFunctions.ConvertToInt16(quote_validty.Text.Trim());
            quote.quote_terms = CommonFunctions.ConvertToInt16(quote_terms.Text.Trim());
            quote.quote_wrty = CommonFunctions.ConvertToInt16(Convert.ToString(quote_wrty.SelectedValue));
            quote.quote_deliver = quote_deliver.Text.Trim();
            quote.quote_deliver_sel = Convert.ToString(quote_deliver_sel.SelectedValue);
            quote.quote_remark = quote_remark.Text.Trim();
            quote.quote_total = quote_total.Checked;
            quote.quote_by = Convert.ToString(quote_by.SelectedValue);
            quote.quote_rejectreason = quote_rejectreason.Text.Trim();
            quote.quote_inrmk = quote_inrmk.Text.Trim();
            quote.quote_cost = CommonFunctions.ConvertToDouble(quote_cost.Text.Trim());
            quote.quote_amt = CommonFunctions.ConvertToDouble(quote_amt.Text.Trim());
            quote.quote_margin = CommonFunctions.ConvertToDouble(quote_margin.Text.Trim());
            quote.quote_margin_pctg = CommonFunctions.ConvertToDouble(quote_margin_pctg.Text.Trim());
            quote.quote_us = quote_us.Checked;
            quote.quote_by2 = quote_by2.SelectedValue;
            quote.quote_sales_rmk = quote_sales_rmk.Text.Trim();
            quote.quote_cust_ref = quote_cust_ref.Text.Trim();
            quote.quote_confident_lvl = CommonFunctions.ConvertToSingle(Convert.ToString(quote_confident_lvl.SelectedValue));
            quote.quote_showGST = quote_showGST.Checked;
            quote.quote_gst_pencentage = CommonFunctions.ConvertToSingle(Convert.ToString(quote_gst_pencentage.SelectedValue));
            quote.quote_gst = CommonFunctions.ConvertToDouble(quote_gst.Text.Trim());
            quote.inv_num = inv_num.Text.Trim();
            quote.quote_curr = CommonFunctions.ConvertToInt(Convert.ToString(quote_curr.SelectedValue));
            quote.quote_rate = CommonFunctions.ConvertToSingle(quote_rate.Text.Trim());
            quote.quote_tnc = CommonFunctions.ConvertToInt(Convert.ToString(quote_tnc.SelectedValue));
            quote.quote_des_add1 = quote_des_add1.Text.Trim();
            quote.quote_des_add2 = quote_des_add2.Text.Trim();
            quote.quote_des_add3 = quote_des_add3.Text.Trim();
            quote.quote_des_add4 = quote_des_add4.Text.Trim();
            quote.quote_des_add5 = quote_des_add5.Text.Trim();
            quote.quote_site_add1 = quote_site_add1.Text.Trim();
            quote.quote_site_add2 = quote_site_add2.Text.Trim();
            quote.quote_site_add3 = quote_site_add3.Text.Trim();
            quote.quote_site_add4 = quote_site_add4.Text.Trim();
            quote.quote_site_add5 = quote_site_add5.Text.Trim();
            quote.wo_id = wo_id.Text.Trim();
            new QuotationAssembler().SaveQuote(quote, Common.Operation.AddNew.ToString());
        }

        private void CalculatePrice(QuotationItemUIMapper quotes, string intputType)
        {
            if (string.IsNullOrEmpty(quotes.quote_item_amt.ToString())) quotes.quote_item_amt = 0;
            Single Qty = 0;
            if ((string.IsNullOrEmpty(quotes.quote_item_qty.ToString()) || quotes.quote_item_qty == 0) && quotes.quote_item_amt != 0)
                quotes.quote_item_qty = 1;

            string TempMeasurement = string.Empty;
            Single TempFormual;
            int TempRoundUp;
            int TempTotAmtRoundUp;
            Single MinimunMesurement = 0;
            string tType = string.Empty;

            int cal = 0;

            if (string.IsNullOrEmpty(quotes.quote_item_model))
            {
            }
            else if (quotes.quote_item_model == "VB")
            {
            }
            else
            {
            }
            TempRoundUp = CommonFunctions.ConvertToInt(f_qty_roundup.Text.Trim());
            TempTotAmtRoundUp = 2;

            switch (intputType)
            {
                case "Hight":
                case "Width":
                case "SetNo":
                    cal = 100;
                    break;
                case "Qty":
                case "Price":
                    cal = 200;
                    break;
            }

            if (cal == 100)
            {
                TempMeasurement = f_measurement.SelectedValue;
                TempFormual = CommonFunctions.ConvertToSingle(f_formular.Text.Trim());

                if ((quotes.quote_item_hight > 0 && quotes.quote_item_width > 0) || (quotes.quote_item_width > 0 && TempMeasurement == "Feet"))
                {
                    if (quotes.quote_item_setno == 0 || string.IsNullOrEmpty(quotes.quote_item_setno.ToString()))
                        quotes.quote_item_setno = 1;

                    if (string.IsNullOrEmpty(quotes.quote_item_amt.ToString()))
                        quotes.quote_item_amt = 0;

                    switch (TempMeasurement)
                    {
                        case "Inch":
                            quotes.quote_item_munit = 1;
                            quotes.quote_item_qty = (Single)Math.Round((((quotes.quote_item_hight * quotes.quote_item_width) / TempFormual) * quotes.quote_item_setno), TempRoundUp);
                            if (quotes.quote_item_qty < MinimunMesurement)
                                quotes.quote_item_qty = MinimunMesurement;

                            quotes.quote_item_tamt = Math.Round(quotes.quote_item_qty * quotes.quote_item_amt, TempTotAmtRoundUp);
                            quotes.quote_item_margin = Math.Round(quotes.quote_item_qty * (quotes.quote_item_amt - quotes.quote_item_vcost), TempTotAmtRoundUp);
                            break;
                        case "Millimeter":
                            quotes.quote_item_munit = 2;
                            quotes.quote_item_qty = (Single)Math.Round(((((quotes.quote_item_hight / 1000) * (quotes.quote_item_width / 1000)) * TempFormual) * quotes.quote_item_setno), TempRoundUp);
                            if (quotes.quote_item_qty < MinimunMesurement)
                                quotes.quote_item_qty = MinimunMesurement;

                            quotes.quote_item_tamt = Math.Round(quotes.quote_item_qty * quotes.quote_item_amt, TempTotAmtRoundUp);
                            quotes.quote_item_margin = Math.Round(quotes.quote_item_qty * (quotes.quote_item_amt - quotes.quote_item_vcost), TempTotAmtRoundUp);
                            break;
                        case "Feet":
                            quotes.quote_item_munit = 3;
                            quotes.quote_item_qty = (Single)Math.Round((quotes.quote_item_width / TempFormual * quotes.quote_item_setno), TempRoundUp);
                            if (quotes.quote_item_qty < MinimunMesurement)
                                quotes.quote_item_qty = MinimunMesurement;

                            quotes.quote_item_tamt = Math.Round(quotes.quote_item_qty * quotes.quote_item_amt, TempTotAmtRoundUp);
                            quotes.quote_item_margin = Math.Round(quotes.quote_item_qty * (quotes.quote_item_amt - quotes.quote_item_vcost), TempTotAmtRoundUp);
                            break;
                    }
                }
            }
            if (cal == 200)
            {
                if (quotes.quote_item_amt == 0)
                {
                    quotes.quote_item_tamt = 0;
                    quotes.quote_item_margin = 0;
                }
                else
                {
                    if (quotes.quote_item_qty == 0)
                    {
                        quotes.quote_item_qty = 1;
                        quotes.quote_item_tamt = Math.Round((quotes.quote_item_qty * quotes.quote_item_amt), TempTotAmtRoundUp);
                        quotes.quote_item_margin = Math.Round(quotes.quote_item_qty * (quotes.quote_item_amt - quotes.quote_item_vcost), TempTotAmtRoundUp);
                    }
                    else
                    {
                        quotes.quote_item_tamt = Math.Round((quotes.quote_item_qty * quotes.quote_item_amt), TempTotAmtRoundUp);
                        quotes.quote_item_margin = Math.Round(quotes.quote_item_qty * (quotes.quote_item_amt - quotes.quote_item_vcost), TempTotAmtRoundUp);
                    }
                }
            }

            /*loop grid to find 
               tItemCount = tItemCount + 1
                tTltAmt = tTltAmt + !quote_item_tamt
                tTltlCost = tTltlCost + (!quote_item_qty * !quote_item_vcost)
             * 
               'Total
                Forms!fm_quote_list!txtItemCount = tItemCount
                Forms!fm_quote_list!quote_amt = tTltAmt
                Forms!fm_quote_list!quote_cost = tTltlCost
                If Forms!fm_quote_list!quote_gst_pencentage <> 0 Then
                    Forms!fm_quote_list!quote_gst = RoundToLarger(Forms!fm_quote_list!quote_amt * Forms!fm_quote_list!quote_gst_pencentage, 2)
                Else
                    Forms!fm_quote_list!quote_gst = 0
                End If
                HideLeadingSpace = True
                Forms!fm_quote_list!txtTotAmtWords = ConvertCurr(Nz(Forms!fm_quote_list!txtQTTotalAmt, 0))

                'Margin
                Forms!fm_quote_list!quote_margin = (tTltAmt - tTltlCost)
                If Forms!fm_quote_list!quote_margin > 0 Then
                    Forms!fm_quote_list!quote_margin_pctg = (Forms!fm_quote_list!quote_margin / tTltAmt)
                Else
                    Forms!fm_quote_list!quote_margin_pctg = 0
                End If
             * */
        }

        private void FillFields()
        {
            var quote = new QuotationAssembler().GetQuoteDetails(hdnQuote_id.Value);

            hdnQuote_id.Value = quote.quote_id;
            quote_cust_id.Text = quote.quote_cust_id;
            quote_cust_name.Text = quote.quote_cust_name;
            if (quote_cust_emp_name_seq.Items.FindByValue(quote.quote_cust_emp_name_seq) != null)
                quote_cust_emp_name_seq.SelectedValue = quote.quote_cust_emp_name_seq;
            if (quote_cust_emp_name_salutation.Items.FindByValue(quote.quote_cust_emp_name_salutation) != null)
                quote_cust_emp_name_salutation.SelectedValue = quote.quote_cust_emp_name_salutation;
            quote_cust_emp_name_given.Text = quote.quote_cust_emp_name_given;
            quote_cust_emp_name_middle.Text = quote.quote_cust_emp_name_middle;
            quote_cust_emp_name_family.Text = quote.quote_cust_emp_name_family;
            quote_cust_emp_name.Text = quote.quote_cust_emp_name;
            quote_cust_emp_tel.Text = quote.quote_cust_emp_tel;
            quote_cust_emp_tel_ext.Text = quote.quote_cust_emp_tel_ext;
            quote_cust_emp_hp.Text = quote.quote_cust_emp_hp;
            quote_cust_emp_fax.Text = quote.quote_cust_emp_fax;
            quote_cust_emp_email.Text = quote.quote_cust_emp_email;
            quote_subject.Text = quote.quote_subject;
            quote_date.Value = quote.quote_date;
            quote_reminder1.Value = quote.quote_reminder1;
            quote_reminder2.Value = quote.quote_reminder2;
            if (quote_statusid.Items.FindByValue(quote.quote_statusid.ToString()) != null)
                quote_statusid.SelectedValue = quote.quote_statusid.ToString();
            quote_replieddate.Value = quote.quote_replieddate;
            quote_validty.Text = quote.quote_validty.ToString();
            quote_terms.Text = quote.quote_terms.ToString();
            if (quote_wrty.Items.FindByValue(quote.quote_wrty.ToString()) != null)
                quote_wrty.SelectedValue = quote.quote_wrty.ToString();
            quote_deliver.Text = quote.quote_deliver;
            if (quote_deliver_sel.Items.FindByValue(quote.quote_deliver_sel.ToString()) != null)
                quote_deliver_sel.SelectedValue = quote.quote_deliver_sel;
            quote_remark.Text = quote.quote_remark;
            quote_total.Checked = quote.quote_total;
            if (quote_by.Items.FindByValue(quote.quote_by.ToString()) != null)
                quote_by.SelectedValue = quote.quote_by;
            quote_rejectreason.Text = quote.quote_rejectreason;
            quote_inrmk.Text = quote.quote_inrmk.ToString();
            quote_cost.Text = quote.quote_cost.ToString();
            quote_amt.Text = quote.quote_amt.ToString();
            quote_margin.Text = quote.quote_margin.ToString();
            quote_margin_pctg.Text = quote.quote_margin_pctg.ToString();
            quote_us.Checked = quote.quote_us;
            quote_by2.SelectedValue = quote.quote_by2;
            quote_sales_rmk.Text = quote.quote_sales_rmk;
            quote_cust_ref.Text = quote.quote_cust_ref;
            if (quote_confident_lvl.Items.FindByValue(quote.quote_confident_lvl.ToString()) != null)
                quote_confident_lvl.SelectedValue = quote.quote_confident_lvl.ToString();
            quote_showGST.Checked = quote.quote_showGST;
            if (quote_gst_pencentage.Items.FindByValue(quote.quote_gst_pencentage.ToString()) != null)
                quote_gst_pencentage.SelectedValue = quote.quote_gst_pencentage.ToString();
            quote_gst.Text = quote.quote_gst.ToString();
            inv_num.Text = quote.inv_num;
            if (quote_curr.Items.FindByValue(quote.quote_curr.ToString()) != null)
                quote_curr.SelectedValue = quote.quote_curr.ToString();
            quote_rate.Text = quote.quote_rate.ToString();
            if (quote_tnc.Items.FindByValue(quote.quote_tnc.ToString()) != null)
                quote_tnc.SelectedValue = quote.quote_tnc.ToString();
            quote_des_add1.Text = quote.quote_des_add1;
            quote_des_add2.Text = quote.quote_des_add2;
            quote_des_add3.Text = quote.quote_des_add3;
            quote_des_add4.Text = quote.quote_des_add4;
            quote_des_add5.Text = quote.quote_des_add5;
            quote_site_add1.Text = quote.quote_site_add1;
            quote_site_add2.Text = quote.quote_site_add2;
            quote_site_add3.Text = quote.quote_site_add3;
            quote_site_add4.Text = quote.quote_site_add4;
            quote_site_add5.Text = quote.quote_site_add5;
            wo_id.Text = quote.wo_id.ToString();
        }
    }
}