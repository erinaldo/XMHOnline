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
    /// 表[finance.CashAccount]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014-12-18 14:51:18
    ///</时间>  
    public class CashAccount
    {
        private SqlConnection sqlConn;
        public CashAccount()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }
        public DataSet GetDataCashAccountRecord(int MoneyTypeID, DateTime DateBegin, DateTime DateEnd)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@DateBegin", SqlDbType.DateTime);
            arParams[2] = new SqlParameter("@DateEnd", SqlDbType.DateTime);
            arParams[0].Value = MoneyTypeID;
            arParams[1].Value = DateBegin;
            arParams[2].Value = DateEnd;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "finance.GetDataCashAccountRecord", arParams);
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

        public DataSet GetDataCashAccount()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "finance.GetDataCashAccount");
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
        public DataSet GetDataCashAccountLastRecord(int MoneyTypeID, int RecordCount)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@RecordCount", SqlDbType.Int);
            arParams[0].Value = MoneyTypeID;
            arParams[1].Value = RecordCount;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "finance.GetDataCashAccountLastRecord", arParams);
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
        public bool GetParmCashAccountBalanceAMT(int MoneyTypeID, ref decimal BalanceAMT)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@BalanceAMT", SqlDbType.Money);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = MoneyTypeID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "finance.GetParmCashAccountBalanceAMT", arParams);
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
        public bool InsertCashAccountForAdjust(ref string ErrorMsg, object MoneyTypeID, object BalanceAMT, object RegisterPsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@BalanceAMT", SqlDbType.Money);
            arParams[2] = new SqlParameter("@RegisterPsnID", SqlDbType.Int);
            arParams[0].Value = MoneyTypeID;
            arParams[1].Value = BalanceAMT;
            arParams[2].Value = RegisterPsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "finance.InsertCashAccountForAdjust", arParams);
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
        public bool InsertCashAccountForCredit(ref string ErrorMsg, object Summary, object MoneyTypeID, object CreditAMT, object RegisterPsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@Summary", SqlDbType.VarChar);
            arParams[0].Size = 100;
            arParams[1] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@CreditAMT", SqlDbType.Money);
            arParams[3] = new SqlParameter("@RegisterPsnID", SqlDbType.Int);
            arParams[0].Value = Summary;
            arParams[1].Value = MoneyTypeID;
            arParams[2].Value = CreditAMT;
            arParams[3].Value = RegisterPsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "finance.InsertCashAccountForCredit", arParams);
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
        public bool InsertCashAccountForDebit(ref string ErrorMsg, object Summary, object MoneyTypeID, object DebitAMT, object RegisterPsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@Summary", SqlDbType.VarChar);
            arParams[0].Size = 100;
            arParams[1] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@DebitAMT", SqlDbType.Money);
            arParams[3] = new SqlParameter("@RegisterPsnID", SqlDbType.Int);
            arParams[0].Value = Summary;
            arParams[1].Value = MoneyTypeID;
            arParams[2].Value = DebitAMT;
            arParams[3].Value = RegisterPsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "finance.InsertCashAccountForDebit", arParams);
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