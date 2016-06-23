namespace JERPApp.Finance.Report
{
    partial class FrmReceivableReconciliationRpt
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
            this.ctrlSaleReconciliationRpt = new JERPApp.Finance.Report.CtrlSaleReconciliationRpt();
            this.panel1.SuspendLayout();
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
            this.label1.Size = new System.Drawing.Size(127, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "客户货款对账报告";
            // 
            // ctrlSaleReconciliationRpt
            // 
            this.ctrlSaleReconciliationRpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlSaleReconciliationRpt.Location = new System.Drawing.Point(0, 37);
            this.ctrlSaleReconciliationRpt.Name = "ctrlSaleReconciliationRpt";
            this.ctrlSaleReconciliationRpt.Size = new System.Drawing.Size(882, 456);
            this.ctrlSaleReconciliationRpt.TabIndex = 2;
            // 
            // FrmReceivableReconciliationRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 493);
            this.Controls.Add(this.ctrlSaleReconciliationRpt);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReceivableReconciliationRpt";
            this.Text = "FrmReceivableReconciliationRpt";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private JCommon.CtrlYear ctrlYear;
        private System.Windows.Forms.Label label2;
        private CtrlSaleReconciliationRpt ctrlSaleReconciliationRpt;
    }
}