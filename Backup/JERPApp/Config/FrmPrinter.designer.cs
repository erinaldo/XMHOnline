namespace JERPApp.Config
{
    partial class FrmPrinter
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放客供资源，为 true；否则为 false。</param>
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnRegedit = new System.Windows.Forms.Button();
            this.cmbNotePrinter = new System.Windows.Forms.ComboBox();
            this.cmbBoxPrinter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBoxItemPrinter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "多联打印机(送货单,退货单,补货单...)";
            // 
            // btnRegedit
            // 
            this.btnRegedit.Location = new System.Drawing.Point(14, 141);
            this.btnRegedit.Name = "btnRegedit";
            this.btnRegedit.Size = new System.Drawing.Size(75, 23);
            this.btnRegedit.TabIndex = 3;
            this.btnRegedit.Text = "设置";
            this.btnRegedit.UseVisualStyleBackColor = true;
            this.btnRegedit.Click += new System.EventHandler(this.btnRegedit_Click);
            // 
            // cmbNotePrinter
            // 
            this.cmbNotePrinter.FormattingEnabled = true;
            this.cmbNotePrinter.Location = new System.Drawing.Point(13, 24);
            this.cmbNotePrinter.Name = "cmbNotePrinter";
            this.cmbNotePrinter.Size = new System.Drawing.Size(233, 20);
            this.cmbNotePrinter.TabIndex = 2;
            // 
            // cmbBoxPrinter
            // 
            this.cmbBoxPrinter.FormattingEnabled = true;
            this.cmbBoxPrinter.Location = new System.Drawing.Point(12, 66);
            this.cmbBoxPrinter.Name = "cmbBoxPrinter";
            this.cmbBoxPrinter.Size = new System.Drawing.Size(233, 20);
            this.cmbBoxPrinter.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "外箱标签打印机";
            // 
            // cmbBoxItemPrinter
            // 
            this.cmbBoxItemPrinter.FormattingEnabled = true;
            this.cmbBoxItemPrinter.Location = new System.Drawing.Point(12, 106);
            this.cmbBoxItemPrinter.Name = "cmbBoxItemPrinter";
            this.cmbBoxItemPrinter.Size = new System.Drawing.Size(233, 20);
            this.cmbBoxItemPrinter.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "产品标签打印机";
            // 
            // FrmPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 192);
            this.Controls.Add(this.cmbBoxItemPrinter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbBoxPrinter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbNotePrinter);
            this.Controls.Add(this.btnRegedit);
            this.Controls.Add(this.label2);
            this.Name = "FrmPrinter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "票据打印机";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRegedit;
        private System.Windows.Forms.ComboBox cmbNotePrinter;
        private System.Windows.Forms.ComboBox cmbBoxPrinter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBoxItemPrinter;
        private System.Windows.Forms.Label label3;
    }
}