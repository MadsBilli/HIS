using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.Common;

namespace HIS.UI.Mapper.EmployeeAdmin
{
    public class EmployeeAdminUIMapper
    {
        public string emp_id { get; set; }
        public Int16 emp_bu { get; set; }
        public string emp_name { get; set; }
        public string emp_directno { get; set; }
        public string emp_hp { get; set; }
        public string emp_email { get; set; }
        public string emp_title { get; set; }
        public bool emp_left { get; set; }
        public DateTime emp_date_left { get; set; }
        public string emp_logname { get; set; }
        public int emp_status_id { get; set; }
        public string emp_logpwd { get; set; }
        public int emp_type { get; set; }
        public string emp_wf_grp { get; set; }
        public Int16 emp_logcount { get; set; }
        public DateTime emp_logstamp { get; set; }
        public DateTime emp_date_join { get; set; }
        public string emp_gender { get; set; }
        public Int16 emp_kid_no { get; set; }
        public string emp_passport_ic { get; set; }
        public DateTime emp_passport_ic_expiry { get; set; }
        public string emp_nationality { get; set; }
        public DateTime emp_dob { get; set; }
        public string emp_pob { get; set; }
        public string emp_religion { get; set; }
        public string emp_marital_status { get; set; }
        public string emp_blood_grp { get; set; }
        public string emp_health { get; set; }
        public string emp_medical_history { get; set; }
        public string emp_r_add1 { get; set; }
        public string emp_r_add2 { get; set; }
        public string emp_r_add3 { get; set; }
        public string emp_tel { get; set; }
        public string emp_nok { get; set; }
        public string emp_nok_relationship { get; set; }
        public string emp_bank { get; set; }
        public string emp_bank_branch { get; set; }
        public string emp_bank_acc { get; set; }
        public string emp_rmk { get; set; }
        public decimal pay_regular { get; set; }
        public decimal pay_cpf_emp { get; set; }
        public decimal pay_cpf_company { get; set; }
        public decimal pay_fixed_allowance { get; set; }
        public decimal pay_SDL { get; set; }
        public decimal pay_donation { get; set; }
        public Int16 pay_donation_desc { get; set; }
        public decimal pay_cpf_emp_amt { get; set; }
        public decimal pay_cpf_company_amt { get; set; }

        public Operation emp_operation { get; set; }
        //grid
        public string emp_typedesc { get; set; }
        public string emp_salesman_id { get; set; }

        //login
        public string incorrect { get; set; }
        public bool account_disable { get; set; }
        public string LastLoginDate { get; set; }
    }
}
