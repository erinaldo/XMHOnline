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
namespace JERPData.Product
{
    /// <描述>
    /// 表[prd.SalePriceItems]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2013-01-12 15:29:08
    ///</时间>  
    public class SalePriceItems
    {
        private SqlConnection sqlConn;
        public SalePriceItems()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public DataSet GetDataSalePriceItemsPivotCustomer(int MoneyTypeID, int SettleTypeID, int PriceTypeID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@SettleTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@PriceTypeID", SqlDbType.Int);
            arParams[0].Value = MoneyTypeID;
            arParams[1].Value = SettleTypeID;
            arParams[2].Value = PriceTypeID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataSalePriceItemsPivotCustomer", arParams);
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
        public bool DeleteSalePriceItems(ref string ErrorMsg, object ItemID)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.DeleteSalePriceItems", arParams);
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
        public DataSet GetDataSalePriceItemsByNoteID(long NoteID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[0].Value = NoteID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataSalePriceItemsByNoteID", arParams);
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
        public DataSet GetDataSalePriceItemsPivotDateNote(int CompanyID, int MoneyTypeID, int SettleTypeID, int PriceTypeID, DateTime DateFrom)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@SettleTypeID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@PriceTypeID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@DateFrom", SqlDbType.DateTime);
            arParams[0].Value = CompanyID;
            arParams[1].Value = MoneyTypeID;
            arParams[2].Value = SettleTypeID;
            arParams[3].Value = PriceTypeID;
            arParams[4].Value = DateFrom;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataSalePriceItemsPivotDateBegin", arParams);
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
   
        public bool GetParmSalePriceItemsPrice(int CompanyID, int MoneyTypeID, int SettleTypeID, int PriceTypeID, DateTime DateCurrent, int PrdID, ref decimal Price)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[7];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@SettleTypeID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@PriceTypeID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@DateCurrent", SqlDbType.DateTime);
            arParams[5] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[6] = new SqlParameter("@Price", SqlDbType.Decimal);
            arParams[6].Precision = 18;
            arParams[6].Scale = 6;
            arParams[6].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = CompanyID;
            arParams[1].Value = MoneyTypeID;
            arParams[2].Value = SettleTypeID;
            arParams[3].Value = PriceTypeID;
            arParams[4].Value = DateCurrent;
            arParams[5].Value = PrdID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "prd.GetParmSalePriceItemsPrice", arParams);
                Price = (decimal)arParams[6].Value;
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
        public bool InsertSalePriceItems(ref string ErrorMsg, ref object ItemID, object NoteID, object PrdID, object Price, object Memo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@ItemID", SqlDbType.BigInt);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[2] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@Price", SqlDbType.Decimal);
            arParams[3].Precision = 18;
            arParams[3].Scale = 6;
            arParams[4] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[4].Size = 200;
            arParams[1].Value = NoteID;
            arParams[2].Value = PrdID;
            arParams[3].Value = Price;
            arParams[4].Value = Memo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertSalePriceItems", arParams);
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

        public bool UpdateSalePriceItems(ref string ErrorMsg, object ItemID, object PrdID, object Price, object Memo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@ItemID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@Price", SqlDbType.Decimal);
            arParams[2].Precision = 18;
            arParams[2].Scale = 6;
            arParams[3] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[3].Size = 200;
            arParams[0].Value = ItemID;
            arParams[1].Value = PrdID;
            arParams[2].Value = Price;
            arParams[3].Value = Memo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateSalePriceItems", arParams);
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