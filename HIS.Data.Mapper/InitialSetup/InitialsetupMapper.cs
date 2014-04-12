using DataAccess.SQL2008;
using HIS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Data.Mapper.InitialSetup
{
    public class InitialsetupMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INITIAL_SETUP, ParameterName = "@emp_logname", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.GET_INITIALSETUP, ParameterName = "@emp_logname", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string emp_logname { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INITIAL_SETUP, ParameterName = "@col_general", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool col_general { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INITIAL_SETUP, ParameterName = "@col_finance", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool col_finance { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INITIAL_SETUP, ParameterName = "@col_vendor", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool col_vendor { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INITIAL_SETUP, ParameterName = "@col_customer", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool col_customer { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INITIAL_SETUP, ParameterName = "@col_management", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool col_management { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INITIAL_SETUP, ParameterName = "@col_administrator", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool col_administrator { get; set; }
        public bool pf_inv_sort { get; set; }
        public string pf_inv_sort1 { get; set; }
        public string pf_inv_sort2 { get; set; }
        public string pf_inv_sort3 { get; set; }
        public bool pf_inv_sort1_by { get; set; }
        public bool pf_inv_sort2_by { get; set; }
        public bool pf_inv_sort3_by { get; set; }
        public string pf_quote_sort { get; set; }
        public string pf_quote_sort1 { get; set; }
        public string pf_quote_sort2 { get; set; }
        public string pf_quote_sort3 { get; set; }
        public bool pf_quote_sort1_by { get; set; }
        public bool pf_quote_sort2_by { get; set; }
        public bool pf_quote_sort3_by { get; set; }
        public string pf_wo_sort { get; set; }
        public string pf_wo_sort1 { get; set; }
        public string pf_wo_sort2 { get; set; }
        public string pf_wo_sort3 { get; set; }
        public bool pf_wo_sort1_by { get; set; }
        public bool pf_wo_sort2_by { get; set; }
        public bool pf_wo_sort3_by { get; set; }
        public string pf_po_sort { get; set; }
        public string pf_po_sort1 { get; set; }
        public string pf_po_sort2 { get; set; }
        public string pf_po_sort3 { get; set; }
        public bool pf_po_sort1_by { get; set; }
        public bool pf_po_sort2_by { get; set; }
        public bool pf_po_sort3_by { get; set; }
        public bool pf_active_window { get; set; }
        public string pf_backup_path { get; set; }
        public string pf_restore_path { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INITIAL_SETUP, ParameterName = "@pf_show_gst", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool pf_show_gst { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INITIAL_SETUP, ParameterName = "@pf_show_gst_po", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool pf_show_gst_po { get; set; }
        public bool pf_show_wrty { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INITIAL_SETUP, ParameterName = "@pf_show_signature", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool pf_show_signature { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_INITIAL_SETUP, ParameterName = "@pf_show_bank", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool pf_show_bank { get; set; }
			

    }
}
