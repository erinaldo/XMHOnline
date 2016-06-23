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
namespace JERPData.Packing
{
    /// <描述>
    /// 表[packing.BoxFormatColumn]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/11/29 15:12:53
    ///</时间>  
    public class BoxFormatColumn
    {
        private SqlConnection sqlConn;
        public BoxFormatColumn()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public bool DeleteBoxFormatColumn(ref string ErrorMsg, object FormatID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[0].Value = FormatID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "packing.DeleteBoxFormatColumn", arParams);
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
        public DataSet GetDataBoxFormatColumn()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "packing.GetDataBoxFormatColumn");
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
        public bool InsertBoxFormatColumn(ref string ErrorMsg, ref object FormatID, object BarcodeX, object BarcodeY, object CaptionX, object CaptionY, object CaptionWidth)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@BarcodeX", SqlDbType.Int);
            arParams[2] = new SqlParameter("@BarcodeY", SqlDbType.Int);
            arParams[3] = new SqlParameter("@CaptionX", SqlDbType.Int);
            arParams[4] = new SqlParameter("@CaptionY", SqlDbType.Int);
            arParams[5] = new SqlParameter("@CaptionWidth", SqlDbType.Int);
            arParams[0].Value = FormatID;
            arParams[1].Value = BarcodeX;
            arParams[2].Value = BarcodeY;
            arParams[3].Value = CaptionX;
            arParams[4].Value = CaptionY;
            arParams[5].Value = CaptionWidth;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "packing.InsertBoxFormatColumn", arParams);
                FormatID = arParams[0].Value;
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
        public bool UpdateBoxFormatColumn(ref string ErrorMsg, object FormatID, object BarcodeX, object BarcodeY, object CaptionX, object CaptionY, object CaptionWidth)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@FormatID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@BarcodeX", SqlDbType.Int);
            arParams[2] = new SqlParameter("@BarcodeY", SqlDbType.Int);
            arParams[3] = new SqlParameter("@CaptionX", SqlDbType.Int);
            arParams[4] = new SqlParameter("@CaptionY", SqlDbType.Int);
            arParams[5] = new SqlParameter("@CaptionWidth", SqlDbType.Int);
            arParams[0].Value = FormatID;
            arParams[1].Value = BarcodeX;
            arParams[2].Value = BarcodeY;
            arParams[3].Value = CaptionX;
            arParams[4].Value = CaptionY;
            arParams[5].Value = CaptionWidth;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "packing.UpdateBoxFormatColumn", arParams);
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