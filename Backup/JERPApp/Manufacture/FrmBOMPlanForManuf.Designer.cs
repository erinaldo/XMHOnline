namespace JERPApp.Manufacture
{
    partial class FrmBOMPlanForManuf
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlPrdID = new JERPApp.Define.Product.CtrlProduct();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctrlCustomerID = new JERPApp.Define.General.CtrlCustomer();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.ctrlPrdID);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.ctrlCustomerID);
            this.panel2.Controls.Add(this.txtQuantity);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(934, 59);
            this.panel2.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 98;
            this.label1.Text = "客户";
            // 
            // ctrlPrdID
            // 
            this.ctrlPrdID.AutoSize = true;
            this.ctrlPrdID.Location = new System.Drawing.Point(12, 3);
            this.ctrlPrdID.Name = "ctrlPrdID";
            this.ctrlPrdID.PrdID = -1;
            this.ctrlPrdID.Size = new System.Drawing.Size(631, 29);
            this.ctrlPrdID.TabIndex = 97;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(529, 35);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 23);
            this.btnSave.TabIndex = 96;
            this.btnSave.Text = "物料计划保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // ctrlCustomerID
            // 
            this.ctrlCustomerID.CompanyID = -1;
            this.ctrlCustomerID.Location = new System.Drawing.Point(225, 34);
            this.ctrlCustomerID.Name = "ctrlCustomerID";
            this.ctrlCustomerID.Size = new System.Drawing.Size(137, 23);
            this.ctrlCustomerID.TabIndex = 93;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(49, 34);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(119, 21);
            this.txtQuantity.TabIndex = 81;
            this.txtQuantity.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 80;
            this.label10.Text = "数量";
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 59);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(934, 553);
            this.tabMain.TabIndex = 23;
            // 
            // FrmBOMPlanForManuf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 612);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel2);
            this.Name = "FrmBOMPlanForManuf";
            this.Text = "生产物料计划";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.Button btnSave;
        private JERPApp.Define.General.CtrlCustomer ctrlCustomerID;
        private JERPApp.Define.Product.CtrlProduct ctrlPrdID;
        private System.Windows.Forms.Label label1;
    }
}