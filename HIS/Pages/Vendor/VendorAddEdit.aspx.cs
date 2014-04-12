using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using HIS.UI.Mapper.Customer;
using HIS.UI.Assembler.Customer;
using HIS.UI.SessionManagement;
using HIS.UI.Common;
using System.Web.Services;

namespace HIS.Pages.Vendor
{
    public partial class VendorAddEdit : System.Web.UI.Page
    {
        private bool PreviousRecord;
        private bool NextRecord;
        private int CurrentContact;

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
            btnnext.Enabled = false;
            btnprevious.Enabled = false;
            imgContactAddNew.Enabled = false;
            imgContactSave.Enabled = false;
            HideShowMandatoryLabel(false);
        }

        private void HideShowMandatoryLabel(bool val)
        {
            lblstart1.Visible = val;
            lblstart2.Visible = val;
            lblstart3.Visible = val;
            lblstart4.Visible = val;
            lblstart5.Visible = val;
            lblstart6.Visible = val;
            lblstart7.Visible = val;
            lblstart8.Visible = val;
            lblstart9.Visible = val;
            lblstart10.Visible = val;
            lblstart11.Visible = val;
        }

        private void BindDropDownList()
        {

            BindEnumToddl<Common.Gender>(ddlGender, false);
            BindEnumToddl<Common.NameSequence>(ddlNameSeq, false);
            BindEnumToddl<Common.ContactType>(ddlContactType, true);
            BindEnumToddl<Common.Level>(ddlLevel, true);
            BindEnumToddl<Common.PreferedDialog>(ddlPreferDialog, false);

            var res = new CustomerAddEditAssembler().GetCustomerScreenListValues();
            
            if (res.Tables.Count > 2 && res.Tables[2] != null && res.Tables[2].Rows.Count > 0)
            {
                //Country
                ddlCountry.DataSource = res.Tables[2].AsDataView();
                ddlCountry.DataValueField = "city_code";
                ddlCountry.DataTextField = "city_desc";
                ddlCountry.DataBind();
                CommonFunctions.InsertEmptyValueToddl(ddlCountry);
                ddlAsstCountry.DataSource = res.Tables[2].AsDataView();
                ddlAsstCountry.DataValueField = "city_code";
                ddlAsstCountry.DataTextField = "city_desc";
                ddlAsstCountry.DataBind();
                CommonFunctions.InsertEmptyValueToddl(ddlAsstCountry);
            }
            if (res.Tables.Count > 4 && res.Tables[4] != null && res.Tables[4].Rows.Count > 0)
            {
                //Default Trade debtor
                ddlDefaultTradeDebtor.DataSource = res.Tables[4].AsDataView();
                ddlDefaultTradeDebtor.DataValueField = "gl_acc_code";
                ddlDefaultTradeDebtor.DataTextField = "acc";
                ddlDefaultTradeDebtor.DataBind();
                CommonFunctions.InsertEmptyValueToddl(ddlDefaultTradeDebtor);
            }
            if (res.Tables.Count > 6 && res.Tables[6] != null && res.Tables[6].Rows.Count > 0)
            {
                //Salutation
                ddlSalutation.DataSource = res.Tables[6].AsDataView();
                ddlSalutation.DataValueField = "salutation_desc";
                ddlSalutation.DataTextField = "salutation_desc";
                ddlSalutation.DataBind();
                CommonFunctions.InsertEmptyValueToddl(ddlSalutation);
            }
        }
        private void BindEnumToddl<T>(DropDownList ddl, bool useDescription) where T : struct
        {
            if (!useDescription)
                ddl.DataSource = Enum.GetNames(typeof(T)).Select(o => new { Text = o, Value = o });
            else
            {
                var r = Enum.GetNames(typeof(T)).Select(o => new { Text = Common.EnumHelper.GetEnumDescription(((Enum)Enum.Parse(typeof(T), o.ToString()))), Value = o });
                ddl.DataSource = Enum.GetNames(typeof(T)).Select(o => new { Text = Common.EnumHelper.GetEnumDescription(((Enum)Enum.Parse(typeof(T), o.ToString()))), Value = o });
            }
            ddl.DataTextField = "Text";
            ddl.DataValueField = "Value";
            ddl.DataBind();
            CommonFunctions.InsertEmptyValueToddl(ddl);
        }

        private void BindDataGrid()
        {
            var res = new CustomerAddEditAssembler().GetVendorList();
            gvCustomerList.DataSource = res;
            gvCustomerList.PageSize = CommonFunctions.GetGridPageSize();
            gvCustomerList.DataBind();
        }

