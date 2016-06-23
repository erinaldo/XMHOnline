namespace JERPApp.Manufacture.Tool
{
    partial class FrmRepair
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgrdvRepair = new JCommon.MyDataGridView();
            this.ColumnBtnRepair = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnPrdTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRepairLimitQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnManufQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRepairedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRepairedCnt = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExportRepair = new System.Windows.Forms.Button();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.dgrdvUpgrade = new JCommon.MyDataGridView();
            this.ColumnbtnUpgrade = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnbtnStop = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnPrdTypeName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnExportUpgrade = new System.Windows.Forms.Button();
            this.ctrlFindUpgrade = new JCommon.CtrlGridQuickFind();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvRepair)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvUpgrade)).BeginInit();
            this.panel3.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 34);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(300, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "治具管理";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 34);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgrdvRepair);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgrdvUpgrade);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(656, 523);
            this.splitContainer1.SplitterDistance = 323;
            this.splitContainer1.TabIndex = 6;
            // 
            // dgrdvRepair
            // 
            this.dgrdvRepair.AllowUserToAddRows = false;
            this.dgrdvRepair.AllowUserToDeleteRows = false;
            this.dgrdvRepair.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvRepair.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnBtnRepair,
            this.ColumnPrdTypeName,
            this.ColumnPrdCode,
            this.ColumnRepairLimitQty,
            this.ColumnManufQty,
            this.ColumnRepairedQty,
            this.ColumnRepairedCnt});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvRepair.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvRepair.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvRepair.Location = new System.Drawing.Point(0, 0);
            this.dgrdvRepair.Name = "dgrdvRepair";
            this.dgrdvRepair.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvRepair.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgrdvRepair.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdvRepair.RowTemplate.Height = 23;
            this.dgrdvRepair.Size = new System.Drawing.Size(656, 291);
            this.dgrdvRepair.TabIndex = 7;
            // 
            // ColumnBtnRepair
            // 
            this.ColumnBtnRepair.HeaderText = "保养";
            this.ColumnBtnRepair.Name = "ColumnBtnRepair";
            this.ColumnBtnRepair.ReadOnly = true;
            this.ColumnBtnRepair.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnBtnRepair.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnBtnRepair.Text = "保养";
            this.ColumnBtnRepair.ToolTipText = "保养";
            this.ColumnBtnRepair.UseColumnTextForButtonValue = true;
            this.ColumnBtnRepair.Width = 60;
            // 
            // ColumnPrdTypeName
            // 
            this.ColumnPrdTypeName.DataPropertyName = "PrdTypeName";
            this.ColumnPrdTypeName.HeaderText = "类型";
            this.ColumnPrdTypeName.Name = "ColumnPrdTypeName";
            this.ColumnPrdTypeName.ReadOnly = true;
            this.ColumnPrdTypeName.Width = 66;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.HeaderText = "治具编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.ReadOnly = true;
            this.ColumnPrdCode.Width = 150;
            // 
            // ColumnRepairLimitQty
            // 
            this.ColumnRepairLimitQty.DataPropertyName = "MaxRepairQty";
            dataGridViewCellStyle1.Format = "#,##0.####";
            this.ColumnRepairLimitQty.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnRepairLimitQty.HeaderText = "保养参数";
            this.ColumnRepairLimitQty.Name = "ColumnRepairLimitQty";
            this.ColumnRepairLimitQty.ReadOnly = true;
            this.ColumnRepairLimitQty.Width = 78;
            // 
            // ColumnManufQty
            // 
            this.ColumnManufQty.DataPropertyName = "ManufQty";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Red;
            this.ColumnManufQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnManufQty.HeaderText = "生产累积";
            this.ColumnManufQty.Name = "ColumnManufQty";
            this.ColumnManufQty.ReadOnly = true;
            this.ColumnManufQty.Width = 78;
            // 
            // ColumnRepairedQty
            // 
            this.ColumnRepairedQty.DataPropertyName = "RepairedQty";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Red;
            this.ColumnRepairedQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnRepairedQty.HeaderText = "保养累积";
            this.ColumnRepairedQty.Name = "ColumnRepairedQty";
            this.ColumnRepairedQty.ReadOnly = true;
            this.ColumnRepairedQty.Width = 78;
            // 
            // ColumnRepairedCnt
            // 
            this.ColumnRepairedCnt.DataPropertyName = "RepairedCnt";
            this.ColumnRepairedCnt.HeaderText = "保养次数";
            this.ColumnRepairedCnt.Name = "ColumnRepairedCnt";
            this.ColumnRepairedCnt.ReadOnly = true;
            this.ColumnRepairedCnt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnRepairedCnt.Width = 78;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExportRepair);
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 291);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(656, 32);
            this.panel2.TabIndex = 5;
            // 
            // btnExportRepair
            // 
            this.btnExportRepair.Location = new System.Drawing.Point(250, 6);
            this.btnExportRepair.Name = "btnExportRepair";
            this.btnExportRepair.Size = new System.Drawing.Size(75, 23);
            this.btnExportRepair.TabIndex = 6;
            this.btnExportRepair.Text = "输出打印";
            this.btnExportRepair.UseVisualStyleBackColor = true;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(0, 6);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(244, 21);
            this.ctrlQFind.TabIndex = 5;
            // 
            // dgrdvUpgrade
            // 
            this.dgrdvUpgrade.AllowUserToAddRows = false;
            this.dgrdvUpgrade.AllowUserToDeleteRows = false;
            this.dgrdvUpgrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvUpgrade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnUpgrade,
            this.ColumnbtnStop,
            this.ColumnPrdTypeName1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvUpgrade.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgrdvUpgrade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvUpgrade.Location = new System.Drawing.Point(0, 0);
            this.dgrdvUpgrade.Name = "dgrdvUpgrade";
            this.dgrdvUpgrade.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvUpgrade.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            this.dgrdvUpgrade.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgrdvUpgrade.RowTemplate.Height = 23;
            this.dgrdvUpgrade.Size = new System.Drawing.Size(656, 164);
            this.dgrdvUpgrade.TabIndex = 8;
            // 
            // ColumnbtnUpgrade
            // 
            this.ColumnbtnUpgrade.HeaderText = "升级";
            this.ColumnbtnUpgrade.Name = "ColumnbtnUpgrade";
            this.ColumnbtnUpgrade.ReadOnly = true;
            this.ColumnbtnUpgrade.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnbtnUpgrade.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnbtnUpgrade.Text = "升级";
            this.ColumnbtnUpgrade.ToolTipText = "升级";
            this.ColumnbtnUpgrade.UseColumnTextForButtonValue = true;
            this.ColumnbtnUpgrade.Width = 60;
            // 
            // ColumnbtnStop
            // 
            this.ColumnbtnStop.HeaderText = "停产";
            this.ColumnbtnStop.Name = "ColumnbtnStop";
            this.ColumnbtnStop.ReadOnly = true;
            this.ColumnbtnStop.Text = "停产";
            this.ColumnbtnStop.UseColumnTextForButtonValue = true;
            this.ColumnbtnStop.Width = 54;
            // 
            // ColumnPrdTypeName1
            // 
            this.ColumnPrdTypeName1.DataPropertyName = "PrdTypeName";
            this.ColumnPrdTypeName1.HeaderText = "类型";
            this.ColumnPrdTypeName1.Name = "ColumnPrdTypeName1";
            this.ColumnPrdTypeName1.ReadOnly = true;
            this.ColumnPrdTypeName1.Width = 66;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PrdCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "治具编号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MaxManufQty";
            dataGridViewCellStyle7.Format = "#,##0.####";
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn2.HeaderText = "最大产量";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 78;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ManufQty";
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Red;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.HeaderText = "生产累积";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 78;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnExportUpgrade);
            this.panel3.Controls.Add(this.ctrlFindUpgrade);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 164);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(656, 32);
            this.panel3.TabIndex = 6;
            // 
            // btnExportUpgrade
            // 
            this.btnExportUpgrade.Location = new System.Drawing.Point(250, 6);
            this.btnExportUpgrade.Name = "btnExportUpgrade";
            this.btnExportUpgrade.Size = new System.Drawing.Size(75, 23);
            this.btnExportUpgrade.TabIndex = 6;
            this.btnExportUpgrade.Text = "输出打印";
            this.btnExportUpgrade.UseVisualStyleBackColor = true;
            // 
            // ctrlFindUpgrade
            // 
            this.ctrlFindUpgrade.Location = new System.Drawing.Point(0, 6);
            this.ctrlFindUpgrade.Name = "ctrlFindUpgrade";
            this.ctrlFindUpgrade.SeachGridView = null;
            this.ctrlFindUpgrade.Size = new System.Drawing.Size(244, 21);
            this.ctrlFindUpgrade.TabIndex = 5;
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
            // FrmRepair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 557);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmRepair";
            this.Text = "FrmDie";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvRepair)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvUpgrade)).EndInit();
            this.panel3.ResumeLayout(false);
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private JCommon.MyDataGridView dgrdvRepair;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExportRepair;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private JCommon.MyDataGridView dgrdvUpgrade;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnExportUpgrade;
        private JCommon.CtrlGridQuickFind ctrlFindUpgrade;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnBtnRepair;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRepairLimitQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnManufQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRepairedQty;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnRepairedCnt;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnUpgrade;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnStop;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdTypeName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
    }
}