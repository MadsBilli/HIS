using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.UI.Mapper.FabricCode
{
    public class FabricCodeUIMapper
    {
        public string fc_code { get; set; }
        public int fc_type { get; set; }
        public string fc_desc { get; set; }
        public string fc_colour { get; set; }
        public decimal fc_unitcost { get; set; }
        public decimal fc_unitprice { get; set; }
        public decimal fc_unitprice2 { get; set; }
        public decimal fc_unitprice3 { get; set; }
        public decimal fc_unitprice4 { get; set; }
        public decimal fc_instprice { get; set; }
        public decimal fc_instprice2 { get; set; }
        public decimal fc_instprice3 { get; set; }
        public decimal fc_instprice4 { get; set; }
        public string fc_width { get; set; }
        public string fc_min_width { get; set; }
        public string fc_rmk { get; set; }
        public string fc_size { get; set; }

        public string primaryKey { get; set; }

    }
}
