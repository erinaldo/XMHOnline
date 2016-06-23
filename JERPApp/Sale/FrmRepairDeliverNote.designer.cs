namespace JERPApp.Sale
{
    partial class FrmRepairDeliverNote
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageNonDeliver = new System.Windows.Forms.TabPage();
            this.dgrdvRepairItem = new JCommon.MyDataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ctrlQRepairItem = new JCommon.CtrlGridQuickFind();
            this.pageRecord = new System.Windows.Forms.TabPage();
            this.dgrdvNote = new JCommon.MyDataGridView();
            this.ColumnbtnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnNoteCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyAbbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpressRequire = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMakerPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlQNote = new JCommon.CtrlGridQuickFind();
            this.ColumnbtnNew = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDeliverApplyPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pageNonDeliver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvRepairItem)).BeginInit();
            this.panel3.SuspendLayout();
            this.pageRecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvNote)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(737, 37);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(366, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "维修出货单";
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
            this.tabMain.Controls.Add(this.pageNonDeliver);
            this.tabMain.Controls.Add(this.pageRecord);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 37);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(737, 470);
            this.tabMain.TabIndex = 9;
            // 
            // pageNonDeliver
            // 
            this.pageNonDeliver.Controls.Add(this.dgrdvRepairItem);
            this.pageNonDeliver.Controls.Add(this.panel3);
            this.pageNonDeliver.Location = new System.Drawing.Point(4, 22);
            this.pageNonDeliver.Name = "pageNonDeliver";
            this.pageNonDeliver.Padding = new System.Windows.Forms.Padding(3);
            this.pageNonDeliver.Size = new System.Drawing.Size(729, 444);
            this.pageNonDeliver.TabIndex = 2;
            this.pageNonDeliver.Text = "未制单";
            this.pageNonDeliver.UseVisualStyleBackColor = true;
            // 
            // dgrdvRepairItem
            // 
            this.dgrdvRepairItem.AllowUserToAddRows = false;
            this.dgrdvRepairItem.AllowUserToDeleteRows = false;
            this.dgrdvRepairItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvRepairItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnNew,
            this.dataGridViewTextBoxColumn9,
            this.ColumnDeliverApplyPsn,
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvRepairItem.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgrdvRepairItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvRepairItem.Location = new System.Drawing.Point(3, 3);
            this.dgrdvRepairItem.Name = "dgrdvRepairItem";
            this.dgrdvRepairItem.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvRepairItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvRepairItem.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgrdvRepairItem.RowTemplate.Height = 23;
            this.dgrdvRepairItem.Size = new System.Drawing.Size(723, 408);
            this.dgrdvRepairItem.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ctrlQRepairItem);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 411);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(723, 30);
            this.panel3.TabIndex = 11;
            // 
            // ctrlQRepairItem
            // 
            this.ctrlQRepairItem.Location = new System.Drawing.Point(5, 3);
            this.ctrlQRepairItem.Name = "ctrlQRepairItem";
            this.ctrlQRepairItem.SeachGridView = null;
            this.ctrlQRepairItem.Size = new System.Drawing.Size(287, 21);
            this.ctrlQRepairItem.TabIndex = 0;
            // 
            // pageRecord
            // 
            this.pageRecord.Controls.Add(this.dgrdvNote);
            this.pageRecord.Controls.Add(this.panel2);
            this.pageRecord.Location = new System.Drawing.Point(4, 22);
            this.pageRecord.Name = "pageRecord";
            this.pageRecord.Padding = new System.Windows.Forms.Padding(3);
            this.pageRecord.Size = new System.Drawing.Size(729, 444);
            this.pageRecord.TabIndex = 0;
            this.pageRecord.Text = "出货单";
            this.pageRecord.UseVisualStyleBackColor = true;
            // 
            // dgrdvNote
            // 
            this.dgrdvNote.AllowUserToAddRows = false;
            this.dgrdvNote.AllowUserToDeleteRows = false;
            this.dgrdvNote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvNote.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnEdit,
            this.ColumnNoteCode,
            this.ColumnDateNote,
            this.ColumnCompanyAbbName,
            this.ColumnExpressRequire,
            this.ColumnMakerPsn,
            this.ColumnMemo});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvNote.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgrdvNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvNote.Location = new System.Drawing.Point(3, 3);
            this.dgrdvNote.Name = "dgrdvNote";
            this.dgrdvNote.ReadOnly = true;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvNote.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdvNote.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dgrdvNote.RowTemplate.Height = 23;
            this.dgrdvNote.Size = new System.Drawing.Size(723, 408);
            this.dgrdvNote.TabIndex = 8;
            // 
            // ColumnbtnEdit
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Control;
            this.ColumnbtnEdit.DefaultCellStyle = dataGridViewCellStyle11;
            this.ColumnbtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColumnbtnEdit.HeaderText = "变更";
            this.ColumnbtnEdit.Name = "ColumnbtnEdit";
            this.ColumnbtnEdit.ReadOnly = true;
            this.ColumnbtnEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnbtnEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnbtnEdit.Text = "变更";
            this.ColumnbtnEdit.UseColumnTextForButtonValue = true;
            this.ColumnbtnEdit.Width = 54;
            // 
            // ColumnNoteCode
            // 
            this.ColumnNoteCode.DataPropertyName = "NoteCode";
            this.ColumnNoteCode.HeaderText = "出货单号";
            this.ColumnNoteCode.Name = "ColumnNoteCode";
            this.ColumnNoteCode.ReadOnly = true;
            this.ColumnNoteCode.Width = 78;
            // 
            // ColumnDateNote
            // 
            this.ColumnDateNote.DataPropertyName = "DateNote";
            this.ColumnDateNote.HeaderText = "收货日期";
            this.ColumnDateNote.Name = "ColumnDateNote";
            this.ColumnDateNote.ReadOnly = true;
            this.ColumnDateNote.Width = 78;
            // 
            // ColumnCompanyAbbName
            // 
            this.ColumnCompanyAbbName.DataPropertyName = "CompanyAbbName";
            this.ColumnCompanyAbbName.HeaderText = "客户";
            this.ColumnCompanyAbbName.Name = "ColumnCompanyAbbName";
            this.ColumnCompanyAbbName.ReadOnly = true;
            this.ColumnCompanyAbbName.Width = 80;
            // 
            // ColumnExpressRequire
            // 
            this.ColumnExpressRequire.DataPropertyName = "ExpressRequire";
            this.ColumnExpressRequire.HeaderText = "物流要求";
            this.ColumnExpressRequire.Name = "ColumnExpressRequire";
            this.ColumnExpressRequire.ReadOnly = true;
            this.ColumnExpressRequire.Width = 80;
            // 
            // ColumnMakerPsn
            // 
            this.ColumnMakerPsn.DataPropertyName = "MakerPsn";
            this.ColumnMakerPsn.HeaderText = "制单人";
            this.ColumnMakerPsn.Name = "ColumnMakerPsn";
            this.ColumnMakerPsn.ReadOnly = true;
            this.ColumnMakerPsn.Width = 66;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.ReadOnly = true;
            this.ColumnMemo.Width = 150;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlQNote);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 411);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(723, 30);
            this.panel2.TabIndex = 7;
            // 
            // ctrlQNote
            // 
            this.ctrlQNote.Location = new System.Drawing.Point(5, 4);
            this.ctrlQNote.Name = "ctrlQNote";
            this.ctrlQNote.SeachGridView = null;
            this.ctrlQNote.Size = new System.Drawing.Size(287, 21);
            this.ctrlQNote.TabIndex = 0;
            // 
            // ColumnbtnNew
            // 
            this.ColumnbtnNew.HeaderText = "制单";
            this.ColumnbtnNew.Name = "ColumnbtnNew";
            this.ColumnbtnNew.ReadOnly = true;
            this.ColumnbtnNew.Text = "制单";
            this.ColumnbtnNew.UseColumnTextForButtonValue = true;
            this.ColumnbtnNew.Width = 54;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "CompanyAbbName";
            this.dataGridViewTextBoxColumn9.HeaderText = "客户";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 80;
            // 
            // ColumnDeliverApplyPsn
            // 
            this.ColumnDeliverApplyPsn.DataPropertyName = "DeliverApplyPsn";
            this.ColumnDeliverApplyPsn.HeaderText = "申请人";
            this.ColumnDeliverApplyPsn.Name = "ColumnDeliverApplyPsn";
            this.ColumnDeliverApplyPsn.ReadOnly = true;
            this.ColumnDeliverApplyPsn.Width = 66;
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
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            this.ColumnPrdSpec.HeaderText = "产品规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            this.ColumnPrdSpec.ReadOnly = true;
            // 
            // ColumnModel
            // 
            this.ColumnModel.DataPropertyName = "Model";
            this.ColumnModel.HeaderText = "机型";
            this.ColumnModel.Name = "ColumnModel";
            this.ColumnModel.ReadOnly = true;
            this.ColumnModel.Width = 66;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "DateTarget";
            this.dataGridViewTextBoxColumn10.HeaderText = "出货日期";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 80;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Memo";
            this.dataGridViewTextBoxColumn11.HeaderText = "备注";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 120;
            // 
            // FrmRepairDeliverNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 507);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmRepairDeliverNote";
            this.Text = "FrmRepairDeliverNote";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cMenu.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.pageNonDeliver.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvRepairItem)).EndInit();
            this.panel3.ResumeLayout(false);
            this.pageRecord.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvNote)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageRecord;
        private JCommon.MyDataGridView dgrdvNote;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage pageNonDeliver;
        private JCommon.MyDataGridView dgrdvRepairItem;
        private System.Windows.Forms.Panel panel3;
        private JCommon.CtrlGridQuickFind ctrlQRepairItem;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNoteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyAbbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpressRequire;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMakerPsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private JCommon.CtrlGridQuickFind ctrlQNote;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeliverApplyPsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
    }
}