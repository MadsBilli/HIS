using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Transactions;
using DataAccess.SQL2008;
using HIS.Common;
using HIS.Data.Mapper.PurchaseOrder;

namespace HIS.DataAccess.PurchaseOrder
{
    public class PurchaseOrderDA
    {
        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_QUOTATION_SCREEN_LISTVALUES)]
        public DataSet GetPurchaseOrderScreenListValues()
        {
            return new StoredProcedureCommandBuilder().ExecuteDataSet(
                                   (MethodInfo)MethodInfo.GetCurrentMethod(), null);
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER)]
        public void SavePurchaseOrder(PurchaseOrderMapper purord)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), purord);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER_ITEMS)]
        public void SavePurchaseOrderItems(PurchaseOrderItemMapper purord)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), purord);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_PURCHASEORDER_DETAILS)]
        public PurchaseOrderMapper GetPurchaseOrderDetails(string purchaseorderId)
        {
            var lsMapper = new StoredProcedureCommandBuilder().GetEntities<PurchaseOrderMapper>(
                                    (MethodInfo)MethodInfo.GetCurrentMethod(), null);
            return lsMapper.FirstOrDefault();
        }

        public DataSet SearchPurchaseOrderDetails(string where, string orderBy)
        {
            var command = new StoredProcedureCommandBuilder();
            AdhocStoredProcedureExecutionResult result =
                 command.ExecuteAdhocStoredProcedure(
                    StoredProcedureName.SEARCH_PURCHASEORDER_DETAILS,
                    new List<AdhocStoredProcedureInputParameters>
                    {
                        new AdhocStoredProcedureInputParameters
                            {
                                ParameterName = "@whereCondition",
                                ParameterDataType = SqlDbType.VarChar,
                                ParameterValue = where
                            },
                            new AdhocStoredProcedureInputParameters
                            {
                                ParameterName = "@orderBy",
                                ParameterDataType = SqlDbType.VarChar,
                                ParameterValue = orderBy
                            }
                    },
                    StoredProcedureEnums.StoredProcedureExecutionType.DataSet);
            return (DataSet)result.ExecutionResult;
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_SALESMAN_LIST)]
        public DataSet GetSalesmanList()
        {
            return new StoredProcedureCommandBuilder().ExecuteDataSet(
                                   (MethodInfo)MethodInfo.GetCurrentMethod(), null);
        }
    }
}
