namespace JERPApp.Finance.Receivable
{
    partial class FrmInvoiceConfirm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageSale = new System.Windows.Forms.TabPage();
            this.ctrlSaleInvoiceConfirm = new JERPApp.Finance.Receivable.CtrlSaleInvoiceConfirm();
            this.pageRepair = new System.Windows.Forms.TabPage();
            this.ctrlRepairInvoiceConfirm = new JERPApp.Finance.Receivable.CtrlRepairInvoiceConfirm();
            this.lnkRefreshAll = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pageSale.SuspendLayout();
            this.pageRepair.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkRefreshAll);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 38);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(379, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "发票审核";
            // 
            // cMenu
            // 
            this.cMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemRefresh});
            this.cMenu.Name = "cMenu";
            this.cMenu.Size = new System.Drawing.Size(101, 26);
            // 
            // mItemRefresh
            // 
            this.mItemRefresh.Name = "mItemRefresh";
            this.mItemRefresh.Size = new System.Drawing.Size(100, 22);
            this.mItemRefresh.Text = "刷新";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pageSale);
            this.tabMain.Controls.Add(this.pageRepair);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 38);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(806, 533);
            this.tabMain.TabIndex = 18;
            // 
            // pageSale
            // 
            this.pageSale.Controls.Add(this.ctrlSaleInvoiceConfirm);
            this.pageSale.Location = new System.Drawing.Point(4, 22);
            this.pageSale.Name = "pageSale";
            this.pageSale.Padding = new System.Windows.Forms.Padding(3);
            this.pageSale.Size = new System.Drawing.Size(798, 507);
            this.pageSale.TabIndex = 0;
            this.pageSale.Text = "销售发票";
            this.pageSale.UseVisualStyleBackColor = true;
            // 
            // ctrlSaleInvoiceConfirm
            // 
            this.ctrlSaleInvoiceConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlSaleInvoiceConfirm.Location = new System.Drawing.Point(3, 3);
            this.ctrlSaleInvoiceConfirm.Name = "ctrlSaleInvoiceConfirm";
            this.ctrlSaleInvoiceConfirm.Size = new System.Drawing.Size(792, 501);
            this.ctrlSaleInvoiceConfirm.TabIndex = 0;
            // 
            // pageRepair
            // 
            this.pageRepair.Controls.Add(this.ctrlRepairInvoiceConfirm);
            this.pageRepair.Location = new System.Drawing.Point(4, 22);
            this.pageRepair.Name = "pageRepair";
            this.pageRepair.Padding = new System.Windows.Forms.Padding(3);
            this.pageRepair.Size = new System.Drawing.Size(798, 507);
            this.pageRepair.TabIndex = 1;
            this.pageRepair.Text = "维修发票";
            this.pageRepair.UseVisualStyleBackColor = true;
            // 
            // ctrlRepairInvoiceConfirm
            // 
            this.ctrlRepairInvoiceConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlRepairInvoiceConfirm.Location = new System.Drawing.Point(3, 3);
            this.ctrlRepairInvoiceConfirm.Name = "ctrlRepairInvoiceConfirm";
            this.ctrlRepairInvoiceConfirm.Size = new System.Drawing.Size(792, 501);
            this.ctrlRepairInvoiceConfirm.TabIndex = 0;
            // 
            // lnkRefreshAll
            // 
            this.lnkRefreshAll.AutoSize = true;
            this.lnkRefreshAll.Location = new System.Drawing.Point(5, 23);
            this.lnkRefreshAll.Name = "lnkRefreshAll";
            this.lnkRefreshAll.Size = new System.Drawing.Size(53, 12);
            this.lnkRefreshAll.TabIndex = 3;
            this.lnkRefreshAll.TabStop = true;
            this.lnkRefreshAll.Text = "全部刷新";
            // 
            // FrmInvoiceConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 571);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmInvoiceConfirm";
            this.Text = "FrmInvoiceConfirm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cMenu.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.pageSale.ResumeLayout(false);
            this.pageRepair.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageSale;
        private System.Windows.Forms.TabPage pageRepair;
        private CtrlSaleInvoiceConfirm ctrlSaleInvoiceConfirm;
        private CtrlRepairInvoiceConfirm ctrlRepairInvoiceConfirm;
        private System.Windows.Forms.LinkLabel lnkRefreshAll;
    }
}