namespace JERPApp.Common.Report.Bill
{
    partial class FrmMeeting
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
            this.txtDateMeeting = new System.Windows.Forms.TextBox();
            this.txtMeetingTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rchMeetingContent = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctrlFileBrowse = new JCommon.CtrlFileBrowse();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPsnName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtDateMeeting);
            this.panel1.Controls.Add(this.txtMeetingTitle);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 62);
            this.panel1.TabIndex = 1;
            // 
            // txtPsnName
            // 
            this.txtPsnName.Location = new System.Drawing.Point(71, 34);
            this.txtPsnName.Name = "txtPsnName";
            this.txtPsnName.ReadOnly = true;
            this.txtPsnName.Size = new System.Drawing.Size(617, 21);
            this.txtPsnName.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "与会人员";
            // 
            // txtDateMeeting
            // 
            this.txtDateMeeting.Location = new System.Drawing.Point(581, 4);
            this.txtDateMeeting.Name = "txtDateMeeting";
            this.txtDateMeeting.ReadOnly = true;
            this.txtDateMeeting.Size = new System.Drawing.Size(107, 21);
            this.txtDateMeeting.TabIndex = 4;
            // 
            // txtMeetingTitle
            // 
            this.txtMeetingTitle.Location = new System.Drawing.Point(71, 7);
            this.txtMeetingTitle.Name = "txtMeetingTitle";
            this.txtMeetingTitle.ReadOnly = true;
            this.txtMeetingTitle.Size = new System.Drawing.Size(453, 21);
            this.txtMeetingTitle.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "主题";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(546, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 62);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(700, 414);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rchMeetingContent);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(692, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "会议内容";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rchMeetingContent
            // 
            this.rchMeetingContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchMeetingContent.Location = new System.Drawing.Point(3, 3);
            this.rchMeetingContent.Name = "rchMeetingContent";
            this.rchMeetingContent.ReadOnly = true;
            this.rchMeetingContent.Size = new System.Drawing.Size(686, 382);
            this.rchMeetingContent.TabIndex = 2;
            this.rchMeetingContent.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctrlFileBrowse);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(692, 388);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "会议文件";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ctrlFileBrowse
            // 
            this.ctrlFileBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlFileBrowse.Location = new System.Drawing.Point(3, 3);
            this.ctrlFileBrowse.Name = "ctrlFileBrowse";
            this.ctrlFileBrowse.ReadOnly = false;
            this.ctrlFileBrowse.Size = new System.Drawing.Size(686, 382);
            this.ctrlFileBrowse.TabIndex = 0;
            // 
            // FrmMeeting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 476);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMeeting";
            this.Text = "会议记录";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDateMeeting;
        private System.Windows.Forms.TextBox txtMeetingTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPsnName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox rchMeetingContent;
        private System.Windows.Forms.TabPage tabPage2;
        private JCommon.CtrlFileBrowse ctrlFileBrowse;
    }
}