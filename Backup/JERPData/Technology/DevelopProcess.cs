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
    /// 表[tech.DevelopProcess]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014-10-10 14:11:27
    ///</时间>  
    public class DevelopProcess
    {
        private SqlConnection sqlConn;
        public DevelopProcess()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }


        public DataSet GetDataDevelopProcessForScheduleByPrdID(int PrdID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[0].Value = PrdID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "tech.GetDataDevelopProcessForScheduleByPrdID", arParams);
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
        public bool DeleteDevelopProcess(ref string ErrorMsg, object DevelopProcessID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@DevelopProcessID", SqlDbType.BigInt);
            arParams[0].Value = DevelopProcessID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "tech.DeleteDevelopProcess", arParams);
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
        public DataSet GetDataDevelopProcessByPrdID(int PrdID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[0].Value = PrdID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "tech.GetDataDevelopProcessByPrdID", arParams);
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

        public bool InsertDevelopProcessForClone(ref string ErrorMsg, object SrcPrdID, object NewPrdID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@SrcPrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@NewPrdID", SqlDbType.Int);
            arParams[0].Value = SrcPrdID;
            arParams[1].Value = NewPrdID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "tech.InsertDevelopProcessForClone", arParams);
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
        public bool InsertDevelopProcess(ref string ErrorMsg, ref object DevelopProcessID, object PrdID, object SerialNo, object ProcessTypeID, object Memo, object DateTarget, object DateFinished, object FinishedRemark)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[8];
            arParams[0] = new SqlParameter("@DevelopProcessID", SqlDbType.BigInt);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@SerialNo", SqlDbType.Int);
            arParams[3] = new SqlParameter("@ProcessTypeID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[4].Size = -1;
            arParams[5] = new SqlParameter("@DateTarget", SqlDbType.DateTime);
            arParams[6] = new SqlParameter("@DateFinished", SqlDbType.DateTime);
            arParams[7] = new SqlParameter("@FinishedRemark", SqlDbType.VarChar);
            arParams[7].Size = -1;
            arParams[1].Value = PrdID;
            arParams[2].Value = SerialNo;
            arParams[3].Value = ProcessTypeID;
            arParams[4].Value = Memo;
            arParams[5].Value = DateTarget;
            arParams[6].Value = DateFinished;
            arParams[7].Value = FinishedRemark;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "tech.InsertDevelopProcess", arParams);
                DevelopProcessID = arParams[0].Value;
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
        public bool UpdateDevelopProcess(ref string ErrorMsg, object DevelopProcessID, object SerialNo, object ProcessTypeID, object Memo, object DateTarget, object DateFinished, object FinishedRemark)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[7];
            arParams[0] = new SqlParameter("@DevelopProcessID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@SerialNo", SqlDbType.Int);
            arParams[2] = new SqlParameter("@ProcessTypeID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[3].Size = -1;
            arParams[4] = new SqlParameter("@DateTarget", SqlDbType.DateTime);
            arParams[5] = new SqlParameter("@DateFinished", SqlDbType.DateTime);
            arParams[6] = new SqlParameter("@FinishedRemark", SqlDbType.VarChar);
            arParams[6].Size = -1;
            arParams[0].Value = DevelopProcessID;
            arParams[1].Value = SerialNo;
            arParams[2].Value = ProcessTypeID;
            arParams[3].Value = Memo;
            arParams[4].Value = DateTarget;
            arParams[5].Value = DateFinished;
            arParams[6].Value = FinishedRemark;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "tech.UpdateDevelopProcess", arParams);
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