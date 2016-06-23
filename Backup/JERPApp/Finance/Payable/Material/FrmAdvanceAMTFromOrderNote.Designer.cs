namespace JERPApp.Finance.Payable.Material
{
    partial class FrmAdvanceAMTFromOrderNote
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
            this.pbar = new JCommon.PagebreakNav();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.dgrdv = new JCommon.MyDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlSupplierID = new JERPApp.Define.General.CtrlSupplierForMaterial();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ckbCapDateNote = new System.Windows.Forms.CheckBox();
            this.tpkDateBegin = new System.Windows.Forms.DateTimePicker();
            this.lblCapDateNote = new System.Windows.Forms.Label();
            this.tpkDateEnd = new System.Windows.Forms.DateTimePicker();
            this.ckbSupplier = new System.Windows.Forms.CheckBox();
            this.txtPONo = new System.Windows.Forms.TextBox();
            this.ckbNoteCode = new System.Windows.Forms.CheckBox();
            this.ColumnbtnSelect = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnNoteCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyAbbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMoneyTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSettleTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPriceTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMakerPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbar);
            this.panel1.Controls.Add(this.ctrlQFind);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 423);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 30);
            this.panel1.TabIndex = 0;
            // 
            // pbar
            // 
            this.pbar.AutoSize = true;
            this.pbar.Location = new System.Drawing.Point(234, 3);
            this.pbar.Name = "pbar";
            this.pbar.PageInBlock = 10;
            this.pbar.PageIndex = 1;
            this.pbar.PageSize = 50;
            this.pbar.Size = new System.Drawing.Size(406, 27);
            this.pbar.TabIndex = 1;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(3, 3);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(225, 21);
            this.ctrlQFind.TabIndex = 0;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnSelect,
            this.ColumnNoteCode,
            this.ColumnCompanyAbbName,
            this.ColumnDateNote,
            this.ColumnMoneyTypeName,
            this.ColumnSettleTypeName,
            this.ColumnPriceTypeName,
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
            this.dgrdv.Location = new System.Drawing.Point(0, 47);
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
            this.dgrdv.Size = new System.Drawing.Size(809, 376);
            this.dgrdv.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlSupplierID);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.ckbCapDateNote);
            this.panel2.Controls.Add(this.tpkDateBegin);
            this.panel2.Controls.Add(this.lblCapDateNote);
            this.panel2.Controls.Add(this.tpkDateEnd);
            this.panel2.Controls.Add(this.ckbSupplier);
            this.panel2.Controls.Add(this.txtPONo);
            this.panel2.Controls.Add(this.ckbNoteCode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(809, 47);
            this.panel2.TabIndex = 10;
            // 
            // ctrlSupplierID
            // 
            this.ctrlSupplierID.CompanyID = 1;
            this.ctrlSupplierID.Location = new System.Drawing.Point(253, 16);
            this.ctrlSupplierID.Name = "ctrlSupplierID";
            this.ctrlSupplierID.Size = new System.Drawing.Size(121, 23);
            this.ctrlSupplierID.TabIndex = 58;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(726, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 47;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // ckbCapDateNote
            // 
            this.ckbCapDateNote.AutoSize = true;
            this.ckbCapDateNote.Location = new System.Drawing.Point(375, 21);
            this.ckbCapDateNote.Name = "ckbCapDateNote";
            this.ckbCapDateNote.Size = new System.Drawing.Size(72, 16);
            this.ckbCapDateNote.TabIndex = 43;
            this.ckbCapDateNote.Text = "接单日期";
            // 
            // tpkDateBegin
            // 
            this.tpkDateBegin.Location = new System.Drawing.Point(455, 15);
            this.tpkDateBegin.Name = "tpkDateBegin";
            this.tpkDateBegin.Size = new System.Drawing.Size(120, 21);
            this.tpkDateBegin.TabIndex = 44;
            // 
            // lblCapDateNote
            // 
            this.lblCapDateNote.AutoSize = true;
            this.lblCapDateNote.Location = new System.Drawing.Point(580, 20);
            this.lblCapDateNote.Name = "lblCapDateNote";
            this.lblCapDateNote.Size = new System.Drawing.Size(17, 12);
            this.lblCapDateNote.TabIndex = 45;
            this.lblCapDateNote.Text = "—";
            // 
            // tpkDateEnd
            // 
            this.tpkDateEnd.Location = new System.Drawing.Point(600, 15);
            this.tpkDateEnd.Name = "tpkDateEnd";
            this.tpkDateEnd.Size = new System.Drawing.Size(120, 21);
            this.tpkDateEnd.TabIndex = 46;
            // 
            // ckbSupplier
            // 
            this.ckbSupplier.AutoSize = true;
            this.ckbSupplier.Location = new System.Drawing.Point(191, 23);
            this.ckbSupplier.Name = "ckbSupplier";
            this.ckbSupplier.Size = new System.Drawing.Size(60, 16);
            this.ckbSupplier.TabIndex = 42;
            this.ckbSupplier.Text = "供应商";
            this.ckbSupplier.UseVisualStyleBackColor = true;
            // 
            // txtPONo
            // 
            this.txtPONo.Location = new System.Drawing.Point(85, 16);
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.Size = new System.Drawing.Size(100, 21);
            this.txtPONo.TabIndex = 41;
            // 
            // ckbNoteCode
            // 
            this.ckbNoteCode.AutoSize = true;
            this.ckbNoteCode.Location = new System.Drawing.Point(7, 23);
            this.ckbNoteCode.Name = "ckbNoteCode";
            this.ckbNoteCode.Size = new System.Drawing.Size(72, 16);
            this.ckbNoteCode.TabIndex = 40;
            this.ckbNoteCode.Text = "订单编号";
            this.ckbNoteCode.UseVisualStyleBackColor = true;
            // 
            // ColumnbtnSelect
            // 
            this.ColumnbtnSelect.HeaderText = "选择";
            this.ColumnbtnSelect.Name = "ColumnbtnSelect";
            this.ColumnbtnSelect.ReadOnly = true;
            this.ColumnbtnSelect.Text = "选择";
            this.ColumnbtnSelect.UseColumnTextForButtonValue = true;
            this.ColumnbtnSelect.Width = 54;
            // 
            // ColumnNoteCode
            // 
            this.ColumnNoteCode.DataPropertyName = "NoteCode";
            this.ColumnNoteCode.HeaderText = "订单编号";
            this.ColumnNoteCode.Name = "ColumnNoteCode";
            this.ColumnNoteCode.ReadOnly = true;
            // 
            // ColumnCompanyAbbName
            // 
            this.ColumnCompanyAbbName.DataPropertyName = "CompanyAbbName";
            this.ColumnCompanyAbbName.HeaderText = "供应商";
            this.ColumnCompanyAbbName.Name = "ColumnCompanyAbbName";
            this.ColumnCompanyAbbName.ReadOnly = true;
            // 
            // ColumnDateNote
            // 
            this.ColumnDateNote.DataPropertyName = "DateNote";
            this.ColumnDateNote.HeaderText = "日期";
            this.ColumnDateNote.Name = "ColumnDateNote";
            this.ColumnDateNote.ReadOnly = true;
            this.ColumnDateNote.Width = 80;
            // 
            // ColumnMoneyTypeName
            // 
            this.ColumnMoneyTypeName.DataPropertyName = "MoneyTypeName";
            this.ColumnMoneyTypeName.HeaderText = "币种";
            this.ColumnMoneyTypeName.Name = "ColumnMoneyTypeName";
            this.ColumnMoneyTypeName.ReadOnly = true;
            this.ColumnMoneyTypeName.Width = 54;
            // 
            // ColumnSettleTypeName
            // 
            this.ColumnSettleTypeName.DataPropertyName = "SettleTypeName";
            this.ColumnSettleTypeName.HeaderText = "结算方式";
            this.ColumnSettleTypeName.Name = "ColumnSettleTypeName";
            this.ColumnSettleTypeName.ReadOnly = true;
            this.ColumnSettleTypeName.Width = 80;
            // 
            // ColumnPriceTypeName
            // 
            this.ColumnPriceTypeName.DataPropertyName = "PriceTypeName";
            this.ColumnPriceTypeName.HeaderText = "单价类型";
            this.ColumnPriceTypeName.Name = "ColumnPriceTypeName";
            this.ColumnPriceTypeName.ReadOnly = true;
            this.ColumnPriceTypeName.Width = 80;
            // 
            // ColumnMakerPsn
            // 
            this.ColumnMakerPsn.DataPropertyName = "MakerPsn";
            this.ColumnMakerPsn.HeaderText = "制单人";
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
            // FrmAdvanceAMTFromOrderNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 453);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmAdvanceAMTFromOrderNote";
            this.Text = "原料采购订单预付";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private JCommon.MyDataGridView dgrdv;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private JCommon.PagebreakNav pbar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox ckbCapDateNote;
        private System.Windows.Forms.DateTimePicker tpkDateBegin;
        private System.Windows.Forms.Label lblCapDateNote;
        private System.Windows.Forms.DateTimePicker tpkDateEnd;
        private System.Windows.Forms.CheckBox ckbSupplier;
        private System.Windows.Forms.TextBox txtPONo;
        private System.Windows.Forms.CheckBox ckbNoteCode;
        private JERPApp.Define.General.CtrlSupplierForMaterial ctrlSupplierID;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNoteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyAbbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMoneyTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSettleTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPriceTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMakerPsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
    }
}