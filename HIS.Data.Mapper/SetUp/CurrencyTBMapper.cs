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
    public class CurrencyTBMapper
    {
        public Int16 currency_id { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_CURRENCY_TB_DETAILS, ParameterName = "@currency_desc", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string currency_desc { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_CURRENCY_TB_DETAILS, ParameterName = "@currency_type", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string currency_type { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_CURRENCY_TB_DETAILS, ParameterName = "@currency_rate", ParameterType = SqlDbType.Decimal, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public decimal currency_rate { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_CURRENCY_TB_DETAILS, ParameterName = "@currency_rmk", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string currency_rmk { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_CURRENCY_TB_DETAILS, ParameterName = "@currency_date", ParameterType = SqlDbType.DateTime, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public DateTime currency_date { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_CURRENCY_TB_DETAILS, ParameterName = "@currency_update_by", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string currency_update_by { get; set; }
    }
}
