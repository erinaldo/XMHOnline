using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace JERPData.Product
{
    public class ManuPrdType
    {
        private SqlConnection sqlConn;
        public ManuPrdType()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }



        public bool DeletePrdType(ref string ErrorMsg, object PrdTypeID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ManuPrdTypeID", System.Data.SqlDbType.Int);
            arParams[0].Value = PrdTypeID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, System.Data.CommandType.StoredProcedure, "prd.DeleteManuPrdType", arParams);
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
        public DataSet GetDataPrdType()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "prd.GetDataManuPrdType");
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
        public bool GetParmPrdTypeTreePrdTypeName(int PrdTypeID, ref string PrdTypeName)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ManuPrdTypeID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@ManuPrdTypeName", SqlDbType.VarChar);
            arParams[1].Size = 500;
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = PrdTypeID;
            arParams[1].Value = PrdTypeName;
            try
            {
                //if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                //SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "prd.GetParmPrdTypeTreePrdTypeName", arParams);
                //PrdTypeName = (string)arParams[1].Value;
                //flag = true;
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
        public DataSet GetDataPrdTypeForFinishedPrd()
        {
            DataSet ds = null;
            try
            {
                //if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                //ds = SqlHelper.ExecuteDataset(sqlConn, "prd.GetDataPrdTypeForFinishedPrd");
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
        public DataSet GetDataPrdTypeForManufPrd()
        {
            DataSet ds = null;
            try
            {
                //if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                //ds = SqlHelper.ExecuteDataset(sqlConn, "prd.GetDataPrdTypeForManufPrd");
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
        public DataSet GetDataPrdTypeForMaterial()
        {
            DataSet ds = null;
            try
            {
                //if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                //ds = SqlHelper.ExecuteDataset(sqlConn, "prd.GetDataPrdTypeForMaterial");
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
        public DataSet GetDataPrdTypeByParentID(int ParentID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ParentID", SqlDbType.Int);
            arParams[0].Value = ParentID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataManuPrdTypeByParentID", arParams);
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
        public DataSet GetDataPrdTypeTree(int ParentID, string Tag, string Prefix)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@ParentID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@Tag", SqlDbType.VarChar);
            arParams[1].Size = 10;
            arParams[2] = new SqlParameter("@Prefix", SqlDbType.VarChar);
            arParams[2].Size = 200;
            arParams[0].Value = ParentID;
            arParams[1].Value = Tag;
            arParams[2].Value = Prefix;
            try
            {
                //if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                //ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataPrdTypeTree", arParams);
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
        public bool GetParmPrdTypeID(string PrdTypeName, ref int PrdTypeID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ManuPrdTypeName", SqlDbType.VarChar);
            arParams[0].Size = 50;
            arParams[1] = new SqlParameter("@ManuPrdTypeID", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = PrdTypeName;
            arParams[1].Value = PrdTypeID;
            try
            {
                //if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                //SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "prd.GetParmPrdTypeID", arParams);
                //PrdTypeID = (int)arParams[1].Value;
                //flag = true;
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
        public bool GetParmPrdTypeIsChildTree(int PrdTypeID, int ParentID, ref bool IsChildTreeFlag)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@ManuPrdTypeID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@Manu", SqlDbType.Int);
            arParams[2] = new SqlParameter("@IsChildTreeFlag", SqlDbType.Bit);
            arParams[2].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = PrdTypeID;
            arParams[1].Value = ParentID;
            arParams[2].Value = IsChildTreeFlag;
            try
            {
                //if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                //SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "prd.GetParmManuPrdTypeIsChildTree", arParams);
                //IsChildTreeFlag = (bool)arParams[2].Value;
                //flag = true;
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
        public bool InsertPrdType(ref string ErrorMsg, ref object ManuPrdTypeID, object ManuPrdTypeCode, object MabnuPrdTypeName, object ParentID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@ManuPrdTypeID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@ManuPrdTypeCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@ManuPrdTypeName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@ParentID", SqlDbType.Int);
            arParams[0].Value = ManuPrdTypeID;
            arParams[1].Value = ManuPrdTypeCode;
            arParams[2].Value = MabnuPrdTypeName;
            arParams[3].Value = ParentID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertManuPrdType", arParams);
                ManuPrdTypeID = arParams[0].Value;
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
        public bool UpdatePrdType(ref string ErrorMsg,object ManuPrdTypeID, object ManuPrdTypeCode, object ManuPrdTypeName, object ParentID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@ManuPrdTypeID", SqlDbType.Int);

            arParams[1] = new SqlParameter("@ManuPrdTypeCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[2] = new SqlParameter("@ManuPrdTypeName", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[3] = new SqlParameter("@ParentID", SqlDbType.Int);
            arParams[0].Value = ManuPrdTypeID;
            arParams[1].Value = ManuPrdTypeCode;
            arParams[2].Value = ManuPrdTypeName;
            arParams[3].Value = ParentID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateManuPrdType", arParams);
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
