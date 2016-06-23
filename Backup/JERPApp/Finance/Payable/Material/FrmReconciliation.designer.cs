namespace JERPApp.Finance.Payable.Material
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkNew = new System.Windows.Forms.LinkLabel();
            this.lnkRefreshAll = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.dgrdvMonthSettle = new JCommon.MyDataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMoneyTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSettleTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageReconciliation = new System.Windows.Forms.TabPage();
            this.dgrdvReconciliation = new JCommon.MyDataGridView();
            this.ColumnBtnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnReconciliationCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyAbbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReconciliationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMoneyTypeName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSettleTypeName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotalAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlQReconciliation = new JCommon.CtrlGridQuickFind();
            this.pageMonthSettle = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ctrlQMonthSettle = new JCommon.CtrlGridQuickFind();
            this.pageReceive = new System.Windows.Forms.TabPage();
            this.dgrdvReceive = new JCommon.MyDataGridView();
            this.ColumnbtnBuy = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSettleTypeName3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotalAMT2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ctrlQReceive = new JCommon.CtrlGridQuickFind();
            this.panel1.SuspendLayout();
            this.cMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvMonthSettle)).BeginInit();
            this.tabMain.SuspendLayout();
            this.pageReconciliation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvReconciliation)).BeginInit();
            this.panel2.SuspendLayout();
            this.pageMonthSettle.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pageReceive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvReceive)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkNew);
            this.panel1.Controls.Add(this.lnkRefreshAll);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 38);
            this.panel1.TabIndex = 0;
            // 
            // lnkNew
            // 
            this.lnkNew.AutoSize = true;
            this.lnkNew.Location = new System.Drawing.Point(76, 23);
            this.lnkNew.Name = "lnkNew";
            this.lnkNew.Size = new System.Drawing.Size(77, 12);
            this.lnkNew.TabIndex = 4;
            this.lnkNew.TabStop = true;
            this.lnkNew.Text = "新月结对账单";
            // 
            // lnkRefreshAll
            // 
            this.lnkRefreshAll.AutoSize = true;
            this.lnkRefreshAll.Location = new System.Drawing.Point(4, 23);
            this.lnkRefreshAll.Name = "lnkRefreshAll";
            this.lnkRefreshAll.Size = new System.Drawing.Size(53, 12);
            this.lnkRefreshAll.TabIndex = 3;
            this.lnkRefreshAll.TabStop = true;
            this.lnkRefreshAll.Text = "全部刷新";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(356, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "原料采购对账单";
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
            // dgrdvMonthSettle
            // 
            this.dgrdvMonthSettle.AllowUserToAddRows = false;
            this.dgrdvMonthSettle.AllowUserToDeleteRows = false;
            this.dgrdvMonthSettle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvMonthSettle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.ColumnMoneyTypeName,
            this.ColumnSettleTypeName});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvMonthSettle.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdvMonthSettle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvMonthSettle.Location = new System.Drawing.Point(3, 3);
            this.dgrdvMonthSettle.Name = "dgrdvMonthSettle";
            this.dgrdvMonthSettle.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvMonthSettle.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdvMonthSettle.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdvMonthSettle.RowTemplate.Height = 23;
            this.dgrdvMonthSettle.Size = new System.Drawing.Size(778, 465);
            this.dgrdvMonthSettle.TabIndex = 12;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CompanyAbbName";
            this.dataGridViewTextBoxColumn2.HeaderText = "供应商";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // ColumnMoneyTypeName
            // 
            this.ColumnMoneyTypeName.DataPropertyName = "MoneyTypeName";
            this.ColumnMoneyTypeName.HeaderText = "币种";
            this.ColumnMoneyTypeName.Name = "ColumnMoneyTypeName";
            this.ColumnMoneyTypeName.ReadOnly = true;
            this.ColumnMoneyTypeName.Width = 54;
            // 
            // ColumnSettleTypeName
            // 
            this.ColumnSettleTypeName.DataPropertyName = "SettleTypeName";
            this.ColumnSettleTypeName.HeaderText = "结算方式";
            this.ColumnSettleTypeName.Name = "ColumnSettleTypeName";
            this.ColumnSettleTypeName.ReadOnly = true;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pageReconciliation);
            this.tabMain.Controls.Add(this.pageMonthSettle);
            this.tabMain.Controls.Add(this.pageReceive);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 38);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(792, 527);
            this.tabMain.TabIndex = 13;
            // 
            // pageReconciliation
            // 
            this.pageReconciliation.Controls.Add(this.dgrdvReconciliation);
            this.pageReconciliation.Controls.Add(this.panel2);
            this.pageReconciliation.Location = new System.Drawing.Point(4, 22);
            this.pageReconciliation.Name = "pageReconciliation";
            this.pageReconciliation.Padding = new System.Windows.Forms.Padding(3);
            this.pageReconciliation.Size = new System.Drawing.Size(784, 501);
            this.pageReconciliation.TabIndex = 0;
            this.pageReconciliation.Text = "对账变更";
            this.pageReconciliation.UseVisualStyleBackColor = true;
            // 
            // dgrdvReconciliation
            // 
            this.dgrdvReconciliation.AllowUserToAddRows = false;
            this.dgrdvReconciliation.AllowUserToDeleteRows = false;
            this.dgrdvReconciliation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvReconciliation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnBtnEdit,
            this.ColumnReconciliationCode,
            this.ColumnCompanyAbbName,
            this.ColumnReconciliationName,
            this.ColumnMoneyTypeName2,
            this.ColumnSettleTypeName1,
            this.ColumnTotalAMT,
            this.ColumnDateNote});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvReconciliation.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvReconciliation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvReconciliation.Location = new System.Drawing.Point(3, 3);
            this.dgrdvReconciliation.Name = "dgrdvReconciliation";
            this.dgrdvReconciliation.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvReconciliation.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdvReconciliation.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdvReconciliation.RowTemplate.Height = 23;
            this.dgrdvReconciliation.Size = new System.Drawing.Size(778, 465);
            this.dgrdvReconciliation.TabIndex = 3;
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
            // ColumnReconciliationCode
            // 
            this.ColumnReconciliationCode.DataPropertyName = "ReconciliationCode";
            this.ColumnReconciliationCode.HeaderText = "对账单号";
            this.ColumnReconciliationCode.Name = "ColumnReconciliationCode";
            this.ColumnReconciliationCode.ReadOnly = true;
            // 
            // ColumnCompanyAbbName
            // 
            this.ColumnCompanyAbbName.DataPropertyName = "CompanyAbbName";
            this.ColumnCompanyAbbName.HeaderText = "供应商";
            this.ColumnCompanyAbbName.Name = "ColumnCompanyAbbName";
            this.ColumnCompanyAbbName.ReadOnly = true;
            this.ColumnCompanyAbbName.Width = 80;
            // 
            // ColumnReconciliationName
            // 
            this.ColumnReconciliationName.DataPropertyName = "ReconciliationName";
            this.ColumnReconciliationName.HeaderText = "对账单名称";
            this.ColumnReconciliationName.Name = "ColumnReconciliationName";
            this.ColumnReconciliationName.ReadOnly = true;
            // 
            // ColumnMoneyTypeName2
            // 
            this.ColumnMoneyTypeName2.DataPropertyName = "MoneyTypeName";
            this.ColumnMoneyTypeName2.HeaderText = "币种";
            this.ColumnMoneyTypeName2.Name = "ColumnMoneyTypeName2";
            this.ColumnMoneyTypeName2.ReadOnly = true;
            this.ColumnMoneyTypeName2.Width = 54;
            // 
            // ColumnSettleTypeName1
            // 
            this.ColumnSettleTypeName1.DataPropertyName = "SettleTypeName";
            this.ColumnSettleTypeName1.HeaderText = "结算方式";
            this.ColumnSettleTypeName1.Name = "ColumnSettleTypeName1";
            this.ColumnSettleTypeName1.ReadOnly = true;
            this.ColumnSettleTypeName1.Width = 80;
            // 
            // ColumnTotalAMT
            // 
            this.ColumnTotalAMT.DataPropertyName = "TotalAMT";
            this.ColumnTotalAMT.HeaderText = "合计金额";
            this.ColumnTotalAMT.Name = "ColumnTotalAMT";
            this.ColumnTotalAMT.ReadOnly = true;
            this.ColumnTotalAMT.Width = 78;
            // 
            // ColumnDateNote
            // 
            this.ColumnDateNote.DataPropertyName = "DateNote";
            this.ColumnDateNote.HeaderText = "制单日期";
            this.ColumnDateNote.Name = "ColumnDateNote";
            this.ColumnDateNote.ReadOnly = true;
            this.ColumnDateNote.Width = 78;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlQReconciliation);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 468);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(778, 30);
            this.panel2.TabIndex = 0;
            // 
            // ctrlQReconciliation
            // 
            this.ctrlQReconciliation.Location = new System.Drawing.Point(3, 6);
            this.ctrlQReconciliation.Name = "ctrlQReconciliation";
            this.ctrlQReconciliation.SeachGridView = null;
            this.ctrlQReconciliation.Size = new System.Drawing.Size(287, 21);
            this.ctrlQReconciliation.TabIndex = 0;
            // 
            // pageMonthSettle
            // 
            this.pageMonthSettle.Controls.Add(this.dgrdvMonthSettle);
            this.pageMonthSettle.Controls.Add(this.panel3);
            this.pageMonthSettle.Location = new System.Drawing.Point(4, 22);
            this.pageMonthSettle.Name = "pageMonthSettle";
            this.pageMonthSettle.Padding = new System.Windows.Forms.Padding(3);
            this.pageMonthSettle.Size = new System.Drawing.Size(784, 501);
            this.pageMonthSettle.TabIndex = 1;
            this.pageMonthSettle.Text = "月结对账";
            this.pageMonthSettle.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ctrlQMonthSettle);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 468);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(778, 30);
            this.panel3.TabIndex = 1;
            // 
            // ctrlQMonthSettle
            // 
            this.ctrlQMonthSettle.Location = new System.Drawing.Point(3, 4);
            this.ctrlQMonthSettle.Name = "ctrlQMonthSettle";
            this.ctrlQMonthSettle.SeachGridView = null;
            this.ctrlQMonthSettle.Size = new System.Drawing.Size(287, 21);
            this.ctrlQMonthSettle.TabIndex = 1;
            // 
            // pageReceive
            // 
            this.pageReceive.Controls.Add(this.dgrdvReceive);
            this.pageReceive.Controls.Add(this.panel5);
            this.pageReceive.Location = new System.Drawing.Point(4, 22);
            this.pageReceive.Name = "pageReceive";
            this.pageReceive.Padding = new System.Windows.Forms.Padding(3);
            this.pageReceive.Size = new System.Drawing.Size(784, 501);
            this.pageReceive.TabIndex = 2;
            this.pageReceive.Text = "现结送货";
            this.pageReceive.UseVisualStyleBackColor = true;
            // 
            // dgrdvReceive
            // 
            this.dgrdvReceive.AllowUserToAddRows = false;
            this.dgrdvReceive.AllowUserToDeleteRows = false;
            this.dgrdvReceive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvReceive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnBuy,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn1,
            this.ColumnSettleTypeName3,
            this.ColumnTotalAMT2});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvReceive.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgrdvReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvReceive.Location = new System.Drawing.Point(3, 3);
            this.dgrdvReceive.Name = "dgrdvReceive";
            this.dgrdvReceive.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvReceive.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvReceive.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgrdvReceive.RowTemplate.Height = 23;
            this.dgrdvReceive.Size = new System.Drawing.Size(778, 464);
            this.dgrdvReceive.TabIndex = 10;
            // 
            // ColumnbtnBuy
            // 
            this.ColumnbtnBuy.HeaderText = "制单";
            this.ColumnbtnBuy.Name = "ColumnbtnBuy";
            this.ColumnbtnBuy.ReadOnly = true;
            this.ColumnbtnBuy.Text = "制单";
            this.ColumnbtnBuy.UseColumnTextForButtonValue = true;
            this.ColumnbtnBuy.Width = 54;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PONo";
            this.dataGridViewTextBoxColumn4.HeaderText = "订单编号";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CompanyAbbName";
            this.dataGridViewTextBoxColumn5.HeaderText = "供应商";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 66;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MoneyTypeName";
            this.dataGridViewTextBoxColumn1.HeaderText = "币种";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 54;
            // 
            // ColumnSettleTypeName3
            // 
            this.ColumnSettleTypeName3.DataPropertyName = "SettleTypeName";
            this.ColumnSettleTypeName3.HeaderText = "结算方式";
            this.ColumnSettleTypeName3.Name = "ColumnSettleTypeName3";
            this.ColumnSettleTypeName3.ReadOnly = true;
            this.ColumnSettleTypeName3.Width = 80;
            // 
            // ColumnTotalAMT2
            // 
            this.ColumnTotalAMT2.DataPropertyName = "TotalAMT";
            this.ColumnTotalAMT2.HeaderText = "货款";
            this.ColumnTotalAMT2.Name = "ColumnTotalAMT2";
            this.ColumnTotalAMT2.ReadOnly = true;
            this.ColumnTotalAMT2.Width = 66;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ctrlQReceive);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 467);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(778, 31);
            this.panel5.TabIndex = 11;
            // 
            // ctrlQReceive
            // 
            this.ctrlQReceive.Location = new System.Drawing.Point(5, 3);
            this.ctrlQReceive.Name = "ctrlQReceive";
            this.ctrlQReceive.SeachGridView = null;
            this.ctrlQReceive.Size = new System.Drawing.Size(287, 21);
            this.ctrlQReceive.TabIndex = 1;
            // 
            // FrmReconciliation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 565);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReconciliation";
            this.Text = "FrmBuyReconciliation";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvMonthSettle)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.pageReconciliation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvReconciliation)).EndInit();
            this.panel2.ResumeLayout(false);
            this.pageMonthSettle.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.pageReceive.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvReceive)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.Label label1;
        private JCommon.MyDataGridView dgrdvMonthSettle;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageReconciliation;
        private System.Windows.Forms.TabPage pageMonthSettle;
        private JCommon.MyDataGridView dgrdvReconciliation;
        private System.Windows.Forms.Panel panel2;
        private JCommon.CtrlGridQuickFind ctrlQReconciliation;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.LinkLabel lnkRefreshAll;
        private System.Windows.Forms.TabPage pageReceive;
        private JCommon.MyDataGridView dgrdvReceive;
        private System.Windows.Forms.Panel panel5;
        private JCommon.CtrlGridQuickFind ctrlQMonthSettle;
        private JCommon.CtrlGridQuickFind ctrlQReceive;
        private System.Windows.Forms.LinkLabel lnkNew;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnBtnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReconciliationCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyAbbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReconciliationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMoneyTypeName2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSettleTypeName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMoneyTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSettleTypeName;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnBuy;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSettleTypeName3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalAMT2;
    }
}