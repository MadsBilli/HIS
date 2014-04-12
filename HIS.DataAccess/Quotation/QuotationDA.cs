using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using HIS.Common;
using HIS.Data.Mapper.Quotation;
using DataAccess.SQL2008;
using System.Reflection;

namespace HIS.DataAccess.Quotation
{
    public class QuotationDA
    {
        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_QUOTATION_SCREEN_LISTVALUES)]
        public DataSet GetQuotationScreenListValues()
        {
            return new StoredProcedureCommandBuilder().ExecuteDataSet(
                                   (MethodInfo)MethodInfo.GetCurrentMethod(), null);
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.SAVE_QUOTE)]
        public void SaveQuote(QuotationMapper quot)
        //public void SaveQuote(DataTable dtQuote, string operation)
        {
            //var command = new StoredProcedureCommandBuilder();
            //AdhocStoredProcedureExecutionResult result =
            //     command.ExecuteAdhocStoredProcedure(
            //        StoredProcedureName.SAVE_QUOTE,
            //        new List<AdhocStoredProcedureInputParameters>
            //        {
            //            new AdhocStoredProcedureInputParameters
            //                {
            //                    ParameterName = "@quotes",
            //                    ParameterDataType = SqlDbType.Structured,
            //                    ParameterValue = dtQuote
            //                },
            //                new AdhocStoredProcedureInputParameters
            //                {
            //                    ParameterName = "@operation",
            //                    ParameterDataType = SqlDbType.VarChar,
            //                    ParameterValue = operation
            //                }
            //        },
            //        StoredProcedureEnums.StoredProcedureExecutionType.NonQuery);

            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), quot);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_QUOTE_DETAILS)]
        public QuotationMapper GetQuoteDetails(string quoteId)
        {
            var lsMapper = new StoredProcedureCommandBuilder().GetEntities<QuotationMapper>(
                                    (MethodInfo)MethodInfo.GetCurrentMethod(), null);
            return lsMapper.FirstOrDefault();
        }

        public DataSet SearchQuoteDetails(string where, string orderBy)
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
