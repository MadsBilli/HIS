using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using HIS.Data.Mapper.EmployeeAdmin;
using HIS.Common;
using DataAccess.SQL2008;
using System.Reflection;

namespace HIS.DataAccess.EmployeeAdmin
{
    public class EmployeeAdminAddEditDA
    {
        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_EMPLOYEE_SCREEN_LIST_VALUES)]
        public DataSet GetEmployeeScreenListValues()
        {
            return new StoredProcedureCommandBuilder().ExecuteDataSet(
                                   (MethodInfo)MethodInfo.GetCurrentMethod(), null);
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.SAVE_EMPLOYEE_DETAILS)]
        public void SaveEmployeeDetails(EmployeeAdminMapper emp)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), emp);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_EMPLOYEE_DETAILS_FOR_GRID)]
        public List<EmployeeAdminMapper> GetEmployeeListForGrid()
        {
            var lsEmpMapper = new StoredProcedureCommandBuilder().GetEntities<EmployeeAdminMapper>(
                                    (MethodInfo)MethodInfo.GetCurrentMethod(), null);
            return lsEmpMapper.ToList();
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.DELETE_EMPLOYEE_DETAILS)]
        public void DeleteEmployeeDetails(EmployeeAdminMapper emp)
        {
            using (var scope = new TransactionScope())
            {
                int noOfRows = new StoredProcedureCommandBuilder().ExecuteNonQuery(
                                       (MethodInfo)MethodInfo.GetCurrentMethod(), emp);
                scope.Complete();
            }
        }

        [StoredProcedure(StoredProcedureName = StoredProcedureName.GET_EMPLOYEE_DETAILS)]
        public List<EmployeeAdminMapper> GetEmployeeDetails(EmployeeAdminMapper mapper)
        {
            var lsEmpMapper = new StoredProcedureCommandBuilder().GetEntities<EmployeeAdminMapper>(
                                    (MethodInfo)MethodInfo.GetCurrentMethod(), mapper);
            return lsEmpMapper.ToList();
        }

        public string GetEmpID(int statusid)
        {
            var command = new StoredProcedureCommandBuilder();
            AdhocStoredProcedureExecutionResult result =
                 command.ExecuteAdhocStoredProcedure(
                    StoredProcedureName.GET_EMPID, new List<AdhocStoredProcedureInputParameters>
                    {
                        new AdhocStoredProcedureInputParameters
                            {
                                ParameterName = "@TempStatusID",
                                ParameterDataType = SqlDbType.Int,
                                ParameterValue = statusid
                            } 
                    },
                    StoredProcedureEnums.StoredProcedureExecutionType.Scalar);

            var dsReturn = (string)result.ExecutionResult;

            return dsReturn;
        }
    }
}
