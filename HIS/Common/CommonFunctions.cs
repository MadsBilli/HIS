using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Web.UI.WebControls;
using HIS.Common;
using HIS.UI.Assembler.Setup;
using HIS.UI.Mapper.Setup;
using HIS.UI.SessionManagement;

namespace HIS.UI.Common
{
    public static class CommonFunctions
    {
        public static void CheckUserAccessRights(AccessRights accessRights)
        {
            SessionManager session = new  SessionManager();
            var user = session.GetSessionUser();
            bool AllowAccess = false;
            bool UserTerminated = false;
            new AccessRightAssembler().CheckUserAccessRights(accessRights.ToString(), user.emp_type, user.emp_logname, out AllowAccess, out UserTerminated);
            
        }

        public static AccessRightsUIMapper GetUserAccessRights()
        {
            SessionManager session = new SessionManager();
            if (session.SessionUserExist())
            {
                var user = session.GetSessionUser();
                bool UserTerminated = false;
                AccessRightsUIMapper res = new AccessRightAssembler().GetUserAccessRights(user.emp_type, user.emp_logname, out UserTerminated);
                if (!UserTerminated)
                {
                    return res;
                }
                else
                    return null;
            }
            return null;

        }

        public static void InsertEmptyValueToddl(DropDownList ddl)
        {
            ddl.Items.Insert(0, new ListItem("Select Value", "0"));
            ddl.AppendDataBoundItems = true;
        }

        public static void BindEnumToddl<T>(DropDownList ddl, bool useDescription, bool insertEmptyValue = true) where T : struct
        {
            if (!useDescription)
                ddl.DataSource = Enum.GetNames(typeof(T)).Select(o => new { Text = o, Value = o });
            else
            {
                var r = Enum.GetNames(typeof(T)).Select(o => new { Text = HIS.Common.EnumHelper.GetEnumDescription(((Enum)Enum.Parse(typeof(T), o.ToString()))), Value = o });
                ddl.DataSource = Enum.GetNames(typeof(T)).Select(o => new { Text = HIS.Common.EnumHelper.GetEnumDescription(((Enum)Enum.Parse(typeof(T), o.ToString()))), Value = o });
            }
            ddl.DataTextField = "Text";
            ddl.DataValueField = "Value";
            ddl.DataBind();
            if (insertEmptyValue) 
            CommonFunctions.InsertEmptyValueToddl(ddl);
        }

        public static Int16 ConvertToInt16(string val)
        {
            Int16 res = 0;
            if (string.IsNullOrEmpty(val))
                return 0;
            else
            {
                Int16.TryParse(val, out res);
                return res;
            }
        }

        public static int ConvertToInt(string val)
        {
            int res = 0;
            if (string.IsNullOrEmpty(val))
                return 0;
            else
            {
                int.TryParse(val, out res);
                return res;
            }
        }

        public static decimal ConvertToDecimal(string val)
        {
            decimal res = 0;
            if (string.IsNullOrEmpty(val))
                return 0;
            else
            {
                decimal.TryParse(val, out res);
                return res;
            }
        }

        public static double ConvertToDouble(string val)
        {
            double res = 0;
            if (string.IsNullOrEmpty(val))
                return 0;
            else
            {
                double.TryParse(val, out res);
                return res;
            }
        }

        public static Single ConvertToSingle(string val)
        {
            Single res = 0;
            if (string.IsNullOrEmpty(val))
                return 0;
            else
            {
                Single.TryParse(val, out res);
                return res;
            }
        }

        public static string GetDate(string val)
        {
            if (string.IsNullOrEmpty(val))
                return string.Empty;
            else
            {
                if (Convert.ToDateTime(val) == DateTime.MinValue)
                {
                    return string.Empty;
                }
            }
            return val;
        }
        public static DateTime ParseDate(string DateString)
        {
            if (!string.IsNullOrEmpty(DateString))
            {
                string[] DateParts = new string[] { };
                if (DateString.Contains("-"))
                {
                    DateParts = DateString.Split('-');
                }
                else if (DateString.Contains("/"))
                {
                    DateParts = DateString.Split('/');
                }
                if (DateParts.Length >= 3)
                {
                    DateTime resultDate = new DateTime(Convert.ToInt32(DateParts[2]), Convert.ToInt32(DateParts[1]), Convert.ToInt32(DateParts[0]));
                    return resultDate;
                }
            }
            return DateTime.MinValue;
        }

