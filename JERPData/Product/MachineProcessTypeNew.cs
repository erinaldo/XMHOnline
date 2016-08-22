using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;
namespace JERPData.Product
{
    /// <描述>
    /// 表[manuf.MachineProcessTypeNew]数据访问类
    ///</描述> 
    ///<作者> 
    /// 
    ///</作者> 
    ///<时间> 
    /// 2016-08-20 10:21:26
    ///</时间>  
    public class MachineProcessTypeNew
    {
        private SqlConnection sqlConn;
        public MachineProcessTypeNew()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }


        public DataSet GetDataMachineProcessTypeNew()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "manuf.GetDataMachineProcessTypeNew");
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

        public bool InsertMachineProcessTypeNew(ref string ErrorMsg, ref object MachineProcessID, object MachineProcessCode, object MachineProcessName, object MachineProcessMemo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@MachineProcessID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@MachineProcessCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@MachineProcessName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@MachineProcessMemo", SqlDbType.VarChar);
            arParams[3].Size = 400;
            arParams[0].Value = MachineProcessID;
            arParams[1].Value = MachineProcessCode;
            arParams[2].Value = MachineProcessName;
            arParams[3].Value = MachineProcessMemo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.InsertMachineProcessTypeNew", arParams);
                MachineProcessID = arParams[0].Value;
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

        public bool UpdateMachineProcessTypeNew(ref string ErrorMsg, object MachineProcessID, object MachineProcessCode, object MachineProcessName, object MachineProcessMemo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@MachineProcessID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@MachineProcessCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@MachineProcessName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@MachineProcessMemo", SqlDbType.VarChar);
            arParams[3].Size = 400;
            arParams[0].Value = MachineProcessID;
            arParams[1].Value = MachineProcessCode;
            arParams[2].Value = MachineProcessName;
            arParams[3].Value = MachineProcessMemo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateMachineProcessTypeNew", arParams);
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


        public bool DeleteMachineProcessTypeNew(ref string ErrorMsg, object MachineProcessID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@MachineProcessID", SqlDbType.Int);
            arParams[0].Value = MachineProcessID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.DeleteMachineProcessTypeNew", arParams);
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


        public bool GetParmMachineProcessByName(string MachineProcessName, ref int MachineProcessID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@MachineProcessName", SqlDbType.VarChar);
            arParams[0].Size = 50;
            arParams[1] = new SqlParameter("@MachineProcessID", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = MachineProcessName;
            arParams[1].Value = MachineProcessID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "manuf.GetParmMachineProcessByName", arParams);
                MachineProcessID = (int)arParams[1].Value;
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