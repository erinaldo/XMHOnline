namespace JERPApp.Store.Material
{
    partial class FrmOutSrcSupplyConfirm
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
            this.txtNoteCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSupplyAddress = new System.Windows.Forms.TextBox();
            this.txtDateNote = new System.Windows.Forms.TextBox();
            this.txtCompanyAbbName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.rchMemo = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgrdvPlan = new JCommon.MyDataGridView();
            this.ColumnPONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWorkingSheetCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageItems = new System.Windows.Forms.TabPage();
            this.ctrlOutSrcSupplyItem = new JERPApp.Store.Material.CtrlOutSrcSupplyItemConfirm();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvPlan)).BeginInit();
            this.tabMain.SuspendLayout();
            this.pageItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtNoteCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSupplyAddress);
            this.panel1.Controls.Add(this.txtDateNote);
            this.panel1.Controls.Add(this.txtCompanyAbbName);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1126, 28);
            this.panel1.TabIndex = 2;
            // 
            // txtNoteCode
            // 
            this.txtNoteCode.Location = new System.Drawing.Point(70, 5);
            this.txtNoteCode.Name = "txtNoteCode";
            this.txtNoteCode.ReadOnly = true;
            this.txtNoteCode.Size = new System.Drawing.Size(109, 21);
            this.txtNoteCode.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 52;
            this.label1.Text = "发料单号";
            // 
            // txtSupplyAddress
            // 
            this.txtSupplyAddress.Location = new System.Drawing.Point(607, 4);
            this.txtSupplyAddress.Name = "txtSupplyAddress";
            this.txtSupplyAddress.ReadOnly = true;
            this.txtSupplyAddress.Size = new System.Drawing.Size(343, 21);
            this.txtSupplyAddress.TabIndex = 51;
            // 
            // txtDateNote
            // 
            this.txtDateNote.Location = new System.Drawing.Point(261, 5);
            this.txtDateNote.Name = "txtDateNote";
            this.txtDateNote.ReadOnly = true;
            this.txtDateNote.Size = new System.Drawing.Size(109, 21);
            this.txtDateNote.TabIndex = 50;
            // 
            // txtCompanyAbbName
            // 
            this.txtCompanyAbbName.Location = new System.Drawing.Point(423, 3);
            this.txtCompanyAbbName.Name = "txtCompanyAbbName";
            this.txtCompanyAbbName.ReadOnly = true;
            this.txtCompanyAbbName.Size = new System.Drawing.Size(131, 21);
            this.txtCompanyAbbName.TabIndex = 49;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(560, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 48;
            this.label15.Text = "委外地";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(376, 12);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 46;
            this.label16.Text = "供应商";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "制单日期";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.rchMemo);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 615);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1126, 31);
            this.panel2.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(909, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "审核发料";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // rchMemo
            // 
            this.rchMemo.Location = new System.Drawing.Point(57, 4);
            this.rchMemo.Name = "rchMemo";
            this.rchMemo.Size = new System.Drawing.Size(827, 24);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgrdvPlan);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabMain);
            this.splitContainer1.Size = new System.Drawing.Size(1126, 587);
            this.splitContainer1.SplitterDistance = 147;
            this.splitContainer1.TabIndex = 12;
            // 
            // dgrdvPlan
            // 
            this.dgrdvPlan.AllowUserToAddRows = false;
            this.dgrdvPlan.AllowUserToDeleteRows = false;
            this.dgrdvPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPONo,
            this.ColumnWorkingSheetCode,
            this.ColumnPrdCode1,
            this.ColumnPrdName1,
            this.ColumnPrdSpec1,
            this.ColumnModel1,
            this.ColumnPrdStatus,
            this.ColumnUnitName1,
            this.ColumnQuantity});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvPlan.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdvPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvPlan.Location = new System.Drawing.Point(0, 0);
            this.dgrdvPlan.Name = "dgrdvPlan";
            this.dgrdvPlan.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvPlan.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvPlan.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdvPlan.RowTemplate.Height = 23;
            this.dgrdvPlan.Size = new System.Drawing.Size(1126, 147);
            this.dgrdvPlan.TabIndex = 3;
            // 
            // ColumnPONo
            // 
            this.ColumnPONo.DataPropertyName = "PONo";
            this.ColumnPONo.HeaderText = "订单编号";
            this.ColumnPONo.Name = "ColumnPONo";
            this.ColumnPONo.ReadOnly = true;
            // 
            // ColumnWorkingSheetCode
            // 
            this.ColumnWorkingSheetCode.DataPropertyName = "WorkingSheetCode";
            this.ColumnWorkingSheetCode.HeaderText = "生产批号";
            this.ColumnWorkingSheetCode.Name = "ColumnWorkingSheetCode";
            this.ColumnWorkingSheetCode.ReadOnly = true;
            // 
            // ColumnPrdCode1
            // 
            this.ColumnPrdCode1.DataPropertyName = "PrdCode";
            this.ColumnPrdCode1.HeaderText = "物料编号";
            this.ColumnPrdCode1.Name = "ColumnPrdCode1";
            this.ColumnPrdCode1.ReadOnly = true;
            // 
            // ColumnPrdName1
            // 
            this.ColumnPrdName1.DataPropertyName = "PrdName";
            this.ColumnPrdName1.HeaderText = "物料名称";
            this.ColumnPrdName1.Name = "ColumnPrdName1";
            this.ColumnPrdName1.ReadOnly = true;
            // 
            // ColumnPrdSpec1
            // 
            this.ColumnPrdSpec1.DataPropertyName = "PrdSpec";
            this.ColumnPrdSpec1.HeaderText = "物料规格";
            this.ColumnPrdSpec1.Name = "ColumnPrdSpec1";
            this.ColumnPrdSpec1.ReadOnly = true;
            this.ColumnPrdSpec1.Width = 120;
            // 
            // ColumnModel1
            // 
            this.ColumnModel1.DataPropertyName = "Model";
            this.ColumnModel1.HeaderText = "机型";
            this.ColumnModel1.Name = "ColumnModel1";
            this.ColumnModel1.ReadOnly = true;
            this.ColumnModel1.Width = 66;
            // 
            // ColumnPrdStatus
            // 
            this.ColumnPrdStatus.DataPropertyName = "PrdStatus";
            this.ColumnPrdStatus.HeaderText = "加工工序";
            this.ColumnPrdStatus.Name = "ColumnPrdStatus";
            this.ColumnPrdStatus.ReadOnly = true;
            this.ColumnPrdStatus.Width = 80;
            // 
            // ColumnUnitName1
            // 
            this.ColumnUnitName1.DataPropertyName = "UnitName";
            this.ColumnUnitName1.HeaderText = "单位";
            this.ColumnUnitName1.Name = "ColumnUnitName1";
            this.ColumnUnitName1.ReadOnly = true;
            this.ColumnUnitName1.Width = 54;
            // 
            // ColumnQuantity
            // 
            this.ColumnQuantity.DataPropertyName = "Quantity";
            this.ColumnQuantity.HeaderText = "加工数";
            this.ColumnQuantity.Name = "ColumnQuantity";
            this.ColumnQuantity.ReadOnly = true;
            this.ColumnQuantity.Width = 80;
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
            this.tabMain.Size = new System.Drawing.Size(1126, 436);
            this.tabMain.TabIndex = 12;
            // 
            // pageItems
            // 
            this.pageItems.Controls.Add(this.ctrlOutSrcSupplyItem);
            this.pageItems.Location = new System.Drawing.Point(4, 22);
            this.pageItems.Name = "pageItems";
            this.pageItems.Padding = new System.Windows.Forms.Padding(3);
            this.pageItems.Size = new System.Drawing.Size(1118, 410);
            this.pageItems.TabIndex = 1;
            this.pageItems.Text = "物料明细";
            this.pageItems.UseVisualStyleBackColor = true;
            // 
            // ctrlOutSrcSupplyItem
            // 
            this.ctrlOutSrcSupplyItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlOutSrcSupplyItem.Location = new System.Drawing.Point(3, 3);
            this.ctrlOutSrcSupplyItem.Name = "ctrlOutSrcSupplyItem";
            this.ctrlOutSrcSupplyItem.Size = new System.Drawing.Size(1112, 404);
            this.ctrlOutSrcSupplyItem.TabIndex = 0;
            // 
            // FrmOutSrcSupplyConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 646);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmOutSrcSupplyConfirm";
            this.Text = "物料委外发料单";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvPlan)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.pageItems.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox rchMemo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCompanyAbbName;
        private System.Windows.Forms.TextBox txtSupplyAddress;
        private System.Windows.Forms.TextBox txtDateNote;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private JCommon.MyDataGridView dgrdvPlan;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageItems;
        private System.Windows.Forms.TextBox txtNoteCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWorkingSheetCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity;
        private CtrlOutSrcSupplyItemConfirm ctrlOutSrcSupplyItem;
    }
}