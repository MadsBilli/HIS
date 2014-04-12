using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using HIS.UI.Mapper.Setup;
using HIS.UI.Assembler.Setup;
using HIS.UI.SessionManagement;
using HIS.UI.Common;
using System.Web.Services;

namespace HIS.Pages.Setup
{
    public partial class AccessRights : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            if (!Page.IsPostBack)
            {
                InitialSetup();
                BindDropDownList();
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
        }

        private void BindDropDownList()
        {
            var res = new AccessRightAssembler().GetEmpTypeForddl();
            if (res.Tables.Count > 0 && res.Tables[0] != null && res.Tables[0].Rows.Count > 0)
            {
                ddlAccessRightType.DataSource = res.Tables[0].AsDataView();
                ddlAccessRightType.DataValueField = "emp_type";
                ddlAccessRightType.DataTextField = "emp_typedesc";
                ddlAccessRightType.DataBind();
                ddlAccessRightType_SelectedIndexChanged(null, null);
            }
        }

        protected void ddlAccessRightType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AccessRightsUIMapper accessRights = new AccessRightsUIMapper();
                accessRights.emp_type = CommonFunctions.ConvertToInt(ddlAccessRightType.SelectedValue);
                var res = new AccessRightAssembler().GetAccessRightDetails(accessRights);
                chkAging.Checked            = res.fm_aging;
                chkCustomer.Checked         = res.fm_cust;
                chkEmpAdmin.Checked         = res.fm_emp_admin;
                chkFinanceAccCode.Checked   = res.fm_acc;
                chkFinanceGeneral.Checked   = res.fm_misc_gl;
                chkFinancePO.Checked        = res.fm_po;
                chkInventory.Checked        = res.fm_inventory;
                chkInvoice.Checked          = res.fm_inv;
                chkPayments.Checked         = res.fm_pay;
                chkPurchaseInvoice.Checked  = res.fm_pur_inv;
                chkReceipts.Checked         = res.fm_rec;
                chkReports.Checked          = res.fm_rpt;
                chkSalesCommission.Checked  = res.fm_commission;
                chkSystemSetup.Checked      = res.fm_setup;
                chkUPCCode.Checked          = res.fm_upc;
                chkVendor.Checked           = res.fm_ven;
                chkWorkOrder.Checked        = res.fm_wo;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AccessRightsUIMapper accessRights = new AccessRightsUIMapper();

                accessRights.fm_aging = chkAging.Checked;
                accessRights.fm_cust = chkCustomer.Checked;
                accessRights.fm_emp_admin = chkEmpAdmin.Checked;
                accessRights.fm_acc = chkFinanceAccCode.Checked;
                accessRights.fm_misc_gl = chkFinanceGeneral.Checked;
                accessRights.fm_po = chkFinancePO.Checked;
                accessRights.fm_inventory = chkInventory.Checked;
                accessRights.fm_inv = chkInvoice.Checked;
                accessRights.fm_pay = chkPayments.Checked;
                accessRights.fm_pur_inv = chkPurchaseInvoice.Checked;
                accessRights.fm_rec = chkReceipts.Checked;
                accessRights.fm_rpt = chkReports.Checked;
                accessRights.fm_commission = chkSalesCommission.Checked;
                accessRights.fm_setup = chkSystemSetup.Checked;
                accessRights.fm_upc = chkUPCCode.Checked;
                accessRights.fm_ven = chkVendor.Checked;
                accessRights.fm_wo = chkWorkOrder.Checked;
                accessRights.emp_type = CommonFunctions.ConvertToInt(ddlAccessRightType.SelectedValue);
                new AccessRightAssembler().SaveAccessRightsDetails(accessRights);
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
