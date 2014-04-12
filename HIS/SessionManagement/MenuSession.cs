using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace HIS.UI.SessionManagement
{
    public class MenuSession
    {
        private HttpSessionState session_;

        public MenuSession(HttpSessionState session)
        {
            session_ = session;
        }



        public int MenuSelected
        {
            set { session_["MenuSelected"] = value; }
            get
            {
                try { return (int)session_["MenuSelected"]; }
                catch (Exception) { return 0; }    // initial value
            }
        }
    }
}