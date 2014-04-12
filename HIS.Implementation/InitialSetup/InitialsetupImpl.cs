using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.Data.Mapper.InitialSetup;
using HIS.UI.Mapper.InitialSetup;
using HIS.DataAccess.InitialSetup;

namespace HIS.Implementation.InitialSetup
{
    public class InitialsetupImpl
    {

        public InitialsetupUIMapper GetInitialSetup(string emp_logName) 
        {
            InitialSetupDA inida = new InitialSetupDA();
            var res = inida.GetInitialSetup(emp_logName);

            InitialsetupUIMapper resMapper = new InitialsetupUIMapper
            {
                emp_logname = res.emp_logname,
                col_general = res.col_general,
                col_finance = res.col_finance,
                col_vendor = res.col_vendor,
                col_customer = res.col_customer,
                col_management = res.col_management,
                col_administrator = res.col_administrator,
                pf_inv_sort = res.pf_inv_sort,
                pf_inv_sort1 = res.pf_inv_sort1,
                pf_inv_sort2 = res.pf_inv_sort2,
                pf_inv_sort3 = res.pf_inv_sort3,
                pf_inv_sort1_by = res.pf_inv_sort1_by,
                pf_inv_sort2_by = res.pf_inv_sort2_by,
                pf_inv_sort3_by = res.pf_inv_sort3_by,
                pf_quote_sort = res.pf_quote_sort,
                pf_quote_sort1 = res.pf_quote_sort1,
                pf_quote_sort2 = res.pf_quote_sort2,
                pf_quote_sort3 = res.pf_quote_sort3,
                pf_quote_sort1_by = res.pf_quote_sort1_by,
                pf_quote_sort2_by = res.pf_quote_sort2_by,
                pf_quote_sort3_by = res.pf_quote_sort3_by,
                pf_wo_sort = res.pf_wo_sort,
                pf_wo_sort1 = res.pf_wo_sort1,
                pf_wo_sort2 = res.pf_wo_sort2,
                pf_wo_sort3 = res.pf_wo_sort3,
                pf_wo_sort1_by = res.pf_wo_sort1_by,
                pf_wo_sort2_by = res.pf_wo_sort2_by,
                pf_wo_sort3_by = res.pf_wo_sort3_by,
                pf_po_sort = res.pf_po_sort,
                pf_po_sort1 = res.pf_po_sort1,
                pf_po_sort2 = res.pf_po_sort2,
                pf_po_sort3 = res.pf_po_sort3,
                pf_po_sort1_by = res.pf_po_sort1_by,
                pf_po_sort2_by = res.pf_po_sort2_by,
                pf_po_sort3_by = res.pf_po_sort3_by,
                pf_active_window = res.pf_active_window,
                pf_backup_path = res.pf_backup_path,
                pf_restore_path = res.pf_restore_path,
                pf_show_gst = res.pf_show_gst,
                pf_show_gst_po = res.pf_show_gst_po,
                pf_show_wrty = res.pf_show_wrty,
                pf_show_signature = res.pf_show_signature,
                pf_show_bank = res.pf_show_bank
            };
            return resMapper;
        }

        public void SaveInitialSetup(InitialsetupUIMapper UImapper)
        {
            InitialSetupDA inida = new InitialSetupDA();
            InitialsetupMapper mapper = new InitialsetupMapper
            {
                emp_logname = UImapper.emp_logname,
                col_general = UImapper.col_general,
                col_finance = UImapper.col_finance,
                col_vendor = UImapper.col_vendor,
                col_customer = UImapper.col_customer,
                col_management = UImapper.col_management,
                col_administrator = UImapper.col_administrator,
                pf_show_gst = UImapper.pf_show_gst,
                pf_show_gst_po = UImapper.pf_show_gst_po,
                pf_show_wrty = UImapper.pf_show_wrty,
                pf_show_signature = UImapper.pf_show_signature,
                pf_show_bank = UImapper.pf_show_bank
            };
             inida.SaveInitialSetup(mapper);
        }


    }
}
