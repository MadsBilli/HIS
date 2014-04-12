using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.UI.Mapper.Customer;
using HIS.Data.Mapper.Customer;
using HIS.DataAccess.Customer;
using HIS.Common;

namespace HIS.Implementation.Customer
{
    public class CustomerAddEditImpl
    {
        public DataSet GetCustomerScreenListValues()
        {
            CustomerAddEditDA customerDA = new CustomerAddEditDA();
            return customerDA.GetCustomerScreenListValues();
        }

        public void DeleteCustomerAndContactDetails(CustVendorUIMapper custVendor)
        {
            CustVendorMapper mapper = new CustVendorMapper
            {
                cust_id = custVendor.cust_id
            };

            CustomerAddEditDA customerDA = new CustomerAddEditDA();
            customerDA.DeleteCustomerAndContactDetails(mapper);
        }
        public void InsertCustomerDetails(CustVendorUIMapper custVendor)
        {
            CustVendorMapper mapper = new CustVendorMapper
            {
                cust_id = custVendor.cust_id,
                cust_name = custVendor.cust_name,
                cust_add1 = custVendor.cust_add1,
                cust_add2 = custVendor.cust_add2,
                cust_add3 = custVendor.cust_add3,
                cust_add4 = custVendor.cust_add4,
                cust_add5 = custVendor.cust_add5,
                cust_br_add1 = custVendor.cust_br_add1,
                cust_br_add2 = custVendor.cust_br_add2,
                cust_br_add3 = custVendor.cust_br_add3,
                cust_br_add4 = custVendor.cust_br_add4,
                cust_terms = custVendor.cust_terms,
                cust_creditlimit = custVendor.cust_creditlimit,
                cust_type = custVendor.cust_type,
                cust_blacklisted = custVendor.cust_blacklisted,
                cust_rmk = custVendor.cust_rmk,
                cust_inactive = custVendor.cust_inactive,
                cust_company_type = custVendor.cust_company_type,
                cust_Nature = custVendor.cust_Nature,
                cust_emp_no = custVendor.cust_emp_no,
                cust_payup = custVendor.cust_payup,
                cust_tradedebtor = custVendor.cust_tradedebtor,
                cust_pos_price_grp = custVendor.cust_pos_price_grp,
                cust_revenue_acc_code = custVendor.cust_revenue_acc_code,
                cust_salesman_code = custVendor.cust_salesman_code,
                cust_emp_name = custVendor.cust_emp_name,
                cust_emp_tel_area_code = custVendor.cust_emp_tel_area_code,
                cust_emp_tel = custVendor.cust_emp_tel,
                cust_emp_fax_area_code = custVendor.cust_emp_fax_area_code,
                cust_emp_fax = custVendor.cust_emp_fax,
                cust_emp_email = custVendor.cust_emp_email,
                cust_intrmk = custVendor.cust_intrmk,
                cust_CreatedBy = custVendor.cust_CreatedBy,
                cust_Created = custVendor.cust_Created,
                cust_updated = custVendor.cust_updated,
                cust_updatedby = custVendor.cust_updatedby
            };

            CustomerAddEditDA customerDA = new CustomerAddEditDA();
            customerDA.InsertCustomerDetails(mapper);

            custVendor.cust_id = mapper.cust_id;
        }

        public List<CustVendorUIMapper> GetCustomerList()
        {
            CustomerAddEditDA customerDA = new CustomerAddEditDA();
            var lsCustVendorMapper = customerDA.GetCustomerList();

            var res = GetCustVendorUIMapper(lsCustVendorMapper);
            return res;

        }

        public List<CustVendorUIMapper> GetVendorList()
        {
            CustomerAddEditDA customerDA = new CustomerAddEditDA();
            var lsCustVendorMapper = customerDA.GetVendorList();

            var res = GetCustVendorUIMapper(lsCustVendorMapper);
            return res;

        }

        public CustVendorUIMapper GetCustomerDetails(CustVendorUIMapper custVendorUI)
        {
            CustomerAddEditDA customerDA = new CustomerAddEditDA();
            CustVendorMapper custVendor = new CustVendorMapper();
            custVendor.cust_id = custVendorUI.cust_id;
            var lsCustVendorMapper = customerDA.GetCustomerDetails(custVendor);

            var res = GetCustVendorUIMapper(lsCustVendorMapper);
            return res.FirstOrDefault();

        }

