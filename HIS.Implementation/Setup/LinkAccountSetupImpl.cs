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
    public class LinkAccountSetupImpl
    {
        public List<AccCodeUIMapper> GetAccCodeList()
        {
            LinkAccountSetupDA da = new LinkAccountSetupDA();
            var lsMapper = da.GetAccCodeList();
            if (lsMapper != null)
            {
                var res = (from setup in lsMapper
                           select new AccCodeUIMapper
                           {
                               acc_code = setup.acc_code,
                               acc_balance = setup.acc_balance,
                               acc_class = setup.acc_class,
                               acc_class_option = setup.acc_class_option,
                               acc_class_option_type = setup.acc_class_option_type,
                               acc_inactive = setup.acc_inactive,
                               acc_reconciliation = setup.acc_reconciliation,
                               acc_type = setup.acc_type,
                               acc_bank_code = setup.acc_bank_code,
                               primaryKey = setup.acc_code
                           }).ToList();
                return res;
            }
            return new List<AccCodeUIMapper>();
        }

        public AccGLTypeSetupUIMapper GetAccGLSetupByGLType(string GLType)
        {
            LinkAccountSetupDA da = new LinkAccountSetupDA();
            AccGLTypeSetupMapper mapper = new AccGLTypeSetupMapper();
            mapper.gl_setup_type = GLType;
            var res = da.GetAccGLSetupByGLType(mapper);
            if (res != null)
                return new AccGLTypeSetupUIMapper
                           {
                               gl_setup_type = res.gl_setup_type,
                               gl_acc_code = res.gl_acc_code,
                               gl_discount = res.gl_discount,
                               gl_freight = res.gl_freight,
                               gl_principal_bank = res.gl_principal_bank
                           };
            return new AccGLTypeSetupUIMapper();
        }

        public void SetAccGLSetup(string type, string value)
        {
            LinkAccountSetupDA da = new LinkAccountSetupDA();
            AccGLTypeSetupMapper mapper = new AccGLTypeSetupMapper();
            mapper.gl_setup_type = type;
            mapper.gl_acc_code = value;
            da.SetAccGLSetup(mapper);            
        }

        public List<AccCodeUIMapper> GetBankAccCodeList()
        {
            LinkAccountSetupDA da = new LinkAccountSetupDA();
            var lsMapper = da.GetBankAccCodeList();
            if (lsMapper != null)
            {
                var res = (from setup in lsMapper
                           select new AccCodeUIMapper
                           {
                               acc_code = setup.acc_code,
                               acc_balance = setup.acc_balance,
                               acc_class = setup.acc_class,
                               acc_class_option = setup.acc_class_option,
                               acc_class_option_type = setup.acc_class_option_type,
                               acc_inactive = setup.acc_inactive,
                               acc_reconciliation = setup.acc_reconciliation,
                               acc_type = setup.acc_type,
                               acc_bank_code = setup.acc_bank_code,
                               primaryKey = setup.acc_code
                           }).ToList();
                return res;
            }
            return new List<AccCodeUIMapper>();
        }

        public List<AccCodeUIMapper> GetPayablesAccCodeList()
        {
            LinkAccountSetupDA da = new LinkAccountSetupDA();
            var lsMapper = da.GetPayablesAccCodeList();
            if (lsMapper != null)
            {
                var res = (from setup in lsMapper
                           select new AccCodeUIMapper
                           {
                               acc_code = setup.acc_code,
                               acc_balance = setup.acc_balance,
                               acc_class = setup.acc_class,
                               acc_class_option = setup.acc_class_option,
                               acc_class_option_type = setup.acc_class_option_type,
                               acc_inactive = setup.acc_inactive,
                               acc_reconciliation = setup.acc_reconciliation,
                               acc_type = setup.acc_type,
                               acc_bank_code = setup.acc_bank_code,
                               primaryKey = setup.acc_code
                           }).ToList();
                return res;
            }
            return new List<AccCodeUIMapper>();
        }

        public List<AccCodeUIMapper> GetAllAccCodeList()
        {
            LinkAccountSetupDA da = new LinkAccountSetupDA();
            var lsMapper = da.GetAllAccCodeList();
            if (lsMapper != null)
            {
                var res = (from setup in lsMapper
                           select new AccCodeUIMapper
                           {
                               acc_code = setup.acc_code,
                               acc_balance = setup.acc_balance,
                               acc_class = setup.acc_class,
                               acc_class_option = setup.acc_class_option,
                               acc_class_option_type = setup.acc_class_option_type,
                               acc_inactive = setup.acc_inactive,
                               acc_reconciliation = setup.acc_reconciliation,
                               acc_type = setup.acc_type,
                               acc_bank_code = setup.acc_bank_code,
                               primaryKey = setup.acc_code
                           }).ToList();
                return res;
            }
            return new List<AccCodeUIMapper>();
        }

        public void SetAccGLSetup(AccGLTypeSetupUIMapper UImapper)
        {
            LinkAccountSetupDA da = new LinkAccountSetupDA();
            AccGLTypeSetupMapper mapper = new AccGLTypeSetupMapper();
            mapper.gl_setup_type = UImapper.gl_setup_type;
            mapper.gl_acc_code = UImapper.gl_acc_code;
            mapper.gl_principal_bank = UImapper.gl_principal_bank;
            mapper.gl_freight = UImapper.gl_freight;
            mapper.gl_discount = UImapper.gl_discount;
            da.SetVendorPurchasesDetails(mapper);  
        }

        public List<AccCodeUIMapper> GetReceivablesAccCodeList()
        {
            LinkAccountSetupDA da = new LinkAccountSetupDA();
            var lsMapper = da.GetReceivablesAccCodeList();
            if (lsMapper != null)
            {
                var res = (from setup in lsMapper
                           select new AccCodeUIMapper
                           {
                               acc_code = setup.acc_code,
                               acc_balance = setup.acc_balance,
                               acc_class = setup.acc_class,
                               acc_class_option = setup.acc_class_option,
                               acc_class_option_type = setup.acc_class_option_type,
                               acc_inactive = setup.acc_inactive,
                               acc_reconciliation = setup.acc_reconciliation,
                               acc_type = setup.acc_type,
                               acc_bank_code = setup.acc_bank_code,
                               primaryKey = setup.acc_code
                           }).ToList();
                return res;
            }
            return new List<AccCodeUIMapper>();
        }
    }
}
