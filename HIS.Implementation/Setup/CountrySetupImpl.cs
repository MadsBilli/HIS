using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.UI.Mapper.Setup;
using HIS.DataAccess.SetUp;
using HIS.Data.Mapper.SetUp;

namespace HIS.Implementation.Setup
{
    public class CountrySetupImpl
    {
        public List<CountrySetupUIMapper> GetCountrySetupList()
        {
            CountrySetupDA da = new CountrySetupDA();
            var lsMapper = da.GetCountrySetupList();

            var res = (from setup in lsMapper
                       select new CountrySetupUIMapper
                       {
                           city_code = setup.city_code,
                           city_desc = setup.city_desc,
                           city_active = setup.city_active,
                           primaryKey = setup.city_code
                       }).ToList();
            return res;
        }

        public void UpdateCountryDetails(CountrySetupUIMapper uiMapper)
        {
            CountrySetupMapper mapper = new CountrySetupMapper
            {
                city_code = uiMapper.city_code,
                city_desc = uiMapper.city_desc,
                city_active = uiMapper.city_active,
                primaryKey = uiMapper.primaryKey
            };

            CountrySetupDA da = new CountrySetupDA();
            da.UpdateCountryDetails(mapper);
        }
    }
}
