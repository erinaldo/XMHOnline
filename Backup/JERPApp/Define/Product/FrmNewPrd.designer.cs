namespace JERPApp.Define.Product
{
    partial class FrmPrdNew
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
            this.dgrdv = new JCommon.MyDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlPrdTypeID = new JERPApp.Define.Product.CtrlPrdType();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSurface = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnSaleFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnMinPackingQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDWGNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAssistantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTaxfreeFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnPrdWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRohsFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnRohsRequireFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrdv
            // 
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnSurface,
            this.ColumnManufacturer,
            this.ColumnUnitID,
            this.ColumnSaleFlag,
            this.ColumnMinPackingQty,
            this.ColumnDWGNo,
            this.ColumnAssistantCode,
            this.ColumnTaxfreeFlag,
            this.ColumnPrdWeight,
            this.ColumnRohsFlag,
            this.ColumnRohsRequireFlag,
            this.ColumnURL,
            this.ColumnMemo});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 0);
            this.dgrdv.Name = "dgrdv";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(836, 354);
            this.dgrdv.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlPrdTypeID);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnImport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 354);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(836, 32);
            this.panel2.TabIndex = 4;
            // 
            // ctrlPrdTypeID
            // 
            this.ctrlPrdTypeID.Location = new System.Drawing.Point(71, 5);
            this.ctrlPrdTypeID.Name = "ctrlPrdTypeID";
            this.ctrlPrdTypeID.PrdTypeID = -1;
            this.ctrlPrdTypeID.Size = new System.Drawing.Size(353, 23);
            this.ctrlPrdTypeID.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "选择类型";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(660, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "新增保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(749, 5);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Excel导入";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.HeaderText = "产品编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.Width = 120;
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.HeaderText = "产品名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            this.ColumnPrdSpec.HeaderText = "产品规格 ";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            this.ColumnPrdSpec.Width = 120;
            // 
            // ColumnModel
            // 
            this.ColumnModel.DataPropertyName = "Model";
            this.ColumnModel.HeaderText = "机型";
            this.ColumnModel.Name = "ColumnModel";
            this.ColumnModel.Width = 80;
            // 
            // ColumnSurface
            // 
            this.ColumnSurface.DataPropertyName = "Surface";
            this.ColumnSurface.HeaderText = "封装/表面处理";
            this.ColumnSurface.Name = "ColumnSurface";
            this.ColumnSurface.Width = 120;
            // 
            // ColumnManufacturer
            // 
            this.ColumnManufacturer.DataPropertyName = "Manufacturer";
            this.ColumnManufacturer.HeaderText = "品牌";
            this.ColumnManufacturer.Name = "ColumnManufacturer";
            this.ColumnManufacturer.Width = 66;
            // 
            // ColumnUnitID
            // 
            this.ColumnUnitID.DataPropertyName = "UnitID";
            this.ColumnUnitID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnUnitID.HeaderText = "单位";
            this.ColumnUnitID.Name = "ColumnUnitID";
            this.ColumnUnitID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnUnitID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnUnitID.Width = 54;
            // 
            // ColumnSaleFlag
            // 
            this.ColumnSaleFlag.DataPropertyName = "SaleFlag";
            this.ColumnSaleFlag.HeaderText = "销售";
            this.ColumnSaleFlag.Name = "ColumnSaleFlag";
            this.ColumnSaleFlag.Width = 54;
            // 
            // ColumnMinPackingQty
            // 
            this.ColumnMinPackingQty.DataPropertyName = "MinPackingQty";
            this.ColumnMinPackingQty.HeaderText = "最小包装";
            this.ColumnMinPackingQty.Name = "ColumnMinPackingQty";
            this.ColumnMinPackingQty.Width = 80;
            // 
            // ColumnDWGNo
            // 
            this.ColumnDWGNo.DataPropertyName = "DWGNo";
            this.ColumnDWGNo.HeaderText = "图号";
            this.ColumnDWGNo.Name = "ColumnDWGNo";
            this.ColumnDWGNo.Width = 80;
            // 
            // ColumnAssistantCode
            // 
            this.ColumnAssistantCode.DataPropertyName = "AssistantCode";
            this.ColumnAssistantCode.HeaderText = "助记码";
            this.ColumnAssistantCode.Name = "ColumnAssistantCode";
            this.ColumnAssistantCode.Width = 80;
            // 
            // ColumnTaxfreeFlag
            // 
            this.ColumnTaxfreeFlag.DataPropertyName = "TaxfreeFlag";
            this.ColumnTaxfreeFlag.HeaderText = "保税料";
            this.ColumnTaxfreeFlag.Name = "ColumnTaxfreeFlag";
            this.ColumnTaxfreeFlag.Width = 66;
            // 
            // ColumnPrdWeight
            // 
            this.ColumnPrdWeight.DataPropertyName = "PrdWeight";
            this.ColumnPrdWeight.HeaderText = "单重Kg";
            this.ColumnPrdWeight.Name = "ColumnPrdWeight";
            this.ColumnPrdWeight.Width = 66;
            // 
            // ColumnRohsFlag
            // 
            this.ColumnRohsFlag.DataPropertyName = "RohsFlag";
            this.ColumnRohsFlag.HeaderText = "Rohs合格";
            this.ColumnRohsFlag.Name = "ColumnRohsFlag";
            this.ColumnRohsFlag.Width = 80;
            // 
            // ColumnRohsRequireFlag
            // 
            this.ColumnRohsRequireFlag.DataPropertyName = "RohsRequireFlag";
            this.ColumnRohsRequireFlag.HeaderText = "Rohs要求";
            this.ColumnRohsRequireFlag.Name = "ColumnRohsRequireFlag";
            this.ColumnRohsRequireFlag.Width = 80;
            // 
            // ColumnURL
            // 
            this.ColumnURL.DataPropertyName = "URL";
            this.ColumnURL.HeaderText = "网址";
            this.ColumnURL.Name = "ColumnURL";
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            // 
            // FrmPrdNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 386);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Name = "FrmPrdNew";
            this.Text = "产品定义";
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnImport;
        private CtrlPrdType ctrlPrdTypeID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSurface;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnManufacturer;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnUnitID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnSaleFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMinPackingQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDWGNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAssistantCode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnTaxfreeFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdWeight;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnRohsFlag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnRohsRequireFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnURL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
    }
}