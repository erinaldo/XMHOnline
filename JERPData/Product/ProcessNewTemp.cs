using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;

namespace JERPData.Product
{
    public class ProcessNewTemp
    {
        private SqlConnection sqlConn;
        public ProcessNewTemp()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        //获取所有工序模板的表头
        public DataSet GetDataProcessTempNewNotes()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "manuf.GetDataProcessTempNewNotes");
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

        //获取所有工序模板的表体
        public DataSet GetDataProcessTempNewItems()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "manuf.GetDataProcessTempNewItems");
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

        //获取某个版本的明细工序
        public DataSet GetDataProcessTempNewItemsByProcessTempId(int ProcessTempId)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ProcessTempId", SqlDbType.Int);
            arParams[0].Value = ProcessTempId;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataProcessTempNewItemsByProcessTempId", arParams);
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

        //获取某个版本的明细工序关联其他表的数据
        public DataSet GetDataProcessTempNewItemsByProcessTempIdUnion(int ProcessTempId)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ProcessTempId", SqlDbType.Int);
            arParams[0].Value = ProcessTempId;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataProcessTempNewItemsByProcessTempIdUnion", arParams);
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


        //表头
        public bool InsertProcessTempNewNotes(ref string ErrorMsg, ref object ProcessTempId, object ProcessTempCode, object ProcessTempName, object SumModeMachineTime, object TimeTypeID, object SumTimeCost, object SumMoneyCost, object ProcessMemo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[8];
            arParams[0] = new SqlParameter("@ProcessTempId", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@ProcessTempCode", SqlDbType.VarChar);
            arParams[1].Size = 100;
            arParams[2] = new SqlParameter("@ProcessTempName", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@SumModeMachineTime", SqlDbType.Decimal);
            arParams[3].Precision = 18;
            arParams[3].Scale = 4;
            arParams[4] = new SqlParameter("@TimeTypeID", SqlDbType.Int);
            arParams[5] = new SqlParameter("@SumTimeCost", SqlDbType.Decimal);
            arParams[5].Precision = 18;
            arParams[5].Scale = 4;
            arParams[6] = new SqlParameter("@SumMoneyCost", SqlDbType.Decimal);
            arParams[6].Precision = 18;
            arParams[6].Scale = 4;
            arParams[7] = new SqlParameter("@ProcessMemo", SqlDbType.VarChar);
            arParams[7].Size = 400;
            arParams[0].Value = ProcessTempId;
            arParams[1].Value = ProcessTempCode;
            arParams[2].Value = ProcessTempName;
            arParams[3].Value = SumModeMachineTime;
            arParams[4].Value = TimeTypeID;
            arParams[5].Value = SumTimeCost;
            arParams[6].Value = SumMoneyCost;
            arParams[7].Value = ProcessMemo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.InsertProcessTempNewNotes", arParams);
                ProcessTempId = arParams[0].Value;
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

        //表体
        public bool InsertProcessTempNewItems(ref string ErrorMsg, ref object ItemID, object ProcessTempId, object ProcessTempIndex, object ProcessID, object ModeMachineTime, object TimeTypeID, object TimeCost, object MoneyCost, object ProcessMemo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[9];
            arParams[0] = new SqlParameter("@ItemID", SqlDbType.BigInt);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@ProcessTempId", SqlDbType.Int);
            arParams[2] = new SqlParameter("@ProcessTempIndex", SqlDbType.Int);
            arParams[3] = new SqlParameter("@ProcessID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@ModeMachineTime", SqlDbType.Decimal);
            arParams[4].Precision = 18;
            arParams[4].Scale = 4;
            arParams[5] = new SqlParameter("@TimeTypeID", SqlDbType.Int);
            arParams[6] = new SqlParameter("@TimeCost", SqlDbType.Decimal);
            arParams[6].Precision = 18;
            arParams[6].Scale = 4;
            arParams[7] = new SqlParameter("@MoneyCost", SqlDbType.Decimal);
            arParams[7].Precision = 18;
            arParams[7].Scale = 4;
            arParams[8] = new SqlParameter("@ProcessMemo", SqlDbType.VarChar);
            arParams[8].Size = 400;
            arParams[0].Value = ItemID;
            arParams[1].Value = ProcessTempId;
            arParams[2].Value = ProcessTempIndex;
            arParams[3].Value = ProcessID;
            arParams[4].Value = ModeMachineTime;
            arParams[5].Value = TimeTypeID;
            arParams[6].Value = TimeCost;
            arParams[7].Value = MoneyCost;
            arParams[8].Value = ProcessMemo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.InsertProcessTempNewItems", arParams);
                ItemID = arParams[0].Value;
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


        //更新表头
        public bool UpdateProcessTempNewNotes(ref string ErrorMsg, object ProcessTempId, object ProcessTempCode, object ProcessTempName, object SumModeMachineTime, object TimeTypeID, object SumTimeCost, object SumMoneyCost, object ConfirmPsnID, object ProcessMemo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[9];
            arParams[0] = new SqlParameter("@ProcessTempId", SqlDbType.Int);
            arParams[1] = new SqlParameter("@ProcessTempCode", SqlDbType.VarChar);
            arParams[1].Size = 100;
            arParams[2] = new SqlParameter("@ProcessTempName", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@SumModeMachineTime", SqlDbType.Decimal);
            arParams[3].Precision = 18;
            arParams[3].Scale = 4;
            arParams[4] = new SqlParameter("@TimeTypeID", SqlDbType.Int);
            arParams[5] = new SqlParameter("@SumTimeCost", SqlDbType.Decimal);
            arParams[5].Precision = 18;
            arParams[5].Scale = 4;
            arParams[6] = new SqlParameter("@SumMoneyCost", SqlDbType.Decimal);
            arParams[6].Precision = 18;
            arParams[6].Scale = 4;
            arParams[7] = new SqlParameter("@ConfirmPsnID", SqlDbType.Int);
            arParams[8] = new SqlParameter("@ProcessMemo", SqlDbType.VarChar);
            arParams[8].Size = 400;
            arParams[0].Value = ProcessTempId;
            arParams[1].Value = ProcessTempCode;
            arParams[2].Value = ProcessTempName;
            arParams[3].Value = SumModeMachineTime;
            arParams[4].Value = TimeTypeID;
            arParams[5].Value = SumTimeCost;
            arParams[6].Value = SumMoneyCost;
            arParams[7].Value = ConfirmPsnID;
            arParams[8].Value = ProcessMemo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateProcessTempNewNotes", arParams);
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


        //更新表体
        public bool UpdateProcessTempNewItems(ref string ErrorMsg, object ItemID, object ProcessTempId, object ProcessTempIndex, object ProcessID, object ModeMachineTime, object TimeTypeID, object TimeCost, object MoneyCost, object ProcessMemo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[9];
            arParams[0] = new SqlParameter("@ItemID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@ProcessTempId", SqlDbType.Int);
            arParams[2] = new SqlParameter("@ProcessTempIndex", SqlDbType.Int);
            arParams[3] = new SqlParameter("@ProcessID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@ModeMachineTime", SqlDbType.Decimal);
            arParams[4].Precision = 18;
            arParams[4].Scale = 4;
            arParams[5] = new SqlParameter("@TimeTypeID", SqlDbType.Int);
            arParams[6] = new SqlParameter("@TimeCost", SqlDbType.Decimal);
            arParams[6].Precision = 18;
            arParams[6].Scale = 4;
            arParams[7] = new SqlParameter("@MoneyCost", SqlDbType.Decimal);
            arParams[7].Precision = 18;
            arParams[7].Scale = 4;
            arParams[8] = new SqlParameter("@ProcessMemo", SqlDbType.VarChar);
            arParams[8].Size = 400;
            arParams[0].Value = ItemID;
            arParams[1].Value = ProcessTempId;
            arParams[2].Value = ProcessTempIndex;
            arParams[3].Value = ProcessID;
            arParams[4].Value = ModeMachineTime;
            arParams[5].Value = TimeTypeID;
            arParams[6].Value = TimeCost;
            arParams[7].Value = MoneyCost;
            arParams[8].Value = ProcessMemo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateProcessTempNewItems", arParams);
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



        //删除工序头
        public bool DeleteProcessTempNewNotes(ref string ErrorMsg, object ProcessTempId)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ProcessTempId", SqlDbType.Int);
            arParams[0].Value = ProcessTempId;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.DeleteProcessTempNewNotes", arParams);
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

        //删除 明细
        public bool DeleteProcessTempNewItems(ref string ErrorMsg, object ProcessTempId)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ProcessTempId", SqlDbType.Int);
            arParams[0].Value = ProcessTempId;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.DeleteProcessTempNewItems", arParams);
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

        //删除某个明细
        public bool DeleteProcessTempNewItemsByItemID(ref string ErrorMsg, object ItemID, object ProcessTempId)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ItemID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@ProcessTempId", SqlDbType.Int);
            arParams[0].Value = ItemID;
            arParams[1].Value = ProcessTempId;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.DeleteProcessTempNewItemsByItemID", arParams);
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
