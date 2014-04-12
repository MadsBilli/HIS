using System;

namespace DataAccess.SQL2008
{
    /// <summary>
    /// Stored Procedure attribute        
    /// </summary>    
    //======================================================================
    // Author: Hamid Widjaja
    // Date:3 July 2008
    // Revision History
    // ====================================================================== 
    [AttributeUsage(AttributeTargets.Method,AllowMultiple = false,Inherited = true)]
    public class StoredProcedureAttribute:Attribute
    {
        public string StoredProcedureName { get; set; }
    }
}
