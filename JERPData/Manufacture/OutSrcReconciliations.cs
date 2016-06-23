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
    /// 表[manuf.OutSrcReconciliations]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2013-9-3 0:02:03
    ///</时间>  
    public class OutSrcReconciliations
    {
        private SqlConnection sqlConn;
        public OutSrcReconciliations()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }



        public bool DeleteOutSrcReconciliations(ref string ErrorMsg, object ReconciliationID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ReconciliationID", SqlDbType.BigInt);
            arParams[0].Value = ReconciliationID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.DeleteOutSrcReconciliations", arParams);
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
        public DataSet GetDataOutSrcReconciliationsByReconciliationID(long ReconciliationID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ReconciliationID", SqlDbType.BigInt);
            arParams[0].Value = ReconciliationID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataOutSrcReconciliationsByReconciliationID", arParams);
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
        public DataSet GetDataOutSrcReconciliationsDescPagesSettleAMT(int PageIndex, int PageSize, ref int RecordCount)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@PageIndex", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PageSize", SqlDbType.Int);
            arParams[2] = new SqlParameter("@RecordCount", SqlDbType.Int);
            arParams[2].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = PageIndex;
            arParams[1].Value = PageSize;
            arParams[2].Value = RecordCount;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataOutSrcReconciliationsDescPagesSettleAMT", arParams);
                RecordCount = (int)arParams[2].Value;
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
        public DataSet GetDataOutSrcReconciliationsNonFinishedAMT()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "manuf.GetDataOutSrcReconciliationsNonFinishedAMT");
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

        public DataSet GetDataOutSrcReconciliationsNonSettleAMT()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "manuf.GetDataOutSrcReconciliationsNonSettleAMT");
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
        public DataSet GetDataOutSrcReconciliationsYearReport(int Year)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@Year", SqlDbType.Int);
            arParams[0].Value = Year;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataOutSrcReconciliationsYearReport", arParams);
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

        public DataSet GetDataOutSrcReconciliationsByOutSrcOrderNoteID(long OutSrcOrderNoteID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@OutSrcOrderNoteID", SqlDbType.BigInt);
            arParams[0].Value = OutSrcOrderNoteID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataOutSrcReconciliationsByOutSrcOrderNoteID", arParams);
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
        public DataSet GetDataOutSrcReconciliationsReceiptRpt(string WhereClause)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@WhereClause", SqlDbType.NVarChar);
            arParams[0].Size = -1;
            arParams[0].Value = WhereClause;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataOutSrcReconciliationsReceiptRpt", arParams);
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

        public bool GetParmOutSrcReconciliationsReconciliationIDByOutSrcOrderSerialNo(long OutSrcOrderNoteID, int OutSrcOrderSerialNo, ref long ReconciliationID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@OutSrcOrderNoteID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@OutSrcOrderSerialNo", SqlDbType.Int);
            arParams[2] = new SqlParameter("@ReconciliationID", SqlDbType.BigInt);
            arParams[2].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = OutSrcOrderNoteID;
            arParams[1].Value = OutSrcOrderSerialNo;
            arParams[2].Value = ReconciliationID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "manuf.GetParmOutSrcReconciliationsReconciliationIDByOutSrcOrderSerialNo", arParams);
                ReconciliationID = (long)arParams[2].Value;
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
        public bool InsertOutSrcReconciliations(ref string ErrorMsg, ref object ReconciliationID, object ReconciliationCode, object ReconciliationName, object Year, object Month, object DateNote, object CompanyID, object OutSrcOrderNoteID, object CashSettleFlag, object MoneyTypeID, object SettleTypeID, object DateSettle, object MakerPsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[13];
            arParams[0] = new SqlParameter("@ReconciliationID", SqlDbType.BigInt);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@ReconciliationCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@ReconciliationName", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@Year", SqlDbType.Int);
            arParams[4] = new SqlParameter("@Month", SqlDbType.Int);
            arParams[5] = new SqlParameter("@DateNote", SqlDbType.DateTime);
            arParams[6] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[7] = new SqlParameter("@OutSrcOrderNoteID", SqlDbType.BigInt);
            arParams[8] = new SqlParameter("@CashSettleFlag", SqlDbType.Bit);
            arParams[9] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[10] = new SqlParameter("@SettleTypeID", SqlDbType.Int);
            arParams[11] = new SqlParameter("@DateSettle", SqlDbType.DateTime);
            arParams[12] = new SqlParameter("@MakerPsnID", SqlDbType.Int);
            arParams[0].Value = ReconciliationID;
            arParams[1].Value = ReconciliationCode;
            arParams[2].Value = ReconciliationName;
            arParams[3].Value = Year;
            arParams[4].Value = Month;
            arParams[5].Value = DateNote;
            arParams[6].Value = CompanyID;
            arParams[7].Value = OutSrcOrderNoteID;
            arParams[8].Value = CashSettleFlag;
            arParams[9].Value = MoneyTypeID;
            arParams[10].Value = SettleTypeID;
            arParams[11].Value = DateSettle;
            arParams[12].Value = MakerPsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.InsertOutSrcReconciliations", arParams);
                ReconciliationID = arParams[0].Value;
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
        public bool UpdateOutSrcReconciliations(ref string ErrorMsg, object ReconciliationID, object ReconciliationCode, object ReconciliationName, object DateNote, object DateSettle, object MakerPsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@ReconciliationID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@ReconciliationCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@ReconciliationName", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@DateNote", SqlDbType.DateTime);
            arParams[4] = new SqlParameter("@DateSettle", SqlDbType.DateTime);
            arParams[5] = new SqlParameter("@MakerPsnID", SqlDbType.Int);
            arParams[0].Value = ReconciliationID;
            arParams[1].Value = ReconciliationCode;
            arParams[2].Value = ReconciliationName;
            arParams[3].Value = DateNote;
            arParams[4].Value = DateSettle;
            arParams[5].Value = MakerPsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateOutSrcReconciliations", arParams);
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
        public bool UpdateOutSrcReconciliationsForAMT(ref string ErrorMsg, object ReconciliationID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ReconciliationID", SqlDbType.BigInt);
            arParams[0].Value = ReconciliationID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateOutSrcReconciliationsForAMT", arParams);
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
        public bool UpdateOutSrcReconciliationsForAppendFinishedAMT(ref string ErrorMsg, object ReconciliationID, object AppendFinishedAMT)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ReconciliationID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@AppendFinishedAMT", SqlDbType.Money);
            arParams[0].Value = ReconciliationID;
            arParams[1].Value = AppendFinishedAMT;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateOutSrcReconciliationsForAppendFinishedAMT", arParams);
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