namespace JERPApp.Store.Product
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageNonConfirm = new System.Windows.Forms.TabPage();
            this.dgrdvNonConfirm = new JCommon.MyDataGridView();
            this.ColumnbtnConfirm = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnNoteCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyAbbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpressRequire = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMakerPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDeliverAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlQNonConfirm = new JCommon.CtrlGridQuickFind();
            this.pageConfirm = new System.Windows.Forms.TabPage();
            this.dgrdvConfirm = new JCommon.MyDataGridView();
            this.ColumnbtnDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ctrlPrdID = new JERPApp.Define.Product.CtrlFinishedPrd();
            this.ckbPrd = new System.Windows.Forms.CheckBox();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.ckbDateNote = new System.Windows.Forms.CheckBox();
            this.ctrlCompanyID = new JERPApp.Define.General.CtrlCustomer();
            this.ckbCustomer = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pbar = new JCommon.PagebreakNav();
            this.panel1.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pageNonConfirm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvNonConfirm)).BeginInit();
            this.panel2.SuspendLayout();
            this.pageConfirm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvConfirm)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.label1.Location = new System.Drawing.Point(351, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "维修出货";
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
            this.tabMain.Controls.Add(this.pageNonConfirm);
            this.tabMain.Controls.Add(this.pageConfirm);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 37);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(737, 470);
            this.tabMain.TabIndex = 9;
            // 
            // pageNonConfirm
            // 
            this.pageNonConfirm.Controls.Add(this.dgrdvNonConfirm);
            this.pageNonConfirm.Controls.Add(this.panel2);
            this.pageNonConfirm.Location = new System.Drawing.Point(4, 22);
            this.pageNonConfirm.Name = "pageNonConfirm";
            this.pageNonConfirm.Padding = new System.Windows.Forms.Padding(3);
            this.pageNonConfirm.Size = new System.Drawing.Size(729, 444);
            this.pageNonConfirm.TabIndex = 0;
            this.pageNonConfirm.Text = "未出货";
            this.pageNonConfirm.UseVisualStyleBackColor = true;
            // 
            // dgrdvNonConfirm
            // 
            this.dgrdvNonConfirm.AllowUserToAddRows = false;
            this.dgrdvNonConfirm.AllowUserToDeleteRows = false;
            this.dgrdvNonConfirm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvNonConfirm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnConfirm,
            this.ColumnNoteCode,
            this.ColumnDateNote,
            this.ColumnCompanyAbbName,
            this.ColumnExpressRequire,
            this.ColumnMakerPsn,
            this.ColumnMemo,
            this.ColumnDeliverAddress});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvNonConfirm.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrdvNonConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvNonConfirm.Location = new System.Drawing.Point(3, 3);
            this.dgrdvNonConfirm.Name = "dgrdvNonConfirm";
            this.dgrdvNonConfirm.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvNonConfirm.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdvNonConfirm.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvNonConfirm.RowTemplate.Height = 23;
            this.dgrdvNonConfirm.Size = new System.Drawing.Size(723, 408);
            this.dgrdvNonConfirm.TabIndex = 8;
            // 
            // ColumnbtnConfirm
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            this.ColumnbtnConfirm.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnbtnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColumnbtnConfirm.HeaderText = "出货";
            this.ColumnbtnConfirm.Name = "ColumnbtnConfirm";
            this.ColumnbtnConfirm.ReadOnly = true;
            this.ColumnbtnConfirm.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnbtnConfirm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnbtnConfirm.Text = "出货";
            this.ColumnbtnConfirm.UseColumnTextForButtonValue = true;
            this.ColumnbtnConfirm.Width = 54;
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
            // 
            // ColumnDeliverAddress
            // 
            this.ColumnDeliverAddress.DataPropertyName = "DeliverAddress";
            this.ColumnDeliverAddress.HeaderText = "送货地";
            this.ColumnDeliverAddress.Name = "ColumnDeliverAddress";
            this.ColumnDeliverAddress.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlQNonConfirm);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 411);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(723, 30);
            this.panel2.TabIndex = 7;
            // 
            // ctrlQNonConfirm
            // 
            this.ctrlQNonConfirm.Location = new System.Drawing.Point(5, 4);
            this.ctrlQNonConfirm.Name = "ctrlQNonConfirm";
            this.ctrlQNonConfirm.SeachGridView = null;
            this.ctrlQNonConfirm.Size = new System.Drawing.Size(287, 21);
            this.ctrlQNonConfirm.TabIndex = 0;
            // 
            // pageConfirm
            // 
            this.pageConfirm.Controls.Add(this.dgrdvConfirm);
            this.pageConfirm.Controls.Add(this.panel4);
            this.pageConfirm.Controls.Add(this.panel3);
            this.pageConfirm.Location = new System.Drawing.Point(4, 22);
            this.pageConfirm.Name = "pageConfirm";
            this.pageConfirm.Padding = new System.Windows.Forms.Padding(3);
            this.pageConfirm.Size = new System.Drawing.Size(729, 444);
            this.pageConfirm.TabIndex = 2;
            this.pageConfirm.Text = "已出货";
            this.pageConfirm.UseVisualStyleBackColor = true;
            // 
            // dgrdvConfirm
            // 
            this.dgrdvConfirm.AllowUserToAddRows = false;
            this.dgrdvConfirm.AllowUserToDeleteRows = false;
            this.dgrdvConfirm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvConfirm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnDetail,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvConfirm.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdvConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvConfirm.Location = new System.Drawing.Point(3, 69);
            this.dgrdvConfirm.Name = "dgrdvConfirm";
            this.dgrdvConfirm.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvConfirm.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdvConfirm.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgrdvConfirm.RowTemplate.Height = 23;
            this.dgrdvConfirm.Size = new System.Drawing.Size(723, 342);
            this.dgrdvConfirm.TabIndex = 13;
            // 
            // ColumnbtnDetail
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            this.ColumnbtnDetail.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnbtnDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColumnbtnDetail.HeaderText = "详细";
            this.ColumnbtnDetail.Name = "ColumnbtnDetail";
            this.ColumnbtnDetail.ReadOnly = true;
            this.ColumnbtnDetail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnbtnDetail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnbtnDetail.Text = "详细";
            this.ColumnbtnDetail.UseColumnTextForButtonValue = true;
            this.ColumnbtnDetail.Width = 54;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NoteCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "出货单号";
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
            this.dataGridViewTextBoxColumn3.HeaderText = "客户";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ExpressRequire";
            this.dataGridViewTextBoxColumn4.HeaderText = "物流要求";
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
            this.panel4.Controls.Add(this.btnSearch);
            this.panel4.Controls.Add(this.ctrlPrdID);
            this.panel4.Controls.Add(this.ckbPrd);
            this.panel4.Controls.Add(this.dtpDateEnd);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.dtpDateBegin);
            this.panel4.Controls.Add(this.ckbDateNote);
            this.panel4.Controls.Add(this.ctrlCompanyID);
            this.panel4.Controls.Add(this.ckbCustomer);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(723, 66);
            this.panel4.TabIndex = 12;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(616, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // ctrlPrdID
            // 
            this.ctrlPrdID.AutoSize = true;
            this.ctrlPrdID.Location = new System.Drawing.Point(60, 7);
            this.ctrlPrdID.Name = "ctrlPrdID";
            this.ctrlPrdID.PrdID = -1;
            this.ctrlPrdID.Size = new System.Drawing.Size(631, 29);
            this.ctrlPrdID.TabIndex = 7;
            // 
            // ckbPrd
            // 
            this.ckbPrd.AutoSize = true;
            this.ckbPrd.Location = new System.Drawing.Point(6, 13);
            this.ckbPrd.Name = "ckbPrd";
            this.ckbPrd.Size = new System.Drawing.Size(48, 16);
            this.ckbPrd.TabIndex = 6;
            this.ckbPrd.Text = "产品";
            this.ckbPrd.UseVisualStyleBackColor = true;
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateEnd.Location = new System.Drawing.Point(414, 36);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(117, 21);
            this.dtpDateEnd.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "到";
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateBegin.Location = new System.Drawing.Point(267, 38);
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.Size = new System.Drawing.Size(117, 21);
            this.dtpDateBegin.TabIndex = 3;
            // 
            // ckbDateNote
            // 
            this.ckbDateNote.AutoSize = true;
            this.ckbDateNote.Location = new System.Drawing.Point(189, 39);
            this.ckbDateNote.Name = "ckbDateNote";
            this.ckbDateNote.Size = new System.Drawing.Size(72, 16);
            this.ckbDateNote.TabIndex = 2;
            this.ckbDateNote.Text = "日期  从";
            this.ckbDateNote.UseVisualStyleBackColor = true;
            // 
            // ctrlCompanyID
            // 
            this.ctrlCompanyID.CompanyID = 1;
            this.ctrlCompanyID.Location = new System.Drawing.Point(60, 39);
            this.ctrlCompanyID.Name = "ctrlCompanyID";
            this.ctrlCompanyID.Size = new System.Drawing.Size(123, 23);
            this.ctrlCompanyID.TabIndex = 1;
            // 
            // ckbCustomer
            // 
            this.ckbCustomer.AutoSize = true;
            this.ckbCustomer.Location = new System.Drawing.Point(6, 43);
            this.ckbCustomer.Name = "ckbCustomer";
            this.ckbCustomer.Size = new System.Drawing.Size(48, 16);
            this.ckbCustomer.TabIndex = 0;
            this.ckbCustomer.Text = "客户";
            this.ckbCustomer.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pbar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 411);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(723, 30);
            this.panel3.TabIndex = 11;
            // 
            // pbar
            // 
            this.pbar.AutoSize = true;
            this.pbar.Location = new System.Drawing.Point(4, 2);
            this.pbar.Name = "pbar";
            this.pbar.PageInBlock = 10;
            this.pbar.PageIndex = 0;
            this.pbar.PageSize = 50;
            this.pbar.Size = new System.Drawing.Size(406, 27);
            this.pbar.TabIndex = 0;
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
            this.pageNonConfirm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvNonConfirm)).EndInit();
            this.panel2.ResumeLayout(false);
            this.pageConfirm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvConfirm)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageNonConfirm;
        private JCommon.MyDataGridView dgrdvNonConfirm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage pageConfirm;
        private System.Windows.Forms.Panel panel3;
        private JCommon.CtrlGridQuickFind ctrlQNonConfirm;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox ckbCustomer;
        private System.Windows.Forms.Button btnSearch;
        private JERPApp.Define.Product.CtrlFinishedPrd ctrlPrdID;
        private System.Windows.Forms.CheckBox ckbPrd;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.CheckBox ckbDateNote;
        private JERPApp.Define.General.CtrlCustomer ctrlCompanyID;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnConfirm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNoteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyAbbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpressRequire;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMakerPsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeliverAddress;
        private JCommon.MyDataGridView dgrdvConfirm;
        private JCommon.PagebreakNav pbar;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}