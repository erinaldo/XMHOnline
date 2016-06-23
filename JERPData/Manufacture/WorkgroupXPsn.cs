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
namespace JERPData.Manufacture
{
    /// <描述>
    /// 表[manuf.WorkingGroupXPsn]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015-02-17 16:12:31
    ///</时间>  
    public class WorkgroupXPsn
    {
        private SqlConnection sqlConn;
        public WorkgroupXPsn()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }


        public bool DeleteWorkgroupXPsn(ref string ErrorMsg, object WorkgroupID, object ShiftID, object PsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@WorkgroupID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@ShiftID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[0].Value = WorkgroupID;
            arParams[1].Value = ShiftID;
            arParams[2].Value = PsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.DeleteWorkgroupXPsn", arParams);
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
        public DataSet GetDataWorkgroupXPsnForDailyWorking(int WorkgroupID, int ShiftID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@WorkgroupID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@ShiftID", SqlDbType.Int);
            arParams[0].Value = WorkgroupID;
            arParams[1].Value = ShiftID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataWorkgroupXPsnForDailyWorking", arParams);
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
        public bool SaveWorkgroupXPsn(ref string ErrorMsg, object WorkgroupID, object ShiftID, object PsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@WorkgroupID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@ShiftID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[0].Value = WorkgroupID;
            arParams[1].Value = ShiftID;
            arParams[2].Value = PsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.SaveWorkgroupXPsn", arParams);
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