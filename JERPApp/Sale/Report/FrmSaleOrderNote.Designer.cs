namespace JERPApp.Sale.Report
{
    partial class FrmSaleOrderNote
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
            this.ctrlMoneyTypeID = new JERPApp.Define.Finance.CtrlMoneyType();
            this.ckbMoneyType = new System.Windows.Forms.CheckBox();
            this.ctrlCustomerID = new JERPApp.Define.General.CtrlCustomer();
            this.ckbCustomer = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radNonFinished = new System.Windows.Forms.RadioButton();
            this.radFinishedFlag = new System.Windows.Forms.RadioButton();
            this.ckbFinished = new System.Windows.Forms.CheckBox();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbDateNote = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbar = new JCommon.PagebreakNav();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnNoteCode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnPONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyAbbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalePsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFinishedFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnMoneyTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotalAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAdvanceAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSettleTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDeliverNoteAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFinishedAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPriceTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMakerPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlMoneyTypeID);
            this.panel1.Controls.Add(this.ckbMoneyType);
            this.panel1.Controls.Add(this.ctrlCustomerID);
            this.panel1.Controls.Add(this.ckbCustomer);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.ckbFinished);
            this.panel1.Controls.Add(this.dtpDateEnd);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpDateBegin);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ckbDateNote);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1046, 57);
            this.panel1.TabIndex = 0;
            // 
            // ctrlMoneyTypeID
            // 
            this.ctrlMoneyTypeID.AutoSize = true;
            this.ctrlMoneyTypeID.Location = new System.Drawing.Point(660, 31);
            this.ctrlMoneyTypeID.MoneyTypeID = 1;
            this.ctrlMoneyTypeID.Name = "ctrlMoneyTypeID";
            this.ctrlMoneyTypeID.Size = new System.Drawing.Size(140, 23);
            this.ctrlMoneyTypeID.TabIndex = 12;
            // 
            // ckbMoneyType
            // 
            this.ckbMoneyType.AutoSize = true;
            this.ckbMoneyType.Location = new System.Drawing.Point(606, 35);
            this.ckbMoneyType.Name = "ckbMoneyType";
            this.ckbMoneyType.Size = new System.Drawing.Size(48, 16);
            this.ckbMoneyType.TabIndex = 11;
            this.ckbMoneyType.Text = "币种";
            this.ckbMoneyType.UseVisualStyleBackColor = true;
            // 
            // ctrlCustomerID
            // 
            this.ctrlCustomerID.CompanyID = 1;
            this.ctrlCustomerID.Location = new System.Drawing.Point(460, 31);
            this.ctrlCustomerID.Name = "ctrlCustomerID";
            this.ctrlCustomerID.Size = new System.Drawing.Size(140, 23);
            this.ctrlCustomerID.TabIndex = 10;
            // 
            // ckbCustomer
            // 
            this.ckbCustomer.AutoSize = true;
            this.ckbCustomer.Location = new System.Drawing.Point(406, 34);
            this.ckbCustomer.Name = "ckbCustomer";
            this.ckbCustomer.Size = new System.Drawing.Size(48, 16);
            this.ckbCustomer.TabIndex = 9;
            this.ckbCustomer.Text = "客户";
            this.ckbCustomer.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(815, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radNonFinished);
            this.panel3.Controls.Add(this.radFinishedFlag);
            this.panel3.Location = new System.Drawing.Point(72, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(132, 22);
            this.panel3.TabIndex = 7;
            // 
            // radNonFinished
            // 
            this.radNonFinished.AutoSize = true;
            this.radNonFinished.Checked = true;
            this.radNonFinished.Location = new System.Drawing.Point(3, 3);
            this.radNonFinished.Name = "radNonFinished";
            this.radNonFinished.Size = new System.Drawing.Size(59, 16);
            this.radNonFinished.TabIndex = 1;
            this.radNonFinished.TabStop = true;
            this.radNonFinished.Text = "未完成";
            this.radNonFinished.UseVisualStyleBackColor = true;
            // 
            // radFinishedFlag
            // 
            this.radFinishedFlag.AutoSize = true;
            this.radFinishedFlag.Location = new System.Drawing.Point(65, 3);
            this.radFinishedFlag.Name = "radFinishedFlag";
            this.radFinishedFlag.Size = new System.Drawing.Size(47, 16);
            this.radFinishedFlag.TabIndex = 0;
            this.radFinishedFlag.Text = "完成";
            this.radFinishedFlag.UseVisualStyleBackColor = true;
            // 
            // ckbFinished
            // 
            this.ckbFinished.AutoSize = true;
            this.ckbFinished.Location = new System.Drawing.Point(17, 9);
            this.ckbFinished.Name = "ckbFinished";
            this.ckbFinished.Size = new System.Drawing.Size(48, 16);
            this.ckbFinished.TabIndex = 6;
            this.ckbFinished.Text = "完成";
            this.ckbFinished.UseVisualStyleBackColor = true;
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Location = new System.Drawing.Point(257, 29);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(140, 21);
            this.dtpDateEnd.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "从";
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.Location = new System.Drawing.Point(88, 30);
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.Size = new System.Drawing.Size(140, 21);
            this.dtpDateBegin.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "从";
            // 
            // ckbDateNote
            // 
            this.ckbDateNote.AutoSize = true;
            this.ckbDateNote.Checked = true;
            this.ckbDateNote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbDateNote.Location = new System.Drawing.Point(17, 35);
            this.ckbDateNote.Name = "ckbDateNote";
            this.ckbDateNote.Size = new System.Drawing.Size(48, 16);
            this.ckbDateNote.TabIndex = 1;
            this.ckbDateNote.Text = "日期";
            this.ckbDateNote.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(510, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "销售订单一览";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pbar);
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 503);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1046, 37);
            this.panel2.TabIndex = 1;
            // 
            // pbar
            // 
            this.pbar.AutoSize = true;
            this.pbar.Location = new System.Drawing.Point(257, 6);
            this.pbar.Name = "pbar";
            this.pbar.PageInBlock = 10;
            this.pbar.PageIndex = 0;
            this.pbar.PageSize = 100;
            this.pbar.Size = new System.Drawing.Size(406, 27);
            this.pbar.TabIndex = 3;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(7, 8);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(244, 21);
            this.ctrlQFind.TabIndex = 2;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNoteCode,
            this.ColumnPONo,
            this.ColumnCompanyAbbName,
            this.ColumnAreaName,
            this.ColumnDateNote,
            this.ColumnSalePsn,
            this.ColumnFinishedFlag,
            this.ColumnMoneyTypeName,
            this.ColumnTotalAMT,
            this.ColumnAdvanceAMT,
            this.ColumnSettleTypeName,
            this.ColumnDeliverNoteAMT,
            this.ColumnFinishedAMT,
            this.ColumnPriceTypeName,
            this.ColumnMemo,
            this.ColumnMakerPsn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 57);
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
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(1046, 446);
            this.dgrdv.TabIndex = 8;
            // 
            // ColumnNoteCode
            // 
            this.ColumnNoteCode.DataPropertyName = "NoteCode";
            this.ColumnNoteCode.HeaderText = "订单流水";
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
            // 
            // ColumnCompanyAbbName
            // 
            this.ColumnCompanyAbbName.DataPropertyName = "CompanyAbbName";
            this.ColumnCompanyAbbName.HeaderText = "客户";
            this.ColumnCompanyAbbName.Name = "ColumnCompanyAbbName";
            this.ColumnCompanyAbbName.ReadOnly = true;
            this.ColumnCompanyAbbName.Width = 80;
            // 
            // ColumnAreaName
            // 
            this.ColumnAreaName.DataPropertyName = "AreaName";
            this.ColumnAreaName.HeaderText = "区域";
            this.ColumnAreaName.Name = "ColumnAreaName";
            this.ColumnAreaName.ReadOnly = true;
            this.ColumnAreaName.Width = 66;
            // 
            // ColumnDateNote
            // 
            this.ColumnDateNote.DataPropertyName = "DateNote";
            this.ColumnDateNote.HeaderText = "日期";
            this.ColumnDateNote.Name = "ColumnDateNote";
            this.ColumnDateNote.ReadOnly = true;
            this.ColumnDateNote.Width = 80;
            // 
            // ColumnSalePsn
            // 
            this.ColumnSalePsn.DataPropertyName = "SalePsn";
            this.ColumnSalePsn.HeaderText = "业务员";
            this.ColumnSalePsn.Name = "ColumnSalePsn";
            this.ColumnSalePsn.ReadOnly = true;
            this.ColumnSalePsn.Width = 66;
            // 
            // ColumnFinishedFlag
            // 
            this.ColumnFinishedFlag.DataPropertyName = "FinishedFlag";
            this.ColumnFinishedFlag.HeaderText = "完成";
            this.ColumnFinishedFlag.Name = "ColumnFinishedFlag";
            this.ColumnFinishedFlag.ReadOnly = true;
            this.ColumnFinishedFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnFinishedFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnFinishedFlag.Width = 54;
            // 
            // ColumnMoneyTypeName
            // 
            this.ColumnMoneyTypeName.DataPropertyName = "MoneyTypeName";
            this.ColumnMoneyTypeName.HeaderText = "币种";
            this.ColumnMoneyTypeName.Name = "ColumnMoneyTypeName";
            this.ColumnMoneyTypeName.ReadOnly = true;
            this.ColumnMoneyTypeName.Width = 54;
            // 
            // ColumnTotalAMT
            // 
            this.ColumnTotalAMT.DataPropertyName = "TotalAMT";
            this.ColumnTotalAMT.HeaderText = "订单金额";
            this.ColumnTotalAMT.Name = "ColumnTotalAMT";
            this.ColumnTotalAMT.ReadOnly = true;
            this.ColumnTotalAMT.Width = 80;
            // 
            // ColumnAdvanceAMT
            // 
            this.ColumnAdvanceAMT.DataPropertyName = "AdvanceAMT";
            this.ColumnAdvanceAMT.HeaderText = "预收款";
            this.ColumnAdvanceAMT.Name = "ColumnAdvanceAMT";
            this.ColumnAdvanceAMT.ReadOnly = true;
            this.ColumnAdvanceAMT.Width = 66;
            // 
            // ColumnSettleTypeName
            // 
            this.ColumnSettleTypeName.DataPropertyName = "SettleTypeName";
            this.ColumnSettleTypeName.HeaderText = "结算方式";
            this.ColumnSettleTypeName.Name = "ColumnSettleTypeName";
            this.ColumnSettleTypeName.ReadOnly = true;
            this.ColumnSettleTypeName.Width = 80;
            // 
            // ColumnDeliverNoteAMT
            // 
            this.ColumnDeliverNoteAMT.DataPropertyName = "DeliverNoteAMT";
            this.ColumnDeliverNoteAMT.HeaderText = "送货金额";
            this.ColumnDeliverNoteAMT.Name = "ColumnDeliverNoteAMT";
            this.ColumnDeliverNoteAMT.ReadOnly = true;
            this.ColumnDeliverNoteAMT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnDeliverNoteAMT.Width = 80;
            // 
            // ColumnFinishedAMT
            // 
            this.ColumnFinishedAMT.DataPropertyName = "FinishedAMT";
            this.ColumnFinishedAMT.HeaderText = "收据金额";
            this.ColumnFinishedAMT.Name = "ColumnFinishedAMT";
            this.ColumnFinishedAMT.ReadOnly = true;
            this.ColumnFinishedAMT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnFinishedAMT.Width = 80;
            // 
            // ColumnPriceTypeName
            // 
            this.ColumnPriceTypeName.DataPropertyName = "PriceTypeName";
            this.ColumnPriceTypeName.HeaderText = "含税";
            this.ColumnPriceTypeName.Name = "ColumnPriceTypeName";
            this.ColumnPriceTypeName.ReadOnly = true;
            this.ColumnPriceTypeName.Width = 66;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.ReadOnly = true;
            this.ColumnMemo.Width = 120;
            // 
            // ColumnMakerPsn
            // 
            this.ColumnMakerPsn.DataPropertyName = "MakerPsn";
            this.ColumnMakerPsn.HeaderText = "制单员";
            this.ColumnMakerPsn.Name = "ColumnMakerPsn";
            this.ColumnMakerPsn.ReadOnly = true;
            this.ColumnMakerPsn.Width = 66;
            // 
            // FrmSaleOrderNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 540);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSaleOrderNote";
            this.Text = "FrmSaleOrderNote";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckbDateNote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radNonFinished;
        private System.Windows.Forms.RadioButton radFinishedFlag;
        private System.Windows.Forms.CheckBox ckbFinished;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.Label label3;
        private JCommon.MyDataGridView dgrdv;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private JERPApp.Define.General.CtrlCustomer ctrlCustomerID;
        private System.Windows.Forms.CheckBox ckbCustomer;
        private JERPApp.Define.Finance.CtrlMoneyType ctrlMoneyTypeID;
        private System.Windows.Forms.CheckBox ckbMoneyType;
        private JCommon.PagebreakNav pbar;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnNoteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyAbbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAreaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalePsn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnFinishedFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMoneyTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAdvanceAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSettleTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeliverNoteAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFinishedAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPriceTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMakerPsn;
    }
}