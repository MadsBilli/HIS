using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.UI.Mapper.Setup;
using HIS.DataAccess.SetUp;
using HIS.Data.Mapper.SetUp;

namespace HIS.Implementation.Setup
{
    public class ActiveFinMonthSetupImpl
    {
        public FinYearSetupUIMapper GetActiveFinanceYearInfo()
        {
            ActiveFinMonthSetupDA da = new ActiveFinMonthSetupDA();
            var lsMapper = da.GetActiveFinanceYearInfo();
            return new FinYearSetupUIMapper
                       {
                           fin_yrs = lsMapper.fin_yrs,
                           fin_yrs_sdate = lsMapper.fin_yrs_sdate,
                           fin_yrs_edate = lsMapper.fin_yrs_edate,
                           fin_yrs_closed = lsMapper.fin_yrs_closed,
                           fin_yrs_act = lsMapper.fin_yrs_act,
                           primaryKey = lsMapper.fin_yrs
                       };
        }

        public FinMonthSetupUIMapper GetActiveFinanceMonthInfo()
        {
            ActiveFinMonthSetupDA da = new ActiveFinMonthSetupDA();
            FinMonthSetupMapper mapper = new FinMonthSetupMapper();
            mapper.fin_mth_sdate = null;
            var lsMapper = da.GetFinanceMonthInfo(mapper);
            if (lsMapper != null)
            {
                return new FinMonthSetupUIMapper
                {
                    fin_mth_LN = lsMapper.fin_mth_LN,
                    fin_mth_sdate = lsMapper.fin_mth_sdate,
                    fin_mth_edate = lsMapper.fin_mth_edate,
                    fin_mth_act = lsMapper.fin_mth_act,
                    fin_mth_close = lsMapper.fin_mth_close,
                    primaryKey = String.Concat(lsMapper.fin_mth_LN, "|", lsMapper.fin_mth_sdate)
                };
            }
            else
                return new FinMonthSetupUIMapper();
        }

        public FinMonthSetupUIMapper GetActiveFinanceMonthInfoBySDate(DateTime SDate)
        {
            ActiveFinMonthSetupDA da = new ActiveFinMonthSetupDA();
            FinMonthSetupMapper mapper = new FinMonthSetupMapper();
            mapper.fin_mth_sdate = SDate;
            var lsMapper = da.GetFinanceMonthInfo(mapper);
            if (lsMapper != null)
            {
                return new FinMonthSetupUIMapper
                {
                    fin_mth_LN = lsMapper.fin_mth_LN,
                    fin_mth_sdate = lsMapper.fin_mth_sdate,
                    fin_mth_edate = lsMapper.fin_mth_edate,
                    fin_mth_act = lsMapper.fin_mth_act,
                    fin_mth_close = lsMapper.fin_mth_close,
                    primaryKey = String.Concat(lsMapper.fin_mth_LN, "|", lsMapper.fin_mth_sdate)
                };
            }
            return new FinMonthSetupUIMapper();                
        }

        public void SetActiveFinanceMonthInfoBySDate(DateTime SDate)
        {
            ActiveFinMonthSetupDA da = new ActiveFinMonthSetupDA();
            FinMonthSetupMapper mapper = new FinMonthSetupMapper();
            mapper.fin_mth_sdate = SDate;
            da.SetActiveFinanceMonthInfo(mapper);            
        }
    }
}
