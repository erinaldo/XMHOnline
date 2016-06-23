namespace JERPApp.Manufacture
{
    partial class FrmBOMPlan
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
            this.lnkRefreshAll = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageManufBOM = new System.Windows.Forms.TabPage();
            this.ctrlManufBOMPlan = new JERPApp.Manufacture.CtrlManufBOMPlan();
            this.pagePackingBOM = new System.Windows.Forms.TabPage();
            this.ctrlPackingBOMPlan = new JERPApp.Manufacture.CtrlPackingBOMPlan();
            this.panel1.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pageManufBOM.SuspendLayout();
            this.pagePackingBOM.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkRefreshAll);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(867, 31);
            this.panel1.TabIndex = 0;
            // 
            // lnkRefreshAll
            // 
            this.lnkRefreshAll.AutoSize = true;
            this.lnkRefreshAll.Location = new System.Drawing.Point(4, 15);
            this.lnkRefreshAll.Name = "lnkRefreshAll";
            this.lnkRefreshAll.Size = new System.Drawing.Size(53, 12);
            this.lnkRefreshAll.TabIndex = 3;
            this.lnkRefreshAll.TabStop = true;
            this.lnkRefreshAll.Text = "全部刷新";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(400, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "物料计划";
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
            this.tabMain.Controls.Add(this.pageManufBOM);
            this.tabMain.Controls.Add(this.pagePackingBOM);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 31);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(867, 494);
            this.tabMain.TabIndex = 3;
            // 
            // pageManufBOM
            // 
            this.pageManufBOM.Controls.Add(this.ctrlManufBOMPlan);
            this.pageManufBOM.Location = new System.Drawing.Point(4, 22);
            this.pageManufBOM.Name = "pageManufBOM";
            this.pageManufBOM.Padding = new System.Windows.Forms.Padding(3);
            this.pageManufBOM.Size = new System.Drawing.Size(859, 468);
            this.pageManufBOM.TabIndex = 0;
            this.pageManufBOM.Text = "生产料";
            this.pageManufBOM.UseVisualStyleBackColor = true;
            // 
            // ctrlManufBOMPlan
            // 
            this.ctrlManufBOMPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlManufBOMPlan.Location = new System.Drawing.Point(3, 3);
            this.ctrlManufBOMPlan.Name = "ctrlManufBOMPlan";
            this.ctrlManufBOMPlan.Size = new System.Drawing.Size(853, 462);
            this.ctrlManufBOMPlan.TabIndex = 0;
            // 
            // pagePackingBOM
            // 
            this.pagePackingBOM.Controls.Add(this.ctrlPackingBOMPlan);
            this.pagePackingBOM.Location = new System.Drawing.Point(4, 22);
            this.pagePackingBOM.Name = "pagePackingBOM";
            this.pagePackingBOM.Padding = new System.Windows.Forms.Padding(3);
            this.pagePackingBOM.Size = new System.Drawing.Size(859, 468);
            this.pagePackingBOM.TabIndex = 2;
            this.pagePackingBOM.Text = "包装料";
            this.pagePackingBOM.UseVisualStyleBackColor = true;
            // 
            // ctrlPackingBOMPlan
            // 
            this.ctrlPackingBOMPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPackingBOMPlan.Location = new System.Drawing.Point(3, 3);
            this.ctrlPackingBOMPlan.Name = "ctrlPackingBOMPlan";
            this.ctrlPackingBOMPlan.Size = new System.Drawing.Size(853, 462);
            this.ctrlPackingBOMPlan.TabIndex = 0;
            // 
            // FrmBOMPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 525);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBOMPlan";
            this.Text = "FrmBOMPlan";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cMenu.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.pageManufBOM.ResumeLayout(false);
            this.pagePackingBOM.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageManufBOM;
        private System.Windows.Forms.TabPage pagePackingBOM;
        private System.Windows.Forms.LinkLabel lnkRefreshAll;
        private CtrlManufBOMPlan ctrlManufBOMPlan;
        private CtrlPackingBOMPlan ctrlPackingBOMPlan;
    }
}