using System;
using System.Data;
using DataAccess.SQL2008;


namespace DataAccess.SQL2008
{
    /// <summary>
    /// Stored Procedure parameter attribute
    /// </summary>
    //======================================================================
    // Author: Hamid Widjaja
    // Date:3 July 2008
    // Revision History
    //          Modified By  : Mohan
    //          Modification : Support to SQL 2008, Changed ParameterType DBType -> SQLDbType
    // ====================================================================== 
    [AttributeUsage(AttributeTargets.Property,AllowMultiple = true,Inherited = true)]
    public class StoredProcedureParameterAttribute:Attribute
    {
        public string StoredProcedureName { get; set; }
        public string ParameterName { get; set; }
        public StoredProcedureEnums.StoredProcedureParameterDirection ParameterDirection { get; set; }
        public SqlDbType ParameterType { get; set; }
        public int Size { get; set; }
        public byte Scale { get; set; }
        public byte Precision { get; set; }
    }
}
