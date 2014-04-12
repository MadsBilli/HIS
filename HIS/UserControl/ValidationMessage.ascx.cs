using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace HIS.UserControl
{
    public partial class ValidationMessage : System.Web.UI.UserControl
    {
        #region Properties
        private bool _display_summary_ = false;

        private bool _message_type_ = false;

        private List<string> _validation_error_list_;

        public bool IsSuccess
        {
            get { return _message_type_; }
            set { _message_type_ = value; }
        }

        public override bool Visible
        {
            get { return _display_summary_; }
            set { _display_summary_ = value; }
        }

        public List<string> ValidationErrors
        {
            get { return (_validation_error_list_ as List<string>); }
            set { _validation_error_list_ = (value as List<string>); }
        }

        public string SuccessMessage
        {
            get { return this.ltrSuccessMessage.Text; }
            set { this.ltrSuccessMessage.Text = value.Trim(); }
        }

        public string Information
        {
            get { return this.ltrInformation.Text; }
            set { this.ltrInformation.Text = value.Trim(); }
        }

        public string ErrorMessage
        {
            get { return this.ltrErrorMessage.Text; }
            set { this.ltrErrorMessage.Text = value.Trim(); }
        }

        private string ErrorList
        {
            get { return this.ltrErrorList.Text; }
            set { this.ltrErrorList.Text = value.Trim(); }
        }
        #endregion

        #region EventArgs Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            this.EnableViewState = false;
            this.tblMsgInfo.Visible = this.Visible;
            //this.Visible = false;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Displays the Status Messages
        /// </summary>
        public void Show()
        {
            tblMsgInfo.Visible = this.Visible = true;
            trError.Visible = false;
            trSuccess.Visible = this.IsSuccess;
            trInfo.Visible = !string.IsNullOrEmpty(this.Information);
            trErrorList.Visible = false;

            if (string.IsNullOrEmpty(this.SuccessMessage))
            {
                this.SuccessMessage = UI.ExceptionHandling.ExceptionMethodHandler.GetUIValidationMessages("COMMON01");
            }

            if (!this.IsSuccess)
            {
                if ((this.ValidationErrors != null) && (this.ValidationErrors.Count > 0))
                {
                    trErrorList.Visible = true;
                    this.ErrorList = this.FormatErrorList();
                }
                else if (!string.IsNullOrEmpty(this.ErrorMessage))
                {
                    trError.Visible = true;
                    this.ErrorMessage = this.ErrorMessage;
                }
                else
                {
                    trError.Visible = true;
                    this.ErrorMessage = UI.ExceptionHandling.ExceptionMethodHandler.GetUIValidationMessages("COMMON02");
                }
            }
        }
        #endregion

        #region private Functions
        /// <summary>
        /// Generates a [Bulleted List] of the [ErrorMessages] supplied from the caller page
        /// </summary>
        /// <returns>Formated String</returns>
        private string FormatErrorList()
        {
            StringBuilder sbErrorList = new StringBuilder();
            sbErrorList.Append("<ul id=\"ErrorList1\">");
            foreach (string errorMsg in this.ValidationErrors)
                sbErrorList.Append(string.Format("<li>{0}</li>", errorMsg.Trim()));
            sbErrorList.Append("</ul>");
            return sbErrorList.ToString().Trim();
        }
        #endregion
    }
}