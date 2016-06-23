namespace JERPApp.Supply.Material
{
    partial class FrmPurchaseSetting
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
            this.lnkRefreshAll = new System.Windows.Forms.LinkLabel();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageSupplier = new System.Windows.Forms.TabPage();
            this.pageBuyer = new System.Windows.Forms.TabPage();
            this.pagePurchaseSetting = new System.Windows.Forms.TabPage();
            this.ctrlSupplier = new JERPApp.Supply.Material.CtrlSupplierSetting();
            this.ctrlBuyer = new JERPApp.Supply.Material.CtrlBuyerSetting();
            this.ctrlPurchaseSetting = new JERPApp.Supply.Material.CtrlPurchaseSetting();
            this.panel1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pageSupplier.SuspendLayout();
            this.pageBuyer.SuspendLayout();
            this.pagePurchaseSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkRefreshAll);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 36);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(445, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "原料采购设置";
            // 
            // lnkRefreshAll
            // 
            this.lnkRefreshAll.AutoSize = true;
            this.lnkRefreshAll.Location = new System.Drawing.Point(4, 21);
            this.lnkRefreshAll.Name = "lnkRefreshAll";
            this.lnkRefreshAll.Size = new System.Drawing.Size(53, 12);
            this.lnkRefreshAll.TabIndex = 1;
            this.lnkRefreshAll.TabStop = true;
            this.lnkRefreshAll.Text = "全部刷新";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pageSupplier);
            this.tabMain.Controls.Add(this.pageBuyer);
            this.tabMain.Controls.Add(this.pagePurchaseSetting);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 36);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1024, 521);
            this.tabMain.TabIndex = 2;
            // 
            // pageSupplier
            // 
            this.pageSupplier.Controls.Add(this.ctrlSupplier);
            this.pageSupplier.Location = new System.Drawing.Point(4, 22);
            this.pageSupplier.Name = "pageSupplier";
            this.pageSupplier.Padding = new System.Windows.Forms.Padding(3);
            this.pageSupplier.Size = new System.Drawing.Size(1016, 495);
            this.pageSupplier.TabIndex = 0;
            this.pageSupplier.Text = "未设供应商";
            this.pageSupplier.UseVisualStyleBackColor = true;
            // 
            // pageBuyer
            // 
            this.pageBuyer.Controls.Add(this.ctrlBuyer);
            this.pageBuyer.Location = new System.Drawing.Point(4, 22);
            this.pageBuyer.Name = "pageBuyer";
            this.pageBuyer.Padding = new System.Windows.Forms.Padding(3);
            this.pageBuyer.Size = new System.Drawing.Size(1016, 495);
            this.pageBuyer.TabIndex = 1;
            this.pageBuyer.Text = "未设采购员";
            this.pageBuyer.UseVisualStyleBackColor = true;
            // 
            // pagePurchaseSetting
            // 
            this.pagePurchaseSetting.Controls.Add(this.ctrlPurchaseSetting);
            this.pagePurchaseSetting.Location = new System.Drawing.Point(4, 22);
            this.pagePurchaseSetting.Name = "pagePurchaseSetting";
            this.pagePurchaseSetting.Padding = new System.Windows.Forms.Padding(3);
            this.pagePurchaseSetting.Size = new System.Drawing.Size(1016, 495);
            this.pagePurchaseSetting.TabIndex = 2;
            this.pagePurchaseSetting.Text = "综合设定";
            this.pagePurchaseSetting.UseVisualStyleBackColor = true;
            // 
            // ctrlSupplier
            // 
            this.ctrlSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlSupplier.Location = new System.Drawing.Point(3, 3);
            this.ctrlSupplier.Name = "ctrlSupplier";
            this.ctrlSupplier.Size = new System.Drawing.Size(1010, 489);
            this.ctrlSupplier.TabIndex = 0;
            // 
            // ctrlBuyer
            // 
            this.ctrlBuyer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlBuyer.Location = new System.Drawing.Point(3, 3);
            this.ctrlBuyer.Name = "ctrlBuyer";
            this.ctrlBuyer.Size = new System.Drawing.Size(1010, 489);
            this.ctrlBuyer.TabIndex = 0;
            // 
            // ctrlPurchaseSetting
            // 
            this.ctrlPurchaseSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPurchaseSetting.Location = new System.Drawing.Point(3, 3);
            this.ctrlPurchaseSetting.Name = "ctrlPurchaseSetting";
            this.ctrlPurchaseSetting.Size = new System.Drawing.Size(1010, 489);
            this.ctrlPurchaseSetting.TabIndex = 0;
            // 
            // FrmPurchaseSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 557);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmPurchaseSetting";
            this.Text = "FrmPurchaseSetting";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.pageSupplier.ResumeLayout(false);
            this.pageBuyer.ResumeLayout(false);
            this.pagePurchaseSetting.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkRefreshAll;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageSupplier;
        private System.Windows.Forms.TabPage pageBuyer;
        private System.Windows.Forms.TabPage pagePurchaseSetting;
        private CtrlSupplierSetting ctrlSupplier;
        private CtrlBuyerSetting ctrlBuyer;
        private CtrlPurchaseSetting ctrlPurchaseSetting;
    }
}