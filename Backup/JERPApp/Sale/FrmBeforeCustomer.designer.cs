namespace JERPApp.Sale
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkNew = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgrdvMy = new JCommon.MyDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.grpPublic = new System.Windows.Forms.GroupBox();
            this.dgrdvPublic = new JCommon.MyDataGridView();
            this.ColumnbtnCatch = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLastSalePsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnbtnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnbtnShare = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnbtnSuccess = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnCompanyName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvMy)).BeginInit();
            this.panel2.SuspendLayout();
            this.grpPublic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvPublic)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(881, 37);
            this.panel1.TabIndex = 1;
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
            this.label1.Location = new System.Drawing.Point(412, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "售前客户";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 37);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpPublic);
            this.splitContainer1.Size = new System.Drawing.Size(881, 552);
            this.splitContainer1.SplitterDistance = 632;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgrdvMy);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(632, 552);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "我的客户";
            // 
            // dgrdvMy
            // 
            this.dgrdvMy.AllowUserToAddRows = false;
            this.dgrdvMy.AllowUserToDeleteRows = false;
            this.dgrdvMy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvMy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnEdit,
            this.ColumnbtnShare,
            this.ColumnbtnSuccess,
            this.ColumnCompanyName1,
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvMy.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdvMy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvMy.Location = new System.Drawing.Point(3, 17);
            this.dgrdvMy.Name = "dgrdvMy";
            this.dgrdvMy.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvMy.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvMy.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdvMy.RowTemplate.Height = 23;
            this.dgrdvMy.Size = new System.Drawing.Size(626, 502);
            this.dgrdvMy.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 519);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(626, 30);
            this.panel2.TabIndex = 1;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(9, 6);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(287, 21);
            this.ctrlQFind.TabIndex = 0;
            // 
            // grpPublic
            // 
            this.grpPublic.Controls.Add(this.dgrdvPublic);
            this.grpPublic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPublic.Location = new System.Drawing.Point(0, 0);
            this.grpPublic.Name = "grpPublic";
            this.grpPublic.Size = new System.Drawing.Size(245, 552);
            this.grpPublic.TabIndex = 0;
            this.grpPublic.TabStop = false;
            this.grpPublic.Text = "公共区";
            // 
            // dgrdvPublic
            // 
            this.dgrdvPublic.AllowUserToAddRows = false;
            this.dgrdvPublic.AllowUserToDeleteRows = false;
            this.dgrdvPublic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvPublic.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnCatch,
            this.ColumnCompanyName,
            this.ColumnLastSalePsn});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvPublic.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvPublic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvPublic.Location = new System.Drawing.Point(3, 17);
            this.dgrdvPublic.Name = "dgrdvPublic";
            this.dgrdvPublic.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvPublic.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgrdvPublic.RowHeadersWidth = 10;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvPublic.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdvPublic.RowTemplate.Height = 23;
            this.dgrdvPublic.Size = new System.Drawing.Size(239, 532);
            this.dgrdvPublic.TabIndex = 3;
            // 
            // ColumnbtnCatch
            // 
            this.ColumnbtnCatch.HeaderText = "获取";
            this.ColumnbtnCatch.Name = "ColumnbtnCatch";
            this.ColumnbtnCatch.ReadOnly = true;
            this.ColumnbtnCatch.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnbtnCatch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnbtnCatch.Text = "获取";
            this.ColumnbtnCatch.UseColumnTextForButtonValue = true;
            this.ColumnbtnCatch.Width = 54;
            // 
            // ColumnCompanyName
            // 
            this.ColumnCompanyName.DataPropertyName = "CompanyName";
            this.ColumnCompanyName.HeaderText = "客户";
            this.ColumnCompanyName.Name = "ColumnCompanyName";
            this.ColumnCompanyName.ReadOnly = true;
            this.ColumnCompanyName.Width = 120;
            // 
            // ColumnLastSalePsn
            // 
            this.ColumnLastSalePsn.DataPropertyName = "LastSalePsn";
            this.ColumnLastSalePsn.HeaderText = "跟单人";
            this.ColumnLastSalePsn.Name = "ColumnLastSalePsn";
            this.ColumnLastSalePsn.ReadOnly = true;
            this.ColumnLastSalePsn.Width = 66;
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
            this.ColumnbtnEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnbtnEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnbtnEdit.Text = "变更";
            this.ColumnbtnEdit.UseColumnTextForButtonValue = true;
            this.ColumnbtnEdit.Width = 54;
            // 
            // ColumnbtnShare
            // 
            this.ColumnbtnShare.HeaderText = "共享";
            this.ColumnbtnShare.Name = "ColumnbtnShare";
            this.ColumnbtnShare.ReadOnly = true;
            this.ColumnbtnShare.Text = "共享";
            this.ColumnbtnShare.UseColumnTextForButtonValue = true;
            this.ColumnbtnShare.Width = 54;
            // 
            // ColumnbtnSuccess
            // 
            this.ColumnbtnSuccess.HeaderText = "成交";
            this.ColumnbtnSuccess.Name = "ColumnbtnSuccess";
            this.ColumnbtnSuccess.ReadOnly = true;
            this.ColumnbtnSuccess.Text = "成交";
            this.ColumnbtnSuccess.UseColumnTextForButtonValue = true;
            this.ColumnbtnSuccess.Width = 54;
            // 
            // ColumnCompanyName1
            // 
            this.ColumnCompanyName1.DataPropertyName = "CompanyName";
            this.ColumnCompanyName1.HeaderText = "客户";
            this.ColumnCompanyName1.Name = "ColumnCompanyName1";
            this.ColumnCompanyName1.ReadOnly = true;
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
            // FrmBeforeCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 589);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBeforeCustomer";
            this.Text = "FrmCustomer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvMy)).EndInit();
            this.panel2.ResumeLayout(false);
            this.grpPublic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvPublic)).EndInit();
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lnkNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpPublic;
        private JCommon.MyDataGridView dgrdvMy;
        private System.Windows.Forms.Panel panel2;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private JCommon.MyDataGridView dgrdvPublic;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnCatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLastSalePsn;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnShare;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnSuccess;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyName1;
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
    }
}