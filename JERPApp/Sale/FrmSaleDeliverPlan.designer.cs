namespace JERPApp.Sale
{
    partial class FrmSaleDeliverPlan
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkNonNew = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageOrder = new System.Windows.Forms.TabPage();
            this.dgrdvOrder = new JCommon.MyDataGridView();
            this.ColumnbtnDeliver = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewLinkColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotalAMT2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAdvanceAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSettleTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalePsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDeliverAddress1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ctrlQOrder = new JCommon.CtrlGridFind();
            this.pagePlan = new System.Windows.Forms.TabPage();
            this.dgrdvPlan = new JCommon.MyDataGridView();
            this.ColumnbtnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPONo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ctrlQPlan = new JCommon.CtrlGridFind();
            this.lnkBatchNew = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pageOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvOrder)).BeginInit();
            this.panel6.SuspendLayout();
            this.pagePlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvPlan)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkBatchNew);
            this.panel1.Controls.Add(this.lnkNonNew);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 31);
            this.panel1.TabIndex = 2;
            // 
            // lnkNonNew
            // 
            this.lnkNonNew.AutoSize = true;
            this.lnkNonNew.Location = new System.Drawing.Point(99, 16);
            this.lnkNonNew.Name = "lnkNonNew";
            this.lnkNonNew.Size = new System.Drawing.Size(65, 12);
            this.lnkNonNew.TabIndex = 21;
            this.lnkNonNew.TabStop = true;
            this.lnkNonNew.Text = "非订单申请";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(394, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "销售出货申请";
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
            // panel4
            // 
            this.panel4.Controls.Add(this.tabMain);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 31);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(797, 512);
            this.panel4.TabIndex = 7;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pageOrder);
            this.tabMain.Controls.Add(this.pagePlan);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Multiline = true;
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(797, 512);
            this.tabMain.TabIndex = 9;
            // 
            // pageOrder
            // 
            this.pageOrder.Controls.Add(this.dgrdvOrder);
            this.pageOrder.Controls.Add(this.panel6);
            this.pageOrder.Location = new System.Drawing.Point(4, 22);
            this.pageOrder.Name = "pageOrder";
            this.pageOrder.Padding = new System.Windows.Forms.Padding(3);
            this.pageOrder.Size = new System.Drawing.Size(789, 486);
            this.pageOrder.TabIndex = 2;
            this.pageOrder.Text = "订单申请";
            this.pageOrder.UseVisualStyleBackColor = true;
            // 
            // dgrdvOrder
            // 
            this.dgrdvOrder.AllowUserToAddRows = false;
            this.dgrdvOrder.AllowUserToDeleteRows = false;
            this.dgrdvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnDeliver,
            this.dataGridViewLinkColumn1,
            this.ColumnPONo,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.ColumnTotalAMT2,
            this.ColumnAdvanceAMT,
            this.ColumnSettleTypeName,
            this.ColumnSalePsn,
            this.ColumnDeliverAddress1,
            this.dataGridViewTextBoxColumn10});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvOrder.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdvOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvOrder.Location = new System.Drawing.Point(3, 3);
            this.dgrdvOrder.Name = "dgrdvOrder";
            this.dgrdvOrder.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvOrder.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdvOrder.RowTemplate.Height = 23;
            this.dgrdvOrder.Size = new System.Drawing.Size(783, 451);
            this.dgrdvOrder.TabIndex = 9;
            // 
            // ColumnbtnDeliver
            // 
            this.ColumnbtnDeliver.HeaderText = "申请";
            this.ColumnbtnDeliver.Name = "ColumnbtnDeliver";
            this.ColumnbtnDeliver.ReadOnly = true;
            this.ColumnbtnDeliver.Text = "申请";
            this.ColumnbtnDeliver.UseColumnTextForButtonValue = true;
            this.ColumnbtnDeliver.Width = 60;
            // 
            // dataGridViewLinkColumn1
            // 
            this.dataGridViewLinkColumn1.DataPropertyName = "NoteCode";
            this.dataGridViewLinkColumn1.HeaderText = "订单流水";
            this.dataGridViewLinkColumn1.Name = "dataGridViewLinkColumn1";
            this.dataGridViewLinkColumn1.ReadOnly = true;
            this.dataGridViewLinkColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnPONo
            // 
            this.ColumnPONo.DataPropertyName = "PONo";
            this.ColumnPONo.HeaderText = "订单编号";
            this.ColumnPONo.Name = "ColumnPONo";
            this.ColumnPONo.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CompanyAbbName";
            this.dataGridViewTextBoxColumn7.HeaderText = "客户";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "DateNote";
            this.dataGridViewTextBoxColumn8.HeaderText = "日期";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // ColumnTotalAMT2
            // 
            this.ColumnTotalAMT2.DataPropertyName = "TotalAMT";
            this.ColumnTotalAMT2.HeaderText = "订单货款";
            this.ColumnTotalAMT2.Name = "ColumnTotalAMT2";
            this.ColumnTotalAMT2.ReadOnly = true;
            this.ColumnTotalAMT2.Width = 80;
            // 
            // ColumnAdvanceAMT
            // 
            this.ColumnAdvanceAMT.DataPropertyName = "AdvanceAMT";
            this.ColumnAdvanceAMT.HeaderText = "预收款";
            this.ColumnAdvanceAMT.Name = "ColumnAdvanceAMT";
            this.ColumnAdvanceAMT.ReadOnly = true;
            this.ColumnAdvanceAMT.Width = 66;
            // 
            // ColumnSettleTypeName
            // 
            this.ColumnSettleTypeName.DataPropertyName = "SettleTypeName";
            this.ColumnSettleTypeName.HeaderText = "结算方式";
            this.ColumnSettleTypeName.Name = "ColumnSettleTypeName";
            this.ColumnSettleTypeName.ReadOnly = true;
            this.ColumnSettleTypeName.Width = 80;
            // 
            // ColumnSalePsn
            // 
            this.ColumnSalePsn.DataPropertyName = "SalePsn";
            this.ColumnSalePsn.HeaderText = "业务员";
            this.ColumnSalePsn.Name = "ColumnSalePsn";
            this.ColumnSalePsn.ReadOnly = true;
            this.ColumnSalePsn.Width = 66;
            // 
            // ColumnDeliverAddress1
            // 
            this.ColumnDeliverAddress1.DataPropertyName = "DeliverAddress";
            this.ColumnDeliverAddress1.HeaderText = "送货地";
            this.ColumnDeliverAddress1.Name = "ColumnDeliverAddress1";
            this.ColumnDeliverAddress1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Memo";
            this.dataGridViewTextBoxColumn10.HeaderText = "备注";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 120;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.ctrlQOrder);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(3, 454);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(783, 29);
            this.panel6.TabIndex = 3;
            // 
            // ctrlQOrder
            // 
            this.ctrlQOrder.Location = new System.Drawing.Point(5, 3);
            this.ctrlQOrder.Name = "ctrlQOrder";
            this.ctrlQOrder.SeachGridView = null;
            this.ctrlQOrder.Size = new System.Drawing.Size(331, 21);
            this.ctrlQOrder.TabIndex = 0;
            // 
            // pagePlan
            // 
            this.pagePlan.Controls.Add(this.dgrdvPlan);
            this.pagePlan.Controls.Add(this.panel5);
            this.pagePlan.Location = new System.Drawing.Point(4, 22);
            this.pagePlan.Name = "pagePlan";
            this.pagePlan.Padding = new System.Windows.Forms.Padding(3);
            this.pagePlan.Size = new System.Drawing.Size(789, 486);
            this.pagePlan.TabIndex = 1;
            this.pagePlan.Text = "申请变更";
            this.pagePlan.UseVisualStyleBackColor = true;
            // 
            // dgrdvPlan
            // 
            this.dgrdvPlan.AllowUserToAddRows = false;
            this.dgrdvPlan.AllowUserToDeleteRows = false;
            this.dgrdvPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnEdit,
            this.dataGridViewTextBoxColumn2,
            this.ColumnPONo2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvPlan.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvPlan.Location = new System.Drawing.Point(3, 3);
            this.dgrdvPlan.Name = "dgrdvPlan";
            this.dgrdvPlan.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvPlan.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvPlan.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdvPlan.RowTemplate.Height = 23;
            this.dgrdvPlan.Size = new System.Drawing.Size(783, 451);
            this.dgrdvPlan.TabIndex = 10;
            // 
            // ColumnbtnEdit
            // 
            this.ColumnbtnEdit.HeaderText = "变更";
            this.ColumnbtnEdit.Name = "ColumnbtnEdit";
            this.ColumnbtnEdit.ReadOnly = true;
            this.ColumnbtnEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnbtnEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnbtnEdit.Text = "变更";
            this.ColumnbtnEdit.UseColumnTextForButtonValue = true;
            this.ColumnbtnEdit.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CompanyAbbName";
            this.dataGridViewTextBoxColumn2.HeaderText = "客户";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // ColumnPONo2
            // 
            this.ColumnPONo2.DataPropertyName = "PONo";
            this.ColumnPONo2.HeaderText = "订单编号";
            this.ColumnPONo2.Name = "ColumnPONo2";
            this.ColumnPONo2.ReadOnly = true;
            this.ColumnPONo2.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DateTarget";
            this.dataGridViewTextBoxColumn4.HeaderText = "出货期";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Memo";
            this.dataGridViewTextBoxColumn6.HeaderText = "备注";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DeliverAddress";
            this.dataGridViewTextBoxColumn3.HeaderText = "送货地";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 180;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ctrlQPlan);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 454);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(783, 29);
            this.panel5.TabIndex = 2;
            // 
            // ctrlQPlan
            // 
            this.ctrlQPlan.Location = new System.Drawing.Point(5, 3);
            this.ctrlQPlan.Name = "ctrlQPlan";
            this.ctrlQPlan.SeachGridView = null;
            this.ctrlQPlan.Size = new System.Drawing.Size(331, 21);
            this.ctrlQPlan.TabIndex = 0;
            // 
            // lnkBatchNew
            // 
            this.lnkBatchNew.AutoSize = true;
            this.lnkBatchNew.Location = new System.Drawing.Point(3, 16);
            this.lnkBatchNew.Name = "lnkBatchNew";
            this.lnkBatchNew.Size = new System.Drawing.Size(77, 12);
            this.lnkBatchNew.TabIndex = 22;
            this.lnkBatchNew.TabStop = true;
            this.lnkBatchNew.Text = "订单批量申请";
            // 
            // FrmSaleDeliverPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 543);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSaleDeliverPlan";
            this.Text = "FrmSaleDeliverNote";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cMenu.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.pageOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvOrder)).EndInit();
            this.panel6.ResumeLayout(false);
            this.pagePlan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvPlan)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.LinkLabel lnkNonNew;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pagePlan;
        private JCommon.MyDataGridView dgrdvPlan;
        private System.Windows.Forms.Panel panel5;
        private JCommon.CtrlGridFind ctrlQPlan;
        private System.Windows.Forms.TabPage pageOrder;
        private System.Windows.Forms.Panel panel6;
        private JCommon.CtrlGridFind ctrlQOrder;
        private JCommon.MyDataGridView dgrdvOrder;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnDeliver;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewLinkColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalAMT2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAdvanceAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSettleTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalePsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeliverAddress1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPONo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.LinkLabel lnkBatchNew;
    }
}