        public VenPayeeUIMapper GetVendorBankDetails(VenPayeeUIMapper custVendorUI)
        {
            CustomerAddEditDA customerDA = new CustomerAddEditDA();
            VenPayeeMapper custVendor = new VenPayeeMapper();
            custVendor.PayeeID = custVendorUI.PayeeID;
            var lsCustVendorMapper = customerDA.GetVendorBankDetails(custVendor);

            var res = GetVendorPayeeUIMapper(lsCustVendorMapper);
            return res.FirstOrDefault();

        }

        public List<CustContactsUIMapper> GetCustomerContactDetails(CustContactsUIMapper custContactUI)
        {
            CustomerAddEditDA customerDA = new CustomerAddEditDA();
            CustContactsMapper custContact = new CustContactsMapper();
            custContact.cust_id = custContactUI.cust_id;
            var lsCustContactMapper = customerDA.GetCustomerContactDetails(custContact);

            var res = GetCustContactUIMapper(lsCustContactMapper);
            return res;

        }

        public void InsertCustomerContactDetails(CustContactsUIMapper contacts)
        {

            CustContactsMapper mapper = new CustContactsMapper
            {
                cust_id = contacts.cust_id,
                cust_emp_id = contacts.cust_emp_id,
                cust_emp_name_seq = contacts.cust_emp_name_seq,
                cust_emp_gender = contacts.cust_emp_gender,
                cust_emp_name_salutation = contacts.cust_emp_name_salutation,
                cust_emp_name_given = contacts.cust_emp_name_given,
                cust_emp_name_family = contacts.cust_emp_name_family,
                cust_emp_name_middle = contacts.cust_emp_name_middle,
                cust_emp_name = contacts.cust_emp_name,
                cust_emp_level = contacts.cust_emp_level,
                cust_emp_dept = contacts.cust_emp_dept,
                cust_emp_title = contacts.cust_emp_title,
                cust_emp_tel_area_code = contacts.cust_emp_tel_area_code,
                cust_emp_tel = contacts.cust_emp_tel,
                cust_emp_tel_ext = contacts.cust_emp_tel_ext,
                cust_emp_hp_area_code = contacts.cust_emp_hp_area_code,
                cust_emp_hp = contacts.cust_emp_hp,
                cust_emp_fax_area_code = contacts.cust_emp_fax_area_code,
                cust_emp_fax = contacts.cust_emp_fax,
                cust_emp_email = contacts.cust_emp_email,
                cust_emp_add1 = contacts.cust_emp_add1,
                cust_emp_add2 = contacts.cust_emp_add2,
                cust_emp_add3 = contacts.cust_emp_add3,
                cust_emp_add4 = contacts.cust_emp_add4,
                cust_emp_add5 = contacts.cust_emp_add5,
                cust_emp_contact_source = contacts.cust_emp_contact_source,
                cust_emp_region = contacts.cust_emp_region,
                cust_emp_create_bu = contacts.cust_emp_create_bu,
                cust_emp_left = contacts.cust_emp_left,
                cust_emp_type = contacts.cust_emp_type,
                cust_emp_contact_type = contacts.cust_emp_contact_type,
                cust_emp_prefer_comm = contacts.cust_emp_prefer_comm,
                cust_emp_fax_oth_area_code = contacts.cust_emp_fax_oth_area_code,
                cust_emp_tel_asst_area_code = contacts.cust_emp_tel_asst_area_code,
                cust_emp_fax_oth = contacts.cust_emp_fax_oth,
                cust_emp_asst_name = contacts.cust_emp_asst_name,
                cust_emp_manager_name = contacts.cust_emp_manager_name,
                cust_emp_tel_asst = contacts.cust_emp_tel_asst,
                cust_emp_tel_asst_ext = contacts.cust_emp_tel_asst_ext,
                cust_emp_email2 = contacts.cust_emp_email2,
                cust_emp_rmk = contacts.cust_emp_rmk,
                cust_emp_relationship_rmk = contacts.cust_emp_relationship_rmk,
                cust_contact_opreration = contacts.cust_contact_opreration,
                cust_emp_update_by = contacts.cust_emp_update_by,
                cust_emp_create_datestamp = contacts.cust_emp_create_datestamp,
                cust_emp_update_datestamp = contacts.cust_emp_update_datestamp
            };
            CustomerAddEditDA customerDA = new CustomerAddEditDA();
            customerDA.InsertCustomerContactDetails(mapper);
        }

