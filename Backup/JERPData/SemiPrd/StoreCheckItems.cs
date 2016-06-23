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
    /// 表[semiprd.StoreCheckItems]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/8/12 22:38:25
    ///</时间>  
    public class StoreCheckItems
    {
        private SqlConnection sqlConn;
        public StoreCheckItems()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public DataSet GetDataStoreCheckItemsByNoteID(long NoteID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[0].Value = NoteID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "semiprd.GetDataStoreCheckItemsByNoteID", arParams);
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
        public bool InsertStoreCheckItems(ref string ErrorMsg, object NoteID, object ManufProcessID, object CheckQty, object InventoryQty, object InitQty, object SurplusQty, object LostQty)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[7];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[2] = new SqlParameter("@CheckQty", SqlDbType.Decimal);
            arParams[2].Precision = 18;
            arParams[2].Scale = 4;
            arParams[3] = new SqlParameter("@InventoryQty", SqlDbType.Decimal);
            arParams[3].Precision = 18;
            arParams[3].Scale = 4;
            arParams[4] = new SqlParameter("@InitQty", SqlDbType.Decimal);
            arParams[4].Precision = 18;
            arParams[4].Scale = 4;
            arParams[5] = new SqlParameter("@SurplusQty", SqlDbType.Decimal);
            arParams[5].Precision = 18;
            arParams[5].Scale = 4;
            arParams[6] = new SqlParameter("@LostQty", SqlDbType.Decimal);
            arParams[6].Precision = 18;
            arParams[6].Scale = 4;
            arParams[0].Value = NoteID;
            arParams[1].Value = ManufProcessID;
            arParams[2].Value = CheckQty;
            arParams[3].Value = InventoryQty;
            arParams[4].Value = InitQty;
            arParams[5].Value = SurplusQty;
            arParams[6].Value = LostQty;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "semiprd.InsertStoreCheckItems", arParams);
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