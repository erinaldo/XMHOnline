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

namespace JCEData
{

    public class ServerParameter
    {
        private SqlConnection sqlConn;
        public ServerParameter()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }
        //public static string ServerName = "(local)";
        public static string ServerName = "192.168.1.88";
        public static string UserName = "sa";
        public static string Password = "902157";//902157
        public static string Customer = "Yongshengjie";
        public static string DbName = Customer + "Solution";
        public static DateTime DatabaseTime
        {
            get
            {
                DateTime dtnow = DateTime.Now;
                new ServerParameter().GetParmDatabaseNow(ref dtnow);
                return dtnow;
            }
        }
        public bool GetParmDatabaseNow(ref DateTime DatabaseNow)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@DatabaseNow", SqlDbType.DateTime);
            arParams[0].Direction = ParameterDirection.InputOutput;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "dbo.GetParmDatabaseNow", arParams);
                DatabaseNow = (DateTime)arParams[0].Value;
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

        public DataSet GetDataServerFolder(string ParentFolder)
        {
            DataSet ds = null;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ParentFolder", SqlDbType.VarChar);
            arParams[0].Size = 100;
            arParams[0].Value = ParentFolder;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                ds = SqlHelper.ExecuteDataset(sqlConn, CommandType.StoredProcedure, "dbo.GetDataServerFolder", arParams);
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
