using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using HIS.Data.Mapper.Customer;
using HIS.Common;
using DataAccess.SQL2008;
using System.Reflection;

namespace HIS.DataAccess.Customer
{
    public class CustomerAddEditDA
    {
        [StoredProcedure(StoredProcedureName = StoredProcedureName.CUSTOMER_SCREEN_LIST_VALUES)]
        public DataSet GetCustomerScreenListValues()
        {  
                return new StoredProcedureCommandBuilder().ExecuteDataSet(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), null); 
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.CUSTOMER_DETAILS_INSERT)]
        public void InsertCustomerDetails(CustVendorMapper custVendor)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), custVendor);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.SAVE_VENDOR_PAYEE_DETAILS)]
        public void SaveVenPayeeDetails(VenPayeeMapper custVendor)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), custVendor);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.CUSTOMER_CONTACT_DETAILS_INSERT)]
        public void InsertCustomerContactDetails(CustContactsMapper custContVendor)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), custContVendor);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.DELETE_CUSTOMER_CONTACT_DETAILS)]
        public void DeleteCustomerAndContactDetails(CustVendorMapper custVendor)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), custVendor);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_CUSTOMER_DETAILS_FOR_GRID)]
        public List<CustVendorMapper> GetCustomerList()
        {
            var lsCustVendorMapper = new StoredProcedureCommandBuilder().GetEntities<CustVendorMapper>(
                                    (MethodInfo)MethodInfo.GetCurrentMethod(), null);
            return lsCustVendorMapper.ToList();
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_VENDOR_DETAILS_FOR_GRID)]
        public List<CustVendorMapper> GetVendorList()
        {
            var lsCustVendorMapper = new StoredProcedureCommandBuilder().GetEntities<CustVendorMapper>(
                                    (MethodInfo)MethodInfo.GetCurrentMethod(), null);
            return lsCustVendorMapper.ToList();
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_CUSTOMER_DETAILS)]
        public List<CustVendorMapper> GetCustomerDetails(CustVendorMapper custVendor)
        {
            var lsCustVendorMapper = new StoredProcedureCommandBuilder().GetEntities<CustVendorMapper>(
                                    (MethodInfo)MethodInfo.GetCurrentMethod(), custVendor);
            return lsCustVendorMapper.ToList();
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_VENDOR_BANK_DETAILS)]
        public List<VenPayeeMapper> GetVendorBankDetails(VenPayeeMapper custVendor)
        {
            var lsCustVendorMapper = new StoredProcedureCommandBuilder().GetEntities<VenPayeeMapper>(
                                    (MethodInfo)MethodInfo.GetCurrentMethod(), custVendor);
            return lsCustVendorMapper.ToList();
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_CUSTOMER_CONTACT_DETAILS)]
        public List<CustContactsMapper> GetCustomerContactDetails(CustContactsMapper custContact)
        {
            var lsCustContactMapper = new StoredProcedureCommandBuilder().GetEntities<CustContactsMapper>(
                                    (MethodInfo)MethodInfo.GetCurrentMethod(), custContact);
            return lsCustContactMapper.ToList();
        }
        
        public string GetSalesmanName(string salesmanCode)
        {
            var command = new StoredProcedureCommandBuilder();
            AdhocStoredProcedureExecutionResult result =
                 command.ExecuteAdhocStoredProcedure(
                    StoredProcedureName.GET_SALESMAN_NAME, new List<AdhocStoredProcedureInputParameters>
                    {
                        new AdhocStoredProcedureInputParameters
                            {
                                ParameterName = "@salesmanCode",
                                ParameterDataType = SqlDbType.VarChar,
                                ParameterValue = salesmanCode
                            } 
                    },
                    StoredProcedureEnums.StoredProcedureExecutionType.Scalar);

            var dsReturn = (string)result.ExecutionResult;

            return dsReturn;
        }

    }
}
