namespace JERPApp.Finance.Report
{
    partial class FrmPayableReconciliationRpt
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
            this.ctrlYear = new JCommon.CtrlYear();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ctrlMtrBuyReconciliationRpt = new JERPApp.Finance.Report.CtrlMtrBuyReconciliationRpt();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctrlOutSrcReconciliationRpt = new JERPApp.Finance.Report.CtrlOutSrcReconciliationRpt();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ctrlPostageReconciliationRpt = new JERPApp.Finance.Report.CtrlPostageReconciliationRpt();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.ctrlOtherResBuyReconciliationRpt = new JERPApp.Finance.Report.CtrlOtherResBuyReconciliationRpt();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.ctrlPrdBuyReconciliationRpt = new JERPApp.Finance.Report.CtrlPrdBuyReconciliationRpt();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.ctrlToolBuyReconciliationRpt = new JERPApp.Finance.Report.CtrlToolBuyReconciliationRpt();
            this.panel1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlYear);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(882, 37);
            this.panel1.TabIndex = 0;
            // 
            // ctrlYear
            // 
            this.ctrlYear.AutoSize = true;
            this.ctrlYear.Location = new System.Drawing.Point(27, 15);
            this.ctrlYear.Name = "ctrlYear";
            this.ctrlYear.Size = new System.Drawing.Size(79, 21);
            this.ctrlYear.TabIndex = 3;
            this.ctrlYear.Year = 2013;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "年";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(421, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "应付款对账报告";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage4);
            this.tabMain.Controls.Add(this.tabPage5);
            this.tabMain.Controls.Add(this.tabPage6);
            this.tabMain.Controls.Add(this.tabPage7);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 37);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(882, 456);
            this.tabMain.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ctrlMtrBuyReconciliationRpt);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(874, 430);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "原料采购";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ctrlMtrBuyReconciliationRpt
            // 
            this.ctrlMtrBuyReconciliationRpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlMtrBuyReconciliationRpt.Location = new System.Drawing.Point(3, 3);
            this.ctrlMtrBuyReconciliationRpt.Name = "ctrlMtrBuyReconciliationRpt";
            this.ctrlMtrBuyReconciliationRpt.Size = new System.Drawing.Size(868, 424);
            this.ctrlMtrBuyReconciliationRpt.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctrlOutSrcReconciliationRpt);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(874, 430);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "委外加工";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ctrlOutSrcReconciliationRpt
            // 
            this.ctrlOutSrcReconciliationRpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlOutSrcReconciliationRpt.Location = new System.Drawing.Point(3, 3);
            this.ctrlOutSrcReconciliationRpt.Name = "ctrlOutSrcReconciliationRpt";
            this.ctrlOutSrcReconciliationRpt.Size = new System.Drawing.Size(868, 424);
            this.ctrlOutSrcReconciliationRpt.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ctrlPostageReconciliationRpt);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(874, 430);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "运费";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ctrlPostageReconciliationRpt
            // 
            this.ctrlPostageReconciliationRpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPostageReconciliationRpt.Location = new System.Drawing.Point(3, 3);
            this.ctrlPostageReconciliationRpt.Name = "ctrlPostageReconciliationRpt";
            this.ctrlPostageReconciliationRpt.Size = new System.Drawing.Size(868, 424);
            this.ctrlPostageReconciliationRpt.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.ctrlOtherResBuyReconciliationRpt);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(874, 430);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "耗材采购";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // ctrlOtherResBuyReconciliationRpt
            // 
            this.ctrlOtherResBuyReconciliationRpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlOtherResBuyReconciliationRpt.Location = new System.Drawing.Point(3, 3);
            this.ctrlOtherResBuyReconciliationRpt.Name = "ctrlOtherResBuyReconciliationRpt";
            this.ctrlOtherResBuyReconciliationRpt.Size = new System.Drawing.Size(868, 424);
            this.ctrlOtherResBuyReconciliationRpt.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.ctrlPrdBuyReconciliationRpt);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(874, 430);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "产品采购";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // ctrlPrdBuyReconciliationRpt
            // 
            this.ctrlPrdBuyReconciliationRpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPrdBuyReconciliationRpt.Location = new System.Drawing.Point(3, 3);
            this.ctrlPrdBuyReconciliationRpt.Name = "ctrlPrdBuyReconciliationRpt";
            this.ctrlPrdBuyReconciliationRpt.Size = new System.Drawing.Size(868, 424);
            this.ctrlPrdBuyReconciliationRpt.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.ctrlToolBuyReconciliationRpt);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(874, 430);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "治具";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // ctrlToolBuyReconciliationRpt
            // 
            this.ctrlToolBuyReconciliationRpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlToolBuyReconciliationRpt.Location = new System.Drawing.Point(3, 3);
            this.ctrlToolBuyReconciliationRpt.Name = "ctrlToolBuyReconciliationRpt";
            this.ctrlToolBuyReconciliationRpt.Size = new System.Drawing.Size(868, 424);
            this.ctrlToolBuyReconciliationRpt.TabIndex = 0;
            // 
            // FrmPayableReconciliationRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 493);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmPayableReconciliationRpt";
            this.Text = "FrmPayableReconcilaitonRpt";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private JCommon.CtrlYear ctrlYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage4;
        private CtrlMtrBuyReconciliationRpt ctrlMtrBuyReconciliationRpt;
        private CtrlOutSrcReconciliationRpt ctrlOutSrcReconciliationRpt; 
        private CtrlPostageReconciliationRpt ctrlPostageReconciliationRpt;
        private System.Windows.Forms.TabPage tabPage5;
        private CtrlOtherResBuyReconciliationRpt ctrlOtherResBuyReconciliationRpt;
        private System.Windows.Forms.TabPage tabPage6;
        private CtrlPrdBuyReconciliationRpt ctrlPrdBuyReconciliationRpt;
        private System.Windows.Forms.TabPage tabPage7;
        private CtrlToolBuyReconciliationRpt ctrlToolBuyReconciliationRpt;
    }
}