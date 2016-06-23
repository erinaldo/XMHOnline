using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Config
{
    public partial class FrmUnlock : Form
    {
        public FrmUnlock()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(FrmUnlock_FormClosing);
            this.Activate();
        }

        void FrmUnlock_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((this.txtUserName.Text ==JERPBiz.Frame.UserBiz.UserName)
               && (this.txtPassword.Text == JERPBiz.Frame.UserBiz.UserPassword))
            {
                e.Cancel = false;
            }
            else
            {
                MessageBox.Show("对不起，您的用户名及密码不正确，不能解锁");
                e.Cancel = true;
            }
        }

        private void bntUnlock_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.Close();
            }
        }
    }
}