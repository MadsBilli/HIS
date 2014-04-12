using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using HIS.UI.Assembler.Quotation;
using HIS.UI.Common;

namespace HIS.Pages.Quotation
{
    public partial class QuotationSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindDropdown();
        }

        private void BindDropdown()
        {
            var res = new QuotationAssembler().GetSalesmanList();
            QuoteBy.DataSource = res.Tables[0].AsDataView();
            QuoteBy.DataValueField = "emp_salesman_id";
            QuoteBy.DataTextField = "emp_name";
            QuoteBy.DataBind();
            CommonFunctions.InsertEmptyValueToddl(QuoteBy);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            var res = new QuotationAssembler().SearchQuoteDetails(GetWhereCondition(), GetOrderby());
            gvQuoteItem.DataSource = res;
            gvQuoteItem.DataBind();
        }

        private string GetWhereCondition()
        {
            List<string> where = new List<string>();
            if (quoteStatus.SelectedValue != "-1")
            {
                if (quoteStatus.SelectedValue == "150")
                {
                    where.Add(" (quote.quote_statusid=150 or quote.quote_statusid=170)  ");
                }
                else
                {
                    where.Add(" quote.quote_statusid= " + quoteStatus.SelectedValue);
                }

            }

            if (txtQuoteRef.Text.Trim() != string.Empty)
            {
                where.Add(" quote.quote_id like '%" + txtQuoteRef.Text.Trim() + "%'");
            }
            if (QuoteBy.SelectedValue != "0")
            {
                where.Add(" quote.quote_by like '%" + QuoteBy.Text.Trim() + "%'");
            }
            if (txtCustomer.Text.Trim() != string.Empty)
            {
                where.Add(" quote.quote_cust_name like '%" + txtCustomer.Text.Trim() + "%'");
            }
            if (txtProject.Text.Trim() != string.Empty)
            {
                where.Add(" quote.quote_project like '%" + txtProject.Text.Trim() + "%'");
            }
            //if (Designer.SelectedValue  != "0")
            //{
            //    where.Add(" quote_designer like '%" + Designer.SelectedValue + "%'");
            //}
            if (QuoteDateFrom.HasValue && QuoteDateTo.HasValue)
            {
                where.Add(" quote_date >= convert(varchar,'" + QuoteDateFrom.Value.ToString("dd-MMM-yyyy") + "',112) and  quote_date <= convert(varchar,'" + QuoteDateTo.Value.ToString("dd-MMM-yyyy") + "',112) ");
            }
            if (QuoteDateFrom.HasValue && !QuoteDateTo.HasValue)
            {
                where.Add(" quote_date = convert(varchar,'" + QuoteDateFrom.Value.ToString("dd-MMM-yyyy") + "',112) ");
            }
            if (!QuoteDateFrom.HasValue && QuoteDateTo.HasValue)
            {
                where.Add(" quote_date = convert(varchar,'" + QuoteDateTo.Value.ToString("dd-MMM-yyyy") + "',112) ");
            }
            return string.Join(" and ", where);
        }

        private string GetOrderby()
        {
            List<string> order = new List<string>();
            if (sortby1.SelectedValue != "0")
                order.Add(sortby1.SelectedValue + " " + (sortOrder1.SelectedValue != null && sortOrder1.SelectedValue != "" ? sortOrder1.SelectedValue : string.Empty));
            //if (sortby2.SelectedValue != "0")
            //    order.Add(sortby2.SelectedValue + " " + (sortOrder2.SelectedValue != null && sortOrder2.SelectedValue != "" ? sortOrder2.SelectedValue : string.Empty));
            if (sortby3.SelectedValue != "0")
                order.Add(sortby3.SelectedValue + " " + (sortOrder3.SelectedValue != null && sortOrder3.SelectedValue != "" ? sortOrder3.SelectedValue : string.Empty));
            return string.Join(" , ", order);
        }

        protected void btnAddNewQuotation_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuotationAddEdit.aspx");
        }

        protected void gvPageIndexChangedEventHandler(object sender, GridViewPageEventArgs e)
        {
            try
            {
                CommonFunctions.SetGridViewPageIndex(gvQuoteItem, e.NewPageIndex);
                BindGrid();
            }
            catch (Exception ex)
            {
                string ErrorMessage = UI.ExceptionHandling.ExceptionMethodHandler.HandlesException(ex);
                ucValidationMessage.ErrorMessage = ErrorMessage;
                ucValidationMessage.Show();
            }
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