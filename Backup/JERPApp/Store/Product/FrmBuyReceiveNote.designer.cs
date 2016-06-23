namespace JERPApp.Store.Product
{
    partial class FrmBuyReceiveNote
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlNoteSearch = new JCommon.ctrlNoteSearch();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnBtnDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnNoteCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyAbbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQCPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMakerPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageOrder = new System.Windows.Forms.TabPage();
            this.dgrdvOrder = new JCommon.MyDataGridView();
            this.ColumnbtnReceive = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnNoteCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ctrlGridOrder = new JCommon.CtrlGridFind();
            this.pageNote = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbar = new JCommon.PagebreakNav();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pageNonPrint = new System.Windows.Forms.TabPage();
            this.dgrdvNonPrint = new JCommon.MyDataGridView();
            this.ColumnbtnPrint = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ctrlGridNonPrintFind = new JCommon.CtrlGridFind();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.tabMain.SuspendLayout();
            this.pageOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvOrder)).BeginInit();
            this.panel6.SuspendLayout();
            this.pageNote.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pageNonPrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvNonPrint)).BeginInit();
            this.panel4.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 36);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(321, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "产品采购收货单";
            // 
            // ctrlNoteSearch
            // 
            this.ctrlNoteSearch.DateNoteFieldName = "DateNote";
            this.ctrlNoteSearch.Location = new System.Drawing.Point(4, 3);
            this.ctrlNoteSearch.Name = "ctrlNoteSearch";
            this.ctrlNoteSearch.NoteCodeFieldName = "NoteCode";
            this.ctrlNoteSearch.Size = new System.Drawing.Size(550, 28);
            this.ctrlNoteSearch.TabIndex = 19;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnBtnDetail,
            this.ColumnNoteCode,
            this.ColumnDateNote,
            this.ColumnCompanyAbbName,
            this.ColumnQCPsn,
            this.ColumnMakerPsn,
            this.ColumnMemo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(3, 32);
            this.dgrdv.Name = "dgrdv";
            this.dgrdv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(717, 346);
            this.dgrdv.TabIndex = 0;
            // 
            // ColumnBtnDetail
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            this.ColumnBtnDetail.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnBtnDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColumnBtnDetail.HeaderText = "详细";
            this.ColumnBtnDetail.Name = "ColumnBtnDetail";
            this.ColumnBtnDetail.ReadOnly = true;
            this.ColumnBtnDetail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnBtnDetail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnBtnDetail.Text = "详细";
            this.ColumnBtnDetail.UseColumnTextForButtonValue = true;
            this.ColumnBtnDetail.Width = 60;
            // 
            // ColumnNoteCode
            // 
            this.ColumnNoteCode.DataPropertyName = "NoteCode";
            this.ColumnNoteCode.HeaderText = "送货单号";
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
            this.ColumnCompanyAbbName.HeaderText = "供应商";
            this.ColumnCompanyAbbName.Name = "ColumnCompanyAbbName";
            this.ColumnCompanyAbbName.ReadOnly = true;
            this.ColumnCompanyAbbName.Width = 80;
            // 
            // ColumnQCPsn
            // 
            this.ColumnQCPsn.DataPropertyName = "QCPsn";
            this.ColumnQCPsn.HeaderText = "签收人";
            this.ColumnQCPsn.Name = "ColumnQCPsn";
            this.ColumnQCPsn.ReadOnly = true;
            this.ColumnQCPsn.Width = 80;
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
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pageOrder);
            this.tabMain.Controls.Add(this.pageNote);
            this.tabMain.Controls.Add(this.pageNonPrint);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 36);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(731, 437);
            this.tabMain.TabIndex = 6;
            // 
            // pageOrder
            // 
            this.pageOrder.Controls.Add(this.dgrdvOrder);
            this.pageOrder.Controls.Add(this.panel6);
            this.pageOrder.Location = new System.Drawing.Point(4, 22);
            this.pageOrder.Name = "pageOrder";
            this.pageOrder.Padding = new System.Windows.Forms.Padding(3);
            this.pageOrder.Size = new System.Drawing.Size(723, 411);
            this.pageOrder.TabIndex = 2;
            this.pageOrder.Text = "订单收货";
            this.pageOrder.UseVisualStyleBackColor = true;
            // 
            // dgrdvOrder
            // 
            this.dgrdvOrder.AllowUserToAddRows = false;
            this.dgrdvOrder.AllowUserToDeleteRows = false;
            this.dgrdvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnReceive,
            this.ColumnNoteCode1,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvOrder.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgrdvOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvOrder.Location = new System.Drawing.Point(3, 3);
            this.dgrdvOrder.Name = "dgrdvOrder";
            this.dgrdvOrder.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvOrder.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgrdvOrder.RowTemplate.Height = 23;
            this.dgrdvOrder.Size = new System.Drawing.Size(717, 376);
            this.dgrdvOrder.TabIndex = 11;
            // 
            // ColumnbtnReceive
            // 
            this.ColumnbtnReceive.HeaderText = "收货";
            this.ColumnbtnReceive.Name = "ColumnbtnReceive";
            this.ColumnbtnReceive.ReadOnly = true;
            this.ColumnbtnReceive.Text = "收货";
            this.ColumnbtnReceive.UseColumnTextForButtonValue = true;
            this.ColumnbtnReceive.Width = 60;
            // 
            // ColumnNoteCode1
            // 
            this.ColumnNoteCode1.DataPropertyName = "NoteCode";
            this.ColumnNoteCode1.HeaderText = "订单编号";
            this.ColumnNoteCode1.Name = "ColumnNoteCode1";
            this.ColumnNoteCode1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CompanyAbbName";
            this.dataGridViewTextBoxColumn7.HeaderText = "供应商";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "DateNote";
            this.dataGridViewTextBoxColumn8.HeaderText = "日期";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "MakerPsn";
            this.dataGridViewTextBoxColumn9.HeaderText = "制单员";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 66;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Memo";
            this.dataGridViewTextBoxColumn10.HeaderText = "备注";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 120;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.ctrlGridOrder);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(3, 379);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(717, 29);
            this.panel6.TabIndex = 5;
            // 
            // ctrlGridOrder
            // 
            this.ctrlGridOrder.Location = new System.Drawing.Point(5, 3);
            this.ctrlGridOrder.Name = "ctrlGridOrder";
            this.ctrlGridOrder.SeachGridView = null;
            this.ctrlGridOrder.Size = new System.Drawing.Size(331, 21);
            this.ctrlGridOrder.TabIndex = 0;
            // 
            // pageNote
            // 
            this.pageNote.Controls.Add(this.dgrdv);
            this.pageNote.Controls.Add(this.panel2);
            this.pageNote.Controls.Add(this.panel3);
            this.pageNote.Location = new System.Drawing.Point(4, 22);
            this.pageNote.Name = "pageNote";
            this.pageNote.Padding = new System.Windows.Forms.Padding(3);
            this.pageNote.Size = new System.Drawing.Size(723, 411);
            this.pageNote.TabIndex = 0;
            this.pageNote.Text = "收货单";
            this.pageNote.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pbar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 378);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(717, 30);
            this.panel2.TabIndex = 6;
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
            // panel3
            // 
            this.panel3.Controls.Add(this.ctrlNoteSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(717, 29);
            this.panel3.TabIndex = 0;
            // 
            // pageNonPrint
            // 
            this.pageNonPrint.Controls.Add(this.dgrdvNonPrint);
            this.pageNonPrint.Controls.Add(this.panel4);
            this.pageNonPrint.Location = new System.Drawing.Point(4, 22);
            this.pageNonPrint.Name = "pageNonPrint";
            this.pageNonPrint.Padding = new System.Windows.Forms.Padding(3);
            this.pageNonPrint.Size = new System.Drawing.Size(723, 411);
            this.pageNonPrint.TabIndex = 1;
            this.pageNonPrint.Text = "未打印";
            this.pageNonPrint.UseVisualStyleBackColor = true;
            // 
            // dgrdvNonPrint
            // 
            this.dgrdvNonPrint.AllowUserToAddRows = false;
            this.dgrdvNonPrint.AllowUserToDeleteRows = false;
            this.dgrdvNonPrint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvNonPrint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnPrint,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvNonPrint.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgrdvNonPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvNonPrint.Location = new System.Drawing.Point(3, 3);
            this.dgrdvNonPrint.Name = "dgrdvNonPrint";
            this.dgrdvNonPrint.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvNonPrint.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdvNonPrint.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgrdvNonPrint.RowTemplate.Height = 23;
            this.dgrdvNonPrint.Size = new System.Drawing.Size(717, 376);
            this.dgrdvNonPrint.TabIndex = 1;
            // 
            // ColumnbtnPrint
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Control;
            this.ColumnbtnPrint.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColumnbtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColumnbtnPrint.HeaderText = "打印";
            this.ColumnbtnPrint.Name = "ColumnbtnPrint";
            this.ColumnbtnPrint.ReadOnly = true;
            this.ColumnbtnPrint.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnbtnPrint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnbtnPrint.Text = "打印";
            this.ColumnbtnPrint.UseColumnTextForButtonValue = true;
            this.ColumnbtnPrint.Width = 60;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NoteCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "送货单号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 78;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DateNote";
            this.dataGridViewTextBoxColumn2.HeaderText = "收货日期";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 78;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CompanyAbbName";
            this.dataGridViewTextBoxColumn3.HeaderText = "供应商";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "QCPsn";
            this.dataGridViewTextBoxColumn4.HeaderText = "签收人";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "MakerPsn";
            this.dataGridViewTextBoxColumn5.HeaderText = "制单人";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 66;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Memo";
            this.dataGridViewTextBoxColumn6.HeaderText = "备注";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ctrlGridNonPrintFind);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 379);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(717, 29);
            this.panel4.TabIndex = 0;
            // 
            // ctrlGridNonPrintFind
            // 
            this.ctrlGridNonPrintFind.Location = new System.Drawing.Point(5, 3);
            this.ctrlGridNonPrintFind.Name = "ctrlGridNonPrintFind";
            this.ctrlGridNonPrintFind.SeachGridView = null;
            this.ctrlGridNonPrintFind.Size = new System.Drawing.Size(331, 21);
            this.ctrlGridNonPrintFind.TabIndex = 0;
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
            // FrmBuyReceiveNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 473);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBuyReceiveNote";
            this.Text = "FrmBuyReceiveNote";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.pageOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvOrder)).EndInit();
            this.panel6.ResumeLayout(false);
            this.pageNote.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.pageNonPrint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvNonPrint)).EndInit();
            this.panel4.ResumeLayout(false);
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Label label1;
        private JCommon.ctrlNoteSearch ctrlNoteSearch;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnBtnDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNoteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyAbbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQCPsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMakerPsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageNote;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabPage pageNonPrint;
        private System.Windows.Forms.Panel panel2;
        private JCommon.PagebreakNav pbar;
        private JCommon.MyDataGridView dgrdvNonPrint;
        private System.Windows.Forms.Panel panel4;
        private JCommon.CtrlGridFind ctrlGridNonPrintFind;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.TabPage pageOrder;
        private System.Windows.Forms.Panel panel6;
        private JCommon.CtrlGridFind ctrlGridOrder;
        private JCommon.MyDataGridView dgrdvOrder;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnReceive;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNoteCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
    }
}