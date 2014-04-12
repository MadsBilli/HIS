using System;
using System.Reflection;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HIS.UI.Assembler.InitialSetup;
using HIS.UI.Assembler.Setup;
using HIS.UI.Common;
using HIS.UI.Mapper.EmployeeAdmin;
using HIS.UI.Mapper.InitialSetup;
using HIS.UI.Mapper.Setup;
using HIS.UI.SessionManagement;

namespace HIS.Pages
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionManager session = new SessionManager();
            if (!session.SessionUserExist())
                Response.Redirect(ResolveClientUrl("~/SignIn.aspx"), false);

            GetMenuBuilder();
            if (HttpContext.Current.Request.QueryString["param"] != null)
            {
                var querystring = HIS.UI.Common.QueryStringHelper.DecryptQueryString(HttpContext.Current.Request.QueryString["param"].ToString());
                MenuSession menuSession = new MenuSession(Session);
                menuSession.MenuSelected = CommonFunctions.ConvertToInt(querystring["menu"]);
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            Response.Redirect(ResolveClientUrl("~/SignIn.aspx"), false);
        }

        private void GetMenuBuilder()
        {
            try
            {
                SessionManager session = new SessionManager();
                EmployeeAdminUIMapper user = new EmployeeAdminUIMapper();
                if (session.SessionUserExist())
                {
                    user = session.GetSessionUser();
                    InitialsetupUIMapper init = new InitialsetupAssembler().GetInitialSetup(user.emp_logname);

                    //First Row
                    main.Controls.Add(GetMenu("Fabric Code", "fabricCode", "FabricCode.png"));
                    main.Controls.Add(GetMenu("Account", "fm_acc", "Account.png"));
                    if (init.col_vendor)
                        main.Controls.Add(GetMenu("Vendor", "fm_ven", "Vendor.png"));
                    if (init.col_customer)
                        main.Controls.Add(GetMenu("Customers", "fm_cust", "Customer.png"));
                    if (init.col_management)
                        main.Controls.Add(GetMenu("Aging", "fm_aging", "Ageing.png"));
                    main.Controls.Add(GetMenu("Employee Admin", "fm_emp_admin", "EmpAdmin.png"));

                    //Second Row
                    main.Controls.Add(GetMenu("Quotation", "Quotation", "Quotation.png"));
                    main.Controls.Add(GetMenu("General", "fm_misc_gl", "General.png"));
                    if (init.col_vendor)
                        main.Controls.Add(GetMenu("Purchase Invoice", "fm_pur_inv", "PurInvoice.png"));
                    if (init.col_customer)
                        main.Controls.Add(GetMenu("Invoice", "fm_inv", "Invoice.png"));
                    if (init.col_management)
                        main.Controls.Add(GetMenu("Reports", "fm_rpt", "Reports.png"));
                    main.Controls.Add(GetMenu("System Setup", "fm_setup", "Setup.png"));

                    //Third Row
                    main.Controls.Add(GetMenu("Work Order", "fm_wo", "WorkOrder.png"));
                    main.Controls.Add(GetMenu("Purchase Order", "fm_po", "PurchaseOrder.png"));
                    if (init.col_vendor)
                        main.Controls.Add(GetMenu("Payments", "fm_pay", "Payments.png"));
                    if (init.col_customer)
                        main.Controls.Add(GetMenu("Receipts", "fm_rec", "Receipt.png"));
                    if (init.col_management)
                        main.Controls.Add(GetMenu("Sales Commission", "fm_commission", "SalesCom.png"));
                    main.Controls.Add(GetMenu("Backup DB", "backup", "Backup.png"));
                }
            }
            catch
            {
            }
        }

        private ImageButton GetMenu1s(string text, string id, string imgName)
        {
            ImageButton imgBtn = new ImageButton();
            imgBtn.ID = id;
            imgBtn.CssClass = "tile";
            imgBtn.ImageUrl = "~/Images/" + imgName;
            imgBtn.CausesValidation = false;
            imgBtn.Click += new System.Web.UI.ImageClickEventHandler(imagebutton_Click);
            return imgBtn;
        }

        private HtmlGenericControl GetMenu(string text, string id, string imgName)
        {
            HtmlGenericControl li = new HtmlGenericControl("li");
            HtmlGenericControl span = new HtmlGenericControl("span");
            HtmlImage img = new HtmlImage();
            LinkButton lnkBtn = new LinkButton();
            lnkBtn.ID = id;
            span.InnerHtml = text;
            img.Src = "../App_Themes/theme/images/t2.png";
            lnkBtn.Click += new EventHandler(imagebutton_Click);
            lnkBtn.Controls.Add(img);
            lnkBtn.Controls.Add(span);
            li.Controls.Add(lnkBtn);
            return li;
        }

        protected void imagebutton_Click(object sender, EventArgs e)
        {
            bool allowAccess = false;
            //ImageButton button = sender as ImageButton;
            LinkButton button = sender as LinkButton;
            SessionManager session = new SessionManager();
            EmployeeAdminUIMapper user = new EmployeeAdminUIMapper();
            if (session.SessionUserExist())
            {
                user = session.GetSessionUser();
                string url = string.Empty;
                bool terminated = false;
                AccessRightsUIMapper access = new AccessRightAssembler().GetUserAccessRights(user.emp_type, user.emp_logname, out terminated);
                if (terminated)
                {
                    HttpContext.Current.Session.Clear();
                    HttpContext.Current.Session.Abandon();
                    Response.Redirect(ResolveClientUrl("../userTerminated.aspx"));
                }
                else
                {
                    if (button.ID == "fabricCode" || button.ID == "Quotation" || button.ID == "backup")
                    {
                        allowAccess = true; //no access rights for the above screens.
                    }
                    else
                    {
                        PropertyInfo propertyInfo = access.GetType().GetProperty(button.ID);
                        allowAccess = Convert.ToBoolean(propertyInfo.GetValue(access, null));
                    }
                    if (allowAccess)
                    {
                        if (button.ID == "fabricCode")//Fabric  Code
                            url = "FabricCode/FabricCodeAddEdit.aspx";
                        if (button.ID == "fm_acc")//Account
                            url = "ComingSoon.aspx";
                        else if (button.ID == "fm_ven")//Vendor
                            url = "Vendor/VendorAddEdit.aspx";
                        else if (button.ID == "fm_cust")//Customer
                            url = "Customer/CustomerAddEdit.aspx";
                        else if (button.ID == "fm_aging")//Aging
                            url = "ComingSoon.aspx";
                        else if (button.ID == "fm_emp_admin")//Employee Admin -Employee/EmployeeAdminAddEdit.aspx
                            url = "ComingSoon.aspx";

                        else if (button.ID == "Quotation")//Quotation
                            url = "Quotation/QuotationSearch.aspx";
                        else if (button.ID == "fm_misc_gl")//General 
                            url = "General.aspx";
                        else if (button.ID == "fm_pur_inv")//Purchase Invoice
                            url = "PurchaseInvoice/PurchaseInvoice.aspx";
                        else if (button.ID == "fm_inv")//Invoice
                            url = "Invoice/Invoice.aspx";
                        else if (button.ID == "fm_rpt")//Reports
                            url = "ComingSoon.aspx";
                        else if (button.ID == "fm_setup")//System Setup -Setup/SetupLandingPage.aspx 
                            url = "ComingSoon.aspx";

                        else if (button.ID == "fm_wo")//Work Order
                            url = "WorkOrder/Search.aspx";
                        else if (button.ID == "fm_po")//Purchase Order
                            url = "PurchaseOrder/SearchPO.aspx";
                        else if (button.ID == "fm_pay")//Payments
                            url = "Payments/Payment.aspx";
                        else if (button.ID == "fm_rec")//Receipt
                            url = "Receipt/Search.aspx";
                        else if (button.ID == "fm_commission")//Sales Commission
                            url = "ComingSoon.aspx";
                        else if (button.ID == "backup")//System Backup
                            url = "ComingSoon.aspx";

                        Response.Redirect(ResolveClientUrl(url));
                    }
                }
            }
        }
    }
}