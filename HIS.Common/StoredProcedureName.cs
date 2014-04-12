using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Common
{
    public class StoredProcedureName
    {

        #region Quotation
        public const string GET_QUOTATION_SCREEN_LISTVALUES = "usp_H_QuotationScreenListValues";
        public const string SAVE_QUOTE = "usp_H_SaveQuote";
        public const string GET_QUOTE_DETAILS = "usp_H_GetQuoteDetails";
        public const string SEARCH_QUOTE_DETAILS = "usp_H_SearchQuoteDetails";
        public const string GET_SALESMAN_LIST = "usp_H_GetSalesmanList";
        #endregion

        #region Workorder
        public const string GET_WORKORDER_SCREEN_LISTVALUES = "usp_H_WorkorderScreenListValues";
        public const string SEARCH_WORKORDER_DETAILS = "usp_H_SearchWorkorderDetails";
        public const string SAVE_WORKORDER = "usp_H_SaveWorkOrder";
        public const string SAVE_WORKORDER_ITEMS = "usp_H_SaveWorkOrder_Items";
        public const string GET_WORKORDER_DETAILS = "usp_H_GetWorkOrderDetails";
        #endregion

        #region login
        public const string GET_INITIALSETUP = "usp_H_GetInitialSetup";
        public const string GET_ACCESSRIGHTS = "usp_H_GetAccessRights";
        public const string CHECK_ACCESSRIGHTS = "usp_H_CheckAccessRights";
        public const string LOGIN_DETAILS = "usp_H_Login";
        public const string GET_USER_LOGIN_LISTING = "usp_H_GetUserLogListing";
        public const string SAVE_INITIAL_SETUP = "usp_H_SaveInitialSetup";
        #endregion
        #region
        public const string GET_EMPLOYEE_DETAILS_FOR_GRID = "usp_H_GetEmployeeListing";
        public const string SAVE_EMPLOYEE_DETAILS = "usp_H_SaveEmployeeAdminDetails";
        public const string GET_EMPLOYEE_SCREEN_LIST_VALUES = "usp_H_GetEmployeeScreenListValues";
        public const string DELETE_EMPLOYEE_DETAILS = "usp_H_DeleteEmployeeDetails";
        public const string GET_EMPLOYEE_DETAILS = "usp_H_GetEmployeeDetails";
        public const string GET_EMPID = "usp_H_GetEmpID";
        #endregion

        public const string DELETE_CUSTOMER_CONTACT_DETAILS = "usp_H_DeleteCustomerAndContactDetails";
        public const string GET_CUSTOMER_CONTACT_DETAILS = "usp_H_GetCustomerContactDetails";
        public const string GET_CUSTOMER_DETAILS = "usp_H_GetCustomerDetails";
        public const string CUSTOMER_SCREEN_LIST_VALUES = "usp_H_GetCustomerScreenListValues";
        public const string CUSTOMER_CONTACT_DETAILS_INSERT = "usp_H_InsertCustomerContact";
        public const string CUSTOMER_DETAILS_INSERT = "usp_H_InsertCustomerDetails";
        public const string GET_CUSTOMER_DETAILS_FOR_GRID = "usp_H_GetCustomerListing";
        public const string GET_VENDOR_DETAILS_FOR_GRID = "usp_H_GetVendorListing";
        public const string GET_SALESMAN_NAME = "usp_H_GetSalesmanName";
        public const string GET_VENDOR_BANK_DETAILS = "usp_H_GetVendorBankDetails";
        public const string SAVE_VENDOR_PAYEE_DETAILS = "usp_H_SaveVendorPayeeDetails";

        #region fabric code
        public const string GET_FABRIC_TYPE_DETAILS = "usp_S_GetFabricTypeListing";
        public const string GET_FABRIC_TYPE_DETAILS_BY_FABRIC_TYPE = "usp_S_GetFabricTypeByFc_Type";
        public const string GET_FABRICCODE_DETAILS = "usp_S_GetFabricCodeListing";
        public const string FABRIC_CODE_DETAILS_INSERT = "usp_S_InsertFabricCodeDetails";
        public const string FABRIC_CODE_DELETE = "usp_S_DeleteFabricCode";
        public const string FABRIC_CODE_DETAILS_UPDATE = "usp_S_UpdateFabricTypeDetails";
        #endregion

        #region Setup
        public const string DELETE_TERM = "usp_H_DeleteTerm";
        public const string DELETE_TERM_ITEMS= "usp_H_DeleteTermItems";
        public const string SAVE_TERMS= "usp_H_SaveTerm";
        public const string SAVE_TERM_ITEMS = "usp_H_SaveTermItems";
        public const string GET_TERMSETUPDETAILS = "usp_H_GetTermSetupDetails";
        public const string SAVE_CURRENCY_TB_DETAILS = "usp_H_SaveCurrencyTB";
        public const string SAVE_CURRENCY_SETUP_DETAILS = "usp_H_SaveCurrencySetupDetails";
        public const string GET_CURRENCY_SETUP_DETAILS = "usp_H_GetCurrencySetup";
        public const string GET_SYSTEM_SetUP_DETAILS = "usp_S_GetSystemSetup";
        public const string SYSTEM_SetUP_DETAILS_UPDATE = "usp_S_UpdateSystemSettingSetupdetails";

        public const string GET_INVOICE_ITEM_DESC_DETAILS = "usp_S_GetInvoiceItemsSelectionListing";
        public const string INVOICE_ITEM_DESC_DETAILS_INSERT = "usp_S_InsertAcctInvoiceDescDetails";
        public const string INVOICE_ITEM_DESC_DETAILS_DELETE = "usp_S_DeleteInvoiceSetupDescriptionDetails";

        public const string GET_BU_NAME_SETUP_DETAILS = "usp_S_GetBUNameSetupListing";
        public const string BU_NAME_SETUP_DETAILS_DELETE = "usp_S_DeleteBUNameSetupDetails";
        public const string BU_NAME_SETUP_DETAILS_INSERT = "usp_S_InsertBUNameSetupdetails";

        public const string GET_UOM_SETUP_DETAILS = "usp_S_GetUOMSetupListing";
        public const string UOM_SETUP_DETAILS_DELETE = "usp_S_DeleteUOMSetupDetails";
        public const string UOM_SETUP_DETAILS_INSERT = "usp_S_InsertUOMSetupdetails";

        public const string GET_RPT_PRINTING_SETUP_DETAILS = "usp_S_GetRptPrintingSetupListing";
        public const string RPT_PRINTING_SETUP_DETAILS_DELETE = "usp_S_DeleteRptPrintingSetupDetails";
        public const string RPT_PRINTING_SETUP_DETAILS_INSERT = "usp_S_InsertRptPrintingSetupdetails";

        public const string GET_Country_SETUP_DETAILS = "usp_S_GetCountrySetupListing";
        public const string COUNTRY_SETUP_DETAILS_UPDATE = "usp_S_UpdateCountrySetupdetails";

        public const string GET_SALESMAN_COMM_SETUP_DETAILS = "usp_S_GetSalesManCommSetupListing";
        public const string SALESMAN_COMM_SETUP_DETAILS_UPDATE = "usp_S_UpdateSalesManCommSetupdetails";

        public const string GET_FinanceSetting_SETUP_DETAILS = "usp_S_GetFinanceSettingSetupListing";
        public const string FINANCE_SETUP_DETAILS_UPDATE = "usp_S_UpdateFinanceSettingSetupdetails";

        public const string BANK_ACCT_NUM_SETUP_DETAILS_UPDATE = "usp_S_UpdateBankAcctNumberdetails";

        public const string GET_Active_FINYEAR_SETUP_DETAILS = "usp_S_GetActiveFinYear";
        public const string GET_Active_FINMONTH_SETUP_DETAILS = "usp_S_GetActiveFinMonth";
        public const string SET_Active_FINMONTH_SETUP_DETAILS = "usp_S_SetActiveFinMonth";

        public const string GET_ACC_CODE_DETAILS = "usp_S_GetAccCodeListing";
        public const string GET_ACCGL_SETUP_DETAILS_BY_GLTYPE = "usp_S_GetAccGLSetupByType";
        public const string SET_ACCGL_SETUP_DETAILS = "usp_S_SetAccGLSetupByType";

        public const string GET_BANK_ACC_DETAILS = "usp_S_GetBankAccountListing";
        public const string GET_PAYABLES_DETAILS = "usp_S_GetPayableListing";
        public const string GET_ALL_ACC_CODE_DETAILS = "usp_S_GetAllAccCodeListing";
        public const string SET_VENDOR_PURCHASES_DETAILS = "usp_S_SetVendorPurchaseByType";
        public const string GET_RECEIVABLES_DETAILS = "usp_S_GetReceivableListing";
                
        public const string FINANCE_CTRL_PWD_UPDATE = "usp_S_UpdateFinanceCtrlPwddetails";

        public const string GET_ACCESSRIGHTS_DETAILS = "usp_H_GetAccessRightsDetails";
        public const string SAVE_ACCESSRIGHTS_DETAILS = "usp_H_SaveAccessRightsDetails";
        public const string GET_SYSTEM_UP_DETAILS = "usp_S_GetSystemSetup";

        #endregion

        #region Receipts
        public const string SEARCH_RECEIPTS = "usp_H_SearchReceipts";
        #endregion

        #region Purchase Order
        public const string GET_PURCHASEORDER_SCREEN_LISTVALUES = "usp_H_PurchaseOrderScreenListValues";
        public const string SAVE_PURCHASEORDER = "usp_H_SavePurchaseOrder";
        public const string SAVE_PURCHASEORDER_ITEMS = "usp_H_SavePurchaseOrder_Items";
        public const string GET_PURCHASEORDER_DETAILS = "usp_H_GetPurchaseOrderDetails";
        public const string SEARCH_PURCHASEORDER_DETAILS = "usp_H_SearchPurchaseOrderDetails";
        #endregion

        #region Purchase Invoice
        public const string SAVE_PURCHASE_INVOICE = "usp_H_SavePurchaseOrder";
        #endregion

        #region Invoice
        public const string SAVE_INVOICE = "usp_H_SavePurchaseOrder";
        public const string SAVE_INVOICE_ITEMS = "usp_H_SavePurchaseOrder_Items";
        public const string GET_INVOICE_DETAILS = "";
        #endregion
    }
}