        public void SaveVenPayeeDetails(VenPayeeUIMapper payee)
        {

            VenPayeeMapper mapper = new VenPayeeMapper
            {
                PayeeID = payee.PayeeID,
                PayeeName1 = payee.PayeeName1,
                PayeeName2 = payee.PayeeName2,
                PayeeAdd1 = payee.PayeeAdd1,
                PayeeAdd2 = payee.PayeeAdd2,
                PayeeAdd3 = payee.PayeeAdd3,
                PayeeAdd4 = payee.PayeeAdd4,
                PayeeFax = payee.PayeeFax,
                PayeeNo = payee.PayeeNo,
                PayeeContact = payee.PayeeContact,
                BankCode = payee.BankCode,
                BankName = payee.BankName,
                BankAdd1 = payee.BankAdd1,
                BankAdd2 = payee.BankAdd2,
                BankAdd3 = payee.BankAdd3,
                BankSwiftCode = payee.BankSwiftCode,
                BankBranchCode = payee.BankBranchCode,
                BankRoutingNo = payee.BankRoutingNo,
                BankAccountNo = payee.BankAccountNo,
                BankRemarks = payee.BankRemarks 
            };
            CustomerAddEditDA customerDA = new CustomerAddEditDA();
            customerDA.SaveVenPayeeDetails(mapper);
        }

        public string GetSalesmanName(string salesmanCode)
        {
            CustomerAddEditDA customerDA = new CustomerAddEditDA();
            return customerDA.GetSalesmanName(salesmanCode);
        }

        private List<CustVendorUIMapper> GetCustVendorUIMapper(List<CustVendorMapper> lsCustVendorMapper)
        {
            var res = (from custVendor in lsCustVendorMapper
                       select new CustVendorUIMapper
                       {
                           cust_id = custVendor.cust_id,
                           cust_name = custVendor.cust_name,
                           cust_add1 = custVendor.cust_add1,
                           cust_add2 = custVendor.cust_add2,
                           cust_add3 = custVendor.cust_add3,
                           cust_add4 = custVendor.cust_add4,
                           cust_add5 = custVendor.cust_add5,
                           cust_br_add1 = custVendor.cust_br_add1,
                           cust_br_add2 = custVendor.cust_br_add2,
                           cust_br_add3 = custVendor.cust_br_add3,
                           cust_br_add4 = custVendor.cust_br_add4,
                           cust_terms = custVendor.cust_terms,
                           cust_creditlimit = custVendor.cust_creditlimit,
                           cust_type = custVendor.cust_type,
                           cust_blacklisted = custVendor.cust_blacklisted,
                           cust_rmk = custVendor.cust_rmk,
                           cust_inactive = custVendor.cust_inactive,
                           cust_company_type = custVendor.cust_company_type,
                           cust_Nature = custVendor.cust_Nature,
                           cust_emp_no = custVendor.cust_emp_no,
                           cust_payup = custVendor.cust_payup,
                           cust_tradedebtor = custVendor.cust_tradedebtor,
                           cust_pos_price_grp = custVendor.cust_pos_price_grp,
                           cust_revenue_acc_code = custVendor.cust_revenue_acc_code,
                           cust_salesman_code = custVendor.cust_salesman_code,
                           cust_emp_name = custVendor.cust_emp_name,
                           cust_emp_tel_area_code = custVendor.cust_emp_tel_area_code,
                           cust_emp_tel = custVendor.cust_emp_tel,
                           cust_emp_fax_area_code = custVendor.cust_emp_fax_area_code,
                           cust_emp_fax = custVendor.cust_emp_fax,
                           cust_emp_email = custVendor.cust_emp_email,
                           cust_intrmk = custVendor.cust_intrmk,
                           cust_CreatedBy = custVendor.cust_CreatedBy,
                           cust_Created = custVendor.cust_Created,
                           YTD_Owing = custVendor.YTD_Owing,
                           YTD_Sales = custVendor.YTD_Sales
                       }).ToList();
            return res;
        }

