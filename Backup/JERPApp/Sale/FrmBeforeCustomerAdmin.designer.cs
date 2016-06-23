namespace JERPApp.Sale
{
    partial class FrmBeforeCustomerAdmin
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
            this.label1 = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageNormal = new System.Windows.Forms.TabPage();
            this.dgrdvNormal = new JCommon.MyDataGridView();
            this.ColumnCheckedFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnCompanyName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckbAllFlag = new System.Windows.Forms.CheckBox();
            this.btnAlterSalePsn = new System.Windows.Forms.Button();
            this.ctrlSalePsnID = new JERPApp.Define.Hr.CtrlPersonnel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.ctrlGridNormal = new JCommon.CtrlGridFind();
            this.pagePause = new System.Windows.Forms.TabPage();
            this.dgrdvPause = new JCommon.MyDataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSourceTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRecover = new System.Windows.Forms.Button();
            this.ctrlGridPause = new JCommon.CtrlGridFind();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pageNormal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvNormal)).BeginInit();
            this.panel2.SuspendLayout();
            this.pagePause.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvPause)).BeginInit();
            this.panel3.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(842, 31);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(373, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "售前客户管理";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pageNormal);
            this.tabMain.Controls.Add(this.pagePause);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 31);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(842, 473);
            this.tabMain.TabIndex = 3;
            // 
            // pageNormal
            // 
            this.pageNormal.Controls.Add(this.dgrdvNormal);
            this.pageNormal.Controls.Add(this.panel2);
            this.pageNormal.Location = new System.Drawing.Point(4, 22);
            this.pageNormal.Name = "pageNormal";
            this.pageNormal.Padding = new System.Windows.Forms.Padding(3);
            this.pageNormal.Size = new System.Drawing.Size(834, 447);
            this.pageNormal.TabIndex = 0;
            this.pageNormal.Text = "跟进中";
            this.pageNormal.UseVisualStyleBackColor = true;
            // 
            // dgrdvNormal
            // 
            this.dgrdvNormal.AllowUserToAddRows = false;
            this.dgrdvNormal.AllowUserToDeleteRows = false;
            this.dgrdvNormal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvNormal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCheckedFlag,
            this.ColumnCompanyName1,
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvNormal.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdvNormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvNormal.Location = new System.Drawing.Point(3, 3);
            this.dgrdvNormal.Name = "dgrdvNormal";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvNormal.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvNormal.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdvNormal.RowTemplate.Height = 23;
            this.dgrdvNormal.Size = new System.Drawing.Size(828, 411);
            this.dgrdvNormal.TabIndex = 1;
            // 
            // ColumnCheckedFlag
            // 
            this.ColumnCheckedFlag.DataPropertyName = "CheckedFlag";
            this.ColumnCheckedFlag.HeaderText = "选择";
            this.ColumnCheckedFlag.Name = "ColumnCheckedFlag";
            this.ColumnCheckedFlag.Width = 54;
            // 
            // ColumnCompanyName1
            // 
            this.ColumnCompanyName1.DataPropertyName = "CompanyName";
            this.ColumnCompanyName1.HeaderText = "客户";
            this.ColumnCompanyName1.Name = "ColumnCompanyName1";
            // 
            // ColumnSalePsn
            // 
            this.ColumnSalePsn.DataPropertyName = "SalePsn";
            this.ColumnSalePsn.HeaderText = "业务";
            this.ColumnSalePsn.Name = "ColumnSalePsn";
            this.ColumnSalePsn.Width = 66;
            // 
            // ColumnSourceTypeName1
            // 
            this.ColumnSourceTypeName1.DataPropertyName = "SourceTypeName";
            this.ColumnSourceTypeName1.HeaderText = "来源";
            this.ColumnSourceTypeName1.Name = "ColumnSourceTypeName1";
            this.ColumnSourceTypeName1.Width = 66;
            // 
            // ColumnProcessTypeName
            // 
            this.ColumnProcessTypeName.DataPropertyName = "ProcessTypeName";
            this.ColumnProcessTypeName.HeaderText = "进度";
            this.ColumnProcessTypeName.Name = "ColumnProcessTypeName";
            this.ColumnProcessTypeName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnProcessTypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnProcessTypeName.Width = 66;
            // 
            // ColumnDateContact
            // 
            this.ColumnDateContact.DataPropertyName = "DateContact";
            this.ColumnDateContact.HeaderText = "联络时间";
            this.ColumnDateContact.Name = "ColumnDateContact";
            this.ColumnDateContact.Width = 80;
            // 
            // ColumnResultContact
            // 
            this.ColumnResultContact.DataPropertyName = "ResultContact";
            this.ColumnResultContact.HeaderText = "联络结果";
            this.ColumnResultContact.Name = "ColumnResultContact";
            // 
            // ColumnDateNextContact
            // 
            this.ColumnDateNextContact.DataPropertyName = "DateNextContact";
            this.ColumnDateNextContact.HeaderText = "下次联络";
            this.ColumnDateNextContact.Name = "ColumnDateNextContact";
            this.ColumnDateNextContact.Width = 80;
            // 
            // ColumnLinkman
            // 
            this.ColumnLinkman.DataPropertyName = "Linkman";
            this.ColumnLinkman.HeaderText = "联系人";
            this.ColumnLinkman.Name = "ColumnLinkman";
            this.ColumnLinkman.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnLinkman.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnLinkman.Width = 66;
            // 
            // ColumnTelephone
            // 
            this.ColumnTelephone.DataPropertyName = "Telephone";
            this.ColumnTelephone.HeaderText = "电话";
            this.ColumnTelephone.Name = "ColumnTelephone";
            this.ColumnTelephone.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnTelephone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnTelephone.Width = 66;
            // 
            // ColumnQQ
            // 
            this.ColumnQQ.DataPropertyName = "QQ";
            this.ColumnQQ.HeaderText = "QQ";
            this.ColumnQQ.Name = "ColumnQQ";
            this.ColumnQQ.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnQQ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnQQ.Width = 66;
            // 
            // ColumnWechat
            // 
            this.ColumnWechat.DataPropertyName = "Wechat";
            this.ColumnWechat.HeaderText = "微信";
            this.ColumnWechat.Name = "ColumnWechat";
            this.ColumnWechat.Width = 66;
            // 
            // ColumnEmail
            // 
            this.ColumnEmail.DataPropertyName = "Email";
            this.ColumnEmail.HeaderText = "Email";
            this.ColumnEmail.Name = "ColumnEmail";
            this.ColumnEmail.Width = 80;
            // 
            // ColumnAddress
            // 
            this.ColumnAddress.DataPropertyName = "Address";
            this.ColumnAddress.HeaderText = "地址";
            this.ColumnAddress.Name = "ColumnAddress";
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ckbAllFlag);
            this.panel2.Controls.Add(this.btnAlterSalePsn);
            this.panel2.Controls.Add(this.ctrlSalePsnID);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnPause);
            this.panel2.Controls.Add(this.ctrlGridNormal);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 414);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(828, 30);
            this.panel2.TabIndex = 2;
            // 
            // ckbAllFlag
            // 
            this.ckbAllFlag.AutoSize = true;
            this.ckbAllFlag.Location = new System.Drawing.Point(643, 6);
            this.ckbAllFlag.Name = "ckbAllFlag";
            this.ckbAllFlag.Size = new System.Drawing.Size(48, 16);
            this.ckbAllFlag.TabIndex = 5;
            this.ckbAllFlag.Text = "全部";
            this.ckbAllFlag.UseVisualStyleBackColor = true;
            // 
            // btnAlterSalePsn
            // 
            this.btnAlterSalePsn.Location = new System.Drawing.Point(697, 3);
            this.btnAlterSalePsn.Name = "btnAlterSalePsn";
            this.btnAlterSalePsn.Size = new System.Drawing.Size(75, 23);
            this.btnAlterSalePsn.TabIndex = 4;
            this.btnAlterSalePsn.Text = "变更";
            this.btnAlterSalePsn.UseVisualStyleBackColor = true;
            // 
            // ctrlSalePsnID
            // 
            this.ctrlSalePsnID.AutoSize = true;
            this.ctrlSalePsnID.Location = new System.Drawing.Point(526, 4);
            this.ctrlSalePsnID.Name = "ctrlSalePsnID";
            this.ctrlSalePsnID.PsnID = -1;
            this.ctrlSalePsnID.Size = new System.Drawing.Size(111, 23);
            this.ctrlSalePsnID.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(455, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "变更业务为";
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(357, 4);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "终止";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // ctrlGridNormal
            // 
            this.ctrlGridNormal.Location = new System.Drawing.Point(5, 6);
            this.ctrlGridNormal.Name = "ctrlGridNormal";
            this.ctrlGridNormal.SeachGridView = null;
            this.ctrlGridNormal.Size = new System.Drawing.Size(331, 21);
            this.ctrlGridNormal.TabIndex = 0;
            // 
            // pagePause
            // 
            this.pagePause.Controls.Add(this.dgrdvPause);
            this.pagePause.Controls.Add(this.panel3);
            this.pagePause.Location = new System.Drawing.Point(4, 22);
            this.pagePause.Name = "pagePause";
            this.pagePause.Padding = new System.Windows.Forms.Padding(3);
            this.pagePause.Size = new System.Drawing.Size(834, 447);
            this.pagePause.TabIndex = 1;
            this.pagePause.Text = "已终止";
            this.pagePause.UseVisualStyleBackColor = true;
            // 
            // dgrdvPause
            // 
            this.dgrdvPause.AllowUserToAddRows = false;
            this.dgrdvPause.AllowUserToDeleteRows = false;
            this.dgrdvPause.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvPause.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.ColumnSourceTypeName,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvPause.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvPause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvPause.Location = new System.Drawing.Point(3, 3);
            this.dgrdvPause.Name = "dgrdvPause";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvPause.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvPause.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdvPause.RowTemplate.Height = 23;
            this.dgrdvPause.Size = new System.Drawing.Size(828, 411);
            this.dgrdvPause.TabIndex = 4;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "CheckedFlag";
            this.dataGridViewCheckBoxColumn1.HeaderText = "选择";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 54;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CompanyName";
            this.dataGridViewTextBoxColumn1.HeaderText = "客户";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SalePsn";
            this.dataGridViewTextBoxColumn2.HeaderText = "业务";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 66;
            // 
            // ColumnSourceTypeName
            // 
            this.ColumnSourceTypeName.DataPropertyName = "SourceTypeName";
            this.ColumnSourceTypeName.HeaderText = "来源";
            this.ColumnSourceTypeName.Name = "ColumnSourceTypeName";
            this.ColumnSourceTypeName.Width = 66;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ProcessTypeName";
            this.dataGridViewTextBoxColumn3.HeaderText = "进度";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 66;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DateContact";
            this.dataGridViewTextBoxColumn4.HeaderText = "联络时间";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ResultContact";
            this.dataGridViewTextBoxColumn5.HeaderText = "联络结果";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "DateNextContact";
            this.dataGridViewTextBoxColumn6.HeaderText = "下次联络";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Linkman";
            this.dataGridViewTextBoxColumn7.HeaderText = "联系人";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 66;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Telephone";
            this.dataGridViewTextBoxColumn8.HeaderText = "电话";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Width = 66;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "QQ";
            this.dataGridViewTextBoxColumn9.HeaderText = "QQ";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Width = 66;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Wechat";
            this.dataGridViewTextBoxColumn10.HeaderText = "微信";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 66;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Email";
            this.dataGridViewTextBoxColumn11.HeaderText = "Email";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 80;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Address";
            this.dataGridViewTextBoxColumn12.HeaderText = "地址";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Memo";
            this.dataGridViewTextBoxColumn13.HeaderText = "备注";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnRecover);
            this.panel3.Controls.Add(this.ctrlGridPause);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 414);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(828, 30);
            this.panel3.TabIndex = 3;
            // 
            // btnRecover
            // 
            this.btnRecover.Location = new System.Drawing.Point(384, 5);
            this.btnRecover.Name = "btnRecover";
            this.btnRecover.Size = new System.Drawing.Size(75, 23);
            this.btnRecover.TabIndex = 1;
            this.btnRecover.Text = "终止恢复";
            this.btnRecover.UseVisualStyleBackColor = true;
            // 
            // ctrlGridPause
            // 
            this.ctrlGridPause.Location = new System.Drawing.Point(5, 6);
            this.ctrlGridPause.Name = "ctrlGridPause";
            this.ctrlGridPause.SeachGridView = null;
            this.ctrlGridPause.Size = new System.Drawing.Size(331, 21);
            this.ctrlGridPause.TabIndex = 0;
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
            // FrmBeforeCustomerAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 504);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBeforeCustomerAdmin";
            this.Text = "FrmBeforeCustomerAdmin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.pageNormal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvNormal)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pagePause.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvPause)).EndInit();
            this.panel3.ResumeLayout(false);
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageNormal;
        private System.Windows.Forms.TabPage pagePause;
        private JCommon.MyDataGridView dgrdvNormal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAlterSalePsn;
        private JERPApp.Define.Hr.CtrlPersonnel ctrlSalePsnID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPause;
        private JCommon.CtrlGridFind ctrlGridNormal;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRecover;
        private JCommon.CtrlGridFind ctrlGridPause;
        private JCommon.MyDataGridView dgrdvPause;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheckedFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyName1;
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSourceTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.CheckBox ckbAllFlag;
    }
}