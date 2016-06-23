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
namespace JERPData.Manufacture
{
    /// <描述>
    /// 表[manuf.ManufProcess]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/4/11 11:20:16
    ///</时间>  
    public class ManufProcess
    {
        private SqlConnection sqlConn;
        public ManufProcess()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public DataSet GetDataManufProcessByProcessTypeID(int ProcessTypeID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ProcessTypeID", SqlDbType.Int);
            arParams[0].Value = ProcessTypeID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataManufProcessByProcessTypeID", arParams);
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
        public bool GetParmManufProcessFinalManufProcessID(int PrdID, ref long ManufProcessID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = PrdID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "manuf.GetParmManufProcessFinalManufProcessID", arParams);
                ManufProcessID = (long)arParams[1].Value;
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
        public bool DeleteManufProcess(ref string ErrorMsg, object ManufProcessID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[0].Value = ManufProcessID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.DeleteManufProcess", arParams);
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
        public DataSet GetDataManufProcessByPrdID(int PrdID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[0].Value = PrdID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataManufProcessByPrdID", arParams);
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

        public bool GetParmManufProcessLaborPrice(long ManufProcessID, ref decimal LaborPrice)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@LaborPrice", SqlDbType.Money);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = ManufProcessID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "manuf.GetParmManufProcessLaborPrice", arParams);
                LaborPrice = (decimal)arParams[1].Value;
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
        public bool GetParmManufProcessReworkLaborPrice(long ManufProcessID, ref decimal ReworkLaborPrice)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@ReworkLaborPrice", SqlDbType.Money);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = ManufProcessID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "manuf.GetParmManufProcessReworkLaborPrice", arParams);
                ReworkLaborPrice = (decimal)arParams[1].Value;
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
        public bool GetParmManufProcessDayManufQty(long ManufProcessID, ref decimal DayManufQty)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@DayManufQty", SqlDbType.Money);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = ManufProcessID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "manuf.GetParmManufProcessDayManufQty", arParams);
                DayManufQty = (decimal)arParams[1].Value;
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
        public bool GetParmManufProcessMemo(long ManufProcessID, ref string Memo)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[1].Size = -1;
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = ManufProcessID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "manuf.GetParmManufProcessMemo", arParams);
                Memo = (string)arParams[1].Value;
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

        public bool GetParmManufProcessCostPrice(long ManufProcessID, ref decimal CostPrice)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@CostPrice", SqlDbType.Decimal);
            arParams[1].Precision = 20;
            arParams[1].Scale = 4;
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = ManufProcessID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "manuf.GetParmManufProcessCostPrice", arParams);
                CostPrice = (decimal)arParams[1].Value;
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
        public DataSet GetDataManufProcessByManufProcessID(long ManufProcessID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[0].Value = ManufProcessID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataManufProcessByManufProcessID", arParams);
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
        public DataSet GetDataManufProcess()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "manuf.GetDataManufProcess");
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



        public bool InsertManufProcess(ref string ErrorMsg, ref object ManufProcessID, object PrdID, object SerialNo, object ProcessTypeID, object Memo, object MouldCode, object OutSrcFlag, object OutSrcCompanyID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[8];
            arParams[0] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@SerialNo", SqlDbType.Int);
            arParams[3] = new SqlParameter("@ProcessTypeID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[4].Size = 200;
            arParams[5] = new SqlParameter("@MouldCode", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@OutSrcFlag", SqlDbType.Bit);
            arParams[7] = new SqlParameter("@OutSrcCompanyID", SqlDbType.Int);
            arParams[0].Value = ManufProcessID;
            arParams[1].Value = PrdID;
            arParams[2].Value = SerialNo;
            arParams[3].Value = ProcessTypeID;
            arParams[4].Value = Memo;
            arParams[5].Value = MouldCode;
            arParams[6].Value = OutSrcFlag;
            arParams[7].Value = OutSrcCompanyID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.InsertManufProcess", arParams);
                ManufProcessID = arParams[0].Value;
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
        public bool InsertManufProcessForCopy(ref string ErrorMsg, object SrcPrdID, object NewPrdID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@SrcPrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@NewPrdID", SqlDbType.Int);
            arParams[0].Value = SrcPrdID;
            arParams[1].Value = NewPrdID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.InsertManufProcessForCopy", arParams);
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

        public bool UpdateManufProcess(ref string ErrorMsg, object ManufProcessID, object SerialNo, object ProcessTypeID, object Memo, object MouldCode, object OutSrcFlag, object OutSrcCompanyID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[7];
            arParams[0] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@SerialNo", SqlDbType.Int);
            arParams[2] = new SqlParameter("@ProcessTypeID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[3].Size = 200;
            arParams[4] = new SqlParameter("@MouldCode", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@OutSrcFlag", SqlDbType.Bit);
            arParams[6] = new SqlParameter("@OutSrcCompanyID", SqlDbType.Int);
            arParams[0].Value = ManufProcessID;
            arParams[1].Value = SerialNo;
            arParams[2].Value = ProcessTypeID;
            arParams[3].Value = Memo;
            arParams[4].Value = MouldCode;
            arParams[5].Value = OutSrcFlag;
            arParams[6].Value = OutSrcCompanyID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateManufProcess", arParams);
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
        public bool UpdateManufProcessForFileCount(ref string ErrorMsg, object ManufProcessID, object FileCount)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@FileCount", SqlDbType.Int);
            arParams[0].Value = ManufProcessID;
            arParams[1].Value = FileCount;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateManufProcessForFileCount", arParams);
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
        public bool UpdateManufProcessForLaborPrice(ref string ErrorMsg, object ManufProcessID, object LaborPrice, object ReworkLaborPrice)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@LaborPrice", SqlDbType.Decimal);
            arParams[1].Precision = 18;
            arParams[1].Scale = 4;
            arParams[2] = new SqlParameter("@ReworkLaborPrice", SqlDbType.Decimal);
            arParams[2].Precision = 18;
            arParams[2].Scale = 4;
            arParams[0].Value = ManufProcessID;
            arParams[1].Value = LaborPrice;
            arParams[2].Value = ReworkLaborPrice;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateManufProcessForLaborPrice", arParams);
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
        public bool UpdateManufProcessForLastCostPrice(ref string ErrorMsg, object ManufProcessID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[0].Value = ManufProcessID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateManufProcessForLastCostPrice", arParams);
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
        public bool UpdateManufProcessForMtrCostPrice(ref string ErrorMsg, object ManufProcessID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[0].Value = ManufProcessID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateManufProcessForMtrCostPrice", arParams);
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
        public bool UpdateManufProcessForProcessCostPrice(ref string ErrorMsg, object ManufProcessID, object ProcessCostPrice)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@ProcessCostPrice", SqlDbType.Decimal);
            arParams[1].Precision = 18;
            arParams[1].Scale = 4;
            arParams[0].Value = ManufProcessID;
            arParams[1].Value = ProcessCostPrice;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateManufProcessForProcessCostPrice", arParams);
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