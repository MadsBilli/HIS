using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Xml;
using System.Data.SqlClient;
using System.Text;
using HIS.Common;

namespace HIS.UI.ExceptionHandling
{
    public class ExceptionMethodHandler
    {
        public static string HandlesException(Exception ex)
        {
            if (ex is ExceptionHandler)
            { 
                    string error = GetUIValidationMessages(ex as ExceptionHandler);
                    return string.IsNullOrEmpty(error) ? ex.Message : error; 
            }
            else if (ex is SqlException)
            {
                string error = GetBLValidationMessages(ex.Message);
                return string.IsNullOrEmpty(error) ? ex.Message : error; 
            }
            else
            {
                LogApplicationException(ex, false);
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the UI Validation Message
        /// </summary>
        /// <param name="ErrorCode"></param>
        /// <returns></returns>
        public static string GetUIValidationMessages(ExceptionHandler ex)
        {
            string ErrorMessage = string.Empty;
            string xmlFileName = ConfigurationManager.AppSettings[Common.Constants.UIVALIDATIONMESSAGES];
            foreach (var msg in (ex as ExceptionHandler).ErrorMessages)
            {
                ErrorMessage = ErrorMessage + " " + GetValidationMessages(msg.Message, xmlFileName);
            }
            
            var error = string.Join( "<br/>" , ((ex as ExceptionHandler).ErrorMessages).Select(i => i.Message));

            return ErrorMessage.Trim().Equals(string.Empty) ? error : ErrorMessage.Trim();
        }

        public static string GetUIValidationMessages(string ErrorCode)
        {
            string ErrorMessage = string.Empty;
            string xmlFileName = ConfigurationManager.AppSettings[Common.Constants.UIVALIDATIONMESSAGES];
            ErrorMessage = GetValidationMessages(ErrorCode, xmlFileName);
            return ErrorMessage;
        }

        public static string GetBLValidationMessages(string ErrorCode)
        {
            string ErrorMessage = string.Empty;
            string xmlFileName = ConfigurationManager.AppSettings[Common.Constants.BLVALIDATIONMESSAGES];
            ErrorMessage = GetValidationMessages(ErrorCode, xmlFileName);
            return ErrorMessage;
        }

        /// <summary>
        /// Gets the Custom BL Validation Message
        /// </summary>
        /// <param name="ErrorCode"></param>
        /// <returns></returns>
        public static string GetValidationMessages(string errorCode, string fileName)
        {
            if (errorCode.Equals("") || errorCode.Equals(DBNull.Value))
                return "Application Error. Error Code is empty/null"; 
            
            char[] deLimiter = new char[] { '|' };

            string ErrorMessage = string.Empty;
            //Convert errorCode to List using the delimiter
            List<string> codeNValue = new List<string>(errorCode.Split(deLimiter, StringSplitOptions.None));

            //If error code has a corresponding message, get the message
            if (codeNValue.Count > 0)
            {
                string xmlFileName = fileName;
                XmlDocument xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.Load(HttpContext.Current.Server.MapPath(xmlFileName));
                XmlNodeList NodeList = xmlDoc.SelectNodes(Common.Constants.ERRORNODE);
                for (int i = 0; i < NodeList.Count; i++)
                {
                    if (codeNValue[0].Trim() == NodeList.Item(i).SelectSingleNode(Common.Constants.ERRORIDNODE).InnerText)
                    {
                        ErrorMessage = NodeList.Item(i).SelectSingleNode(Common.Constants.ERRORMESSAGENODE).InnerText;
                        break;
                    }
                }

            }
            if (codeNValue.Count <= 1)
                return ErrorMessage;
            else
            {
                //Remove the first value which is the error code
                codeNValue.RemoveAt(0);

                //Pass the list without the error code to replace the place holders with the corresponding values
                try
                {
                    ErrorMessage = String.Format(ErrorMessage, codeNValue.ToArray());
                }
                catch (System.FormatException ex)
                {
                    throw new Exception("Replacement values and place holders' count do not match", ex);
                }
                return ErrorMessage;

            }
        }

        private static void LogApplicationException(Exception ex, bool isPopup)
        {  
            StringBuilder messages = new StringBuilder();

            //Store message in Session
            UI.SessionManagement.SessionManager session = new UI.SessionManagement.SessionManager();
            string errorStackTrace = ex.StackTrace;
            session.StoreLogErrorMessage(errorStackTrace);

            // Message Store Mesage
            string errorMessages = ex.Message;
            session.StoreErrorMessage(errorMessages);

            messages.Append(ex.Message);
            messages.Append("\n");
         

            string errorPage = "~/Error.aspx";
            
            HttpContext.Current.Response.Redirect(errorPage, true);
        }
    }
}