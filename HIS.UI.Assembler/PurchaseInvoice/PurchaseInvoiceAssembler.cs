using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.UI.Mapper.PurchaseInvoice;
using HIS.Implementation.PurchaseInvoice;

namespace HIS.UI.Assembler.PurchaseInvoice
{
    public class PurchaseInvoiceAssembler
    {
        public DataSet GetPurchaseOrderScreenListValues()
        {
            PurchaseInvoiceImpl purordImpl = new PurchaseInvoiceImpl();
            return purordImpl.GetPurchaseInvoiceScreenListValues();
        }

        public void SavePurchaseOrder(PurchaseInvoiceUIMapper purordMapper, string operation)
        {
            PurchaseInvoiceImpl purordImpl = new PurchaseInvoiceImpl();
            purordImpl.SavePurchaseInvoice(purordMapper, operation);
        }



        public DataSet SearchPurchaseOrderDetails(string where, string orderBy)
        {
            PurchaseInvoiceImpl purordImpl = new PurchaseInvoiceImpl();
            return purordImpl.SearchPurchaseInvoiceDetails(where, orderBy);
        }

        public DataSet GetSalesmanList()
        {
            PurchaseInvoiceImpl purordImpl = new PurchaseInvoiceImpl();
            return purordImpl.GetSalesmanList();
        }
    }
}
