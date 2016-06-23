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
namespace JERPData.Finance
{
    /// <描述>
    /// 表[finance.BasicWages]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/5/7 15:25:58
    ///</时间>  
    public class BasicWages
    {
        private SqlConnection sqlConn;
        public BasicWages()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }


        public bool DeleteBasicWages(ref string ErrorMsg, object WageID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@WageID", SqlDbType.Int);
            arParams[0].Value = WageID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "finance.DeleteBasicWages", arParams);
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
        public DataSet GetDataBasicWages()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "finance.GetDataBasicWages");
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
        public bool GetParmBasicWagesWage(int PsnID, ref decimal StaticWage, ref decimal PositionWage)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@StaticWage", SqlDbType.Money);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[2] = new SqlParameter("@PositionWage", SqlDbType.Money);
            arParams[2].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = PsnID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "finance.GetParmBasicWagesWage", arParams);
                StaticWage = (decimal)arParams[1].Value;
                PositionWage = (decimal)arParams[2].Value;
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
        public bool InsertBasicWages(ref string ErrorMsg, ref object WageID, object PsnID, object StaticWage, object PositionWage)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@WageID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@StaticWage", SqlDbType.Money);
            arParams[3] = new SqlParameter("@PositionWage", SqlDbType.Money);
            arParams[1].Value = PsnID;
            arParams[2].Value = StaticWage;
            arParams[3].Value = PositionWage;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "finance.InsertBasicWages", arParams);
                WageID = arParams[0].Value;
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
        public bool UpdateBasicWages(ref string ErrorMsg, object WageID, object PsnID, object StaticWage, object PositionWage)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@WageID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@StaticWage", SqlDbType.Money);
            arParams[3] = new SqlParameter("@PositionWage", SqlDbType.Money);
            arParams[0].Value = WageID;
            arParams[1].Value = PsnID;
            arParams[2].Value = StaticWage;
            arParams[3].Value = PositionWage;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "finance.UpdateBasicWages", arParams);
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