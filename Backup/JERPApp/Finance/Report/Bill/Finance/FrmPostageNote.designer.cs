namespace JERPApp.Finance.Report.Bill.Finance
{
    partial class FrmPostageNote
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
            this.lblCapNoteCode = new System.Windows.Forms.Label();
            this.txtNoteCode = new System.Windows.Forms.TextBox();
            this.lblCapDateNote = new System.Windows.Forms.Label();
            this.txtDateNote = new System.Windows.Forms.TextBox();
            this.lblCapAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblCapCompanyAllName = new System.Windows.Forms.Label();
            this.lblCapMakerPsn = new System.Windows.Forms.Label();
            this.txtMakerPsn = new System.Windows.Forms.TextBox();
            this.lblCapReconciliationCode = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtCompanyAllName = new System.Windows.Forms.TextBox();
            this.rchMemo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblCapNoteCode
            // 
            this.lblCapNoteCode.AutoSize = true;
            this.lblCapNoteCode.Location = new System.Drawing.Point(10, 15);
            this.lblCapNoteCode.Name = "lblCapNoteCode";
            this.lblCapNoteCode.Size = new System.Drawing.Size(53, 12);
            this.lblCapNoteCode.TabIndex = 0;
            this.lblCapNoteCode.Text = "快递单号";
            // 
            // txtNoteCode
            // 
            this.txtNoteCode.Location = new System.Drawing.Point(100, 10);
            this.txtNoteCode.Name = "txtNoteCode";
            this.txtNoteCode.ReadOnly = true;
            this.txtNoteCode.Size = new System.Drawing.Size(120, 21);
            this.txtNoteCode.TabIndex = 1;
            // 
            // lblCapDateNote
            // 
            this.lblCapDateNote.AutoSize = true;
            this.lblCapDateNote.Location = new System.Drawing.Point(226, 15);
            this.lblCapDateNote.Name = "lblCapDateNote";
            this.lblCapDateNote.Size = new System.Drawing.Size(53, 12);
            this.lblCapDateNote.TabIndex = 2;
            this.lblCapDateNote.Text = "制单日期";
            // 
            // txtDateNote
            // 
            this.txtDateNote.Location = new System.Drawing.Point(285, 10);
            this.txtDateNote.Name = "txtDateNote";
            this.txtDateNote.ReadOnly = true;
            this.txtDateNote.Size = new System.Drawing.Size(120, 21);
            this.txtDateNote.TabIndex = 3;
            // 
            // lblCapAmount
            // 
            this.lblCapAmount.AutoSize = true;
            this.lblCapAmount.Location = new System.Drawing.Point(10, 69);
            this.lblCapAmount.Name = "lblCapAmount";
            this.lblCapAmount.Size = new System.Drawing.Size(29, 12);
            this.lblCapAmount.TabIndex = 4;
            this.lblCapAmount.Text = "金额";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(100, 64);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(120, 21);
            this.txtAmount.TabIndex = 5;
            // 
            // lblCapCompanyAllName
            // 
            this.lblCapCompanyAllName.AutoSize = true;
            this.lblCapCompanyAllName.Location = new System.Drawing.Point(10, 42);
            this.lblCapCompanyAllName.Name = "lblCapCompanyAllName";
            this.lblCapCompanyAllName.Size = new System.Drawing.Size(53, 12);
            this.lblCapCompanyAllName.TabIndex = 6;
            this.lblCapCompanyAllName.Text = "物流公司";
            // 
            // lblCapMakerPsn
            // 
            this.lblCapMakerPsn.AutoSize = true;
            this.lblCapMakerPsn.Location = new System.Drawing.Point(226, 67);
            this.lblCapMakerPsn.Name = "lblCapMakerPsn";
            this.lblCapMakerPsn.Size = new System.Drawing.Size(41, 12);
            this.lblCapMakerPsn.TabIndex = 8;
            this.lblCapMakerPsn.Text = "制单人";
            // 
            // txtMakerPsn
            // 
            this.txtMakerPsn.Location = new System.Drawing.Point(285, 64);
            this.txtMakerPsn.Name = "txtMakerPsn";
            this.txtMakerPsn.ReadOnly = true;
            this.txtMakerPsn.Size = new System.Drawing.Size(120, 21);
            this.txtMakerPsn.TabIndex = 9;
            // 
            // lblCapReconciliationCode
            // 
            this.lblCapReconciliationCode.AutoSize = true;
            this.lblCapReconciliationCode.Location = new System.Drawing.Point(10, 101);
            this.lblCapReconciliationCode.Name = "lblCapReconciliationCode";
            this.lblCapReconciliationCode.Size = new System.Drawing.Size(29, 12);
            this.lblCapReconciliationCode.TabIndex = 10;
            this.lblCapReconciliationCode.Text = "备注";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(100, 153);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 16;
            this.btnExport.Text = "输出打印";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // txtCompanyAllName
            // 
            this.txtCompanyAllName.Location = new System.Drawing.Point(100, 37);
            this.txtCompanyAllName.Name = "txtCompanyAllName";
            this.txtCompanyAllName.ReadOnly = true;
            this.txtCompanyAllName.Size = new System.Drawing.Size(305, 21);
            this.txtCompanyAllName.TabIndex = 17;
            // 
            // rchMemo
            // 
            this.rchMemo.Location = new System.Drawing.Point(100, 98);
            this.rchMemo.Name = "rchMemo";
            this.rchMemo.ReadOnly = true;
            this.rchMemo.Size = new System.Drawing.Size(305, 42);
            this.rchMemo.TabIndex = 18;
            this.rchMemo.Text = "";
            // 
            // FrmPostageNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(475, 188);
            this.Controls.Add(this.rchMemo);
            this.Controls.Add(this.txtCompanyAllName);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblCapNoteCode);
            this.Controls.Add(this.txtNoteCode);
            this.Controls.Add(this.lblCapDateNote);
            this.Controls.Add(this.txtDateNote);
            this.Controls.Add(this.lblCapAmount);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblCapCompanyAllName);
            this.Controls.Add(this.lblCapMakerPsn);
            this.Controls.Add(this.txtMakerPsn);
            this.Controls.Add(this.lblCapReconciliationCode);
            this.Name = "FrmPostageNote";
            this.Text = "快递单";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label lblCapNoteCode;
        private System.Windows.Forms.TextBox txtNoteCode;
        private System.Windows.Forms.Label lblCapDateNote;
        private System.Windows.Forms.TextBox txtDateNote;
        private System.Windows.Forms.Label lblCapAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblCapCompanyAllName;
        private System.Windows.Forms.Label lblCapMakerPsn;
        private System.Windows.Forms.TextBox txtMakerPsn;
        private System.Windows.Forms.Label lblCapReconciliationCode;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtCompanyAllName;
        private System.Windows.Forms.RichTextBox rchMemo;
    }
}