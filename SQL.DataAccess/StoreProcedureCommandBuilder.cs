using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Configuration;
using System.Data.Sql;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Data.SqlClient;

namespace DataAccess.SQL2008
{
    public class StoredProcedureCommandBuilder
    {
        private SqlDatabase sqlDB;
        private Dictionary<string, PropertyInfo> outputParameterName;
        private string defaultConnectionString;

        public int? CommandTimeOut
        {
            get;
            set;
        }

        public StoredProcedureCommandBuilder()
        {
            try
            {
                DatabaseSettings settings = DatabaseSettings.GetDatabaseSettings(new SystemConfigurationSource());
                string connectionName = settings.DefaultDatabase;
               // CommandTimeOut = 0;
                defaultConnectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;

                sqlDB = new SqlDatabase(defaultConnectionString);

            }
            catch (SqlException ex)
            {
                LogException(ex.Message, ex.StackTrace, "ExecuteNonQuery");
                throw ex;
            }
            catch (Exception ex)
            {
                LogException(ex.Message ,ex.StackTrace, "StoredProcedureCommandBuilder");
                throw new Exception(ex.Message);
            }


        }

        public StoredProcedureCommandBuilder(string configurationName)
        {

            try
            {
                sqlDB = new SqlDatabase(configurationName);
            }
            catch (SqlException ex)
            {
                LogException(ex.Message, ex.StackTrace, "ExecuteNonQuery");
                throw ex;
            }
            catch (Exception ex)
            {
                LogException(ex.Message ,ex.StackTrace, "StoredProcedureCommandBuilder");
                throw new Exception(ex.Message);
            }


        }

        public StoredProcedureCommandBuilder(SqlDatabase existingDB)
        {
            try
            {
                sqlDB = existingDB;
            }
            catch (SqlException ex)
            {
                LogException(ex.Message, ex.StackTrace, "ExecuteNonQuery");
                throw ex;
            }
            catch (Exception ex)
            {
                LogException(ex.Message ,ex.StackTrace, "StoredProcedureCommandBuilder");
                throw new Exception(ex.Message);

            }

        }

        private string GetStoredProcedureName(MethodInfo methodInfo)
        {
            var spAttribs = methodInfo.GetCustomAttributes(typeof(StoredProcedureAttribute), true);
            var spName = "";

            if (spAttribs.Count() == 0)
                throw new Exception("Method is not mapped with Stored Procedure attribute");
            else
                spName = ((StoredProcedureAttribute)spAttribs[0]).StoredProcedureName.ToLower();

            return spName;
        }

        ///// <summary>
        ///// Construct DbCommand with parameters based on entity attributes
        ///// </summary>
        ///// <param name="spName"></param>
        ///// <param name="parameters"></param>
        ///// <returns></returns>
        //private DbCommand ConstructDbCommand(string spName, object parameters)
        //{
        //    if (parameters == null)
        //        return sqlDB.GetStoredProcCommand(spName);

        //    var queryProperties = parameters.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
        //            .Where(propInfo => propInfo.GetCustomAttributes(typeof(StoredProcedureParameterAttribute), true)
        //                                .Cast<StoredProcedureParameterAttribute>()
        //                                .Where(spAttrib => spAttrib.StoredProcedureName.ToLower() == spName.ToLower()).Count() > 0
        //                   );

        //    var cmd = sqlDB.GetStoredProcCommand(spName);


        //    foreach (var propInfo in queryProperties)
        //    {
        //        var queryAttrib = propInfo.GetCustomAttributes(typeof(StoredProcedureParameterAttribute), true)
        //            .Cast<StoredProcedureParameterAttribute>()
        //            .Where(attrib => attrib.StoredProcedureName.ToLower() == spName.ToLower());


        //        foreach (var attrib in queryAttrib)
        //        {
        //            object propertyValue = null;
        //            switch (attrib.ParameterDirection)
        //            {

