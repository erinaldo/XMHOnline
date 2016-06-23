namespace JERPApp.Engineer.Report
{
    partial class FrmDevelopSchedule
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPrd = new System.Windows.Forms.TabControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ctrlTabNavPrd = new JCommon.CtrlTabNav();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPsn = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlTabNavPsn = new JCommon.CtrlTabNav();
            this.panel2.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1045, 35);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(505, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "研发排程";
            // 
            // cMenu
            // 
            this.cMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemRefresh});
            this.cMenu.Name = "cMenu";
            this.cMenu.Size = new System.Drawing.Size(99, 26);
            // 
            // mItemRefresh
            // 
            this.mItemRefresh.Name = "mItemRefresh";
            this.mItemRefresh.Size = new System.Drawing.Size(98, 22);
            this.mItemRefresh.Text = "刷新";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 35);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1045, 540);
            this.tabMain.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabPrd);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1037, 514);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "按产品";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPrd
            // 
            this.tabPrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrd.Location = new System.Drawing.Point(3, 3);
            this.tabPrd.Name = "tabPrd";
            this.tabPrd.SelectedIndex = 0;
            this.tabPrd.Size = new System.Drawing.Size(1031, 478);
            this.tabPrd.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ctrlTabNavPrd);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 481);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1031, 30);
            this.panel3.TabIndex = 2;
            // 
            // ctrlTabNavPrd
            // 
            this.ctrlTabNavPrd.Location = new System.Drawing.Point(12, 3);
            this.ctrlTabNavPrd.Name = "ctrlTabNavPrd";
            this.ctrlTabNavPrd.Size = new System.Drawing.Size(133, 23);
            this.ctrlTabNavPrd.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabPsn);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1037, 514);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "按责任人";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPsn
            // 
            this.tabPsn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPsn.Location = new System.Drawing.Point(3, 3);
            this.tabPsn.Name = "tabPsn";
            this.tabPsn.SelectedIndex = 0;
            this.tabPsn.Size = new System.Drawing.Size(1031, 478);
            this.tabPsn.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlTabNavPsn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 481);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1031, 30);
            this.panel1.TabIndex = 1;
            // 
            // ctrlTabNavPsn
            // 
            this.ctrlTabNavPsn.Location = new System.Drawing.Point(12, 3);
            this.ctrlTabNavPsn.Name = "ctrlTabNavPsn";
            this.ctrlTabNavPsn.Size = new System.Drawing.Size(133, 23);
            this.ctrlTabNavPsn.TabIndex = 3;
            // 
            // FrmDevelopSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 575);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel2);
            this.Name = "FrmDevelopSchedule";
            this.Text = "FrmDevelopSchedule";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.cMenu.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabPrd;
        private System.Windows.Forms.Panel panel3;
        private JCommon.CtrlTabNav ctrlTabNavPrd;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabPsn;
        private System.Windows.Forms.Panel panel1;
        private JCommon.CtrlTabNav ctrlTabNavPsn;
    }
}