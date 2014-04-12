using HIS.UI.Assembler.Setup;
using HIS.UI.Mapper.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIS.Pages.Setup
{
    public partial class RptPrintingSetup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindDataGrid();
            }
        }

        private void BindDataGrid()
        {
            var res = new RptPrintingSetupAssembler().GetRptPrintingSetupList();
            res.Add(new RptPrintingSetupUIMapper());
            gvList.DataSource = res;
            gvList.DataBind();
        }

        protected void imgbtnSave_Click(object sender, EventArgs e)
        {
            BindDataGrid();
        }

        public string ProcessData(object value)
        {
            return Convert.ToInt32(value) == 0 ? "" : value.ToString();
        }

        protected void DelItem(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton btn = sender as ImageButton;
                if (btn != null)
                {
                    string keyField = btn.CommandArgument.Trim();
                    new RptPrintingSetupAssembler().DeleteRptPrintingSetup(keyField);
                    BindDataGrid();
                }
            }
            catch (Exception ex)
            {
                string ErrorMessage = UI.ExceptionHandling.ExceptionMethodHandler.HandlesException(ex);
                ucValidationMessage.ErrorMessage = ErrorMessage;
                ucValidationMessage.Show();
            }
        }

        [WebMethod]
        public static string SaveDetails(RptPrintingSetupUIMapper[] uiMapperDetails)
        {
            foreach (var uiMapper in uiMapperDetails)
            {
                if (string.IsNullOrEmpty(uiMapper.rt_name)) continue;
                new RptPrintingSetupAssembler().InsertorUpdateRptPrintingSetupDetails(uiMapper);
            }
            return "true";
        }
    }
}