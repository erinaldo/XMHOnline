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
    /// 表[manuf.OutSrcPriceItems]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/4/29 17:39:28
    ///</时间>  
    public class OutSrcPriceItems
    {
        private SqlConnection sqlConn;
        public OutSrcPriceItems()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }


        public bool DeleteOutSrcPriceItems(ref string ErrorMsg, object ItemID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ItemID", SqlDbType.BigInt);
            arParams[0].Value = ItemID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.DeleteOutSrcPriceItems", arParams);
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
        public DataSet GetDataOutSrcPriceItemsByNoteID(long NoteID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[0].Value = NoteID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataOutSrcPriceItemsByNoteID", arParams);
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
        public DataSet GetDataOutSrcPriceItemsPivotDateNote(int CompanyID, int OrderTypeID, int MoneyTypeID, int SettleTypeID, int PriceTypeID, DateTime DateFrom)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@OrderTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@SettleTypeID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@PriceTypeID", SqlDbType.Int);
            arParams[5] = new SqlParameter("@DateFrom", SqlDbType.DateTime);
            arParams[0].Value = CompanyID;
            arParams[1].Value = OrderTypeID;
            arParams[2].Value = MoneyTypeID;
            arParams[3].Value = SettleTypeID;
            arParams[4].Value = PriceTypeID;
            arParams[5].Value = DateFrom;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataOutSrcPriceItemsPivotDateNote", arParams);
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
        public DataSet GetDataOutSrcPriceItemsPivotSupplier(int OrderTypeID, int MoneyTypeID, int SettleTypeID, int PriceTypeID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@OrderTypeID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@SettleTypeID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@PriceTypeID", SqlDbType.Int);
            arParams[0].Value = OrderTypeID;
            arParams[1].Value = MoneyTypeID;
            arParams[2].Value = SettleTypeID;
            arParams[3].Value = PriceTypeID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataOutSrcPriceItemsPivotSupplier", arParams);
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

        public bool GetParmOutSrcPriceItemsPrice(int CompanyID, int OrderTypeID, int MoneyTypeID, int SettleTypeID, int PriceTypeID, DateTime DateCurrent, long ManufProcessID, ref decimal Price)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[8];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@OrderTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@SettleTypeID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@PriceTypeID", SqlDbType.Int);
            arParams[5] = new SqlParameter("@DateCurrent", SqlDbType.DateTime);
            arParams[6] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[7] = new SqlParameter("@Price", SqlDbType.Decimal);
            arParams[7].Precision = 18;
            arParams[7].Scale = 6;
            arParams[7].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = CompanyID;
            arParams[1].Value = OrderTypeID;
            arParams[2].Value = MoneyTypeID;
            arParams[3].Value = SettleTypeID;
            arParams[4].Value = PriceTypeID;
            arParams[5].Value = DateCurrent;
            arParams[6].Value = ManufProcessID;
            arParams[7].Value = Price;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "manuf.GetParmOutSrcPriceItemsPrice", arParams);
                Price = (decimal)arParams[7].Value;
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
        public bool InsertOutSrcPriceItems(ref string ErrorMsg, ref object ItemID, object NoteID, object ManufProcessID, object Price, object Memo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@ItemID", SqlDbType.BigInt);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[2] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[3] = new SqlParameter("@Price", SqlDbType.Decimal);
            arParams[3].Precision = 18;
            arParams[3].Scale = 6;
            arParams[4] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[4].Size = 200;
            arParams[0].Value = ItemID;
            arParams[1].Value = NoteID;
            arParams[2].Value = ManufProcessID;
            arParams[3].Value = Price;
            arParams[4].Value = Memo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.InsertOutSrcPriceItems", arParams);
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
        public bool UpdateOutSrcPriceItems(ref string ErrorMsg, object ItemID, object ManufProcessID, object Price, object Memo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@ItemID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[2] = new SqlParameter("@Price", SqlDbType.Decimal);
            arParams[2].Precision = 18;
            arParams[2].Scale = 6;
            arParams[3] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[3].Size = 200;
            arParams[0].Value = ItemID;
            arParams[1].Value = ManufProcessID;
            arParams[2].Value = Price;
            arParams[3].Value = Memo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateOutSrcPriceItems", arParams);
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