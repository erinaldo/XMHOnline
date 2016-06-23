namespace JERPApp.Finance.Report
{
    partial class FrmSaleProfitRpt
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
            this.txtMainMoneyType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlYearRpt = new JCommon.CtrlYear();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ctrlCustomerProfit = new JERPApp.Finance.Report.CtrlCustomerProfit();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctrlPrdTypeProfit = new JERPApp.Finance.Report.CtrlPrdTypeProfit();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ctrlProductProfit = new JERPApp.Finance.Report.CtrlProductProfit();
            this.panel1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMainMoneyType);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ctrlYearRpt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(922, 46);
            this.panel1.TabIndex = 0;
            // 
            // txtMainMoneyType
            // 
            this.txtMainMoneyType.Location = new System.Drawing.Point(72, 20);
            this.txtMainMoneyType.Name = "txtMainMoneyType";
            this.txtMainMoneyType.ReadOnly = true;
            this.txtMainMoneyType.Size = new System.Drawing.Size(63, 21);
            this.txtMainMoneyType.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "折合币种:";
            // 
            // ctrlYearRpt
            // 
            this.ctrlYearRpt.AutoSize = true;
            this.ctrlYearRpt.Location = new System.Drawing.Point(168, 19);
            this.ctrlYearRpt.Name = "ctrlYearRpt";
            this.ctrlYearRpt.Size = new System.Drawing.Size(79, 21);
            this.ctrlYearRpt.TabIndex = 2;
            this.ctrlYearRpt.Year = 2009;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "年";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(446, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "销售毛利报告";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 46);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(922, 499);
            this.tabMain.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ctrlCustomerProfit);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(914, 473);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "客户";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ctrlCustomerProfit
            // 
            this.ctrlCustomerProfit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlCustomerProfit.Location = new System.Drawing.Point(3, 3);
            this.ctrlCustomerProfit.Name = "ctrlCustomerProfit";
            this.ctrlCustomerProfit.Size = new System.Drawing.Size(908, 467);
            this.ctrlCustomerProfit.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctrlPrdTypeProfit);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(914, 473);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "产品分类";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ctrlPrdTypeProfit
            // 
            this.ctrlPrdTypeProfit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPrdTypeProfit.Location = new System.Drawing.Point(3, 3);
            this.ctrlPrdTypeProfit.Name = "ctrlPrdTypeProfit";
            this.ctrlPrdTypeProfit.Size = new System.Drawing.Size(908, 467);
            this.ctrlPrdTypeProfit.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ctrlProductProfit);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(914, 473);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "产品";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ctrlProductProfit
            // 
            this.ctrlProductProfit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlProductProfit.Location = new System.Drawing.Point(3, 3);
            this.ctrlProductProfit.Name = "ctrlProductProfit";
            this.ctrlProductProfit.Size = new System.Drawing.Size(908, 467);
            this.ctrlProductProfit.TabIndex = 0;
            // 
            // FrmSaleProfitRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 545);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSaleProfitRpt";
            this.Text = "FrmSaleProfitRpt";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private JCommon.CtrlYear ctrlYearRpt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMainMoneyType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private CtrlCustomerProfit ctrlCustomerProfit;
        private System.Windows.Forms.TabPage tabPage2;
        private CtrlPrdTypeProfit ctrlPrdTypeProfit;
        private System.Windows.Forms.TabPage tabPage3;
        private CtrlProductProfit ctrlProductProfit;
    }
}