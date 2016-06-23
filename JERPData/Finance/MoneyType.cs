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
    /// 表[finance.MoneyType]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2011-12-11 10:25:31
    ///</时间>  
    public class MoneyType
    {
        private SqlConnection sqlConn;
        public MoneyType()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }


        public bool DeleteMoneyType(ref string ErrorMsg, object MoneyTypeID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[0].Value = MoneyTypeID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "finance.DeleteMoneyType", arParams);
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
        public DataSet GetDataMoneyType()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "finance.GetDataMoneyType");
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
        public DataSet GetDataMoneyTypeByMoneyTypeID(int MoneyTypeID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[0].Value = MoneyTypeID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "finance.GetDataMoneyTypeByMoneyTypeID", arParams);
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
        public bool GetParmMoneyTypeExchangeRate(int MoneyTypeID, ref decimal ExchangeRate)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@ExchangeRate", SqlDbType.Decimal);
            arParams[1].Precision = 18;
            arParams[1].Scale = 6;
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = MoneyTypeID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "finance.GetParmMoneyTypeExchangeRate", arParams);
                ExchangeRate = (decimal)arParams[1].Value;
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
        public bool GetParmMoneyTypeMainMoneyTypeID(ref int MoneyTypeID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "finance.GetParmMoneyTypeMainMoneyTypeID", arParams);
                MoneyTypeID = (int)arParams[0].Value;
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
        public bool GetParmMoneyTypeMainMoneyTypeName(ref string MoneyTypeName)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@MoneyTypeName", SqlDbType.VarChar);
            arParams[0].Size = 50;
            arParams[0].Direction = ParameterDirection.InputOutput;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "finance.GetParmMoneyTypeMainMoneyTypeName", arParams);
                MoneyTypeName = (string)arParams[0].Value;
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
        public bool InsertMoneyType(ref string ErrorMsg, ref object MoneyTypeID, object MoneyTypeCode, object MoneyTypeName, object MainMoneyFlag, object ExchangeRate)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@MoneyTypeCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@MoneyTypeName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@MainMoneyFlag", SqlDbType.Bit);
            arParams[4] = new SqlParameter("@ExchangeRate", SqlDbType.Decimal);
            arParams[4].Precision = 18;
            arParams[4].Scale = 6;
            arParams[1].Value = MoneyTypeCode;
            arParams[2].Value = MoneyTypeName;
            arParams[3].Value = MainMoneyFlag;
            arParams[4].Value = ExchangeRate;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "finance.InsertMoneyType", arParams);
                MoneyTypeID = arParams[0].Value;
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
        public bool UpdateMoneyType(ref string ErrorMsg, object MoneyTypeID, object MoneyTypeCode, object MoneyTypeName, object MainMoneyFlag, object ExchangeRate)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@MoneyTypeCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@MoneyTypeName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@MainMoneyFlag", SqlDbType.Bit);
            arParams[4] = new SqlParameter("@ExchangeRate", SqlDbType.Decimal);
            arParams[4].Precision = 18;
            arParams[4].Scale = 6;
            arParams[0].Value = MoneyTypeID;
            arParams[1].Value = MoneyTypeCode;
            arParams[2].Value = MoneyTypeName;
            arParams[3].Value = MainMoneyFlag;
            arParams[4].Value = ExchangeRate;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "finance.UpdateMoneyType", arParams);
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