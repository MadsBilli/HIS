using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.DataAccess.Invoice;
using HIS.UI.Mapper.Invoice;
using HIS.Common;
using HIS.Data.Mapper.Invoice;

namespace HIS.Implementation.Invoice
{
    public class InvoiceImpl
    {
        public DataSet GetInvoiceScreenListValues()
        {
            InvoiceDA invDA = new InvoiceDA();
            return invDA.GetInvoiceScreenListValues();
        }

        public void SaveInvoice(InvoiceUIMapper invMapper, string operation)
        {
            try
            {
                List<InvoiceUIMapper> lsQuoteMapper = new List<InvoiceUIMapper>();
                lsQuoteMapper.Add(invMapper);
                DataTable dt = CommonFunctions.CopyListToDataTable<InvoiceUIMapper>(lsQuoteMapper);
                InvoiceDA quoteDA = new InvoiceDA();
                //quoteDA.SaveQuote(dt, operation);

                InvoiceMapper mapper = new InvoiceMapper
                {
                    inv_id = invMapper.inv_id,
                    inv_cust_id = invMapper.inv_cust_id,
                    inv_cust_name = invMapper.inv_cust_name,
                    inv_resp = invMapper.inv_resp,
                    inv_address = invMapper.inv_address,
                    inv_siteadd = invMapper.inv_siteadd,
                    inv_add2 = invMapper.inv_add2,
                    inv_city = invMapper.inv_city,
                    inv_siteadd2 = invMapper.inv_siteadd2,
                    inv_sitecity = invMapper.inv_sitecity,
                    inv_postal = invMapper.inv_postal,
                    inv_cust_Country = invMapper.inv_cust_Country,
                    inv_sitepos = invMapper.inv_sitepos,
                    inv_sitecountry = invMapper.inv_sitecountry,
                    inv_contact = invMapper.inv_contact,
                    inv_sitecon = invMapper.inv_sitecon,
                    inv_tel = invMapper.inv_tel,
                    inv_Hp = invMapper.inv_Hp,
                    inv_sitetel = invMapper.inv_sitetel,
                    inv_sitehp = invMapper.inv_sitehp,
                    inv_fax = invMapper.inv_fax,
                    inv_sitefax = invMapper.inv_sitefax,
                    inv_email = invMapper.inv_email,
                    inv_siteemail = invMapper.inv_siteemail,
                    inv_cust = invMapper.inv_cust,
                    inv_createddate = invMapper.inv_createddate,
                    inv_created_by = invMapper.inv_created_by,
                    inv_salesby = invMapper.inv_salesby,
                    inv_qutrefno = invMapper.inv_qutrefno,
                    inv_invrefno = invMapper.inv_invrefno,
                    dsc_inv_install = invMapper.dsc_inv_install,
                    inv_time = invMapper.inv_time,
                    inv_by = invMapper.inv_by,
                    inv_roundoff = invMapper.inv_roundoff,
                    inv_installation_rmk = invMapper.inv_installation_rmk,
                    inv_rmk = invMapper.inv_rmk,
                    inv_deposite_bank = invMapper.inv_deposite_bank,
                    inv_deposite_date = invMapper.inv_deposite_date,
                    inv_receivied_by = invMapper.inv_receivied_by,
                    inv_chq_no = invMapper.inv_chq_no,
                    inv_amount = invMapper.inv_amount,
                    inv_internal_rmk = invMapper.inv_internal_rmk
                };
                quoteDA.SaveInvoice(mapper);
            }
            catch
            {
            }
        }

        public void SaveInvoiceItems(InvoiceItemUIMapper invItemMapper, string operation)
        {
            try
            {
                List<InvoiceItemUIMapper> lsQuoteMapper = new List<InvoiceItemUIMapper>();
                lsQuoteMapper.Add(invItemMapper);
                DataTable dt = CommonFunctions.CopyListToDataTable<InvoiceItemUIMapper>(lsQuoteMapper);
                InvoiceDA quoteDA = new InvoiceDA();
                //quoteDA.SaveQuote(dt, operation);

                InvoiceItemMapper mapper = new InvoiceItemMapper
                {
                    inv_id = invItemMapper.inv_id,
                    inv_item_id = invItemMapper.inv_item_id,
                    inv_item_header = invItemMapper.inv_item_header,
                    inv_item_model = invItemMapper.inv_item_model,
                    inv_item_type = invItemMapper.inv_item_type,
                    inv_item_desc = invItemMapper.inv_item_desc,
                    inv_item_width = invItemMapper.inv_item_width,
                    inv_item_height = invItemMapper.inv_item_height,
                    inv_item_Qty = invItemMapper.inv_item_qty,
                    inv_item_amt = invItemMapper.inv_item_amt,
                    inv_item_tamt = invItemMapper.inv_item_tamt

                };
                quoteDA.SaveInvoiceItems(mapper);
            }
            catch
            {
            }
        }

        public InvoiceUIMapper GetInvoiceDetails(string porordId)
        {
            InvoiceDA invDA = new InvoiceDA();
            var val = invDA.GetInvoiceDetails(porordId);
            return CommonFunctions.Cast<InvoiceUIMapper>(val);
        }

        public DataSet SearchInvoiceDetails(string where, string orderBy)
        {
            InvoiceDA invDA = new InvoiceDA();
            return invDA.SearchInvoiceDetails(where, orderBy);
        }

        public DataSet GetSalesmanList()
        {
            InvoiceDA invDA = new InvoiceDA();
            return invDA.GetSalesmanList();
        }
    }
}
