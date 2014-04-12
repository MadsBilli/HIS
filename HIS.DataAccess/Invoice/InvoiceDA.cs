using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Transactions;
using DataAccess.SQL2008;
using HIS.Common;
using HIS.Data.Mapper.Invoice;

namespace HIS.DataAccess.Invoice
{
    public class InvoiceDA
    {
        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_QUOTATION_SCREEN_LISTVALUES)]
        public DataSet GetInvoiceScreenListValues()
        {
            return new StoredProcedureCommandBuilder().ExecuteDataSet(
                                   (MethodInfo)MethodInfo.GetCurrentMethod(), null);
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.SAVE_INVOICE)]
        public void SaveInvoice(InvoiceMapper purord)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), purord);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.SAVE_INVOICE_ITEMS)]
        public void SaveInvoiceItems(InvoiceItemMapper purord)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), purord);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_INVOICE_DETAILS)]
        public InvoiceMapper GetInvoiceDetails(string InvoiceId)
        {
            var lsMapper = new StoredProcedureCommandBuilder().GetEntities<InvoiceMapper>(
                                    (MethodInfo)MethodInfo.GetCurrentMethod(), null);
            return lsMapper.FirstOrDefault();
        }

        public DataSet SearchInvoiceDetails(string where, string orderBy)
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
