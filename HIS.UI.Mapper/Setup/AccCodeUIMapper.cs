using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UI.Mapper.Setup
{
    public class AccCodeUIMapper
    {
        public string acc_code { get; set; }
        public string acc_class { get; set; }
        public string acc_type { get; set; }
        public string acc_class_option { get; set; }
        public bool acc_class_option_type { get; set; }
        public bool acc_inactive { get; set; }
        public decimal acc_balance { get; set; }
        public bool acc_reconciliation { get; set; }
        public string acc_bank_code { get; set; }
        public string primaryKey { get; set; }
    }
}
