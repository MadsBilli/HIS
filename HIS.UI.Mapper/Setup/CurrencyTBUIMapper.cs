using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UI.Mapper.Setup
{
    public class CurrencyTBUIMapper
    {
        public Int16 currency_id { get; set; }
        public string currency_type { get; set; }
        public decimal currency_rate { get; set; }
        public string currency_rmk { get; set; }
        public DateTime currency_date { get; set; }
        public string currency_update_by { get; set; }

    }
}
