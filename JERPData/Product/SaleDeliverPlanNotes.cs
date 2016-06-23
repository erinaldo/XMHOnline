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
    /// 表[prd.SaleDeliverPlanNotes]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/9/25 8:24:08
    ///</时间>  
    public class SaleDeliverPlanNotes
    {
        private SqlConnection sqlConn;
        public SaleDeliverPlanNotes()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }
        public bool DeleteSaleDeliverPlanNotes(ref string ErrorMsg, object NoteID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[0].Value = NoteID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.DeleteSaleDeliverPlanNotes", arParams);
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
        public DataSet GetDataSaleDeliverPlanNotesByNoteID(long NoteID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[0].Value = NoteID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataSaleDeliverPlanNotesByNoteID", arParams);
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
        public bool GetParmSaleDeliverPlanNotesNoteIDBySaleOrderNoteID(long SaleOrderNoteID, ref long NoteID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@SaleOrderNoteID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = SaleOrderNoteID;
            arParams[1].Value = NoteID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "prd.GetParmSaleDeliverPlanNotesNoteIDBySaleOrderNoteID", arParams);
                NoteID = (long)arParams[1].Value;
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
        public DataSet GetDataSaleDeliverPlanNotesForDeliver()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "prd.GetDataSaleDeliverPlanNotesForDeliver");
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

        public DataSet GetDataSaleDeliverPlanNotesForAlter(int MakerPsnID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@MakerPsnID", SqlDbType.Int);
            arParams[0].Value = MakerPsnID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataSaleDeliverPlanNotesForAlter", arParams);
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
        public bool InsertSaleDeliverPlanNotes(ref string ErrorMsg, ref object NoteID, object DateTarget, object SaleOrderNoteID, object CompanyID, object DeliverAddressID, object FinanceAddressID, object DeliverTypeID, object ExpressRequire, object MoneyTypeID, object SettleTypeID, object PriceTypeID, object InvoiceTypeID, object MakerPsnID, object Memo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[14];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@DateTarget", SqlDbType.DateTime);
            arParams[2] = new SqlParameter("@SaleOrderNoteID", SqlDbType.BigInt);
            arParams[3] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@DeliverAddressID", SqlDbType.Int);
            arParams[5] = new SqlParameter("@FinanceAddressID", SqlDbType.Int);
            arParams[6] = new SqlParameter("@DeliverTypeID", SqlDbType.Int);
            arParams[7] = new SqlParameter("@ExpressRequire", SqlDbType.VarChar);
            arParams[7].Size = 100;
            arParams[8] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[9] = new SqlParameter("@SettleTypeID", SqlDbType.Int);
            arParams[10] = new SqlParameter("@PriceTypeID", SqlDbType.Int);
            arParams[11] = new SqlParameter("@InvoiceTypeID", SqlDbType.Int);
            arParams[12] = new SqlParameter("@MakerPsnID", SqlDbType.Int);
            arParams[13] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[13].Size = 200;
            arParams[0].Value = NoteID;
            arParams[1].Value = DateTarget;
            arParams[2].Value = SaleOrderNoteID;
            arParams[3].Value = CompanyID;
            arParams[4].Value = DeliverAddressID;
            arParams[5].Value = FinanceAddressID;
            arParams[6].Value = DeliverTypeID;
            arParams[7].Value = ExpressRequire;
            arParams[8].Value = MoneyTypeID;
            arParams[9].Value = SettleTypeID;
            arParams[10].Value = PriceTypeID;
            arParams[11].Value = InvoiceTypeID;
            arParams[12].Value = MakerPsnID;
            arParams[13].Value = Memo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertSaleDeliverPlanNotes", arParams);
                NoteID = arParams[0].Value;
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
        public bool UpdateSaleDeliverPlanNotes(ref string ErrorMsg, object NoteID, object DateTarget, object DeliverAddressID, object FinanceAddressID, object DeliverTypeID, object ExpressRequire, object MoneyTypeID, object SettleTypeID, object PriceTypeID, object InvoiceTypeID, object MakerPsnID, object Memo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[12];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@DateTarget", SqlDbType.DateTime);
            arParams[2] = new SqlParameter("@DeliverAddressID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@FinanceAddressID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@DeliverTypeID", SqlDbType.Int);
            arParams[5] = new SqlParameter("@ExpressRequire", SqlDbType.VarChar);
            arParams[5].Size = 100;
            arParams[6] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[7] = new SqlParameter("@SettleTypeID", SqlDbType.Int);
            arParams[8] = new SqlParameter("@PriceTypeID", SqlDbType.Int);
            arParams[9] = new SqlParameter("@InvoiceTypeID", SqlDbType.Int);
            arParams[10] = new SqlParameter("@MakerPsnID", SqlDbType.Int);
            arParams[11] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[11].Size = 200;
            arParams[0].Value = NoteID;
            arParams[1].Value = DateTarget;
            arParams[2].Value = DeliverAddressID;
            arParams[3].Value = FinanceAddressID;
            arParams[4].Value = DeliverTypeID;
            arParams[5].Value = ExpressRequire;
            arParams[6].Value = MoneyTypeID;
            arParams[7].Value = SettleTypeID;
            arParams[8].Value = PriceTypeID;
            arParams[9].Value = InvoiceTypeID;
            arParams[10].Value = MakerPsnID;
            arParams[11].Value = Memo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateSaleDeliverPlanNotes", arParams);
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