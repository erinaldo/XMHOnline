using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace JCEData.Frame
{
    public class Users
    {
        private SqlConnection sqlConn = null;
        public Users()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
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
        public bool GetParmUsersLogon(string UserName, string UserPassword, ref short UserID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
            arParams[0].Size = 50;
            arParams[1] = new SqlParameter("@UserPassword", SqlDbType.VarChar);
            arParams[1].Size = 100;
            arParams[2] = new SqlParameter("@UserID", SqlDbType.SmallInt);
            arParams[2].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = UserName;
            arParams[1].Value = UserPassword;
            arParams[2].Value = UserID;
            //try
            //{
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "frame.GetParmUsersLogon", arParams);
                UserID = (short)arParams[2].Value;
                flag = true;
            //}
            //catch//(SqlException ex)
            //{
            //    flag = false;
            //}
            //finally
            //{
                this.sqlConn.Close();
            //}
            return flag;
        }
    }
}
