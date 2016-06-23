namespace JERPApp.Manufacture
{
    partial class FrmManufPlanAdjust
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctrlManufPlanAdjust = new JERPApp.Manufacture.CtrlManufPlanAdjust();
            this.ctrlPackingPlanAdjust = new JERPApp.Manufacture.CtrlPackingPlanAdjust();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(902, 31);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(417, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "计划尾数调整";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(902, 467);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ctrlManufPlanAdjust);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(894, 441);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "生产计划";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctrlPackingPlanAdjust);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(894, 441);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "包装计划";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ctrlManufPlanAdjust
            // 
            this.ctrlManufPlanAdjust.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlManufPlanAdjust.Location = new System.Drawing.Point(3, 3);
            this.ctrlManufPlanAdjust.Name = "ctrlManufPlanAdjust";
            this.ctrlManufPlanAdjust.Size = new System.Drawing.Size(888, 435);
            this.ctrlManufPlanAdjust.TabIndex = 0;
            // 
            // ctrlPackingPlanAdjust
            // 
            this.ctrlPackingPlanAdjust.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPackingPlanAdjust.Location = new System.Drawing.Point(3, 3);
            this.ctrlPackingPlanAdjust.Name = "ctrlPackingPlanAdjust";
            this.ctrlPackingPlanAdjust.Size = new System.Drawing.Size(888, 435);
            this.ctrlPackingPlanAdjust.TabIndex = 0;
            // 
            // FrmManufPlanAdjust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 498);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmManufPlanAdjust";
            this.Text = "FrmManufPlanAdjust";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private CtrlManufPlanAdjust ctrlManufPlanAdjust;
        private System.Windows.Forms.TabPage tabPage2;
        private CtrlPackingPlanAdjust ctrlPackingPlanAdjust;
    }
}