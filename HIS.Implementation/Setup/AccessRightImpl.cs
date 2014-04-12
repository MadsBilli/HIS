using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.UI.Mapper.Setup;
using HIS.Data.Mapper.SetUp;
using HIS.DataAccess.SetUp;
using HIS.Common;

namespace HIS.Implementation.Setup
{
    public class AccessRightImpl
    {
        public DataSet GetEmpTypeForddl()
        {
            AccessRightsDA accessRightDA = new AccessRightsDA();
            return accessRightDA.GetEmpTypeForddl();
        }

        public void SaveAccessRightsDetails(AccessRightsUIMapper accessRightsUI)
        {
            AccessRightsDA accessRightDA = new AccessRightsDA();
            AccessRightsMapper accessRights = new AccessRightsMapper
            {
                fm_upc		    = accessRightsUI.fm_upc,
                fm_inventory    = accessRightsUI.fm_inventory,
                fm_pos          = accessRightsUI.fm_pos,
                fm_acc          = accessRightsUI.fm_acc,
                fm_misc_gl      = accessRightsUI.fm_misc_gl,
                fm_po           = accessRightsUI.fm_po,
                fm_ven          = accessRightsUI.fm_ven,
                fm_pur_inv      = accessRightsUI.fm_pur_inv,
                fm_pay          = accessRightsUI.fm_pay,
                fm_cust         = accessRightsUI.fm_cust,
                fm_inv          = accessRightsUI.fm_inv,
                fm_rec          = accessRightsUI.fm_rec,
                fm_aging        = accessRightsUI.fm_aging,
                fm_rpt          = accessRightsUI.fm_rpt,
                fm_payroll      = accessRightsUI.fm_payroll,
                fm_emp_admin    = accessRightsUI.fm_emp_admin,
                fm_setup        = accessRightsUI.fm_setup,
                fm_commission   = accessRightsUI.fm_commission,
                fm_wo           = accessRightsUI.fm_wo,
                emp_type        = accessRightsUI.emp_type
            };
            accessRightDA.SaveAccessRightsDetails(accessRights);
        }

        public List<AccessRightsUIMapper> GetAccessRightDetails(AccessRightsUIMapper accessRightsUI)
        {
            AccessRightsDA accessRightDA = new AccessRightsDA();
             AccessRightsMapper accessRights = new AccessRightsMapper
            {
                emp_type        = accessRightsUI.emp_type
            };
             var ress = accessRightDA.GetAccessRightDetails(accessRights);
             var accessrightsUI = (from res in ress
                select new AccessRightsUIMapper
             {
                 fm_upc = res.fm_upc,
                 fm_inventory = res.fm_inventory,
                 fm_pos = res.fm_pos,
                 fm_acc = res.fm_acc,
                 fm_misc_gl = res.fm_misc_gl,
                 fm_po = res.fm_po,
                 fm_ven = res.fm_ven,
                 fm_pur_inv = res.fm_pur_inv,
                 fm_pay = res.fm_pay,
                 fm_cust = res.fm_cust,
                 fm_inv = res.fm_inv,
                 fm_rec = res.fm_rec,
                 fm_aging = res.fm_aging,
                 fm_rpt = res.fm_rpt,
                 fm_payroll = res.fm_payroll,
                 fm_emp_admin = res.fm_emp_admin,
                 fm_setup = res.fm_setup,
                 fm_commission = res.fm_commission,
                 fm_wo = res.fm_wo,
                 emp_type = res.emp_type
             }).ToList();
             return accessrightsUI;
        }

        public string CheckUserAccessRights(string accessRights, int Emp_Type, string emp_logName, out bool AllowAccess, out bool UserTerminated)
        {
            AccessRightsDA access = new AccessRightsDA();
            return access.CheckUserAccessRights(accessRights, Emp_Type, emp_logName, out   AllowAccess, out   UserTerminated);
        }

        public AccessRightsUIMapper GetUserAccessRights(int Emp_Type, string emp_logName, out bool UserTerminated)
        {
            AccessRightsDA access = new AccessRightsDA();
            var res = access.GetUserAccessRights(Emp_Type, emp_logName, out   UserTerminated);
            AccessRightsUIMapper accessMapperUI = new AccessRightsUIMapper
            {
                fm_upc = res.fm_upc,
                fm_inventory = res.fm_inventory,
                fm_pos = res.fm_pos,
                fm_acc = res.fm_acc,
                fm_misc_gl = res.fm_misc_gl,
                fm_po = res.fm_po,
                fm_ven = res.fm_ven,
                fm_pur_inv = res.fm_pur_inv,
                fm_pay = res.fm_pay,
                fm_cust = res.fm_cust,
                fm_inv = res.fm_inv,
                fm_rec = res.fm_rec,
                fm_aging = res.fm_aging,
                fm_rpt = res.fm_rpt,
                fm_payroll = res.fm_payroll,
                fm_emp_admin = res.fm_emp_admin,
                fm_setup = res.fm_setup,
                fm_commission = res.fm_commission,
                fm_wo = res.fm_wo,
                emp_type = res.emp_type
            };
            return accessMapperUI;
        }
    }
}
