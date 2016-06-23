namespace JERPApp.Finance.Receivable
{
    partial class FrmSaleFineAMTOper
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
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radPayableFlag = new System.Windows.Forms.RadioButton();
            this.txtNoteCode = new System.Windows.Forms.TextBox();
            this.radCashSettleFlag = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.dtpDateNote = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.ctrlMoneyTypeID = new JERPApp.Define.Finance.CtrlMoneyType();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.ctrlCustomerID = new JERPApp.Define.General.CtrlCustomer();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 131;
            this.label4.Text = "客户";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 144;
            this.label6.Text = "结算方式";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 129;
            this.label2.Text = "扣款单号";
            // 
            // radPayableFlag
            // 
            this.radPayableFlag.AutoSize = true;
            this.radPayableFlag.Checked = true;
            this.radPayableFlag.Location = new System.Drawing.Point(113, 184);
            this.radPayableFlag.Name = "radPayableFlag";
            this.radPayableFlag.Size = new System.Drawing.Size(47, 16);
            this.radPayableFlag.TabIndex = 143;
            this.radPayableFlag.TabStop = true;
            this.radPayableFlag.Text = "月结";
            this.radPayableFlag.UseVisualStyleBackColor = true;
            // 
            // txtNoteCode
            // 
            this.txtNoteCode.Location = new System.Drawing.Point(61, 5);
            this.txtNoteCode.Name = "txtNoteCode";
            this.txtNoteCode.Size = new System.Drawing.Size(143, 21);
            this.txtNoteCode.TabIndex = 130;
            // 
            // radCashSettleFlag
            // 
            this.radCashSettleFlag.AutoSize = true;
            this.radCashSettleFlag.Location = new System.Drawing.Point(60, 184);
            this.radCashSettleFlag.Name = "radCashSettleFlag";
            this.radCashSettleFlag.Size = new System.Drawing.Size(47, 16);
            this.radCashSettleFlag.TabIndex = 142;
            this.radCashSettleFlag.Text = "现结";
            this.radCashSettleFlag.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(215, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 132;
            this.label5.Text = "币种";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(374, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 133;
            this.label7.Text = "扣款款";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 141;
            this.label3.Text = "日期";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(421, 32);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(88, 21);
            this.txtAmount.TabIndex = 134;
            // 
            // dtpDateNote
            // 
            this.dtpDateNote.Location = new System.Drawing.Point(266, 6);
            this.dtpDateNote.Name = "dtpDateNote";
            this.dtpDateNote.Size = new System.Drawing.Size(126, 21);
            this.dtpDateNote.TabIndex = 140;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 135;
            this.label8.Text = "摘要";
            // 
            // ctrlMoneyTypeID
            // 
            this.ctrlMoneyTypeID.AutoSize = true;
            this.ctrlMoneyTypeID.Location = new System.Drawing.Point(255, 33);
            this.ctrlMoneyTypeID.MoneyTypeID = 1;
            this.ctrlMoneyTypeID.Name = "ctrlMoneyTypeID";
            this.ctrlMoneyTypeID.Size = new System.Drawing.Size(111, 23);
            this.ctrlMoneyTypeID.TabIndex = 139;
            // 
            // txtSummary
            // 
            this.txtSummary.Location = new System.Drawing.Point(61, 65);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSummary.Size = new System.Drawing.Size(448, 107);
            this.txtSummary.TabIndex = 136;
            // 
            // ctrlCustomerID
            // 
            this.ctrlCustomerID.CompanyID = 1;
            this.ctrlCustomerID.Location = new System.Drawing.Point(61, 32);
            this.ctrlCustomerID.Name = "ctrlCustomerID";
            this.ctrlCustomerID.Size = new System.Drawing.Size(143, 23);
            this.ctrlCustomerID.TabIndex = 138;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(353, 184);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 137;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(434, 184);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 149;
            this.btnNew.Text = "新增";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // FrmSaleFineAMTOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 231);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radPayableFlag);
            this.Controls.Add(this.txtNoteCode);
            this.Controls.Add(this.radCashSettleFlag);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.dtpDateNote);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ctrlMoneyTypeID);
            this.Controls.Add(this.txtSummary);
            this.Controls.Add(this.ctrlCustomerID);
            this.Controls.Add(this.btnSave);
            this.Name = "FrmSaleFineAMTOper";
            this.Text = "销售扣款";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radPayableFlag;
        private System.Windows.Forms.TextBox txtNoteCode;
        private System.Windows.Forms.RadioButton radCashSettleFlag;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.DateTimePicker dtpDateNote;
        private System.Windows.Forms.Label label8;
        private JERPApp.Define.Finance.CtrlMoneyType ctrlMoneyTypeID;
        private System.Windows.Forms.TextBox txtSummary;
        private JERPApp.Define.General.CtrlCustomer ctrlCustomerID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
    }
}