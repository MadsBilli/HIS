using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using HIS.UI.Mapper.EmployeeAdmin;
using HIS.UI.Assembler.EmployeeAdmin;
using HIS.UI.SessionManagement;
using HIS.UI.Common;
using System.Web.Services;

namespace HIS.Pages.Employee
{
    public partial class EmployeeAdminAddEdit : System.Web.UI.Page
    {
        //confirmation before delete
//reset password
        //default 0s in payroll tab

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    BindDropDownList();
                    BindDataGrid();
                    InitialSetup();
                }
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

        private void InitialSetup()
        {
            ViewState["addnew"] = true;
            ViewState["update"] = false;
        }

        private void BindDropDownList()
        {

            var res = new EmployeeAdminAddEditAssembler().GetEmployeeScreenListValues();
            if (res.Tables.Count > 0 && res.Tables[0] != null && res.Tables[0].Rows.Count > 0)
            {
                //Unit
                ddlE_emp_bu.DataSource = res.Tables[0].AsDataView();
                ddlE_emp_bu.DataValueField = "bu_id";
                ddlE_emp_bu.DataTextField = "bu_desc";
                ddlE_emp_bu.DataBind();
                CommonFunctions.InsertEmptyValueToddl(ddlE_emp_bu);

                //search unit
                ddlSearch_emp_bu.DataSource = res.Tables[0].AsDataView();
                ddlSearch_emp_bu.DataValueField = "bu_id";
                ddlSearch_emp_bu.DataTextField = "bu_desc";
                ddlSearch_emp_bu.DataBind();
                CommonFunctions.InsertEmptyValueToddl(ddlSearch_emp_bu);
            }
            if (res.Tables.Count > 1 && res.Tables[1] != null && res.Tables[1].Rows.Count > 0)
            {
                //Employee Status
                ddlE_emp_status.DataSource = res.Tables[1].AsDataView();
                ddlE_emp_status.DataValueField = "emp_status_id";
                ddlE_emp_status.DataTextField = "emp_status_desc";
                ddlE_emp_status.DataBind();
                CommonFunctions.InsertEmptyValueToddl(ddlE_emp_status);
            }
            if (res.Tables.Count > 2 && res.Tables[2] != null && res.Tables[2].Rows.Count > 0)
            {
                //Welfare Group
                ddlE_emp_walfare.DataSource = res.Tables[2].AsDataView();
                ddlE_emp_walfare.DataValueField = "wf_grp_name";
                ddlE_emp_walfare.DataTextField = "wf_grp_name";
                ddlE_emp_walfare.DataBind();
                CommonFunctions.InsertEmptyValueToddl(ddlE_emp_walfare);
            }

            if (res.Tables.Count > 3 && res.Tables[3] != null && res.Tables[3].Rows.Count > 0)
            {
                //User Group
                ddlE_emp_type.DataSource = res.Tables[3].AsDataView();
                ddlE_emp_type.DataValueField = "emp_type";
                ddlE_emp_type.DataTextField = "emp_typedesc";
                ddlE_emp_type.DataBind();
                CommonFunctions.InsertEmptyValueToddl(ddlE_emp_type);
            }
            if (res.Tables.Count > 4 && res.Tables[4] != null && res.Tables[4].Rows.Count > 0)
            {
                //Donation Desc
                ddlhr_pay_donation_desc.DataSource = res.Tables[4].AsDataView();
                ddlhr_pay_donation_desc.DataValueField = "hr_donation_id";
                ddlhr_pay_donation_desc.DataTextField = "hr_donation_desc";
                ddlhr_pay_donation_desc.DataBind();
                CommonFunctions.InsertEmptyValueToddl(ddlhr_pay_donation_desc);
            }
             
        }
         
