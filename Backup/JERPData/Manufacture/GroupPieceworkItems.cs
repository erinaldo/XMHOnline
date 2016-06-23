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
    /// 表[manuf.GroupPieceworkItems]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015-01-18 15:53:35
    ///</时间>  
    public class GroupPieceworkItems
    {
        private SqlConnection sqlConn;
        public GroupPieceworkItems()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }
        public bool DeleteGroupPieceworkItems(ref string ErrorMsg, object PieceworkID, object PsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PieceworkID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[0].Value = PieceworkID;
            arParams[1].Value = PsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.DeleteGroupPieceworkItems", arParams);
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

        public DataSet GetDataGroupPieceworkItemsPersonnelByDateManuf(DateTime DateManuf)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@DateManuf", SqlDbType.DateTime);
            arParams[0].Value = DateManuf;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataGroupPieceworkItemsPersonnelByDateManuf", arParams);
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
        public DataSet GetDataGroupPieceworkItemsLaborWagePivotProcessType(DateTime DateBegin, DateTime DateEnd)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@DateBegin", SqlDbType.DateTime);
            arParams[1] = new SqlParameter("@DateEnd", SqlDbType.DateTime);
            arParams[0].Value = DateBegin;
            arParams[1].Value = DateEnd;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataGroupPieceworkItemsLaborWagePivotProcessType", arParams);
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

        public DataSet GetDataGroupPieceworkItemsPsnLaborWagePivotProcessType(int PsnID, DateTime DateBegin, DateTime DateEnd)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@DateBegin", SqlDbType.DateTime);
            arParams[2] = new SqlParameter("@DateEnd", SqlDbType.DateTime);
            arParams[0].Value = PsnID;
            arParams[1].Value = DateBegin;
            arParams[2].Value = DateEnd;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataGroupPieceworkItemsPsnLaborWagePivotProcessType", arParams);
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
        public bool SaveGroupPieceworkItems(ref string ErrorMsg, object PieceworkID, object PsnID, object PsnRate, object LaborWage)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@PieceworkID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@PsnRate", SqlDbType.Decimal);
            arParams[2].Precision = 18;
            arParams[2].Scale = 4;
            arParams[3] = new SqlParameter("@LaborWage", SqlDbType.Money);
            arParams[0].Value = PieceworkID;
            arParams[1].Value = PsnID;
            arParams[2].Value = PsnRate;
            arParams[3].Value = LaborWage;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.SaveGroupPieceworkItems", arParams);
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