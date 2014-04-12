using HIS.Implementation.Setup;
using HIS.UI.Mapper.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UI.Assembler
{
    public class SystemSetupAssembler
    {
        public List<SystemSetupUIMapper> GetSystemSetup()
        {
            SystemSetupImpl systemSetupImpl = new SystemSetupImpl();
            return systemSetupImpl.GetSystemSetup();
        }
    }
}
