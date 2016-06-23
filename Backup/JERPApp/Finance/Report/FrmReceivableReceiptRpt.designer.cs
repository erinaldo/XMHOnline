namespace JERPApp.Finance.Report
{
    partial class FrmReceivableReceiptRpt
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
            this.ctrlReceivableCashSettleRpt = new JERPApp.Finance.Report.CtrlReceivableCashReceiptRpt();
            this.ctrlReceivableReconciliationSettleRpt = new JERPApp.Finance.Report.CtrlReceivableReconciliationReceiptRpt();
            this.panel1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 34);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(388, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "应收结款报告";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 34);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(933, 469);
            this.tabMain.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ctrlReceivableCashSettleRpt);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(925, 443);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "订单现结";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctrlReceivableReconciliationSettleRpt);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(925, 443);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "对账单月结";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ctrlReceivableCashSettleRpt
            // 
            this.ctrlReceivableCashSettleRpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlReceivableCashSettleRpt.Location = new System.Drawing.Point(3, 3);
            this.ctrlReceivableCashSettleRpt.Name = "ctrlReceivableCashSettleRpt";
            this.ctrlReceivableCashSettleRpt.Size = new System.Drawing.Size(919, 437);
            this.ctrlReceivableCashSettleRpt.TabIndex = 0;
            // 
            // ctrlReceivableReconciliationSettleRpt
            // 
            this.ctrlReceivableReconciliationSettleRpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlReceivableReconciliationSettleRpt.Location = new System.Drawing.Point(3, 3);
            this.ctrlReceivableReconciliationSettleRpt.Name = "ctrlReceivableReconciliationSettleRpt";
            this.ctrlReceivableReconciliationSettleRpt.Size = new System.Drawing.Size(919, 437);
            this.ctrlReceivableReconciliationSettleRpt.TabIndex = 0;
            // 
            // FrmReceivableReceiptRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 503);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReceivableReceiptRpt";
            this.Text = "FrmReceivaleReceiptRpt";
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
        private System.Windows.Forms.TabPage tabPage2;
        private CtrlReceivableCashReceiptRpt ctrlReceivableCashSettleRpt;
        private CtrlReceivableReconciliationReceiptRpt ctrlReceivableReconciliationSettleRpt;
    }
}