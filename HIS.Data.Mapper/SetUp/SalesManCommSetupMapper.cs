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
    public class SalesManCommSetupMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SALESMAN_COMM_SETUP_DETAILS_UPDATE, ParameterName = "@emp_id", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_id { get; set; }

        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SALESMAN_COMM_SETUP_DETAILS_UPDATE, ParameterName = "@emp_salesman_id", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_salesman_id { get; set; }

        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SALESMAN_COMM_SETUP_DETAILS_UPDATE, ParameterName = "@emp_salesman_com", ParameterType = SqlDbType.Real, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_salesman_com { get; set; }

        public string emp_name { get; set; }

    }
}
