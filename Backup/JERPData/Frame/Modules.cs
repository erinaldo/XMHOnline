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
    /// 表[frame.Modules]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2006-10-15 18:18:42
    ///</时间>  
    public class Modules
    {
        private SqlConnection sqlConn;
        public Modules()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public DataSet GetDataModuleTreeByPermitCode(int ParentID, string Tag, string Prefix, string PermitCode)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@ParentID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@Tag", SqlDbType.VarChar);
            arParams[1].Size = 10;
            arParams[2] = new SqlParameter("@Prefix", SqlDbType.VarChar);
            arParams[2].Size = 200;
            arParams[3] = new SqlParameter("@PermitCode", SqlDbType.VarChar);
            arParams[3].Size = -1;
            arParams[0].Value = ParentID;
            arParams[1].Value = Tag;
            arParams[2].Value = Prefix;
            arParams[3].Value = PermitCode;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "frame.GetDataModuleTreeByPermitCode", arParams);
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
        public DataSet GetDataModuleTreeRemindByPermitCode(int ParentID, string Tag, string Prefix, string PermitCode)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@ParentID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@Tag", SqlDbType.VarChar);
            arParams[1].Size = 10;
            arParams[2] = new SqlParameter("@Prefix", SqlDbType.VarChar);
            arParams[2].Size = 200;
            arParams[3] = new SqlParameter("@PermitCode", SqlDbType.VarChar);
            arParams[3].Size = -1;
            arParams[0].Value = ParentID;
            arParams[1].Value = Tag;
            arParams[2].Value = Prefix;
            arParams[3].Value = PermitCode;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "frame.GetDataModuleTreeRemindByPermitCode", arParams);
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
        public DataSet GetDataModuleTreeValidate(int ParentID, string Tag, string Prefix)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@ParentID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@Tag", SqlDbType.VarChar);
            arParams[1].Size = 10;
            arParams[2] = new SqlParameter("@Prefix", SqlDbType.VarChar);
            arParams[2].Size = 200;
            arParams[0].Value = ParentID;
            arParams[1].Value = Tag;
            arParams[2].Value = Prefix;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "frame.GetDataModuleTreeValidate", arParams);
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

        public DataSet GetDataModuleByModuleID(int ModuleID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ModuleID", SqlDbType.Int);
            arParams[0].Value = ModuleID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "frame.GetDataModuleByModuleID", arParams);
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

        public DataSet GetDataModuleTree(int ParentID, string Tag, string Prefix)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@ParentID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@Tag", SqlDbType.VarChar);
            arParams[1].Size = 10;
            arParams[2] = new SqlParameter("@Prefix", SqlDbType.VarChar);
            arParams[2].Size = 200;
            arParams[0].Value = ParentID;
            arParams[1].Value = Tag;
            arParams[2].Value = Prefix;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "frame.GetDataModuleTree", arParams);
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


    }
}