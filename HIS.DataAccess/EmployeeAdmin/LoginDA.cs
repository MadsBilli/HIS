using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using HIS.Data.Mapper.EmployeeAdmin;
using HIS.Data.Mapper.SetUp;
using HIS.Common;
using DataAccess.SQL2008;
using System.Reflection;

namespace HIS.DataAccess.EmployeeAdmin
{
    public  class LoginDA
    {
        [StoredProcedure(StoredProcedureName = StoredProcedureName.LOGIN_DETAILS)]
        public  EmployeeAdminMapper  GetLoginDetails(EmployeeAdminMapper mapper)
        {
            var lsEmpMapper = new StoredProcedureCommandBuilder().GetEntities<EmployeeAdminMapper>(
                                    (MethodInfo)MethodInfo.GetCurrentMethod(), mapper);
            return lsEmpMapper.ToList().FirstOrDefault();
        }


        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_USER_LOGIN_LISTING)]
        public DataSet GetUserLoginListing()
        {
            return new StoredProcedureCommandBuilder().ExecuteDataSet(
                                   (MethodInfo)MethodInfo.GetCurrentMethod(), null);
        }

        public void UpdateTerminateUser(string empLogname)
        {
            string query = string.Concat("update system_login_log set log_kill = 0 where emp_logname = '" + empLogname + "'");
            var command = new StoredProcedureCommandBuilder();
            var result = command.ExecuteQuery(query, StoredProcedureEnums.StoredProcedureExecutionType.NonQuery);
             
        }


       
    }
}
