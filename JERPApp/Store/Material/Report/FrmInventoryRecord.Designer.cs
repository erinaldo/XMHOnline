namespace JERPApp.Store.Material.Report
{
    partial class FrmInventoryRecord
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
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.ctrlPrdID = new JERPApp.Define.Material.CtrlProduct();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnDateRegister = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIntoQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInventoryQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNoteName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnNoteCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctrlBranchStoreID = new JERPApp.Define.Material.CtrlBranchStore();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlGridQuickQFind = new JCommon.CtrlGridQuickFind();
            this.btnExplore = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlBranchStoreID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpDateBegin);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dtpDateEnd);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.ctrlPrdID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(753, 59);
            this.panel1.TabIndex = 0;
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.CustomFormat = "yyyy年MM月dd日 HH时mm分ss秒";
            this.dtpDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateBegin.Location = new System.Drawing.Point(66, 31);
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.Size = new System.Drawing.Size(187, 21);
            this.dtpDateBegin.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "起始时间";
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.CustomFormat = "yyyy年MM月dd日 HH时mm分ss秒";
            this.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateEnd.Location = new System.Drawing.Point(314, 34);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(187, 21);
            this.dtpDateEnd.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(256, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 22;
            this.label6.Text = "截止时间";
            // 
            // ctrlPrdID
            // 
            this.ctrlPrdID.AutoSize = true;
            this.ctrlPrdID.Location = new System.Drawing.Point(3, 3);
            this.ctrlPrdID.Name = "ctrlPrdID";
            this.ctrlPrdID.PrdID = -1;
            this.ctrlPrdID.Size = new System.Drawing.Size(664, 30);
            this.ctrlPrdID.TabIndex = 4;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDateRegister,
            this.ColumnSummary,
            this.ColumnIntoQty,
            this.ColumnOutQty,
            this.ColumnInventoryQty,
            this.ColumnNoteName,
            this.ColumnNoteCode});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 59);
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
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(753, 459);
            this.dgrdv.TabIndex = 7;
            // 
            // ColumnDateRegister
            // 
            this.ColumnDateRegister.DataPropertyName = "DateRegister";
            this.ColumnDateRegister.HeaderText = "入账时间";
            this.ColumnDateRegister.Name = "ColumnDateRegister";
            this.ColumnDateRegister.ReadOnly = true;
            this.ColumnDateRegister.Width = 120;
            // 
            // ColumnSummary
            // 
            this.ColumnSummary.DataPropertyName = "Summary";
            this.ColumnSummary.HeaderText = "摘要";
            this.ColumnSummary.Name = "ColumnSummary";
            this.ColumnSummary.ReadOnly = true;
            this.ColumnSummary.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSummary.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnSummary.Width = 120;
            // 
            // ColumnIntoQty
            // 
            this.ColumnIntoQty.DataPropertyName = "IntoQty";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.Format = "#,##0.####";
            this.ColumnIntoQty.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnIntoQty.HeaderText = "入库";
            this.ColumnIntoQty.Name = "ColumnIntoQty";
            this.ColumnIntoQty.ReadOnly = true;
            this.ColumnIntoQty.Width = 78;
            // 
            // ColumnOutQty
            // 
            this.ColumnOutQty.DataPropertyName = "OutQty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#,##0.####";
            this.ColumnOutQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnOutQty.HeaderText = "出库";
            this.ColumnOutQty.Name = "ColumnOutQty";
            this.ColumnOutQty.ReadOnly = true;
            this.ColumnOutQty.Width = 78;
            // 
            // ColumnInventoryQty
            // 
            this.ColumnInventoryQty.DataPropertyName = "InventoryQty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.Format = "#,##0.####";
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Red;
            this.ColumnInventoryQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnInventoryQty.HeaderText = "库存";
            this.ColumnInventoryQty.Name = "ColumnInventoryQty";
            this.ColumnInventoryQty.ReadOnly = true;
            this.ColumnInventoryQty.Width = 78;
            // 
            // ColumnNoteName
            // 
            this.ColumnNoteName.DataPropertyName = "NoteName";
            this.ColumnNoteName.HeaderText = "业务单据";
            this.ColumnNoteName.Name = "ColumnNoteName";
            this.ColumnNoteName.ReadOnly = true;
            this.ColumnNoteName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnNoteCode
            // 
            this.ColumnNoteCode.DataPropertyName = "NoteCode";
            this.ColumnNoteCode.HeaderText = "业务单号";
            this.ColumnNoteCode.Name = "ColumnNoteCode";
            this.ColumnNoteCode.ReadOnly = true;
            this.ColumnNoteCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ctrlBranchStoreID
            // 
            this.ctrlBranchStoreID.AutoSize = true;
            this.ctrlBranchStoreID.BranchStoreID = -1;
            this.ctrlBranchStoreID.Location = new System.Drawing.Point(538, 32);
            this.ctrlBranchStoreID.Name = "ctrlBranchStoreID";
            this.ctrlBranchStoreID.Size = new System.Drawing.Size(202, 23);
            this.ctrlBranchStoreID.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(502, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "库位";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExplore);
            this.panel2.Controls.Add(this.ctrlGridQuickQFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 518);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(753, 35);
            this.panel2.TabIndex = 8;
            // 
            // ctrlGridQuickQFind
            // 
            this.ctrlGridQuickQFind.Location = new System.Drawing.Point(3, 6);
            this.ctrlGridQuickQFind.Name = "ctrlGridQuickQFind";
            this.ctrlGridQuickQFind.SeachGridView = null;
            this.ctrlGridQuickQFind.Size = new System.Drawing.Size(244, 21);
            this.ctrlGridQuickQFind.TabIndex = 0;
            // 
            // btnExplore
            // 
            this.btnExplore.Location = new System.Drawing.Point(258, 6);
            this.btnExplore.Name = "btnExplore";
            this.btnExplore.Size = new System.Drawing.Size(67, 23);
            this.btnExplore.TabIndex = 22;
            this.btnExplore.Text = "输出打印";
            this.btnExplore.UseVisualStyleBackColor = true;
            // 
            // FrmInventoryRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 553);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmInventoryRecord";
            this.Text = "库存记录";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private JERPApp.Define.Material.CtrlProduct ctrlPrdID;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.Label label6;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateRegister;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIntoQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInventoryQty;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnNoteName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNoteCode;
        private JERPApp.Define.Material.CtrlBranchStore ctrlBranchStoreID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExplore;
        private JCommon.CtrlGridQuickFind ctrlGridQuickQFind;
    }
}