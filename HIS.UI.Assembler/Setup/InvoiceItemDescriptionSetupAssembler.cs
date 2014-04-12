using HIS.Implementation.Setup;
using HIS.UI.Mapper.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UI.Assembler.Setup
{
    public class InvoiceItemDescriptionSetupAssembler
    {

        public List<InvoiceItemDescriptionUIMapper> GetInvoiceItemDescriptionList()
        {
            InvoiceItemDescriptionImpl Impl = new InvoiceItemDescriptionImpl();
            return Impl.GetInvoiceItemDescriptionList();
        }

        public void InsertorUpdateInvoiceItemDescriptionDetails(InvoiceItemDescriptionUIMapper uiMapper)
        {
            InvoiceItemDescriptionImpl Impl = new InvoiceItemDescriptionImpl();
            Impl.InsertorUpdateInvoiceItemDescriptionDetails(uiMapper);
        }

        public void DeleteInvoiceItemDescription(string keyField)
        {
            InvoiceItemDescriptionImpl Impl = new InvoiceItemDescriptionImpl();
            Impl.DeleteInvoiceItemDescription(keyField);
        }

    }
}
