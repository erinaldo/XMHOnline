namespace JERPApp.Store.Product.Report
{
    partial class FrmSaleDeliverDayRpt
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
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlMonth = new JCommon.CtrlMonth();
            this.ctrlYear = new JCommon.CtrlYear();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageTotal = new System.Windows.Forms.TabPage();
            this.ctrlSaleDeliverDayRpt = new JERPApp.Store.Product.Report.CtrlSaleDeliverDayRpt();
            this.panel1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pageTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ctrlMonth);
            this.panel1.Controls.Add(this.ctrlYear);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 33);
            this.panel1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "月份";
            // 
            // ctrlMonth
            // 
            this.ctrlMonth.AutoSize = true;
            this.ctrlMonth.Location = new System.Drawing.Point(175, 8);
            this.ctrlMonth.Month = 12;
            this.ctrlMonth.Name = "ctrlMonth";
            this.ctrlMonth.Size = new System.Drawing.Size(50, 21);
            this.ctrlMonth.TabIndex = 7;
            // 
            // ctrlYear
            // 
            this.ctrlYear.AutoSize = true;
            this.ctrlYear.Location = new System.Drawing.Point(48, 8);
            this.ctrlYear.Name = "ctrlYear";
            this.ctrlYear.Size = new System.Drawing.Size(79, 21);
            this.ctrlYear.TabIndex = 6;
            this.ctrlYear.Year = 2014;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "年份";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(367, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "销售出货日报";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pageTotal);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 33);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(801, 478);
            this.tabMain.TabIndex = 6;
            // 
            // pageTotal
            // 
            this.pageTotal.Controls.Add(this.ctrlSaleDeliverDayRpt);
            this.pageTotal.Location = new System.Drawing.Point(4, 22);
            this.pageTotal.Name = "pageTotal";
            this.pageTotal.Size = new System.Drawing.Size(793, 452);
            this.pageTotal.TabIndex = 0;
            this.pageTotal.Text = "总计";
            this.pageTotal.UseVisualStyleBackColor = true;
            // 
            // ctrlSaleDeliverDayRpt
            // 
            this.ctrlSaleDeliverDayRpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlSaleDeliverDayRpt.Location = new System.Drawing.Point(0, 0);
            this.ctrlSaleDeliverDayRpt.Name = "ctrlSaleDeliverDayRpt";
            this.ctrlSaleDeliverDayRpt.Size = new System.Drawing.Size(793, 452);
            this.ctrlSaleDeliverDayRpt.TabIndex = 0;
            // 
            // FrmSaleDeliverDayRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 511);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSaleDeliverDayRpt";
            this.Text = "FrmSaleDeliverReport";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.pageTotal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private JCommon.CtrlYear ctrlYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private JCommon.CtrlMonth ctrlMonth;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageTotal;
        private CtrlSaleDeliverDayRpt ctrlSaleDeliverDayRpt;
    }
}