        //                case StoredProcedureEnums.StoredProcedureParameterDirection.In:
        //                    propertyValue = propInfo.GetValue(parameters, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, null, null, null);
        //                    sqlDB.AddInParameter(cmd, attrib.ParameterName, attrib.ParameterType, propertyValue);
        //                    break;
        //                case StoredProcedureEnums.StoredProcedureParameterDirection.Out:
        //                    sqlDB.AddOutParameter(cmd, attrib.ParameterName, attrib.ParameterType, attrib.Size);
        //                    outputParameterName[attrib.ParameterName] = propInfo;
        //                    break;
        //                case StoredProcedureEnums.StoredProcedureParameterDirection.InOut:
        //                    propertyValue = propInfo.GetValue(parameters, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, null, null, null);
        //                    sqlDB.AddParameter(cmd, attrib.ParameterName, attrib.ParameterType, attrib.Size, ParameterDirection.InputOutput, true, attrib.Precision, attrib.Scale, attrib.ParameterName, DataRowVersion.Default, propertyValue);
        //                    outputParameterName[attrib.ParameterName] = propInfo;
        //                    break;
        //            }
        //        }
        //    }

        //    return cmd;
        //}


        /// <summary>
        /// Construct DbCommand with parameters based on entity attributes
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private DbCommand ConstructDbCommand(string spName, object parameters)
        {
            if (parameters == null)
            {
                var cmd1 = sqlDB.GetStoredProcCommand(spName);
                if (this.CommandTimeOut != null)
                    cmd1.CommandTimeout = (int)this.CommandTimeOut;
                return cmd1;
            }


            var queryProperties = parameters.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
                    .Where(propInfo => propInfo.GetCustomAttributes(typeof(StoredProcedureParameterAttribute), true)
                                        .Cast<StoredProcedureParameterAttribute>()
                                        .Where(spAttrib => spAttrib.StoredProcedureName.ToLower() == spName.ToLower()).Count() > 0
                           );

            var cmd = sqlDB.GetStoredProcCommand(spName);
            if (this.CommandTimeOut != null)
                cmd.CommandTimeout = (int)this.CommandTimeOut;

            foreach (var propInfo in queryProperties)
            {
                var queryAttrib = propInfo.GetCustomAttributes(typeof(StoredProcedureParameterAttribute), true)
                    .Cast<StoredProcedureParameterAttribute>()
                    .Where(attrib => attrib.StoredProcedureName.ToLower() == spName.ToLower());


                foreach (var attrib in queryAttrib)
                {
                    object propertyValue = null;
                    switch (attrib.ParameterDirection)
                    {

                        case StoredProcedureEnums.StoredProcedureParameterDirection.In:
                            propertyValue = propInfo.GetValue(parameters, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, null, null, null);
                            sqlDB.AddInParameter(cmd, attrib.ParameterName, attrib.ParameterType, propertyValue);
                            break;
                        case StoredProcedureEnums.StoredProcedureParameterDirection.Out:
                            sqlDB.AddOutParameter(cmd, attrib.ParameterName, attrib.ParameterType, attrib.Size);
                            outputParameterName[attrib.ParameterName] = propInfo;
                            break;
                        case StoredProcedureEnums.StoredProcedureParameterDirection.InOut:
                            propertyValue = propInfo.GetValue(parameters, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, null, null, null);
                            sqlDB.AddParameter(cmd, attrib.ParameterName, attrib.ParameterType, attrib.Size, ParameterDirection.InputOutput, true, attrib.Precision, attrib.Scale, attrib.ParameterName, DataRowVersion.Default, propertyValue);
                            outputParameterName[attrib.ParameterName] = propInfo;
                            break;
                    }
                }
            }

            return cmd;
        }


        private DbCommand ConstructDbCommand(string spName, string ParameterName, DbType ParameterType, object parameter)
        {
            if (parameter == null)
                return sqlDB.GetStoredProcCommand(spName);

            var cmd = sqlDB.GetStoredProcCommand(spName);
            sqlDB.AddInParameter(cmd, ParameterName, ParameterType, parameter);
            return cmd;
        }

