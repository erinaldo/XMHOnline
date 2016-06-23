namespace JERPApp.Sale
{
    partial class FrmCustomer
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkAlterHandler = new System.Windows.Forms.LinkLabel();
            this.lnkAlterSaler = new System.Windows.Forms.LinkLabel();
            this.lnkNew = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlQFind = new JCommon.CtrlGridFind();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.dgrdv = new JCommon.MyDataGridView();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnBtnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnAreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyAbbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyAllName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAssistantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCustomerTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateRegister = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalePsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHandlePsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLinkman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLegalPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDeliverAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFinanceAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnURL = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkAlterHandler);
            this.panel1.Controls.Add(this.lnkAlterSaler);
            this.panel1.Controls.Add(this.lnkNew);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 37);
            this.panel1.TabIndex = 0;
            // 
            // lnkAlterHandler
            // 
            this.lnkAlterHandler.AutoSize = true;
            this.lnkAlterHandler.Location = new System.Drawing.Point(122, 21);
            this.lnkAlterHandler.Name = "lnkAlterHandler";
            this.lnkAlterHandler.Size = new System.Drawing.Size(65, 12);
            this.lnkAlterHandler.TabIndex = 3;
            this.lnkAlterHandler.TabStop = true;
            this.lnkAlterHandler.Text = "跟单员变更";
            // 
            // lnkAlterSaler
            // 
            this.lnkAlterSaler.AutoSize = true;
            this.lnkAlterSaler.Location = new System.Drawing.Point(63, 21);
            this.lnkAlterSaler.Name = "lnkAlterSaler";
            this.lnkAlterSaler.Size = new System.Drawing.Size(53, 12);
            this.lnkAlterSaler.TabIndex = 2;
            this.lnkAlterSaler.TabStop = true;
            this.lnkAlterSaler.Text = "业务变更";
            // 
            // lnkNew
            // 
            this.lnkNew.AutoSize = true;
            this.lnkNew.Location = new System.Drawing.Point(4, 21);
            this.lnkNew.Name = "lnkNew";
            this.lnkNew.Size = new System.Drawing.Size(53, 12);
            this.lnkNew.TabIndex = 1;
            this.lnkNew.TabStop = true;
            this.lnkNew.Text = "新增客户";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(476, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "客户档案";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Controls.Add(this.btnImport);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 545);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1009, 32);
            this.panel2.TabIndex = 1;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(6, 5);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(331, 21);
            this.ctrlQFind.TabIndex = 4;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(453, 4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(90, 23);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "批量导入";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(372, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "输出Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnBtnEdit,
            this.ColumnAreaName,
            this.ColumnCompanyCode,
            this.ColumnCompanyAbbName,
            this.ColumnCompanyAllName,
            this.ColumnAssistantCode,
            this.ColumnCustomerTypeName,
            this.ColumnDateRegister,
            this.ColumnSalePsn,
            this.ColumnHandlePsn,
            this.ColumnLinkman,
            this.ColumnTelephone,
            this.ColumnFax,
            this.ColumnEmail,
            this.ColumnLegalPerson,
            this.ColumnDeliverAddress,
            this.ColumnFinanceAddress,
            this.ColumnMemo,
            this.ColumnURL});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 37);
            this.dgrdv.Name = "dgrdv";
            this.dgrdv.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(1009, 508);
            this.dgrdv.TabIndex = 2;
            // 
            // cMenu
            // 
            this.cMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemRefresh});
            this.cMenu.Name = "cMenu";
            this.cMenu.Size = new System.Drawing.Size(101, 26);
            // 
            // mItemRefresh
            // 
            this.mItemRefresh.Name = "mItemRefresh";
            this.mItemRefresh.Size = new System.Drawing.Size(100, 22);
            this.mItemRefresh.Text = "刷新";
            // 
            // ColumnBtnEdit
            // 
            this.ColumnBtnEdit.HeaderText = "变更";
            this.ColumnBtnEdit.Name = "ColumnBtnEdit";
            this.ColumnBtnEdit.ReadOnly = true;
            this.ColumnBtnEdit.Text = "变更";
            this.ColumnBtnEdit.UseColumnTextForButtonValue = true;
            this.ColumnBtnEdit.Width = 60;
            // 
            // ColumnAreaName
            // 
            this.ColumnAreaName.DataPropertyName = "AreaName";
            this.ColumnAreaName.HeaderText = "区域";
            this.ColumnAreaName.Name = "ColumnAreaName";
            this.ColumnAreaName.ReadOnly = true;
            this.ColumnAreaName.Width = 54;
            // 
            // ColumnCompanyCode
            // 
            this.ColumnCompanyCode.DataPropertyName = "CompanyCode";
            this.ColumnCompanyCode.HeaderText = "客户编号";
            this.ColumnCompanyCode.Name = "ColumnCompanyCode";
            this.ColumnCompanyCode.ReadOnly = true;
            this.ColumnCompanyCode.Width = 80;
            // 
            // ColumnCompanyAbbName
            // 
            this.ColumnCompanyAbbName.DataPropertyName = "CompanyAbbName";
            this.ColumnCompanyAbbName.HeaderText = "简称";
            this.ColumnCompanyAbbName.Name = "ColumnCompanyAbbName";
            this.ColumnCompanyAbbName.ReadOnly = true;
            this.ColumnCompanyAbbName.Width = 80;
            // 
            // ColumnCompanyAllName
            // 
            this.ColumnCompanyAllName.DataPropertyName = "CompanyAllName";
            this.ColumnCompanyAllName.HeaderText = "全称";
            this.ColumnCompanyAllName.Name = "ColumnCompanyAllName";
            this.ColumnCompanyAllName.ReadOnly = true;
            this.ColumnCompanyAllName.Width = 120;
            // 
            // ColumnAssistantCode
            // 
            this.ColumnAssistantCode.DataPropertyName = "AssistantCode";
            this.ColumnAssistantCode.HeaderText = "助记码";
            this.ColumnAssistantCode.Name = "ColumnAssistantCode";
            this.ColumnAssistantCode.ReadOnly = true;
            this.ColumnAssistantCode.Width = 66;
            // 
            // ColumnCustomerTypeName
            // 
            this.ColumnCustomerTypeName.DataPropertyName = "CustomerTypeName";
            this.ColumnCustomerTypeName.HeaderText = "类别";
            this.ColumnCustomerTypeName.Name = "ColumnCustomerTypeName";
            this.ColumnCustomerTypeName.ReadOnly = true;
            this.ColumnCustomerTypeName.Width = 66;
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
            this.ColumnSalePsn.HeaderText = "业务员";
            this.ColumnSalePsn.Name = "ColumnSalePsn";
            this.ColumnSalePsn.ReadOnly = true;
            this.ColumnSalePsn.Width = 66;
            // 
            // ColumnHandlePsn
            // 
            this.ColumnHandlePsn.DataPropertyName = "HandlePsn";
            this.ColumnHandlePsn.HeaderText = "跟单员";
            this.ColumnHandlePsn.Name = "ColumnHandlePsn";
            this.ColumnHandlePsn.ReadOnly = true;
            this.ColumnHandlePsn.Width = 66;
            // 
            // ColumnLinkman
            // 
            this.ColumnLinkman.DataPropertyName = "Linkman";
            this.ColumnLinkman.HeaderText = "联系人";
            this.ColumnLinkman.Name = "ColumnLinkman";
            this.ColumnLinkman.ReadOnly = true;
            this.ColumnLinkman.Width = 78;
            // 
            // ColumnTelephone
            // 
            this.ColumnTelephone.DataPropertyName = "Telephone";
            this.ColumnTelephone.HeaderText = "电话";
            this.ColumnTelephone.Name = "ColumnTelephone";
            this.ColumnTelephone.ReadOnly = true;
            this.ColumnTelephone.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnTelephone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnFax
            // 
            this.ColumnFax.DataPropertyName = "Fax";
            this.ColumnFax.HeaderText = "传真";
            this.ColumnFax.Name = "ColumnFax";
            this.ColumnFax.ReadOnly = true;
            // 
            // ColumnEmail
            // 
            this.ColumnEmail.DataPropertyName = "Email";
            this.ColumnEmail.HeaderText = "Email";
            this.ColumnEmail.Name = "ColumnEmail";
            this.ColumnEmail.ReadOnly = true;
            // 
            // ColumnLegalPerson
            // 
            this.ColumnLegalPerson.DataPropertyName = "LegalPerson";
            this.ColumnLegalPerson.HeaderText = "法人";
            this.ColumnLegalPerson.Name = "ColumnLegalPerson";
            this.ColumnLegalPerson.ReadOnly = true;
            this.ColumnLegalPerson.Width = 66;
            // 
            // ColumnDeliverAddress
            // 
            this.ColumnDeliverAddress.DataPropertyName = "DeliverAddress";
            this.ColumnDeliverAddress.HeaderText = "送货地址";
            this.ColumnDeliverAddress.Name = "ColumnDeliverAddress";
            this.ColumnDeliverAddress.ReadOnly = true;
            // 
            // ColumnFinanceAddress
            // 
            this.ColumnFinanceAddress.DataPropertyName = "FinanceAddress";
            this.ColumnFinanceAddress.HeaderText = "结算地";
            this.ColumnFinanceAddress.Name = "ColumnFinanceAddress";
            this.ColumnFinanceAddress.ReadOnly = true;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.ReadOnly = true;
            // 
            // ColumnURL
            // 
            this.ColumnURL.DataPropertyName = "URL";
            this.ColumnURL.HeaderText = "网址";
            this.ColumnURL.Name = "ColumnURL";
            this.ColumnURL.ReadOnly = true;
            this.ColumnURL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnURL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnURL.Width = 80;
            // 
            // FrmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 577);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCustomer";
            this.Text = "客户档案";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.LinkLabel lnkNew;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.LinkLabel lnkAlterHandler;
        private System.Windows.Forms.LinkLabel lnkAlterSaler;
        private JCommon.CtrlGridFind ctrlQFind;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnBtnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAreaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyAbbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyAllName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAssistantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCustomerTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateRegister;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalePsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHandlePsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLinkman;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFax;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLegalPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeliverAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFinanceAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnURL;
    }
}