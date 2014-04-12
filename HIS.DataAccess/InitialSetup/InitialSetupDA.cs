using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using HIS.Data.Mapper.InitialSetup; 
using HIS.Common;
using DataAccess.SQL2008;
using System.Reflection;

namespace HIS.DataAccess.InitialSetup
{
    public  class InitialSetupDA
    {
        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_INITIALSETUP)]
        public InitialsetupMapper GetInitialSetup(string emp_logName)
        {
            InitialsetupMapper par = new InitialsetupMapper();
            par.emp_logname = emp_logName;
            var lsinit = new StoredProcedureCommandBuilder().GetEntities<InitialsetupMapper>(
                                    (MethodInfo)MethodInfo.GetCurrentMethod(), par);
            return lsinit.ToList().FirstOrDefault();
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.SAVE_INITIAL_SETUP)]
        public void SaveInitialSetup(InitialsetupMapper mapper)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), mapper);
                scope.Complete();
            }
        }
    }
}
