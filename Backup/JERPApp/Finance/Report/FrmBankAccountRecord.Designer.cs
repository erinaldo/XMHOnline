namespace JERPApp.Finance.Report
{
    partial class FrmBankAccountRecord
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnDateRegister = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDebitAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCreditAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBalanceAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRegisterPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.ctrlBankID = new JERPApp.Define.Finance.CtrlBank();
            this.ctrlMoneyTypeID = new JERPApp.Define.Finance.CtrlMoneyType();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlBankID);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.ctrlMoneyTypeID);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpDateEnd);
            this.panel1.Controls.Add(this.dtpDateBegin);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(751, 52);
            this.panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(695, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(56, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(271, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "币种";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(555, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "-";
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.CustomFormat = "yyyy-MM-dd H:mm";
            this.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateEnd.Location = new System.Drawing.Point(569, 27);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(126, 21);
            this.dtpDateEnd.TabIndex = 3;
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.CustomFormat = "yyyy-MM-dd H:mm";
            this.dtpDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateBegin.Location = new System.Drawing.Point(425, 27);
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.Size = new System.Drawing.Size(126, 21);
            this.dtpDateBegin.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(343, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "银行存款记录";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 456);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(751, 34);
            this.panel2.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(250, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "输出Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(0, 6);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(244, 21);
            this.ctrlQFind.TabIndex = 0;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDateRegister,
            this.ColumnSummary,
            this.ColumnDebitAMT,
            this.ColumnCreditAMT,
            this.ColumnBalanceAMT,
            this.ColumnRegisterPsn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 52);
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
            this.dgrdv.Size = new System.Drawing.Size(751, 404);
            this.dgrdv.TabIndex = 2;
            // 
            // ColumnDateRegister
            // 
            this.ColumnDateRegister.DataPropertyName = "DateRegister";
            this.ColumnDateRegister.HeaderText = "日期";
            this.ColumnDateRegister.Name = "ColumnDateRegister";
            this.ColumnDateRegister.ReadOnly = true;
            this.ColumnDateRegister.Width = 120;
            // 
            // ColumnSummary
            // 
            this.ColumnSummary.DataPropertyName = "Summary";
            this.ColumnSummary.HeaderText = "摘要";
            this.ColumnSummary.Name = "ColumnSummary";
            this.ColumnSummary.ReadOnly = true;
            this.ColumnSummary.Width = 200;
            // 
            // ColumnDebitAMT
            // 
            this.ColumnDebitAMT.DataPropertyName = "DebitAMT";
            this.ColumnDebitAMT.HeaderText = "借记金额";
            this.ColumnDebitAMT.Name = "ColumnDebitAMT";
            this.ColumnDebitAMT.ReadOnly = true;
            // 
            // ColumnCreditAMT
            // 
            this.ColumnCreditAMT.DataPropertyName = "CreditAMT";
            this.ColumnCreditAMT.HeaderText = "贷记金额";
            this.ColumnCreditAMT.Name = "ColumnCreditAMT";
            this.ColumnCreditAMT.ReadOnly = true;
            // 
            // ColumnBalanceAMT
            // 
            this.ColumnBalanceAMT.DataPropertyName = "BalanceAMT";
            this.ColumnBalanceAMT.HeaderText = "账目余额";
            this.ColumnBalanceAMT.Name = "ColumnBalanceAMT";
            this.ColumnBalanceAMT.ReadOnly = true;
            // 
            // ColumnRegisterPsn
            // 
            this.ColumnRegisterPsn.DataPropertyName = "RegisterPsn";
            this.ColumnRegisterPsn.HeaderText = "登记人";
            this.ColumnRegisterPsn.Name = "ColumnRegisterPsn";
            this.ColumnRegisterPsn.ReadOnly = true;
            this.ColumnRegisterPsn.Width = 66;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "银行";
            // 
            // ctrlBankID
            // 
            this.ctrlBankID.BankID = 1;
            this.ctrlBankID.Location = new System.Drawing.Point(38, 27);
            this.ctrlBankID.Name = "ctrlBankID";
            this.ctrlBankID.Size = new System.Drawing.Size(230, 23);
            this.ctrlBankID.TabIndex = 11;
            // 
            // ctrlMoneyTypeID
            // 
            this.ctrlMoneyTypeID.AutoSize = true;
            this.ctrlMoneyTypeID.Location = new System.Drawing.Point(300, 27);
            this.ctrlMoneyTypeID.MoneyTypeID = 1;
            this.ctrlMoneyTypeID.Name = "ctrlMoneyTypeID";
            this.ctrlMoneyTypeID.Size = new System.Drawing.Size(86, 23);
            this.ctrlMoneyTypeID.TabIndex = 8;
            // 
            // FrmBankAccountRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 490);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBankAccountRecord";
            this.Text = "银行存款记录";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private JERPApp.Define.Finance.CtrlMoneyType ctrlMoneyTypeID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateRegister;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDebitAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCreditAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBalanceAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRegisterPsn;
        private JERPApp.Define.Finance.CtrlBank ctrlBankID;
        private System.Windows.Forms.Label label6;
    }
}