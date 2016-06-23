namespace JERPApp.Manufacture.Report.Bill
{
    partial class CtrlWorkingSheet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMakerPsn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWorkingSheetCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDateTarget = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgrdvSchedule = new JCommon.MyDataGridView();
            this.ColumnPrdStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWorkingPositionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutSrcSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFinishedQty = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnNonFinishedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnlnkBOM = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnOutSrcOrderNonFinishedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBOMRequireFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnBOMNonFinishedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgrdvOutSrc = new JCommon.MyDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLinkColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnBOMFinishedQty1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvOutSrc)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMakerPsn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtQuantity);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtWorkingSheetCode);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtDateTarget);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 34);
            this.panel1.TabIndex = 0;
            // 
            // txtMakerPsn
            // 
            this.txtMakerPsn.Location = new System.Drawing.Point(533, 5);
            this.txtMakerPsn.Name = "txtMakerPsn";
            this.txtMakerPsn.ReadOnly = true;
            this.txtMakerPsn.Size = new System.Drawing.Size(104, 21);
            this.txtMakerPsn.TabIndex = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(498, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 79;
            this.label1.Text = "制单";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(219, 5);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.Size = new System.Drawing.Size(100, 21);
            this.txtQuantity.TabIndex = 78;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(184, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 77;
            this.label6.Text = "数量";
            // 
            // txtWorkingSheetCode
            // 
            this.txtWorkingSheetCode.Location = new System.Drawing.Point(62, 5);
            this.txtWorkingSheetCode.Name = "txtWorkingSheetCode";
            this.txtWorkingSheetCode.ReadOnly = true;
            this.txtWorkingSheetCode.Size = new System.Drawing.Size(120, 21);
            this.txtWorkingSheetCode.TabIndex = 76;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 75;
            this.label9.Text = "生产批号";
            // 
            // txtDateTarget
            // 
            this.txtDateTarget.Location = new System.Drawing.Point(388, 5);
            this.txtDateTarget.Name = "txtDateTarget";
            this.txtDateTarget.ReadOnly = true;
            this.txtDateTarget.Size = new System.Drawing.Size(104, 21);
            this.txtDateTarget.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(334, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "交货日期";
            // 
            // dgrdvSchedule
            // 
            this.dgrdvSchedule.AllowUserToAddRows = false;
            this.dgrdvSchedule.AllowUserToDeleteRows = false;
            this.dgrdvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPrdStatus,
            this.ColumnWorkingPositionName,
            this.ColumnOutSrcSupplier,
            this.ColumnQuantity,
            this.ColumnFinishedQty,
            this.ColumnNonFinishedQty,
            this.ColumnDateEnd,
            this.ColumnlnkBOM,
            this.ColumnOutSrcOrderNonFinishedQty,
            this.ColumnBOMRequireFlag,
            this.ColumnBOMNonFinishedQty});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvSchedule.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrdvSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvSchedule.Location = new System.Drawing.Point(0, 0);
            this.dgrdvSchedule.Name = "dgrdvSchedule";
            this.dgrdvSchedule.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvSchedule.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvSchedule.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvSchedule.RowTemplate.Height = 23;
            this.dgrdvSchedule.Size = new System.Drawing.Size(848, 344);
            this.dgrdvSchedule.TabIndex = 2;
            // 
            // ColumnPrdStatus
            // 
            this.ColumnPrdStatus.DataPropertyName = "PrdStatus";
            this.ColumnPrdStatus.HeaderText = "工序";
            this.ColumnPrdStatus.Name = "ColumnPrdStatus";
            this.ColumnPrdStatus.ReadOnly = true;
            this.ColumnPrdStatus.Width = 120;
            // 
            // ColumnWorkingPositionName
            // 
            this.ColumnWorkingPositionName.DataPropertyName = "WorkingPositionName";
            this.ColumnWorkingPositionName.HeaderText = "工位";
            this.ColumnWorkingPositionName.Name = "ColumnWorkingPositionName";
            this.ColumnWorkingPositionName.ReadOnly = true;
            this.ColumnWorkingPositionName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnWorkingPositionName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnWorkingPositionName.Width = 66;
            // 
            // ColumnOutSrcSupplier
            // 
            this.ColumnOutSrcSupplier.DataPropertyName = "OutSrcSupplier";
            this.ColumnOutSrcSupplier.HeaderText = "委外商";
            this.ColumnOutSrcSupplier.Name = "ColumnOutSrcSupplier";
            this.ColumnOutSrcSupplier.ReadOnly = true;
            this.ColumnOutSrcSupplier.Width = 66;
            // 
            // ColumnQuantity
            // 
            this.ColumnQuantity.DataPropertyName = "Quantity";
            this.ColumnQuantity.HeaderText = "数量";
            this.ColumnQuantity.Name = "ColumnQuantity";
            this.ColumnQuantity.ReadOnly = true;
            this.ColumnQuantity.Width = 60;
            // 
            // ColumnFinishedQty
            // 
            this.ColumnFinishedQty.DataPropertyName = "FinishedQty";
            this.ColumnFinishedQty.HeaderText = "完成";
            this.ColumnFinishedQty.Name = "ColumnFinishedQty";
            this.ColumnFinishedQty.ReadOnly = true;
            this.ColumnFinishedQty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnFinishedQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnFinishedQty.Width = 60;
            // 
            // ColumnNonFinishedQty
            // 
            this.ColumnNonFinishedQty.DataPropertyName = "NonFinishedQty";
            this.ColumnNonFinishedQty.HeaderText = "欠数";
            this.ColumnNonFinishedQty.Name = "ColumnNonFinishedQty";
            this.ColumnNonFinishedQty.ReadOnly = true;
            this.ColumnNonFinishedQty.Width = 60;
            // 
            // ColumnDateEnd
            // 
            this.ColumnDateEnd.DataPropertyName = "DateEnd";
            dataGridViewCellStyle1.Format = "MM-dd H:m";
            this.ColumnDateEnd.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnDateEnd.HeaderText = "交期";
            this.ColumnDateEnd.Name = "ColumnDateEnd";
            this.ColumnDateEnd.ReadOnly = true;
            this.ColumnDateEnd.Width = 80;
            // 
            // ColumnlnkBOM
            // 
            this.ColumnlnkBOM.HeaderText = "物料";
            this.ColumnlnkBOM.Name = "ColumnlnkBOM";
            this.ColumnlnkBOM.ReadOnly = true;
            this.ColumnlnkBOM.Text = "物料";
            this.ColumnlnkBOM.UseColumnTextForLinkValue = true;
            this.ColumnlnkBOM.Width = 54;
            // 
            // ColumnOutSrcOrderNonFinishedQty
            // 
            this.ColumnOutSrcOrderNonFinishedQty.DataPropertyName = "OutSrcOrderNonFinishedQty";
            this.ColumnOutSrcOrderNonFinishedQty.HeaderText = "委外未下单";
            this.ColumnOutSrcOrderNonFinishedQty.Name = "ColumnOutSrcOrderNonFinishedQty";
            this.ColumnOutSrcOrderNonFinishedQty.ReadOnly = true;
            this.ColumnOutSrcOrderNonFinishedQty.Width = 90;
            // 
            // ColumnBOMRequireFlag
            // 
            this.ColumnBOMRequireFlag.DataPropertyName = "BOMRequireFlag";
            this.ColumnBOMRequireFlag.HeaderText = "需领料";
            this.ColumnBOMRequireFlag.Name = "ColumnBOMRequireFlag";
            this.ColumnBOMRequireFlag.ReadOnly = true;
            this.ColumnBOMRequireFlag.Width = 66;
            // 
            // ColumnBOMNonFinishedQty
            // 
            this.ColumnBOMNonFinishedQty.DataPropertyName = "BOMNonFinishedQty";
            this.ColumnBOMNonFinishedQty.HeaderText = "领料欠数";
            this.ColumnBOMNonFinishedQty.Name = "ColumnBOMNonFinishedQty";
            this.ColumnBOMNonFinishedQty.ReadOnly = true;
            this.ColumnBOMNonFinishedQty.Width = 80;
            // 
            // dgrdvOutSrc
            // 
            this.dgrdvOutSrc.AllowUserToAddRows = false;
            this.dgrdvOutSrc.AllowUserToDeleteRows = false;
            this.dgrdvOutSrc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvOutSrc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewLinkColumn1,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.ColumnBOMFinishedQty1,
            this.dataGridViewTextBoxColumn8});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvOutSrc.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdvOutSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvOutSrc.Location = new System.Drawing.Point(0, 0);
            this.dgrdvOutSrc.Name = "dgrdvOutSrc";
            this.dgrdvOutSrc.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvOutSrc.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvOutSrc.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgrdvOutSrc.RowTemplate.Height = 23;
            this.dgrdvOutSrc.Size = new System.Drawing.Size(848, 115);
            this.dgrdvOutSrc.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PrdStatus";
            this.dataGridViewTextBoxColumn1.HeaderText = "工序";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CompanyAbbName";
            this.dataGridViewTextBoxColumn3.HeaderText = "委外商";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 66;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn4.HeaderText = "订单数";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 66;
            // 
            // dataGridViewLinkColumn1
            // 
            this.dataGridViewLinkColumn1.DataPropertyName = "FinishedQty";
            this.dataGridViewLinkColumn1.HeaderText = "完成";
            this.dataGridViewLinkColumn1.Name = "dataGridViewLinkColumn1";
            this.dataGridViewLinkColumn1.ReadOnly = true;
            this.dataGridViewLinkColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLinkColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NonFinishedQty";
            this.dataGridViewTextBoxColumn5.HeaderText = "欠数";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 60;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "DateEnd";
            dataGridViewCellStyle5.Format = "MM-dd H:m";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn6.HeaderText = "交期";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "BOMRequireFlag";
            this.dataGridViewTextBoxColumn7.HeaderText = "需物料";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn7.Width = 66;
            // 
            // ColumnBOMFinishedQty1
            // 
            this.ColumnBOMFinishedQty1.DataPropertyName = "BOMFinishedQty";
            this.ColumnBOMFinishedQty1.HeaderText = "已发料";
            this.ColumnBOMFinishedQty1.Name = "ColumnBOMFinishedQty1";
            this.ColumnBOMFinishedQty1.ReadOnly = true;
            this.ColumnBOMFinishedQty1.Width = 66;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "BOMNonFinishedQty";
            this.dataGridViewTextBoxColumn8.HeaderText = "未发料";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 66;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 34);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgrdvSchedule);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgrdvOutSrc);
            this.splitContainer1.Size = new System.Drawing.Size(848, 463);
            this.splitContainer1.SplitterDistance = 344;
            this.splitContainer1.TabIndex = 4;
            // 
            // CtrlWorkingSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "CtrlWorkingSheet";
            this.Size = new System.Drawing.Size(848, 497);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvOutSrc)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDateTarget;
        private JCommon.MyDataGridView dgrdvSchedule;
        private System.Windows.Forms.TextBox txtWorkingSheetCode;
        private System.Windows.Forms.Label label9;
        private JCommon.MyDataGridView dgrdvOutSrc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWorkingPositionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutSrcSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnFinishedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNonFinishedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateEnd;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnlnkBOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutSrcOrderNonFinishedQty;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnBOMRequireFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBOMNonFinishedQty;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewLinkColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBOMFinishedQty1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMakerPsn;
        private System.Windows.Forms.Label label1;
    }
}