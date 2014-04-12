using HIS.Implementation.Setup;
using HIS.UI.Mapper.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UI.Assembler.Setup
{
    public class SalesManCommSetupAssembler
    {

        public List<SalesManCommSetupUIMapper> GetSalesManCommSetupList()
        {
            SalesManCommSetupImpl Impl = new SalesManCommSetupImpl();
            return Impl.GetSalesManCommSetupList();
        }

        public void UpdateSalesManCommSetupDetails(SalesManCommSetupUIMapper uiMapper)
        {
            SalesManCommSetupImpl Impl = new SalesManCommSetupImpl();
            Impl.UpdateSalesManCommDetails(uiMapper);
        }
    }
}
