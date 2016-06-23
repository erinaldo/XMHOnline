namespace JERPApp.Manufacture
{
    partial class CtrlManufBOMPlanOper
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlManufBOMPlanOper));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnBatchImport = new System.Windows.Forms.Button();
            this.dgrdv = new JCommon.MyDataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlSupplierID = new JERPApp.Define.General.CtrlSupplierForOutSrc();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbOutSrcFlag = new System.Windows.Forms.CheckBox();
            this.txtPrdStatus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAssemblyQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLossRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSourceTypeID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnSubstitute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRequireQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutSrcStoreQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStoreQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRoadStoreQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPlanQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnParentFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.ctrlQFind);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnBatchImport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 556);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(973, 28);
            this.panel1.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(465, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(3, 4);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(244, 21);
            this.ctrlQFind.TabIndex = 30;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(384, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "+物料";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnBatchImport
            // 
            this.btnBatchImport.Location = new System.Drawing.Point(254, 3);
            this.btnBatchImport.Name = "btnBatchImport";
            this.btnBatchImport.Size = new System.Drawing.Size(89, 23);
            this.btnBatchImport.TabIndex = 25;
            this.btnBatchImport.Text = "Excel导入";
            this.btnBatchImport.UseVisualStyleBackColor = true;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnAssemblyQty,
            this.ColumnLossRate,
            this.ColumnSourceTypeID,
            this.ColumnSubstitute,
            this.ColumnRequireQty,
            this.ColumnOutSrcStoreQty,
            this.ColumnStoreQty,
            this.ColumnRoadStoreQty,
            this.ColumnPlanQty,
            this.ColumnUnitName,
            this.ColumnPrdID,
            this.ColumnParentFlag,
            this.ColumnMemo,
            this.ColumnManufacturer});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 32);
            this.dgrdv.Name = "dgrdv";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(973, 524);
            this.dgrdv.TabIndex = 24;
            // 
            // dataGridViewImageColumn1
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 14F);
            dataGridViewCellStyle7.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle7.NullValue")));
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewImageColumn1.HeaderText = "±";
            this.dataGridViewImageColumn1.Image = global::JERPApp.Properties.Resources.subtract;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 25;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlSupplierID);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.ckbOutSrcFlag);
            this.panel2.Controls.Add(this.txtPrdStatus);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(973, 32);
            this.panel2.TabIndex = 25;
            // 
            // ctrlSupplierID
            // 
            this.ctrlSupplierID.CompanyID = -1;
            this.ctrlSupplierID.Location = new System.Drawing.Point(295, 5);
            this.ctrlSupplierID.Name = "ctrlSupplierID";
            this.ctrlSupplierID.Size = new System.Drawing.Size(195, 23);
            this.ctrlSupplierID.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "委外商";
            // 
            // ckbOutSrcFlag
            // 
            this.ckbOutSrcFlag.AutoSize = true;
            this.ckbOutSrcFlag.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckbOutSrcFlag.Location = new System.Drawing.Point(169, 10);
            this.ckbOutSrcFlag.Name = "ckbOutSrcFlag";
            this.ckbOutSrcFlag.Size = new System.Drawing.Size(48, 16);
            this.ckbOutSrcFlag.TabIndex = 3;
            this.ckbOutSrcFlag.Text = "委外";
            this.ckbOutSrcFlag.UseVisualStyleBackColor = true;
            // 
            // txtPrdStatus
            // 
            this.txtPrdStatus.Location = new System.Drawing.Point(40, 4);
            this.txtPrdStatus.Name = "txtPrdStatus";
            this.txtPrdStatus.ReadOnly = true;
            this.txtPrdStatus.Size = new System.Drawing.Size(121, 21);
            this.txtPrdStatus.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工序";
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdCode.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnPrdCode.HeaderText = "物料编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.ReadOnly = true;
            this.ColumnPrdCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.HeaderText = "物料名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            this.ColumnPrdName.ReadOnly = true;
            this.ColumnPrdName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdName.Width = 80;
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdSpec.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnPrdSpec.HeaderText = "物料规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            this.ColumnPrdSpec.ReadOnly = true;
            this.ColumnPrdSpec.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnModel
            // 
            this.ColumnModel.DataPropertyName = "Model";
            this.ColumnModel.HeaderText = "机型";
            this.ColumnModel.Name = "ColumnModel";
            this.ColumnModel.ReadOnly = true;
            this.ColumnModel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnModel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnModel.Width = 66;
            // 
            // ColumnAssemblyQty
            // 
            this.ColumnAssemblyQty.DataPropertyName = "AssemblyQty";
            this.ColumnAssemblyQty.HeaderText = "用量";
            this.ColumnAssemblyQty.Name = "ColumnAssemblyQty";
            this.ColumnAssemblyQty.Width = 54;
            // 
            // ColumnLossRate
            // 
            this.ColumnLossRate.DataPropertyName = "LossRate";
            dataGridViewCellStyle3.Format = "0.####%";
            this.ColumnLossRate.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnLossRate.HeaderText = "损耗率";
            this.ColumnLossRate.Name = "ColumnLossRate";
            this.ColumnLossRate.Width = 66;
            // 
            // ColumnSourceTypeID
            // 
            this.ColumnSourceTypeID.DataPropertyName = "SourceTypeID";
            this.ColumnSourceTypeID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnSourceTypeID.HeaderText = "来源";
            this.ColumnSourceTypeID.Name = "ColumnSourceTypeID";
            this.ColumnSourceTypeID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSourceTypeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnSourceTypeID.Width = 54;
            // 
            // ColumnSubstitute
            // 
            this.ColumnSubstitute.DataPropertyName = "Substitute";
            this.ColumnSubstitute.HeaderText = "替代料";
            this.ColumnSubstitute.Name = "ColumnSubstitute";
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
            this.ColumnOutSrcStoreQty.Width = 66;
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
            // ColumnUnitName
            // 
            this.ColumnUnitName.DataPropertyName = "UnitName";
            this.ColumnUnitName.HeaderText = "单位";
            this.ColumnUnitName.Name = "ColumnUnitName";
            this.ColumnUnitName.ReadOnly = true;
            this.ColumnUnitName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnUnitName.Width = 54;
            // 
            // ColumnPrdID
            // 
            this.ColumnPrdID.DataPropertyName = "PrdID";
            this.ColumnPrdID.HeaderText = "PrdID";
            this.ColumnPrdID.Name = "ColumnPrdID";
            this.ColumnPrdID.Visible = false;
            // 
            // ColumnParentFlag
            // 
            this.ColumnParentFlag.DataPropertyName = "ParentFlag";
            this.ColumnParentFlag.HeaderText = "ParentFlag";
            this.ColumnParentFlag.Name = "ColumnParentFlag";
            this.ColumnParentFlag.Visible = false;
            this.ColumnParentFlag.Width = 54;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.Width = 80;
            // 
            // ColumnManufacturer
            // 
            this.ColumnManufacturer.DataPropertyName = "Manufacturer";
            this.ColumnManufacturer.HeaderText = "品牌";
            this.ColumnManufacturer.Name = "ColumnManufacturer";
            this.ColumnManufacturer.ReadOnly = true;
            this.ColumnManufacturer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnManufacturer.Width = 66;
            // 
            // CtrlBOMPlanOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CtrlBOMPlanOper";
            this.Size = new System.Drawing.Size(973, 584);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBatchImport;
        private JCommon.MyDataGridView dgrdv;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel2;
        private JERPApp.Define.General.CtrlSupplierForOutSrc ctrlSupplierID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckbOutSrcFlag;
        private System.Windows.Forms.TextBox txtPrdStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAssemblyQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLossRate;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnSourceTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSubstitute;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRequireQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutSrcStoreQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStoreQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRoadStoreQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPlanQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnParentFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnManufacturer;
    }
}