        /// <summary>
        /// Assign entity property values from stored procedure parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="cmd"></param>
        private void SetOutputParameters(object parameters, DbCommand cmd)
        {
            if (parameters == null)
                return;

            foreach (var entry in outputParameterName)
            {
                var outParam = sqlDB.GetParameterValue(cmd, entry.Key);

                if (outParam == DBNull.Value)
                {
                    entry.Value.SetValue(parameters, null, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, null, null, null);
                }
                else
                    entry.Value.SetValue(parameters, outParam, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, null, null, null);
            }
        }

        #region ExecuteNonQuery
        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <param name="parameters"></param>
        /// <returns>Number of rows affected</returns>
        public int ExecuteNonQuery(MethodInfo methodInfo, object parameters)
        {
            return ExecuteNonQuery(GetStoredProcedureName(methodInfo), parameters);
        }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="parameters"></param>
        /// <returns>Number of rows affected</returns>
        public int ExecuteNonQuery(string spName, object parameters)
        {
            int returnValue = 0;
            try
            {
                outputParameterName = new Dictionary<string, PropertyInfo>();
                var cmd = ConstructDbCommand(spName, parameters);
                cmd.CommandTimeout = 0;
                returnValue = sqlDB.ExecuteNonQuery(cmd);
                SetOutputParameters(parameters, cmd);
            }
            catch (SqlException ex)
            {
                LogException(ex.Message, ex.StackTrace, "ExecuteNonQuery");
                throw ex;
            }
            catch (Exception ex)
            {
                LogException(ex.Message ,ex.StackTrace, "ExecuteNonQuery");
                throw new Exception(ex.Message);
            }


            return returnValue;
        }
        #endregion

        #region ExecuteScalar
        /// <summary>
        /// ExecuteScalar
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <param name="parameters"></param>
        /// <returns>Stored Procedure result</returns>
        public object ExecuteScalar(MethodInfo methodInfo, object parameters)
        {
            return ExecuteScalar(GetStoredProcedureName(methodInfo), parameters);
        }

        /// <summary>
        /// ExecuteScalar
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="parameters"></param>
        /// <returns>Stored Procedure result</returns>
        public object ExecuteScalar(string spName, object parameters)
        {

            object returnValue = null;
            try
            {
                outputParameterName = new Dictionary<string, PropertyInfo>();
                var cmd = ConstructDbCommand(spName, parameters);
                cmd.CommandTimeout = 0;
                returnValue = sqlDB.ExecuteScalar(cmd);
                SetOutputParameters(parameters, cmd);


            }
            catch (SqlException ex)
            {
                LogException(ex.Message, ex.StackTrace, "ExecuteNonQuery");
                throw ex;
            }
            catch (Exception ex)
            {
                LogException(ex.Message ,ex.StackTrace, "ExecuteScalar");
                throw new Exception(ex.Message);

            }
            return returnValue;

        }
        #endregion

        /// <summary>
        /// Execute inline Query
        /// </summary>
        /// <returns>Stored Procedure result</returns>
        public object ExecuteQuery(string query, StoredProcedureEnums.StoredProcedureExecutionType executionType)
        {

