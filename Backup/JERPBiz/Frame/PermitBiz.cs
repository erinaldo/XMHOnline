using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace JERPBiz.Frame
{
    public class PermitHelper
    {
        private static string RoleValue = string.Empty;
        public  static bool EnableFunction(int functionID)
        {
            if (RoleValue == string.Empty)
            {
                short  userID = UserBiz.UserID;
                string rolevalue = string.Empty ;
                RoleValue = UserBiz.UserPermitCode ;               
            }
            StringBuilder sbv = new StringBuilder(RoleValue);
            return (sbv[functionID - 1] == '1');

        }
        
    }
}
