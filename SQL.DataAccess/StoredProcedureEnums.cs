namespace DataAccess.SQL2008
{
    /// <summary>
    /// Stored Procedure enumerations
    /// </summary>    
    //======================================================================
    // Author: Hamid Widjaja
    // Date:3 July 2008
    // Revision History
    // ====================================================================== 
    public class StoredProcedureEnums
    {
        public enum StoredProcedureParameterDirection
        {
            In,
            Out,
            InOut
        }

        public enum StoredProcedureExecutionType
        {
            Scalar,
            NonQuery,
            DataSet,
            DataReader
        }
    }
}
