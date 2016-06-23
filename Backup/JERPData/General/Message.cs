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
namespace JERPData.General
{
    /// <描述>
    /// 表[general.Message]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015-05-12 21:49:28
    ///</时间>  
    public class Message
    {
        private SqlConnection sqlConn;
        public Message()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public DataSet GetDataMessageNonReceive(int PsnID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[0].Value = PsnID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "general.GetDataMessageNonReceive", arParams);
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
        public DataSet GetDataMessageRecord(int PsnID, string WhereClause)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@WhereClause", SqlDbType.VarChar);
            arParams[1].Size = -1;
            arParams[0].Value = PsnID;
            arParams[1].Value = WhereClause;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "general.GetDataMessageRecord", arParams);
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
        public bool InsertMessage(ref string ErrorMsg, object DateMsg, object MsgContent, object FromPsnID, object ToPsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@DateMsg", SqlDbType.DateTime);
            arParams[1] = new SqlParameter("@MsgContent", SqlDbType.VarChar);
            arParams[1].Size = -1;
            arParams[2] = new SqlParameter("@FromPsnID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@ToPsnID", SqlDbType.Int);
            arParams[0].Value = DateMsg;
            arParams[1].Value = MsgContent;
            arParams[2].Value = FromPsnID;
            arParams[3].Value = ToPsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "general.InsertMessage", arParams);
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
        public bool UpdateMessageForReceive(ref string ErrorMsg, object MsgID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@MsgID", SqlDbType.BigInt);
            arParams[0].Value = MsgID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "general.UpdateMessageForReceive", arParams);
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