            try
            {
                var cmd = sqlDB.GetSqlStringCommand(query);
                if (this.CommandTimeOut != null)
                    cmd.CommandTimeout = (int)this.CommandTimeOut;
                object executionResult = null;

                switch (executionType)
                {
                    case StoredProcedureEnums.StoredProcedureExecutionType.DataReader:
                        executionResult = sqlDB.ExecuteReader(cmd);
                        break;
                    case StoredProcedureEnums.StoredProcedureExecutionType.DataSet:
                        executionResult = sqlDB.ExecuteDataSet(cmd);
                        break;
                    case StoredProcedureEnums.StoredProcedureExecutionType.NonQuery:
                        executionResult = sqlDB.ExecuteNonQuery(cmd);
                        break;
                    case StoredProcedureEnums.StoredProcedureExecutionType.Scalar:
                        executionResult = sqlDB.ExecuteScalar(cmd);
                        break;
                }

               
                var returnValue = new AdhocStoredProcedureExecutionResult
                {
                    ExecutionResult = executionResult 
                    
                };


                return returnValue.ExecutionResult;
            }
            catch (SqlException ex)
            {
                LogException(ex.Message, ex.StackTrace, "ExecuteNonQuery");
                throw ex;
            }
            catch (Exception ex)
            {
                LogException(ex.Message, ex.StackTrace, "ExecuteAdhocStoredProcedure");
                throw new Exception(ex.Message);

            }


        }

        #region ExecuteDataSet
        /// <summary>
        /// ExecuteDataSet
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <param name="parameters"></param>
        /// <returns>Result in DataSet</returns>
        public DataSet ExecuteDataSet(MethodInfo methodInfo, object parameters)
        {
            return ExecuteDataSet(GetStoredProcedureName(methodInfo), parameters);
        }

        /// <summary>
        /// ExecuteDataSet
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="parameters"></param>
        /// <returns>Result in DataSet</returns>
        public DataSet ExecuteDataSet(string spName, object parameters)
        {
            DataSet returnValue = null;


            try
            {
                outputParameterName = new Dictionary<string, PropertyInfo>();
                var cmd = ConstructDbCommand(spName, parameters);
                cmd.CommandTimeout = 0;
                returnValue = sqlDB.ExecuteDataSet(cmd);
                SetOutputParameters(parameters, cmd);
            }
            catch (SqlException ex)
            {
                LogException(ex.Message, ex.StackTrace, "ExecuteNonQuery");
                throw ex;
            }
            catch (Exception ex)
            {
                LogException(ex.Message ,ex.StackTrace, "ExecuteDataSet");
                throw new Exception(ex.Message);

            }
            return returnValue;


        }

        public DataSet ExecuteDataSet(string spName, string ParameterName, DbType ParameterType, object parameterValue)
        {
            DataSet returnValue = null;
            try
            {
                outputParameterName = new Dictionary<string, PropertyInfo>();

                var cmd = ConstructDbCommand(spName, ParameterName, ParameterType, parameterValue);
                cmd.CommandTimeout = 0;
                returnValue = sqlDB.ExecuteDataSet(cmd);
                SetOutputParameters(parameterValue, cmd);
            }
            catch (SqlException ex)
            {
                LogException(ex.Message, ex.StackTrace, "ExecuteNonQuery");
                throw ex;
            }
            catch (Exception ex)
            {
                LogException(ex.Message ,ex.StackTrace, "ExecuteDataSet");
                throw new Exception(ex.Message);

            }



            return returnValue;
        }
        #endregion

        #region GetEntities
        /// <summary>
        /// Get entities from DataTable
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public IEnumerable<T> GetEntities<T>(DataTable dt)
        {
            if (dt == null)
            {
                return null;
            }


            try
            {


                List<T> returnValue = new List<T>();
                List<string> typeProperties = new List<string>();

                T typeInstance = Activator.CreateInstance<T>();

                foreach (DataColumn column in dt.Columns)
                {
                    var prop = typeInstance.GetType().GetProperty(column.ColumnName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                    if (prop != null)
                    {
                        typeProperties.Add(column.ColumnName);
                    }
                }

                foreach (DataRow row in dt.Rows)
                {
                    T entity = Activator.CreateInstance<T>();

                    foreach (var propertyName in typeProperties)
                    {

                        if (row[propertyName] != DBNull.Value)
                            entity.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).SetValue(entity, row[propertyName], BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, null, null, null);
                        else
                            entity.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).SetValue(entity, null, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, null, null, null);
                    }

                    returnValue.Add(entity);
                }

                return returnValue.AsEnumerable();

            }
            catch (SqlException ex)
            {
                LogException(ex.Message, ex.StackTrace, "ExecuteNonQuery");
                throw ex;
            }
            catch (Exception ex)
            {
                LogException(ex.Message ,ex.StackTrace, "GetEntities<T>");
                throw new Exception(ex.Message);

            }

        }

