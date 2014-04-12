using System;
using System.Data;
using System.Web.UI;
using HIS.UI.Assembler.Quotation;
using HIS.UI.Common;

namespace HIS.Pages.WorkOrder
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindDropdown();
        }

        private void BindDropdown()
        {
            var res = new QuotationAssembler().GetSalesmanList();
            ddlCreatedBy.DataSource = res.Tables[0].AsDataView();
            ddlCreatedBy.DataValueField = "emp_salesman_id";
            ddlCreatedBy.DataTextField = "emp_name";
            ddlCreatedBy.DataBind();
            CommonFunctions.InsertEmptyValueToddl(ddlCreatedBy);
        }

        protected void sortOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sortOrder.SelectedValue == "own")
                OwnSortPnl.Visible = true;
            else
                OwnSortPnl.Visible = false;
        }
    }
}