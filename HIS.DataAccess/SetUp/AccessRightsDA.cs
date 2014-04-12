using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using HIS.Data.Mapper.SetUp;
using HIS.Common;
using DataAccess.SQL2008;
using System.Reflection;

namespace HIS.DataAccess.SetUp
{
    public class AccessRightsDA
    {
        public DataSet GetEmpTypeForddl()
        {
            string query = string.Concat("Select emp_type, emp_typedesc from emptype");
            var command = new StoredProcedureCommandBuilder();
            var result = command.ExecuteQuery(query, StoredProcedureEnums.StoredProcedureExecutionType.DataSet);
            return result == null ? new DataSet() : (DataSet)result;
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.SAVE_ACCESSRIGHTS_DETAILS)]
        public void SaveAccessRightsDetails(AccessRightsMapper accessRights)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), accessRights);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_ACCESSRIGHTS_DETAILS)]
        public List<AccessRightsMapper> GetAccessRightDetails(AccessRightsMapper mapper)
        {
            var accessRightMapper = new StoredProcedureCommandBuilder().GetEntities<AccessRightsMapper>(
                                    (MethodInfo)MethodInfo.GetCurrentMethod(), mapper);
            return accessRightMapper.ToList();
        }

        public string CheckUserAccessRights(string accessRights, int Emp_Type, string emp_logName, out bool AllowAccess, out bool UserTerminated)
        {
            AllowAccess = false;
            UserTerminated = false;
            var command = new StoredProcedureCommandBuilder();
            AdhocStoredProcedureExecutionResult result =
                 command.ExecuteAdhocStoredProcedure(
                    StoredProcedureName.CHECK_ACCESSRIGHTS, new List<AdhocStoredProcedureInputParameters>
                    {
                        new AdhocStoredProcedureInputParameters
                            {
                                ParameterName = "@AccessRights",
                                ParameterDataType = SqlDbType.VarChar,
                                ParameterValue = accessRights
                            } ,
                            new AdhocStoredProcedureInputParameters
                            {
                                ParameterName = "@Emp_Type",
                                ParameterDataType = SqlDbType.Int,
                                ParameterValue = Emp_Type
                            } ,
                            new AdhocStoredProcedureInputParameters
                            {
                                ParameterName = "@emp_logName",
                                ParameterDataType = SqlDbType.VarChar,
                                ParameterValue = emp_logName
                            } ,
                            new AdhocStoredProcedureInputParameters
                            {
                                ParameterName = "@AllowAccess",
                                ParameterDataType = SqlDbType.Bit,
                                ParameterValue = AllowAccess,
                                ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.Out
                            } ,
                            new AdhocStoredProcedureInputParameters
                            {
                                ParameterName = "@UserTerminated",
                                ParameterDataType = SqlDbType.Bit,
                                ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.Out,
                                ParameterValue = UserTerminated
                            } 

                    },
                    StoredProcedureEnums.StoredProcedureExecutionType.Scalar);

            var dsReturn = (string)result.ExecutionResult;

            return dsReturn;
        }

        public AccessRightsMapper GetUserAccessRights(int Emp_Type, string emp_logName, out bool UserTerminated)
        {
            UserTerminated = false;
            var command = new StoredProcedureCommandBuilder();
            AdhocStoredProcedureExecutionResult result =
                 command.ExecuteAdhocStoredProcedure(
                    StoredProcedureName.GET_ACCESSRIGHTS, new List<AdhocStoredProcedureInputParameters>
                    { 
                            new AdhocStoredProcedureInputParameters
                            {
                                ParameterName = "@Emp_Type",
                                ParameterDataType = SqlDbType.Int,
                                ParameterValue = Emp_Type
                            } ,
                            new AdhocStoredProcedureInputParameters
                            {
                                ParameterName = "@emp_logName",
                                ParameterDataType = SqlDbType.VarChar,
                                ParameterValue = emp_logName
                            }   ,
                            new AdhocStoredProcedureInputParameters
                            {
                                ParameterName = "@UserTerminated",
                                ParameterDataType = SqlDbType.Bit,
                                ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.Out,
                                ParameterValue = UserTerminated
                            } 

                    },
                    StoredProcedureEnums.StoredProcedureExecutionType.DataSet);

            var dsReturn = (DataSet)result.ExecutionResult;

            DataRow dr = dsReturn.Tables[0].Rows[0];
            AccessRightsMapper obj = new AccessRightsMapper();
            obj.fm_upc = Convert.ToBoolean(dr["fm_upc"].ToString());
            obj.fm_inventory = Convert.ToBoolean(dr["fm_inventory"].ToString());
            obj.fm_acc = Convert.ToBoolean(dr["fm_acc"].ToString());
            obj.fm_misc_gl = Convert.ToBoolean(dr["fm_misc_gl"].ToString());
            obj.fm_po = Convert.ToBoolean(dr["fm_po"].ToString());
            obj.fm_ven = Convert.ToBoolean(dr["fm_ven"].ToString());
            obj.fm_pur_inv = Convert.ToBoolean(dr["fm_pur_inv"].ToString());
            obj.fm_pay = Convert.ToBoolean(dr["fm_pay"].ToString());
            obj.fm_cust = Convert.ToBoolean(dr["fm_cust"].ToString());
            obj.fm_inv = Convert.ToBoolean(dr["fm_inv"].ToString());
            obj.fm_rec = Convert.ToBoolean(dr["fm_rec"].ToString());
            obj.fm_aging = Convert.ToBoolean(dr["fm_aging"].ToString());
            obj.fm_rpt = Convert.ToBoolean(dr["fm_rpt"].ToString());
            obj.fm_payroll = Convert.ToBoolean(dr["fm_payroll"].ToString());
            obj.fm_emp_admin = Convert.ToBoolean(dr["fm_emp_admin"].ToString());
            obj.fm_setup = Convert.ToBoolean(dr["fm_setup"].ToString());
            obj.fm_commission = Convert.ToBoolean(dr["fm_commission"].ToString());
            obj.fm_wo = Convert.ToBoolean(dr["fm_wo"].ToString());

            return obj;
        }
    }
}
