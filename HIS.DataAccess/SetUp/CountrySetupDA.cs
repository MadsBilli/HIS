using DataAccess.SQL2008;
using HIS.Common;
using HIS.Data.Mapper.SetUp;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Transactions;

namespace HIS.DataAccess.SetUp
{
    public class CountrySetupDA
    {
        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_Country_SETUP_DETAILS)]
        public List<CountrySetupMapper> GetCountrySetupList()
        {
            var lsMapper = new StoredProcedureCommandBuilder().GetEntities<CountrySetupMapper>(
                                   (MethodInfo)MethodInfo.GetCurrentMethod(), null);
            return lsMapper.ToList();
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.COUNTRY_SETUP_DETAILS_UPDATE)]
        public void UpdateCountryDetails(CountrySetupMapper mapper)
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
