using System;
using System.Collections.Generic;
using System.Text;
using System.Data ;
using System.Data .SqlClient ;
namespace JCEData
{
    public class SqlHelper
    {
        public static DataSet ExecuteDataset(SqlConnection sqlconn , string sqls)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlconn; 
            cmd.CommandText = sqls;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }
        public static DataSet ExecuteDataset(SqlConnection sqlconn, CommandType cmdtype, string sqls, params  SqlParameter[] arParams)
        {
          
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlconn;
            cmd.CommandType = cmdtype;
            cmd.CommandText = sqls;
            foreach (SqlParameter prms in arParams)
            {
                cmd.Parameters.Add(prms);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }
        public static int ExecuteNonQuery(SqlConnection sqlconn, string sqls)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlconn; 
            cmd.CommandText = sqls; 
            return cmd.ExecuteNonQuery();
        }
        public static int ExecuteNonQuery(SqlConnection sqlconn, CommandType cmdtype, string sqls, params  SqlParameter[] arParams)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlconn;
            cmd.CommandType = cmdtype;
            cmd.CommandText = sqls;
            foreach (SqlParameter prms in arParams)
            {
                cmd.Parameters.Add(prms);
            }
            return cmd.ExecuteNonQuery();
        }
        public static int ExecuteNonQuery(SqlTransaction  transaction, CommandType cmdtype, string sqls, params  SqlParameter[] arParams)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Transaction  = transaction;
            cmd.CommandType = cmdtype;
            cmd.CommandText = sqls;
            cmd.Connection = transaction.Connection;
            foreach (SqlParameter prms in arParams)
            {
                cmd.Parameters.Add(prms);
            }
            return cmd.ExecuteNonQuery();
        }
    }
}
