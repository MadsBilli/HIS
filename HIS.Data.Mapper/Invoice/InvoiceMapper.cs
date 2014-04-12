using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.SQL2008;
using HIS.Common;
using System.Data;

namespace HIS.Data.Mapper.Invoice
{
    public class InvoiceMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_ID", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_id { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_CUST_ID", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_cust_id { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_CUST_NAME", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_cust_name { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_DELIVERY_CUST_NAME", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_resp { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_ADD1", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_address { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_DELIVERY_ADD1", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_siteadd { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_ADD2", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_add2 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_ADD3", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_city { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_DELIVERY_ADD2", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_siteadd2 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_DELIVERY_ADD3", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_sitecity { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_ADD4", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_postal { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_ADD5", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_cust_Country { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_DELIVERY_ADD4", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_sitepos { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_DELIVERY_ADD5", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_sitecountry { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_CONT_NAME", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_contact { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_DELIVERY_CONT_NAME", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_sitecon { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_CONT_TEL", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int32 inv_tel { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_CONT_HP", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int32 inv_Hp { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_DELIVERY_CONT_TEL", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int32 inv_sitetel { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_DELIVERY_CONT_HP", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int32 inv_sitehp { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_CONT_FAX", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int32 inv_fax { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_DELIVERY_CONT_FAX", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int32 inv_sitefax { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_CONT_EMAIL", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_email { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_DELIVERY_CONT_EMAIL", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_siteemail { get; set; }
        public string inv_cust { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_DATE", ParameterType = SqlDbType.DateTime, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public DateTime inv_createddate { get; set; }
        public string inv_created_by { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_SALES_BY", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_salesby { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@QUOTE_ID", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int32 inv_qutrefno { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_NUM", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int32 inv_invrefno { get; set; }
        public DateTime dsc_inv_install { get; set; }
        public string inv_time { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_BY", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_by { get; set; }
        public Int32 inv_roundoff { get; set; }
        public string inv_installation_rmk { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_RMK", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_rmk { get; set; }
        public string inv_deposite_bank { get; set; }
        public DateTime inv_deposite_date { get; set; }
        public string inv_receivied_by { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@WO_ID", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_chq_no { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_AMT", ParameterType = SqlDbType.Money, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_amount { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE, ParameterName = "@INV_INTRMK", ParameterType = SqlDbType.NText, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_internal_rmk { get; set; }
    }
}
