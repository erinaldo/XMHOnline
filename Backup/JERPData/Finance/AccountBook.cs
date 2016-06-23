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
namespace JERPData.Finance
{  
	/// <描述>
	/// 表[finance.Bank]数据访问类
	///</描述> 
	///<作者> 
	/// 金优富
	///</作者> 
	///<时间> 
	/// 2015-02-12 18:58:29
	///</时间>  
	public class AccountBook
	{
		private SqlConnection sqlConn;
        public AccountBook()
		{
			this.sqlConn=DBConnection.JSqlDBConn;
		}
        public DataSet GetDataAccountBookBalance()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "finance.GetDataAccountBookBalance");
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