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
namespace JERPData.Material
{
    /// <描述>
    /// 表[mtr.OutSrcLossSupplyItems]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/11/8 17:07:51
    ///</时间>  
    public class OutSrcLossSupplyItems
    {
        private SqlConnection sqlConn;
        public OutSrcLossSupplyItems()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }


        public bool DeleteOutSrcLossSupplyItems(ref string ErrorMsg, object ItemID)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.DeleteOutSrcLossSupplyItems", arParams);
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
        public DataSet GetDataOutSrcLossSupplyItemsByInvoiceID(long InvoiceID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            arParams[0].Value = InvoiceID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "mtr.GetDataOutSrcLossSupplyItemsByInvoiceID", arParams);
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
        public DataSet GetDataOutSrcLossSupplyItemsByNoteID(long NoteID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[0].Value = NoteID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "mtr.GetDataOutSrcLossSupplyItemsByNoteID", arParams);
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
        public DataSet GetDataOutSrcLossSupplyItemsByReconciliationID(long ReconciliationID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ReconciliationID", SqlDbType.BigInt);
            arParams[0].Value = ReconciliationID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "mtr.GetDataOutSrcLossSupplyItemsByReconciliationID", arParams);
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
        public DataSet GetDataOutSrcLossSupplyItemsForInvoice(long InvoiceID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            arParams[0].Value = InvoiceID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "mtr.GetDataOutSrcLossSupplyItemsForInvoice", arParams);
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
        public DataSet GetDataOutSrcLossSupplyItemsForReconciliation(long ReconciliationID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ReconciliationID", SqlDbType.BigInt);
            arParams[0].Value = ReconciliationID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "mtr.GetDataOutSrcLossSupplyItemsForReconciliation", arParams);
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
        public DataSet GetDataOutSrcLossSupplyItemsNonInvoicePivotMonthAMT()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "mtr.GetDataOutSrcLossSupplyItemsNonInvoicePivotMonthAMT");
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
        public DataSet GetDataOutSrcLossSupplyItemsNonReconciliationPivotMonthAMT()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "mtr.GetDataOutSrcLossSupplyItemsNonReconciliationPivotMonthAMT");
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
        public DataSet GetDataOutSrcLossSupplyItemsFreeSearch(string WhereClause)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@WhereClause", SqlDbType.VarChar);
            arParams[0].Size = 500;
            arParams[0].Value = WhereClause;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "mtr.GetDataOutSrcLossSupplyItemsFreeSearch", arParams);
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
        public bool GetParmOutSrcLossSupplyItemsCountForInvoice(long InvoiceID, ref int Count)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@Count", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = InvoiceID;
            arParams[1].Value = Count;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "mtr.GetParmOutSrcLossSupplyItemsCountForInvoice", arParams);
                Count = (int)arParams[1].Value;
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
        public bool GetParmOutSrcLossSupplyItemsCountForReconciliation(long ReconciliationID, ref int Count)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ReconciliationID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@Count", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = ReconciliationID;
            arParams[1].Value = Count;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "mtr.GetParmOutSrcLossSupplyItemsCountForReconciliation", arParams);
                Count = (int)arParams[1].Value;
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
        public bool InsertOutSrcLossSupplyItems(ref string ErrorMsg, ref object ItemID, object NoteID, object PrdID, object Quantity, object Price, object Memo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@ItemID", SqlDbType.BigInt);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[2] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@Quantity", SqlDbType.Decimal);
            arParams[3].Precision = 18;
            arParams[3].Scale = 4;
            arParams[4] = new SqlParameter("@Price", SqlDbType.Money);
            arParams[5] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[0].Value = ItemID;
            arParams[1].Value = NoteID;
            arParams[2].Value = PrdID;
            arParams[3].Value = Quantity;
            arParams[4].Value = Price;
            arParams[5].Value = Memo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.InsertOutSrcLossSupplyItems", arParams);
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
        public bool UpdateOutSrcLossSupplyItems(ref string ErrorMsg, object ItemID, object PrdID, object Quantity, object Price, object Memo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@ItemID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@Quantity", SqlDbType.Decimal);
            arParams[2].Precision = 18;
            arParams[2].Scale = 4;
            arParams[3] = new SqlParameter("@Price", SqlDbType.Decimal);
            arParams[3].Precision = 18;
            arParams[3].Scale = 4;
            arParams[4] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[0].Value = ItemID;
            arParams[1].Value = PrdID;
            arParams[2].Value = Quantity;
            arParams[3].Value = Price;
            arParams[4].Value = Memo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.UpdateOutSrcLossSupplyItems", arParams);
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
        public bool UpdateOutSrcLossSupplyItemsCancelInvoice(ref string ErrorMsg, object ItemID)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.UpdateOutSrcLossSupplyItemsCancelInvoice", arParams);
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
        public bool UpdateOutSrcLossSupplyItemsCancelReconciliation(ref string ErrorMsg, object ItemID)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.UpdateOutSrcLossSupplyItemsCancelReconciliation", arParams);
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
        public bool UpdateOutSrcLossSupplyItemsForConfirm(ref string ErrorMsg, object ItemID, object BranchStoreID, object CostPrice, object ConfirmPsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@ItemID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@BranchStoreID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@CostPrice", SqlDbType.Money);
            arParams[3] = new SqlParameter("@ConfirmPsnID", SqlDbType.Int);
            arParams[0].Value = ItemID;
            arParams[1].Value = BranchStoreID;
            arParams[2].Value = CostPrice;
            arParams[3].Value = ConfirmPsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.UpdateOutSrcLossSupplyItemsForConfirm", arParams);
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
        public bool UpdateOutSrcLossSupplyItemsForInvoice(ref string ErrorMsg, object ItemID, object InvoiceID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ItemID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            arParams[0].Value = ItemID;
            arParams[1].Value = InvoiceID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.UpdateOutSrcLossSupplyItemsForInvoice", arParams);
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
        public bool UpdateOutSrcLossSupplyItemsForReconciliation(ref string ErrorMsg, object ItemID, object ReconciliationID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ItemID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@ReconciliationID", SqlDbType.BigInt);
            arParams[0].Value = ItemID;
            arParams[1].Value = ReconciliationID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.UpdateOutSrcLossSupplyItemsForReconciliation", arParams);
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

        public bool UpdateOutSrcLossSupplyItemsForPrice(ref string ErrorMsg, object ItemID, object Price)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ItemID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@Price", SqlDbType.Decimal);
            arParams[1].Precision = 18;
            arParams[1].Scale = 4;
            arParams[0].Value = ItemID;
            arParams[1].Value = Price;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.UpdateOutSrcLossSupplyItemsForPrice", arParams);
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