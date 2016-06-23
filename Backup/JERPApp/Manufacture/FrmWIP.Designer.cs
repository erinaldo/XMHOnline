namespace JERPApp.Manufacture
{
    partial class FrmWIP
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageSchedule = new System.Windows.Forms.TabPage();
            this.dgrdvSchedule = new JCommon.MyDataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgrdvWIP = new JCommon.MyDataGridView();
            this.ColumnbtnAlter = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnWorkingSheetCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdStatus1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWorkingPositionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateFinished = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbar = new JCommon.PagebreakNav();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ctrlNoteSearch = new JCommon.ctrlNoteSearch();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnbtnCreate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnWorkingSheetCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWorkgroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNonFinishedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pageSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvSchedule)).BeginInit();
            this.panel4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvWIP)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(820, 25);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(369, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "生产进程";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pageSchedule);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 25);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(820, 477);
            this.tabMain.TabIndex = 7;
            // 
            // pageSchedule
            // 
            this.pageSchedule.Controls.Add(this.dgrdvSchedule);
            this.pageSchedule.Controls.Add(this.panel4);
            this.pageSchedule.Location = new System.Drawing.Point(4, 22);
            this.pageSchedule.Name = "pageSchedule";
            this.pageSchedule.Padding = new System.Windows.Forms.Padding(3);
            this.pageSchedule.Size = new System.Drawing.Size(812, 451);
            this.pageSchedule.TabIndex = 0;
            this.pageSchedule.Text = "未登记";
            this.pageSchedule.UseVisualStyleBackColor = true;
            // 
            // dgrdvSchedule
            // 
            this.dgrdvSchedule.AllowUserToAddRows = false;
            this.dgrdvSchedule.AllowUserToDeleteRows = false;
            this.dgrdvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnCreate,
            this.ColumnWorkingSheetCode1,
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnPrdStatus,
            this.ColumnWorkgroupName,
            this.ColumnNonFinishedQty,
            this.ColumnCompanyCode});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvSchedule.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrdvSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvSchedule.Location = new System.Drawing.Point(3, 3);
            this.dgrdvSchedule.Name = "dgrdvSchedule";
            this.dgrdvSchedule.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvSchedule.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvSchedule.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvSchedule.RowTemplate.Height = 23;
            this.dgrdvSchedule.Size = new System.Drawing.Size(806, 416);
            this.dgrdvSchedule.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ctrlQFind);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 419);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(806, 29);
            this.panel4.TabIndex = 1;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(3, 5);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(244, 21);
            this.ctrlQFind.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgrdvWIP);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(812, 451);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "变更";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgrdvWIP
            // 
            this.dgrdvWIP.AllowUserToAddRows = false;
            this.dgrdvWIP.AllowUserToDeleteRows = false;
            this.dgrdvWIP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvWIP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnAlter,
            this.ColumnWorkingSheetCode,
            this.ColumnPrdCode1,
            this.ColumnPrdStatus1,
            this.ColumnWorkingPositionName,
            this.ColumnQuantity,
            this.ColumnCompanyCode1,
            this.ColumnDateFinished,
            this.ColumnPrdName1,
            this.ColumnPrdSpec1,
            this.ColumnModel1});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvWIP.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgrdvWIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvWIP.Location = new System.Drawing.Point(3, 32);
            this.dgrdvWIP.Name = "dgrdvWIP";
            this.dgrdvWIP.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvWIP.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvWIP.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgrdvWIP.RowTemplate.Height = 23;
            this.dgrdvWIP.Size = new System.Drawing.Size(806, 387);
            this.dgrdvWIP.TabIndex = 9;
            // 
            // ColumnbtnAlter
            // 
            this.ColumnbtnAlter.HeaderText = "变更";
            this.ColumnbtnAlter.Name = "ColumnbtnAlter";
            this.ColumnbtnAlter.ReadOnly = true;
            this.ColumnbtnAlter.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnbtnAlter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnbtnAlter.Text = "变更";
            this.ColumnbtnAlter.UseColumnTextForButtonValue = true;
            this.ColumnbtnAlter.Width = 54;
            // 
            // ColumnWorkingSheetCode
            // 
            this.ColumnWorkingSheetCode.DataPropertyName = "WorkingSheetCode";
            this.ColumnWorkingSheetCode.HeaderText = "生产批号";
            this.ColumnWorkingSheetCode.Name = "ColumnWorkingSheetCode";
            this.ColumnWorkingSheetCode.ReadOnly = true;
            this.ColumnWorkingSheetCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnWorkingSheetCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnPrdCode1
            // 
            this.ColumnPrdCode1.DataPropertyName = "PrdCode";
            this.ColumnPrdCode1.HeaderText = "产品编号";
            this.ColumnPrdCode1.Name = "ColumnPrdCode1";
            this.ColumnPrdCode1.ReadOnly = true;
            // 
            // ColumnPrdStatus1
            // 
            this.ColumnPrdStatus1.DataPropertyName = "PrdStatus";
            this.ColumnPrdStatus1.HeaderText = "工序";
            this.ColumnPrdStatus1.Name = "ColumnPrdStatus1";
            this.ColumnPrdStatus1.ReadOnly = true;
            // 
            // ColumnWorkingPositionName
            // 
            this.ColumnWorkingPositionName.DataPropertyName = "WorkingPositionName";
            this.ColumnWorkingPositionName.HeaderText = "工位";
            this.ColumnWorkingPositionName.Name = "ColumnWorkingPositionName";
            this.ColumnWorkingPositionName.ReadOnly = true;
            this.ColumnWorkingPositionName.Width = 80;
            // 
            // ColumnQuantity
            // 
            this.ColumnQuantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Blue;
            this.ColumnQuantity.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnQuantity.HeaderText = "完成数";
            this.ColumnQuantity.Name = "ColumnQuantity";
            this.ColumnQuantity.ReadOnly = true;
            this.ColumnQuantity.Width = 66;
            // 
            // ColumnCompanyCode1
            // 
            this.ColumnCompanyCode1.DataPropertyName = "CompanyCode";
            this.ColumnCompanyCode1.HeaderText = "客户";
            this.ColumnCompanyCode1.Name = "ColumnCompanyCode1";
            this.ColumnCompanyCode1.ReadOnly = true;
            this.ColumnCompanyCode1.Width = 54;
            // 
            // ColumnDateFinished
            // 
            this.ColumnDateFinished.DataPropertyName = "DateFinished";
            dataGridViewCellStyle6.Format = "M-d";
            this.ColumnDateFinished.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnDateFinished.HeaderText = "日期";
            this.ColumnDateFinished.Name = "ColumnDateFinished";
            this.ColumnDateFinished.ReadOnly = true;
            this.ColumnDateFinished.Width = 66;
            // 
            // ColumnPrdName1
            // 
            this.ColumnPrdName1.DataPropertyName = "PrdName";
            this.ColumnPrdName1.HeaderText = "产品名称";
            this.ColumnPrdName1.Name = "ColumnPrdName1";
            this.ColumnPrdName1.ReadOnly = true;
            // 
            // ColumnPrdSpec1
            // 
            this.ColumnPrdSpec1.DataPropertyName = "PrdSpec";
            this.ColumnPrdSpec1.HeaderText = "产品规格";
            this.ColumnPrdSpec1.Name = "ColumnPrdSpec1";
            this.ColumnPrdSpec1.ReadOnly = true;
            // 
            // ColumnModel1
            // 
            this.ColumnModel1.DataPropertyName = "Model";
            this.ColumnModel1.HeaderText = "机型";
            this.ColumnModel1.Name = "ColumnModel1";
            this.ColumnModel1.ReadOnly = true;
            this.ColumnModel1.Width = 80;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pbar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 419);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(806, 29);
            this.panel2.TabIndex = 8;
            // 
            // pbar
            // 
            this.pbar.AutoSize = true;
            this.pbar.Location = new System.Drawing.Point(0, 2);
            this.pbar.Name = "pbar";
            this.pbar.PageInBlock = 10;
            this.pbar.PageIndex = 1;
            this.pbar.PageSize = 10;
            this.pbar.Size = new System.Drawing.Size(406, 27);
            this.pbar.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ctrlNoteSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(806, 29);
            this.panel3.TabIndex = 7;
            // 
            // ctrlNoteSearch
            // 
            this.ctrlNoteSearch.DateNoteFieldName = "DateFinished";
            this.ctrlNoteSearch.Location = new System.Drawing.Point(3, 0);
            this.ctrlNoteSearch.Name = "ctrlNoteSearch";
            this.ctrlNoteSearch.NoteCodeFieldName = "WorkingSheetCode";
            this.ctrlNoteSearch.Size = new System.Drawing.Size(550, 28);
            this.ctrlNoteSearch.TabIndex = 1;
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
            // ColumnbtnCreate
            // 
            this.ColumnbtnCreate.HeaderText = "登记";
            this.ColumnbtnCreate.Name = "ColumnbtnCreate";
            this.ColumnbtnCreate.ReadOnly = true;
            this.ColumnbtnCreate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnbtnCreate.Text = "登记";
            this.ColumnbtnCreate.UseColumnTextForButtonValue = true;
            this.ColumnbtnCreate.Width = 54;
            // 
            // ColumnWorkingSheetCode1
            // 
            this.ColumnWorkingSheetCode1.DataPropertyName = "WorkingSheetCode";
            this.ColumnWorkingSheetCode1.HeaderText = "生产批号";
            this.ColumnWorkingSheetCode1.Name = "ColumnWorkingSheetCode1";
            this.ColumnWorkingSheetCode1.ReadOnly = true;
            this.ColumnWorkingSheetCode1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnWorkingSheetCode1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.HeaderText = "产品编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.ReadOnly = true;
            this.ColumnPrdCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.HeaderText = "产品名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            this.ColumnPrdName.ReadOnly = true;
            this.ColumnPrdName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            this.ColumnPrdSpec.HeaderText = "产品规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            this.ColumnPrdSpec.ReadOnly = true;
            this.ColumnPrdSpec.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdSpec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnModel
            // 
            this.ColumnModel.DataPropertyName = "Model";
            this.ColumnModel.HeaderText = "机型";
            this.ColumnModel.Name = "ColumnModel";
            this.ColumnModel.ReadOnly = true;
            this.ColumnModel.Width = 66;
            // 
            // ColumnPrdStatus
            // 
            this.ColumnPrdStatus.DataPropertyName = "PrdStatus";
            this.ColumnPrdStatus.HeaderText = "工序";
            this.ColumnPrdStatus.Name = "ColumnPrdStatus";
            this.ColumnPrdStatus.ReadOnly = true;
            this.ColumnPrdStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnPrdStatus.Width = 66;
            // 
            // ColumnWorkgroupName
            // 
            this.ColumnWorkgroupName.DataPropertyName = "WorkgroupName";
            this.ColumnWorkgroupName.HeaderText = "机组";
            this.ColumnWorkgroupName.Name = "ColumnWorkgroupName";
            this.ColumnWorkgroupName.ReadOnly = true;
            this.ColumnWorkgroupName.Width = 66;
            // 
            // ColumnNonFinishedQty
            // 
            this.ColumnNonFinishedQty.DataPropertyName = "NonFinishedQty";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.ColumnNonFinishedQty.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnNonFinishedQty.HeaderText = "未完数";
            this.ColumnNonFinishedQty.Name = "ColumnNonFinishedQty";
            this.ColumnNonFinishedQty.ReadOnly = true;
            this.ColumnNonFinishedQty.Width = 66;
            // 
            // ColumnCompanyCode
            // 
            this.ColumnCompanyCode.DataPropertyName = "CompanyCode";
            this.ColumnCompanyCode.HeaderText = "客户";
            this.ColumnCompanyCode.Name = "ColumnCompanyCode";
            this.ColumnCompanyCode.ReadOnly = true;
            this.ColumnCompanyCode.Width = 66;
            // 
            // FrmWIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 502);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmWIP";
            this.Text = "FrmWIP";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.pageSchedule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvSchedule)).EndInit();
            this.panel4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvWIP)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageSchedule;
        private System.Windows.Forms.TabPage tabPage2;
        private JCommon.MyDataGridView dgrdvSchedule;
        private System.Windows.Forms.Panel panel4;
        private JCommon.MyDataGridView dgrdvWIP;
        private System.Windows.Forms.Panel panel2;
        private JCommon.PagebreakNav pbar;
        private System.Windows.Forms.Panel panel3;
        private JCommon.ctrlNoteSearch ctrlNoteSearch;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnAlter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWorkingSheetCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdStatus1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWorkingPositionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateFinished;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel1;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWorkingSheetCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWorkgroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNonFinishedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyCode;
    }
}