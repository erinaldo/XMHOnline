namespace JERPApp.Engineer
{
    partial class FrmDGPrdDefine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgrdv = new JCommon.MyDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlQFind = new JCommon.CtrlGridFind();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemPrdType = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlPrdTypeID = new JERPApp.Define.Product.CtrlCommonTypeTree();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDPType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnCustomCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCustomFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnJMPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPFPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHYPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLSPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnImgCount = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnDWGNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAssistantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdCodeSrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.panel2.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrdv
            // 
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnDPType,
            this.ColumnCustomCode,
            this.ColumnCustomFlag,
            this.ColumnBrand,
            this.ColumnUnitID,
            this.ColumnJMPrice,
            this.ColumnPFPrice,
            this.ColumnHYPrice,
            this.ColumnLSPrice,
            this.ColumnImgCount,
            this.ColumnDWGNo,
            this.ColumnAssistantCode,
            this.ColumnPrdCodeSrc,
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
            this.dgrdv.Location = new System.Drawing.Point(176, 0);
            this.dgrdv.Name = "dgrdv";
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
            this.dgrdv.Size = new System.Drawing.Size(1018, 624);
            this.dgrdv.TabIndex = 1;
            this.dgrdv.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgrdv_DataError);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnImport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(176, 624);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1018, 35);
            this.panel2.TabIndex = 6;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(20, 8);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(296, 21);
            this.ctrlQFind.TabIndex = 5;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(692, 8);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "输出Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(408, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(582, 8);
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
            this.mItemPrdType});
            this.cMenu.Name = "cMenu";
            this.cMenu.Size = new System.Drawing.Size(125, 48);
            // 
            // mItemRefresh
            // 
            this.mItemRefresh.Name = "mItemRefresh";
            this.mItemRefresh.Size = new System.Drawing.Size(124, 22);
            this.mItemRefresh.Text = "刷新";
            // 
            // mItemPrdType
            // 
            this.mItemPrdType.Name = "mItemPrdType";
            this.mItemPrdType.Size = new System.Drawing.Size(124, 22);
            this.mItemPrdType.Text = "变更类型";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlPrdTypeID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 659);
            this.panel1.TabIndex = 14;
            // 
            // ctrlPrdTypeID
            // 
            this.ctrlPrdTypeID.AutoSize = true;
            this.ctrlPrdTypeID.Location = new System.Drawing.Point(3, 0);
            this.ctrlPrdTypeID.Name = "ctrlPrdTypeID";
            this.ctrlPrdTypeID.Size = new System.Drawing.Size(170, 659);
            this.ctrlPrdTypeID.TabIndex = 1;
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
            this.ColumnPrdSpec.HeaderText = "产品规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            // 
            // ColumnDPType
            // 
            this.ColumnDPType.DataPropertyName = "DPType";
            this.ColumnDPType.HeaderText = "刀片类别";
            this.ColumnDPType.Name = "ColumnDPType";
            this.ColumnDPType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnDPType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnCustomCode
            // 
            this.ColumnCustomCode.DataPropertyName = "CustomCode";
            this.ColumnCustomCode.HeaderText = "客户产品号";
            this.ColumnCustomCode.Name = "ColumnCustomCode";
            // 
            // ColumnCustomFlag
            // 
            this.ColumnCustomFlag.DataPropertyName = "CustomFlag";
            this.ColumnCustomFlag.HeaderText = "客户产品";
            this.ColumnCustomFlag.Name = "ColumnCustomFlag";
            this.ColumnCustomFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnCustomFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnCustomFlag.Width = 80;
            // 
            // ColumnBrand
            // 
            this.ColumnBrand.DataPropertyName = "Brand";
            this.ColumnBrand.HeaderText = "品牌";
            this.ColumnBrand.Name = "ColumnBrand";
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
            // ColumnJMPrice
            // 
            this.ColumnJMPrice.DataPropertyName = "JMPrice";
            this.ColumnJMPrice.HeaderText = "加盟单价";
            this.ColumnJMPrice.Name = "ColumnJMPrice";
            this.ColumnJMPrice.Width = 80;
            // 
            // ColumnPFPrice
            // 
            this.ColumnPFPrice.DataPropertyName = "PFPrice";
            this.ColumnPFPrice.HeaderText = "批发单价";
            this.ColumnPFPrice.Name = "ColumnPFPrice";
            this.ColumnPFPrice.Width = 80;
            // 
            // ColumnHYPrice
            // 
            this.ColumnHYPrice.DataPropertyName = "HYPrice";
            this.ColumnHYPrice.HeaderText = "会员单价";
            this.ColumnHYPrice.Name = "ColumnHYPrice";
            this.ColumnHYPrice.Width = 80;
            // 
            // ColumnLSPrice
            // 
            this.ColumnLSPrice.DataPropertyName = "LSPrice";
            this.ColumnLSPrice.HeaderText = "零售单价";
            this.ColumnLSPrice.Name = "ColumnLSPrice";
            this.ColumnLSPrice.Width = 80;
            // 
            // ColumnImgCount
            // 
            this.ColumnImgCount.DataPropertyName = "ImgCount";
            this.ColumnImgCount.HeaderText = "图片";
            this.ColumnImgCount.Name = "ColumnImgCount";
            this.ColumnImgCount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnImgCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnImgCount.Width = 60;
            // 
            // ColumnDWGNo
            // 
            this.ColumnDWGNo.DataPropertyName = "DWGNo";
            this.ColumnDWGNo.HeaderText = "图号";
            this.ColumnDWGNo.Name = "ColumnDWGNo";
            this.ColumnDWGNo.Width = 60;
            // 
            // ColumnAssistantCode
            // 
            this.ColumnAssistantCode.DataPropertyName = "AssistantCode";
            this.ColumnAssistantCode.HeaderText = "助记码";
            this.ColumnAssistantCode.Name = "ColumnAssistantCode";
            // 
            // ColumnPrdCodeSrc
            // 
            this.ColumnPrdCodeSrc.DataPropertyName = "PrdCodeSrc";
            this.ColumnPrdCodeSrc.HeaderText = "对应产品编号";
            this.ColumnPrdCodeSrc.Name = "ColumnPrdCodeSrc";
            this.ColumnPrdCodeSrc.Visible = false;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.Width = 180;
            // 
            // FrmDGPrdDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 659);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmDGPrdDefine";
            this.Text = "刀杠资料";
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.cMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Panel panel2;
        private JCommon.CtrlGridFind ctrlQFind;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.ToolStripMenuItem mItemPrdType;
        private System.Windows.Forms.Panel panel1;
        private JERPApp.Define.Product.CtrlCommonTypeTree ctrlPrdTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnDPType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCustomCode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCustomFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBrand;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnUnitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnJMPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPFPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHYPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLSPrice;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnImgCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDWGNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAssistantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCodeSrc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
    }
}