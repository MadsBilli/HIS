using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.SQL2008
{
    /// <summary>
    /// Execution result of stored procedure
    /// </summary>
    //======================================================================
    // Author: Hamid Widjaja
    // Date:23 July 2008
    // Revision History
    // ====================================================================== 
    public class AdhocStoredProcedureExecutionResult
    {
        /// <summary>
        /// Return scalar, DataReader, DataSet, number of rows affected.
        /// </summary>
        public object ExecutionResult { get; internal set; }
        /// <summary>
        /// Return output parameters of stored procedure
        /// </summary>
        public Dictionary<string, object> OutputParameters { get; internal set; }
    }

    /// <summary>
    /// Input parameters of Adhoc Stored Procedure
    /// </summary>
    //======================================================================
    // Author: Hamid Widjaja
    // Date:23 July 2008
    // Revision History
    // ====================================================================== 
    public class AdhocStoredProcedureInputParameters
    {
        /// <summary>
        /// Parameter name
        /// </summary>
        public string ParameterName { get; set; }
        /// <summary>
        /// Data type of parameter
        /// </summary>
        public SqlDbType ParameterDataType { get; set; }
        /// <summary>
        /// Output parameter size
        /// </summary>
        public int OutputParameterSize { get; set; }
        /// <summary>
        /// Input parameter direction (in or out)
        /// </summary>
        public StoredProcedureEnums.StoredProcedureParameterDirection ParameterDirection { get; set; }
        /// <summary>
        /// Value of parameter
        /// </summary>
        public object ParameterValue { get; set; }

        /// <summary>
        /// Scale
        /// </summary>
        public byte Scale { get; set; }

        /// <summary>
        /// Precision
        /// </summary>
        public byte Precision { get; set; }
    }
}
