namespace JERPApp.Manufacture
{
    partial class CtrlPackingSheet
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

        #region 组件设计器生成的代码

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgrdvPackingPlan = new JCommon.MyDataGridView();
            this.ColumnbtnCreate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnDateNote1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPackingTypeName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNonFinishedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAvailableManufQty = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnPONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lnkAppend = new System.Windows.Forms.LinkLabel();
            this.lnkBatchNew = new System.Windows.Forms.LinkLabel();
            this.ctrlQManufPlan = new JCommon.CtrlGridFind();
            this.dgrdvWorkingSheet = new JCommon.MyDataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ctrlCheckedAll = new JCommon.CtrlGridCheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.ctrlQPackingSheet = new JCommon.CtrlGridFind();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnCheckedFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnbtnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnbtnPrint = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPublishFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvPackingPlan)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvWorkingSheet)).BeginInit();
            this.panel4.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgrdvPackingPlan);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgrdvWorkingSheet);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Size = new System.Drawing.Size(606, 379);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgrdvPackingPlan
            // 
            this.dgrdvPackingPlan.AllowUserToAddRows = false;
            this.dgrdvPackingPlan.AllowUserToDeleteRows = false;
            this.dgrdvPackingPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvPackingPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnCreate,
            this.ColumnDateNote1,
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnPackingTypeName1,
            this.ColumnNonFinishedQty,
            this.ColumnAvailableManufQty,
            this.ColumnPONo,
            this.ColumnCompanyCode,
            this.ColumnUnitName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvPackingPlan.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrdvPackingPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvPackingPlan.Location = new System.Drawing.Point(0, 0);
            this.dgrdvPackingPlan.Name = "dgrdvPackingPlan";
            this.dgrdvPackingPlan.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvPackingPlan.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvPackingPlan.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvPackingPlan.RowTemplate.Height = 23;
            this.dgrdvPackingPlan.Size = new System.Drawing.Size(606, 176);
            this.dgrdvPackingPlan.TabIndex = 2;
            // 
            // ColumnbtnCreate
            // 
            this.ColumnbtnCreate.HeaderText = "下达";
            this.ColumnbtnCreate.Name = "ColumnbtnCreate";
            this.ColumnbtnCreate.ReadOnly = true;
            this.ColumnbtnCreate.Text = "下达";
            this.ColumnbtnCreate.UseColumnTextForButtonValue = true;
            this.ColumnbtnCreate.Width = 54;
            // 
            // ColumnDateNote1
            // 
            this.ColumnDateNote1.DataPropertyName = "DateNote";
            this.ColumnDateNote1.HeaderText = "计划日期";
            this.ColumnDateNote1.Name = "ColumnDateNote1";
            this.ColumnDateNote1.ReadOnly = true;
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
            // 
            // ColumnModel
            // 
            this.ColumnModel.DataPropertyName = "Model";
            this.ColumnModel.HeaderText = "机型";
            this.ColumnModel.Name = "ColumnModel";
            this.ColumnModel.ReadOnly = true;
            this.ColumnModel.Width = 80;
            // 
            // ColumnPackingTypeName1
            // 
            this.ColumnPackingTypeName1.DataPropertyName = "PackingTypeName";
            this.ColumnPackingTypeName1.HeaderText = "包装类型";
            this.ColumnPackingTypeName1.Name = "ColumnPackingTypeName1";
            this.ColumnPackingTypeName1.ReadOnly = true;
            this.ColumnPackingTypeName1.Width = 80;
            // 
            // ColumnNonFinishedQty
            // 
            this.ColumnNonFinishedQty.DataPropertyName = "NonFinishedQty";
            this.ColumnNonFinishedQty.HeaderText = "数量";
            this.ColumnNonFinishedQty.Name = "ColumnNonFinishedQty";
            this.ColumnNonFinishedQty.ReadOnly = true;
            this.ColumnNonFinishedQty.Width = 66;
            // 
            // ColumnAvailableManufQty
            // 
            this.ColumnAvailableManufQty.DataPropertyName = "AvailableManufQty";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Red;
            this.ColumnAvailableManufQty.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnAvailableManufQty.HeaderText = "可下达";
            this.ColumnAvailableManufQty.Name = "ColumnAvailableManufQty";
            this.ColumnAvailableManufQty.ReadOnly = true;
            this.ColumnAvailableManufQty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnAvailableManufQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnAvailableManufQty.Width = 66;
            // 
            // ColumnPONo
            // 
            this.ColumnPONo.DataPropertyName = "PONo";
            this.ColumnPONo.HeaderText = "订单编号";
            this.ColumnPONo.Name = "ColumnPONo";
            this.ColumnPONo.ReadOnly = true;
            this.ColumnPONo.Width = 80;
            // 
            // ColumnCompanyCode
            // 
            this.ColumnCompanyCode.DataPropertyName = "CompanyCode";
            this.ColumnCompanyCode.HeaderText = "客户";
            this.ColumnCompanyCode.Name = "ColumnCompanyCode";
            this.ColumnCompanyCode.ReadOnly = true;
            this.ColumnCompanyCode.Width = 60;
            // 
            // ColumnUnitName
            // 
            this.ColumnUnitName.DataPropertyName = "UnitName";
            this.ColumnUnitName.HeaderText = "单位";
            this.ColumnUnitName.Name = "ColumnUnitName";
            this.ColumnUnitName.ReadOnly = true;
            this.ColumnUnitName.Width = 54;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lnkAppend);
            this.panel2.Controls.Add(this.lnkBatchNew);
            this.panel2.Controls.Add(this.ctrlQManufPlan);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 176);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(606, 26);
            this.panel2.TabIndex = 1;
            // 
            // lnkAppend
            // 
            this.lnkAppend.AutoSize = true;
            this.lnkAppend.Location = new System.Drawing.Point(399, 12);
            this.lnkAppend.Name = "lnkAppend";
            this.lnkAppend.Size = new System.Drawing.Size(65, 12);
            this.lnkAppend.TabIndex = 6;
            this.lnkAppend.TabStop = true;
            this.lnkAppend.Text = "非计划制令";
            // 
            // lnkBatchNew
            // 
            this.lnkBatchNew.AutoSize = true;
            this.lnkBatchNew.Location = new System.Drawing.Point(340, 12);
            this.lnkBatchNew.Name = "lnkBatchNew";
            this.lnkBatchNew.Size = new System.Drawing.Size(53, 12);
            this.lnkBatchNew.TabIndex = 1;
            this.lnkBatchNew.TabStop = true;
            this.lnkBatchNew.Text = "批量制令";
            // 
            // ctrlQManufPlan
            // 
            this.ctrlQManufPlan.Location = new System.Drawing.Point(3, 6);
            this.ctrlQManufPlan.Name = "ctrlQManufPlan";
            this.ctrlQManufPlan.SeachGridView = null;
            this.ctrlQManufPlan.Size = new System.Drawing.Size(331, 21);
            this.ctrlQManufPlan.TabIndex = 0;
            // 
            // dgrdvWorkingSheet
            // 
            this.dgrdvWorkingSheet.AllowUserToAddRows = false;
            this.dgrdvWorkingSheet.AllowUserToDeleteRows = false;
            this.dgrdvWorkingSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvWorkingSheet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCheckedFlag,
            this.ColumnbtnEdit,
            this.ColumnbtnPrint,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn9,
            this.ColumnPublishFlag,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvWorkingSheet.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdvWorkingSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvWorkingSheet.Location = new System.Drawing.Point(0, 0);
            this.dgrdvWorkingSheet.Name = "dgrdvWorkingSheet";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvWorkingSheet.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvWorkingSheet.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgrdvWorkingSheet.RowTemplate.Height = 23;
            this.dgrdvWorkingSheet.Size = new System.Drawing.Size(606, 147);
            this.dgrdvWorkingSheet.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ctrlCheckedAll);
            this.panel4.Controls.Add(this.btnExport);
            this.panel4.Controls.Add(this.ctrlQPackingSheet);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 147);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(606, 26);
            this.panel4.TabIndex = 2;
            // 
            // ctrlCheckedAll
            // 
            this.ctrlCheckedAll.CheckedFlag = false;
            this.ctrlCheckedAll.Location = new System.Drawing.Point(2, 5);
            this.ctrlCheckedAll.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlCheckedAll.Name = "ctrlCheckedAll";
            this.ctrlCheckedAll.SeachGridView = null;
            this.ctrlCheckedAll.Size = new System.Drawing.Size(52, 18);
            this.ctrlCheckedAll.TabIndex = 2;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(423, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "输出制令";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // ctrlQPackingSheet
            // 
            this.ctrlQPackingSheet.Location = new System.Drawing.Point(62, 2);
            this.ctrlQPackingSheet.Name = "ctrlQPackingSheet";
            this.ctrlQPackingSheet.SeachGridView = null;
            this.ctrlQPackingSheet.Size = new System.Drawing.Size(331, 21);
            this.ctrlQPackingSheet.TabIndex = 0;
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
            // ColumnCheckedFlag
            // 
            this.ColumnCheckedFlag.DataPropertyName = "CheckedFlag";
            this.ColumnCheckedFlag.HeaderText = "选择";
            this.ColumnCheckedFlag.Name = "ColumnCheckedFlag";
            this.ColumnCheckedFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnCheckedFlag.Width = 54;
            // 
            // ColumnbtnEdit
            // 
            this.ColumnbtnEdit.HeaderText = "变更";
            this.ColumnbtnEdit.Name = "ColumnbtnEdit";
            this.ColumnbtnEdit.Text = "变更";
            this.ColumnbtnEdit.UseColumnTextForButtonValue = true;
            this.ColumnbtnEdit.Width = 54;
            // 
            // ColumnbtnPrint
            // 
            this.ColumnbtnPrint.HeaderText = "输出";
            this.ColumnbtnPrint.Name = "ColumnbtnPrint";
            this.ColumnbtnPrint.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnbtnPrint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnbtnPrint.Text = "输出";
            this.ColumnbtnPrint.UseColumnTextForButtonValue = true;
            this.ColumnbtnPrint.Width = 54;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "WorkingSheetCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "生产批号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PrdCode";
            this.dataGridViewTextBoxColumn3.HeaderText = "产品编号";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PrdName";
            this.dataGridViewTextBoxColumn4.HeaderText = "产品名称";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PrdSpec";
            this.dataGridViewTextBoxColumn5.HeaderText = "产品规格";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Model";
            this.dataGridViewTextBoxColumn6.HeaderText = "机型";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "PackingTypeName";
            this.dataGridViewTextBoxColumn9.HeaderText = "包装类型";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 80;
            // 
            // ColumnPublishFlag
            // 
            this.ColumnPublishFlag.DataPropertyName = "PublishFlag";
            this.ColumnPublishFlag.HeaderText = "发布";
            this.ColumnPublishFlag.Name = "ColumnPublishFlag";
            this.ColumnPublishFlag.Width = 54;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn7.HeaderText = "数量";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 66;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "UnitName";
            this.dataGridViewTextBoxColumn8.HeaderText = "单位";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 54;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "DateTarget";
            dataGridViewCellStyle5.Format = "MM-d H:m:s";
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn10.HeaderText = "交货日期";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "PONo";
            this.dataGridViewTextBoxColumn11.HeaderText = "订单编号";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 80;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "CompanyCode";
            this.dataGridViewTextBoxColumn12.HeaderText = "客户";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 60;
            // 
            // CtrlPackingSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CtrlPackingSheet";
            this.Size = new System.Drawing.Size(606, 379);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvPackingPlan)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvWorkingSheet)).EndInit();
            this.panel4.ResumeLayout(false);
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel lnkBatchNew;
        private JCommon.CtrlGridFind ctrlQManufPlan;
        private JCommon.MyDataGridView dgrdvPackingPlan;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateNote1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPackingTypeName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNonFinishedQty;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnAvailableManufQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName;
        private System.Windows.Forms.Panel panel4;
        private JCommon.CtrlGridCheckBox ctrlCheckedAll;
        private System.Windows.Forms.Button btnExport;
        private JCommon.CtrlGridFind ctrlQPackingSheet;
        private JCommon.MyDataGridView dgrdvWorkingSheet;
        private System.Windows.Forms.LinkLabel lnkAppend;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheckedFlag;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnPublishFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
    }
}
