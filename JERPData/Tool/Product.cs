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
namespace JERPData.Tool
{
    /// <描述>
    /// 表[tool.Product]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2014/5/3 15:28:38
    ///</时间>  
    public class Product
    {
        private SqlConnection sqlConn;
        public Product()
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "tool.DeleteProduct", arParams);
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
        public DataSet GetDataProduct()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "tool.GetDataProduct");
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
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "tool.GetDataProductByPrdID", arParams);
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
        public DataSet GetDataProductByPrdTypeID(int PrdTypeID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PrdTypeID", SqlDbType.Int);
            arParams[0].Value = PrdTypeID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "tool.GetDataProductByPrdTypeID", arParams);
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
        public DataSet GetDataProductForApplyRepair()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "tool.GetDataProductForApplyRepair");
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
        public DataSet GetDataProductForApplyUpgrade()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "tool.GetDataProductForApplyUpgrade");
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

        public DataSet GetDataProductForDie()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "tool.GetDataProductForDie");
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
        public bool GetParmProductPrdID(string PrdCode, ref int PrdID)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PrdCode", SqlDbType.VarChar);
            arParams[0].Size = 50;
            arParams[1] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = PrdCode;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "tool.GetParmProductPrdID", arParams);
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
        public bool InsertProduct(ref string ErrorMsg, ref object PrdID, object PrdTypeID, object PrdCode, object PrdName, object PrdSpec, object UnitID, object Manufacturer, object ContactInfor, object ResponsiblePsnName, object DateBatch, object PositionID, object MaxManufQty, object MaxRepairQty, object ManufQty, object RepairedQty, object RepairedCnt, object StopFlag)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[17];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@PrdTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@PrdCode", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@PrdName", SqlDbType.VarChar);
            arParams[3].Size = 100;
            arParams[4] = new SqlParameter("@PrdSpec", SqlDbType.VarChar);
            arParams[4].Size = 200;
            arParams[5] = new SqlParameter("@UnitID", SqlDbType.Int);
            arParams[6] = new SqlParameter("@Manufacturer", SqlDbType.VarChar);
            arParams[6].Size = 100;
            arParams[7] = new SqlParameter("@ContactInfor", SqlDbType.VarChar);
            arParams[7].Size = 100;
            arParams[8] = new SqlParameter("@ResponsiblePsnName", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@DateBatch", SqlDbType.DateTime);
            arParams[10] = new SqlParameter("@PositionID", SqlDbType.Int);
            arParams[11] = new SqlParameter("@MaxManufQty", SqlDbType.Decimal);
            arParams[11].Precision = 18;
            arParams[11].Scale = 4;
            arParams[12] = new SqlParameter("@MaxRepairQty", SqlDbType.Decimal);
            arParams[12].Precision = 18;
            arParams[12].Scale = 4;
            arParams[13] = new SqlParameter("@ManufQty", SqlDbType.Decimal);
            arParams[13].Precision = 18;
            arParams[13].Scale = 4;
            arParams[14] = new SqlParameter("@RepairedQty", SqlDbType.Decimal);
            arParams[14].Precision = 18;
            arParams[14].Scale = 4;
            arParams[15] = new SqlParameter("@RepairedCnt", SqlDbType.Int);
            arParams[16] = new SqlParameter("@StopFlag", SqlDbType.Bit);
            arParams[1].Value = PrdTypeID;
            arParams[2].Value = PrdCode;
            arParams[3].Value = PrdName;
            arParams[4].Value = PrdSpec;
            arParams[5].Value = UnitID;
            arParams[6].Value = Manufacturer;
            arParams[7].Value = ContactInfor;
            arParams[8].Value = ResponsiblePsnName;
            arParams[9].Value = DateBatch;
            arParams[10].Value = PositionID;
            arParams[11].Value = MaxManufQty;
            arParams[12].Value = MaxRepairQty;
            arParams[13].Value = ManufQty;
            arParams[14].Value = RepairedQty;
            arParams[15].Value = RepairedCnt;
            arParams[16].Value = StopFlag;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "tool.InsertProduct", arParams);
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
        public bool InsertProductForUpgrade(ref string ErrorMsg, object OldPrdID, object PrdCode)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@OldPrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PrdCode", SqlDbType.VarChar);
            arParams[1].Size = 100;
            arParams[0].Value = OldPrdID;
            arParams[1].Value = PrdCode;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "tool.InsertProductForUpgrade", arParams);
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

        public bool UpdateProduct(ref string ErrorMsg, object PrdID, object PrdTypeID, object PrdCode, object PrdName, object PrdSpec, object UnitID, object Manufacturer, object ContactInfor, object ResponsiblePsnName, object DateBatch, object PositionID, object MaxManufQty, object MaxRepairQty, object ManufQty, object RepairedQty, object RepairedCnt, object StopFlag)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[17];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@PrdTypeID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@PrdCode", SqlDbType.VarChar);
            arParams[2].Size = 100;
            arParams[3] = new SqlParameter("@PrdName", SqlDbType.VarChar);
            arParams[3].Size = 100;
            arParams[4] = new SqlParameter("@PrdSpec", SqlDbType.VarChar);
            arParams[4].Size = 200;
            arParams[5] = new SqlParameter("@UnitID", SqlDbType.Int);
            arParams[6] = new SqlParameter("@Manufacturer", SqlDbType.VarChar);
            arParams[6].Size = 100;
            arParams[7] = new SqlParameter("@ContactInfor", SqlDbType.VarChar);
            arParams[7].Size = 100;
            arParams[8] = new SqlParameter("@ResponsiblePsnName", SqlDbType.VarChar);
            arParams[8].Size = 50;
            arParams[9] = new SqlParameter("@DateBatch", SqlDbType.DateTime);
            arParams[10] = new SqlParameter("@PositionID", SqlDbType.Int);
            arParams[11] = new SqlParameter("@MaxManufQty", SqlDbType.Decimal);
            arParams[11].Precision = 18;
            arParams[11].Scale = 4;
            arParams[12] = new SqlParameter("@MaxRepairQty", SqlDbType.Decimal);
            arParams[12].Precision = 18;
            arParams[12].Scale = 4;
            arParams[13] = new SqlParameter("@ManufQty", SqlDbType.Decimal);
            arParams[13].Precision = 18;
            arParams[13].Scale = 4;
            arParams[14] = new SqlParameter("@RepairedQty", SqlDbType.Decimal);
            arParams[14].Precision = 18;
            arParams[14].Scale = 4;
            arParams[15] = new SqlParameter("@RepairedCnt", SqlDbType.Int);
            arParams[16] = new SqlParameter("@StopFlag", SqlDbType.Bit);
            arParams[0].Value = PrdID;
            arParams[1].Value = PrdTypeID;
            arParams[2].Value = PrdCode;
            arParams[3].Value = PrdName;
            arParams[4].Value = PrdSpec;
            arParams[5].Value = UnitID;
            arParams[6].Value = Manufacturer;
            arParams[7].Value = ContactInfor;
            arParams[8].Value = ResponsiblePsnName;
            arParams[9].Value = DateBatch;
            arParams[10].Value = PositionID;
            arParams[11].Value = MaxManufQty;
            arParams[12].Value = MaxRepairQty;
            arParams[13].Value = ManufQty;
            arParams[14].Value = RepairedQty;
            arParams[15].Value = RepairedCnt;
            arParams[16].Value = StopFlag;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "tool.UpdateProduct", arParams);
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
        public bool UpdateProductForAppendManufQty(ref string ErrorMsg, object PrdID, object ManufQty)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@ManufQty", SqlDbType.Decimal);
            arParams[1].Precision = 18;
            arParams[1].Scale = 4;
            arParams[0].Value = PrdID;
            arParams[1].Value = ManufQty;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "tool.UpdateProductForAppendManufQty", arParams);
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
        public bool UpdateProductForParm(ref string ErrorMsg, object PrdID, object DateBatch, object PositionID, object StatusID, object MaxManufQty, object MaxRepairQty, object ManufQty, object RepairedQty, object RepairedCnt)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[9];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@DateBatch", SqlDbType.DateTime);
            arParams[2] = new SqlParameter("@PositionID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@StatusID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@MaxManufQty", SqlDbType.Decimal);
            arParams[4].Precision = 18;
            arParams[4].Scale = 4;
            arParams[5] = new SqlParameter("@MaxRepairQty", SqlDbType.Decimal);
            arParams[5].Precision = 18;
            arParams[5].Scale = 4;
            arParams[6] = new SqlParameter("@ManufQty", SqlDbType.Decimal);
            arParams[6].Precision = 18;
            arParams[6].Scale = 4;
            arParams[7] = new SqlParameter("@RepairedQty", SqlDbType.Decimal);
            arParams[7].Precision = 18;
            arParams[7].Scale = 4;
            arParams[8] = new SqlParameter("@RepairedCnt", SqlDbType.Int);
            arParams[0].Value = PrdID;
            arParams[1].Value = DateBatch;
            arParams[2].Value = PositionID;
            arParams[3].Value = StatusID;
            arParams[4].Value = MaxManufQty;
            arParams[5].Value = MaxRepairQty;
            arParams[6].Value = ManufQty;
            arParams[7].Value = RepairedQty;
            arParams[8].Value = RepairedCnt;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "tool.UpdateProductForParm", arParams);
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
        public bool UpdateProductForRepair(ref string ErrorMsg, object PrdID)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "tool.UpdateProductForRepair", arParams);
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

        public bool UpdateProductForStatus(ref string ErrorMsg, object PrdID, object StatusID, object StatusSummary)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@StatusID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@StatusSummary", SqlDbType.VarChar);
            arParams[2].Size = 200;
            arParams[0].Value = PrdID;
            arParams[1].Value = StatusID;
            arParams[2].Value = StatusSummary;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "tool.UpdateProductForStatus", arParams);
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
        public bool UpdateProductForStop(ref string ErrorMsg, object PrdID)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "tool.UpdateProductForStop", arParams);
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


        public bool UpdateProductForFileCount(ref string ErrorMsg, object PrdID, object FileCount)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@FileCount", SqlDbType.Int);
            arParams[0].Value = PrdID;
            arParams[1].Value = FileCount;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "tool.UpdateProductForFileCount", arParams);
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
        public bool UpdateProductForImgCount(ref string ErrorMsg, object PrdID, object ImgCount)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@ImgCount", SqlDbType.Int);
            arParams[0].Value = PrdID;
            arParams[1].Value = ImgCount;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "tool.UpdateProductForImgCount", arParams);
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