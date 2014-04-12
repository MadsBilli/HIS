using HIS.Implementation.Setup;
using HIS.UI.Mapper.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UI.Assembler.Setup
{
    public class UOMSetupAssembler
    {

        public List<UOMSetupUIMapper> GetUOMSetupList()
        {
            UOMSetupImpl Impl = new UOMSetupImpl();
            return Impl.GetUOMSetupList();
        }

        public void InsertorUpdateUOMSetupDetails(UOMSetupUIMapper uiMapper)
        {
            UOMSetupImpl Impl = new UOMSetupImpl();
            Impl.InsertorUpdateUOMDetails(uiMapper);
        }

        public void DeleteUOMSetup(string keyField)
        {
            UOMSetupImpl Impl = new UOMSetupImpl();
            Impl.DeleteUOM(keyField);
        }

    }
}
