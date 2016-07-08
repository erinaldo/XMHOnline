using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace JERPData.Product
{
    public class OtherProducePro
    {
        private SqlConnection sqlConn;
        public OtherProducePro()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }


        public DataSet GetDataOtherProductProByFType(int FType)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@FType", SqlDbType.Int);
            arParams[0].Value = FType;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataOtherProductProByFType", arParams);
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



        public bool InsertOtherProductPro(ref string ErrorMsg, ref object Fid, object FFieldName, object Fvisable, object FType, object FFieldType, object FFieldText, object FTypeSrcID, object FSrcTable)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[8];
            arParams[0] = new SqlParameter("@Fid", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@FFieldName", SqlDbType.VarChar);
            arParams[1].Size = 100;
            arParams[2] = new SqlParameter("@Fvisable", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@FType", SqlDbType.Int);
            arParams[4] = new SqlParameter("@FFieldType", SqlDbType.VarChar);
            arParams[4].Size = 100;
            arParams[5] = new SqlParameter("@FFieldText", SqlDbType.VarChar);
            arParams[5].Size = 100;
            arParams[6] = new SqlParameter("@FTypeSrcID", SqlDbType.VarChar);
            arParams[6].Size = 100;
            arParams[7] = new SqlParameter("@FSrcTable", SqlDbType.VarChar);
            arParams[7].Size = 100;
            arParams[0].Value = Fid;
            arParams[1].Value = FFieldName;
            arParams[2].Value = Fvisable;
            arParams[3].Value = FType;
            arParams[4].Value = FFieldType;
            arParams[5].Value = FFieldText;
            arParams[6].Value = FTypeSrcID;
            arParams[7].Value = FSrcTable;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertOtherProductPro", arParams);
                Fid = arParams[0].Value;
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

        public bool DeleteOtherProductPro(ref string ErrorMsg, object Fid)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@Fid", SqlDbType.Int);
            arParams[0].Value = Fid;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.DeleteOtherProductPro", arParams);
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
