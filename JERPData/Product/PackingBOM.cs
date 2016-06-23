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
    /// 表[prd.PackingBOM]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/3/20 6:54:19
    ///</时间>  
    public class PackingBOM
    {
        private SqlConnection sqlConn;
        public PackingBOM()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }


        public bool DeletePackingBOM(ref string ErrorMsg, object ID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ID", SqlDbType.Int);
            arParams[0].Value = ID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.DeletePackingBOM", arParams);
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
        public DataSet GetDataPackingBOMStoreByPackingTypeID(int PackingTypeID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PackingTypeID", SqlDbType.Int);
            arParams[0].Value = PackingTypeID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataPackingBOMStoreByPackingTypeID", arParams);
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
        public DataSet GetDataPackingBOMByPackingTypeID(int PackingTypeID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PackingTypeID", SqlDbType.Int);
            arParams[0].Value = PackingTypeID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataPackingBOMByPackingTypeID", arParams);
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

        public DataSet GetDataPackingBOMForPackingRequire(int PackingTypeID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PackingTypeID", SqlDbType.Int);
            arParams[0].Value = PackingTypeID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataPackingBOMForPackingRequire", arParams);
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
        public bool InsertPackingBOM(ref string ErrorMsg, ref object ID, object PackingTypeID, object PrdID, object SourceTypeID, object PrdAssembly, object PackageAssembly, object RecycleFlag, object Position, object Memo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[9];
            arParams[0] = new SqlParameter("@ID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@PackingTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@SourceTypeID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@PrdAssembly", SqlDbType.Int);
            arParams[5] = new SqlParameter("@PackageAssembly", SqlDbType.Int);
            arParams[6] = new SqlParameter("@RecycleFlag", SqlDbType.Bit);
            arParams[7] = new SqlParameter("@Position", SqlDbType.VarChar);
            arParams[7].Size = 200;
            arParams[8] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[8].Size = 200;
            arParams[0].Value = ID;
            arParams[1].Value = PackingTypeID;
            arParams[2].Value = PrdID;
            arParams[3].Value = SourceTypeID;
            arParams[4].Value = PrdAssembly;
            arParams[5].Value = PackageAssembly;
            arParams[6].Value = RecycleFlag;
            arParams[7].Value = Position;
            arParams[8].Value = Memo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertPackingBOM", arParams);
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
        public bool UpdatePackingBOM(ref string ErrorMsg, object ID, object PrdID, object SourceTypeID, object PrdAssembly, object PackageAssembly, object RecycleFlag, object Position, object Memo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[8];
            arParams[0] = new SqlParameter("@ID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@SourceTypeID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@PrdAssembly", SqlDbType.Int);
            arParams[4] = new SqlParameter("@PackageAssembly", SqlDbType.Int);
            arParams[5] = new SqlParameter("@RecycleFlag", SqlDbType.Bit);
            arParams[6] = new SqlParameter("@Position", SqlDbType.VarChar);
            arParams[6].Size = 200;
            arParams[7] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[7].Size = 200;
            arParams[0].Value = ID;
            arParams[1].Value = PrdID;
            arParams[2].Value = SourceTypeID;
            arParams[3].Value = PrdAssembly;
            arParams[4].Value = PackageAssembly;
            arParams[5].Value = RecycleFlag;
            arParams[6].Value = Position;
            arParams[7].Value = Memo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdatePackingBOM", arParams);
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