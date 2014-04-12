using System.Collections.Generic;
using System.Data;
using HIS.Common;
using HIS.DataAccess.Receipts;

namespace HIS.Implementation.Receipts
{
    public class ReceiptsImpl
    {
        public DataSet SearchReceipts(string where)
        {
            ReceiptsDA receiptsDA = new ReceiptsDA();
            return receiptsDA.SearchReceipts(where);
        }
    }
}
