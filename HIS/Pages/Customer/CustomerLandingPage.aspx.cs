using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HIS.UI.SessionManagement;

namespace HIS.Pages.Customer
{
    public partial class CustomerLandingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuSession menuSession = new MenuSession(Session);
            menuSession.MenuSelected = 3;
        }
    }
}