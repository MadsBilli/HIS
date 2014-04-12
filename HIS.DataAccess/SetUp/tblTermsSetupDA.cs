using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using HIS.Data.Mapper.SetUp;
using HIS.Common;
using DataAccess.SQL2008;
using System.Reflection;

namespace HIS.DataAccess.SetUp
{
    public class tblTermsSetupDA
    {
        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_TERMSETUPDETAILS)]
        public DataSet GetTermSetupDetails(string txtSelect)
        {
            tblTermsMapper terms = new tblTermsMapper();
            terms.txtSelect = txtSelect;
            return new StoredProcedureCommandBuilder().ExecuteDataSet(
                                   (MethodInfo)MethodInfo.GetCurrentMethod(), terms);
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.DELETE_TERM)]
        public void DeleteTermDetails(int termId)
        {
            tblTermsMapper term = new tblTermsMapper();
            term.int_ID = termId;
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), term);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.DELETE_TERM_ITEMS)]
        public void DeleteTermItemDetails(List<int> termItemIds)
        {

            using (var scope = new TransactionScope())
            {
                foreach (var termItemId in termItemIds)
                {
                    tblTermsItemMapper term = new tblTermsItemMapper();
                    term.int_ID = termItemId;
                    int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                           (MethodInfo)MethodInfo.GetCurrentMethod(), term);
                }
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.SAVE_TERMS)]
        public void SaveTermDetails(List<tblTermsMapper> termMappers)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var termMapper in termMappers)
                { 
                    int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                           (MethodInfo)MethodInfo.GetCurrentMethod(), termMapper);
                }
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.SAVE_TERM_ITEMS)]
        public void SaveTermItemDetails(List<tblTermsItemMapper> termItemMappers)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var termItemMapper in termItemMappers)
                {
                    int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                           (MethodInfo)MethodInfo.GetCurrentMethod(), termItemMapper);
                }
                scope.Complete();
            }
        }


    }
}
