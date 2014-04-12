using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.SQL2008;
using System.Data;
using HIS.Common;

namespace HIS.Data.Mapper.PurchaseOrder
{
    public class PurchaseOrderItemMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER_ITEMS, ParameterName = "@PO_ID", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_id { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER_ITEMS, ParameterName = "@PO_ITEM_ID", ParameterType = SqlDbType.SmallInt, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int32 purord_item_id { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER_ITEMS, ParameterName = "@PO_ITEM_ARTNO", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_item_header { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER_ITEMS, ParameterName = "@PO_ITEM_MODEL", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public String purord_item_model { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER_ITEMS, ParameterName = "@PO_ITEM_TYPE", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_item_type { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER_ITEMS, ParameterName = "@PO_ITEM_DESC", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string purord_item_desc { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER_ITEMS, ParameterName = "@PO_ITEM_WIDTH", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public double purord_item_width { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER_ITEMS, ParameterName = "@PO_ITEM_PATTERN", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public double purord_item_height { get; set; }
        public Int32 purord_item_ctrl { get; set; }
        public int purord_item_setno { get; set; }
        public int purord_item_uom { get; set; }
        public Single purord_item_col { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER_ITEMS, ParameterName = "@PO_ITEM_QTY_REC", ParameterType = SqlDbType.Int, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int32 quote_item_Qty { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER_ITEMS, ParameterName = "@PO_ITEM_AMT", ParameterType = SqlDbType.Money, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public double purord_item_amt { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_PURCHASEORDER_ITEMS, ParameterName = "@PO_ITEM_TAMT", ParameterType = SqlDbType.Money, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public double purord_item_tamt { get; set; }
    }
}
