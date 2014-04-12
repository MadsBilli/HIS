using DataAccess.SQL2008;
using HIS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Data.Mapper.SetUp
{
    public class BankAccountSetupMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.BANK_ACCT_NUM_SETUP_DETAILS_UPDATE, ParameterName = "@setup_id", ParameterType = SqlDbType.Int, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FINANCE_CTRL_PWD_UPDATE, ParameterName = "@setup_id", ParameterType = SqlDbType.Int, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public Int16 setup_id { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.BANK_ACCT_NUM_SETUP_DETAILS_UPDATE, ParameterName = "@BankAccountNumber", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string setup_value { get; set; }
        public string setup_rmk { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FINANCE_CTRL_PWD_UPDATE, ParameterName = "@FinanceCtrlPwd", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string setup_pw { get; set; }

        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FINANCE_SETUP_DETAILS_UPDATE, ParameterName = "@SGDBankAccountNumber", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string SGDBankAccountNumber { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FINANCE_SETUP_DETAILS_UPDATE, ParameterName = "@USDBankAccountNumber", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string USDBankAccountNumber { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FINANCE_SETUP_DETAILS_UPDATE, ParameterName = "@BankName", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string BankName { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FINANCE_SETUP_DETAILS_UPDATE, ParameterName = "@BankAdd1", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string BankAdd1 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FINANCE_SETUP_DETAILS_UPDATE, ParameterName = "@BankAdd2", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string BankAdd2 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FINANCE_SETUP_DETAILS_UPDATE, ParameterName = "@BankAdd3", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string BankAdd3 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FINANCE_SETUP_DETAILS_UPDATE, ParameterName = "@ShowRemitBankAccinInv", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string ShowRemitBankAccinInv { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FINANCE_SETUP_DETAILS_UPDATE, ParameterName = "@FinancialControlPW", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string FinancialControlPW { get; set; }
    }
}
