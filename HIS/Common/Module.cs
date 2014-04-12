using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HIS.UI.SessionManagement;
using System.Data;
using HIS.UI.Assembler.InitialSetup;
using HIS.UI.Mapper.InitialSetup;
using HIS.UI.Mapper.EmployeeAdmin;

namespace HIS.UI.Common
{
    [Serializable]
    public class Module
    {
        private int pModuleId = 0;
        private string pModuleName = string.Empty;
        private string pURL = string.Empty;
        private int pSortOrder = 0;

        public int ModuleId
        {
            get { return pModuleId; }
            set { pModuleId = Convert.ToInt32(value); }
        }
        public string ModuleName
        {
            get { return pModuleName; }
            set { pModuleName = value; }
        }
        public string URL
        {
            get { return pURL; }
            set { pURL = value; }
        }
        public int SortOrder
        {
            get { return pSortOrder; }
            set { pSortOrder = value; }
        }

        public Module(int intModuleId, string strModuleName, string strURL, int intSortOrder)
        {
            ModuleId = intModuleId;
            ModuleName = strModuleName;
            URL = strURL;
            SortOrder = intSortOrder;
        }


        public static IEnumerable<Module> GetCGHModules()
        {
            List<Module> lstModule = new List<Module>();
            SessionManager session = new SessionManager();
            EmployeeAdminUIMapper user = new EmployeeAdminUIMapper();
            if (session.SessionUserExist())
            {
                user = session.GetSessionUser();

                InitialsetupUIMapper init = new InitialsetupAssembler().GetInitialSetup(user.emp_logname);
                if (init != null)
                {
                    Dictionary<string, string> parm = new Dictionary<string, string>();
                      
                    if (init.col_general)
                    {
                        parm.Clear();
                        parm.Add("menu", "4");
                        var enc = QueryStringHelper.EncryptQueryString(parm);
                        lstModule.Add(new Module(4, "General", "~/Pages/General.aspx?param=" + enc, 4));
                    }
                    if (init.col_finance)
                    {
                        parm.Clear();
                        parm.Add("menu", "1");
                        var enc = QueryStringHelper.EncryptQueryString(parm);
                        lstModule.Add(new Module(1, "Finance", "~/Pages/LandingPage.aspx?param=" + enc, 1));
                    }
                    if (init.col_vendor)
                    {
                        parm.Clear();
                        parm.Add("menu", "2");
                        var enc = QueryStringHelper.EncryptQueryString(parm);
                        lstModule.Add(new Module(2, "Vendor & Purchase", "~/Pages/LandingPage.aspx?param=" + enc, 2));
                    }
                    if (init.col_customer)
                    {
                        parm.Clear();
                        parm.Add("menu", "3");
                        var enc = QueryStringHelper.EncryptQueryString(parm);
                        lstModule.Add(new Module(3, "Customer & Sales", "~/Pages/LandingPage.aspx?param=" + enc, 3));
                    }

                }
            }
            return lstModule;

        }

    }
}