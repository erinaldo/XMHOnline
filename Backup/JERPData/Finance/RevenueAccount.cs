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
    /// 表[finance.RevenueAccount]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015-01-15 09:25:02
    ///</时间>  
    public class RevenueAccount
    {
        private SqlConnection sqlConn;
        public RevenueAccount()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }
        public DataSet GetDataRevenueAccountMonthRecord(int RevenueTypeID, int Year, int Month)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@RevenueTypeID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@Year", SqlDbType.Int);
            arParams[2] = new SqlParameter("@Month", SqlDbType.Int);
            arParams[0].Value = RevenueTypeID;
            arParams[1].Value = Year;
            arParams[2].Value = Month;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "finance.GetDataRevenueAccountMonthRecord", arParams);
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
        public DataSet GetDataRevenueAccountLastRecord(int RevenueTypeID, int RecordCount)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@RevenueTypeID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@RecordCount", SqlDbType.Int);
            arParams[0].Value = RevenueTypeID;
            arParams[1].Value = RecordCount;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "finance.GetDataRevenueAccountLastRecord", arParams);
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
        public DataSet GetDataRevenueAccountRevenueRptPivotMonth(int Year)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@Year", SqlDbType.Int);
            arParams[0].Value = Year;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "finance.GetDataRevenueAccountRevenueRptPivotMonth", arParams);
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

        public DataSet GetDataRevenueAccountAllMonthRecord(int Year, int Month)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@Year", SqlDbType.Int);
            arParams[1] = new SqlParameter("@Month", SqlDbType.Int);
            arParams[0].Value = Year;
            arParams[1].Value = Month;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "finance.GetDataRevenueAccountAllMonthRecord", arParams);
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
        public bool GetParmRevenueAccountBalanceAMT(int RevenueTypeID, ref decimal BalanceAMT)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@RevenueTypeID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@BalanceAMT", SqlDbType.Money);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = RevenueTypeID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "finance.GetParmRevenueAccountBalanceAMT", arParams);
                BalanceAMT = (decimal)arParams[1].Value;
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
        public bool InsertRevenueAccountForAdjust(ref string ErrorMsg, object RevenueTypeID, object BalanceAMT, object RegisterPsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@RevenueTypeID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@BalanceAMT", SqlDbType.Money);
            arParams[2] = new SqlParameter("@RegisterPsnID", SqlDbType.Int);
            arParams[0].Value = RevenueTypeID;
            arParams[1].Value = BalanceAMT;
            arParams[2].Value = RegisterPsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "finance.InsertRevenueAccountForAdjust", arParams);
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
        public bool InsertRevenueAccountForCredit(ref string ErrorMsg, object Summary, object RevenueTypeID, object CreditAMT, object RegisterPsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@Summary", SqlDbType.VarChar);
            arParams[0].Size = 100;
            arParams[1] = new SqlParameter("@RevenueTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@CreditAMT", SqlDbType.Money);
            arParams[3] = new SqlParameter("@RegisterPsnID", SqlDbType.Int);
            arParams[0].Value = Summary;
            arParams[1].Value = RevenueTypeID;
            arParams[2].Value = CreditAMT;
            arParams[3].Value = RegisterPsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "finance.InsertRevenueAccountForCredit", arParams);
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
        public bool InsertRevenueAccountForDebit(ref string ErrorMsg, object Summary, object RevenueTypeID, object DebitAMT, object RegisterPsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@Summary", SqlDbType.VarChar);
            arParams[0].Size = 100;
            arParams[1] = new SqlParameter("@RevenueTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@DebitAMT", SqlDbType.Money);
            arParams[3] = new SqlParameter("@RegisterPsnID", SqlDbType.Int);
            arParams[0].Value = Summary;
            arParams[1].Value = RevenueTypeID;
            arParams[2].Value = DebitAMT;
            arParams[3].Value = RegisterPsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "finance.InsertRevenueAccountForDebit", arParams);
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