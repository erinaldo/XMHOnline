namespace JERPApp.Finance.Payable.OtherRes
{
    partial class FrmAdvanceAMT
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
            this.lnkNew = new System.Windows.Forms.LinkLabel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ckbCapDateNote = new System.Windows.Forms.CheckBox();
            this.tpkDateBegin = new System.Windows.Forms.DateTimePicker();
            this.lblCapDateNote = new System.Windows.Forms.Label();
            this.tpkDateEnd = new System.Windows.Forms.DateTimePicker();
            this.ckbSupplier = new System.Windows.Forms.CheckBox();
            this.txtPONo = new System.Windows.Forms.TextBox();
            this.ckbNoteCode = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.pbar = new JCommon.PagebreakNav();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnPONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyAbbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateRecord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMoneyTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMakerPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlSupplierID = new JERPApp.Define.General.CtrlSupplierForOtherRes();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlSupplierID);
            this.panel1.Controls.Add(this.lnkNew);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.ckbCapDateNote);
            this.panel1.Controls.Add(this.tpkDateBegin);
            this.panel1.Controls.Add(this.lblCapDateNote);
            this.panel1.Controls.Add(this.tpkDateEnd);
            this.panel1.Controls.Add(this.ckbSupplier);
            this.panel1.Controls.Add(this.txtPONo);
            this.panel1.Controls.Add(this.ckbNoteCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 57);
            this.panel1.TabIndex = 0;
            // 
            // lnkNew
            // 
            this.lnkNew.AutoSize = true;
            this.lnkNew.Location = new System.Drawing.Point(3, 20);
            this.lnkNew.Name = "lnkNew";
            this.lnkNew.Size = new System.Drawing.Size(65, 12);
            this.lnkNew.TabIndex = 40;
            this.lnkNew.TabStop = true;
            this.lnkNew.Text = "新增预付款";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(726, 32);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 38;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // ckbCapDateNote
            // 
            this.ckbCapDateNote.AutoSize = true;
            this.ckbCapDateNote.Location = new System.Drawing.Point(375, 39);
            this.ckbCapDateNote.Name = "ckbCapDateNote";
            this.ckbCapDateNote.Size = new System.Drawing.Size(72, 16);
            this.ckbCapDateNote.TabIndex = 34;
            this.ckbCapDateNote.Text = "入账日期";
            // 
            // tpkDateBegin
            // 
            this.tpkDateBegin.Location = new System.Drawing.Point(455, 33);
            this.tpkDateBegin.Name = "tpkDateBegin";
            this.tpkDateBegin.Size = new System.Drawing.Size(120, 21);
            this.tpkDateBegin.TabIndex = 35;
            // 
            // lblCapDateNote
            // 
            this.lblCapDateNote.AutoSize = true;
            this.lblCapDateNote.Location = new System.Drawing.Point(580, 38);
            this.lblCapDateNote.Name = "lblCapDateNote";
            this.lblCapDateNote.Size = new System.Drawing.Size(17, 12);
            this.lblCapDateNote.TabIndex = 36;
            this.lblCapDateNote.Text = "—";
            // 
            // tpkDateEnd
            // 
            this.tpkDateEnd.Location = new System.Drawing.Point(600, 33);
            this.tpkDateEnd.Name = "tpkDateEnd";
            this.tpkDateEnd.Size = new System.Drawing.Size(120, 21);
            this.tpkDateEnd.TabIndex = 37;
            // 
            // ckbSupplier
            // 
            this.ckbSupplier.AutoSize = true;
            this.ckbSupplier.Location = new System.Drawing.Point(191, 41);
            this.ckbSupplier.Name = "ckbSupplier";
            this.ckbSupplier.Size = new System.Drawing.Size(60, 16);
            this.ckbSupplier.TabIndex = 33;
            this.ckbSupplier.Text = "供应商";
            this.ckbSupplier.UseVisualStyleBackColor = true;
            // 
            // txtPONo
            // 
            this.txtPONo.Location = new System.Drawing.Point(85, 34);
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.Size = new System.Drawing.Size(100, 21);
            this.txtPONo.TabIndex = 32;
            // 
            // ckbNoteCode
            // 
            this.ckbNoteCode.AutoSize = true;
            this.ckbNoteCode.Location = new System.Drawing.Point(7, 41);
            this.ckbNoteCode.Name = "ckbNoteCode";
            this.ckbNoteCode.Size = new System.Drawing.Size(72, 16);
            this.ckbNoteCode.TabIndex = 31;
            this.ckbNoteCode.Text = "订单编号";
            this.ckbNoteCode.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(381, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "原料采购预付款";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Controls.Add(this.pbar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 412);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(809, 32);
            this.panel2.TabIndex = 7;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(0, 3);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(251, 21);
            this.ctrlQFind.TabIndex = 2;
            // 
            // pbar
            // 
            this.pbar.AutoSize = true;
            this.pbar.Location = new System.Drawing.Point(257, 3);
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
            this.ColumnPONo,
            this.ColumnCompanyAbbName,
            this.ColumnDateRecord,
            this.ColumnMoneyTypeName,
            this.ColumnAmount,
            this.ColumnMakerPsn,
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
            this.dgrdv.Location = new System.Drawing.Point(0, 57);
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
            this.dgrdv.Size = new System.Drawing.Size(809, 355);
            this.dgrdv.TabIndex = 8;
            // 
            // ColumnPONo
            // 
            this.ColumnPONo.DataPropertyName = "PONo";
            this.ColumnPONo.HeaderText = "订单编号";
            this.ColumnPONo.Name = "ColumnPONo";
            this.ColumnPONo.ReadOnly = true;
            // 
            // ColumnCompanyAbbName
            // 
            this.ColumnCompanyAbbName.DataPropertyName = "CompanyAbbName";
            this.ColumnCompanyAbbName.HeaderText = "供应商";
            this.ColumnCompanyAbbName.Name = "ColumnCompanyAbbName";
            this.ColumnCompanyAbbName.ReadOnly = true;
            // 
            // ColumnDateRecord
            // 
            this.ColumnDateRecord.DataPropertyName = "DateRecord";
            this.ColumnDateRecord.HeaderText = "日期";
            this.ColumnDateRecord.Name = "ColumnDateRecord";
            this.ColumnDateRecord.ReadOnly = true;
            this.ColumnDateRecord.Width = 80;
            // 
            // ColumnMoneyTypeName
            // 
            this.ColumnMoneyTypeName.DataPropertyName = "MoneyTypeName";
            this.ColumnMoneyTypeName.HeaderText = "币种";
            this.ColumnMoneyTypeName.Name = "ColumnMoneyTypeName";
            this.ColumnMoneyTypeName.ReadOnly = true;
            this.ColumnMoneyTypeName.Width = 54;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.DataPropertyName = "Amount";
            this.ColumnAmount.HeaderText = "预付款";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.ReadOnly = true;
            this.ColumnAmount.Width = 66;
            // 
            // ColumnMakerPsn
            // 
            this.ColumnMakerPsn.DataPropertyName = "MakerPsn";
            this.ColumnMakerPsn.HeaderText = "入账人";
            this.ColumnMakerPsn.Name = "ColumnMakerPsn";
            this.ColumnMakerPsn.ReadOnly = true;
            this.ColumnMakerPsn.Width = 66;
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
            this.cMenu.Size = new System.Drawing.Size(101, 26);
            // 
            // mItemRefresh
            // 
            this.mItemRefresh.Name = "mItemRefresh";
            this.mItemRefresh.Size = new System.Drawing.Size(100, 22);
            this.mItemRefresh.Text = "刷新";
            // 
            // ctrlSupplierID
            // 
            this.ctrlSupplierID.CompanyID = 1;
            this.ctrlSupplierID.Location = new System.Drawing.Point(257, 32);
            this.ctrlSupplierID.Name = "ctrlSupplierID";
            this.ctrlSupplierID.Size = new System.Drawing.Size(112, 23);
            this.ctrlSupplierID.TabIndex = 58;
            // 
            // FrmAdvanceAMT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 444);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmAdvanceAMT";
            this.Text = "FrmAdvanceAMT";
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
        private JCommon.PagebreakNav pbar;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox ckbCapDateNote;
        private System.Windows.Forms.DateTimePicker tpkDateBegin;
        private System.Windows.Forms.Label lblCapDateNote;
        private System.Windows.Forms.DateTimePicker tpkDateEnd;
        private System.Windows.Forms.CheckBox ckbSupplier;
        private System.Windows.Forms.TextBox txtPONo;
        private System.Windows.Forms.CheckBox ckbNoteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyAbbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateRecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMoneyTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMakerPsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.LinkLabel lnkNew;
        private JERPApp.Define.General.CtrlSupplierForOtherRes ctrlSupplierID;
    }
}