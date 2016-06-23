namespace JERPApp.Common.Report.Bill
{
    partial class FrmDiary
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
            this.txtDateDiary = new System.Windows.Forms.TextBox();
            this.txtDiaryTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rchDiaryContent = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctrlFileBrowse = new JCommon.CtrlFileBrowse();
            this.txtDiaryTypeName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtDiaryTypeName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtPsnName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtDateDiary);
            this.panel1.Controls.Add(this.txtDiaryTitle);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 33);
            this.panel1.TabIndex = 1;
            // 
            // txtPsnName
            // 
            this.txtPsnName.Location = new System.Drawing.Point(40, 7);
            this.txtPsnName.Name = "txtPsnName";
            this.txtPsnName.ReadOnly = true;
            this.txtPsnName.Size = new System.Drawing.Size(107, 21);
            this.txtPsnName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "人员";
            // 
            // txtDateDiary
            // 
            this.txtDateDiary.Location = new System.Drawing.Point(594, 5);
            this.txtDateDiary.Name = "txtDateDiary";
            this.txtDateDiary.ReadOnly = true;
            this.txtDateDiary.Size = new System.Drawing.Size(94, 21);
            this.txtDateDiary.TabIndex = 4;
            // 
            // txtDiaryTitle
            // 
            this.txtDiaryTitle.Location = new System.Drawing.Point(188, 7);
            this.txtDiaryTitle.Name = "txtDiaryTitle";
            this.txtDiaryTitle.ReadOnly = true;
            this.txtDiaryTitle.Size = new System.Drawing.Size(228, 21);
            this.txtDiaryTitle.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "标题";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(562, 13);
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
            this.tabControl1.Location = new System.Drawing.Point(0, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(700, 443);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rchDiaryContent);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(692, 417);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "日志内容";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rchDiaryContent
            // 
            this.rchDiaryContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchDiaryContent.Location = new System.Drawing.Point(3, 3);
            this.rchDiaryContent.Name = "rchDiaryContent";
            this.rchDiaryContent.ReadOnly = true;
            this.rchDiaryContent.Size = new System.Drawing.Size(686, 411);
            this.rchDiaryContent.TabIndex = 2;
            this.rchDiaryContent.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctrlFileBrowse);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(692, 417);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "日志文件";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ctrlFileBrowse
            // 
            this.ctrlFileBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlFileBrowse.Location = new System.Drawing.Point(3, 3);
            this.ctrlFileBrowse.Name = "ctrlFileBrowse";
            this.ctrlFileBrowse.ReadOnly = false;
            this.ctrlFileBrowse.Size = new System.Drawing.Size(686, 411);
            this.ctrlFileBrowse.TabIndex = 0;
            // 
            // txtDiaryTypeName
            // 
            this.txtDiaryTypeName.Location = new System.Drawing.Point(449, 6);
            this.txtDiaryTypeName.Name = "txtDiaryTypeName";
            this.txtDiaryTypeName.ReadOnly = true;
            this.txtDiaryTypeName.Size = new System.Drawing.Size(107, 21);
            this.txtDiaryTypeName.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(417, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "类型";
            // 
            // FrmDiary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 476);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmDiary";
            this.Text = "日志详细";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDateDiary;
        private System.Windows.Forms.TextBox txtDiaryTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox rchDiaryContent;
        private System.Windows.Forms.TabPage tabPage2;
        private JCommon.CtrlFileBrowse ctrlFileBrowse;
        private System.Windows.Forms.TextBox txtPsnName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiaryTypeName;
        private System.Windows.Forms.Label label4;
    }
}