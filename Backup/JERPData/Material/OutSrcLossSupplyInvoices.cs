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
    /// 表[mtr.OutSrcLossSupplyInvoices]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/5/8 9:35:16
    ///</时间>  
    public class OutSrcLossSupplyInvoices
    {
        private SqlConnection sqlConn;
        public OutSrcLossSupplyInvoices()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public bool DeleteOutSrcLossSupplyInvoices(ref string ErrorMsg, object InvoiceID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            arParams[0].Value = InvoiceID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.DeleteOutSrcLossSupplyInvoices", arParams);
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
        public DataSet GetDataOutSrcLossSupplyInvoicesByInvoiceID(long InvoiceID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            arParams[0].Value = InvoiceID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "mtr.GetDataOutSrcLossSupplyInvoicesByInvoiceID", arParams);
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
        public DataSet GetDataOutSrcLossSupplyInvoicesDescPagesFreeSearch(int PageIndex, int PageSize, ref int RecordCount, string WhereClause)
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
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "mtr.GetDataOutSrcLossSupplyInvoicesDescPagesFreeSearch", arParams);
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
        public DataSet GetDataOutSrcLossSupplyInvoicesNonConfirm()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "mtr.GetDataOutSrcLossSupplyInvoicesNonConfirm");
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
        public bool GetParmOutSrcLossSupplyInvoicesConfirmRemindFlag(int PsnID, ref bool RemindFlag)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@RemindFlag", SqlDbType.Bit);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = PsnID;
            arParams[1].Value = RemindFlag;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "mtr.GetParmOutSrcLossSupplyInvoicesConfirmRemindFlag", arParams);
                RemindFlag = (bool)arParams[1].Value;
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
        public bool InsertOutSrcLossSupplyInvoices(ref string ErrorMsg, ref object InvoiceID, object InvoiceCode, object InvoiceName, object Year, object Month, object DateNote, object CompanyID, object MoneyTypeID, object MakerPsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[9];
            arParams[0] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@InvoiceCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@InvoiceName", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@Year", SqlDbType.Int);
            arParams[4] = new SqlParameter("@Month", SqlDbType.Int);
            arParams[5] = new SqlParameter("@DateNote", SqlDbType.DateTime);
            arParams[6] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[7] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[8] = new SqlParameter("@MakerPsnID", SqlDbType.Int);
            arParams[0].Value = InvoiceID;
            arParams[1].Value = InvoiceCode;
            arParams[2].Value = InvoiceName;
            arParams[3].Value = Year;
            arParams[4].Value = Month;
            arParams[5].Value = DateNote;
            arParams[6].Value = CompanyID;
            arParams[7].Value = MoneyTypeID;
            arParams[8].Value = MakerPsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.InsertOutSrcLossSupplyInvoices", arParams);
                InvoiceID = arParams[0].Value;
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
        public bool UpdateOutSrcLossSupplyInvoices(ref string ErrorMsg, object InvoiceID, object InvoiceCode, object InvoiceName, object DateNote, object TotalAMT, object MakerPsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@InvoiceCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@InvoiceName", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@DateNote", SqlDbType.DateTime);
            arParams[4] = new SqlParameter("@TotalAMT", SqlDbType.Money);
            arParams[5] = new SqlParameter("@MakerPsnID", SqlDbType.Int);
            arParams[0].Value = InvoiceID;
            arParams[1].Value = InvoiceCode;
            arParams[2].Value = InvoiceName;
            arParams[3].Value = DateNote;
            arParams[4].Value = TotalAMT;
            arParams[5].Value = MakerPsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.UpdateOutSrcLossSupplyInvoices", arParams);
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
        public bool UpdateOutSrcLossSupplyInvoicesForConfirm(ref string ErrorMsg, object InvoiceID, object ConfirmPsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@ConfirmPsnID", SqlDbType.Int);
            arParams[0].Value = InvoiceID;
            arParams[1].Value = ConfirmPsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.UpdateOutSrcLossSupplyInvoicesForConfirm", arParams);
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
        public bool UpdateOutSrcLossSupplyInvoicesForTotalAMT(ref string ErrorMsg, object InvoiceID, object TotalAMT)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@TotalAMT", SqlDbType.Money);
            arParams[0].Value = InvoiceID;
            arParams[1].Value = TotalAMT;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.UpdateOutSrcLossSupplyInvoicesForTotalAMT", arParams);
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