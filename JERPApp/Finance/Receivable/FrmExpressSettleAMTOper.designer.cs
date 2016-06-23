namespace JERPApp.Finance.Receivable
{
    partial class FrmExpressSettleAMTOper
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
            this.txtReceiptCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReconciliationName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMoneyTypeName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDateNote = new System.Windows.Forms.TextBox();
            this.txtCompanyAbbName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReconciliationCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSettleAMT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNonFinishedAMT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgrdvReceipt = new JCommon.MyDataGridView();
            this.ColumnNoteCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyAbbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvReceipt)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtReceiptCode);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtReconciliationName);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtMoneyTypeName);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtMonth);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtYear);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtDateNote);
            this.panel1.Controls.Add(this.txtCompanyAbbName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtReconciliationCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 58);
            this.panel1.TabIndex = 1;
            // 
            // txtReceiptCode
            // 
            this.txtReceiptCode.Location = new System.Drawing.Point(247, 4);
            this.txtReceiptCode.Name = "txtReceiptCode";
            this.txtReceiptCode.Size = new System.Drawing.Size(114, 21);
            this.txtReceiptCode.TabIndex = 188;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(187, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 187;
            this.label7.Text = "收据单号";
            // 
            // txtReconciliationName
            // 
            this.txtReconciliationName.Location = new System.Drawing.Point(217, 29);
            this.txtReconciliationName.Name = "txtReconciliationName";
            this.txtReconciliationName.ReadOnly = true;
            this.txtReconciliationName.Size = new System.Drawing.Size(290, 21);
            this.txtReconciliationName.TabIndex = 182;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(188, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 181;
            this.label15.Text = "标题";
            // 
            // txtMoneyTypeName
            // 
            this.txtMoneyTypeName.Location = new System.Drawing.Point(548, 29);
            this.txtMoneyTypeName.Name = "txtMoneyTypeName";
            this.txtMoneyTypeName.ReadOnly = true;
            this.txtMoneyTypeName.Size = new System.Drawing.Size(83, 21);
            this.txtMoneyTypeName.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(510, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 27;
            this.label11.Text = "币种";
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(790, 5);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.ReadOnly = true;
            this.txtMonth.Size = new System.Drawing.Size(34, 21);
            this.txtMonth.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(767, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "月";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(711, 5);
            this.txtYear.Name = "txtYear";
            this.txtYear.ReadOnly = true;
            this.txtYear.Size = new System.Drawing.Size(50, 21);
            this.txtYear.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(688, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "年";
            // 
            // txtDateNote
            // 
            this.txtDateNote.Location = new System.Drawing.Point(708, 29);
            this.txtDateNote.Name = "txtDateNote";
            this.txtDateNote.ReadOnly = true;
            this.txtDateNote.Size = new System.Drawing.Size(116, 21);
            this.txtDateNote.TabIndex = 14;
            // 
            // txtCompanyAbbName
            // 
            this.txtCompanyAbbName.Location = new System.Drawing.Point(66, 30);
            this.txtCompanyAbbName.Name = "txtCompanyAbbName";
            this.txtCompanyAbbName.ReadOnly = true;
            this.txtCompanyAbbName.Size = new System.Drawing.Size(116, 21);
            this.txtCompanyAbbName.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "物流公司";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(637, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "制单日期";
            // 
            // txtReconciliationCode
            // 
            this.txtReconciliationCode.Location = new System.Drawing.Point(66, 3);
            this.txtReconciliationCode.Name = "txtReconciliationCode";
            this.txtReconciliationCode.ReadOnly = true;
            this.txtReconciliationCode.Size = new System.Drawing.Size(117, 21);
            this.txtReconciliationCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "对账单号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(395, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "代收结款";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtSettleAMT);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtNonFinishedAMT);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 543);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(837, 32);
            this.panel2.TabIndex = 2;
            // 
            // txtSettleAMT
            // 
            this.txtSettleAMT.Location = new System.Drawing.Point(217, 4);
            this.txtSettleAMT.Name = "txtSettleAMT";
            this.txtSettleAMT.Size = new System.Drawing.Size(91, 21);
            this.txtSettleAMT.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 36;
            this.label5.Text = "本次结款";
            // 
            // txtNonFinishedAMT
            // 
            this.txtNonFinishedAMT.Location = new System.Drawing.Point(56, 4);
            this.txtNonFinishedAMT.Name = "txtNonFinishedAMT";
            this.txtNonFinishedAMT.ReadOnly = true;
            this.txtNonFinishedAMT.Size = new System.Drawing.Size(85, 21);
            this.txtNonFinishedAMT.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 34;
            this.label3.Text = "合计未结";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(350, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "结款保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // dgrdvReceipt
            // 
            this.dgrdvReceipt.AllowUserToAddRows = false;
            this.dgrdvReceipt.AllowUserToDeleteRows = false;
            this.dgrdvReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvReceipt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNoteCode,
            this.dataGridViewTextBoxColumn9,
            this.ColumnCompanyAbbName,
            this.ColumnAmount});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvReceipt.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdvReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvReceipt.Location = new System.Drawing.Point(0, 58);
            this.dgrdvReceipt.Name = "dgrdvReceipt";
            this.dgrdvReceipt.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvReceipt.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdvReceipt.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdvReceipt.RowTemplate.Height = 23;
            this.dgrdvReceipt.Size = new System.Drawing.Size(837, 485);
            this.dgrdvReceipt.TabIndex = 6;
            // 
            // ColumnNoteCode
            // 
            this.ColumnNoteCode.DataPropertyName = "NoteCode";
            this.ColumnNoteCode.HeaderText = "收据单号";
            this.ColumnNoteCode.Name = "ColumnNoteCode";
            this.ColumnNoteCode.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "DateNote";
            this.dataGridViewTextBoxColumn9.HeaderText = "制单日期";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // ColumnCompanyAbbName
            // 
            this.ColumnCompanyAbbName.DataPropertyName = "CompanyAbbName";
            this.ColumnCompanyAbbName.HeaderText = "客户";
            this.ColumnCompanyAbbName.Name = "ColumnCompanyAbbName";
            this.ColumnCompanyAbbName.ReadOnly = true;
            this.ColumnCompanyAbbName.Width = 80;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.DataPropertyName = "Amount";
            this.ColumnAmount.HeaderText = "代收金额";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.ReadOnly = true;
            this.ColumnAmount.Width = 78;
            // 
            // FrmExpressSettleAMTOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 575);
            this.Controls.Add(this.dgrdvReceipt);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmExpressSettleAMTOper";
            this.Text = "代收结款";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvReceipt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCompanyAbbName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtReconciliationCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDateNote;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMoneyTypeName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNonFinishedAMT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSettleAMT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReconciliationName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtReceiptCode;
        private System.Windows.Forms.Label label7;
        private JCommon.MyDataGridView dgrdvReceipt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNoteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyAbbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
    }
}