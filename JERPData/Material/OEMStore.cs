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
    /// 表[mtr.OEMStore]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/5/2 12:03:32
    ///</时间>  
    public class OEMStore
    {
        private SqlConnection sqlConn;
        public OEMStore()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }
        public DataSet GetDataOEMStoreCustomerSpotTime(DateTime SpotTime)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@SpotTime", SqlDbType.DateTime);
            arParams[0].Value = SpotTime;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "mtr.GetDataOEMStoreCustomerSpotTime", arParams);
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
        public DataSet GetDataOEMStorePivotCompanyID()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "mtr.GetDataOEMStorePivotCompanyID");
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
        public DataSet GetDataOEMStoreInventorySpotTime(DateTime SpotTime, int CompanyID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@SpotTime", SqlDbType.DateTime);
            arParams[1] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[0].Value = SpotTime;
            arParams[1].Value = CompanyID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "mtr.GetDataOEMStoreInventorySpotTime", arParams);
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
        public DataSet GetDataOEMStoreMonthRpt(int Year, int Month, int CompanyID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@Year", SqlDbType.Int);
            arParams[1] = new SqlParameter("@Month", SqlDbType.Int);
            arParams[2] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[0].Value = Year;
            arParams[1].Value = Month;
            arParams[2].Value = CompanyID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "mtr.GetDataOEMStoreMonthRpt", arParams);
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
        public DataSet GetDataOEMStoreRecord(int PrdID, int CompanyID, DateTime DateBegin, DateTime DateEnd)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@DateBegin", SqlDbType.DateTime);
            arParams[3] = new SqlParameter("@DateEnd", SqlDbType.DateTime);
            arParams[0].Value = PrdID;
            arParams[1].Value = CompanyID;
            arParams[2].Value = DateBegin;
            arParams[3].Value = DateEnd;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "mtr.GetDataOEMStoreRecord", arParams);
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

        public DataSet GetDataOEMStoreCustomer()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "mtr.GetDataOEMStoreCustomer");
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
        public DataSet GetDataOEMStoreInventoryByCompanyID(int CompanyID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[0].Value = CompanyID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "mtr.GetDataOEMStoreInventoryByCompanyID", arParams);
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
        public DataSet GetDataOEMStoreInventory()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "mtr.GetDataOEMStoreInventory");
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
        public DataSet GetDataOEMStoreSafeInventoryByCustomerID(int CustomerID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@CustomerID", SqlDbType.Int);
            arParams[0].Value = CustomerID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "mtr.GetDataOEMStoreSafeInventoryByCustomerID", arParams);
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
        public DataSet GetDataOEMStoreSafeInventory()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "mtr.GetDataOEMStoreSafeInventory");
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
        public bool GetParmOEMStoreAvailableStoreQty(int CompanyID, int PrdID, ref decimal AvailableStoreQty)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@AvailableStoreQty", SqlDbType.Decimal);
            arParams[2].Precision = 18;
            arParams[2].Scale = 4;
            arParams[2].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = CompanyID;
            arParams[1].Value = PrdID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "mtr.GetParmOEMStoreAvailableStoreQty", arParams);
                AvailableStoreQty = (decimal)arParams[2].Value;
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
        public bool GetParmOEMStoreExistFlag(int PrdID, int CompanyID, ref bool ExistFlag)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@ExistFlag", SqlDbType.Bit);
            arParams[2].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = PrdID;
            arParams[1].Value = CompanyID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "mtr.GetParmOEMStoreExistFlag", arParams);
                ExistFlag = (bool)arParams[2].Value;
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
        public bool GetParmOEMStoreInventoryQty(int CompanyID, int PrdID, ref decimal InventoryQty)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@InventoryQty", SqlDbType.Decimal);
            arParams[2].Precision = 18;
            arParams[2].Scale = 4;
            arParams[2].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = CompanyID;
            arParams[1].Value = PrdID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "mtr.GetParmOEMStoreInventoryQty", arParams);
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
        public bool InsertOEMStoreForCheckIntoStore(ref string ErrorMsg, object NoteNameID, object NoteName, object NoteID, object NoteCode, object PrdID, object CompanyID, object IntoQty)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[7];
            arParams[0] = new SqlParameter("@NoteNameID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@NoteName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[3] = new SqlParameter("@NoteCode", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[5] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[6] = new SqlParameter("@IntoQty", SqlDbType.Decimal);
            arParams[6].Precision = 18;
            arParams[6].Scale = 4;
            arParams[0].Value = NoteNameID;
            arParams[1].Value = NoteName;
            arParams[2].Value = NoteID;
            arParams[3].Value = NoteCode;
            arParams[4].Value = PrdID;
            arParams[5].Value = CompanyID;
            arParams[6].Value = IntoQty;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.InsertOEMStoreForCheckIntoStore", arParams);
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
        public bool InsertOEMStoreForCheckOutStore(ref string ErrorMsg, object NoteNameID, object NoteName, object NoteID, object NoteCode, object PrdID, object CompanyID, object OutQty)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[7];
            arParams[0] = new SqlParameter("@NoteNameID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@NoteName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[3] = new SqlParameter("@NoteCode", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[5] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[6] = new SqlParameter("@OutQty", SqlDbType.Decimal);
            arParams[6].Precision = 18;
            arParams[6].Scale = 4;
            arParams[0].Value = NoteNameID;
            arParams[1].Value = NoteName;
            arParams[2].Value = NoteID;
            arParams[3].Value = NoteCode;
            arParams[4].Value = PrdID;
            arParams[5].Value = CompanyID;
            arParams[6].Value = OutQty;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.InsertOEMStoreForCheckOutStore", arParams);
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
        public bool InsertOEMStoreForInitStore(ref string ErrorMsg, object NoteNameID, object NoteName, object NoteID, object NoteCode, object PrdID, object CompanyID, object InitQty)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[7];
            arParams[0] = new SqlParameter("@NoteNameID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@NoteName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[3] = new SqlParameter("@NoteCode", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[5] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[6] = new SqlParameter("@InitQty", SqlDbType.Decimal);
            arParams[6].Precision = 18;
            arParams[6].Scale = 4;
            arParams[0].Value = NoteNameID;
            arParams[1].Value = NoteName;
            arParams[2].Value = NoteID;
            arParams[3].Value = NoteCode;
            arParams[4].Value = PrdID;
            arParams[5].Value = CompanyID;
            arParams[6].Value = InitQty;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.InsertOEMStoreForInitStore", arParams);
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
        public bool InsertOEMStoreForIntoStore(ref string ErrorMsg, object NoteNameID, object NoteName, object NoteID, object NoteCode, object PrdID, object CompanyID, object IntoQty)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[7];
            arParams[0] = new SqlParameter("@NoteNameID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@NoteName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[3] = new SqlParameter("@NoteCode", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[5] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[6] = new SqlParameter("@IntoQty", SqlDbType.Decimal);
            arParams[6].Precision = 18;
            arParams[6].Scale = 4;
            arParams[0].Value = NoteNameID;
            arParams[1].Value = NoteName;
            arParams[2].Value = NoteID;
            arParams[3].Value = NoteCode;
            arParams[4].Value = PrdID;
            arParams[5].Value = CompanyID;
            arParams[6].Value = IntoQty;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.InsertOEMStoreForIntoStore", arParams);
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
        public bool InsertOEMStoreForOutStore(ref string ErrorMsg, object NoteNameID, object NoteName, object NoteID, object NoteCode, object PrdID, object CompanyID, object OutQty)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[7];
            arParams[0] = new SqlParameter("@NoteNameID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@NoteName", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[3] = new SqlParameter("@NoteCode", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[5] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[6] = new SqlParameter("@OutQty", SqlDbType.Decimal);
            arParams[6].Precision = 18;
            arParams[6].Scale = 4;
            arParams[0].Value = NoteNameID;
            arParams[1].Value = NoteName;
            arParams[2].Value = NoteID;
            arParams[3].Value = NoteCode;
            arParams[4].Value = PrdID;
            arParams[5].Value = CompanyID;
            arParams[6].Value = OutQty;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.InsertOEMStoreForOutStore", arParams);
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