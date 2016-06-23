namespace JERPApp.Manufacture
{
    partial class FrmWorkingSheet
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageManuf = new System.Windows.Forms.TabPage();
            this.ctrlWorkingSheet = new JERPApp.Manufacture.CtrlWorkingSheet();
            this.pagePacking = new System.Windows.Forms.TabPage();
            this.ctrlPackingSheet = new JERPApp.Manufacture.CtrlPackingSheet();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pageManuf.SuspendLayout();
            this.pagePacking.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkRefreshAll);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 31);
            this.panel1.TabIndex = 1;
            // 
            // lnkRefreshAll
            // 
            this.lnkRefreshAll.AutoSize = true;
            this.lnkRefreshAll.Location = new System.Drawing.Point(5, 16);
            this.lnkRefreshAll.Name = "lnkRefreshAll";
            this.lnkRefreshAll.Size = new System.Drawing.Size(53, 12);
            this.lnkRefreshAll.TabIndex = 4;
            this.lnkRefreshAll.TabStop = true;
            this.lnkRefreshAll.Text = "全部刷新";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(405, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "生产制令";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pageManuf);
            this.tabMain.Controls.Add(this.pagePacking);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 31);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(803, 610);
            this.tabMain.TabIndex = 2;
            // 
            // pageManuf
            // 
            this.pageManuf.Controls.Add(this.ctrlWorkingSheet);
            this.pageManuf.Location = new System.Drawing.Point(4, 22);
            this.pageManuf.Name = "pageManuf";
            this.pageManuf.Padding = new System.Windows.Forms.Padding(3);
            this.pageManuf.Size = new System.Drawing.Size(795, 584);
            this.pageManuf.TabIndex = 0;
            this.pageManuf.Text = "生产制令";
            this.pageManuf.UseVisualStyleBackColor = true;
            // 
            // ctrlWorkingSheet
            // 
            this.ctrlWorkingSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlWorkingSheet.Location = new System.Drawing.Point(3, 3);
            this.ctrlWorkingSheet.Name = "ctrlWorkingSheet";
            this.ctrlWorkingSheet.Size = new System.Drawing.Size(789, 578);
            this.ctrlWorkingSheet.TabIndex = 0;
            // 
            // pagePacking
            // 
            this.pagePacking.Controls.Add(this.ctrlPackingSheet);
            this.pagePacking.Location = new System.Drawing.Point(4, 22);
            this.pagePacking.Name = "pagePacking";
            this.pagePacking.Padding = new System.Windows.Forms.Padding(3);
            this.pagePacking.Size = new System.Drawing.Size(795, 584);
            this.pagePacking.TabIndex = 1;
            this.pagePacking.Text = "包装制令";
            this.pagePacking.UseVisualStyleBackColor = true;
            // 
            // ctrlPackingSheet
            // 
            this.ctrlPackingSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPackingSheet.Location = new System.Drawing.Point(3, 3);
            this.ctrlPackingSheet.Name = "ctrlPackingSheet";
            this.ctrlPackingSheet.Size = new System.Drawing.Size(789, 578);
            this.ctrlPackingSheet.TabIndex = 0;
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
            // FrmWorkingSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 641);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmWorkingSheet";
            this.Text = "FrmWorkingSheet";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.pageManuf.ResumeLayout(false);
            this.pagePacking.ResumeLayout(false);
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageManuf;
        private System.Windows.Forms.TabPage pagePacking;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.LinkLabel lnkRefreshAll;
        private CtrlWorkingSheet ctrlWorkingSheet;
        private CtrlPackingSheet ctrlPackingSheet;
    }
}