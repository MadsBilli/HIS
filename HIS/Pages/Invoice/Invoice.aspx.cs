using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HIS.UI.Assembler.Invoice;
using HIS.Common;
using HIS.UI.Mapper.Invoice;

namespace HIS.Pages.Invoice
{
    public partial class Invoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    BindDropDownList();
                    InitialSetup();
                    BindEmptyData();
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
            inv_createddate.Value = DateTime.Now;
        }

        private void BindDropDownList()
        {
            var res = new InvoiceAssembler().GetInvoiceScreenListValues();

            if (res.Tables.Count > 3 && res.Tables[3] != null && res.Tables[3].Rows.Count > 0)
            {
                inv_salesby.DataSource = res.Tables[3].AsDataView();
                inv_salesby.DataValueField = "emp_salesman_id";
                inv_salesby.DataTextField = "emp_name";
                inv_salesby.DataBind();
                //CommonFunctions.InsertEmptyValueToddl(inv_salesby);
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

                InvoiceUIMapper invMapper = new InvoiceUIMapper();
                //hdnPurchase_id.Value = DateTime.Now.Ticks.ToString();
                invMapper.inv_id = hdnInvoice_id.Value;
                invMapper.inv_cust_id = inv_cust_id.Text;
                invMapper.inv_cust_name = inv_cust_name.Text;
                invMapper.inv_resp = txt_inv_resp.Text;
                invMapper.inv_address = txt_inv_address.Text;
                invMapper.inv_siteadd = txt_inv_siteadd.Text;
                invMapper.inv_add2 = txt_inv_add2.Text;
                invMapper.inv_city = txt_inv_city.Text;
                invMapper.inv_siteadd2 = txt_inv_siteadd2.Text;
                invMapper.inv_sitecity = txt_inv_sitecity.Text;
                invMapper.inv_postal = txt_inv_postal.Text;
                invMapper.inv_cust_Country = ddl_Country.SelectedValue;
                invMapper.inv_sitepos = txt_inv_sitepos.Text;
                invMapper.inv_sitecountry = ddl_sitecountry.SelectedValue;
                invMapper.inv_contact = txt_inv_contact.Text;
                invMapper.inv_sitecon = txt_inv_sitecon.Text;
                invMapper.inv_tel = CommonFunctions.ConvertInt(txt_inv_tel.Text);
                invMapper.inv_Hp = CommonFunctions.ConvertInt(txt_inv_Hp.Text);
                invMapper.inv_sitetel = CommonFunctions.ConvertInt(txt_inv_sitetel.Text);
                invMapper.inv_sitehp = CommonFunctions.ConvertInt(txt_inv_sitehp.Text);
                invMapper.inv_fax = CommonFunctions.ConvertInt(txt_inv_fax.Text);
                invMapper.inv_sitefax = CommonFunctions.ConvertInt(txt_inv_sitefax.Text);
                invMapper.inv_email = txt_inv_email.Text;
                invMapper.inv_siteemail = txt_inv_siteemail.Text;
                invMapper.inv_cust = inv_cust_id.Text;
                invMapper.inv_createddate = inv_createddate.Value;
                invMapper.inv_created_by = txt_inv_created.Text;
                invMapper.inv_salesby = inv_salesby.Text;
                invMapper.inv_qutrefno = CommonFunctions.ConvertInt(txt_inv_qutrefno.Text);
                invMapper.inv_invrefno = CommonFunctions.ConvertInt(txt_inv_invrefno.Text);
                invMapper.dsc_inv_install = dsc_inv_install.Value;
                invMapper.inv_time = txt_inv_time.Text;
                invMapper.inv_by = txt_inv_by.Text;
                invMapper.inv_roundoff = CommonFunctions.ConvertInt(ddl_inv_round.SelectedValue);
                invMapper.inv_installation_rmk = inv_instal_rmk.Text;
                invMapper.inv_rmk = inv_rmk.Text;
                invMapper.inv_deposite_bank = ddl_inv_Dep_to.SelectedValue;
                invMapper.inv_deposite_date = dsc_inv_receive.Value;
                invMapper.inv_receivied_by = ddl_inv_rec_bnk.SelectedValue;
                invMapper.inv_chq_no = txtChqNo.Text;
                invMapper.inv_amount = txtRecAmount.Text;
                invMapper.inv_internal_rmk = txtIntRmks.Text;

                new InvoiceAssembler().SaveInvoice(invMapper, Common.Operation.AddNew.ToString());
                SavePurchaseItems();
                BindEmptyData();
                clearAll();
                Page.RegisterStartupScript("alert", "<script>alert('Invoice saved sucessfully');</script>");
            }
            catch
            {
            }
        }

        private void FillFields()
        {
            var invMapper = new InvoiceAssembler().GetInvoiceDetails(hdnInvoice_id.Value);

            hdnInvoice_id.Value = invMapper.inv_id;
            inv_cust_id.Text = invMapper.inv_cust_id;
            inv_cust_name.Text = invMapper.inv_cust_name;
            txt_inv_resp.Text = invMapper.inv_resp;
            txt_inv_address.Text = invMapper.inv_address;
            txt_inv_siteadd.Text = invMapper.inv_siteadd;
            txt_inv_add2.Text = invMapper.inv_add2;
            txt_inv_city.Text = invMapper.inv_city;
            txt_inv_siteadd2.Text = invMapper.inv_siteadd2;
            txt_inv_sitecity.Text = invMapper.inv_sitecity;
            txt_inv_postal.Text = invMapper.inv_postal;
            if (ddl_Country.Items.FindByValue(invMapper.inv_cust_Country) != null)
                ddl_Country.SelectedValue = invMapper.inv_cust_Country;
            txt_inv_sitepos.Text = invMapper.inv_sitepos;
            if (ddl_sitecountry.Items.FindByValue(invMapper.inv_sitecountry) != null)
                ddl_sitecountry.SelectedValue = invMapper.inv_sitecountry;
            txt_inv_contact.Text = invMapper.inv_contact;
            txt_inv_sitecon.Text = invMapper.inv_sitecon;
            txt_inv_tel.Text = invMapper.inv_tel.ToString();
            txt_inv_Hp.Text = invMapper.inv_Hp.ToString();
            txt_inv_sitetel.Text = invMapper.inv_sitetel.ToString();
            txt_inv_sitehp.Text = invMapper.inv_sitehp.ToString();
            txt_inv_fax.Text = invMapper.inv_fax.ToString();
            txt_inv_sitefax.Text = invMapper.inv_sitefax.ToString();
            txt_inv_email.Text = invMapper.inv_email;
            txt_inv_siteemail.Text = invMapper.inv_siteemail;
            inv_cust_id.Text = invMapper.inv_cust;
            inv_createddate.Value = invMapper.inv_createddate;
            txt_inv_created.Text = invMapper.inv_created_by;
            inv_salesby.Text = invMapper.inv_salesby;
            txt_inv_qutrefno.Text = invMapper.inv_qutrefno.ToString();
            txt_inv_invrefno.Text = invMapper.inv_invrefno.ToString();
            dsc_inv_install.Value = invMapper.dsc_inv_install;
            txt_inv_time.Text = invMapper.inv_time;
            txt_inv_by.Text = invMapper.inv_by;
            ddl_inv_round.SelectedValue = invMapper.inv_roundoff.ToString();
            inv_instal_rmk.Text = invMapper.inv_installation_rmk;
            inv_rmk.Text = invMapper.inv_rmk;
            if (ddl_inv_Dep_to.Items.FindByValue(invMapper.inv_deposite_bank) != null)
                ddl_inv_Dep_to.SelectedValue = invMapper.inv_deposite_bank;
            dsc_inv_receive.Value = invMapper.inv_deposite_date;
            if (ddl_inv_rec_bnk.Items.FindByValue(invMapper.inv_receivied_by) != null)
                ddl_inv_rec_bnk.SelectedValue = invMapper.inv_receivied_by;
            txtChqNo.Text = invMapper.inv_chq_no;
            txtRecAmount.Text = invMapper.inv_amount;
            txtIntRmks.Text = invMapper.inv_internal_rmk;
        }

        private void BindEmptyData()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = createItemDT();
                gvinvItem.DataSource = dt;
                gvinvItem.DataBind();
            }
            catch
            {
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddItem();
                ClearItenDetails();
                if (chkAddAnother.Checked)
                {
                    divoverlaypopup.Style.Add("display", "block");
                    divPopUp.Style.Add("display", "block");
                }
                else
                {
                    divoverlaypopup.Style.Add("display", "none");
                    divPopUp.Style.Add("display", "none");
                }
            }
            catch
            {
            }
        }

        private void AddItem()
        {
            DataTable dtItems = new DataTable();
            try
            {
                if (Session["ITEMS"] != null)
                    dtItems = (DataTable)Session["ITEMS"];
                else
                    dtItems = createItemDT();
                DataRow dr = dtItems.NewRow();
                dr["Header"] = txtHeader.Text;
                dr["Model"] = txtModel.Text;
                dr["Type"] = txtType.Text;
                dr["Description"] = txtDesc.Text;
                dr["Width"] = txtWidth.Text;
                dr["Height"] = txtHeight.Text;
                dr["Ctrl"] = txtCtrl.Text;
                dr["Set"] = txtSet.Text;
                dr["UOM"] = txtUOM.Text;
                dr["Coloumn"] = txtCol.Text;
                dr["Qty"] = txtQty.Text;
                dr["UnitPrice"] = txtUnitPrice.Text;
                dr["TotalAmount"] = txtTotalAmount.Text;
                dtItems.Rows.Add(dr);
                gvinvItem.DataSource = dtItems;
                gvinvItem.DataBind();
                Session["ITEMS"] = dtItems;
            }
            catch
            {
            }
        }

        private DataTable createItemDT()
        {
            DataTable dtItems = new DataTable();
            dtItems.Columns.Add("Header");
            dtItems.Columns.Add("Model");
            dtItems.Columns.Add("Type");
            dtItems.Columns.Add("Description");
            dtItems.Columns.Add("Width");
            dtItems.Columns.Add("Height");
            dtItems.Columns.Add("Ctrl");
            dtItems.Columns.Add("Set");
            dtItems.Columns.Add("UOM");
            dtItems.Columns.Add("Coloumn");
            dtItems.Columns.Add("Qty");
            dtItems.Columns.Add("UnitPrice");
            dtItems.Columns.Add("TotalAmount");
            return dtItems;
        }

        private void ClearItenDetails()
        {
            txtHeader.Text = "";
            txtModel.Text = "";
            txtType.Text = "";
            txtDesc.Text = "";
            txtWidth.Text = "";
            txtHeight.Text = "";
            txtCtrl.Text = "";
            txtSet.Text = "";
            txtUOM.Text = "";
            txtCol.Text = "";
            txtQty.Text = "";
            txtUnitPrice.Text = "";
            txtTotalAmount.Text = "";
        }

        private void SavePurchaseItems()
        {
            InvoiceItemUIMapper invItemMapper = null;
            DataTable dtItems = new DataTable();
            try
            {
                if (Session["ITEMS"] != null)
                {
                    invItemMapper = new InvoiceItemUIMapper();
                    dtItems = (DataTable)Session["ITEMS"];
                    for (int i = 0; i < dtItems.Rows.Count; i++)
                    {
                        invItemMapper = new InvoiceItemUIMapper();
                        invItemMapper.inv_id = string.Empty;
                        invItemMapper.inv_item_id = i + 1;
                        invItemMapper.inv_item_header = dtItems.Rows[i]["Header"].ToString();
                        invItemMapper.inv_item_model = dtItems.Rows[i]["Model"].ToString();
                        invItemMapper.inv_item_type = dtItems.Rows[i]["Type"].ToString();
                        invItemMapper.inv_item_desc = dtItems.Rows[i]["Description"].ToString();
                        invItemMapper.inv_item_width = CommonFunctions.ConvertInt(dtItems.Rows[i]["Width"].ToString());
                        invItemMapper.inv_item_height = CommonFunctions.ConvertInt(dtItems.Rows[i]["Height"].ToString());
                        invItemMapper.inv_item_qty = CommonFunctions.ConvertInt(dtItems.Rows[i]["Qty"].ToString());
                        invItemMapper.inv_item_amt = CommonFunctions.ConvertInt(dtItems.Rows[i]["UnitPrice"].ToString());
                        invItemMapper.inv_item_tamt = CommonFunctions.ConvertInt(dtItems.Rows[i]["TotalAmount"].ToString());

                        new InvoiceAssembler().SaveInvoiceItems(invItemMapper, Common.Operation.AddNew.ToString());
                    }
                }
            }
            catch
            {
            }
        }

        private void savePhurchaseItems(string strpur_id)
        {
            DataTable dtItems = new DataTable();
            try
            {
                if (Session["ITEMS"] != null)
                {
                    dtItems = (DataTable)Session["ITEMS"];
                    for (int i = 0; i < dtItems.Rows.Count; i++)
                    {
                        InvoiceItemUIMapper invItemMapper = new InvoiceItemUIMapper();
                        invItemMapper.inv_id = hdnInvoice_id.Value;
                        invItemMapper.inv_item_id = CommonFunctions.ConvertInt(i.ToString());
                        invItemMapper.inv_item_model = "";
                        invItemMapper.inv_item_type = "";
                        invItemMapper.inv_item_desc = "";
                        invItemMapper.inv_item_width = 10;
                        invItemMapper.inv_item_height = 19;
                        invItemMapper.inv_item_ctrl = 10;
                        invItemMapper.inv_item_setno = 10;
                        invItemMapper.inv_item_setno = 10;
                        invItemMapper.inv_item_uom = 10;
                        invItemMapper.inv_item_col = 10;
                        invItemMapper.inv_item_qty = 10;
                        invItemMapper.inv_item_amt = 10;
                        invItemMapper.inv_item_tamt = 100;
                    }
                }
            }
            catch
            {
            }
        }

        private void clearAll()
        {
            inv_cust_id.Text = string.Empty;
            inv_cust_name.Text = string.Empty;
            txt_inv_resp.Text = string.Empty;
            txt_inv_address.Text = string.Empty;
            txt_inv_siteadd.Text = string.Empty;
            txt_inv_add2.Text = string.Empty;
            txt_inv_city.Text = string.Empty;
            txt_inv_siteadd2.Text = string.Empty;
            txt_inv_sitecity.Text = string.Empty;
            txt_inv_postal.Text = string.Empty;
            ddl_Country.SelectedValue = "";
            txt_inv_sitepos.Text = string.Empty;
            ddl_sitecountry.SelectedValue = "";
            txt_inv_contact.Text = string.Empty;
            txt_inv_sitecon.Text = string.Empty;
            txt_inv_tel.Text = string.Empty;
            txt_inv_Hp.Text = string.Empty;
            txt_inv_sitetel.Text = string.Empty;
            txt_inv_sitehp.Text = string.Empty;
            txt_inv_fax.Text = string.Empty;
            txt_inv_sitefax.Text = string.Empty;
            txt_inv_email.Text = string.Empty;
            txt_inv_siteemail.Text = string.Empty;
            inv_cust_id.Text = string.Empty;
            txt_inv_created.Text = string.Empty;
            txt_inv_qutrefno.Text = string.Empty;
            txt_inv_invrefno.Text = string.Empty;
            txt_inv_time.Text = string.Empty;
            txt_inv_by.Text = string.Empty;
            ddl_inv_round.SelectedValue = "";
            inv_instal_rmk.Text = string.Empty;
            inv_rmk.Text = string.Empty;
            ddl_inv_Dep_to.SelectedValue = "";
            ddl_inv_rec_bnk.SelectedValue = "";
            txtChqNo.Text = string.Empty;
            txtRecAmount.Text = string.Empty;
            txtIntRmks.Text = string.Empty;
        }
    }
}