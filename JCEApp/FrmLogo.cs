using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JCEApp
{
    public partial class FrmLogon : Form
    {
        public FrmLogon()
        {
            InitializeComponent();
            this.accUser = new JCEData.Frame.Users(); 
            this.txtPassword.KeyDown += new KeyEventHandler(txtPassword_KeyDown);
            this.lblInfor.Visible = false;
            this.btnLogon.Click += new EventHandler(btnLogon_Click);
            ControlStyle.SetStyle(this);
        }

       
        private JCEData.Frame.Users accUser;
        void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Logon();
            }
        }
      
        private void Logon()
        {
            this.lblInfor.Visible = true;
            Application.DoEvents();
            short UserID = -1;
            this.accUser.GetParmUsersLogon (this.ctrlUserID .UserName, this.txtPassword.Text, ref UserID);
            
            if (UserID == -1)
            {
                MessageBox.Show("对不起,登录失败,请检查您的输入");
                this.lblInfor.Visible = false;
                return;
            }
            JCEBiz.Frame.UserEntity.UserID = UserID;
            new JCEApp.NavMenu().ShowFirstFrm();
            this.Visible = false;
        }
        void btnLogon_Click(object sender, EventArgs e)
        {
            this.Logon();
        }

       
      
    }
}