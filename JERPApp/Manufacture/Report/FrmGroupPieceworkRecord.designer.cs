namespace JERPApp.Manufacture.Report
{
    partial class FrmGroupPieceworkRecord
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlProcessTypeID = new JERPApp.Define.Manufacture.CtrlProcessType();
            this.ckbProcessTypeFlag = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ckbPrdID = new System.Windows.Forms.CheckBox();
            this.ckbPsnID = new System.Windows.Forms.CheckBox();
            this.ctrlPrdID = new JERPApp.Define.Product.CtrlProduct();
            this.ctrlPsnID = new JERPApp.Define.Hr.CtrlPersonnel();
            this.ctrlBetweenDate = new JCommon.CtrlBetweenDate();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnDateManuf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProcessTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBadQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPriceQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPriceUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLaborPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLaborWage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPsnInfor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlProcessTypeID);
            this.panel1.Controls.Add(this.ckbProcessTypeFlag);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.ckbPrdID);
            this.panel1.Controls.Add(this.ckbPsnID);
            this.panel1.Controls.Add(this.ctrlPrdID);
            this.panel1.Controls.Add(this.ctrlPsnID);
            this.panel1.Controls.Add(this.ctrlBetweenDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 92);
            this.panel1.TabIndex = 3;
            // 
            // ctrlProcessTypeID
            // 
            this.ctrlProcessTypeID.Location = new System.Drawing.Point(611, 27);
            this.ctrlProcessTypeID.Name = "ctrlProcessTypeID";
            this.ctrlProcessTypeID.ProcessTypeID = 1;
            this.ctrlProcessTypeID.Size = new System.Drawing.Size(125, 23);
            this.ctrlProcessTypeID.TabIndex = 9;
            // 
            // ckbProcessTypeFlag
            // 
            this.ckbProcessTypeFlag.AutoSize = true;
            this.ckbProcessTypeFlag.Location = new System.Drawing.Point(557, 34);
            this.ckbProcessTypeFlag.Name = "ckbProcessTypeFlag";
            this.ckbProcessTypeFlag.Size = new System.Drawing.Size(48, 16);
            this.ckbProcessTypeFlag.TabIndex = 8;
            this.ckbProcessTypeFlag.Text = "工序";
            this.ckbProcessTypeFlag.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(661, 66);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // ckbPrdID
            // 
            this.ckbPrdID.AutoSize = true;
            this.ckbPrdID.Location = new System.Drawing.Point(8, 71);
            this.ckbPrdID.Name = "ckbPrdID";
            this.ckbPrdID.Size = new System.Drawing.Size(15, 14);
            this.ckbPrdID.TabIndex = 6;
            this.ckbPrdID.UseVisualStyleBackColor = true;
            // 
            // ckbPsnID
            // 
            this.ckbPsnID.AutoSize = true;
            this.ckbPsnID.Location = new System.Drawing.Point(342, 36);
            this.ckbPsnID.Name = "ckbPsnID";
            this.ckbPsnID.Size = new System.Drawing.Size(48, 16);
            this.ckbPsnID.TabIndex = 5;
            this.ckbPsnID.Text = "员工";
            this.ckbPsnID.UseVisualStyleBackColor = true;
            // 
            // ctrlPrdID
            // 
            this.ctrlPrdID.AutoSize = true;
            this.ctrlPrdID.Location = new System.Drawing.Point(24, 61);
            this.ctrlPrdID.Name = "ctrlPrdID";
            this.ctrlPrdID.PrdID = -1;
            this.ctrlPrdID.Size = new System.Drawing.Size(631, 29);
            this.ctrlPrdID.TabIndex = 4;
            // 
            // ctrlPsnID
            // 
            this.ctrlPsnID.AutoSize = true;
            this.ctrlPsnID.Location = new System.Drawing.Point(396, 30);
            this.ctrlPsnID.Name = "ctrlPsnID";
            this.ctrlPsnID.PsnID = -1;
            this.ctrlPsnID.Size = new System.Drawing.Size(155, 23);
            this.ctrlPsnID.TabIndex = 2;
            // 
            // ctrlBetweenDate
            // 
            this.ctrlBetweenDate.DateBegin = new System.DateTime(2015, 1, 19, 0, 0, 0, 0);
            this.ctrlBetweenDate.DateEnd = new System.DateTime(2015, 1, 19, 0, 0, 0, 0);
            this.ctrlBetweenDate.Location = new System.Drawing.Point(12, 30);
            this.ctrlBetweenDate.Name = "ctrlBetweenDate";
            this.ctrlBetweenDate.Size = new System.Drawing.Size(323, 29);
            this.ctrlBetweenDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(410, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "集体计件检索";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 560);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(934, 29);
            this.panel2.TabIndex = 4;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(274, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "输出excel";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(3, 3);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(244, 21);
            this.ctrlQFind.TabIndex = 0;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDateManuf,
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnProcessTypeName,
            this.ColumnQuantity,
            this.ColumnBadQty,
            this.ColumnUnitName,
            this.ColumnPriceQty,
            this.ColumnPriceUnitName,
            this.ColumnLaborPrice,
            this.ColumnLaborWage,
            this.ColumnPsnInfor});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 92);
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
            this.dgrdv.Size = new System.Drawing.Size(934, 468);
            this.dgrdv.TabIndex = 9;
            // 
            // ColumnDateManuf
            // 
            this.ColumnDateManuf.DataPropertyName = "DateManuf";
            this.ColumnDateManuf.HeaderText = "日期";
            this.ColumnDateManuf.Name = "ColumnDateManuf";
            this.ColumnDateManuf.ReadOnly = true;
            this.ColumnDateManuf.Width = 80;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.HeaderText = "产品编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.ReadOnly = true;
            this.ColumnPrdCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnPrdCode.Width = 80;
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.HeaderText = "产品名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            this.ColumnPrdName.ReadOnly = true;
            this.ColumnPrdName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnPrdName.Width = 80;
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            this.ColumnPrdSpec.HeaderText = "产品规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            this.ColumnPrdSpec.ReadOnly = true;
            this.ColumnPrdSpec.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdSpec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnPrdSpec.Width = 80;
            // 
            // ColumnModel
            // 
            this.ColumnModel.DataPropertyName = "Model";
            this.ColumnModel.HeaderText = "机型";
            this.ColumnModel.Name = "ColumnModel";
            this.ColumnModel.ReadOnly = true;
            this.ColumnModel.Width = 66;
            // 
            // ColumnProcessTypeName
            // 
            this.ColumnProcessTypeName.DataPropertyName = "ProcessTypeName";
            this.ColumnProcessTypeName.HeaderText = "工序";
            this.ColumnProcessTypeName.Name = "ColumnProcessTypeName";
            this.ColumnProcessTypeName.ReadOnly = true;
            this.ColumnProcessTypeName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnProcessTypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnProcessTypeName.Width = 80;
            // 
            // ColumnQuantity
            // 
            this.ColumnQuantity.DataPropertyName = "Quantity";
            this.ColumnQuantity.HeaderText = "良品数";
            this.ColumnQuantity.Name = "ColumnQuantity";
            this.ColumnQuantity.ReadOnly = true;
            this.ColumnQuantity.Width = 66;
            // 
            // ColumnBadQty
            // 
            this.ColumnBadQty.DataPropertyName = "BadQty";
            this.ColumnBadQty.HeaderText = "不良数";
            this.ColumnBadQty.Name = "ColumnBadQty";
            this.ColumnBadQty.ReadOnly = true;
            this.ColumnBadQty.Width = 66;
            // 
            // ColumnUnitName
            // 
            this.ColumnUnitName.DataPropertyName = "UnitName";
            this.ColumnUnitName.HeaderText = "单位";
            this.ColumnUnitName.Name = "ColumnUnitName";
            this.ColumnUnitName.ReadOnly = true;
            this.ColumnUnitName.Width = 54;
            // 
            // ColumnPriceQty
            // 
            this.ColumnPriceQty.DataPropertyName = "PriceQty";
            this.ColumnPriceQty.HeaderText = "计价数";
            this.ColumnPriceQty.Name = "ColumnPriceQty";
            this.ColumnPriceQty.ReadOnly = true;
            this.ColumnPriceQty.Width = 66;
            // 
            // ColumnPriceUnitName
            // 
            this.ColumnPriceUnitName.DataPropertyName = "PriceUnitName";
            this.ColumnPriceUnitName.HeaderText = "计价单位";
            this.ColumnPriceUnitName.Name = "ColumnPriceUnitName";
            this.ColumnPriceUnitName.ReadOnly = true;
            this.ColumnPriceUnitName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPriceUnitName.Width = 80;
            // 
            // ColumnLaborPrice
            // 
            this.ColumnLaborPrice.DataPropertyName = "LaborPrice";
            this.ColumnLaborPrice.HeaderText = "计件价";
            this.ColumnLaborPrice.Name = "ColumnLaborPrice";
            this.ColumnLaborPrice.ReadOnly = true;
            this.ColumnLaborPrice.Width = 66;
            // 
            // ColumnLaborWage
            // 
            this.ColumnLaborWage.DataPropertyName = "LaborWage";
            this.ColumnLaborWage.HeaderText = "工资";
            this.ColumnLaborWage.Name = "ColumnLaborWage";
            this.ColumnLaborWage.ReadOnly = true;
            this.ColumnLaborWage.Width = 66;
            // 
            // ColumnPsnInfor
            // 
            this.ColumnPsnInfor.DataPropertyName = "PsnInfor";
            this.ColumnPsnInfor.HeaderText = "作业人员";
            this.ColumnPsnInfor.Name = "ColumnPsnInfor";
            this.ColumnPsnInfor.ReadOnly = true;
            // 
            // FrmGroupPieceworkRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 589);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmGroupPieceworkRecord";
            this.Text = "FrmGroupPieceworkRecord";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox ckbPrdID;
        private System.Windows.Forms.CheckBox ckbPsnID;
        private JERPApp.Define.Product.CtrlProduct ctrlPrdID;
        private JERPApp.Define.Hr.CtrlPersonnel ctrlPsnID;
        private JCommon.CtrlBetweenDate ctrlBetweenDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private System.Windows.Forms.Button btnExport;
        private JCommon.MyDataGridView dgrdv;
        private JERPApp.Define.Manufacture.CtrlProcessType ctrlProcessTypeID;
        private System.Windows.Forms.CheckBox ckbProcessTypeFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateManuf;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProcessTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBadQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPriceQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPriceUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLaborPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLaborWage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPsnInfor;
    }
}