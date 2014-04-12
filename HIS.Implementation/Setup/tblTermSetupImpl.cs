using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HIS.DataAccess.SetUp;
using HIS.UI.Mapper.Setup;
using HIS.Data.Mapper.SetUp;

namespace HIS.Implementation.Setup
{
    public class tblTermSetupImpl
    {
        public DataSet GetTermSetupDetails(string txtSelect)
        {
            tblTermsSetupDA termDA = new tblTermsSetupDA();
            return termDA.GetTermSetupDetails(txtSelect);
        }

        public void DeleteTermDetails(int termId)
        {
            tblTermsSetupDA termDA = new tblTermsSetupDA();
            termDA.DeleteTermDetails(termId);
        }

        public void DeleteTermItemDetails(List<int> termItemIds)
        {
            tblTermsSetupDA termDA = new tblTermsSetupDA();
            termDA.DeleteTermItemDetails(termItemIds);
        }

        public void SaveTermDetails(List<tblTermsUIMapper> termUIMappers)
        {
            var termMapper = (from i in termUIMappers
                              select new tblTermsMapper
                              {
                                  int_ID = i.int_ID,
                                  operation = i.operation,
                                  txtDescription = i.txtDescription,
                                  txtSelect = i.txtSelect,
                                  txtType = i.txtType
                              }).ToList();
            tblTermsSetupDA termDA = new tblTermsSetupDA();
            termDA.SaveTermDetails(termMapper);
        }

        public void SaveTermItemDetails(List<tblTermsItemUIMapper> termUIMappers)
        {
            var termMapper = (from i in termUIMappers
                              select new tblTermsItemMapper
                              {
                                  int_ID = i.int_ID,
                                  operation = i.operation,
                                  txtDescription = i.txtDescription,
                                  txtLN = i.txtLN,
                                  intTermID = i.intTermID
                              }).ToList();
            tblTermsSetupDA termDA = new tblTermsSetupDA();
            termDA.SaveTermItemDetails(termMapper);
        }

    }
}
