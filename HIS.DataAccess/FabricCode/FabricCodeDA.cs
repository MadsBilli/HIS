using DataAccess.SQL2008;
using HIS.Common;
using HIS.Data.Mapper.FabricCode;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Transactions;

namespace HIS.DataAccess.FabricCode
{
    public class FabricCodeDA
    {
        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_FABRIC_TYPE_DETAILS)]
        public List<FabricTypeMapper> GetFabricTypes()
        {
            var lsFabricTypeMapper = new StoredProcedureCommandBuilder().GetEntities<FabricTypeMapper>(
                                    (MethodInfo)MethodInfo.GetCurrentMethod(), null);
            return lsFabricTypeMapper.ToList();
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_FABRIC_TYPE_DETAILS_BY_FABRIC_TYPE)]
        public FabricTypeMapper GetSelectedFabricType(FabricTypeMapper fctMapper)
        {
            var lsFabricTypeMapper = new StoredProcedureCommandBuilder().GetEntities<FabricTypeMapper>(
                                    (MethodInfo)MethodInfo.GetCurrentMethod(), fctMapper);
            return lsFabricTypeMapper.FirstOrDefault();
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_FABRICCODE_DETAILS)]
        public List<FabricCodeMapper> GetFabricCodeList(FabricCodeMapper fcMapper)
        {
            var lsFabricCodeMapper = new StoredProcedureCommandBuilder().GetEntities<FabricCodeMapper>(
                                   (MethodInfo)MethodInfo.GetCurrentMethod(), fcMapper);
            return lsFabricCodeMapper.ToList();
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_INSERT)]
        public void InsertFabricCodeDetails(FabricCodeMapper fabricCode)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), fabricCode);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DELETE)]
        public void DeleteFabricCode(FabricCodeMapper fabricCode)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), fabricCode);
                scope.Complete();
            }
        }
        
        [StoredProcedure(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_UPDATE)]
        public void UpdateFabricTypeDetails(FabricTypeMapper mapper)
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
