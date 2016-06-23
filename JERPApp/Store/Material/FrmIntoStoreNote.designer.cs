namespace JERPApp.Store.Material
{
    partial class FrmIntoStoreNote
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
            this.lnkNewFromPrd = new System.Windows.Forms.LinkLabel();
            this.lnkAppend = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageWokingSheet = new System.Windows.Forms.TabPage();
            this.dgrdvWorkingSheet = new JCommon.MyDataGridView();
            this.ColumnCheckedFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnWorkingSheetCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNonFinishedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ctrlQWorkingSheet = new JCommon.CtrlGridQuickFind();
            this.btnBatchNew = new System.Windows.Forms.Button();
            this.ctrlCkbAll = new JCommon.CtrlGridCheckBox();
            this.pageNote = new System.Windows.Forms.TabPage();
            this.dgrdvNote = new JCommon.MyDataGridView();
            this.ColumnbtnDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnNoteCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMakerPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ctrlNoteSearch = new JCommon.ctrlNoteSearch();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbar = new JCommon.PagebreakNav();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.lnkFromOEM = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pageWokingSheet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvWorkingSheet)).BeginInit();
            this.panel4.SuspendLayout();
            this.pageNote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvNote)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkFromOEM);
            this.panel1.Controls.Add(this.lnkNewFromPrd);
            this.panel1.Controls.Add(this.lnkAppend);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 42);
            this.panel1.TabIndex = 1;
            // 
            // lnkNewFromPrd
            // 
            this.lnkNewFromPrd.AutoSize = true;
            this.lnkNewFromPrd.Location = new System.Drawing.Point(67, 27);
            this.lnkNewFromPrd.Name = "lnkNewFromPrd";
            this.lnkNewFromPrd.Size = new System.Drawing.Size(65, 12);
            this.lnkNewFromPrd.TabIndex = 2;
            this.lnkNewFromPrd.TabStop = true;
            this.lnkNewFromPrd.Text = "成品库调入";
            // 
            // lnkAppend
            // 
            this.lnkAppend.AutoSize = true;
            this.lnkAppend.Location = new System.Drawing.Point(3, 27);
            this.lnkAppend.Name = "lnkAppend";
            this.lnkAppend.Size = new System.Drawing.Size(53, 12);
            this.lnkAppend.TabIndex = 1;
            this.lnkAppend.TabStop = true;
            this.lnkAppend.Text = "新入库单";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(294, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "原料生产入库";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pageWokingSheet);
            this.tabMain.Controls.Add(this.pageNote);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 42);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(682, 488);
            this.tabMain.TabIndex = 6;
            // 
            // pageWokingSheet
            // 
            this.pageWokingSheet.Controls.Add(this.dgrdvWorkingSheet);
            this.pageWokingSheet.Controls.Add(this.panel4);
            this.pageWokingSheet.Location = new System.Drawing.Point(4, 22);
            this.pageWokingSheet.Name = "pageWokingSheet";
            this.pageWokingSheet.Padding = new System.Windows.Forms.Padding(3);
            this.pageWokingSheet.Size = new System.Drawing.Size(674, 462);
            this.pageWokingSheet.TabIndex = 0;
            this.pageWokingSheet.Text = "未入库批次";
            this.pageWokingSheet.UseVisualStyleBackColor = true;
            // 
            // dgrdvWorkingSheet
            // 
            this.dgrdvWorkingSheet.AllowUserToAddRows = false;
            this.dgrdvWorkingSheet.AllowUserToDeleteRows = false;
            this.dgrdvWorkingSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvWorkingSheet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCheckedFlag,
            this.ColumnWorkingSheetCode1,
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnNonFinishedQty,
            this.ColumnPONo,
            this.ColumnCompanyCode,
            this.ColumnUnitName});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvWorkingSheet.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdvWorkingSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvWorkingSheet.Location = new System.Drawing.Point(3, 3);
            this.dgrdvWorkingSheet.Name = "dgrdvWorkingSheet";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvWorkingSheet.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvWorkingSheet.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdvWorkingSheet.RowTemplate.Height = 23;
            this.dgrdvWorkingSheet.Size = new System.Drawing.Size(668, 424);
            this.dgrdvWorkingSheet.TabIndex = 2;
            // 
            // ColumnCheckedFlag
            // 
            this.ColumnCheckedFlag.DataPropertyName = "CheckedFlag";
            this.ColumnCheckedFlag.HeaderText = "选择";
            this.ColumnCheckedFlag.Name = "ColumnCheckedFlag";
            this.ColumnCheckedFlag.Width = 54;
            // 
            // ColumnWorkingSheetCode1
            // 
            this.ColumnWorkingSheetCode1.DataPropertyName = "WorkingSheetCode";
            this.ColumnWorkingSheetCode1.HeaderText = "生产批号";
            this.ColumnWorkingSheetCode1.Name = "ColumnWorkingSheetCode1";
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.HeaderText = "产品编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.HeaderText = "产品名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            this.ColumnPrdName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            this.ColumnPrdSpec.HeaderText = "产品规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            // 
            // ColumnModel
            // 
            this.ColumnModel.DataPropertyName = "Model";
            this.ColumnModel.HeaderText = "机型";
            this.ColumnModel.Name = "ColumnModel";
            this.ColumnModel.Width = 80;
            // 
            // ColumnNonFinishedQty
            // 
            this.ColumnNonFinishedQty.DataPropertyName = "NonFinishedQty";
            this.ColumnNonFinishedQty.HeaderText = "未入库";
            this.ColumnNonFinishedQty.Name = "ColumnNonFinishedQty";
            this.ColumnNonFinishedQty.Width = 66;
            // 
            // ColumnPONo
            // 
            this.ColumnPONo.DataPropertyName = "PONo";
            this.ColumnPONo.HeaderText = "订单编号";
            this.ColumnPONo.Name = "ColumnPONo";
            this.ColumnPONo.Width = 80;
            // 
            // ColumnCompanyCode
            // 
            this.ColumnCompanyCode.DataPropertyName = "CompanyCode";
            this.ColumnCompanyCode.HeaderText = "客户";
            this.ColumnCompanyCode.Name = "ColumnCompanyCode";
            this.ColumnCompanyCode.Width = 60;
            // 
            // ColumnUnitName
            // 
            this.ColumnUnitName.DataPropertyName = "UnitName";
            this.ColumnUnitName.HeaderText = "单位";
            this.ColumnUnitName.Name = "ColumnUnitName";
            this.ColumnUnitName.Width = 54;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ctrlQWorkingSheet);
            this.panel4.Controls.Add(this.btnBatchNew);
            this.panel4.Controls.Add(this.ctrlCkbAll);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 427);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(668, 32);
            this.panel4.TabIndex = 0;
            // 
            // ctrlQWorkingSheet
            // 
            this.ctrlQWorkingSheet.Location = new System.Drawing.Point(61, 8);
            this.ctrlQWorkingSheet.Name = "ctrlQWorkingSheet";
            this.ctrlQWorkingSheet.SeachGridView = null;
            this.ctrlQWorkingSheet.Size = new System.Drawing.Size(254, 21);
            this.ctrlQWorkingSheet.TabIndex = 2;
            // 
            // btnBatchNew
            // 
            this.btnBatchNew.Location = new System.Drawing.Point(321, 6);
            this.btnBatchNew.Name = "btnBatchNew";
            this.btnBatchNew.Size = new System.Drawing.Size(75, 23);
            this.btnBatchNew.TabIndex = 1;
            this.btnBatchNew.Text = "批量入库";
            this.btnBatchNew.UseVisualStyleBackColor = true;
            // 
            // ctrlCkbAll
            // 
            this.ctrlCkbAll.Location = new System.Drawing.Point(6, 10);
            this.ctrlCkbAll.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlCkbAll.Name = "ctrlCkbAll";
            this.ctrlCkbAll.SeachGridView = null;
            this.ctrlCkbAll.Size = new System.Drawing.Size(52, 18);
            this.ctrlCkbAll.TabIndex = 0;
            // 
            // pageNote
            // 
            this.pageNote.Controls.Add(this.dgrdvNote);
            this.pageNote.Controls.Add(this.panel3);
            this.pageNote.Controls.Add(this.panel2);
            this.pageNote.Location = new System.Drawing.Point(4, 22);
            this.pageNote.Name = "pageNote";
            this.pageNote.Padding = new System.Windows.Forms.Padding(3);
            this.pageNote.Size = new System.Drawing.Size(674, 462);
            this.pageNote.TabIndex = 1;
            this.pageNote.Text = "历史入库单";
            this.pageNote.UseVisualStyleBackColor = true;
            // 
            // dgrdvNote
            // 
            this.dgrdvNote.AllowUserToAddRows = false;
            this.dgrdvNote.AllowUserToDeleteRows = false;
            this.dgrdvNote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvNote.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnDetail,
            this.ColumnNoteCode,
            this.ColumnDateNote,
            this.ColumnMakerPsn,
            this.ColumnMemo});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvNote.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvNote.Location = new System.Drawing.Point(3, 32);
            this.dgrdvNote.Name = "dgrdvNote";
            this.dgrdvNote.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvNote.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvNote.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdvNote.RowTemplate.Height = 23;
            this.dgrdvNote.Size = new System.Drawing.Size(668, 397);
            this.dgrdvNote.TabIndex = 9;
            // 
            // ColumnbtnDetail
            // 
            this.ColumnbtnDetail.HeaderText = "详细";
            this.ColumnbtnDetail.Name = "ColumnbtnDetail";
            this.ColumnbtnDetail.ReadOnly = true;
            this.ColumnbtnDetail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnbtnDetail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnbtnDetail.Text = "详细";
            this.ColumnbtnDetail.UseColumnTextForButtonValue = true;
            this.ColumnbtnDetail.Width = 60;
            // 
            // ColumnNoteCode
            // 
            this.ColumnNoteCode.DataPropertyName = "NoteCode";
            this.ColumnNoteCode.HeaderText = "入库单号";
            this.ColumnNoteCode.Name = "ColumnNoteCode";
            this.ColumnNoteCode.ReadOnly = true;
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
            // panel3
            // 
            this.panel3.Controls.Add(this.ctrlNoteSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(668, 29);
            this.panel3.TabIndex = 8;
            // 
            // ctrlNoteSearch
            // 
            this.ctrlNoteSearch.DateNoteFieldName = "DateNote";
            this.ctrlNoteSearch.Location = new System.Drawing.Point(3, 3);
            this.ctrlNoteSearch.Name = "ctrlNoteSearch";
            this.ctrlNoteSearch.NoteCodeFieldName = "NoteCode";
            this.ctrlNoteSearch.Size = new System.Drawing.Size(550, 28);
            this.ctrlNoteSearch.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pbar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 429);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(668, 30);
            this.panel2.TabIndex = 7;
            // 
            // pbar
            // 
            this.pbar.AutoSize = true;
            this.pbar.Location = new System.Drawing.Point(0, 3);
            this.pbar.Name = "pbar";
            this.pbar.PageInBlock = 10;
            this.pbar.PageIndex = 1;
            this.pbar.PageSize = 30;
            this.pbar.Size = new System.Drawing.Size(406, 27);
            this.pbar.TabIndex = 1;
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
            // lnkFromOEM
            // 
            this.lnkFromOEM.AutoSize = true;
            this.lnkFromOEM.Location = new System.Drawing.Point(145, 27);
            this.lnkFromOEM.Name = "lnkFromOEM";
            this.lnkFromOEM.Size = new System.Drawing.Size(65, 12);
            this.lnkFromOEM.TabIndex = 3;
            this.lnkFromOEM.TabStop = true;
            this.lnkFromOEM.Text = "客供库调入";
            // 
            // FrmIntoStoreNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 530);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmIntoStoreNote";
            this.Text = "FrmIntoStoreNote";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.pageWokingSheet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvWorkingSheet)).EndInit();
            this.panel4.ResumeLayout(false);
            this.pageNote.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvNote)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkAppend;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageWokingSheet;
        private System.Windows.Forms.TabPage pageNote;
        private JCommon.MyDataGridView dgrdvNote;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNoteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMakerPsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.Panel panel3;
        private JCommon.ctrlNoteSearch ctrlNoteSearch;
        private System.Windows.Forms.Panel panel2;
        private JCommon.PagebreakNav pbar;
        private JCommon.MyDataGridView dgrdvWorkingSheet;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheckedFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWorkingSheetCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNonFinishedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName;
        private JCommon.CtrlGridQuickFind ctrlQWorkingSheet;
        private System.Windows.Forms.Button btnBatchNew;
        private JCommon.CtrlGridCheckBox ctrlCkbAll;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.LinkLabel lnkNewFromPrd;
        private System.Windows.Forms.LinkLabel lnkFromOEM;
    }
}