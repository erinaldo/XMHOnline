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
    /// 表[frame.Forms]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2006-8-28 20:49:53
    ///</时间>  
    public class Forms
    {
        private SqlConnection sqlConn;
        public Forms()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }


        public DataSet GetDataFormByFormID(int FormID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@FormID", SqlDbType.Int);
            arParams[0].Value = FormID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "frame.GetDataFormByFormID", arParams);
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

        public DataSet GetDataFormByModuleID(int ModuleID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ModuleID", SqlDbType.Int);
            arParams[0].Value = ModuleID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "frame.GetDataFormByModuleID", arParams);
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
        public DataSet GetDataFormPermitMsgByModule(int ModuleID, short RoleID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ModuleID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@RoleID", SqlDbType.SmallInt);
            arParams[0].Value = ModuleID;
            arParams[1].Value = RoleID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "frame.GetDataFormPermitMsgByModule", arParams);
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


        public DataSet GetDataFormsByModuleIDLists(string ModuleIDLists)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ModuleIDLists", SqlDbType.VarChar);
            arParams[0].Size = -1;
            arParams[0].Value = ModuleIDLists;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "frame.GetDataFormsByModuleIDLists", arParams);
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
        public DataSet GetDataFormsByModulePermitCode(int ModuleID, string PermitCode)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ModuleID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PermitCode", SqlDbType.VarChar);
            arParams[1].Size = -1;
            arParams[0].Value = ModuleID;
            arParams[1].Value = PermitCode;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "frame.GetDataFormsByModulePermitCode", arParams);
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
        public DataSet GetDataFormsByPermitCode(string PermitCode)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PermitCode", SqlDbType.VarChar);
            arParams[0].Size = -1;
            arParams[0].Value = PermitCode;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "frame.GetDataFormsByPermitCode", arParams);
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
        public DataSet GetDataFormsRemindByPermitCode(string PermitCode)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PermitCode", SqlDbType.VarChar);
            arParams[0].Size = -1;
            arParams[0].Value = PermitCode;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "frame.GetDataFormsRemindByPermitCode", arParams);
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
        //获取窗体所在位置
        public bool GetParmFormPosition(int FormID, ref string FormPosition)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@FormID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@FormPosition", SqlDbType.VarChar);
            arParams[1].Size = 1000;
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = FormID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "frame.GetParmFormPosition", arParams);
                FormPosition = (string)arParams[1].Value;
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

        public bool GetParmFormsRemindFlag(int FormID, int PsnID, ref bool RemindFlag)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@FormID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@RemindFlag", SqlDbType.Bit);
            arParams[2].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = FormID;
            arParams[1].Value = PsnID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "frame.GetParmFormsRemindFlag", arParams);
                RemindFlag = (bool)arParams[2].Value;
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

    }
}