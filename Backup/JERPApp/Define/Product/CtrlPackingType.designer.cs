namespace JERPApp.Define.Product
{
    partial class CtrlPackingType
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgrdv = new JCommon.MyDataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rchDescription = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ctrlFileBrowse = new JCommon.CtrlFileBrowse();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPackageAssembly = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdAssembly = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRecycleFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnSourceTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(824, 310);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgrdv);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(816, 284);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "物料";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dgrdv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.ColumnHeadersHeight = 42;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnPackageAssembly,
            this.ColumnPrdAssembly,
            this.ColumnMemo,
            this.ColumnPosition,
            this.ColumnSupplier,
            this.ColumnRecycleFlag,
            this.ColumnSourceTypeName,
            this.ColumnUnitName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(165)))), ((int)(((byte)(198)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(3, 3);
            this.dgrdv.Name = "dgrdv";
            this.dgrdv.ReadOnly = true;
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
            this.dgrdv.Size = new System.Drawing.Size(810, 278);
            this.dgrdv.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rchDescription);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(816, 284);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "说明";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rchDescription
            // 
            this.rchDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchDescription.Location = new System.Drawing.Point(3, 3);
            this.rchDescription.Name = "rchDescription";
            this.rchDescription.ReadOnly = true;
            this.rchDescription.Size = new System.Drawing.Size(810, 278);
            this.rchDescription.TabIndex = 5;
            this.rchDescription.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ctrlFileBrowse);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(816, 284);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "文件";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ctrlFileBrowse
            // 
            this.ctrlFileBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlFileBrowse.Location = new System.Drawing.Point(3, 3);
            this.ctrlFileBrowse.Name = "ctrlFileBrowse";
            this.ctrlFileBrowse.ReadOnly = false;
            this.ctrlFileBrowse.Size = new System.Drawing.Size(810, 278);
            this.ctrlFileBrowse.TabIndex = 4;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.HeaderText = "包材编码";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.ReadOnly = true;
            this.ColumnPrdCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            // ColumnPackageAssembly
            // 
            this.ColumnPackageAssembly.DataPropertyName = "PackageAssembly";
            this.ColumnPackageAssembly.HeaderText = "包材";
            this.ColumnPackageAssembly.Name = "ColumnPackageAssembly";
            this.ColumnPackageAssembly.ReadOnly = true;
            this.ColumnPackageAssembly.Width = 54;
            // 
            // ColumnPrdAssembly
            // 
            this.ColumnPrdAssembly.DataPropertyName = "PrdAssembly";
            this.ColumnPrdAssembly.HeaderText = "产品";
            this.ColumnPrdAssembly.Name = "ColumnPrdAssembly";
            this.ColumnPrdAssembly.ReadOnly = true;
            this.ColumnPrdAssembly.Width = 54;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.ReadOnly = true;
            // 
            // ColumnPosition
            // 
            this.ColumnPosition.DataPropertyName = "Position";
            this.ColumnPosition.HeaderText = "位置";
            this.ColumnPosition.Name = "ColumnPosition";
            this.ColumnPosition.ReadOnly = true;
            // 
            // ColumnSupplier
            // 
            this.ColumnSupplier.DataPropertyName = "Supplier";
            this.ColumnSupplier.HeaderText = "供应商";
            this.ColumnSupplier.Name = "ColumnSupplier";
            this.ColumnSupplier.ReadOnly = true;
            this.ColumnSupplier.Width = 66;
            // 
            // ColumnRecycleFlag
            // 
            this.ColumnRecycleFlag.DataPropertyName = "RecycleFlag";
            this.ColumnRecycleFlag.HeaderText = "回收";
            this.ColumnRecycleFlag.Name = "ColumnRecycleFlag";
            this.ColumnRecycleFlag.ReadOnly = true;
            this.ColumnRecycleFlag.Width = 54;
            // 
            // ColumnSourceTypeName
            // 
            this.ColumnSourceTypeName.DataPropertyName = "SourceTypeName";
            this.ColumnSourceTypeName.HeaderText = "来源";
            this.ColumnSourceTypeName.Name = "ColumnSourceTypeName";
            this.ColumnSourceTypeName.ReadOnly = true;
            this.ColumnSourceTypeName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSourceTypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnSourceTypeName.Width = 66;
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
            // CtrlPackingType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "CtrlPackingType";
            this.Size = new System.Drawing.Size(824, 310);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox rchDescription;
        private System.Windows.Forms.TabPage tabPage3;
        private JCommon.CtrlFileBrowse ctrlFileBrowse;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPackageAssembly;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdAssembly;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSupplier;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnRecycleFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSourceTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName;

    }
}
