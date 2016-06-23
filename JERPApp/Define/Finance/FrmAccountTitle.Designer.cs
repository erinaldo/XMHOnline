namespace JERPApp.Define.Finance
{
    partial class FrmAccountTitle
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlAccountType = new JERPApp.Define.Finance.CtrlAccountType();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSelect = new System.Windows.Forms.Button();
            this.lsbAccountTitle = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "类别";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlAccountType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 29);
            this.panel1.TabIndex = 2;
            // 
            // ctrlAccountType
            // 
            this.ctrlAccountType.Location = new System.Drawing.Point(37, 3);
            this.ctrlAccountType.Name = "ctrlAccountType";
            this.ctrlAccountType.Size = new System.Drawing.Size(207, 21);
            this.ctrlAccountType.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSelect);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 374);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(419, 27);
            this.panel2.TabIndex = 3;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(8, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "+加入";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // lsbAccountTitle
            // 
            this.lsbAccountTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbAccountTitle.FormattingEnabled = true;
            this.lsbAccountTitle.ItemHeight = 12;
            this.lsbAccountTitle.Location = new System.Drawing.Point(0, 29);
            this.lsbAccountTitle.Name = "lsbAccountTitle";
            this.lsbAccountTitle.Size = new System.Drawing.Size(419, 340);
            this.lsbAccountTitle.TabIndex = 4;
            // 
            // FrmAccountTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 401);
            this.Controls.Add(this.lsbAccountTitle);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmAccountTitle";
            this.Text = "科目选择";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lsbAccountTitle;
        private System.Windows.Forms.Button btnSelect;
        private CtrlAccountType ctrlAccountType;
    }
}
