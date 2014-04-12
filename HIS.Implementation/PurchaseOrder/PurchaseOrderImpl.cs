using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.DataAccess.PurchaseOrder;
using HIS.UI.Mapper.PurchaseOrder;
using HIS.Common;
using HIS.Data.Mapper.PurchaseOrder;

namespace HIS.Implementation.PurchaseOrder
{
    public class PurchaseOrderImpl
    {
        public DataSet GetPurchaseOrderScreenListValues()
        {
            PurchaseOrderDA purordDA = new PurchaseOrderDA();
            return purordDA.GetPurchaseOrderScreenListValues();
        }

        public void SavePurchaseOrder(PurchaseOrderUIMapper purordMapper, string operation)
        {
            try
            {
                List<PurchaseOrderUIMapper> lsQuoteMapper = new List<PurchaseOrderUIMapper>();
                lsQuoteMapper.Add(purordMapper);
                DataTable dt = CommonFunctions.CopyListToDataTable<PurchaseOrderUIMapper>(lsQuoteMapper);
                PurchaseOrderDA quoteDA = new PurchaseOrderDA();
                //quoteDA.SaveQuote(dt, operation);

                PurchaseOrderMapper mapper = new PurchaseOrderMapper
                {
                    po_id = purordMapper.quote_id,
                    purord_cust_id = purordMapper.purord_cust_id,
                    purord_cust_name = purordMapper.purord_cust_name,
                    purord_resp = purordMapper.purord_resp,
                    purord_address = purordMapper.purord_address,
                    purord_siteadd = purordMapper.purord_siteadd,
                    purord_add2 = purordMapper.purord_add2,
                    purord_city = purordMapper.purord_city,
                    purord_siteadd2 = purordMapper.purord_siteadd2,
                    purord_sitecity = purordMapper.purord_sitecity,
                    purord_postal = purordMapper.purord_postal,
                    purord_cust_Country = purordMapper.purord_cust_Country,
                    purord_sitepos = purordMapper.purord_sitepos,
                    purord_sitecountry = purordMapper.purord_sitecountry,
                    purord_contact = purordMapper.purord_contact,
                    purord_sitecon = purordMapper.purord_sitecon,
                    purord_tel = purordMapper.purord_tel,
                    purord_Hp = purordMapper.purord_Hp,
                    purord_sitetel = purordMapper.purord_sitetel,
                    purord_sitehp = purordMapper.purord_sitehp,
                    purord_fax = purordMapper.purord_fax,
                    purord_sitefax = purordMapper.purord_sitefax,
                    purord_email = purordMapper.purord_email,
                    purord_siteemail = purordMapper.purord_siteemail,
                    purord_cust = purordMapper.purord_cust,
                    purord_createddate = purordMapper.purord_createddate,
                    purord_created_by = purordMapper.purord_created_by,
                    purord_salesby = purordMapper.purord_salesby,
                    purord_qutrefno = purordMapper.purord_qutrefno,
                    purord_invrefno = purordMapper.purord_invrefno,
                    dsc_purord_install = purordMapper.dsc_purord_install,
                    purord_time = purordMapper.purord_time,
                    purord_by = purordMapper.purord_by,
                    purord_roundoff = purordMapper.purord_roundoff,
                    purord_installation_rmk = purordMapper.purord_installation_rmk,
                    purord_rmk = purordMapper.purord_rmk,
                    purord_deposite_bank = purordMapper.purord_deposite_bank,
                    purord_deposite_date = purordMapper.purord_deposite_date,
                    purord_receivied_by = purordMapper.purord_receivied_by,
                    purord_chq_no = purordMapper.purord_chq_no,
                    purord_amount = purordMapper.purord_amount,
                    purord_internal_rmk = purordMapper.purord_internal_rmk
                };
                quoteDA.SavePurchaseOrder(mapper);
            }
            catch
            {
            }
        }

        public void SavePurchaseOrderItems(PurchaseOrderItemUIMapper purordItemMapper, string operation)
        {
            try
            {
                List<PurchaseOrderItemUIMapper> lsQuoteMapper = new List<PurchaseOrderItemUIMapper>();
                lsQuoteMapper.Add(purordItemMapper);
                DataTable dt = CommonFunctions.CopyListToDataTable<PurchaseOrderItemUIMapper>(lsQuoteMapper);
                PurchaseOrderDA quoteDA = new PurchaseOrderDA();
                //quoteDA.SaveQuote(dt, operation);

                PurchaseOrderItemMapper mapper = new PurchaseOrderItemMapper
                {
                    purord_id = purordItemMapper.purord_id,
                    purord_item_id = purordItemMapper.purord_item_id,
                    purord_item_header = purordItemMapper.purord_item_header,
                    purord_item_model = purordItemMapper.purord_item_model,
                    purord_item_type = purordItemMapper.purord_item_type,
                    purord_item_desc = purordItemMapper.purord_item_desc,
                    purord_item_width = purordItemMapper.purord_item_width,
                    purord_item_height = purordItemMapper.purord_item_height,
                    quote_item_Qty = purordItemMapper.quote_item_qty,
                    purord_item_amt = purordItemMapper.purord_item_amt,
                    purord_item_tamt = purordItemMapper.purord_item_tamt

                };
                quoteDA.SavePurchaseOrderItems(mapper);
            }
            catch
            {
            }
        }

        public PurchaseOrderUIMapper GetPurchaseOrderDetails(string porordId)
        {
            PurchaseOrderDA purordDA = new PurchaseOrderDA();
            var val = purordDA.GetPurchaseOrderDetails(porordId);
            return CommonFunctions.Cast<PurchaseOrderUIMapper>(val);
        }

        public DataSet SearchPurchaseOrderDetails(string where, string orderBy)
        {
            PurchaseOrderDA purordDA = new PurchaseOrderDA();
            return purordDA.SearchPurchaseOrderDetails(where, orderBy);
        }

        public DataSet GetSalesmanList()
        {
            PurchaseOrderDA purordDA = new PurchaseOrderDA();
            return purordDA.GetSalesmanList();
        }
    }
}
