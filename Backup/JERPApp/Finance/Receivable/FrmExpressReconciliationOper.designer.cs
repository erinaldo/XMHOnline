namespace JERPApp.Finance.Receivable
{
    partial class FrmExpressReconciliationOper
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtReconciliationName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMoneyTypeName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDateNote = new System.Windows.Forms.TextBox();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReconciliationCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTotalAMT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageSaleReceipt = new System.Windows.Forms.TabPage();
            this.dgrdvReceipt = new JCommon.MyDataGridView();
            this.ColumnNoteCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyAbbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pageSaleReceipt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvReceipt)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtReconciliationName);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtMoneyTypeName);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtDateNote);
            this.panel1.Controls.Add(this.txtMonth);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtYear);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtCompanyName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtReconciliationCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(765, 54);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(351, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 177;
            this.label1.Text = "代收对账单";
            // 
            // txtReconciliationName
            // 
            this.txtReconciliationName.Location = new System.Drawing.Point(226, 29);
            this.txtReconciliationName.Name = "txtReconciliationName";
            this.txtReconciliationName.Size = new System.Drawing.Size(227, 21);
            this.txtReconciliationName.TabIndex = 176;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(191, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 175;
            this.label7.Text = "标题";
            // 
            // txtMoneyTypeName
            // 
            this.txtMoneyTypeName.Location = new System.Drawing.Point(494, 29);
            this.txtMoneyTypeName.Name = "txtMoneyTypeName";
            this.txtMoneyTypeName.ReadOnly = true;
            this.txtMoneyTypeName.Size = new System.Drawing.Size(73, 21);
            this.txtMoneyTypeName.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(459, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 28;
            this.label11.Text = "币种";
            // 
            // txtDateNote
            // 
            this.txtDateNote.Location = new System.Drawing.Point(626, 28);
            this.txtDateNote.Name = "txtDateNote";
            this.txtDateNote.ReadOnly = true;
            this.txtDateNote.Size = new System.Drawing.Size(112, 21);
            this.txtDateNote.TabIndex = 27;
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(703, 4);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.ReadOnly = true;
            this.txtMonth.Size = new System.Drawing.Size(35, 21);
            this.txtMonth.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(684, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "月";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(633, 4);
            this.txtYear.Name = "txtYear";
            this.txtYear.ReadOnly = true;
            this.txtYear.Size = new System.Drawing.Size(45, 21);
            this.txtYear.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(610, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "年";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(68, 28);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.ReadOnly = true;
            this.txtCompanyName.Size = new System.Drawing.Size(116, 21);
            this.txtCompanyName.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "代收物流";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(573, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "制单日期";
            // 
            // txtReconciliationCode
            // 
            this.txtReconciliationCode.Location = new System.Drawing.Point(68, 4);
            this.txtReconciliationCode.Name = "txtReconciliationCode";
            this.txtReconciliationCode.ReadOnly = true;
            this.txtReconciliationCode.Size = new System.Drawing.Size(115, 21);
            this.txtReconciliationCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "对账单号";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.txtTotalAMT);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 541);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(765, 35);
            this.panel2.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(663, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 173;
            this.btnExport.Text = "打印输出";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(508, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // txtTotalAMT
            // 
            this.txtTotalAMT.Location = new System.Drawing.Point(418, 6);
            this.txtTotalAMT.Name = "txtTotalAMT";
            this.txtTotalAMT.ReadOnly = true;
            this.txtTotalAMT.Size = new System.Drawing.Size(82, 21);
            this.txtTotalAMT.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(341, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 32;
            this.label3.Text = "合计金额";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(589, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(68, 23);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pageSaleReceipt);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 54);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(765, 487);
            this.tabMain.TabIndex = 5;
            // 
            // pageSaleReceipt
            // 
            this.pageSaleReceipt.Controls.Add(this.dgrdvReceipt);
            this.pageSaleReceipt.Location = new System.Drawing.Point(4, 22);
            this.pageSaleReceipt.Name = "pageSaleReceipt";
            this.pageSaleReceipt.Padding = new System.Windows.Forms.Padding(3);
            this.pageSaleReceipt.Size = new System.Drawing.Size(757, 461);
            this.pageSaleReceipt.TabIndex = 0;
            this.pageSaleReceipt.Text = "送货";
            this.pageSaleReceipt.UseVisualStyleBackColor = true;
            // 
            // dgrdvReceipt
            // 
            this.dgrdvReceipt.AllowUserToAddRows = false;
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
            this.dgrdvReceipt.Location = new System.Drawing.Point(3, 3);
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
            this.dgrdvReceipt.Size = new System.Drawing.Size(751, 455);
            this.dgrdvReceipt.TabIndex = 5;
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
            // FrmExpressReconciliationOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 576);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmExpressReconciliationOper";
            this.Text = "代收对账单";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.pageSaleReceipt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvReceipt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtReconciliationCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMoneyTypeName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDateNote;
        private System.Windows.Forms.TextBox txtTotalAMT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageSaleReceipt;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtReconciliationName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private JCommon.MyDataGridView dgrdvReceipt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNoteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyAbbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
    }
}