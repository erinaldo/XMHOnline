namespace JERPApp.Store.Material
{
    partial class FrmOutSrcSupplyNoteOper
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCompanyAbbName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.ctrlSupplierAddress = new JERPApp.Define.Manufacture.CtrlOutSrcOrderSupplierAddress();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpDateNote = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.rchMemo = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageItems = new System.Windows.Forms.TabPage();
            this.ctrlOutSrcSupplyItemOper = new JERPApp.Store.Material.CtrlOutSrcSupplyItemOper();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgrdvOrder = new JCommon.MyDataGridView();
            this.ColumnPONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWorkingSheetCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBOMNonFinishedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateTarget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnManufQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtNoteCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pageItems.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtNoteCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCompanyAbbName);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.ctrlSupplierAddress);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.dtpDateNote);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1082, 33);
            this.panel1.TabIndex = 2;
            // 
            // txtCompanyAbbName
            // 
            this.txtCompanyAbbName.Location = new System.Drawing.Point(398, 6);
            this.txtCompanyAbbName.Name = "txtCompanyAbbName";
            this.txtCompanyAbbName.ReadOnly = true;
            this.txtCompanyAbbName.Size = new System.Drawing.Size(131, 21);
            this.txtCompanyAbbName.TabIndex = 49;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(545, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 48;
            this.label15.Text = "委外地";
            // 
            // ctrlSupplierAddress
            // 
            this.ctrlSupplierAddress.Location = new System.Drawing.Point(604, 7);
            this.ctrlSupplierAddress.Name = "ctrlSupplierAddress";
            this.ctrlSupplierAddress.Size = new System.Drawing.Size(354, 23);
            this.ctrlSupplierAddress.SupplierAddress = "";
            this.ctrlSupplierAddress.TabIndex = 47;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(351, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 46;
            this.label16.Text = "供应商";
            // 
            // dtpDateNote
            // 
            this.dtpDateNote.Location = new System.Drawing.Point(233, 7);
            this.dtpDateNote.Name = "dtpDateNote";
            this.dtpDateNote.Size = new System.Drawing.Size(108, 21);
            this.dtpDateNote.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "制单日期";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.rchMemo);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 615);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1082, 31);
            this.panel2.TabIndex = 7;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(914, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(73, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "打印出库单";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(698, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // rchMemo
            // 
            this.rchMemo.Location = new System.Drawing.Point(57, 4);
            this.rchMemo.Name = "rchMemo";
            this.rchMemo.Size = new System.Drawing.Size(635, 24);
            this.rchMemo.TabIndex = 1;
            this.rchMemo.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "备注";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pageItems);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.ItemSize = new System.Drawing.Size(100, 18);
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Margin = new System.Windows.Forms.Padding(1);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Drawing.Point(4, 2);
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1082, 440);
            this.tabMain.TabIndex = 11;
            // 
            // pageItems
            // 
            this.pageItems.Controls.Add(this.ctrlOutSrcSupplyItemOper);
            this.pageItems.Location = new System.Drawing.Point(4, 22);
            this.pageItems.Name = "pageItems";
            this.pageItems.Padding = new System.Windows.Forms.Padding(3);
            this.pageItems.Size = new System.Drawing.Size(1074, 414);
            this.pageItems.TabIndex = 1;
            this.pageItems.Text = "物料明细";
            this.pageItems.UseVisualStyleBackColor = true;
            // 
            // ctrlOutSrcSupplyItemOper
            // 
            this.ctrlOutSrcSupplyItemOper.CompanyID = -1;
            this.ctrlOutSrcSupplyItemOper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlOutSrcSupplyItemOper.Location = new System.Drawing.Point(3, 3);
            this.ctrlOutSrcSupplyItemOper.Name = "ctrlOutSrcSupplyItemOper";
            this.ctrlOutSrcSupplyItemOper.Size = new System.Drawing.Size(1068, 408);
            this.ctrlOutSrcSupplyItemOper.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 33);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgrdvOrder);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabMain);
            this.splitContainer1.Size = new System.Drawing.Size(1082, 582);
            this.splitContainer1.SplitterDistance = 138;
            this.splitContainer1.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 108);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1082, 30);
            this.panel3.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(5, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(59, 23);
            this.btnAdd.TabIndex = 43;
            this.btnAdd.Text = "+加入";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(74, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 23);
            this.btnCancel.TabIndex = 44;
            this.btnCancel.Text = "重置";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dgrdvOrder
            // 
            this.dgrdvOrder.AllowUserToAddRows = false;
            this.dgrdvOrder.AllowUserToDeleteRows = false;
            this.dgrdvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPONo,
            this.ColumnWorkingSheetCode,
            this.ColumnPrdCode1,
            this.ColumnPrdName1,
            this.ColumnPrdSpec1,
            this.ColumnModel1,
            this.ColumnBOMNonFinishedQty,
            this.ColumnDateTarget,
            this.ColumnUnitName1,
            this.ColumnManufQty});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvOrder.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgrdvOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvOrder.Location = new System.Drawing.Point(0, 0);
            this.dgrdvOrder.Name = "dgrdvOrder";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvOrder.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgrdvOrder.RowTemplate.Height = 23;
            this.dgrdvOrder.Size = new System.Drawing.Size(1082, 108);
            this.dgrdvOrder.TabIndex = 3;
            // 
            // ColumnPONo
            // 
            this.ColumnPONo.DataPropertyName = "PONo";
            this.ColumnPONo.HeaderText = "订单编号";
            this.ColumnPONo.Name = "ColumnPONo";
            this.ColumnPONo.Width = 80;
            // 
            // ColumnWorkingSheetCode
            // 
            this.ColumnWorkingSheetCode.DataPropertyName = "WorkingSheetCode";
            this.ColumnWorkingSheetCode.HeaderText = "生产批号";
            this.ColumnWorkingSheetCode.Name = "ColumnWorkingSheetCode";
            this.ColumnWorkingSheetCode.Width = 80;
            // 
            // ColumnPrdCode1
            // 
            this.ColumnPrdCode1.DataPropertyName = "PrdCode";
            this.ColumnPrdCode1.HeaderText = "物料编号";
            this.ColumnPrdCode1.Name = "ColumnPrdCode1";
            this.ColumnPrdCode1.Width = 80;
            // 
            // ColumnPrdName1
            // 
            this.ColumnPrdName1.DataPropertyName = "PrdName";
            this.ColumnPrdName1.HeaderText = "物料名称";
            this.ColumnPrdName1.Name = "ColumnPrdName1";
            this.ColumnPrdName1.Width = 80;
            // 
            // ColumnPrdSpec1
            // 
            this.ColumnPrdSpec1.DataPropertyName = "PrdSpec";
            this.ColumnPrdSpec1.HeaderText = "物料规格";
            this.ColumnPrdSpec1.Name = "ColumnPrdSpec1";
            // 
            // ColumnModel1
            // 
            this.ColumnModel1.DataPropertyName = "Model";
            this.ColumnModel1.HeaderText = "机型";
            this.ColumnModel1.Name = "ColumnModel1";
            this.ColumnModel1.Width = 66;
            // 
            // ColumnBOMNonFinishedQty
            // 
            this.ColumnBOMNonFinishedQty.DataPropertyName = "BOMNonFinishedQty";
            this.ColumnBOMNonFinishedQty.HeaderText = "未发料";
            this.ColumnBOMNonFinishedQty.Name = "ColumnBOMNonFinishedQty";
            this.ColumnBOMNonFinishedQty.ReadOnly = true;
            this.ColumnBOMNonFinishedQty.Width = 66;
            // 
            // ColumnDateTarget
            // 
            this.ColumnDateTarget.DataPropertyName = "DateTarget";
            this.ColumnDateTarget.HeaderText = "交货期";
            this.ColumnDateTarget.Name = "ColumnDateTarget";
            this.ColumnDateTarget.Width = 66;
            // 
            // ColumnUnitName1
            // 
            this.ColumnUnitName1.DataPropertyName = "UnitName";
            this.ColumnUnitName1.HeaderText = "单位";
            this.ColumnUnitName1.Name = "ColumnUnitName1";
            this.ColumnUnitName1.Width = 54;
            // 
            // ColumnManufQty
            // 
            this.ColumnManufQty.DataPropertyName = "ManufQty";
            this.ColumnManufQty.HeaderText = "本次发料";
            this.ColumnManufQty.Name = "ColumnManufQty";
            this.ColumnManufQty.Width = 80;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(993, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // txtNoteCode
            // 
            this.txtNoteCode.Location = new System.Drawing.Point(62, 8);
            this.txtNoteCode.Name = "txtNoteCode";
            this.txtNoteCode.ReadOnly = true;
            this.txtNoteCode.Size = new System.Drawing.Size(109, 21);
            this.txtNoteCode.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 54;
            this.label1.Text = "发料单号";
            // 
            // FrmOutSrcSupplyNoteOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 646);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmOutSrcSupplyNoteOper";
            this.Text = "物料委外发料单";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.pageItems.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpDateNote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox rchMemo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private JERPApp.Define.Manufacture.CtrlOutSrcOrderSupplierAddress ctrlSupplierAddress;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageItems;
        private CtrlOutSrcSupplyItemOper ctrlOutSrcSupplyItemOper;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtCompanyAbbName;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private JCommon.MyDataGridView dgrdvOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWorkingSheetCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBOMNonFinishedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateTarget;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnManufQty;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtNoteCode;
        private System.Windows.Forms.Label label1;
    }
}