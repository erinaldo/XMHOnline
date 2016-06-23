namespace JERPApp.Manufacture
{
    partial class FrmPackingPlanOper
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
            this.lblUnitName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDateTarget = new System.Windows.Forms.DateTimePicker();
            this.rchMemo = new System.Windows.Forms.RichTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.ckbBOMPlanFlag = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateNote = new System.Windows.Forms.DateTimePicker();
            this.ctrlPrdID = new JERPApp.Define.Product.CtrlFinishedPrd();
            this.ctrlPackingTypeID = new JERPApp.Define.Product.CtrlPrdPackingType();
            this.ctrlCompanyID = new JERPApp.Define.General.CtrlCustomer();
            this.SuspendLayout();
            // 
            // lblUnitName
            // 
            this.lblUnitName.AutoSize = true;
            this.lblUnitName.Location = new System.Drawing.Point(124, 67);
            this.lblUnitName.Name = "lblUnitName";
            this.lblUnitName.Size = new System.Drawing.Size(29, 12);
            this.lblUnitName.TabIndex = 69;
            this.lblUnitName.Text = "单位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 67;
            this.label2.Text = "数量";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(44, 62);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(74, 21);
            this.txtQuantity.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 75;
            this.label3.Text = "计划日期";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 77;
            this.label4.Text = "交货日期";
            // 
            // dtpDateTarget
            // 
            this.dtpDateTarget.Location = new System.Drawing.Point(65, 191);
            this.dtpDateTarget.Name = "dtpDateTarget";
            this.dtpDateTarget.Size = new System.Drawing.Size(161, 21);
            this.dtpDateTarget.TabIndex = 78;
            // 
            // rchMemo
            // 
            this.rchMemo.Location = new System.Drawing.Point(44, 89);
            this.rchMemo.Name = "rchMemo";
            this.rchMemo.Size = new System.Drawing.Size(595, 94);
            this.rchMemo.TabIndex = 80;
            this.rchMemo.Text = "";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 92);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 79;
            this.label18.Text = "备注";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(15, 239);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 81;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(176, 239);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 82;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(189, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 86;
            this.label6.Text = "客户";
            // 
            // ckbBOMPlanFlag
            // 
            this.ckbBOMPlanFlag.AutoSize = true;
            this.ckbBOMPlanFlag.Enabled = false;
            this.ckbBOMPlanFlag.Location = new System.Drawing.Point(246, 196);
            this.ckbBOMPlanFlag.Name = "ckbBOMPlanFlag";
            this.ckbBOMPlanFlag.Size = new System.Drawing.Size(72, 16);
            this.ckbBOMPlanFlag.TabIndex = 88;
            this.ckbBOMPlanFlag.Text = "物料计划";
            this.ckbBOMPlanFlag.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 90;
            this.label1.Text = "包装类型";
            // 
            // dtpDateNote
            // 
            this.dtpDateNote.Location = new System.Drawing.Point(62, 3);
            this.dtpDateNote.Name = "dtpDateNote";
            this.dtpDateNote.Size = new System.Drawing.Size(121, 21);
            this.dtpDateNote.TabIndex = 92;
            // 
            // ctrlPrdID
            // 
            this.ctrlPrdID.AutoSize = true;
            this.ctrlPrdID.Location = new System.Drawing.Point(3, 32);
            this.ctrlPrdID.Name = "ctrlPrdID";
            this.ctrlPrdID.PrdID = -1;
            this.ctrlPrdID.Size = new System.Drawing.Size(631, 29);
            this.ctrlPrdID.TabIndex = 91;
            // 
            // ctrlPackingTypeID
            // 
            this.ctrlPackingTypeID.Location = new System.Drawing.Point(232, 62);
            this.ctrlPackingTypeID.Name = "ctrlPackingTypeID";
            this.ctrlPackingTypeID.PackingTypeID = -1;
            this.ctrlPackingTypeID.Size = new System.Drawing.Size(154, 23);
            this.ctrlPackingTypeID.TabIndex = 89;
            // 
            // ctrlCompanyID
            // 
            this.ctrlCompanyID.CompanyID = 1;
            this.ctrlCompanyID.Location = new System.Drawing.Point(229, 3);
            this.ctrlCompanyID.Name = "ctrlCompanyID";
            this.ctrlCompanyID.Size = new System.Drawing.Size(126, 23);
            this.ctrlCompanyID.TabIndex = 85;
            // 
            // FrmPackingPlanOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 274);
            this.Controls.Add(this.dtpDateNote);
            this.Controls.Add(this.ctrlPrdID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlPackingTypeID);
            this.Controls.Add(this.ckbBOMPlanFlag);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ctrlCompanyID);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rchMemo);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.dtpDateTarget);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblUnitName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQuantity);
            this.Name = "FrmPackingPlanOper";
            this.Text = "包装计划";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUnitName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDateTarget;
        private System.Windows.Forms.RichTextBox rchMemo;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private JERPApp.Define.General.CtrlCustomer ctrlCompanyID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ckbBOMPlanFlag;
        private JERPApp.Define.Product.CtrlPrdPackingType ctrlPackingTypeID;
        private System.Windows.Forms.Label label1;
        private JERPApp.Define.Product.CtrlFinishedPrd ctrlPrdID;
        private System.Windows.Forms.DateTimePicker dtpDateNote;
    }
}