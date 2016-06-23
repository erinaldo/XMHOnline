namespace JERPApp.Finance.Report
{
    partial class FrmExpenseAccountAllRecord
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
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.dgrdv = new JCommon.MyDataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.ColumnDateRegister = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpenseTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDebitAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCreditAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRegisterPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.ctrlQFind);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 461);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 29);
            this.panel1.TabIndex = 0;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(3, 3);
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
            this.ColumnExpenseTypeName,
            this.ColumnDebitAMT,
            this.ColumnCreditAMT,
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
            this.dgrdv.Location = new System.Drawing.Point(0, 0);
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
            this.dgrdv.Size = new System.Drawing.Size(665, 461);
            this.dgrdv.TabIndex = 16;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(257, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "输出Excel";
            this.btnExport.UseVisualStyleBackColor = true;
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
            this.ColumnSummary.Width = 160;
            // 
            // ColumnExpenseTypeName
            // 
            this.ColumnExpenseTypeName.DataPropertyName = "ExpenseTypeName";
            this.ColumnExpenseTypeName.HeaderText = "类型";
            this.ColumnExpenseTypeName.Name = "ColumnExpenseTypeName";
            this.ColumnExpenseTypeName.ReadOnly = true;
            // 
            // ColumnDebitAMT
            // 
            this.ColumnDebitAMT.DataPropertyName = "DebitAMT";
            this.ColumnDebitAMT.HeaderText = "借记金额";
            this.ColumnDebitAMT.Name = "ColumnDebitAMT";
            this.ColumnDebitAMT.ReadOnly = true;
            this.ColumnDebitAMT.Width = 80;
            // 
            // ColumnCreditAMT
            // 
            this.ColumnCreditAMT.DataPropertyName = "CreditAMT";
            this.ColumnCreditAMT.HeaderText = "贷记金额";
            this.ColumnCreditAMT.Name = "ColumnCreditAMT";
            this.ColumnCreditAMT.ReadOnly = true;
            this.ColumnCreditAMT.Width = 80;
            // 
            // ColumnRegisterPsn
            // 
            this.ColumnRegisterPsn.DataPropertyName = "RegisterPsn";
            this.ColumnRegisterPsn.HeaderText = "登记人";
            this.ColumnRegisterPsn.Name = "ColumnRegisterPsn";
            this.ColumnRegisterPsn.ReadOnly = true;
            this.ColumnRegisterPsn.Width = 66;
            // 
            // FrmExpenseAccountAllRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 490);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel1);
            this.Name = "FrmExpenseAccountAllRecord";
            this.Text = "费用记录";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateRegister;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpenseTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDebitAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCreditAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRegisterPsn;
    }
}