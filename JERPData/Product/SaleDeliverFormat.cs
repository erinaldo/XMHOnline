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
    /// 表[prd.SaleDeliverFormat]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2010-4-19 15:34:12
    ///</时间>  
    public class SaleDeliverFormat
    {
        private SqlConnection sqlConn;
        public SaleDeliverFormat()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }
        public DataSet GetDataSaleDeliverFormat()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "prd.GetDataSaleDeliverFormat");
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
        public DataSet GetDataSaleDeliverFormatByFormatID(int  FormatID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[0].Value = FormatID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataSaleDeliverFormatByFormatID", arParams);
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
        public DataSet GetDataSaleDeliverFormatByCompanyID(int CompanyID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[0].Value = CompanyID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataSaleDeliverFormatByCompanyID", arParams);
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

        public bool InsertSaleDeliverFormat(ref string ErrorMsg, ref object FormatID, object TmpSheetName, object NoteCodeCellName, object DateNoteCellName, object PONoCellName, object CompanyNameCellName, object DeliverAddressCellName, object FinanceAddressCellName, object LinkmanCellName, object TelephoneCellName, object DeliverPsnCellName, object MoneyTypeCellName, object SettleTypeCellName, object PriceTypeCellName, object InvoiceTypeCellName, object SalePsnCellName, object MakerPsnCellName, object MemoCellName, object TotalQtyCellName, object TotalAMTCellName, object ItemRowIndex, object ItemRowCount)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[22];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@TmpSheetName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@NoteCodeCellName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@DateNoteCellName", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@PONoCellName", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@CompanyNameCellName", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@DeliverAddressCellName", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@FinanceAddressCellName", SqlDbType.VarChar);
            arParams[7].Size = 50;
            arParams[8] = new SqlParameter("@LinkmanCellName", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@TelephoneCellName", SqlDbType.VarChar);
            arParams[9].Size = 50;
            arParams[10] = new SqlParameter("@DeliverPsnCellName", SqlDbType.VarChar);
            arParams[10].Size = 50;
            arParams[11] = new SqlParameter("@MoneyTypeCellName", SqlDbType.VarChar);
            arParams[11].Size = 50;
            arParams[12] = new SqlParameter("@SettleTypeCellName", SqlDbType.VarChar);
            arParams[12].Size = 50;
            arParams[13] = new SqlParameter("@PriceTypeCellName", SqlDbType.VarChar);
            arParams[13].Size = 50;
            arParams[14] = new SqlParameter("@InvoiceTypeCellName", SqlDbType.VarChar);
            arParams[14].Size = 50;
            arParams[15] = new SqlParameter("@SalePsnCellName", SqlDbType.VarChar);
            arParams[15].Size = 50;
            arParams[16] = new SqlParameter("@MakerPsnCellName", SqlDbType.VarChar);
            arParams[16].Size = 50;
            arParams[17] = new SqlParameter("@MemoCellName", SqlDbType.VarChar);
            arParams[17].Size = 50;
            arParams[18] = new SqlParameter("@TotalQtyCellName", SqlDbType.VarChar);
            arParams[18].Size = 50;
            arParams[19] = new SqlParameter("@TotalAMTCellName", SqlDbType.VarChar);
            arParams[19].Size = 50;
            arParams[20] = new SqlParameter("@ItemRowIndex", SqlDbType.Int);
            arParams[21] = new SqlParameter("@ItemRowCount", SqlDbType.Int);
            arParams[0].Value = FormatID;
            arParams[1].Value = TmpSheetName;
            arParams[2].Value = NoteCodeCellName;
            arParams[3].Value = DateNoteCellName;
            arParams[4].Value = PONoCellName;
            arParams[5].Value = CompanyNameCellName;
            arParams[6].Value = DeliverAddressCellName;
            arParams[7].Value = FinanceAddressCellName;
            arParams[8].Value = LinkmanCellName;
            arParams[9].Value = TelephoneCellName;
            arParams[10].Value = DeliverPsnCellName;
            arParams[11].Value = MoneyTypeCellName;
            arParams[12].Value = SettleTypeCellName;
            arParams[13].Value = PriceTypeCellName;
            arParams[14].Value = InvoiceTypeCellName;
            arParams[15].Value = SalePsnCellName;
            arParams[16].Value = MakerPsnCellName;
            arParams[17].Value = MemoCellName;
            arParams[18].Value = TotalQtyCellName;
            arParams[19].Value = TotalAMTCellName;
            arParams[20].Value = ItemRowIndex;
            arParams[21].Value = ItemRowCount;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertSaleDeliverFormat", arParams);
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
        public bool InsertSaleDeliverFormatFromCopy(ref string ErrorMsg, object OldFormatID, object TmpSheetName)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertSaleDeliverFormatFromCopy", arParams);
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
        public bool UpdateSaleDeliverFormat(ref string ErrorMsg, object FormatID, object TmpSheetName, object NoteCodeCellName, object DateNoteCellName, object PONoCellName, object CompanyNameCellName, object DeliverAddressCellName, object FinanceAddressCellName, object LinkmanCellName, object TelephoneCellName, object DeliverPsnCellName, object MoneyTypeCellName, object SettleTypeCellName, object PriceTypeCellName, object InvoiceTypeCellName, object SalePsnCellName, object MakerPsnCellName, object MemoCellName, object TotalQtyCellName, object TotalAMTCellName, object ItemRowIndex, object ItemRowCount)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[22];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@TmpSheetName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@NoteCodeCellName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@DateNoteCellName", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@PONoCellName", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@CompanyNameCellName", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@DeliverAddressCellName", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@FinanceAddressCellName", SqlDbType.VarChar);
            arParams[7].Size = 50;
            arParams[8] = new SqlParameter("@LinkmanCellName", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@TelephoneCellName", SqlDbType.VarChar);
            arParams[9].Size = 50;
            arParams[10] = new SqlParameter("@DeliverPsnCellName", SqlDbType.VarChar);
            arParams[10].Size = 50;
            arParams[11] = new SqlParameter("@MoneyTypeCellName", SqlDbType.VarChar);
            arParams[11].Size = 50;
            arParams[12] = new SqlParameter("@SettleTypeCellName", SqlDbType.VarChar);
            arParams[12].Size = 50;
            arParams[13] = new SqlParameter("@PriceTypeCellName", SqlDbType.VarChar);
            arParams[13].Size = 50;
            arParams[14] = new SqlParameter("@InvoiceTypeCellName", SqlDbType.VarChar);
            arParams[14].Size = 50;
            arParams[15] = new SqlParameter("@SalePsnCellName", SqlDbType.VarChar);
            arParams[15].Size = 50;
            arParams[16] = new SqlParameter("@MakerPsnCellName", SqlDbType.VarChar);
            arParams[16].Size = 50;
            arParams[17] = new SqlParameter("@MemoCellName", SqlDbType.VarChar);
            arParams[17].Size = 50;
            arParams[18] = new SqlParameter("@TotalQtyCellName", SqlDbType.VarChar);
            arParams[18].Size = 50;
            arParams[19] = new SqlParameter("@TotalAMTCellName", SqlDbType.VarChar);
            arParams[19].Size = 50;
            arParams[20] = new SqlParameter("@ItemRowIndex", SqlDbType.Int);
            arParams[21] = new SqlParameter("@ItemRowCount", SqlDbType.Int);
            arParams[0].Value = FormatID;
            arParams[1].Value = TmpSheetName;
            arParams[2].Value = NoteCodeCellName;
            arParams[3].Value = DateNoteCellName;
            arParams[4].Value = PONoCellName;
            arParams[5].Value = CompanyNameCellName;
            arParams[6].Value = DeliverAddressCellName;
            arParams[7].Value = FinanceAddressCellName;
            arParams[8].Value = LinkmanCellName;
            arParams[9].Value = TelephoneCellName;
            arParams[10].Value = DeliverPsnCellName;
            arParams[11].Value = MoneyTypeCellName;
            arParams[12].Value = SettleTypeCellName;
            arParams[13].Value = PriceTypeCellName;
            arParams[14].Value = InvoiceTypeCellName;
            arParams[15].Value = SalePsnCellName;
            arParams[16].Value = MakerPsnCellName;
            arParams[17].Value = MemoCellName;
            arParams[18].Value = TotalQtyCellName;
            arParams[19].Value = TotalAMTCellName;
            arParams[20].Value = ItemRowIndex;
            arParams[21].Value = ItemRowCount;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateSaleDeliverFormat", arParams);
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
        public bool DeleteSaleDeliverFormat(ref string ErrorMsg, object FormatID)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.DeleteSaleDeliverFormat", arParams);
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