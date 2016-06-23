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
    /// 表[manuf.ManufPlans]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2016/3/2 22:08:06
    ///</时间>  
    public class ManufPlans
    {
        private SqlConnection sqlConn;
        public ManufPlans()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }


        public bool DeleteManufPlans(ref string ErrorMsg, object ManufPlanID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ManufPlanID", SqlDbType.BigInt);
            arParams[0].Value = ManufPlanID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.DeleteManufPlans", arParams);
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
        public DataSet GetDataManufPlansByManufPlanID(long ManufPlanID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ManufPlanID", SqlDbType.BigInt);
            arParams[0].Value = ManufPlanID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataManufPlansByManufPlanID", arParams);
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
        public DataSet GetDataManufPlansDescPagesFreeSearch(int PageIndex, int PageSize, ref int RecordCount, string WhereClause)
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
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "manuf.GetDataManufPlansDescPagesFreeSearch", arParams);
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
       
        public DataSet GetDataManufPlansNeedBOMPlan()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "manuf.GetDataManufPlansNeedBOMPlan");
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
        public DataSet GetDataManufPlansNonFinished()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "manuf.GetDataManufPlansNonFinished");
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
        public bool GetParmManufPlansBOMPlanRemindFlag(int PsnID, ref bool RemindFlag)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@RemindFlag", SqlDbType.Bit);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = PsnID;
            arParams[1].Value = RemindFlag;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "manuf.GetParmManufPlansBOMPlanRemindFlag", arParams);
                RemindFlag = (bool)arParams[1].Value;
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
        public bool GetParmManufPlansCreateRemindFlag(int PsnID, ref bool RemindFlag)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@PsnID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@RemindFlag", SqlDbType.Bit);
            arParams[1].Direction = ParameterDirection.InputOutput;
            arParams[0].Value = PsnID;
            arParams[1].Value = RemindFlag;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "manuf.GetParmManufPlansCreateRemindFlag", arParams);
                RemindFlag = (bool)arParams[1].Value;
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
        public bool InsertManufPlans(ref string ErrorMsg, object DateNote, object SaleOrderItemID, object CompanyID, object PrdID, object Quantity, object PrdStoreFlag, object MtrStoreFlag, object DateTarget, object Memo, object ManPlanFlag, object MakerPsnID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[11];
            arParams[0] = new SqlParameter("@DateNote", SqlDbType.DateTime);
            arParams[1] = new SqlParameter("@SaleOrderItemID", SqlDbType.BigInt);
            arParams[2] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[3] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[4] = new SqlParameter("@Quantity", SqlDbType.Decimal);
            arParams[4].Precision = 18;
            arParams[4].Scale = 4;
            arParams[5] = new SqlParameter("@PrdStoreFlag", SqlDbType.Bit);
            arParams[6] = new SqlParameter("@MtrStoreFlag", SqlDbType.Bit);
            arParams[7] = new SqlParameter("@DateTarget", SqlDbType.DateTime);
            arParams[8] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[8].Size = 200;
            arParams[9] = new SqlParameter("@ManPlanFlag", SqlDbType.Bit);
            arParams[10] = new SqlParameter("@MakerPsnID", SqlDbType.Int);
            arParams[0].Value = DateNote;
            arParams[1].Value = SaleOrderItemID;
            arParams[2].Value = CompanyID;
            arParams[3].Value = PrdID;
            arParams[4].Value = Quantity;
            arParams[5].Value = PrdStoreFlag;
            arParams[6].Value = MtrStoreFlag;
            arParams[7].Value = DateTarget;
            arParams[8].Value = Memo;
            arParams[9].Value = ManPlanFlag;
            arParams[10].Value = MakerPsnID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.InsertManufPlans", arParams);
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
        public bool UpdateManufPlans(ref string ErrorMsg, object ManufPlanID, object CompanyID, object Quantity, object DateTarget, object PrdStoreFlag, object MtrStoreFlag, object MakerPsnID, object Memo)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[8];
            arParams[0] = new SqlParameter("@ManufPlanID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@CompanyID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@Quantity", SqlDbType.Decimal);
            arParams[2].Precision = 18;
            arParams[2].Scale = 4;
            arParams[3] = new SqlParameter("@DateTarget", SqlDbType.DateTime);
            arParams[4] = new SqlParameter("@PrdStoreFlag", SqlDbType.Bit);
            arParams[5] = new SqlParameter("@MtrStoreFlag", SqlDbType.Bit);
            arParams[6] = new SqlParameter("@MakerPsnID", SqlDbType.Int);
            arParams[7] = new SqlParameter("@Memo", SqlDbType.VarChar);
            arParams[7].Size = 200;
            arParams[0].Value = ManufPlanID;
            arParams[1].Value = CompanyID;
            arParams[2].Value = Quantity;
            arParams[3].Value = DateTarget;
            arParams[4].Value = PrdStoreFlag;
            arParams[5].Value = MtrStoreFlag;
            arParams[6].Value = MakerPsnID;
            arParams[7].Value = Memo;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateManufPlans", arParams);
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
        public bool UpdateManufPlansForAdjustNonFinishedQty(ref string ErrorMsg, object ManufPlanID, object NonFinishedQty)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ManufPlanID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@NonFinishedQty", SqlDbType.Decimal);
            arParams[1].Precision = 18;
            arParams[1].Scale = 4;
            arParams[0].Value = ManufPlanID;
            arParams[1].Value = NonFinishedQty;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateManufPlansForAdjustNonFinishedQty", arParams);
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
        public bool UpdateManufPlansForBOMPlan(ref string ErrorMsg, object ManufPlanID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ManufPlanID", SqlDbType.BigInt);
            arParams[0].Value = ManufPlanID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateManufPlansForBOMPlan", arParams);
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
        public bool UpdateManufPlansForFinishedQty(ref string ErrorMsg, object ManufPlanID)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ManufPlanID", SqlDbType.BigInt);
            arParams[0].Value = ManufPlanID;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "manuf.UpdateManufPlansForFinishedQty", arParams);
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