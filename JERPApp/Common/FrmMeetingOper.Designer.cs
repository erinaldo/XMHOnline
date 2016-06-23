namespace JERPApp.Common
{
    partial class FrmMeetingOper
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
            this.txtMeetingPsns = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMeetingTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateMeeting = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rchMeetingContent = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctrlFileBrowse = new JCommon.CtrlFileBrowse();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMeetingPsns);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtMeetingTitle);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpDateMeeting);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(699, 62);
            this.panel1.TabIndex = 0;
            // 
            // txtMeetingPsns
            // 
            this.txtMeetingPsns.Location = new System.Drawing.Point(48, 31);
            this.txtMeetingPsns.Name = "txtMeetingPsns";
            this.txtMeetingPsns.Size = new System.Drawing.Size(639, 21);
            this.txtMeetingPsns.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "与会";
            // 
            // txtMeetingTitle
            // 
            this.txtMeetingTitle.Location = new System.Drawing.Point(237, 3);
            this.txtMeetingTitle.Name = "txtMeetingTitle";
            this.txtMeetingTitle.Size = new System.Drawing.Size(450, 21);
            this.txtMeetingTitle.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "主题";
            // 
            // dtpDateMeeting
            // 
            this.dtpDateMeeting.Location = new System.Drawing.Point(48, 4);
            this.dtpDateMeeting.Name = "dtpDateMeeting";
            this.dtpDateMeeting.Size = new System.Drawing.Size(146, 21);
            this.dtpDateMeeting.TabIndex = 1;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 465);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(699, 37);
            this.panel2.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(621, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(543, 7);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "新增";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(399, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 62);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(699, 403);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rchMeetingContent);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(691, 377);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "会议内容";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rchMeetingContent
            // 
            this.rchMeetingContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchMeetingContent.Location = new System.Drawing.Point(3, 3);
            this.rchMeetingContent.Name = "rchMeetingContent";
            this.rchMeetingContent.Size = new System.Drawing.Size(685, 371);
            this.rchMeetingContent.TabIndex = 2;
            this.rchMeetingContent.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctrlFileBrowse);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(691, 377);
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
            this.ctrlFileBrowse.Size = new System.Drawing.Size(685, 371);
            this.ctrlFileBrowse.TabIndex = 0;
            // 
            // FrmMeetingOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 502);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMeetingOper";
            this.Text = "会议记录";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMeetingTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateMeeting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtMeetingPsns;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox rchMeetingContent;
        private System.Windows.Forms.TabPage tabPage2;
        private JCommon.CtrlFileBrowse ctrlFileBrowse;
    }
}