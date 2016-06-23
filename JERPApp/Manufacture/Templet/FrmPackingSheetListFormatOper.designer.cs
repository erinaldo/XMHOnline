namespace JERPApp.Manufacture.Templet
{
    partial class FrmPackingSheetListFormatOper
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTmpSheetName = new System.Windows.Forms.TextBox();
            this.txtItemRowIndex = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDateNoteCellName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMakerPsnCellName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtItemRowCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnSerialNoFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnFieldTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnlnkFieldMsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBtnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(265, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "多项包装单格式";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "模版名称";
            // 
            // txtTmpSheetName
            // 
            this.txtTmpSheetName.Location = new System.Drawing.Point(85, 35);
            this.txtTmpSheetName.Name = "txtTmpSheetName";
            this.txtTmpSheetName.Size = new System.Drawing.Size(175, 21);
            this.txtTmpSheetName.TabIndex = 2;
            // 
            // txtItemRowIndex
            // 
            this.txtItemRowIndex.Location = new System.Drawing.Point(337, 64);
            this.txtItemRowIndex.Name = "txtItemRowIndex";
            this.txtItemRowIndex.Size = new System.Drawing.Size(50, 21);
            this.txtItemRowIndex.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "明细开始行";
            // 
            // txtDateNoteCellName
            // 
            this.txtDateNoteCellName.Location = new System.Drawing.Point(86, 62);
            this.txtDateNoteCellName.Name = "txtDateNoteCellName";
            this.txtDateNoteCellName.Size = new System.Drawing.Size(45, 21);
            this.txtDateNoteCellName.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "下单日期栏";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMakerPsnCellName);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtItemRowCount);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtItemRowIndex);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDateNoteCellName);
            this.panel1.Controls.Add(this.txtTmpSheetName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 91);
            this.panel1.TabIndex = 21;
            // 
            // txtMakerPsnCellName
            // 
            this.txtMakerPsnCellName.Location = new System.Drawing.Point(205, 62);
            this.txtMakerPsnCellName.Name = "txtMakerPsnCellName";
            this.txtMakerPsnCellName.Size = new System.Drawing.Size(47, 21);
            this.txtMakerPsnCellName.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(137, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 49;
            this.label14.Text = "下单员栏";
            // 
            // txtItemRowCount
            // 
            this.txtItemRowCount.Location = new System.Drawing.Point(458, 62);
            this.txtItemRowCount.Name = "txtItemRowCount";
            this.txtItemRowCount.Size = new System.Drawing.Size(44, 21);
            this.txtItemRowCount.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(392, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 34;
            this.label9.Text = "明细行数";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 466);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(633, 30);
            this.panel2.TabIndex = 22;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(266, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 106;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(192, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 104;
            this.btnNew.Text = "新增";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(111, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 102;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(5, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(51, 23);
            this.btnAdd.TabIndex = 100;
            this.btnAdd.Text = "+列";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSerialNoFlag,
            this.ColumnFieldTitle,
            this.ColumnColumnName,
            this.ColumnlnkFieldMsg,
            this.ColumnBtnEdit});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 91);
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
            this.dgrdv.Size = new System.Drawing.Size(633, 375);
            this.dgrdv.TabIndex = 60;
            // 
            // ColumnSerialNoFlag
            // 
            this.ColumnSerialNoFlag.DataPropertyName = "SerialNoFlag";
            this.ColumnSerialNoFlag.HeaderText = "序号列";
            this.ColumnSerialNoFlag.Name = "ColumnSerialNoFlag";
            this.ColumnSerialNoFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSerialNoFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnSerialNoFlag.Width = 66;
            // 
            // ColumnFieldTitle
            // 
            this.ColumnFieldTitle.DataPropertyName = "FieldTitle";
            this.ColumnFieldTitle.HeaderText = "列标题";
            this.ColumnFieldTitle.Name = "ColumnFieldTitle";
            // 
            // ColumnColumnName
            // 
            this.ColumnColumnName.DataPropertyName = "ColumnName";
            this.ColumnColumnName.HeaderText = "Excel列名";
            this.ColumnColumnName.Name = "ColumnColumnName";
            // 
            // ColumnlnkFieldMsg
            // 
            this.ColumnlnkFieldMsg.DataPropertyName = "FieldMsg";
            this.ColumnlnkFieldMsg.HeaderText = "字段信息";
            this.ColumnlnkFieldMsg.Name = "ColumnlnkFieldMsg";
            this.ColumnlnkFieldMsg.ReadOnly = true;
            this.ColumnlnkFieldMsg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnBtnEdit
            // 
            this.ColumnBtnEdit.HeaderText = "变更";
            this.ColumnBtnEdit.Name = "ColumnBtnEdit";
            this.ColumnBtnEdit.Text = "变更";
            this.ColumnBtnEdit.UseColumnTextForButtonValue = true;
            this.ColumnBtnEdit.Width = 54;
            // 
            // FrmPackingSheetListFormatOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 496);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmPackingSheetListFormatOper";
            this.Text = "多项包装单格式";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTmpSheetName;
        private System.Windows.Forms.TextBox txtItemRowIndex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDateNoteCellName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAdd;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtItemRowCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnSerialNoFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFieldTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnlnkFieldMsg;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnBtnEdit;
        private System.Windows.Forms.TextBox txtMakerPsnCellName;
        private System.Windows.Forms.Label label14;
    }
}