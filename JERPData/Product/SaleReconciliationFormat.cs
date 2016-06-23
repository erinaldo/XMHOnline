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
    /// 表[prd.SaleReconciliationFormat]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/1/3 9:52:18
    ///</时间>  
    public class SaleReconciliationFormat
    {
        private SqlConnection sqlConn;
        public SaleReconciliationFormat()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }


        public bool DeleteSaleReconciliationFormat(ref string ErrorMsg, object FormatID)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.DeleteSaleReconciliationFormat", arParams);
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
        public DataSet GetDataSaleReconciliationFormat()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "prd.GetDataSaleReconciliationFormat");
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
        public DataSet GetDataSaleReconciliationFormatByCompanyID(int CompanyID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[0].Value = CompanyID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataSaleReconciliationFormatByCompanyID", arParams);
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
        public DataSet GetDataSaleReconciliationFormatByFormatID(int FormatID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[0].Value = FormatID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataSaleReconciliationFormatByFormatID", arParams);
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

        public bool InsertSaleReconciliationFormat(ref string ErrorMsg, ref object FormatID, object TmpSheetName, object ReconciliationNameCellName, object ReconciliationCodeCellName, object CompanyNameCellName, object FinanceAddressCellName, object LinkmanCellName, object TelephoneCellName, object FaxCellName, object MoneyTypeCellName, object SettleTypeCellName, object DateNoteCellName, object DateSettleCellName, object ItemBeginRowIndex, object TotalQtyCellName, object DeliverAMTCellName, object RepairAMTCellName, object ReplaceExpressAMTCellName, object ReturnAMTCellName, object FineAMTCellName, object TotalAMTCellName, object RecordBeginRowIndex, object RecordDateColumnName, object RecordCodeColumnName, object RecordPsnColumnName, object RecordAMTColumnName)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[26];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@TmpSheetName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@ReconciliationNameCellName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@ReconciliationCodeCellName", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@CompanyNameCellName", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@FinanceAddressCellName", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@LinkmanCellName", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@TelephoneCellName", SqlDbType.VarChar);
            arParams[7].Size = 50;
            arParams[8] = new SqlParameter("@FaxCellName", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@MoneyTypeCellName", SqlDbType.VarChar);
            arParams[9].Size = 50;
            arParams[10] = new SqlParameter("@SettleTypeCellName", SqlDbType.VarChar);
            arParams[10].Size = 50;
            arParams[11] = new SqlParameter("@DateNoteCellName", SqlDbType.VarChar);
            arParams[11].Size = 50;
            arParams[12] = new SqlParameter("@DateSettleCellName", SqlDbType.VarChar);
            arParams[12].Size = 50;
            arParams[13] = new SqlParameter("@ItemBeginRowIndex", SqlDbType.Int);
            arParams[14] = new SqlParameter("@TotalQtyCellName", SqlDbType.VarChar);
            arParams[14].Size = 50;
            arParams[15] = new SqlParameter("@DeliverAMTCellName", SqlDbType.VarChar);
            arParams[15].Size = 50;
            arParams[16] = new SqlParameter("@RepairAMTCellName", SqlDbType.VarChar);
            arParams[16].Size = 50;
            arParams[17] = new SqlParameter("@ReplaceExpressAMTCellName", SqlDbType.VarChar);
            arParams[17].Size = 50;
            arParams[18] = new SqlParameter("@ReturnAMTCellName", SqlDbType.VarChar);
            arParams[18].Size = 50;
            arParams[19] = new SqlParameter("@FineAMTCellName", SqlDbType.VarChar);
            arParams[19].Size = 50;
            arParams[20] = new SqlParameter("@TotalAMTCellName", SqlDbType.VarChar);
            arParams[20].Size = 50;
            arParams[21] = new SqlParameter("@RecordBeginRowIndex", SqlDbType.Int);
            arParams[22] = new SqlParameter("@RecordDateColumnName", SqlDbType.VarChar);
            arParams[22].Size = 50;
            arParams[23] = new SqlParameter("@RecordCodeColumnName", SqlDbType.VarChar);
            arParams[23].Size = 50;
            arParams[24] = new SqlParameter("@RecordPsnColumnName", SqlDbType.VarChar);
            arParams[24].Size = 50;
            arParams[25] = new SqlParameter("@RecordAMTColumnName", SqlDbType.VarChar);
            arParams[25].Size = 50;
            arParams[1].Value = TmpSheetName;
            arParams[2].Value = ReconciliationNameCellName;
            arParams[3].Value = ReconciliationCodeCellName;
            arParams[4].Value = CompanyNameCellName;
            arParams[5].Value = FinanceAddressCellName;
            arParams[6].Value = LinkmanCellName;
            arParams[7].Value = TelephoneCellName;
            arParams[8].Value = FaxCellName;
            arParams[9].Value = MoneyTypeCellName;
            arParams[10].Value = SettleTypeCellName;
            arParams[11].Value = DateNoteCellName;
            arParams[12].Value = DateSettleCellName;
            arParams[13].Value = ItemBeginRowIndex;
            arParams[14].Value = TotalQtyCellName;
            arParams[15].Value = DeliverAMTCellName;
            arParams[16].Value = RepairAMTCellName;
            arParams[17].Value = ReplaceExpressAMTCellName;
            arParams[18].Value = ReturnAMTCellName;
            arParams[19].Value = FineAMTCellName;
            arParams[20].Value = TotalAMTCellName;
            arParams[21].Value = RecordBeginRowIndex;
            arParams[22].Value = RecordDateColumnName;
            arParams[23].Value = RecordCodeColumnName;
            arParams[24].Value = RecordPsnColumnName;
            arParams[25].Value = RecordAMTColumnName;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertSaleReconciliationFormat", arParams);
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
        public bool InsertSaleReconciliationFormatFromCopy(ref string ErrorMsg, object OldFormatID, object TmpSheetName)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertSaleReconciliationFormatFromCopy", arParams);
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
        public bool UpdateSaleReconciliationFormat(ref string ErrorMsg, object FormatID, object TmpSheetName, object ReconciliationNameCellName, object ReconciliationCodeCellName, object CompanyNameCellName, object FinanceAddressCellName, object LinkmanCellName, object TelephoneCellName, object FaxCellName, object MoneyTypeCellName, object SettleTypeCellName, object DateNoteCellName, object DateSettleCellName, object ItemBeginRowIndex, object TotalQtyCellName, object DeliverAMTCellName, object RepairAMTCellName, object ReplaceExpressAMTCellName, object ReturnAMTCellName, object FineAMTCellName, object TotalAMTCellName, object RecordBeginRowIndex, object RecordDateColumnName, object RecordCodeColumnName, object RecordPsnColumnName, object RecordAMTColumnName)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[26];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@TmpSheetName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@ReconciliationNameCellName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@ReconciliationCodeCellName", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@CompanyNameCellName", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@FinanceAddressCellName", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@LinkmanCellName", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@TelephoneCellName", SqlDbType.VarChar);
            arParams[7].Size = 50;
            arParams[8] = new SqlParameter("@FaxCellName", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@MoneyTypeCellName", SqlDbType.VarChar);
            arParams[9].Size = 50;
            arParams[10] = new SqlParameter("@SettleTypeCellName", SqlDbType.VarChar);
            arParams[10].Size = 50;
            arParams[11] = new SqlParameter("@DateNoteCellName", SqlDbType.VarChar);
            arParams[11].Size = 50;
            arParams[12] = new SqlParameter("@DateSettleCellName", SqlDbType.VarChar);
            arParams[12].Size = 50;
            arParams[13] = new SqlParameter("@ItemBeginRowIndex", SqlDbType.Int);
            arParams[14] = new SqlParameter("@TotalQtyCellName", SqlDbType.VarChar);
            arParams[14].Size = 50;
            arParams[15] = new SqlParameter("@DeliverAMTCellName", SqlDbType.VarChar);
            arParams[15].Size = 50;
            arParams[16] = new SqlParameter("@RepairAMTCellName", SqlDbType.VarChar);
            arParams[16].Size = 50;
            arParams[17] = new SqlParameter("@ReplaceExpressAMTCellName", SqlDbType.VarChar);
            arParams[17].Size = 50;
            arParams[18] = new SqlParameter("@ReturnAMTCellName", SqlDbType.VarChar);
            arParams[18].Size = 50;
            arParams[19] = new SqlParameter("@FineAMTCellName", SqlDbType.VarChar);
            arParams[19].Size = 50;
            arParams[20] = new SqlParameter("@TotalAMTCellName", SqlDbType.VarChar);
            arParams[20].Size = 50;
            arParams[21] = new SqlParameter("@RecordBeginRowIndex", SqlDbType.Int);
            arParams[22] = new SqlParameter("@RecordDateColumnName", SqlDbType.VarChar);
            arParams[22].Size = 50;
            arParams[23] = new SqlParameter("@RecordCodeColumnName", SqlDbType.VarChar);
            arParams[23].Size = 50;
            arParams[24] = new SqlParameter("@RecordPsnColumnName", SqlDbType.VarChar);
            arParams[24].Size = 50;
            arParams[25] = new SqlParameter("@RecordAMTColumnName", SqlDbType.VarChar);
            arParams[25].Size = 50;
            arParams[0].Value = FormatID;
            arParams[1].Value = TmpSheetName;
            arParams[2].Value = ReconciliationNameCellName;
            arParams[3].Value = ReconciliationCodeCellName;
            arParams[4].Value = CompanyNameCellName;
            arParams[5].Value = FinanceAddressCellName;
            arParams[6].Value = LinkmanCellName;
            arParams[7].Value = TelephoneCellName;
            arParams[8].Value = FaxCellName;
            arParams[9].Value = MoneyTypeCellName;
            arParams[10].Value = SettleTypeCellName;
            arParams[11].Value = DateNoteCellName;
            arParams[12].Value = DateSettleCellName;
            arParams[13].Value = ItemBeginRowIndex;
            arParams[14].Value = TotalQtyCellName;
            arParams[15].Value = DeliverAMTCellName;
            arParams[16].Value = RepairAMTCellName;
            arParams[17].Value = ReplaceExpressAMTCellName;
            arParams[18].Value = ReturnAMTCellName;
            arParams[19].Value = FineAMTCellName;
            arParams[20].Value = TotalAMTCellName;
            arParams[21].Value = RecordBeginRowIndex;
            arParams[22].Value = RecordDateColumnName;
            arParams[23].Value = RecordCodeColumnName;
            arParams[24].Value = RecordPsnColumnName;
            arParams[25].Value = RecordAMTColumnName;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateSaleReconciliationFormat", arParams);
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