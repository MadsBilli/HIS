using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using DataAccess.SQL2008;
using HIS.Common;

namespace HIS.Data.Mapper.SetUp
{
    public class tblTermsMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_TERMS, ParameterName = "@int_id", ParameterType = SqlDbType.Int, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.DELETE_TERM, ParameterName = "@int_id", ParameterType = SqlDbType.Int, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public int int_ID { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_TERMS, ParameterName = "@txtDescription", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string txtDescription { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_TERMS, ParameterName = "@txtType", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string txtType { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.GET_TERMSETUPDETAILS, ParameterName = "@txtSelect", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_TERMS, ParameterName = "@txtSelect", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string txtSelect { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_TERMS, ParameterName = "@operation", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Operation operation { get; set; }
    }
}
