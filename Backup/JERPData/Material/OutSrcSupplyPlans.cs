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
namespace JERPData.Material
{
    /// <描述>
    /// 表[mtr.OutSrcSupplyPlans]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/9/1 9:44:40
    ///</时间>  
    public class OutSrcSupplyPlans
    {
        private SqlConnection sqlConn;
        public OutSrcSupplyPlans()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }

        public DataSet GetDataOutSrcSupplyPlansByOutSrcSupplyPlanID(long OutSrcSupplyPlanID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@OutSrcSupplyPlanID", SqlDbType.BigInt);
            arParams[0].Value = OutSrcSupplyPlanID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "mtr.GetDataOutSrcSupplyPlansByOutSrcSupplyPlanID", arParams);
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
        public DataSet GetDataOutSrcSupplyPlansByNoteID(long NoteID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[0].Value = NoteID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "mtr.GetDataOutSrcSupplyPlansByNoteID", arParams);
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

        public bool InsertOutSrcSupplyPlans(ref string ErrorMsg, ref object OutSrcSupplyPlanID, object NoteID, object OutSrcOrderItemID, object Quantity)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@OutSrcSupplyPlanID", SqlDbType.BigInt);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@NoteID", SqlDbType.BigInt);
            arParams[2] = new SqlParameter("@OutSrcOrderItemID", SqlDbType.BigInt);
            arParams[3] = new SqlParameter("@Quantity", SqlDbType.Decimal);
            arParams[3].Precision = 18;
            arParams[3].Scale = 4;
            arParams[0].Value = OutSrcSupplyPlanID;
            arParams[1].Value = NoteID;
            arParams[2].Value = OutSrcOrderItemID;
            arParams[3].Value = Quantity;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.InsertOutSrcSupplyPlans", arParams);
                OutSrcSupplyPlanID = arParams[0].Value;
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