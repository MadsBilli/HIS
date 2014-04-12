using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Data.Mapper.Workorder
{
   public  class WorkorderitemMapper
    {
        public string wo_id { get; set; }
        public int wo_item_id { get; set; }
        public string wo_item_hide { get; set; }
        public string wo_item_header { get; set; }
        public string wo_item_desc { get; set; }
        public int wo_item_qty { get; set; }
        public double wo_item_amt { get; set; }
        public double wo_item_tamt { get; set; }
        public int wo_item_setno { get; set; }
        public int wo_item_munit { get; set; }
        public Single wo_item_height { get; set; }
        public Single wo_item_width { get; set; }
        public string wo_item_ctrl { get; set; }
        public string wo_item_model { get; set; }
        public string wo_item_colour { get; set; }
        public string wo_item_type { get; set; }
        public string wo_item_reverse { get; set; } 
   }
}
