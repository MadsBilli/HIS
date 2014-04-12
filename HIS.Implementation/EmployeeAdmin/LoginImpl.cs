using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.Data.Mapper.EmployeeAdmin;
using HIS.UI.Mapper.EmployeeAdmin;
using HIS.DataAccess.EmployeeAdmin;

namespace HIS.Implementation.EmployeeAdmin
{
    public class LoginImpl
    {
        public EmployeeAdminUIMapper GetLoginDetails(EmployeeAdminUIMapper mapper)
        {
            EmployeeAdminMapper login = new EmployeeAdminMapper();
            login.emp_logname = mapper.emp_logname;
            login.emp_logpwd = mapper.emp_logpwd;
            login.incorrect = mapper.incorrect;
            login.account_disable = mapper.account_disable;
            login.LastLoginDate = mapper.LastLoginDate;

            LoginDA loginda = new LoginDA();
            var emp = loginda.GetLoginDetails(login); 
            
            EmployeeAdminUIMapper loginret = new EmployeeAdminUIMapper
            { 
                emp_id = emp.emp_id,
                emp_name = emp.emp_name,
                emp_type = emp.emp_type,
                emp_logname = emp.emp_logname,
                emp_logcount = emp.emp_logcount,
                account_disable = login.account_disable,
                LastLoginDate = login.LastLoginDate
            } ;
            return loginret;
            
        }

        public DataSet GetUserLoginListing()
        {
            LoginDA loginda = new LoginDA();
            return loginda.GetUserLoginListing(); 
        }
        public void UpdateTerminateUser(string empLogname)
        {
            LoginDA loginda = new LoginDA();
             loginda.UpdateTerminateUser(empLogname);
        }

        
    }
}
