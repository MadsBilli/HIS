using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HIS.Common;
using HIS.UI.Mapper.PurchaseInvoice;
using HIS.UI.Assembler.PurchaseInvoice;

namespace HIS.Pages.PurchaseInvoice
{
    public partial class PurchaseInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindEmptyData();
        }

        private void BindEmptyData()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = createItemDT();
                gvInvoice.DataSource = dt;
                gvInvoice.DataBind();
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
                dr["Invoice"] = txtInvoiceNo.Text;
                dr["Order"] = txtOrder.Text;
                dr["Re"] = txtRe.Text;
                dr["Unit"] = txtUnit.Text;
                dr["Desc"] = txtDesc.Text;
                dr["Price"] = txtPrice.Text;
                dr["Tax"] = txtTax.Text;
                dr["GST"] = txtGSTNo.Text;
                dr["Amount"] = txtAmount.Text;
                dr["AccCode"] = txtAccCode.Text;
                dr["Supplier"] = txtSupplier.Text;
                dr["Rec"] = txtRec.Text;
                dr["InvoiceNumber"] = txtInvoiceNumber.Text;
                dr["WOID"] = txtWOID.Text;
                dtItems.Rows.Add(dr);
                gvInvoice.DataSource = dtItems;
                gvInvoice.DataBind();
                Session["ITEMS"] = dtItems;
            }
            catch
            {
            }
        }

        private DataTable createItemDT()
        {
            DataTable dtItems = new DataTable();
            dtItems.Columns.Add("Invoice");
            dtItems.Columns.Add("Order");
            dtItems.Columns.Add("Re");
            dtItems.Columns.Add("Unit");
            dtItems.Columns.Add("Desc");
            dtItems.Columns.Add("Price");
            dtItems.Columns.Add("Tax");
            dtItems.Columns.Add("GST");
            dtItems.Columns.Add("Amount");
            dtItems.Columns.Add("AccCode");
            dtItems.Columns.Add("Supplier");
            dtItems.Columns.Add("Rec");
            dtItems.Columns.Add("InvoiceNumber");
            dtItems.Columns.Add("WOID");
            return dtItems;
        }

        private void ClearItenDetails()
        {
            txtInvoiceNo.Text = String.Empty;
            txtOrder.Text = String.Empty;
            txtRe.Text = String.Empty;
            txtUnit.Text = String.Empty;
            txtDesc.Text = String.Empty;
            txtPrice.Text = String.Empty;
            txtTax.Text = String.Empty;
            txtGSTNo.Text = String.Empty;
            txtAmount.Text = String.Empty;
            txtAccCode.Text = String.Empty;
            txtSupplier.Text = String.Empty;
            txtRec.Text = String.Empty;
            txtInvoiceNumber.Text = String.Empty;
            txtWOID.Text = String.Empty;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtItems = new DataTable();
            try
            {
                if (Session["ITEMS"] != null)
                {
                    dtItems = (DataTable)Session["ITEMS"];
                    for (int i = 0; i < dtItems.Rows.Count; i++)
                    {
                        PurchaseInvoiceUIMapper purinvMapper = new PurchaseInvoiceUIMapper();

                        purinvMapper.pur_id = hdnInvoiceId.Value;
                        purinvMapper.puchase_from = ddlPurchaseFrom1.SelectedValue;
                        purinvMapper.po_no = ddlPONumber.SelectedValue;
                        purinvMapper.invoice = txtInvoice.Text;
                        purinvMapper.pi_date = InvoiceDate.Value;
                        purinvMapper.pi_acct = txtFilledAllAcct.Text;
                        purinvMapper.pi_default_acc_code = txtDefaultMaterialCode.Text;
                        purinvMapper.pi_balance_code = txtBalanceAmount.Text;
                        purinvMapper.pi_sub_Total = txtSubTotal.Text;
                        purinvMapper.pi_gst = txtGST.Text;
                        purinvMapper.pi_Total = txtTotal.Text;
                        purinvMapper.pi_item_id = dtItems.Rows[i]["Invoice"].ToString();
                        purinvMapper.pi_item_order = dtItems.Rows[i]["Order"].ToString();
                        purinvMapper.pi_item_Re = dtItems.Rows[i]["Re"].ToString();
                        purinvMapper.pi_item_Unit = dtItems.Rows[i]["Unit"].ToString();
                        purinvMapper.pi_item_Desc = dtItems.Rows[i]["Desc"].ToString();
                        purinvMapper.pi_item_Price = dtItems.Rows[i]["Price"].ToString();
                        purinvMapper.pi_item_Tax = dtItems.Rows[i]["Tax"].ToString();
                        purinvMapper.pi_item_Gst = dtItems.Rows[i]["GST"].ToString();
                        purinvMapper.pi_item_amount = CommonFunctions.ConvertInt(dtItems.Rows[i]["Amount"].ToString());
                        purinvMapper.pi_item_Acccode = dtItems.Rows[i]["AccCode"].ToString();
                        purinvMapper.pi_item_Suplier = dtItems.Rows[i]["Supplier"].ToString();
                        purinvMapper.pi_item_Rec = dtItems.Rows[i]["Rec"].ToString();
                        purinvMapper.pi_item_InoviceNumber = dtItems.Rows[i]["InvoiceNumber"].ToString();
                        purinvMapper.pi_item_woid = dtItems.Rows[i]["WOID"].ToString();
                        new PurchaseInvoiceAssembler().SavePurchaseOrder(purinvMapper, Common.Operation.AddNew.ToString());
                    }
                }
                BindEmptyData();
                clearAll();
                Page.RegisterStartupScript("alert", "<script>alert('Purchase Invoice saved sucessfully');</script>");
            }
            catch
            {
            }
        }

        private void clearAll()
        {
            TextBox1.Text = string.Empty;
            ddlPONumber.SelectedValue = "";
            txtInvoice.Text = String.Empty;
            txtFilledAllAcct.Text = String.Empty;
            txtBalanceAmount.Text = String.Empty;
            txtSubTotal.Text = String.Empty;
            txtGST.Text = String.Empty;
            txtTotal.Text = String.Empty;
            txtTrackingNumber.Text = String.Empty;
        }
    }
}