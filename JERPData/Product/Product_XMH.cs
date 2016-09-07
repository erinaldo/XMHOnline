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
    /// 表[prd.Product_XMH]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016-09-02 16:12:46
    ///</时间>  
    public class Product_XMH
    {
        private SqlConnection sqlConn;
        public Product_XMH()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public DataSet GetDataProduct_XMHByPrdID(int PrdID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[0].Value = PrdID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataProduct_XMHByPrdID", arParams);
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


        public  DataSet GetDataProduct_XMHBySql(String sql)
        {
            DataSet ds = null;
            try
            {
                if (DBConnection.JSqlDBConn.State == System.Data.ConnectionState.Closed) DBConnection.JSqlDBConn.Open();
                ds = SqlHelper.ExecuteDataset(DBConnection.JSqlDBConn, CommandType.Text, sql);
            }
            catch//(SqlException ex)
            {
                // ex.Message --这里作调试用
            }
            finally
            {
                DBConnection.JSqlDBConn.Close();
            }
            return ds;
        }


        public bool InsertProduct_XMH(ref string ErrorMsg, object PrdID, object DPType, object JMPrice, object PFPrice, object HYPrice, object LSPrice, object CustomCode, object Brand, object CustomFlag)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[9];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@DPType", SqlDbType.Int);
            arParams[2] = new SqlParameter("@JMPrice", SqlDbType.Money);
            arParams[3] = new SqlParameter("@PFPrice", SqlDbType.Money);
            arParams[4] = new SqlParameter("@HYPrice", SqlDbType.Money);
            arParams[5] = new SqlParameter("@LSPrice", SqlDbType.Money);
            arParams[6] = new SqlParameter("@CustomCode", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@Brand", SqlDbType.VarChar);
            arParams[7].Size = 50;
            arParams[8] = new SqlParameter("@CustomFlag", SqlDbType.Bit);
            arParams[0].Value = PrdID;
            arParams[1].Value = DPType;
            arParams[2].Value = JMPrice;
            arParams[3].Value = PFPrice;
            arParams[4].Value = HYPrice;
            arParams[5].Value = LSPrice;
            arParams[6].Value = CustomCode;
            arParams[7].Value = Brand;
            arParams[8].Value = CustomFlag;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertProduct_XMH", arParams);
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

        public bool UpdateProduct_XMH(ref string ErrorMsg, object PrdID, object DPType, object JMPrice, object PFPrice, object HYPrice, object LSPrice, object CustomCode, object Brand, object CustomFlag)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[9];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@DPType", SqlDbType.Int);
            arParams[2] = new SqlParameter("@JMPrice", SqlDbType.Money);
            arParams[3] = new SqlParameter("@PFPrice", SqlDbType.Money);
            arParams[4] = new SqlParameter("@HYPrice", SqlDbType.Money);
            arParams[5] = new SqlParameter("@LSPrice", SqlDbType.Money);
            arParams[6] = new SqlParameter("@CustomCode", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@Brand", SqlDbType.VarChar);
            arParams[7].Size = 50;
            arParams[8] = new SqlParameter("@CustomFlag", SqlDbType.Bit);
            arParams[0].Value = PrdID;
            arParams[1].Value = DPType;
            arParams[2].Value = JMPrice;
            arParams[3].Value = PFPrice;
            arParams[4].Value = HYPrice;
            arParams[5].Value = LSPrice;
            arParams[6].Value = CustomCode;
            arParams[7].Value = Brand;
            arParams[8].Value = CustomFlag;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateProduct_XMH", arParams);
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
    


        public bool DeleteProduct_XMH(ref string ErrorMsg, object PrdID)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.DeleteProduct_XMH", arParams);
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