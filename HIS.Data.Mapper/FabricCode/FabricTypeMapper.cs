using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.SQL2008;
using HIS.Common;
using System.Data;

namespace HIS.Data.Mapper.FabricCode
{
    public class FabricTypeMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.GET_FABRIC_TYPE_DETAILS_BY_FABRIC_TYPE, ParameterName = "@FC_Type", ParameterType = SqlDbType.Int, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_UPDATE, ParameterName = "@FC_Type", ParameterType = SqlDbType.Int, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public int fc_type { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_UPDATE, ParameterName = "@fc_desc", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string fc_desc { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_UPDATE, ParameterName = "@fc_header", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string fc_header { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_UPDATE, ParameterName = "@fc_footer", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string fc_footer { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_UPDATE, ParameterName = "@fc_eff_date", ParameterType = SqlDbType.DateTime, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public DateTime fc_eff_date { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_UPDATE, ParameterName = "@fc_rmk", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string fc_rmk { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_UPDATE, ParameterName = "@fc_minimum", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string fc_minimum { get; set; }
    }
}
