namespace JERPApp.Finance.Report
{
    partial class CtrlPrdBOM
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnMark = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnPrefix = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnPrdStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAssemblyQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnParentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnManufProcessID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnParentFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMark,
            this.ColumnPrefix,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnPrdStatus,
            this.ColumnAssemblyQty,
            this.ColumnUnitName,
            this.ColumnCostPrice,
            this.ColumnPrdID,
            this.ColumnParentID,
            this.ColumnManufProcessID,
            this.ColumnParentFlag});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 0);
            this.dgrdv.Name = "dgrdv";
            this.dgrdv.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(738, 176);
            this.dgrdv.TabIndex = 24;
            // 
            // ColumnMark
            // 
            this.ColumnMark.DataPropertyName = "Mark";
            this.ColumnMark.HeaderText = "±";
            this.ColumnMark.Name = "ColumnMark";
            this.ColumnMark.ReadOnly = true;
            this.ColumnMark.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnMark.Width = 35;
            // 
            // ColumnPrefix
            // 
            this.ColumnPrefix.ActiveLinkColor = System.Drawing.Color.Blue;
            this.ColumnPrefix.DataPropertyName = "Prefix";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrefix.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnPrefix.HeaderText = "产品编号";
            this.ColumnPrefix.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.ColumnPrefix.LinkColor = System.Drawing.Color.Blue;
            this.ColumnPrefix.Name = "ColumnPrefix";
            this.ColumnPrefix.ReadOnly = true;
            this.ColumnPrefix.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrefix.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnPrefix.VisitedLinkColor = System.Drawing.Color.Blue;
            this.ColumnPrefix.Width = 200;
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.ActiveLinkColor = System.Drawing.Color.Blue;
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.HeaderText = "产品名称";
            this.ColumnPrdName.LinkColor = System.Drawing.Color.Blue;
            this.ColumnPrdName.Name = "ColumnPrdName";
            this.ColumnPrdName.ReadOnly = true;
            this.ColumnPrdName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnPrdName.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.ActiveLinkColor = System.Drawing.Color.Blue;
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdSpec.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnPrdSpec.HeaderText = "产品规格";
            this.ColumnPrdSpec.LinkColor = System.Drawing.Color.Blue;
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            this.ColumnPrdSpec.ReadOnly = true;
            this.ColumnPrdSpec.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdSpec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnPrdSpec.VisitedLinkColor = System.Drawing.Color.Blue;
            this.ColumnPrdSpec.Width = 120;
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
            this.ColumnPrdStatus.Width = 66;
            // 
            // ColumnAssemblyQty
            // 
            this.ColumnAssemblyQty.DataPropertyName = "AssemblyQty";
            this.ColumnAssemblyQty.HeaderText = "用量";
            this.ColumnAssemblyQty.Name = "ColumnAssemblyQty";
            this.ColumnAssemblyQty.ReadOnly = true;
            this.ColumnAssemblyQty.Width = 66;
            // 
            // ColumnUnitName
            // 
            this.ColumnUnitName.DataPropertyName = "UnitName";
            this.ColumnUnitName.HeaderText = "单位";
            this.ColumnUnitName.Name = "ColumnUnitName";
            this.ColumnUnitName.ReadOnly = true;
            this.ColumnUnitName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnUnitName.Width = 54;
            // 
            // ColumnCostPrice
            // 
            this.ColumnCostPrice.DataPropertyName = "CostPrice";
            this.ColumnCostPrice.HeaderText = "成本价";
            this.ColumnCostPrice.Name = "ColumnCostPrice";
            this.ColumnCostPrice.ReadOnly = true;
            this.ColumnCostPrice.Width = 66;
            // 
            // ColumnPrdID
            // 
            this.ColumnPrdID.DataPropertyName = "PrdID";
            this.ColumnPrdID.HeaderText = "PrdID";
            this.ColumnPrdID.Name = "ColumnPrdID";
            this.ColumnPrdID.ReadOnly = true;
            this.ColumnPrdID.Visible = false;
            // 
            // ColumnParentID
            // 
            this.ColumnParentID.DataPropertyName = "ParentID";
            this.ColumnParentID.HeaderText = "ParentID";
            this.ColumnParentID.Name = "ColumnParentID";
            this.ColumnParentID.ReadOnly = true;
            this.ColumnParentID.Visible = false;
            // 
            // ColumnManufProcessID
            // 
            this.ColumnManufProcessID.DataPropertyName = "ManufProcessID";
            this.ColumnManufProcessID.HeaderText = "ManufProcessID";
            this.ColumnManufProcessID.Name = "ColumnManufProcessID";
            this.ColumnManufProcessID.ReadOnly = true;
            this.ColumnManufProcessID.Visible = false;
            // 
            // ColumnParentFlag
            // 
            this.ColumnParentFlag.DataPropertyName = "ParentFlag";
            this.ColumnParentFlag.HeaderText = "ParentFlag";
            this.ColumnParentFlag.Name = "ColumnParentFlag";
            this.ColumnParentFlag.ReadOnly = true;
            this.ColumnParentFlag.Visible = false;
            // 
            // CtrlPrdBOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgrdv);
            this.Name = "CtrlPrdBOM";
            this.Size = new System.Drawing.Size(738, 176);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DataGridViewImageColumn ColumnMark;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnPrefix;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAssemblyQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCostPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnParentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnManufProcessID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnParentFlag;


    }
}
