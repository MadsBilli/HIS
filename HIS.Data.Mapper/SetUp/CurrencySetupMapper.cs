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
    public class CurrencySetupMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_CURRENCY_SETUP_DETAILS, ParameterName = "@currency_id", ParameterType = SqlDbType.SmallInt, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int16 currency_id { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_CURRENCY_SETUP_DETAILS, ParameterName = "@currency_desc", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string currency_desc { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_CURRENCY_SETUP_DETAILS, ParameterName = "@currency_code", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string currency_code { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_CURRENCY_SETUP_DETAILS, ParameterName = "@currency_symbol", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string currency_symbol { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_CURRENCY_SETUP_DETAILS, ParameterName = "@currency_position", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string currency_position { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_CURRENCY_SETUP_DETAILS, ParameterName = "@currency_home", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool currency_home { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_CURRENCY_SETUP_DETAILS, ParameterName = "@currency_format", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string currency_format { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_CURRENCY_SETUP_DETAILS, ParameterName = "@currency_thousand_sepa", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string currency_thousand_sepa { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_CURRENCY_SETUP_DETAILS, ParameterName = "@currency_decimal_sepa", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string currency_decimal_sepa { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_CURRENCY_SETUP_DETAILS, ParameterName = "@currency_decimal_place", ParameterType = SqlDbType.SmallInt, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int16 currency_decimal_place { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_CURRENCY_SETUP_DETAILS, ParameterName = "@gl_acc_code", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string gl_acc_code { get; set; }

    }
}
