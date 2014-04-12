using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.DataAccess.SetUp;
using HIS.UI.Mapper.Setup;
using HIS.Data.Mapper.SetUp;

namespace HIS.Implementation.Setup
{
    public class CurrencySetupImpl
    {
        public DataSet GetCurrencySetupDetails()
        {
            CurrencySetupDA currency = new CurrencySetupDA();
            return currency.GetCurrencySetupDetails();
        }

        public void SaveCurrencySetupDetails(List<CurrencySetupUIMapper> currencySetupUI, List<CurrencyTBUIMapper> uicurrencytbMapper)
        {
            CurrencySetupDA currencySetupDA = new CurrencySetupDA(); 
            var currencySetup = (from res in currencySetupUI
                                 select new CurrencySetupMapper
                                  {
                                      currency_id = res.currency_id,
                                      currency_desc = res.currency_desc,
                                      currency_code = res.currency_code,
                                      currency_symbol = res.currency_symbol,
                                      currency_position = res.currency_position,
                                      currency_home = res.currency_home,
                                      currency_format = res.currency_format,
                                      currency_thousand_sepa = res.currency_thousand_sepa,
                                      currency_decimal_sepa = res.currency_decimal_sepa,
                                      currency_decimal_place = res.currency_decimal_place,
                                      gl_acc_code = res.gl_acc_code 

                                  }).ToList();

            var currencytb = (from res in uicurrencytbMapper
                              select new CurrencyTBMapper
                                 {
                                     currency_id = res.currency_id,
                                     currency_type = res.currency_type,
                                     currency_rate = res.currency_rate,
                                     currency_rmk = res.currency_rmk,
                                     currency_date = res.currency_date,
                                     currency_update_by = res.currency_update_by
                                 }).ToList();


            currencySetupDA.SaveCurrencySetupDetails(currencySetup, currencytb);
        }
    }
}
