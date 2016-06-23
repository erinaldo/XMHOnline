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
    /// 表[manuf.ManufBadReportItems]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2013-10-30 22:57:52
    ///</时间>  
    public class ManufBadReportItems
    {
        private SqlConnection sqlConn;
        public ManufBadReportItems()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public bool DeleteManufBadReportItems(ref string ErrorMsg, object ItemID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ItemID", SqlDbType.BigInt);
            arParams[0].Value = ItemID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.DeleteManufBadReportItems", arParams);
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

        public DataSet GetDataManufBadReportItemsForSetting(long NoteID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[0].Value = NoteID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataManufBadReportItemsForSetting", arParams);
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
        public DataSet GetDataManufBadReportItemsPivotBadTypeBetweenDate(DateTime DateBegin, DateTime DateEnd)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@DateBegin", SqlDbType.DateTime);
            arParams[1] = new SqlParameter("@DateEnd", SqlDbType.DateTime);
            arParams[0].Value = DateBegin;
            arParams[1].Value = DateEnd;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataManufBadReportItemsPivotBadTypeBetweenDate", arParams);
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
        public DataSet GetDataManufBadReportItemsPrdRptPivotProcessTypeBetweenDate(DateTime DateBegin, DateTime DateEnd)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@DateBegin", SqlDbType.DateTime);
            arParams[1] = new SqlParameter("@DateEnd", SqlDbType.DateTime);
            arParams[0].Value = DateBegin;
            arParams[1].Value = DateEnd;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataManufBadReportItemsPrdRptPivotProcessTypeBetweenDate", arParams);
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
        public DataSet GetDataManufBadReportItemsProcessTypeRptPivotBadTypeBetweenDate(DateTime DateBegin, DateTime DateEnd)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@DateBegin", SqlDbType.DateTime);
            arParams[1] = new SqlParameter("@DateEnd", SqlDbType.DateTime);
            arParams[0].Value = DateBegin;
            arParams[1].Value = DateEnd;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataManufBadReportItemsProcessTypeRptPivotBadTypeBetweenDate", arParams);
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


        public bool InsertManufBadReportItems(ref string ErrorMsg, ref object ItemID, object NoteID, object WorkingSheetID, object ManufProcessID, object Quantity, object BadQty)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@ItemID", SqlDbType.BigInt);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[2] = new SqlParameter("@WorkingSheetID", SqlDbType.BigInt);
            arParams[3] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[4] = new SqlParameter("@Quantity", SqlDbType.Decimal);
            arParams[4].Precision = 18;
            arParams[4].Scale = 4;
            arParams[5] = new SqlParameter("@BadQty", SqlDbType.Decimal);
            arParams[5].Precision = 18;
            arParams[5].Scale = 4;
            arParams[1].Value = NoteID;
            arParams[2].Value = WorkingSheetID;
            arParams[3].Value = ManufProcessID;
            arParams[4].Value = Quantity;
            arParams[5].Value = BadQty;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.InsertManufBadReportItems", arParams);
                ItemID = arParams[0].Value;
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
        public bool UpdateManufBadReportItems(ref string ErrorMsg, object ItemID, object Quantity, object BadQty)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@ItemID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@Quantity", SqlDbType.Decimal);
            arParams[1].Precision = 18;
            arParams[1].Scale = 4;
            arParams[2] = new SqlParameter("@BadQty", SqlDbType.Decimal);
            arParams[2].Precision = 18;
            arParams[2].Scale = 4;
            arParams[0].Value = ItemID;
            arParams[1].Value = Quantity;
            arParams[2].Value = BadQty;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateManufBadReportItems", arParams);
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