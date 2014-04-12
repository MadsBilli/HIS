using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HIS.UI.Mapper.InitialSetup;
using HIS.Common;
using HIS.UI.SessionManagement;
using HIS.UI.Assembler.InitialSetup;
using HIS.UI.Mapper.EmployeeAdmin;

namespace HIS
{
    public partial class General : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MenuSession menuSession = new MenuSession(Session);
                menuSession.MenuSelected = 4;

                if (!Page.IsPostBack)
                {
                    BindFields();
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

        private void BindFields()
        {
            SessionManager session = new SessionManager();
            EmployeeAdminUIMapper user = new EmployeeAdminUIMapper();
            if (session.SessionUserExist())
            {
                user = session.GetSessionUser();

                InitialsetupUIMapper init = new InitialsetupAssembler().GetInitialSetup(user.emp_logname);
                chkGeneral.Checked = init.col_general;
                chkFinance.Checked = init.col_finance;
                chkVenPur.Checked = init.col_vendor;
                chkCustSales.Checked = init.col_customer;
                chkManagement.Checked = init.col_management;
                chkAdmin.Checked = init.col_administrator;
                chkQuotegst.Checked = init.pf_show_gst;
                chkSetpogst.Checked = init.pf_show_gst_po;
                chkShowSign.Checked = init.pf_show_signature;
                chkShowBankOn.Checked = init.pf_show_bank;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try{
            SessionManager session = new SessionManager();
            string user = string.Empty;
            if(session.SessionUserExist())
                user = session.GetSessionUser().emp_logname;
            InitialsetupUIMapper mapper = new InitialsetupUIMapper();
                mapper.emp_logname = user;
                mapper.col_general = chkGeneral.Checked;
                mapper.col_finance = chkFinance.Checked;
                mapper.col_vendor = chkVenPur.Checked;
                 mapper.col_customer = chkCustSales.Checked;
                mapper.col_management = chkManagement.Checked;
                mapper.col_administrator = chkAdmin.Checked;
                mapper.pf_show_gst = chkQuotegst.Checked;
                mapper.pf_show_gst_po= chkSetpogst.Checked; 
                mapper.pf_show_signature = chkShowSign.Checked;
                mapper.pf_show_bank = chkShowBankOn.Checked;
                new InitialsetupAssembler().SaveInitialSetup(mapper);
                BindFields();
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

        protected void btnApplyChanges_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}