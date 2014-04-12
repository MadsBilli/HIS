using HIS.UI.SessionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIS.Pages.Setup
{
    public partial class SetupLandingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuSession menuSession = new MenuSession(Session);
            menuSession.MenuSelected = 5;
        }
    }
}