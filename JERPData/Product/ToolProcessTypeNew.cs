using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;
namespace JERPData.Product
{
    /// <描述>
    /// 表[manuf.ToolProcessTypeNew]数据访问类
    ///</描述> 
    ///<作者> 
    /// 
    ///</作者> 
    ///<时间> 
    /// 2016-08-20 11:08:14
    ///</时间>  
    public class ToolProcessTypeNew
    {
        private SqlConnection sqlConn;
        public ToolProcessTypeNew()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public DataSet GetDataToolProcessTypeNew()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "manuf.GetDataToolProcessTypeNew");
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

        public bool InsertToolProcessTypeNew(ref string ErrorMsg, ref object ToolProcessID, object ToolProcessCode, object ToolProcessName, object ToolProcessMemo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@ToolProcessID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@ToolProcessCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@ToolProcessName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@ToolProcessMemo", SqlDbType.VarChar);
            arParams[3].Size = 400;
            arParams[0].Value = ToolProcessID;
            arParams[1].Value = ToolProcessCode;
            arParams[2].Value = ToolProcessName;
            arParams[3].Value = ToolProcessMemo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.InsertToolProcessTypeNew", arParams);
                ToolProcessID = arParams[0].Value;
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

        public bool UpdateToolProcessTypeNew(ref string ErrorMsg, object ToolProcessID, object ToolProcessCode, object ToolProcessName, object ToolProcessMemo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@ToolProcessID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@ToolProcessCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@ToolProcessName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@ToolProcessMemo", SqlDbType.VarChar);
            arParams[3].Size = 400;
            arParams[0].Value = ToolProcessID;
            arParams[1].Value = ToolProcessCode;
            arParams[2].Value = ToolProcessName;
            arParams[3].Value = ToolProcessMemo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateToolProcessTypeNew", arParams);
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



        public bool DeleteToolProcessTypeNew(ref string ErrorMsg, object ToolProcessID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ToolProcessID", SqlDbType.Int);
            arParams[0].Value = ToolProcessID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.DeleteToolProcessTypeNew", arParams);
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

        public bool GetParmToolProcessByName(string ToolProcessName, ref int ToolProcessID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ToolProcessName", SqlDbType.VarChar);
            arParams[0].Size = 50;
            arParams[1] = new SqlParameter("@ToolProcessID", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = ToolProcessName;
            arParams[1].Value = ToolProcessID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "manuf.GetParmToolProcessByName", arParams);
                ToolProcessID = (int)arParams[1].Value;
                flag = true;
            }
            catch//(SqlException ex)
            {
                flag = false;
            }
            finally
            {
                this.sqlConn.Close();
            }
            return flag;
        }
    }
}
