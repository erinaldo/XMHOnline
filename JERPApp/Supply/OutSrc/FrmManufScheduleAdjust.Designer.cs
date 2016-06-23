namespace JERPApp.Supply.OutSrc
{
    partial class FrmManufScheduleAdjust
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ctrlSupplierID = new JERPApp.Define.General.CtrlSupplierForOutSrc();
            this.ckbSupplier = new System.Windows.Forms.CheckBox();
            this.txtWorkingSheetCode = new System.Windows.Forms.TextBox();
            this.ckbWorkingSheetCode = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbar = new JCommon.PagebreakNav();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnOutSrcSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWorkingSheetCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutSrcOrderQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutSrcOrderFinishedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutSrcOrderNonFinishedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.ctrlSupplierID);
            this.panel1.Controls.Add(this.ckbSupplier);
            this.panel1.Controls.Add(this.txtWorkingSheetCode);
            this.panel1.Controls.Add(this.ckbWorkingSheetCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(945, 60);
            this.panel1.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(447, 31);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // ctrlSupplierID
            // 
            this.ctrlSupplierID.CompanyID = 153;
            this.ctrlSupplierID.Location = new System.Drawing.Point(297, 34);
            this.ctrlSupplierID.Name = "ctrlSupplierID";
            this.ctrlSupplierID.Size = new System.Drawing.Size(143, 23);
            this.ctrlSupplierID.TabIndex = 6;
            // 
            // ckbSupplier
            // 
            this.ckbSupplier.AutoSize = true;
            this.ckbSupplier.Location = new System.Drawing.Point(230, 39);
            this.ckbSupplier.Name = "ckbSupplier";
            this.ckbSupplier.Size = new System.Drawing.Size(60, 16);
            this.ckbSupplier.TabIndex = 5;
            this.ckbSupplier.Text = "供应商";
            this.ckbSupplier.UseVisualStyleBackColor = true;
            // 
            // txtWorkingSheetCode
            // 
            this.txtWorkingSheetCode.Location = new System.Drawing.Point(84, 34);
            this.txtWorkingSheetCode.Name = "txtWorkingSheetCode";
            this.txtWorkingSheetCode.Size = new System.Drawing.Size(135, 21);
            this.txtWorkingSheetCode.TabIndex = 4;
            // 
            // ckbWorkingSheetCode
            // 
            this.ckbWorkingSheetCode.AutoSize = true;
            this.ckbWorkingSheetCode.Location = new System.Drawing.Point(10, 39);
            this.ckbWorkingSheetCode.Name = "ckbWorkingSheetCode";
            this.ckbWorkingSheetCode.Size = new System.Drawing.Size(72, 16);
            this.ckbWorkingSheetCode.TabIndex = 3;
            this.ckbWorkingSheetCode.Text = "生产批号";
            this.ckbWorkingSheetCode.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(444, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "委外计划余数调整";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pbar);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 485);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(945, 27);
            this.panel2.TabIndex = 3;
            // 
            // pbar
            // 
            this.pbar.AutoSize = true;
            this.pbar.Location = new System.Drawing.Point(0, 1);
            this.pbar.Name = "pbar";
            this.pbar.PageInBlock = 10;
            this.pbar.PageIndex = 1;
            this.pbar.PageSize = 50;
            this.pbar.Size = new System.Drawing.Size(406, 27);
            this.pbar.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(806, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "变更保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnOutSrcSupplier,
            this.ColumnWorkingSheetCode,
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnPrdStatus,
            this.ColumnQuantity,
            this.ColumnOutSrcOrderQty,
            this.ColumnOutSrcOrderFinishedQty,
            this.ColumnOutSrcOrderNonFinishedQty,
            this.ColumnUnitName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 60);
            this.dgrdv.Name = "dgrdv";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(945, 425);
            this.dgrdv.TabIndex = 4;
            // 
            // ColumnOutSrcSupplier
            // 
            this.ColumnOutSrcSupplier.DataPropertyName = "OutSrcSupplier";
            this.ColumnOutSrcSupplier.HeaderText = "委外商";
            this.ColumnOutSrcSupplier.Name = "ColumnOutSrcSupplier";
            this.ColumnOutSrcSupplier.Width = 66;
            // 
            // ColumnWorkingSheetCode
            // 
            this.ColumnWorkingSheetCode.DataPropertyName = "WorkingSheetCode";
            this.ColumnWorkingSheetCode.HeaderText = "生产批号";
            this.ColumnWorkingSheetCode.Name = "ColumnWorkingSheetCode";
            this.ColumnWorkingSheetCode.Width = 80;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.HeaderText = "产品编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
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
            this.ColumnPrdSpec.HeaderText = "产品规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            this.ColumnPrdSpec.Width = 120;
            // 
            // ColumnModel
            // 
            this.ColumnModel.DataPropertyName = "Model";
            this.ColumnModel.HeaderText = "机型";
            this.ColumnModel.Name = "ColumnModel";
            this.ColumnModel.Width = 66;
            // 
            // ColumnPrdStatus
            // 
            this.ColumnPrdStatus.DataPropertyName = "PrdStatus";
            this.ColumnPrdStatus.HeaderText = "工序";
            this.ColumnPrdStatus.Name = "ColumnPrdStatus";
            this.ColumnPrdStatus.Width = 66;
            // 
            // ColumnQuantity
            // 
            this.ColumnQuantity.DataPropertyName = "Quantity";
            this.ColumnQuantity.HeaderText = "生产计划";
            this.ColumnQuantity.Name = "ColumnQuantity";
            this.ColumnQuantity.Width = 80;
            // 
            // ColumnOutSrcOrderQty
            // 
            this.ColumnOutSrcOrderQty.DataPropertyName = "OutSrcOrderQty";
            this.ColumnOutSrcOrderQty.HeaderText = "需下单";
            this.ColumnOutSrcOrderQty.Name = "ColumnOutSrcOrderQty";
            this.ColumnOutSrcOrderQty.Width = 66;
            // 
            // ColumnOutSrcOrderFinishedQty
            // 
            this.ColumnOutSrcOrderFinishedQty.DataPropertyName = "OutSrcOrderFinishedQty";
            this.ColumnOutSrcOrderFinishedQty.HeaderText = "已完成";
            this.ColumnOutSrcOrderFinishedQty.Name = "ColumnOutSrcOrderFinishedQty";
            this.ColumnOutSrcOrderFinishedQty.Width = 66;
            // 
            // ColumnOutSrcOrderNonFinishedQty
            // 
            this.ColumnOutSrcOrderNonFinishedQty.DataPropertyName = "OutSrcOrderNonFinishedQty";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            this.ColumnOutSrcOrderNonFinishedQty.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnOutSrcOrderNonFinishedQty.HeaderText = "未下单";
            this.ColumnOutSrcOrderNonFinishedQty.Name = "ColumnOutSrcOrderNonFinishedQty";
            this.ColumnOutSrcOrderNonFinishedQty.Width = 66;
            // 
            // ColumnUnitName
            // 
            this.ColumnUnitName.DataPropertyName = "UnitName";
            this.ColumnUnitName.HeaderText = "单位";
            this.ColumnUnitName.Name = "ColumnUnitName";
            this.ColumnUnitName.Width = 54;
            // 
            // FrmManufScheduleAdjust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 512);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmManufScheduleAdjust";
            this.Text = "FrmManufScheduleAdjust";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ckbWorkingSheetCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckbSupplier;
        private System.Windows.Forms.TextBox txtWorkingSheetCode;
        private System.Windows.Forms.Button btnSearch;
        private JERPApp.Define.General.CtrlSupplierForOutSrc ctrlSupplierID;
        private System.Windows.Forms.Panel panel2;
        private JCommon.MyDataGridView dgrdv;
        private JCommon.PagebreakNav pbar;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutSrcSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWorkingSheetCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutSrcOrderQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutSrcOrderFinishedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutSrcOrderNonFinishedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName;
    }
}