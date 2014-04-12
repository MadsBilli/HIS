using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIS
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UI.SessionManagement.SessionManager session = new UI.SessionManagement.SessionManager();
            if (session.LogErrorMessageExist())
                litErrorMsg.Text = session.GetErrorMessage();
            if (session.LogErrorMessageExist())
                litErrorMsg.Text = session.GetErrorMessage();
        }
    }
}