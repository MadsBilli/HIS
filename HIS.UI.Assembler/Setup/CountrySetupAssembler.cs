using HIS.Implementation.Setup;
using HIS.UI.Mapper.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UI.Assembler.Setup
{
    public class CountrySetupAssembler
    {

        public List<CountrySetupUIMapper> GetCountrySetupList()
        {
            CountrySetupImpl Impl = new CountrySetupImpl();
            return Impl.GetCountrySetupList();
        }

        public void InsertorUpdateCountrySetupDetails(CountrySetupUIMapper uiMapper)
        {
            CountrySetupImpl Impl = new CountrySetupImpl();
            Impl.UpdateCountryDetails(uiMapper);
        }
    }
}
