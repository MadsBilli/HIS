using HIS.Implementation.Setup;
using HIS.UI.Mapper.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UI.Assembler.Setup
{
    public class BankAccountSetupAssembler
    {
        public BankAccountSetupUIMapper GetFinanceSettingSetupList()
        {
            FinanceSettingSetupImpl Impl = new FinanceSettingSetupImpl();
            return Impl.GetFinanceSettingSetupList();
        }

        public void InsertorUpdateFinanceSettingSetupDetails(BankAccountSetupUIMapper uiMapper)
        {
            FinanceSettingSetupImpl Impl = new FinanceSettingSetupImpl();
            Impl.UpdateFinanceSettingDetails(uiMapper);
        }

        public void UpdateBankAcctNumberDetails(BankAccountSetupUIMapper uiMapper)
        {
            FinanceSettingSetupImpl Impl = new FinanceSettingSetupImpl();
            Impl.UpdateBankAccountNumberDetails(uiMapper);
        }
        public void UpdateFinanceCtrlPwdDetails(BankAccountSetupUIMapper uiMapper)
        {
            FinanceSettingSetupImpl Impl = new FinanceSettingSetupImpl();
            Impl.UpdateFinanceCtrlPwdDetails(uiMapper);
        }
    }
}
