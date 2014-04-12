using HIS.Implementation.Setup;
using HIS.UI.Mapper.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UI.Assembler.Setup
{
    public class SystemSetupAssembler
    {

        public List<SystemSetupUIMapper> GetSystemSetupList()
        {
            SystemSetupImpl Impl = new SystemSetupImpl();
            return Impl.GetSystemSetup();
        }

        public void UpdateSystemSetupDetails(SystemSetupUIMapper uiMapper)
        {
            SystemSetupImpl Impl = new SystemSetupImpl();
            Impl.UpdateSystemSetupDetails(uiMapper);
        }

    }
}
