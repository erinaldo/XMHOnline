using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace JERPData.Frame
{
    public class Users
    {
        private SqlConnection sqlConn = null;
        public Users()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPassword"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool GetParmUsersLogon(string UserName,
            string UserPassword,
            string Passport,
            out short UserID,
            out bool RegisterFlag,
            out bool RemindFlag,
            out bool CloseFlag)
        {
            bool flag = false;
            UserID = -1;
            RegisterFlag = false;
            RemindFlag = false;
            CloseFlag = false;
            SqlParameter[] arParams = new SqlParameter[7];
            arParams[0] = new SqlParameter("@UserName", SqlDbType.NVarChar);
            arParams[0].Size = 4000;

            arParams[1] = new SqlParameter("@UserPassword", SqlDbType.NVarChar);
            arParams[1].Size = 4000;

            arParams[2] = new SqlParameter("@Passport", SqlDbType.NVarChar);
            arParams[2].Size = 4000;

            arParams[3] = new SqlParameter("@UserID", SqlDbType.SmallInt);
            arParams[3].Direction = ParameterDirection.Output;

            arParams[4] = new SqlParameter("@RegisterFlag", SqlDbType.Bit);
            arParams[4].Direction = ParameterDirection.Output;


            arParams[5] = new SqlParameter("@RemindFlag", SqlDbType.Bit);
            arParams[5].Direction = ParameterDirection.Output;

            arParams[6] = new SqlParameter("@CloseFlag", SqlDbType.Bit);
            arParams[6].Direction = ParameterDirection.Output;

            arParams[0].Value = UserName;
            arParams[1].Value = UserPassword;
            arParams[2].Value = Passport;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure,
                    "dbo.GetParmUserLogon", arParams);
                UserID = (short)arParams[3].Value;
                RegisterFlag = (bool)arParams[4].Value;
                RemindFlag = (bool)arParams[5].Value;
                CloseFlag = (bool)arParams[6].Value;
                DBTransaction.Commit();
                flag = true;
            }
            catch//(SqlException ex)
            {
                // ex.Message //--这里作调试用
                flag = false;
                DBTransaction.Rollback();//--回退事务
            }
            finally
            {
                this.sqlConn.Close();
            }
            return flag;
        }
      
        //更新用户密码

        public bool UpdateUsersPassword(object UserID, object UserPassword)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@UserID", SqlDbType.SmallInt);
            arParams[1] = new SqlParameter("@UserPassword", SqlDbType.VarChar);
            arParams[1].Size = 100;
            arParams[0].Value = UserID;
            arParams[1].Value = UserPassword;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "frame.UpdateUsersPassword", arParams);
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
        //获取用户菜单
        public DataSet GetDataMenuTree(string Passport, string PermitCode)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@Passport", SqlDbType.NVarChar);
            arParams[0].Size = 4000;
            arParams[0].Value = Passport;
            arParams[1] = new SqlParameter("@PermitCode", SqlDbType.NVarChar);
            arParams[1].Size = 4000;
            arParams[1].Value = PermitCode;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "dbo.GetDataMenuTree", arParams);
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


        public DataSet GetDataUsersByUserID(short UserID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@UserID", SqlDbType.SmallInt);
            arParams[0].Value = UserID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "frame.GetDataUsersByUserID", arParams);
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
        public DataSet GetDataUsers()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "frame.GetDataUsers");
            }
            catch { }
            finally
            {
                this.sqlConn.Close();
            }
            return ds;
        }

        public bool InsertUsers(ref string ErrorMsg, ref object UserID, object UserName, object UserPassword, object PsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@UserID", SqlDbType.SmallInt);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@UserName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@UserPassword", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[1].Value = UserName;
            arParams[2].Value = UserPassword;
            arParams[3].Value = PsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "frame.InsertUsers", arParams);
                UserID = arParams[0].Value;
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

        public bool UpdateUsers(ref string ErrorMsg, object UserID, object UserName, object UserPassword, object PsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@UserID", SqlDbType.SmallInt);
            arParams[1] = new SqlParameter("@UserName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@UserPassword", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[0].Value = UserID;
            arParams[1].Value = UserName;
            arParams[2].Value = UserPassword;
            arParams[3].Value = PsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "frame.UpdateUsers", arParams);
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
        public bool UpdateUsersForOffline(ref string ErrorMsg, object UserID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@UserID", SqlDbType.SmallInt);
            arParams[0].Value = UserID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "frame.UpdateUsersForOffline", arParams);
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
        public bool UpdateUsersForOnline(ref string ErrorMsg, object UserID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@UserID", SqlDbType.SmallInt);
            arParams[0].Value = UserID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "frame.UpdateUsersForOnline", arParams);
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
