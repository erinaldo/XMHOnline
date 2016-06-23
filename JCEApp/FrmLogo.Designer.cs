namespace JCEApp
{
    partial class FrmLogon
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogon = new System.Windows.Forms.Button();
            this.lblInfor = new System.Windows.Forms.Label();
            this.ctrlUserID = new JCEApp.Define.Frame.CtrlUser();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.Text = "用户:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(64, 41);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(152, 23);
            this.txtPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.Text = "密码:";
            // 
            // btnLogon
            // 
            this.btnLogon.Location = new System.Drawing.Point(64, 70);
            this.btnLogon.Name = "btnLogon";
            this.btnLogon.Size = new System.Drawing.Size(72, 23);
            this.btnLogon.TabIndex = 5;
            this.btnLogon.Text = "登录";
            // 
            // lblInfor
            // 
            this.lblInfor.ForeColor = System.Drawing.Color.Red;
            this.lblInfor.Location = new System.Drawing.Point(143, 72);
            this.lblInfor.Name = "lblInfor";
            this.lblInfor.Size = new System.Drawing.Size(73, 20);
            this.lblInfor.Text = "登录中.....";
            // 
            // ctrlUserID
            // 
            this.ctrlUserID.Location = new System.Drawing.Point(64, 9);
            this.ctrlUserID.Name = "ctrlUserID";
            this.ctrlUserID.Size = new System.Drawing.Size(152, 23);
            this.ctrlUserID.TabIndex = 8;
            // 
            // FrmLogon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 103);
            this.Controls.Add(this.ctrlUserID);
            this.Controls.Add(this.lblInfor);
            this.Controls.Add(this.btnLogon);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(40, 175);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogon";
            this.Text = "天衣ERP";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogon;
        private System.Windows.Forms.Label lblInfor;
        private JCEApp.Define.Frame.CtrlUser ctrlUserID;


    }
}

