
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
    /// 表[prd.Product]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2013-9-2 14:47:40
    ///</时间>  
    public class ManuProduct
    {
        private SqlConnection sqlConn;
        public ManuProduct()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }
        public bool DeleteProduct(ref string ErrorMsg, object PrdID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[0].Value = PrdID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.DeleteManuProduct", arParams);
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

        public DataSet GetDataProductByFreeSearch(string WhereClause)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@WhereClause", SqlDbType.VarChar);
            arParams[0].Size = -1;
            arParams[0].Value = WhereClause;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataManuProductByFreeSearch", arParams);
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

        public DataSet GetDataProduct()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "prd.GetDataManuProduct");
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
        public DataSet GetDataProductByPrdID(int PrdID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[0].Value = PrdID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataManuProductByPrdID", arParams);
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

        public bool GetParmProductMaxPrdCode(string PrdName, ref string PrdCode)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PrdName", SqlDbType.VarChar);
            arParams[0].Size = 100;
            arParams[1] = new SqlParameter("@PrdCode", SqlDbType.VarChar);
            arParams[1].Size = 100;
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = PrdName;
            arParams[1].Value = PrdCode;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "prd.GetParmManuProductMaxPrdCode", arParams);
                PrdCode = (string)arParams[1].Value;
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
      
        public DataSet GetDataProductByPrdTypeID(int PrdTypeID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PrdTypeID", SqlDbType.Int);
            arParams[0].Value = PrdTypeID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataManuProductByPrdTypeID", arParams);
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

        public DataSet GetDataProductByAssistantCode(string AssistantCode)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@AssistantCode", SqlDbType.VarChar);
            arParams[0].Size = 50;
            arParams[0].Value = AssistantCode;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataManuProductByAssistantCode", arParams);
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

  
        public DataSet GetDataProductPagesFreeSearch(int PageIndex, int PageSize, ref int RecordCount, string WhereClause)
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
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataManuProductPagesFreeSearch", arParams);
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
  
   
        //public DataSet GetDataProductForFinishedPrdByPrdTypeID(int PrdTypeID)
        //{
        //    DataSet ds = null;
        //    SqlParameter[] arParams = new SqlParameter[1];
        //    arParams[0] = new SqlParameter("@PrdTypeID", SqlDbType.Int);
        //    arParams[0].Value = PrdTypeID;
        //    try
        //    {
        //        if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
        //        ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataProductForFinishedPrdByPrdTypeID", arParams);
        //    }
        //    catch//(SqlException ex)
        //    {
        //        // ex.Message --这里作调试用
        //    }
        //    finally
        //    {
        //        this.sqlConn.Close();
        //    }
        //    return ds;
        //}
        //public DataSet GetDataProductForMaterialByPrdTypeID(int PrdTypeID)
        //{
        //    DataSet ds = null;
        //    SqlParameter[] arParams = new SqlParameter[1];
        //    arParams[0] = new SqlParameter("@PrdTypeID", SqlDbType.Int);
        //    arParams[0].Value = PrdTypeID;
        //    try
        //    {
        //        if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
        //        ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataProductForMaterialByPrdTypeID", arParams);
        //    }
        //    catch//(SqlException ex)
        //    {
        //        // ex.Message --这里作调试用
        //    }
        //    finally
        //    {
        //        this.sqlConn.Close();
        //    }
        //    return ds;
        //}
        //public DataSet GetDataProductForManufPrdByPrdTypeID(int PrdTypeID)
        //{
        //    DataSet ds = null;
        //    SqlParameter[] arParams = new SqlParameter[1];
        //    arParams[0] = new SqlParameter("@PrdTypeID", SqlDbType.Int);
        //    arParams[0].Value = PrdTypeID;
        //    try
        //    {
        //        if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
        //        ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataProductForManufPrdByPrdTypeID", arParams);
        //    }
        //    catch//(SqlException ex)
        //    {
        //        // ex.Message --这里作调试用
        //    }
        //    finally
        //    {
        //        this.sqlConn.Close();
        //    }
        //    return ds;
        //}
        //public DataSet GetDataProductForSemiPrd()
        //{
        //    DataSet ds = null;
        //    try
        //    {
        //        if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
        //        ds = SqlHelper.ExecuteDataset(sqlConn, "prd.GetDataProductForSemiPrd");
        //    }
        //    catch//(SqlException ex)
        //    {
        //        // ex.Message --这里作调试用
        //    }
        //    finally
        //    {
        //        this.sqlConn.Close();
        //    }
        //    return ds;
        //}

        //public DataSet GetDataProductForSetCostPrice()
        //{
        //    DataSet ds = null;
        //    try
        //    {
        //        if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
        //        ds = SqlHelper.ExecuteDataset(sqlConn, "prd.GetDataProductForSetCostPrice");
        //    }
        //    catch//(SqlException ex)
        //    {
        //        // ex.Message --这里作调试用
        //    }
        //    finally
        //    {
        //        this.sqlConn.Close();
        //    }
        //    return ds;
        //}

        //public DataSet GetDataProductReferedFromManuf(int PrdID)
        //{
        //    DataSet ds = null;
        //    SqlParameter[] arParams = new SqlParameter[1];
        //    arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
        //    arParams[0].Value = PrdID;
        //    try
        //    {
        //        if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
        //        ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataProductReferedFromManuf", arParams);
        //    }
        //    catch//(SqlException ex)
        //    {
        //        // ex.Message --这里作调试用
        //    }
        //    finally
        //    {
        //        this.sqlConn.Close();
        //    }
        //    return ds;
        //}
        //public DataSet GetDataProductReferedFromPacking(int PrdID)
        //{
        //    DataSet ds = null;
        //    SqlParameter[] arParams = new SqlParameter[1];
        //    arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
        //    arParams[0].Value = PrdID;
        //    try
        //    {
        //        if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
        //        ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataProductReferedFromPacking", arParams);
        //    }
        //    catch//(SqlException ex)
        //    {
        //        // ex.Message --这里作调试用
        //    }
        //    finally
        //    {
        //        this.sqlConn.Close();
        //    }
        //    return ds;
        //}
        //public DataSet GetDataProductReferedFromPrdSet(int PrdID)
        //{
        //    DataSet ds = null;
        //    SqlParameter[] arParams = new SqlParameter[1];
        //    arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
        //    arParams[0].Value = PrdID;
        //    try
        //    {
        //        if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
        //        ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataProductReferedFromPrdSet", arParams);
        //    }
        //    catch//(SqlException ex)
        //    {
        //        // ex.Message --这里作调试用
        //    }
        //    finally
        //    {
        //        this.sqlConn.Close();
        //    }
        //    return ds;
        //}
        //public DataSet GetDataProductPrdSetByPrdTypeID(int PrdTypeID)
        //{
        //    DataSet ds = null;
        //    SqlParameter[] arParams = new SqlParameter[1];
        //    arParams[0] = new SqlParameter("@PrdTypeID", SqlDbType.Int);
        //    arParams[0].Value = PrdTypeID;
        //    try
        //    {
        //        if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
        //        ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataProductPrdSetByPrdTypeID", arParams);
        //    }
        //    catch//(SqlException ex)
        //    {
        //        // ex.Message --这里作调试用
        //    }
        //    finally
        //    {
        //        this.sqlConn.Close();
        //    }
        //    return ds;
        //}
        public bool GetParmProductAllowChildrenFlag(int ParentID, int ChildPrdID, ref bool AllowFlag)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@ParentID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@ChildPrdID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@AllowFlag", SqlDbType.Bit);
            arParams[2].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = ParentID;
            arParams[1].Value = ChildPrdID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "prd.GetParmProductAllowChildrenFlag", arParams);
                AllowFlag = (bool)arParams[2].Value;
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

        public bool GetParmProductPrdID(string PrdCode, ref int PrdID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PrdCode", SqlDbType.VarChar);
            arParams[0].Size = 100;
            arParams[1] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = PrdCode;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "prd.GetParmProductPrdID", arParams);
                PrdID = (int)arParams[1].Value;
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

        //public bool GetParmProductSupplier(int PrdID, ref string Supplier)
        //{
        //    bool flag = false;
        //    SqlParameter[] arParams = new SqlParameter[2];
        //    arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
        //    arParams[1] = new SqlParameter("@Supplier", SqlDbType.VarChar);
        //    arParams[1].Size = 200;
        //    arParams[1].Direction = ParameterDirection.InputOutput;
        //    arParams[0].Value = PrdID;
        //    arParams[1].Value = Supplier;
        //    try
        //    {
        //        if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
        //        SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "prd.GetParmProductSupplier", arParams);
        //        Supplier = (string)arParams[1].Value;
        //        flag = true;
        //    }
        //    catch//(SqlException ex)
        //    {
        //        flag = false;
        //    }
        //    finally
        //    {
        //        this.sqlConn.Close();
        //    }
        //    return flag;
        //}
        //public bool GetParmProductManufProcessAvailableManufQty(long ManufProcessID, ref decimal AvailableManufQty)
        //{
        //    bool flag = false;
        //    SqlParameter[] arParams = new SqlParameter[2];
        //    arParams[0] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
        //    arParams[1] = new SqlParameter("@AvailableManufQty", SqlDbType.Decimal);
        //    arParams[1].Precision = 18;
        //    arParams[1].Scale = 4;
        //    arParams[1].Direction = ParameterDirection.InputOutput;
        //    arParams[0].Value = ManufProcessID;
        //    arParams[1].Value = AvailableManufQty;
        //    try
        //    {
        //        if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
        //        SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "prd.GetParmProductManufProcessAvailableManufQty", arParams);
        //        AvailableManufQty = (decimal)arParams[1].Value;
        //        flag = true;
        //    }
        //    catch//(SqlException ex)
        //    {
        //        flag = false;
        //    }
        //    finally
        //    {
        //        this.sqlConn.Close();
        //    }
        //    return flag;
        //}

        //public bool GetParmProductAvailablePackingQty(int PackingTypeID, ref decimal AvailableManufQty)
        //{
        //    bool flag = false;
        //    SqlParameter[] arParams = new SqlParameter[2];
        //    arParams[0] = new SqlParameter("@PackingTypeID", SqlDbType.Int);
        //    arParams[1] = new SqlParameter("@AvailableManufQty", SqlDbType.Decimal);
        //    arParams[1].Precision = 18;
        //    arParams[1].Scale = 4;
        //    arParams[1].Direction = ParameterDirection.InputOutput;
        //    arParams[0].Value = PackingTypeID;
        //    arParams[1].Value = AvailableManufQty;
        //    try
        //    {
        //        if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
        //        SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "prd.GetParmProductAvailablePackingQty", arParams);
        //        AvailableManufQty = (decimal)arParams[1].Value;
        //        flag = true;
        //    }
        //    catch//(SqlException ex)
        //    {
        //        flag = false;
        //    }
        //    finally
        //    {
        //        this.sqlConn.Close();
        //    }
        //    return flag;
        //}
        //public bool GetParmProductPrdAvailableManufQty(int ParentID, ref decimal AvailableManufQty)
        //{
        //    bool flag = false;
        //    SqlParameter[] arParams = new SqlParameter[2];
        //    arParams[0] = new SqlParameter("@ParentID", SqlDbType.Int);
        //    arParams[1] = new SqlParameter("@AvailableManufQty", SqlDbType.Decimal);
        //    arParams[1].Precision = 18;
        //    arParams[1].Scale = 4;
        //    arParams[1].Direction = ParameterDirection.InputOutput;
        //    arParams[0].Value = ParentID;
        //    arParams[1].Value = AvailableManufQty;
        //    try
        //    {
        //        if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
        //        SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "prd.GetParmProductPrdAvailableManufQty", arParams);
        //        AvailableManufQty = (decimal)arParams[1].Value;
        //        flag = true;
        //    }
        //    catch//(SqlException ex)
        //    {
        //        flag = false;
        //    }
        //    finally
        //    {
        //        this.sqlConn.Close();
        //    }
        //    return flag;
        //}
        //public bool GetParmProductPrdIDFromOtherInfor(string PrdName, string PrdSpec, ref int PrdID)
        //{
        //    bool flag = false;
        //    SqlParameter[] arParams = new SqlParameter[3];
        //    arParams[0] = new SqlParameter("@PrdName", SqlDbType.VarChar);
        //    arParams[0].Size = 100;
        //    arParams[1] = new SqlParameter("@PrdSpec", SqlDbType.VarChar);
        //    arParams[1].Size = 200;
        //    arParams[2] = new SqlParameter("@PrdID", SqlDbType.Int);
        //    arParams[2].Direction = ParameterDirection.InputOutput;
        //    arParams[0].Value = PrdName;
        //    arParams[1].Value = PrdSpec;
        //    arParams[2].Value = PrdID;
        //    try
        //    {
        //        if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
        //        SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "prd.GetParmProductPrdIDFromOtherInfor", arParams);
        //        PrdID = (int)arParams[2].Value;
        //        flag = true;
        //    }
        //    catch//(SqlException ex)
        //    {
        //        flag = false;
        //    }
        //    finally
        //    {
        //        this.sqlConn.Close();
        //    }
        //    return flag;
        //}

        //public bool GetParmProductPrdSetFlag(int PrdID, ref bool PrdSetFlag)
        //{
        //    bool flag = false;
        //    SqlParameter[] arParams = new SqlParameter[2];
        //    arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
        //    arParams[1] = new SqlParameter("@PrdSetFlag", SqlDbType.Bit);
        //    arParams[1].Direction = ParameterDirection.InputOutput;
        //    arParams[0].Value = PrdID;
        //    arParams[1].Value = PrdSetFlag;
        //    try
        //    {
        //        if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
        //        SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "prd.GetParmProductPrdSetFlag", arParams);
        //        PrdSetFlag = (bool)arParams[1].Value;
        //        flag = true;
        //    }
        //    catch//(SqlException ex)
        //    {
        //        flag = false;
        //    }
        //    finally
        //    {
        //        this.sqlConn.Close();
        //    }
        //    return flag;
        //}
        //public DataSet GetDataProductNonDevelopSchedule()
        //{
        //    DataSet ds = null;
        //    try
        //    {
        //        if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
        //        ds = SqlHelper.ExecuteDataset(sqlConn, "prd.GetDataProductNonDevelopSchedule");
        //    }
        //    catch//(SqlException ex)
        //    {
        //        // ex.Message --这里作调试用
        //    }
        //    finally
        //    {
        //        this.sqlConn.Close();
        //    }
        //    return ds;
        //}
        //public DataSet GetDataProductForDevelopSchedule()
        //{
        //    DataSet ds = null;
        //    try
        //    {
        //        if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
        //        ds = SqlHelper.ExecuteDataset(sqlConn, "prd.GetDataProductForDevelopSchedule");
        //    }
        //    catch//(SqlException ex)
        //    {
        //        // ex.Message --这里作调试用
        //    }
        //    finally
        //    {
        //        this.sqlConn.Close();
        //    }
        //    return ds;
        //}
        //public bool GetParmProductManufDays(int PrdID, ref int ManufDays)
        //{
        //    bool flag = false;
        //    SqlParameter[] arParams = new SqlParameter[2];
        //    arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
        //    arParams[1] = new SqlParameter("@ManufDays", SqlDbType.Int);
        //    arParams[1].Direction = ParameterDirection.InputOutput;
        //    arParams[0].Value = PrdID;
        //    try
        //    {
        //        if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
        //        SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "prd.GetParmProductManufDays", arParams);
        //        ManufDays = (int)arParams[1].Value;
        //        flag = true;
        //    }
        //    catch//(SqlException ex)
        //    {
        //        flag = false;
        //    }
        //    finally
        //    {
        //        this.sqlConn.Close();
        //    }
        //    return flag;
        //}
        public bool GetParmProductParentFlag(int PrdID, ref bool ParentFlag)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@ParentFlag", SqlDbType.Bit);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = PrdID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "prd.GetParmProductParentFlag", arParams);
                ParentFlag = (bool)arParams[1].Value;
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

        public bool InsertProduct(ref string ErrorMsg, ref object PrdID, object PrdTypeID, object PrdCode, object PrdName, object PrdSpec, object Model, object Surface, object Manufacturer, object AssistantCode, object DWGNo, object TaxfreeFlag, object RohsFlag, object RohsRequireFlag, object ICSolution, object PrdWeight, object SaleFlag, object UnitID, object DateRegister, object FileCode, object RegisterPsn, object VersionCode, object VersionRecord, object MinPackingQty, object URL, object Memo, object StopFlag)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[26];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@PrdTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@PrdCode", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@PrdName", SqlDbType.VarChar);
            arParams[3].Size = 100;
            arParams[4] = new SqlParameter("@PrdSpec", SqlDbType.VarChar);
            arParams[4].Size = 300;
            arParams[5] = new SqlParameter("@Model", SqlDbType.VarChar);
            arParams[5].Size = 100;
            arParams[6] = new SqlParameter("@Surface", SqlDbType.VarChar);
            arParams[6].Size = 100;
            arParams[7] = new SqlParameter("@Manufacturer", SqlDbType.VarChar);
            arParams[7].Size = 100;
            arParams[8] = new SqlParameter("@AssistantCode", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@DWGNo", SqlDbType.VarChar);
            arParams[9].Size = 100;
            arParams[10] = new SqlParameter("@TaxfreeFlag", SqlDbType.Bit);
            arParams[11] = new SqlParameter("@RohsFlag", SqlDbType.Bit);
            arParams[12] = new SqlParameter("@RohsRequireFlag", SqlDbType.Bit);
            arParams[13] = new SqlParameter("@ICSolution", SqlDbType.VarChar);
            arParams[13].Size = 200;
            arParams[14] = new SqlParameter("@PrdWeight", SqlDbType.Decimal);
            arParams[14].Precision = 18;
            arParams[14].Scale = 6;
            arParams[15] = new SqlParameter("@SaleFlag", SqlDbType.Bit);
            arParams[16] = new SqlParameter("@UnitID", SqlDbType.Int);
            arParams[17] = new SqlParameter("@DateRegister", SqlDbType.DateTime);
            arParams[18] = new SqlParameter("@FileCode", SqlDbType.VarChar);
            arParams[18].Size = 50;
            arParams[19] = new SqlParameter("@RegisterPsn", SqlDbType.VarChar);
            arParams[19].Size = 50;
            arParams[20] = new SqlParameter("@VersionCode", SqlDbType.VarChar);
            arParams[20].Size = 50;
            arParams[21] = new SqlParameter("@VersionRecord", SqlDbType.VarChar);
            arParams[21].Size = -1;
            arParams[22] = new SqlParameter("@MinPackingQty", SqlDbType.Decimal);
            arParams[22].Precision = 18;
            arParams[22].Scale = 4;
            arParams[23] = new SqlParameter("@URL", SqlDbType.VarChar);
            arParams[23].Size = 500;
            arParams[24] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[24].Size = 500;
            arParams[25] = new SqlParameter("@StopFlag", SqlDbType.Bit);
            arParams[0].Value = PrdID;
            arParams[1].Value = PrdTypeID;
            arParams[2].Value = PrdCode;
            arParams[3].Value = PrdName;
            arParams[4].Value = PrdSpec;
            arParams[5].Value = Model;
            arParams[6].Value = Surface;
            arParams[7].Value = Manufacturer;
            arParams[8].Value = AssistantCode;
            arParams[9].Value = DWGNo;
            arParams[10].Value = TaxfreeFlag;
            arParams[11].Value = RohsFlag;
            arParams[12].Value = RohsRequireFlag;
            arParams[13].Value = ICSolution;
            arParams[14].Value = PrdWeight;
            arParams[15].Value = SaleFlag;
            arParams[16].Value = UnitID;
            arParams[17].Value = DateRegister;
            arParams[18].Value = FileCode;
            arParams[19].Value = RegisterPsn;
            arParams[20].Value = VersionCode;
            arParams[21].Value = VersionRecord;
            arParams[22].Value = MinPackingQty;
            arParams[23].Value = URL;
            arParams[24].Value = Memo;
            arParams[25].Value = StopFlag;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertManuProduct", arParams);
                PrdID = arParams[0].Value;
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
        public bool InsertProductForImport(ref string ErrorMsg, ref object PrdID, object PrdTypeID, object PrdCode, object PrdName, object PrdSpec, object Model, object Surface, object Manufacturer, object AssistantCode, object DWGNo, object TaxfreeFlag, object RohsFlag, object RohsRequireFlag, object PrdWeight, object SaleFlag, object UnitID, object MinPackingQty, object URL, object Memo,object CustomFlag,object StopFlag)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[21];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@PrdTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@PrdCode", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@PrdName", SqlDbType.VarChar);
            arParams[3].Size = 100;
            arParams[4] = new SqlParameter("@PrdSpec", SqlDbType.VarChar);
            arParams[4].Size = 300;
            arParams[5] = new SqlParameter("@Model", SqlDbType.VarChar);
            arParams[5].Size = 100;
            arParams[6] = new SqlParameter("@Surface", SqlDbType.VarChar);
            arParams[6].Size = 100;
            arParams[7] = new SqlParameter("@Manufacturer", SqlDbType.VarChar);
            arParams[7].Size = 100;
            arParams[8] = new SqlParameter("@AssistantCode", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@DWGNo", SqlDbType.VarChar);
            arParams[9].Size = 100;
            arParams[10] = new SqlParameter("@TaxfreeFlag", SqlDbType.Bit);
            arParams[11] = new SqlParameter("@RohsFlag", SqlDbType.Bit);
            arParams[12] = new SqlParameter("@RohsRequireFlag", SqlDbType.Bit);
            arParams[13] = new SqlParameter("@PrdWeight", SqlDbType.Decimal);
            arParams[13].Precision = 18;
            arParams[13].Scale = 6;
            arParams[14] = new SqlParameter("@SaleFlag", SqlDbType.Bit);
            arParams[15] = new SqlParameter("@UnitID", SqlDbType.Int);
            arParams[16] = new SqlParameter("@MinPackingQty", SqlDbType.Decimal);
            arParams[16].Precision = 18;
            arParams[16].Scale = 4;
            arParams[17] = new SqlParameter("@URL", SqlDbType.VarChar);
            arParams[17].Size = 500;
            arParams[18] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[18].Size = 500;
            arParams[19] = new SqlParameter("@CustomFlag", SqlDbType.Bit);
            arParams[20] = new SqlParameter("@StopFlag", SqlDbType.Bit);

            arParams[0].Value = PrdID;
            arParams[1].Value = PrdTypeID;
            arParams[2].Value = PrdCode;
            arParams[3].Value = PrdName;
            arParams[4].Value = PrdSpec;
            arParams[5].Value = Model;
            arParams[6].Value = Surface;
            arParams[7].Value = Manufacturer;
            arParams[8].Value = AssistantCode;
            arParams[9].Value = DWGNo;
            arParams[10].Value = TaxfreeFlag;
            arParams[11].Value = RohsFlag;
            arParams[12].Value = RohsRequireFlag;
            arParams[13].Value = PrdWeight;
            arParams[14].Value = SaleFlag;
            arParams[15].Value = UnitID;
            arParams[16].Value = MinPackingQty;
            arParams[17].Value = URL;
            arParams[18].Value = Memo;
            arParams[19].Value =CustomFlag;
            arParams[20].Value = StopFlag;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertManuProductForImport", arParams);
                PrdID = arParams[0].Value;
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

        public bool UpdateProduct(ref string ErrorMsg, object PrdID, object PrdTypeID, object PrdCode, object PrdName, object PrdSpec, object Model, object Surface, object Manufacturer, object AssistantCode, object DWGNo, object TaxfreeFlag, object RohsFlag, object RohsRequireFlag, object ICSolution, object PrdWeight, object SaleFlag, object UnitID, object DateRegister, object FileCode, object RegisterPsn, object VersionCode, object VersionRecord, object MinPackingQty, object URL, object Memo, object CustomFlag, object StopFlag)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[27];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PrdTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@PrdCode", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@PrdName", SqlDbType.VarChar);
            arParams[3].Size = 100;
            arParams[4] = new SqlParameter("@PrdSpec", SqlDbType.VarChar);
            arParams[4].Size = 300;
            arParams[5] = new SqlParameter("@Model", SqlDbType.VarChar);
            arParams[5].Size = 100;
            arParams[6] = new SqlParameter("@Surface", SqlDbType.VarChar);
            arParams[6].Size = 100;
            arParams[7] = new SqlParameter("@Manufacturer", SqlDbType.VarChar);
            arParams[7].Size = 100;
            arParams[8] = new SqlParameter("@AssistantCode", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@DWGNo", SqlDbType.VarChar);
            arParams[9].Size = 100;
            arParams[10] = new SqlParameter("@TaxfreeFlag", SqlDbType.Bit);
            arParams[11] = new SqlParameter("@RohsFlag", SqlDbType.Bit);
            arParams[12] = new SqlParameter("@RohsRequireFlag", SqlDbType.Bit);
            arParams[13] = new SqlParameter("@ICSolution", SqlDbType.VarChar);
            arParams[13].Size = 200;
            arParams[14] = new SqlParameter("@PrdWeight", SqlDbType.Decimal);
            arParams[14].Precision = 18;
            arParams[14].Scale = 6;
            arParams[15] = new SqlParameter("@SaleFlag", SqlDbType.Bit);
            arParams[16] = new SqlParameter("@UnitID", SqlDbType.Int);
            arParams[17] = new SqlParameter("@DateRegister", SqlDbType.DateTime);
            arParams[18] = new SqlParameter("@FileCode", SqlDbType.VarChar);
            arParams[18].Size = 50;
            arParams[19] = new SqlParameter("@RegisterPsn", SqlDbType.VarChar);
            arParams[19].Size = 50;
            arParams[20] = new SqlParameter("@VersionCode", SqlDbType.VarChar);
            arParams[20].Size = 50;
            arParams[21] = new SqlParameter("@VersionRecord", SqlDbType.VarChar);
            arParams[21].Size = -1;
            arParams[22] = new SqlParameter("@MinPackingQty", SqlDbType.Decimal);
            arParams[22].Precision = 18;
            arParams[22].Scale = 4;
            arParams[23] = new SqlParameter("@URL", SqlDbType.VarChar);
            arParams[23].Size = 500;
            arParams[24] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[24].Size = 500;
            arParams[25] = new SqlParameter("@CustomFlag", SqlDbType.Bit);
            arParams[26] = new SqlParameter("@StopFlag", SqlDbType.Bit);
            arParams[0].Value = PrdID;
            arParams[1].Value = PrdTypeID;
            arParams[2].Value = PrdCode;
            arParams[3].Value = PrdName;
            arParams[4].Value = PrdSpec;
            arParams[5].Value = Model;
            arParams[6].Value = Surface;
            arParams[7].Value = Manufacturer;
            arParams[8].Value = AssistantCode;
            arParams[9].Value = DWGNo;
            arParams[10].Value = TaxfreeFlag;
            arParams[11].Value = RohsFlag;
            arParams[12].Value = RohsRequireFlag;
            arParams[13].Value = ICSolution;
            arParams[14].Value = PrdWeight;
            arParams[15].Value = SaleFlag;
            arParams[16].Value = UnitID;
            arParams[17].Value = DateRegister;
            arParams[18].Value = FileCode;
            arParams[19].Value = RegisterPsn;
            arParams[20].Value = VersionCode;
            arParams[21].Value = VersionRecord;
            arParams[22].Value = MinPackingQty;
            arParams[23].Value = URL;
            arParams[24].Value = Memo;
            arParams[25].Value = CustomFlag;
            arParams[26].Value = StopFlag;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateManuProduct", arParams);
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
        public bool UpdateProductForImport(ref string ErrorMsg, object PrdID, object PrdTypeID, object PrdCode, object PrdName, object PrdSpec, object Model, object Surface, object Manufacturer, object AssistantCode, object DWGNo, object TaxfreeFlag, object RohsFlag, object RohsRequireFlag, object PrdWeight, object SaleFlag, object UnitID, object MinPackingQty, object URL, object Memo,object CustomFlag, object StopFlag)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[21];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PrdTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@PrdCode", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@PrdName", SqlDbType.VarChar);
            arParams[3].Size = 100;
            arParams[4] = new SqlParameter("@PrdSpec", SqlDbType.VarChar);
            arParams[4].Size = 300;
            arParams[5] = new SqlParameter("@Model", SqlDbType.VarChar);
            arParams[5].Size = 100;
            arParams[6] = new SqlParameter("@Surface", SqlDbType.VarChar);
            arParams[6].Size = 100;
            arParams[7] = new SqlParameter("@Manufacturer", SqlDbType.VarChar);
            arParams[7].Size = 100;
            arParams[8] = new SqlParameter("@AssistantCode", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@DWGNo", SqlDbType.VarChar);
            arParams[9].Size = 100;
            arParams[10] = new SqlParameter("@TaxfreeFlag", SqlDbType.Bit);
            arParams[11] = new SqlParameter("@RohsFlag", SqlDbType.Bit);
            arParams[12] = new SqlParameter("@RohsRequireFlag", SqlDbType.Bit);
            arParams[13] = new SqlParameter("@PrdWeight", SqlDbType.Decimal);
            arParams[13].Precision = 18;
            arParams[13].Scale = 6;
            arParams[14] = new SqlParameter("@SaleFlag", SqlDbType.Bit);
            arParams[15] = new SqlParameter("@UnitID", SqlDbType.Int);
            arParams[16] = new SqlParameter("@MinPackingQty", SqlDbType.Decimal);
            arParams[16].Precision = 18;
            arParams[16].Scale = 4;
            arParams[17] = new SqlParameter("@URL", SqlDbType.VarChar);
            arParams[17].Size = 500;
            arParams[18] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[18].Size = 500;
            arParams[19] = new SqlParameter("@CustomFlag", SqlDbType.Bit);
            arParams[20] = new SqlParameter("@StopFlag", SqlDbType.Bit);
            arParams[0].Value = PrdID;
            arParams[1].Value = PrdTypeID;
            arParams[2].Value = PrdCode;
            arParams[3].Value = PrdName;
            arParams[4].Value = PrdSpec;
            arParams[5].Value = Model;
            arParams[6].Value = Surface;
            arParams[7].Value = Manufacturer;
            arParams[8].Value = AssistantCode;
            arParams[9].Value = DWGNo;
            arParams[10].Value = TaxfreeFlag;
            arParams[11].Value = RohsFlag;
            arParams[12].Value = RohsRequireFlag;
            arParams[13].Value = PrdWeight;
            arParams[14].Value = SaleFlag;
            arParams[15].Value = UnitID;
            arParams[16].Value = MinPackingQty;
            arParams[17].Value = URL;
            arParams[18].Value = Memo;
            arParams[19].Value = CustomFlag;
            arParams[20].Value = StopFlag;
            
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateManuProductForImport", arParams);
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
 

        public bool UpdateProductForAssistantCode(ref string ErrorMsg, object PrdID, object AssistantCode)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@AssistantCode", SqlDbType.VarChar);
            arParams[1].Size = 50;
            arParams[0].Value = PrdID;
            arParams[1].Value = AssistantCode;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateProductForAssistantCode", arParams);
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
 

        public bool InsertProductForPrdSet(ref string ErrorMsg, ref object PrdID, object PrdTypeID, object PrdCode, object PrdName, object PrdSpec, object Model, object AssistantCode, object UnitID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[8];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@PrdTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@PrdCode", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@PrdName", SqlDbType.VarChar);
            arParams[3].Size = 100;
            arParams[4] = new SqlParameter("@PrdSpec", SqlDbType.VarChar);
            arParams[4].Size = 200;
            arParams[5] = new SqlParameter("@Model", SqlDbType.VarChar);
            arParams[5].Size = 100;
            arParams[6] = new SqlParameter("@AssistantCode", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@UnitID", SqlDbType.Int);
            arParams[0].Value = PrdID;
            arParams[1].Value = PrdTypeID;
            arParams[2].Value = PrdCode;
            arParams[3].Value = PrdName;
            arParams[4].Value = PrdSpec;
            arParams[5].Value = Model;
            arParams[6].Value = AssistantCode;
            arParams[7].Value = UnitID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertManuProductForPrdSet", arParams);
                PrdID = arParams[0].Value;
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

        public bool UpdateProductForPrdSet(ref string ErrorMsg, object PrdID, object PrdTypeID, object PrdCode, object PrdName, object PrdSpec, object Model, object AssistantCode, object UnitID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[8];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PrdTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@PrdCode", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@PrdName", SqlDbType.VarChar);
            arParams[3].Size = 100;
            arParams[4] = new SqlParameter("@PrdSpec", SqlDbType.VarChar);
            arParams[4].Size = 200;
            arParams[5] = new SqlParameter("@Model", SqlDbType.VarChar);
            arParams[5].Size = 100;
            arParams[6] = new SqlParameter("@AssistantCode", SqlDbType.VarChar);
            arParams[6].Size = 50;
            arParams[7] = new SqlParameter("@UnitID", SqlDbType.Int);
            arParams[0].Value = PrdID;
            arParams[1].Value = PrdTypeID;
            arParams[2].Value = PrdCode;
            arParams[3].Value = PrdName;
            arParams[4].Value = PrdSpec;
            arParams[5].Value = Model;
            arParams[6].Value = AssistantCode;
            arParams[7].Value = UnitID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateManuProductForPrdSet", arParams);
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


        //增加的自定义属性的保存
        public DataSet GetTypePro()
        {
            DataSet ds = new DataSet();

            DataTable dt = new DataTable("ManuProductTypeProTable");

            String[] FieldNames = new String[] { "FieldName","Type" ,"FieldType" ,"FieldText","TypeParentID"};
            String[,] FieldValues = new String[,] {
            { "PrdID", "0", "int", "产品编码","" },
            { "ProType1", "0", "int", "刀杠类型","4" }, 
            { "ProType2", "1", "int", "刀片R角" ,"71"}, 
            { "ProType3", "1", "int", "刀片加工材质","72" }, 
            { "ProType4", "0", "int", "刀具尺寸","13" },
            { "ProType5", "0", "int","无","" }, 
            { "ProType6", "0", "int", "无" ,""},
            { "ProType7", "0", "int", "无" ,""} 
            };

            foreach(String fieldanme in FieldNames){
                dt.Columns.Add(fieldanme, typeof(string));
            }
            ds.Tables.Add(dt);
            
           for (int i = 0; i < FieldValues.GetLength(0) ;  i++) //行数
           {
               DataRow newRow = dt.NewRow();
               //String[] values = new String[FieldValues.GetLength(0)];
               for (int j = 0; j < FieldValues.GetLength(1) ;  j++) //列数
               {
                   newRow[j] = FieldValues[i, j];
               }

               dt.Rows.Add(newRow);
            }

            return ds;
        }
        public DataSet GetDataManuProductTypeProTable()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "prd.GetDataManuProductTypeProTable");
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


        public bool UpdateManuProductForPrdTypeID(ref string ErrorMsg, object PrdID, object PrdTypeID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PrdTypeID", SqlDbType.Int);
            arParams[0].Value = PrdID;
            arParams[1].Value = PrdTypeID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateManuProductForPrdTypeID", arParams);
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