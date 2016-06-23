namespace JCEApp
{
    partial class FrmChipset
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
            this.txtChipsetCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInfor = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtChipsetCode
            // 
            this.txtChipsetCode.Location = new System.Drawing.Point(68, 3);
            this.txtChipsetCode.Name = "txtChipsetCode";
            this.txtChipsetCode.Size = new System.Drawing.Size(227, 23);
            this.txtChipsetCode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.Text = "芯片码";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(68, 43);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(227, 23);
            this.txtBarcode.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.Text = "产品码";
            // 
            // lblInfor
            // 
            this.lblInfor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblInfor.ForeColor = System.Drawing.Color.Red;
            this.lblInfor.Location = new System.Drawing.Point(0, 96);
            this.lblInfor.Name = "lblInfor";
            this.lblInfor.Size = new System.Drawing.Size(310, 25);
            this.lblInfor.Text = "成功!";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtChipsetCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtBarcode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 93);
            // 
            // FrmChipset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(310, 121);
            this.Controls.Add(this.lblInfor);
            this.Controls.Add(this.panel1);
            this.Name = "FrmChipset";
            this.Text = "条码绑定";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtChipsetCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInfor;
        private System.Windows.Forms.Panel panel1;
    }
}