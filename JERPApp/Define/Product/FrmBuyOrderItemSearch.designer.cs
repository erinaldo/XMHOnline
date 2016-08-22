namespace JERPApp.Define.Product
{
    partial class FrmBuyOrderItemSearchItem
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
        /// 使用代码变更器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpNoteEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpNoteBegin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbDateTarget = new System.Windows.Forms.CheckBox();
            this.txtPONo = new System.Windows.Forms.TextBox();
            this.ckbPONo = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ckbCompany = new System.Windows.Forms.CheckBox();
            this.ckbPrd = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ctrlSupplierID = new JERPApp.Define.General.CtrlSupplierForProduct();
            this.ctrlPrdID = new JERPApp.Define.Product.CtrlProduct();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpNoteEnd
            // 
            this.dtpNoteEnd.Location = new System.Drawing.Point(251, 110);
            this.dtpNoteEnd.Name = "dtpNoteEnd";
            this.dtpNoteEnd.Size = new System.Drawing.Size(119, 21);
            this.dtpNoteEnd.TabIndex = 24;
            // 
            // dtpNoteBegin
            // 
            this.dtpNoteBegin.Location = new System.Drawing.Point(103, 109);
            this.dtpNoteBegin.Name = "dtpNoteBegin";
            this.dtpNoteBegin.Size = new System.Drawing.Size(119, 21);
            this.dtpNoteBegin.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "到";
            // 
            // ckbDateTarget
            // 
            this.ckbDateTarget.AutoSize = true;
            this.ckbDateTarget.Location = new System.Drawing.Point(7, 113);
            this.ckbDateTarget.Name = "ckbDateTarget";
            this.ckbDateTarget.Size = new System.Drawing.Size(90, 16);
            this.ckbDateTarget.TabIndex = 21;
            this.ckbDateTarget.Text = "交货时间 从";
            this.ckbDateTarget.UseVisualStyleBackColor = true;
            // 
            // txtPONo
            // 
            this.txtPONo.Location = new System.Drawing.Point(116, 42);
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.Size = new System.Drawing.Size(124, 21);
            this.txtPONo.TabIndex = 42;
            // 
            // ckbPONo
            // 
            this.ckbPONo.AutoSize = true;
            this.ckbPONo.Location = new System.Drawing.Point(7, 44);
            this.ckbPONo.Name = "ckbPONo";
            this.ckbPONo.Size = new System.Drawing.Size(72, 16);
            this.ckbPONo.TabIndex = 41;
            this.ckbPONo.Text = "订单编号";
            this.ckbPONo.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(388, 146);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 29;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(479, 146);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ckbCompany
            // 
            this.ckbCompany.AutoSize = true;
            this.ckbCompany.Location = new System.Drawing.Point(7, 18);
            this.ckbCompany.Name = "ckbCompany";
            this.ckbCompany.Size = new System.Drawing.Size(60, 16);
            this.ckbCompany.TabIndex = 31;
            this.ckbCompany.Text = "供应商";
            this.ckbCompany.UseVisualStyleBackColor = true;
            // 
            // ckbPrd
            // 
            this.ckbPrd.AutoSize = true;
            this.ckbPrd.Location = new System.Drawing.Point(7, 80);
            this.ckbPrd.Name = "ckbPrd";
            this.ckbPrd.Size = new System.Drawing.Size(15, 14);
            this.ckbPrd.TabIndex = 35;
            this.ckbPrd.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ctrlSupplierID);
            this.groupBox2.Controls.Add(this.txtPONo);
            this.groupBox2.Controls.Add(this.ckbPONo);
            this.groupBox2.Controls.Add(this.ckbDateTarget);
            this.groupBox2.Controls.Add(this.ctrlPrdID);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.ckbPrd);
            this.groupBox2.Controls.Add(this.dtpNoteBegin);
            this.groupBox2.Controls.Add(this.dtpNoteEnd);
            this.groupBox2.Controls.Add(this.ckbCompany);
            this.groupBox2.Location = new System.Drawing.Point(12, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(719, 137);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            // 
            // ctrlSupplierID
            // 
            this.ctrlSupplierID.CompanyID = 1;
            this.ctrlSupplierID.Location = new System.Drawing.Point(116, 13);
            this.ctrlSupplierID.Name = "ctrlSupplierID";
            this.ctrlSupplierID.Size = new System.Drawing.Size(195, 23);
            this.ctrlSupplierID.TabIndex = 43;
            // 
            // ctrlPrdID
            // 
            this.ctrlPrdID.AutoSize = true;
            this.ctrlPrdID.Location = new System.Drawing.Point(23, 69);
            this.ctrlPrdID.Name = "ctrlPrdID";
            this.ctrlPrdID.PrdID = -1;
            this.ctrlPrdID.Size = new System.Drawing.Size(643, 30);
            this.ctrlPrdID.TabIndex = 36;
            // 
            // FrmBuyOrderItemSearchItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 174);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSearch);
            this.Name = "FrmBuyOrderItemSearchItem";
            this.Text = "产品采购订购明细检索";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpNoteEnd;
        private System.Windows.Forms.DateTimePicker dtpNoteBegin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckbDateTarget;
        private System.Windows.Forms.TextBox txtPONo;
        private System.Windows.Forms.CheckBox ckbPONo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox ckbCompany;
        private System.Windows.Forms.CheckBox ckbPrd;
        private JERPApp.Define.Product .CtrlProduct ctrlPrdID;
        private System.Windows.Forms.GroupBox groupBox2;
        private JERPApp.Define.General.CtrlSupplierForProduct ctrlSupplierID;
    }
}