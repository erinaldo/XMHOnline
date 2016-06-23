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
namespace JERPData.Product
{
    /// <描述>
    /// 表[prd.SalePriceNotes]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2013-01-12 16:03:57
    ///</时间>  
    public class SalePriceNotes
    {
        private SqlConnection sqlConn;
        public SalePriceNotes()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public bool DeleteSalePriceNotes(ref string ErrorMsg, object NoteID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[0].Value = NoteID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.DeleteSalePriceNotes", arParams);
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
        public DataSet GetDataSalePriceNotesByNoteID(long NoteID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[0].Value = NoteID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataSalePriceNotesByNoteID", arParams);
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
        public bool GetParmSalePriceNotesLastElement(int CompanyID, ref int MoneyTypeID, ref int SettleTypeID, ref int PriceTypeID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[2] = new SqlParameter("@SettleTypeID", SqlDbType.Int);
            arParams[2].Direction = ParameterDirection.InputOutput;
            arParams[3] = new SqlParameter("@PriceTypeID", SqlDbType.Int);
            arParams[3].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = CompanyID;
            arParams[1].Value = MoneyTypeID;
            arParams[2].Value = SettleTypeID;
            arParams[3].Value = PriceTypeID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "prd.GetParmSalePriceNotesLastElement", arParams);
                MoneyTypeID = (int)arParams[1].Value;
                SettleTypeID = (int)arParams[2].Value;
                PriceTypeID = (int)arParams[3].Value;
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
        public DataSet GetDataSalePriceNotesDescPagesFreeSearch(int PageIndex, int PageSize, ref int RecordCount, string WhereClause)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@PageIndex", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PageSize", SqlDbType.Int);
            arParams[2] = new SqlParameter("@RecordCount", SqlDbType.Int);
            arParams[2].Direction = ParameterDirection.InputOutput;
            arParams[3] = new SqlParameter("@WhereClause", SqlDbType.NVarChar);
            arParams[3].Size = -1;
            arParams[0].Value = PageIndex;
            arParams[1].Value = PageSize;
            arParams[2].Value = RecordCount;
            arParams[3].Value = WhereClause;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataSalePriceNotesDescPagesFreeSearch", arParams);
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

        public DataSet GetDataSalePriceNotesLastElementByMakerPsnID(int MakerPsnID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@MakerPsnID", SqlDbType.Int);
            arParams[0].Value = MakerPsnID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataSalePriceNotesLastElementByMakerPsnID", arParams);
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
        public DataSet GetDataSalePriceNotesLastElement()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "prd.GetDataSalePriceNotesLastElement");
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
        public bool GetParmSalePriceNotesDefaultMemo(int CompanyID, ref string Memo)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[1].Size = -1;
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = CompanyID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "prd.GetParmSalePriceNotesDefaultMemo", arParams);
                Memo = (string)arParams[1].Value;
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

        public bool InsertSalePriceNotes(ref string ErrorMsg, ref object NoteID, object DateNote, object CompanyID, object MoneyTypeID, object SettleTypeID, object PriceTypeID, object MakerPsnID, object Memo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[8];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@DateNote", SqlDbType.DateTime);
            arParams[2] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@SettleTypeID", SqlDbType.Int);
            arParams[5] = new SqlParameter("@PriceTypeID", SqlDbType.Int);
            arParams[6] = new SqlParameter("@MakerPsnID", SqlDbType.Int);
            arParams[7] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[7].Size = -1;
            arParams[0].Value = NoteID;
            arParams[1].Value = DateNote;
            arParams[2].Value = CompanyID;
            arParams[3].Value = MoneyTypeID;
            arParams[4].Value = SettleTypeID;
            arParams[5].Value = PriceTypeID;
            arParams[6].Value = MakerPsnID;
            arParams[7].Value = Memo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertSalePriceNotes", arParams);
                NoteID = arParams[0].Value;
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
        public bool UpdateSalePriceNotes(ref string ErrorMsg, object NoteID, object DateNote, object CompanyID, object MoneyTypeID, object SettleTypeID, object PriceTypeID, object MakerPsnID, object Memo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[8];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@DateNote", SqlDbType.DateTime);
            arParams[2] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@MoneyTypeID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@SettleTypeID", SqlDbType.Int);
            arParams[5] = new SqlParameter("@PriceTypeID", SqlDbType.Int);
            arParams[6] = new SqlParameter("@MakerPsnID", SqlDbType.Int);
            arParams[7] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[7].Size = -1;
            arParams[0].Value = NoteID;
            arParams[1].Value = DateNote;
            arParams[2].Value = CompanyID;
            arParams[3].Value = MoneyTypeID;
            arParams[4].Value = SettleTypeID;
            arParams[5].Value = PriceTypeID;
            arParams[6].Value = MakerPsnID;
            arParams[7].Value = Memo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateSalePriceNotes", arParams);
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