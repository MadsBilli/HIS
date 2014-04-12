using HIS.Implementation.Setup;
using HIS.UI.Mapper.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UI.Assembler.Setup
{
    public class BUNameSetupAssembler
    {

        public List<BUNameSetupUIMapper> GetBUNameSetupList()
        {
            BUNameSetupImpl Impl = new BUNameSetupImpl();
            return Impl.GetBUNameSetupList();
        }

        public void InsertorUpdateBUNameSetupDetails(BUNameSetupUIMapper uiMapper)
        {
            BUNameSetupImpl Impl = new BUNameSetupImpl();
            Impl.InsertorUpdateBUNameDetails(uiMapper);
        }

        public void DeleteBUNameSetup(string keyField)
        {
            BUNameSetupImpl Impl = new BUNameSetupImpl();
            Impl.DeleteBUName(keyField);
        }

    }
}
