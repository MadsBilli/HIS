using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.SQL2008;
using HIS.Common;
using System.Data;

namespace HIS.Data.Mapper.PurchaseOrder
{
    public class PurchaseOrderMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_ID", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string po_id { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_CUST_ID", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_cust_id { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_CUST_NAME", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_cust_name { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_DELIVERY_CUST_NAME", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_resp { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_ADD1", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_address { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_DELIVERY_ADD1", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_siteadd { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_ADD2", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_add2 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_ADD3", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_city { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_DELIVERY_ADD2", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_siteadd2 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_DELIVERY_ADD3", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_sitecity { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_ADD4", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_postal { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_ADD5", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_cust_Country { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_DELIVERY_ADD4", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_sitepos { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_DELIVERY_ADD5", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_sitecountry { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_CONT_NAME", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_contact { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_DELIVERY_CONT_NAME", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_sitecon { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_CONT_TEL", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int32 purord_tel { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_CONT_HP", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int32 purord_Hp { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_DELIVERY_CONT_TEL", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int32 purord_sitetel { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_DELIVERY_CONT_HP", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int32 purord_sitehp { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_CONT_FAX", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int32 purord_fax { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_DELIVERY_CONT_FAX", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int32 purord_sitefax { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_CONT_EMAIL", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_email { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_DELIVERY_CONT_EMAIL", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_siteemail { get; set; }
        public string purord_cust { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_DATE", ParameterType = SqlDbType.DateTime, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public DateTime purord_createddate { get; set; }
        public string purord_created_by { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_SALES_BY", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_salesby { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@QUOTE_ID", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int32 purord_qutrefno { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@INV_NUM", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int32 purord_invrefno { get; set; }
        public DateTime dsc_purord_install { get; set; }
        public string purord_time { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_BY", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_by { get; set; }
        public Int32 purord_roundoff { get; set; }
        public string purord_installation_rmk { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_RMK", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_rmk { get; set; }
        public string purord_deposite_bank { get; set; }
        public DateTime purord_deposite_date { get; set; }
        public string purord_receivied_by { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@WO_ID", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_chq_no { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_AMT", ParameterType = SqlDbType.Money, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_amount { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER, ParameterName = "@PO_INTRMK", ParameterType = SqlDbType.NText, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_internal_rmk { get; set; }
    }

}
