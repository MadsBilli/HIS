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
    public class CountrySetupMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.COUNTRY_SETUP_DETAILS_UPDATE, ParameterName = "@city_code", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string city_code { get; set; }

        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.COUNTRY_SETUP_DETAILS_UPDATE, ParameterName = "@city_desc", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string city_desc { get; set; }

        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.COUNTRY_SETUP_DETAILS_UPDATE, ParameterName = "@city_active", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool city_active { get; set; }

        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.COUNTRY_SETUP_DETAILS_UPDATE, ParameterName = "@PK", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string primaryKey { get; set; }
    }
}
