using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UI.Mapper.Setup
{
    public class BankAccountSetupUIMapper
    {
        public Int16 setup_id { get; set; }
        public string setup_value { get; set; }
        public string setup_rmk { get; set; }
        public string setup_pw { get; set; }

        public string SGDBankAccountNumber { get; set; }
        public string USDBankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string BankAdd1 { get; set; }
        public string BankAdd2 { get; set; }
        public string BankAdd3 { get; set; }
        public string ShowRemitBankAccinInv { get; set; }
        public string FinancialControlPW { get; set; }
    }
}
