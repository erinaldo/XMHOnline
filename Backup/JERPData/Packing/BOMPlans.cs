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
    /// 表[packing.BOMPlans]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/5/20 20:54:56
    ///</时间>  
    public class BOMPlans
    {
        private SqlConnection sqlConn;
        public BOMPlans()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }



        public DataSet GetDataBOMPlansAvailablePackingQty(long PackingPlanID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PackingPlanID", SqlDbType.BigInt);
            arParams[0].Value = PackingPlanID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "packing.GetDataBOMPlansAvailablePackingQty", arParams);
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
        public DataSet GetDataBOMPlansByPackingPlanID(long PackingPlanID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PackingPlanID", SqlDbType.BigInt);
            arParams[0].Value = PackingPlanID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "packing.GetDataBOMPlansByPackingPlanID", arParams);
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

        public bool GetParmBOMPlanAvailablePackingQty(long PackingPlanID, ref decimal AvailableManufQty)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PackingPlanID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@AvailableManufQty", SqlDbType.Decimal);
            arParams[1].Precision = 18;
            arParams[1].Scale = 4;
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = PackingPlanID;
            arParams[1].Value = AvailableManufQty;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "packing.GetParmBOMPlanAvailablePackingQty", arParams);
                AvailableManufQty = (decimal)arParams[1].Value;
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
        public bool InsertBOMPlans(ref string ErrorMsg, object PackingPlanID, object PrdID, object PrdAssembly, object PackageAssembly, object SourceTypeID, object RequireQty, object StoreQty, object RoadStoreQty, object PlanQty)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[9];
            arParams[0] = new SqlParameter("@PackingPlanID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@PrdAssembly", SqlDbType.Int);
            arParams[3] = new SqlParameter("@PackageAssembly", SqlDbType.Int);
            arParams[4] = new SqlParameter("@SourceTypeID", SqlDbType.Int);
            arParams[5] = new SqlParameter("@RequireQty", SqlDbType.Decimal);
            arParams[5].Precision = 18;
            arParams[5].Scale = 4;
            arParams[6] = new SqlParameter("@StoreQty", SqlDbType.Decimal);
            arParams[6].Precision = 18;
            arParams[6].Scale = 4;
            arParams[7] = new SqlParameter("@RoadStoreQty", SqlDbType.Decimal);
            arParams[7].Precision = 18;
            arParams[7].Scale = 4;
            arParams[8] = new SqlParameter("@PlanQty", SqlDbType.Decimal);
            arParams[8].Precision = 18;
            arParams[8].Scale = 4;
            arParams[0].Value = PackingPlanID;
            arParams[1].Value = PrdID;
            arParams[2].Value = PrdAssembly;
            arParams[3].Value = PackageAssembly;
            arParams[4].Value = SourceTypeID;
            arParams[5].Value = RequireQty;
            arParams[6].Value = StoreQty;
            arParams[7].Value = RoadStoreQty;
            arParams[8].Value = PlanQty;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "packing.InsertBOMPlans", arParams);
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