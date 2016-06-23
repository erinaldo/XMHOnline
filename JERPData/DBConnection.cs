using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace JERPData
{
    public class DBConnection
    {
        public static SqlConnection JSqlDBConn
        {
            get
            {
                return new SqlConnection("data source=" + ServerParameter.ServerName + ";initial catalog=" +ServerParameter . DbName + ";uid=" + ServerParameter.UserName + ";pwd=" + ServerParameter.Password + ";Connect Timeout=120;");
            }
        }
     
    }
    
}
