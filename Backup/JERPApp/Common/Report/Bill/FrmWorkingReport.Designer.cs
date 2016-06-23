namespace JERPApp.Common.Report.Bill
{
    partial class FrmWorkingReport
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
            this.txtDateRecord = new System.Windows.Forms.TextBox();
            this.txtReportTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rchReportContent = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPsnName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtDateRecord);
            this.panel1.Controls.Add(this.txtReportTitle);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 29);
            this.panel1.TabIndex = 1;
            // 
            // txtPsnName
            // 
            this.txtPsnName.Location = new System.Drawing.Point(205, 4);
            this.txtPsnName.Name = "txtPsnName";
            this.txtPsnName.ReadOnly = true;
            this.txtPsnName.Size = new System.Drawing.Size(72, 21);
            this.txtPsnName.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "汇报人";
            // 
            // txtDateRecord
            // 
            this.txtDateRecord.Location = new System.Drawing.Point(40, 3);
            this.txtDateRecord.Name = "txtDateRecord";
            this.txtDateRecord.ReadOnly = true;
            this.txtDateRecord.Size = new System.Drawing.Size(107, 21);
            this.txtDateRecord.TabIndex = 4;
            // 
            // txtReportTitle
            // 
            this.txtReportTitle.Location = new System.Drawing.Point(318, 3);
            this.txtReportTitle.Name = "txtReportTitle";
            this.txtReportTitle.ReadOnly = true;
            this.txtReportTitle.Size = new System.Drawing.Size(369, 21);
            this.txtReportTitle.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "标题";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期";
            // 
            // rchReportContent
            // 
            this.rchReportContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchReportContent.Location = new System.Drawing.Point(0, 29);
            this.rchReportContent.Name = "rchReportContent";
            this.rchReportContent.ReadOnly = true;
            this.rchReportContent.Size = new System.Drawing.Size(700, 447);
            this.rchReportContent.TabIndex = 3;
            this.rchReportContent.Text = "";
            // 
            // FrmWorkingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 476);
            this.Controls.Add(this.rchReportContent);
            this.Controls.Add(this.panel1);
            this.Name = "FrmWorkingReport";
            this.Text = "工作汇报";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDateRecord;
        private System.Windows.Forms.TextBox txtReportTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rchReportContent;
        private System.Windows.Forms.TextBox txtPsnName;
        private System.Windows.Forms.Label label3;
    }
}