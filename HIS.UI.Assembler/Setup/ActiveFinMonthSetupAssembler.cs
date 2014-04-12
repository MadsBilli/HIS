using HIS.Implementation.Setup;
using HIS.UI.Mapper.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UI.Assembler.Setup
{
    public class ActiveFinMonthSetupAssembler
    {
        public FinYearSetupUIMapper GetActiveFinanceYearInfo()
        {
            ActiveFinMonthSetupImpl Impl = new ActiveFinMonthSetupImpl();
            return Impl.GetActiveFinanceYearInfo();
        }

        public FinMonthSetupUIMapper GetActiveFinanceMonthInfo()
        {
            ActiveFinMonthSetupImpl Impl = new ActiveFinMonthSetupImpl();
            return Impl.GetActiveFinanceMonthInfo();
        }
        public FinMonthSetupUIMapper GetActiveFinanceMonthInfoBySDate(DateTime SDate)
        {
            ActiveFinMonthSetupImpl Impl = new ActiveFinMonthSetupImpl();
            return Impl.GetActiveFinanceMonthInfoBySDate(SDate);
        }
        public void SetActiveFinanceMonthInfoBySDate(DateTime SDate)
        {
            ActiveFinMonthSetupImpl Impl = new ActiveFinMonthSetupImpl();
            Impl.SetActiveFinanceMonthInfoBySDate(SDate);
        }
    }
}
