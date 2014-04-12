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
    public class SalesManCommSetupImpl
    {
        public List<SalesManCommSetupUIMapper> GetSalesManCommSetupList()
        {
            SalesManCommSetupDA da = new SalesManCommSetupDA();
            var lsMapper = da.GetSalesManCommSetupList();

            var res = (from setup in lsMapper
                       select new SalesManCommSetupUIMapper
                       {
                           emp_id = setup.emp_id,
                           emp_name = setup.emp_name,
                           emp_salesman_com = decimal.Parse(setup.emp_salesman_com).ToString("0.00%"),
                           emp_salesman_id = setup.emp_salesman_id
                       }).ToList();
            return res;
        }

        public void UpdateSalesManCommDetails(SalesManCommSetupUIMapper uiMapper)
        {
            SalesManCommSetupMapper mapper = new SalesManCommSetupMapper
            {
                emp_id = uiMapper.emp_id,
                emp_name = uiMapper.emp_name,
                emp_salesman_com = uiMapper.emp_salesman_com,
                emp_salesman_id = uiMapper.emp_salesman_id     
            };

            SalesManCommSetupDA da = new SalesManCommSetupDA();
            da.UpdateSalesManCommDetails(mapper);
        }
    }
}
