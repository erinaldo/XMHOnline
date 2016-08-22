using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;
namespace JERPData.Product
{
    /// <描述>
    /// 表[manuf.ProcessNew]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016-08-20 13:11:26
    ///</时间>  
    public class ProcessNew
    {
        private SqlConnection sqlConn;
        public ProcessNew()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        //获取数据
        public DataSet GetDataProcessNew()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "manuf.GetDataProcessNew");
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


        //插入数据
        public bool InsertProcessNew(ref string ErrorMsg, ref object ProcessID, object ProcessCode, object ProcessName, object ModeMachineTime, object TimeCost, object TimeTypeID, object UseMachineID, object ModelID, object ToolsID, object MoneyCost, object ConfirmPsnID, object ProcessMemo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[12];
            arParams[0] = new SqlParameter("@ProcessID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@ProcessCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@ProcessName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@ModeMachineTime", SqlDbType.Decimal);
            arParams[3].Precision = 18;
            arParams[3].Scale = 4;
            arParams[4] = new SqlParameter("@TimeCost", SqlDbType.Decimal);
            arParams[4].Precision = 18;
            arParams[4].Scale = 4;
            arParams[5] = new SqlParameter("@TimeTypeID", SqlDbType.Int);
            arParams[6] = new SqlParameter("@UseMachineID", SqlDbType.Int);
            arParams[7] = new SqlParameter("@ModelID", SqlDbType.Int);
            arParams[8] = new SqlParameter("@ToolsID", SqlDbType.Int);
            arParams[9] = new SqlParameter("@MoneyCost", SqlDbType.Decimal);
            arParams[9].Precision = 18;
            arParams[9].Scale = 4;
            arParams[10] = new SqlParameter("@ConfirmPsnID", SqlDbType.Int);
            arParams[11] = new SqlParameter("@ProcessMemo", SqlDbType.VarChar);
            arParams[11].Size = 400;
            arParams[0].Value = ProcessID;
            arParams[1].Value = ProcessCode;
            arParams[2].Value = ProcessName;
            arParams[3].Value = ModeMachineTime;
            arParams[4].Value = TimeCost;
            arParams[5].Value = TimeTypeID;
            arParams[6].Value = UseMachineID;
            arParams[7].Value = ModelID;
            arParams[8].Value = ToolsID;
            arParams[9].Value = MoneyCost;
            arParams[10].Value = ConfirmPsnID;
            arParams[11].Value = ProcessMemo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.InsertProcessNew", arParams);
                ProcessID = arParams[0].Value;
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

        //更新数据
        public bool UpdateProcessNew(ref string ErrorMsg, object ProcessID, object ProcessCode, object ProcessName, object ModeMachineTime, object TimeCost, object TimeTypeID, object UseMachineID, object ModelID, object ToolsID, object MoneyCost, object ProcessMemo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[11];
            arParams[0] = new SqlParameter("@ProcessID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@ProcessCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@ProcessName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@ModeMachineTime", SqlDbType.Decimal);
            arParams[3].Precision = 18;
            arParams[3].Scale = 4;
            arParams[4] = new SqlParameter("@TimeCost", SqlDbType.Decimal);
            arParams[4].Precision = 18;
            arParams[4].Scale = 4;
            arParams[5] = new SqlParameter("@TimeTypeID", SqlDbType.Int);
            arParams[6] = new SqlParameter("@UseMachineID", SqlDbType.Int);
            arParams[7] = new SqlParameter("@ModelID", SqlDbType.Int);
            arParams[8] = new SqlParameter("@ToolsID", SqlDbType.Int);
            arParams[9] = new SqlParameter("@MoneyCost", SqlDbType.Decimal);
            arParams[9].Precision = 18;
            arParams[9].Scale = 4;
            arParams[10] = new SqlParameter("@ProcessMemo", SqlDbType.VarChar);
            arParams[10].Size = 400;
            arParams[0].Value = ProcessID;
            arParams[1].Value = ProcessCode;
            arParams[2].Value = ProcessName;
            arParams[3].Value = ModeMachineTime;
            arParams[4].Value = TimeCost;
            arParams[5].Value = TimeTypeID;
            arParams[6].Value = UseMachineID;
            arParams[7].Value = ModelID;
            arParams[8].Value = ToolsID;
            arParams[9].Value = MoneyCost;
            arParams[10].Value = ProcessMemo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateProcessNew", arParams);
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

        //删除数据
        public bool DeleteProcessNew(ref string ErrorMsg, object ProcessID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ProcessID", SqlDbType.Int);
            arParams[0].Value = ProcessID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.DeleteProcessNew", arParams);
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



        public bool GetParmProcessNewProcessID(string ProcessCode, ref int ProcessID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ProcessCode", SqlDbType.VarChar);
            arParams[0].Size = 50;
            arParams[1] = new SqlParameter("@ProcessID", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = ProcessCode;
            arParams[1].Value = ProcessID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "manuf.GetParmProcessNewProcessID", arParams);
                ProcessID = (int)arParams[1].Value;
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