using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.UI.Mapper.PurchaseInvoice
{
    public class PurchaseInvoiceUIMapper
    {
        public string pur_id { get; set; }
        public string puchase_from { get; set; }
        public string po_no { get; set; }
        public string invoice { get; set; }
        public DateTime pi_date { get; set; }
        public string pi_acct { get; set; }
        public string pi_default_acc_code { get; set; }
        public string pi_balance_code { get; set; }
        public string pi_sub_Total { get; set; }
        public string pi_gst { get; set; }
        public string pi_Total { get; set; }
        public string pi_item_id { get; set; }
        public string pi_item_order { get; set; }
        public string pi_item_Re { get; set; }
        public string pi_item_Unit { get; set; }
        public string pi_item_Desc { get; set; }
        public string pi_item_Price { get; set; }
        public string pi_item_Tax { get; set; }
        public string pi_item_Gst { get; set; }
        public double pi_item_amount { get; set; }
        public string pi_item_Acccode { get; set; }
        public string pi_item_Suplier { get; set; }
        public string pi_item_Rec { get; set; }
        public string pi_item_InoviceNumber { get; set; }
        public string pi_item_woid { get; set; }
    }
}
