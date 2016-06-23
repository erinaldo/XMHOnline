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
    /// 表[mtr.OutSrcLossSupplyFormat]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2013-12-20 22:02:36
    ///</时间>  
    public class OutSrcLossSupplyFormat
    {
        private SqlConnection sqlConn;
        public OutSrcLossSupplyFormat()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public bool DeleteOutSrcLossSupplyFormat(ref string ErrorMsg, object FormatID)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.DeleteOutSrcLossSupplyFormat", arParams);
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
        public DataSet GetDataOutSrcLossSupplyFormat()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "mtr.GetDataOutSrcLossSupplyFormat");
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
        public DataSet GetDataOutSrcLossSupplyFormatByFormatID(int FormatID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[0].Value = FormatID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "mtr.GetDataOutSrcLossSupplyFormatByFormatID", arParams);
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

        public bool InsertOutSrcLossSupplyFormat(ref string ErrorMsg, ref object FormatID, object TmpSheetName, object NoteCodeCellName, object DateNoteCellName, object SupplierCellName, object SupplierAddressCellName, object LinkmanCellName, object TelephoneCellName, object FaxCellName, object MakerPsnCellName, object MemoCellName, object ItemRowIndex, object ItemRowCount)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[13];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@TmpSheetName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@NoteCodeCellName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@DateNoteCellName", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@SupplierCellName", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@SupplierAddressCellName", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@LinkmanCellName", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@TelephoneCellName", SqlDbType.VarChar);
            arParams[7].Size = 50;
            arParams[8] = new SqlParameter("@FaxCellName", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@MakerPsnCellName", SqlDbType.VarChar);
            arParams[9].Size = 50;
            arParams[10] = new SqlParameter("@MemoCellName", SqlDbType.VarChar);
            arParams[10].Size = 50;
            arParams[11] = new SqlParameter("@ItemRowIndex", SqlDbType.Int);
            arParams[12] = new SqlParameter("@ItemRowCount", SqlDbType.Int);
            arParams[0].Value = FormatID;
            arParams[1].Value = TmpSheetName;
            arParams[2].Value = NoteCodeCellName;
            arParams[3].Value = DateNoteCellName;
            arParams[4].Value = SupplierCellName;
            arParams[5].Value = SupplierAddressCellName;
            arParams[6].Value = LinkmanCellName;
            arParams[7].Value = TelephoneCellName;
            arParams[8].Value = FaxCellName;
            arParams[9].Value = MakerPsnCellName;
            arParams[10].Value = MemoCellName;
            arParams[11].Value = ItemRowIndex;
            arParams[12].Value = ItemRowCount;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.InsertOutSrcLossSupplyFormat", arParams);
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
        public bool InsertOutSrcLossSupplyFormatFromCopy(ref string ErrorMsg, object OldFormatID, object TmpSheetName)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.InsertOutSrcLossSupplyFormatFromCopy", arParams);
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
        public bool UpdateOutSrcLossSupplyFormat(ref string ErrorMsg, object FormatID, object TmpSheetName, object NoteCodeCellName, object DateNoteCellName, object SupplierCellName, object SupplierAddressCellName, object LinkmanCellName, object TelephoneCellName, object FaxCellName, object MakerPsnCellName, object MemoCellName, object ItemRowIndex, object ItemRowCount)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[13];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@TmpSheetName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@NoteCodeCellName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@DateNoteCellName", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@SupplierCellName", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@SupplierAddressCellName", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@LinkmanCellName", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@TelephoneCellName", SqlDbType.VarChar);
            arParams[7].Size = 50;
            arParams[8] = new SqlParameter("@FaxCellName", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@MakerPsnCellName", SqlDbType.VarChar);
            arParams[9].Size = 50;
            arParams[10] = new SqlParameter("@MemoCellName", SqlDbType.VarChar);
            arParams[10].Size = 50;
            arParams[11] = new SqlParameter("@ItemRowIndex", SqlDbType.Int);
            arParams[12] = new SqlParameter("@ItemRowCount", SqlDbType.Int);
            arParams[0].Value = FormatID;
            arParams[1].Value = TmpSheetName;
            arParams[2].Value = NoteCodeCellName;
            arParams[3].Value = DateNoteCellName;
            arParams[4].Value = SupplierCellName;
            arParams[5].Value = SupplierAddressCellName;
            arParams[6].Value = LinkmanCellName;
            arParams[7].Value = TelephoneCellName;
            arParams[8].Value = FaxCellName;
            arParams[9].Value = MakerPsnCellName;
            arParams[10].Value = MemoCellName;
            arParams[11].Value = ItemRowIndex;
            arParams[12].Value = ItemRowCount;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.UpdateOutSrcLossSupplyFormat", arParams);
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
        public bool UpdateOutSrcLossSupplyFormat(ref string ErrorMsg, object FormatID, object TmpSheetName, object NoteCodeCellName, object DateNoteCellName, object SupplierCellName, object SupplierAddressCellName, object LinkmanCellName, object TelephoneCellName, object FaxCellName, object PONoCellName, object WorkingSheetCodeCellName, object PrdCodeCellName, object PrdNameCellName, object PrdSpecCellName, object ModelCellName, object PrdStatusCellName, object QuantityCellName, object UnitNameCellName, object MakerPsnCellName, object MemoCellName, object ItemRowIndex, object ItemRowCount)
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
            arParams[4] = new SqlParameter("@SupplierCellName", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@SupplierAddressCellName", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@LinkmanCellName", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@TelephoneCellName", SqlDbType.VarChar);
            arParams[7].Size = 50;
            arParams[8] = new SqlParameter("@FaxCellName", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@PONoCellName", SqlDbType.VarChar);
            arParams[9].Size = 50;
            arParams[10] = new SqlParameter("@WorkingSheetCodeCellName", SqlDbType.VarChar);
            arParams[10].Size = 50;
            arParams[11] = new SqlParameter("@PrdCodeCellName", SqlDbType.VarChar);
            arParams[11].Size = 50;
            arParams[12] = new SqlParameter("@PrdNameCellName", SqlDbType.VarChar);
            arParams[12].Size = 50;
            arParams[13] = new SqlParameter("@PrdSpecCellName", SqlDbType.VarChar);
            arParams[13].Size = 50;
            arParams[14] = new SqlParameter("@ModelCellName", SqlDbType.VarChar);
            arParams[14].Size = 50;
            arParams[15] = new SqlParameter("@PrdStatusCellName", SqlDbType.VarChar);
            arParams[15].Size = 50;
            arParams[16] = new SqlParameter("@QuantityCellName", SqlDbType.VarChar);
            arParams[16].Size = 50;
            arParams[17] = new SqlParameter("@UnitNameCellName", SqlDbType.VarChar);
            arParams[17].Size = 50;
            arParams[18] = new SqlParameter("@MakerPsnCellName", SqlDbType.VarChar);
            arParams[18].Size = 50;
            arParams[19] = new SqlParameter("@MemoCellName", SqlDbType.VarChar);
            arParams[19].Size = 50;
            arParams[20] = new SqlParameter("@ItemRowIndex", SqlDbType.Int);
            arParams[21] = new SqlParameter("@ItemRowCount", SqlDbType.Int);
            arParams[0].Value = FormatID;
            arParams[1].Value = TmpSheetName;
            arParams[2].Value = NoteCodeCellName;
            arParams[3].Value = DateNoteCellName;
            arParams[4].Value = SupplierCellName;
            arParams[5].Value = SupplierAddressCellName;
            arParams[6].Value = LinkmanCellName;
            arParams[7].Value = TelephoneCellName;
            arParams[8].Value = FaxCellName;
            arParams[9].Value = PONoCellName;
            arParams[10].Value = WorkingSheetCodeCellName;
            arParams[11].Value = PrdCodeCellName;
            arParams[12].Value = PrdNameCellName;
            arParams[13].Value = PrdSpecCellName;
            arParams[14].Value = ModelCellName;
            arParams[15].Value = PrdStatusCellName;
            arParams[16].Value = QuantityCellName;
            arParams[17].Value = UnitNameCellName;
            arParams[18].Value = MakerPsnCellName;
            arParams[19].Value = MemoCellName;
            arParams[20].Value = ItemRowIndex;
            arParams[21].Value = ItemRowCount;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.UpdateOutSrcLossSupplyFormat", arParams);
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