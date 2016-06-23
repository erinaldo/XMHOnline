namespace JERPApp.Manufacture.Boxing
{
    partial class FrmBoxNew
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
            this.txtWorkingSheetCode = new System.Windows.Forms.TextBox();
            this.txtPrdCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrdName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrdSpec = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOneBoxQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblUnitName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBoxQty = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPackingTypeName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBarcodeNonFinishedQty = new System.Windows.Forms.TextBox();
            this.dtpDateNote = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.ctrlPackingType = new JERPApp.Define.Product.CtrlPackingType();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "生产批号";
            // 
            // txtWorkingSheetCode
            // 
            this.txtWorkingSheetCode.Location = new System.Drawing.Point(72, 4);
            this.txtWorkingSheetCode.Name = "txtWorkingSheetCode";
            this.txtWorkingSheetCode.ReadOnly = true;
            this.txtWorkingSheetCode.Size = new System.Drawing.Size(138, 21);
            this.txtWorkingSheetCode.TabIndex = 1;
            // 
            // txtPrdCode
            // 
            this.txtPrdCode.Location = new System.Drawing.Point(277, 4);
            this.txtPrdCode.Name = "txtPrdCode";
            this.txtPrdCode.ReadOnly = true;
            this.txtPrdCode.Size = new System.Drawing.Size(138, 21);
            this.txtPrdCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "产品编号";
            // 
            // txtPrdName
            // 
            this.txtPrdName.Location = new System.Drawing.Point(480, 4);
            this.txtPrdName.Name = "txtPrdName";
            this.txtPrdName.ReadOnly = true;
            this.txtPrdName.Size = new System.Drawing.Size(133, 21);
            this.txtPrdName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(421, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "产品名称";
            // 
            // txtPrdSpec
            // 
            this.txtPrdSpec.Location = new System.Drawing.Point(677, 4);
            this.txtPrdSpec.Name = "txtPrdSpec";
            this.txtPrdSpec.ReadOnly = true;
            this.txtPrdSpec.Size = new System.Drawing.Size(144, 21);
            this.txtPrdSpec.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(615, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "产品规格";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(73, 29);
            this.txtModel.Name = "txtModel";
            this.txtModel.ReadOnly = true;
            this.txtModel.Size = new System.Drawing.Size(85, 21);
            this.txtModel.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "机型";
            // 
            // txtOneBoxQty
            // 
            this.txtOneBoxQty.Location = new System.Drawing.Point(226, 58);
            this.txtOneBoxQty.Name = "txtOneBoxQty";
            this.txtOneBoxQty.Size = new System.Drawing.Size(70, 21);
            this.txtOneBoxQty.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "未完成";
            // 
            // lblUnitName
            // 
            this.lblUnitName.AutoSize = true;
            this.lblUnitName.Location = new System.Drawing.Point(149, 64);
            this.lblUnitName.Name = "lblUnitName";
            this.lblUnitName.Size = new System.Drawing.Size(23, 12);
            this.lblUnitName.TabIndex = 12;
            this.lblUnitName.Text = "PCS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(303, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "外箱数";
            // 
            // txtBoxQty
            // 
            this.txtBoxQty.Location = new System.Drawing.Point(348, 59);
            this.txtBoxQty.Name = "txtBoxQty";
            this.txtBoxQty.Size = new System.Drawing.Size(45, 21);
            this.txtBoxQty.TabIndex = 14;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(399, 58);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 15;
            this.btnCreate.Text = "标签生成";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPackingTypeName);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtBarcodeNonFinishedQty);
            this.panel1.Controls.Add(this.dtpDateNote);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBoxQty);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtWorkingSheetCode);
            this.panel1.Controls.Add(this.lblUnitName);
            this.panel1.Controls.Add(this.txtPrdSpec);
            this.panel1.Controls.Add(this.txtOneBoxQty);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtPrdName);
            this.panel1.Controls.Add(this.txtModel);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPrdCode);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(824, 93);
            this.panel1.TabIndex = 18;
            // 
            // txtPackingTypeName
            // 
            this.txtPackingTypeName.Location = new System.Drawing.Point(225, 29);
            this.txtPackingTypeName.Name = "txtPackingTypeName";
            this.txtPackingTypeName.ReadOnly = true;
            this.txtPackingTypeName.Size = new System.Drawing.Size(112, 21);
            this.txtPackingTypeName.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(166, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "包装类型";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(178, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "单箱数";
            // 
            // txtBarcodeNonFinishedQty
            // 
            this.txtBarcodeNonFinishedQty.Location = new System.Drawing.Point(72, 56);
            this.txtBarcodeNonFinishedQty.Name = "txtBarcodeNonFinishedQty";
            this.txtBarcodeNonFinishedQty.ReadOnly = true;
            this.txtBarcodeNonFinishedQty.Size = new System.Drawing.Size(70, 21);
            this.txtBarcodeNonFinishedQty.TabIndex = 20;
            // 
            // dtpDateNote
            // 
            this.dtpDateNote.Location = new System.Drawing.Point(412, 27);
            this.dtpDateNote.Name = "dtpDateNote";
            this.dtpDateNote.Size = new System.Drawing.Size(130, 21);
            this.dtpDateNote.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(353, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "生产日期";
            // 
            // ctrlPackingType
            // 
            this.ctrlPackingType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPackingType.Location = new System.Drawing.Point(0, 93);
            this.ctrlPackingType.Name = "ctrlPackingType";
            this.ctrlPackingType.Size = new System.Drawing.Size(824, 340);
            this.ctrlPackingType.TabIndex = 19;
            // 
            // FrmBoxNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 433);
            this.Controls.Add(this.ctrlPackingType);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBoxNew";
            this.Text = "外箱标签生成";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWorkingSheetCode;
        private System.Windows.Forms.TextBox txtPrdCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrdName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrdSpec;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOneBoxQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblUnitName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBoxQty;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Panel panel1;
        private JERPApp.Define.Product.CtrlPackingType ctrlPackingType;
        private System.Windows.Forms.DateTimePicker dtpDateNote;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBarcodeNonFinishedQty;
        private System.Windows.Forms.TextBox txtPackingTypeName;
        private System.Windows.Forms.Label label10;
    }
}