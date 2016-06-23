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

namespace JCEData.Hr
{
    /// <描述>
    /// 表[hr.Personnels]数据访问类
    ///</描述> 
    ///<作者> 
    /// 金优富
    ///</作者> 
    ///<时间> 
    /// 2011-1-27 16:14:35
    ///</时间>  
    public class Personnel
    {
        private SqlConnection sqlConn;
        public Personnel()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }
      
        public DataSet GetDataPersonnel()
        {
            DataSet ds = null;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, "hr.GetDataPersonnel");
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