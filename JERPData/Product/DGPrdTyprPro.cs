    /*
$Header$
$Author$
$Date$
$Revision$
*/
using System;
using System.Data ; 
using System.Data .SqlClient ;
using System.Text;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;
namespace JERPData.Product
{  
	/// <描述>
	/// 表[prd.DPPrdTypePro]数据访问类
	///</描述> 
	///<作者> 
	/// 金优富
	///</作者> 
	///<时间> 
	/// 2016/7/5 14:26:12
	///</时间>  
    public class DGPrdTyprPro
	{
		private SqlConnection sqlConn;
        public DGPrdTyprPro()
		{
			this.sqlConn=DBConnection.JSqlDBConn;
		}

        public DataSet GetDataDGProductProByPrdID(int PrdID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[0].Value = PrdID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataDGProductProByPrdID", arParams);
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



        public bool InsertDGProductPro(ref string ErrorMsg, ref object ID, object PrdID, object ProType1, 
            object ProType2, object ProType3, object ProType4, object ProType5, object ProType6, object ProType7, 
            object ProType8, object ProType9, object ProType10, object ProType11, object ProType12, object ProType13, 
            object ProType14, object ProType15)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[17];
            arParams[0] = new SqlParameter("@ID", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.InputOutput;
            arParams[1] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[2] = new SqlParameter("@ProType1", SqlDbType.Int);
            arParams[3] = new SqlParameter("@ProType2", SqlDbType.Int);
            arParams[4] = new SqlParameter("@ProType3", SqlDbType.Int);
            arParams[5] = new SqlParameter("@ProType4", SqlDbType.Int);
            arParams[6] = new SqlParameter("@ProType5", SqlDbType.Int);
            arParams[7] = new SqlParameter("@ProType6", SqlDbType.Int);
            arParams[8] = new SqlParameter("@ProType7", SqlDbType.Int);
            arParams[9] = new SqlParameter("@ProType8", SqlDbType.Int);
            arParams[10] = new SqlParameter("@ProType9", SqlDbType.Int);
            arParams[11] = new SqlParameter("@ProType10", SqlDbType.Int);
            arParams[12] = new SqlParameter("@ProType11", SqlDbType.Int);
            arParams[13] = new SqlParameter("@ProType12", SqlDbType.Int);
            arParams[14] = new SqlParameter("@ProType13", SqlDbType.Int);
            arParams[15] = new SqlParameter("@ProType14", SqlDbType.Int);
            arParams[16] = new SqlParameter("@ProType15", SqlDbType.Int);
            arParams[0].Value = ID;
            arParams[1].Value = PrdID;
            arParams[2].Value = ProType1;
            arParams[3].Value = ProType2;
            arParams[4].Value = ProType3;
            arParams[5].Value = ProType4;
            arParams[6].Value = ProType5;
            arParams[7].Value = ProType6;
            arParams[8].Value = ProType7;
            arParams[9].Value = ProType8;
            arParams[10].Value = ProType9;
            arParams[11].Value = ProType10;
            arParams[12].Value = ProType11;
            arParams[13].Value = ProType12;
            arParams[14].Value = ProType13;
            arParams[15].Value = ProType14;
            arParams[16].Value = ProType15;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.InsertDGProductPro", arParams);
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



        public bool UpdateDGProductPro(ref string ErrorMsg, object PrdID, object ProType1, object ProType2, object ProType3,
            object ProType4, object ProType5, object ProType6, object ProType7, object ProType8, object ProType9, object ProType10, 
            object ProType11, object ProType12, object ProType13, object ProType14, object ProType15)
        {
            bool flag = false;
            ErrorMsg = string.Empty;
            SqlParameter[] arParams = new SqlParameter[16];
            arParams[0] = new SqlParameter("@PrdID", SqlDbType.Int);
            arParams[1] = new SqlParameter("@ProType1", SqlDbType.Int);
            arParams[2] = new SqlParameter("@ProType2", SqlDbType.Int);
            arParams[3] = new SqlParameter("@ProType3", SqlDbType.Int);
            arParams[4] = new SqlParameter("@ProType4", SqlDbType.Int);
            arParams[5] = new SqlParameter("@ProType5", SqlDbType.Int);
            arParams[6] = new SqlParameter("@ProType6", SqlDbType.Int);
            arParams[7] = new SqlParameter("@ProType7", SqlDbType.Int);
            arParams[8] = new SqlParameter("@ProType8", SqlDbType.Int);
            arParams[9] = new SqlParameter("@ProType9", SqlDbType.Int);
            arParams[10] = new SqlParameter("@ProType10", SqlDbType.Int);
            arParams[11] = new SqlParameter("@ProType11", SqlDbType.Int);
            arParams[12] = new SqlParameter("@ProType12", SqlDbType.Int);
            arParams[13] = new SqlParameter("@ProType13", SqlDbType.Int);
            arParams[14] = new SqlParameter("@ProType14", SqlDbType.Int);
            arParams[15] = new SqlParameter("@ProType15", SqlDbType.Int);
            arParams[0].Value = PrdID;
            arParams[1].Value = ProType1;
            arParams[2].Value = ProType2;
            arParams[3].Value = ProType3;
            arParams[4].Value = ProType4;
            arParams[5].Value = ProType5;
            arParams[6].Value = ProType6;
            arParams[7].Value = ProType7;
            arParams[8].Value = ProType8;
            arParams[9].Value = ProType9;
            arParams[10].Value = ProType10;
            arParams[11].Value = ProType11;
            arParams[12].Value = ProType12;
            arParams[13].Value = ProType13;
            arParams[14].Value = ProType14;
            arParams[15].Value = ProType15;
            SqlTransaction DBTransaction = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                DBTransaction = this.sqlConn.BeginTransaction();
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.UpdateDGProductPro", arParams);
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

        public bool DeleteDGProductPro(ref string ErrorMsg, object PrdID)
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
                SqlHelper.ExecuteNonQuery(DBTransaction, CommandType.StoredProcedure, "prd.DeleteDGProductPro", arParams);
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

