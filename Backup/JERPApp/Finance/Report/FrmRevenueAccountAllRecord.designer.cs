namespace JERPApp.Finance.Report
{
    partial class FrmRevenueAccountAllRecord
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnDateRegister = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRevenueTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDebitAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCreditAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRegisterPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExport = new System.Windows.Forms.Button();
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
            this.panel1.Size = new System.Drawing.Size(682, 29);
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
            this.ColumnRevenueTypeName,
            this.ColumnDebitAMT,
            this.ColumnCreditAMT,
            this.ColumnRegisterPsn});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 0);
            this.dgrdv.Name = "dgrdv";
            this.dgrdv.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(682, 461);
            this.dgrdv.TabIndex = 17;
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
            // ColumnRevenueTypeName
            // 
            this.ColumnRevenueTypeName.DataPropertyName = "RevenueTypeName";
            this.ColumnRevenueTypeName.HeaderText = "类型";
            this.ColumnRevenueTypeName.Name = "ColumnRevenueTypeName";
            this.ColumnRevenueTypeName.ReadOnly = true;
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
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(267, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "输出Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // FrmRevenueAccountAllRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 490);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel1);
            this.Name = "FrmRevenueAccountAllRecord";
            this.Text = "收入记录";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateRegister;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRevenueTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDebitAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCreditAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRegisterPsn;
        private System.Windows.Forms.Button btnExport;
    }
}