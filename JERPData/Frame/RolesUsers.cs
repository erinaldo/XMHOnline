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
    /// 表[frame.RolesUsers]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2006-8-31 15:46:19
    ///</时间>  
    public class RolesUsers
    {
        private SqlConnection sqlConn;
        public RolesUsers()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }
       

        public DataSet GetDataRolesUsersByRoleID(short RoleID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@RoleID", SqlDbType.SmallInt);
            arParams[0].Value = RoleID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "frame.GetDataRolesUsersByRoleID", arParams);
            }
            catch { }
            finally
            {
                this.sqlConn.Close();
            }
            return ds;
        }

        public DataSet GetDataRolesUsersByUserID(short UserID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@UserID", SqlDbType.SmallInt);
            arParams[0].Value = UserID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "frame.GetDataRolesUsersByUserID", arParams);
            }
            catch { }
            finally
            {
                this.sqlConn.Close();
            }
            return ds;
        }


        public bool InsertRolesUsers(ref int ID, short RoleID, short UserID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@ID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@RoleID", SqlDbType.SmallInt);
            arParams[2] = new SqlParameter("@UserID", SqlDbType.SmallInt);
            arParams[1].Value = RoleID;
            arParams[2].Value = UserID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "frame.InsertRolesUsers", arParams);
                ID = (int)arParams[0].Value;
                DBTransaction.Commit();
                flag = true;
            }
            catch
            {
                flag = false;
                DBTransaction.Rollback();//--回退事务
            }
            finally
            {
                this.sqlConn.Close();
            }
            return flag;
        }
        public bool UpdateRolesUsers(int ID, short RoleID, short UserID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@ID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@RoleID", SqlDbType.SmallInt);
            arParams[2] = new SqlParameter("@UserID", SqlDbType.SmallInt);
            arParams[0].Value = ID;
            arParams[1].Value = RoleID;
            arParams[2].Value = UserID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "frame.UpdateRolesUsers", arParams);
                DBTransaction.Commit();
                flag = true;
            }
            catch
            {
                flag = false;
                DBTransaction.Rollback();//--回退事务
            }
            finally
            {
                this.sqlConn.Close();
            }
            return flag;
        }
        public bool DeleteRolesUsers(short RoleID, short UserID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@RoleID", SqlDbType.SmallInt);
            arParams[1] = new SqlParameter("@UserID", SqlDbType.SmallInt);
            arParams[0].Value = RoleID;
            arParams[1].Value = UserID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "frame.DeleteRolesUsers", arParams);
                DBTransaction.Commit();
                flag = true;
            }
            catch
            {
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