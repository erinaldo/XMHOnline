namespace JERPApp.Manufacture
{
    partial class FrmPackingSheetBatchNew
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctrlCkbAll = new JCommon.CtrlGridCheckBox();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnCheckedFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNonFinishedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPackingTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAvailablePackingQty = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnPONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.ctrlCkbAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 637);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(978, 30);
            this.panel2.TabIndex = 1;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(71, 4);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(287, 21);
            this.ctrlQFind.TabIndex = 13;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(364, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "批量保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // ctrlCkbAll
            // 
            this.ctrlCkbAll.CheckedFlag = false;
            this.ctrlCkbAll.Location = new System.Drawing.Point(6, 8);
            this.ctrlCkbAll.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlCkbAll.Name = "ctrlCkbAll";
            this.ctrlCkbAll.SeachGridView = null;
            this.ctrlCkbAll.Size = new System.Drawing.Size(52, 18);
            this.ctrlCkbAll.TabIndex = 0;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCheckedFlag,
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnNonFinishedQty,
            this.ColumnPackingTypeName,
            this.ColumnAvailablePackingQty,
            this.ColumnPONo,
            this.ColumnCompanyCode,
            this.ColumnUnitName});
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
            this.dgrdv.Size = new System.Drawing.Size(978, 637);
            this.dgrdv.TabIndex = 2;
            // 
            // ColumnCheckedFlag
            // 
            this.ColumnCheckedFlag.DataPropertyName = "CheckedFlag";
            this.ColumnCheckedFlag.HeaderText = "下达";
            this.ColumnCheckedFlag.Name = "ColumnCheckedFlag";
            this.ColumnCheckedFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnCheckedFlag.Width = 54;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.HeaderText = "产品编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.HeaderText = "产品名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            this.ColumnPrdName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            this.ColumnPrdSpec.HeaderText = "产品规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            // 
            // ColumnModel
            // 
            this.ColumnModel.DataPropertyName = "Model";
            this.ColumnModel.HeaderText = "机型";
            this.ColumnModel.Name = "ColumnModel";
            this.ColumnModel.Width = 80;
            // 
            // ColumnNonFinishedQty
            // 
            this.ColumnNonFinishedQty.DataPropertyName = "NonFinishedQty";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            this.ColumnNonFinishedQty.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnNonFinishedQty.HeaderText = "数量";
            this.ColumnNonFinishedQty.Name = "ColumnNonFinishedQty";
            this.ColumnNonFinishedQty.Width = 66;
            // 
            // ColumnPackingTypeName
            // 
            this.ColumnPackingTypeName.DataPropertyName = "PackingTypeName";
            this.ColumnPackingTypeName.HeaderText = "包装方案";
            this.ColumnPackingTypeName.Name = "ColumnPackingTypeName";
            this.ColumnPackingTypeName.Width = 80;
            // 
            // ColumnAvailablePackingQty
            // 
            this.ColumnAvailablePackingQty.DataPropertyName = "AvailablePackingQty";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Red;
            this.ColumnAvailablePackingQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnAvailablePackingQty.HeaderText = "可下达";
            this.ColumnAvailablePackingQty.Name = "ColumnAvailablePackingQty";
            this.ColumnAvailablePackingQty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnAvailablePackingQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnAvailablePackingQty.Width = 66;
            // 
            // ColumnPONo
            // 
            this.ColumnPONo.DataPropertyName = "PONo";
            this.ColumnPONo.HeaderText = "订单编号";
            this.ColumnPONo.Name = "ColumnPONo";
            this.ColumnPONo.Width = 80;
            // 
            // ColumnCompanyCode
            // 
            this.ColumnCompanyCode.DataPropertyName = "CompanyCode";
            this.ColumnCompanyCode.HeaderText = "客户";
            this.ColumnCompanyCode.Name = "ColumnCompanyCode";
            this.ColumnCompanyCode.Width = 60;
            // 
            // ColumnUnitName
            // 
            this.ColumnUnitName.DataPropertyName = "UnitName";
            this.ColumnUnitName.HeaderText = "单位";
            this.ColumnUnitName.Name = "ColumnUnitName";
            this.ColumnUnitName.Width = 54;
            // 
            // FrmPackingSheetBatchNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 667);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Name = "FrmPackingSheetBatchNew";
            this.Text = "包装制令单(适用于包装物料无变动)";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private JCommon.CtrlGridCheckBox ctrlCkbAll;
        private System.Windows.Forms.Button btnSave;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheckedFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNonFinishedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPackingTypeName;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnAvailablePackingQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName;
    }
}