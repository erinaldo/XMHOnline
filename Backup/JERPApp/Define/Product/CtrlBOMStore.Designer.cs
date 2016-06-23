namespace JERPApp.Define.Product
{
    partial class CtrlBOMStore
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlBOMStore));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnMark = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnPrdStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAssistantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAssemblyQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLossRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdStoreQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMtrStoreQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnElement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPostProcessing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSourceTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubstitute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTechnology = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnParentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnParentFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.ctrlQFind);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 307);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 28);
            this.panel1.TabIndex = 27;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(333, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 28;
            this.btnExport.Text = "输出Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(3, 4);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(304, 21);
            this.ctrlQFind.TabIndex = 27;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMark,
            this.ColumnPrdStatus,
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnAssistantCode,
            this.ColumnAssemblyQty,
            this.ColumnLossRate,
            this.ColumnPrdStoreQty,
            this.ColumnMtrStoreQty,
            this.ColumnElement,
            this.ColumnMemo,
            this.ColumnPostProcessing,
            this.ColumnSourceTypeName,
            this.ColumnManufacturer,
            this.ColumnSubstitute,
            this.ColumnTechnology,
            this.ColumnUnitName,
            this.ColumnPrdID,
            this.ColumnParentID,
            this.ColumnParentFlag});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 0);
            this.dgrdv.Name = "dgrdv";
            this.dgrdv.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(720, 307);
            this.dgrdv.TabIndex = 94;
            // 
            // ColumnMark
            // 
            this.ColumnMark.DataPropertyName = "Mark";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle1.NullValue")));
            this.ColumnMark.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnMark.HeaderText = "±";
            this.ColumnMark.Name = "ColumnMark";
            this.ColumnMark.ReadOnly = true;
            this.ColumnMark.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnMark.Width = 30;
            // 
            // ColumnPrdStatus
            // 
            this.ColumnPrdStatus.DataPropertyName = "PrdStatus";
            this.ColumnPrdStatus.HeaderText = "工序";
            this.ColumnPrdStatus.Name = "ColumnPrdStatus";
            this.ColumnPrdStatus.ReadOnly = true;
            this.ColumnPrdStatus.Width = 80;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnPrdCode.HeaderText = "产品编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.ReadOnly = true;
            this.ColumnPrdCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.HeaderText = "产品名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            this.ColumnPrdName.ReadOnly = true;
            this.ColumnPrdName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdSpec.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnPrdSpec.HeaderText = "产品规格";
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
            // ColumnAssistantCode
            // 
            this.ColumnAssistantCode.DataPropertyName = "AssistantCode";
            this.ColumnAssistantCode.HeaderText = "助记码";
            this.ColumnAssistantCode.Name = "ColumnAssistantCode";
            this.ColumnAssistantCode.ReadOnly = true;
            this.ColumnAssistantCode.Width = 66;
            // 
            // ColumnAssemblyQty
            // 
            this.ColumnAssemblyQty.DataPropertyName = "AssemblyQty";
            this.ColumnAssemblyQty.HeaderText = "用量";
            this.ColumnAssemblyQty.Name = "ColumnAssemblyQty";
            this.ColumnAssemblyQty.ReadOnly = true;
            this.ColumnAssemblyQty.Width = 66;
            // 
            // ColumnLossRate
            // 
            this.ColumnLossRate.DataPropertyName = "LossRate";
            dataGridViewCellStyle4.Format = "0.####%";
            this.ColumnLossRate.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnLossRate.HeaderText = "损耗率";
            this.ColumnLossRate.Name = "ColumnLossRate";
            this.ColumnLossRate.ReadOnly = true;
            this.ColumnLossRate.Width = 66;
            // 
            // ColumnPrdStoreQty
            // 
            this.ColumnPrdStoreQty.DataPropertyName = "PrdStoreQty";
            this.ColumnPrdStoreQty.HeaderText = "产品库";
            this.ColumnPrdStoreQty.Name = "ColumnPrdStoreQty";
            this.ColumnPrdStoreQty.ReadOnly = true;
            this.ColumnPrdStoreQty.Width = 66;
            // 
            // ColumnMtrStoreQty
            // 
            this.ColumnMtrStoreQty.DataPropertyName = "MtrStoreQty";
            this.ColumnMtrStoreQty.HeaderText = "原料库";
            this.ColumnMtrStoreQty.Name = "ColumnMtrStoreQty";
            this.ColumnMtrStoreQty.ReadOnly = true;
            this.ColumnMtrStoreQty.Width = 66;
            // 
            // ColumnElement
            // 
            this.ColumnElement.DataPropertyName = "Element";
            this.ColumnElement.HeaderText = "位置";
            this.ColumnElement.Name = "ColumnElement";
            this.ColumnElement.ReadOnly = true;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.ReadOnly = true;
            this.ColumnMemo.Width = 80;
            // 
            // ColumnPostProcessing
            // 
            this.ColumnPostProcessing.DataPropertyName = "PostProcessing";
            this.ColumnPostProcessing.HeaderText = "后处理方式";
            this.ColumnPostProcessing.Name = "ColumnPostProcessing";
            this.ColumnPostProcessing.ReadOnly = true;
            this.ColumnPostProcessing.Width = 90;
            // 
            // ColumnSourceTypeName
            // 
            this.ColumnSourceTypeName.DataPropertyName = "SourceTypeName";
            this.ColumnSourceTypeName.HeaderText = "来源";
            this.ColumnSourceTypeName.Name = "ColumnSourceTypeName";
            this.ColumnSourceTypeName.ReadOnly = true;
            this.ColumnSourceTypeName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSourceTypeName.Width = 54;
            // 
            // ColumnManufacturer
            // 
            this.ColumnManufacturer.DataPropertyName = "Manufacturer";
            this.ColumnManufacturer.HeaderText = "品牌";
            this.ColumnManufacturer.Name = "ColumnManufacturer";
            this.ColumnManufacturer.ReadOnly = true;
            this.ColumnManufacturer.Width = 66;
            // 
            // ColumnSubstitute
            // 
            this.ColumnSubstitute.DataPropertyName = "Substitute";
            this.ColumnSubstitute.HeaderText = "替代料";
            this.ColumnSubstitute.Name = "ColumnSubstitute";
            this.ColumnSubstitute.ReadOnly = true;
            // 
            // ColumnTechnology
            // 
            this.ColumnTechnology.DataPropertyName = "Technology";
            this.ColumnTechnology.HeaderText = "工艺要求";
            this.ColumnTechnology.Name = "ColumnTechnology";
            this.ColumnTechnology.ReadOnly = true;
            this.ColumnTechnology.Width = 80;
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
            // ColumnParentFlag
            // 
            this.ColumnParentFlag.DataPropertyName = "ParentFlag";
            this.ColumnParentFlag.HeaderText = "ParentFlag";
            this.ColumnParentFlag.Name = "ColumnParentFlag";
            this.ColumnParentFlag.ReadOnly = true;
            this.ColumnParentFlag.Visible = false;
            // 
            // CtrlBOMStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel1);
            this.Name = "CtrlBOMStore";
            this.Size = new System.Drawing.Size(720, 335);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewImageColumn ColumnMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAssistantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAssemblyQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLossRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdStoreQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMtrStoreQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnElement;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPostProcessing;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSourceTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSubstitute;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTechnology;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnParentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnParentFlag;
    }
}
