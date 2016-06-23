/*
$Header$
$Author$
$Date$
$Revision$
*/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;
namespace JERPData.Manufacture
{
    /// <描述>
    /// 表[manuf.ProcessParmType]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/4/24 16:50:37
    ///</时间>  
    public class ProcessParmType
    {
        private SqlConnection sqlConn;
        public ProcessParmType()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public bool DeleteProcessParmType(ref string ErrorMsg, object ParmTypeID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ParmTypeID", SqlDbType.Int);
            arParams[0].Value = ParmTypeID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.DeleteProcessParmType", arParams);
                DBTransaction.Commit();
                flag = true;
            }
            catch (SqlException ex)
            {
                ErrorMsg = ex.Message; //返回错误信息
                flag = false;
                DBTransaction.Rollback();//--回退事务
            }
            finally
            {
                this.sqlConn.Close();
            }
            return flag;
        }
        public DataSet GetDataProcessParmTypeByProcessTypeID(int ProcessTypeID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ProcessTypeID", SqlDbType.Int);
            arParams[0].Value = ProcessTypeID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataProcessParmTypeByProcessTypeID", arParams);
            }
            catch//(SqlException ex)
            {
                // ex.Message --这里作调试用
            }
            finally
            {
                this.sqlConn.Close();
            }
            return ds;
        }
        public bool InsertProcessParmType(ref string ErrorMsg, ref object ParmTypeID, object ProcessTypeID, object ParmTypeName, object DefaultValue, object ItemValues)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@ParmTypeID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@ProcessTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@ParmTypeName", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@DefaultValue", SqlDbType.VarChar);
            arParams[3].Size = -1;
            arParams[4] = new SqlParameter("@ItemValues", SqlDbType.VarChar);
            arParams[4].Size = -1;
            arParams[1].Value = ProcessTypeID;
            arParams[2].Value = ParmTypeName;
            arParams[3].Value = DefaultValue;
            arParams[4].Value = ItemValues;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.InsertProcessParmType", arParams);
                ParmTypeID = arParams[0].Value;
                DBTransaction.Commit();
                flag = true;
            }
            catch (SqlException ex)
            {
                ErrorMsg = ex.Message; //返回错误信息
                flag = false;
                DBTransaction.Rollback();//--回退事务
            }
            finally
            {
                this.sqlConn.Close();
            }
            return flag;
        }
        public bool UpdateProcessParmType(ref string ErrorMsg, object ParmTypeID, object ParmTypeName, object DefaultValue, object ItemValues)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@ParmTypeID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@ParmTypeName", SqlDbType.VarChar);
            arParams[1].Size = 100;
            arParams[2] = new SqlParameter("@DefaultValue", SqlDbType.VarChar);
            arParams[2].Size = -1;
            arParams[3] = new SqlParameter("@ItemValues", SqlDbType.VarChar);
            arParams[3].Size = -1;
            arParams[0].Value = ParmTypeID;
            arParams[1].Value = ParmTypeName;
            arParams[2].Value = DefaultValue;
            arParams[3].Value = ItemValues;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateProcessParmType", arParams);
                DBTransaction.Commit();
                flag = true;
            }
            catch (SqlException ex)
            {
                ErrorMsg = ex.Message; //返回错误信息
                flag = false;
                DBTransaction.Rollback();//--回退事务
            }
            finally
            {
                this.sqlConn.Close();
            }
            return flag;
        }




    }
}