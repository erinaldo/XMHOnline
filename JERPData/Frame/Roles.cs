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
    /// 表[frame.Roles]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2006-8-31 13:32:10
    ///</时间>  
    public class Roles
    {
        private SqlConnection sqlConn;
        public Roles()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }
       
        public DataSet GetDataRoles()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "frame.GetDataRoles");
            }
            catch { }
            finally
            {
                this.sqlConn.Close();
            }
            return ds;
        }
        //获取该用户的所有角色值列表,供处理
        public DataSet GetDataRoleValuesByUserID(short UserID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@UserID", SqlDbType.SmallInt);
            arParams[0].Value = UserID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "frame.GetDataRoleValuesByUserID", arParams);
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
        public DataSet GetDataRolesByRoleID(short RoleID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@RoleID", SqlDbType.SmallInt);
            arParams[0].Value = RoleID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "frame.GetDataRolesByRoleID", arParams);
            }
            catch { }
            finally
            {
                this.sqlConn.Close();
            }
            return ds;
        }

        public bool InsertRoles(ref object RoleID, object RoleName, object SubjectKey, object RoleValue, object Description)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@RoleID", SqlDbType.SmallInt);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@RoleName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@SubjectKey", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@RoleValue", SqlDbType.VarChar);
            arParams[3].Size = -1;
            arParams[4] = new SqlParameter("@Description", SqlDbType.VarChar);
            arParams[4].Size = -1;
            arParams[1].Value = RoleName;
            arParams[2].Value = SubjectKey;
            arParams[3].Value = RoleValue;
            arParams[4].Value = Description;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "frame.InsertRoles", arParams);
                RoleID = arParams[0].Value;
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

        public bool UpdateRoles(object RoleID, object RoleName, object SubjectKey, object Description)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@RoleID", SqlDbType.SmallInt);
            arParams[1] = new SqlParameter("@RoleName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@SubjectKey", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@Description", SqlDbType.VarChar);
            arParams[3].Size = -1;
            arParams[0].Value = RoleID;
            arParams[1].Value = RoleName;
            arParams[2].Value = SubjectKey;
            arParams[3].Value = Description;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "frame.UpdateRoles", arParams);
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
        public bool DeleteRoles(short RoleID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@RoleID", SqlDbType.SmallInt);
            arParams[0].Value = RoleID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "frame.DeleteRoles", arParams);
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

        public bool UpdateRolesRoleValue(object RoleID, object RoleValue)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@RoleID", SqlDbType.SmallInt);
            arParams[1] = new SqlParameter("@RoleValue", SqlDbType.VarChar);
            arParams[1].Size = -1;
            arParams[0].Value = RoleID;
            arParams[1].Value = RoleValue;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "frame.UpdateRolesRoleValue", arParams);
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

    }
}