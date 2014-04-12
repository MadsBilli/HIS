using DataAccess.SQL2008;
using HIS.Common;
using HIS.Data.Mapper.SetUp;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Transactions;

namespace HIS.DataAccess.SetUp
{
    public class UOMSetupDA
    {
        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_UOM_SETUP_DETAILS)]
        public List<UOMSetupMapper> GetUOMSetupList()
        {
            var lsMapper = new StoredProcedureCommandBuilder().GetEntities<UOMSetupMapper>(
                                   (MethodInfo)MethodInfo.GetCurrentMethod(), null);
            return lsMapper.ToList();
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.UOM_SETUP_DETAILS_INSERT)]
        public void InsertorUpdateUOMDetails(UOMSetupMapper mapper)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), mapper);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.UOM_SETUP_DETAILS_DELETE)]
        public void DeleteUOM(UOMSetupMapper mapper)
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
