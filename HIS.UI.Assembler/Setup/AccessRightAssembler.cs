using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.UI.Mapper.Setup;
using HIS.Implementation.Setup;
using HIS.Common;

namespace HIS.UI.Assembler.Setup
{
    public class AccessRightAssembler
    {
        public DataSet GetEmpTypeForddl()
        {
            AccessRightImpl accessRightImpl = new AccessRightImpl();
            return accessRightImpl.GetEmpTypeForddl();
        }

        public void SaveAccessRightsDetails(AccessRightsUIMapper accessRightsUI)
        {
            AccessRightImpl accessRightImpl = new AccessRightImpl();
            accessRightImpl.SaveAccessRightsDetails(accessRightsUI);
        }

        public AccessRightsUIMapper GetAccessRightDetails(AccessRightsUIMapper accessRightsUI)
        {
            AccessRightImpl accessRightImpl = new AccessRightImpl();
            var res = accessRightImpl.GetAccessRightDetails(accessRightsUI);
            return res.FirstOrDefault();
        }

        public string CheckUserAccessRights(string accessRights, int Emp_Type, string emp_logName, out bool AllowAccess, out bool UserTerminated)
        {
            AccessRightImpl access = new AccessRightImpl();
            return access.CheckUserAccessRights(accessRights, Emp_Type, emp_logName, out   AllowAccess, out   UserTerminated);
        }

        public AccessRightsUIMapper GetUserAccessRights(int Emp_Type, string emp_logName, out bool UserTerminated)
        {
            AccessRightImpl access = new AccessRightImpl();
            return access.GetUserAccessRights(Emp_Type, emp_logName, out   UserTerminated);
        }
    }
}
