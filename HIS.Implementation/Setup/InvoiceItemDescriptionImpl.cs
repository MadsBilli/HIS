using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.UI.Mapper.Setup;
using HIS.DataAccess.SetUp;
using HIS.Data.Mapper.SetUp;

namespace HIS.Implementation.Setup
{
    public class InvoiceItemDescriptionImpl
    {
        public List<InvoiceItemDescriptionUIMapper> GetInvoiceItemDescriptionList()
        {
            InvoiceItemDescriptionDA da = new InvoiceItemDescriptionDA();
            var lsMapper = da.GetInvoiceSetupDescList();

            var res = (from setup in lsMapper
                       select new InvoiceItemDescriptionUIMapper
                       {
                           inv_sel_ln = setup.inv_sel_ln,
                           inv_sel_desc = setup.inv_sel_desc,
                           primaryKey = setup.inv_sel_ln
                       }).ToList();
            return res;
        }

        public void InsertorUpdateInvoiceItemDescriptionDetails(InvoiceItemDescriptionUIMapper uiMapper)
        {
            InvoiceItemDescriptionMapper mapper = new InvoiceItemDescriptionMapper
            {
                inv_sel_ln = uiMapper.inv_sel_ln,
                inv_sel_desc = uiMapper.inv_sel_desc,
                primaryKey = uiMapper.primaryKey
            };

            InvoiceItemDescriptionDA da = new InvoiceItemDescriptionDA();
            da.InsertInvoiceSetupDescDetails(mapper);
        }

        public void DeleteInvoiceItemDescription(string keyField)
        {
            InvoiceItemDescriptionDA da = new InvoiceItemDescriptionDA();
            InvoiceItemDescriptionMapper mapper = new InvoiceItemDescriptionMapper { inv_sel_ln = int.Parse(keyField) };
            da.DeleteInvoiceSetupDescDetails(mapper);
        }
    }
}
