namespace JERPApp.Define.Product
{
    partial class CtrlSaleOrderRequireType
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ckbRequreTypeName = new System.Windows.Forms.CheckBox();
            this.cmbRequireValue = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ckbRequreTypeName
            // 
            this.ckbRequreTypeName.AutoSize = true;
            this.ckbRequreTypeName.Dock = System.Windows.Forms.DockStyle.Left;
            this.ckbRequreTypeName.Location = new System.Drawing.Point(0, 0);
            this.ckbRequreTypeName.Name = "ckbRequreTypeName";
            this.ckbRequreTypeName.Size = new System.Drawing.Size(48, 22);
            this.ckbRequreTypeName.TabIndex = 0;
            this.ckbRequreTypeName.Text = "类别";
            this.ckbRequreTypeName.UseVisualStyleBackColor = true;
            // 
            // cmbRequireValue
            // 
            this.cmbRequireValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmbRequireValue.FormattingEnabled = true;
            this.cmbRequireValue.Location = new System.Drawing.Point(48, 2);
            this.cmbRequireValue.Name = "cmbRequireValue";
            this.cmbRequireValue.Size = new System.Drawing.Size(317, 20);
            this.cmbRequireValue.TabIndex = 1;
            // 
            // CtrlSaleOrderRequireType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbRequireValue);
            this.Controls.Add(this.ckbRequreTypeName);
            this.Name = "CtrlSaleOrderRequireType";
            this.Size = new System.Drawing.Size(365, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbRequreTypeName;
        private System.Windows.Forms.ComboBox cmbRequireValue;
    }
}
