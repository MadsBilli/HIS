using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.SQL2008;
using System.Data;
using HIS.Common;
using System.Reflection;
using HIS.Data.Mapper.PurchaseInvoice;
using System.Transactions;

namespace HIS.DataAccess.PurchaseInvoice
{
    public class PurchaseInvoiceDA
    {
        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_QUOTATION_SCREEN_LISTVALUES)]
        public DataSet GetPurchaseInvoiceScreenListValues()
        {
            return new StoredProcedureCommandBuilder().ExecuteDataSet(
                                   (MethodInfo)MethodInfo.GetCurrentMethod(), null);
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE)]
        public void SavePurchaseInvoice(PurchaseInvoiceMapper purord)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), purord);
                scope.Complete();
            }
        }

        public DataSet SearchPurchaseInvoiceDetails(string where, string orderBy)
        {
            var command = new StoredProcedureCommandBuilder();
            AdhocStoredProcedureExecutionResult result =
                 command.ExecuteAdhocStoredProcedure(
                    StoredProcedureName.SEARCH_QUOTE_DETAILS,
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
