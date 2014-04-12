using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HIS.UI.Assembler.Setup;
using HIS.UI.Common;

namespace HIS.Pages.Setup
{
    public partial class TermsSetup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDataGrid("Quote");
            }
        }

        private void BindDataGrid(string txtSelect)
        {
            var res = new tblTermsSetupAssembler().GetTermSetupDetails(txtSelect);
            if (res.Tables.Count > 0 && res.Tables[0] != null && res.Tables[0].Rows.Count > 0)
            {
                ddlTerms.DataSource = res.Tables[0].AsDataView();
                ddlTerms.DataValueField = "int_ID";
                ddlTerms.DataTextField = "txtDescription";
                ddlTerms.DataBind();
            }
            if (res.Tables.Count > 1 && res.Tables[1] != null && res.Tables[1].Rows.Count > 0)
            {
                gvTermsSetup.DataSource = res.Tables[1].AsDataView();
                gvTermsSetup.DataBind();
            }
        }
    }
}