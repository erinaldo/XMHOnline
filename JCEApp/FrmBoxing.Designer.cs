namespace JCEApp
{
    partial class FrmBoxing
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
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxCode = new System.Windows.Forms.TextBox();
            this.txtPrdSpec = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrdCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrdName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlBoxItem = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(80, 4);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(235, 23);
            this.txtBarcode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.Text = "条码";
            // 
            // lblError
            // 
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(155, 3);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(144, 16);
            this.lblError.Text = "错误信息";
            // 
            // txtModel
            // 
            this.txtModel.BackColor = System.Drawing.SystemColors.Control;
            this.txtModel.Location = new System.Drawing.Point(245, 59);
            this.txtModel.Name = "txtModel";
            this.txtModel.ReadOnly = true;
            this.txtModel.Size = new System.Drawing.Size(67, 23);
            this.txtModel.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(206, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 18);
            this.label6.Text = "机型";
            // 
            // txtBoxCode
            // 
            this.txtBoxCode.BackColor = System.Drawing.SystemColors.Control;
            this.txtBoxCode.Location = new System.Drawing.Point(80, 30);
            this.txtBoxCode.Name = "txtBoxCode";
            this.txtBoxCode.ReadOnly = true;
            this.txtBoxCode.Size = new System.Drawing.Size(235, 23);
            this.txtBoxCode.TabIndex = 17;
            // 
            // txtPrdSpec
            // 
            this.txtPrdSpec.BackColor = System.Drawing.SystemColors.Control;
            this.txtPrdSpec.Location = new System.Drawing.Point(80, 111);
            this.txtPrdSpec.Name = "txtPrdSpec";
            this.txtPrdSpec.ReadOnly = true;
            this.txtPrdSpec.Size = new System.Drawing.Size(235, 23);
            this.txtPrdSpec.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 18);
            this.label3.Text = "产品编号";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(7, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 18);
            this.label5.Text = "产品规格";
            // 
            // txtPrdCode
            // 
            this.txtPrdCode.BackColor = System.Drawing.SystemColors.Control;
            this.txtPrdCode.Location = new System.Drawing.Point(80, 57);
            this.txtPrdCode.Name = "txtPrdCode";
            this.txtPrdCode.ReadOnly = true;
            this.txtPrdCode.Size = new System.Drawing.Size(120, 23);
            this.txtPrdCode.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.Text = "产品名称";
            // 
            // txtPrdName
            // 
            this.txtPrdName.BackColor = System.Drawing.SystemColors.Control;
            this.txtPrdName.Location = new System.Drawing.Point(80, 84);
            this.txtPrdName.Name = "txtPrdName";
            this.txtPrdName.ReadOnly = true;
            this.txtPrdName.Size = new System.Drawing.Size(235, 23);
            this.txtPrdName.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 23);
            this.label2.Text = "箱号";
            // 
            // pnlBoxItem
            // 
            this.pnlBoxItem.AutoScroll = true;
            this.pnlBoxItem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlBoxItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBoxItem.Location = new System.Drawing.Point(0, 137);
            this.pnlBoxItem.Name = "pnlBoxItem";
            this.pnlBoxItem.Size = new System.Drawing.Size(318, 258);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPrdCode);
            this.panel1.Controls.Add(this.txtBarcode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtModel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtPrdName);
            this.panel1.Controls.Add(this.txtBoxCode);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtPrdSpec);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 137);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Controls.Add(this.lblError);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 395);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(318, 30);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(80, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 24);
            this.btnCancel.TabIndex = 100;
            this.btnCancel.Text = "取消";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(5, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(69, 24);
            this.btnOK.TabIndex = 90;
            this.btnOK.Text = "确认";
            // 
            // FrmBoxing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(318, 425);
            this.Controls.Add(this.pnlBoxItem);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmBoxing";
            this.Text = "装拆箱";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxCode;
        private System.Windows.Forms.TextBox txtPrdSpec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrdCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrdName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlBoxItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}