        private void BindDataGrid(bool hideLeft=false, string unit = "")
        {
            var res = new EmployeeAdminAddEditAssembler().GetEmployeeListForGrid();
            if (hideLeft)
                res = res.Where(i => !(i.emp_left)).Select(k => k).ToList();
            if(!string.IsNullOrEmpty(unit))
                res = res.Where(i => i.emp_bu.ToString() == unit).Select(k => k).ToList();
            gvEmployeeList.DataSource = res;
            gvEmployeeList.PageSize = CommonFunctions.GetGridPageSize();
            gvEmployeeList.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try{
            EmployeeAdminUIMapper empUIMapper = new EmployeeAdminUIMapper();
            empUIMapper.emp_bu                  = CommonFunctions.ConvertToInt16(ddlE_emp_bu.SelectedValue);
            empUIMapper.emp_id                  = txtE_emp_id.Text.Trim();
            empUIMapper.emp_name                = txtE_emp_name.Text.Trim();
            empUIMapper.emp_title               = txtE_emp_title.Text.Trim();
            empUIMapper.emp_status_id           = CommonFunctions.ConvertToInt(ddlE_emp_status.SelectedValue);
            empUIMapper.emp_wf_grp              = ddlE_emp_walfare.SelectedValue;
            empUIMapper.emp_directno            = txtE_emp_directno.Text.Trim();
            empUIMapper.emp_hp                  = txtE_emp_hp.Text.Trim();
            empUIMapper.emp_email               = txtE_emp_email.Text.Trim();
            empUIMapper.emp_type                = CommonFunctions.ConvertToInt( ddlE_emp_type.SelectedValue);
            empUIMapper.emp_date_join           = dtE_emp_date_join.Value;
            empUIMapper.emp_logname             = txtE_emp_logname.Text.Trim();
            empUIMapper.emp_left                = chkE_emp_left.Checked;
            if (chkE_emp_left.Checked)
                empUIMapper.emp_date_left       = dtE_emp_date_left.Value;
            else
                empUIMapper.emp_date_left       = DateTime.MinValue;
            empUIMapper.emp_r_add1              = txthr_emp_r_add1.Text.Trim();
            empUIMapper.emp_r_add2              = txthr_emp_r_add2.Text.Trim();
            empUIMapper.emp_r_add3              = txthr_emp_r_add3.Text.Trim();
            empUIMapper.emp_tel                 = txthr_emp_tel.Text.Trim();
            empUIMapper.emp_nok                 = txthr_emp_nok.Text.Trim();
            empUIMapper.emp_nok_relationship    = txthr_emp_nok_relationship.Text.Trim();
            empUIMapper.emp_health              = txthr_emp_health.Text.Trim();
            empUIMapper.emp_blood_grp           = txthr_emp_blood_grp.Text.Trim();
            empUIMapper.emp_medical_history     = txthr_emp_medical_history.Text.Trim();
            empUIMapper.emp_gender              = ddlhr_emp_gender.SelectedValue;
            empUIMapper.emp_marital_status      = txthr_emp_marital_status.Text.Trim();
            empUIMapper.emp_passport_ic         = txthr_emp_passport_ic.Text.Trim();

            empUIMapper.emp_passport_ic_expiry  = dthr_emp_passport_ic_expiry.Value;

            empUIMapper.emp_dob                 = dthr_emp_dob.Value;

            empUIMapper.emp_pob                 = dthr_emp_pob.Value.ToString();
            empUIMapper.emp_bank                = txthr_emp_bank.Text.Trim();
            empUIMapper.emp_bank_acc            = txthr_emp_bank_acc.Text.Trim();
            empUIMapper.emp_bank_branch         = txthr_emp_bank_branch.Text.Trim();
            empUIMapper.emp_religion            = txthr_emp_religion.Text.Trim();
            empUIMapper.emp_rmk                 = txtE_emp_rmk.Text.Trim();
            empUIMapper.pay_regular             = CommonFunctions.ConvertToDecimal(txthr_pay_regular.Text.Trim());
            empUIMapper.pay_fixed_allowance     = CommonFunctions.ConvertToDecimal(txthr_pay_fixed_allowance.Text.Trim());
            empUIMapper.pay_SDL                 = CommonFunctions.ConvertToDecimal(txthr_pay_SDL.Text.Trim());
            empUIMapper.pay_donation            = CommonFunctions.ConvertToDecimal(txthr_pay_donation.Text.Trim());
            empUIMapper.pay_cpf_emp             = CommonFunctions.ConvertToDecimal(txthr_pay_cpf_emp.Text.Trim());
            empUIMapper.pay_cpf_emp_amt         = CommonFunctions.ConvertToDecimal(txthr_pay_cpf_emp_amt.Text.Trim());
            empUIMapper.pay_cpf_company         = CommonFunctions.ConvertToDecimal(txthr_pay_cpf_company.Text.Trim());
            empUIMapper.pay_cpf_company_amt     = CommonFunctions.ConvertToDecimal(txthr_pay_cpf_company_amt.Text.Trim());
            empUIMapper.pay_donation_desc       = CommonFunctions.ConvertToInt16(ddlhr_pay_donation_desc.SelectedValue);
            
            if(Convert.ToBoolean(ViewState["addnew"]))
                empUIMapper.emp_operation = Common.Operation.AddNew;
            else
                empUIMapper.emp_operation = Common.Operation.Update;
            new EmployeeAdminAddEditAssembler().InsertEmployeeAdminDetails(empUIMapper);
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

        protected void gvEmployeeListGridRowDataBoundEneventHandler(object sender, GridViewRowEventArgs e)
        {
            try
            {
                GridViewRow row = e.Row;
                if (row != null)
                {
                    //if (row.RowType == DataControlRowType.DataRow || row.RowType == DataControlRowType.Header)
                    //{
                    //    if (row.RowType == DataControlRowType.Header)
                    //        e.Row.Cells[3].Text = chkShowInactiveColumn.Checked ? "Inactive" : "";
                    //    e.Row.Cells[4].Visible = chkShowHideGridColumn.Checked;
                    //    e.Row.Cells[5].Visible = chkShowHideGridColumn.Checked;

                    //}
                    //if (row.RowType == DataControlRowType.DataRow)
                    //{
                    //    CustVendorUIMapper cust = row.DataItem as CustVendorUIMapper;
                    //    if (cust != null)
                    //    {
                    //        CheckBox chkInactive = row.FindControl("chkInactive") as CheckBox;
                    //        if (cust.cust_inactive)
                    //            chkInactive.Checked = true;
                    //        else
                    //            chkInactive.Checked = false;

                    //        chkInactive.Visible = chkShowInactiveColumn.Checked;
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                string ErrorMessage = UI.ExceptionHandling.ExceptionMethodHandler.HandlesException(ex);
                ucValidationMessage.ErrorMessage = ErrorMessage;
                ucValidationMessage.Show();
            }
        }

        protected void gvPageIndexChangedEventHandler(object sender, GridViewPageEventArgs e)
        {
            try
            {
                CommonFunctions.SetGridViewPageIndex(gvEmployeeList, e.NewPageIndex);
                //this.BindDataGrid();
            }
            catch (Exception ex)
            {
                string ErrorMessage = UI.ExceptionHandling.ExceptionMethodHandler.HandlesException(ex);
                ucValidationMessage.ErrorMessage = ErrorMessage;
                ucValidationMessage.Show();
            }
        }

        protected void DelCustomer(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton btn = sender as ImageButton;
                if (btn != null)
                {
                    string keyField = btn.CommandArgument.Trim();
                    EmployeeAdminUIMapper emp = new EmployeeAdminUIMapper();
                    emp.emp_id = keyField;
                    new EmployeeAdminAddEditAssembler().DeleteEmployeeDetails(emp);
                }
            }
            catch (Exception ex)
            {
                string ErrorMessage = UI.ExceptionHandling.ExceptionMethodHandler.HandlesException(ex);
                ucValidationMessage.ErrorMessage = ErrorMessage;
                ucValidationMessage.Show();
            }
        }

        protected void EditCustomer(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton btn = sender as ImageButton;
                if (btn != null)
                {
                    string keyField = btn.CommandArgument.Trim();
                    EmployeeAdminUIMapper emp = new EmployeeAdminUIMapper();
                    emp.emp_id = keyField;
                    EmployeeAdminUIMapper empui = new EmployeeAdminAddEditAssembler().GetEmployeeDetails(emp);
                    FillData(empui);
                    ViewState["addnew"] = false;
                    ViewState["update"] = true;
                }
            }
            catch (Exception ex)
            {
                string ErrorMessage = UI.ExceptionHandling.ExceptionMethodHandler.HandlesException(ex);
                ucValidationMessage.ErrorMessage = ErrorMessage;
                ucValidationMessage.Show();
            }
        }

        private void FillData(EmployeeAdminUIMapper empui)
        {
            if (ddlE_emp_bu.Items.FindByValue(empui.emp_bu.ToString()) != null)
                ddlE_emp_bu.SelectedValue = empui.emp_bu.ToString();
            txtE_emp_id.Text = empui.emp_id;
            txtE_emp_name.Text = empui.emp_name;
            txtE_emp_title.Text = empui.emp_title;
            txtE_emp_directno.Text = empui.emp_directno;
            txtE_emp_hp.Text = empui.emp_hp;
            txtE_emp_email.Text = empui.emp_email;
            if (ddlE_emp_type.Items.FindByValue(empui.emp_type.ToString()) != null)
                ddlE_emp_type.SelectedValue = empui.emp_type.ToString();

            dtE_emp_date_join.Value = empui.emp_date_join;
            if (ddlE_emp_status.Items.FindByValue(empui.emp_status_id.ToString()) != null)
                ddlE_emp_status.SelectedValue = empui.emp_status_id.ToString();
            if (ddlE_emp_walfare.Items.FindByValue(empui.emp_wf_grp.ToString()) != null)
                ddlE_emp_walfare.SelectedValue = empui.emp_wf_grp;
            txtE_emp_logname.Text = empui.emp_logname;
            chkE_emp_left.Checked = empui.emp_left;
            dtE_emp_date_left.Value = empui.emp_date_left;
            txthr_emp_r_add1.Text = empui.emp_r_add1;
            txthr_emp_r_add2.Text = empui.emp_r_add2;
            txthr_emp_r_add3.Text = empui.emp_r_add3;
            txthr_emp_tel.Text = empui.emp_tel;
            txthr_emp_nok.Text = empui.emp_nok;
            txthr_emp_nok_relationship.Text = empui.emp_nok_relationship;
            txthr_emp_health.Text = empui.emp_health;
            txthr_emp_blood_grp.Text = empui.emp_blood_grp;
            txthr_emp_medical_history.Text = empui.emp_medical_history;
            ddlhr_emp_gender.SelectedValue = empui.emp_gender;
            txthr_emp_marital_status.Text = empui.emp_marital_status;
            txthr_emp_passport_ic.Text = empui.emp_passport_ic;
            dthr_emp_passport_ic_expiry.Value = empui.emp_passport_ic_expiry;
            dthr_emp_dob.Value = empui.emp_dob;
            dthr_emp_pob.Value = string.IsNullOrEmpty(empui.emp_pob) ? DateTime.MinValue : Convert.ToDateTime(empui.emp_pob);
            txthr_emp_bank.Text = empui.emp_bank;
            txthr_emp_bank_acc.Text = empui.emp_bank_acc;
            txthr_emp_bank_branch.Text = empui.emp_bank_branch;
            txthr_emp_religion.Text = empui.emp_religion;
            txtE_emp_rmk.Text = empui.emp_rmk;
            txthr_emp_age.Text = CalculateAge(empui.emp_dob).ToString();
            txthr_pay_regular.Text = empui.pay_regular.ToString();
            txthr_pay_fixed_allowance.Text = empui.pay_fixed_allowance.ToString();
            txthr_pay_SDL.Text = empui.pay_SDL.ToString();
            txthr_pay_donation.Text = empui.pay_donation.ToString();
            txthr_pay_cpf_emp.Text = empui.pay_cpf_emp.ToString();
            txthr_pay_cpf_emp_amt.Text = empui.pay_cpf_emp_amt.ToString();
            txthr_pay_cpf_company.Text = empui.pay_cpf_company.ToString();
            txthr_pay_cpf_company_amt.Text = empui.pay_cpf_company_amt.ToString();
            ddlhr_pay_donation_desc.SelectedValue = empui.pay_donation_desc.ToString();

        }

        private int CalculateAge(DateTime dob)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dob.Year;
            if (dob > today.AddYears(-age)) age--;
            return age;
        }

        protected void btnAddNew_Click(object sender, System.EventArgs e)
        {
            try
            {
                ViewState["addnew"] = true;
                ViewState["update"] = false;
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

        [WebMethod]
        public static string GetEmpID(int statusID)
        {
            return new EmployeeAdminAddEditAssembler().GetEmpID(statusID);
        }

        protected void btnShowHideLeft_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (btnShowHideLeft.Text == "Hide Left")
                {
                    BindDataGrid(true);
                    btnShowHideLeft.Text = "Show Left";
                }
                else
                {
                    BindDataGrid();
                    btnShowHideLeft.Text = "Hide Left";
                }
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

        protected void ddlSearch_emp_bu_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                BindDataGrid(unit: ddlSearch_emp_bu.SelectedValue);
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
        
    }
}