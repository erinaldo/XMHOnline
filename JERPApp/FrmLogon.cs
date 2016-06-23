using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
namespace JERPApp
{
    public partial class FrmLogon : Form
    {
        public FrmLogon()
        {
            InitializeComponent();
            this.accUsers = new JERPData.Frame.Users();            
            this.txtUserName.Focus();
            this.plLogon.Click += new EventHandler(plLogon_Click);
            this.pnlCancel .Click +=new EventHandler(pnlCancel_Click);
            this.KeyPress += new KeyPressEventHandler(FrmLogon_KeyPress);
            this.accBackupPath = new JERPData.Frame.BackupPath();
            this.Load += new EventHandler(FrmLogon_Load);
            this.txtUserName .KeyPress +=new KeyPressEventHandler(txtUserName_KeyPress);
            this.txtPassword .KeyPress +=new KeyPressEventHandler(txtPassword_KeyPress);
        }

        private bool UserRegisterFlag = true;
        private JERPData.Frame.BackupPath accBackupPath;
        Config.FrmUserRegister frmregist = null;
        void FrmLogon_Load(object sender, EventArgs e)
        {
          

            FrmStyle.LoadForm(this);
            if (JERPData.ServerParameter .ServerName .ToLower().IndexOf("local") > -1)
            {
                //个人版的也要给老子注册
                string sourcecode;
                FrmMsg.Show("正在验证中,请稍候....");
                this.UserRegisterFlag = Config.FrmUserRegister.IsPass(out sourcecode);
                FrmMsg.Hide();
                if (!this.UserRegisterFlag)
                {
                    if (frmregist == null)
                    {
                        frmregist = new Config.FrmUserRegister(sourcecode);
                        frmregist.AffterRegister += new JERPApp.Config.FrmUserRegister.AffterRisterDelegate(frmregist_AffterRegister);
                    }
                    frmregist.ShowDialog();
                }
            }
        }

        void frmregist_AffterRegister(bool flag)
        {
            this.UserRegisterFlag = flag;
        }

        void pnlCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void plLogon_Click(object sender, EventArgs e)
        {
            this.Logon();
        }
    
        void FrmLogon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
        private JERPData.Frame.Users accUsers;
        FrmMain frmMain;
        private void Logon()
        {
            if (!this.UserRegisterFlag) return; 
            this.lblInfo.Visible = true;
            this.lblInfo.Text = "系统验证登录中.....";
            Application.DoEvents();
            short userID;
            bool RegisterFlag, RemindFlag, CloseFlag;
            string passport = JERPBiz.Frame.Passport.GetPassport();
            this.accUsers.GetParmUsersLogon(this.txtUserName.Text,
                this.txtPassword.Text,
                passport,
                out userID,
                out RegisterFlag,
                out RemindFlag,
                out CloseFlag);
            if (!RegisterFlag)
            {
                Config.FrmServRegister  frm = new JERPApp.Config.FrmServRegister ();
                new FrmStyle(frm).SetPopFrmStyle(this);
                frm.ShowDialog();
                return;
            }
            DateTime dbdate = JERPData.ServerParameter.DatabaseTime;       
            if (CloseFlag)
            {
                MessageBox.Show("对不起，系统已过期，不能继续使用！", "系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (RemindFlag)
            {             
                MessageBox.Show("系统已过试用期，可能随时停用，请与供应商联系!", "系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (userID == -1)
            {
                MessageBox.Show("对不起，用户名或密码错误！", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtPassword.Text = string.Empty;
                this.txtUserName.Focus();
                this.txtUserName.SelectAll();
                this.lblInfo.Visible = false;
                return;
            }
            lblInfo.Text = "系统正在设置用户信息.....";
            Application.DoEvents();
            JERPBiz.Frame.UserBiz.UserID = userID;
            string errormsg = string.Empty;
            this.accUsers.UpdateUsersForOnline(ref errormsg, userID);
            lblInfo.Text = "正在连接文件系统...";
            JCommon.NetworkConnection.Connect(JERPData.ServerParameter.ERPFileFolder, "X:", "天衣ERP", "902157");
            lblInfo.Text = "系统正在加载主窗体.....";
            Application.DoEvents();
            if (frmMain == null)
            {
                frmMain = new FrmMain();
                frmMain.FormClosed += new FormClosedEventHandler(frmMain_FormClosed);
            }
            this.Visible = false;
            frmMain.Show();

        }
  
      
        void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            string errormsg = string.Empty;
            this.accUsers.UpdateUsersForOffline(ref errormsg, JERPBiz.Frame.UserBiz.UserID);
            //FrmMsg.Show("正在备份数据库...");
            //new JERPData.ServerParameter().PM_BackupDatabase(JERPData.ServerParameter.DbName);
            //FrmMsg.Hide();
           
            this.Close();
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }


        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.Logon();
            }
        }
        void pctCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void pctLogon_Click(object sender, EventArgs e)
        {
            this.Logon();
        }
       


      

    }
}