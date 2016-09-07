using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;

namespace JERPData
{
     public class CommonTool
    {
         private SqlConnection sqlConn;
         private CommonTool()
        {
            //this.sqlConn = DBConnection.JSqlDBConn;
        }

         public static String[] getTableColumns(String tbName)
         {
             String[] ColNames = null;
             DataTable tb = GetColumnsDataSet(tbName).Tables[0];
             int cols = tb.Columns.Count;
             ColNames = new String[cols];
             for (int i = 0; i < cols; i++)
             {
                 ColNames[i] = tb.Columns[i].ColumnName;
             }
             return ColNames;
         }

         /*
          * 表前缀，
          * 表名
          * 列名
          * 
         */
         public static String getSelCol(String pre, String tbName, String[] ColNames)
         {
             StringBuilder strSel = new StringBuilder();
             foreach (String colName in ColNames)
             {
                 strSel.Append("," + pre + "." + colName + " as " + delModTbName(tbName) + colName);
                 // t1.tablename  as tablenamecolname
             }

             return strSel.ToString();
         }


         public static DataSet GetColumnsDataSet(String TableName)
         {
             DataSet ds = null;
             try
             {
                 if (DBConnection.JSqlDBConn.State == System.Data.ConnectionState.Closed) DBConnection.JSqlDBConn.Open();
                 String sql = " select * from " + TableName + " where 1=0 ";
                 ds = SqlHelper.ExecuteDataset(DBConnection.JSqlDBConn, CommandType.Text, sql);
             }
             catch//(SqlException ex)
             {
                 // ex.Message --这里作调试用
             }
             finally
             {
                 DBConnection.JSqlDBConn.Close();
             }
             return ds;
         }

         //表自定义字段的获取
         public static DataSet GetDefineColumns(string sql) {
             DataSet ds = null;
             try
             {
                 if (DBConnection.JSqlDBConn.State == System.Data.ConnectionState.Closed) DBConnection.JSqlDBConn.Open();
                 ds = SqlHelper.ExecuteDataset(DBConnection.JSqlDBConn, CommandType.Text, sql);
             }
             catch//(SqlException ex)
             {
                 // ex.Message --这里作调试用
             }
             finally
             {
                 DBConnection.JSqlDBConn.Close();
             }
             return ds;
         }

         //把prd.produce 变为 produce
         private static String delModTbName(String tbName){
             string Temp = string.Empty;
             if (tbName.IndexOf(".") > 0) {
                 Temp = tbName.Substring(tbName.IndexOf(".") + 1, tbName.Length - tbName.IndexOf(".") - 1);
             }
             return Temp;
         }

         //自定义查询
         public static DataSet GetDateSet(string sql)
         {
             DataSet ds = null;
             try
             {
                 if (DBConnection.JSqlDBConn.State == System.Data.ConnectionState.Closed) DBConnection.JSqlDBConn.Open();
                 ds = SqlHelper.ExecuteDataset(DBConnection.JSqlDBConn, CommandType.Text, sql);
             }
             catch//(SqlException ex)
             {
                 // ex.Message --这里作调试用
             }
             finally
             {
                 DBConnection.JSqlDBConn.Close();
             }
             return ds;
         }


      }
}
