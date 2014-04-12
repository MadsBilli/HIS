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
    public class UOMSetupMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.UOM_SETUP_DETAILS_INSERT, ParameterName = "@unit_id", ParameterType = SqlDbType.SmallInt, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.UOM_SETUP_DETAILS_DELETE, ParameterName = "@unit_id", ParameterType = SqlDbType.SmallInt, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public int unit_id { get; set; }

        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.UOM_SETUP_DETAILS_INSERT, ParameterName = "@unit_type", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string unit_type { get; set; }

        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.UOM_SETUP_DETAILS_INSERT, ParameterName = "@unit_rmk", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string unit_rmk { get; set; }

        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.UOM_SETUP_DETAILS_INSERT, ParameterName = "@PK", ParameterType = SqlDbType.Int, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public int primaryKey { get; set; }
    }
}
