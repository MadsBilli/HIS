using DataAccess.SQL2008;
using HIS.Common;
using HIS.Data.Mapper.FabricCode;
using HIS.Data.Mapper.SetUp;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Transactions;


namespace HIS.DataAccess.SetUp
{
    public class SystemSetupDA
    {
        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_SYSTEM_SetUP_DETAILS)]
        public List<SystemSetupMapper> GetSystemSetup()
        {
            var lsSystemSetupMapper = new StoredProcedureCommandBuilder().GetEntities<SystemSetupMapper>(
                                    (MethodInfo)MethodInfo.GetCurrentMethod(), null);
            return lsSystemSetupMapper.ToList();
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.SYSTEM_SetUP_DETAILS_UPDATE)]
        public void UpdateSystemSetupDetails(SystemSetupMapper mapper)
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