        /// <summary>
        /// Get entities
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <param name="parameters"></param>
        /// <returns>Enumerable of entities</returns>
        public IEnumerable<T> GetEntities<T>(MethodInfo methodInfo, object parameters)
        {
            return GetEntities<T>(GetStoredProcedureName(methodInfo), parameters);
        }

        /// <summary>
        /// Get entities
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="parameters"></param>
        /// <returns>Enumerable of entities</returns>
        public IEnumerable<T> GetEntities<T>(string spName, object parameters)
        {
            outputParameterName = new Dictionary<string, PropertyInfo>();
            try
            {
                var cmd = ConstructDbCommand(spName, parameters);
                var result = sqlDB.ExecuteDataSet(cmd);
                SetOutputParameters(parameters, cmd);


                if (result != null)
                {
                    if (result.Tables.Count == 1)
                        return this.GetEntities<T>(((DataSet)result).Tables[0]);
                    else
                        return null;
                }
                else
                    return null;

            }
            catch (SqlException ex)
            {
                LogException(ex.Message, ex.StackTrace, "ExecuteNonQuery");
                throw ex;
            }
            catch (Exception ex)
            {
                LogException(ex.Message ,ex.StackTrace, "GetEntities<T>");
                throw new Exception(ex.Message);
            }


        }

