using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace JERPApp.Config
{
    public partial class FrmUserRegister : Form
    {
        public FrmUserRegister(string source)
        {
            InitializeComponent();
            this.txtSource .Text = source;
            this.btnRegedit.Click += new EventHandler(btnRegedit_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
        }
        public delegate void AffterRisterDelegate(bool flag);
        private AffterRisterDelegate affterRegister;
        public event AffterRisterDelegate AffterRegister
        {
            add
            {
                affterRegister += value;
            }
            remove
            {
                affterRegister -= value;
            }
        }     
        public static  bool IsPass(out string source)
        {
          
            string passcode = JERPBiz.Config.ConfigInfo.GetRegistryValue("RegisterCode").ToString ();
            string strHash1 = string.Empty;
            String strHash = string.Empty;
            HardwareInfo hard = new HardwareInfo();
            StringBuilder sb = new StringBuilder();
            sb.Append(hard.GetCpuID());
            sb.Append(hard.GetHardDiskID());
            SHA1Managed sh1 = new SHA1Managed();
            UnicodeEncoding uEncode = new UnicodeEncoding();
            byte[] byt = uEncode.GetBytes(sb.ToString().ToUpper() + "TMD");
            byte[] hashbyt = sh1.ComputeHash(byt);
            strHash1 = Convert.ToBase64String(hashbyt);
            strHash1 = strHash1.Substring(0, 16).ToUpper();

            source = strHash1.Substring(0, 4)
            + "-" + strHash1.Substring(4, 4)
            + "-" + strHash1.Substring(8, 4)
            + "-" + strHash1.Substring(12, 4);
            if (passcode == string.Empty)
            {
                return false;
            }
            else
            {
                byte[] byt_ = uEncode.GetBytes(strHash1 + "金优富软件");
                byte[] hashbyt_ = sh1.ComputeHash(byt_);
                strHash = Convert.ToBase64String(hashbyt_);
                strHash = strHash.Substring(0, 16).ToUpper();
                string targetcode = strHash.Substring(0, 4) + "-" + strHash.Substring(4, 4) + "-" + strHash.Substring(8, 4) + "-" + strHash.Substring(12, 4);
                if (targetcode == passcode) return true;

            }
            return false;
        }    
        private void btnRegedit_Click(object sender, EventArgs e)
        {
            SHA1Managed sh1 = new SHA1Managed();
            UnicodeEncoding uEncode = new UnicodeEncoding();
            string strHash =string.Empty  ;
            string source = this.txtSource  .Text.ToUpper ();
            string[] strArr = source.Split('-');
            StringBuilder sb = new StringBuilder();
            foreach (string str in strArr)
            {
                sb.Append(str);
            }
            byte[] byt_ = uEncode.GetBytes(sb.ToString() + "金优富软件");
            byte[] hashbyt_ = sh1.ComputeHash(byt_);
            strHash = Convert.ToBase64String(hashbyt_);
            strHash = strHash.Substring(0, 16).ToUpper ();
            string targetcode = strHash.Substring(0, 4) + "-" + strHash.Substring (4, 4) + "-" + strHash.Substring(8, 4) + "-" + strHash.Substring(12, 4);
            if (targetcode == this.txtTarget.Text)
            {
                JERPBiz.Config.ConfigInfo.SetRegistryValue("RegisterCode", targetcode);
                MessageBox.Show("软件注册成功,请放心使用");
                if (this.affterRegister != null) this.affterRegister(true);
                this.Close();
            }
            else
            {
                MessageBox.Show("对不起，注册失败，使用盗版后果自负!");
            }
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.affterRegister != null) this.affterRegister(false);
            this.Close();
        }
    
    }
}