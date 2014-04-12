using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using HIS.Common;
using HIS.Data.Mapper.Workorder;
using DataAccess.SQL2008;
using System.Reflection;
using System.Data;

namespace HIS.DataAccess.Workorder
{
    public class WorkorderDA
    {
        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_WORKORDER_SCREEN_LISTVALUES)]
        public DataSet GetWorkorderScreenListValues()
        {
            return new StoredProcedureCommandBuilder().ExecuteDataSet(
                                   (MethodInfo)MethodInfo.GetCurrentMethod(), null);
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.SAVE_WORKORDER)]
        public void SavePurchaseOrder(WorkOrderMapper workorder)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), workorder);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.SAVE_WORKORDER_ITEMS)]
        public void SavePurchaseOrderItems(WorkorderitemMapper workorder)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), workorder);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_WORKORDER_DETAILS)]
        public WorkOrderMapper GetPurchaseOrderDetails(string purchaseorderId)
        {
            var lsMapper = new StoredProcedureCommandBuilder().GetEntities<WorkOrderMapper>(
                                    (MethodInfo)MethodInfo.GetCurrentMethod(), null);
            return lsMapper.FirstOrDefault();
        }

        public DataSet SearchworkorderDetails(string where, string orderBy)
        {
            var command = new StoredProcedureCommandBuilder();
            AdhocStoredProcedureExecutionResult result =
                 command.ExecuteAdhocStoredProcedure(
                    StoredProcedureName.SEARCH_WORKORDER_DETAILS,
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
            return new StoredProcedureCommandBuilder().ExecuteDataSet((MethodInfo)MethodInfo.GetCurrentMethod(), null);
        }
    }
}
