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
    public partial class FinanceCtrlPwd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSave.Click += btnSave_Click;
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOldPwd.Text) || string.IsNullOrEmpty(txtNewPwd.Text))
            {
                ucValidationMessage.ErrorMessage = "Please enter in the password and new password to change.";
                ucValidationMessage.Show();
            }
            else
            {
                var uimapper = new BankAccountSetupAssembler().GetFinanceSettingSetupList();
                var oldPwd = uimapper.FinancialControlPW;
                if (oldPwd != txtOldPwd.Text)
                {
                    ucValidationMessage.ErrorMessage = "Invalid Password Detected!";
                    ucValidationMessage.Show();
                }
                else
                {
                    var mapper = new BankAccountSetupUIMapper {setup_id = 100, setup_pw = txtNewPwd.Text };
                    new BankAccountSetupAssembler().UpdateFinanceCtrlPwdDetails(mapper);
                    ucValidationMessage.SuccessMessage = "New Password Updated!";
                    ucValidationMessage.IsSuccess = true;
                    ucValidationMessage.Show();
                }
            }
        }
    }
}