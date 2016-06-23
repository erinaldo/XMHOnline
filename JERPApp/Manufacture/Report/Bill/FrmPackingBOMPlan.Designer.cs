namespace JERPApp.Manufacture.Report.Bill
{
    partial class FrmPackingBOMPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPackageAssembly = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdAssembly = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSourceTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRequireQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutSrcStoreQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStoreQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRoadStoreQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPlanQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProcessingFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlQFind);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 454);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(935, 28);
            this.panel1.TabIndex = 3;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(3, 4);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(295, 21);
            this.ctrlQFind.TabIndex = 30;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dgrdv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.ColumnHeadersHeight = 42;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnManufacturer,
            this.ColumnUnitName,
            this.ColumnPackageAssembly,
            this.ColumnPrdAssembly,
            this.ColumnSourceTypeName,
            this.ColumnRequireQty,
            this.ColumnOutSrcStoreQty,
            this.ColumnStoreQty,
            this.ColumnRoadStoreQty,
            this.ColumnPlanQty,
            this.ColumnPrdID,
            this.ColumnProcessingFlag});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(165)))), ((int)(((byte)(198)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 0);
            this.dgrdv.Name = "dgrdv";
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
            this.dgrdv.Size = new System.Drawing.Size(935, 454);
            this.dgrdv.TabIndex = 4;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.HeaderText = "包材编码";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.ReadOnly = true;
            this.ColumnPrdCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdCode.Width = 80;
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.HeaderText = "包材名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            this.ColumnPrdName.ReadOnly = true;
            this.ColumnPrdName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            this.ColumnPrdSpec.HeaderText = "包材规格";
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
            // ColumnManufacturer
            // 
            this.ColumnManufacturer.DataPropertyName = "Manufacturer";
            this.ColumnManufacturer.HeaderText = "品牌";
            this.ColumnManufacturer.Name = "ColumnManufacturer";
            this.ColumnManufacturer.ReadOnly = true;
            this.ColumnManufacturer.Width = 66;
            // 
            // ColumnUnitName
            // 
            this.ColumnUnitName.DataPropertyName = "UnitName";
            this.ColumnUnitName.HeaderText = "单位";
            this.ColumnUnitName.Name = "ColumnUnitName";
            this.ColumnUnitName.ReadOnly = true;
            this.ColumnUnitName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnUnitName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnUnitName.Width = 54;
            // 
            // ColumnPackageAssembly
            // 
            this.ColumnPackageAssembly.DataPropertyName = "PackageAssembly";
            this.ColumnPackageAssembly.HeaderText = "包材";
            this.ColumnPackageAssembly.Name = "ColumnPackageAssembly";
            this.ColumnPackageAssembly.Width = 54;
            // 
            // ColumnPrdAssembly
            // 
            this.ColumnPrdAssembly.DataPropertyName = "PrdAssembly";
            this.ColumnPrdAssembly.HeaderText = "物料";
            this.ColumnPrdAssembly.Name = "ColumnPrdAssembly";
            this.ColumnPrdAssembly.Width = 54;
            // 
            // ColumnSourceTypeName
            // 
            this.ColumnSourceTypeName.DataPropertyName = "SourceTypeName";
            this.ColumnSourceTypeName.HeaderText = "来源";
            this.ColumnSourceTypeName.Name = "ColumnSourceTypeName";
            this.ColumnSourceTypeName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSourceTypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnSourceTypeName.Width = 66;
            // 
            // ColumnRequireQty
            // 
            this.ColumnRequireQty.DataPropertyName = "RequireQty";
            this.ColumnRequireQty.HeaderText = "需求";
            this.ColumnRequireQty.Name = "ColumnRequireQty";
            this.ColumnRequireQty.Width = 54;
            // 
            // ColumnOutSrcStoreQty
            // 
            this.ColumnOutSrcStoreQty.DataPropertyName = "OutSrcStoreQty";
            this.ColumnOutSrcStoreQty.HeaderText = "委外存";
            this.ColumnOutSrcStoreQty.Name = "ColumnOutSrcStoreQty";
            this.ColumnOutSrcStoreQty.ReadOnly = true;
            this.ColumnOutSrcStoreQty.Width = 54;
            // 
            // ColumnStoreQty
            // 
            this.ColumnStoreQty.DataPropertyName = "StoreQty";
            this.ColumnStoreQty.HeaderText = "库存";
            this.ColumnStoreQty.Name = "ColumnStoreQty";
            this.ColumnStoreQty.ReadOnly = true;
            this.ColumnStoreQty.Width = 54;
            // 
            // ColumnRoadStoreQty
            // 
            this.ColumnRoadStoreQty.DataPropertyName = "RoadStoreQty";
            this.ColumnRoadStoreQty.HeaderText = "在途";
            this.ColumnRoadStoreQty.Name = "ColumnRoadStoreQty";
            this.ColumnRoadStoreQty.ReadOnly = true;
            this.ColumnRoadStoreQty.Width = 54;
            // 
            // ColumnPlanQty
            // 
            this.ColumnPlanQty.DataPropertyName = "PlanQty";
            this.ColumnPlanQty.HeaderText = "计划";
            this.ColumnPlanQty.Name = "ColumnPlanQty";
            this.ColumnPlanQty.Width = 54;
            // 
            // ColumnPrdID
            // 
            this.ColumnPrdID.DataPropertyName = "PrdID";
            this.ColumnPrdID.HeaderText = "PrdID";
            this.ColumnPrdID.Name = "ColumnPrdID";
            this.ColumnPrdID.Visible = false;
            // 
            // ColumnProcessingFlag
            // 
            this.ColumnProcessingFlag.DataPropertyName = "ProcessingFlag";
            this.ColumnProcessingFlag.HeaderText = "ProcessingFlag";
            this.ColumnProcessingFlag.Name = "ColumnProcessingFlag";
            this.ColumnProcessingFlag.Visible = false;
            // 
            // FrmPackingBOMPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 482);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel1);
            this.Name = "FrmPackingBOMPlan";
            this.Text = "包装物料";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPackageAssembly;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdAssembly;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSourceTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRequireQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutSrcStoreQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStoreQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRoadStoreQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPlanQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnProcessingFlag;
    }
}