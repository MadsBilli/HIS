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


namespace HIS.Data.Mapper.SetUp
{
    public class AccessRightsMapper
    {
        public Int16 emp_sqno { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_ACCESSRIGHTS_DETAILS, ParameterName = "@emp_type", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.GET_ACCESSRIGHTS_DETAILS, ParameterName = "@emp_type", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public int emp_type { get; set; }
        public string emp_typedesc { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_ACCESSRIGHTS_DETAILS, ParameterName = "@fm_upc", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool fm_upc { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_ACCESSRIGHTS_DETAILS, ParameterName = "@fm_inventory", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool fm_inventory { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_ACCESSRIGHTS_DETAILS, ParameterName = "@fm_pos", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool fm_pos { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_ACCESSRIGHTS_DETAILS, ParameterName = "@fm_acc", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool fm_acc { get; set; }
        public bool fm_gen { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_ACCESSRIGHTS_DETAILS, ParameterName = "@fm_po", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool fm_po { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_ACCESSRIGHTS_DETAILS, ParameterName = "@fm_ven", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool fm_ven { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_ACCESSRIGHTS_DETAILS, ParameterName = "@fm_pur_inv", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool fm_pur_inv { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_ACCESSRIGHTS_DETAILS, ParameterName = "@fm_pay", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool fm_pay { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_ACCESSRIGHTS_DETAILS, ParameterName = "@fm_cust", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool fm_cust { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_ACCESSRIGHTS_DETAILS, ParameterName = "@fm_inv", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool fm_inv { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_ACCESSRIGHTS_DETAILS, ParameterName = "@fm_rec", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool fm_rec { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_ACCESSRIGHTS_DETAILS, ParameterName = "@fm_aging", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool fm_aging { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_ACCESSRIGHTS_DETAILS, ParameterName = "@fm_rpt", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool fm_rpt { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_ACCESSRIGHTS_DETAILS, ParameterName = "@fm_payroll", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool fm_payroll { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_ACCESSRIGHTS_DETAILS, ParameterName = "@fm_emp_admin", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool fm_emp_admin { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_ACCESSRIGHTS_DETAILS, ParameterName = "@fm_setup", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool fm_setup { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_ACCESSRIGHTS_DETAILS, ParameterName = "@fm_commission", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool fm_commission { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_ACCESSRIGHTS_DETAILS, ParameterName = "@fm_misc_gl", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool fm_misc_gl { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SAVE_ACCESSRIGHTS_DETAILS, ParameterName = "@fm_wo", ParameterType = SqlDbType.Bit, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public bool fm_wo { get; set; }
    }
}
