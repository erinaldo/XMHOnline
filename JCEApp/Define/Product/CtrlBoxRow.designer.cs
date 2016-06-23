namespace JCEApp.Define.Product
{
    partial class CtrlBoxRow
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
            this.txtBoxCode = new System.Windows.Forms.TextBox();
            this.pnlRow = new System.Windows.Forms.Panel();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtPrdName = new System.Windows.Forms.TextBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnlRow.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxCode
            // 
            this.txtBoxCode.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtBoxCode.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txtBoxCode.Location = new System.Drawing.Point(0, 0);
            this.txtBoxCode.Name = "txtBoxCode";
            this.txtBoxCode.ReadOnly = true;
            this.txtBoxCode.Size = new System.Drawing.Size(110, 21);
            this.txtBoxCode.TabIndex = 0;
            // 
            // pnlRow
            // 
            this.pnlRow.Controls.Add(this.txtQuantity);
            this.pnlRow.Controls.Add(this.txtBoxCode);
            this.pnlRow.Controls.Add(this.txtPrdName);
            this.pnlRow.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRow.Location = new System.Drawing.Point(0, 22);
            this.pnlRow.Name = "pnlRow";
            this.pnlRow.Size = new System.Drawing.Size(300, 22);
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtQuantity.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txtQuantity.Location = new System.Drawing.Point(258, 0);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.Size = new System.Drawing.Size(41, 21);
            this.txtQuantity.TabIndex = 3;
            // 
            // txtPrdName
            // 
            this.txtPrdName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtPrdName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txtPrdName.Location = new System.Drawing.Point(110, 0);
            this.txtPrdName.Name = "txtPrdName";
            this.txtPrdName.ReadOnly = true;
            this.txtPrdName.Size = new System.Drawing.Size(148, 21);
            this.txtPrdName.TabIndex = 2;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.textBox2);
            this.pnlHeader.Controls.Add(this.textBox5);
            this.pnlHeader.Controls.Add(this.textBox1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(300, 22);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.textBox2.Location = new System.Drawing.Point(258, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(41, 21);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "数量";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.textBox5.Location = new System.Drawing.Point(0, 0);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(110, 21);
            this.textBox5.TabIndex = 0;
            this.textBox5.Text = "箱号";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.textBox1.Location = new System.Drawing.Point(110, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(148, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "产品名称";
            // 
            // CtrlBoxRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pnlRow);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.Name = "CtrlBoxRow";
            this.Size = new System.Drawing.Size(300, 44);
            this.pnlRow.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxCode;
        private System.Windows.Forms.Panel pnlRow;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox txtPrdName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox textBox2;
    }
}
