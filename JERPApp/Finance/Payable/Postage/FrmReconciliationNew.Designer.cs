namespace JERPApp.Finance.Payable.Postage
{
    partial class FrmReconciliationNew
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
            this.ctrlYear = new JCommon.CtrlYear();
            this.ctrlMonth = new JCommon.CtrlMonth();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReconciliationName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDateNote = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtReconciliationCode = new System.Windows.Forms.TextBox();
            this.dtpDateTarget = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.ctrlExpressID = new JERPApp.Define.General.CtrlExpress();
            this.SuspendLayout();
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
            this.label2.Location = new System.Drawing.Point(212, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "年";
            // 
            // ctrlYear
            // 
            this.ctrlYear.AutoSize = true;
            this.ctrlYear.Location = new System.Drawing.Point(237, 15);
            this.ctrlYear.Name = "ctrlYear";
            this.ctrlYear.Size = new System.Drawing.Size(79, 21);
            this.ctrlYear.TabIndex = 3;
            this.ctrlYear.Year = 2015;
            // 
            // ctrlMonth
            // 
            this.ctrlMonth.AutoSize = true;
            this.ctrlMonth.Location = new System.Drawing.Point(353, 15);
            this.ctrlMonth.Month = 7;
            this.ctrlMonth.Name = "ctrlMonth";
            this.ctrlMonth.Size = new System.Drawing.Size(54, 21);
            this.ctrlMonth.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(322, 24);
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
            // txtReconciliationName
            // 
            this.txtReconciliationName.Location = new System.Drawing.Point(59, 98);
            this.txtReconciliationName.Name = "txtReconciliationName";
            this.txtReconciliationName.Size = new System.Drawing.Size(348, 21);
            this.txtReconciliationName.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "对账日期";
            // 
            // dtpDateNote
            // 
            this.dtpDateNote.Location = new System.Drawing.Point(59, 44);
            this.dtpDateNote.Name = "dtpDateNote";
            this.dtpDateNote.Size = new System.Drawing.Size(140, 21);
            this.dtpDateNote.TabIndex = 13;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(59, 137);
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
            // txtReconciliationCode
            // 
            this.txtReconciliationCode.Location = new System.Drawing.Point(59, 71);
            this.txtReconciliationCode.Name = "txtReconciliationCode";
            this.txtReconciliationCode.Size = new System.Drawing.Size(195, 21);
            this.txtReconciliationCode.TabIndex = 16;
            // 
            // dtpDateTarget
            // 
            this.dtpDateTarget.Location = new System.Drawing.Point(267, 44);
            this.dtpDateTarget.Name = "dtpDateTarget";
            this.dtpDateTarget.Size = new System.Drawing.Size(140, 21);
            this.dtpDateTarget.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(208, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "结算日期";
            // 
            // ctrlExpressID
            // 
            this.ctrlExpressID.AutoSize = true;
            this.ctrlExpressID.CompanyID = -1;
            this.ctrlExpressID.Location = new System.Drawing.Point(59, 12);
            this.ctrlExpressID.Name = "ctrlExpressID";
            this.ctrlExpressID.Size = new System.Drawing.Size(140, 23);
            this.ctrlExpressID.TabIndex = 47;
            // 
            // FrmReconciliationNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 197);
            this.Controls.Add(this.ctrlExpressID);
            this.Controls.Add(this.dtpDateTarget);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtReconciliationCode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpDateNote);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtReconciliationName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctrlMonth);
            this.Controls.Add(this.ctrlYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmReconciliationNew";
            this.Text = "新增原料对账单";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private JCommon.CtrlYear ctrlYear;
        private JCommon.CtrlMonth ctrlMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtReconciliationName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDateNote;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtReconciliationCode;
        private System.Windows.Forms.DateTimePicker dtpDateTarget;
        private System.Windows.Forms.Label label9;
        private JERPApp.Define.General.CtrlExpress ctrlExpressID;
    }
}