using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.UI.Mapper.Setup;
using HIS.DataAccess.SetUp;
using HIS.Data.Mapper.SetUp;

namespace HIS.Implementation.Setup
{
    public class UOMSetupImpl
    {
        public List<UOMSetupUIMapper> GetUOMSetupList()
        {
            UOMSetupDA da = new UOMSetupDA();
            var lsMapper = da.GetUOMSetupList();

            var res = (from setup in lsMapper
                       select new UOMSetupUIMapper
                       {
                           unit_id = setup.unit_id,
                           unit_type = setup.unit_type,
                           unit_rmk = setup.unit_rmk,
                           primaryKey = setup.unit_id
                       }).ToList();
            return res;
        }

        public void InsertorUpdateUOMDetails(UOMSetupUIMapper uiMapper)
        {
            UOMSetupMapper mapper = new UOMSetupMapper
            {
                unit_id = uiMapper.unit_id,
                unit_type = uiMapper.unit_type,
                unit_rmk = uiMapper.unit_rmk,
                primaryKey = uiMapper.primaryKey
            };

            UOMSetupDA da = new UOMSetupDA();
            da.InsertorUpdateUOMDetails(mapper);
        }

        public void DeleteUOM(string keyField)
        {
            UOMSetupDA da = new UOMSetupDA();
            UOMSetupMapper mapper = new UOMSetupMapper { unit_id = int.Parse(keyField) };
            da.DeleteUOM(mapper);
        }
    }
}
