namespace JERPApp.Manufacture
{
    partial class CtrlPackingPlan
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.ctrlPrdID = new JERPApp.Define.Product.CtrlFinishedPrd();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radNonFinishedFlag = new System.Windows.Forms.RadioButton();
            this.radFinishedFlag = new System.Windows.Forms.RadioButton();
            this.ckbFinished = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radNonBOMPlan = new System.Windows.Forms.RadioButton();
            this.radBOMFlag = new System.Windows.Forms.RadioButton();
            this.ckbBOMFlag = new System.Windows.Forms.CheckBox();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.ckbDateNote = new System.Windows.Forms.CheckBox();
            this.ckbPrd = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pbar = new JCommon.PagebreakNav();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnbtnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnDateNote1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPackingTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateTarget1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBOMPlanFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnCompanyCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFinishedQty = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnPONo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMakerPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.panel5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ctrlPrdID);
            this.panel5.Controls.Add(this.btnSearch);
            this.panel5.Controls.Add(this.groupBox2);
            this.panel5.Controls.Add(this.ckbFinished);
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Controls.Add(this.ckbBOMFlag);
            this.panel5.Controls.Add(this.dtpDateEnd);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.dtpDateBegin);
            this.panel5.Controls.Add(this.ckbDateNote);
            this.panel5.Controls.Add(this.ckbPrd);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(937, 58);
            this.panel5.TabIndex = 5;
            // 
            // ctrlPrdID
            // 
            this.ctrlPrdID.AutoSize = true;
            this.ctrlPrdID.Location = new System.Drawing.Point(59, 3);
            this.ctrlPrdID.Name = "ctrlPrdID";
            this.ctrlPrdID.PrdID = -1;
            this.ctrlPrdID.Size = new System.Drawing.Size(631, 29);
            this.ctrlPrdID.TabIndex = 92;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(793, 33);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radNonFinishedFlag);
            this.groupBox2.Controls.Add(this.radFinishedFlag);
            this.groupBox2.Location = new System.Drawing.Point(464, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(131, 26);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // radNonFinishedFlag
            // 
            this.radNonFinishedFlag.AutoSize = true;
            this.radNonFinishedFlag.Checked = true;
            this.radNonFinishedFlag.Location = new System.Drawing.Point(56, 8);
            this.radNonFinishedFlag.Name = "radNonFinishedFlag";
            this.radNonFinishedFlag.Size = new System.Drawing.Size(59, 16);
            this.radNonFinishedFlag.TabIndex = 2;
            this.radNonFinishedFlag.TabStop = true;
            this.radNonFinishedFlag.Text = "未完成";
            this.radNonFinishedFlag.UseVisualStyleBackColor = true;
            // 
            // radFinishedFlag
            // 
            this.radFinishedFlag.AutoSize = true;
            this.radFinishedFlag.Location = new System.Drawing.Point(3, 8);
            this.radFinishedFlag.Name = "radFinishedFlag";
            this.radFinishedFlag.Size = new System.Drawing.Size(47, 16);
            this.radFinishedFlag.TabIndex = 0;
            this.radFinishedFlag.Text = "完成";
            this.radFinishedFlag.UseVisualStyleBackColor = true;
            // 
            // ckbFinished
            // 
            this.ckbFinished.AutoSize = true;
            this.ckbFinished.Location = new System.Drawing.Point(408, 36);
            this.ckbFinished.Name = "ckbFinished";
            this.ckbFinished.Size = new System.Drawing.Size(48, 16);
            this.ckbFinished.TabIndex = 8;
            this.ckbFinished.Text = "制令";
            this.ckbFinished.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radNonBOMPlan);
            this.groupBox1.Controls.Add(this.radBOMFlag);
            this.groupBox1.Location = new System.Drawing.Point(655, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 26);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // radNonBOMPlan
            // 
            this.radNonBOMPlan.AutoSize = true;
            this.radNonBOMPlan.Checked = true;
            this.radNonBOMPlan.Location = new System.Drawing.Point(57, 9);
            this.radNonBOMPlan.Name = "radNonBOMPlan";
            this.radNonBOMPlan.Size = new System.Drawing.Size(59, 16);
            this.radNonBOMPlan.TabIndex = 2;
            this.radNonBOMPlan.TabStop = true;
            this.radNonBOMPlan.Text = "未算料";
            this.radNonBOMPlan.UseVisualStyleBackColor = true;
            // 
            // radBOMFlag
            // 
            this.radBOMFlag.AutoSize = true;
            this.radBOMFlag.Location = new System.Drawing.Point(4, 9);
            this.radBOMFlag.Name = "radBOMFlag";
            this.radBOMFlag.Size = new System.Drawing.Size(47, 16);
            this.radBOMFlag.TabIndex = 0;
            this.radBOMFlag.Text = "算料";
            this.radBOMFlag.UseVisualStyleBackColor = true;
            // 
            // ckbBOMFlag
            // 
            this.ckbBOMFlag.AutoSize = true;
            this.ckbBOMFlag.Location = new System.Drawing.Point(601, 39);
            this.ckbBOMFlag.Name = "ckbBOMFlag";
            this.ckbBOMFlag.Size = new System.Drawing.Size(48, 16);
            this.ckbBOMFlag.TabIndex = 6;
            this.ckbBOMFlag.Text = "算料";
            this.ckbBOMFlag.UseVisualStyleBackColor = true;
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Location = new System.Drawing.Point(256, 33);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(137, 21);
            this.dtpDateEnd.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "到";
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.Location = new System.Drawing.Point(89, 32);
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.Size = new System.Drawing.Size(137, 21);
            this.dtpDateBegin.TabIndex = 3;
            // 
            // ckbDateNote
            // 
            this.ckbDateNote.AutoSize = true;
            this.ckbDateNote.Location = new System.Drawing.Point(6, 38);
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
            // panel4
            // 
            this.panel4.Controls.Add(this.pbar);
            this.panel4.Controls.Add(this.ctrlQFind);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 311);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(937, 24);
            this.panel4.TabIndex = 6;
            // 
            // pbar
            // 
            this.pbar.AutoSize = true;
            this.pbar.Location = new System.Drawing.Point(269, 0);
            this.pbar.Name = "pbar";
            this.pbar.PageInBlock = 10;
            this.pbar.PageIndex = 1;
            this.pbar.PageSize = 50;
            this.pbar.Size = new System.Drawing.Size(406, 27);
            this.pbar.TabIndex = 7;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(7, 3);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(256, 21);
            this.ctrlQFind.TabIndex = 5;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnEdit,
            this.ColumnDateNote1,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.ColumnPackingTypeName,
            this.ColumnQuantity,
            this.ColumnDateTarget1,
            this.ColumnBOMPlanFlag,
            this.ColumnCompanyCode1,
            this.ColumnFinishedQty,
            this.ColumnPONo1,
            this.dataGridViewTextBoxColumn9,
            this.ColumnMakerPsn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 58);
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
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(937, 253);
            this.dgrdv.TabIndex = 7;
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
            // ColumnDateNote1
            // 
            this.ColumnDateNote1.DataPropertyName = "DateNote";
            this.ColumnDateNote1.HeaderText = "计划日期";
            this.ColumnDateNote1.Name = "ColumnDateNote1";
            this.ColumnDateNote1.ReadOnly = true;
            this.ColumnDateNote1.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PrdCode";
            this.dataGridViewTextBoxColumn5.HeaderText = "产品编号";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PrdName";
            this.dataGridViewTextBoxColumn6.HeaderText = "产品名称";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "PrdSpec";
            this.dataGridViewTextBoxColumn7.HeaderText = "产品规格";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Model";
            this.dataGridViewTextBoxColumn8.HeaderText = "机型";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 66;
            // 
            // ColumnPackingTypeName
            // 
            this.ColumnPackingTypeName.DataPropertyName = "PackingTypeName";
            this.ColumnPackingTypeName.HeaderText = "包装类型";
            this.ColumnPackingTypeName.Name = "ColumnPackingTypeName";
            this.ColumnPackingTypeName.ReadOnly = true;
            this.ColumnPackingTypeName.Width = 80;
            // 
            // ColumnQuantity
            // 
            this.ColumnQuantity.DataPropertyName = "Quantity";
            this.ColumnQuantity.HeaderText = "数量";
            this.ColumnQuantity.Name = "ColumnQuantity";
            this.ColumnQuantity.ReadOnly = true;
            this.ColumnQuantity.Width = 66;
            // 
            // ColumnDateTarget1
            // 
            this.ColumnDateTarget1.DataPropertyName = "DateTarget";
            this.ColumnDateTarget1.HeaderText = "交货日期";
            this.ColumnDateTarget1.Name = "ColumnDateTarget1";
            this.ColumnDateTarget1.ReadOnly = true;
            this.ColumnDateTarget1.Width = 80;
            // 
            // ColumnBOMPlanFlag
            // 
            this.ColumnBOMPlanFlag.DataPropertyName = "BOMPlanFlag";
            this.ColumnBOMPlanFlag.HeaderText = "算料";
            this.ColumnBOMPlanFlag.Name = "ColumnBOMPlanFlag";
            this.ColumnBOMPlanFlag.ReadOnly = true;
            this.ColumnBOMPlanFlag.Width = 54;
            // 
            // ColumnCompanyCode1
            // 
            this.ColumnCompanyCode1.DataPropertyName = "CompanyCode";
            this.ColumnCompanyCode1.HeaderText = "客户";
            this.ColumnCompanyCode1.Name = "ColumnCompanyCode1";
            this.ColumnCompanyCode1.ReadOnly = true;
            this.ColumnCompanyCode1.Width = 66;
            // 
            // ColumnFinishedQty
            // 
            this.ColumnFinishedQty.DataPropertyName = "FinishedQty";
            this.ColumnFinishedQty.HeaderText = "制令数";
            this.ColumnFinishedQty.Name = "ColumnFinishedQty";
            this.ColumnFinishedQty.ReadOnly = true;
            this.ColumnFinishedQty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnFinishedQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnFinishedQty.Width = 66;
            // 
            // ColumnPONo1
            // 
            this.ColumnPONo1.DataPropertyName = "PONo";
            this.ColumnPONo1.HeaderText = "订单编号";
            this.ColumnPONo1.Name = "ColumnPONo1";
            this.ColumnPONo1.ReadOnly = true;
            this.ColumnPONo1.Width = 80;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "UnitName";
            this.dataGridViewTextBoxColumn9.HeaderText = "单位";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 54;
            // 
            // ColumnMakerPsn
            // 
            this.ColumnMakerPsn.DataPropertyName = "MakerPsn";
            this.ColumnMakerPsn.HeaderText = "制定人";
            this.ColumnMakerPsn.Name = "ColumnMakerPsn";
            this.ColumnMakerPsn.ReadOnly = true;
            this.ColumnMakerPsn.Width = 66;
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
            // CtrlPackingPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Name = "CtrlPackingPlan";
            this.Size = new System.Drawing.Size(937, 335);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radNonFinishedFlag;
        private System.Windows.Forms.RadioButton radFinishedFlag;
        private System.Windows.Forms.CheckBox ckbFinished;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radNonBOMPlan;
        private System.Windows.Forms.RadioButton radBOMFlag;
        private System.Windows.Forms.CheckBox ckbBOMFlag;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.CheckBox ckbDateNote;
        private System.Windows.Forms.CheckBox ckbPrd;
        private System.Windows.Forms.Panel panel4;
        private JCommon.PagebreakNav pbar;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private JERPApp.Define.Product.CtrlFinishedPrd ctrlPrdID;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateNote1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPackingTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateTarget1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnBOMPlanFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyCode1;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnFinishedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPONo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMakerPsn;
    }
}
