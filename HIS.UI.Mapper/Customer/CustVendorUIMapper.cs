using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UI.Mapper.Customer
{
    public class CustVendorUIMapper
    {

        public string cust_id { get; set; }
        public string cust_type { get; set; }
        public bool cust_blacklisted { get; set; }
        public bool cust_exclusive { get; set; }
        public string cust_name { get; set; }
        public string cust_add1 { get; set; }
        public string cust_add2 { get; set; }
        public string cust_add3 { get; set; }
        public string cust_add4 { get; set; }
        public string cust_add5 { get; set; }
        public string cust_emp_tel_area_code { get; set; }
        public string cust_emp_tel { get; set; }
        public string cust_emp_fax_area_code { get; set; }
        public string cust_emp_fax { get; set; }
        public string cust_salesman_code { get; set; }
        public DateTime cust_Rdate { get; set; }
        public string cust_salesman_dept { get; set; }
        public string cust_CreatedBy { get; set; }
        public DateTime cust_Created { get; set; }
        public decimal cust_payup { get; set; }
        public string cust_company_type { get; set; }
        public string cust_BR { get; set; }
        public string cust_CR { get; set; }
        public string cust_Nature { get; set; }
        public string cust_Nature_rmk { get; set; }
        public string cust_emp_no { get; set; }
        public DateTime cust_est { get; set; }
        public Int16 cust_year { get; set; }
        public int cust_branch { get; set; }
        public Int16 cust_area { get; set; }
        public string cust_ownership { get; set; }
        public string cust_br_add1 { get; set; }
        public string cust_br_add2 { get; set; }
        public string cust_br_add3 { get; set; }
        public string cust_br_add4 { get; set; }
        public string cust_br_add5 { get; set; }
        public string cust_proprietor { get; set; }
        public string cust_emp_position { get; set; }
        public string cust_emp_department { get; set; }
        public string cust_emp_level { get; set; }
        public string cust_emp_name { get; set; }
        public string cust_emp_hp { get; set; }
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
        public decimal cust_creditlimit { get; set; }
        public Int16 cust_terms { get; set; }
        public int cust_limit_factor { get; set; }
        public int cust_system_size { get; set; }
        public int cust_server_size { get; set; }
        public string cust_it_platform { get; set; }
        public string cust_rmk { get; set; }
        public string cust_prompt_rmk { get; set; }
        public bool cust_inactive { get; set; }
        public string cust_payee { get; set; }
        public string cust_intrmk { get; set; }
        public string cust_tradedebtor { get; set; }
        public string cust_tradecreditor { get; set; }
        public string cust_revenue_acc_code { get; set; }
        public decimal cust_excess_payment { get; set; }
        public string cust_updatedby { get; set; }
        public DateTime cust_updated { get; set; }
        public bool cust_gst_reg { get; set; }
        public string cust_pos_price_grp { get; set; }

        //retrieve
         public decimal YTD_Sales { get; set; }
         public decimal YTD_Owing { get; set; }

    }
}
