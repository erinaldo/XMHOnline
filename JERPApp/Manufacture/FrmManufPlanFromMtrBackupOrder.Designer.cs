namespace JERPApp.Manufacture
{
    partial class FrmManufPlanFromMtrBackupOrder
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
            this.label13 = new System.Windows.Forms.Label();
            this.radBuyFlag = new System.Windows.Forms.RadioButton();
            this.radManufFlag = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblUnitName = new System.Windows.Forms.Label();
            this.ctrlPrdID = new JERPApp.Define.Product.CtrlManufPrd();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rchMemo = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ctrlCompanyID = new JERPApp.Define.General.CtrlCustomer();
            this.dtpDateTarget = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 169);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 56;
            this.label13.Text = "处理方式";
            // 
            // radBuyFlag
            // 
            this.radBuyFlag.AutoSize = true;
            this.radBuyFlag.Location = new System.Drawing.Point(128, 167);
            this.radBuyFlag.Name = "radBuyFlag";
            this.radBuyFlag.Size = new System.Drawing.Size(71, 16);
            this.radBuyFlag.TabIndex = 57;
            this.radBuyFlag.Text = "直接采购";
            this.radBuyFlag.UseVisualStyleBackColor = true;
            // 
            // radManufFlag
            // 
            this.radManufFlag.AutoSize = true;
            this.radManufFlag.Checked = true;
            this.radManufFlag.Location = new System.Drawing.Point(71, 166);
            this.radManufFlag.Name = "radManufFlag";
            this.radManufFlag.Size = new System.Drawing.Size(47, 16);
            this.radManufFlag.TabIndex = 58;
            this.radManufFlag.TabStop = true;
            this.radManufFlag.Text = "生产";
            this.radManufFlag.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(233, 162);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 23);
            this.btnSave.TabIndex = 61;
            this.btnSave.Text = "计划生成";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 62;
            this.label2.Text = "数量";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(220, 39);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(74, 21);
            this.txtQuantity.TabIndex = 63;
            // 
            // lblUnitName
            // 
            this.lblUnitName.AutoSize = true;
            this.lblUnitName.Location = new System.Drawing.Point(300, 48);
            this.lblUnitName.Name = "lblUnitName";
            this.lblUnitName.Size = new System.Drawing.Size(29, 12);
            this.lblUnitName.TabIndex = 64;
            this.lblUnitName.Text = "单位";
            // 
            // ctrlPrdID
            // 
            this.ctrlPrdID.AutoSize = true;
            this.ctrlPrdID.Location = new System.Drawing.Point(9, 7);
            this.ctrlPrdID.Name = "ctrlPrdID";
            this.ctrlPrdID.PrdID = -1;
            this.ctrlPrdID.Size = new System.Drawing.Size(631, 29);
            this.ctrlPrdID.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 66;
            this.label1.Text = "交货日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 68;
            this.label3.Text = "备注";
            // 
            // rchMemo
            // 
            this.rchMemo.Location = new System.Drawing.Point(41, 71);
            this.rchMemo.Name = "rchMemo";
            this.rchMemo.Size = new System.Drawing.Size(597, 85);
            this.rchMemo.TabIndex = 69;
            this.rchMemo.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 88;
            this.label6.Text = "客户";
            // 
            // ctrlCompanyID
            // 
            this.ctrlCompanyID.CompanyID = -1;
            this.ctrlCompanyID.Location = new System.Drawing.Point(41, 42);
            this.ctrlCompanyID.Name = "ctrlCompanyID";
            this.ctrlCompanyID.Size = new System.Drawing.Size(142, 23);
            this.ctrlCompanyID.TabIndex = 87;
            // 
            // dtpDateTarget
            // 
            this.dtpDateTarget.CustomFormat = "yyyy-MM-d H:m";
            this.dtpDateTarget.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTarget.Location = new System.Drawing.Point(406, 39);
            this.dtpDateTarget.Name = "dtpDateTarget";
            this.dtpDateTarget.Size = new System.Drawing.Size(134, 21);
            this.dtpDateTarget.TabIndex = 89;
            // 
            // FrmWorkingSheetFromMtrBackupOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 194);
            this.Controls.Add(this.dtpDateTarget);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ctrlCompanyID);
            this.Controls.Add(this.rchMemo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlPrdID);
            this.Controls.Add(this.lblUnitName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.radBuyFlag);
            this.Controls.Add(this.radManufFlag);
            this.Name = "FrmWorkingSheetFromMtrBackupOrder";
            this.Text = "原料备库下单";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton radBuyFlag;
        private System.Windows.Forms.RadioButton radManufFlag;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblUnitName;
        private JERPApp.Define.Product.CtrlManufPrd ctrlPrdID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rchMemo;
        private System.Windows.Forms.Label label6;
        private JERPApp.Define.General.CtrlCustomer ctrlCompanyID;
        private System.Windows.Forms.DateTimePicker dtpDateTarget;
    }
}