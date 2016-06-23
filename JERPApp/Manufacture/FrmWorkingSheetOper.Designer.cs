namespace JERPApp.Manufacture
{
    partial class FrmWorkingSheetOper
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radMtrStore = new System.Windows.Forms.RadioButton();
            this.radPrdStore = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.txtWorkingSheetCode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpDateTarget = new System.Windows.Forms.DateTimePicker();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.rchMemo = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.ctrlPrdID = new JERPApp.Define.Product.CtrlManufPrd();
            this.ctrlCompanyID = new JERPApp.Define.General.CtrlCustomer();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.ctrlPrdID);
            this.panel1.Controls.Add(this.ctrlCompanyID);
            this.panel1.Controls.Add(this.txtWorkingSheetCode);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.dtpDateTarget);
            this.panel1.Controls.Add(this.txtQuantity);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 59);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radMtrStore);
            this.groupBox1.Controls.Add(this.radPrdStore);
            this.groupBox1.Location = new System.Drawing.Point(743, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 27);
            this.groupBox1.TabIndex = 126;
            this.groupBox1.TabStop = false;
            // 
            // radMtrStore
            // 
            this.radMtrStore.AutoSize = true;
            this.radMtrStore.Location = new System.Drawing.Point(60, 9);
            this.radMtrStore.Name = "radMtrStore";
            this.radMtrStore.Size = new System.Drawing.Size(47, 16);
            this.radMtrStore.TabIndex = 1;
            this.radMtrStore.Text = "原料";
            this.radMtrStore.UseVisualStyleBackColor = true;
            // 
            // radPrdStore
            // 
            this.radPrdStore.AutoSize = true;
            this.radPrdStore.Checked = true;
            this.radPrdStore.Location = new System.Drawing.Point(7, 9);
            this.radPrdStore.Name = "radPrdStore";
            this.radPrdStore.Size = new System.Drawing.Size(47, 16);
            this.radPrdStore.TabIndex = 0;
            this.radPrdStore.TabStop = true;
            this.radPrdStore.Text = "成品";
            this.radPrdStore.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(682, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 125;
            this.label11.Text = "转入仓库";
            // 
            // txtWorkingSheetCode
            // 
            this.txtWorkingSheetCode.Location = new System.Drawing.Point(62, 5);
            this.txtWorkingSheetCode.Name = "txtWorkingSheetCode";
            this.txtWorkingSheetCode.ReadOnly = true;
            this.txtWorkingSheetCode.Size = new System.Drawing.Size(117, 21);
            this.txtWorkingSheetCode.TabIndex = 77;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 76;
            this.label10.Text = "生产批号";
            // 
            // dtpDateTarget
            // 
            this.dtpDateTarget.CustomFormat = "yyyy-MM-dd H:m";
            this.dtpDateTarget.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTarget.Location = new System.Drawing.Point(769, 29);
            this.dtpDateTarget.Name = "dtpDateTarget";
            this.dtpDateTarget.Size = new System.Drawing.Size(141, 21);
            this.dtpDateTarget.TabIndex = 73;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(671, 29);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(59, 21);
            this.txtQuantity.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(639, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "数量";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(734, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "交期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "客户";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(448, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "生产制令单";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.rchMemo);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 646);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(916, 36);
            this.panel2.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(787, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(674, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // rchMemo
            // 
            this.rchMemo.Location = new System.Drawing.Point(62, 3);
            this.rchMemo.Name = "rchMemo";
            this.rchMemo.Size = new System.Drawing.Size(596, 30);
            this.rchMemo.TabIndex = 3;
            this.rchMemo.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "备注";
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 59);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(916, 587);
            this.tabMain.TabIndex = 3;
            // 
            // ctrlPrdID
            // 
            this.ctrlPrdID.AutoSize = true;
            this.ctrlPrdID.Location = new System.Drawing.Point(5, 27);
            this.ctrlPrdID.Name = "ctrlPrdID";
            this.ctrlPrdID.PrdID = -1;
            this.ctrlPrdID.Size = new System.Drawing.Size(631, 29);
            this.ctrlPrdID.TabIndex = 124;
            // 
            // ctrlCompanyID
            // 
            this.ctrlCompanyID.CompanyID = -1;
            this.ctrlCompanyID.Location = new System.Drawing.Point(220, 5);
            this.ctrlCompanyID.Name = "ctrlCompanyID";
            this.ctrlCompanyID.Size = new System.Drawing.Size(117, 23);
            this.ctrlCompanyID.TabIndex = 117;
            // 
            // FrmWorkingSheetOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 682);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmWorkingSheetOper";
            this.Text = "生产制令";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private JERPApp.Define.General.CtrlCustomer ctrlCompanyID;
        private System.Windows.Forms.TextBox txtWorkingSheetCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpDateTarget;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox rchMemo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private JERPApp.Define.Product.CtrlManufPrd ctrlPrdID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radMtrStore;
        private System.Windows.Forms.RadioButton radPrdStore;
        private System.Windows.Forms.Label label11;
    }
}