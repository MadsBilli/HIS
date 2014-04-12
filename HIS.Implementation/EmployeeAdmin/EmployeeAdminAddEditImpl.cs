using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.UI.Mapper.EmployeeAdmin;
using HIS.Data.Mapper.EmployeeAdmin;
using HIS.DataAccess.EmployeeAdmin;
using HIS.Common;

namespace HIS.Implementation.EmployeeAdmin
{
    public class EmployeeAdminAddEditImpl
    {
        public DataSet GetEmployeeScreenListValues()
        {
            EmployeeAdminAddEditDA empDA = new EmployeeAdminAddEditDA();
            return empDA.GetEmployeeScreenListValues();
        }

        public List<EmployeeAdminUIMapper> GetEmployeeListForGrid()
        {
            EmployeeAdminAddEditDA empDA = new EmployeeAdminAddEditDA();
            var empMapper = empDA.GetEmployeeListForGrid();
            var res = (from emp in empMapper
                       select new EmployeeAdminUIMapper
                       {
                           emp_id = emp.emp_id,
                           emp_name = emp.emp_name,
                           emp_typedesc = emp.emp_typedesc,
                           emp_salesman_id = emp.emp_salesman_id,
                           emp_left = emp.emp_left,
                           emp_bu = emp.emp_bu
                       }).ToList();
            return res;
        }

