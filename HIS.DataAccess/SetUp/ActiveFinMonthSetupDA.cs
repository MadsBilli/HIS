using DataAccess.SQL2008;
using HIS.Common;
using HIS.Data.Mapper.SetUp;
using HIS.UI.Mapper.Setup;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Transactions;

namespace HIS.DataAccess.SetUp
{
    public class ActiveFinMonthSetupDA
    {
        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_Active_FINYEAR_SETUP_DETAILS)]
        public FinYearSetupMapper GetActiveFinanceYearInfo()
        {
            var lsMapper = new StoredProcedureCommandBuilder().GetEntities<FinYearSetupMapper>(
                                 (MethodInfo)MethodInfo.GetCurrentMethod(), null);
            return lsMapper.FirstOrDefault();
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_Active_FINMONTH_SETUP_DETAILS)]
        public FinMonthSetupMapper GetFinanceMonthInfo(FinMonthSetupMapper mapper)
        {
            var lsMapper = new StoredProcedureCommandBuilder().GetEntities<FinMonthSetupMapper>(
                                 (MethodInfo)MethodInfo.GetCurrentMethod(), mapper);
            return lsMapper.FirstOrDefault();
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.SET_Active_FINMONTH_SETUP_DETAILS)]
        public void SetActiveFinanceMonthInfo(FinMonthSetupMapper mapper)
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
