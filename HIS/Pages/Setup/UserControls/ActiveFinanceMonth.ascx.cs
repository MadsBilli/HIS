using HIS.UI.Assembler.Setup;
using HIS.UI.Mapper.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HIS.Pages.Setup.UserControls
{
    public partial class ActiveFinanceMonth : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetActiveFinanceYearInfo();
            btnSave.Click += new EventHandler(imgbtnSave_Click);
        }

        private void GetActiveFinanceYearInfo()
        {
            FinYearSetupUIMapper mapper = new ActiveFinMonthSetupAssembler().GetActiveFinanceYearInfo();
            ltlYear.Text = mapper.fin_yrs.ToString();

            FinMonthSetupUIMapper monthMapper = new ActiveFinMonthSetupAssembler().GetActiveFinanceMonthInfo();
            if (!monthMapper.fin_mth_sdate.HasValue)
                ddlMonth.SelectedIndex = 0;
            else
                ddlMonth.SelectedIndex = monthMapper.fin_mth_LN;
        }

        protected void imgbtnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ltlYear.Text))
            {
                if (ddlMonth.SelectedIndex != 0)
                {
                    DateTime Sdate = new DateTime(int.Parse(ltlYear.Text), int.Parse(ddlMonth.SelectedValue), int.Parse("01"));
                    FinMonthSetupUIMapper monthMapper = new ActiveFinMonthSetupAssembler().GetActiveFinanceMonthInfoBySDate(Sdate);
                    if (monthMapper.fin_mth_sdate.HasValue && monthMapper.fin_mth_close == true)
                    {
                        ucValidationMessage.ErrorMessage = "The selected month have been closed!";
                        ucValidationMessage.IsSuccess = false;
                        ucValidationMessage.Show();
                        //ScriptManager.RegisterClientScriptBlock(btnSave, typeof(System.Web.UI.WebControls.Button), "Script1", "alert(\"The selected month have been closed!\");", true);
                    }
                    else if (!monthMapper.fin_mth_sdate.HasValue)
                    {
                        ucValidationMessage.ErrorMessage = "Choose a Valid Mth!";
                        ucValidationMessage.IsSuccess = false;
                        ucValidationMessage.Show();
                        //ScriptManager.RegisterClientScriptBlock(btnSave, typeof(System.Web.UI.WebControls.Button), "Script1", "alert(\"Choose a Valid Mth!\");", true);
                    }
                    else
                    {
                        new ActiveFinMonthSetupAssembler().SetActiveFinanceMonthInfoBySDate(Sdate);
                        ucValidationMessage.SuccessMessage = "Active Fin Month Saved Successfully!";
                        ucValidationMessage.IsSuccess = true;
                        ucValidationMessage.Show();
                    }
                }
                else
                {
                    ucValidationMessage.ErrorMessage = "Choose a Valid Mth!";
                    ucValidationMessage.IsSuccess = false;
                    ucValidationMessage.Show();

                    //ScriptManager.RegisterClientScriptBlock(btnSave, typeof(System.Web.UI.WebControls.Button), "Script1", "alert(\"\");", true);
                }
            }
            else
            {
                ucValidationMessage.ErrorMessage = "Invalid Year!";
                ucValidationMessage.IsSuccess = false;
                ucValidationMessage.Show();
                //ScriptManager.RegisterClientScriptBlock(btnSave, typeof(System.Web.UI.WebControls.Button), "Script1", "alert(\"Invalid Year!\");", true);
            }
        }
    }
}