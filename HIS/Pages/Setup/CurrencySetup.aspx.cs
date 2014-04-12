using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HIS.UI.Assembler.Setup;
using HIS.UI.Common;
using HIS.UI.Mapper.Setup;
using System.Web.Services;
using HIS.UserControl;

namespace HIS.Pages.Setup
{
    public partial class CurrencySetup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitialisePage();  
            }
        }

        private void InitialisePage()
        {
            var res = new CurrencySetupAssembler().GetCurrencySetupDetails();
            if (res.Tables.Count > 0 && res.Tables[0] != null && res.Tables[0].Rows.Count > 0)
            {
                FillFieldsAndGrid(res.Tables[0]);
            }
            if (res.Tables.Count > 1 && res.Tables[1] != null && res.Tables[1].Rows.Count > 0)
            {  
                ddl_f_currency_id.DataSource = res.Tables[1].AsDataView();
                ddl_f_currency_id.DataValueField = "currency_id";
                ddl_f_currency_id.DataTextField = "currency_desc";
                ddl_f_currency_id.DataBind();
                CommonFunctions.InsertEmptyValueToddl(ddl_f_currency_id);

                DataView dv = new DataView();
                dv=  res.Tables[1].AsDataView();
                ddl_ex_currency_desc.DataSource = dv;
                ddl_ex_currency_desc.DataValueField = "currency_id";
                ddl_ex_currency_desc.DataTextField = "currency_desc";
                ddl_ex_currency_desc.DataBind();
            }

            if (res.Tables.Count > 2 && res.Tables[2] != null && res.Tables[2].Rows.Count > 0)
            { 
                ddl_f_currency_gl_code.DataSource = res.Tables[2].AsDataView();
                ddl_f_currency_gl_code.DataValueField = "acc_code";
                ddl_f_currency_gl_code.DataTextField = "acc_currency";
                ddl_f_currency_gl_code.DataBind();
                CommonFunctions.InsertEmptyValueToddl(ddl_f_currency_gl_code);
            }

            if (res.Tables.Count > 3 && res.Tables[3] != null && res.Tables[3].Rows.Count > 0)
            {
                ViewState["ExchangeRate"] = res.Tables[3];
                ddl_ex_currency_desc.SelectedIndex = 1;
                FillExchangeDetails();
            }
        }

        private void FillExchangeDetails()
        {
            if (ViewState["ExchangeRate"] != null)
            {
                DataTable dt = (DataTable)ViewState["ExchangeRate"];
                DataView dvEx = dt.AsDataView();
                dvEx.RowFilter = "currency_id = " + ddl_ex_currency_desc.SelectedValue;
                gvExchangeRate.DataSource = dvEx;
                gvExchangeRate.DataBind();


            }
        }

        private void FillFieldsAndGrid(DataTable dt)
        {
            var homeCurrency = dt.AsEnumerable().Where(i => Convert.ToBoolean(i["currency_home"])).Select(k => k);

            if(homeCurrency.Count() > 0)
            {
                var hc = homeCurrency.FirstOrDefault();
                ddl_f_currency_id.SelectedValue             = hc["currency_id"].ToString();
                txt_f_currency_code.Text                    = hc["currency_code"].ToString();
                txt_f_currency_symbol.Text                  = hc["currency_symbol"].ToString();
                ddl_f_currency_position.SelectedValue       = hc["currency_position"].ToString();
                txt_f_currency_format.Text                  = hc["currency_format"].ToString();
                ddl_f_currency_decimal_sepa.SelectedValue   = hc["currency_decimal_sepa"].ToString();
                ddl_f_currency_thousand_sepa.SelectedValue  = hc["currency_thousand_sepa"].ToString();
                ddl_f_currency_decimal_place.SelectedValue  = hc["currency_decimal_place"].ToString();
                ddl_f_currency_gl_code.SelectedValue        = hc["gl_acc_code"].ToString();
            }

            var gridRec = dt.AsEnumerable().Where(i => !Convert.ToBoolean(i["currency_home"])).Select(k => k);

            var dv = dt.AsDataView();
            dv.RowFilter = "currency_home = 0";

            gvCurrencySetup.DataSource = dv;
            gvCurrencySetup.DataBind();

        }

        protected void gvCurrencySetupGridRowDataBoundEneventHandler(object sender, GridViewRowEventArgs e)
        {
            try
            {
                GridViewRow row = e.Row;
                if (row != null)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        var r = row.DataItem  as DataRowView;
                        if (r != null)
                        {
                            DropDownList ddl_gv_f_currency_position = row.FindControl("ddl_gv_f_currency_position") as DropDownList;
                            ddl_gv_f_currency_position.SelectedValue = r["currency_position"].ToString();

                            DropDownList ddl_gv_f_currency_decimal_place = row.FindControl("ddl_gv_f_currency_decimal_place") as DropDownList;
                            ddl_gv_f_currency_decimal_place.SelectedValue = r["currency_decimal_place"].ToString();

                            Label lbl_gv_f_currency_format = row.FindControl("lbl_gv_f_currency_format") as Label;
                            lbl_gv_f_currency_format.Text = r["currency_format"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string ErrorMessage = UI.ExceptionHandling.ExceptionMethodHandler.HandlesException(ex);
                ucValidationMessage.ErrorMessage = ErrorMessage;
                ucValidationMessage.Show();
            }
        }

        [WebMethod]
        public static string SaveDetails(CurrencySetupUIMapper[] uiMapperDetails, CurrencyTBUIMapper[] uiTbMapperDetails)
        {
            List<CurrencySetupUIMapper> uicurrencyMapper = new List<CurrencySetupUIMapper>();
            foreach (var uiMapper in uiMapperDetails)
            {
                if ((uiMapper.currency_symbol.ToString() == string.Empty && uiMapper.currency_code.Trim() == string.Empty)) continue;
                uicurrencyMapper.Add(uiMapper);
            }

            List<CurrencyTBUIMapper> uicurrencytbMapper = new List<CurrencyTBUIMapper>();
            foreach (var uiMapper in uiTbMapperDetails)
            {
                if ((uiMapper.currency_rate.ToString() == string.Empty  )) continue;
                uicurrencytbMapper.Add(uiMapper);
            }

            new CurrencySetupAssembler().SaveCurrencySetupDetails(uicurrencyMapper, uicurrencytbMapper);
            return "true";
        }
       
    }
}