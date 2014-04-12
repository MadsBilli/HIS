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

namespace HIS.Data.Mapper.Customer
{
    public class CustVendorMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.DELETE_CUSTOMER_CONTACT_DETAILS, ParameterName = "@cust_id", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.GET_CUSTOMER_DETAILS, ParameterName = "@cust_id", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_id", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.InOut, Size = 10)]
        public string cust_id { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_type", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_type { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_blacklisted", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool cust_blacklisted { get; set; }
        public bool cust_exclusive { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_name", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_name { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_add1", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_add1 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_add2", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_add2 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_add3", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_add3 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_add4", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_add4 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_add5", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_add5 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_emp_tel_area_code", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_tel_area_code { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_emp_tel", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_tel { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_emp_fax_area_code", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_fax_area_code { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_emp_fax", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_fax { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_salesman_code", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_salesman_code { get; set; }
        public DateTime cust_Rdate { get; set; }
        public string cust_salesman_dept { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_CreatedBy", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_CreatedBy { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_Created", ParameterType = SqlDbType.DateTime, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public DateTime cust_Created { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_payup", ParameterType = SqlDbType.Money, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public decimal cust_payup { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_company_type", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_company_type { get; set; }
        public string cust_BR { get; set; }
        public string cust_CR { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_Nature", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_Nature { get; set; }
        public string cust_Nature_rmk { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_emp_no", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_no { get; set; }
        public DateTime cust_est { get; set; }
        public Int16 cust_year { get; set; }
        public int cust_branch { get; set; }
        public Int16 cust_area { get; set; }
        public string cust_ownership { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_br_add1", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_br_add1 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_br_add2", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_br_add2 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_br_add3", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_br_add3 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_br_add4", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_br_add4 { get; set; }
        public string cust_br_add5 { get; set; }
        public string cust_proprietor { get; set; }
        public string cust_emp_position { get; set; }
        public string cust_emp_department { get; set; }
        public string cust_emp_level { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_emp_name", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_name { get; set; }
        public string cust_emp_hp { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_emp_email", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_email { get; set; }
        public string cust_emp_add1 { get; set; }
        public string cust_emp_add2 { get; set; }
        public string cust_emp_add3 { get; set; }
        public string cust_emp_add4 { get; set; }
        public decimal cust_treading_value { get; set; }
        public string cust_sale_name { get; set; }
        public string cust_sale_title { get; set; }
        public string cust_sale_phone { get; set; }
        public string cust_acc_name { get; set; }
        public string cust_acc_title { get; set; }
        public string cust_acc_phone { get; set; }
        public string cust_ar_name { get; set; }
        public string cust_ar_title { get; set; }
        public string cust_ar_phone { get; set; }
        public string cust_ar_location { get; set; }
        public string cust_banker { get; set; }
        public string cust_banker_acc { get; set; }
        public string cust_banker_branch { get; set; }
        public string cust_banker2 { get; set; }
        public string cust_banker_acc2 { get; set; }
        public string cust_banker2_branch { get; set; }
        public string cust_ref { get; set; }
        public string cust_ref_add { get; set; }
        public string cust_ref_phone { get; set; }
        public string cust_ref2 { get; set; }
        public string cust_ref2_add { get; set; }
        public string cust_ref2_phone { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_creditlimit", ParameterType = SqlDbType.Decimal, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public decimal cust_creditlimit { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_terms", ParameterType = SqlDbType.SmallInt, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int16 cust_terms { get; set; }
        public int cust_limit_factor { get; set; }
        public int cust_system_size { get; set; }
        public int cust_server_size { get; set; }
        public string cust_it_platform { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_rmk", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_rmk { get; set; }
        public string cust_prompt_rmk { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_inactive", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool cust_inactive { get; set; }
        public string cust_payee { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_intrmk", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_intrmk { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_tradedebtor", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_tradedebtor { get; set; }
        public string cust_tradecreditor { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_revenue_acc_code", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_revenue_acc_code { get; set; }
        public decimal cust_excess_payment { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_updatedby", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_updatedby { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_updated", ParameterType = SqlDbType.DateTime, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public DateTime cust_updated { get; set; }
        public bool cust_gst_reg { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT, ParameterName = "@cust_pos_price_grp", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_pos_price_grp { get; set; }
        //retrieve
        public decimal YTD_Sales { get; set; }
        public decimal YTD_Owing { get; set; }
    }
}
