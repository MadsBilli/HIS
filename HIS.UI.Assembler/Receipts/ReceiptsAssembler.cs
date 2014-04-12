using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.Implementation.Receipts;
using HIS.Common;

namespace HIS.UI.Assembler.Receipts
{
    public class ReceiptsAssembler
    {
        public DataSet SearchReceipts(string where)
        {
            ReceiptsImpl receiptsImpl = new ReceiptsImpl();
            return receiptsImpl.SearchReceipts(where);
        }
    }
}
