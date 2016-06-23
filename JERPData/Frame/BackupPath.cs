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
    /// 表[frame.BackupPath]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2012-5-31 18:17:18
    ///</时间>  
    public class BackupPath
    {
        private SqlConnection sqlConn;
        public BackupPath()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public bool GetParmBackupPath(ref string BackupPath)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@BackupPath", SqlDbType.VarChar);
            arParams[0].Size = 100;
            arParams[0].Direction = ParameterDirection.InputOutput;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "frame.GetParmBackupPath", arParams);
                BackupPath = (string)arParams[0].Value;
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
        public bool SaveBackupPath(ref string ErrorMsg, object BackupPath)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@BackupPath", SqlDbType.VarChar);
            arParams[0].Size = 100;
            arParams[0].Value = BackupPath;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "frame.SaveBackupPath", arParams);
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