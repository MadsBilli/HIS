using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using HIS.UI.SessionManagement;
using HIS.UI.Common;
using HIS.UI.Assembler.Workorder;
using HIS.UI.Mapper.Workorder;
using System.Web.Services;

namespace HIS.Pages.WorkOrder
{
    public partial class WorkOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownList();
                BindData();
            }
        }

        private void BindData()
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add("id");
                DataRow dr = dt.NewRow();
                dr["id"] = "1";
                dt.Rows.Add(dr);
                gvWorkOder.DataSource = dt;
                gvWorkOder.DataBind();
            }
            catch
            {
            }
        }

        private void BindDropDownList()
        {
            var res = new WorkorderAssembler().GetWorkorderScreenListValues();

            if (res.Tables.Count > 3 && res.Tables[3] != null && res.Tables[3].Rows.Count > 0)
            {
                wo_salesby.DataSource = res.Tables[3].AsDataView();
                wo_salesby.DataValueField = "emp_salesman_id";
                wo_salesby.DataTextField = "emp_name";
                wo_salesby.DataBind();
                CommonFunctions.InsertEmptyValueToddl(wo_salesby);
            }
            if (res.Tables.Count > 4 && res.Tables[4] != null && res.Tables[4].Rows.Count > 0)
            {
                //pymnt_salesby.DataSource = res.Tables[4].AsDataView();
                //pymnt_salesby.DataValueField = "emp_salesman_id";
                //pymnt_salesby.DataTextField = "emp_salesman_id";
                //pymnt_salesby.DataBind();
                //CommonFunctions.InsertEmptyValueToddl(pymnt_salesby);
            }

            if (res.Tables.Count > 9 && res.Tables[9] != null && res.Tables[9].Rows.Count > 0)
            {
                //Country
                ddl_Country.DataSource = res.Tables[9].AsDataView();
                ddl_Country.DataValueField = "city_code";
                ddl_Country.DataTextField = "city_desc";
                ddl_Country.DataBind();
                CommonFunctions.InsertEmptyValueToddl(ddl_Country);
                ddl_sitecountry.DataSource = res.Tables[9].AsDataView();
                ddl_sitecountry.DataValueField = "city_code";
                ddl_sitecountry.DataTextField = "city_desc";
                ddl_sitecountry.DataBind();
                CommonFunctions.InsertEmptyValueToddl(ddl_sitecountry);
                wo_des_add5.DataSource = res.Tables[9].AsDataView();
                wo_des_add5.DataValueField = "city_code";
                wo_des_add5.DataTextField = "city_desc";
                wo_des_add5.DataBind();
                CommonFunctions.InsertEmptyValueToddl(wo_des_add5);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //workorderUIMapper woMapper = new workorderUIMapper();
                //woMapper.quote_id = hdnWO_id.Value;
                //woMapper.wo_cust_id = wo_cust_id.Text;
                //woMapper.wo_cust_name = wo_cust_name.Text;
                //woMapper.wo_resp = txt_wo_resp.Text;
                //woMapper.wo_address = txt_wo_address.Text;
                //woMapper.wo_siteadd = txt_wo_siteadd.Text;
                //woMapper.wo_add2 = txt_wo_add2.Text;
                //woMapper.wo_city = txt_wo_city.Text;
                //woMapper.wo_siteadd2 = txt_wo_siteadd2.Text;
                //woMapper.wo_sitecity = txt_wo_sitecity.Text;
                //woMapper.wo_postal = txt_wo_postal.Text;
                //woMapper.wo_cust_Country = ddl_Country.SelectedValue;
                //woMapper.wo_sitepos = txt_wo_sitepos.Text;
                //woMapper.wo_sitecountry = ddl_sitecountry.SelectedValue;
                //woMapper.wo_contact = txt_wo_contact.Text;
                //woMapper.wo_sitecon = txt_wo_sitecon.Text;
                //woMapper.wo_tel = CommonFunctions.ConvertInt(txt_wo_tel.Text);
                //woMapper.wo_Hp = CommonFunctions.ConvertInt(txt_wo_Hp.Text);
                //woMapper.wo_sitetel = CommonFunctions.ConvertInt(txt_wo_sitetel.Text);
                //woMapper.wo_sitehp = CommonFunctions.ConvertInt(txt_wo_sitehp.Text);
                //woMapper.wo_fax = CommonFunctions.ConvertInt(txt_wo_fax.Text);
                //woMapper.wo_sitefax = CommonFunctions.ConvertInt(txt_wo_sitefax.Text);
                //woMapper.wo_email = txt_wo_email.Text;
                //woMapper.wo_siteemail = txt_wo_siteemail.Text;
                //woMapper.wo_cust = wo_cust_id.Text;
                //woMapper.wo_createddate = wo_createddate.Value;
                //woMapper.wo_created_by = txt_wo_created.Text;
                //woMapper.wo_salesby = wo_salesby.Text;
                //woMapper.wo_qutrefno = CommonFunctions.ConvertInt(txt_wo_qutrefno.Text);
                //woMapper.wo_invrefno = CommonFunctions.ConvertInt(txt_wo_invrefno.Text);
                //woMapper.dsc_wo_install = dsc_wo_install.Value;
                //woMapper.wo_time = txt_wo_time.Text;
                //woMapper.wo_by = txt_wo_by.Text;
                //woMapper.wo_roundoff = CommonFunctions.ConvertInt(ddl_wo_round.SelectedValue);
                //woMapper.wo_installation_rmk = wo_instal_rmk.Text;
                //woMapper.wo_rmk = wo_rmk.Text;
                //woMapper.wo_deposite_bank = ddl_wo_Dep_to.SelectedValue;
                //woMapper.wo_deposite_date = dsc_wo_receive.Value;
                //woMapper.wo_receivied_by = ddl_wo_rec_bnk.SelectedValue;
                //woMapper.wo_chq_no = txtChqNo.Text;
                //woMapper.wo_amount = txtRecAmount.Text;
                //woMapper.wo_internal_rmk = txtIntRmks.Text;

                //new WorkorderAssembler().SaveWorkOrder(woMapper, Common.Operation.AddNew.ToString());
                //SavePurchaseItems();
                //BindEmptyData();
                //clearAll();
                Page.RegisterStartupScript("alert", "<script>alert('Work Order saved sucessfully');</script>");
            }
            catch
            {
            }
        }

        private void FillFields()
        {
            var woMapper = new WorkorderAssembler().GetWorkOrderDetails(hdnWO_id.Value);

            //hdnWO_id.Value = woMapper.wo_id;
            //wo_cust_id.Text = woMapper.wo_cust_id;
            //wo_cust_name.Text = woMapper.wo_cust_name;
            //txt_wo_resp.Text = woMapper.wo_resp;
            //txt_wo_address.Text = woMapper.wo_address;
            //txt_wo_siteadd.Text = woMapper.wo_siteadd;
            //txt_wo_add2.Text = woMapper.wo_add2;
            //txt_wo_city.Text = woMapper.wo_city;
            //txt_wo_siteadd2.Text = woMapper.wo_siteadd2;
            //txt_wo_sitecity.Text = woMapper.wo_sitecity;
            //txt_wo_postal.Text = woMapper.wo_postal;
            //if (ddl_Country.Items.FindByValue(woMapper.wo_cust_Country) != null)
            //    ddl_Country.SelectedValue = woMapper.wo_cust_Country;
            //txt_wo_sitepos.Text = woMapper.wo_sitepos;
            //if (ddl_sitecountry.Items.FindByValue(woMapper.wo_sitecountry) != null)
            //    ddl_sitecountry.SelectedValue = woMapper.wo_sitecountry;
            //txt_wo_contact.Text = woMapper.wo_contact;
            //txt_wo_sitecon.Text = woMapper.wo_sitecon;
            //txt_wo_tel.Text = woMapper.wo_tel.ToString();
            //txt_wo_Hp.Text = woMapper.wo_Hp.ToString();
            //txt_wo_sitetel.Text = woMapper.wo_sitetel.ToString();
            //txt_wo_sitehp.Text = woMapper.wo_sitehp.ToString();
            //txt_wo_fax.Text = woMapper.wo_fax.ToString();
            //txt_wo_sitefax.Text = woMapper.wo_sitefax.ToString();
            //txt_wo_email.Text = woMapper.wo_email;
            //txt_wo_siteemail.Text = woMapper.wo_siteemail;
            //wo_cust_id.Text = woMapper.wo_cust;
            //wo_createddate.Value = woMapper.wo_createddate;
            //txt_wo_created.Text = woMapper.wo_created_by;
            //wo_salesby.Text = woMapper.wo_salesby;
            //txt_wo_qutrefno.Text = woMapper.wo_qutrefno.ToString();
            //txt_wo_invrefno.Text = woMapper.wo_invrefno.ToString();
            //dsc_wo_install.Value = woMapper.dsc_wo_install;
            //txt_wo_time.Text = woMapper.wo_time;
            //txt_wo_by.Text = woMapper.wo_by;
            //ddl_wo_round.SelectedValue = woMapper.wo_roundoff.ToString();
            //txtIntRmks.Text = woMapper.wo_internal_rmk;
        }

        private void BindEmptyData()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = createItemDT();
                gvWorkOder.DataSource = dt;
                gvWorkOder.DataBind();
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
                    divOverLayPopup.Style.Add("display", "block");
                    divPopupAlert.Style.Add("display", "block");
                }
                else
                {
                    divOverLayPopup.Style.Add("display", "none");
                    divPopupAlert.Style.Add("display", "none");
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
                if (Session["WOITEMS"] != null)
                    dtItems = (DataTable)Session["WOITEMS"];
                else
                    dtItems = createItemDT();
                DataRow dr = dtItems.NewRow();
                dr["Header"] = "";
                dr["Model"] = txtModel.Text;
                dr["Type"] = txtType.Text;
                dr["Description"] = txtDesc.Text;
                dr["Width"] = txtWidth.Text;
                dr["Height"] = txtHeight.Text;
                dr["Ctrl"] = txtCtrl.Text;
                dr["Set"] = txtSet.Text;
                dr["UOM"] = txtUOM.Text;
                dr["Coloumn"] = txtColumn.Text;
                dr["Qty"] = txtQuantity.Text;
                dr["UnitPrice"] = txtUnitPrice.Text;
                dr["TotalAmount"] = txtTotalPrice.Text;
                dtItems.Rows.Add(dr);
                gvWorkOder.DataSource = dtItems;
                gvWorkOder.DataBind();
                Session["WOITEMS"] = dtItems;
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
            //txtHeader.Text = "";
            txtModel.Text = "";
            txtType.Text = "";
            txtDesc.Text = "";
            txtWidth.Text = "";
            txtHeight.Text = "";
            txtCtrl.Text = "";
            txtSet.Text = "";
            txtUOM.Text = "";
            txtColumn.Text = "";
            txtQuantity.Text = "";
            txtUnitPrice.Text = "";
            txtTotalPrice.Text = "";
        }

        private void SavePurchaseItems()
        {
            WorkorderItemUIMapper woItemMapper = null;
            DataTable dtItems = new DataTable();
            try
            {
                if (Session["WOITEMS"] != null)
                {
                    woItemMapper = new WorkorderItemUIMapper();
                    dtItems = (DataTable)Session["WOITEMS"];
                    for (int i = 0; i < dtItems.Rows.Count; i++)
                    {
                        woItemMapper = new WorkorderItemUIMapper();
                        woItemMapper.wo_id = string.Empty;
                        woItemMapper.wo_item_id = i + 1;
                        woItemMapper.wo_item_header = dtItems.Rows[i]["Header"].ToString();
                        woItemMapper.wo_item_model = dtItems.Rows[i]["Model"].ToString();
                        woItemMapper.wo_item_type = dtItems.Rows[i]["Type"].ToString();
                        woItemMapper.wo_item_desc = dtItems.Rows[i]["Description"].ToString();
                        woItemMapper.wo_item_width = CommonFunctions.ConvertInt(dtItems.Rows[i]["Width"].ToString());
                        woItemMapper.wo_item_height = CommonFunctions.ConvertInt(dtItems.Rows[i]["Height"].ToString());
                        woItemMapper.wo_item_qty = CommonFunctions.ConvertInt(dtItems.Rows[i]["Qty"].ToString());
                        woItemMapper.wo_item_amt = CommonFunctions.ConvertInt(dtItems.Rows[i]["UnitPrice"].ToString());
                        woItemMapper.wo_item_tamt = CommonFunctions.ConvertInt(dtItems.Rows[i]["TotalAmount"].ToString());

                        new WorkorderAssembler().SaveWorkOrderItems(woItemMapper, Common.Operation.AddNew.ToString());
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
                if (Session["WOITEMS"] != null)
                {
                    dtItems = (DataTable)Session["WOITEMS"];
                    for (int i = 0; i < dtItems.Rows.Count; i++)
                    {
                        WorkorderItemUIMapper woItemMapper = new WorkorderItemUIMapper();
                        woItemMapper.wo_id = "";
                        woItemMapper.wo_item_id = CommonFunctions.ConvertInt(i.ToString());
                        woItemMapper.wo_item_model = txtModel.Text;
                        woItemMapper.wo_item_type = txtDesc.Text;
                        woItemMapper.wo_item_width = CommonFunctions.ConvertInt(txtWidth.Text);
                        woItemMapper.wo_item_height = CommonFunctions.ConvertInt(txtHeight.Text);
                        woItemMapper.wo_item_ctrl = txtCtrl.Text;
                        woItemMapper.wo_item_setno = CommonFunctions.ConvertInt(txtSet.Text);
                        //woItemMapper.wo_item_uom = 10;
                        //woItemMapper.wo_item_colu = 10;
                        woItemMapper.wo_item_qty = CommonFunctions.ConvertInt(txtQuantity.Text);
                        woItemMapper.wo_item_amt = CommonFunctions.ConvertInt(txtUnitPrice.Text);
                        woItemMapper.wo_item_tamt = CommonFunctions.ConvertInt(txtTotalPrice.Text);
                    }
                }
            }
            catch
            {
            }
        }

        private void clearAll()
        {
            wo_cust_id.Text = string.Empty;
            wo_cust_name.Text = string.Empty;
            txt_wo_resp.Text = string.Empty;
            txt_wo_address.Text = string.Empty;
            txt_wo_siteadd.Text = string.Empty;
            txt_wo_add2.Text = string.Empty;
            txt_wo_city.Text = string.Empty;
            txt_wo_siteadd2.Text = string.Empty;
            txt_wo_sitecity.Text = string.Empty;
            txt_wo_postal.Text = string.Empty;
            ddl_Country.SelectedValue = "";
            txt_wo_sitepos.Text = string.Empty;
            ddl_sitecountry.SelectedValue = "";
            txt_wo_contact.Text = string.Empty;
            txt_wo_sitecon.Text = string.Empty;
            txt_wo_tel.Text = string.Empty;
            txt_wo_Hp.Text = string.Empty;
            txt_wo_sitetel.Text = string.Empty;
            txt_wo_sitehp.Text = string.Empty;
            txt_wo_fax.Text = string.Empty;
            txt_wo_sitefax.Text = string.Empty;
            txt_wo_email.Text = string.Empty;
            txt_wo_siteemail.Text = string.Empty;
            wo_cust_id.Text = string.Empty;
            txt_wo_created.Text = string.Empty;
            txt_wo_qutrefno.Text = string.Empty;
            txt_wo_invrefno.Text = string.Empty;
            txt_wo_time.Text = string.Empty;
            txt_wo_by.Text = string.Empty;
            ddl_wo_round.SelectedValue = "";
            txtIntRmks.Text = string.Empty;
        }
    }
}