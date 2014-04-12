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
    public class EmployeeAdminAddEditAssembler
    {
        public DataSet GetEmployeeScreenListValues()
        {
            EmployeeAdminAddEditImpl empImpl = new EmployeeAdminAddEditImpl();
            return empImpl.GetEmployeeScreenListValues();
        }

        public void InsertEmployeeAdminDetails(EmployeeAdminUIMapper emp)
        {
            var errorMessage = ValidateEmpDetails(emp);
            if (errorMessage.Count > 0)
            {
                throw new ExceptionHandler(string.Join("<br/>", errorMessage));
            }
            EmployeeAdminAddEditImpl empImpl = new EmployeeAdminAddEditImpl();
            empImpl.SaveEmployeeDetails(emp);

        }

        private List<string> ValidateEmpDetails(EmployeeAdminUIMapper emp)
        {
            List<string> ErrorMessage = new List<string>();
            if (emp.emp_bu.Equals("0"))
                ErrorMessage.Add("Unit");
            if (emp.emp_status_id.Equals("0"))
                ErrorMessage.Add("Employee Status");
            if (string.IsNullOrEmpty(emp.emp_id))
                ErrorMessage.Add("Employee ID");
            if (string.IsNullOrEmpty(emp.emp_name))
                ErrorMessage.Add("Employee Name");
            if (string.IsNullOrEmpty(emp.emp_title))
                ErrorMessage.Add("Title");
            if (string.IsNullOrEmpty(emp.emp_logname))
                ErrorMessage.Add("Log Name");
            if (emp.emp_wf_grp.Equals("0"))
                ErrorMessage.Add("Welfare Group");
            if (ErrorMessage.Count > 0)
            {
                ErrorMessage.Insert(0, "Missing Mandatory Field(s)!");
            }
            return ErrorMessage;
        }

        public List<EmployeeAdminUIMapper> GetEmployeeListForGrid()
        {
            EmployeeAdminAddEditImpl empImpl = new EmployeeAdminAddEditImpl();
            return empImpl.GetEmployeeListForGrid();
        }

        public void DeleteEmployeeDetails(EmployeeAdminUIMapper emp)
        {
            EmployeeAdminAddEditImpl empImpl = new EmployeeAdminAddEditImpl();
            empImpl.DeleteEmployeeDetails(emp);
        }

        public EmployeeAdminUIMapper GetEmployeeDetails(EmployeeAdminUIMapper emp)
        {
            EmployeeAdminAddEditImpl customerImpl = new EmployeeAdminAddEditImpl();
            return customerImpl.GetEmployeeDetails(emp);
        }

        public string GetEmpID(int statusid)
        {
            EmployeeAdminAddEditImpl empImpl = new EmployeeAdminAddEditImpl();
            return empImpl.GetEmpID(statusid);
        }
    }
}
