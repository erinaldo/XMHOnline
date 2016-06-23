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
namespace JERPData.Frame
{
    /// <描述>
    /// 表[frame.Functions]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2006-10-15 18:22:42
    ///</时间>  
    public class Functions
    {
        private SqlConnection sqlConn;
        public Functions()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public DataSet GetDataFunctionPermitMsgByFormID(int FormID, short RoleID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@FormID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@RoleID", SqlDbType.SmallInt);
            arParams[0].Value = FormID;
            arParams[1].Value = RoleID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "frame.GetDataFunctionPermitMsgByFormID", arParams);
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
        public DataSet GetDataFunctionByFormID(int FormID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@FormID", SqlDbType.Int);
            arParams[0].Value = FormID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "frame.GetDataFunctionByFormID", arParams);
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

        public bool GetParmMaxFunctionID(ref int MaxFunctionID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@MaxFunctionID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "frame.GetParmMaxFunctionID", arParams);
                MaxFunctionID = (int)arParams[0].Value;
                DBTransaction.Commit();
                flag = true;
            }
            catch//(SqlException ex)
            {
                // ex.Message --这里作调试用
                flag = false;
                DBTransaction.Rollback();//--回退事务
            }
            finally
            {
                this.sqlConn.Close();
            }
            return flag;
        }
        public DataSet GetDataFunctionsByFormIDLists(string FormIDLists)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@FormIDLists", SqlDbType.VarChar);
            arParams[0].Size = -1;
            arParams[0].Value = FormIDLists;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "frame.GetDataFunctionsByFormIDLists", arParams);
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


    }
}