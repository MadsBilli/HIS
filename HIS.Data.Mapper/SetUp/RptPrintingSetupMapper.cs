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
    public class RptPrintingSetupMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.RPT_PRINTING_SETUP_DETAILS_INSERT, ParameterName = "@rt_name", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.RPT_PRINTING_SETUP_DETAILS_DELETE, ParameterName = "@rt_name", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string rt_name { get; set; }

        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.RPT_PRINTING_SETUP_DETAILS_INSERT, ParameterName = "@rt_display_name", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string rt_display_name { get; set; }

        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.RPT_PRINTING_SETUP_DETAILS_INSERT, ParameterName = "@rt_allow_edit", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool rt_allow_edit { get; set; }

        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.RPT_PRINTING_SETUP_DETAILS_INSERT, ParameterName = "@rt_form", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string rt_form { get; set; }

        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.RPT_PRINTING_SETUP_DETAILS_INSERT, ParameterName = "@rt_table", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string rt_table { get; set; }

        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.RPT_PRINTING_SETUP_DETAILS_INSERT, ParameterName = "@rt_id", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string rt_id { get; set; }

        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.RPT_PRINTING_SETUP_DETAILS_INSERT, ParameterName = "@rt_criteria", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string rt_criteria { get; set; }

        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.RPT_PRINTING_SETUP_DETAILS_INSERT, ParameterName = "@PK", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string primaryKey { get; set; }
    }
}
