using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.Implementation.Setup;
using HIS.UI.Mapper.Setup;

namespace HIS.UI.Assembler.Setup
{
    public class CurrencySetupAssembler
    {
        public DataSet GetCurrencySetupDetails()
        {
            CurrencySetupImpl currency = new CurrencySetupImpl();
            return currency.GetCurrencySetupDetails();
        }

        public void SaveCurrencySetupDetails(List<CurrencySetupUIMapper> currencySetupUI, List<CurrencyTBUIMapper> uicurrencytbMapper)
        {
            CurrencySetupImpl currency = new CurrencySetupImpl();
            currency.SaveCurrencySetupDetails(currencySetupUI, uicurrencytbMapper);
        }
    }
}
