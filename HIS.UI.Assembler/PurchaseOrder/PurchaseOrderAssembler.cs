using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.Implementation.PurchaseOrder;
using HIS.UI.Mapper.PurchaseOrder;

namespace HIS.UI.Assembler.PurchaseOrder
{
    public class PurchaseOrderAssembler
    {
        public DataSet GetPurchaseOrderScreenListValues()
        {
            PurchaseOrderImpl purordImpl = new PurchaseOrderImpl();
            return purordImpl.GetPurchaseOrderScreenListValues();
        }

        public void SavePurchaseOrder(PurchaseOrderUIMapper purordMapper, string operation)
        {
            PurchaseOrderImpl purordImpl = new PurchaseOrderImpl();
            purordImpl.SavePurchaseOrder(purordMapper, operation);
        }

        public void SavePurchaseOrderItems(PurchaseOrderItemUIMapper purordItemMapper, string operation)
        {
            PurchaseOrderImpl purordImpl = new PurchaseOrderImpl();
            purordImpl.SavePurchaseOrderItems(purordItemMapper, operation);
        }

        public PurchaseOrderUIMapper GetPurchaseOrderDetails(string purordId)
        {
            PurchaseOrderImpl purordImpl = new PurchaseOrderImpl();
            return purordImpl.GetPurchaseOrderDetails(purordId);
        }

        public DataSet SearchPurchaseOrderDetails(string where, string orderBy)
        {
            PurchaseOrderImpl purordImpl = new PurchaseOrderImpl();
            return purordImpl.SearchPurchaseOrderDetails(where, orderBy);
        }

        public DataSet GetSalesmanList()
        {
            PurchaseOrderImpl purordImpl = new PurchaseOrderImpl();
            return purordImpl.GetSalesmanList();
        }
    }
}
