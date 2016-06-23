namespace JERPApp.Engineer
{
    partial class FrmSupplierPrdCode
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
            this.btnSave = new System.Windows.Forms.Button();
            this.ctrlSupplierPrdCode = new JERPApp.Engineer.CtrlSupplierPrdCode();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 304);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 32);
            this.panel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存设置";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // ctrlSupplierPrdCode
            // 
            this.ctrlSupplierPrdCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlSupplierPrdCode.Location = new System.Drawing.Point(0, 0);
            this.ctrlSupplierPrdCode.Name = "ctrlSupplierPrdCode";
            this.ctrlSupplierPrdCode.Size = new System.Drawing.Size(399, 304);
            this.ctrlSupplierPrdCode.TabIndex = 1;
            // 
            // FrmSupplierPrdCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 336);
            this.Controls.Add(this.ctrlSupplierPrdCode);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSupplierPrdCode";
            this.Text = "供应商及料号";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private CtrlSupplierPrdCode ctrlSupplierPrdCode;
    }
}