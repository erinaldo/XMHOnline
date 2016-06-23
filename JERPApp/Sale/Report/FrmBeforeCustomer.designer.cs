namespace JERPApp.Sale.Report
{
    partial class FrmBeforeCustomer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckbProcessType = new System.Windows.Forms.CheckBox();
            this.ckbSourceType = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.ckbRegisterFlag = new System.Windows.Forms.CheckBox();
            this.ckbSalerFlag = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnCompanyName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateRegister = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalePsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSourceTypeName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProcessTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateContact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnResultContact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateNextContact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLinkman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWechat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ckbSuccessFlag = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radSuccessFlag = new System.Windows.Forms.RadioButton();
            this.radNonSuccessFlag = new System.Windows.Forms.RadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.radNonPauseFlag = new System.Windows.Forms.RadioButton();
            this.radPauseFlag = new System.Windows.Forms.RadioButton();
            this.ckbPauseFlag = new System.Windows.Forms.CheckBox();
            this.ctrlProcessTypeID = new JERPApp.Define.General.CtrlCustomerProcessType();
            this.ctrlSourceTypeID = new JERPApp.Define.General.CtrlCustomerSourceType();
            this.ctrlSalePsnID = new JERPApp.Define.Hr.CtrlPersonnel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlSalePsnID);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.ckbPauseFlag);
            this.panel1.Controls.Add(this.ckbSuccessFlag);
            this.panel1.Controls.Add(this.ctrlProcessTypeID);
            this.panel1.Controls.Add(this.ckbProcessType);
            this.panel1.Controls.Add(this.ctrlSourceTypeID);
            this.panel1.Controls.Add(this.ckbSourceType);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dtpDateEnd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpDateBegin);
            this.panel1.Controls.Add(this.ckbRegisterFlag);
            this.panel1.Controls.Add(this.ckbSalerFlag);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 54);
            this.panel1.TabIndex = 1;
            // 
            // ckbProcessType
            // 
            this.ckbProcessType.AutoSize = true;
            this.ckbProcessType.Location = new System.Drawing.Point(526, 30);
            this.ckbProcessType.Name = "ckbProcessType";
            this.ckbProcessType.Size = new System.Drawing.Size(48, 16);
            this.ckbProcessType.TabIndex = 14;
            this.ckbProcessType.Text = "进度";
            this.ckbProcessType.UseVisualStyleBackColor = true;
            // 
            // ckbSourceType
            // 
            this.ckbSourceType.AutoSize = true;
            this.ckbSourceType.Location = new System.Drawing.Point(347, 30);
            this.ckbSourceType.Name = "ckbSourceType";
            this.ckbSourceType.Size = new System.Drawing.Size(48, 16);
            this.ckbSourceType.TabIndex = 12;
            this.ckbSourceType.Text = "来源";
            this.ckbSourceType.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(846, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Location = new System.Drawing.Point(228, 30);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(113, 21);
            this.dtpDateEnd.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "到";
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.Location = new System.Drawing.Point(85, 30);
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.Size = new System.Drawing.Size(113, 21);
            this.dtpDateBegin.TabIndex = 8;
            // 
            // ckbRegisterFlag
            // 
            this.ckbRegisterFlag.AutoSize = true;
            this.ckbRegisterFlag.Location = new System.Drawing.Point(6, 33);
            this.ckbRegisterFlag.Name = "ckbRegisterFlag";
            this.ckbRegisterFlag.Size = new System.Drawing.Size(72, 16);
            this.ckbRegisterFlag.TabIndex = 7;
            this.ckbRegisterFlag.Text = "注册时间";
            this.ckbRegisterFlag.UseVisualStyleBackColor = true;
            // 
            // ckbSalerFlag
            // 
            this.ckbSalerFlag.AutoSize = true;
            this.ckbSalerFlag.Location = new System.Drawing.Point(6, 6);
            this.ckbSalerFlag.Name = "ckbSalerFlag";
            this.ckbSalerFlag.Size = new System.Drawing.Size(48, 16);
            this.ckbSalerFlag.TabIndex = 3;
            this.ckbSalerFlag.Text = "业务";
            this.ckbSalerFlag.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(448, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "售前客户一览";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 527);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(932, 30);
            this.panel2.TabIndex = 2;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(253, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "输出Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(3, 6);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(244, 21);
            this.ctrlQFind.TabIndex = 0;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCompanyName1,
            this.ColumnDateRegister,
            this.ColumnSalePsn,
            this.ColumnSourceTypeName1,
            this.ColumnProcessTypeName,
            this.ColumnDateContact,
            this.ColumnResultContact,
            this.ColumnDateNextContact,
            this.ColumnLinkman,
            this.ColumnTelephone,
            this.ColumnQQ,
            this.ColumnWechat,
            this.ColumnEmail,
            this.ColumnAddress,
            this.ColumnMemo});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 54);
            this.dgrdv.Name = "dgrdv";
            this.dgrdv.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(932, 473);
            this.dgrdv.TabIndex = 3;
            // 
            // ColumnCompanyName1
            // 
            this.ColumnCompanyName1.DataPropertyName = "CompanyName";
            this.ColumnCompanyName1.HeaderText = "客户";
            this.ColumnCompanyName1.Name = "ColumnCompanyName1";
            this.ColumnCompanyName1.ReadOnly = true;
            // 
            // ColumnDateRegister
            // 
            this.ColumnDateRegister.DataPropertyName = "DateRegister";
            this.ColumnDateRegister.HeaderText = "注册时间";
            this.ColumnDateRegister.Name = "ColumnDateRegister";
            this.ColumnDateRegister.ReadOnly = true;
            this.ColumnDateRegister.Width = 80;
            // 
            // ColumnSalePsn
            // 
            this.ColumnSalePsn.DataPropertyName = "SalePsn";
            this.ColumnSalePsn.HeaderText = "业务";
            this.ColumnSalePsn.Name = "ColumnSalePsn";
            this.ColumnSalePsn.ReadOnly = true;
            this.ColumnSalePsn.Width = 66;
            // 
            // ColumnSourceTypeName1
            // 
            this.ColumnSourceTypeName1.DataPropertyName = "SourceTypeName";
            this.ColumnSourceTypeName1.HeaderText = "来源";
            this.ColumnSourceTypeName1.Name = "ColumnSourceTypeName1";
            this.ColumnSourceTypeName1.ReadOnly = true;
            this.ColumnSourceTypeName1.Width = 66;
            // 
            // ColumnProcessTypeName
            // 
            this.ColumnProcessTypeName.DataPropertyName = "ProcessTypeName";
            this.ColumnProcessTypeName.HeaderText = "进度";
            this.ColumnProcessTypeName.Name = "ColumnProcessTypeName";
            this.ColumnProcessTypeName.ReadOnly = true;
            this.ColumnProcessTypeName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnProcessTypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnProcessTypeName.Width = 66;
            // 
            // ColumnDateContact
            // 
            this.ColumnDateContact.DataPropertyName = "DateContact";
            this.ColumnDateContact.HeaderText = "联络时间";
            this.ColumnDateContact.Name = "ColumnDateContact";
            this.ColumnDateContact.ReadOnly = true;
            this.ColumnDateContact.Width = 80;
            // 
            // ColumnResultContact
            // 
            this.ColumnResultContact.DataPropertyName = "ResultContact";
            this.ColumnResultContact.HeaderText = "联络结果";
            this.ColumnResultContact.Name = "ColumnResultContact";
            this.ColumnResultContact.ReadOnly = true;
            // 
            // ColumnDateNextContact
            // 
            this.ColumnDateNextContact.DataPropertyName = "DateNextContact";
            this.ColumnDateNextContact.HeaderText = "下次联络";
            this.ColumnDateNextContact.Name = "ColumnDateNextContact";
            this.ColumnDateNextContact.ReadOnly = true;
            this.ColumnDateNextContact.Width = 80;
            // 
            // ColumnLinkman
            // 
            this.ColumnLinkman.DataPropertyName = "Linkman";
            this.ColumnLinkman.HeaderText = "联系人";
            this.ColumnLinkman.Name = "ColumnLinkman";
            this.ColumnLinkman.ReadOnly = true;
            this.ColumnLinkman.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnLinkman.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnLinkman.Width = 66;
            // 
            // ColumnTelephone
            // 
            this.ColumnTelephone.DataPropertyName = "Telephone";
            this.ColumnTelephone.HeaderText = "电话";
            this.ColumnTelephone.Name = "ColumnTelephone";
            this.ColumnTelephone.ReadOnly = true;
            this.ColumnTelephone.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnTelephone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnTelephone.Width = 66;
            // 
            // ColumnQQ
            // 
            this.ColumnQQ.DataPropertyName = "QQ";
            this.ColumnQQ.HeaderText = "QQ";
            this.ColumnQQ.Name = "ColumnQQ";
            this.ColumnQQ.ReadOnly = true;
            this.ColumnQQ.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnQQ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnQQ.Width = 66;
            // 
            // ColumnWechat
            // 
            this.ColumnWechat.DataPropertyName = "Wechat";
            this.ColumnWechat.HeaderText = "微信";
            this.ColumnWechat.Name = "ColumnWechat";
            this.ColumnWechat.ReadOnly = true;
            this.ColumnWechat.Width = 66;
            // 
            // ColumnEmail
            // 
            this.ColumnEmail.DataPropertyName = "Email";
            this.ColumnEmail.HeaderText = "Email";
            this.ColumnEmail.Name = "ColumnEmail";
            this.ColumnEmail.ReadOnly = true;
            this.ColumnEmail.Width = 80;
            // 
            // ColumnAddress
            // 
            this.ColumnAddress.DataPropertyName = "Address";
            this.ColumnAddress.HeaderText = "地址";
            this.ColumnAddress.Name = "ColumnAddress";
            this.ColumnAddress.ReadOnly = true;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.ReadOnly = true;
            // 
            // ckbSuccessFlag
            // 
            this.ckbSuccessFlag.AutoSize = true;
            this.ckbSuccessFlag.Location = new System.Drawing.Point(695, 9);
            this.ckbSuccessFlag.Name = "ckbSuccessFlag";
            this.ckbSuccessFlag.Size = new System.Drawing.Size(48, 16);
            this.ckbSuccessFlag.TabIndex = 16;
            this.ckbSuccessFlag.Text = "成交";
            this.ckbSuccessFlag.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.radNonSuccessFlag);
            this.panel3.Controls.Add(this.radSuccessFlag);
            this.panel3.Location = new System.Drawing.Point(750, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(90, 23);
            this.panel3.TabIndex = 17;
            // 
            // radSuccessFlag
            // 
            this.radSuccessFlag.AutoSize = true;
            this.radSuccessFlag.Location = new System.Drawing.Point(4, 3);
            this.radSuccessFlag.Name = "radSuccessFlag";
            this.radSuccessFlag.Size = new System.Drawing.Size(35, 16);
            this.radSuccessFlag.TabIndex = 0;
            this.radSuccessFlag.Text = "是";
            this.radSuccessFlag.UseVisualStyleBackColor = true;
            // 
            // radNonSuccessFlag
            // 
            this.radNonSuccessFlag.AutoSize = true;
            this.radNonSuccessFlag.Checked = true;
            this.radNonSuccessFlag.Location = new System.Drawing.Point(41, 4);
            this.radNonSuccessFlag.Name = "radNonSuccessFlag";
            this.radNonSuccessFlag.Size = new System.Drawing.Size(35, 16);
            this.radNonSuccessFlag.TabIndex = 1;
            this.radNonSuccessFlag.TabStop = true;
            this.radNonSuccessFlag.Text = "否";
            this.radNonSuccessFlag.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.radNonPauseFlag);
            this.panel6.Controls.Add(this.radPauseFlag);
            this.panel6.Location = new System.Drawing.Point(750, 28);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(90, 23);
            this.panel6.TabIndex = 19;
            // 
            // radNonPauseFlag
            // 
            this.radNonPauseFlag.AutoSize = true;
            this.radNonPauseFlag.Checked = true;
            this.radNonPauseFlag.Location = new System.Drawing.Point(41, 4);
            this.radNonPauseFlag.Name = "radNonPauseFlag";
            this.radNonPauseFlag.Size = new System.Drawing.Size(35, 16);
            this.radNonPauseFlag.TabIndex = 1;
            this.radNonPauseFlag.TabStop = true;
            this.radNonPauseFlag.Text = "否";
            this.radNonPauseFlag.UseVisualStyleBackColor = true;
            // 
            // radPauseFlag
            // 
            this.radPauseFlag.AutoSize = true;
            this.radPauseFlag.Location = new System.Drawing.Point(4, 3);
            this.radPauseFlag.Name = "radPauseFlag";
            this.radPauseFlag.Size = new System.Drawing.Size(35, 16);
            this.radPauseFlag.TabIndex = 0;
            this.radPauseFlag.Text = "是";
            this.radPauseFlag.UseVisualStyleBackColor = true;
            // 
            // ckbPauseFlag
            // 
            this.ckbPauseFlag.AutoSize = true;
            this.ckbPauseFlag.Location = new System.Drawing.Point(695, 32);
            this.ckbPauseFlag.Name = "ckbPauseFlag";
            this.ckbPauseFlag.Size = new System.Drawing.Size(48, 16);
            this.ckbPauseFlag.TabIndex = 18;
            this.ckbPauseFlag.Text = "终止";
            this.ckbPauseFlag.UseVisualStyleBackColor = true;
            // 
            // ctrlProcessTypeID
            // 
            this.ctrlProcessTypeID.Location = new System.Drawing.Point(580, 28);
            this.ctrlProcessTypeID.Name = "ctrlProcessTypeID";
            this.ctrlProcessTypeID.ProcessTypeID = 1;
            this.ctrlProcessTypeID.Size = new System.Drawing.Size(109, 23);
            this.ctrlProcessTypeID.TabIndex = 15;
            // 
            // ctrlSourceTypeID
            // 
            this.ctrlSourceTypeID.Location = new System.Drawing.Point(401, 28);
            this.ctrlSourceTypeID.Name = "ctrlSourceTypeID";
            this.ctrlSourceTypeID.Size = new System.Drawing.Size(117, 23);
            this.ctrlSourceTypeID.SourceTypeID = 1;
            this.ctrlSourceTypeID.TabIndex = 13;
            // 
            // ctrlSalePsnID
            // 
            this.ctrlSalePsnID.AutoSize = true;
            this.ctrlSalePsnID.Location = new System.Drawing.Point(85, 6);
            this.ctrlSalePsnID.Name = "ctrlSalePsnID";
            this.ctrlSalePsnID.PsnID = -1;
            this.ctrlSalePsnID.Size = new System.Drawing.Size(137, 23);
            this.ctrlSalePsnID.TabIndex = 20;
            // 
            // FrmBeforeCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 557);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBeforeCustomer";
            this.Text = "FrmBeforeCustomer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExport;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private System.Windows.Forms.CheckBox ckbSalerFlag;
        private System.Windows.Forms.CheckBox ckbRegisterFlag;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.CheckBox ckbProcessType;
        private JERPApp.Define.General.CtrlCustomerSourceType ctrlSourceTypeID;
        private System.Windows.Forms.CheckBox ckbSourceType;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateRegister;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalePsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSourceTypeName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProcessTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateContact;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnResultContact;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateNextContact;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLinkman;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWechat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radNonSuccessFlag;
        private System.Windows.Forms.RadioButton radSuccessFlag;
        private System.Windows.Forms.CheckBox ckbSuccessFlag;
        private JERPApp.Define.General.CtrlCustomerProcessType ctrlProcessTypeID;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RadioButton radNonPauseFlag;
        private System.Windows.Forms.RadioButton radPauseFlag;
        private System.Windows.Forms.CheckBox ckbPauseFlag;
        private JERPApp.Define.Hr.CtrlPersonnel ctrlSalePsnID;
    }
}