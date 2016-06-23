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
namespace JERPData.Finance
{
    /// <描述>
    /// 表[finance.PostageReconciliations]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2012-12-31 20:27:49
    ///</时间>  
    public class PostageReconciliations
    {
        private SqlConnection sqlConn;
        public PostageReconciliations()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public DataSet GetDataPostageReconciliationsByReconciliationID(long ReconciliationID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ReconciliationID", SqlDbType.BigInt);
            arParams[0].Value = ReconciliationID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "finance.GetDataPostageReconciliationsByReconciliationID", arParams);
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
        public DataSet GetDataPostageReconciliationsDescPagesSettleAMT(int PageIndex, int PageSize, ref int RecordCount)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@PageIndex", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PageSize", SqlDbType.Int);
            arParams[2] = new SqlParameter("@RecordCount", SqlDbType.Int);
            arParams[2].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = PageIndex;
            arParams[1].Value = PageSize;
            arParams[2].Value = RecordCount;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "finance.GetDataPostageReconciliationsDescPagesSettleAMT", arParams);
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
        public DataSet GetDataPostageReconciliationsNonFinishedAMT()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "finance.GetDataPostageReconciliationsNonFinishedAMT");
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
        public DataSet GetDataPostageReconciliationsNonFinance()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "finance.GetDataPostageReconciliationsNonFinance");
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
        public DataSet GetDataPostageReconciliationsYearReport(int Year)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@Year", SqlDbType.Int);
            arParams[0].Value = Year;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "finance.GetDataPostageReconciliationsYearReport", arParams);
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

        public bool InsertPostageReconciliations(ref string ErrorMsg, ref object ReconciliationID, object ReconciliationCode, object ReconciliationName, object CompanyID, object Year, object Month, object DateNote, object DateSettle, object MakerPsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[9];
            arParams[0] = new SqlParameter("@ReconciliationID", SqlDbType.BigInt);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@ReconciliationCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@ReconciliationName", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@Year", SqlDbType.Int);
            arParams[5] = new SqlParameter("@Month", SqlDbType.Int);
            arParams[6] = new SqlParameter("@DateNote", SqlDbType.DateTime);
            arParams[7] = new SqlParameter("@DateSettle", SqlDbType.DateTime);
            arParams[8] = new SqlParameter("@MakerPsnID", SqlDbType.Int);
            arParams[1].Value = ReconciliationCode;
            arParams[2].Value = ReconciliationName;
            arParams[3].Value = CompanyID;
            arParams[4].Value = Year;
            arParams[5].Value = Month;
            arParams[6].Value = DateNote;
            arParams[7].Value = DateSettle;
            arParams[8].Value = MakerPsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "finance.InsertPostageReconciliations", arParams);
                ReconciliationID = arParams[0].Value;
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

        public bool UpdatePostageReconciliations(ref string ErrorMsg, object ReconciliationID, object ReconciliationCode, object ReconciliationName, object DateNote, object DateSettle, object MakerPsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@ReconciliationID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@ReconciliationCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@ReconciliationName", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@DateNote", SqlDbType.DateTime);
            arParams[4] = new SqlParameter("@DateSettle", SqlDbType.DateTime);
            arParams[5] = new SqlParameter("@MakerPsnID", SqlDbType.Int);
            arParams[0].Value = ReconciliationID;
            arParams[1].Value = ReconciliationCode;
            arParams[2].Value = ReconciliationName;
            arParams[3].Value = DateNote;
            arParams[4].Value = DateSettle;
            arParams[5].Value = MakerPsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "finance.UpdatePostageReconciliations", arParams);
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
        public bool UpdatePostageReconciliationsForAppendFinishedAMT(ref string ErrorMsg, object ReconciliationID, object AppendFinishedAMT)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ReconciliationID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@AppendFinishedAMT", SqlDbType.Money);
            arParams[0].Value = ReconciliationID;
            arParams[1].Value = AppendFinishedAMT;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "finance.UpdatePostageReconciliationsForAppendFinishedAMT", arParams);
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

        public bool UpdatePostageReconciliationsForTotalAMT(ref string ErrorMsg, object ReconciliationID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ReconciliationID", SqlDbType.BigInt);
            arParams[0].Value = ReconciliationID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "finance.UpdatePostageReconciliationsForTotalAMT", arParams);
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
        public bool DeletePostageReconciliations(ref string ErrorMsg, object ReconciliationID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ReconciliationID", SqlDbType.BigInt);
            arParams[0].Value = ReconciliationID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "finance.DeletePostageReconciliations", arParams);
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