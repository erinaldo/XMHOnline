namespace JERPApp.Finance.Report
{
    partial class FrmReceivableReceipt
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.radSettleFlag = new System.Windows.Forms.RadioButton();
            this.radNonSettleFlag = new System.Windows.Forms.RadioButton();
            this.ckbSettleFlag = new System.Windows.Forms.CheckBox();
            this.txtPONo = new System.Windows.Forms.TextBox();
            this.ckbPONo = new System.Windows.Forms.CheckBox();
            this.txtReconciliationCode = new System.Windows.Forms.TextBox();
            this.ckbReconciliationCodeFlag = new System.Windows.Forms.CheckBox();
            this.txtRepairDeliverNoteCode = new System.Windows.Forms.TextBox();
            this.ckbRepairDeliverNoteFlag = new System.Windows.Forms.CheckBox();
            this.txtSaleDeliverNoteCode = new System.Windows.Forms.TextBox();
            this.ckbSaleDeliverNoteFlag = new System.Windows.Forms.CheckBox();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.ckbDateNoteFlag = new System.Windows.Forms.CheckBox();
            this.ctrlExpressID = new JERPApp.Define.General.CtrlExpress();
            this.ckbExpressFlag = new System.Windows.Forms.CheckBox();
            this.ctrlCustomerID = new JERPApp.Define.General.CtrlCustomer();
            this.ckbCustomerFlag = new System.Windows.Forms.CheckBox();
            this.txtNoteCode = new System.Windows.Forms.TextBox();
            this.ckbNoteCodeFlag = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.pbar = new JCommon.PagebreakNav();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnNoteCode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnPONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReconciliationCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateNote1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyAbbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpressCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMoneyTypeName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotalAMT1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAdvanceAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMakerPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSettlePsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSaleDeliverNoteCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRepairDeliverNoteCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBankCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.ckbSettleFlag);
            this.panel1.Controls.Add(this.txtPONo);
            this.panel1.Controls.Add(this.ckbPONo);
            this.panel1.Controls.Add(this.txtReconciliationCode);
            this.panel1.Controls.Add(this.ckbReconciliationCodeFlag);
            this.panel1.Controls.Add(this.txtRepairDeliverNoteCode);
            this.panel1.Controls.Add(this.ckbRepairDeliverNoteFlag);
            this.panel1.Controls.Add(this.txtSaleDeliverNoteCode);
            this.panel1.Controls.Add(this.ckbSaleDeliverNoteFlag);
            this.panel1.Controls.Add(this.dtpDateEnd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dtpDateBegin);
            this.panel1.Controls.Add(this.ckbDateNoteFlag);
            this.panel1.Controls.Add(this.ctrlExpressID);
            this.panel1.Controls.Add(this.ckbExpressFlag);
            this.panel1.Controls.Add(this.ctrlCustomerID);
            this.panel1.Controls.Add(this.ckbCustomerFlag);
            this.panel1.Controls.Add(this.txtNoteCode);
            this.panel1.Controls.Add(this.ckbNoteCodeFlag);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 86);
            this.panel1.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.radSettleFlag);
            this.panel4.Controls.Add(this.radNonSettleFlag);
            this.panel4.Location = new System.Drawing.Point(84, 9);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(86, 22);
            this.panel4.TabIndex = 47;
            // 
            // radSettleFlag
            // 
            this.radSettleFlag.AutoSize = true;
            this.radSettleFlag.Location = new System.Drawing.Point(3, 3);
            this.radSettleFlag.Name = "radSettleFlag";
            this.radSettleFlag.Size = new System.Drawing.Size(35, 16);
            this.radSettleFlag.TabIndex = 1;
            this.radSettleFlag.Text = "是";
            this.radSettleFlag.UseVisualStyleBackColor = true;
            // 
            // radNonSettleFlag
            // 
            this.radNonSettleFlag.AutoSize = true;
            this.radNonSettleFlag.Checked = true;
            this.radNonSettleFlag.Location = new System.Drawing.Point(38, 2);
            this.radNonSettleFlag.Name = "radNonSettleFlag";
            this.radNonSettleFlag.Size = new System.Drawing.Size(35, 16);
            this.radNonSettleFlag.TabIndex = 0;
            this.radNonSettleFlag.TabStop = true;
            this.radNonSettleFlag.Text = "否";
            this.radNonSettleFlag.UseVisualStyleBackColor = true;
            // 
            // ckbSettleFlag
            // 
            this.ckbSettleFlag.AutoSize = true;
            this.ckbSettleFlag.Checked = true;
            this.ckbSettleFlag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbSettleFlag.Location = new System.Drawing.Point(6, 12);
            this.ckbSettleFlag.Name = "ckbSettleFlag";
            this.ckbSettleFlag.Size = new System.Drawing.Size(48, 16);
            this.ckbSettleFlag.TabIndex = 46;
            this.ckbSettleFlag.Text = "结款";
            this.ckbSettleFlag.UseVisualStyleBackColor = true;
            // 
            // txtPONo
            // 
            this.txtPONo.Location = new System.Drawing.Point(476, 34);
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.Size = new System.Drawing.Size(103, 21);
            this.txtPONo.TabIndex = 45;
            // 
            // ckbPONo
            // 
            this.ckbPONo.AutoSize = true;
            this.ckbPONo.Location = new System.Drawing.Point(398, 38);
            this.ckbPONo.Name = "ckbPONo";
            this.ckbPONo.Size = new System.Drawing.Size(72, 16);
            this.ckbPONo.TabIndex = 44;
            this.ckbPONo.Text = "订单编号";
            this.ckbPONo.UseVisualStyleBackColor = true;
            // 
            // txtReconciliationCode
            // 
            this.txtReconciliationCode.Location = new System.Drawing.Point(279, 35);
            this.txtReconciliationCode.Name = "txtReconciliationCode";
            this.txtReconciliationCode.Size = new System.Drawing.Size(110, 21);
            this.txtReconciliationCode.TabIndex = 43;
            // 
            // ckbReconciliationCodeFlag
            // 
            this.ckbReconciliationCodeFlag.AutoSize = true;
            this.ckbReconciliationCodeFlag.Location = new System.Drawing.Point(208, 39);
            this.ckbReconciliationCodeFlag.Name = "ckbReconciliationCodeFlag";
            this.ckbReconciliationCodeFlag.Size = new System.Drawing.Size(72, 16);
            this.ckbReconciliationCodeFlag.TabIndex = 42;
            this.ckbReconciliationCodeFlag.Text = "对账单号";
            this.ckbReconciliationCodeFlag.UseVisualStyleBackColor = true;
            // 
            // txtRepairDeliverNoteCode
            // 
            this.txtRepairDeliverNoteCode.Location = new System.Drawing.Point(830, 32);
            this.txtRepairDeliverNoteCode.Name = "txtRepairDeliverNoteCode";
            this.txtRepairDeliverNoteCode.Size = new System.Drawing.Size(78, 21);
            this.txtRepairDeliverNoteCode.TabIndex = 41;
            // 
            // ckbRepairDeliverNoteFlag
            // 
            this.ckbRepairDeliverNoteFlag.AutoSize = true;
            this.ckbRepairDeliverNoteFlag.Location = new System.Drawing.Point(760, 35);
            this.ckbRepairDeliverNoteFlag.Name = "ckbRepairDeliverNoteFlag";
            this.ckbRepairDeliverNoteFlag.Size = new System.Drawing.Size(72, 16);
            this.ckbRepairDeliverNoteFlag.TabIndex = 40;
            this.ckbRepairDeliverNoteFlag.Text = "维修单号";
            this.ckbRepairDeliverNoteFlag.UseVisualStyleBackColor = true;
            // 
            // txtSaleDeliverNoteCode
            // 
            this.txtSaleDeliverNoteCode.Location = new System.Drawing.Point(674, 32);
            this.txtSaleDeliverNoteCode.Name = "txtSaleDeliverNoteCode";
            this.txtSaleDeliverNoteCode.Size = new System.Drawing.Size(79, 21);
            this.txtSaleDeliverNoteCode.TabIndex = 39;
            // 
            // ckbSaleDeliverNoteFlag
            // 
            this.ckbSaleDeliverNoteFlag.AutoSize = true;
            this.ckbSaleDeliverNoteFlag.Location = new System.Drawing.Point(596, 37);
            this.ckbSaleDeliverNoteFlag.Name = "ckbSaleDeliverNoteFlag";
            this.ckbSaleDeliverNoteFlag.Size = new System.Drawing.Size(72, 16);
            this.ckbSaleDeliverNoteFlag.TabIndex = 38;
            this.ckbSaleDeliverNoteFlag.Text = "送货单号";
            this.ckbSaleDeliverNoteFlag.UseVisualStyleBackColor = true;
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Location = new System.Drawing.Point(672, 58);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(153, 21);
            this.dtpDateEnd.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(641, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 36;
            this.label2.Text = "到";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(831, 56);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 35;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.Location = new System.Drawing.Point(498, 58);
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.Size = new System.Drawing.Size(136, 21);
            this.dtpDateBegin.TabIndex = 34;
            // 
            // ckbDateNoteFlag
            // 
            this.ckbDateNoteFlag.AutoSize = true;
            this.ckbDateNoteFlag.Checked = true;
            this.ckbDateNoteFlag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbDateNoteFlag.Location = new System.Drawing.Point(407, 63);
            this.ckbDateNoteFlag.Name = "ckbDateNoteFlag";
            this.ckbDateNoteFlag.Size = new System.Drawing.Size(66, 16);
            this.ckbDateNoteFlag.TabIndex = 33;
            this.ckbDateNoteFlag.Text = "日期 从";
            this.ckbDateNoteFlag.UseVisualStyleBackColor = true;
            // 
            // ctrlExpressID
            // 
            this.ctrlExpressID.AutoSize = true;
            this.ctrlExpressID.CompanyID = 1;
            this.ctrlExpressID.Location = new System.Drawing.Point(279, 61);
            this.ctrlExpressID.Name = "ctrlExpressID";
            this.ctrlExpressID.Size = new System.Drawing.Size(119, 23);
            this.ctrlExpressID.TabIndex = 32;
            // 
            // ckbExpressFlag
            // 
            this.ckbExpressFlag.AutoSize = true;
            this.ckbExpressFlag.Location = new System.Drawing.Point(208, 61);
            this.ckbExpressFlag.Name = "ckbExpressFlag";
            this.ckbExpressFlag.Size = new System.Drawing.Size(72, 16);
            this.ckbExpressFlag.TabIndex = 31;
            this.ckbExpressFlag.Text = "代收物流";
            this.ckbExpressFlag.UseVisualStyleBackColor = true;
            // 
            // ctrlCustomerID
            // 
            this.ctrlCustomerID.CompanyID = 1;
            this.ctrlCustomerID.Location = new System.Drawing.Point(59, 60);
            this.ctrlCustomerID.Name = "ctrlCustomerID";
            this.ctrlCustomerID.Size = new System.Drawing.Size(138, 23);
            this.ctrlCustomerID.TabIndex = 30;
            // 
            // ckbCustomerFlag
            // 
            this.ckbCustomerFlag.AutoSize = true;
            this.ckbCustomerFlag.Location = new System.Drawing.Point(5, 65);
            this.ckbCustomerFlag.Name = "ckbCustomerFlag";
            this.ckbCustomerFlag.Size = new System.Drawing.Size(48, 16);
            this.ckbCustomerFlag.TabIndex = 29;
            this.ckbCustomerFlag.Text = "客户";
            this.ckbCustomerFlag.UseVisualStyleBackColor = true;
            // 
            // txtNoteCode
            // 
            this.txtNoteCode.Location = new System.Drawing.Point(84, 35);
            this.txtNoteCode.Name = "txtNoteCode";
            this.txtNoteCode.Size = new System.Drawing.Size(113, 21);
            this.txtNoteCode.TabIndex = 28;
            // 
            // ckbNoteCodeFlag
            // 
            this.ckbNoteCodeFlag.AutoSize = true;
            this.ckbNoteCodeFlag.Location = new System.Drawing.Point(6, 40);
            this.ckbNoteCodeFlag.Name = "ckbNoteCodeFlag";
            this.ckbNoteCodeFlag.Size = new System.Drawing.Size(72, 16);
            this.ckbNoteCodeFlag.TabIndex = 27;
            this.ckbNoteCodeFlag.Text = "收据单号";
            this.ckbNoteCodeFlag.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(395, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "应收款收据";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Controls.Add(this.pbar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 484);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(918, 30);
            this.panel2.TabIndex = 3;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(5, 3);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(219, 21);
            this.ctrlQFind.TabIndex = 1;
            // 
            // pbar
            // 
            this.pbar.AutoSize = true;
            this.pbar.Location = new System.Drawing.Point(237, 2);
            this.pbar.Margin = new System.Windows.Forms.Padding(0);
            this.pbar.Name = "pbar";
            this.pbar.PageInBlock = 10;
            this.pbar.PageIndex = 1;
            this.pbar.PageSize = 30;
            this.pbar.Size = new System.Drawing.Size(406, 31);
            this.pbar.TabIndex = 0;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNoteCode,
            this.ColumnPONo,
            this.ColumnReconciliationCode,
            this.ColumnDateNote1,
            this.ColumnCompanyAbbName,
            this.ColumnExpressCompanyName,
            this.ColumnMoneyTypeName2,
            this.ColumnTotalAMT1,
            this.ColumnAdvanceAMT,
            this.ColumnAmount,
            this.ColumnMakerPsn,
            this.ColumnSettlePsn,
            this.ColumnSaleDeliverNoteCode,
            this.ColumnRepairDeliverNoteCode,
            this.ColumnBankName,
            this.ColumnBankCode});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 86);
            this.dgrdv.Name = "dgrdv";
            this.dgrdv.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(918, 398);
            this.dgrdv.TabIndex = 7;
            // 
            // ColumnNoteCode
            // 
            this.ColumnNoteCode.DataPropertyName = "NoteCode";
            this.ColumnNoteCode.HeaderText = "收据单号";
            this.ColumnNoteCode.Name = "ColumnNoteCode";
            this.ColumnNoteCode.ReadOnly = true;
            this.ColumnNoteCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnNoteCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnPONo
            // 
            this.ColumnPONo.DataPropertyName = "PONo";
            this.ColumnPONo.HeaderText = "订单编号";
            this.ColumnPONo.Name = "ColumnPONo";
            this.ColumnPONo.ReadOnly = true;
            this.ColumnPONo.Width = 80;
            // 
            // ColumnReconciliationCode
            // 
            this.ColumnReconciliationCode.DataPropertyName = "ReconciliationCode";
            this.ColumnReconciliationCode.HeaderText = "对账单号";
            this.ColumnReconciliationCode.Name = "ColumnReconciliationCode";
            this.ColumnReconciliationCode.ReadOnly = true;
            this.ColumnReconciliationCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnReconciliationCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnDateNote1
            // 
            this.ColumnDateNote1.DataPropertyName = "DateNote";
            this.ColumnDateNote1.HeaderText = "制单日期";
            this.ColumnDateNote1.Name = "ColumnDateNote1";
            this.ColumnDateNote1.ReadOnly = true;
            this.ColumnDateNote1.Width = 80;
            // 
            // ColumnCompanyAbbName
            // 
            this.ColumnCompanyAbbName.DataPropertyName = "CompanyAbbName";
            this.ColumnCompanyAbbName.HeaderText = "客户";
            this.ColumnCompanyAbbName.Name = "ColumnCompanyAbbName";
            this.ColumnCompanyAbbName.ReadOnly = true;
            this.ColumnCompanyAbbName.Width = 80;
            // 
            // ColumnExpressCompanyName
            // 
            this.ColumnExpressCompanyName.DataPropertyName = "ExpressCompanyName";
            this.ColumnExpressCompanyName.HeaderText = "代收物流";
            this.ColumnExpressCompanyName.Name = "ColumnExpressCompanyName";
            this.ColumnExpressCompanyName.ReadOnly = true;
            this.ColumnExpressCompanyName.Width = 78;
            // 
            // ColumnMoneyTypeName2
            // 
            this.ColumnMoneyTypeName2.DataPropertyName = "MoneyTypeName";
            this.ColumnMoneyTypeName2.HeaderText = "币种";
            this.ColumnMoneyTypeName2.Name = "ColumnMoneyTypeName2";
            this.ColumnMoneyTypeName2.ReadOnly = true;
            this.ColumnMoneyTypeName2.Width = 54;
            // 
            // ColumnTotalAMT1
            // 
            this.ColumnTotalAMT1.DataPropertyName = "TotalAMT";
            this.ColumnTotalAMT1.HeaderText = "合计货款";
            this.ColumnTotalAMT1.Name = "ColumnTotalAMT1";
            this.ColumnTotalAMT1.ReadOnly = true;
            this.ColumnTotalAMT1.Width = 80;
            // 
            // ColumnAdvanceAMT
            // 
            this.ColumnAdvanceAMT.DataPropertyName = "AdvanceAMT";
            this.ColumnAdvanceAMT.HeaderText = "结算预收";
            this.ColumnAdvanceAMT.Name = "ColumnAdvanceAMT";
            this.ColumnAdvanceAMT.ReadOnly = true;
            this.ColumnAdvanceAMT.Width = 80;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.DataPropertyName = "Amount";
            this.ColumnAmount.HeaderText = "应结金额";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.ReadOnly = true;
            this.ColumnAmount.Width = 80;
            // 
            // ColumnMakerPsn
            // 
            this.ColumnMakerPsn.DataPropertyName = "MakerPsn";
            this.ColumnMakerPsn.HeaderText = "制单人";
            this.ColumnMakerPsn.Name = "ColumnMakerPsn";
            this.ColumnMakerPsn.ReadOnly = true;
            this.ColumnMakerPsn.Width = 66;
            // 
            // ColumnSettlePsn
            // 
            this.ColumnSettlePsn.DataPropertyName = "SettlePsn";
            this.ColumnSettlePsn.HeaderText = "结款人";
            this.ColumnSettlePsn.Name = "ColumnSettlePsn";
            this.ColumnSettlePsn.ReadOnly = true;
            this.ColumnSettlePsn.Width = 66;
            // 
            // ColumnSaleDeliverNoteCode
            // 
            this.ColumnSaleDeliverNoteCode.DataPropertyName = "SaleDeliverNoteCode";
            this.ColumnSaleDeliverNoteCode.HeaderText = "送货单号";
            this.ColumnSaleDeliverNoteCode.Name = "ColumnSaleDeliverNoteCode";
            this.ColumnSaleDeliverNoteCode.ReadOnly = true;
            this.ColumnSaleDeliverNoteCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSaleDeliverNoteCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnSaleDeliverNoteCode.Width = 80;
            // 
            // ColumnRepairDeliverNoteCode
            // 
            this.ColumnRepairDeliverNoteCode.DataPropertyName = "RepairDeliverNoteCode";
            this.ColumnRepairDeliverNoteCode.HeaderText = "维修单号";
            this.ColumnRepairDeliverNoteCode.Name = "ColumnRepairDeliverNoteCode";
            this.ColumnRepairDeliverNoteCode.ReadOnly = true;
            this.ColumnRepairDeliverNoteCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnRepairDeliverNoteCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnRepairDeliverNoteCode.Width = 80;
            // 
            // ColumnBankName
            // 
            this.ColumnBankName.HeaderText = "银行";
            this.ColumnBankName.Name = "ColumnBankName";
            this.ColumnBankName.ReadOnly = true;
            // 
            // ColumnBankCode
            // 
            this.ColumnBankCode.DataPropertyName = "BankCode";
            this.ColumnBankCode.HeaderText = "银行账号";
            this.ColumnBankCode.Name = "ColumnBankCode";
            this.ColumnBankCode.ReadOnly = true;
            // 
            // FrmReceivableReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 514);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReceivableReceipt";
            this.Text = "FrmReceivableReceipt";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPONo;
        private System.Windows.Forms.CheckBox ckbPONo;
        private System.Windows.Forms.TextBox txtReconciliationCode;
        private System.Windows.Forms.CheckBox ckbReconciliationCodeFlag;
        private System.Windows.Forms.TextBox txtRepairDeliverNoteCode;
        private System.Windows.Forms.CheckBox ckbRepairDeliverNoteFlag;
        private System.Windows.Forms.TextBox txtSaleDeliverNoteCode;
        private System.Windows.Forms.CheckBox ckbSaleDeliverNoteFlag;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.CheckBox ckbDateNoteFlag;
        private JERPApp.Define.General.CtrlExpress ctrlExpressID;
        private System.Windows.Forms.CheckBox ckbExpressFlag;
        private JERPApp.Define.General.CtrlCustomer ctrlCustomerID;
        private System.Windows.Forms.CheckBox ckbCustomerFlag;
        private System.Windows.Forms.TextBox txtNoteCode;
        private System.Windows.Forms.CheckBox ckbNoteCodeFlag;
        private System.Windows.Forms.Panel panel2;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private JCommon.PagebreakNav pbar;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.CheckBox ckbSettleFlag;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton radSettleFlag;
        private System.Windows.Forms.RadioButton radNonSettleFlag;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnNoteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReconciliationCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateNote1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyAbbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpressCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMoneyTypeName2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalAMT1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAdvanceAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMakerPsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSettlePsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSaleDeliverNoteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRepairDeliverNoteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBankName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBankCode;
    }
}