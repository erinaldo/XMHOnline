using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.Win32;
using System.Windows.Forms;
namespace JERPBiz.Config
{
    public class ConfigInfo
    {
        private static string NotePrinterKey = "NotePrinter";
        private static string BoxPrinterKey = "BoxPrinter";
        private static string BoxItemPrinterKey = "BoxItemPrinter";
        private static string ApplicationName = "深圳金优富软件";
        public static string GetNotePrinter()
        {
            object obj = GetRegistryValue(NotePrinterKey);            
            return (obj ==null)?string.Empty :obj .ToString ();
        }
       
        public static void SetNotePrinter(string NotePrinter)
        {
            SetRegistryValue(NotePrinterKey, NotePrinter);
        }
        public static bool GetNotePrintKeyFlag()
        {
            return GetRegisterKeyFlag(NotePrinterKey);

        }

      
        public static string GetBoxPrinter()
        {
            object obj = GetRegistryValue(BoxPrinterKey );
            return (obj == null) ? string.Empty : obj.ToString();
        }

        public static void SetBoxPrinter(string BoxPrinter)
        {
            SetRegistryValue(BoxPrinterKey, BoxPrinter);
        }
        public static bool GetBoxPrinterKeyFlag()
        {
            return GetRegisterKeyFlag(BoxPrinterKey);
        }
        public static string GetBoxItemPrinter()
        {
            object obj = GetRegistryValue(BoxItemPrinterKey);
            return (obj == null) ? string.Empty : obj.ToString();
        }

        public static void SetBoxItemPrinter(string BoxItemPrinter)
        {
            SetRegistryValue(BoxItemPrinterKey, BoxItemPrinter);
        }
        public static bool GetBoxItemPrinterKeyFlag()
        {
            return GetRegisterKeyFlag(BoxItemPrinterKey);
        }
        public static string GetStyleFont()
        {
            object obj = GetRegistryValue("StyleFont");
            return (obj == null) ? string.Empty : obj.ToString();
        }

        public static void SetStyleFont(string fontName)
        {
            SetRegistryValue("StyleFont", fontName);
        }
        public static bool GetStyleFontKeyFlag()
        {
            return GetRegisterKeyFlag("StyleFont");
        }
        public static bool GetRegisterKeyFlag(string KeyName)
        {

            try
            {
               
                RegistryKey rkey = Registry.LocalMachine;
                RegistryKey rkey1 = rkey.OpenSubKey(@"SOFTWARE\" + ApplicationName, true);
                if (rkey1 == null)
                {
                    rkey.Close();
                    return false;
                }
                bool flag = (rkey1.GetValue(KeyName, null) != null);                
                rkey1.Close();
                rkey.Close();
                return flag;
            }
            catch { return false; }
        }

        public  static object  GetRegistryValue(string KeyName)
        {
            try
            {
              
                RegistryKey rkey = Registry.LocalMachine;
                RegistryKey rkey1 = rkey.OpenSubKey(@"SOFTWARE\" + ApplicationName, true);
                if (rkey1 == null)
                {
                    rkey.Close();
                    return string.Empty;
                }
                object  keyvalue = rkey1.GetValue(KeyName);
                rkey1.Close();
                rkey.Close();
                return keyvalue;
            }
            catch { return null; }
         
        }
        public  static void SetRegistryValue(string KeyName,object KeyVal)
        {
           
            RegistryKey rkey = Registry.LocalMachine;
            RegistryKey rkey1 = rkey.OpenSubKey("SOFTWARE", true);
            RegistryKey rkey2=null;
            if(rkey1.OpenSubKey (ApplicationName,true)==null )
            {
                rkey1 .CreateSubKey (ApplicationName);
            }
            rkey2 = rkey1.OpenSubKey(ApplicationName, true);
            rkey2.SetValue(KeyName, KeyVal);
            rkey2.Close();
            rkey1.Close();
            rkey.Close();
        }
    }
    
}
