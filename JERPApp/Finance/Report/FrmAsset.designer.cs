namespace JERPApp.Finance.Report
{
    partial class FrmAsset
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.dgrdv = new JCommon.MyDataGridView();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDepositPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDepositStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnResponsiblePsnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDatePurchase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalvage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccumDepreciate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateLastRepair = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(954, 31);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(430, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "资产管理";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 503);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(954, 25);
            this.panel2.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(267, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "输出Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(3, 2);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(244, 21);
            this.ctrlQFind.TabIndex = 0;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnDepositPlace,
            this.ColumnDepositStatus,
            this.ColumnUserName,
            this.ColumnResponsiblePsnName,
            this.ColumnDatePurchase,
            this.ColumnCost,
            this.ColumnSalvage,
            this.ColumnAccumDepreciate,
            this.ColumnDateLastRepair});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 31);
            this.dgrdv.Name = "dgrdv";
            this.dgrdv.ReadOnly = true;
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
            this.dgrdv.Size = new System.Drawing.Size(954, 472);
            this.dgrdv.TabIndex = 2;
            // 
            // cMenu
            // 
            this.cMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemRefresh});
            this.cMenu.Name = "cMenu";
            this.cMenu.Size = new System.Drawing.Size(99, 26);
            // 
            // mItemRefresh
            // 
            this.mItemRefresh.Name = "mItemRefresh";
            this.mItemRefresh.Size = new System.Drawing.Size(98, 22);
            this.mItemRefresh.Text = "刷新";
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.HeaderText = "资产编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.ReadOnly = true;
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.HeaderText = "资产名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            this.ColumnPrdName.ReadOnly = true;
            // 
            // ColumnDepositPlace
            // 
            this.ColumnDepositPlace.DataPropertyName = "DepositPlace";
            this.ColumnDepositPlace.HeaderText = "存放地";
            this.ColumnDepositPlace.Name = "ColumnDepositPlace";
            this.ColumnDepositPlace.ReadOnly = true;
            this.ColumnDepositPlace.Width = 80;
            // 
            // ColumnDepositStatus
            // 
            this.ColumnDepositStatus.DataPropertyName = "DepositStatus";
            this.ColumnDepositStatus.HeaderText = "存放状态";
            this.ColumnDepositStatus.Name = "ColumnDepositStatus";
            this.ColumnDepositStatus.ReadOnly = true;
            this.ColumnDepositStatus.Width = 80;
            // 
            // ColumnUserName
            // 
            this.ColumnUserName.DataPropertyName = "UserName";
            this.ColumnUserName.HeaderText = "使用人";
            this.ColumnUserName.Name = "ColumnUserName";
            this.ColumnUserName.ReadOnly = true;
            this.ColumnUserName.Width = 66;
            // 
            // ColumnResponsiblePsnName
            // 
            this.ColumnResponsiblePsnName.DataPropertyName = "ResponsiblePsnName";
            this.ColumnResponsiblePsnName.HeaderText = "责任人";
            this.ColumnResponsiblePsnName.Name = "ColumnResponsiblePsnName";
            this.ColumnResponsiblePsnName.ReadOnly = true;
            this.ColumnResponsiblePsnName.Width = 66;
            // 
            // ColumnDatePurchase
            // 
            this.ColumnDatePurchase.DataPropertyName = "DatePurchase";
            this.ColumnDatePurchase.HeaderText = "采购日期";
            this.ColumnDatePurchase.Name = "ColumnDatePurchase";
            this.ColumnDatePurchase.ReadOnly = true;
            this.ColumnDatePurchase.Width = 80;
            // 
            // ColumnCost
            // 
            this.ColumnCost.DataPropertyName = "Cost";
            this.ColumnCost.HeaderText = "价值";
            this.ColumnCost.Name = "ColumnCost";
            this.ColumnCost.ReadOnly = true;
            this.ColumnCost.Width = 66;
            // 
            // ColumnSalvage
            // 
            this.ColumnSalvage.DataPropertyName = "Salvage";
            this.ColumnSalvage.HeaderText = "净残值";
            this.ColumnSalvage.Name = "ColumnSalvage";
            this.ColumnSalvage.ReadOnly = true;
            this.ColumnSalvage.Width = 66;
            // 
            // ColumnAccumDepreciate
            // 
            this.ColumnAccumDepreciate.DataPropertyName = "AccumDepreciate";
            this.ColumnAccumDepreciate.HeaderText = "累积折旧";
            this.ColumnAccumDepreciate.Name = "ColumnAccumDepreciate";
            this.ColumnAccumDepreciate.ReadOnly = true;
            this.ColumnAccumDepreciate.Width = 80;
            // 
            // ColumnDateLastRepair
            // 
            this.ColumnDateLastRepair.DataPropertyName = "DateLastRepair";
            dataGridViewCellStyle1.NullValue = "未维修";
            this.ColumnDateLastRepair.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnDateLastRepair.HeaderText = "维修日期";
            this.ColumnDateLastRepair.Name = "ColumnDateLastRepair";
            this.ColumnDateLastRepair.ReadOnly = true;
            this.ColumnDateLastRepair.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnDateLastRepair.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnDateLastRepair.Width = 80;
            // 
            // FrmAsset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 528);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmAsset";
            this.Text = "FrmAsset";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDepositPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDepositStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnResponsiblePsnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDatePurchase;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalvage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccumDepreciate;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnDateLastRepair;
    }
}