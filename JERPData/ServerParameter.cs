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
namespace JERPData
{

    public class ServerParameter
    {
        private SqlConnection sqlConn;
        public ServerParameter()
        {
            this.sqlConn = DBConnection.JSqlDBConn;
        }
        //public static string ServerName = "(local)";
        public static string ServerName = "192.168.1.88";//"(local)"
        public static string UserName = "sa";//jyfsoft
        public static string Password = "902157";//902157
        public static string Customer = "XMH";//Soongon,Vaco，Yongshengjie,s,ToMoon,Yongshengjie
        public static string DbName = Customer +"Solution";
        public static string ERPFileFolder = @"\\" + ServerName + @"\ERP文档";
        //public static string ERPFileFolder = @"E:\\ERP文档"; 
        public static string TempletFolder = ERPFileFolder + @"\"+Customer+@"Templet\";    
        public static  DateTime DatabaseTime
        {
            get
            {
           
                ServerParameter parm = new ServerParameter();
                DateTime datenow = DateTime.Now;
                parm.GetParmDatabaseNow(ref datenow);
                return datenow;
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

        public bool PM_BackupDatabase(string ServerName)
        {
            bool flag = false;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@ServerName", SqlDbType.VarChar);
            arParams[0].Size = 50;
            arParams[0].Value = ServerName;
            try
            {
                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open(); 
                SqlHelper.ExecuteNonQuery(this.sqlConn, CommandType.StoredProcedure, "dbo.PM_BackupDatabase", arParams);
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
    }
}
