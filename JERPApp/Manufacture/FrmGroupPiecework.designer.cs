namespace JERPApp.Manufacture
{
    partial class FrmGroupPiecework
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
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDateManuf = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlShiftID = new JERPApp.Define.Manufacture.CtrlShift();
            this.label5 = new System.Windows.Forms.Label();
            this.ctrlWorkgroupID = new JERPApp.Define.Manufacture.CtrlWorkgroup();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddMorePsn = new System.Windows.Forms.Button();
            this.btnAddPsn = new System.Windows.Forms.Button();
            this.ctrlPsnID = new JERPApp.Define.Hr.CtrlPersonnel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnProcessTypeName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnAssistantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReworkFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBadQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnPriceQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPriceUnitName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnLaborPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLaborWage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddPrd = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpDateManuf);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1062, 37);
            this.panel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "生产日期";
            // 
            // dtpDateManuf
            // 
            this.dtpDateManuf.Location = new System.Drawing.Point(66, 9);
            this.dtpDateManuf.Name = "dtpDateManuf";
            this.dtpDateManuf.Size = new System.Drawing.Size(128, 21);
            this.dtpDateManuf.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(465, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "集体计件统计";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddPrd);
            this.panel2.Controls.Add(this.ctrlShiftID);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.ctrlWorkgroupID);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnAddMorePsn);
            this.panel2.Controls.Add(this.btnAddPsn);
            this.panel2.Controls.Add(this.ctrlPsnID);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 533);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1062, 31);
            this.panel2.TabIndex = 5;
            // 
            // ctrlShiftID
            // 
            this.ctrlShiftID.AutoSize = true;
            this.ctrlShiftID.Location = new System.Drawing.Point(530, 5);
            this.ctrlShiftID.Name = "ctrlShiftID";
            this.ctrlShiftID.ShiftID = 1;
            this.ctrlShiftID.Size = new System.Drawing.Size(77, 23);
            this.ctrlShiftID.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(494, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "班次";
            // 
            // ctrlWorkgroupID
            // 
            this.ctrlWorkgroupID.AutoSize = true;
            this.ctrlWorkgroupID.Location = new System.Drawing.Point(358, 5);
            this.ctrlWorkgroupID.Name = "ctrlWorkgroupID";
            this.ctrlWorkgroupID.Size = new System.Drawing.Size(130, 23);
            this.ctrlWorkgroupID.TabIndex = 11;
            this.ctrlWorkgroupID.WorkgroupID = -1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "区域";
            // 
            // btnAddMorePsn
            // 
            this.btnAddMorePsn.Location = new System.Drawing.Point(613, 3);
            this.btnAddMorePsn.Name = "btnAddMorePsn";
            this.btnAddMorePsn.Size = new System.Drawing.Size(75, 23);
            this.btnAddMorePsn.TabIndex = 9;
            this.btnAddMorePsn.Text = "+多人";
            this.btnAddMorePsn.UseVisualStyleBackColor = true;
            // 
            // btnAddPsn
            // 
            this.btnAddPsn.Location = new System.Drawing.Point(276, 5);
            this.btnAddPsn.Name = "btnAddPsn";
            this.btnAddPsn.Size = new System.Drawing.Size(41, 23);
            this.btnAddPsn.TabIndex = 7;
            this.btnAddPsn.Text = "+人";
            this.btnAddPsn.UseVisualStyleBackColor = true;
            // 
            // ctrlPsnID
            // 
            this.ctrlPsnID.AutoSize = true;
            this.ctrlPsnID.Location = new System.Drawing.Point(118, 5);
            this.ctrlPsnID.Name = "ctrlPsnID";
            this.ctrlPsnID.PsnID = -1;
            this.ctrlPsnID.Size = new System.Drawing.Size(138, 23);
            this.ctrlPsnID.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "人员";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(766, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // dgrdv
            // 
            this.dgrdv.ColumnHeadersHeight = 40;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnProcessTypeName,
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnAssistantCode,
            this.ColumnReworkFlag,
            this.ColumnQuantity,
            this.ColumnBadQty,
            this.ColumnUnitName,
            this.ColumnPriceQty,
            this.ColumnPriceUnitName,
            this.ColumnLaborPrice,
            this.ColumnLaborWage});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 37);
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
            this.dgrdv.Size = new System.Drawing.Size(1062, 496);
            this.dgrdv.TabIndex = 6;
            // 
            // ColumnProcessTypeName
            // 
            this.ColumnProcessTypeName.DataPropertyName = "ProcessTypeID";
            this.ColumnProcessTypeName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnProcessTypeName.HeaderText = "工序";
            this.ColumnProcessTypeName.Name = "ColumnProcessTypeName";
            this.ColumnProcessTypeName.Width = 80;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdID";
            this.ColumnPrdCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnPrdCode.HeaderText = "产品编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnPrdCode.Width = 80;
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdID";
            this.ColumnPrdName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnPrdName.HeaderText = "产品名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            this.ColumnPrdName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnPrdName.Width = 80;
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdID";
            this.ColumnPrdSpec.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnPrdSpec.HeaderText = "产品规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            this.ColumnPrdSpec.Width = 80;
            // 
            // ColumnAssistantCode
            // 
            this.ColumnAssistantCode.DataPropertyName = "AssistantCode";
            this.ColumnAssistantCode.HeaderText = "助记码";
            this.ColumnAssistantCode.Name = "ColumnAssistantCode";
            this.ColumnAssistantCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnAssistantCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnAssistantCode.Width = 66;
            // 
            // ColumnReworkFlag
            // 
            this.ColumnReworkFlag.DataPropertyName = "ReworkFlag";
            this.ColumnReworkFlag.HeaderText = "返工";
            this.ColumnReworkFlag.Name = "ColumnReworkFlag";
            this.ColumnReworkFlag.Width = 54;
            // 
            // ColumnQuantity
            // 
            this.ColumnQuantity.DataPropertyName = "Quantity";
            this.ColumnQuantity.HeaderText = "数量";
            this.ColumnQuantity.Name = "ColumnQuantity";
            this.ColumnQuantity.Width = 54;
            // 
            // ColumnBadQty
            // 
            this.ColumnBadQty.DataPropertyName = "BadQty";
            this.ColumnBadQty.HeaderText = "不良数";
            this.ColumnBadQty.Name = "ColumnBadQty";
            this.ColumnBadQty.Width = 66;
            // 
            // ColumnUnitName
            // 
            this.ColumnUnitName.DataPropertyName = "PrdID";
            this.ColumnUnitName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnUnitName.HeaderText = "单位";
            this.ColumnUnitName.Name = "ColumnUnitName";
            this.ColumnUnitName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnUnitName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnUnitName.Width = 45;
            // 
            // ColumnPriceQty
            // 
            this.ColumnPriceQty.DataPropertyName = "PriceQty";
            this.ColumnPriceQty.HeaderText = "计件数";
            this.ColumnPriceQty.Name = "ColumnPriceQty";
            this.ColumnPriceQty.Width = 66;
            // 
            // ColumnPriceUnitName
            // 
            this.ColumnPriceUnitName.DataPropertyName = "ProcessTypeID";
            this.ColumnPriceUnitName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnPriceUnitName.HeaderText = "计价单位";
            this.ColumnPriceUnitName.Name = "ColumnPriceUnitName";
            this.ColumnPriceUnitName.ReadOnly = true;
            this.ColumnPriceUnitName.Width = 45;
            // 
            // ColumnLaborPrice
            // 
            this.ColumnLaborPrice.DataPropertyName = "LaborPrice";
            this.ColumnLaborPrice.HeaderText = "单价";
            this.ColumnLaborPrice.Name = "ColumnLaborPrice";
            this.ColumnLaborPrice.ReadOnly = true;
            this.ColumnLaborPrice.Width = 54;
            // 
            // ColumnLaborWage
            // 
            this.ColumnLaborWage.DataPropertyName = "LaborWage";
            this.ColumnLaborWage.HeaderText = "总工资";
            this.ColumnLaborWage.Name = "ColumnLaborWage";
            this.ColumnLaborWage.ReadOnly = true;
            this.ColumnLaborWage.Width = 66;
            // 
            // btnAddPrd
            // 
            this.btnAddPrd.Location = new System.Drawing.Point(6, 5);
            this.btnAddPrd.Name = "btnAddPrd";
            this.btnAddPrd.Size = new System.Drawing.Size(59, 23);
            this.btnAddPrd.TabIndex = 14;
            this.btnAddPrd.Text = "+产品";
            this.btnAddPrd.UseVisualStyleBackColor = true;
            // 
            // FrmGroupPiecework
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 564);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmGroupPiecework";
            this.Text = "FrmGroupPiecework";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDateManuf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Button btnAddPsn;
        private JERPApp.Define.Hr.CtrlPersonnel ctrlPsnID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddMorePsn;
        private JERPApp.Define.Manufacture.CtrlWorkgroup  ctrlWorkgroupID;
        private System.Windows.Forms.Label label4;
        private JERPApp.Define.Manufacture.CtrlShift ctrlShiftID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnProcessTypeName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAssistantCode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnReworkFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBadQty;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPriceQty;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnPriceUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLaborPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLaborWage;
        private System.Windows.Forms.Button btnAddPrd;
    }
}