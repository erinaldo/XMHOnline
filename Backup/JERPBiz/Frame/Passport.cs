using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Runtime.InteropServices;
namespace JERPBiz.Frame
{
    public class Passport
    {
        public static string GetPassport()
        {
            return GetMACByIP(JERPData.ServerParameter .ServerName  );
        }
        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, byte[] mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);

        /// <summary>
        /// 根据ip得到网卡mac地址
        /// </summary>
        /// <param name="ip">给出的ip地址</param>
        /// <returns>对应ip的网卡mac地址</returns>
        private static string GetMACByIP(string ip)
        {
            try
            {
                byte[] aa = new byte[6];

                Int32 ldest = inet_addr(ip); //目的地的ip
                Int32 len = 6;
                int res = SendARP(ldest, 0, aa, ref len);

                return BitConverter.ToString(aa, 0, 6); ;
            }
            catch (Exception err)
            {
                throw err;
            }


        }
    }
}
