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
    public class BUNameSetupImpl
    {
        public List<BUNameSetupUIMapper> GetBUNameSetupList()
        {
            BUNameSetupDA da = new BUNameSetupDA();
            var lsMapper = da.GetBUNameSetupList();

            var res = (from setup in lsMapper
                       select new BUNameSetupUIMapper
                       {
                           bu_id = setup.bu_id,
                           bu_desc = setup.bu_desc,
                           bu_GST_code = setup.bu_GST_code,
                           primaryKey = setup.bu_id
                       }).ToList();
            return res;
        }

        public void InsertorUpdateBUNameDetails(BUNameSetupUIMapper uiMapper)
        {
            BUNameSetupMapper mapper = new BUNameSetupMapper
            {
                bu_id = uiMapper.bu_id,
                bu_desc = uiMapper.bu_desc,
                bu_GST_code = uiMapper.bu_GST_code,
                primaryKey = uiMapper.primaryKey
            };

            BUNameSetupDA da = new BUNameSetupDA();
            da.InsertorUpdateBUNameDetails(mapper);
        }

        public void DeleteBUName(string keyField)
        {
            BUNameSetupDA da = new BUNameSetupDA();
            BUNameSetupMapper mapper = new BUNameSetupMapper { bu_id = int.Parse(keyField) };
            da.DeleteBUName(mapper);
        }
    }
}
