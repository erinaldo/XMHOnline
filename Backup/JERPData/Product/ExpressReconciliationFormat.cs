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
    /// 表[prd.ExpressReconciliationFormat]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015-05-31 06:19:52
    ///</时间>  
    public class ExpressReconciliationFormat
    {
        private SqlConnection sqlConn;
        public ExpressReconciliationFormat()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public bool DeleteExpressReconciliationFormat(ref string ErrorMsg, object FormatID)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.DeleteExpressReconciliationFormat", arParams);
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
        public DataSet GetDataExpressReconciliationFormat()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "prd.GetDataExpressReconciliationFormat");
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
        public DataSet GetDataExpressReconciliationFormatByFormatID(int FormatID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[0].Value = FormatID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataExpressReconciliationFormatByFormatID", arParams);
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
        public bool InsertExpressReconciliationFormat(ref string ErrorMsg, ref object FormatID, object TmpSheetName, object ReconciliationNameCellName, object ReconciliationCodeCellName, object CompanyNameCellName, object MoneyTypeCellName, object DateNoteCellName, object ItemBeginRowIndex, object TotalAMTCellName, object MakerPsnCellName, object RecordBeginRowIndex, object RecordDateColumnName, object RecordCodeColumnName, object RecordPsnColumnName, object RecordAMTColumnName)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[15];
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
            arParams[5] = new SqlParameter("@MoneyTypeCellName", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@DateNoteCellName", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@ItemBeginRowIndex", SqlDbType.Int);
            arParams[8] = new SqlParameter("@TotalAMTCellName", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@MakerPsnCellName", SqlDbType.VarChar);
            arParams[9].Size = 50;
            arParams[10] = new SqlParameter("@RecordBeginRowIndex", SqlDbType.Int);
            arParams[11] = new SqlParameter("@RecordDateColumnName", SqlDbType.VarChar);
            arParams[11].Size = 50;
            arParams[12] = new SqlParameter("@RecordCodeColumnName", SqlDbType.VarChar);
            arParams[12].Size = 50;
            arParams[13] = new SqlParameter("@RecordPsnColumnName", SqlDbType.VarChar);
            arParams[13].Size = 50;
            arParams[14] = new SqlParameter("@RecordAMTColumnName", SqlDbType.VarChar);
            arParams[14].Size = 50;
            arParams[1].Value = TmpSheetName;
            arParams[2].Value = ReconciliationNameCellName;
            arParams[3].Value = ReconciliationCodeCellName;
            arParams[4].Value = CompanyNameCellName;
            arParams[5].Value = MoneyTypeCellName;
            arParams[6].Value = DateNoteCellName;
            arParams[7].Value = ItemBeginRowIndex;
            arParams[8].Value = TotalAMTCellName;
            arParams[9].Value = MakerPsnCellName;
            arParams[10].Value = RecordBeginRowIndex;
            arParams[11].Value = RecordDateColumnName;
            arParams[12].Value = RecordCodeColumnName;
            arParams[13].Value = RecordPsnColumnName;
            arParams[14].Value = RecordAMTColumnName;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertExpressReconciliationFormat", arParams);
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
        public bool InsertExpressReconciliationFormatFromCopy(ref string ErrorMsg, object OldFormatID, object TmpSheetName)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertExpressReconciliationFormatFromCopy", arParams);
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

        public bool UpdateExpressReconciliationFormat(ref string ErrorMsg, object FormatID, object TmpSheetName, object ReconciliationNameCellName, object ReconciliationCodeCellName, object CompanyNameCellName, object MoneyTypeCellName, object DateNoteCellName, object ItemBeginRowIndex, object TotalAMTCellName, object MakerPsnCellName, object RecordBeginRowIndex, object RecordDateColumnName, object RecordCodeColumnName, object RecordPsnColumnName, object RecordAMTColumnName)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[15];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@TmpSheetName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@ReconciliationNameCellName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@ReconciliationCodeCellName", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@CompanyNameCellName", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@MoneyTypeCellName", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@DateNoteCellName", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@ItemBeginRowIndex", SqlDbType.Int);
            arParams[8] = new SqlParameter("@TotalAMTCellName", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@MakerPsnCellName", SqlDbType.VarChar);
            arParams[9].Size = 50;
            arParams[10] = new SqlParameter("@RecordBeginRowIndex", SqlDbType.Int);
            arParams[11] = new SqlParameter("@RecordDateColumnName", SqlDbType.VarChar);
            arParams[11].Size = 50;
            arParams[12] = new SqlParameter("@RecordCodeColumnName", SqlDbType.VarChar);
            arParams[12].Size = 50;
            arParams[13] = new SqlParameter("@RecordPsnColumnName", SqlDbType.VarChar);
            arParams[13].Size = 50;
            arParams[14] = new SqlParameter("@RecordAMTColumnName", SqlDbType.VarChar);
            arParams[14].Size = 50;
            arParams[0].Value = FormatID;
            arParams[1].Value = TmpSheetName;
            arParams[2].Value = ReconciliationNameCellName;
            arParams[3].Value = ReconciliationCodeCellName;
            arParams[4].Value = CompanyNameCellName;
            arParams[5].Value = MoneyTypeCellName;
            arParams[6].Value = DateNoteCellName;
            arParams[7].Value = ItemBeginRowIndex;
            arParams[8].Value = TotalAMTCellName;
            arParams[9].Value = MakerPsnCellName;
            arParams[10].Value = RecordBeginRowIndex;
            arParams[11].Value = RecordDateColumnName;
            arParams[12].Value = RecordCodeColumnName;
            arParams[13].Value = RecordPsnColumnName;
            arParams[14].Value = RecordAMTColumnName;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateExpressReconciliationFormat", arParams);
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