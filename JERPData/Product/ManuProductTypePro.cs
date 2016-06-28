using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;
namespace JERPData.Product
{
    ///<时间> 
    /// 2016/6/28 13:34:28
    ///</时间>  
    public class ManuProductTypePro
    {
        private SqlConnection sqlConn;
        public ManuProductTypePro()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }


        public bool InsertManuProductTypePro(ref string ErrorMsg, object PrdID, object ProType1, object ProType2, object ProType3, object ProType4, object ProType5, object ProType6, object ProType7)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[8];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@ProType1", SqlDbType.Int);
            arParams[2] = new SqlParameter("@ProType2", SqlDbType.Int);
            arParams[3] = new SqlParameter("@ProType3", SqlDbType.Int);
            arParams[4] = new SqlParameter("@ProType4", SqlDbType.Int);
            arParams[5] = new SqlParameter("@ProType5", SqlDbType.Int);
            arParams[6] = new SqlParameter("@ProType6", SqlDbType.Int);
            arParams[7] = new SqlParameter("@ProType7", SqlDbType.Int);
            arParams[0].Value = PrdID;
            arParams[1].Value = ProType1;
            arParams[2].Value = ProType2;
            arParams[3].Value = ProType3;
            arParams[4].Value = ProType4;
            arParams[5].Value = ProType5;
            arParams[6].Value = ProType6;
            arParams[7].Value = ProType7;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertManuProductTypePro", arParams);
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


        public bool UpdateManuProductTypePro(ref string ErrorMsg, object PrdID, object ProType1, object ProType2, object ProType3, object ProType4, object ProType5, object ProType6, object ProType7)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[8];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@ProType1", SqlDbType.Int);
            arParams[2] = new SqlParameter("@ProType2", SqlDbType.Int);
            arParams[3] = new SqlParameter("@ProType3", SqlDbType.Int);
            arParams[4] = new SqlParameter("@ProType4", SqlDbType.Int);
            arParams[5] = new SqlParameter("@ProType5", SqlDbType.Int);
            arParams[6] = new SqlParameter("@ProType6", SqlDbType.Int);
            arParams[7] = new SqlParameter("@ProType7", SqlDbType.Int);
            arParams[0].Value = PrdID;
            arParams[1].Value = ProType1;
            arParams[2].Value = ProType2;
            arParams[3].Value = ProType3;
            arParams[4].Value = ProType4;
            arParams[5].Value = ProType5;
            arParams[6].Value = ProType6;
            arParams[7].Value = ProType7;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateManuProductTypePro", arParams);
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
      

        public DataSet GetDataManuPrdType()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "prd.GetDataManuPrdType");
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



        public DataSet GetDataProductPrdSetByPrdTypeID(int PrdTypeID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PrdTypeID", SqlDbType.Int);
            arParams[0].Value = PrdTypeID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataProductPrdSetByPrdTypeID", arParams);
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


        public bool DeleteManuProductTypePro(ref string ErrorMsg, object PrdID)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.DeleteManuProductTypePro", arParams);
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
