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
    /// 表[general.Diary]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014-11-27 22:24:55
    ///</时间>  
    public class Diary
    {
        private SqlConnection sqlConn;
        public Diary()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public bool DeleteDiary(ref string ErrorMsg, object DiaryID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@DiaryID", SqlDbType.BigInt);
            arParams[0].Value = DiaryID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "general.DeleteDiary", arParams);
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
        public DataSet GetDataDiaryByDiaryID(long DiaryID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@DiaryID", SqlDbType.BigInt);
            arParams[0].Value = DiaryID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "general.GetDataDiaryByDiaryID", arParams);
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
        public DataSet GetDataDiaryForHandle(int PsnID, int DiaryTypeID, bool CloseFlag)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@DiaryTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@CloseFlag", SqlDbType.Bit);
            arParams[0].Value = PsnID;
            arParams[1].Value = DiaryTypeID;
            arParams[2].Value = CloseFlag;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "general.GetDataDiaryForHandle", arParams);
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

        public DataSet GetDataDiaryDescPagesFreeSearch(int PageIndex, int PageSize, ref int RecordCount, string WhereClause)
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
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "general.GetDataDiaryDescPagesFreeSearch", arParams);
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
        public bool InsertDiary(ref string ErrorMsg, ref object DiaryID, object PsnID, object DateDiary, object DiaryTitle, object DiaryContent, object DiaryTypeID, object CloseFlag)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[7];
            arParams[0] = new SqlParameter("@DiaryID", SqlDbType.BigInt);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@DateDiary", SqlDbType.DateTime);
            arParams[3] = new SqlParameter("@DiaryTitle", SqlDbType.VarChar);
            arParams[3].Size = 100;
            arParams[4] = new SqlParameter("@DiaryContent", SqlDbType.VarChar);
            arParams[4].Size = -1;
            arParams[5] = new SqlParameter("@DiaryTypeID", SqlDbType.Int);
            arParams[6] = new SqlParameter("@CloseFlag", SqlDbType.Bit);
            arParams[1].Value = PsnID;
            arParams[2].Value = DateDiary;
            arParams[3].Value = DiaryTitle;
            arParams[4].Value = DiaryContent;
            arParams[5].Value = DiaryTypeID;
            arParams[6].Value = CloseFlag;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "general.InsertDiary", arParams);
                DiaryID = arParams[0].Value;
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
        public bool UpdateDiary(ref string ErrorMsg, object DiaryID, object DateDiary, object DiaryTitle, object DiaryContent, object DiaryTypeID, object CloseFlag)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@DiaryID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@DateDiary", SqlDbType.DateTime);
            arParams[2] = new SqlParameter("@DiaryTitle", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@DiaryContent", SqlDbType.VarChar);
            arParams[3].Size = -1;
            arParams[4] = new SqlParameter("@DiaryTypeID", SqlDbType.Int);
            arParams[5] = new SqlParameter("@CloseFlag", SqlDbType.Bit);
            arParams[0].Value = DiaryID;
            arParams[1].Value = DateDiary;
            arParams[2].Value = DiaryTitle;
            arParams[3].Value = DiaryContent;
            arParams[4].Value = DiaryTypeID;
            arParams[5].Value = CloseFlag;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "general.UpdateDiary", arParams);
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