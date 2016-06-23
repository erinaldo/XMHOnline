namespace JERPApp.Finance.Receivable
{
    partial class CtrlSaleInvoice
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

        #region 组件设计器生成的代码

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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgrdvNonInvoice = new JCommon.MyDataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFinanceAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMoneyTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInvoiceTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ctrlQDeliver = new JCommon.CtrlGridQuickFind();
            this.dgrdvInvoice = new JCommon.MyDataGridView();
            this.ColumnbtnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnInvoiceCode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnCompanyAbbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFinanceAddress1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMoneyTypeName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInvoiceTypeName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotalAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTaxAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlQInvoice = new JCommon.CtrlGridQuickFind();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvNonInvoice)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvInvoice)).BeginInit();
            this.panel2.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgrdvNonInvoice);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgrdvInvoice);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(678, 416);
            this.splitContainer1.SplitterDistance = 248;
            this.splitContainer1.TabIndex = 17;
            // 
            // dgrdvNonInvoice
            // 
            this.dgrdvNonInvoice.AllowUserToAddRows = false;
            this.dgrdvNonInvoice.AllowUserToDeleteRows = false;
            this.dgrdvNonInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvNonInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.ColumnFinanceAddress,
            this.ColumnMoneyTypeName,
            this.ColumnInvoiceTypeName});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvNonInvoice.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdvNonInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvNonInvoice.Location = new System.Drawing.Point(0, 0);
            this.dgrdvNonInvoice.Name = "dgrdvNonInvoice";
            this.dgrdvNonInvoice.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvNonInvoice.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdvNonInvoice.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdvNonInvoice.RowTemplate.Height = 23;
            this.dgrdvNonInvoice.Size = new System.Drawing.Size(678, 218);
            this.dgrdvNonInvoice.TabIndex = 17;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CompanyAbbName";
            this.dataGridViewTextBoxColumn2.HeaderText = "客户";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // ColumnFinanceAddress
            // 
            this.ColumnFinanceAddress.DataPropertyName = "FinanceAddress";
            this.ColumnFinanceAddress.HeaderText = "结算地";
            this.ColumnFinanceAddress.Name = "ColumnFinanceAddress";
            this.ColumnFinanceAddress.ReadOnly = true;
            this.ColumnFinanceAddress.Width = 150;
            // 
            // ColumnMoneyTypeName
            // 
            this.ColumnMoneyTypeName.DataPropertyName = "MoneyTypeName";
            this.ColumnMoneyTypeName.HeaderText = "币种";
            this.ColumnMoneyTypeName.Name = "ColumnMoneyTypeName";
            this.ColumnMoneyTypeName.ReadOnly = true;
            this.ColumnMoneyTypeName.Width = 66;
            // 
            // ColumnInvoiceTypeName
            // 
            this.ColumnInvoiceTypeName.DataPropertyName = "InvoiceTypeName";
            this.ColumnInvoiceTypeName.HeaderText = "发票类型";
            this.ColumnInvoiceTypeName.Name = "ColumnInvoiceTypeName";
            this.ColumnInvoiceTypeName.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ctrlQDeliver);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 218);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(678, 30);
            this.panel3.TabIndex = 16;
            // 
            // ctrlQDeliver
            // 
            this.ctrlQDeliver.Location = new System.Drawing.Point(5, 4);
            this.ctrlQDeliver.Name = "ctrlQDeliver";
            this.ctrlQDeliver.SeachGridView = null;
            this.ctrlQDeliver.Size = new System.Drawing.Size(287, 21);
            this.ctrlQDeliver.TabIndex = 0;
            // 
            // dgrdvInvoice
            // 
            this.dgrdvInvoice.AllowUserToAddRows = false;
            this.dgrdvInvoice.AllowUserToDeleteRows = false;
            this.dgrdvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnEdit,
            this.ColumnInvoiceCode,
            this.ColumnCompanyAbbName,
            this.ColumnFinanceAddress1,
            this.ColumnYear,
            this.ColumnMonth,
            this.ColumnMoneyTypeName1,
            this.ColumnInvoiceTypeName1,
            this.ColumnTotalAMT,
            this.ColumnTaxAMT,
            this.ColumnDateNote,
            this.ColumnMemo});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvInvoice.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvInvoice.Location = new System.Drawing.Point(0, 0);
            this.dgrdvInvoice.Name = "dgrdvInvoice";
            this.dgrdvInvoice.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvInvoice.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdvInvoice.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdvInvoice.RowTemplate.Height = 23;
            this.dgrdvInvoice.Size = new System.Drawing.Size(678, 134);
            this.dgrdvInvoice.TabIndex = 16;
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
            this.ColumnbtnEdit.Width = 54;
            // 
            // ColumnInvoiceCode
            // 
            this.ColumnInvoiceCode.DataPropertyName = "InvoiceCode";
            this.ColumnInvoiceCode.HeaderText = "发票单号";
            this.ColumnInvoiceCode.Name = "ColumnInvoiceCode";
            this.ColumnInvoiceCode.ReadOnly = true;
            this.ColumnInvoiceCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnInvoiceCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnCompanyAbbName
            // 
            this.ColumnCompanyAbbName.DataPropertyName = "CompanyAbbName";
            this.ColumnCompanyAbbName.HeaderText = "客户";
            this.ColumnCompanyAbbName.Name = "ColumnCompanyAbbName";
            this.ColumnCompanyAbbName.ReadOnly = true;
            this.ColumnCompanyAbbName.Width = 54;
            // 
            // ColumnFinanceAddress1
            // 
            this.ColumnFinanceAddress1.DataPropertyName = "FinanceAddress";
            this.ColumnFinanceAddress1.HeaderText = "结算地";
            this.ColumnFinanceAddress1.Name = "ColumnFinanceAddress1";
            this.ColumnFinanceAddress1.ReadOnly = true;
            this.ColumnFinanceAddress1.Width = 120;
            // 
            // ColumnYear
            // 
            this.ColumnYear.DataPropertyName = "Year";
            this.ColumnYear.HeaderText = "年";
            this.ColumnYear.Name = "ColumnYear";
            this.ColumnYear.ReadOnly = true;
            this.ColumnYear.Width = 40;
            // 
            // ColumnMonth
            // 
            this.ColumnMonth.DataPropertyName = "Month";
            this.ColumnMonth.HeaderText = "月";
            this.ColumnMonth.Name = "ColumnMonth";
            this.ColumnMonth.ReadOnly = true;
            this.ColumnMonth.Width = 30;
            // 
            // ColumnMoneyTypeName1
            // 
            this.ColumnMoneyTypeName1.DataPropertyName = "MoneyTypeName";
            this.ColumnMoneyTypeName1.HeaderText = "币种";
            this.ColumnMoneyTypeName1.Name = "ColumnMoneyTypeName1";
            this.ColumnMoneyTypeName1.ReadOnly = true;
            this.ColumnMoneyTypeName1.Width = 66;
            // 
            // ColumnInvoiceTypeName1
            // 
            this.ColumnInvoiceTypeName1.DataPropertyName = "InvoiceTypeName";
            this.ColumnInvoiceTypeName1.HeaderText = "发票类型";
            this.ColumnInvoiceTypeName1.Name = "ColumnInvoiceTypeName1";
            this.ColumnInvoiceTypeName1.ReadOnly = true;
            // 
            // ColumnTotalAMT
            // 
            this.ColumnTotalAMT.DataPropertyName = "TotalAMT";
            this.ColumnTotalAMT.HeaderText = "金额";
            this.ColumnTotalAMT.Name = "ColumnTotalAMT";
            this.ColumnTotalAMT.ReadOnly = true;
            this.ColumnTotalAMT.Width = 66;
            // 
            // ColumnTaxAMT
            // 
            this.ColumnTaxAMT.DataPropertyName = "TaxAMT";
            this.ColumnTaxAMT.HeaderText = "税额";
            this.ColumnTaxAMT.Name = "ColumnTaxAMT";
            this.ColumnTaxAMT.ReadOnly = true;
            this.ColumnTaxAMT.Width = 66;
            // 
            // ColumnDateNote
            // 
            this.ColumnDateNote.DataPropertyName = "DateNote";
            this.ColumnDateNote.HeaderText = "制单日期";
            this.ColumnDateNote.Name = "ColumnDateNote";
            this.ColumnDateNote.ReadOnly = true;
            this.ColumnDateNote.Width = 78;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlQInvoice);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 134);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(678, 30);
            this.panel2.TabIndex = 15;
            // 
            // ctrlQInvoice
            // 
            this.ctrlQInvoice.Location = new System.Drawing.Point(5, 4);
            this.ctrlQInvoice.Name = "ctrlQInvoice";
            this.ctrlQInvoice.SeachGridView = null;
            this.ctrlQInvoice.Size = new System.Drawing.Size(287, 21);
            this.ctrlQInvoice.TabIndex = 0;
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
            // CtrlSaleInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CtrlSaleInvoice";
            this.Size = new System.Drawing.Size(678, 416);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvNonInvoice)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvInvoice)).EndInit();
            this.panel2.ResumeLayout(false);
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private JCommon.MyDataGridView dgrdvNonInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFinanceAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMoneyTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInvoiceTypeName;
        private System.Windows.Forms.Panel panel3;
        private JCommon.CtrlGridQuickFind ctrlQDeliver;
        private JCommon.MyDataGridView dgrdvInvoice;
        private System.Windows.Forms.Panel panel2;
        private JCommon.CtrlGridQuickFind ctrlQInvoice;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnEdit;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnInvoiceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyAbbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFinanceAddress1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMoneyTypeName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInvoiceTypeName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTaxAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
    }
}
