namespace JERPApp.Finance.Payable.Postage
{
    partial class FrmSettleAMT
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
            this.pbar = new JCommon.PagebreakNav();
            this.dgrdvReconciliation = new JCommon.MyDataGridView();
            this.ColumnBtnSettle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnYear1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotalAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFinishedAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNonFinishedAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageReconciliation = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ctrlQReconciliation = new JCommon.CtrlGridQuickFind();
            this.pageReceipt = new System.Windows.Forms.TabPage();
            this.dgrdvReceipt = new JCommon.MyDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.ckbDateNoteFlag = new System.Windows.Forms.CheckBox();
            this.txtReconciliationCode = new System.Windows.Forms.TextBox();
            this.ckbReconciliationCode = new System.Windows.Forms.CheckBox();
            this.txtNoteCode = new System.Windows.Forms.TextBox();
            this.ckbNoteCode = new System.Windows.Forms.CheckBox();
            this.ctrlExpressID = new JERPApp.Define.General.CtrlExpress();
            this.ckbExpressFlag = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ColumnlnkNoteCode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnDateNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReconciliationCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMakerPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.cMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvReconciliation)).BeginInit();
            this.tabMain.SuspendLayout();
            this.pageReconciliation.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pageReceipt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvReceipt)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 34);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(348, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "运费结账";
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
            // pbar
            // 
            this.pbar.AutoSize = true;
            this.pbar.Location = new System.Drawing.Point(2, 2);
            this.pbar.Margin = new System.Windows.Forms.Padding(0);
            this.pbar.Name = "pbar";
            this.pbar.PageInBlock = 10;
            this.pbar.PageIndex = 0;
            this.pbar.PageSize = 50;
            this.pbar.Size = new System.Drawing.Size(406, 31);
            this.pbar.TabIndex = 1;
            // 
            // dgrdvReconciliation
            // 
            this.dgrdvReconciliation.AllowUserToAddRows = false;
            this.dgrdvReconciliation.AllowUserToDeleteRows = false;
            this.dgrdvReconciliation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvReconciliation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnBtnSettle,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.ColumnYear1,
            this.ColumnMonth,
            this.ColumnTotalAMT,
            this.ColumnFinishedAMT,
            this.ColumnNonFinishedAMT});
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
            this.dgrdvReconciliation.Size = new System.Drawing.Size(730, 433);
            this.dgrdvReconciliation.TabIndex = 2;
            // 
            // ColumnBtnSettle
            // 
            this.ColumnBtnSettle.HeaderText = "结款";
            this.ColumnBtnSettle.Name = "ColumnBtnSettle";
            this.ColumnBtnSettle.ReadOnly = true;
            this.ColumnBtnSettle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnBtnSettle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnBtnSettle.Text = "结款";
            this.ColumnBtnSettle.UseColumnTextForButtonValue = true;
            this.ColumnBtnSettle.Width = 78;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ReconciliationCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "对账单号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 78;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DateSettle";
            this.dataGridViewTextBoxColumn2.HeaderText = "结算日期";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 78;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CompanyName";
            this.dataGridViewTextBoxColumn3.HeaderText = "物流公司";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // ColumnYear1
            // 
            this.ColumnYear1.DataPropertyName = "Year";
            this.ColumnYear1.HeaderText = "年";
            this.ColumnYear1.Name = "ColumnYear1";
            this.ColumnYear1.ReadOnly = true;
            this.ColumnYear1.Width = 40;
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
            this.ColumnTotalAMT.HeaderText = "金额";
            this.ColumnTotalAMT.Name = "ColumnTotalAMT";
            this.ColumnTotalAMT.ReadOnly = true;
            this.ColumnTotalAMT.Width = 66;
            // 
            // ColumnFinishedAMT
            // 
            this.ColumnFinishedAMT.DataPropertyName = "FinishedAMT";
            this.ColumnFinishedAMT.HeaderText = "已结";
            this.ColumnFinishedAMT.Name = "ColumnFinishedAMT";
            this.ColumnFinishedAMT.ReadOnly = true;
            this.ColumnFinishedAMT.Width = 66;
            // 
            // ColumnNonFinishedAMT
            // 
            this.ColumnNonFinishedAMT.DataPropertyName = "NonFinishedAMT";
            this.ColumnNonFinishedAMT.HeaderText = "未结";
            this.ColumnNonFinishedAMT.Name = "ColumnNonFinishedAMT";
            this.ColumnNonFinishedAMT.ReadOnly = true;
            this.ColumnNonFinishedAMT.Width = 66;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pageReconciliation);
            this.tabMain.Controls.Add(this.pageReceipt);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 34);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(744, 491);
            this.tabMain.TabIndex = 3;
            // 
            // pageReconciliation
            // 
            this.pageReconciliation.Controls.Add(this.dgrdvReconciliation);
            this.pageReconciliation.Controls.Add(this.panel3);
            this.pageReconciliation.Location = new System.Drawing.Point(4, 22);
            this.pageReconciliation.Name = "pageReconciliation";
            this.pageReconciliation.Padding = new System.Windows.Forms.Padding(3);
            this.pageReconciliation.Size = new System.Drawing.Size(736, 465);
            this.pageReconciliation.TabIndex = 0;
            this.pageReconciliation.Text = "对账单结款";
            this.pageReconciliation.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ctrlQReconciliation);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 436);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(730, 26);
            this.panel3.TabIndex = 3;
            // 
            // ctrlQReconciliation
            // 
            this.ctrlQReconciliation.Location = new System.Drawing.Point(4, 4);
            this.ctrlQReconciliation.Name = "ctrlQReconciliation";
            this.ctrlQReconciliation.SeachGridView = null;
            this.ctrlQReconciliation.Size = new System.Drawing.Size(287, 21);
            this.ctrlQReconciliation.TabIndex = 0;
            // 
            // pageReceipt
            // 
            this.pageReceipt.Controls.Add(this.dgrdvReceipt);
            this.pageReceipt.Controls.Add(this.panel2);
            this.pageReceipt.Controls.Add(this.panel4);
            this.pageReceipt.Location = new System.Drawing.Point(4, 22);
            this.pageReceipt.Name = "pageReceipt";
            this.pageReceipt.Padding = new System.Windows.Forms.Padding(3);
            this.pageReceipt.Size = new System.Drawing.Size(736, 465);
            this.pageReceipt.TabIndex = 1;
            this.pageReceipt.Text = "运费收据";
            this.pageReceipt.UseVisualStyleBackColor = true;
            // 
            // dgrdvReceipt
            // 
            this.dgrdvReceipt.AllowUserToAddRows = false;
            this.dgrdvReceipt.AllowUserToDeleteRows = false;
            this.dgrdvReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvReceipt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnlnkNoteCode,
            this.ColumnDateNote,
            this.ColumnReconciliationCode,
            this.ColumnCompanyName,
            this.ColumnAmount1,
            this.ColumnMakerPsn});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvReceipt.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvReceipt.Location = new System.Drawing.Point(3, 63);
            this.dgrdvReceipt.Name = "dgrdvReceipt";
            this.dgrdvReceipt.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvReceipt.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdvReceipt.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdvReceipt.RowTemplate.Height = 23;
            this.dgrdvReceipt.Size = new System.Drawing.Size(730, 373);
            this.dgrdvReceipt.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtpDateEnd);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.dtpDateBegin);
            this.panel2.Controls.Add(this.ckbDateNoteFlag);
            this.panel2.Controls.Add(this.txtReconciliationCode);
            this.panel2.Controls.Add(this.ckbReconciliationCode);
            this.panel2.Controls.Add(this.txtNoteCode);
            this.panel2.Controls.Add(this.ckbNoteCode);
            this.panel2.Controls.Add(this.ctrlExpressID);
            this.panel2.Controls.Add(this.ckbExpressFlag);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(730, 60);
            this.panel2.TabIndex = 6;
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Location = new System.Drawing.Point(258, 30);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(153, 21);
            this.dtpDateEnd.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "到";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(479, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(54, 23);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.Location = new System.Drawing.Point(84, 30);
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.Size = new System.Drawing.Size(136, 21);
            this.dtpDateBegin.TabIndex = 12;
            // 
            // ckbDateNoteFlag
            // 
            this.ckbDateNoteFlag.AutoSize = true;
            this.ckbDateNoteFlag.Location = new System.Drawing.Point(4, 35);
            this.ckbDateNoteFlag.Name = "ckbDateNoteFlag";
            this.ckbDateNoteFlag.Size = new System.Drawing.Size(66, 16);
            this.ckbDateNoteFlag.TabIndex = 11;
            this.ckbDateNoteFlag.Text = "日期 从";
            this.ckbDateNoteFlag.UseVisualStyleBackColor = true;
            // 
            // txtReconciliationCode
            // 
            this.txtReconciliationCode.Location = new System.Drawing.Point(433, 5);
            this.txtReconciliationCode.Name = "txtReconciliationCode";
            this.txtReconciliationCode.Size = new System.Drawing.Size(100, 21);
            this.txtReconciliationCode.TabIndex = 5;
            // 
            // ckbReconciliationCode
            // 
            this.ckbReconciliationCode.AutoSize = true;
            this.ckbReconciliationCode.Location = new System.Drawing.Point(360, 8);
            this.ckbReconciliationCode.Name = "ckbReconciliationCode";
            this.ckbReconciliationCode.Size = new System.Drawing.Size(72, 16);
            this.ckbReconciliationCode.TabIndex = 4;
            this.ckbReconciliationCode.Text = "对账单号";
            this.ckbReconciliationCode.UseVisualStyleBackColor = true;
            // 
            // txtNoteCode
            // 
            this.txtNoteCode.Location = new System.Drawing.Point(252, 4);
            this.txtNoteCode.Name = "txtNoteCode";
            this.txtNoteCode.Size = new System.Drawing.Size(100, 21);
            this.txtNoteCode.TabIndex = 3;
            // 
            // ckbNoteCode
            // 
            this.ckbNoteCode.AutoSize = true;
            this.ckbNoteCode.Location = new System.Drawing.Point(173, 7);
            this.ckbNoteCode.Name = "ckbNoteCode";
            this.ckbNoteCode.Size = new System.Drawing.Size(72, 16);
            this.ckbNoteCode.TabIndex = 2;
            this.ckbNoteCode.Text = "收据单号";
            this.ckbNoteCode.UseVisualStyleBackColor = true;
            // 
            // ctrlExpressID
            // 
            this.ctrlExpressID.AutoSize = true;
            this.ctrlExpressID.CompanyID = 1;
            this.ctrlExpressID.Location = new System.Drawing.Point(57, 3);
            this.ctrlExpressID.Name = "ctrlExpressID";
            this.ctrlExpressID.Size = new System.Drawing.Size(110, 23);
            this.ctrlExpressID.TabIndex = 1;
            // 
            // ckbExpressFlag
            // 
            this.ckbExpressFlag.AutoSize = true;
            this.ckbExpressFlag.Location = new System.Drawing.Point(4, 10);
            this.ckbExpressFlag.Name = "ckbExpressFlag";
            this.ckbExpressFlag.Size = new System.Drawing.Size(48, 16);
            this.ckbExpressFlag.TabIndex = 0;
            this.ckbExpressFlag.Text = "物流";
            this.ckbExpressFlag.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pbar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 436);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(730, 26);
            this.panel4.TabIndex = 4;
            // 
            // ColumnlnkNoteCode
            // 
            this.ColumnlnkNoteCode.DataPropertyName = "NoteCode";
            this.ColumnlnkNoteCode.HeaderText = "收据单号";
            this.ColumnlnkNoteCode.Name = "ColumnlnkNoteCode";
            this.ColumnlnkNoteCode.ReadOnly = true;
            this.ColumnlnkNoteCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnlnkNoteCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            this.ColumnCompanyName.Width = 80;
            // 
            // ColumnAmount1
            // 
            this.ColumnAmount1.DataPropertyName = "Amount";
            this.ColumnAmount1.HeaderText = "结算金额";
            this.ColumnAmount1.Name = "ColumnAmount1";
            this.ColumnAmount1.ReadOnly = true;
            this.ColumnAmount1.Width = 80;
            // 
            // ColumnMakerPsn
            // 
            this.ColumnMakerPsn.DataPropertyName = "MakerPsn";
            this.ColumnMakerPsn.HeaderText = "制单人";
            this.ColumnMakerPsn.Name = "ColumnMakerPsn";
            this.ColumnMakerPsn.ReadOnly = true;
            this.ColumnMakerPsn.Width = 66;
            // 
            // FrmSettleAMT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 525);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSettleAMT";
            this.Text = "FrmSettleAMT";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvReconciliation)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.pageReconciliation.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.pageReceipt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvReceipt)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private JCommon.MyDataGridView dgrdvReconciliation;
        private JCommon.PagebreakNav pbar;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnBtnSettle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnYear1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFinishedAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNonFinishedAMT;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageReconciliation;
        private System.Windows.Forms.Panel panel3;
        private JCommon.CtrlGridQuickFind ctrlQReconciliation;
        private System.Windows.Forms.TabPage pageReceipt;
        private JCommon.MyDataGridView dgrdvReceipt;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtReconciliationCode;
        private System.Windows.Forms.CheckBox ckbReconciliationCode;
        private System.Windows.Forms.TextBox txtNoteCode;
        private System.Windows.Forms.CheckBox ckbNoteCode;
        private JERPApp.Define.General.CtrlExpress ctrlExpressID;
        private System.Windows.Forms.CheckBox ckbExpressFlag;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.CheckBox ckbDateNoteFlag;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnlnkNoteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReconciliationCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMakerPsn;
    }
}