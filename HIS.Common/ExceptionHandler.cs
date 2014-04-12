using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Common
{
    public class ExceptionHandler : ApplicationException
    {
        #region -- Enumerators --

        public enum FaultCode
        {
            Success = 0,
            Exception = 1000,
            InsufficientAccess = 1001,
            SQLException = 1002,
        }



        public enum ErrorType
        {
            Alert,
            Confirm
        }

        public enum Status
        {
            Success,
            Error
        }

        public struct Messages
        {
            public String Message;
            public Status MessageStatus;
            public String AdditionalData;
        }

        //public const char AdditionalDataSplitter ='#';

        #endregion

        #region -- Declarations --

        private static string _UnexpectedExceptionTitle = "Unexpected Exception Detected";

        private List<Messages> _ErrorMessages = null;
        private ErrorType _ErrorMessagesType = ErrorType.Alert;
        private string _ErrorData = string.Empty;

        #endregion

        #region -- Public Properties --

        public List<Messages> ErrorMessages
        {
            get { return _ErrorMessages; }
        }

        public ErrorType ErrorMessageType
        {
            get { return _ErrorMessagesType; }
        }

        public string AdditionalData
        {
            get { return _ErrorData; }
        }

        #endregion

        #region -- Constructors --

        public ExceptionHandler()
            : base()
        {
            throw new ApplicationException();
        }

        public ExceptionHandler(string message)
        {
            List<string> messageList = new List<string>();
            messageList.Add(message);

            ValidateErrorMessage(messageList);
        }

        public ExceptionHandler(string message, Exception innerexception)
            : base(message, innerexception)
        {
            throw new ApplicationException(message, innerexception);
        }

        public ExceptionHandler(List<string> messageList)
        {
            ValidateErrorMessage(messageList);
        }

        #endregion

        #region  -- Public Methods --

        public static void UnHandledExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception ex = (Exception)args.ExceptionObject;
            List<string> errors = new List<string>();
            errors.Add(ex.Message);

            ExceptionHandler ex1 = new ExceptionHandler(errors);
        }

        public static void ValidateSuccessMessage(ref List<Messages> messageList)
        {
            List<Messages> nMessageList = new List<Messages>();
            foreach (Messages message in messageList)
            {
                char[] deLimiter = new char[] { '#' };

                //Convert errorCode to List using the delimiter
                string[] codeNValue = message.Message.Split(deLimiter, StringSplitOptions.None);

                //string sMessage = ErrorMessageHelper.GetErrorMessage(codeNValue[0]);
                string sMessage = codeNValue[0];

                if (codeNValue.Length > 1)
                    sMessage += codeNValue[1];

                Messages nMessage = new Messages();
                nMessage.Message = sMessage;
                nMessage.MessageStatus = message.MessageStatus;
                nMessage.AdditionalData = message.AdditionalData;

                nMessageList.Add(nMessage);
            }

            messageList = nMessageList;
        }

        private void ValidateErrorMessage(List<string> errorList)
        {
            if (errorList.Count <= 0)
                throw new Exception(_UnexpectedExceptionTitle);

            ErrorType eType = ErrorType.Alert;
            bool isAlert = false;
            List<Messages> errorMessages = new List<Messages>();
            foreach (string errorCode in errorList)
            {
                char[] deLimiter = new char[] { '#' };

                //Convert errorCode to List using the delimiter
                string[] codeNValue = errorCode.Split(deLimiter, StringSplitOptions.None);

                string errorMessage = codeNValue[0];
                string additionalData = string.Empty;

                if (codeNValue.Length > 1)
                {
                    if (codeNValue[1] == "C" && isAlert == false)
                        eType = ErrorType.Confirm;
                    else if (codeNValue[1] == "A")
                    {
                        eType = ErrorType.Alert;
                        isAlert = true;
                    }
                }

                Messages msgs = new Messages();
                msgs.Message = errorMessage;
                msgs.MessageStatus = Status.Error;
                //msgs.AdditionalData = additionalData;

                errorMessages.Add(msgs);
            }

            _ErrorMessagesType = eType;
            _ErrorMessages = errorMessages;
        }

        #endregion
    }
}
