using HIS.UI.Assembler.Setup;
using HIS.UI.Mapper.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIS.Pages.Setup
{
    public partial class FinanceSettingSetup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                LoadUserControls();
        }

        private void LoadUserControls()
        {
            Control ucSimpleControl = new Control();           
            switch (ddlSetupType.SelectedValue)
            {
                case "1":
                    ucSimpleControl = (Control)LoadControl("~/Pages/Setup/UserControls/BankAcctUpdate.ascx");
                    break;
                case "2":
                    ucSimpleControl = (Control)LoadControl("~/Pages/Setup/UserControls/BankAcctNumber.ascx");
                    break;
                case "3":
                    ucSimpleControl = (Control)LoadControl("~/Pages/Setup/UserControls/ActiveFinanceMonth.ascx");
                    break;
                case "4":
                    ucSimpleControl = (Control)LoadControl("~/Pages/Setup/UserControls/LinkAccounts.ascx");
                    break;
                case "6":
                    ucSimpleControl = (Control)LoadControl("~/Pages/Setup/UserControls/FinanceCtrlPwd.ascx");
                    break;
            }
            Placeholder1.Controls.Add(ucSimpleControl);            
        }

        [WebMethod]
        public static string GetSGDAccountNumber()
        {
            var uimapper = new BankAccountSetupAssembler().GetFinanceSettingSetupList();
            return uimapper.SGDBankAccountNumber;
        }

        [WebMethod]
        public static string GetUSDAccountNumber()
        {
            var uimapper = new BankAccountSetupAssembler().GetFinanceSettingSetupList();
            return uimapper.USDBankAccountNumber;
        }

        [WebMethod]
        public static string UpdateSGDAccountNumber(string value)
        {
            var uimapper = new BankAccountSetupUIMapper();
            uimapper.setup_value = value.ToString();
            uimapper.setup_id = 10;
            new BankAccountSetupAssembler().UpdateBankAcctNumberDetails(uimapper);
            return "Success";
        }

        [WebMethod]
        public static string UpdateUSDAccountNumber(string value)
        {
            var uimapper = new BankAccountSetupUIMapper();
            uimapper.setup_value = value.ToString();
            uimapper.setup_id = 20;
            new BankAccountSetupAssembler().UpdateBankAcctNumberDetails(uimapper);
            return "Success";
        }

        [WebMethod]
        public static Dictionary<string,string> GetBankAccCodes()
        {
            return new LinkAccountSetupAssembler().GetAccCodeList().ToDictionary(x => x.acc_code, x => x.acc_bank_code);
        }
        [WebMethod]
        public static string GetAccGLSetupByGLType(string value)
        {
            var result = new LinkAccountSetupAssembler().GetAccGLSetupByGLType(value);
           return result.gl_acc_code;
        }
        [WebMethod]
        public static string SetAccGLSetup(string type, string value)
        {
            new LinkAccountSetupAssembler().SetAccGLSetup(type,value);
            return "Success";
        }

        [WebMethod]
        public static Dictionary<string, string> GetBankAccCodesForVendorsPurchasesCUstomers()
        {
            return new LinkAccountSetupAssembler().GetBankAccCodeList().ToDictionary(x => x.acc_code, x => x.acc_bank_code);
        }

        [WebMethod]
        public static Dictionary<string, string> GetPayablesAccCodeList()
        {
            return new LinkAccountSetupAssembler().GetPayablesAccCodeList().ToDictionary(x => x.acc_code, x => x.acc_bank_code);
        }

        [WebMethod]
        public static Dictionary<string, string> GetAllAccCodeList()
        {
            return new LinkAccountSetupAssembler().GetAllAccCodeList().ToDictionary(x => x.acc_code, x => x.acc_bank_code);
        }

         [WebMethod]
        public static Dictionary<string, string> GetReceivablesAccCodeList()
        {
            return new LinkAccountSetupAssembler().GetReceivablesAccCodeList().ToDictionary(x => x.acc_code, x => x.acc_bank_code);
        }
        

        [WebMethod]
        public static AccGLTypeSetupUIMapper GetAccGLSetupValuesByGLType(string value)
        {
            var result = new LinkAccountSetupAssembler().GetAccGLSetupByGLType(value);
            return result;
        }

        [WebMethod]
        public static string SaveDetails(AccGLTypeSetupUIMapper[] uiMapper)
        {
            foreach (var mappper in uiMapper)
            {
                new LinkAccountSetupAssembler().SetAccGLSetup(mappper);
            }           
            return "true";
        }
    }
}