        public void SaveEmployeeDetails(EmployeeAdminUIMapper emp)
        {
            EmployeeAdminMapper mapper = new EmployeeAdminMapper
            {
                emp_bu = emp.emp_bu,
                emp_id = emp.emp_id,
                emp_name = emp.emp_name,
                emp_title = emp.emp_title,
                emp_status_id = emp.emp_status_id,
                emp_wf_grp = emp.emp_wf_grp,
                emp_directno = emp.emp_directno,
                emp_hp = emp.emp_hp,
                emp_email = emp.emp_email,
                emp_type = emp.emp_type,
                emp_date_join = emp.emp_date_join.Equals(DateTime.MinValue) ? (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue : emp.emp_date_join,
                emp_logname = emp.emp_logname,
                emp_left = emp.emp_left,
                emp_date_left = emp.emp_date_left.Equals(DateTime.MinValue) ? (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue : emp.emp_date_left,
                emp_r_add1 = emp.emp_r_add1,
                emp_r_add2 = emp.emp_r_add2,
                emp_r_add3 = emp.emp_r_add3,
                emp_tel = emp.emp_tel,
                emp_nok = emp.emp_nok,
                emp_nok_relationship = emp.emp_nok_relationship,
                emp_health = emp.emp_health,
                emp_blood_grp = emp.emp_blood_grp,
                emp_medical_history = emp.emp_medical_history,
                emp_gender = emp.emp_gender,
                emp_marital_status = emp.emp_marital_status,
                emp_passport_ic = emp.emp_passport_ic,
                emp_passport_ic_expiry =  emp.emp_passport_ic_expiry.Equals(DateTime.MinValue) ? (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue : emp.emp_passport_ic_expiry,
                emp_dob = emp.emp_dob.Equals(DateTime.MinValue) ? (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue : emp.emp_dob,
                emp_pob = emp.emp_pob,
                emp_bank = emp.emp_bank,
                emp_bank_acc = emp.emp_bank_acc,
                emp_bank_branch = emp.emp_bank_branch,
                emp_religion = emp.emp_religion,
                emp_rmk = emp.emp_rmk,
                pay_regular = emp.pay_regular,
                pay_fixed_allowance = emp.pay_fixed_allowance,
                pay_SDL = emp.pay_SDL,
                pay_donation = emp.pay_donation,
                pay_cpf_emp = emp.pay_cpf_emp,
                pay_cpf_emp_amt = emp.pay_cpf_emp_amt,
                pay_cpf_company = emp.pay_cpf_company,
                pay_cpf_company_amt = emp.pay_cpf_company_amt,
                pay_donation_desc = emp.pay_donation_desc,
                emp_operation = emp.emp_operation
            };

            EmployeeAdminAddEditDA empDA = new EmployeeAdminAddEditDA();
            empDA.SaveEmployeeDetails(mapper);

            //custVendor.cust_id = mapper.cust_id;
        }

        public void DeleteEmployeeDetails(EmployeeAdminUIMapper uiMapper)
        {
            EmployeeAdminMapper mapper = new EmployeeAdminMapper
            {
                emp_id = uiMapper.emp_id
            };

            EmployeeAdminAddEditDA empDA = new EmployeeAdminAddEditDA();
            empDA.DeleteEmployeeDetails(mapper);
        }

        public EmployeeAdminUIMapper GetEmployeeDetails(EmployeeAdminUIMapper uiMapper)
        {
            EmployeeAdminAddEditDA empDA = new EmployeeAdminAddEditDA();
            EmployeeAdminMapper emp = new EmployeeAdminMapper();
            emp.emp_id = uiMapper.emp_id;
            var lsemp = empDA.GetEmployeeDetails(emp);

            var res = GetEmployeeUIMapper(lsemp);
            return res.FirstOrDefault();

        }

        public string GetEmpID(int statusid)
        {
            EmployeeAdminAddEditDA empDA = new EmployeeAdminAddEditDA();
            return empDA.GetEmpID(statusid);
        }

        private List<EmployeeAdminUIMapper> GetEmployeeUIMapper(List<EmployeeAdminMapper> lsEmp)
        {
            var res = (from emp in lsEmp
                       select new EmployeeAdminUIMapper
                       {
                           emp_bu = emp.emp_bu,
                           emp_id = emp.emp_id,
                           emp_name = emp.emp_name,
                           emp_title = emp.emp_title,
                           emp_directno = emp.emp_directno,
                           emp_hp = emp.emp_hp,
                           emp_email = emp.emp_email,
                           emp_type = emp.emp_type,
                           emp_date_join = emp.emp_date_join,
                           emp_status_id = emp.emp_status_id,
                           emp_wf_grp = emp.emp_wf_grp,
                           emp_logname = emp.emp_logname,
                           emp_left = emp.emp_left,
                           emp_date_left = emp.emp_date_left,
                           emp_r_add1 = emp.emp_r_add1,
                           emp_r_add2 = emp.emp_r_add2,
                           emp_r_add3 = emp.emp_r_add3,
                           emp_tel = emp.emp_tel,
                           emp_nok = emp.emp_nok,
                           emp_nok_relationship = emp.emp_nok_relationship,
                           emp_health = emp.emp_health,
                           emp_blood_grp = emp.emp_blood_grp,
                           emp_medical_history = emp.emp_medical_history,
                           emp_gender = emp.emp_gender,
                           emp_marital_status = emp.emp_marital_status,
                           emp_passport_ic = emp.emp_passport_ic,
                           emp_passport_ic_expiry = emp.emp_passport_ic_expiry,
                           emp_dob = emp.emp_dob,
                           emp_pob = emp.emp_pob,
                           emp_bank = emp.emp_bank,
                           emp_bank_acc = emp.emp_bank_acc,
                           emp_bank_branch = emp.emp_bank_branch,
                           emp_religion = emp.emp_religion,
                           emp_rmk = emp.emp_rmk,
                           pay_regular = emp.pay_regular,
                           pay_fixed_allowance = emp.pay_fixed_allowance,
                           pay_SDL = emp.pay_SDL,
                           pay_donation = emp.pay_donation,
                           pay_cpf_emp = emp.pay_cpf_emp,
                           pay_cpf_emp_amt = emp.pay_cpf_emp_amt,
                           pay_cpf_company = emp.pay_cpf_company,
                           pay_cpf_company_amt = emp.pay_cpf_company_amt,
                           pay_donation_desc = emp.pay_donation_desc
                       }).ToList();
            return res;
        }

    }
}
