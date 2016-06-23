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
namespace JERPData.Manufacture
{
    /// <描述>
    /// 表[manuf.BOMPlans]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/11/5 21:28:52
    ///</时间>  
    public class BOMPlans
    {
        private SqlConnection sqlConn;
        public BOMPlans()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public DataSet GetDataBOMPlansForManufScheduleBOM(long ManufPlanID, long ManufProcessID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ManufPlanID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[0].Value = ManufPlanID;
            arParams[1].Value = ManufProcessID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataBOMPlansForManufScheduleBOM", arParams);
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
        public DataSet GetDataBOMPlansByManufPlanID(long ManufPlanID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ManufPlanID", SqlDbType.BigInt);
            arParams[0].Value = ManufPlanID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataBOMPlansByManufPlanID", arParams);
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
        public DataSet GetDataBOMPlansAvailableManufQty(long ManufPlanID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ManufPlanID", SqlDbType.BigInt);
            arParams[0].Value = ManufPlanID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataBOMPlansAvailableManufQty", arParams);
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
        public bool GetParmBOMPlanAvailableManufQty(long ManufPlanID, ref decimal AvailableManufQty)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ManufPlanID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@AvailableManufQty", SqlDbType.Decimal);
            arParams[1].Precision = 18;
            arParams[1].Scale = 4;
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = ManufPlanID;
            arParams[1].Value = AvailableManufQty;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "manuf.GetParmBOMPlanAvailableManufQty", arParams);
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
        public bool GetParmBOMPlansManufProcessAvailableManufQty(long ManufPlanID, long ManufProcessID, ref decimal AvailableManufQty)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@ManufPlanID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[2] = new SqlParameter("@AvailableManufQty", SqlDbType.Decimal);
            arParams[2].Precision = 18;
            arParams[2].Scale = 4;
            arParams[2].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = ManufPlanID;
            arParams[1].Value = ManufProcessID;
            arParams[2].Value = AvailableManufQty;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "manuf.GetParmBOMPlansManufProcessAvailableManufQty", arParams);
                AvailableManufQty = (decimal)arParams[2].Value;
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
        public bool InsertBOMPlans(ref string ErrorMsg, object ManufPlanID, object ManufProcessID, object PrdID, object AssemblyQty, object LossRate, object SourceTypeID, object RequireQty, object StoreQty, object OutSrcStoreQty, object RoadStoreQty, object PlanQty)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[11];
            arParams[0] = new SqlParameter("@ManufPlanID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@ManufProcessID", SqlDbType.BigInt);
            arParams[2] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@AssemblyQty", SqlDbType.Decimal);
            arParams[3].Precision = 18;
            arParams[3].Scale = 4;
            arParams[4] = new SqlParameter("@LossRate", SqlDbType.Decimal);
            arParams[4].Precision = 18;
            arParams[4].Scale = 6;
            arParams[5] = new SqlParameter("@SourceTypeID", SqlDbType.Int);
            arParams[6] = new SqlParameter("@RequireQty", SqlDbType.Decimal);
            arParams[6].Precision = 18;
            arParams[6].Scale = 4;
            arParams[7] = new SqlParameter("@StoreQty", SqlDbType.Decimal);
            arParams[7].Precision = 18;
            arParams[7].Scale = 4;
            arParams[8] = new SqlParameter("@OutSrcStoreQty", SqlDbType.Decimal);
            arParams[8].Precision = 18;
            arParams[8].Scale = 4;
            arParams[9] = new SqlParameter("@RoadStoreQty", SqlDbType.Decimal);
            arParams[9].Precision = 18;
            arParams[9].Scale = 4;
            arParams[10] = new SqlParameter("@PlanQty", SqlDbType.Decimal);
            arParams[10].Precision = 18;
            arParams[10].Scale = 4;
            arParams[0].Value = ManufPlanID;
            arParams[1].Value = ManufProcessID;
            arParams[2].Value = PrdID;
            arParams[3].Value = AssemblyQty;
            arParams[4].Value = LossRate;
            arParams[5].Value = SourceTypeID;
            arParams[6].Value = RequireQty;
            arParams[7].Value = StoreQty;
            arParams[8].Value = OutSrcStoreQty;
            arParams[9].Value = RoadStoreQty;
            arParams[10].Value = PlanQty;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.InsertBOMPlans", arParams);
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