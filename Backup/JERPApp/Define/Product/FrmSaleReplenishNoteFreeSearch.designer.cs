namespace JERPApp.Define.Product
{
    partial class FrmSaleReplenishNoteFreeSearch
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
            this.ckbCapPONo = new System.Windows.Forms.CheckBox();
            this.txtNoteCode = new System.Windows.Forms.TextBox();
            this.ckbCapDateNote = new System.Windows.Forms.CheckBox();
            this.tpkDateNoteBegin = new System.Windows.Forms.DateTimePicker();
            this.lblCapDateNote = new System.Windows.Forms.Label();
            this.tpkDateNoteEnd = new System.Windows.Forms.DateTimePicker();
            this.ckbCapCompanyID = new System.Windows.Forms.CheckBox();
            this.ckbPrdID = new System.Windows.Forms.CheckBox();
            this.ctrlCompanyID = new JERPApp.Define.General.CtrlCustomer();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ctrlPrdID = new JERPApp.Define.Product.CtrlProduct();
            this.ckbSalePsnID = new System.Windows.Forms.CheckBox();
            this.ctrlSalePsnID = new JERPApp.Define.Hr.CtrlSalePsn();
            this.SuspendLayout();
            // 
            // ckbCapPONo
            // 
            this.ckbCapPONo.AutoSize = true;
            this.ckbCapPONo.Location = new System.Drawing.Point(10, 15);
            this.ckbCapPONo.Name = "ckbCapPONo";
            this.ckbCapPONo.Size = new System.Drawing.Size(84, 16);
            this.ckbCapPONo.TabIndex = 0;
            this.ckbCapPONo.Text = "补货单编号";
            // 
            // txtNoteCode
            // 
            this.txtNoteCode.Location = new System.Drawing.Point(100, 10);
            this.txtNoteCode.Name = "txtNoteCode";
            this.txtNoteCode.Size = new System.Drawing.Size(120, 21);
            this.txtNoteCode.TabIndex = 1;
            // 
            // ckbCapDateNote
            // 
            this.ckbCapDateNote.AutoSize = true;
            this.ckbCapDateNote.Location = new System.Drawing.Point(10, 38);
            this.ckbCapDateNote.Name = "ckbCapDateNote";
            this.ckbCapDateNote.Size = new System.Drawing.Size(72, 16);
            this.ckbCapDateNote.TabIndex = 3;
            this.ckbCapDateNote.Text = "接单日期";
            // 
            // tpkDateNoteBegin
            // 
            this.tpkDateNoteBegin.Location = new System.Drawing.Point(100, 33);
            this.tpkDateNoteBegin.Name = "tpkDateNoteBegin";
            this.tpkDateNoteBegin.Size = new System.Drawing.Size(120, 21);
            this.tpkDateNoteBegin.TabIndex = 4;
            // 
            // lblCapDateNote
            // 
            this.lblCapDateNote.AutoSize = true;
            this.lblCapDateNote.Location = new System.Drawing.Point(230, 38);
            this.lblCapDateNote.Name = "lblCapDateNote";
            this.lblCapDateNote.Size = new System.Drawing.Size(17, 12);
            this.lblCapDateNote.TabIndex = 5;
            this.lblCapDateNote.Text = "—";
            // 
            // tpkDateNoteEnd
            // 
            this.tpkDateNoteEnd.Location = new System.Drawing.Point(260, 33);
            this.tpkDateNoteEnd.Name = "tpkDateNoteEnd";
            this.tpkDateNoteEnd.Size = new System.Drawing.Size(120, 21);
            this.tpkDateNoteEnd.TabIndex = 6;
            // 
            // ckbCapCompanyID
            // 
            this.ckbCapCompanyID.AutoSize = true;
            this.ckbCapCompanyID.Location = new System.Drawing.Point(10, 68);
            this.ckbCapCompanyID.Name = "ckbCapCompanyID";
            this.ckbCapCompanyID.Size = new System.Drawing.Size(48, 16);
            this.ckbCapCompanyID.TabIndex = 7;
            this.ckbCapCompanyID.Text = "客户";
            // 
            // ckbPrdID
            // 
            this.ckbPrdID.AutoSize = true;
            this.ckbPrdID.Location = new System.Drawing.Point(10, 97);
            this.ckbPrdID.Name = "ckbPrdID";
            this.ckbPrdID.Size = new System.Drawing.Size(15, 14);
            this.ckbPrdID.TabIndex = 9;
            // 
            // ctrlCompanyID
            // 
            this.ctrlCompanyID.CompanyID = 1;
            this.ctrlCompanyID.Location = new System.Drawing.Point(100, 61);
            this.ctrlCompanyID.Name = "ctrlCompanyID";
            this.ctrlCompanyID.Size = new System.Drawing.Size(187, 23);
            this.ctrlCompanyID.TabIndex = 10;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(100, 121);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // ctrlPrdID
            // 
            this.ctrlPrdID.AutoSize = true;
            this.ctrlPrdID.Location = new System.Drawing.Point(35, 85);
            this.ctrlPrdID.Name = "ctrlPrdID";
            this.ctrlPrdID.PrdID = -1;
            this.ctrlPrdID.Size = new System.Drawing.Size(664, 30);
            this.ctrlPrdID.TabIndex = 13;
            // 
            // ckbSalePsnID
            // 
            this.ckbSalePsnID.AutoSize = true;
            this.ckbSalePsnID.Location = new System.Drawing.Point(317, 63);
            this.ckbSalePsnID.Name = "ckbSalePsnID";
            this.ckbSalePsnID.Size = new System.Drawing.Size(60, 16);
            this.ckbSalePsnID.TabIndex = 14;
            this.ckbSalePsnID.Text = "业务员";
            // 
            // ctrlSalePsnID
            // 
            this.ctrlSalePsnID.AutoSize = true;
            this.ctrlSalePsnID.Location = new System.Drawing.Point(383, 56);
            this.ctrlSalePsnID.Name = "ctrlSalePsnID";
            this.ctrlSalePsnID.PsnID = -1;
            this.ctrlSalePsnID.Size = new System.Drawing.Size(133, 23);
            this.ctrlSalePsnID.TabIndex = 15;
            // 
            // FrmSaleReplenishNoteFreeSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(677, 152);
            this.Controls.Add(this.ctrlSalePsnID);
            this.Controls.Add(this.ckbSalePsnID);
            this.Controls.Add(this.ctrlPrdID);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.ctrlCompanyID);
            this.Controls.Add(this.ckbPrdID);
            this.Controls.Add(this.ckbCapPONo);
            this.Controls.Add(this.txtNoteCode);
            this.Controls.Add(this.ckbCapDateNote);
            this.Controls.Add(this.tpkDateNoteBegin);
            this.Controls.Add(this.lblCapDateNote);
            this.Controls.Add(this.tpkDateNoteEnd);
            this.Controls.Add(this.ckbCapCompanyID);
            this.Name = "FrmSaleReplenishNoteFreeSearch";
            this.Text = "销售补货单检索";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.CheckBox ckbCapPONo;
        private System.Windows.Forms.TextBox txtNoteCode;
        private System.Windows.Forms.CheckBox ckbCapDateNote;
        private System.Windows.Forms.DateTimePicker tpkDateNoteBegin;
        private System.Windows.Forms.Label lblCapDateNote;
        private System.Windows.Forms.DateTimePicker tpkDateNoteEnd;
        private System.Windows.Forms.CheckBox ckbCapCompanyID;
        private System.Windows.Forms.CheckBox ckbPrdID;
        private JERPApp.Define.General.CtrlCustomer ctrlCompanyID;
        private System.Windows.Forms.Button btnSearch;
        private Product.CtrlProduct ctrlPrdID;
        private System.Windows.Forms.CheckBox ckbSalePsnID;
        private JERPApp.Define.Hr.CtrlSalePsn ctrlSalePsnID;
    }
}