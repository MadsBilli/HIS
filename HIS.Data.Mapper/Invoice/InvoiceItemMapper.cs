using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.SQL2008;
using System.Data;
using HIS.Common;

namespace HIS.Data.Mapper.Invoice
{
    public class InvoiceItemMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE_ITEMS, ParameterName = "@INV_ID", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_id { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE_ITEMS, ParameterName = "@INV_ITEM_ID", ParameterType = SqlDbType.SmallInt, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int32 inv_item_id { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE_ITEMS, ParameterName = "@INV_ITEM_ARTNO", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_item_header { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE_ITEMS, ParameterName = "@INV_ITEM_MODEL", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public String inv_item_model { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE_ITEMS, ParameterName = "@INV_ITEM_TYPE", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_item_type { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE_ITEMS, ParameterName = "@INV_ITEM_DESC", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_item_desc { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE_ITEMS, ParameterName = "@INV_ITEM_WIDTH", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public double inv_item_width { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE_ITEMS, ParameterName = "@INV_ITEM_PATTERN", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public double inv_item_height { get; set; }
        public Int32 inv_item_ctrl { get; set; }
        public int inv_item_setno { get; set; }
        public int inv_item_uom { get; set; }
        public Single inv_item_col { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE_ITEMS, ParameterName = "@INV_ITEM_QTY_REC", ParameterType = SqlDbType.Int, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int32 inv_item_Qty { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE_ITEMS, ParameterName = "@INV_ITEM_AMT", ParameterType = SqlDbType.Money, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public double inv_item_amt { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INVOICE_ITEMS, ParameterName = "@INV_ITEM_TAMT", ParameterType = SqlDbType.Money, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public double inv_item_tamt { get; set; }
    }
}
