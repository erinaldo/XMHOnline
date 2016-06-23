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
    /// 表[mtr.OutSrcSupplyRequires]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2015/9/1 9:49:43
    ///</时间>  
    public class OutSrcSupplyRequires
    {
        private SqlConnection sqlConn;
        public OutSrcSupplyRequires()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }
        public DataSet GetDataOutSrcSupplyRequiresByOutSrcSupplyPlanID(long OutSrcSupplyPlanID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@OutSrcSupplyPlanID", SqlDbType.BigInt);
            arParams[0].Value = OutSrcSupplyPlanID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "mtr.GetDataOutSrcSupplyRequiresByOutSrcSupplyPlanID", arParams);
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
        public bool InsertOutSrcSupplyRequires(ref string ErrorMsg, object OutSrcSupplyPlanID, object PrdID, object AssemblyQty, object LossRate, object RequireQty)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@OutSrcSupplyPlanID", SqlDbType.BigInt);
            arParams[1] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@AssemblyQty", SqlDbType.Decimal);
            arParams[2].Precision = 18;
            arParams[2].Scale = 6;
            arParams[3] = new SqlParameter("@LossRate", SqlDbType.Decimal);
            arParams[3].Precision = 18;
            arParams[3].Scale = 6;
            arParams[4] = new SqlParameter("@RequireQty", SqlDbType.Decimal);
            arParams[4].Precision = 18;
            arParams[4].Scale = 4;
            arParams[0].Value = OutSrcSupplyPlanID;
            arParams[1].Value = PrdID;
            arParams[2].Value = AssemblyQty;
            arParams[3].Value = LossRate;
            arParams[4].Value = RequireQty;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "mtr.InsertOutSrcSupplyRequires", arParams);
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