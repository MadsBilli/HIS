using HIS.Implementation.Setup;
using HIS.UI.Mapper.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UI.Assembler.Setup
{
    public class LinkAccountSetupAssembler
    {
        public List<AccCodeUIMapper> GetAccCodeList()
        {
            LinkAccountSetupImpl Impl = new LinkAccountSetupImpl();
            return Impl.GetAccCodeList();
        }

        public AccGLTypeSetupUIMapper GetAccGLSetupByGLType(string GLType)
        {
            LinkAccountSetupImpl Impl = new LinkAccountSetupImpl();
            return Impl.GetAccGLSetupByGLType(GLType);
        }

        public void SetAccGLSetup(string type, string value)
        {
            LinkAccountSetupImpl Impl = new LinkAccountSetupImpl();
            Impl.SetAccGLSetup(type,value);
        }

        public List<AccCodeUIMapper> GetBankAccCodeList()
        {
            LinkAccountSetupImpl Impl = new LinkAccountSetupImpl();
            return Impl.GetBankAccCodeList();
        }

        public List<AccCodeUIMapper> GetPayablesAccCodeList()
        {
            LinkAccountSetupImpl Impl = new LinkAccountSetupImpl();
            return Impl.GetPayablesAccCodeList();
        }

        public List<AccCodeUIMapper> GetAllAccCodeList()
        {
            LinkAccountSetupImpl Impl = new LinkAccountSetupImpl();
            return Impl.GetAllAccCodeList();
        }

        public void SetAccGLSetup(AccGLTypeSetupUIMapper mapper)
        {
            LinkAccountSetupImpl Impl = new LinkAccountSetupImpl();
            Impl.SetAccGLSetup(mapper);
        }

        public List<AccCodeUIMapper> GetReceivablesAccCodeList()
        {
            LinkAccountSetupImpl Impl = new LinkAccountSetupImpl();
            return Impl.GetReceivablesAccCodeList();
        }
    }
}
