namespace JERPApp.Finance.Payable.Postage
{
    partial class FrmReconciliation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkNew = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageReconciliation = new System.Windows.Forms.TabPage();
            this.dgrdvReconciliation = new JCommon.MyDataGridView();
            this.ColumnBtnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnDateNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReconciliationCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotalAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlQReconciliation = new JCommon.CtrlGridQuickFind();
            this.pageNonReconciliation = new System.Windows.Forms.TabPage();
            this.dgrdvNonReconciliation = new JCommon.MyDataGridView();
            this.ColumnCompanyName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ctrlQNonReconciliation = new JCommon.CtrlGridQuickFind();
            this.panel1.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pageReconciliation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvReconciliation)).BeginInit();
            this.panel2.SuspendLayout();
            this.pageNonReconciliation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvNonReconciliation)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkNew);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(762, 32);
            this.panel1.TabIndex = 0;
            // 
            // lnkNew
            // 
            this.lnkNew.AutoSize = true;
            this.lnkNew.Location = new System.Drawing.Point(4, 17);
            this.lnkNew.Name = "lnkNew";
            this.lnkNew.Size = new System.Drawing.Size(65, 12);
            this.lnkNew.TabIndex = 3;
            this.lnkNew.TabStop = true;
            this.lnkNew.Text = "新增对账单";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(344, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "运费对账单";
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
            this.tabMain.Controls.Add(this.pageReconciliation);
            this.tabMain.Controls.Add(this.pageNonReconciliation);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 32);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(762, 468);
            this.tabMain.TabIndex = 16;
            // 
            // pageReconciliation
            // 
            this.pageReconciliation.Controls.Add(this.dgrdvReconciliation);
            this.pageReconciliation.Controls.Add(this.panel2);
            this.pageReconciliation.Location = new System.Drawing.Point(4, 22);
            this.pageReconciliation.Name = "pageReconciliation";
            this.pageReconciliation.Padding = new System.Windows.Forms.Padding(3);
            this.pageReconciliation.Size = new System.Drawing.Size(754, 442);
            this.pageReconciliation.TabIndex = 0;
            this.pageReconciliation.Text = "对账单";
            this.pageReconciliation.UseVisualStyleBackColor = true;
            // 
            // dgrdvReconciliation
            // 
            this.dgrdvReconciliation.AllowUserToAddRows = false;
            this.dgrdvReconciliation.AllowUserToDeleteRows = false;
            this.dgrdvReconciliation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvReconciliation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnBtnEdit,
            this.ColumnDateNote,
            this.ColumnReconciliationCode,
            this.ColumnCompanyName,
            this.ColumnYear,
            this.ColumnMonth,
            this.ColumnTotalAMT});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvReconciliation.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdvReconciliation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvReconciliation.Location = new System.Drawing.Point(3, 3);
            this.dgrdvReconciliation.Name = "dgrdvReconciliation";
            this.dgrdvReconciliation.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvReconciliation.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdvReconciliation.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdvReconciliation.RowTemplate.Height = 23;
            this.dgrdvReconciliation.Size = new System.Drawing.Size(748, 406);
            this.dgrdvReconciliation.TabIndex = 16;
            // 
            // ColumnBtnEdit
            // 
            this.ColumnBtnEdit.HeaderText = "变更";
            this.ColumnBtnEdit.Name = "ColumnBtnEdit";
            this.ColumnBtnEdit.ReadOnly = true;
            this.ColumnBtnEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnBtnEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnBtnEdit.Text = "变更";
            this.ColumnBtnEdit.UseColumnTextForButtonValue = true;
            this.ColumnBtnEdit.Width = 54;
            // 
            // ColumnDateNote
            // 
            this.ColumnDateNote.DataPropertyName = "DateNote";
            this.ColumnDateNote.HeaderText = "制单日期";
            this.ColumnDateNote.Name = "ColumnDateNote";
            this.ColumnDateNote.ReadOnly = true;
            this.ColumnDateNote.Width = 78;
            // 
            // ColumnReconciliationCode
            // 
            this.ColumnReconciliationCode.DataPropertyName = "ReconciliationCode";
            this.ColumnReconciliationCode.HeaderText = "对账单号";
            this.ColumnReconciliationCode.Name = "ColumnReconciliationCode";
            this.ColumnReconciliationCode.ReadOnly = true;
            // 
            // ColumnCompanyName
            // 
            this.ColumnCompanyName.DataPropertyName = "CompanyName";
            this.ColumnCompanyName.HeaderText = "物流公司";
            this.ColumnCompanyName.Name = "ColumnCompanyName";
            this.ColumnCompanyName.ReadOnly = true;
            // 
            // ColumnYear
            // 
            this.ColumnYear.DataPropertyName = "Year";
            this.ColumnYear.HeaderText = "年";
            this.ColumnYear.Name = "ColumnYear";
            this.ColumnYear.ReadOnly = true;
            this.ColumnYear.Width = 40;
            // 
            // ColumnMonth
            // 
            this.ColumnMonth.DataPropertyName = "Month";
            this.ColumnMonth.HeaderText = "月";
            this.ColumnMonth.Name = "ColumnMonth";
            this.ColumnMonth.ReadOnly = true;
            this.ColumnMonth.Width = 30;
            // 
            // ColumnTotalAMT
            // 
            this.ColumnTotalAMT.DataPropertyName = "TotalAMT";
            this.ColumnTotalAMT.HeaderText = "合计金额";
            this.ColumnTotalAMT.Name = "ColumnTotalAMT";
            this.ColumnTotalAMT.ReadOnly = true;
            this.ColumnTotalAMT.Width = 78;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlQReconciliation);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 409);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(748, 30);
            this.panel2.TabIndex = 15;
            // 
            // ctrlQReconciliation
            // 
            this.ctrlQReconciliation.Location = new System.Drawing.Point(3, 6);
            this.ctrlQReconciliation.Name = "ctrlQReconciliation";
            this.ctrlQReconciliation.SeachGridView = null;
            this.ctrlQReconciliation.Size = new System.Drawing.Size(287, 21);
            this.ctrlQReconciliation.TabIndex = 0;
            // 
            // pageNonReconciliation
            // 
            this.pageNonReconciliation.Controls.Add(this.dgrdvNonReconciliation);
            this.pageNonReconciliation.Controls.Add(this.panel3);
            this.pageNonReconciliation.Location = new System.Drawing.Point(4, 22);
            this.pageNonReconciliation.Name = "pageNonReconciliation";
            this.pageNonReconciliation.Padding = new System.Windows.Forms.Padding(3);
            this.pageNonReconciliation.Size = new System.Drawing.Size(754, 442);
            this.pageNonReconciliation.TabIndex = 1;
            this.pageNonReconciliation.Text = "未做";
            this.pageNonReconciliation.UseVisualStyleBackColor = true;
            // 
            // dgrdvNonReconciliation
            // 
            this.dgrdvNonReconciliation.AllowUserToAddRows = false;
            this.dgrdvNonReconciliation.AllowUserToDeleteRows = false;
            this.dgrdvNonReconciliation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvNonReconciliation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCompanyName1});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvNonReconciliation.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvNonReconciliation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvNonReconciliation.Location = new System.Drawing.Point(3, 3);
            this.dgrdvNonReconciliation.Name = "dgrdvNonReconciliation";
            this.dgrdvNonReconciliation.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvNonReconciliation.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvNonReconciliation.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdvNonReconciliation.RowTemplate.Height = 23;
            this.dgrdvNonReconciliation.Size = new System.Drawing.Size(748, 406);
            this.dgrdvNonReconciliation.TabIndex = 17;
            // 
            // ColumnCompanyName1
            // 
            this.ColumnCompanyName1.DataPropertyName = "CompanyName";
            this.ColumnCompanyName1.HeaderText = "物流";
            this.ColumnCompanyName1.Name = "ColumnCompanyName1";
            this.ColumnCompanyName1.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ctrlQNonReconciliation);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 409);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(748, 30);
            this.panel3.TabIndex = 16;
            // 
            // ctrlQNonReconciliation
            // 
            this.ctrlQNonReconciliation.Location = new System.Drawing.Point(3, 6);
            this.ctrlQNonReconciliation.Name = "ctrlQNonReconciliation";
            this.ctrlQNonReconciliation.SeachGridView = null;
            this.ctrlQNonReconciliation.Size = new System.Drawing.Size(287, 21);
            this.ctrlQNonReconciliation.TabIndex = 0;
            // 
            // FrmReconciliation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 500);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReconciliation";
            this.Text = "FrmReconciliation";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cMenu.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.pageReconciliation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvReconciliation)).EndInit();
            this.panel2.ResumeLayout(false);
            this.pageNonReconciliation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvNonReconciliation)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkNew;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageReconciliation;
        private JCommon.MyDataGridView dgrdvReconciliation;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnBtnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReconciliationCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalAMT;
        private System.Windows.Forms.Panel panel2;
        private JCommon.CtrlGridQuickFind ctrlQReconciliation;
        private System.Windows.Forms.TabPage pageNonReconciliation;
        private System.Windows.Forms.Panel panel3;
        private JCommon.CtrlGridQuickFind ctrlQNonReconciliation;
        private JCommon.MyDataGridView dgrdvNonReconciliation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyName1;
    }
}