namespace JERPApp
{
    partial class FrmMsg
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
            this.lblMsg = new System.Windows.Forms.Label();
            this.proBar = new System.Windows.Forms.ProgressBar();
            this.bgwork = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.Font = new System.Drawing.Font("宋体", 9F);
            this.lblMsg.ForeColor = System.Drawing.Color.Blue;
            this.lblMsg.Location = new System.Drawing.Point(27, 5);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(29, 12);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "信息";
            this.lblMsg.UseWaitCursor = true;
            // 
            // proBar
            // 
            this.proBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.proBar.Location = new System.Drawing.Point(12, 21);
            this.proBar.Name = "proBar";
            this.proBar.Size = new System.Drawing.Size(270, 14);
            this.proBar.TabIndex = 3;
            this.proBar.UseWaitCursor = true;
            // 
            // bgwork
            // 
            this.bgwork.WorkerReportsProgress = true;
            this.bgwork.WorkerSupportsCancellation = true;
            this.bgwork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwork_DoWork);
            this.bgwork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwork_RunWorkerCompleted);
            this.bgwork.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwork_ProgressChanged);
            // 
            // FrmMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::JERPApp.Properties.Resources.loadingbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(294, 48);
            this.Controls.Add(this.proBar);
            this.Controls.Add(this.lblMsg);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMsg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.UseWaitCursor = true;
            this.VisibleChanged += new System.EventHandler(this.FrmMsg_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.ProgressBar proBar;
        private System.ComponentModel.BackgroundWorker bgwork;
    }
}