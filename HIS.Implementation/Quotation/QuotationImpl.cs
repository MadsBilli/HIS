using System.Collections.Generic;
using System.Data;
using HIS.Common;
using HIS.DataAccess.Quotation;
using HIS.UI.Mapper.Quotation;
using HIS.Data.Mapper.Quotation;

namespace HIS.Implementation.Quotation
{
    public class QuotationImpl
    {
        public DataSet GetQuotationScreenListValues()
        {
            QuotationDA quoteDA = new QuotationDA();
            return quoteDA.GetQuotationScreenListValues();
        }

        public void SaveQuote(QuotationUIMapper quoteMapper, string operation)
        {
            try
            {
                List<QuotationUIMapper> lsQuoteMapper = new List<QuotationUIMapper>();
                lsQuoteMapper.Add(quoteMapper);
                DataTable dt = CommonFunctions.CopyListToDataTable<QuotationUIMapper>(lsQuoteMapper);
                QuotationDA quoteDA = new QuotationDA();
                //quoteDA.SaveQuote(dt, operation);

                QuotationMapper mapper = new QuotationMapper
                {
                    quote_id = quoteMapper.quote_id,
                    quote_cust_id = quoteMapper.quote_cust_id,
                    quote_cust_name = quoteMapper.quote_cust_name,
                    quote_cust_emp_name_seq = quoteMapper.quote_cust_emp_name_seq,
                    quote_cust_emp_name_salutation = quoteMapper.quote_cust_emp_name_salutation,
                    quote_cust_emp_name_given = quoteMapper.quote_cust_emp_name_given,
                    quote_cust_emp_name_middle = quoteMapper.quote_cust_emp_name_middle,
                    quote_cust_emp_name_family = quoteMapper.quote_cust_emp_name_family,
                    quote_cust_emp_name = quoteMapper.quote_cust_emp_name,
                    quote_cust_emp_tel = quoteMapper.quote_cust_emp_tel,
                    quote_cust_emp_tel_ext = quoteMapper.quote_cust_emp_tel_ext,
                    quote_cust_emp_hp = quoteMapper.quote_cust_emp_hp,
                    quote_cust_emp_fax = quoteMapper.quote_cust_emp_fax,
                    quote_cust_emp_email = quoteMapper.quote_cust_emp_email,
                    quote_subject = quoteMapper.quote_subject,
                    quote_date = quoteMapper.quote_date,
                    quote_reminder1 = quoteMapper.quote_reminder1,
                    quote_reminder2 = quoteMapper.quote_reminder2,
                    quote_statusid = quoteMapper.quote_statusid,
                    quote_replieddate = quoteMapper.quote_replieddate,
                    quote_validty = quoteMapper.quote_validty,
                    quote_terms = quoteMapper.quote_terms,
                    quote_wrty = quoteMapper.quote_wrty,
                    quote_cancelcharge = quoteMapper.quote_cancelcharge,
                    quote_deliver = quoteMapper.quote_deliver,
                    quote_deliver_sel = quoteMapper.quote_deliver_sel,
                    quote_remark = quoteMapper.quote_remark,
                    quote_total = quoteMapper.quote_total,
                    quote_by = quoteMapper.quote_by,
                    quote_sales_grp_id = quoteMapper.quote_sales_grp_id,
                    quote_rejectreason = quoteMapper.quote_rejectreason,
                    quote_custpo = quoteMapper.quote_custpo,
                    quote_inrmk = quoteMapper.quote_inrmk,
                    approval_id = quoteMapper.approval_id,
                    quote_cost = quoteMapper.quote_cost,
                    quote_amt = quoteMapper.quote_amt,
                    quote_margin = quoteMapper.quote_margin,
                    quote_margin_pctg = quoteMapper.quote_margin_pctg,
                    quote_us = quoteMapper.quote_us,
                    quote_by2 = quoteMapper.quote_by2,
                    quote_sales_rmk = quoteMapper.quote_sales_rmk,
                    quote_cust_ref = quoteMapper.quote_cust_ref,
                    quote_display = quoteMapper.quote_display,
                    quote_condition_rmk = quoteMapper.quote_condition_rmk,
                    quote_condition_app = quoteMapper.quote_condition_app,
                    quote_confident_lvl = quoteMapper.quote_confident_lvl,
                    quote_condition_app_date = quoteMapper.quote_condition_app_date,
                    quote_approval_rmk = quoteMapper.quote_approval_rmk,
                    quote_showGST = quoteMapper.quote_showGST,
                    quote_gst_pencentage = quoteMapper.quote_gst_pencentage,
                    quote_gst = quoteMapper.quote_gst,
                    quote_discount = quoteMapper.quote_discount,
                    inv_num = quoteMapper.inv_num,
                    quote_curr = quoteMapper.quote_curr,
                    quote_rate = quoteMapper.quote_rate,
                    quote_tnc = quoteMapper.quote_tnc,
                    quote_showWty = quoteMapper.quote_showWty,
                    quote_des_add1 = quoteMapper.quote_des_add1,
                    quote_des_add2 = quoteMapper.quote_des_add2,
                    quote_des_add3 = quoteMapper.quote_des_add3,
                    quote_des_add4 = quoteMapper.quote_des_add4,
                    quote_des_add5 = quoteMapper.quote_des_add5,
                    quote_site_add1 = quoteMapper.quote_site_add1,
                    quote_site_add2 = quoteMapper.quote_site_add2,
                    quote_site_add3 = quoteMapper.quote_site_add3,
                    quote_site_add4 = quoteMapper.quote_site_add4,
                    quote_site_add5 = quoteMapper.quote_site_add5,
                    wo_id = quoteMapper.wo_id
                };
                quoteDA.SaveQuote(mapper);
            }
            catch
            {
            }
        }

        public QuotationUIMapper GetQuoteDetails(string quoteId)
        {
            QuotationDA quoteDA = new QuotationDA();
            var val = quoteDA.GetQuoteDetails(quoteId);
            return CommonFunctions.Cast<QuotationUIMapper>(val);
        }

        public DataSet SearchQuoteDetails(string where, string orderBy)
        {
            QuotationDA quoteDA = new QuotationDA();
            return quoteDA.SearchQuoteDetails(where, orderBy);
        }

        public DataSet GetSalesmanList()
        {
            QuotationDA quoteDA = new QuotationDA();
            return quoteDA.GetSalesmanList();
        }
    }
}
