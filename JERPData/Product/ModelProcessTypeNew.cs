using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;
namespace JERPData.Product
{
    /// <描述>
    /// 表[manuf.ModeProcessTypeNew]数据访问类
    ///</描述> 
    ///<作者> 
    /// 
    ///</作者> 
    ///<时间> 
    /// 2016-08-20 10:34:02
    ///</时间>  
    public class ModelProcessTypeNew
    {
        private SqlConnection sqlConn;
        public ModelProcessTypeNew()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }


        public DataSet GetDataModeProcessTypeNew()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "manuf.GetDataModelProcessTypeNew");
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


        public bool InsertModeProcessTypeNew(ref string ErrorMsg, ref object ModelProcessID, object ModelProcessCode, object ModelProcessName, object ModelProcessMemo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@ModelProcessID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@ModelProcessCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@ModelProcessName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@ModelProcessMemo", SqlDbType.VarChar);
            arParams[3].Size = 400;
            arParams[0].Value = ModelProcessID;
            arParams[1].Value = ModelProcessCode;
            arParams[2].Value = ModelProcessName;
            arParams[3].Value = ModelProcessMemo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.InsertModelProcessTypeNew", arParams);
                ModelProcessID = arParams[0].Value;
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


        public bool UpdateModeProcessTypeNew(ref string ErrorMsg, object ModelProcessID, object ModelProcessCode, object ModelProcessName, object ModelProcessMemo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@ModelProcessID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@ModelProcessCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@ModelProcessName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@ModelProcessMemo", SqlDbType.VarChar);
            arParams[3].Size = 400;
            arParams[0].Value = ModelProcessID;
            arParams[1].Value = ModelProcessCode;
            arParams[2].Value = ModelProcessName;
            arParams[3].Value = ModelProcessMemo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateModelProcessTypeNew", arParams);
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

        public bool DeleteModeProcessTypeNew(ref string ErrorMsg, object ModelProcessID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ModelProcessID", SqlDbType.Int);
            arParams[0].Value = ModelProcessID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.DeleteModelProcessTypeNew", arParams);
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


        public bool GetParmModelProcessByName(string ModelProcessName, ref int ModelProcessID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ModelProcessName", SqlDbType.VarChar);
            arParams[0].Size = 50;
            arParams[1] = new SqlParameter("@ModelProcessID", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = ModelProcessName;
            arParams[1].Value = ModelProcessID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "manuf.GetParmModelProcessByName", arParams);
                ModelProcessID = (int)arParams[1].Value;
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

    }
}