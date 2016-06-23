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
namespace JERPData.Technology
{
    /// <描述>
    /// 表[tech.FileStatus]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2012-3-28 12:57:34
    ///</时间>  
    public class FileStatus
    {
        private SqlConnection sqlConn;
        public FileStatus()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }
        public bool DeleteFileStatus(ref string ErrorMsg, object FileID, object IsUseFlag, object DeptID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@FileID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@IsUseFlag", SqlDbType.Bit);
            arParams[2] = new SqlParameter("@DeptID", SqlDbType.Int);
            arParams[0].Value = FileID;
            arParams[1].Value = IsUseFlag;
            arParams[2].Value = DeptID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "tech.DeleteFileStatus", arParams);
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

        public DataSet GetDataFileStatusByFileTypeID(int FileTypeID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@FileTypeID", SqlDbType.Int);
            arParams[0].Value = FileTypeID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "tech.GetDataFileStatusByFileTypeID", arParams);
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
        public bool SaveFileStatus(ref string ErrorMsg, object FileID, object IsUseFlag, object DeptID, object Quantity)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@FileID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@IsUseFlag", SqlDbType.Bit);
            arParams[2] = new SqlParameter("@DeptID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@Quantity", SqlDbType.Int);
            arParams[0].Value = FileID;
            arParams[1].Value = IsUseFlag;
            arParams[2].Value = DeptID;
            arParams[3].Value = Quantity;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "tech.SaveFileStatus", arParams);
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