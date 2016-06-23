namespace JERPApp.Manufacture.Report
{
    partial class FrmWageRpt
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
            this.ctrlBetweenDate = new JCommon.CtrlBetweenDate();
            this.label1 = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ctrlWorkinghourWorkinghour = new JERPApp.Manufacture.Report.CtrlWorkinghourWorkinghourRpt();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctrlIndivPieceworkQuantity = new JERPApp.Manufacture.Report.CtrlIndivPieceworkQuantityRpt();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ctrlWorkinghourLaborWage = new JERPApp.Manufacture.Report.CtrlWorkinghourLaborWageRpt();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ctrlIndivPieceworkLaborWage = new JERPApp.Manufacture.Report.CtrlIndivPieceworkLaborWageRpt();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.ctrlGroupPieceworkLaborWage = new JERPApp.Manufacture.Report.CtrlGroupPieceworkLaborWageRpt();
            this.panel1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlBetweenDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(726, 57);
            this.panel1.TabIndex = 2;
            // 
            // ctrlBetweenDate
            // 
            this.ctrlBetweenDate.DateBegin = new System.DateTime(2015, 1, 19, 0, 0, 0, 0);
            this.ctrlBetweenDate.DateEnd = new System.DateTime(2015, 1, 19, 0, 0, 0, 0);
            this.ctrlBetweenDate.Location = new System.Drawing.Point(12, 26);
            this.ctrlBetweenDate.Name = "ctrlBetweenDate";
            this.ctrlBetweenDate.Size = new System.Drawing.Size(323, 29);
            this.ctrlBetweenDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(328, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "劳务工资报告";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Controls.Add(this.tabPage4);
            this.tabMain.Controls.Add(this.tabPage5);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 57);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(726, 402);
            this.tabMain.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ctrlWorkinghourWorkinghour);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(718, 376);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "工时统计";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ctrlWorkinghourWorkinghour
            // 
            this.ctrlWorkinghourWorkinghour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlWorkinghourWorkinghour.Location = new System.Drawing.Point(3, 3);
            this.ctrlWorkinghourWorkinghour.Name = "ctrlWorkinghourWorkinghour";
            this.ctrlWorkinghourWorkinghour.Size = new System.Drawing.Size(712, 370);
            this.ctrlWorkinghourWorkinghour.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctrlIndivPieceworkQuantity);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(718, 395);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "计件数量";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ctrlIndivPieceworkQuantity
            // 
            this.ctrlIndivPieceworkQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlIndivPieceworkQuantity.Location = new System.Drawing.Point(3, 3);
            this.ctrlIndivPieceworkQuantity.Name = "ctrlIndivPieceworkQuantity";
            this.ctrlIndivPieceworkQuantity.Size = new System.Drawing.Size(712, 389);
            this.ctrlIndivPieceworkQuantity.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ctrlWorkinghourLaborWage);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(718, 395);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "工时工资";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ctrlWorkinghourLaborWage
            // 
            this.ctrlWorkinghourLaborWage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlWorkinghourLaborWage.Location = new System.Drawing.Point(3, 3);
            this.ctrlWorkinghourLaborWage.Name = "ctrlWorkinghourLaborWage";
            this.ctrlWorkinghourLaborWage.Size = new System.Drawing.Size(712, 389);
            this.ctrlWorkinghourLaborWage.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ctrlIndivPieceworkLaborWage);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(718, 395);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "个人计件工资";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ctrlIndivPieceworkLaborWage
            // 
            this.ctrlIndivPieceworkLaborWage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlIndivPieceworkLaborWage.Location = new System.Drawing.Point(3, 3);
            this.ctrlIndivPieceworkLaborWage.Name = "ctrlIndivPieceworkLaborWage";
            this.ctrlIndivPieceworkLaborWage.Size = new System.Drawing.Size(712, 389);
            this.ctrlIndivPieceworkLaborWage.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.ctrlGroupPieceworkLaborWage);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(718, 395);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "集体计件工资";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // ctrlGroupPieceworkLaborWage
            // 
            this.ctrlGroupPieceworkLaborWage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlGroupPieceworkLaborWage.Location = new System.Drawing.Point(3, 3);
            this.ctrlGroupPieceworkLaborWage.Name = "ctrlGroupPieceworkLaborWage";
            this.ctrlGroupPieceworkLaborWage.Size = new System.Drawing.Size(712, 389);
            this.ctrlGroupPieceworkLaborWage.TabIndex = 0;
            // 
            // FrmWageRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 459);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmWageRpt";
            this.Text = "FrmWageRpt";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private CtrlWorkinghourWorkinghourRpt ctrlWorkinghourWorkinghour;
        private System.Windows.Forms.TabPage tabPage2;
        private CtrlIndivPieceworkQuantityRpt ctrlIndivPieceworkQuantity;
        private System.Windows.Forms.TabPage tabPage3;
        private CtrlWorkinghourLaborWageRpt ctrlWorkinghourLaborWage;
        private System.Windows.Forms.TabPage tabPage4;
        private CtrlIndivPieceworkLaborWageRpt ctrlIndivPieceworkLaborWage;
        private System.Windows.Forms.TabPage tabPage5;
        private JCommon.CtrlBetweenDate ctrlBetweenDate;
        private CtrlGroupPieceworkLaborWageRpt ctrlGroupPieceworkLaborWage;
    }
}