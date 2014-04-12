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

namespace HIS.DataAccess.Receipts
{
    public class ReceiptsDA
    {
        public DataSet SearchReceipts(string where)
        {
            var command = new StoredProcedureCommandBuilder();
            AdhocStoredProcedureExecutionResult result =
                 command.ExecuteAdhocStoredProcedure(
                    StoredProcedureName.SEARCH_RECEIPTS,
                    new List<AdhocStoredProcedureInputParameters>
                    {
                        new AdhocStoredProcedureInputParameters
                            {
                                ParameterName = "@whereCondition",
                                ParameterDataType = SqlDbType.VarChar,
                                ParameterValue = where
                            }
                    },
                    StoredProcedureEnums.StoredProcedureExecutionType.DataSet);
            return (DataSet)result.ExecutionResult;
        }
    }
}
