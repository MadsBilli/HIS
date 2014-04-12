using DataAccess.SQL2008;
using HIS.Common;
using HIS.Data.Mapper.SetUp;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Transactions;


namespace HIS.DataAccess.SetUp
{
    public class RptPrintingSetupDA
    {
        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_RPT_PRINTING_SETUP_DETAILS)]
        public List<RptPrintingSetupMapper> GetRptPrintingSetupList()
        {
            var lsMapper = new StoredProcedureCommandBuilder().GetEntities<RptPrintingSetupMapper>(
                                   (MethodInfo)MethodInfo.GetCurrentMethod(), null);
            return lsMapper.ToList();
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.RPT_PRINTING_SETUP_DETAILS_INSERT)]
        public void InsertorUpdateRptPrintingDetails(RptPrintingSetupMapper mapper)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), mapper);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.RPT_PRINTING_SETUP_DETAILS_DELETE)]
        public void DeleteRptPrinting(RptPrintingSetupMapper mapper)
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
