namespace JERPApp.Dispatcher
{
    partial class FrmPostageNote
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
            this.lnkOtherResReturn = new System.Windows.Forms.LinkLabel();
            this.lnkPrdReturn = new System.Windows.Forms.LinkLabel();
            this.lnkMtrReturn = new System.Windows.Forms.LinkLabel();
            this.lnkSaleRepair = new System.Windows.Forms.LinkLabel();
            this.lnkSaleReplenish = new System.Windows.Forms.LinkLabel();
            this.lnkSaleDeliver = new System.Windows.Forms.LinkLabel();
            this.ctrlNoteSearch = new JCommon.ctrlNoteSearch();
            this.lnkNew = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbar = new JCommon.PagebreakNav();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnbtnDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnDateNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNoteCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel1.Controls.Add(this.lnkOtherResReturn);
            this.panel1.Controls.Add(this.lnkPrdReturn);
            this.panel1.Controls.Add(this.lnkMtrReturn);
            this.panel1.Controls.Add(this.lnkSaleRepair);
            this.panel1.Controls.Add(this.lnkSaleReplenish);
            this.panel1.Controls.Add(this.lnkSaleDeliver);
            this.panel1.Controls.Add(this.ctrlNoteSearch);
            this.panel1.Controls.Add(this.lnkNew);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(742, 76);
            this.panel1.TabIndex = 1;
            // 
            // lnkOtherResReturn
            // 
            this.lnkOtherResReturn.AutoSize = true;
            this.lnkOtherResReturn.Location = new System.Drawing.Point(597, 29);
            this.lnkOtherResReturn.Name = "lnkOtherResReturn";
            this.lnkOtherResReturn.Size = new System.Drawing.Size(113, 12);
            this.lnkOtherResReturn.TabIndex = 8;
            this.lnkOtherResReturn.TabStop = true;
            this.lnkOtherResReturn.Text = "耗材采购退货单快递";
            // 
            // lnkPrdReturn
            // 
            this.lnkPrdReturn.AutoSize = true;
            this.lnkPrdReturn.Location = new System.Drawing.Point(478, 29);
            this.lnkPrdReturn.Name = "lnkPrdReturn";
            this.lnkPrdReturn.Size = new System.Drawing.Size(113, 12);
            this.lnkPrdReturn.TabIndex = 7;
            this.lnkPrdReturn.TabStop = true;
            this.lnkPrdReturn.Text = "产品采购退货单快递";
            // 
            // lnkMtrReturn
            // 
            this.lnkMtrReturn.AutoSize = true;
            this.lnkMtrReturn.Location = new System.Drawing.Point(353, 29);
            this.lnkMtrReturn.Name = "lnkMtrReturn";
            this.lnkMtrReturn.Size = new System.Drawing.Size(113, 12);
            this.lnkMtrReturn.TabIndex = 6;
            this.lnkMtrReturn.TabStop = true;
            this.lnkMtrReturn.Text = "原料采购退货单快递";
            // 
            // lnkSaleRepair
            // 
            this.lnkSaleRepair.AutoSize = true;
            this.lnkSaleRepair.Location = new System.Drawing.Point(258, 29);
            this.lnkSaleRepair.Name = "lnkSaleRepair";
            this.lnkSaleRepair.Size = new System.Drawing.Size(89, 12);
            this.lnkSaleRepair.TabIndex = 5;
            this.lnkSaleRepair.TabStop = true;
            this.lnkSaleRepair.Text = "维修送货单快递";
            // 
            // lnkSaleReplenish
            // 
            this.lnkSaleReplenish.AutoSize = true;
            this.lnkSaleReplenish.Location = new System.Drawing.Point(160, 29);
            this.lnkSaleReplenish.Name = "lnkSaleReplenish";
            this.lnkSaleReplenish.Size = new System.Drawing.Size(89, 12);
            this.lnkSaleReplenish.TabIndex = 4;
            this.lnkSaleReplenish.TabStop = true;
            this.lnkSaleReplenish.Text = "销售补货单快递";
            // 
            // lnkSaleDeliver
            // 
            this.lnkSaleDeliver.AutoSize = true;
            this.lnkSaleDeliver.Location = new System.Drawing.Point(62, 29);
            this.lnkSaleDeliver.Name = "lnkSaleDeliver";
            this.lnkSaleDeliver.Size = new System.Drawing.Size(89, 12);
            this.lnkSaleDeliver.TabIndex = 3;
            this.lnkSaleDeliver.TabStop = true;
            this.lnkSaleDeliver.Text = "销售送货单快递";
            // 
            // ctrlNoteSearch
            // 
            this.ctrlNoteSearch.DateNoteFieldName = "DateNote";
            this.ctrlNoteSearch.Location = new System.Drawing.Point(7, 47);
            this.ctrlNoteSearch.Name = "ctrlNoteSearch";
            this.ctrlNoteSearch.NoteCodeFieldName = "NoteCode";
            this.ctrlNoteSearch.Size = new System.Drawing.Size(550, 28);
            this.ctrlNoteSearch.TabIndex = 2;
            // 
            // lnkNew
            // 
            this.lnkNew.AutoSize = true;
            this.lnkNew.Location = new System.Drawing.Point(5, 29);
            this.lnkNew.Name = "lnkNew";
            this.lnkNew.Size = new System.Drawing.Size(53, 12);
            this.lnkNew.TabIndex = 1;
            this.lnkNew.TabStop = true;
            this.lnkNew.Text = "新快递单";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(352, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "快递单登记";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pbar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 469);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(742, 37);
            this.panel2.TabIndex = 2;
            // 
            // pbar
            // 
            this.pbar.AutoSize = true;
            this.pbar.Location = new System.Drawing.Point(3, 6);
            this.pbar.Name = "pbar";
            this.pbar.PageInBlock = 10;
            this.pbar.PageIndex = 1;
            this.pbar.PageSize = 50;
            this.pbar.Size = new System.Drawing.Size(406, 27);
            this.pbar.TabIndex = 0;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnDetail,
            this.ColumnDateNote,
            this.ColumnNoteCode,
            this.ColumnCompanyName,
            this.ColumnAmount,
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
            this.dgrdv.Location = new System.Drawing.Point(0, 76);
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
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(742, 393);
            this.dgrdv.TabIndex = 3;
            // 
            // ColumnbtnDetail
            // 
            this.ColumnbtnDetail.HeaderText = "详细";
            this.ColumnbtnDetail.Name = "ColumnbtnDetail";
            this.ColumnbtnDetail.ReadOnly = true;
            this.ColumnbtnDetail.Text = "详细";
            this.ColumnbtnDetail.UseColumnTextForButtonValue = true;
            this.ColumnbtnDetail.Width = 66;
            // 
            // ColumnDateNote
            // 
            this.ColumnDateNote.DataPropertyName = "DateNote";
            this.ColumnDateNote.HeaderText = "快递日期";
            this.ColumnDateNote.Name = "ColumnDateNote";
            this.ColumnDateNote.ReadOnly = true;
            // 
            // ColumnNoteCode
            // 
            this.ColumnNoteCode.DataPropertyName = "NoteCode";
            this.ColumnNoteCode.HeaderText = "快递单号";
            this.ColumnNoteCode.Name = "ColumnNoteCode";
            this.ColumnNoteCode.ReadOnly = true;
            this.ColumnNoteCode.Width = 150;
            // 
            // ColumnCompanyName
            // 
            this.ColumnCompanyName.DataPropertyName = "CompanyName";
            this.ColumnCompanyName.HeaderText = "快递公司";
            this.ColumnCompanyName.Name = "ColumnCompanyName";
            this.ColumnCompanyName.ReadOnly = true;
            this.ColumnCompanyName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnCompanyName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnCompanyName.Width = 120;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.DataPropertyName = "Amount";
            this.ColumnAmount.HeaderText = "运费";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.ReadOnly = true;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.ReadOnly = true;
            this.ColumnMemo.Width = 140;
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
            // FrmPostageNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 506);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmPostageNote";
            this.Text = "FrmPostageNote";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel lnkNew;
        private JCommon.PagebreakNav pbar;
        private JCommon.MyDataGridView dgrdv;
        private JCommon.ctrlNoteSearch ctrlNoteSearch;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNoteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.LinkLabel lnkSaleRepair;
        private System.Windows.Forms.LinkLabel lnkSaleReplenish;
        private System.Windows.Forms.LinkLabel lnkSaleDeliver;
        private System.Windows.Forms.LinkLabel lnkMtrReturn;
        private System.Windows.Forms.LinkLabel lnkOtherResReturn;
        private System.Windows.Forms.LinkLabel lnkPrdReturn;
    }
}