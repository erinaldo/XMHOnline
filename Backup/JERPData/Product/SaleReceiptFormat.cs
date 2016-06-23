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
    /// 表[prd.SaleReceiptFormat]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015-05-28 11:30:25
    ///</时间>  
    public class SaleReceiptFormat
    {
        private SqlConnection sqlConn;
        public SaleReceiptFormat()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }


        public bool DeleteSaleReceiptFormat(ref string ErrorMsg, object FormatID)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.DeleteSaleReceiptFormat", arParams);
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
        public DataSet GetDataSaleReceiptFormat()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "prd.GetDataSaleReceiptFormat");
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
        public DataSet GetDataSaleReceiptFormatByFormatID(int FormatID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[0].Value = FormatID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataSaleReceiptFormatByFormatID", arParams);
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

        public bool InsertSaleReceiptFormat(ref string ErrorMsg, ref object FormatID, object TmpSheetName, object NoteCodeCellName, object DateNoteCellName, object CompanyNameCellName, object ReconciliationCodeCellName, object MoneyTypeCellName, object TotalAMTCellName, object AdvanceAMTCellName, object AmountCellName, object ExpressCompanyNameCellName, object MakerPsnCellName)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[12];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@TmpSheetName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@NoteCodeCellName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@DateNoteCellName", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@CompanyNameCellName", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@ReconciliationCodeCellName", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@MoneyTypeCellName", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@TotalAMTCellName", SqlDbType.VarChar);
            arParams[7].Size = 50;
            arParams[8] = new SqlParameter("@AdvanceAMTCellName", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@AmountCellName", SqlDbType.VarChar);
            arParams[9].Size = 50;
            arParams[10] = new SqlParameter("@ExpressCompanyNameCellName", SqlDbType.VarChar);
            arParams[10].Size = 50;
            arParams[11] = new SqlParameter("@MakerPsnCellName", SqlDbType.VarChar);
            arParams[11].Size = 50;
            arParams[0].Value = FormatID;
            arParams[1].Value = TmpSheetName;
            arParams[2].Value = NoteCodeCellName;
            arParams[3].Value = DateNoteCellName;
            arParams[4].Value = CompanyNameCellName;
            arParams[5].Value = ReconciliationCodeCellName;
            arParams[6].Value = MoneyTypeCellName;
            arParams[7].Value = TotalAMTCellName;
            arParams[8].Value = AdvanceAMTCellName;
            arParams[9].Value = AmountCellName;
            arParams[10].Value = ExpressCompanyNameCellName;
            arParams[11].Value = MakerPsnCellName;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertSaleReceiptFormat", arParams);
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
        public bool InsertSaleReceiptFormatFromCopy(ref string ErrorMsg, object OldFormatID, object TmpSheetName)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertSaleReceiptFormatFromCopy", arParams);
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
        public bool UpdateSaleReceiptFormat(ref string ErrorMsg, object FormatID, object TmpSheetName, object NoteCodeCellName, object DateNoteCellName, object CompanyNameCellName, object ReconciliationCodeCellName, object MoneyTypeCellName, object TotalAMTCellName, object AdvanceAMTCellName, object AmountCellName, object ExpressCompanyNameCellName, object MakerPsnCellName)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[12];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@TmpSheetName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@NoteCodeCellName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@DateNoteCellName", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@CompanyNameCellName", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@ReconciliationCodeCellName", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@MoneyTypeCellName", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@TotalAMTCellName", SqlDbType.VarChar);
            arParams[7].Size = 50;
            arParams[8] = new SqlParameter("@AdvanceAMTCellName", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@AmountCellName", SqlDbType.VarChar);
            arParams[9].Size = 50;
            arParams[10] = new SqlParameter("@ExpressCompanyNameCellName", SqlDbType.VarChar);
            arParams[10].Size = 50;
            arParams[11] = new SqlParameter("@MakerPsnCellName", SqlDbType.VarChar);
            arParams[11].Size = 50;
            arParams[0].Value = FormatID;
            arParams[1].Value = TmpSheetName;
            arParams[2].Value = NoteCodeCellName;
            arParams[3].Value = DateNoteCellName;
            arParams[4].Value = CompanyNameCellName;
            arParams[5].Value = ReconciliationCodeCellName;
            arParams[6].Value = MoneyTypeCellName;
            arParams[7].Value = TotalAMTCellName;
            arParams[8].Value = AdvanceAMTCellName;
            arParams[9].Value = AmountCellName;
            arParams[10].Value = ExpressCompanyNameCellName;
            arParams[11].Value = MakerPsnCellName;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateSaleReceiptFormat", arParams);
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