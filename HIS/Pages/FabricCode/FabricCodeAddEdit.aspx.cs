using HIS.UI.Assembler;
using HIS.UI.Mapper.FabricCode;
using HIS.UI.SessionManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIS.Pages.FabricCode
{
    public partial class FabricCodeAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRdbPriceOption();
                BindDdlFabricType();
                BindDataGrid();
            }
        }

        private void BindRdbPriceOption()
        {
            rdbPriceOption.Items.Add(new ListItem { Text = "Supply", Value = "1", Selected = true });
            rdbPriceOption.Items.Add(new ListItem { Text = "Supply & Installation", Value = "2" });
        }

        private void BindDdlFabricType()
        {
            var res = new FabricCodeAssembler().GetFabricTypeList();
            ddlmaterial.DataSource = res;
            ddlmaterial.DataTextField = "fc_desc";
            ddlmaterial.DataValueField = "fc_type";
            ddlmaterial.DataBind();
        }

        protected void ddlmaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDataGrid();
        }

        private void BindHeaderAndFooter(int selectedFabricMaterial)
        {
            var res = new FabricCodeAssembler().GetSelectedFabricType(selectedFabricMaterial);
            txtHeader.Text = res.fc_header;
            txtEffectiveDate.Value = res.fc_eff_date;
            txtMinQty.Text = res.fc_minimum;
            txtFooter.Text = res.fc_footer;
            txtRemarks.Text = res.fc_rmk;
        }

        private void BindDataGrid()
        {
            int selectedFabricMaterial = int.Parse(ddlmaterial.SelectedValue);
            var res = new FabricCodeAssembler().GetFabricCodesList(selectedFabricMaterial);
            bool hasResult = true;
            if (res.Count == 0)
            {
                res.Add(new FabricCodeUIMapper());
                hasResult = false;
            }

            if (selectedFabricMaterial == 1)
            {
                if (!hasResult)
                    gvFabricCodeRollerList.Rows[0].Visible = false;

                ShowHideGrid(gvFabricCodeRollerList, gvFabricCodeList, res, hasResult);
            }
            else
            {
                if (selectedFabricMaterial == 3)
                    gvFabricCodeList.Columns[6].HeaderText = gvFabricCodeList.Columns[8].HeaderText = "Std Cord String (psf)";
                else
                    gvFabricCodeList.Columns[6].HeaderText = gvFabricCodeList.Columns[8].HeaderText = "Normal Cord String (psf)";

                ShowHideGrid(gvFabricCodeList, gvFabricCodeRollerList, res, hasResult);
            }

            BindHeaderAndFooter(selectedFabricMaterial);
        }

        protected void rdbPriceOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDataGrid();
        }

        private void ShowHideGrid(GridView show, GridView hide, List<FabricCodeUIMapper> res, bool hasResult)
        {
            show.DataSource = res;
            show.DataBind();
            hide.Visible = false;
            show.Visible = true;
            if (!hasResult)
                show.Rows[0].Visible = false;
        }

        protected void imgbtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                FabricTypeUIMapper fabrictype = new FabricTypeUIMapper
                       {
                           fc_type = int.Parse(ddlmaterial.SelectedValue),
                           fc_header = txtHeader.Text,
                           fc_eff_date = txtEffectiveDate.Value,
                           fc_minimum = txtMinQty.Text,
                           fc_footer = txtFooter.Text,
                           fc_rmk = txtRemarks.Text
                       };
                new FabricCodeAssembler().UpdateFabricTypeDetails(fabrictype);
                BindDataGrid();
            }
            catch (System.Threading.ThreadAbortException)
            {
                //Do nothing.
            }
            catch (Exception ex)
            {
                string ErrorMessage = UI.ExceptionHandling.ExceptionMethodHandler.HandlesException(ex);
                ucValidationMessage.ErrorMessage = ErrorMessage;
                ucValidationMessage.Show();
            }
        }

        protected void DelFabricCode(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton btn = sender as ImageButton;
                if (btn != null)
                {
                    string keyField = btn.CommandArgument.Trim();
                    new FabricCodeAssembler().DeleteFabricCode(keyField);
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
        public static string SaveFabricCode(FabricCodeUIMapper[] fabricCodeDetails)
        {
            foreach (var fabricCode in fabricCodeDetails)
            {
                if (fabricCode.fc_code.Trim() == string.Empty) continue;
                fabricCode.primaryKey = fabricCode.primaryKey.Replace("&nbsp;", "");
                new FabricCodeAssembler().InsertFabricCodeDetails(fabricCode);
            }
            return "true";
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {

        }
    }
}