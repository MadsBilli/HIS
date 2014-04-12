using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.UI.Mapper.Quotation;
using HIS.Implementation.Quotation;
using HIS.Common;

namespace HIS.UI.Assembler.Quotation
{
    public class QuotationAssembler
    {
        public DataSet GetQuotationScreenListValues()
        {
            QuotationImpl quoteImpl = new QuotationImpl();
            return quoteImpl.GetQuotationScreenListValues();
        }

        public void SaveQuote(QuotationUIMapper quoteMapper, string operation)
        {
            QuotationImpl quoteImpl = new QuotationImpl();
            quoteImpl.SaveQuote(quoteMapper, operation);
        }

        public QuotationUIMapper GetQuoteDetails(string quoteId)
        {
            QuotationImpl quoteImpl = new QuotationImpl();
            return quoteImpl.GetQuoteDetails(quoteId);
        }

        public DataSet SearchQuoteDetails(string where, string orderBy)
        {
            QuotationImpl quoteImpl = new QuotationImpl();
            return quoteImpl.SearchQuoteDetails(where, orderBy);
        }

        public DataSet GetSalesmanList()
        {
            QuotationImpl quoteImpl = new QuotationImpl();
            return quoteImpl.GetSalesmanList();
        }
    }
}
