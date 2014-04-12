using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.UI.Mapper.PurchaseOrder
{
    public class PurchaseOrderItemUIMapper
    {
        public string purord_id { get; set; }
        public Int32 purord_item_id { get; set; }
        public string purord_item_header { get; set; }
        public string purord_item_model { get; set; }
        public string purord_item_type { get; set; }
        public string purord_item_desc { get; set; }
        public Int32 purord_item_width { get; set; }
        public Int32 purord_item_height { get; set; }
        public Int32 purord_item_ctrl { get; set; }
        public int purord_item_setno { get; set; }
        public int purord_item_uom { get; set; }
        public Int32 purord_item_col { get; set; }
        public Int32 quote_item_qty { get; set; }
        public Double purord_item_amt { get; set; }
        public Double purord_item_tamt { get; set; }
    }
}
