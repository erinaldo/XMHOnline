namespace JERPApp.Engineer
{
    partial class FrmPrdDefine
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSurface = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnSupplier = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnSaleFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnMinPackingQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSetCount = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnBuyer = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnFileCount = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnImgCount = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRohsFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnRohsRequireFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnPrdWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTaxfreeFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnAssistantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDWGNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemPrdType = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemBuyer = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemMaxPrdCode = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlPrdTypeID = new JERPApp.Define.Product.CtrlPrdTypeTree();
            this.ctrlQFind = new JCommon.CtrlGridFind();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.panel2.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ctrlPrdTypeID);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgrdv);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(980, 600);
            this.splitContainer1.SplitterDistance = 167;
            this.splitContainer1.TabIndex = 3;
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
            this.ColumnSupplier,
            this.ColumnSaleFlag,
            this.ColumnMinPackingQty,
            this.ColumnPrdSetCount,
            this.ColumnBuyer,
            this.ColumnFileCount,
            this.ColumnImgCount,
            this.ColumnMemo,
            this.ColumnURL,
            this.ColumnRohsFlag,
            this.ColumnRohsRequireFlag,
            this.ColumnPrdWeight,
            this.ColumnTaxfreeFlag,
            this.ColumnAssistantCode,
            this.ColumnDWGNo});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 0);
            this.dgrdv.Name = "dgrdv";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(809, 568);
            this.dgrdv.TabIndex = 4;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.Frozen = true;
            this.ColumnPrdCode.HeaderText = "产品编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.Frozen = true;
            this.ColumnPrdName.HeaderText = "产品名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            this.ColumnPrdSpec.Frozen = true;
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
            this.ColumnSurface.Width = 130;
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
            // ColumnSupplier
            // 
            this.ColumnSupplier.DataPropertyName = "Supplier";
            dataGridViewCellStyle1.NullValue = "未设置";
            this.ColumnSupplier.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnSupplier.HeaderText = "供应商";
            this.ColumnSupplier.Name = "ColumnSupplier";
            this.ColumnSupplier.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSupplier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnSupplier.Width = 80;
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
            // ColumnPrdSetCount
            // 
            this.ColumnPrdSetCount.DataPropertyName = "PrdSetCount";
            dataGridViewCellStyle2.NullValue = "0";
            this.ColumnPrdSetCount.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnPrdSetCount.HeaderText = "套料";
            this.ColumnPrdSetCount.Name = "ColumnPrdSetCount";
            this.ColumnPrdSetCount.Width = 54;
            // 
            // ColumnBuyer
            // 
            this.ColumnBuyer.DataPropertyName = "Buyer";
            dataGridViewCellStyle3.NullValue = "未设置";
            this.ColumnBuyer.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnBuyer.HeaderText = "采购员";
            this.ColumnBuyer.Name = "ColumnBuyer";
            this.ColumnBuyer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnBuyer.Width = 80;
            // 
            // ColumnFileCount
            // 
            this.ColumnFileCount.DataPropertyName = "FileCount";
            dataGridViewCellStyle4.NullValue = "0";
            this.ColumnFileCount.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnFileCount.HeaderText = "文件";
            this.ColumnFileCount.Name = "ColumnFileCount";
            this.ColumnFileCount.Width = 54;
            // 
            // ColumnImgCount
            // 
            this.ColumnImgCount.DataPropertyName = "ImgCount";
            dataGridViewCellStyle5.NullValue = "0";
            this.ColumnImgCount.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnImgCount.HeaderText = "图片";
            this.ColumnImgCount.Name = "ColumnImgCount";
            this.ColumnImgCount.Width = 54;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            // 
            // ColumnURL
            // 
            this.ColumnURL.DataPropertyName = "URL";
            this.ColumnURL.HeaderText = "网址";
            this.ColumnURL.Name = "ColumnURL";
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
            // ColumnPrdWeight
            // 
            this.ColumnPrdWeight.DataPropertyName = "PrdWeight";
            this.ColumnPrdWeight.HeaderText = "单重Kg";
            this.ColumnPrdWeight.Name = "ColumnPrdWeight";
            this.ColumnPrdWeight.Width = 66;
            // 
            // ColumnTaxfreeFlag
            // 
            this.ColumnTaxfreeFlag.DataPropertyName = "TaxfreeFlag";
            this.ColumnTaxfreeFlag.HeaderText = "保税料";
            this.ColumnTaxfreeFlag.Name = "ColumnTaxfreeFlag";
            this.ColumnTaxfreeFlag.Width = 66;
            // 
            // ColumnAssistantCode
            // 
            this.ColumnAssistantCode.DataPropertyName = "AssistantCode";
            this.ColumnAssistantCode.HeaderText = "助记码";
            this.ColumnAssistantCode.Name = "ColumnAssistantCode";
            this.ColumnAssistantCode.Width = 80;
            // 
            // ColumnDWGNo
            // 
            this.ColumnDWGNo.DataPropertyName = "DWGNo";
            this.ColumnDWGNo.HeaderText = "图号";
            this.ColumnDWGNo.Name = "ColumnDWGNo";
            this.ColumnDWGNo.Width = 80;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnImport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 568);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(809, 32);
            this.panel2.TabIndex = 5;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(607, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "输出Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(364, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(526, 6);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Excel导入";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // cMenu
            // 
            this.cMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemRefresh,
            this.mItemPrdType,
            this.mItemSupplier,
            this.mItemBuyer,
            this.mItemMaxPrdCode});
            this.cMenu.Name = "cMenu";
            this.cMenu.Size = new System.Drawing.Size(137, 114);
            // 
            // mItemRefresh
            // 
            this.mItemRefresh.Name = "mItemRefresh";
            this.mItemRefresh.Size = new System.Drawing.Size(136, 22);
            this.mItemRefresh.Text = "刷新";
            // 
            // mItemPrdType
            // 
            this.mItemPrdType.Name = "mItemPrdType";
            this.mItemPrdType.Size = new System.Drawing.Size(136, 22);
            this.mItemPrdType.Text = "变更类型";
            // 
            // mItemSupplier
            // 
            this.mItemSupplier.Name = "mItemSupplier";
            this.mItemSupplier.Size = new System.Drawing.Size(136, 22);
            this.mItemSupplier.Text = "设置供应商";
            // 
            // mItemBuyer
            // 
            this.mItemBuyer.Name = "mItemBuyer";
            this.mItemBuyer.Size = new System.Drawing.Size(136, 22);
            this.mItemBuyer.Text = "设置采购";
            // 
            // mItemMaxPrdCode
            // 
            this.mItemMaxPrdCode.Name = "mItemMaxPrdCode";
            this.mItemMaxPrdCode.Size = new System.Drawing.Size(136, 22);
            this.mItemMaxPrdCode.Text = "最大编码";
            // 
            // ctrlPrdTypeID
            // 
            this.ctrlPrdTypeID.AutoSize = true;
            this.ctrlPrdTypeID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPrdTypeID.Location = new System.Drawing.Point(0, 0);
            this.ctrlPrdTypeID.Name = "ctrlPrdTypeID";
            this.ctrlPrdTypeID.Size = new System.Drawing.Size(167, 600);
            this.ctrlPrdTypeID.TabIndex = 2;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(3, 8);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(331, 21);
            this.ctrlQFind.TabIndex = 5;
            // 
            // FrmPrdDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 600);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmPrdDefine";
            this.Text = "产品定义";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemPrdType;
        private System.Windows.Forms.ToolStripMenuItem mItemSupplier;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.ToolStripMenuItem mItemBuyer;
        private System.Windows.Forms.ToolStripMenuItem mItemMaxPrdCode;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSurface;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnManufacturer;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnUnitID;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnSupplier;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnSaleFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMinPackingQty;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnPrdSetCount;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnBuyer;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnFileCount;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnImgCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnURL;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnRohsFlag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnRohsRequireFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdWeight;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnTaxfreeFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAssistantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDWGNo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnImport;
        private JERPApp.Define.Product.CtrlPrdTypeTree ctrlPrdTypeID;
        private JCommon.CtrlGridFind ctrlQFind;
    }
}