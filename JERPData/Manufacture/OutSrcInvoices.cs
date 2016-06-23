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
    /// 表[manuf.OutSrcInvoices]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015-01-12 11:47:40
    ///</时间>  
    public class OutSrcInvoices
    {
        private SqlConnection sqlConn;
        public OutSrcInvoices()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public bool DeleteOutSrcInvoices(ref string ErrorMsg, object InvoiceID)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.DeleteOutSrcInvoices", arParams);
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
        public DataSet GetDataOutSrcInvoicesByInvoiceID(long InvoiceID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            arParams[0].Value = InvoiceID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataOutSrcInvoicesByInvoiceID", arParams);
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
        public DataSet GetDataOutSrcInvoicesDescPagesFreeSearch(int PageIndex, int PageSize, ref int RecordCount, string WhereClause)
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
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataOutSrcInvoicesDescPagesFreeSearch", arParams);
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
        public DataSet GetDataOutSrcInvoicesNonConfirm()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "manuf.GetDataOutSrcInvoicesNonConfirm");
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
        public bool InsertOutSrcInvoices(ref string ErrorMsg, ref object InvoiceID, object InvoiceCode, object InvoiceName, object Year, object Month, object DateNote, object CompanyID, object MoneyTypeID, object InvoiceTypeID, object MakerPsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[10];
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
            arParams[8] = new SqlParameter("@InvoiceTypeID", SqlDbType.Int);
            arParams[9] = new SqlParameter("@MakerPsnID", SqlDbType.Int);
            arParams[1].Value = InvoiceCode;
            arParams[2].Value = InvoiceName;
            arParams[3].Value = Year;
            arParams[4].Value = Month;
            arParams[5].Value = DateNote;
            arParams[6].Value = CompanyID;
            arParams[7].Value = MoneyTypeID;
            arParams[8].Value = InvoiceTypeID;
            arParams[9].Value = MakerPsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.InsertOutSrcInvoices", arParams);
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


        public bool UpdateOutSrcInvoices(ref string ErrorMsg, object InvoiceID, object InvoiceCode, object InvoiceName, object DateNote, object TotalAMT, object TaxAMT, object MakerPsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[7];
            arParams[0] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@InvoiceCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@InvoiceName", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@DateNote", SqlDbType.DateTime);
            arParams[4] = new SqlParameter("@TotalAMT", SqlDbType.Money);
            arParams[5] = new SqlParameter("@TaxAMT", SqlDbType.Money);
            arParams[6] = new SqlParameter("@MakerPsnID", SqlDbType.Int);
            arParams[0].Value = InvoiceID;
            arParams[1].Value = InvoiceCode;
            arParams[2].Value = InvoiceName;
            arParams[3].Value = DateNote;
            arParams[4].Value = TotalAMT;
            arParams[5].Value = TaxAMT;
            arParams[6].Value = MakerPsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateOutSrcInvoices", arParams);
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
        public bool UpdateOutSrcInvoicesForConfirm(ref string ErrorMsg, object InvoiceID, object ConfirmPsnID)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateOutSrcInvoicesForConfirm", arParams);
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
        public bool UpdateOutSrcInvoicesForTotalAMT(ref string ErrorMsg, object InvoiceID, object TotalAMT, object TaxAMT)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@InvoiceID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@TotalAMT", SqlDbType.Money);
            arParams[2] = new SqlParameter("@TaxAMT", SqlDbType.Money);
            arParams[0].Value = InvoiceID;
            arParams[1].Value = TotalAMT;
            arParams[2].Value = TaxAMT;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateOutSrcInvoicesForTotalAMT", arParams);
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