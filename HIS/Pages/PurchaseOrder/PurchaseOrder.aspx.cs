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
    public partial class PurchaseOrder : System.Web.UI.Page
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
            purord_createddate.Value = DateTime.Now;
        }

        private void BindDropDownList()
        {
            var res = new PurchaseOrderAssembler().GetPurchaseOrderScreenListValues();

            if (res.Tables.Count > 3 && res.Tables[3] != null && res.Tables[3].Rows.Count > 0)
            {
                purord_salesby.DataSource = res.Tables[3].AsDataView();
                purord_salesby.DataValueField = "emp_salesman_id";
                purord_salesby.DataTextField = "emp_name";
                purord_salesby.DataBind();
                //CommonFunctions.InsertEmptyValueToddl(purord_salesby);
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
                //hdnPurchase_id.Value = DateTime.Now.Ticks.ToString();
                purordMapper.quote_id = hdnPurchase_id.Value;
                purordMapper.purord_cust_id = purord_cust_id.Text;
                purordMapper.purord_cust_name = purord_cust_name.Text;
                purordMapper.purord_resp = txt_purord_resp.Text;
                purordMapper.purord_address = txt_purord_address.Text;
                purordMapper.purord_siteadd = txt_purord_siteadd.Text;
                purordMapper.purord_add2 = txt_purord_add2.Text;
                purordMapper.purord_city = txt_purord_city.Text;
                purordMapper.purord_siteadd2 = txt_purord_siteadd2.Text;
                purordMapper.purord_sitecity = txt_purord_sitecity.Text;
                purordMapper.purord_postal = txt_purord_postal.Text;
                purordMapper.purord_cust_Country = ddl_Country.SelectedValue;
                purordMapper.purord_sitepos = txt_purord_sitepos.Text;
                purordMapper.purord_sitecountry = ddl_sitecountry.SelectedValue;
                purordMapper.purord_contact = txt_purord_contact.Text;
                purordMapper.purord_sitecon = txt_purord_sitecon.Text;
                purordMapper.purord_tel = CommonFunctions.ConvertInt(txt_purord_tel.Text);
                purordMapper.purord_Hp = CommonFunctions.ConvertInt(txt_purord_Hp.Text);
                purordMapper.purord_sitetel = CommonFunctions.ConvertInt(txt_purord_sitetel.Text);
                purordMapper.purord_sitehp = CommonFunctions.ConvertInt(txt_purord_sitehp.Text);
                purordMapper.purord_fax = CommonFunctions.ConvertInt(txt_purord_fax.Text);
                purordMapper.purord_sitefax = CommonFunctions.ConvertInt(txt_purord_sitefax.Text);
                purordMapper.purord_email = txt_purord_email.Text;
                purordMapper.purord_siteemail = txt_purord_siteemail.Text;
                purordMapper.purord_cust = purord_cust_id.Text;
                purordMapper.purord_createddate = purord_createddate.Value;
                purordMapper.purord_created_by = txt_purord_created.Text;
                purordMapper.purord_salesby = purord_salesby.Text;
                purordMapper.purord_qutrefno = CommonFunctions.ConvertInt(txt_purord_qutrefno.Text);
                purordMapper.purord_invrefno = CommonFunctions.ConvertInt(txt_purord_invrefno.Text);
                purordMapper.dsc_purord_install = dsc_purord_install.Value;
                purordMapper.purord_time = txt_purord_time.Text;
                purordMapper.purord_by = txt_purord_by.Text;
                purordMapper.purord_roundoff = CommonFunctions.ConvertInt(ddl_purord_round.SelectedValue);
                purordMapper.purord_installation_rmk = purord_instal_rmk.Text;
                purordMapper.purord_rmk = purord_rmk.Text;
                purordMapper.purord_deposite_bank = ddl_purord_Dep_to.SelectedValue;
                purordMapper.purord_deposite_date = dsc_purord_receive.Value;
                purordMapper.purord_receivied_by = ddl_purord_rec_bnk.SelectedValue;
                purordMapper.purord_chq_no = txtChqNo.Text;
                purordMapper.purord_amount = txtRecAmount.Text;
                purordMapper.purord_internal_rmk = txtIntRmks.Text;

                new PurchaseOrderAssembler().SavePurchaseOrder(purordMapper, Common.Operation.AddNew.ToString());
                SavePurchaseItems();
                BindEmptyData();
                clearAll();
                Page.RegisterStartupScript("alert", "<script>alert('Purchase Order saved sucessfully');</script>");
            }
            catch
            {
            }
        }

        private void FillFields()
        {
            var purordMapper = new PurchaseOrderAssembler().GetPurchaseOrderDetails(hdnPurchase_id.Value);

            hdnPurchase_id.Value = purordMapper.quote_id;
            purord_cust_id.Text = purordMapper.purord_cust_id;
            purord_cust_name.Text = purordMapper.purord_cust_name;
            txt_purord_resp.Text = purordMapper.purord_resp;
            txt_purord_address.Text = purordMapper.purord_address;
            txt_purord_siteadd.Text = purordMapper.purord_siteadd;
            txt_purord_add2.Text = purordMapper.purord_add2;
            txt_purord_city.Text = purordMapper.purord_city;
            txt_purord_siteadd2.Text = purordMapper.purord_siteadd2;
            txt_purord_sitecity.Text = purordMapper.purord_sitecity;
            txt_purord_postal.Text = purordMapper.purord_postal;
            if (ddl_Country.Items.FindByValue(purordMapper.purord_cust_Country) != null)
                ddl_Country.SelectedValue = purordMapper.purord_cust_Country;
            txt_purord_sitepos.Text = purordMapper.purord_sitepos;
            if (ddl_sitecountry.Items.FindByValue(purordMapper.purord_sitecountry) != null)
                ddl_sitecountry.SelectedValue = purordMapper.purord_sitecountry;
            txt_purord_contact.Text = purordMapper.purord_contact;
            txt_purord_sitecon.Text = purordMapper.purord_sitecon;
            txt_purord_tel.Text = purordMapper.purord_tel.ToString();
            txt_purord_Hp.Text = purordMapper.purord_Hp.ToString();
            txt_purord_sitetel.Text = purordMapper.purord_sitetel.ToString();
            txt_purord_sitehp.Text = purordMapper.purord_sitehp.ToString();
            txt_purord_fax.Text = purordMapper.purord_fax.ToString();
            txt_purord_sitefax.Text = purordMapper.purord_sitefax.ToString();
            txt_purord_email.Text = purordMapper.purord_email;
            txt_purord_siteemail.Text = purordMapper.purord_siteemail;
            purord_cust_id.Text = purordMapper.purord_cust;
            purord_createddate.Value = purordMapper.purord_createddate;
            txt_purord_created.Text = purordMapper.purord_created_by;
            purord_salesby.Text = purordMapper.purord_salesby;
            txt_purord_qutrefno.Text = purordMapper.purord_qutrefno.ToString();
            txt_purord_invrefno.Text = purordMapper.purord_invrefno.ToString();
            dsc_purord_install.Value = purordMapper.dsc_purord_install;
            txt_purord_time.Text = purordMapper.purord_time;
            txt_purord_by.Text = purordMapper.purord_by;
            ddl_purord_round.SelectedValue = purordMapper.purord_roundoff.ToString();
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

        private void BindEmptyData()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = createItemDT();
                gvpurordItem.DataSource = dt;
                gvpurordItem.DataBind();
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
                gvpurordItem.DataSource = dtItems;
                gvpurordItem.DataBind();
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
            PurchaseOrderItemUIMapper purordItemMapper = null;
            DataTable dtItems = new DataTable();
            try
            {
                if (Session["ITEMS"] != null)
                {
                    purordItemMapper = new PurchaseOrderItemUIMapper();
                    dtItems = (DataTable)Session["ITEMS"];
                    for (int i = 0; i < dtItems.Rows.Count; i++)
                    {
                        purordItemMapper = new PurchaseOrderItemUIMapper();
                        purordItemMapper.purord_id = string.Empty;
                        purordItemMapper.purord_item_id = i + 1;
                        purordItemMapper.purord_item_header = dtItems.Rows[i]["Header"].ToString();
                        purordItemMapper.purord_item_model = dtItems.Rows[i]["Model"].ToString();
                        purordItemMapper.purord_item_type = dtItems.Rows[i]["Type"].ToString();
                        purordItemMapper.purord_item_desc = dtItems.Rows[i]["Description"].ToString();
                        purordItemMapper.purord_item_width = CommonFunctions.ConvertInt(dtItems.Rows[i]["Width"].ToString());
                        purordItemMapper.purord_item_height = CommonFunctions.ConvertInt(dtItems.Rows[i]["Height"].ToString());
                        purordItemMapper.quote_item_qty = CommonFunctions.ConvertInt(dtItems.Rows[i]["Qty"].ToString());
                        purordItemMapper.purord_item_amt = CommonFunctions.ConvertInt(dtItems.Rows[i]["UnitPrice"].ToString());
                        purordItemMapper.purord_item_tamt = CommonFunctions.ConvertInt(dtItems.Rows[i]["TotalAmount"].ToString());

                        new PurchaseOrderAssembler().SavePurchaseOrderItems(purordItemMapper, Common.Operation.AddNew.ToString());
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
                        PurchaseOrderItemUIMapper purordItemMapper = new PurchaseOrderItemUIMapper();
                        purordItemMapper.purord_id = hdnPurchase_id.Value;
                        purordItemMapper.purord_item_id = CommonFunctions.ConvertInt(i.ToString());
                        purordItemMapper.purord_item_model = "";
                        purordItemMapper.purord_item_type = "";
                        purordItemMapper.purord_item_desc = "";
                        purordItemMapper.purord_item_width = 10;
                        purordItemMapper.purord_item_height = 19;
                        purordItemMapper.purord_item_ctrl = 10;
                        purordItemMapper.purord_item_setno = 10;
                        purordItemMapper.purord_item_setno = 10;
                        purordItemMapper.purord_item_uom = 10;
                        purordItemMapper.purord_item_col = 10;
                        purordItemMapper.quote_item_qty = 10;
                        purordItemMapper.purord_item_amt = 10;
                        purordItemMapper.purord_item_tamt = 100;
                    }
                }
            }
            catch
            {
            }
        }

        private void clearAll()
        {
            purord_cust_id.Text = string.Empty;
            purord_cust_name.Text = string.Empty;
            txt_purord_resp.Text = string.Empty;
            txt_purord_address.Text = string.Empty;
            txt_purord_siteadd.Text = string.Empty;
            txt_purord_add2.Text = string.Empty;
            txt_purord_city.Text = string.Empty;
            txt_purord_siteadd2.Text = string.Empty;
            txt_purord_sitecity.Text = string.Empty;
            txt_purord_postal.Text = string.Empty;
            ddl_Country.SelectedValue = "";
            txt_purord_sitepos.Text = string.Empty;
            ddl_sitecountry.SelectedValue = "";
            txt_purord_contact.Text = string.Empty;
            txt_purord_sitecon.Text = string.Empty;
            txt_purord_tel.Text = string.Empty;
            txt_purord_Hp.Text = string.Empty;
            txt_purord_sitetel.Text = string.Empty;
            txt_purord_sitehp.Text = string.Empty;
            txt_purord_fax.Text = string.Empty;
            txt_purord_sitefax.Text = string.Empty;
            txt_purord_email.Text = string.Empty;
            txt_purord_siteemail.Text = string.Empty;
            purord_cust_id.Text = string.Empty;
            txt_purord_created.Text = string.Empty;
            txt_purord_qutrefno.Text = string.Empty;
            txt_purord_invrefno.Text = string.Empty;
            txt_purord_time.Text = string.Empty;
            txt_purord_by.Text = string.Empty;
            ddl_purord_round.SelectedValue = "";
            purord_instal_rmk.Text = string.Empty;
            purord_rmk.Text = string.Empty;
            ddl_purord_Dep_to.SelectedValue = "";
            ddl_purord_rec_bnk.SelectedValue = "";
            txtChqNo.Text = string.Empty;
            txtRecAmount.Text = string.Empty;
            txtIntRmks.Text = string.Empty;
        }
    }
}