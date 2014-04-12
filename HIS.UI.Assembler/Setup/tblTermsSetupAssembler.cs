using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HIS.Implementation.Setup;
using HIS.UI.Mapper.Setup;

namespace HIS.UI.Assembler.Setup
{
    public class tblTermsSetupAssembler
    {
        public DataSet GetTermSetupDetails(string txtSelect)
        {
            tblTermSetupImpl termimpl = new tblTermSetupImpl();
            return termimpl.GetTermSetupDetails(txtSelect);
        }

        public void DeleteTermDetails(int termId)
        {
            tblTermSetupImpl termimpl = new tblTermSetupImpl();
            termimpl.DeleteTermDetails(termId);
        }

        public void DeleteTermItemDetails(List<int> termItemIds)
        {
            tblTermSetupImpl termimpl = new tblTermSetupImpl();
            termimpl.DeleteTermItemDetails(termItemIds);
        }

        public void SaveTermDetails(List<tblTermsUIMapper> termUIMappers)
        {
            tblTermSetupImpl termimpl = new tblTermSetupImpl();
            termimpl.SaveTermDetails(termUIMappers);
        }

        public void SaveTermItemDetails(List<tblTermsItemUIMapper> termUIMappers)
        {
            tblTermSetupImpl termimpl = new tblTermSetupImpl();
            termimpl.SaveTermItemDetails(termUIMappers);
        }
    }
}
