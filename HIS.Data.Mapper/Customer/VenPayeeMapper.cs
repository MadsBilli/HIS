using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using DataAccess.SQL2008;
using HIS.Common;

namespace HIS.Data.Mapper.Customer
{
    public class VenPayeeMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_VENDOR_PAYEE_DETAILS, ParameterName = "@PayeeID", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.GET_VENDOR_BANK_DETAILS, ParameterName = "@PayeeID", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string PayeeID { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_VENDOR_PAYEE_DETAILS, ParameterName = "@PayeeName1", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string PayeeName1 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_VENDOR_PAYEE_DETAILS, ParameterName = "@PayeeName2", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string PayeeName2 { get; set; }
        public string PayeeAdd1 { get; set; }
        public string PayeeAdd2 { get; set; }
        public string PayeeAdd3 { get; set; }
        public string PayeeAdd4 { get; set; }
        public string PayeeFax { get; set; }
        public string PayeeNo { get; set; }
        public string PayeeContact { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_VENDOR_PAYEE_DETAILS, ParameterName = "@BankCode", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string BankCode { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_VENDOR_PAYEE_DETAILS, ParameterName = "@BankName", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string BankName { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_VENDOR_PAYEE_DETAILS, ParameterName = "@BankAdd1", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string BankAdd1 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_VENDOR_PAYEE_DETAILS, ParameterName = "@BankAdd2", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string BankAdd2 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_VENDOR_PAYEE_DETAILS, ParameterName = "@BankAdd3", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string BankAdd3 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_VENDOR_PAYEE_DETAILS, ParameterName = "@BankSwiftCode", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string BankSwiftCode { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_VENDOR_PAYEE_DETAILS, ParameterName = "@BankBranchCode", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string BankBranchCode { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_VENDOR_PAYEE_DETAILS, ParameterName = "@BankRoutingNo", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string BankRoutingNo { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_VENDOR_PAYEE_DETAILS, ParameterName = "@BankAccountNo", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string BankAccountNo { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_VENDOR_PAYEE_DETAILS, ParameterName = "@BankRemarks", ParameterType = SqlDbType.NVarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string BankRemarks { get; set; }
    }
}
