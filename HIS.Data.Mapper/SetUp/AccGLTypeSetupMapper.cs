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
    public class AccGLTypeSetupMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.GET_ACCGL_SETUP_DETAILS_BY_GLTYPE, ParameterName = "@GL_Type", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SET_ACCGL_SETUP_DETAILS, ParameterName = "@GL_Type", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SET_VENDOR_PURCHASES_DETAILS, ParameterName = "@gl_setup_type", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string gl_setup_type { get; set; }

        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SET_VENDOR_PURCHASES_DETAILS, ParameterName = "@gl_principal_bank", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string gl_principal_bank { get; set; }
        
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SET_ACCGL_SETUP_DETAILS, ParameterName = "@Value", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SET_VENDOR_PURCHASES_DETAILS, ParameterName = "@gl_acc_code", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string gl_acc_code { get; set; }
        
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SET_VENDOR_PURCHASES_DETAILS, ParameterName = "@gl_freight", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string gl_freight { get; set; }
        
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.SET_VENDOR_PURCHASES_DETAILS, ParameterName = "@gl_discount", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string gl_discount { get; set; }

    }
}
