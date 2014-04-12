using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HIS.Common
{
    public enum Operation
    {
        AddNew,
        Delete,
        Update
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum NameSequence
    {
        FMG,
        GFM,
        GMF,
        GF,
        MF
    }

    public enum Salutation
    {
        Mr,
        Mrs,
        Mdm,
        Ms,
        Doc,
        Prof
    }

    public enum DeliverySelection
    {
        Weeks,
        Days
    } 

    public enum ContactType
    {
        [Description("Human Resource Contact")]
        HumanResourceContact,
        [Description("Admin Contact")]
        AdminContact,
        [Description("Business Contact")]
        BusinessContact,
        [Description("Technology Contact")]
        TechnologyContact,
        [Description("Procurement Contact")]
        ProcurementContact,
        [Description("Finance Contact")]
        FinanceContact
    }
    public enum Level
    {
        [Description("1 - CEO, MD, DIRECTOR, GM")]
        CEOMDDIRECTORGM,
        [Description("2 - MANAGER, DEPT HEAD")]
        MANAGERDEPTHEAD,
        [Description("3 - EXECUTIVE, OFFICER, ASST MANAGER")]
        EXECUTIVEOFFICERASSTMANAGER,
        [Description("4 - SECRETARY, CLERK, OTHERS")]
        SECRETARYCLERKOTHERS
    }

    public enum PreferedDialog
    {
        English,
        Mandarin,
        Cantonese
    }

    public enum AccessRights
    {
         [Description("UPC Code")]
        fm_upc,
        [Description("Inventory")]
        fm_inventory,
        [Description("Finance Acc Code")]
        fm_acc,
        [Description("Finance General-GL")]
        fm_misc_gl,
        [Description("Finance PO")]
        fm_po,
        [Description("Vendor")]
        fm_ven,
        [Description("Purchase Invoice")]
        fm_pur_inv,
        [Description("Payments")]
        fm_pay,
        [Description("Customer")]
        fm_cust,
        [Description("Invoice")]
        fm_inv,
        [Description("Receipts")]
        fm_rec,
        [Description("Aging")]
        fm_aging,
        [Description("Reports")]
        fm_rpt, 
        [Description("Emp Admin")]
        fm_emp_admin,
        [Description("System Setup")]
        fm_setup,
        [Description("Sales Commission")]
        fm_commission,
        [Description("Work Order")]
        fm_wo			
    }
}
