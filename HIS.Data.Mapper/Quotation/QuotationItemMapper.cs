using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Data.Mapper.Quotation
{
    public class QuotationItemMapper
    {
        public string quote_id { get; set; }
        public Int16 quote_item_id { get; set; }
        public string quote_item_desc { get; set; }
        public Single quote_item_qty { get; set; }
        public int quote_item_curr { get; set; }
        public Single quote_item_crate { get; set; }
        public double quote_item_amt { get; set; }
        public double quote_item_tamt { get; set; }
        public Int16 quote_item_LN { get; set; }
        public int quote_item_setno { get; set; }
        public int quote_item_munit { get; set; }
        public Single quote_item_hight { get; set; }
        public Single quote_item_width { get; set; }
        public string quote_item_model { get; set; }
        public string quote_item_side { get; set; }
        public double quote_item_vcost { get; set; }
        public double quote_item_margin { get; set; }
        public bool quote_item_header { get; set; }
        public int quote_item_qty_accept { get; set; }
        public bool quote_item_reject { get; set; }
    }
}
