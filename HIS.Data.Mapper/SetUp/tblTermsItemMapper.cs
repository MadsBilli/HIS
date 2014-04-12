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
    public class tblTermsItemMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.DELETE_TERM_ITEMS, ParameterName = "@int_id", ParameterType = SqlDbType.Int, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_TERM_ITEMS, ParameterName = "@int_id", ParameterType = SqlDbType.Int, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public int int_ID { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_TERM_ITEMS, ParameterName = "@intTermID", ParameterType = SqlDbType.Int, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public int intTermID { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_TERM_ITEMS, ParameterName = "@txtLN", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string txtLN { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_TERM_ITEMS, ParameterName = "@txtDescription", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string txtDescription { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_TERM_ITEMS, ParameterName = "@operation", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Operation operation { get; set; }

    }
}
