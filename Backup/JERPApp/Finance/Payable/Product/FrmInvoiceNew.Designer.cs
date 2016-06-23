namespace JERPApp.Finance.Payable.Product
{
    partial class FrmInvoiceNew
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
            this.ctrlSupplierID = new JERPApp.Define.General.CtrlSupplierForProduct();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlYear = new JCommon.CtrlYear();
            this.ctrlMonth = new JCommon.CtrlMonth();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInvoiceName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ctrlMoneyTypeID = new JERPApp.Define.Finance.CtrlMoneyType();
            this.ctrlInvoiceTypeID = new JERPApp.Define.Finance.CtrlInvoiceType();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDateNote = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInvoiceCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ctrlSupplierID
            // 
            this.ctrlSupplierID.CompanyID = 6;
            this.ctrlSupplierID.Location = new System.Drawing.Point(59, 15);
            this.ctrlSupplierID.Name = "ctrlSupplierID";
            this.ctrlSupplierID.Size = new System.Drawing.Size(140, 23);
            this.ctrlSupplierID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "供应商";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "年";
            // 
            // ctrlYear
            // 
            this.ctrlYear.AutoSize = true;
            this.ctrlYear.Location = new System.Drawing.Point(59, 44);
            this.ctrlYear.Name = "ctrlYear";
            this.ctrlYear.Size = new System.Drawing.Size(79, 21);
            this.ctrlYear.TabIndex = 3;
            this.ctrlYear.Year = 2015;
            // 
            // ctrlMonth
            // 
            this.ctrlMonth.AutoSize = true;
            this.ctrlMonth.Location = new System.Drawing.Point(175, 44);
            this.ctrlMonth.Month = 7;
            this.ctrlMonth.Name = "ctrlMonth";
            this.ctrlMonth.Size = new System.Drawing.Size(79, 21);
            this.ctrlMonth.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "月";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "标题";
            // 
            // txtInvoiceName
            // 
            this.txtInvoiceName.Location = new System.Drawing.Point(59, 98);
            this.txtInvoiceName.Name = "txtInvoiceName";
            this.txtInvoiceName.Size = new System.Drawing.Size(195, 21);
            this.txtInvoiceName.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "币种";
            // 
            // ctrlMoneyTypeID
            // 
            this.ctrlMoneyTypeID.AutoSize = true;
            this.ctrlMoneyTypeID.Location = new System.Drawing.Point(59, 125);
            this.ctrlMoneyTypeID.MoneyTypeID = 1;
            this.ctrlMoneyTypeID.Name = "ctrlMoneyTypeID";
            this.ctrlMoneyTypeID.Size = new System.Drawing.Size(140, 23);
            this.ctrlMoneyTypeID.TabIndex = 9;
            // 
            // ctrlInvoiceTypeID
            // 
            this.ctrlInvoiceTypeID.InvoiceTypeID = 1;
            this.ctrlInvoiceTypeID.Location = new System.Drawing.Point(267, 125);
            this.ctrlInvoiceTypeID.Name = "ctrlInvoiceTypeID";
            this.ctrlInvoiceTypeID.Size = new System.Drawing.Size(140, 23);
            this.ctrlInvoiceTypeID.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "发票类型";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(208, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "开票日期";
            // 
            // dtpDateNote
            // 
            this.dtpDateNote.Location = new System.Drawing.Point(267, 12);
            this.dtpDateNote.Name = "dtpDateNote";
            this.dtpDateNote.Size = new System.Drawing.Size(140, 21);
            this.dtpDateNote.TabIndex = 13;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(59, 165);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "新增保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "流水单号";
            // 
            // txtInvoiceCode
            // 
            this.txtInvoiceCode.Location = new System.Drawing.Point(59, 71);
            this.txtInvoiceCode.Name = "txtInvoiceCode";
            this.txtInvoiceCode.Size = new System.Drawing.Size(195, 21);
            this.txtInvoiceCode.TabIndex = 16;
            // 
            // FrmInvoiceNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 197);
            this.Controls.Add(this.txtInvoiceCode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpDateNote);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ctrlInvoiceTypeID);
            this.Controls.Add(this.ctrlMoneyTypeID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtInvoiceName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctrlMonth);
            this.Controls.Add(this.ctrlYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlSupplierID);
            this.Name = "FrmInvoiceNew";
            this.Text = "新增发票";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JERPApp.Define.General.CtrlSupplierForProduct ctrlSupplierID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private JCommon.CtrlYear ctrlYear;
        private JCommon.CtrlMonth ctrlMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInvoiceName;
        private System.Windows.Forms.Label label5;
        private JERPApp.Define.Finance.CtrlMoneyType ctrlMoneyTypeID;
        private JERPApp.Define.Finance.CtrlInvoiceType ctrlInvoiceTypeID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDateNote;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtInvoiceCode;
    }
}