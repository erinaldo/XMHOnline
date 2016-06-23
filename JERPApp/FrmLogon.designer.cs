namespace JERPApp
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
        /// <param name="disposing">如果应释放客供资源，为 true；否则为 false。</param>
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
        /// 使用代码变更器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogon));
            this.pnlCancel = new System.Windows.Forms.Panel();
            this.plLogon = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pnlCancel
            // 
            this.pnlCancel.BackColor = System.Drawing.Color.Transparent;
            this.pnlCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCancel.Location = new System.Drawing.Point(232, 5);
            this.pnlCancel.Name = "pnlCancel";
            this.pnlCancel.Size = new System.Drawing.Size(24, 20);
            this.pnlCancel.TabIndex = 12;
            // 
            // plLogon
            // 
            this.plLogon.BackColor = System.Drawing.Color.Transparent;
            this.plLogon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plLogon.Location = new System.Drawing.Point(38, 323);
            this.plLogon.Name = "plLogon";
            this.plLogon.Size = new System.Drawing.Size(207, 40);
            this.plLogon.TabIndex = 11;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("宋体", 9F);
            this.lblInfo.ForeColor = System.Drawing.Color.DarkGray;
            this.lblInfo.Location = new System.Drawing.Point(66, 227);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(101, 12);
            this.lblInfo.TabIndex = 10;
            this.lblInfo.Text = "系统登录中......";
            this.lblInfo.Visible = false;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("宋体", 13F);
            this.txtPassword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtPassword.Location = new System.Drawing.Point(82, 282);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(146, 20);
            this.txtPassword.TabIndex = 9;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserName.Font = new System.Drawing.Font("宋体", 13F);
            this.txtUserName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUserName.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtUserName.Location = new System.Drawing.Point(82, 253);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(146, 20);
            this.txtUserName.TabIndex = 8;
            // 
            // FrmLogon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = global::JERPApp.Properties.Resources.logonbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(273, 405);
            this.ControlBox = false;
            this.Controls.Add(this.pnlCancel);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.plLogon);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblInfo);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "天衣ERP";
            this.TransparencyKey = System.Drawing.Color.Gray;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel plLogon;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Panel pnlCancel;


    }
}