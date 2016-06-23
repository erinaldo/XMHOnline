namespace JERPApp.Manufacture.Report
{
    partial class FrmWageRecord
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.ctrlPsnID = new JERPApp.Define.Hr.CtrlPersonnel();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlWorkinghourWorkinghourRecord = new JERPApp.Manufacture.Report.CtrlWorkinghourWorkinghourRecord();
            this.ctrlIndivPieceworkRecord = new JERPApp.Manufacture.Report.CtrlIndivPieceworkRecord();
            this.ctrlWorkinghourLaborWageRecord = new JERPApp.Manufacture.Report.CtrlWorkinghourLaborWageRecord();
            this.ctrlGroupPieceworkLaborWageRecord = new JERPApp.Manufacture.Report.CtrlGroupPieceworkLaborWageRecord();
            this.panel1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ctrlPsnID);
            this.panel1.Controls.Add(this.ctrlBetweenDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 57);
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
            this.label1.Location = new System.Drawing.Point(373, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "劳务工资记录";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Controls.Add(this.tabPage4);
            this.tabMain.Controls.Add(this.tabPage5);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 57);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(840, 577);
            this.tabMain.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctrlIndivPieceworkRecord);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(832, 551);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "个体计件工资";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ctrlWorkinghourWorkinghourRecord);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(718, 376);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "工时一览";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ctrlWorkinghourLaborWageRecord);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(718, 376);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "工时工资";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.ctrlGroupPieceworkLaborWageRecord);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(718, 376);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "集体计件工资";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // ctrlPsnID
            // 
            this.ctrlPsnID.AutoSize = true;
            this.ctrlPsnID.Location = new System.Drawing.Point(376, 28);
            this.ctrlPsnID.Name = "ctrlPsnID";
            this.ctrlPsnID.PsnID = -1;
            this.ctrlPsnID.Size = new System.Drawing.Size(155, 23);
            this.ctrlPsnID.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "员工";
            // 
            // ctrlWorkinghourWorkinghourRecord
            // 
            this.ctrlWorkinghourWorkinghourRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlWorkinghourWorkinghourRecord.Location = new System.Drawing.Point(3, 3);
            this.ctrlWorkinghourWorkinghourRecord.Name = "ctrlWorkinghourWorkinghourRecord";
            this.ctrlWorkinghourWorkinghourRecord.Size = new System.Drawing.Size(712, 370);
            this.ctrlWorkinghourWorkinghourRecord.TabIndex = 0;
            // 
            // ctrlIndivPieceworkRecord
            // 
            this.ctrlIndivPieceworkRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlIndivPieceworkRecord.Location = new System.Drawing.Point(3, 3);
            this.ctrlIndivPieceworkRecord.Name = "ctrlIndivPieceworkRecord";
            this.ctrlIndivPieceworkRecord.Size = new System.Drawing.Size(826, 545);
            this.ctrlIndivPieceworkRecord.TabIndex = 0;
            // 
            // ctrlWorkinghourLaborWageRecord
            // 
            this.ctrlWorkinghourLaborWageRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlWorkinghourLaborWageRecord.Location = new System.Drawing.Point(3, 3);
            this.ctrlWorkinghourLaborWageRecord.Name = "ctrlWorkinghourLaborWageRecord";
            this.ctrlWorkinghourLaborWageRecord.Size = new System.Drawing.Size(712, 370);
            this.ctrlWorkinghourLaborWageRecord.TabIndex = 0;
            // 
            // ctrlGroupPieceworkLaborWageRecord
            // 
            this.ctrlGroupPieceworkLaborWageRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlGroupPieceworkLaborWageRecord.Location = new System.Drawing.Point(3, 3);
            this.ctrlGroupPieceworkLaborWageRecord.Name = "ctrlGroupPieceworkLaborWageRecord";
            this.ctrlGroupPieceworkLaborWageRecord.Size = new System.Drawing.Size(712, 370);
            this.ctrlGroupPieceworkLaborWageRecord.TabIndex = 0;
            // 
            // FrmWageRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 634);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmWageRecord";
            this.Text = "FrmWageRecord";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabMain.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private JCommon.CtrlBetweenDate ctrlBetweenDate;
        private System.Windows.Forms.Label label2;
        private JERPApp.Define.Hr.CtrlPersonnel ctrlPsnID;
        private CtrlIndivPieceworkRecord ctrlIndivPieceworkRecord;
        private CtrlWorkinghourWorkinghourRecord ctrlWorkinghourWorkinghourRecord;
        private CtrlWorkinghourLaborWageRecord ctrlWorkinghourLaborWageRecord;
        private CtrlGroupPieceworkLaborWageRecord ctrlGroupPieceworkLaborWageRecord;
    }
}