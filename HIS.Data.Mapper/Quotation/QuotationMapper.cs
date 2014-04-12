using System;

namespace HIS.Data.Mapper.Quotation
{
    public class QuotationMapper
    {
        public string quote_id { get; set; }
        public string quote_cust_id { get; set; }
        public string quote_cust_name { get; set; }
        public string quote_cust_emp_name_seq { get; set; }
        public string quote_cust_emp_name_salutation { get; set; }
        public string quote_cust_emp_name_given { get; set; }
        public string quote_cust_emp_name_middle { get; set; }
        public string quote_cust_emp_name_family { get; set; }
        public string quote_cust_emp_name { get; set; }
        public string quote_cust_emp_tel { get; set; }
        public string quote_cust_emp_tel_ext { get; set; }
        public string quote_cust_emp_hp { get; set; }
        public string quote_cust_emp_fax { get; set; }
        public string quote_cust_emp_email { get; set; }
        public string quote_subject { get; set; }
        public DateTime quote_date { get; set; }
        public DateTime quote_reminder1 { get; set; }
        public DateTime quote_reminder2 { get; set; }
        public Int16 quote_statusid { get; set; }
        public DateTime quote_replieddate { get; set; }
        public Int16 quote_validty { get; set; }
        public Int16 quote_terms { get; set; }
        public Int16 quote_wrty { get; set; }
        public double quote_cancelcharge { get; set; }
        public string quote_deliver { get; set; }
        public string quote_deliver_sel { get; set; }
        public string quote_remark { get; set; }
        public bool quote_total { get; set; }
        public string quote_by { get; set; }
        public Int16 quote_sales_grp_id { get; set; }
        public string quote_rejectreason { get; set; }
        public string quote_custpo { get; set; }
        public string quote_inrmk { get; set; }
        public Int16 approval_id { get; set; }
        public double quote_cost { get; set; }
        public double quote_amt { get; set; }
        public double quote_margin { get; set; }
        public double quote_margin_pctg { get; set; }
        public bool quote_us { get; set; }
        public string quote_by2 { get; set; }
        public string quote_sales_rmk { get; set; }
        public string quote_cust_ref { get; set; }
        public Int16 quote_display { get; set; }
        public string quote_condition_rmk { get; set; }
        public bool quote_condition_app { get; set; }
        public Single quote_confident_lvl { get; set; }
        public DateTime quote_condition_app_date { get; set; }
        public string quote_approval_rmk { get; set; }
        public bool quote_showGST { get; set; }
        public Single quote_gst_pencentage { get; set; }
        public double quote_gst { get; set; }
        public double quote_discount { get; set; }
        public string inv_num { get; set; }
        public int quote_curr { get; set; }
        public Single quote_rate { get; set; }
        public int quote_tnc { get; set; }
        public bool quote_showWty { get; set; }
        public string quote_des_add1 { get; set; }
        public string quote_des_add2 { get; set; }
        public string quote_des_add3 { get; set; }
        public string quote_des_add4 { get; set; }
        public string quote_des_add5 { get; set; }
        public string quote_site_add1 { get; set; }
        public string quote_site_add2 { get; set; }
        public string quote_site_add3 { get; set; }
        public string quote_site_add4 { get; set; }
        public string quote_site_add5 { get; set; }
        public string wo_id { get; set; }
    }
}
