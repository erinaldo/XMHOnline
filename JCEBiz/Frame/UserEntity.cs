using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace JCEBiz.Frame
{
    public class UserEntity
    {
        private static short userID = -1;
        public static short UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
                JCEData.Frame.Users accUser = new JCEData.Frame.Users();
                DataTable  dtbl = accUser.GetDataUsersByUserID(value).Tables [0];
                if (dtbl.Rows.Count  > 0)
                {
                    DataRow drow = dtbl.Rows[0];
                    UserName = drow["UserName"].ToString();
                    UserPassword = drow["UserPassword"].ToString();
                    PsnID = (int)drow["PsnID"];
                    PsnName = drow["PsnName"].ToString();
                }

               
            }
        }
        public static string UserName;
        public static string UserPassword;
        public static int PsnID;
        public static string PsnName;
    }
}
