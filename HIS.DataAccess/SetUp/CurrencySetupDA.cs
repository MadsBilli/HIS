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
    public class CurrencySetupDA
    {
        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_CURRENCY_SETUP_DETAILS)]
        public DataSet GetCurrencySetupDetails()
        {
            return new StoredProcedureCommandBuilder().ExecuteDataSet(
                                   (MethodInfo)MethodInfo.GetCurrentMethod(), null);
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.SAVE_CURRENCY_SETUP_DETAILS)]
        public void SaveCurrencySetupDetails(List<CurrencySetupMapper> currencySetups, List<CurrencyTBMapper> currencytbMapper)
        {
            using (var scope = new TransactionScope())
            {
                foreach (var currencySetup in currencySetups)
                {
                    int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                           (MethodInfo)MethodInfo.GetCurrentMethod(), currencySetup);
                }
                SaveCurrencySetupDetails(currencytbMapper);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.SAVE_CURRENCY_TB_DETAILS)]
        public void SaveCurrencySetupDetails(List<CurrencyTBMapper> currencytbMapper)
        {
            foreach (var currencytb in currencytbMapper)
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), currencytb);
            }
        }
    }
}
