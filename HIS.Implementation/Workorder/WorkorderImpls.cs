using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.Common;
using HIS.DataAccess.Workorder;
using HIS.UI.Mapper.Workorder;
using HIS.Data.Mapper.Workorder;




namespace HIS.Implementation.Workorder
{
    public class WorkorderImpls
    {
        public DataSet GetWorkorderScreenListValues()
        {
            WorkorderDA workorderDA = new WorkorderDA();
            return workorderDA.GetWorkorderScreenListValues();
        }

        public void saveWorkorder(workorderUIMapper workordermapper, string operation)
        {
            try
            {
                List<workorderUIMapper> lsworkordermapper = new List<workorderUIMapper>();
                lsworkordermapper.Add(workordermapper);
                DataTable dt = CommonFunctions.CopyListToDataTable<workorderUIMapper>(lsworkordermapper);
                WorkorderDA workorderDA = new WorkorderDA();
                WorkOrderMapper mapper = new WorkOrderMapper
                {
                    wo_id = workordermapper.wo_id,
                    wo_cust_id = workordermapper.wo_cust_id,
                    wo_cust_name = workordermapper.wo_cust_name,
                    quote_id = workordermapper.quote_id,
                    inv_num = workordermapper.inv_num,
                    wo_by = workordermapper.wo_by,
                    wo_date = workordermapper.wo_date,
                    wo_statusid = workordermapper.wo_statusid,
                    wo_rmk = workordermapper.wo_rmk,
                    wo_billing_add1 = workordermapper.wo_billing_add1,
                    wo_billing_add2 = workordermapper.wo_billing_add2,
                    wo_billing_add3 = workordermapper.wo_billing_add3,
                    wo_billing_add4 = workordermapper.wo_billing_add4,
                    wo_billing_add5 = workordermapper.wo_billing_add5,
                    wo_cust_emp_name = workordermapper.wo_cust_emp_name,
                    wo_cust_emp_tel = workordermapper.wo_cust_emp_tel,
                    wo_cust_emp_tel_ext = workordermapper.wo_cust_emp_tel_ext,
                    wo_cust_emp_hp = workordermapper.wo_cust_emp_hp,
                    wo_cust_emp_fax = workordermapper.wo_cust_emp_fax,
                    wo_cust_emp_email = workordermapper.wo_cust_emp_email,
                    wo_delivery_cust_name = workordermapper.wo_delivery_cust_name,
                    wo_delivery_add1 = workordermapper.wo_delivery_add1,
                    wo_delivery_add2 = workordermapper.wo_delivery_add2,
                    wo_delivery_add3 = workordermapper.wo_delivery_add3,
                    wo_delivery_add4 = workordermapper.wo_delivery_add4,
                    wo_delivery_add5 = workordermapper.wo_delivery_add5,
                    wo_cont_emp_name = workordermapper.wo_cont_emp_name,
                    wo_cont_emp_tel = workordermapper.wo_cont_emp_tel,
                    wo_cont_emp_tel_ext = workordermapper.wo_cont_emp_tel_ext,
                    wo_cont_emp_hp = workordermapper.wo_cust_emp_hp,
                    wo_cont_emp_fax = workordermapper.wo_cust_emp_fax,
                    wo_cont_emp_email = workordermapper.wo_cust_emp_email,
                    wo_installation_date = workordermapper.wo_installation_date,
                    wo_installation_time = workordermapper.wo_installation_time,
                    wo_installation_rmk = workordermapper.wo_installation_rmk,
                    wo_installation_by = workordermapper.wo_installation_by,
                    rec_chqTT_no = workordermapper.rec_chqTT_no,
                    rec_by = workordermapper.rec_by,
                    rec_bank_code = workordermapper.rec_bank_code,
                    rec_date = workordermapper.rec_date,
                    rec_amt = workordermapper.rec_amt,
                    wo_intrmk = workordermapper.wo_intrmk,
                    wo_cust_ref_num = workordermapper.wo_cust_ref_num,
                    wo_sales_by = workordermapper.wo_sales_by
                };
                workorderDA.SavePurchaseOrder(mapper);
            }
            catch
            {
            }
        }

        public void SaveWorkOrderItems(WorkorderItemUIMapper woItemMapper, string operation)
        {
            try
            {
                List<WorkorderItemUIMapper> lsQuoteMapper = new List<WorkorderItemUIMapper>();
                lsQuoteMapper.Add(woItemMapper);
                DataTable dt = CommonFunctions.CopyListToDataTable<WorkorderItemUIMapper>(lsQuoteMapper);
                WorkorderDA workorderDA = new WorkorderDA();
                WorkorderitemMapper mapper = new WorkorderitemMapper
                {
                    wo_id = woItemMapper.wo_id,
                    wo_item_id = woItemMapper.wo_item_id,
                    wo_item_header = woItemMapper.wo_item_header,
                    wo_item_model = woItemMapper.wo_item_model,
                    wo_item_type = woItemMapper.wo_item_type,
                    wo_item_desc = woItemMapper.wo_item_desc,
                    wo_item_width = woItemMapper.wo_item_width,
                    wo_item_height = woItemMapper.wo_item_height,
                    wo_item_qty = woItemMapper.wo_item_qty,
                    wo_item_amt = woItemMapper.wo_item_amt,
                    wo_item_tamt = woItemMapper.wo_item_tamt
                };
                workorderDA.SavePurchaseOrderItems(mapper);
            }
            catch
            {
            }
        }

        public workorderUIMapper GetWorkOrderDetails(string strWOID)
        {
            WorkorderDA workorderDA = new WorkorderDA();
            var val = workorderDA.GetPurchaseOrderDetails(strWOID);
            return CommonFunctions.Cast<workorderUIMapper>(val);
        }

        public DataSet SearchworkorderDetails(string where, string orderBy)
        {
            WorkorderDA workorderDA = new WorkorderDA();
            return workorderDA.SearchworkorderDetails(where, orderBy);
        }

        public DataSet GetSalesmanList()
        {
            WorkorderDA workorderDA = new WorkorderDA();
            return workorderDA.GetSalesmanList();
        }
    }
}