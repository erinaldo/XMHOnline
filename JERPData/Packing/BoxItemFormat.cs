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
    /// 表[packing.BoxItemFormat]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/11/29 15:12:22
    ///</时间>  
    public class BoxItemFormat
    {
        private SqlConnection sqlConn;
        public BoxItemFormat()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public DataSet GetDataBoxItemFormat()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "packing.GetDataBoxItemFormat");
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

        public bool SaveBoxItemFormat(ref string ErrorMsg, object Width, object Height, object Margin, object Offset, object BarcodeName, object BarcodeVersion, object FontSize, object Repeat)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[8];
            arParams[0] = new SqlParameter("@Width", SqlDbType.VarChar);
            arParams[0].Size = 50;
            arParams[1] = new SqlParameter("@Height", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@Margin", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@Offset", SqlDbType.VarChar);
            arParams[3].Size = 50;
            arParams[4] = new SqlParameter("@BarcodeName", SqlDbType.VarChar);
            arParams[4].Size = 50;
            arParams[5] = new SqlParameter("@BarcodeVersion", SqlDbType.VarChar);
            arParams[5].Size = 50;
            arParams[6] = new SqlParameter("@FontSize", SqlDbType.Int);
            arParams[7] = new SqlParameter("@Repeat", SqlDbType.Int);
            arParams[0].Value = Width;
            arParams[1].Value = Height;
            arParams[2].Value = Margin;
            arParams[3].Value = Offset;
            arParams[4].Value = BarcodeName;
            arParams[5].Value = BarcodeVersion;
            arParams[6].Value = FontSize;
            arParams[7].Value = Repeat;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "packing.SaveBoxItemFormat", arParams);
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