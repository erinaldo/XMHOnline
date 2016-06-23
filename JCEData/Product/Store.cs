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
namespace JCEData.Product
{
    /// <描述>
    /// 表[prd.Store]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2013-02-15 11:22:10
    ///</时间>  
    public class Store
    {
        private SqlConnection sqlConn;
        public Store()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public bool GetParmStoreInventoryPrice(int PrdID, int BranchStoreID, ref decimal InventoryPrice)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@BranchStoreID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@InventoryPrice", SqlDbType.Money);
            arParams[2].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = PrdID;
            arParams[1].Value = BranchStoreID;
            arParams[2].Value = InventoryPrice;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "prd.GetParmStoreInventoryPrice", arParams);
                InventoryPrice = (decimal)arParams[2].Value;
                flag = true;
            }
            catch//(SqlException ex)
            {
                flag = false;
            }
            finally
            {
                this.sqlConn.Close();
            }
            return flag;
        }
        public bool GetParmStoreInventoryQty(int PrdID, int BranchStoreID, ref decimal InventoryQty)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@BranchStoreID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@InventoryQty", SqlDbType.Decimal);
            arParams[2].Precision = 18;
            arParams[2].Scale = 4;
            arParams[2].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = PrdID;
            arParams[1].Value = BranchStoreID;
            arParams[2].Value = InventoryQty;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "prd.GetParmStoreInventoryQty", arParams);
                InventoryQty = (decimal)arParams[2].Value;
                flag = true;
            }
            catch//(SqlException ex)
            {
                flag = false;
            }
            finally
            {
                this.sqlConn.Close();
            }
            return flag;
        }
        public bool InsertStoreForIntoStore(ref string ErrorMsg, object NoteNameID, object NoteID, object NoteCode, object PrdID, object BranchStoreID, object IntoQty, object IntoPrice)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[7];
            arParams[0] = new SqlParameter("@NoteNameID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[2] = new SqlParameter("@NoteCode", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@BranchStoreID", SqlDbType.Int);
            arParams[5] = new SqlParameter("@IntoQty", SqlDbType.Decimal);
            arParams[5].Precision = 18;
            arParams[5].Scale = 4;
            arParams[6] = new SqlParameter("@IntoPrice", SqlDbType.Money);
            arParams[0].Value = NoteNameID;
            arParams[1].Value = NoteID;
            arParams[2].Value = NoteCode;
            arParams[3].Value = PrdID;
            arParams[4].Value = BranchStoreID;
            arParams[5].Value = IntoQty;
            arParams[6].Value = IntoPrice;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertStoreForIntoStore", arParams);
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
        public bool InsertStoreForOutStore(ref string ErrorMsg, object NoteNameID, object NoteID, object NoteCode, object PrdID, object BranchStoreID, object OutQty, object OutPrice)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[7];
            arParams[0] = new SqlParameter("@NoteNameID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[2] = new SqlParameter("@NoteCode", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@BranchStoreID", SqlDbType.Int);
            arParams[5] = new SqlParameter("@OutQty", SqlDbType.Decimal);
            arParams[5].Precision = 18;
            arParams[5].Scale = 4;
            arParams[6] = new SqlParameter("@OutPrice", SqlDbType.Money);
            arParams[0].Value = NoteNameID;
            arParams[1].Value = NoteID;
            arParams[2].Value = NoteCode;
            arParams[3].Value = PrdID;
            arParams[4].Value = BranchStoreID;
            arParams[5].Value = OutQty;
            arParams[6].Value = OutPrice;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertStoreForOutStore", arParams);
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