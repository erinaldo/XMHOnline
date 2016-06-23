namespace JERPApp.Engineer
{
    partial class FrmBOMClone
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlPrdID = new JERPApp.Define.Product.CtrlProduct();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.ctrlManufProcessID = new JERPApp.Define.Manufacture.CtrlManufProcess();
            this.label1 = new System.Windows.Forms.Label();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAssemblyQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLossRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSourceTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnElement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPostProcessing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubstitute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTechnology = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFixedFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlPrdID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ctrlManufProcessID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(652, 61);
            this.panel1.TabIndex = 0;
            // 
            // ctrlPrdID
            // 
            this.ctrlPrdID.AutoSize = true;
            this.ctrlPrdID.Location = new System.Drawing.Point(3, 3);
            this.ctrlPrdID.Name = "ctrlPrdID";
            this.ctrlPrdID.PrdID = -1;
            this.ctrlPrdID.Size = new System.Drawing.Size(631, 29);
            this.ctrlPrdID.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Controls.Add(this.btnImport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 461);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(652, 31);
            this.panel2.TabIndex = 1;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(305, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // ctrlManufProcessID
            // 
            this.ctrlManufProcessID.Location = new System.Drawing.Point(38, 35);
            this.ctrlManufProcessID.ManufProcessID = ((long)(-1));
            this.ctrlManufProcessID.Name = "ctrlManufProcessID";
            this.ctrlManufProcessID.Size = new System.Drawing.Size(155, 23);
            this.ctrlManufProcessID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(3, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 90;
            this.label1.Text = "工序";
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnManufacturer,
            this.ColumnAssemblyQty,
            this.ColumnLossRate,
            this.ColumnSourceTypeName,
            this.ColumnElement,
            this.ColumnMemo,
            this.ColumnPostProcessing,
            this.ColumnSubstitute,
            this.ColumnTechnology,
            this.ColumnUnitName,
            this.ColumnFixedFlag});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 61);
            this.dgrdv.Name = "dgrdv";
            this.dgrdv.ReadOnly = true;
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
            this.dgrdv.Size = new System.Drawing.Size(652, 400);
            this.dgrdv.TabIndex = 25;
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
            this.ColumnPrdSpec.Width = 120;
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
            // ColumnManufacturer
            // 
            this.ColumnManufacturer.DataPropertyName = "Manufacturer";
            this.ColumnManufacturer.HeaderText = "品牌";
            this.ColumnManufacturer.Name = "ColumnManufacturer";
            this.ColumnManufacturer.ReadOnly = true;
            this.ColumnManufacturer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnManufacturer.Width = 66;
            // 
            // ColumnAssemblyQty
            // 
            this.ColumnAssemblyQty.DataPropertyName = "AssemblyQty";
            this.ColumnAssemblyQty.HeaderText = "用量";
            this.ColumnAssemblyQty.Name = "ColumnAssemblyQty";
            this.ColumnAssemblyQty.ReadOnly = true;
            this.ColumnAssemblyQty.Width = 54;
            // 
            // ColumnLossRate
            // 
            this.ColumnLossRate.DataPropertyName = "LossRate";
            dataGridViewCellStyle3.Format = "0.####%";
            this.ColumnLossRate.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnLossRate.HeaderText = "损耗";
            this.ColumnLossRate.Name = "ColumnLossRate";
            this.ColumnLossRate.ReadOnly = true;
            this.ColumnLossRate.Width = 54;
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
            // ColumnFixedFlag
            // 
            this.ColumnFixedFlag.DataPropertyName = "FixedFlag";
            this.ColumnFixedFlag.HeaderText = "固定";
            this.ColumnFixedFlag.Name = "ColumnFixedFlag";
            this.ColumnFixedFlag.ReadOnly = true;
            this.ColumnFixedFlag.Width = 54;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(12, 3);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(287, 21);
            this.ctrlQFind.TabIndex = 3;
            // 
            // FrmPrdBOMClone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 492);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmPrdBOMClone";
            this.Text = "物料克隆";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private JERPApp.Define.Product.CtrlProduct ctrlPrdID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private JERPApp.Define.Manufacture.CtrlManufProcess ctrlManufProcessID;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Button btnImport;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAssemblyQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLossRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSourceTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnElement;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPostProcessing;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSubstitute;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTechnology;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnFixedFlag;
    }
}