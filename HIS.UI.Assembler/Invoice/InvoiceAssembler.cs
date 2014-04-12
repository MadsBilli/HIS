using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.Implementation.Invoice;
using HIS.UI.Mapper.Invoice;

namespace HIS.UI.Assembler.Invoice
{
    public class InvoiceAssembler
    {
        public DataSet GetInvoiceScreenListValues()
        {
            InvoiceImpl purordImpl = new InvoiceImpl();
            return purordImpl.GetInvoiceScreenListValues();
        }

        public void SaveInvoice(InvoiceUIMapper purordMapper, string operation)
        {
            InvoiceImpl purordImpl = new InvoiceImpl();
            purordImpl.SaveInvoice(purordMapper, operation);
        }

        public void SaveInvoiceItems(InvoiceItemUIMapper purordItemMapper, string operation)
        {
            InvoiceImpl purordImpl = new InvoiceImpl();
            purordImpl.SaveInvoiceItems(purordItemMapper, operation);
        }

        public InvoiceUIMapper GetInvoiceDetails(string purordId)
        {
            InvoiceImpl purordImpl = new InvoiceImpl();
            return purordImpl.GetInvoiceDetails(purordId);
        }

        public DataSet SearchInvoiceDetails(string where, string orderBy)
        {
            InvoiceImpl purordImpl = new InvoiceImpl();
            return purordImpl.SearchInvoiceDetails(where, orderBy);
        }

        public DataSet GetSalesmanList()
        {
            InvoiceImpl purordImpl = new InvoiceImpl();
            return purordImpl.GetSalesmanList();
        }
    }
}
