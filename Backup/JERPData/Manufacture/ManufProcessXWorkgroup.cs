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
    /// 表[manuf.ManufProcessXWorkgroup]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/6/4 11:49:02
    ///</时间>  
    public class ManufProcessXWorkgroup
    {
        private SqlConnection sqlConn;
        public ManufProcessXWorkgroup()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        } 
        public DataSet GetDataManufProcessXWorkgroup()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "manuf.GetDataManufProcessXWorkgroup");
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
        public bool SaveManufProcessXWorkgroup(ref string ErrorMsg, object ManufProcessID, object WorkgroupID, object HourManufQty)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@WorkgroupID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@HourManufQty", SqlDbType.Decimal);
            arParams[2].Precision = 18;
            arParams[2].Scale = 4;
            arParams[0].Value = ManufProcessID;
            arParams[1].Value = WorkgroupID;
            arParams[2].Value = HourManufQty;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.SaveManufProcessXWorkgroup", arParams);
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