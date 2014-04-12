using DataAccess.SQL2008;
using HIS.Common;
using HIS.Data.Mapper.SetUp;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Transactions;

namespace HIS.DataAccess.SetUp
{
    public class BankAccountSetupDA
    {
        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_FinanceSetting_SETUP_DETAILS)]
        public List<BankAccountSetupMapper> GetFinanceSettingSetupList()
        {
            var lsMapper = new StoredProcedureCommandBuilder().GetEntities<BankAccountSetupMapper>(
                                   (MethodInfo)MethodInfo.GetCurrentMethod(), null);
            return lsMapper.ToList();
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.FINANCE_SETUP_DETAILS_UPDATE)]
        public void UpdateFinanceSettingDetails(BankAccountSetupMapper mapper)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), mapper);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.BANK_ACCT_NUM_SETUP_DETAILS_UPDATE)]
        public void UpdateBankAcctNumberDetails(BankAccountSetupMapper mapper)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), mapper);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.FINANCE_CTRL_PWD_UPDATE)]
        public void UpdateFinanceCtrlPwdDetails(BankAccountSetupMapper mapper)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), mapper);
                scope.Complete();
            }
        }
    }
}
