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
    /// 表[prd.RepairDeliverNotes]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/3/12 9:39:23
    ///</时间>  
    public class RepairDeliverNotes
    {
        private SqlConnection sqlConn;
        public RepairDeliverNotes()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public bool DeleteRepairDeliverNotes(ref string ErrorMsg, object NoteID)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.DeleteRepairDeliverNotes", arParams);
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
        public DataSet GetDataRepairDeliverNotesByNoteID(long NoteID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[0].Value = NoteID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataRepairDeliverNotesByNoteID", arParams);
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
        public DataSet GetDataRepairDeliverNotesByReconciliationID(long ReconciliationID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ReconciliationID", SqlDbType.BigInt);
            arParams[0].Value = ReconciliationID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataRepairDeliverNotesByReconciliationID", arParams);
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
        public DataSet GetDataRepairDeliverNotesDescPagesFreeSearch(int PageIndex, int PageSize, ref int RecordCount, string WhereClause)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@PageIndex", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PageSize", SqlDbType.Int);
            arParams[2] = new SqlParameter("@RecordCount", SqlDbType.Int);
            arParams[2].Direction = ParameterDirection.InputOutput;
            arParams[3] = new SqlParameter("@WhereClause", SqlDbType.NVarChar);
            arParams[3].Size = -1;
            arParams[0].Value = PageIndex;
            arParams[1].Value = PageSize;
            arParams[2].Value = RecordCount;
            arParams[3].Value = WhereClause;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataRepairDeliverNotesDescPagesFreeSearch", arParams);
                RecordCount = (int)arParams[2].Value;
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
        public DataSet GetDataRepairDeliverNotesForReconciliation(int CompanyID, int FinanceAddressID, int MoneyTypeID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@FinanceAddressID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[0].Value = CompanyID;
            arParams[1].Value = FinanceAddressID;
            arParams[2].Value = MoneyTypeID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataRepairDeliverNotesForReconciliation", arParams);
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
        public DataSet GetDataRepairDeliverNotesNeedReconciliation()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "prd.GetDataRepairDeliverNotesNeedReconciliation");
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
        public DataSet GetDataRepairDeliverNotesNonConfirm()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "prd.GetDataRepairDeliverNotesNonConfirm");
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
        public bool GetParmRepairDeliverNotesCountForReconciliation(ref int Count)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@Count", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = Count;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "prd.GetParmRepairDeliverNotesCountForReconciliation", arParams);
                Count = (int)arParams[0].Value;
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

        public bool InsertRepairDeliverNotes(ref string ErrorMsg, ref object NoteID, ref object NoteCode, object DateNote, object CompanyID, object MoneyTypeID, object SettleTypeID, object PriceTypeID, object DeliverAddressID, object FinanceAddressID, object ExpressRequire, object CashSettleFlag, object TotalAMT, object MakerPsnID, object Memo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[14];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@NoteCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[2] = new SqlParameter("@DateNote", SqlDbType.DateTime);
            arParams[3] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[5] = new SqlParameter("@SettleTypeID", SqlDbType.Int);
            arParams[6] = new SqlParameter("@PriceTypeID", SqlDbType.Int);
            arParams[7] = new SqlParameter("@DeliverAddressID", SqlDbType.Int);
            arParams[8] = new SqlParameter("@FinanceAddressID", SqlDbType.Int);
            arParams[9] = new SqlParameter("@ExpressRequire", SqlDbType.VarChar);
            arParams[9].Size = 100;
            arParams[10] = new SqlParameter("@CashSettleFlag", SqlDbType.Bit);
            arParams[11] = new SqlParameter("@TotalAMT", SqlDbType.Decimal);
            arParams[11].Precision = 18;
            arParams[11].Scale = 4;
            arParams[12] = new SqlParameter("@MakerPsnID", SqlDbType.Int);
            arParams[13] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[13].Size = 100;
            arParams[0].Value = NoteID;
            arParams[1].Value = NoteCode;
            arParams[2].Value = DateNote;
            arParams[3].Value = CompanyID;
            arParams[4].Value = MoneyTypeID;
            arParams[5].Value = SettleTypeID;
            arParams[6].Value = PriceTypeID;
            arParams[7].Value = DeliverAddressID;
            arParams[8].Value = FinanceAddressID;
            arParams[9].Value = ExpressRequire;
            arParams[10].Value = CashSettleFlag;
            arParams[11].Value = TotalAMT;
            arParams[12].Value = MakerPsnID;
            arParams[13].Value = Memo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertRepairDeliverNotes", arParams);
                NoteID = arParams[0].Value;
                NoteCode = arParams[1].Value;
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

        public bool UpdateRepairDeliverNotes(ref string ErrorMsg, object NoteID, object MoneyTypeID, object SettleTypeID, object PriceTypeID, object DeliverAddressID, object FinanceAddressID, object ExpressRequire, object CashSettleFlag, object TotalAMT, object MakerPsnID, object Memo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[11];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@SettleTypeID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@PriceTypeID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@DeliverAddressID", SqlDbType.Int);
            arParams[5] = new SqlParameter("@FinanceAddressID", SqlDbType.Int);
            arParams[6] = new SqlParameter("@ExpressRequire", SqlDbType.VarChar);
            arParams[6].Size = 100;
            arParams[7] = new SqlParameter("@CashSettleFlag", SqlDbType.Bit);
            arParams[8] = new SqlParameter("@TotalAMT", SqlDbType.Money);
            arParams[9] = new SqlParameter("@MakerPsnID", SqlDbType.Int);
            arParams[10] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[10].Size = 100;
            arParams[0].Value = NoteID;
            arParams[1].Value = MoneyTypeID;
            arParams[2].Value = SettleTypeID;
            arParams[3].Value = PriceTypeID;
            arParams[4].Value = DeliverAddressID;
            arParams[5].Value = FinanceAddressID;
            arParams[6].Value = ExpressRequire;
            arParams[7].Value = CashSettleFlag;
            arParams[8].Value = TotalAMT;
            arParams[9].Value = MakerPsnID;
            arParams[10].Value = Memo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateRepairDeliverNotes", arParams);
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
        public bool UpdateRepairDeliverNotesCancelReconciliation(ref string ErrorMsg, object NoteID)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateRepairDeliverNotesCancelReconciliation", arParams);
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

        public bool UpdateRepairDeliverNotesForConfirm(ref string ErrorMsg, object NoteID, object DeliverTypeID, object ExpressRequire, object DeliverPsnID, object ConfirmPsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@DeliverTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@ExpressRequire", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@DeliverPsnID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@ConfirmPsnID", SqlDbType.Int);
            arParams[0].Value = NoteID;
            arParams[1].Value = DeliverTypeID;
            arParams[2].Value = ExpressRequire;
            arParams[3].Value = DeliverPsnID;
            arParams[4].Value = ConfirmPsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateRepairDeliverNotesForConfirm", arParams);
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
        public bool UpdateRepairDeliverNotesForExpress(ref string ErrorMsg, object NoteID, object ExpressCompanyID, object ExpressCode)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@ExpressCompanyID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@ExpressCode", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[0].Value = NoteID;
            arParams[1].Value = ExpressCompanyID;
            arParams[2].Value = ExpressCode;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateRepairDeliverNotesForExpress", arParams);
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
        public bool UpdateRepairDeliverNotesForReconciliation(ref string ErrorMsg, object NoteID, object ReconciliationID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@ReconciliationID", SqlDbType.BigInt);
            arParams[0].Value = NoteID;
            arParams[1].Value = ReconciliationID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateRepairDeliverNotesForReconciliation", arParams);
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