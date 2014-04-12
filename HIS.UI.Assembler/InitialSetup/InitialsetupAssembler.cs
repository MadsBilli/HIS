using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.UI.Mapper.InitialSetup;
using HIS.Implementation.InitialSetup;

namespace HIS.UI.Assembler.InitialSetup
{
    public class InitialsetupAssembler
    {
        public InitialsetupUIMapper GetInitialSetup(string emp_logName)
        {
            InitialsetupImpl initImpl = new InitialsetupImpl();
            return initImpl.GetInitialSetup(emp_logName);
        }

        public void SaveInitialSetup(InitialsetupUIMapper UImapper)
        {
            InitialsetupImpl initImpl = new InitialsetupImpl();
            initImpl.SaveInitialSetup(UImapper);
        }
    }
}
