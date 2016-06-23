namespace JERPApp.Manufacture
{
    partial class FrmManufPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkPackingPlan = new System.Windows.Forms.LinkLabel();
            this.lnkRefreshAll = new System.Windows.Forms.LinkLabel();
            this.lnkMtrNew = new System.Windows.Forms.LinkLabel();
            this.lnkFinishedPrdNew = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageManufPlan = new System.Windows.Forms.TabPage();
            this.pageSale = new System.Windows.Forms.TabPage();
            this.dgrdvOrder = new JCommon.MyDataGridView();
            this.ColumnbtnOrder = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnCompanyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNonHandleQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateTarget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHandlePsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlQSale = new JCommon.CtrlGridQuickFind();
            this.pagePrdStore = new System.Windows.Forms.TabPage();
            this.dgrdvPrdStore = new JCommon.MyDataGridView();
            this.ColumnbtnPrdStore = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSafeQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStoreQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRoadQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnManufQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRequireQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ctrlQPrdStore = new JCommon.CtrlGridQuickFind();
            this.pageMtrStore = new System.Windows.Forms.TabPage();
            this.dgrdvMtrStore = new JCommon.MyDataGridView();
            this.ColumnbtnMtrStore = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ctrlQMtr = new JCommon.CtrlGridQuickFind();
            this.pagePackingPlan = new System.Windows.Forms.TabPage();
            this.ctrlManufPlan = new JERPApp.Manufacture.CtrlManufPlan();
            this.ctrlPackingPlan = new JERPApp.Manufacture.CtrlPackingPlan();
            this.panel1.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pageManufPlan.SuspendLayout();
            this.pageSale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvOrder)).BeginInit();
            this.panel2.SuspendLayout();
            this.pagePrdStore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvPrdStore)).BeginInit();
            this.panel3.SuspendLayout();
            this.pageMtrStore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvMtrStore)).BeginInit();
            this.panel6.SuspendLayout();
            this.pagePackingPlan.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkPackingPlan);
            this.panel1.Controls.Add(this.lnkRefreshAll);
            this.panel1.Controls.Add(this.lnkMtrNew);
            this.panel1.Controls.Add(this.lnkFinishedPrdNew);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 31);
            this.panel1.TabIndex = 2;
            // 
            // lnkPackingPlan
            // 
            this.lnkPackingPlan.AutoSize = true;
            this.lnkPackingPlan.Location = new System.Drawing.Point(254, 13);
            this.lnkPackingPlan.Name = "lnkPackingPlan";
            this.lnkPackingPlan.Size = new System.Drawing.Size(77, 12);
            this.lnkPackingPlan.TabIndex = 12;
            this.lnkPackingPlan.TabStop = true;
            this.lnkPackingPlan.Text = "包装计划追加";
            // 
            // lnkRefreshAll
            // 
            this.lnkRefreshAll.AutoSize = true;
            this.lnkRefreshAll.Location = new System.Drawing.Point(7, 13);
            this.lnkRefreshAll.Name = "lnkRefreshAll";
            this.lnkRefreshAll.Size = new System.Drawing.Size(53, 12);
            this.lnkRefreshAll.TabIndex = 11;
            this.lnkRefreshAll.TabStop = true;
            this.lnkRefreshAll.Text = "全部刷新";
            // 
            // lnkMtrNew
            // 
            this.lnkMtrNew.AutoSize = true;
            this.lnkMtrNew.Location = new System.Drawing.Point(150, 13);
            this.lnkMtrNew.Name = "lnkMtrNew";
            this.lnkMtrNew.Size = new System.Drawing.Size(89, 12);
            this.lnkMtrNew.TabIndex = 10;
            this.lnkMtrNew.TabStop = true;
            this.lnkMtrNew.Text = "半成品备库追加";
            // 
            // lnkFinishedPrdNew
            // 
            this.lnkFinishedPrdNew.AutoSize = true;
            this.lnkFinishedPrdNew.Location = new System.Drawing.Point(65, 13);
            this.lnkFinishedPrdNew.Name = "lnkFinishedPrdNew";
            this.lnkFinishedPrdNew.Size = new System.Drawing.Size(77, 12);
            this.lnkFinishedPrdNew.TabIndex = 9;
            this.lnkFinishedPrdNew.TabStop = true;
            this.lnkFinishedPrdNew.Text = "成品备库追加";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(414, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "生产计划";
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
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pageManufPlan);
            this.tabMain.Controls.Add(this.pagePackingPlan);
            this.tabMain.Controls.Add(this.pageSale);
            this.tabMain.Controls.Add(this.pagePrdStore);
            this.tabMain.Controls.Add(this.pageMtrStore);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 31);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(978, 490);
            this.tabMain.TabIndex = 9;
            // 
            // pageManufPlan
            // 
            this.pageManufPlan.Controls.Add(this.ctrlManufPlan);
            this.pageManufPlan.Location = new System.Drawing.Point(4, 22);
            this.pageManufPlan.Name = "pageManufPlan";
            this.pageManufPlan.Padding = new System.Windows.Forms.Padding(3);
            this.pageManufPlan.Size = new System.Drawing.Size(970, 464);
            this.pageManufPlan.TabIndex = 2;
            this.pageManufPlan.Text = "生产计划";
            this.pageManufPlan.UseVisualStyleBackColor = true;
            // 
            // pageSale
            // 
            this.pageSale.Controls.Add(this.dgrdvOrder);
            this.pageSale.Controls.Add(this.panel2);
            this.pageSale.Location = new System.Drawing.Point(4, 22);
            this.pageSale.Name = "pageSale";
            this.pageSale.Padding = new System.Windows.Forms.Padding(3);
            this.pageSale.Size = new System.Drawing.Size(970, 464);
            this.pageSale.TabIndex = 0;
            this.pageSale.Text = "客户订单";
            this.pageSale.UseVisualStyleBackColor = true;
            // 
            // dgrdvOrder
            // 
            this.dgrdvOrder.AllowUserToAddRows = false;
            this.dgrdvOrder.AllowUserToDeleteRows = false;
            this.dgrdvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnOrder,
            this.ColumnCompanyCode,
            this.ColumnPONo,
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnNonHandleQty,
            this.ColumnUnitName,
            this.ColumnDateNote,
            this.ColumnDateTarget,
            this.ColumnMemo,
            this.ColumnHandlePsn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvOrder.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdvOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvOrder.Location = new System.Drawing.Point(3, 3);
            this.dgrdvOrder.Name = "dgrdvOrder";
            this.dgrdvOrder.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvOrder.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdvOrder.RowTemplate.Height = 23;
            this.dgrdvOrder.Size = new System.Drawing.Size(964, 434);
            this.dgrdvOrder.TabIndex = 10;
            // 
            // ColumnbtnOrder
            // 
            this.ColumnbtnOrder.HeaderText = "制定";
            this.ColumnbtnOrder.Name = "ColumnbtnOrder";
            this.ColumnbtnOrder.ReadOnly = true;
            this.ColumnbtnOrder.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnbtnOrder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnbtnOrder.Text = "制定";
            this.ColumnbtnOrder.UseColumnTextForButtonValue = true;
            this.ColumnbtnOrder.Width = 60;
            // 
            // ColumnCompanyCode
            // 
            this.ColumnCompanyCode.DataPropertyName = "CompanyCode";
            this.ColumnCompanyCode.HeaderText = "客户";
            this.ColumnCompanyCode.Name = "ColumnCompanyCode";
            this.ColumnCompanyCode.ReadOnly = true;
            this.ColumnCompanyCode.Width = 54;
            // 
            // ColumnPONo
            // 
            this.ColumnPONo.DataPropertyName = "PONo";
            this.ColumnPONo.HeaderText = "订单编号";
            this.ColumnPONo.Name = "ColumnPONo";
            this.ColumnPONo.ReadOnly = true;
            this.ColumnPONo.Width = 80;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.HeaderText = "产品编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.ReadOnly = true;
            this.ColumnPrdCode.Width = 80;
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.HeaderText = "产品名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            this.ColumnPrdName.ReadOnly = true;
            this.ColumnPrdName.Width = 80;
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            this.ColumnPrdSpec.HeaderText = "产品规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            this.ColumnPrdSpec.ReadOnly = true;
            this.ColumnPrdSpec.Width = 80;
            // 
            // ColumnModel
            // 
            this.ColumnModel.DataPropertyName = "Model";
            this.ColumnModel.HeaderText = "机型";
            this.ColumnModel.Name = "ColumnModel";
            this.ColumnModel.ReadOnly = true;
            this.ColumnModel.Width = 66;
            // 
            // ColumnNonHandleQty
            // 
            this.ColumnNonHandleQty.DataPropertyName = "NonHandleQty";
            this.ColumnNonHandleQty.HeaderText = "数量";
            this.ColumnNonHandleQty.Name = "ColumnNonHandleQty";
            this.ColumnNonHandleQty.ReadOnly = true;
            this.ColumnNonHandleQty.Width = 66;
            // 
            // ColumnUnitName
            // 
            this.ColumnUnitName.DataPropertyName = "UnitName";
            this.ColumnUnitName.HeaderText = "单位";
            this.ColumnUnitName.Name = "ColumnUnitName";
            this.ColumnUnitName.ReadOnly = true;
            this.ColumnUnitName.Width = 54;
            // 
            // ColumnDateNote
            // 
            this.ColumnDateNote.DataPropertyName = "DateNote";
            this.ColumnDateNote.HeaderText = "接单日期";
            this.ColumnDateNote.Name = "ColumnDateNote";
            this.ColumnDateNote.ReadOnly = true;
            this.ColumnDateNote.Width = 80;
            // 
            // ColumnDateTarget
            // 
            this.ColumnDateTarget.DataPropertyName = "DateTarget";
            this.ColumnDateTarget.HeaderText = "交货期";
            this.ColumnDateTarget.Name = "ColumnDateTarget";
            this.ColumnDateTarget.ReadOnly = true;
            this.ColumnDateTarget.Width = 78;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.ReadOnly = true;
            // 
            // ColumnHandlePsn
            // 
            this.ColumnHandlePsn.DataPropertyName = "HandlePsn";
            this.ColumnHandlePsn.HeaderText = "跟单员";
            this.ColumnHandlePsn.Name = "ColumnHandlePsn";
            this.ColumnHandlePsn.ReadOnly = true;
            this.ColumnHandlePsn.Width = 66;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlQSale);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 437);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(964, 24);
            this.panel2.TabIndex = 0;
            // 
            // ctrlQSale
            // 
            this.ctrlQSale.Location = new System.Drawing.Point(5, 3);
            this.ctrlQSale.Name = "ctrlQSale";
            this.ctrlQSale.SeachGridView = null;
            this.ctrlQSale.Size = new System.Drawing.Size(287, 21);
            this.ctrlQSale.TabIndex = 11;
            // 
            // pagePrdStore
            // 
            this.pagePrdStore.Controls.Add(this.dgrdvPrdStore);
            this.pagePrdStore.Controls.Add(this.panel3);
            this.pagePrdStore.Location = new System.Drawing.Point(4, 22);
            this.pagePrdStore.Name = "pagePrdStore";
            this.pagePrdStore.Padding = new System.Windows.Forms.Padding(3);
            this.pagePrdStore.Size = new System.Drawing.Size(970, 464);
            this.pagePrdStore.TabIndex = 1;
            this.pagePrdStore.Text = "成品备库";
            this.pagePrdStore.UseVisualStyleBackColor = true;
            // 
            // dgrdvPrdStore
            // 
            this.dgrdvPrdStore.AllowUserToAddRows = false;
            this.dgrdvPrdStore.AllowUserToDeleteRows = false;
            this.dgrdvPrdStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvPrdStore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnPrdStore,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.ColumnModel1,
            this.dataGridViewTextBoxColumn4,
            this.ColumnSafeQty,
            this.ColumnStoreQty,
            this.ColumnRoadQty,
            this.ColumnManufQty,
            this.ColumnRequireQty});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvPrdStore.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgrdvPrdStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvPrdStore.Location = new System.Drawing.Point(3, 3);
            this.dgrdvPrdStore.Name = "dgrdvPrdStore";
            this.dgrdvPrdStore.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvPrdStore.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdvPrdStore.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgrdvPrdStore.RowTemplate.Height = 23;
            this.dgrdvPrdStore.Size = new System.Drawing.Size(964, 434);
            this.dgrdvPrdStore.TabIndex = 7;
            // 
            // ColumnbtnPrdStore
            // 
            this.ColumnbtnPrdStore.HeaderText = "制定";
            this.ColumnbtnPrdStore.Name = "ColumnbtnPrdStore";
            this.ColumnbtnPrdStore.ReadOnly = true;
            this.ColumnbtnPrdStore.Text = "制定";
            this.ColumnbtnPrdStore.UseColumnTextForButtonValue = true;
            this.ColumnbtnPrdStore.Width = 54;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PrdCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "产品编号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PrdName";
            this.dataGridViewTextBoxColumn2.HeaderText = "产品名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PrdSpec";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn3.HeaderText = "产品规格";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // ColumnModel1
            // 
            this.ColumnModel1.DataPropertyName = "Model";
            this.ColumnModel1.HeaderText = "机型";
            this.ColumnModel1.Name = "ColumnModel1";
            this.ColumnModel1.ReadOnly = true;
            this.ColumnModel1.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "UnitName";
            this.dataGridViewTextBoxColumn4.HeaderText = "单位";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 54;
            // 
            // ColumnSafeQty
            // 
            this.ColumnSafeQty.DataPropertyName = "SafeQty";
            this.ColumnSafeQty.HeaderText = "安全数";
            this.ColumnSafeQty.Name = "ColumnSafeQty";
            this.ColumnSafeQty.ReadOnly = true;
            this.ColumnSafeQty.Width = 66;
            // 
            // ColumnStoreQty
            // 
            this.ColumnStoreQty.DataPropertyName = "StoreQty";
            this.ColumnStoreQty.HeaderText = "有效库存";
            this.ColumnStoreQty.Name = "ColumnStoreQty";
            this.ColumnStoreQty.ReadOnly = true;
            this.ColumnStoreQty.Width = 80;
            // 
            // ColumnRoadQty
            // 
            this.ColumnRoadQty.DataPropertyName = "RoadQty";
            this.ColumnRoadQty.HeaderText = "有效在途";
            this.ColumnRoadQty.Name = "ColumnRoadQty";
            this.ColumnRoadQty.ReadOnly = true;
            this.ColumnRoadQty.Width = 80;
            // 
            // ColumnManufQty
            // 
            this.ColumnManufQty.DataPropertyName = "ManufQty";
            this.ColumnManufQty.HeaderText = "在制数";
            this.ColumnManufQty.Name = "ColumnManufQty";
            this.ColumnManufQty.ReadOnly = true;
            this.ColumnManufQty.Width = 80;
            // 
            // ColumnRequireQty
            // 
            this.ColumnRequireQty.DataPropertyName = "RequireQty";
            this.ColumnRequireQty.HeaderText = "需求数";
            this.ColumnRequireQty.Name = "ColumnRequireQty";
            this.ColumnRequireQty.ReadOnly = true;
            this.ColumnRequireQty.Width = 66;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ctrlQPrdStore);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 437);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(964, 24);
            this.panel3.TabIndex = 1;
            // 
            // ctrlQPrdStore
            // 
            this.ctrlQPrdStore.Location = new System.Drawing.Point(14, 3);
            this.ctrlQPrdStore.Name = "ctrlQPrdStore";
            this.ctrlQPrdStore.SeachGridView = null;
            this.ctrlQPrdStore.Size = new System.Drawing.Size(244, 21);
            this.ctrlQPrdStore.TabIndex = 5;
            // 
            // pageMtrStore
            // 
            this.pageMtrStore.Controls.Add(this.dgrdvMtrStore);
            this.pageMtrStore.Controls.Add(this.panel6);
            this.pageMtrStore.Location = new System.Drawing.Point(4, 22);
            this.pageMtrStore.Name = "pageMtrStore";
            this.pageMtrStore.Padding = new System.Windows.Forms.Padding(3);
            this.pageMtrStore.Size = new System.Drawing.Size(970, 464);
            this.pageMtrStore.TabIndex = 3;
            this.pageMtrStore.Text = "半成品备库";
            this.pageMtrStore.UseVisualStyleBackColor = true;
            // 
            // dgrdvMtrStore
            // 
            this.dgrdvMtrStore.AllowUserToAddRows = false;
            this.dgrdvMtrStore.AllowUserToDeleteRows = false;
            this.dgrdvMtrStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvMtrStore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnMtrStore,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvMtrStore.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgrdvMtrStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvMtrStore.Location = new System.Drawing.Point(3, 3);
            this.dgrdvMtrStore.Name = "dgrdvMtrStore";
            this.dgrdvMtrStore.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvMtrStore.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdvMtrStore.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgrdvMtrStore.RowTemplate.Height = 23;
            this.dgrdvMtrStore.Size = new System.Drawing.Size(964, 434);
            this.dgrdvMtrStore.TabIndex = 7;
            // 
            // ColumnbtnMtrStore
            // 
            this.ColumnbtnMtrStore.HeaderText = "制定";
            this.ColumnbtnMtrStore.Name = "ColumnbtnMtrStore";
            this.ColumnbtnMtrStore.ReadOnly = true;
            this.ColumnbtnMtrStore.Text = "制定";
            this.ColumnbtnMtrStore.UseColumnTextForButtonValue = true;
            this.ColumnbtnMtrStore.Width = 54;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "PrdCode";
            this.dataGridViewTextBoxColumn10.HeaderText = "产品编号";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "PrdName";
            this.dataGridViewTextBoxColumn11.HeaderText = "产品名称";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "PrdSpec";
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn12.HeaderText = "产品规格";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Model";
            this.dataGridViewTextBoxColumn13.HeaderText = "机型";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 80;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "UnitName";
            this.dataGridViewTextBoxColumn14.HeaderText = "单位";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 54;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "SafeQty";
            this.dataGridViewTextBoxColumn15.HeaderText = "安全数";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 66;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "StoreQty";
            this.dataGridViewTextBoxColumn16.HeaderText = "有效库存";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Width = 80;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "RoadQty";
            this.dataGridViewTextBoxColumn17.HeaderText = "有效在途";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 80;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "ManufQty";
            this.dataGridViewTextBoxColumn18.HeaderText = "在制数";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 80;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "RequireQty";
            this.dataGridViewTextBoxColumn19.HeaderText = "需求数";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Width = 66;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.ctrlQMtr);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(3, 437);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(964, 24);
            this.panel6.TabIndex = 1;
            // 
            // ctrlQMtr
            // 
            this.ctrlQMtr.Location = new System.Drawing.Point(14, 3);
            this.ctrlQMtr.Name = "ctrlQMtr";
            this.ctrlQMtr.SeachGridView = null;
            this.ctrlQMtr.Size = new System.Drawing.Size(244, 21);
            this.ctrlQMtr.TabIndex = 5;
            // 
            // pagePackingPlan
            // 
            this.pagePackingPlan.Controls.Add(this.ctrlPackingPlan);
            this.pagePackingPlan.Location = new System.Drawing.Point(4, 22);
            this.pagePackingPlan.Name = "pagePackingPlan";
            this.pagePackingPlan.Padding = new System.Windows.Forms.Padding(3);
            this.pagePackingPlan.Size = new System.Drawing.Size(970, 464);
            this.pagePackingPlan.TabIndex = 4;
            this.pagePackingPlan.Text = "包装计划";
            this.pagePackingPlan.UseVisualStyleBackColor = true;
            // 
            // ctrlManufPlan
            // 
            this.ctrlManufPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlManufPlan.Location = new System.Drawing.Point(3, 3);
            this.ctrlManufPlan.Name = "ctrlManufPlan";
            this.ctrlManufPlan.Size = new System.Drawing.Size(964, 458);
            this.ctrlManufPlan.TabIndex = 0;
            // 
            // ctrlPackingPlan
            // 
            this.ctrlPackingPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPackingPlan.Location = new System.Drawing.Point(3, 3);
            this.ctrlPackingPlan.Name = "ctrlPackingPlan";
            this.ctrlPackingPlan.Size = new System.Drawing.Size(964, 458);
            this.ctrlPackingPlan.TabIndex = 0;
            // 
            // FrmManufPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 521);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmManufPlan";
            this.Text = "FrmManufPlan";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cMenu.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.pageManufPlan.ResumeLayout(false);
            this.pageSale.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvOrder)).EndInit();
            this.panel2.ResumeLayout(false);
            this.pagePrdStore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvPrdStore)).EndInit();
            this.panel3.ResumeLayout(false);
            this.pageMtrStore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvMtrStore)).EndInit();
            this.panel6.ResumeLayout(false);
            this.pagePackingPlan.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageSale;
        private System.Windows.Forms.TabPage pagePrdStore;
        private JCommon.MyDataGridView dgrdvOrder;
        private System.Windows.Forms.Panel panel2;
        private JCommon.CtrlGridQuickFind ctrlQSale;
        private System.Windows.Forms.Panel panel3;
        private JCommon.MyDataGridView dgrdvPrdStore;
        private JCommon.CtrlGridQuickFind ctrlQPrdStore;
        private System.Windows.Forms.LinkLabel lnkMtrNew;
        private System.Windows.Forms.LinkLabel lnkFinishedPrdNew;
        private System.Windows.Forms.TabPage pageManufPlan;
        private System.Windows.Forms.LinkLabel lnkRefreshAll;
        private System.Windows.Forms.TabPage pageMtrStore;
        private JCommon.MyDataGridView dgrdvMtrStore;
        private System.Windows.Forms.Panel panel6;
        private JCommon.CtrlGridQuickFind ctrlQMtr;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNonHandleQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateTarget;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHandlePsn;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnPrdStore;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSafeQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStoreQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRoadQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnManufQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRequireQty;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnMtrStore;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.LinkLabel lnkPackingPlan;
        private System.Windows.Forms.TabPage pagePackingPlan;
        private CtrlManufPlan ctrlManufPlan;
        private CtrlPackingPlan ctrlPackingPlan;
    }
}