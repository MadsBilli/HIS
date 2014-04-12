using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using DataAccess.SQL2008;
using HIS.Common;

namespace HIS.Data.Mapper.EmployeeAdmin
{
    public class EmployeeAdminMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.GET_EMPLOYEE_DETAILS, ParameterName = "@emp_id", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.DELETE_EMPLOYEE_DETAILS, ParameterName = "@emp_id", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_id", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_id { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_bu", ParameterType = SqlDbType.SmallInt, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int16 emp_bu { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_name", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_name { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_directno", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_directno { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_hp", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_hp { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_email", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_email { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_title", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_title { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_left", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool emp_left { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_date_left", ParameterType = SqlDbType.DateTime, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public DateTime emp_date_left { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_logname", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.LOGIN_DETAILS, ParameterName = "@emp_logname", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_logname { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_status_id", ParameterType = SqlDbType.Int, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public int emp_status_id { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.LOGIN_DETAILS, ParameterName = "@emp_logpwd", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_logpwd { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_type", ParameterType = SqlDbType.Int, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public int emp_type { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_wf_grp", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_wf_grp { get; set; }
        public Int16 emp_logcount { get; set; }
        public DateTime emp_logstamp { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_date_join", ParameterType = SqlDbType.DateTime, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public DateTime emp_date_join { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_gender", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_gender { get; set; }
        public Int16 emp_kid_no { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_passport_ic", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_passport_ic { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_passport_ic_expiry", ParameterType = SqlDbType.DateTime, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public DateTime emp_passport_ic_expiry { get; set; }
        public string emp_nationality { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_dob", ParameterType = SqlDbType.DateTime, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public DateTime emp_dob { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_pob", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_pob { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_religion", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_religion { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_marital_status", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_marital_status { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_blood_grp", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_blood_grp { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_health", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_health { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_medical_history", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_medical_history { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_r_add1", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_r_add1 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_r_add2", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_r_add2 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_r_add3", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_r_add3 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_tel", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_tel { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_nok", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_nok { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_nok_relationship", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_nok_relationship { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_bank", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_bank { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_bank_branch", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_bank_branch { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_bank_acc", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_bank_acc { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_rmk", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_rmk { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@pay_regular", ParameterType = SqlDbType.Decimal, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public decimal pay_regular { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@pay_cpf_emp", ParameterType = SqlDbType.Decimal, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public decimal pay_cpf_emp { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@pay_cpf_company", ParameterType = SqlDbType.Decimal, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public decimal pay_cpf_company { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@pay_fixed_allowance", ParameterType = SqlDbType.Decimal, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public decimal pay_fixed_allowance { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@pay_SDL", ParameterType = SqlDbType.Decimal, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public decimal pay_SDL { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@pay_donation", ParameterType = SqlDbType.Decimal, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public decimal pay_donation { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@pay_donation_desc", ParameterType = SqlDbType.SmallInt, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int16 pay_donation_desc { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@pay_cpf_emp_amt", ParameterType = SqlDbType.Decimal, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public decimal pay_cpf_emp_amt { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@pay_cpf_company_amt", ParameterType = SqlDbType.Decimal, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public decimal pay_cpf_company_amt { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS, ParameterName = "@emp_operation", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Operation emp_operation { get; set; }
        //grid
        public string emp_typedesc { get; set; }
        public string emp_salesman_id { get; set; }

        //login
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.LOGIN_DETAILS, ParameterName = "@incorrect", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string incorrect { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.LOGIN_DETAILS, ParameterName = "@account_disable", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.InOut)]
        public bool account_disable { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.LOGIN_DETAILS, ParameterName = "@LastLoginDate", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.InOut, Size=50)]
        public string LastLoginDate { get; set; }

    }
}
