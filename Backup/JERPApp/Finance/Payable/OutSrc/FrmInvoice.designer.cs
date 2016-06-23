namespace JERPApp.Finance.Payable.OutSrc
{
    partial class FrmInvoice
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageOutSrc = new System.Windows.Forms.TabPage();
            this.pageLossSupply = new System.Windows.Forms.TabPage();
            this.lnkRefreshAll = new System.Windows.Forms.LinkLabel();
            this.ctrlOutSrcInvoice = new JERPApp.Finance.Payable.OutSrc.CtrlOutSrcInvoice();
            this.ctrlOutSrcLossSupplyInvoice = new JERPApp.Finance.Payable.OutSrc.CtrlOutSrcLossSupplyInvoice();
            this.panel1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pageOutSrc.SuspendLayout();
            this.pageLossSupply.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkRefreshAll);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 38);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(384, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "委外发票";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pageOutSrc);
            this.tabMain.Controls.Add(this.pageLossSupply);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 38);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(791, 497);
            this.tabMain.TabIndex = 18;
            // 
            // pageOutSrc
            // 
            this.pageOutSrc.Controls.Add(this.ctrlOutSrcInvoice);
            this.pageOutSrc.Location = new System.Drawing.Point(4, 22);
            this.pageOutSrc.Name = "pageOutSrc";
            this.pageOutSrc.Padding = new System.Windows.Forms.Padding(3);
            this.pageOutSrc.Size = new System.Drawing.Size(783, 471);
            this.pageOutSrc.TabIndex = 0;
            this.pageOutSrc.Text = "加工发票";
            this.pageOutSrc.UseVisualStyleBackColor = true;
            // 
            // pageLossSupply
            // 
            this.pageLossSupply.Controls.Add(this.ctrlOutSrcLossSupplyInvoice);
            this.pageLossSupply.Location = new System.Drawing.Point(4, 22);
            this.pageLossSupply.Name = "pageLossSupply";
            this.pageLossSupply.Padding = new System.Windows.Forms.Padding(3);
            this.pageLossSupply.Size = new System.Drawing.Size(783, 471);
            this.pageLossSupply.TabIndex = 1;
            this.pageLossSupply.Text = "超发料发票";
            this.pageLossSupply.UseVisualStyleBackColor = true;
            // 
            // lnkRefreshAll
            // 
            this.lnkRefreshAll.AutoSize = true;
            this.lnkRefreshAll.Location = new System.Drawing.Point(3, 23);
            this.lnkRefreshAll.Name = "lnkRefreshAll";
            this.lnkRefreshAll.Size = new System.Drawing.Size(53, 12);
            this.lnkRefreshAll.TabIndex = 3;
            this.lnkRefreshAll.TabStop = true;
            this.lnkRefreshAll.Text = "全部刷新";
            // 
            // ctrlOutSrcInvoice
            // 
            this.ctrlOutSrcInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlOutSrcInvoice.Location = new System.Drawing.Point(3, 3);
            this.ctrlOutSrcInvoice.Name = "ctrlOutSrcInvoice";
            this.ctrlOutSrcInvoice.Size = new System.Drawing.Size(777, 465);
            this.ctrlOutSrcInvoice.TabIndex = 0;
            // 
            // ctrlOutSrcLossSupplyInvoice
            // 
            this.ctrlOutSrcLossSupplyInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlOutSrcLossSupplyInvoice.Location = new System.Drawing.Point(3, 3);
            this.ctrlOutSrcLossSupplyInvoice.Name = "ctrlOutSrcLossSupplyInvoice";
            this.ctrlOutSrcLossSupplyInvoice.Size = new System.Drawing.Size(777, 465);
            this.ctrlOutSrcLossSupplyInvoice.TabIndex = 0;
            // 
            // FrmInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 535);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmInvoice";
            this.Text = "FrmInvoice";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.pageOutSrc.ResumeLayout(false);
            this.pageLossSupply.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageOutSrc;
        private System.Windows.Forms.TabPage pageLossSupply;
        private System.Windows.Forms.LinkLabel lnkRefreshAll;
        private CtrlOutSrcInvoice ctrlOutSrcInvoice;
        private CtrlOutSrcLossSupplyInvoice ctrlOutSrcLossSupplyInvoice;
    }
}