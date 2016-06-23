namespace JERPApp.Supply.OutSrc
{
    partial class FrmOrderNoteConfirm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlQNonConfirm = new JCommon.CtrlGridQuickFind();
            this.dgrdvNonConfirm = new JCommon.MyDataGridView();
            this.ColumnbtnConfirm = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnNoteCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyAbbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrderTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMakerPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pbar = new JCommon.PagebreakNav();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.ckbDateNote = new System.Windows.Forms.CheckBox();
            this.txtNoteCode = new System.Windows.Forms.TextBox();
            this.ckbNoteCode = new System.Windows.Forms.CheckBox();
            this.ctrlCompanyID = new JERPApp.Define.General.CtrlSupplierForOutSrc();
            this.ckbSupplier = new System.Windows.Forms.CheckBox();
            this.dgrdvConfirm = new JCommon.MyDataGridView();
            this.ColumnbtnCancel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnNoteCode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnConfirmPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvNonConfirm)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvConfirm)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 31);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(343, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "委外订单审核";
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgrdvNonConfirm);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgrdvConfirm);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(769, 444);
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlQNonConfirm);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 163);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(769, 30);
            this.panel2.TabIndex = 11;
            // 
            // ctrlQNonConfirm
            // 
            this.ctrlQNonConfirm.Location = new System.Drawing.Point(1, 5);
            this.ctrlQNonConfirm.Name = "ctrlQNonConfirm";
            this.ctrlQNonConfirm.SeachGridView = null;
            this.ctrlQNonConfirm.Size = new System.Drawing.Size(287, 21);
            this.ctrlQNonConfirm.TabIndex = 0;
            // 
            // dgrdvNonConfirm
            // 
            this.dgrdvNonConfirm.AllowUserToAddRows = false;
            this.dgrdvNonConfirm.AllowUserToDeleteRows = false;
            this.dgrdvNonConfirm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvNonConfirm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnConfirm,
            this.ColumnNoteCode1,
            this.ColumnCompanyAbbName,
            this.ColumnOrderTypeName,
            this.ColumnDateNote,
            this.ColumnMakerPsn,
            this.ColumnMemo});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvNonConfirm.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdvNonConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvNonConfirm.Location = new System.Drawing.Point(0, 0);
            this.dgrdvNonConfirm.Name = "dgrdvNonConfirm";
            this.dgrdvNonConfirm.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvNonConfirm.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvNonConfirm.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdvNonConfirm.RowTemplate.Height = 23;
            this.dgrdvNonConfirm.Size = new System.Drawing.Size(769, 163);
            this.dgrdvNonConfirm.TabIndex = 12;
            // 
            // ColumnbtnConfirm
            // 
            this.ColumnbtnConfirm.HeaderText = "审核";
            this.ColumnbtnConfirm.Name = "ColumnbtnConfirm";
            this.ColumnbtnConfirm.ReadOnly = true;
            this.ColumnbtnConfirm.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnbtnConfirm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnbtnConfirm.Text = "审核";
            this.ColumnbtnConfirm.UseColumnTextForButtonValue = true;
            this.ColumnbtnConfirm.Width = 60;
            // 
            // ColumnNoteCode1
            // 
            this.ColumnNoteCode1.DataPropertyName = "NoteCode";
            this.ColumnNoteCode1.HeaderText = "订单编号";
            this.ColumnNoteCode1.Name = "ColumnNoteCode1";
            this.ColumnNoteCode1.ReadOnly = true;
            // 
            // ColumnCompanyAbbName
            // 
            this.ColumnCompanyAbbName.DataPropertyName = "CompanyAbbName";
            this.ColumnCompanyAbbName.HeaderText = "供应商";
            this.ColumnCompanyAbbName.Name = "ColumnCompanyAbbName";
            this.ColumnCompanyAbbName.ReadOnly = true;
            this.ColumnCompanyAbbName.Width = 80;
            // 
            // ColumnOrderTypeName
            // 
            this.ColumnOrderTypeName.DataPropertyName = "OrderTypeName";
            this.ColumnOrderTypeName.HeaderText = "订单类型";
            this.ColumnOrderTypeName.Name = "ColumnOrderTypeName";
            this.ColumnOrderTypeName.ReadOnly = true;
            this.ColumnOrderTypeName.Width = 80;
            // 
            // ColumnDateNote
            // 
            this.ColumnDateNote.DataPropertyName = "DateNote";
            this.ColumnDateNote.HeaderText = "日期";
            this.ColumnDateNote.Name = "ColumnDateNote";
            this.ColumnDateNote.ReadOnly = true;
            this.ColumnDateNote.Width = 80;
            // 
            // ColumnMakerPsn
            // 
            this.ColumnMakerPsn.DataPropertyName = "MakerPsn";
            this.ColumnMakerPsn.HeaderText = "下单人";
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
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pbar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 217);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(769, 30);
            this.panel3.TabIndex = 12;
            // 
            // pbar
            // 
            this.pbar.AutoSize = true;
            this.pbar.Location = new System.Drawing.Point(3, 6);
            this.pbar.Name = "pbar";
            this.pbar.PageInBlock = 10;
            this.pbar.PageIndex = 1;
            this.pbar.PageSize = 50;
            this.pbar.Size = new System.Drawing.Size(406, 27);
            this.pbar.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnSearch);
            this.panel4.Controls.Add(this.dtpDateEnd);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.dtpDateBegin);
            this.panel4.Controls.Add(this.ckbDateNote);
            this.panel4.Controls.Add(this.txtNoteCode);
            this.panel4.Controls.Add(this.ckbNoteCode);
            this.panel4.Controls.Add(this.ctrlCompanyID);
            this.panel4.Controls.Add(this.ckbSupplier);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(769, 29);
            this.panel4.TabIndex = 13;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(697, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(55, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Location = new System.Drawing.Point(573, 3);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(118, 21);
            this.dtpDateEnd.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(550, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "到";
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.Location = new System.Drawing.Point(426, 3);
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.Size = new System.Drawing.Size(118, 21);
            this.dtpDateBegin.TabIndex = 5;
            // 
            // ckbDateNote
            // 
            this.ckbDateNote.AutoSize = true;
            this.ckbDateNote.Location = new System.Drawing.Point(360, 6);
            this.ckbDateNote.Name = "ckbDateNote";
            this.ckbDateNote.Size = new System.Drawing.Size(66, 16);
            this.ckbDateNote.TabIndex = 4;
            this.ckbDateNote.Text = "日期 从";
            this.ckbDateNote.UseVisualStyleBackColor = true;
            // 
            // txtNoteCode
            // 
            this.txtNoteCode.Location = new System.Drawing.Point(253, 4);
            this.txtNoteCode.Name = "txtNoteCode";
            this.txtNoteCode.Size = new System.Drawing.Size(100, 21);
            this.txtNoteCode.TabIndex = 3;
            // 
            // ckbNoteCode
            // 
            this.ckbNoteCode.AutoSize = true;
            this.ckbNoteCode.Location = new System.Drawing.Point(180, 6);
            this.ckbNoteCode.Name = "ckbNoteCode";
            this.ckbNoteCode.Size = new System.Drawing.Size(72, 16);
            this.ckbNoteCode.TabIndex = 2;
            this.ckbNoteCode.Text = "订单编号";
            this.ckbNoteCode.UseVisualStyleBackColor = true;
            // 
            // ctrlCompanyID
            // 
            this.ctrlCompanyID.CompanyID = -1;
            this.ctrlCompanyID.Location = new System.Drawing.Point(67, 3);
            this.ctrlCompanyID.Name = "ctrlCompanyID";
            this.ctrlCompanyID.Size = new System.Drawing.Size(109, 23);
            this.ctrlCompanyID.TabIndex = 1;
            // 
            // ckbSupplier
            // 
            this.ckbSupplier.AutoSize = true;
            this.ckbSupplier.Location = new System.Drawing.Point(5, 6);
            this.ckbSupplier.Name = "ckbSupplier";
            this.ckbSupplier.Size = new System.Drawing.Size(60, 16);
            this.ckbSupplier.TabIndex = 0;
            this.ckbSupplier.Text = "供应商";
            this.ckbSupplier.UseVisualStyleBackColor = true;
            // 
            // dgrdvConfirm
            // 
            this.dgrdvConfirm.AllowUserToAddRows = false;
            this.dgrdvConfirm.AllowUserToDeleteRows = false;
            this.dgrdvConfirm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvConfirm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnCancel,
            this.ColumnNoteCode,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.ColumnConfirmPsn,
            this.dataGridViewTextBoxColumn6});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvConfirm.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvConfirm.Location = new System.Drawing.Point(0, 29);
            this.dgrdvConfirm.Name = "dgrdvConfirm";
            this.dgrdvConfirm.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvConfirm.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvConfirm.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdvConfirm.RowTemplate.Height = 23;
            this.dgrdvConfirm.Size = new System.Drawing.Size(769, 188);
            this.dgrdvConfirm.TabIndex = 14;
            // 
            // ColumnbtnCancel
            // 
            this.ColumnbtnCancel.HeaderText = "返审";
            this.ColumnbtnCancel.Name = "ColumnbtnCancel";
            this.ColumnbtnCancel.ReadOnly = true;
            this.ColumnbtnCancel.Text = "返审";
            this.ColumnbtnCancel.UseColumnTextForButtonValue = true;
            this.ColumnbtnCancel.Width = 54;
            // 
            // ColumnNoteCode
            // 
            this.ColumnNoteCode.DataPropertyName = "NoteCode";
            this.ColumnNoteCode.HeaderText = "订单编号";
            this.ColumnNoteCode.Name = "ColumnNoteCode";
            this.ColumnNoteCode.ReadOnly = true;
            this.ColumnNoteCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnNoteCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CompanyAbbName";
            this.dataGridViewTextBoxColumn2.HeaderText = "供应商";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "OrderTypeName";
            this.dataGridViewTextBoxColumn3.HeaderText = "订单类型";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DateNote";
            this.dataGridViewTextBoxColumn4.HeaderText = "日期";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "MakerPsn";
            this.dataGridViewTextBoxColumn5.HeaderText = "下单人";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 66;
            // 
            // ColumnConfirmPsn
            // 
            this.ColumnConfirmPsn.DataPropertyName = "ConfirmPsn";
            this.ColumnConfirmPsn.HeaderText = "审核人";
            this.ColumnConfirmPsn.Name = "ColumnConfirmPsn";
            this.ColumnConfirmPsn.ReadOnly = true;
            this.ColumnConfirmPsn.Width = 66;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Memo";
            this.dataGridViewTextBoxColumn6.HeaderText = "备注";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // FrmOrderNoteConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 475);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmOrderNoteConfirm";
            this.Text = "FrmOrderNoteConfirm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cMenu.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvNonConfirm)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvConfirm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private JCommon.MyDataGridView dgrdvNonConfirm;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnConfirm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNoteCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyAbbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMakerPsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.Panel panel2;
        private JCommon.CtrlGridQuickFind ctrlQNonConfirm;
        private JCommon.MyDataGridView dgrdvConfirm;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnCancel;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnNoteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnConfirmPsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.CheckBox ckbDateNote;
        private System.Windows.Forms.TextBox txtNoteCode;
        private System.Windows.Forms.CheckBox ckbNoteCode;
        private JERPApp.Define.General.CtrlSupplierForOutSrc ctrlCompanyID;
        private System.Windows.Forms.CheckBox ckbSupplier;
        private System.Windows.Forms.Panel panel3;
        private JCommon.PagebreakNav pbar;
    }
}