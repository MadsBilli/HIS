using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HIS.UI.Assembler.PurchaseOrder;
using HIS.Common;
using HIS.UI.Mapper.PurchaseOrder;

namespace HIS.Pages.Quotation
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    BindDropDownList();
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
            pymnt_createddate.Value = DateTime.Now;
        }

        private void BindDropDownList()
        {
            var res = new PurchaseOrderAssembler().GetPurchaseOrderScreenListValues();

            if (res.Tables.Count > 3 && res.Tables[3] != null && res.Tables[3].Rows.Count > 0)
            {
                pymnt_salesby.DataSource = res.Tables[3].AsDataView();
                pymnt_salesby.DataValueField = "emp_salesman_id";
                pymnt_salesby.DataTextField = "emp_name";
                pymnt_salesby.DataBind();
                //CommonFunctions.InsertEmptyValueToddl(pymnt_salesby);
            }



            if (res.Tables.Count > 9 && res.Tables[9] != null && res.Tables[9].Rows.Count > 0)
            {
                //Country
                ddl_Country.DataSource = res.Tables[9].AsDataView();
                ddl_Country.DataValueField = "city_code";
                ddl_Country.DataTextField = "city_desc";
                ddl_Country.DataBind();
                //CommonFunctions.InsertEmptyValueToddl(quote_des_add5);
                ddl_sitecountry.DataSource = res.Tables[9].AsDataView();
                ddl_sitecountry.DataValueField = "city_code";
                ddl_sitecountry.DataTextField = "city_desc";
                ddl_sitecountry.DataBind();
                //CommonFunctions.InsertEmptyValueToddl(quote_site_add5);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                PurchaseOrderUIMapper purordMapper = new PurchaseOrderUIMapper();

                purordMapper.quote_id = hdnPurchase_id.Value;
                purordMapper.purord_cust_id = pymnt_cust_id.Text;
                purordMapper.purord_cust_name = pymnt_cust_name.Text;
                purordMapper.purord_resp = txt_pymnt_resp.Text;
                purordMapper.purord_address = txt_pymnt_address.Text;
                purordMapper.purord_siteadd = txt_pymnt_siteadd.Text;
                purordMapper.purord_add2 = txt_pymnt_add2.Text;
                purordMapper.purord_city = txt_pymnt_city.Text;
                purordMapper.purord_siteadd2 = txt_pymnt_siteadd2.Text;
                purordMapper.purord_sitecity = txt_pymnt_sitecity.Text;
                purordMapper.purord_postal = txt_pymnt_postal.Text;
                purordMapper.purord_cust_Country = ddl_Country.SelectedValue;
                purordMapper.purord_sitepos = txt_pymnt_sitepos.Text;
                purordMapper.purord_sitecountry = ddl_sitecountry.SelectedValue;
                purordMapper.purord_contact = txt_pymnt_contact.Text;
                purordMapper.purord_sitecon = txt_pymnt_sitecon.Text;
                purordMapper.purord_tel = Convert.ToInt16(txt_pymnt_tel.Text);
                purordMapper.purord_Hp = Convert.ToInt16(txt_pymnt_Hp.Text);
                purordMapper.purord_sitetel = Convert.ToInt16(txt_pymnt_sitetel.Text);
                purordMapper.purord_sitehp = Convert.ToInt16(txt_pymnt_sitehp.Text);
                purordMapper.purord_fax = Convert.ToInt16(txt_pymnt_fax.Text);
                purordMapper.purord_sitefax = Convert.ToInt16(txt_pymnt_sitefax.Text);
                purordMapper.purord_email = txt_pymnt_email.Text;
                purordMapper.purord_siteemail = txt_pymnt_siteemail.Text;
                purordMapper.purord_cust = pymnt_cust_id.Text;
                purordMapper.purord_createddate = pymnt_createddate.Value;
                purordMapper.purord_created_by = txt_pymnt_created.Text;
                purordMapper.purord_salesby = pymnt_salesby.Text;
                purordMapper.purord_qutrefno = Convert.ToInt16(txt_pymnt_qutrefno.Text);
                purordMapper.purord_invrefno = Convert.ToInt16(txt_pymnt_invrefno.Text);
                purordMapper.dsc_purord_install = dsc_pymnt_install.Value;
                purordMapper.purord_time = txt_pymnt_time.Text;
                purordMapper.purord_by = txt_pymnt_by.Text;
                purordMapper.purord_roundoff = Convert.ToInt16(ddl_pymnt_round.SelectedValue);
                purordMapper.purord_installation_rmk = purord_instal_rmk.Text;
                purordMapper.purord_rmk = purord_rmk.Text;
                purordMapper.purord_deposite_bank = ddl_purord_Dep_to.SelectedValue;
                purordMapper.purord_deposite_date = dsc_purord_receive.Value;
                purordMapper.purord_receivied_by = ddl_purord_rec_bnk.SelectedValue;
                purordMapper.purord_chq_no = txtChqNo.Text;
                purordMapper.purord_amount = txtRecAmount.Text;
                purordMapper.purord_internal_rmk = txtIntRmks.Text;

                new PurchaseOrderAssembler().SavePurchaseOrder(purordMapper, Common.Operation.AddNew.ToString());
            }
            catch
            {
            }
        }

        private void FillFields()
        {
            var purordMapper = new PurchaseOrderAssembler().GetPurchaseOrderDetails(hdnPurchase_id.Value);

            hdnPurchase_id.Value = purordMapper.quote_id;
            pymnt_cust_id.Text = purordMapper.purord_cust_id;
            pymnt_cust_name.Text = purordMapper.purord_cust_name;
            txt_pymnt_resp.Text = purordMapper.purord_resp;
            txt_pymnt_address.Text = purordMapper.purord_address;
            txt_pymnt_siteadd.Text = purordMapper.purord_siteadd;
            txt_pymnt_add2.Text = purordMapper.purord_add2;
            txt_pymnt_city.Text = purordMapper.purord_city;
            txt_pymnt_siteadd2.Text = purordMapper.purord_siteadd2;
            txt_pymnt_sitecity.Text = purordMapper.purord_sitecity;
            txt_pymnt_postal.Text = purordMapper.purord_postal;
            if (ddl_Country.Items.FindByValue(purordMapper.purord_cust_Country) != null)
                ddl_Country.SelectedValue = purordMapper.purord_cust_Country;
            txt_pymnt_sitepos.Text = purordMapper.purord_sitepos;
            if (ddl_sitecountry.Items.FindByValue(purordMapper.purord_sitecountry) != null)
                ddl_sitecountry.SelectedValue = purordMapper.purord_sitecountry;
            txt_pymnt_contact.Text = purordMapper.purord_contact;
            txt_pymnt_sitecon.Text = purordMapper.purord_sitecon;
            txt_pymnt_tel.Text = purordMapper.purord_tel.ToString();
            txt_pymnt_Hp.Text = purordMapper.purord_Hp.ToString();
            txt_pymnt_sitetel.Text = purordMapper.purord_sitetel.ToString();
            txt_pymnt_sitehp.Text = purordMapper.purord_sitehp.ToString();
            txt_pymnt_fax.Text = purordMapper.purord_fax.ToString();
            txt_pymnt_sitefax.Text = purordMapper.purord_sitefax.ToString();
            txt_pymnt_email.Text = purordMapper.purord_email;
            txt_pymnt_siteemail.Text = purordMapper.purord_siteemail;
            pymnt_cust_id.Text = purordMapper.purord_cust;
            pymnt_createddate.Value = purordMapper.purord_createddate;
            txt_pymnt_created.Text = purordMapper.purord_created_by;
            pymnt_salesby.Text = purordMapper.purord_salesby;
            txt_pymnt_qutrefno.Text = purordMapper.purord_qutrefno.ToString();
            txt_pymnt_invrefno.Text = purordMapper.purord_invrefno.ToString();
            dsc_pymnt_install.Value = purordMapper.dsc_purord_install;
            txt_pymnt_time.Text = purordMapper.purord_time;
            txt_pymnt_by.Text = purordMapper.purord_by;
            ddl_pymnt_round.SelectedValue = purordMapper.purord_roundoff.ToString();
            purord_instal_rmk.Text = purordMapper.purord_installation_rmk;
            purord_rmk.Text = purordMapper.purord_rmk;
            if (ddl_purord_Dep_to.Items.FindByValue(purordMapper.purord_deposite_bank) != null)
                ddl_purord_Dep_to.SelectedValue = purordMapper.purord_deposite_bank;
            dsc_purord_receive.Value = purordMapper.purord_deposite_date;
            if (ddl_purord_rec_bnk.Items.FindByValue(purordMapper.purord_receivied_by) != null)
                ddl_purord_rec_bnk.SelectedValue = purordMapper.purord_receivied_by;
            txtChqNo.Text = purordMapper.purord_chq_no;
            txtRecAmount.Text = purordMapper.purord_amount;
            txtIntRmks.Text = purordMapper.purord_internal_rmk;
        }
    }
}