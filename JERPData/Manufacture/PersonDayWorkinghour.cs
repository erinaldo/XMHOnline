
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;
namespace JERPData.Product
{
    /// <描述>
    /// 表[manuf.PersonDayWorkinghourNotes]数据访问类
    ///</描述> 
    ///<作者> 
    /// 
    ///</作者> 
    ///<时间> 
    /// 2016-08-26 15:37:54
    ///</时间>  
    public class PersonDayWorkinghour
    {
        private SqlConnection sqlConn;
        public PersonDayWorkinghour()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        ////表头

        public DataSet GetDataPersonDayWorkinghourNotesByWorkDate(DateTime WorkDate)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@WorkDate", SqlDbType.DateTime);
            arParams[0].Value = WorkDate;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataPersonDayWorkinghourNotesByWorkDate", arParams);
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


        public DataSet GetDataPersonDayWorkinghourNotesByWorkingDayID(long WorkingDayID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@WorkingDayID", SqlDbType.BigInt);
            arParams[0].Value = WorkingDayID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataPersonDayWorkinghourNotesByWorkingDayID", arParams);
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


        public bool InsertPersonDayWorkinghourNotes(ref string ErrorMsg, ref object WorkingDayID, object WorkDate, object PsnID, object WorkingTimeTypeID, object WorkTime, object ConfirmPsnID, object WorkingMemo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[7];
            arParams[0] = new SqlParameter("@WorkingDayID", SqlDbType.BigInt);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@WorkDate", SqlDbType.DateTime);
            arParams[2] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@WorkingTimeTypeID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@WorkTime", SqlDbType.Decimal);
            arParams[4].Precision = 18;
            arParams[4].Scale = 4;
            arParams[5] = new SqlParameter("@ConfirmPsnID", SqlDbType.Int);
            arParams[6] = new SqlParameter("@WorkingMemo", SqlDbType.VarChar);
            arParams[6].Size = 400;
            arParams[0].Value = WorkingDayID;
            arParams[1].Value = WorkDate;
            arParams[2].Value = PsnID;
            arParams[3].Value = WorkingTimeTypeID;
            arParams[4].Value = WorkTime;
            arParams[5].Value = ConfirmPsnID;
            arParams[6].Value = WorkingMemo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.InsertPersonDayWorkinghourNotes", arParams);
                WorkingDayID = arParams[0].Value;
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

        public bool UpdatePersonDayWorkinghourNotes(ref string ErrorMsg, object WorkingDayID, object WorkDate, object PsnID, object WorkingTimeTypeID, object WorkTime, object WorkingMemo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@WorkingDayID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@WorkDate", SqlDbType.DateTime);
            arParams[2] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@WorkingTimeTypeID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@WorkTime", SqlDbType.Decimal);
            arParams[4].Precision = 18;
            arParams[4].Scale = 4;
            arParams[5] = new SqlParameter("@WorkingMemo", SqlDbType.VarChar);
            arParams[5].Size = 400;
            arParams[0].Value = WorkingDayID;
            arParams[1].Value = WorkDate;
            arParams[2].Value = PsnID;
            arParams[3].Value = WorkingTimeTypeID;
            arParams[4].Value = WorkTime;
            arParams[5].Value = WorkingMemo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdatePersonDayWorkinghourNotes", arParams);
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

        public bool DeletePersonDayWorkinghourNotes(ref string ErrorMsg, object WorkingDayID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@WorkingDayID", SqlDbType.BigInt);
            arParams[0].Value = WorkingDayID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.DeletePersonDayWorkinghourNotes", arParams);
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



        ////表体

        public DataSet GetDataPersonDayWorkinghourItemsByWorkingDayID(long WorkingDayID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@WorkingDayID", SqlDbType.BigInt);
            arParams[0].Value = WorkingDayID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataPersonDayWorkinghourItemsByWorkingDayID", arParams);
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


        public DataSet GetDataPersonDayWorkinghourItemsByItemIDAndWorkingDayID(long ItemID, long WorkingDayID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ItemID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@WorkingDayID", SqlDbType.BigInt);
            arParams[0].Value = ItemID;
            arParams[1].Value = WorkingDayID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataPersonDayWorkinghourItemsByItemIDAndWorkingDayID", arParams);
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




        public bool InsertPersonDayWorkinghourItems(ref string ErrorMsg, ref object ItemID, object WorkingDayID, object ProcessTempIndex, object ProcessID, object ModeMachineTime, object TimeTypeID, object TimeCost, object MoneyCost, object TimeCount, object TotalTimeCost, object TotalMoneyCost, object ProcessMemo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[12];
            arParams[0] = new SqlParameter("@ItemID", SqlDbType.BigInt);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@WorkingDayID", SqlDbType.BigInt);
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
            arParams[8] = new SqlParameter("@TimeCount", SqlDbType.Decimal);
            arParams[8].Precision = 18;
            arParams[8].Scale = 4;
            arParams[9] = new SqlParameter("@TotalTimeCost", SqlDbType.Decimal);
            arParams[9].Precision = 18;
            arParams[9].Scale = 4;
            arParams[10] = new SqlParameter("@TotalMoneyCost", SqlDbType.Decimal);
            arParams[10].Precision = 18;
            arParams[10].Scale = 4;
            arParams[11] = new SqlParameter("@ProcessMemo", SqlDbType.VarChar);
            arParams[11].Size = 400;
            arParams[0].Value = ItemID;
            arParams[1].Value = WorkingDayID;
            arParams[2].Value = ProcessTempIndex;
            arParams[3].Value = ProcessID;
            arParams[4].Value = ModeMachineTime;
            arParams[5].Value = TimeTypeID;
            arParams[6].Value = TimeCost;
            arParams[7].Value = MoneyCost;
            arParams[8].Value = TimeCount;
            arParams[9].Value = TotalTimeCost;
            arParams[10].Value = TotalMoneyCost;
            arParams[11].Value = ProcessMemo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.InsertPersonDayWorkinghourItems", arParams);
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




        public bool UpdatePersonDayWorkinghourItems(ref string ErrorMsg, object ItemID, object WorkingDayID, object ProcessTempIndex, object ProcessID, object ModeMachineTime, object TimeTypeID, object TimeCost, object MoneyCost, object TimeCount, object TotalTimeCost, object TotalMoneyCost, object ProcessMemo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[12];
            arParams[0] = new SqlParameter("@ItemID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@WorkingDayID", SqlDbType.BigInt);
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
            arParams[8] = new SqlParameter("@TimeCount", SqlDbType.Decimal);
            arParams[8].Precision = 18;
            arParams[8].Scale = 4;
            arParams[9] = new SqlParameter("@TotalTimeCost", SqlDbType.Decimal);
            arParams[9].Precision = 18;
            arParams[9].Scale = 4;
            arParams[10] = new SqlParameter("@TotalMoneyCost", SqlDbType.Decimal);
            arParams[10].Precision = 18;
            arParams[10].Scale = 4;
            arParams[11] = new SqlParameter("@ProcessMemo", SqlDbType.VarChar);
            arParams[11].Size = 400;
            arParams[0].Value = ItemID;
            arParams[1].Value = WorkingDayID;
            arParams[2].Value = ProcessTempIndex;
            arParams[3].Value = ProcessID;
            arParams[4].Value = ModeMachineTime;
            arParams[5].Value = TimeTypeID;
            arParams[6].Value = TimeCost;
            arParams[7].Value = MoneyCost;
            arParams[8].Value = TimeCount;
            arParams[9].Value = TotalTimeCost;
            arParams[10].Value = TotalMoneyCost;
            arParams[11].Value = ProcessMemo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdatePersonDayWorkinghourItems", arParams);
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


        public bool DeletePersonDayWorkinghourItems(ref string ErrorMsg, object ItemID, object WorkingDayID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ItemID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@WorkingDayID", SqlDbType.BigInt);
            arParams[0].Value = ItemID;
            arParams[1].Value = WorkingDayID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.DeletePersonDayWorkinghourItems", arParams);
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



        public bool DeletePersonDayWorkinghourItemsByWorkingDayID(ref string ErrorMsg, object WorkingDayID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@WorkingDayID", SqlDbType.BigInt);
            arParams[0].Value = WorkingDayID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.DeletePersonDayWorkinghourItemsByWorkingDayID", arParams);
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