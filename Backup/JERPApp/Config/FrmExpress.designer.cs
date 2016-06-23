namespace JERPApp.Config
{
    partial class FrmExpress
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCopies = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.ctrlExpress = new JERPApp.Define.General.CtrlExpress();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlCustomer = new JERPApp.Define.General.CtrlCustomer();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtLinkman = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFromCustomer = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFromSupplier = new System.Windows.Forms.Button();
            this.ctrlSupplier = new JERPApp.Define.General.CtrlSupplier();
            this.label9 = new System.Windows.Forms.Label();
            this.ctrlDeliverAddress = new JERPApp.Define.General.CtrlDeliverAddress();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "快递类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "份数";
            // 
            // txtCopies
            // 
            this.txtCopies.Location = new System.Drawing.Point(278, 15);
            this.txtCopies.Name = "txtCopies";
            this.txtCopies.Size = new System.Drawing.Size(29, 21);
            this.txtCopies.TabIndex = 3;
            this.txtCopies.Text = "1";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(83, 341);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "输出打印";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // ctrlExpress
            // 
            this.ctrlExpress.AutoSize = true;
            this.ctrlExpress.CompanyID = -1;
            this.ctrlExpress.Location = new System.Drawing.Point(83, 13);
            this.ctrlExpress.Name = "ctrlExpress";
            this.ctrlExpress.Size = new System.Drawing.Size(140, 23);
            this.ctrlExpress.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "客户";
            // 
            // ctrlCustomer
            // 
            this.ctrlCustomer.CompanyID = -1;
            this.ctrlCustomer.Location = new System.Drawing.Point(68, 20);
            this.ctrlCustomer.Name = "ctrlCustomer";
            this.ctrlCustomer.Size = new System.Drawing.Size(277, 23);
            this.ctrlCustomer.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "送货地";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(83, 274);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(325, 21);
            this.txtAddress.TabIndex = 8;
            // 
            // txtLinkman
            // 
            this.txtLinkman.Location = new System.Drawing.Point(83, 301);
            this.txtLinkman.Name = "txtLinkman";
            this.txtLinkman.Size = new System.Drawing.Size(95, 21);
            this.txtLinkman.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 311);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "联系人";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(245, 301);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(115, 21);
            this.txtTelephone.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(186, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "联系电话";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ctrlDeliverAddress);
            this.groupBox1.Controls.Add(this.btnFromCustomer);
            this.groupBox1.Controls.Add(this.ctrlCustomer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(15, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 116);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "从客户";
            // 
            // btnFromCustomer
            // 
            this.btnFromCustomer.Location = new System.Drawing.Point(270, 78);
            this.btnFromCustomer.Name = "btnFromCustomer";
            this.btnFromCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnFromCustomer.TabIndex = 9;
            this.btnFromCustomer.Text = "生成";
            this.btnFromCustomer.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "公司名称";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(83, 244);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(325, 21);
            this.txtCompanyName.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFromSupplier);
            this.groupBox2.Controls.Add(this.ctrlSupplier);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(15, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(391, 51);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "从供应商";
            // 
            // btnFromSupplier
            // 
            this.btnFromSupplier.Location = new System.Drawing.Point(285, 17);
            this.btnFromSupplier.Name = "btnFromSupplier";
            this.btnFromSupplier.Size = new System.Drawing.Size(75, 23);
            this.btnFromSupplier.TabIndex = 11;
            this.btnFromSupplier.Text = "生成";
            this.btnFromSupplier.UseVisualStyleBackColor = true;
            // 
            // ctrlSupplier
            // 
            this.ctrlSupplier.CompanyID = -1;
            this.ctrlSupplier.Location = new System.Drawing.Point(66, 17);
            this.ctrlSupplier.Name = "ctrlSupplier";
            this.ctrlSupplier.Size = new System.Drawing.Size(195, 23);
            this.ctrlSupplier.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "供应商";
            // 
            // ctrlDeliverAddress
            // 
            this.ctrlDeliverAddress.DeliverAddressID = -1;
            this.ctrlDeliverAddress.Location = new System.Drawing.Point(68, 49);
            this.ctrlDeliverAddress.Name = "ctrlDeliverAddress";
            this.ctrlDeliverAddress.Size = new System.Drawing.Size(277, 23);
            this.ctrlDeliverAddress.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "送货地";
            // 
            // FrmExpress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 415);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLinkman);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.txtCopies);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlExpress);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmExpress";
            this.Text = "快递打印";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private JERPApp.Define.General.CtrlExpress ctrlExpress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCopies;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label3;
        private JERPApp.Define.General.CtrlCustomer ctrlCustomer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtLinkman;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Button btnFromCustomer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnFromSupplier;
        private JERPApp.Define.General.CtrlSupplier ctrlSupplier;
        private System.Windows.Forms.Label label8;
        private JERPApp.Define.General.CtrlDeliverAddress ctrlDeliverAddress;
    }
}