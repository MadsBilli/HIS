using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UI.Mapper.Setup
{
    public class FinMonthSetupUIMapper
    {
        public int fin_mth_LN { get; set; }
        public DateTime? fin_mth_sdate { get; set; }
        public DateTime fin_mth_edate { get; set; }
        public bool fin_mth_act { get; set; }
        public bool fin_mth_close { get; set; }
        public string primaryKey { get; set; }
    }
}
