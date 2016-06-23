namespace JERPApp.Finance.Payable.OutSrc
{
    partial class FrmFineAMTConfirm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNoteCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rchSummary = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDateNote = new System.Windows.Forms.TextBox();
            this.txtCompanyAbbName = new System.Windows.Forms.TextBox();
            this.txtMoneyTypeName = new System.Windows.Forms.TextBox();
            this.radCashFlag = new System.Windows.Forms.RadioButton();
            this.radPayableFlag = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(159, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "外发扣款单";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "扣款单号";
            // 
            // txtNoteCode
            // 
            this.txtNoteCode.Location = new System.Drawing.Point(72, 29);
            this.txtNoteCode.Name = "txtNoteCode";
            this.txtNoteCode.ReadOnly = true;
            this.txtNoteCode.Size = new System.Drawing.Size(123, 21);
            this.txtNoteCode.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "制单日期";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "供应商";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "币种";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(175, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "扣款金额";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(235, 204);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(100, 21);
            this.txtAmount.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "摘要";
            // 
            // rchSummary
            // 
            this.rchSummary.Location = new System.Drawing.Point(72, 83);
            this.rchSummary.Name = "rchSummary";
            this.rchSummary.ReadOnly = true;
            this.rchSummary.Size = new System.Drawing.Size(311, 115);
            this.rchSummary.TabIndex = 13;
            this.rchSummary.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(308, 262);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "审核入账";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // txtDateNote
            // 
            this.txtDateNote.Location = new System.Drawing.Point(260, 29);
            this.txtDateNote.Name = "txtDateNote";
            this.txtDateNote.ReadOnly = true;
            this.txtDateNote.Size = new System.Drawing.Size(123, 21);
            this.txtDateNote.TabIndex = 15;
            // 
            // txtCompanyAbbName
            // 
            this.txtCompanyAbbName.Location = new System.Drawing.Point(72, 56);
            this.txtCompanyAbbName.Name = "txtCompanyAbbName";
            this.txtCompanyAbbName.ReadOnly = true;
            this.txtCompanyAbbName.Size = new System.Drawing.Size(311, 21);
            this.txtCompanyAbbName.TabIndex = 16;
            // 
            // txtMoneyTypeName
            // 
            this.txtMoneyTypeName.Location = new System.Drawing.Point(72, 204);
            this.txtMoneyTypeName.Name = "txtMoneyTypeName";
            this.txtMoneyTypeName.ReadOnly = true;
            this.txtMoneyTypeName.Size = new System.Drawing.Size(100, 21);
            this.txtMoneyTypeName.TabIndex = 17;
            // 
            // radCashFlag
            // 
            this.radCashFlag.AutoSize = true;
            this.radCashFlag.ForeColor = System.Drawing.Color.Blue;
            this.radCashFlag.Location = new System.Drawing.Point(71, 234);
            this.radCashFlag.Name = "radCashFlag";
            this.radCashFlag.Size = new System.Drawing.Size(47, 16);
            this.radCashFlag.TabIndex = 24;
            this.radCashFlag.Text = "现结";
            this.radCashFlag.UseVisualStyleBackColor = true;
            // 
            // radPayableFlag
            // 
            this.radPayableFlag.AutoSize = true;
            this.radPayableFlag.Checked = true;
            this.radPayableFlag.ForeColor = System.Drawing.Color.Blue;
            this.radPayableFlag.Location = new System.Drawing.Point(124, 234);
            this.radPayableFlag.Name = "radPayableFlag";
            this.radPayableFlag.Size = new System.Drawing.Size(47, 16);
            this.radPayableFlag.TabIndex = 23;
            this.radPayableFlag.TabStop = true;
            this.radPayableFlag.Text = "月结";
            this.radPayableFlag.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "结算方式";
            // 
            // FrmFineAMTConfirmOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 291);
            this.Controls.Add(this.radCashFlag);
            this.Controls.Add(this.radPayableFlag);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMoneyTypeName);
            this.Controls.Add(this.txtCompanyAbbName);
            this.Controls.Add(this.txtDateNote);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rchSummary);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNoteCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmFineAMTConfirmOper";
            this.Text = "外发扣款单";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNoteCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rchSummary;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDateNote;
        private System.Windows.Forms.TextBox txtCompanyAbbName;
        private System.Windows.Forms.TextBox txtMoneyTypeName;
        private System.Windows.Forms.RadioButton radCashFlag;
        private System.Windows.Forms.RadioButton radPayableFlag;
        private System.Windows.Forms.Label label8;

    }
}