namespace JERPApp.Engineer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pagePrdSchedule = new System.Windows.Forms.TabPage();
            this.tabPrd = new System.Windows.Forms.TabControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ctrlTabNavPrd = new JCommon.CtrlTabNav();
            this.btnPrdSave = new System.Windows.Forms.Button();
            this.pagePsnSchedule = new System.Windows.Forms.TabPage();
            this.tabPsn = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlTabNavPsn = new JCommon.CtrlTabNav();
            this.btnPsnSave = new System.Windows.Forms.Button();
            this.pageNonSchedule = new System.Windows.Forms.TabPage();
            this.dgrdvNonSchedule = new JCommon.MyDataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnImgCount = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ctrlQNonSchedule = new JCommon.CtrlGridQuickFind();
            this.panel2.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pagePrdSchedule.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pagePsnSchedule.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pageNonSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvNonSchedule)).BeginInit();
            this.panel4.SuspendLayout();
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
            this.tabMain.Controls.Add(this.pageNonSchedule);
            this.tabMain.Controls.Add(this.pagePrdSchedule);
            this.tabMain.Controls.Add(this.pagePsnSchedule);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 35);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1045, 540);
            this.tabMain.TabIndex = 4;
            // 
            // pagePrdSchedule
            // 
            this.pagePrdSchedule.Controls.Add(this.tabPrd);
            this.pagePrdSchedule.Controls.Add(this.panel3);
            this.pagePrdSchedule.Location = new System.Drawing.Point(4, 22);
            this.pagePrdSchedule.Name = "pagePrdSchedule";
            this.pagePrdSchedule.Padding = new System.Windows.Forms.Padding(3);
            this.pagePrdSchedule.Size = new System.Drawing.Size(1037, 514);
            this.pagePrdSchedule.TabIndex = 0;
            this.pagePrdSchedule.Text = "按产品";
            this.pagePrdSchedule.UseVisualStyleBackColor = true;
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
            this.panel3.Controls.Add(this.btnPrdSave);
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
            // btnPrdSave
            // 
            this.btnPrdSave.Location = new System.Drawing.Point(164, 2);
            this.btnPrdSave.Name = "btnPrdSave";
            this.btnPrdSave.Size = new System.Drawing.Size(98, 23);
            this.btnPrdSave.TabIndex = 0;
            this.btnPrdSave.Text = "保存";
            this.btnPrdSave.UseVisualStyleBackColor = true;
            // 
            // pagePsnSchedule
            // 
            this.pagePsnSchedule.Controls.Add(this.tabPsn);
            this.pagePsnSchedule.Controls.Add(this.panel1);
            this.pagePsnSchedule.Location = new System.Drawing.Point(4, 22);
            this.pagePsnSchedule.Name = "pagePsnSchedule";
            this.pagePsnSchedule.Padding = new System.Windows.Forms.Padding(3);
            this.pagePsnSchedule.Size = new System.Drawing.Size(1037, 514);
            this.pagePsnSchedule.TabIndex = 1;
            this.pagePsnSchedule.Text = "按责任人";
            this.pagePsnSchedule.UseVisualStyleBackColor = true;
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
            this.panel1.Controls.Add(this.btnPsnSave);
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
            // btnPsnSave
            // 
            this.btnPsnSave.Location = new System.Drawing.Point(151, 2);
            this.btnPsnSave.Name = "btnPsnSave";
            this.btnPsnSave.Size = new System.Drawing.Size(98, 23);
            this.btnPsnSave.TabIndex = 0;
            this.btnPsnSave.Text = "保存";
            this.btnPsnSave.UseVisualStyleBackColor = true;
            // 
            // pageNonSchedule
            // 
            this.pageNonSchedule.Controls.Add(this.dgrdvNonSchedule);
            this.pageNonSchedule.Controls.Add(this.panel4);
            this.pageNonSchedule.Location = new System.Drawing.Point(4, 22);
            this.pageNonSchedule.Name = "pageNonSchedule";
            this.pageNonSchedule.Padding = new System.Windows.Forms.Padding(3);
            this.pageNonSchedule.Size = new System.Drawing.Size(1037, 514);
            this.pageNonSchedule.TabIndex = 2;
            this.pageNonSchedule.Text = "未作排程";
            this.pageNonSchedule.UseVisualStyleBackColor = true;
            // 
            // dgrdvNonSchedule
            // 
            this.dgrdvNonSchedule.AllowUserToAddRows = false;
            this.dgrdvNonSchedule.AllowUserToDeleteRows = false;
            this.dgrdvNonSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvNonSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnImgCount});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvNonSchedule.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrdvNonSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvNonSchedule.Location = new System.Drawing.Point(3, 3);
            this.dgrdvNonSchedule.Name = "dgrdvNonSchedule";
            this.dgrdvNonSchedule.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvNonSchedule.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvNonSchedule.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvNonSchedule.RowTemplate.Height = 23;
            this.dgrdvNonSchedule.Size = new System.Drawing.Size(1031, 475);
            this.dgrdvNonSchedule.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ctrlQNonSchedule);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 478);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1031, 33);
            this.panel4.TabIndex = 2;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.HeaderText = "产品编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.ReadOnly = true;
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.HeaderText = "产品名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            this.ColumnPrdName.ReadOnly = true;
            this.ColumnPrdName.Width = 100;
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            this.ColumnPrdSpec.HeaderText = "产品规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            this.ColumnPrdSpec.ReadOnly = true;
            this.ColumnPrdSpec.Width = 150;
            // 
            // ColumnImgCount
            // 
            this.ColumnImgCount.DataPropertyName = "ImgCount";
            dataGridViewCellStyle1.NullValue = "0";
            this.ColumnImgCount.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnImgCount.HeaderText = "图片";
            this.ColumnImgCount.Name = "ColumnImgCount";
            this.ColumnImgCount.ReadOnly = true;
            this.ColumnImgCount.Width = 66;
            // 
            // ctrlQNonSchedule
            // 
            this.ctrlQNonSchedule.Location = new System.Drawing.Point(5, 6);
            this.ctrlQNonSchedule.Name = "ctrlQNonSchedule";
            this.ctrlQNonSchedule.SeachGridView = null;
            this.ctrlQNonSchedule.Size = new System.Drawing.Size(287, 21);
            this.ctrlQNonSchedule.TabIndex = 0;
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
            this.pagePrdSchedule.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.pagePsnSchedule.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pageNonSchedule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvNonSchedule)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pagePrdSchedule;
        private System.Windows.Forms.TabControl tabPrd;
        private System.Windows.Forms.Panel panel3;
        private JCommon.CtrlTabNav ctrlTabNavPrd;
        private System.Windows.Forms.Button btnPrdSave;
        private System.Windows.Forms.TabPage pagePsnSchedule;
        private System.Windows.Forms.TabControl tabPsn;
        private System.Windows.Forms.Panel panel1;
        private JCommon.CtrlTabNav ctrlTabNavPsn;
        private System.Windows.Forms.Button btnPsnSave;
        private System.Windows.Forms.TabPage pageNonSchedule;
        private JCommon.MyDataGridView dgrdvNonSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnImgCount;
        private System.Windows.Forms.Panel panel4;
        private JCommon.CtrlGridQuickFind ctrlQNonSchedule;
    }
}