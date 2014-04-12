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
    public partial class SystemSettingSetup : System.Web.UI.Page
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
            var html = @"<fieldset id='fld_{0}'>
                            <table id='tbl_{0}' style='width: 100%'>
                                <tr>
                                    <td style='vertical-align: top; padding-top: 3px; width: 130px'><b>Description</b> &nbsp;
                                        <label style='border: 1px solid gray; padding: 0px 10px 0px 10px' id='lblLN_{0}'>{1}</label></td>
                                    <td style='width: 300px;'>                                      
                                            <textarea cols='50' rows='3' style='font-weight: bolder; background-color: lightgray;' id='txtDesc_{0}'>{2}</textarea>
<div style='display:none;' id='divDesc_{0}'>{2}</div>
                                    </td>
                                    <td style='vertical-align: top; padding-left: 5px'>
                                        <b>Setup Group</b><br />
                                        <input type='text' style='border: 0; padding: 5px; background-color: lightgray; color: black; width: 100px' id='txtGrp_{0}' value='{3}'></input>
                                    </td>
                                </tr>
                                <tr>
                                    <td style='vertical-align: top; padding-top: 3px; width: 120px'><b>System Initialise Value</b>
                                    <td style='width: 300px;'>
                                        <textarea cols='50' rows='3' id='txtVal_{0}'>{4}</textarea>
                                        <div style='display:none;' id='divVal_{0}'>{4}</div>
                                    </td>
                                    <td class='hide' id='txtPrimaryKey_{0}'>{5}</td>
                                </tr>
                            </table>
                        </fieldset>";
            var results = new SystemSetupAssembler().GetSystemSetupList();
            var formatedText = string.Empty;
            int count = 1;
            foreach (var result in results)
            {
                formatedText += string.Format(html, count++, result.setup_LN, result.setup_description, result.setup_grp, result.setup_value, result.setup_txt);
            }
            ltlPanel.Text = formatedText;
        }

        protected void imgbtnSave_Click(object sender, EventArgs e)
        {
            BindDataGrid();
        }

        [WebMethod]
        public static string SaveDetails(SystemSetupUIMapper[] uiMapperDetails)
        {
            foreach (var uiMapper in uiMapperDetails)
            {
                new SystemSetupAssembler().UpdateSystemSetupDetails(uiMapper);
            }
            return "true";
        }
    }
}
////                                            