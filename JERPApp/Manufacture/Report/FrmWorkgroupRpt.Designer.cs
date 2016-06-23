namespace JERPApp.Manufacture.Report
{
    partial class FrmWorkgroupRpt
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
            this.label1 = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctrlWorkgroupWorkingHour = new JERPApp.Manufacture.Report.CtrlWorkgroupWorkingHourPivotMonth();
            this.ctrlWorkgroupFinishedRpt = new JERPApp.Manufacture.Report.CtrlWorkgroupFinishedPivotMonth();
            this.ctrlYear = new JCommon.CtrlYear();
            this.ctrlMonth = new JCommon.CtrlMonth();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ctrlMonth);
            this.panel1.Controls.Add(this.ctrlYear);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 34);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(390, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "机组报告";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 34);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(898, 554);
            this.tabMain.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ctrlWorkgroupWorkingHour);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(890, 528);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "作业时间";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctrlWorkgroupFinishedRpt);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(890, 528);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "达成报告";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ctrlWorkgroupWorkingHour
            // 
            this.ctrlWorkgroupWorkingHour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlWorkgroupWorkingHour.Location = new System.Drawing.Point(3, 3);
            this.ctrlWorkgroupWorkingHour.Name = "ctrlWorkgroupWorkingHour";
            this.ctrlWorkgroupWorkingHour.Size = new System.Drawing.Size(884, 522);
            this.ctrlWorkgroupWorkingHour.TabIndex = 0;
            // 
            // ctrlWorkgroupFinishedRpt
            // 
            this.ctrlWorkgroupFinishedRpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlWorkgroupFinishedRpt.Location = new System.Drawing.Point(3, 3);
            this.ctrlWorkgroupFinishedRpt.Name = "ctrlWorkgroupFinishedRpt";
            this.ctrlWorkgroupFinishedRpt.Size = new System.Drawing.Size(884, 522);
            this.ctrlWorkgroupFinishedRpt.TabIndex = 0;
            // 
            // ctrlYear
            // 
            this.ctrlYear.AutoSize = true;
            this.ctrlYear.Location = new System.Drawing.Point(30, 12);
            this.ctrlYear.Name = "ctrlYear";
            this.ctrlYear.Size = new System.Drawing.Size(79, 21);
            this.ctrlYear.TabIndex = 1;
            this.ctrlYear.Year = 2016;
            // 
            // ctrlMonth
            // 
            this.ctrlMonth.AutoSize = true;
            this.ctrlMonth.Location = new System.Drawing.Point(142, 10);
            this.ctrlMonth.Month = 6;
            this.ctrlMonth.Name = "ctrlMonth";
            this.ctrlMonth.Size = new System.Drawing.Size(56, 21);
            this.ctrlMonth.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "年";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "月";
            // 
            // FrmWorkgroupRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 588);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmWorkgroupRpt";
            this.Text = "FrmWorkgroupRpt";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private CtrlWorkgroupWorkingHourPivotMonth ctrlWorkgroupWorkingHour;
        private System.Windows.Forms.TabPage tabPage2;
        private CtrlWorkgroupFinishedPivotMonth ctrlWorkgroupFinishedRpt;
        private JCommon.CtrlMonth ctrlMonth;
        private JCommon.CtrlYear ctrlYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}