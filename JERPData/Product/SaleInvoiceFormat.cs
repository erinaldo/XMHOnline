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
    /// 表[prd.SaleInvoiceFormat]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2010-1-17 22:29:38
    ///</时间>  
    public class SaleInvoiceFormat
    {
        private SqlConnection sqlConn;
        public SaleInvoiceFormat()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }
        public DataSet GetDataSaleInvoiceFormat()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "prd.GetDataSaleInvoiceFormat");
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
        public DataSet GetDataSaleInvoiceFormatByFormatID(int  FormatID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[0].Value = FormatID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataSaleInvoiceFormatByFormatID", arParams);
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
        public DataSet GetDataSaleInvoiceFormatByCompanyID(int CompanyID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[0].Value = CompanyID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataSaleInvoiceFormatByCompanyID", arParams);
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

        public bool InsertSaleInvoiceFormat(ref string ErrorMsg, ref object FormatID, object TmpSheetName, object InvoiceCodeCellName, object InvoiceNameCellName, object CompanyNameCellName, object FinanceAddressCellName, object MoneyTypeCellName, object InvoiceTypeCellName, object LinkmanCellName, object TelephoneCellName, object FaxCellName, object DateNoteCellName, object TotalQtyCellName, object TotalAMTCellName, object TaxAMTCellName, object ItemBeginRowIndex)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[16];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@TmpSheetName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@InvoiceCodeCellName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@InvoiceNameCellName", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@CompanyNameCellName", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@FinanceAddressCellName", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@MoneyTypeCellName", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@InvoiceTypeCellName", SqlDbType.VarChar);
            arParams[7].Size = 50;
            arParams[8] = new SqlParameter("@LinkmanCellName", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@TelephoneCellName", SqlDbType.VarChar);
            arParams[9].Size = 50;
            arParams[10] = new SqlParameter("@FaxCellName", SqlDbType.VarChar);
            arParams[10].Size = 50;
            arParams[11] = new SqlParameter("@DateNoteCellName", SqlDbType.VarChar);
            arParams[11].Size = 50;
            arParams[12] = new SqlParameter("@TotalQtyCellName", SqlDbType.VarChar);
            arParams[12].Size = 50;
            arParams[13] = new SqlParameter("@TotalAMTCellName", SqlDbType.VarChar);
            arParams[13].Size = 50;
            arParams[14] = new SqlParameter("@TaxAMTCellName", SqlDbType.VarChar);
            arParams[14].Size = 50;
            arParams[15] = new SqlParameter("@ItemBeginRowIndex", SqlDbType.Int);
            arParams[1].Value = TmpSheetName;
            arParams[2].Value = InvoiceCodeCellName;
            arParams[3].Value = InvoiceNameCellName;
            arParams[4].Value = CompanyNameCellName;
            arParams[5].Value = FinanceAddressCellName;
            arParams[6].Value = MoneyTypeCellName;
            arParams[7].Value = InvoiceTypeCellName;
            arParams[8].Value = LinkmanCellName;
            arParams[9].Value = TelephoneCellName;
            arParams[10].Value = FaxCellName;
            arParams[11].Value = DateNoteCellName;
            arParams[12].Value = TotalQtyCellName;
            arParams[13].Value = TotalAMTCellName;
            arParams[14].Value = TaxAMTCellName;
            arParams[15].Value = ItemBeginRowIndex;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertSaleInvoiceFormat", arParams);
                FormatID = arParams[0].Value;
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
        public bool InsertSaleInvoiceFormatFromCopy(ref string ErrorMsg, object OldFormatID, object TmpSheetName)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@OldFormatID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@TmpSheetName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[0].Value = OldFormatID;
            arParams[1].Value = TmpSheetName;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertSaleInvoiceFormatFromCopy", arParams);
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
        public bool UpdateSaleInvoiceFormat(ref string ErrorMsg, object FormatID, object TmpSheetName, object InvoiceCodeCellName, object InvoiceNameCellName, object CompanyNameCellName, object FinanceAddressCellName, object MoneyTypeCellName, object InvoiceTypeCellName, object LinkmanCellName, object TelephoneCellName, object FaxCellName, object DateNoteCellName, object TotalQtyCellName, object TotalAMTCellName, object TaxAMTCellName, object ItemBeginRowIndex)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[16];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@TmpSheetName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@InvoiceCodeCellName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@InvoiceNameCellName", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@CompanyNameCellName", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@FinanceAddressCellName", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@MoneyTypeCellName", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@InvoiceTypeCellName", SqlDbType.VarChar);
            arParams[7].Size = 50;
            arParams[8] = new SqlParameter("@LinkmanCellName", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@TelephoneCellName", SqlDbType.VarChar);
            arParams[9].Size = 50;
            arParams[10] = new SqlParameter("@FaxCellName", SqlDbType.VarChar);
            arParams[10].Size = 50;
            arParams[11] = new SqlParameter("@DateNoteCellName", SqlDbType.VarChar);
            arParams[11].Size = 50;
            arParams[12] = new SqlParameter("@TotalQtyCellName", SqlDbType.VarChar);
            arParams[12].Size = 50;
            arParams[13] = new SqlParameter("@TotalAMTCellName", SqlDbType.VarChar);
            arParams[13].Size = 50;
            arParams[14] = new SqlParameter("@TaxAMTCellName", SqlDbType.VarChar);
            arParams[14].Size = 50;
            arParams[15] = new SqlParameter("@ItemBeginRowIndex", SqlDbType.Int);
            arParams[0].Value = FormatID;
            arParams[1].Value = TmpSheetName;
            arParams[2].Value = InvoiceCodeCellName;
            arParams[3].Value = InvoiceNameCellName;
            arParams[4].Value = CompanyNameCellName;
            arParams[5].Value = FinanceAddressCellName;
            arParams[6].Value = MoneyTypeCellName;
            arParams[7].Value = InvoiceTypeCellName;
            arParams[8].Value = LinkmanCellName;
            arParams[9].Value = TelephoneCellName;
            arParams[10].Value = FaxCellName;
            arParams[11].Value = DateNoteCellName;
            arParams[12].Value = TotalQtyCellName;
            arParams[13].Value = TotalAMTCellName;
            arParams[14].Value = TaxAMTCellName;
            arParams[15].Value = ItemBeginRowIndex;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateSaleInvoiceFormat", arParams);
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
        public bool DeleteSaleInvoiceFormat(ref string ErrorMsg, object FormatID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[0].Value = FormatID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.DeleteSaleInvoiceFormat", arParams);
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