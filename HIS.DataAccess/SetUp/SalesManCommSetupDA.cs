using DataAccess.SQL2008;
using HIS.Common;
using HIS.Data.Mapper.SetUp;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Transactions;

namespace HIS.DataAccess.SetUp
{
    public class SalesManCommSetupDA
    {
        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_SALESMAN_COMM_SETUP_DETAILS)]
        public List<SalesManCommSetupMapper> GetSalesManCommSetupList()
        {
            var lsMapper = new StoredProcedureCommandBuilder().GetEntities<SalesManCommSetupMapper>(
                                   (MethodInfo)MethodInfo.GetCurrentMethod(), null);
            return lsMapper.ToList();
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.SALESMAN_COMM_SETUP_DETAILS_UPDATE)]
        public void UpdateSalesManCommDetails(SalesManCommSetupMapper mapper)
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
