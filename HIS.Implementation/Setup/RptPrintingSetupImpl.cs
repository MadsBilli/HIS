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
    public class RptPrintingSetupImpl
    {
        public List<RptPrintingSetupUIMapper> GetRptPrintingSetupList()
        {
            RptPrintingSetupDA da = new RptPrintingSetupDA();
            var lsMapper = da.GetRptPrintingSetupList();

            var res = (from setup in lsMapper
                       select new RptPrintingSetupUIMapper
                       {
                           rt_name = setup.rt_name,
                           rt_display_name = setup.rt_display_name,
                           rt_allow_edit = setup.rt_allow_edit,
                           rt_form  = setup.rt_form,
                           rt_id = setup.rt_id,
                           rt_criteria = setup.rt_criteria,
                           rt_table = setup.rt_table,                           
                           primaryKey = setup.rt_name
                       }).ToList();
            return res;
        }

        public void InsertorUpdateRptPrintingDetails(RptPrintingSetupUIMapper uiMapper)
        {
            RptPrintingSetupMapper mapper = new RptPrintingSetupMapper
            {
                rt_name = uiMapper.rt_name,
                rt_display_name = uiMapper.rt_display_name,
                rt_allow_edit = uiMapper.rt_allow_edit,
                rt_form = uiMapper.rt_form,
                rt_id = uiMapper.rt_id,
                rt_criteria = uiMapper.rt_criteria,
                rt_table = uiMapper.rt_table,  
                primaryKey = uiMapper.primaryKey
            };

            RptPrintingSetupDA da = new RptPrintingSetupDA();
            da.InsertorUpdateRptPrintingDetails(mapper);
        }

        public void DeleteRptPrinting(string keyField)
        {
            RptPrintingSetupDA da = new RptPrintingSetupDA();
            RptPrintingSetupMapper mapper = new RptPrintingSetupMapper { rt_name = keyField };
            da.DeleteRptPrinting(mapper);
        }
    }
}
