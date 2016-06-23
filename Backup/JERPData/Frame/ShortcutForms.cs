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
    /// 表[frame.ShortcutForms]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2009-4-9 22:12:04
    ///</时间>  
    public class ShortcutForms
    {
        private SqlConnection sqlConn;
        public ShortcutForms()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public DataSet GetDataShortcutFormsByUser(short UserID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@UserID", SqlDbType.SmallInt);
            arParams[0].Value = UserID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "frame.GetDataShortcutFormsByUser", arParams);
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

        public DataSet GetDataShortcutFormsForSetting(short UserID, string UserPermitCode)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@UserID", SqlDbType.SmallInt);
            arParams[1] = new SqlParameter("@UserPermitCode", SqlDbType.VarChar);
            arParams[1].Size = -1;
            arParams[0].Value = UserID;
            arParams[1].Value = UserPermitCode;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "frame.GetDataShortcutFormsForSetting", arParams);
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


        public bool SaveShortcutForms(ref string ErrorMsg, object UserID, object FormID, object ModifierCode, object KeyCode)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@UserID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@FormID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@ModifierCode", SqlDbType.VarChar);
            arParams[2].Size = 10;
            arParams[3] = new SqlParameter("@KeyCode", SqlDbType.VarChar);
            arParams[3].Size = 10;
            arParams[0].Value = UserID;
            arParams[1].Value = FormID;
            arParams[2].Value = ModifierCode;
            arParams[3].Value = KeyCode;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "frame.SaveShortcutForms", arParams);
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
        public bool DeleteShortcutForms(ref string ErrorMsg, object UserID, object FormID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@UserID", SqlDbType.SmallInt);
            arParams[1] = new SqlParameter("@FormID", SqlDbType.Int);
            arParams[0].Value = UserID;
            arParams[1].Value = FormID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "frame.DeleteShortcutForms", arParams);
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