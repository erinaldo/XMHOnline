namespace JERPApp.Manufacture
{
    partial class FrmWIPOper
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
            this.lblPrdCode = new System.Windows.Forms.Label();
            this.txtPrdName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrdStatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDateFinished = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPrdSpec = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ctrlWorkgroupID = new JERPApp.Define.Manufacture.CtrlWorkgroup();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "生产批号";
            // 
            // txtWorkingSheetCode
            // 
            this.txtWorkingSheetCode.Location = new System.Drawing.Point(73, 3);
            this.txtWorkingSheetCode.Name = "txtWorkingSheetCode";
            this.txtWorkingSheetCode.ReadOnly = true;
            this.txtWorkingSheetCode.Size = new System.Drawing.Size(138, 21);
            this.txtWorkingSheetCode.TabIndex = 1;
            // 
            // txtPrdCode
            // 
            this.txtPrdCode.Location = new System.Drawing.Point(73, 31);
            this.txtPrdCode.Name = "txtPrdCode";
            this.txtPrdCode.ReadOnly = true;
            this.txtPrdCode.Size = new System.Drawing.Size(136, 21);
            this.txtPrdCode.TabIndex = 3;
            // 
            // lblPrdCode
            // 
            this.lblPrdCode.AutoSize = true;
            this.lblPrdCode.Location = new System.Drawing.Point(10, 34);
            this.lblPrdCode.Name = "lblPrdCode";
            this.lblPrdCode.Size = new System.Drawing.Size(53, 12);
            this.lblPrdCode.TabIndex = 2;
            this.lblPrdCode.Text = "产品编号";
            // 
            // txtPrdName
            // 
            this.txtPrdName.Location = new System.Drawing.Point(278, 30);
            this.txtPrdName.Name = "txtPrdName";
            this.txtPrdName.ReadOnly = true;
            this.txtPrdName.Size = new System.Drawing.Size(136, 21);
            this.txtPrdName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "产品名称";
            // 
            // txtPrdStatus
            // 
            this.txtPrdStatus.Location = new System.Drawing.Point(74, 86);
            this.txtPrdStatus.Name = "txtPrdStatus";
            this.txtPrdStatus.ReadOnly = true;
            this.txtPrdStatus.Size = new System.Drawing.Size(136, 21);
            this.txtPrdStatus.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "工序名称";
            // 
            // dtpDateFinished
            // 
            this.dtpDateFinished.CustomFormat = "yyyy-MM-dd H:mm";
            this.dtpDateFinished.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFinished.Location = new System.Drawing.Point(73, 113);
            this.dtpDateFinished.Name = "dtpDateFinished";
            this.dtpDateFinished.Size = new System.Drawing.Size(138, 21);
            this.dtpDateFinished.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "完成时间";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(317, 152);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 23);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(277, 116);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(136, 21);
            this.txtQuantity.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(221, 122);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 25;
            this.label12.Text = "完成数";
            // 
            // txtPrdSpec
            // 
            this.txtPrdSpec.Location = new System.Drawing.Point(73, 58);
            this.txtPrdSpec.Name = "txtPrdSpec";
            this.txtPrdSpec.ReadOnly = true;
            this.txtPrdSpec.Size = new System.Drawing.Size(136, 21);
            this.txtPrdSpec.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "产品规格";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(278, 57);
            this.txtModel.Name = "txtModel";
            this.txtModel.ReadOnly = true;
            this.txtModel.Size = new System.Drawing.Size(136, 21);
            this.txtModel.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(222, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "机型";
            // 
            // ctrlWorkgroupID
            // 
            this.ctrlWorkgroupID.AutoSize = true;
            this.ctrlWorkgroupID.Location = new System.Drawing.Point(278, 86);
            this.ctrlWorkgroupID.Name = "ctrlWorkgroupID";
            this.ctrlWorkgroupID.Size = new System.Drawing.Size(135, 23);
            this.ctrlWorkgroupID.TabIndex = 32;
            this.ctrlWorkgroupID.WorkgroupID = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(222, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 33;
            this.label5.Text = "机组";
            // 
            // FrmWIPOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 188);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ctrlWorkgroupID);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPrdSpec);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpDateFinished);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPrdStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrdName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrdCode);
            this.Controls.Add(this.lblPrdCode);
            this.Controls.Add(this.txtWorkingSheetCode);
            this.Controls.Add(this.label1);
            this.Name = "FrmWIPOper";
            this.Text = "进程统计";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWorkingSheetCode;
        private System.Windows.Forms.TextBox txtPrdCode;
        private System.Windows.Forms.Label lblPrdCode;
        private System.Windows.Forms.TextBox txtPrdName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrdStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDateFinished;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPrdSpec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label6;
        private JERPApp.Define.Manufacture.CtrlWorkgroup ctrlWorkgroupID;
        private System.Windows.Forms.Label label5;
    }
}