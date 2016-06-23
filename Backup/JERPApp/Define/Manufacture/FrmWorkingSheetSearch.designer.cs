namespace JERPApp.Define.Manufacture
{
    partial class FrmWorkingSheetSearch
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.ckbWorkingSheetCode = new System.Windows.Forms.CheckBox();
            this.txtWorkingSheetCode = new System.Windows.Forms.TextBox();
            this.ckbDateWorkingSheet = new System.Windows.Forms.CheckBox();
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.ckbCustomer = new System.Windows.Forms.CheckBox();
            this.ctrlCompanyID = new JERPApp.Define.General.CtrlCustomer();
            this.ckbPONo = new System.Windows.Forms.CheckBox();
            this.txtPONo = new System.Windows.Forms.TextBox();
            this.ctrlPrdID = new JERPApp.Define.Product.CtrlManufPrd();
            this.ckbPrdID = new System.Windows.Forms.CheckBox();
            this.ckbNonFinishedFlag = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(89, 130);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 41;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ckbWorkingSheetCode
            // 
            this.ckbWorkingSheetCode.AutoSize = true;
            this.ckbWorkingSheetCode.Location = new System.Drawing.Point(10, 12);
            this.ckbWorkingSheetCode.Name = "ckbWorkingSheetCode";
            this.ckbWorkingSheetCode.Size = new System.Drawing.Size(72, 16);
            this.ckbWorkingSheetCode.TabIndex = 67;
            this.ckbWorkingSheetCode.Text = "生产批号";
            this.ckbWorkingSheetCode.UseVisualStyleBackColor = true;
            // 
            // txtWorkingSheetCode
            // 
            this.txtWorkingSheetCode.Location = new System.Drawing.Point(89, 7);
            this.txtWorkingSheetCode.Name = "txtWorkingSheetCode";
            this.txtWorkingSheetCode.Size = new System.Drawing.Size(129, 21);
            this.txtWorkingSheetCode.TabIndex = 86;
            // 
            // ckbDateWorkingSheet
            // 
            this.ckbDateWorkingSheet.AutoSize = true;
            this.ckbDateWorkingSheet.Location = new System.Drawing.Point(9, 35);
            this.ckbDateWorkingSheet.Name = "ckbDateWorkingSheet";
            this.ckbDateWorkingSheet.Size = new System.Drawing.Size(72, 16);
            this.ckbDateWorkingSheet.TabIndex = 87;
            this.ckbDateWorkingSheet.Text = "制单日期";
            this.ckbDateWorkingSheet.UseVisualStyleBackColor = true;
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.Location = new System.Drawing.Point(89, 32);
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.Size = new System.Drawing.Size(129, 21);
            this.dtpDateBegin.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 89;
            this.label1.Text = "到";
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Location = new System.Drawing.Point(248, 31);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(129, 21);
            this.dtpDateEnd.TabIndex = 90;
            // 
            // ckbCustomer
            // 
            this.ckbCustomer.AutoSize = true;
            this.ckbCustomer.Location = new System.Drawing.Point(227, 10);
            this.ckbCustomer.Name = "ckbCustomer";
            this.ckbCustomer.Size = new System.Drawing.Size(48, 16);
            this.ckbCustomer.TabIndex = 91;
            this.ckbCustomer.Text = "客户";
            this.ckbCustomer.UseVisualStyleBackColor = true;
            // 
            // ctrlCompanyID
            // 
            this.ctrlCompanyID.CompanyID = 1;
            this.ctrlCompanyID.Location = new System.Drawing.Point(282, 5);
            this.ctrlCompanyID.Name = "ctrlCompanyID";
            this.ctrlCompanyID.Size = new System.Drawing.Size(95, 23);
            this.ctrlCompanyID.TabIndex = 92;
            // 
            // ckbPONo
            // 
            this.ckbPONo.AutoSize = true;
            this.ckbPONo.Location = new System.Drawing.Point(9, 66);
            this.ckbPONo.Name = "ckbPONo";
            this.ckbPONo.Size = new System.Drawing.Size(72, 16);
            this.ckbPONo.TabIndex = 93;
            this.ckbPONo.Text = "订单编号";
            this.ckbPONo.UseVisualStyleBackColor = true;
            // 
            // txtPONo
            // 
            this.txtPONo.Location = new System.Drawing.Point(89, 59);
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.Size = new System.Drawing.Size(129, 21);
            this.txtPONo.TabIndex = 94;
            // 
            // ctrlPrdID
            // 
            this.ctrlPrdID.AutoSize = true;
            this.ctrlPrdID.Location = new System.Drawing.Point(28, 88);
            this.ctrlPrdID.Name = "ctrlPrdID";
            this.ctrlPrdID.PrdID = -1;
            this.ctrlPrdID.Size = new System.Drawing.Size(631, 29);
            this.ctrlPrdID.TabIndex = 95;
            // 
            // ckbPrdID
            // 
            this.ckbPrdID.AutoSize = true;
            this.ckbPrdID.Location = new System.Drawing.Point(8, 98);
            this.ckbPrdID.Name = "ckbPrdID";
            this.ckbPrdID.Size = new System.Drawing.Size(15, 14);
            this.ckbPrdID.TabIndex = 96;
            this.ckbPrdID.UseVisualStyleBackColor = true;
            // 
            // ckbNonFinishedFlag
            // 
            this.ckbNonFinishedFlag.AutoSize = true;
            this.ckbNonFinishedFlag.Location = new System.Drawing.Point(9, 136);
            this.ckbNonFinishedFlag.Name = "ckbNonFinishedFlag";
            this.ckbNonFinishedFlag.Size = new System.Drawing.Size(60, 16);
            this.ckbNonFinishedFlag.TabIndex = 97;
            this.ckbNonFinishedFlag.Text = "未完成";
            this.ckbNonFinishedFlag.UseVisualStyleBackColor = true;
            // 
            // FrmWorkingSheetSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 165);
            this.Controls.Add(this.ckbNonFinishedFlag);
            this.Controls.Add(this.ckbPrdID);
            this.Controls.Add(this.ctrlPrdID);
            this.Controls.Add(this.txtPONo);
            this.Controls.Add(this.ckbPONo);
            this.Controls.Add(this.ctrlCompanyID);
            this.Controls.Add(this.ckbCustomer);
            this.Controls.Add(this.dtpDateEnd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDateBegin);
            this.Controls.Add(this.ckbDateWorkingSheet);
            this.Controls.Add(this.txtWorkingSheetCode);
            this.Controls.Add(this.ckbWorkingSheetCode);
            this.Controls.Add(this.btnSearch);
            this.Name = "FrmWorkingSheetSearch";
            this.Text = "生产单检索";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox ckbWorkingSheetCode;
        private System.Windows.Forms.TextBox txtWorkingSheetCode;
        private System.Windows.Forms.CheckBox ckbDateWorkingSheet;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.CheckBox ckbCustomer;
        private JERPApp.Define.General.CtrlCustomer ctrlCompanyID;
        private System.Windows.Forms.CheckBox ckbPONo;
        private System.Windows.Forms.TextBox txtPONo;
        private JERPApp.Define.Product.CtrlManufPrd ctrlPrdID;
        private System.Windows.Forms.CheckBox ckbPrdID;
        private System.Windows.Forms.CheckBox ckbNonFinishedFlag;

    }
}