        public static string ParseDate(DateTime dt)
        {
            if (dt != null && dt != DateTime.MinValue && dt.ToString("dd/MM/yyyy") != "01/01/1900")
            {
                int day, month, year;
                day = dt.Day;
                month = dt.Month;
                year = dt.Year;

                string formatedDate = string.Format("{0}/{1}/{2}", day.ToString().PadLeft(2, '0'), month.ToString().PadLeft(2, '0'), year.ToString());

                return string.IsNullOrEmpty(formatedDate) ? string.Empty : formatedDate;
            }
            return string.Empty;
        }

        /// <summary>
        /// Retrieve current user
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentUser()
        {
            string userID = HttpContext.Current.User.Identity.Name;
            string[] userArray = userID.Split(new char[] { '\\' });
            return userArray[1];
        }


        /// <summary>
        /// Gets the QueryString Values
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetQueryStringParameter()
        {
            Dictionary<string, string> queryString = new Dictionary<string, string>();

            HttpRequest request = HttpContext.Current.Request;
            if (request.QueryString != null && request.QueryString.Count > 0 && request.QueryString["param"] != null && !string.IsNullOrEmpty(request.QueryString["param"].ToString()))
            {
                queryString = QueryStringHelper.DecryptQueryString(request.QueryString["param"].ToString());
            }

            return queryString;
        }

        /// <summary>
        /// Builds the QueryString
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string BuildEncryptedQueryString(Dictionary<string, string> parameters)
        {
            if (parameters != null && parameters.Count > 0)
            {
                return string.Format("?param={0}", QueryStringHelper.EncryptQueryString(parameters));
            }

            return string.Empty;
        }

        

        public static Dictionary<string, string> GetQueryString()
        {
            Dictionary<string, string> queryString = new Dictionary<string, string>();
            if (HttpContext.Current.Request.QueryString["param"] != null && !string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["param"].ToString()))
            {
                //Decrypt query string
                queryString = QueryStringHelper.DecryptQueryString(HttpContext.Current.Request.QueryString["param"].ToString());
            }
            else
            {
                foreach (string key in HttpContext.Current.Request.QueryString.Keys)
                {
                    if (key != null)
                        queryString.Add(key, HttpContext.Current.Request[key].ToString());
                }
            }

            return queryString;
        }

        public static Dictionary<string, string> ConvertXMLToDictionaryList(string xmlData, string xPath)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlData);
            XmlNodeList idNodes = doc.SelectNodes(xPath);
            foreach (XmlNode node in idNodes)
                list.Add(node.InnerText, node.InnerText);

            return list;
        }

        public static List<string> ConvertXMLToList(string xmlData, string xPath)
        {
            List<string> list = new List<string>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlData);
            XmlNodeList idNodes = doc.SelectNodes(xPath);
            foreach (XmlNode node in idNodes)
                list.Add(node.InnerText);

            return list;
        }

        #region Gridview
        public static void SetGridViewPageIndex(GridView gridview, int pageIndex)
        {
            int currentPage = pageIndex;
            if (currentPage >= gridview.PageCount)
            {
                currentPage = gridview.PageCount;
            }
            else if (currentPage < 0)
            {
                currentPage = 0;
            }

            gridview.PageIndex = currentPage;
        }

        public static int GetGridPageSize()
        {
            if (System.Configuration.ConfigurationManager.AppSettings["NumberOfRecordsPerPage"] != null)
                return ConvertToInt(System.Configuration.ConfigurationManager.AppSettings["NumberOfRecordsPerPage"]);
            else
                return 20;
        }
        #endregion

        public static int ConvertInt(string strVal)
        {
            try
            {
                return Convert.ToInt32(strVal);
            }
            catch
            {
                return 0;
            }
        }
    }
}