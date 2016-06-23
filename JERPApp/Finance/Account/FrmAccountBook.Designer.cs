namespace JERPApp.Finance.Account
{
    partial class FrmAccountBook
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
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ctrlMoneyTypeID = new JERPApp.Define.Finance.CtrlMoneyType();
            this.ColumnSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccountTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccountTitleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDebitAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCreditAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnlnkDetail = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnAccountTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccountTitleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlMoneyTypeID);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 37);
            this.panel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(571, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 39;
            this.label4.Text = "币种";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(317, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "自定义入账";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 435);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(736, 32);
            this.panel2.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(462, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "+项";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(564, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存并入账";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // dgrdv
            // 
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSummary,
            this.ColumnAccountTypeName,
            this.ColumnAccountTitleName,
            this.ColumnDebitAMT,
            this.ColumnCreditAMT,
            this.ColumnlnkDetail,
            this.ColumnAccountTypeID,
            this.ColumnAccountTitleID});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 37);
            this.dgrdv.Name = "dgrdv";
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
            this.dgrdv.Size = new System.Drawing.Size(736, 398);
            this.dgrdv.TabIndex = 16;
            // 
            // ctrlMoneyTypeID
            // 
            this.ctrlMoneyTypeID.AutoSize = true;
            this.ctrlMoneyTypeID.Location = new System.Drawing.Point(606, 9);
            this.ctrlMoneyTypeID.MoneyTypeID = 1;
            this.ctrlMoneyTypeID.Name = "ctrlMoneyTypeID";
            this.ctrlMoneyTypeID.Size = new System.Drawing.Size(100, 23);
            this.ctrlMoneyTypeID.TabIndex = 40;
            // 
            // ColumnSummary
            // 
            this.ColumnSummary.DataPropertyName = "Summary";
            this.ColumnSummary.HeaderText = "摘要";
            this.ColumnSummary.Name = "ColumnSummary";
            this.ColumnSummary.Width = 160;
            // 
            // ColumnAccountTypeName
            // 
            this.ColumnAccountTypeName.DataPropertyName = "AccountTypeName";
            this.ColumnAccountTypeName.HeaderText = "类别";
            this.ColumnAccountTypeName.Name = "ColumnAccountTypeName";
            this.ColumnAccountTypeName.ReadOnly = true;
            this.ColumnAccountTypeName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnAccountTypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnAccountTypeName.Width = 80;
            // 
            // ColumnAccountTitleName
            // 
            this.ColumnAccountTitleName.DataPropertyName = "AccountTitleName";
            this.ColumnAccountTitleName.HeaderText = "明细";
            this.ColumnAccountTitleName.Name = "ColumnAccountTitleName";
            this.ColumnAccountTitleName.ReadOnly = true;
            this.ColumnAccountTitleName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnAccountTitleName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnAccountTitleName.Width = 250;
            // 
            // ColumnDebitAMT
            // 
            this.ColumnDebitAMT.DataPropertyName = "DebitAMT";
            this.ColumnDebitAMT.HeaderText = "借记";
            this.ColumnDebitAMT.Name = "ColumnDebitAMT";
            this.ColumnDebitAMT.Width = 66;
            // 
            // ColumnCreditAMT
            // 
            this.ColumnCreditAMT.DataPropertyName = "CreditAMT";
            this.ColumnCreditAMT.HeaderText = "贷记";
            this.ColumnCreditAMT.Name = "ColumnCreditAMT";
            this.ColumnCreditAMT.Width = 66;
            // 
            // ColumnlnkDetail
            // 
            this.ColumnlnkDetail.HeaderText = "记录";
            this.ColumnlnkDetail.Name = "ColumnlnkDetail";
            this.ColumnlnkDetail.Text = "记录";
            this.ColumnlnkDetail.UseColumnTextForLinkValue = true;
            this.ColumnlnkDetail.Width = 54;
            // 
            // ColumnAccountTypeID
            // 
            this.ColumnAccountTypeID.DataPropertyName = "AccountTypeID";
            this.ColumnAccountTypeID.HeaderText = "AccountTypeID";
            this.ColumnAccountTypeID.Name = "ColumnAccountTypeID";
            this.ColumnAccountTypeID.Visible = false;
            // 
            // ColumnAccountTitleID
            // 
            this.ColumnAccountTitleID.DataPropertyName = "AccountTitleID";
            this.ColumnAccountTitleID.HeaderText = "AccountTitleID";
            this.ColumnAccountTitleID.Name = "ColumnAccountTitleID";
            this.ColumnAccountTitleID.Visible = false;
            // 
            // FrmAccountBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 467);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmAccountBook";
            this.Text = "FrmAccountBook";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private JERPApp.Define.Finance.CtrlMoneyType ctrlMoneyTypeID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccountTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccountTitleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDebitAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCreditAMT;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnlnkDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccountTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccountTitleID;
    }
}