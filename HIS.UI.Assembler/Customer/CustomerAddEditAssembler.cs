using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.UI.Mapper.Customer;
using HIS.Implementation.Customer;
using HIS.Common;


namespace HIS.UI.Assembler.Customer
{
    public class CustomerAddEditAssembler
    {
        public void InsertCustomerDetails(CustVendorUIMapper custVendor)
        {
            var errorMessage = ValidateCustomerDetails(custVendor);
            if (errorMessage.Count > 0)
            {
                throw new ExceptionHandler(string.Join("<br/>", errorMessage));
            }
            CustomerAddEditImpl customerImpl = new CustomerAddEditImpl();
            customerImpl.InsertCustomerDetails(custVendor);

        }

        public void SaveVenPayeeDetails(VenPayeeUIMapper custVendor)
        { 
            CustomerAddEditImpl customerImpl = new CustomerAddEditImpl();
            customerImpl.SaveVenPayeeDetails(custVendor); 
        }

        public void DeleteCustomerAndContactDetails(CustVendorUIMapper custVendor)
        {
            CustomerAddEditImpl customerImpl = new CustomerAddEditImpl();
            customerImpl.DeleteCustomerAndContactDetails(custVendor);

        }

        public void InsertCustomerContactDetails(CustContactsUIMapper custContVendor)
        {
            var errorMessage = ValidateCustomerDetails(custContVendor);
            if (errorMessage.Count > 0)
            {
                throw new ExceptionHandler(string.Join("<br/>", errorMessage));
            }
            GetCustomerEmpName(custContVendor);
            CustomerAddEditImpl customerImpl = new CustomerAddEditImpl();
            customerImpl.InsertCustomerContactDetails(custContVendor);

        }

        private List<string> ValidateCustomerDetails(CustVendorUIMapper custVendor)
        {
            List<string> ErrorMessage = new List<string>();
            if (string.IsNullOrEmpty(custVendor.cust_name))
                ErrorMessage.Add("Customer Name");
            if (ErrorMessage.Count > 0)
            {
                ErrorMessage.Insert(0, "Missing Mandatory Field(s)!");
            }
            return ErrorMessage;
        }

        private List<string> ValidateCustomerDetails(CustContactsUIMapper custContVendor)
        {
            string ZoneAreaCode = "065";
            List<string> ErrorMessage = new List<string>();
            if (custContVendor.cust_emp_gender.Equals("0"))
                ErrorMessage.Add("Gender");
            if (custContVendor.cust_emp_name_salutation.Equals("0"))
                ErrorMessage.Add("Salutation");
            if (string.IsNullOrEmpty(custContVendor.cust_emp_name_family))
                ErrorMessage.Add("Family Name");
            if (string.IsNullOrEmpty(custContVendor.cust_emp_name_given) && string.IsNullOrEmpty(custContVendor.cust_emp_name_middle))
                ErrorMessage.Add("Middle Name or Given Name");
            if (custContVendor.cust_emp_name_seq.Equals("0"))
                ErrorMessage.Add("Contact's Name Seq");
            if (custContVendor.cust_emp_level.Equals("0"))
                ErrorMessage.Add("Contact's Level");
            if (string.IsNullOrEmpty(custContVendor.cust_emp_title))
                ErrorMessage.Add("Contact's Title");
            if (string.IsNullOrEmpty(custContVendor.cust_emp_tel_area_code))
                custContVendor.cust_emp_tel_area_code = ZoneAreaCode;
            if (string.IsNullOrEmpty(custContVendor.cust_emp_tel))
                ErrorMessage.Add("Contact's Type");

            if (ErrorMessage.Count > 0)
            {
                ErrorMessage.Insert(0, "Missing Mandatory Field(s)!");
            }
            return ErrorMessage;
        }

        public List<CustVendorUIMapper> GetCustomerList()
        {
            CustomerAddEditImpl customerImpl = new CustomerAddEditImpl();
            return customerImpl.GetCustomerList();
        }

        public List<CustVendorUIMapper> GetVendorList()
        {
            CustomerAddEditImpl customerImpl = new CustomerAddEditImpl();
            return customerImpl.GetVendorList();
        }

        public CustVendorUIMapper GetCustomerDetails(CustVendorUIMapper custVendorUI)
        {
            CustomerAddEditImpl customerImpl = new CustomerAddEditImpl();
            return customerImpl.GetCustomerDetails(custVendorUI);
        }

        public VenPayeeUIMapper GetVendorBankDetails(VenPayeeUIMapper custVendorUI)
        {
            CustomerAddEditImpl customerImpl = new CustomerAddEditImpl();
            return customerImpl.GetVendorBankDetails(custVendorUI);
        }

        public List<CustContactsUIMapper> GetCustomerContactDetails(CustContactsUIMapper custContactUI)
        {
            CustomerAddEditImpl customerImpl = new CustomerAddEditImpl();
            return customerImpl.GetCustomerContactDetails(custContactUI);
        }

        public DataSet GetCustomerScreenListValues()
        {
            CustomerAddEditImpl customerImpl = new CustomerAddEditImpl();
            return customerImpl.GetCustomerScreenListValues();
        }

        private void GetCustomerEmpName(CustContactsUIMapper custContVendor)
        {
            string NameSeq = custContVendor.cust_emp_name_seq;
 
            string[] empName = new  string[4];
            empName[0] = custContVendor.cust_emp_name_salutation;
            int index = NameSeq.IndexOf("F");
            if(index >= 0)
                empName[index + 1] =  custContVendor.cust_emp_name_family;
            index = NameSeq.IndexOf("M");
            if (index >= 0)
                empName[index + 1] = custContVendor.cust_emp_name_middle;
            index = NameSeq.IndexOf("G");
            if (index >= 0)
                empName[index + 1] = custContVendor.cust_emp_name_given;

            custContVendor.cust_emp_name = string.Join(" ", empName).Replace("  ", " ").Trim();
        }

        public string GetSalesmanName(string salesmanCode)
        {
            CustomerAddEditImpl customerImpl = new CustomerAddEditImpl();
            return customerImpl.GetSalesmanName(salesmanCode);
        }

    }
}
