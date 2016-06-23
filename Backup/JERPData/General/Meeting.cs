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
    /// 表[general.Meeting]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014-11-26 09:38:52
    ///</时间>  
    public class Meeting
    {
        private SqlConnection sqlConn;
        public Meeting()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public DataSet GetDataMeetingByMeetingID(long MeetingID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@MeetingID", SqlDbType.BigInt);
            arParams[0].Value = MeetingID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "general.GetDataMeetingByMeetingID", arParams);
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

        public bool DeleteMeeting(ref string ErrorMsg, object MeetingID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@MeetingID", SqlDbType.BigInt);
            arParams[0].Value = MeetingID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "general.DeleteMeeting", arParams);
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
        public DataSet GetDataMeetingDescPagesFreeSearch(int PageIndex, int PageSize, ref int RecordCount, string WhereClause)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@PageIndex", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PageSize", SqlDbType.Int);
            arParams[2] = new SqlParameter("@RecordCount", SqlDbType.Int);
            arParams[2].Direction = ParameterDirection.InputOutput;
            arParams[3] = new SqlParameter("@WhereClause", SqlDbType.NVarChar);
            arParams[3].Size = -1;
            arParams[0].Value = PageIndex;
            arParams[1].Value = PageSize;
            arParams[2].Value = RecordCount;
            arParams[3].Value = WhereClause;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "general.GetDataMeetingDescPagesFreeSearch", arParams);
                RecordCount = (int)arParams[2].Value;
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
        public bool InsertMeeting(ref string ErrorMsg, ref object MeetingID, object DateMeeting, object MeetingTitle, object MeetingContent, object MeetingPsns, object MakerPsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@MeetingID", SqlDbType.BigInt);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@DateMeeting", SqlDbType.DateTime);
            arParams[2] = new SqlParameter("@MeetingTitle", SqlDbType.VarChar);
            arParams[2].Size = 200;
            arParams[3] = new SqlParameter("@MeetingContent", SqlDbType.VarChar);
            arParams[3].Size = -1;
            arParams[4] = new SqlParameter("@MeetingPsns", SqlDbType.VarChar);
            arParams[4].Size = 100;
            arParams[5] = new SqlParameter("@MakerPsnID", SqlDbType.Int);
            arParams[1].Value = DateMeeting;
            arParams[2].Value = MeetingTitle;
            arParams[3].Value = MeetingContent;
            arParams[4].Value = MeetingPsns;
            arParams[5].Value = MakerPsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "general.InsertMeeting", arParams);
                MeetingID = arParams[0].Value;
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
        public bool UpdateMeeting(ref string ErrorMsg, object MeetingID, object DateMeeting, object MeetingTitle, object MeetingContent, object MeetingPsns, object MakerPsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@MeetingID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@DateMeeting", SqlDbType.DateTime);
            arParams[2] = new SqlParameter("@MeetingTitle", SqlDbType.VarChar);
            arParams[2].Size = 200;
            arParams[3] = new SqlParameter("@MeetingContent", SqlDbType.VarChar);
            arParams[3].Size = -1;
            arParams[4] = new SqlParameter("@MeetingPsns", SqlDbType.VarChar);
            arParams[4].Size = 100;
            arParams[5] = new SqlParameter("@MakerPsnID", SqlDbType.Int);
            arParams[0].Value = MeetingID;
            arParams[1].Value = DateMeeting;
            arParams[2].Value = MeetingTitle;
            arParams[3].Value = MeetingContent;
            arParams[4].Value = MeetingPsns;
            arParams[5].Value = MakerPsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "general.UpdateMeeting", arParams);
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