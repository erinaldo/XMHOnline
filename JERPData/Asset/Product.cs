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
namespace JERPData.Asset
{
    /// <描述>
    /// 表[asset.Product]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014-12-22 11:47:54
    ///</时间>  
    public class Product
    {
        private SqlConnection sqlConn;
        public Product()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public bool DeleteProduct(ref string ErrorMsg, object PrdID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[0].Value = PrdID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "asset.DeleteProduct", arParams);
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
        public DataSet GetDataProduct()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "asset.GetDataProduct");
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
        public DataSet GetDataProductByPrdID(int PrdID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[0].Value = PrdID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "asset.GetDataProductByPrdID", arParams);
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
        public bool GetParmPrdID(string PrdCode, ref int PrdID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PrdCode", SqlDbType.VarChar);
            arParams[0].Size = 100;
            arParams[1] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = PrdCode;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "asset.GetParmPrdID", arParams);
                PrdID = (int)arParams[1].Value;
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
        public bool InsertProduct(ref string ErrorMsg, ref object PrdID, object PrdCode, object PrdName, object UserName, object ResponsiblePsnName, object DepositPlace, object DepositStatus, object DatePurchase, object Cost, object Salvage, object AccumDepreciate)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[11];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@PrdCode", SqlDbType.VarChar);
            arParams[1].Size = 100;
            arParams[2] = new SqlParameter("@PrdName", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@UserName", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@ResponsiblePsnName", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@DepositPlace", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@DepositStatus", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@DatePurchase", SqlDbType.DateTime);
            arParams[8] = new SqlParameter("@Cost", SqlDbType.Money);
            arParams[9] = new SqlParameter("@Salvage", SqlDbType.Money);
            arParams[10] = new SqlParameter("@AccumDepreciate", SqlDbType.Money);
            arParams[1].Value = PrdCode;
            arParams[2].Value = PrdName;
            arParams[3].Value = UserName;
            arParams[4].Value = ResponsiblePsnName;
            arParams[5].Value = DepositPlace;
            arParams[6].Value = DepositStatus;
            arParams[7].Value = DatePurchase;
            arParams[8].Value = Cost;
            arParams[9].Value = Salvage;
            arParams[10].Value = AccumDepreciate;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "asset.InsertProduct", arParams);
                PrdID = arParams[0].Value;
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
        public bool UpdateProduct(ref string ErrorMsg, object PrdID, object PrdCode, object PrdName, object UserName, object ResponsiblePsnName, object DepositPlace, object DepositStatus, object DatePurchase, object Cost, object Salvage, object AccumDepreciate)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[11];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PrdCode", SqlDbType.VarChar);
            arParams[1].Size = 100;
            arParams[2] = new SqlParameter("@PrdName", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@UserName", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@ResponsiblePsnName", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@DepositPlace", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@DepositStatus", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@DatePurchase", SqlDbType.DateTime);
            arParams[8] = new SqlParameter("@Cost", SqlDbType.Money);
            arParams[9] = new SqlParameter("@Salvage", SqlDbType.Money);
            arParams[10] = new SqlParameter("@AccumDepreciate", SqlDbType.Money);
            arParams[0].Value = PrdID;
            arParams[1].Value = PrdCode;
            arParams[2].Value = PrdName;
            arParams[3].Value = UserName;
            arParams[4].Value = ResponsiblePsnName;
            arParams[5].Value = DepositPlace;
            arParams[6].Value = DepositStatus;
            arParams[7].Value = DatePurchase;
            arParams[8].Value = Cost;
            arParams[9].Value = Salvage;
            arParams[10].Value = AccumDepreciate;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "asset.UpdateProduct", arParams);
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
        public bool UpdateProductForRepair(ref string ErrorMsg, object PrdID, object DateLastRepair)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@DateLastRepair", SqlDbType.DateTime);
            arParams[0].Value = PrdID;
            arParams[1].Value = DateLastRepair;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "asset.UpdateProductForRepair", arParams);
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