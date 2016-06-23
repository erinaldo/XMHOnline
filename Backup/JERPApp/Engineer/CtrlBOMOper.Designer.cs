namespace JERPApp.Engineer
{
    partial class CtrlBOMOper
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlBOMOper));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClone = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnMark = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAssemblyQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLossRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSourceTypeID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnElement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPostProcessing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubstitute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTechnology = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFixedFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnParentFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnPrdID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rchMemo = new System.Windows.Forms.RichTextBox();
            this.lnkMemo = new System.Windows.Forms.LinkLabel();
            this.lnkFileCount = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMouldCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ctrlSupplierID = new JERPApp.Define.General.CtrlSupplierForOutSrc();
            this.label4 = new System.Windows.Forms.Label();
            this.ckbOutSrcFlag = new System.Windows.Forms.CheckBox();
            this.ctrlProcessTypeID = new JERPApp.Define.Manufacture.CtrlProcessType();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnClone);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.ctrlQFind);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 556);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(973, 28);
            this.panel1.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(722, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 34;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnClone
            // 
            this.btnClone.Location = new System.Drawing.Point(465, 2);
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(75, 23);
            this.btnClone.TabIndex = 33;
            this.btnClone.Text = "+克隆";
            this.btnClone.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(557, 3);
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
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(254, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(89, 23);
            this.btnImport.TabIndex = 25;
            this.btnImport.Text = "Excel导入";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMark,
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnManufacturer,
            this.ColumnAssemblyQty,
            this.ColumnLossRate,
            this.ColumnSourceTypeID,
            this.ColumnElement,
            this.ColumnMemo,
            this.ColumnPostProcessing,
            this.ColumnSubstitute,
            this.ColumnTechnology,
            this.ColumnUnitName,
            this.ColumnFixedFlag,
            this.ColumnParentFlag,
            this.ColumnPrdID});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 35);
            this.dgrdv.Name = "dgrdv";
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
            this.dgrdv.Size = new System.Drawing.Size(973, 521);
            this.dgrdv.TabIndex = 24;
            // 
            // ColumnMark
            // 
            this.ColumnMark.DataPropertyName = "Mark";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 14F);
            dataGridViewCellStyle1.NullValue = " global::JERPApp.Properties.Resources.empty";
            this.ColumnMark.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnMark.Frozen = true;
            this.ColumnMark.HeaderText = "±";
            this.ColumnMark.Name = "ColumnMark";
            this.ColumnMark.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnMark.Width = 25;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnPrdCode.Frozen = true;
            this.ColumnPrdCode.HeaderText = "物料编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.ReadOnly = true;
            this.ColumnPrdCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.Frozen = true;
            this.ColumnPrdName.HeaderText = "物料名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            this.ColumnPrdName.ReadOnly = true;
            this.ColumnPrdName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdName.Width = 80;
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdSpec.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnPrdSpec.Frozen = true;
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
            this.ColumnAssemblyQty.Width = 54;
            // 
            // ColumnLossRate
            // 
            this.ColumnLossRate.DataPropertyName = "LossRate";
            dataGridViewCellStyle4.Format = "0.####%";
            this.ColumnLossRate.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnLossRate.HeaderText = "损耗";
            this.ColumnLossRate.Name = "ColumnLossRate";
            this.ColumnLossRate.Width = 54;
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
            // ColumnElement
            // 
            this.ColumnElement.DataPropertyName = "Element";
            this.ColumnElement.HeaderText = "位置";
            this.ColumnElement.Name = "ColumnElement";
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.Width = 80;
            // 
            // ColumnPostProcessing
            // 
            this.ColumnPostProcessing.DataPropertyName = "PostProcessing";
            this.ColumnPostProcessing.HeaderText = "后处理方式";
            this.ColumnPostProcessing.Name = "ColumnPostProcessing";
            this.ColumnPostProcessing.Width = 90;
            // 
            // ColumnSubstitute
            // 
            this.ColumnSubstitute.DataPropertyName = "Substitute";
            this.ColumnSubstitute.HeaderText = "替代料";
            this.ColumnSubstitute.Name = "ColumnSubstitute";
            // 
            // ColumnTechnology
            // 
            this.ColumnTechnology.DataPropertyName = "Technology";
            this.ColumnTechnology.HeaderText = "工艺要求";
            this.ColumnTechnology.Name = "ColumnTechnology";
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
            this.ColumnFixedFlag.Width = 54;
            // 
            // ColumnParentFlag
            // 
            this.ColumnParentFlag.DataPropertyName = "ParentFlag";
            this.ColumnParentFlag.HeaderText = "ParentFlag";
            this.ColumnParentFlag.Name = "ColumnParentFlag";
            this.ColumnParentFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnParentFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnParentFlag.Visible = false;
            this.ColumnParentFlag.Width = 54;
            // 
            // ColumnPrdID
            // 
            this.ColumnPrdID.DataPropertyName = "PrdID";
            this.ColumnPrdID.HeaderText = "PrdID";
            this.ColumnPrdID.Name = "ColumnPrdID";
            this.ColumnPrdID.Visible = false;
            // 
            // dataGridViewImageColumn1
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 14F);
            dataGridViewCellStyle8.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle8.NullValue")));
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewImageColumn1.HeaderText = "±";
            this.dataGridViewImageColumn1.Image = global::JERPApp.Properties.Resources.subtract;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 25;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rchMemo);
            this.panel2.Controls.Add(this.lnkMemo);
            this.panel2.Controls.Add(this.lnkFileCount);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtMouldCode);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.ctrlSupplierID);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.ckbOutSrcFlag);
            this.panel2.Controls.Add(this.ctrlProcessTypeID);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtSerialNo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(973, 35);
            this.panel2.TabIndex = 25;
            // 
            // rchMemo
            // 
            this.rchMemo.Location = new System.Drawing.Point(612, 2);
            this.rchMemo.Name = "rchMemo";
            this.rchMemo.Size = new System.Drawing.Size(189, 28);
            this.rchMemo.TabIndex = 11;
            this.rchMemo.Text = "";
            // 
            // lnkMemo
            // 
            this.lnkMemo.Location = new System.Drawing.Point(579, 4);
            this.lnkMemo.Name = "lnkMemo";
            this.lnkMemo.Size = new System.Drawing.Size(40, 28);
            this.lnkMemo.TabIndex = 16;
            this.lnkMemo.TabStop = true;
            this.lnkMemo.Text = "参数说明";
            // 
            // lnkFileCount
            // 
            this.lnkFileCount.AutoSize = true;
            this.lnkFileCount.Location = new System.Drawing.Point(559, 8);
            this.lnkFileCount.Name = "lnkFileCount";
            this.lnkFileCount.Size = new System.Drawing.Size(11, 12);
            this.lnkFileCount.TabIndex = 15;
            this.lnkFileCount.TabStop = true;
            this.lnkFileCount.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(523, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "文件";
            // 
            // txtMouldCode
            // 
            this.txtMouldCode.Location = new System.Drawing.Point(854, 4);
            this.txtMouldCode.Name = "txtMouldCode";
            this.txtMouldCode.Size = new System.Drawing.Size(112, 21);
            this.txtMouldCode.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(807, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "模具号";
            // 
            // ctrlSupplierID
            // 
            this.ctrlSupplierID.CompanyID = 2;
            this.ctrlSupplierID.Location = new System.Drawing.Point(384, 4);
            this.ctrlSupplierID.Name = "ctrlSupplierID";
            this.ctrlSupplierID.Size = new System.Drawing.Size(133, 23);
            this.ctrlSupplierID.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(337, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "委外商";
            // 
            // ckbOutSrcFlag
            // 
            this.ckbOutSrcFlag.AutoSize = true;
            this.ckbOutSrcFlag.Location = new System.Drawing.Point(283, 8);
            this.ckbOutSrcFlag.Name = "ckbOutSrcFlag";
            this.ckbOutSrcFlag.Size = new System.Drawing.Size(48, 16);
            this.ckbOutSrcFlag.TabIndex = 7;
            this.ckbOutSrcFlag.Text = "委外";
            this.ckbOutSrcFlag.UseVisualStyleBackColor = true;
            // 
            // ctrlProcessTypeID
            // 
            this.ctrlProcessTypeID.Location = new System.Drawing.Point(159, 4);
            this.ctrlProcessTypeID.Name = "ctrlProcessTypeID";
            this.ctrlProcessTypeID.ProcessTypeID = 1;
            this.ctrlProcessTypeID.Size = new System.Drawing.Size(121, 23);
            this.ctrlProcessTypeID.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "工序类型";
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Location = new System.Drawing.Point(40, 4);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(54, 21);
            this.txtSerialNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "序号";
            // 
            // CtrlBOMOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CtrlBOMOper";
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
        private System.Windows.Forms.Button btnImport;
        private JCommon.MyDataGridView dgrdv;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClone;
        private System.Windows.Forms.DataGridViewImageColumn ColumnMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAssemblyQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLossRate;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnSourceTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnElement;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPostProcessing;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSubstitute;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTechnology;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnFixedFlag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnParentFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdID;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private JERPApp.Define.Manufacture.CtrlProcessType ctrlProcessTypeID;
        private System.Windows.Forms.CheckBox ckbOutSrcFlag;
        private JERPApp.Define.General.CtrlSupplierForOutSrc ctrlSupplierID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rchMemo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMouldCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel lnkFileCount;
        private System.Windows.Forms.LinkLabel lnkMemo;
    }
}