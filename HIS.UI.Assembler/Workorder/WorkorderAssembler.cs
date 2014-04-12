using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.UI.Mapper.Workorder;
using HIS.Implementation.Workorder;
using HIS.Common;
using System.Data;

namespace HIS.UI.Assembler.Workorder
{
    public class WorkorderAssembler
    {
        public DataSet GetWorkorderScreenListValues()
        {
            WorkorderImpls workorderImpls = new WorkorderImpls();
            return workorderImpls.GetWorkorderScreenListValues();
        }

        public void SaveWorkOrder(workorderUIMapper purordMapper, string operation)
        {
            WorkorderImpls workorderImpls = new WorkorderImpls();
            workorderImpls.saveWorkorder(purordMapper, operation);
        }

        public void SaveWorkOrderItems(WorkorderItemUIMapper purordItemMapper, string operation)
        {
            WorkorderImpls workorderImpls = new WorkorderImpls();
            workorderImpls.SaveWorkOrderItems(purordItemMapper, operation);
        }

        public workorderUIMapper GetWorkOrderDetails(string purordId)
        {
            WorkorderImpls workorderImpls = new WorkorderImpls();
            return workorderImpls.GetWorkOrderDetails(purordId);
        }

        public DataSet SearchWorkorderDetails(string where, string orderBy)
        {
            WorkorderImpls workorderImpls = new WorkorderImpls();
            return workorderImpls.SearchworkorderDetails(where, orderBy);
        }

        public DataSet GetSalesmanList()
        {
            WorkorderImpls workorderImpls = new WorkorderImpls();
            return workorderImpls.GetSalesmanList();
        }
    }
}
