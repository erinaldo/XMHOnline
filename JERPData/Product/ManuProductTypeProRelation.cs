using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace JERPData.Product
{
    public class ManuProductTypeProRelation
    {
        private SqlConnection sqlConn;
        public ManuProductTypeProRelation()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }



        public bool InsertManuProductTypeProRelation(ref string ErrorMsg, ref object ID, object PrdIDSrc, object PrdIDDescr)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@ID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@PrdIDSrc", SqlDbType.Int);
            arParams[2] = new SqlParameter("@PrdIDDesc", SqlDbType.Int);
            arParams[0].Value = ID;
            arParams[1].Value = PrdIDSrc;
            arParams[2].Value = PrdIDDescr;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertManuProductTypeProRelation", arParams);
                ID = arParams[0].Value;
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

        public bool DeleteManuProductTypeProRelation(ref string ErrorMsg, object ID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ID", SqlDbType.Int);
            arParams[0].Value = ID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.DeleteManuProductTypeProRelation", arParams);
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

        public DataSet GetDataManuProductTypeProRelation()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "prd.GetDataManuProductTypeProRelation");
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
    }
}
