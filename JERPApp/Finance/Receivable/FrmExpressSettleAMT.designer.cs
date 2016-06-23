namespace JERPApp.Finance.Receivable
{
    partial class FrmExpressSettleAMT
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
            this.dgrdvReconciliation = new JCommon.MyDataGridView();
            this.ColumnbtnReconciliation = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnYear1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotalAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFinishedAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNonFinishedAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageReconciliation = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ctrlQReconciliation = new JCommon.CtrlGridQuickFind();
            this.pageReceipt = new System.Windows.Forms.TabPage();
            this.dgrdvReceipt = new JCommon.MyDataGridView();
            this.ColumnlnkNoteCode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSettlePsnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtReconciliationCode = new System.Windows.Forms.TextBox();
            this.ckbReconciliationCodeFlag = new System.Windows.Forms.CheckBox();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.ckbDateNoteFlag = new System.Windows.Forms.CheckBox();
            this.ctrlExpressID = new JERPApp.Define.General.CtrlExpress();
            this.ckbExpressFlag = new System.Windows.Forms.CheckBox();
            this.txtNoteCode = new System.Windows.Forms.TextBox();
            this.ckbNoteCodeFlag = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlQReceipt = new JCommon.CtrlGridQuickFind();
            this.pbar = new JCommon.PagebreakNav();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvReconciliation)).BeginInit();
            this.cMenu.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pageReconciliation.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pageReceipt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvReceipt)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 34);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(416, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "代收结款";
            // 
            // dgrdvReconciliation
            // 
            this.dgrdvReconciliation.AllowUserToAddRows = false;
            this.dgrdvReconciliation.AllowUserToDeleteRows = false;
            this.dgrdvReconciliation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvReconciliation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnReconciliation,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.ColumnYear1,
            this.ColumnMonth,
            this.dataGridViewTextBoxColumn6,
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
            this.dgrdvReconciliation.Size = new System.Drawing.Size(920, 441);
            this.dgrdvReconciliation.TabIndex = 2;
            // 
            // ColumnbtnReconciliation
            // 
            this.ColumnbtnReconciliation.HeaderText = "结款";
            this.ColumnbtnReconciliation.Name = "ColumnbtnReconciliation";
            this.ColumnbtnReconciliation.ReadOnly = true;
            this.ColumnbtnReconciliation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnbtnReconciliation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnbtnReconciliation.Text = "结款";
            this.ColumnbtnReconciliation.UseColumnTextForButtonValue = true;
            this.ColumnbtnReconciliation.Width = 54;
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
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DateNote";
            this.dataGridViewTextBoxColumn2.HeaderText = "制单日期";
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
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "MoneyTypeName";
            this.dataGridViewTextBoxColumn6.HeaderText = "币种";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 54;
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
            this.tabMain.Controls.Add(this.pageReceipt);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 34);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(934, 504);
            this.tabMain.TabIndex = 3;
            // 
            // pageReconciliation
            // 
            this.pageReconciliation.Controls.Add(this.dgrdvReconciliation);
            this.pageReconciliation.Controls.Add(this.panel4);
            this.pageReconciliation.Location = new System.Drawing.Point(4, 22);
            this.pageReconciliation.Name = "pageReconciliation";
            this.pageReconciliation.Padding = new System.Windows.Forms.Padding(3);
            this.pageReconciliation.Size = new System.Drawing.Size(926, 478);
            this.pageReconciliation.TabIndex = 0;
            this.pageReconciliation.Text = "未结";
            this.pageReconciliation.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ctrlQReconciliation);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 444);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(920, 31);
            this.panel4.TabIndex = 4;
            // 
            // ctrlQReconciliation
            // 
            this.ctrlQReconciliation.Location = new System.Drawing.Point(3, 3);
            this.ctrlQReconciliation.Name = "ctrlQReconciliation";
            this.ctrlQReconciliation.SeachGridView = null;
            this.ctrlQReconciliation.Size = new System.Drawing.Size(287, 21);
            this.ctrlQReconciliation.TabIndex = 0;
            // 
            // pageReceipt
            // 
            this.pageReceipt.Controls.Add(this.dgrdvReceipt);
            this.pageReceipt.Controls.Add(this.panel3);
            this.pageReceipt.Controls.Add(this.panel2);
            this.pageReceipt.Location = new System.Drawing.Point(4, 22);
            this.pageReceipt.Name = "pageReceipt";
            this.pageReceipt.Padding = new System.Windows.Forms.Padding(3);
            this.pageReceipt.Size = new System.Drawing.Size(926, 478);
            this.pageReceipt.TabIndex = 2;
            this.pageReceipt.Text = "已结";
            this.pageReceipt.UseVisualStyleBackColor = true;
            // 
            // dgrdvReceipt
            // 
            this.dgrdvReceipt.AllowUserToAddRows = false;
            this.dgrdvReceipt.AllowUserToDeleteRows = false;
            this.dgrdvReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvReceipt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnlnkNoteCode,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.ColumnSettlePsnName});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvReceipt.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvReceipt.Location = new System.Drawing.Point(3, 33);
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
            this.dgrdvReceipt.Size = new System.Drawing.Size(920, 412);
            this.dgrdvReceipt.TabIndex = 11;
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
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CompanyName";
            this.dataGridViewTextBoxColumn4.HeaderText = "物流公司";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "ReconciliationCode";
            this.dataGridViewTextBoxColumn10.HeaderText = "对账单号";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn10.Width = 80;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "DateNote";
            this.dataGridViewTextBoxColumn11.HeaderText = "制单日期";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 80;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "MoneyTypeName";
            this.dataGridViewTextBoxColumn12.HeaderText = "币种";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 54;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Amount";
            this.dataGridViewTextBoxColumn13.HeaderText = "结款金额";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 80;
            // 
            // ColumnSettlePsnName
            // 
            this.ColumnSettlePsnName.DataPropertyName = "SettlePsn";
            this.ColumnSettlePsnName.HeaderText = "入账人";
            this.ColumnSettlePsnName.Name = "ColumnSettlePsnName";
            this.ColumnSettlePsnName.ReadOnly = true;
            this.ColumnSettlePsnName.Width = 66;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtReconciliationCode);
            this.panel3.Controls.Add(this.ckbReconciliationCodeFlag);
            this.panel3.Controls.Add(this.dtpDateEnd);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.dtpDateBegin);
            this.panel3.Controls.Add(this.ckbDateNoteFlag);
            this.panel3.Controls.Add(this.ctrlExpressID);
            this.panel3.Controls.Add(this.ckbExpressFlag);
            this.panel3.Controls.Add(this.txtNoteCode);
            this.panel3.Controls.Add(this.ckbNoteCodeFlag);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(920, 30);
            this.panel3.TabIndex = 10;
            // 
            // txtReconciliationCode
            // 
            this.txtReconciliationCode.Location = new System.Drawing.Point(264, 5);
            this.txtReconciliationCode.Name = "txtReconciliationCode";
            this.txtReconciliationCode.Size = new System.Drawing.Size(103, 21);
            this.txtReconciliationCode.TabIndex = 16;
            // 
            // ckbReconciliationCodeFlag
            // 
            this.ckbReconciliationCodeFlag.AutoSize = true;
            this.ckbReconciliationCodeFlag.Location = new System.Drawing.Point(186, 9);
            this.ckbReconciliationCodeFlag.Name = "ckbReconciliationCodeFlag";
            this.ckbReconciliationCodeFlag.Size = new System.Drawing.Size(72, 16);
            this.ckbReconciliationCodeFlag.TabIndex = 15;
            this.ckbReconciliationCodeFlag.Text = "对账单号";
            this.ckbReconciliationCodeFlag.UseVisualStyleBackColor = true;
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Location = new System.Drawing.Point(735, 6);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(107, 21);
            this.dtpDateEnd.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(712, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "到";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(848, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(54, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.Location = new System.Drawing.Point(589, 6);
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.Size = new System.Drawing.Size(117, 21);
            this.dtpDateBegin.TabIndex = 7;
            // 
            // ckbDateNoteFlag
            // 
            this.ckbDateNoteFlag.AutoSize = true;
            this.ckbDateNoteFlag.Location = new System.Drawing.Point(521, 11);
            this.ckbDateNoteFlag.Name = "ckbDateNoteFlag";
            this.ckbDateNoteFlag.Size = new System.Drawing.Size(66, 16);
            this.ckbDateNoteFlag.TabIndex = 6;
            this.ckbDateNoteFlag.Text = "日期 从";
            this.ckbDateNoteFlag.UseVisualStyleBackColor = true;
            // 
            // ctrlExpressID
            // 
            this.ctrlExpressID.AutoSize = true;
            this.ctrlExpressID.CompanyID = 1;
            this.ctrlExpressID.Location = new System.Drawing.Point(429, 7);
            this.ctrlExpressID.Name = "ctrlExpressID";
            this.ctrlExpressID.Size = new System.Drawing.Size(89, 23);
            this.ctrlExpressID.TabIndex = 5;
            // 
            // ckbExpressFlag
            // 
            this.ckbExpressFlag.AutoSize = true;
            this.ckbExpressFlag.Location = new System.Drawing.Point(375, 11);
            this.ckbExpressFlag.Name = "ckbExpressFlag";
            this.ckbExpressFlag.Size = new System.Drawing.Size(48, 16);
            this.ckbExpressFlag.TabIndex = 4;
            this.ckbExpressFlag.Text = "物流";
            this.ckbExpressFlag.UseVisualStyleBackColor = true;
            // 
            // txtNoteCode
            // 
            this.txtNoteCode.Location = new System.Drawing.Point(83, 6);
            this.txtNoteCode.Name = "txtNoteCode";
            this.txtNoteCode.Size = new System.Drawing.Size(95, 21);
            this.txtNoteCode.TabIndex = 1;
            // 
            // ckbNoteCodeFlag
            // 
            this.ckbNoteCodeFlag.AutoSize = true;
            this.ckbNoteCodeFlag.Location = new System.Drawing.Point(5, 11);
            this.ckbNoteCodeFlag.Name = "ckbNoteCodeFlag";
            this.ckbNoteCodeFlag.Size = new System.Drawing.Size(72, 16);
            this.ckbNoteCodeFlag.TabIndex = 0;
            this.ckbNoteCodeFlag.Text = "收据单号";
            this.ckbNoteCodeFlag.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlQReceipt);
            this.panel2.Controls.Add(this.pbar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 445);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(920, 30);
            this.panel2.TabIndex = 3;
            // 
            // ctrlQReceipt
            // 
            this.ctrlQReceipt.Location = new System.Drawing.Point(5, 6);
            this.ctrlQReceipt.Name = "ctrlQReceipt";
            this.ctrlQReceipt.SeachGridView = null;
            this.ctrlQReceipt.Size = new System.Drawing.Size(244, 21);
            this.ctrlQReceipt.TabIndex = 1;
            // 
            // pbar
            // 
            this.pbar.AutoSize = true;
            this.pbar.Location = new System.Drawing.Point(254, 3);
            this.pbar.Margin = new System.Windows.Forms.Padding(0);
            this.pbar.Name = "pbar";
            this.pbar.PageInBlock = 10;
            this.pbar.PageIndex = 1;
            this.pbar.PageSize = 30;
            this.pbar.Size = new System.Drawing.Size(406, 31);
            this.pbar.TabIndex = 0;
            // 
            // FrmExpressSettleAMT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 538);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmExpressSettleAMT";
            this.Text = "FrmExpressSettleAMT";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvReconciliation)).EndInit();
            this.cMenu.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.pageReconciliation.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pageReceipt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvReceipt)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private JCommon.MyDataGridView dgrdvReconciliation;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageReconciliation;
        private System.Windows.Forms.TabPage pageReceipt;
        private System.Windows.Forms.Panel panel4;
        private JCommon.CtrlGridQuickFind ctrlQReconciliation;
        private System.Windows.Forms.Panel panel2;
        private JCommon.CtrlGridQuickFind ctrlQReceipt;
        private JCommon.PagebreakNav pbar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtReconciliationCode;
        private System.Windows.Forms.CheckBox ckbReconciliationCodeFlag;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.CheckBox ckbDateNoteFlag;
        private JERPApp.Define.General.CtrlExpress ctrlExpressID;
        private System.Windows.Forms.CheckBox ckbExpressFlag;
        private System.Windows.Forms.TextBox txtNoteCode;
        private System.Windows.Forms.CheckBox ckbNoteCodeFlag;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnReconciliation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnYear1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFinishedAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNonFinishedAMT;
        private JCommon.MyDataGridView dgrdvReceipt;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnlnkNoteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSettlePsnName;
    }
}