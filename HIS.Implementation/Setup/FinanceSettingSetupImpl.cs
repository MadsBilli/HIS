using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.UI.Mapper.Setup;
using HIS.DataAccess.SetUp;
using HIS.Data.Mapper.SetUp;

namespace HIS.Implementation.Setup
{
    public class FinanceSettingSetupImpl
    {
        public BankAccountSetupUIMapper GetFinanceSettingSetupList()
        {
            BankAccountSetupDA da = new BankAccountSetupDA();
            var lsMapper = da.GetFinanceSettingSetupList();

            var res = new BankAccountSetupUIMapper
                       {
                           BankName = lsMapper.Where(x => x.setup_id == 30).Select(x => x.setup_value).FirstOrDefault(),
                           BankAdd1 = lsMapper.Where(x => x.setup_id == 40).Select(x => x.setup_value).FirstOrDefault(),
                           BankAdd2 = lsMapper.Where(x => x.setup_id == 50).Select(x => x.setup_value).FirstOrDefault(),
                           BankAdd3 = lsMapper.Where(x => x.setup_id == 60).Select(x => x.setup_value).FirstOrDefault(),
                           SGDBankAccountNumber = lsMapper.Where(x => x.setup_id == 10).Select(x => x.setup_value).FirstOrDefault(),
                           ShowRemitBankAccinInv = lsMapper.Where(x => x.setup_id == 70).Select(x => x.setup_value).FirstOrDefault(),
                           USDBankAccountNumber = lsMapper.Where(x => x.setup_id == 20).Select(x => x.setup_value).FirstOrDefault(),
                           FinancialControlPW = lsMapper.Where(x => x.setup_id == 100).Select(x => x.setup_pw).FirstOrDefault()
                       };
            return res;
        }

        public void UpdateFinanceSettingDetails(BankAccountSetupUIMapper uiMapper)
        {
            BankAccountSetupMapper mapper = new BankAccountSetupMapper
            {
                BankName = uiMapper.BankName,
                BankAdd1 = uiMapper.BankAdd1,
                BankAdd2 = uiMapper.BankAdd2,
                BankAdd3 = uiMapper.BankAdd3,
                SGDBankAccountNumber = uiMapper.SGDBankAccountNumber,
                USDBankAccountNumber = uiMapper.USDBankAccountNumber,
                ShowRemitBankAccinInv = uiMapper.ShowRemitBankAccinInv,
                FinancialControlPW = uiMapper.FinancialControlPW
            };

            BankAccountSetupDA da = new BankAccountSetupDA();
            da.UpdateFinanceSettingDetails(mapper);
        }
        public void UpdateBankAccountNumberDetails(BankAccountSetupUIMapper uiMapper)
        {
            BankAccountSetupMapper mapper = new BankAccountSetupMapper
            {
               setup_id = uiMapper.setup_id,
               setup_value = uiMapper.setup_value
            };

            BankAccountSetupDA da = new BankAccountSetupDA();
            da.UpdateBankAcctNumberDetails(mapper);
        }

        public void UpdateFinanceCtrlPwdDetails(BankAccountSetupUIMapper uiMapper)
        {
            BankAccountSetupMapper mapper = new BankAccountSetupMapper
            {
                setup_id = uiMapper.setup_id,
                setup_pw = uiMapper.setup_pw
            };

            BankAccountSetupDA da = new BankAccountSetupDA();
            da.UpdateFinanceCtrlPwdDetails(mapper);
        }   
    }
}
