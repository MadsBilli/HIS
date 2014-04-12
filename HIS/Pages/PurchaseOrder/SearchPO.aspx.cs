using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using HIS.UI.Assembler.PurchaseOrder;
using HIS.UI.Common;

namespace HIS.Pages.PurchaseOrder
{
    public partial class SearchPO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDropdown();
                BindData();
            }
        }

        private void BindDropdown()
        {
            var res = new PurchaseOrderAssembler().GetSalesmanList();
            CreatedBy.DataSource = res.Tables[0].AsDataView();
            CreatedBy.DataValueField = "emp_salesman_id";
            CreatedBy.DataTextField = "emp_name";
            CreatedBy.DataBind();
            CommonFunctions.InsertEmptyValueToddl(CreatedBy);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            divResults.Style.Add("display", "block");
            BindGrid();
        }

        private void BindGrid()
        {
            var res = new PurchaseOrderAssembler().SearchPurchaseOrderDetails(GetWhereCondition(), String.Empty);
            gvPO.DataSource = res;
            gvPO.DataBind();
        }

        private string GetWhereCondition()
        {
            List<string> where = new List<string>();
            if (quoteStatus.SelectedValue != "-1")
                where.Add(" po.po_statusid= " + quoteStatus.SelectedValue);
            if (txtQuoteRef.Text.Trim() != string.Empty)
                where.Add(" po.quote_id like '%" + txtQuoteRef.Text.Trim() + "%'");
            if (txtWORef.Text.Trim() != string.Empty)
                where.Add(" po.wo_id like '%" + txtWORef.Text.Trim() + "%'");
            if (CreatedBy.SelectedValue != "0")
                where.Add(" po.po_by like '%" + CreatedBy.Text.Trim() + "%'");
            if (txtSupplierName.Text.Trim() != string.Empty)
                where.Add(" po.po_cust_name like '%" + txtSupplierName.Text.Trim() + "%'");

            if (DateFrom.HasValue && DateTo.HasValue)
                where.Add(" po_date >= convert(varchar,'" + DateFrom.Value.ToString("dd-MMM-yyyy") + "',112) and  po_date <= convert(varchar,'" + DateTo.Value.ToString("dd-MMM-yyyy") + "',112) ");
            if (DateFrom.HasValue && !DateTo.HasValue)
                where.Add(" po_date = convert(varchar,'" + DateFrom.Value.ToString("dd-MMM-yyyy") + "',112) ");
            if (!DateFrom.HasValue && DateTo.HasValue)
                where.Add(" po_date = convert(varchar,'" + DateTo.Value.ToString("dd-MMM-yyyy") + "',112) ");
            return string.Join(" and ", where);
        }

        protected void btnAddNewPO_Click(object sender, EventArgs e)
        {
            Response.Redirect("PurchaseOrder.aspx");
        }

        protected void gvPageIndexChangedEventHandler(object sender, GridViewPageEventArgs e)
        {
            try
            {
                CommonFunctions.SetGridViewPageIndex(gvPO, e.NewPageIndex);
                BindGrid();
            }
            catch (Exception ex)
            {
                string ErrorMessage = UI.ExceptionHandling.ExceptionMethodHandler.HandlesException(ex);
                ucValidationMessage.ErrorMessage = ErrorMessage;
                ucValidationMessage.Show();
            }
        }

        private void BindData()
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add("quote_id");
                dt.Columns.Add("CustName");
                dt.Columns.Add("quote_date");
                dt.Columns.Add("quote_by");
                dt.Columns.Add("quote_by2");
                dt.Columns.Add("quote_statusdesc");
                dt.Columns.Add("quote_subject");
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                gvPO.DataSource = dt;
                gvPO.DataBind();
                gvPO.Rows[0].Visible = false;
            }
            catch
            {
            }
        }
    }
}