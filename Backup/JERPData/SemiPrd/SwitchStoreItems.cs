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
namespace JERPData.SemiPrd
{
    /// <描述>
    /// 表[semiprd.SwitchStoreItems]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/8/12 22:38:55
    ///</时间>  
    public class SwitchStoreItems
    {
        private SqlConnection sqlConn;
        public SwitchStoreItems()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public DataSet GetDataSwitchStoreItemsByNoteID(long NoteID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[0].Value = NoteID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "semiprd.GetDataSwitchStoreItemsByNoteID", arParams);
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
        public bool InsertSwitchStoreItems(ref string ErrorMsg, object NoteID, object WorkingSheetID, object FromManufProcessID, object ToManufProcessID, object Quantity, object Memo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@WorkingSheetID", SqlDbType.BigInt);
            arParams[2] = new SqlParameter("@FromManufProcessID", SqlDbType.BigInt);
            arParams[3] = new SqlParameter("@ToManufProcessID", SqlDbType.BigInt);
            arParams[4] = new SqlParameter("@Quantity", SqlDbType.Decimal);
            arParams[4].Precision = 18;
            arParams[4].Scale = 4;
            arParams[5] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[5].Size = 100;
            arParams[0].Value = NoteID;
            arParams[1].Value = WorkingSheetID;
            arParams[2].Value = FromManufProcessID;
            arParams[3].Value = ToManufProcessID;
            arParams[4].Value = Quantity;
            arParams[5].Value = Memo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "semiprd.InsertSwitchStoreItems", arParams);
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