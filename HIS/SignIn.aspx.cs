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

namespace HIS
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ViewState["incorrect"] = 0;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            EmployeeAdminUIMapper retLogin = new EmployeeAdminUIMapper();
            try
            {
                EmployeeAdminUIMapper login = new EmployeeAdminUIMapper();
                login.emp_logname = txtUserName.Text.Trim();
                login.emp_logpwd = txtPassword.Text.Trim();
                login.incorrect = ViewState["incorrect"].ToString();
                retLogin = new LoginAssembler().GetLoginDetails(login);
                SessionManager session = new SessionManager();
                session.StoreSessionUser(retLogin);
                Dictionary<string, string> parm = new Dictionary<string, string>();
                parm.Add("menu", "4");
                var enc = QueryStringHelper.EncryptQueryString(parm);
                //Response.Redirect("Pages/LandingPage.aspx?param=" + enc, false);
                Response.Redirect("Pages/Home.aspx?param=" + enc, false);
            }
            catch (System.Threading.ThreadAbortException)
            {
                //Do nothing.
            }
            catch (Exception ex)
            {
                //if (ViewState["incorrect"].ToString() == "3" || retLogin.account_disable)
                //{
                //}
                if (ex.Message == "SQL_ERROR_0004") //'Incorrect Login Name Please try again'
                {
                    txtUserName.Text = string.Empty;
                    ViewState["incorrect"] = CommonFunctions.ConvertToInt(ViewState["incorrect"].ToString()) + 1;
                }
                string ErrorMessage = UI.ExceptionHandling.ExceptionMethodHandler.HandlesException(ex);
                ucValidationMessage.ErrorMessage = ErrorMessage;
                ucValidationMessage.Show();
            }
        }
    }
}