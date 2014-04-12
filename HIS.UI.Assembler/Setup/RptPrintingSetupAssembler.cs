using HIS.Implementation.Setup;
using HIS.UI.Mapper.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UI.Assembler.Setup
{
    public class RptPrintingSetupAssembler
    {

        public List<RptPrintingSetupUIMapper> GetRptPrintingSetupList()
        {
            RptPrintingSetupImpl Impl = new RptPrintingSetupImpl();
            return Impl.GetRptPrintingSetupList();
        }

        public void InsertorUpdateRptPrintingSetupDetails(RptPrintingSetupUIMapper uiMapper)
        {
            RptPrintingSetupImpl Impl = new RptPrintingSetupImpl();
            Impl.InsertorUpdateRptPrintingDetails(uiMapper);
        }

        public void DeleteRptPrintingSetup(string keyField)
        {
            RptPrintingSetupImpl Impl = new RptPrintingSetupImpl();
            Impl.DeleteRptPrinting(keyField);
        }

    }
}
