using DataAccess.SQL2008;
using HIS.Common;
using HIS.Data.Mapper.SetUp;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Transactions;


namespace HIS.DataAccess.SetUp
{
    public class InvoiceItemDescriptionDA
    {
        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_INVOICE_ITEM_DESC_DETAILS)]
        public List<InvoiceItemDescriptionMapper> GetInvoiceSetupDescList()
        {
            var lsMapper = new StoredProcedureCommandBuilder().GetEntities<InvoiceItemDescriptionMapper>(
                                   (MethodInfo)MethodInfo.GetCurrentMethod(), null);
            return lsMapper.ToList();
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.INVOICE_ITEM_DESC_DETAILS_INSERT)]
        public void InsertInvoiceSetupDescDetails(InvoiceItemDescriptionMapper mapper)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), mapper);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.INVOICE_ITEM_DESC_DETAILS_DELETE)]
        public void DeleteInvoiceSetupDescDetails(InvoiceItemDescriptionMapper mapper)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), mapper);
                scope.Complete();
            }
        }
    }
}
