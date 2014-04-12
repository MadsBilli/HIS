using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.UI.Mapper.EmployeeAdmin;
using HIS.Implementation.EmployeeAdmin;
using HIS.Common;

namespace HIS.UI.Assembler.EmployeeAdmin
{
    public class LoginAssembler
    {
        public EmployeeAdminUIMapper GetLoginDetails(EmployeeAdminUIMapper mapper)
        {
            var errorMessage = ValidateLoginDetails(mapper);
            if (errorMessage.Count > 0)
            {
                throw new ExceptionHandler(string.Join("<br/>", errorMessage));
            }
            LoginImpl empImpl = new LoginImpl();
            return empImpl.GetLoginDetails(mapper);
        }

        private List<string> ValidateLoginDetails(EmployeeAdminUIMapper emp)
        {
            List<string> ErrorMessage = new List<string>();
            if (string.IsNullOrEmpty(emp.emp_logname))
                ErrorMessage.Add("Log Name");
            if (string.IsNullOrEmpty(emp.emp_logpwd ))
                ErrorMessage.Add("Password");
            if (ErrorMessage.Count > 0)
            {
                ErrorMessage.Insert(0, "Missing Mandatory Field(s)!");
            }
            return ErrorMessage;
        }

        public DataSet GetUserLoginListing()
        {
            LoginImpl login  = new LoginImpl();
            return login.GetUserLoginListing();
        }

        public void UpdateTerminateUser(string empLogname)
        {
            LoginImpl login = new LoginImpl();
            login.UpdateTerminateUser(empLogname);
        }

        
    }
}
