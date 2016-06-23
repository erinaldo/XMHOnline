using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace JERPBiz.Frame
{
    public class UserBiz
    {
        private static short userID=-1;
        public static short UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
                JERPData.Frame.Users user = new JERPData.Frame.Users();
                DataSet dst=user.GetDataUsersByUserID(value);
                if (dst.Tables[0].Rows.Count > 0)
                {
                    DataRow drow = dst.Tables[0].Rows[0];                    
                    UserName = drow["UserName"].ToString ();
                    UserPassword = drow["UserPassword"].ToString();
                    PsnID = (int)drow["PsnID"]; 
                    PsnName = drow["PsnName"].ToString();
                }
                
                JERPData.Frame.Roles rols = new JERPData.Frame.Roles();
                dst = rols.GetDataRoleValuesByUserID(userID);
                DataTable dt = dst.Tables[0];
                StringBuilder sbRet = new StringBuilder();
                sbRet.Append('0', 3000);
                StringBuilder sb = null ;
                int maxfunctionID = 1;
                (new JERPData.Frame.Functions()).GetParmMaxFunctionID(ref maxfunctionID);
                for (int i = 0; i < maxfunctionID+1; i++)
                {
                    foreach (DataRow rw in dt.Rows)
                    {
                        sb = new StringBuilder(rw["RoleValue"].ToString());
                        sbRet[i] = sb[i];
                        if (sb[i] == '1')
                        {                           
                            break;
                        }
                    }
                }
                UserPermitCode = sbRet.ToString ();
            }
        }
        public static string UserName;
        public static string UserPassword;
        public static int PsnID;
        public static string PsnName;
        public static string UserPermitCode;
    }
}
