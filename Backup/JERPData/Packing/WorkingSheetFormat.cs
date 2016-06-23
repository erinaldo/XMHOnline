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
namespace JERPData.Packing
{
    /// <描述>
    /// 表[packing.WorkingSheetFormat]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2013-12-20 22:02:36
    ///</时间>  
    public class WorkingSheetFormat
    {
        private SqlConnection sqlConn;
        public WorkingSheetFormat()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }
        public bool DeleteWorkingSheetFormat(ref string ErrorMsg, object FormatID)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "packing.DeleteWorkingSheetFormat", arParams);
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
        public DataSet GetDataWorkingSheetFormat()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "packing.GetDataWorkingSheetFormat");
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
        public DataSet GetDataWorkingSheetFormatByFormatID(int FormatID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[0].Value = FormatID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "packing.GetDataWorkingSheetFormatByFormatID", arParams);
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

        public bool InsertWorkingSheetFormat(ref string ErrorMsg, ref object FormatID, object TmpSheetName, object WorkingSheetCodeCellName, object DateNoteCellName, object CompanyNameCellName, object PrdCodeCellName, object PrdNameCellName, object PrdSpecCellName, object ModelCellName, object QuantityCellName, object UnitNameCellName, object DateTargetCellName, object PackingTypeCellName, object MemoCellName, object MakerPsnCellName)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[15];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@TmpSheetName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@WorkingSheetCodeCellName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@DateNoteCellName", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@CompanyNameCellName", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@PrdCodeCellName", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@PrdNameCellName", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@PrdSpecCellName", SqlDbType.VarChar);
            arParams[7].Size = 50;
            arParams[8] = new SqlParameter("@ModelCellName", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@QuantityCellName", SqlDbType.VarChar);
            arParams[9].Size = 50;
            arParams[10] = new SqlParameter("@UnitNameCellName", SqlDbType.VarChar);
            arParams[10].Size = 50;
            arParams[11] = new SqlParameter("@DateTargetCellName", SqlDbType.VarChar);
            arParams[11].Size = 50;
            arParams[12] = new SqlParameter("@PackingTypeCellName", SqlDbType.VarChar);
            arParams[12].Size = 50;
            arParams[13] = new SqlParameter("@MemoCellName", SqlDbType.VarChar);
            arParams[13].Size = 50;
            arParams[14] = new SqlParameter("@MakerPsnCellName", SqlDbType.VarChar);
            arParams[14].Size = 50;
            arParams[0].Value = FormatID;
            arParams[1].Value = TmpSheetName;
            arParams[2].Value = WorkingSheetCodeCellName;
            arParams[3].Value = DateNoteCellName;
            arParams[4].Value = CompanyNameCellName;
            arParams[5].Value = PrdCodeCellName;
            arParams[6].Value = PrdNameCellName;
            arParams[7].Value = PrdSpecCellName;
            arParams[8].Value = ModelCellName;
            arParams[9].Value = QuantityCellName;
            arParams[10].Value = UnitNameCellName;
            arParams[11].Value = DateTargetCellName;
            arParams[12].Value = PackingTypeCellName;
            arParams[13].Value = MemoCellName;
            arParams[14].Value = MakerPsnCellName;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "packing.InsertWorkingSheetFormat", arParams);
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
        public bool InsertWorkingSheetFormatFromCopy(ref string ErrorMsg, object OldFormatID, object TmpSheetName)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "packing.InsertWorkingSheetFormatFromCopy", arParams);
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
        public bool UpdateWorkingSheetFormat(ref string ErrorMsg, object FormatID, object TmpSheetName, object WorkingSheetCodeCellName, object DateNoteCellName, object CompanyNameCellName, object PrdCodeCellName, object PrdNameCellName, object PrdSpecCellName, object ModelCellName, object QuantityCellName, object UnitNameCellName, object DateTargetCellName, object PackingTypeCellName, object MemoCellName, object MakerPsnCellName)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[15];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@TmpSheetName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@WorkingSheetCodeCellName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@DateNoteCellName", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@CompanyNameCellName", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@PrdCodeCellName", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@PrdNameCellName", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@PrdSpecCellName", SqlDbType.VarChar);
            arParams[7].Size = 50;
            arParams[8] = new SqlParameter("@ModelCellName", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@QuantityCellName", SqlDbType.VarChar);
            arParams[9].Size = 50;
            arParams[10] = new SqlParameter("@UnitNameCellName", SqlDbType.VarChar);
            arParams[10].Size = 50;
            arParams[11] = new SqlParameter("@DateTargetCellName", SqlDbType.VarChar);
            arParams[11].Size = 50;
            arParams[12] = new SqlParameter("@PackingTypeCellName", SqlDbType.VarChar);
            arParams[12].Size = 50;
            arParams[13] = new SqlParameter("@MemoCellName", SqlDbType.VarChar);
            arParams[13].Size = 50;
            arParams[14] = new SqlParameter("@MakerPsnCellName", SqlDbType.VarChar);
            arParams[14].Size = 50;
            arParams[0].Value = FormatID;
            arParams[1].Value = TmpSheetName;
            arParams[2].Value = WorkingSheetCodeCellName;
            arParams[3].Value = DateNoteCellName;
            arParams[4].Value = CompanyNameCellName;
            arParams[5].Value = PrdCodeCellName;
            arParams[6].Value = PrdNameCellName;
            arParams[7].Value = PrdSpecCellName;
            arParams[8].Value = ModelCellName;
            arParams[9].Value = QuantityCellName;
            arParams[10].Value = UnitNameCellName;
            arParams[11].Value = DateTargetCellName;
            arParams[12].Value = PackingTypeCellName;
            arParams[13].Value = MemoCellName;
            arParams[14].Value = MakerPsnCellName;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "packing.UpdateWorkingSheetFormat", arParams);
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