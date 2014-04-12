using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.UI.Mapper.Invoice
{
    public class InvoiceItemUIMapper
    {
        public string inv_id { get; set; }
        public Int32 inv_item_id { get; set; }
        public string inv_item_header { get; set; }
        public string inv_item_model { get; set; }
        public string inv_item_type { get; set; }
        public string inv_item_desc { get; set; }
        public Int32 inv_item_width { get; set; }
        public Int32 inv_item_height { get; set; }
        public Int32 inv_item_ctrl { get; set; }
        public int inv_item_setno { get; set; }
        public int inv_item_uom { get; set; }
        public Int32 inv_item_col { get; set; }
        public Int32 inv_item_qty { get; set; }
        public Double inv_item_amt { get; set; }
        public Double inv_item_tamt { get; set; }
    }
}