        private List<CustContactsUIMapper> GetCustContactUIMapper(List<CustContactsMapper> lsCustContactMapper)
        {
            var res = (from contacts in lsCustContactMapper
                       select new CustContactsUIMapper
                       {
                           cust_id = contacts.cust_id,
                           cust_emp_id = contacts.cust_emp_id,
                           cust_emp_name_seq = contacts.cust_emp_name_seq,
                           cust_emp_gender = contacts.cust_emp_gender,
                           cust_emp_name_salutation = contacts.cust_emp_name_salutation,
                           cust_emp_name_given = contacts.cust_emp_name_given,
                           cust_emp_name_family = contacts.cust_emp_name_family,
                           cust_emp_name_middle = contacts.cust_emp_name_middle,
                           cust_emp_name = contacts.cust_emp_name,
                           cust_emp_level = contacts.cust_emp_level,
                           cust_emp_dept = contacts.cust_emp_dept,
                           cust_emp_title = contacts.cust_emp_title,
                           cust_emp_tel_area_code = contacts.cust_emp_tel_area_code,
                           cust_emp_tel = contacts.cust_emp_tel,
                           cust_emp_tel_ext = contacts.cust_emp_tel_ext,
                           cust_emp_hp_area_code = contacts.cust_emp_hp_area_code,
                           cust_emp_hp = contacts.cust_emp_hp,
                           cust_emp_fax_area_code = contacts.cust_emp_fax_area_code,
                           cust_emp_fax = contacts.cust_emp_fax,
                           cust_emp_email = contacts.cust_emp_email,
                           cust_emp_add1 = contacts.cust_emp_add1,
                           cust_emp_add2 = contacts.cust_emp_add2,
                           cust_emp_add3 = contacts.cust_emp_add3,
                           cust_emp_add4 = contacts.cust_emp_add4,
                           cust_emp_add5 = contacts.cust_emp_add5,
                           cust_emp_contact_source = contacts.cust_emp_contact_source,
                           cust_emp_region = contacts.cust_emp_region,
                           cust_emp_create_bu = contacts.cust_emp_create_bu,
                           cust_emp_left = contacts.cust_emp_left,
                           cust_emp_type = contacts.cust_emp_type,
                           cust_emp_contact_type = contacts.cust_emp_contact_type,
                           cust_emp_prefer_comm = contacts.cust_emp_prefer_comm,
                           cust_emp_fax_oth_area_code = contacts.cust_emp_fax_oth_area_code,
                           cust_emp_tel_asst_area_code = contacts.cust_emp_tel_asst_area_code,
                           cust_emp_fax_oth = contacts.cust_emp_fax_oth,
                           cust_emp_asst_name = contacts.cust_emp_asst_name,
                           cust_emp_manager_name = contacts.cust_emp_manager_name,
                           cust_emp_tel_asst = contacts.cust_emp_tel_asst,
                           cust_emp_tel_asst_ext = contacts.cust_emp_tel_asst_ext,
                           cust_emp_email2 = contacts.cust_emp_email2,
                           cust_emp_rmk = contacts.cust_emp_rmk,
                           cust_emp_relationship_rmk = contacts.cust_emp_relationship_rmk,
                           cust_contact_opreration = contacts.cust_contact_opreration,
                           cust_emp_update_by = contacts.cust_emp_update_by,
                           cust_emp_create_datestamp = contacts.cust_emp_create_datestamp,
                           cust_emp_update_datestamp = contacts.cust_emp_update_datestamp
                       }).ToList();
            return res;
        }

        private List<VenPayeeUIMapper> GetVendorPayeeUIMapper(List<VenPayeeMapper> lsCustContactMapper)
        {
            var res = (from payee in lsCustContactMapper
                       select new VenPayeeUIMapper
                       {
                           PayeeID = payee.PayeeID,
                           PayeeName1 = payee.PayeeName1,
                           PayeeName2 = payee.PayeeName2,
                           PayeeAdd1 = payee.PayeeAdd1,
                           PayeeAdd2 = payee.PayeeAdd2,
                           PayeeAdd3 = payee.PayeeAdd3,
                           PayeeAdd4 = payee.PayeeAdd4,
                           PayeeFax = payee.PayeeFax,
                           PayeeNo = payee.PayeeNo,
                           PayeeContact = payee.PayeeContact,
                           BankCode = payee.BankCode,
                           BankName = payee.BankName,
                           BankAdd1 = payee.BankAdd1,
                           BankAdd2 = payee.BankAdd2,
                           BankAdd3 = payee.BankAdd3,
                           BankSwiftCode = payee.BankSwiftCode,
                           BankBranchCode = payee.BankBranchCode,
                           BankRoutingNo = payee.BankRoutingNo,
                           BankAccountNo = payee.BankAccountNo,
                           BankRemarks = payee.BankRemarks 
                       }).ToList();
            return res;
        }


    }
}
