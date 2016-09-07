namespace JERPApp.Sale
{
    partial class FrmSaleOrderManuPlan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.dtpDateManuf = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgrdv = new JCommon.MyDataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgrdvPocess = new JCommon.MyDataGridView();
            this.itemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateNote1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrdID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateTarget1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBOMPlanFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnCompanyCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFinishedQty = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnPONo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMakerPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SumTimeCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMenuProcess = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mProcessRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.up = new System.Windows.Forms.ToolStripMenuItem();
            this.down = new System.Windows.Forms.ToolStripMenuItem();
            this.cMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvPocess)).BeginInit();
            this.cMenuProcess.SuspendLayout();
            this.SuspendLayout();
            // 
            // cMenu
            // 
            this.cMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemRefresh});
            this.cMenu.Name = "cMenu";
            this.cMenu.Size = new System.Drawing.Size(101, 26);
            // 
            // mItemRefresh
            // 
            this.mItemRefresh.Name = "mItemRefresh";
            this.mItemRefresh.Size = new System.Drawing.Size(100, 22);
            this.mItemRefresh.Text = "刷新";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnAddOrder);
            this.panel1.Controls.Add(this.dtpDateManuf);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1218, 68);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(549, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "订单排程计划";
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Location = new System.Drawing.Point(254, 26);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(81, 23);
            this.btnAddOrder.TabIndex = 6;
            this.btnAddOrder.Text = "+订单";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            // 
            // dtpDateManuf
            // 
            this.dtpDateManuf.Location = new System.Drawing.Point(12, 28);
            this.dtpDateManuf.Name = "dtpDateManuf";
            this.dtpDateManuf.Size = new System.Drawing.Size(149, 21);
            this.dtpDateManuf.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgrdv);
            this.panel2.Location = new System.Drawing.Point(2, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(785, 508);
            this.panel2.TabIndex = 7;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemID,
            this.ColumnDateNote1,
            this.PrdID,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.ColumnQuantity,
            this.ColumnDateTarget1,
            this.ColumnBOMPlanFlag,
            this.ColumnCompanyCode1,
            this.ColumnFinishedQty,
            this.ColumnPONo1,
            this.dataGridViewTextBoxColumn9,
            this.ColumnMakerPsn});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 0);
            this.dgrdv.Name = "dgrdv";
            this.dgrdv.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(785, 508);
            this.dgrdv.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgrdvPocess);
            this.panel3.Location = new System.Drawing.Point(794, 77);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(422, 508);
            this.panel3.TabIndex = 8;
            // 
            // dgrdvPocess
            // 
            this.dgrdvPocess.AllowUserToAddRows = false;
            this.dgrdvPocess.AllowUserToDeleteRows = false;
            this.dgrdvPocess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvPocess.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessIndex,
            this.ProcessName,
            this.TimeCost,
            this.count,
            this.SumTimeCost});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvPocess.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgrdvPocess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvPocess.Location = new System.Drawing.Point(0, 0);
            this.dgrdvPocess.Name = "dgrdvPocess";
            this.dgrdvPocess.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvPocess.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvPocess.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgrdvPocess.RowTemplate.Height = 23;
            this.dgrdvPocess.Size = new System.Drawing.Size(422, 508);
            this.dgrdvPocess.TabIndex = 9;
            // 
            // itemID
            // 
            this.itemID.HeaderText = "销售单明细";
            this.itemID.Name = "itemID";
            this.itemID.ReadOnly = true;
            this.itemID.Visible = false;
            // 
            // ColumnDateNote1
            // 
            this.ColumnDateNote1.DataPropertyName = "DateNote";
            this.ColumnDateNote1.HeaderText = "计划日期";
            this.ColumnDateNote1.Name = "ColumnDateNote1";
            this.ColumnDateNote1.ReadOnly = true;
            this.ColumnDateNote1.Width = 80;
            // 
            // PrdID
            // 
            this.PrdID.DataPropertyName = "PrdID";
            this.PrdID.HeaderText = "物料ID";
            this.PrdID.Name = "PrdID";
            this.PrdID.ReadOnly = true;
            this.PrdID.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PrdCode";
            this.dataGridViewTextBoxColumn5.HeaderText = "产品编号";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PrdName";
            this.dataGridViewTextBoxColumn6.HeaderText = "产品名称";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "PrdSpec";
            this.dataGridViewTextBoxColumn7.HeaderText = "产品规格";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Model";
            this.dataGridViewTextBoxColumn8.HeaderText = "机型";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 66;
            // 
            // ColumnQuantity
            // 
            this.ColumnQuantity.DataPropertyName = "Quantity";
            this.ColumnQuantity.HeaderText = "数量";
            this.ColumnQuantity.Name = "ColumnQuantity";
            this.ColumnQuantity.ReadOnly = true;
            this.ColumnQuantity.Width = 66;
            // 
            // ColumnDateTarget1
            // 
            this.ColumnDateTarget1.DataPropertyName = "DateTarget";
            this.ColumnDateTarget1.HeaderText = "交货日期";
            this.ColumnDateTarget1.Name = "ColumnDateTarget1";
            this.ColumnDateTarget1.ReadOnly = true;
            this.ColumnDateTarget1.Width = 80;
            // 
            // ColumnBOMPlanFlag
            // 
            this.ColumnBOMPlanFlag.DataPropertyName = "BOMPlanFlag";
            this.ColumnBOMPlanFlag.HeaderText = "算料";
            this.ColumnBOMPlanFlag.Name = "ColumnBOMPlanFlag";
            this.ColumnBOMPlanFlag.ReadOnly = true;
            this.ColumnBOMPlanFlag.Visible = false;
            this.ColumnBOMPlanFlag.Width = 54;
            // 
            // ColumnCompanyCode1
            // 
            this.ColumnCompanyCode1.DataPropertyName = "CompanyCode";
            this.ColumnCompanyCode1.HeaderText = "客户";
            this.ColumnCompanyCode1.Name = "ColumnCompanyCode1";
            this.ColumnCompanyCode1.ReadOnly = true;
            this.ColumnCompanyCode1.Width = 66;
            // 
            // ColumnFinishedQty
            // 
            this.ColumnFinishedQty.DataPropertyName = "FinishedQty";
            this.ColumnFinishedQty.HeaderText = "制令数";
            this.ColumnFinishedQty.Name = "ColumnFinishedQty";
            this.ColumnFinishedQty.ReadOnly = true;
            this.ColumnFinishedQty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnFinishedQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnFinishedQty.Visible = false;
            this.ColumnFinishedQty.Width = 66;
            // 
            // ColumnPONo1
            // 
            this.ColumnPONo1.DataPropertyName = "PONo";
            this.ColumnPONo1.HeaderText = "订单编号";
            this.ColumnPONo1.Name = "ColumnPONo1";
            this.ColumnPONo1.ReadOnly = true;
            this.ColumnPONo1.Width = 80;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "UnitName";
            this.dataGridViewTextBoxColumn9.HeaderText = "单位";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 54;
            // 
            // ColumnMakerPsn
            // 
            this.ColumnMakerPsn.DataPropertyName = "MakerPsn";
            this.ColumnMakerPsn.HeaderText = "制定人";
            this.ColumnMakerPsn.Name = "ColumnMakerPsn";
            this.ColumnMakerPsn.ReadOnly = true;
            this.ColumnMakerPsn.Visible = false;
            this.ColumnMakerPsn.Width = 66;
            // 
            // ProcessIndex
            // 
            this.ProcessIndex.DataPropertyName = "ProcessIndex";
            this.ProcessIndex.HeaderText = "序号";
            this.ProcessIndex.Name = "ProcessIndex";
            this.ProcessIndex.ReadOnly = true;
            this.ProcessIndex.Visible = false;
            this.ProcessIndex.Width = 54;
            // 
            // ProcessName
            // 
            this.ProcessName.DataPropertyName = "ProcessName";
            this.ProcessName.HeaderText = "工序名称";
            this.ProcessName.Name = "ProcessName";
            this.ProcessName.ReadOnly = true;
            this.ProcessName.Width = 80;
            // 
            // TimeCost
            // 
            this.TimeCost.DataPropertyName = "TimeCost";
            this.TimeCost.HeaderText = "加工时间";
            this.TimeCost.Name = "TimeCost";
            this.TimeCost.ReadOnly = true;
            this.TimeCost.Width = 80;
            // 
            // count
            // 
            this.count.DataPropertyName = "Count";
            this.count.HeaderText = "加工次数";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            this.count.Width = 80;
            // 
            // SumTimeCost
            // 
            this.SumTimeCost.DataPropertyName = "SumTimeCost";
            this.SumTimeCost.HeaderText = "总加工时间";
            this.SumTimeCost.Name = "SumTimeCost";
            this.SumTimeCost.ReadOnly = true;
            // 
            // cMenuProcess
            // 
            this.cMenuProcess.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mProcessRefresh,
            this.up,
            this.down});
            this.cMenuProcess.Name = "cMenuProcess";
            this.cMenuProcess.Size = new System.Drawing.Size(153, 92);
            // 
            // mProcessRefresh
            // 
            this.mProcessRefresh.Name = "mProcessRefresh";
            this.mProcessRefresh.Size = new System.Drawing.Size(152, 22);
            this.mProcessRefresh.Text = "刷新";
            this.mProcessRefresh.Visible = false;
            // 
            // up
            // 
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(100, 22);
            this.up.Text = "上移";
            // 
            // down
            // 
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(100, 22);
            this.down.Text = "下移";
            // 
            // FrmSaleOrderManuPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 597);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSaleOrderManuPlan";
            this.Text = "订单生产计划表";
            this.cMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvPocess)).EndInit();
            this.cMenuProcess.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.DateTimePicker dtpDateManuf;
        private System.Windows.Forms.Panel panel2;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Panel panel3;
        private JCommon.MyDataGridView dgrdvPocess;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateNote1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrdID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateTarget1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnBOMPlanFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyCode1;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnFinishedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPONo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMakerPsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn SumTimeCost;
        private System.Windows.Forms.ContextMenuStrip cMenuProcess;
        private System.Windows.Forms.ToolStripMenuItem mProcessRefresh;
        private System.Windows.Forms.ToolStripMenuItem up;
        private System.Windows.Forms.ToolStripMenuItem down;
    }
}