        public IEnumerable<T> GetEntities<T>(string spName, string ParameterName, DbType ParameterType, object parameterValue)
        {
            outputParameterName = new Dictionary<string, PropertyInfo>();
            try
            {
                var cmd = ConstructDbCommand(spName, ParameterName, ParameterType, parameterValue);
                var result = sqlDB.ExecuteDataSet(cmd);
                SetOutputParameters(parameterValue, cmd);
                if (result != null)
                {
                    if (result.Tables.Count == 1)
                        return this.GetEntities<T>(((DataSet)result).Tables[0]);
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                LogException(ex.Message, ex.StackTrace, "ExecuteNonQuery");
                throw ex;
            }
            catch (Exception ex)
            {
                LogException(ex.Message ,ex.StackTrace, "GetEntities<T>");
                throw new Exception(ex.Message);
            }

        }

        #endregion

        #region ExecuteAdhocStoredProcedure
        /////// <summary>
        /////// Execute stored procedure without entity as parameters
        /////// </summary>
        /////// <param name="storedProcedureName">Name of stored procedure</param>
        /////// <param name="parameters">Input parameter</param>
        /////// <param name="executionType">Type of execution</param>
        /////// <returns>Result of execution</returns>
        ////public AdhocStoredProcedureExecutionResult ExecuteAdhocStoredProcedure(string storedProcedureName, List<AdhocStoredProcedureInputParameters> parameters, StoredProcedureEnums.StoredProcedureExecutionType executionType)
        ////{
        ////    try
        ////    {
        ////        var cmd = sqlDB.GetStoredProcCommand(storedProcedureName);
        ////        cmd.CommandTimeout = 0;
        ////        var outputParamName = new List<string>();
        ////        object executionResult = null;

        ////        if (parameters != null)
        ////        {
        ////            foreach (var inputParam in parameters)
        ////            {
        ////                switch (inputParam.ParameterDirection)
        ////                {
        ////                    case StoredProcedureEnums.StoredProcedureParameterDirection.In:
        ////                        sqlDB.AddInParameter(cmd, inputParam.ParameterName, inputParam.ParameterDataType, inputParam.ParameterValue);
        ////                        break;
        ////                    case StoredProcedureEnums.StoredProcedureParameterDirection.Out:
        ////                        sqlDB.AddOutParameter(cmd, inputParam.ParameterName, inputParam.ParameterDataType, inputParam.OutputParameterSize);
        ////                        outputParamName.Add(inputParam.ParameterName);
        ////                        break;
        ////                    case StoredProcedureEnums.StoredProcedureParameterDirection.InOut:
        ////                        sqlDB.AddParameter(cmd, inputParam.ParameterName, inputParam.ParameterDataType, inputParam.OutputParameterSize, ParameterDirection.InputOutput, true, inputParam.Precision, inputParam.Scale, inputParam.ParameterName, DataRowVersion.Default, inputParam.ParameterValue);
        ////                        outputParamName.Add(inputParam.ParameterName);
        ////                        break;
        ////                }
        ////            }
        ////        }



        ////        switch (executionType)
        ////        {
        ////            case StoredProcedureEnums.StoredProcedureExecutionType.DataReader:
        ////                executionResult = sqlDB.ExecuteReader(cmd);
        ////                break;
        ////            case StoredProcedureEnums.StoredProcedureExecutionType.DataSet:
        ////                executionResult = sqlDB.ExecuteDataSet(cmd);
        ////                break;
        ////            case StoredProcedureEnums.StoredProcedureExecutionType.NonQuery:
        ////                executionResult = sqlDB.ExecuteNonQuery(cmd);
        ////                break;
        ////            case StoredProcedureEnums.StoredProcedureExecutionType.Scalar:
        ////                executionResult = sqlDB.ExecuteScalar(cmd);
        ////                break;
        ////        }

        ////        var outputParameterResult = new Dictionary<string, object>();
        ////        foreach (var outputParam in outputParamName)
        ////        {
        ////            var output = sqlDB.GetParameterValue(cmd, outputParam);
        ////            outputParameterResult[outputParam] = output == DBNull.Value ? null : output;
        ////        }


        ////        var returnValue = new AdhocStoredProcedureExecutionResult
        ////        {
        ////            ExecutionResult = executionResult,
        ////            OutputParameters = outputParameterResult
        ////        };
        ////        return returnValue;

        ////    }
        ////    catch (SqlException ex)
        ////    {
        ////        LogException(ex.Message, ex.StackTrace, "ExecuteNonQuery");
        ////        throw ex;
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        LogException(ex.Message , ex.StackTrace, "ExecuteAdhocStoredProcedure");
        ////        throw new Exception(ex.Message);

        ////    }

        ////}


        /// <summary>
        /// Execute stored procedure without entity as parameters
        /// </summary>
        /// <param name="storedProcedureName">Name of stored procedure</param>
        /// <param name="parameters">Input parameter</param>
        /// <param name="executionType">Type of execution</param>
        /// <returns>Result of execution</returns>
        public AdhocStoredProcedureExecutionResult ExecuteAdhocStoredProcedure(string storedProcedureName, List<AdhocStoredProcedureInputParameters> parameters, StoredProcedureEnums.StoredProcedureExecutionType executionType)
        {
            try
            {
                var cmd = sqlDB.GetStoredProcCommand(storedProcedureName);
                if (this.CommandTimeOut != null)
                    cmd.CommandTimeout = (int)this.CommandTimeOut;
                var outputParamName = new List<string>();
                object executionResult = null;

                if (parameters != null)
                {
                    foreach (var inputParam in parameters)
                    {
                        switch (inputParam.ParameterDirection)
                        {
                            case StoredProcedureEnums.StoredProcedureParameterDirection.In:
                                sqlDB.AddInParameter(cmd, inputParam.ParameterName, inputParam.ParameterDataType, inputParam.ParameterValue);
                                break;
                            case StoredProcedureEnums.StoredProcedureParameterDirection.Out:
                                sqlDB.AddOutParameter(cmd, inputParam.ParameterName, inputParam.ParameterDataType, inputParam.OutputParameterSize);
                                outputParamName.Add(inputParam.ParameterName);
                                break;
                            case StoredProcedureEnums.StoredProcedureParameterDirection.InOut:
                                sqlDB.AddParameter(cmd, inputParam.ParameterName, inputParam.ParameterDataType, inputParam.OutputParameterSize, ParameterDirection.InputOutput, true, inputParam.Precision, inputParam.Scale, inputParam.ParameterName, DataRowVersion.Default, inputParam.ParameterValue);
                                outputParamName.Add(inputParam.ParameterName);
                                break;
                        }
                    }
                }



                switch (executionType)
                {
                    case StoredProcedureEnums.StoredProcedureExecutionType.DataReader:
                        executionResult = sqlDB.ExecuteReader(cmd);
                        break;
                    case StoredProcedureEnums.StoredProcedureExecutionType.DataSet:
                        executionResult = sqlDB.ExecuteDataSet(cmd);
                        break;
                    case StoredProcedureEnums.StoredProcedureExecutionType.NonQuery:
                        executionResult = sqlDB.ExecuteNonQuery(cmd);
                        break;
                    case StoredProcedureEnums.StoredProcedureExecutionType.Scalar:
                        executionResult = sqlDB.ExecuteScalar(cmd);
                        break;
                }

                var outputParameterResult = new Dictionary<string, object>();
                foreach (var outputParam in outputParamName)
                {
                    var output = sqlDB.GetParameterValue(cmd, outputParam);
                    outputParameterResult[outputParam] = output == DBNull.Value ? null : output;
                }

                var returnValue = new AdhocStoredProcedureExecutionResult
                {
                    ExecutionResult = executionResult,
                    OutputParameters = outputParameterResult
                };

                return returnValue;
            }
            catch (SqlException ex)
            {
                LogException(ex.Message, ex.StackTrace, "ExecuteNonQuery");
                throw ex;
            }
            catch (Exception ex)
            {
                LogException(ex.Message, ex.StackTrace, "ExecuteAdhocStoredProcedure");
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Execute stored procedure without entity as parameters
        /// </summary>
        /// <param name="storedProcedureName">Name of stored procedure</param>
        /// <param name="parameters">Input parameter</param>
        /// <param name="executionType">Type of execution</param>
        /// <returns>Result of execution</returns>
        public AdhocStoredProcedureExecutionResult ExecuteAdhocStoredProcedure(MethodInfo storedProcedureName, List<AdhocStoredProcedureInputParameters> parameters, StoredProcedureEnums.StoredProcedureExecutionType executionType)
        {
            return ExecuteAdhocStoredProcedure(GetStoredProcedureName(storedProcedureName), parameters, executionType);
        }
        #endregion


        #region Exception Log

        private static void LogException(string message, string stackTrace, string title)
        {
            Log(message,stackTrace, title, LogEnum.LoggerCategory.LIMS,
            LogEnum.LoggerEvent.Job, System.Diagnostics.TraceEventType.Error,
            LogEnum.LoggerPriority.High);
        }


        public static void Log(string message, string stackTrace, string title, LogEnum.LoggerCategory category, LogEnum.LoggerEvent eventCode, TraceEventType severity, LogEnum.LoggerPriority priority)
        {
            //var entry = new LogEntry
            //{
            //    Message = message,
            //    Title = title,
            //    Categories = new List<string>() { category.ToString() },
            //    EventId = eventCode.GetHashCode(),
            //    Severity = severity,
            //    Priority = priority.GetHashCode(),
            //    TimeStamp = DateTime.Now,
            //};
            
            //if (!string.IsNullOrEmpty(stackTrace))
            //{
            //    entry.ExtendedProperties.Add("Stack Trace", stackTrace);
            //}
                        
            //Logger.Write(entry);
        }

        #endregion
    }

    public class LogEnum
    {
        public enum LoggerCategory
        {
            Exception,
            Security,
            Information,
            LIMS
        }

        public enum LoggerEvent
        {
            Web,
            Job,
            DataExchange
        }

        public enum LoggerPriority
        {
            Low,
            Medium,
            High
        }
    }
}
