using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UI.Mapper.Setup
{
    public class CurrencySetupUIMapper
    {
        public Int16 currency_id { get; set; }
        public string currency_desc { get; set; }
        public string currency_code { get; set; }
        public string currency_symbol { get; set; }
        public string currency_position { get; set; }
        public bool currency_home { get; set; }
        public string currency_format { get; set; }
        public string currency_thousand_sepa { get; set; }
        public string currency_decimal_sepa { get; set; }
        public Int16 currency_decimal_place { get; set; }

        //
        public string gl_acc_code { get; set; }

    }
}
