using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIS.UserControl
{
    public partial class DateControl : System.Web.UI.UserControl
    {
        #region Properties
        public DateTime Value
        {
            get { return HIS.UI.Common.CommonFunctions.ParseDate(txtDate.Text); }
            set { txtDate.Text = HIS.UI.Common.CommonFunctions.ParseDate(value); }
        }

        public int Width
        {
            set { txtDate.Width = Unit.Pixel(value); }
        }

        public bool Enabled
        {
            get { return (imgCalender.Attributes["disabled"] == "true"); }
            set
            {
                if (value)
                {
                    txtDate.Enabled = true;
                    txtDate.Attributes.Add("readonly", "readonly");
                    imgCalender.Attributes.Remove("disabled");
                }
                else
                {
                    txtDate.Enabled = false;
                    imgCalender.Attributes.Add("disabled", "true");
                }
            }
        }

        public bool HasValue
        {
            get { return !(string.IsNullOrEmpty(txtDate.Text)); }
        }

        public short TabIndex
        {
            get
            {
                return txtDate.TabIndex;
            }
            set
            {
                txtDate.TabIndex = value;
            }
        }
        #endregion

        #region Event Handler
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //this.EnableViewState = false;
                txtDate.Attributes.Add("readonly", "readonly");
                imgCalender.Attributes.Add("onClick", string.Format("javascript:showCalendarControl('{0}');", txtDate.ClientID));
            }
        }
        #endregion

        #region Public Methods
        public void Clear()
        {
            txtDate.Text = string.Empty;
        }
        #endregion
    }
}