using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using HIS.UI.Mapper.EmployeeAdmin;
using HIS.UI.Assembler.EmployeeAdmin;
using HIS.UI.SessionManagement;
using HIS.UI.Common;
using System.Web.Services;

namespace HIS.Pages.Setup
{
    public partial class UseLogListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                    BindDataGrid();
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

        private void BindDataGrid()
        {
            var res = new LoginAssembler().GetUserLoginListing();
            gvUseLogListing.DataSource = res;
            gvUseLogListing.PageSize = CommonFunctions.GetGridPageSize();
            gvUseLogListing.DataBind();
        }

        protected void gvUseLogListingGridRowDataBoundEneventHandler(object sender, GridViewRowEventArgs e)
        {
            try
            {
                GridViewRow row = e.Row;
                if (row != null)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        var user = row.DataItem as DataRowView;
                        if (user != null)
                        { 
                            Label lblConnectedTime = row.FindControl("lblConnectedTime") as Label;
                            lblConnectedTime.Text = GetConnectedTime(Convert.ToDateTime(user["log_datetime"]));
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

        private string GetConnectedTime(DateTime TempDate)
        {
            DateTime tempDate1 = Convert.ToDateTime(TempDate.ToString("dd-MMM-yyyy"));
            DateTime CurrentDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy"));


            if ((DateTime.Compare(tempDate1, CurrentDate) == 0))
            {
                if (DateTime.Compare(tempDate1, DateTime.Now) > 0)
                    return string.Empty;
                else
                    return DateTime.Now.Subtract(TempDate).Hours.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Subtract(TempDate).Minutes.ToString().PadLeft(2, '0') + " Hrs";
            }
            else
            {
                if (DateTime.Compare(tempDate1, DateTime.Now) < 0)
                {
                    int TempDays = Convert.ToInt32((DateTime.Now - tempDate1).TotalDays);
                    string TempHours = TempDate.ToString("HH:mm") + " Hrs";
                    return TempDays.ToString() + " Day(s) " + TempHours;
                }
            }
            return string.Empty;
        }

        protected void gvPageIndexChangedEventHandler(object sender, GridViewPageEventArgs e)
        {
            try
            {
                CommonFunctions.SetGridViewPageIndex(gvUseLogListing, e.NewPageIndex);
                this.BindDataGrid();
            }
            catch (Exception ex)
            {
                string ErrorMessage = UI.ExceptionHandling.ExceptionMethodHandler.HandlesException(ex);
                ucValidationMessage.ErrorMessage = ErrorMessage;
                ucValidationMessage.Show();
            }
        }

        protected void TerminateUser(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton btn = sender as ImageButton;
                if (btn != null)
                {
                    string keyField = btn.CommandArgument.Trim();
                    new LoginAssembler().UpdateTerminateUser(keyField);
                }
            }
            catch (Exception ex)
            {
                string ErrorMessage = UI.ExceptionHandling.ExceptionMethodHandler.HandlesException(ex);
                ucValidationMessage.ErrorMessage = ErrorMessage;
                ucValidationMessage.Show();
            }
        }
    }
}