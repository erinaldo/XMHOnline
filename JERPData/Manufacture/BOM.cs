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
    /// 表[manuf.BOM]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014-11-19 14:43:55
    ///</时间>  
    public class BOM
    {
        private SqlConnection sqlConn;
        public BOM()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }
        public bool DeleteBOM(ref string ErrorMsg, object ID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ID", SqlDbType.BigInt);
            arParams[0].Value = ID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.DeleteBOM", arParams);
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

        public DataSet GetDataBOMForOutStore(long ManufScheduleID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ManufScheduleID", SqlDbType.BigInt);
            arParams[0].Value = ManufScheduleID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataBOMForOutStore", arParams);
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
        public DataSet GetDataBOMByManufScheduleID(long ManufScheduleID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ManufScheduleID", SqlDbType.BigInt);
            arParams[0].Value = ManufScheduleID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataBOMByManufScheduleID", arParams);
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


        public bool InsertBOM(ref string ErrorMsg, ref object ID, object ManufScheduleID, object PrdID, object AssemblyQty, object LossRate, object SourceTypeID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@ID", SqlDbType.BigInt);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@ManufScheduleID", SqlDbType.BigInt);
            arParams[2] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@AssemblyQty", SqlDbType.Decimal);
            arParams[3].Precision = 18;
            arParams[3].Scale = 6;
            arParams[4] = new SqlParameter("@LossRate", SqlDbType.Decimal);
            arParams[4].Precision = 18;
            arParams[4].Scale = 6;
            arParams[5] = new SqlParameter("@SourceTypeID", SqlDbType.Int);
            arParams[0].Value = ID;
            arParams[1].Value = ManufScheduleID;
            arParams[2].Value = PrdID;
            arParams[3].Value = AssemblyQty;
            arParams[4].Value = LossRate;
            arParams[5].Value = SourceTypeID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.InsertBOM", arParams);
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
        public bool UpdateBOM(ref string ErrorMsg, object ID, object PrdID, object AssemblyQty, object LossRate, object SourceTypeID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@ID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@AssemblyQty", SqlDbType.Decimal);
            arParams[2].Precision = 18;
            arParams[2].Scale = 6;
            arParams[3] = new SqlParameter("@LossRate", SqlDbType.Decimal);
            arParams[3].Precision = 18;
            arParams[3].Scale = 6;
            arParams[4] = new SqlParameter("@SourceTypeID", SqlDbType.Int);
            arParams[0].Value = ID;
            arParams[1].Value = PrdID;
            arParams[2].Value = AssemblyQty;
            arParams[3].Value = LossRate;
            arParams[4].Value = SourceTypeID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateBOM", arParams);
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