using HIS.Data.Mapper.SetUp;
using HIS.DataAccess.SetUp;
using HIS.UI.Mapper.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Implementation.Setup
{
    public class SystemSetupImpl
    {
        public List<SystemSetupUIMapper> GetSystemSetup()
        {
            SystemSetupDA setupDA = new SystemSetupDA();
            var lsSystemSetupMapper = setupDA.GetSystemSetup();

            var res = (from setup in lsSystemSetupMapper
                       select new SystemSetupUIMapper
                       {
                           setup_id = setup.setup_id,
                           setup_description = setup.setup_description,
                           setup_grp = setup.setup_grp,
                           setup_LN = setup.setup_LN,
                           setup_txt = setup.setup_txt,
                           setup_value = setup.setup_value,
                           primaryKey = setup.setup_txt
                       }).ToList();
            return res;
        }

        public void UpdateSystemSetupDetails(SystemSetupUIMapper uiMapper)
        {
            SystemSetupMapper mapper = new SystemSetupMapper
            {
                setup_id = uiMapper.setup_id,
                setup_description = uiMapper.setup_description,
                setup_grp = uiMapper.setup_grp,
                setup_LN = uiMapper.setup_LN,
                setup_txt = uiMapper.setup_txt,
                setup_value = uiMapper.setup_value,
                primaryKey = uiMapper.primaryKey
            };

            SystemSetupDA da = new SystemSetupDA();
            da.UpdateSystemSetupDetails(mapper);
        }
    }
}
