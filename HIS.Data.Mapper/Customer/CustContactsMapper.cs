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
    public class CustContactsMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.GET_CUSTOMER_CONTACT_DETAILS, ParameterName = "@cust_id", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_id", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_id { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_id", ParameterType = SqlDbType.Int, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public int cust_emp_id { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_gender", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_gender { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_name_seq", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_name_seq { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_name_salutation", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_name_salutation { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_name_family", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_name_family { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_name_middle", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_name_middle { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_name_given", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_name_given { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_name", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_name { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_dept", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_dept { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_title", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_title { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_email", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_email { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_email2", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_email2 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_tel_area_code", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_tel_area_code { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_tel", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_tel { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_tel_ext", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_tel_ext { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_hp_area_code", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_hp_area_code { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_hp", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_hp { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_fax_area_code", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_fax_area_code { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_fax", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_fax { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_fax_oth_area_code", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_fax_oth_area_code { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_fax_oth", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_fax_oth { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_left", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool cust_emp_left { get; set; }
       // [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_inactive_rmk", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_inactive_rmk { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_level", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_level { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_add1", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_add1 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_add2", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_add2 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_add3", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_add3 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_add4", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_add4 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_add5", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_add5 { get; set; }
        //[StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_city", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_city { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_contact_source", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_contact_source { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_region", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_region { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_manager_name", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_manager_name { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_asst_name", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_asst_name { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_tel_asst_area_code", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_tel_asst_area_code { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_tel_asst", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_tel_asst { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_tel_asst_ext", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_tel_asst_ext { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_contact_type", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_contact_type { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_prefer_comm", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_prefer_comm { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_create_bu", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_create_bu { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_create_datestamp", ParameterType = SqlDbType.DateTime, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public DateTime cust_emp_create_datestamp { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_update_by", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_update_by { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_update_datestamp", ParameterType = SqlDbType.DateTime, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public DateTime cust_emp_update_datestamp { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_rmk", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_rmk { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_relationship_rmk", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_relationship_rmk { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_emp_type", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string cust_emp_type { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT, ParameterName = "@cust_contact_opreration", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Operation cust_contact_opreration { get; set; }
    }
}
