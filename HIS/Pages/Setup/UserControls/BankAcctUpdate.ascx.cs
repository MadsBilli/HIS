using HIS.UI.Assembler.Setup;
using HIS.UI.Mapper.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIS.Pages.Setup.UserControls
{
    public partial class BankAcctUpdate : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetBankAccountInfo();
            btnSave.Click += new EventHandler(imgbtnSave_Click);
        }

        private void GetBankAccountInfo()
        {
            var uimapper = new BankAccountSetupAssembler().GetFinanceSettingSetupList();
            txtBankName.Text = uimapper.BankName;
            txtAddress1.Text = uimapper.BankAdd1;
            txtAddress2.Text = uimapper.BankAdd2;
            txtAddress3.Text = uimapper.BankAdd3;
            txtSGDAcct.Text = uimapper.SGDBankAccountNumber;
            txtUSDAcct.Text = uimapper.USDBankAccountNumber;
            chkShowIvoice.Checked = uimapper.ShowRemitBankAccinInv == "0" ? false : true;
        }

        protected void imgbtnSave_Click(object sender, EventArgs e)
        {
            var uimapper = new BankAccountSetupUIMapper();
            uimapper.BankName = txtBankName.Text;
            uimapper.BankAdd1 = txtAddress1.Text;
            uimapper.BankAdd2 = txtAddress2.Text;
            uimapper.BankAdd3 = txtAddress3.Text;
            uimapper.SGDBankAccountNumber = txtSGDAcct.Text;
            uimapper.USDBankAccountNumber = txtUSDAcct.Text;
            uimapper.ShowRemitBankAccinInv = chkShowIvoice.Checked ? "1" : "0";
            new BankAccountSetupAssembler().InsertorUpdateFinanceSettingSetupDetails(uimapper);
        }
    }
}