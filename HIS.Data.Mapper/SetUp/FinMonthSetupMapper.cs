using DataAccess.SQL2008;
using HIS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UI.Mapper.Setup
{
    public class FinMonthSetupMapper
    {
        public int fin_mth_LN { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.GET_Active_FINMONTH_SETUP_DETAILS, ParameterName = "@FinMonthSDate", ParameterType = SqlDbType.DateTime, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SET_Active_FINMONTH_SETUP_DETAILS, ParameterName = "@FinMonthSDate", ParameterType = SqlDbType.DateTime, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public DateTime? fin_mth_sdate { get; set; }
        public DateTime fin_mth_edate { get; set; }
        public bool fin_mth_act { get; set; }
        public bool fin_mth_close { get; set; }
        public int primaryKey { get; set; }
    }
}
