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
namespace JERPData.Technology
{
    /// <描述>
    /// 表[tech.DevelopSchedules]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014-10-10 14:12:02
    ///</时间>  
    public class DevelopSchedules
    {
        private SqlConnection sqlConn;
        public DevelopSchedules()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }


        public bool DeleteDevelopSchedules(ref string ErrorMsg, object DevelopProcessID, object PsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@DevelopProcessID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[0].Value = DevelopProcessID;
            arParams[1].Value = PsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "tech.DeleteDevelopSchedules", arParams);
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
        public DataSet GetDataDevelopSchedulesForPrdSetting(int PrdID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[0].Value = PrdID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "tech.GetDataDevelopSchedulesForPrdSetting", arParams);
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
        public DataSet GetDataDevelopSchedulesForPsnSeeting(int PsnID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[0].Value = PsnID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "tech.GetDataDevelopSchedulesForPsnSeeting", arParams);
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
        public bool SaveDevelopSchedules(ref string ErrorMsg, object DevelopProcessID, object PsnID, object DateSchedule, object ScheduleFlag)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@DevelopProcessID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@DateSchedule", SqlDbType.DateTime);
            arParams[3] = new SqlParameter("@ScheduleFlag", SqlDbType.Bit);
            arParams[0].Value = DevelopProcessID;
            arParams[1].Value = PsnID;
            arParams[2].Value = DateSchedule;
            arParams[3].Value = ScheduleFlag;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "tech.SaveDevelopSchedules", arParams);
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