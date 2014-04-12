using DataAccess.SQL2008;
using HIS.Common;
using HIS.Data.Mapper.SetUp;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Transactions;


namespace HIS.DataAccess.SetUp
{
    public class BUNameSetupDA
    {
        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_BU_NAME_SETUP_DETAILS)]
        public List<BUNameSetupMapper> GetBUNameSetupList()
        {
            var lsMapper = new StoredProcedureCommandBuilder().GetEntities<BUNameSetupMapper>(
                                   (MethodInfo)MethodInfo.GetCurrentMethod(), null);
            return lsMapper.ToList();
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.BU_NAME_SETUP_DETAILS_INSERT)]
        public void InsertorUpdateBUNameDetails(BUNameSetupMapper mapper)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), mapper);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.BU_NAME_SETUP_DETAILS_DELETE)]
        public void DeleteBUName(BUNameSetupMapper mapper)
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
