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
    public class SystemSetupMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SYSTEM_SetUP_DETAILS_UPDATE, ParameterName = "@setup_txt", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string setup_txt { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SYSTEM_SetUP_DETAILS_UPDATE, ParameterName = "@setup_value", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string setup_value { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SYSTEM_SetUP_DETAILS_UPDATE, ParameterName = "@setup_description", ParameterType = SqlDbType.NText, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string setup_description { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SYSTEM_SetUP_DETAILS_UPDATE, ParameterName = "@setup_id", ParameterType = SqlDbType.Int, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public int setup_id { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SYSTEM_SetUP_DETAILS_UPDATE, ParameterName = "@setup_grp", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string setup_grp { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SYSTEM_SetUP_DETAILS_UPDATE, ParameterName = "@setup_LN", ParameterType = SqlDbType.SmallInt, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int16 setup_LN { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SYSTEM_SetUP_DETAILS_UPDATE, ParameterName = "@PK", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string primaryKey { get; set; }
    }
}
