namespace JERPApp.Manufacture
{
    partial class CtrlPackingBOMPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgrdvNonBOMPlan = new JCommon.MyDataGridView();
            this.ColumnbtnBOMPlan = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPackingTypeName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyAbbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lnkNonPlanBOM = new System.Windows.Forms.LinkLabel();
            this.lnkBatchBOMPlan = new System.Windows.Forms.LinkLabel();
            this.ctrlQFind = new JCommon.CtrlGridFind();
            this.dgrdvBOMPlan = new JCommon.MyDataGridView();
            this.ColumnbtnDetail = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnDateNote1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPackingTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateTarget1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPONo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMakerPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pbar = new JCommon.PagebreakNav();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ctrlPrdID = new JERPApp.Define.Product.CtrlFinishedPrd();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.ckbDateNote = new System.Windows.Forms.CheckBox();
            this.ckbPrd = new System.Windows.Forms.CheckBox();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvNonBOMPlan)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvBOMPlan)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.dgrdvNonBOMPlan);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgrdvBOMPlan);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Size = new System.Drawing.Size(849, 504);
            this.splitContainer1.SplitterDistance = 223;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgrdvNonBOMPlan
            // 
            this.dgrdvNonBOMPlan.AllowUserToAddRows = false;
            this.dgrdvNonBOMPlan.AllowUserToDeleteRows = false;
            this.dgrdvNonBOMPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvNonBOMPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnBOMPlan,
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnPackingTypeName1,
            this.ColumnQuantity,
            this.ColumnCompanyAbbName,
            this.ColumnUnitName});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvNonBOMPlan.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdvNonBOMPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvNonBOMPlan.Location = new System.Drawing.Point(0, 0);
            this.dgrdvNonBOMPlan.Name = "dgrdvNonBOMPlan";
            this.dgrdvNonBOMPlan.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvNonBOMPlan.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvNonBOMPlan.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdvNonBOMPlan.RowTemplate.Height = 23;
            this.dgrdvNonBOMPlan.Size = new System.Drawing.Size(849, 196);
            this.dgrdvNonBOMPlan.TabIndex = 4;
            // 
            // ColumnbtnBOMPlan
            // 
            this.ColumnbtnBOMPlan.HeaderText = "计划";
            this.ColumnbtnBOMPlan.Name = "ColumnbtnBOMPlan";
            this.ColumnbtnBOMPlan.ReadOnly = true;
            this.ColumnbtnBOMPlan.Text = "计划";
            this.ColumnbtnBOMPlan.UseColumnTextForButtonValue = true;
            this.ColumnbtnBOMPlan.Width = 54;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.HeaderText = "物料编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.ReadOnly = true;
            this.ColumnPrdCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.HeaderText = "物料名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            this.ColumnPrdName.ReadOnly = true;
            this.ColumnPrdName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            this.ColumnPrdSpec.HeaderText = "物料规格";
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
            // ColumnQuantity
            // 
            this.ColumnQuantity.DataPropertyName = "Quantity";
            this.ColumnQuantity.HeaderText = "数量";
            this.ColumnQuantity.Name = "ColumnQuantity";
            this.ColumnQuantity.ReadOnly = true;
            this.ColumnQuantity.Width = 66;
            // 
            // ColumnCompanyAbbName
            // 
            this.ColumnCompanyAbbName.DataPropertyName = "CompanyAbbName";
            this.ColumnCompanyAbbName.HeaderText = "客户";
            this.ColumnCompanyAbbName.Name = "ColumnCompanyAbbName";
            this.ColumnCompanyAbbName.ReadOnly = true;
            this.ColumnCompanyAbbName.Width = 80;
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
            this.panel2.Controls.Add(this.lnkNonPlanBOM);
            this.panel2.Controls.Add(this.lnkBatchBOMPlan);
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 196);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(849, 27);
            this.panel2.TabIndex = 3;
            // 
            // lnkNonPlanBOM
            // 
            this.lnkNonPlanBOM.AutoSize = true;
            this.lnkNonPlanBOM.Location = new System.Drawing.Point(427, 8);
            this.lnkNonPlanBOM.Name = "lnkNonPlanBOM";
            this.lnkNonPlanBOM.Size = new System.Drawing.Size(65, 12);
            this.lnkNonPlanBOM.TabIndex = 5;
            this.lnkNonPlanBOM.TabStop = true;
            this.lnkNonPlanBOM.Text = "非计划算料";
            // 
            // lnkBatchBOMPlan
            // 
            this.lnkBatchBOMPlan.AutoSize = true;
            this.lnkBatchBOMPlan.Location = new System.Drawing.Point(368, 8);
            this.lnkBatchBOMPlan.Name = "lnkBatchBOMPlan";
            this.lnkBatchBOMPlan.Size = new System.Drawing.Size(53, 12);
            this.lnkBatchBOMPlan.TabIndex = 3;
            this.lnkBatchBOMPlan.TabStop = true;
            this.lnkBatchBOMPlan.Text = "批量算料";
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(12, 3);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(331, 21);
            this.ctrlQFind.TabIndex = 0;
            // 
            // dgrdvBOMPlan
            // 
            this.dgrdvBOMPlan.AllowUserToAddRows = false;
            this.dgrdvBOMPlan.AllowUserToDeleteRows = false;
            this.dgrdvBOMPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvBOMPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnDetail,
            this.ColumnDateNote1,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.ColumnPackingTypeName,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.ColumnDateTarget1,
            this.ColumnCompanyCode1,
            this.ColumnPONo1,
            this.dataGridViewTextBoxColumn13,
            this.ColumnMakerPsn});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvBOMPlan.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvBOMPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvBOMPlan.Location = new System.Drawing.Point(0, 58);
            this.dgrdvBOMPlan.Name = "dgrdvBOMPlan";
            this.dgrdvBOMPlan.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvBOMPlan.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvBOMPlan.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdvBOMPlan.RowTemplate.Height = 23;
            this.dgrdvBOMPlan.Size = new System.Drawing.Size(849, 195);
            this.dgrdvBOMPlan.TabIndex = 8;
            // 
            // ColumnbtnDetail
            // 
            this.ColumnbtnDetail.HeaderText = "详细";
            this.ColumnbtnDetail.Name = "ColumnbtnDetail";
            this.ColumnbtnDetail.ReadOnly = true;
            this.ColumnbtnDetail.Text = "详细";
            this.ColumnbtnDetail.UseColumnTextForLinkValue = true;
            this.ColumnbtnDetail.Width = 54;
            // 
            // ColumnDateNote1
            // 
            this.ColumnDateNote1.DataPropertyName = "DateNote";
            this.ColumnDateNote1.HeaderText = "计划日期";
            this.ColumnDateNote1.Name = "ColumnDateNote1";
            this.ColumnDateNote1.ReadOnly = true;
            this.ColumnDateNote1.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "PrdCode";
            this.dataGridViewTextBoxColumn8.HeaderText = "产品编号";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "PrdName";
            this.dataGridViewTextBoxColumn9.HeaderText = "产品名称";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "PrdSpec";
            this.dataGridViewTextBoxColumn10.HeaderText = "产品规格";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // ColumnPackingTypeName
            // 
            this.ColumnPackingTypeName.DataPropertyName = "PackingTypeName";
            this.ColumnPackingTypeName.HeaderText = "包装类型";
            this.ColumnPackingTypeName.Name = "ColumnPackingTypeName";
            this.ColumnPackingTypeName.ReadOnly = true;
            this.ColumnPackingTypeName.Width = 80;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Model";
            this.dataGridViewTextBoxColumn11.HeaderText = "机型";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 66;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn12.HeaderText = "数量";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 66;
            // 
            // ColumnDateTarget1
            // 
            this.ColumnDateTarget1.DataPropertyName = "DateTarget";
            this.ColumnDateTarget1.HeaderText = "交货日期";
            this.ColumnDateTarget1.Name = "ColumnDateTarget1";
            this.ColumnDateTarget1.ReadOnly = true;
            this.ColumnDateTarget1.Width = 80;
            // 
            // ColumnCompanyCode1
            // 
            this.ColumnCompanyCode1.DataPropertyName = "CompanyCode";
            this.ColumnCompanyCode1.HeaderText = "客户";
            this.ColumnCompanyCode1.Name = "ColumnCompanyCode1";
            this.ColumnCompanyCode1.ReadOnly = true;
            this.ColumnCompanyCode1.Width = 66;
            // 
            // ColumnPONo1
            // 
            this.ColumnPONo1.DataPropertyName = "PONo";
            this.ColumnPONo1.HeaderText = "订单编号";
            this.ColumnPONo1.Name = "ColumnPONo1";
            this.ColumnPONo1.ReadOnly = true;
            this.ColumnPONo1.Width = 80;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "UnitName";
            this.dataGridViewTextBoxColumn13.HeaderText = "单位";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 54;
            // 
            // ColumnMakerPsn
            // 
            this.ColumnMakerPsn.DataPropertyName = "MakerPsn";
            this.ColumnMakerPsn.HeaderText = "制定人";
            this.ColumnMakerPsn.Name = "ColumnMakerPsn";
            this.ColumnMakerPsn.ReadOnly = true;
            this.ColumnMakerPsn.Width = 66;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pbar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 253);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(849, 24);
            this.panel4.TabIndex = 7;
            // 
            // pbar
            // 
            this.pbar.AutoSize = true;
            this.pbar.Location = new System.Drawing.Point(3, 0);
            this.pbar.Name = "pbar";
            this.pbar.PageInBlock = 10;
            this.pbar.PageIndex = 1;
            this.pbar.PageSize = 50;
            this.pbar.Size = new System.Drawing.Size(406, 27);
            this.pbar.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ctrlPrdID);
            this.panel5.Controls.Add(this.btnSearch);
            this.panel5.Controls.Add(this.dtpDateEnd);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.dtpDateBegin);
            this.panel5.Controls.Add(this.ckbDateNote);
            this.panel5.Controls.Add(this.ckbPrd);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(849, 58);
            this.panel5.TabIndex = 6;
            // 
            // ctrlPrdID
            // 
            this.ctrlPrdID.AutoSize = true;
            this.ctrlPrdID.Location = new System.Drawing.Point(59, 2);
            this.ctrlPrdID.Name = "ctrlPrdID";
            this.ctrlPrdID.PrdID = -1;
            this.ctrlPrdID.Size = new System.Drawing.Size(631, 29);
            this.ctrlPrdID.TabIndex = 92;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(615, 31);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Location = new System.Drawing.Point(253, 33);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(137, 21);
            this.dtpDateEnd.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "到";
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.Location = new System.Drawing.Point(86, 32);
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.Size = new System.Drawing.Size(137, 21);
            this.dtpDateBegin.TabIndex = 3;
            // 
            // ckbDateNote
            // 
            this.ckbDateNote.AutoSize = true;
            this.ckbDateNote.Location = new System.Drawing.Point(3, 35);
            this.ckbDateNote.Name = "ckbDateNote";
            this.ckbDateNote.Size = new System.Drawing.Size(72, 16);
            this.ckbDateNote.TabIndex = 2;
            this.ckbDateNote.Text = "计划日期";
            this.ckbDateNote.UseVisualStyleBackColor = true;
            // 
            // ckbPrd
            // 
            this.ckbPrd.AutoSize = true;
            this.ckbPrd.Location = new System.Drawing.Point(5, 13);
            this.ckbPrd.Name = "ckbPrd";
            this.ckbPrd.Size = new System.Drawing.Size(48, 16);
            this.ckbPrd.TabIndex = 0;
            this.ckbPrd.Text = "产品";
            this.ckbPrd.UseVisualStyleBackColor = true;
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
            // CtrlPackingBOMPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CtrlPackingBOMPlan";
            this.Size = new System.Drawing.Size(849, 504);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvNonBOMPlan)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvBOMPlan)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel lnkBatchBOMPlan;
        private JCommon.CtrlGridFind ctrlQFind;
        private JCommon.MyDataGridView dgrdvNonBOMPlan;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnBOMPlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPackingTypeName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyAbbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.CheckBox ckbDateNote;
        private System.Windows.Forms.CheckBox ckbPrd;
        private System.Windows.Forms.Panel panel4;
        private JCommon.PagebreakNav pbar;
        private JCommon.MyDataGridView dgrdvBOMPlan;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnbtnDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateNote1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPackingTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateTarget1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPONo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMakerPsn;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private JERPApp.Define.Product.CtrlFinishedPrd ctrlPrdID;
        private System.Windows.Forms.LinkLabel lnkNonPlanBOM;
    }
}
