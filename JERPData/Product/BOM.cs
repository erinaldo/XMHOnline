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
    /// 表[prd.BOM]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2013-12-5 9:36:22
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.DeleteBOM", arParams);
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
     
        public bool DeleteBOMByParentID(ref string ErrorMsg, object ParentID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ParentID", SqlDbType.Int);
            arParams[0].Value = ParentID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.DeleteBOMByParentID", arParams);
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
        public DataSet GetDataBOMByChildPrdID(int ChildPrdID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ChildPrdID", SqlDbType.Int);
            arParams[0].Value = ChildPrdID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataBOMByChildPrdID", arParams);
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
        public DataSet GetDataBOMByParentID(int ParentID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ParentID", SqlDbType.Int);
            arParams[0].Value = ParentID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataBOMByParentID", arParams);
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
        public DataSet GetDataBOMManufTreeByPrdID(int PrdID, string Tag, string Prefix)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@Tag", SqlDbType.VarChar);
            arParams[1].Size = 10;
            arParams[2] = new SqlParameter("@Prefix", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[0].Value = PrdID;
            arParams[1].Value = Tag;
            arParams[2].Value = Prefix;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataBOMManufTreeByPrdID", arParams);
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
        public DataSet GetDataBOMTreeStoreByPrdID(int PrdID, string Tag, string Prefix)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@Tag", SqlDbType.VarChar);
            arParams[1].Size = 10;
            arParams[2] = new SqlParameter("@Prefix", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[0].Value = PrdID;
            arParams[1].Value = Tag;
            arParams[2].Value = Prefix;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataBOMTreeStoreByPrdID", arParams);
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

        public DataSet GetDataBOMForManufRequire(long ManufProcessID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[0].Value = ManufProcessID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataBOMForManufRequire", arParams);
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
        public DataSet GetDataBOMForOutStore(long ManufProcessID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[0].Value = ManufProcessID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataBOMForOutStore", arParams);
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
        public DataSet GetDataBOMStoreByParentID(int ParentID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ParentID", SqlDbType.Int);
            arParams[0].Value = ParentID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataBOMStoreByParentID", arParams);
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
        public DataSet GetDataBOMStoreByPrdTypeID(int PrdTypeID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PrdTypeID", SqlDbType.Int);
            arParams[0].Value = PrdTypeID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataBOMStoreByPrdTypeID", arParams);
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
        public DataSet GetDataBOMByManufProcessID(long ManufProcessID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[0].Value = ManufProcessID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataBOMByManufProcessID", arParams);
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
        public DataSet GetDataBOMForShare()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "prd.GetDataBOMForShare");
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

        public DataSet GetDataBOMPrdAvailableManufQty(int ParentID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ParentID", SqlDbType.Int);
            arParams[0].Value = ParentID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataBOMPrdAvailableManufQty", arParams);
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
        public DataSet GetDataBOMTreeByPrdID(int PrdID, string Tag, string Prefix)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@Tag", SqlDbType.VarChar);
            arParams[1].Size = 10;
            arParams[2] = new SqlParameter("@Prefix", SqlDbType.VarChar);
            arParams[2].Size = 50;
            arParams[0].Value = PrdID;
            arParams[1].Value = Tag;
            arParams[2].Value = Prefix;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataBOMTreeByPrdID", arParams);
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

        public bool GetParmBOMDefaultSourceTypeID(int PrdID, ref int SourceTypeID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@SourceTypeID", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = PrdID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "prd.GetParmBOMDefaultSourceTypeID", arParams);
                SourceTypeID = (int)arParams[1].Value;
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

        public bool InsertBOM(ref string ErrorMsg, ref object ID, object ParentID, object ManufProcessID, object PrdID, object AssemblyQty, object SourceTypeID, object Element, object Substitute, object Technology, object PostProcessing, object LossRate, object FixedFlag, object Memo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[13];
            arParams[0] = new SqlParameter("@ID", SqlDbType.BigInt);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@ParentID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[3] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@AssemblyQty", SqlDbType.Decimal);
            arParams[4].Precision = 18;
            arParams[4].Scale = 6;
            arParams[5] = new SqlParameter("@SourceTypeID", SqlDbType.Int);
            arParams[6] = new SqlParameter("@Element", SqlDbType.VarChar);
            arParams[6].Size = -1;
            arParams[7] = new SqlParameter("@Substitute", SqlDbType.VarChar);
            arParams[7].Size = 200;
            arParams[8] = new SqlParameter("@Technology", SqlDbType.VarChar);
            arParams[8].Size = 200;
            arParams[9] = new SqlParameter("@PostProcessing", SqlDbType.VarChar);
            arParams[9].Size = 200;
            arParams[10] = new SqlParameter("@LossRate", SqlDbType.Decimal);
            arParams[10].Precision = 18;
            arParams[10].Scale = 6;
            arParams[11] = new SqlParameter("@FixedFlag", SqlDbType.Bit);
            arParams[12] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[12].Size = 200;
            arParams[0].Value = ID;
            arParams[1].Value = ParentID;
            arParams[2].Value = ManufProcessID;
            arParams[3].Value = PrdID;
            arParams[4].Value = AssemblyQty;
            arParams[5].Value = SourceTypeID;
            arParams[6].Value = Element;
            arParams[7].Value = Substitute;
            arParams[8].Value = Technology;
            arParams[9].Value = PostProcessing;
            arParams[10].Value = LossRate;
            arParams[11].Value = FixedFlag;
            arParams[12].Value = Memo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertBOM", arParams);
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
        public bool InsertBOMForCopy(ref string ErrorMsg, object SrcPrdID, object NewPrdID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@SrcPrdID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@NewPrdID", SqlDbType.BigInt);
            arParams[0].Value = SrcPrdID;
            arParams[1].Value = NewPrdID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertBOMForCopy", arParams);
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
        public bool UpdateBOM(ref string ErrorMsg, object ID, object ManufProcessID, object PrdID, object AssemblyQty, object SourceTypeID, object Element, object Substitute, object Technology, object PostProcessing, object LossRate, object FixedFlag, object Memo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[12];
            arParams[0] = new SqlParameter("@ID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[2] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@AssemblyQty", SqlDbType.Decimal);
            arParams[3].Precision = 18;
            arParams[3].Scale = 6;
            arParams[4] = new SqlParameter("@SourceTypeID", SqlDbType.Int);
            arParams[5] = new SqlParameter("@Element", SqlDbType.VarChar);
            arParams[5].Size = -1;
            arParams[6] = new SqlParameter("@Substitute", SqlDbType.VarChar);
            arParams[6].Size = 200;
            arParams[7] = new SqlParameter("@Technology", SqlDbType.VarChar);
            arParams[7].Size = 200;
            arParams[8] = new SqlParameter("@PostProcessing", SqlDbType.VarChar);
            arParams[8].Size = 200;
            arParams[9] = new SqlParameter("@LossRate", SqlDbType.Decimal);
            arParams[9].Precision = 18;
            arParams[9].Scale = 6;
            arParams[10] = new SqlParameter("@FixedFlag", SqlDbType.Bit);
            arParams[11] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[11].Size = 200;
            arParams[0].Value = ID;
            arParams[1].Value = ManufProcessID;
            arParams[2].Value = PrdID;
            arParams[3].Value = AssemblyQty;
            arParams[4].Value = SourceTypeID;
            arParams[5].Value = Element;
            arParams[6].Value = Substitute;
            arParams[7].Value = Technology;
            arParams[8].Value = PostProcessing;
            arParams[9].Value = LossRate;
            arParams[10].Value = FixedFlag;
            arParams[11].Value = Memo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateBOM", arParams);
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