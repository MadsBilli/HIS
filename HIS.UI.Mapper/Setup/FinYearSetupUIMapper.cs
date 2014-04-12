using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UI.Mapper.Setup
{
    public class FinYearSetupUIMapper
    {
        public int fin_yrs { get; set; }
        public DateTime fin_yrs_sdate { get; set; }
        public DateTime fin_yrs_edate { get; set; }
        public bool fin_yrs_act { get; set; }
        public bool fin_yrs_closed { get; set; }
        public int primaryKey { get; set; }
    }
}
