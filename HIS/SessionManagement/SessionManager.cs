using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HIS.UI.Mapper.EmployeeAdmin;

namespace HIS.UI.SessionManagement
{
    public class SessionManager
    {
        /// <summary>
        /// store logged in user in session
        /// </summary>
        /// <param name="Users"></param>
        public void StoreSessionUser(EmployeeAdminUIMapper Users)
        {
            HttpContext.Current.Session[SessionConstant.LOGGEDINUSER] = Users;
        }

        public void StoreSessionUserName(string Users)
        {
            HttpContext.Current.Session[SessionConstant.LOGGEDINUSER] = Users;
        }

        public bool SessionUserExist()
        {
            return !(HttpContext.Current.Session[SessionConstant.LOGGEDINUSER] == null);
        }

        public EmployeeAdminUIMapper GetSessionUser()
        { 
            return (EmployeeAdminUIMapper)HttpContext.Current.Session[SessionConstant.LOGGEDINUSER];
        }

        public string GetSessionUserName()
        {
            return  HttpContext.Current.Session[SessionConstant.LOGGEDINUSER].ToString();
        }

        public void StoreLogErrorMessage(string error)
        {
            HttpContext.Current.Session[SessionConstant.LOGERRORMESSAGE] = error;
        }
        
        public bool LogErrorMessageExist()
        {
            return !(HttpContext.Current.Session[SessionConstant.LOGERRORMESSAGE] == null);
        }

        public string GetLogErrorMessage( )
        {
            return Convert.ToString(HttpContext.Current.Session[SessionConstant.LOGERRORMESSAGE]);
        }

        public void StoreErrorMessage(string error)
        {
            HttpContext.Current.Session[SessionConstant.ERRORMESSAGE] = error;
        }

        public bool ErrorMessageExist()
        {
            return !(HttpContext.Current.Session[SessionConstant.ERRORMESSAGE] == null);
        }

        public string GetErrorMessage( )
        {
             return Convert.ToString(HttpContext.Current.Session[SessionConstant.ERRORMESSAGE]);
        }
    }
}