namespace JERPApp.Supply
{
    partial class FrmSupplier
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkNew = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.dgrdv = new JCommon.MyDataGridView();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnbtnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnCompanyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyAbbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyAllName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLegalPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMtrFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnPrdFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnOutSrcFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnOtherResFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnToolFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnLinkman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnURL = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkNew);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1106, 30);
            this.panel1.TabIndex = 0;
            // 
            // lnkNew
            // 
            this.lnkNew.AutoSize = true;
            this.lnkNew.Location = new System.Drawing.Point(4, 15);
            this.lnkNew.Name = "lnkNew";
            this.lnkNew.Size = new System.Drawing.Size(65, 12);
            this.lnkNew.TabIndex = 1;
            this.lnkNew.TabStop = true;
            this.lnkNew.Text = "新增供应商";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(541, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "供应商";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnImport);
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 530);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1106, 32);
            this.panel2.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(360, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "输出Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(269, 4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "批量导入";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(3, 5);
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
            this.ColumnbtnEdit,
            this.ColumnCompanyCode,
            this.ColumnCompanyAbbName,
            this.ColumnCompanyAllName,
            this.ColumnLegalPerson,
            this.ColumnMemo,
            this.ColumnMtrFlag,
            this.ColumnPrdFlag,
            this.ColumnOutSrcFlag,
            this.ColumnOtherResFlag,
            this.ColumnToolFlag,
            this.ColumnLinkman,
            this.ColumnTelephone,
            this.ColumnFax,
            this.ColumnQQ,
            this.ColumnEmail,
            this.ColumnURL,
            this.ColumnAddress});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 30);
            this.dgrdv.Name = "dgrdv";
            this.dgrdv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(1106, 500);
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
            // ColumnbtnEdit
            // 
            this.ColumnbtnEdit.HeaderText = "变更";
            this.ColumnbtnEdit.Name = "ColumnbtnEdit";
            this.ColumnbtnEdit.ReadOnly = true;
            this.ColumnbtnEdit.Text = "变更";
            this.ColumnbtnEdit.UseColumnTextForButtonValue = true;
            this.ColumnbtnEdit.Width = 54;
            // 
            // ColumnCompanyCode
            // 
            this.ColumnCompanyCode.DataPropertyName = "CompanyCode";
            this.ColumnCompanyCode.HeaderText = "编号";
            this.ColumnCompanyCode.Name = "ColumnCompanyCode";
            this.ColumnCompanyCode.ReadOnly = true;
            this.ColumnCompanyCode.Width = 54;
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
            this.ColumnCompanyAllName.Width = 160;
            // 
            // ColumnLegalPerson
            // 
            this.ColumnLegalPerson.DataPropertyName = "LegalPerson";
            this.ColumnLegalPerson.HeaderText = "法人";
            this.ColumnLegalPerson.Name = "ColumnLegalPerson";
            this.ColumnLegalPerson.ReadOnly = true;
            this.ColumnLegalPerson.Width = 66;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.ReadOnly = true;
            // 
            // ColumnMtrFlag
            // 
            this.ColumnMtrFlag.DataPropertyName = "MtrFlag";
            this.ColumnMtrFlag.HeaderText = "原料";
            this.ColumnMtrFlag.Name = "ColumnMtrFlag";
            this.ColumnMtrFlag.ReadOnly = true;
            this.ColumnMtrFlag.Width = 54;
            // 
            // ColumnPrdFlag
            // 
            this.ColumnPrdFlag.DataPropertyName = "PrdFlag";
            this.ColumnPrdFlag.HeaderText = "产品";
            this.ColumnPrdFlag.Name = "ColumnPrdFlag";
            this.ColumnPrdFlag.ReadOnly = true;
            this.ColumnPrdFlag.Width = 54;
            // 
            // ColumnOutSrcFlag
            // 
            this.ColumnOutSrcFlag.DataPropertyName = "OutSrcFlag";
            this.ColumnOutSrcFlag.HeaderText = "委外";
            this.ColumnOutSrcFlag.Name = "ColumnOutSrcFlag";
            this.ColumnOutSrcFlag.ReadOnly = true;
            this.ColumnOutSrcFlag.Width = 54;
            // 
            // ColumnOtherResFlag
            // 
            this.ColumnOtherResFlag.DataPropertyName = "OtherResFlag";
            this.ColumnOtherResFlag.HeaderText = "耗材";
            this.ColumnOtherResFlag.Name = "ColumnOtherResFlag";
            this.ColumnOtherResFlag.ReadOnly = true;
            this.ColumnOtherResFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnOtherResFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnOtherResFlag.Width = 54;
            // 
            // ColumnToolFlag
            // 
            this.ColumnToolFlag.DataPropertyName = "ToolFlag";
            this.ColumnToolFlag.HeaderText = "治具";
            this.ColumnToolFlag.Name = "ColumnToolFlag";
            this.ColumnToolFlag.ReadOnly = true;
            this.ColumnToolFlag.Width = 54;
            // 
            // ColumnLinkman
            // 
            this.ColumnLinkman.DataPropertyName = "Linkman";
            this.ColumnLinkman.HeaderText = "联系人";
            this.ColumnLinkman.Name = "ColumnLinkman";
            this.ColumnLinkman.ReadOnly = true;
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
            // 
            // ColumnFax
            // 
            this.ColumnFax.DataPropertyName = "Fax";
            this.ColumnFax.HeaderText = "传真";
            this.ColumnFax.Name = "ColumnFax";
            this.ColumnFax.ReadOnly = true;
            this.ColumnFax.Width = 70;
            // 
            // ColumnQQ
            // 
            this.ColumnQQ.DataPropertyName = "QQ";
            this.ColumnQQ.HeaderText = "QQ";
            this.ColumnQQ.Name = "ColumnQQ";
            this.ColumnQQ.ReadOnly = true;
            this.ColumnQQ.Width = 66;
            // 
            // ColumnEmail
            // 
            this.ColumnEmail.DataPropertyName = "Email";
            this.ColumnEmail.HeaderText = "Email";
            this.ColumnEmail.Name = "ColumnEmail";
            this.ColumnEmail.ReadOnly = true;
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
            // ColumnAddress
            // 
            this.ColumnAddress.DataPropertyName = "Address";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnAddress.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnAddress.HeaderText = "地址";
            this.ColumnAddress.Name = "ColumnAddress";
            this.ColumnAddress.ReadOnly = true;
            this.ColumnAddress.Width = 120;
            // 
            // FrmSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 562);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSupplier";
            this.Text = "供应商";
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
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.LinkLabel lnkNew;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyAbbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyAllName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLegalPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnMtrFlag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnPrdFlag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnOutSrcFlag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnOtherResFlag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnToolFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLinkman;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFax;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEmail;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnURL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAddress;
    }
}