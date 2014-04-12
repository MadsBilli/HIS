using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.UI.Mapper.PurchaseInvoice;
using HIS.Common;
using HIS.DataAccess.PurchaseInvoice;
using HIS.Data.Mapper.PurchaseInvoice;

namespace HIS.Implementation.PurchaseInvoice
{
    public class PurchaseInvoiceImpl
    {
        public DataSet GetPurchaseInvoiceScreenListValues()
        {
            PurchaseInvoiceDA purordDA = new PurchaseInvoiceDA();
            return purordDA.GetPurchaseInvoiceScreenListValues();
        }

        public void SavePurchaseInvoice(PurchaseInvoiceUIMapper purordMapper, string operation)
        {
            try
            {
                List<PurchaseInvoiceUIMapper> lsQuoteMapper = new List<PurchaseInvoiceUIMapper>();
                lsQuoteMapper.Add(purordMapper);
                DataTable dt = CommonFunctions.CopyListToDataTable<PurchaseInvoiceUIMapper>(lsQuoteMapper);
                PurchaseInvoiceDA quoteDA = new PurchaseInvoiceDA();
                //quoteDA.SaveQuote(dt, operation);

                PurchaseInvoiceMapper mapper = new PurchaseInvoiceMapper
                {
                    invoice = purordMapper.invoice,
                    pi_date = purordMapper.pi_date,
                    pi_acct = purordMapper.pi_acct,
                    pi_default_acc_code = purordMapper.pi_default_acc_code,
                    pi_balance_code = purordMapper.pi_balance_code,
                    pi_sub_Total = purordMapper.pi_sub_Total,
                    pi_gst = purordMapper.pi_gst,
                    pi_Total = purordMapper.pi_Total,
                    pi_item_id = purordMapper.pi_item_id,
                    pi_item_order = purordMapper.pi_item_order,
                    pi_item_Re = purordMapper.pi_item_Re,
                    pi_item_Unit = purordMapper.pi_item_Unit,
                    pi_item_Desc = purordMapper.pi_item_Desc,
                    pi_item_Price = purordMapper.pi_item_Price,
                    pi_item_Tax = purordMapper.pi_item_Tax,
                    pi_item_Gst = purordMapper.pi_item_Gst,
                    pi_item_amount = purordMapper.pi_item_amount,
                    pi_item_Acccode = purordMapper.pi_item_Acccode,
                    pi_item_Suplier = purordMapper.pi_item_Suplier,
                    pi_item_Rec = purordMapper.pi_item_Rec,
                    pi_item_InoviceNumber = purordMapper.pi_item_InoviceNumber,
                    pi_item_woid = purordMapper.pi_item_woid
                };
                quoteDA.SavePurchaseInvoice(mapper);
            }
            catch
            {
            }
        }




        public DataSet SearchPurchaseInvoiceDetails(string where, string orderBy)
        {
            PurchaseInvoiceDA purordDA = new PurchaseInvoiceDA();
            return purordDA.SearchPurchaseInvoiceDetails(where, orderBy);
        }

        public DataSet GetSalesmanList()
        {
            PurchaseInvoiceDA purordDA = new PurchaseInvoiceDA();
            return purordDA.GetSalesmanList();
        }
    }
}
