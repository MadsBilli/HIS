using DataAccess.SQL2008;
using HIS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Data.Mapper.SetUp
{
    public class BUNameSetupMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.BU_NAME_SETUP_DETAILS_INSERT, ParameterName = "@bu_id", ParameterType = SqlDbType.SmallInt, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.BU_NAME_SETUP_DETAILS_DELETE, ParameterName = "@bu_id", ParameterType = SqlDbType.SmallInt, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public int bu_id { get; set; }

        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.BU_NAME_SETUP_DETAILS_INSERT, ParameterName = "@bu_desc", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string bu_desc { get; set; }

        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.BU_NAME_SETUP_DETAILS_INSERT, ParameterName = "@bu_GST_code", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string bu_GST_code { get; set; }

        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.BU_NAME_SETUP_DETAILS_INSERT, ParameterName = "@PK", ParameterType = SqlDbType.Int, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public int primaryKey { get; set; }
    }
}