        protected void imgbtnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                imgbtnSave.Enabled = true;
                ClearAllFields();
                InitialSetup();
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

        protected void imgbtnSave_Click(object sender, EventArgs e)
        {
            try
            {

                CustVendorUIMapper custVendor = new CustVendorUIMapper();
                custVendor.cust_id = txtCustomerId.Text.Trim();
                custVendor.cust_name = txtCustomerName.Text.Trim();
                custVendor.cust_add1 = txtAddress1.Text.Trim();
                custVendor.cust_add2 = txtAddress2.Text.Trim();
                custVendor.cust_add3 = txtPostalCode.Text.Trim();
                custVendor.cust_add4 = txtCity.Text.Trim();
                custVendor.cust_add5 = ddlCountry.SelectedValue; 

                //custVendor.cust_br_add4 = txtDACity.Text.Trim();

                custVendor.cust_terms = UI.Common.CommonFunctions.ConvertToInt16(txtTerms.Text.Trim());
                //credit limit does not accept decimal places
                custVendor.cust_creditlimit = UI.Common.CommonFunctions.ConvertToInt(txtCreditLimit.Text.Trim());
                custVendor.cust_type = "V";

                custVendor.cust_gst_reg = ChkRegisteredCompany.Checked;
                custVendor.cust_blacklisted = ChkBlacklisted.Checked;
                custVendor.cust_rmk = txtCustomerRemark.Text.Trim();
                custVendor.cust_inactive = chkInactiveCustomer.Checked;

                custVendor.cust_Nature = hdnCustNature.Value;
                custVendor.cust_emp_no = hdnCustEmpNo.Value;
                custVendor.cust_payup = UI.Common.CommonFunctions.ConvertToDecimal(hdnCustPayup.Value);
                custVendor.cust_tradedebtor = ddlDefaultTradeDebtor.SelectedValue;

                custVendor.cust_emp_name = txtMainContact.Text.Trim();
                custVendor.cust_emp_tel_area_code = txtTelAreaCode.Text.Trim();
                custVendor.cust_emp_tel = txtTel.Text.Trim();
                custVendor.cust_emp_fax_area_code = txtFaxAreaCode.Text.Trim();
                custVendor.cust_emp_fax = txtFax.Text.Trim();
                custVendor.cust_emp_email = txtEmail.Text.Trim();


                custVendor.cust_intrmk = GetInternalRemarks();
                SessionManager session = new SessionManager();
                if (session.SessionUserExist())
                {
                    custVendor.cust_CreatedBy = session.GetSessionUserName();
                    custVendor.cust_updatedby = session.GetSessionUserName();
                }
                DateTime saveTime = DateTime.Now;
                custVendor.cust_Created = saveTime;

                custVendor.cust_updated = saveTime;

                VenPayeeUIMapper payee = new VenPayeeUIMapper();
                payee.PayeeID = txtCustomerId.Text.Trim();
                payee.PayeeName1 = txtPayeeName1.Text.Trim();
                payee.PayeeName2 = txtPayeeName2.Text.Trim();
                payee.BankName = txtBankName.Text.Trim();	
                payee.BankAdd1 = txtBankAdd1.Text.Trim();		
                payee.BankAdd2 = txtBankAdd2.Text.Trim();			
                payee.BankAdd3 = txtBankAdd3.Text.Trim();			
                payee.BankSwiftCode	= txtSwiftCode.Text.Trim();	
                payee.BankCode = txtBankCode.Text.Trim();			
                payee.BankBranchCode = txtBranchCode.Text.Trim();		
                payee.BankRoutingNo	= txtRoutingNo.Text.Trim();	
                payee.BankAccountNo	= txtAccountNo.Text.Trim();
                payee.BankRemarks = txtBankRemarks.Text.Trim();	  

                new CustomerAddEditAssembler().InsertCustomerDetails(custVendor);
                payee.PayeeID = custVendor.cust_id;

                new CustomerAddEditAssembler().SaveVenPayeeDetails(payee);

                lblCustCreatedBy.Text = custVendor.cust_CreatedBy;
                lblCustCreatedOn.Text = custVendor.cust_Created.ToString("dd-MM-yyyy hh:mm:ss tt");
                txtInternalRemark.Text = custVendor.cust_intrmk;
                if (!txtCustomerId.Text.Trim().Equals(string.Empty))
                {
                    lblCustCreatedBy.Text = custVendor.cust_updatedby;
                    lblCustCreatedOn.Text = custVendor.cust_updated.ToString("dd-MM-yyyy hh:mm:ss tt");
                }
                txtCustomerId.Text = custVendor.cust_id;
                imgContactAddNew.Enabled = true;

                BindDataGrid();
                GetCustomerDetails(custVendor.cust_id);
                GetCustomerContactDetails(custVendor.cust_id);
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

        protected void imgContactSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustContactsUIMapper contacts = new CustContactsUIMapper();
                contacts.cust_id = txtCustomerId.Text.Trim();
                contacts.cust_emp_id = CommonFunctions.ConvertToInt(hdnCustContEmpNo.Value);
                contacts.cust_emp_name_seq = ddlNameSeq.SelectedValue;
                contacts.cust_emp_gender = ddlGender.SelectedValue;
                contacts.cust_emp_name_salutation = ddlSalutation.SelectedValue;
                contacts.cust_emp_name_given = txtGivenName.Text.Trim();
                contacts.cust_emp_name_family = txtFamilyName.Text.Trim();
                contacts.cust_emp_name_middle = txtMiddleName.Text.Trim();
                //contacts.cust_emp_name              = 
                contacts.cust_emp_level = ddlLevel.SelectedValue;
                contacts.cust_emp_dept = txtDept.Text.Trim();
                contacts.cust_emp_title = txtTitle.Text.Trim();
                contacts.cust_emp_tel_area_code = txtContTelAreaCode.Text.Trim();
                contacts.cust_emp_tel = txtContTel.Text.Trim();
                contacts.cust_emp_tel_ext = txtContExt.Text.Trim();
                contacts.cust_emp_hp_area_code = txtHPAreaCode.Text.Trim();
                contacts.cust_emp_hp = txtHP.Text.Trim();
                contacts.cust_emp_fax_area_code = txtContFaxAreaCode.Text.Trim();
                contacts.cust_emp_fax = txtContFax.Text.Trim();
                contacts.cust_emp_email = txtContactEmail.Text.Trim();
                contacts.cust_emp_add1 = txtContactAddress1.Text.Trim();
                contacts.cust_emp_add2 = txtContactAddress2.Text.Trim();
                contacts.cust_emp_add3 = txtAsstPostalCode.Text.Trim();
                contacts.cust_emp_add4 = txtAsstCity.Text.Trim();
                contacts.cust_emp_add5 = ddlAsstCountry.SelectedValue;
                contacts.cust_emp_contact_source = txtSource.Text.Trim();
                contacts.cust_emp_region = txtRegion.Text.Trim();
                contacts.cust_emp_create_bu = txtBU.Text.Trim();
                contacts.cust_emp_left = chkContInactive.Checked;
                contacts.cust_emp_type = "V";
                contacts.cust_emp_contact_type = ddlContactType.SelectedValue;
                contacts.cust_emp_prefer_comm = ddlPreferDialog.SelectedValue;
                contacts.cust_emp_fax_oth_area_code = txtAsstFaxAreaCode.Text.Trim();
                contacts.cust_emp_tel_asst_area_code = txtAsstAreaCode.Text.Trim();
                contacts.cust_emp_fax_oth = txtAsstFax.Text.Trim();
                contacts.cust_emp_asst_name = txtAsstName.Text.Trim();
                contacts.cust_emp_manager_name = txtManagerName.Text.Trim();
                contacts.cust_emp_tel_asst = txtAsstTel.Text.Trim();
                contacts.cust_emp_tel_asst_ext = txtAsstExt.Text.Trim();
                contacts.cust_emp_email2 = txtAsstEmail2.Text.Trim();
                contacts.cust_emp_rmk = txtAsstRemark.Text.Trim();
                contacts.cust_emp_relationship_rmk = txtContactRelationship.Text.Trim();

                if (Convert.ToBoolean(ViewState["NewContact"]))
                    contacts.cust_contact_opreration = Common.Operation.AddNew;
                else
                    contacts.cust_contact_opreration = Common.Operation.Update;

                SessionManager session = new SessionManager();
                if (session.SessionUserExist())
                    contacts.cust_emp_update_by = session.GetSessionUserName();
                contacts.cust_emp_create_datestamp = DateTime.Now;
                contacts.cust_emp_update_datestamp = DateTime.Now;
                lblContUpdateBy.Text = contacts.cust_emp_create_datestamp.ToString("dd-MMM-yyyy :hh:mm:ss tt");

                new CustomerAddEditAssembler().InsertCustomerContactDetails(contacts);
                GetCustomerContactDetails(contacts.cust_id);
                ViewState["NewContact"] = false;

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

        protected void imgContactAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                ViewState["NewContact"] = true;
                ClearContactFields();
                imgContactSave.Enabled = true;
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

        protected void gvCustomerListGridRowDataBoundEneventHandler(object sender, GridViewRowEventArgs e)
        {
            try
            {
                GridViewRow row = e.Row;
                if (row != null)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CustVendorUIMapper cust = row.DataItem as CustVendorUIMapper;
                        if (cust != null)
                        {
                            CheckBox chkInactive = row.FindControl("chkInactive") as CheckBox;
                            if (cust.cust_inactive)
                                chkInactive.Checked = true;
                            else
                                chkInactive.Checked = false;
                        }
                    }
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
                CommonFunctions.SetGridViewPageIndex(gvCustomerList, e.NewPageIndex);
                this.BindDataGrid();
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
                if (!Page.IsValid) return;
                ImageButton btn = sender as ImageButton;
                if (btn != null)
                {
                    string keyField = btn.CommandArgument.Trim();
                    CustVendorUIMapper custVendorUI = new CustVendorUIMapper();
                    custVendorUI.cust_id = keyField;
                    new CustomerAddEditAssembler().DeleteCustomerAndContactDetails(custVendorUI);
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

        protected void EditCustomer(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton btn = sender as ImageButton;
                if (btn != null)
                {
                    string keyField = btn.CommandArgument.Trim();
                    GetCustomerDetails(keyField);
                    GetCustomerContactDetails(keyField);
                    GetVendorBankDetails(keyField);
                    imgContactAddNew.Enabled = true;
                    imgContactSave.Enabled = true;
                    imgbtnSave.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                string ErrorMessage = UI.ExceptionHandling.ExceptionMethodHandler.HandlesException(ex);
                ucValidationMessage.ErrorMessage = ErrorMessage;
                ucValidationMessage.Show();
            }
        }

        private void GetCustomerDetails(string cust_id)
        {
            CustVendorUIMapper custVendorUI = new CustVendorUIMapper();
            custVendorUI.cust_id = cust_id;
            var cust = new CustomerAddEditAssembler().GetCustomerDetails(custVendorUI);
            FillDetails(cust);
        }

        private void GetVendorBankDetails(string cust_id)
        {
            VenPayeeUIMapper custVendorUI = new VenPayeeUIMapper();
            custVendorUI.PayeeID = cust_id;
            var cust = new CustomerAddEditAssembler().GetVendorBankDetails(custVendorUI);
        }

        private void GetCustomerContactDetails(string cust_id)
        {
            CustContactsUIMapper custContactUI = new CustContactsUIMapper();
            custContactUI.cust_id = cust_id;
            var cont = new CustomerAddEditAssembler().GetCustomerContactDetails(custContactUI);
            if (cont.Count > 0)
            {
                FillContactDetails(cont);
                imgContactSave.Enabled = true;
                btnnext.Enabled = true;
                btnprevious.Enabled = true;
            }
            else
            {
                imgContactSave.Enabled = false;
                btnnext.Enabled = false;
                btnprevious.Enabled = false;
                ViewState["NewContact"] = true;
            }
        }

        private string GetInternalRemarks()
        {
            return string.Concat(UI.Common.Constants.INTERNALREMARKS, DateTime.Now.ToString("dd-MM-yyyy HH:mm"));
        }

        private void FillDetails(CustVendorUIMapper cust)
        {
            txtCustomerId.Text = cust.cust_id;
            txtCustomerName.Text = cust.cust_name;
            txtAddress1.Text = cust.cust_add1;
            txtAddress2.Text = cust.cust_add2;
            txtPostalCode.Text = cust.cust_add3;
            txtCity.Text = cust.cust_add4;

            if (ddlCountry.Items.FindByValue(cust.cust_add5) != null)
                ddlCountry.SelectedValue = cust.cust_add5;
            
            txtTerms.Text = cust.cust_terms.ToString();
            txtMainContact.Text = cust.cust_emp_name;
            txtTelAreaCode.Text = cust.cust_emp_tel_area_code;
            txtTel.Text = cust.cust_emp_tel;
            txtFaxAreaCode.Text = cust.cust_emp_fax_area_code;
            txtFax.Text = cust.cust_emp_fax;
            txtEmail.Text = cust.cust_emp_email;

            hdnCustNature.Value = cust.cust_Nature;
            hdnCustEmpNo.Value = cust.cust_emp_no;
            hdnCustPayup.Value = cust.cust_payup.ToString();

            if (ddlDefaultTradeDebtor.Items.FindByValue(cust.cust_tradedebtor) != null)
                ddlDefaultTradeDebtor.SelectedValue = cust.cust_tradedebtor;

            ChkBlacklisted.Checked = cust.cust_blacklisted;
            txtCreditLimit.Text = cust.cust_creditlimit.ToString();
            ChkRegisteredCompany.Checked = cust.cust_gst_reg;
            txtCustomerRemark.Text = cust.cust_rmk;
            chkInactiveCustomer.Checked = cust.cust_inactive;
            lblLastUpdatedBy.Text = cust.cust_updatedby;
            lblLastUpdatedOn.Text = CommonFunctions.GetDate(cust.cust_updated.ToString());
            lblCustCreatedBy.Text = cust.cust_CreatedBy;
            lblCustCreatedOn.Text = cust.cust_Created.ToString();
            txtInternalRemark.Text = cust.cust_intrmk;


        }

        private void FillContactDetails(List<CustContactsUIMapper> lscont)
        {
            CustContactsUIMapper contacts = new CustContactsUIMapper();
            txtNoOfContact.Text = lscont.Count.ToString();
            if (PreviousRecord)
            {
                CurrentContact = CommonFunctions.ConvertToInt(hdnNoOfContacts.Value);
                if (CurrentContact != 0) CurrentContact--;
                hdnNoOfContacts.Value = CurrentContact.ToString();
            }
            if (NextRecord)
            {
                CurrentContact = CommonFunctions.ConvertToInt(hdnNoOfContacts.Value);
                if (CurrentContact < lscont.Count - 1) CurrentContact++;
                hdnNoOfContacts.Value = CurrentContact.ToString();
            }

            contacts = lscont[CurrentContact];
            hdnCustContEmpNo.Value = contacts.cust_emp_id.ToString();
            if (ddlNameSeq.Items.FindByValue(contacts.cust_emp_name_seq) != null)
                ddlNameSeq.SelectedValue = contacts.cust_emp_name_seq;

            if (ddlGender.Items.FindByValue(contacts.cust_emp_gender) != null)
                ddlGender.SelectedValue = contacts.cust_emp_gender;

            if (ddlSalutation.Items.FindByValue(contacts.cust_emp_name_salutation) != null)
                ddlSalutation.SelectedValue = contacts.cust_emp_name_salutation;
            txtGivenName.Text = contacts.cust_emp_name_given;
            txtFamilyName.Text = contacts.cust_emp_name_family;
            txtMiddleName.Text = contacts.cust_emp_name_middle;

            if (ddlLevel.Items.FindByValue(contacts.cust_emp_level) != null)
                ddlLevel.SelectedValue = contacts.cust_emp_level;
            txtDept.Text = contacts.cust_emp_dept;
            txtTitle.Text = contacts.cust_emp_title;
            txtContTelAreaCode.Text = contacts.cust_emp_tel_area_code;
            txtContTel.Text = contacts.cust_emp_tel;
            txtContExt.Text = contacts.cust_emp_tel_ext;
            txtHPAreaCode.Text = contacts.cust_emp_hp_area_code;
            txtHP.Text = contacts.cust_emp_hp;
            txtContFaxAreaCode.Text = contacts.cust_emp_fax_area_code;
            txtContFax.Text = contacts.cust_emp_fax;
            txtContactEmail.Text = contacts.cust_emp_email;
            txtContactAddress1.Text = contacts.cust_emp_add1;
            txtContactAddress2.Text = contacts.cust_emp_add2;
            txtAsstPostalCode.Text = contacts.cust_emp_add3;
            txtAsstCity.Text = contacts.cust_emp_add4;

            if (ddlAsstCountry.Items.FindByValue(contacts.cust_emp_add5) != null)
                ddlAsstCountry.SelectedValue = contacts.cust_emp_add5;
            txtSource.Text = contacts.cust_emp_contact_source;
            txtRegion.Text = contacts.cust_emp_region;
            txtBU.Text = contacts.cust_emp_create_bu;
            chkContInactive.Checked = contacts.cust_emp_left;

            if (ddlContactType.Items.FindByValue(contacts.cust_emp_contact_type) != null)
                ddlContactType.SelectedValue = contacts.cust_emp_contact_type;

            if (ddlPreferDialog.Items.FindByValue(contacts.cust_emp_prefer_comm) != null)
                ddlPreferDialog.SelectedValue = contacts.cust_emp_prefer_comm;
            txtAsstFaxAreaCode.Text = contacts.cust_emp_fax_oth_area_code;
            txtAsstAreaCode.Text = contacts.cust_emp_tel_asst_area_code;
            txtAsstFax.Text = contacts.cust_emp_fax_oth;
            txtAsstName.Text = contacts.cust_emp_asst_name;
            txtManagerName.Text = contacts.cust_emp_manager_name;
            txtAsstTel.Text = contacts.cust_emp_tel_asst;
            txtAsstExt.Text = contacts.cust_emp_tel_asst_ext;
            txtAsstEmail2.Text = contacts.cust_emp_email2;
            txtAsstRemark.Text = contacts.cust_emp_rmk;
            txtContactRelationship.Text = contacts.cust_emp_relationship_rmk;
        }

        private void ClearAllFields()
        {
            var content = Page.Master.FindControl("MainContent");
            ClearControls(content.Controls);
            ClearContactFields();
        }

        private void ClearControls(ControlCollection controls)
        {
            foreach (var control in controls)
            {
                if (control is DropDownList)
                {
                    ((DropDownList)control).SelectedValue = "0";
                }
                if (control is TextBox)
                {
                    ((TextBox)control).Text = string.Empty;
                }
                if (control is CheckBox)
                {
                    ((CheckBox)control).Checked = false;
                }
                if (control is Literal)
                {
                    ((Literal)control).Text = string.Empty;
                }
                if (control is Label)
                {
                    ((Label)control).Text = string.Empty;
                }
                if (control is HiddenField)
                {
                    ((HiddenField)control).Value = string.Empty;
                }
            }
        }
        private void ClearContactFields()
        {
            ClearControls(pnlContact.Controls);

            //ddlNameSeq.SelectedValue         = "0";
            //ddlGender.SelectedValue          = "0";
            //ddlSalutation.SelectedValue      = "0";
            // txtGivenName.Text               = string.Empty;
            // txtFamilyName.Text              = string.Empty;
            // txtMiddleName.Text              = string.Empty;

            //     ddlLevel.SelectedValue      = "0";
            // txtDept.Text                    = string.Empty;
            // txtTitle.Text                   = string.Empty;
            // txtContTelAreaCode.Text         = string.Empty;
            // txtContTel.Text                 = string.Empty;
            // txtContExt.Text                 = string.Empty;
            // txtHPAreaCode.Text              = string.Empty;
            // txtHP.Text                      = string.Empty;
            // txtContFaxAreaCode.Text         = string.Empty;
            // txtContFax.Text                 = string.Empty;
            // txtContactEmail.Text            = string.Empty;
            // txtContactAddress1.Text         = string.Empty;
            // txtContactAddress2.Text         = string.Empty;
            // txtAsstPostalCode.Text          = string.Empty;
            // txtAsstCity.Text                = string.Empty;

            //ddlAsstCountry.SelectedValue     =string.Empty;
            // txtSource.Text                  = string.Empty;
            // txtRegion.Text                  = string.Empty;
            // txtBU.Text                      = string.Empty;
            // chkContInactive.Checked         = false;

            //ddlContactType.SelectedValue     ="0";

            //ddlPreferDialog.SelectedValue    = "0";
            // txtAsstFaxAreaCode.Text         = string.Empty;
            // txtAsstAreaCode.Text            = string.Empty;
            // txtAsstFax.Text                 = string.Empty;
            // txtAsstName.Text                = string.Empty;
            // txtManagerName.Text             = string.Empty;
            // txtAsstTel.Text                 = string.Empty;
            // txtAsstExt.Text                 = string.Empty;
            // txtAsstEmail2.Text              = string.Empty;
            // txtAsstRemark.Text              = string.Empty;
            // txtContactRelationship.Text     = string.Empty;
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            try
            {
                PreviousRecord = true;
                GetCustomerContactDetails(txtCustomerId.Text.Trim());
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

        protected void btnnext_Click(object sender, EventArgs e)
        {
            try
            {
                NextRecord = true;
                GetCustomerContactDetails(txtCustomerId.Text.Trim());
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
        public static string GetSalesManCode(string emp_id)
        {
            return new CustomerAddEditAssembler().GetSalesmanName(emp_id);
        }
    }
}