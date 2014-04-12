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
    public partial class BUNameSetup : System.Web.UI.Page
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
            var res = new BUNameSetupAssembler().GetBUNameSetupList();
            res.Add(new BUNameSetupUIMapper());
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
                    new BUNameSetupAssembler().DeleteBUNameSetup(keyField);
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
        public static string SaveDetails(BUNameSetupUIMapper[] uiMapperDetails)
        {
            foreach (var uiMapper in uiMapperDetails)
            {
                if ((uiMapper.bu_id.ToString() == string.Empty && uiMapper.bu_desc.Trim() == string.Empty) || (uiMapper.bu_id == 0 && uiMapper.bu_desc.Trim() == string.Empty)) continue;
                new BUNameSetupAssembler().InsertorUpdateBUNameSetupDetails(uiMapper);
            }
            return "true";
        }
    }
}