using System;
using System.Data ; 
using System.Data .SqlClient ;
using System.Text;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;

namespace JERPData.General
{
	///<时间> 
	/// 2016/6/29 18:47:55
	///</时间>  
	public class PrdProType
	{
		private SqlConnection sqlConn;
		public PrdProType()
		{
			this.sqlConn=DBConnection.JSqlDBConn;
		}

        public DataSet GetDataManuPrdTypeByManuPrdTypeNameAndParentID(string ManuPrdTypeName, int ParentID)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@ManuPrdTypeName", SqlDbType.VarChar);
            arParams[0].Size = 50;
            arParams[1] = new SqlParameter("@ParentID", SqlDbType.Int);
            arParams[0].Value = ManuPrdTypeName;
            arParams[1].Value = ParentID;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "prd.GetDataManuPrdTypeByManuPrdTypeNameAndParentID", arParams);
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

	}
    
}
