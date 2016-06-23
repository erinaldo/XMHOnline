namespace JERPApp.Sale.Report
{
    partial class FrmHandlerCustomer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnAreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyCode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnCompanyAbbName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnCompanyAllName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnTotalMainAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateLastOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLinkman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDeliverAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFinanceAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
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
            this.panel1.Size = new System.Drawing.Size(932, 31);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(448, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "跟单客户";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 509);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(932, 32);
            this.panel2.TabIndex = 2;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(253, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "输出Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(3, 5);
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
            this.ColumnAreaName,
            this.ColumnCompanyCode,
            this.ColumnCompanyAbbName,
            this.ColumnCompanyAllName,
            this.ColumnTotalMainAMT,
            this.ColumnDateLastOrder,
            this.ColumnTelephone,
            this.ColumnFax,
            this.ColumnEmail,
            this.ColumnLinkman,
            this.ColumnDeliverAddress,
            this.ColumnFinanceAddress,
            this.ColumnMemo});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 31);
            this.dgrdv.Name = "dgrdv";
            this.dgrdv.ReadOnly = true;
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
            this.dgrdv.Size = new System.Drawing.Size(932, 478);
            this.dgrdv.TabIndex = 3;
            // 
            // ColumnAreaName
            // 
            this.ColumnAreaName.DataPropertyName = "AreaName";
            this.ColumnAreaName.HeaderText = "区域";
            this.ColumnAreaName.Name = "ColumnAreaName";
            this.ColumnAreaName.ReadOnly = true;
            this.ColumnAreaName.Width = 54;
            // 
            // ColumnCompanyCode
            // 
            this.ColumnCompanyCode.DataPropertyName = "CompanyCode";
            this.ColumnCompanyCode.HeaderText = "客户编号";
            this.ColumnCompanyCode.Name = "ColumnCompanyCode";
            this.ColumnCompanyCode.ReadOnly = true;
            this.ColumnCompanyCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnCompanyCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnCompanyCode.Width = 80;
            // 
            // ColumnCompanyAbbName
            // 
            this.ColumnCompanyAbbName.DataPropertyName = "CompanyAbbName";
            this.ColumnCompanyAbbName.HeaderText = "简称";
            this.ColumnCompanyAbbName.Name = "ColumnCompanyAbbName";
            this.ColumnCompanyAbbName.ReadOnly = true;
            this.ColumnCompanyAbbName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnCompanyAbbName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnCompanyAbbName.Width = 80;
            // 
            // ColumnCompanyAllName
            // 
            this.ColumnCompanyAllName.DataPropertyName = "CompanyAllName";
            this.ColumnCompanyAllName.HeaderText = "全称";
            this.ColumnCompanyAllName.Name = "ColumnCompanyAllName";
            this.ColumnCompanyAllName.ReadOnly = true;
            this.ColumnCompanyAllName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnCompanyAllName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnCompanyAllName.Width = 120;
            // 
            // ColumnTotalMainAMT
            // 
            this.ColumnTotalMainAMT.DataPropertyName = "TotalMainAMT";
            this.ColumnTotalMainAMT.HeaderText = "销售额";
            this.ColumnTotalMainAMT.Name = "ColumnTotalMainAMT";
            this.ColumnTotalMainAMT.ReadOnly = true;
            this.ColumnTotalMainAMT.Width = 66;
            // 
            // ColumnDateLastOrder
            // 
            this.ColumnDateLastOrder.DataPropertyName = "DateLastOrder";
            this.ColumnDateLastOrder.HeaderText = "最后下单";
            this.ColumnDateLastOrder.Name = "ColumnDateLastOrder";
            this.ColumnDateLastOrder.ReadOnly = true;
            this.ColumnDateLastOrder.Width = 80;
            // 
            // ColumnTelephone
            // 
            this.ColumnTelephone.DataPropertyName = "Telephone";
            this.ColumnTelephone.HeaderText = "电话";
            this.ColumnTelephone.Name = "ColumnTelephone";
            this.ColumnTelephone.ReadOnly = true;
            this.ColumnTelephone.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnTelephone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnTelephone.Width = 80;
            // 
            // ColumnFax
            // 
            this.ColumnFax.DataPropertyName = "Fax";
            this.ColumnFax.HeaderText = "传真";
            this.ColumnFax.Name = "ColumnFax";
            this.ColumnFax.ReadOnly = true;
            this.ColumnFax.Width = 80;
            // 
            // ColumnEmail
            // 
            this.ColumnEmail.DataPropertyName = "Email";
            this.ColumnEmail.HeaderText = "Email";
            this.ColumnEmail.Name = "ColumnEmail";
            this.ColumnEmail.ReadOnly = true;
            // 
            // ColumnLinkman
            // 
            this.ColumnLinkman.DataPropertyName = "Linkman";
            this.ColumnLinkman.HeaderText = "联系人";
            this.ColumnLinkman.Name = "ColumnLinkman";
            this.ColumnLinkman.ReadOnly = true;
            // 
            // ColumnDeliverAddress
            // 
            this.ColumnDeliverAddress.DataPropertyName = "DeliverAddress";
            this.ColumnDeliverAddress.HeaderText = "送货地址";
            this.ColumnDeliverAddress.Name = "ColumnDeliverAddress";
            this.ColumnDeliverAddress.ReadOnly = true;
            // 
            // ColumnFinanceAddress
            // 
            this.ColumnFinanceAddress.DataPropertyName = "FinanceAddress";
            this.ColumnFinanceAddress.HeaderText = "结算地";
            this.ColumnFinanceAddress.Name = "ColumnFinanceAddress";
            this.ColumnFinanceAddress.ReadOnly = true;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.ReadOnly = true;
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
            // FrmHandlerCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 541);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmHandlerCustomer";
            this.Text = "FrmHandlerCustomer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExport;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAreaName;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnCompanyCode;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnCompanyAbbName;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnCompanyAllName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalMainAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateLastOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFax;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLinkman;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeliverAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFinanceAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
    }
}