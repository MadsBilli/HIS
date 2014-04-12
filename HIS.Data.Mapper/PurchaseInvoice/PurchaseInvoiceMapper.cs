using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.SQL2008;
using HIS.Common;
using System.Data;

namespace HIS.Data.Mapper.PurchaseInvoice
{
    public class PurchaseInvoiceMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "@PUR_ID", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string pur_id { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string puchase_from { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string po_no { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string invoice { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public DateTime pi_date { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string pi_acct { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string pi_default_acc_code { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string pi_balance_code { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string pi_sub_Total { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string pi_gst { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string pi_Total { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "@PUR_ITEM_ID", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string pi_item_id { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string pi_item_order { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "@PUR_ITEM_MODEL", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string pi_item_Re { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "@PUR_ITEM_UNIT", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string pi_item_Unit { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "@PUR_ITEM_DESC", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string pi_item_Desc { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string pi_item_Price { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string pi_item_Tax { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string pi_item_Gst { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public double pi_item_amount { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "@PUR_ACC_CODE", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string pi_item_Acccode { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "@PUR_ITEM_CATEGORY", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string pi_item_Suplier { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string pi_item_Rec { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string pi_item_InoviceNumber { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASE_INVOICE, ParameterName = "", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string pi_item_woid { get; set; }
    }
}
