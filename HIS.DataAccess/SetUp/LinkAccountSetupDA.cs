using DataAccess.SQL2008;
using HIS.Common;
using HIS.Data.Mapper.SetUp;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Transactions;

namespace HIS.DataAccess.SetUp
{
    public class LinkAccountSetupDA
    {
        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_ACC_CODE_DETAILS)]
        public List<AccCodeMapper> GetAccCodeList()
        {
            var lsMapper = new StoredProcedureCommandBuilder().GetEntities<AccCodeMapper>(
                                  (MethodInfo)MethodInfo.GetCurrentMethod(), null);
            return lsMapper.ToList();
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_ACCGL_SETUP_DETAILS_BY_GLTYPE)]
        public AccGLTypeSetupMapper GetAccGLSetupByGLType(AccGLTypeSetupMapper mapper)
        {
            var lsMapper = new StoredProcedureCommandBuilder().GetEntities<AccGLTypeSetupMapper>(
                                 (MethodInfo)MethodInfo.GetCurrentMethod(), mapper);
            return lsMapper.FirstOrDefault();
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.SET_ACCGL_SETUP_DETAILS)]
        public void SetAccGLSetup(AccGLTypeSetupMapper mapper)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), mapper);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_BANK_ACC_DETAILS)]
        public List<AccCodeMapper> GetBankAccCodeList()
        {
            var lsMapper = new StoredProcedureCommandBuilder().GetEntities<AccCodeMapper>(
                                  (MethodInfo)MethodInfo.GetCurrentMethod(), null);
            return lsMapper.ToList();
        }
        
        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_PAYABLES_DETAILS)]    
        public List<AccCodeMapper> GetPayablesAccCodeList()
        {
            var lsMapper = new StoredProcedureCommandBuilder().GetEntities<AccCodeMapper>(
                                  (MethodInfo)MethodInfo.GetCurrentMethod(), null);
            return lsMapper.ToList();
        }
       
        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_ALL_ACC_CODE_DETAILS)]
        public List<AccCodeMapper> GetAllAccCodeList()
        {
            var lsMapper = new StoredProcedureCommandBuilder().GetEntities<AccCodeMapper>(
                                  (MethodInfo)MethodInfo.GetCurrentMethod(), null);
            return lsMapper.ToList();
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.SET_VENDOR_PURCHASES_DETAILS)]
        public void SetVendorPurchasesDetails(AccGLTypeSetupMapper mapper)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), mapper);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_RECEIVABLES_DETAILS)]    
        public List<AccCodeMapper> GetReceivablesAccCodeList()
        {
            var lsMapper = new StoredProcedureCommandBuilder().GetEntities<AccCodeMapper>(
                                  (MethodInfo)MethodInfo.GetCurrentMethod(), null);
            return lsMapper.ToList();
        }
    }
}
