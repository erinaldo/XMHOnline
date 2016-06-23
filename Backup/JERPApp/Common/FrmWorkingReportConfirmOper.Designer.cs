namespace JERPApp.Common
{
    partial class FrmWorkingReportConfirmOper
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPsnName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDateReport = new System.Windows.Forms.TextBox();
            this.txtReportTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rchReportContent = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPsnName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtDateReport);
            this.panel1.Controls.Add(this.txtReportTitle);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 31);
            this.panel1.TabIndex = 1;
            // 
            // txtPsnName
            // 
            this.txtPsnName.Location = new System.Drawing.Point(217, 4);
            this.txtPsnName.Name = "txtPsnName";
            this.txtPsnName.ReadOnly = true;
            this.txtPsnName.Size = new System.Drawing.Size(72, 21);
            this.txtPsnName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "业务员";
            // 
            // txtDateReport
            // 
            this.txtDateReport.Location = new System.Drawing.Point(48, 5);
            this.txtDateReport.Name = "txtDateReport";
            this.txtDateReport.ReadOnly = true;
            this.txtDateReport.Size = new System.Drawing.Size(112, 21);
            this.txtDateReport.TabIndex = 4;
            // 
            // txtReportTitle
            // 
            this.txtReportTitle.Location = new System.Drawing.Point(330, 3);
            this.txtReportTitle.Name = "txtReportTitle";
            this.txtReportTitle.ReadOnly = true;
            this.txtReportTitle.Size = new System.Drawing.Size(276, 21);
            this.txtReportTitle.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "标题";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期";
            // 
            // rchReportContent
            // 
            this.rchReportContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchReportContent.Location = new System.Drawing.Point(0, 31);
            this.rchReportContent.Name = "rchReportContent";
            this.rchReportContent.ReadOnly = true;
            this.rchReportContent.Size = new System.Drawing.Size(621, 414);
            this.rchReportContent.TabIndex = 3;
            this.rchReportContent.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnConfirm);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 445);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(621, 31);
            this.panel2.TabIndex = 4;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(3, 5);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "审核确认";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // FrmWorkingReportConfirmOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 476);
            this.Controls.Add(this.rchReportContent);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmWorkingReportConfirmOper";
            this.Text = "工作汇报审核";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDateReport;
        private System.Windows.Forms.TextBox txtReportTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rchReportContent;
        private System.Windows.Forms.TextBox txtPsnName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnConfirm;
    }
}