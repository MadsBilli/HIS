using DataAccess.SQL2008;
using HIS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Data.Mapper.SetUp
{
    public class InvoiceItemDescriptionMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.INVOICE_ITEM_DESC_DETAILS_INSERT, ParameterName = "@inv_sel_ln", ParameterType = SqlDbType.Int, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.INVOICE_ITEM_DESC_DETAILS_DELETE, ParameterName = "@inv_sel_ln", ParameterType = SqlDbType.Int, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public int inv_sel_ln { get; set; }

        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.INVOICE_ITEM_DESC_DETAILS_INSERT, ParameterName = "@inv_sel_desc", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string inv_sel_desc { get; set; }
                        
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.INVOICE_ITEM_DESC_DETAILS_INSERT, ParameterName = "@PK", ParameterType = SqlDbType.Int, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public int primaryKey { get; set; }
    }
}
