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
    /// 表[mtr.OEMRoadStoreReserve]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/7/31 17:55:02
    ///</时间>  
    public class OEMRoadStoreReserve
    {
        private SqlConnection sqlConn;
        public OEMRoadStoreReserve()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public DataSet GetDataOEMRoadStoreReserve(int CompanyID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[0].Value = CompanyID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "mtr.GetDataOEMRoadStoreReserve", arParams);
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
        public bool GetParmOEMRoadStoreReserveQuantity(int CompanyID, int PrdID, ref decimal Quantity)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@Quantity", SqlDbType.Decimal);
            arParams[2].Precision = 18;
            arParams[2].Scale = 4;
            arParams[2].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = CompanyID;
            arParams[1].Value = PrdID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "mtr.GetParmOEMRoadStoreReserveQuantity", arParams);
                Quantity = (decimal)arParams[2].Value;
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
        public bool SaveOEMRoadStoreReserveAppReserve(ref string ErrorMsg, object CompanyID, object PrdID, object Quantity)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@Quantity", SqlDbType.Decimal);
            arParams[2].Precision = 18;
            arParams[2].Scale = 4;
            arParams[0].Value = CompanyID;
            arParams[1].Value = PrdID;
            arParams[2].Value = Quantity;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.SaveOEMRoadStoreReserveAppReserve", arParams);
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
        public bool SaveOEMRoadStoreReserveCheck(ref string ErrorMsg, object CompanyID, object PrdID, object Quantity)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@Quantity", SqlDbType.Decimal);
            arParams[2].Precision = 18;
            arParams[2].Scale = 4;
            arParams[0].Value = CompanyID;
            arParams[1].Value = PrdID;
            arParams[2].Value = Quantity;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.SaveOEMRoadStoreReserveCheck", arParams);
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

        public bool SaveOEMRoadStoreReserveSwitchToStoreReserve(ref string ErrorMsg, object CompanyID, object PrdID, object Quantity)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@Quantity", SqlDbType.Decimal);
            arParams[2].Precision = 18;
            arParams[2].Scale = 4;
            arParams[0].Value = CompanyID;
            arParams[1].Value = PrdID;
            arParams[2].Value = Quantity;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.SaveOEMRoadStoreReserveSwitchToStoreReserve", arParams);
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
        public bool UpdateOEMRoadStoreReserveForAdjustStore(ref string ErrorMsg, object CompanyID, object PrdID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[0].Value = CompanyID;
            arParams[1].Value = PrdID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.UpdateOEMRoadStoreReserveForAdjustStore", arParams);
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