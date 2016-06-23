namespace JERPApp.Sale
{
    partial class FrmSaleDeliverAlter
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.ckbNoteCode = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNoteCode = new System.Windows.Forms.TextBox();
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.ckbCustomer = new System.Windows.Forms.CheckBox();
            this.ckbDateNote = new System.Windows.Forms.CheckBox();
            this.ctrlCompanyID = new JERPApp.Define.General.CtrlCustomer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbar = new JCommon.PagebreakNav();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnbtnAlter = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnNoteCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyAbbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPONo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMakerPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDeliverAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpDateEnd);
            this.panel1.Controls.Add(this.ckbNoteCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNoteCode);
            this.panel1.Controls.Add(this.dtpDateBegin);
            this.panel1.Controls.Add(this.ckbCustomer);
            this.panel1.Controls.Add(this.ckbDateNote);
            this.panel1.Controls.Add(this.ctrlCompanyID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(867, 60);
            this.panel1.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(726, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 23);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(393, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "销售送货变更";
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Location = new System.Drawing.Point(588, 29);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(129, 21);
            this.dtpDateEnd.TabIndex = 27;
            // 
            // ckbNoteCode
            // 
            this.ckbNoteCode.AutoSize = true;
            this.ckbNoteCode.Location = new System.Drawing.Point(2, 39);
            this.ckbNoteCode.Name = "ckbNoteCode";
            this.ckbNoteCode.Size = new System.Drawing.Size(72, 16);
            this.ckbNoteCode.TabIndex = 20;
            this.ckbNoteCode.Text = "送货单号";
            this.ckbNoteCode.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(565, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "到";
            // 
            // txtNoteCode
            // 
            this.txtNoteCode.Location = new System.Drawing.Point(80, 32);
            this.txtNoteCode.Name = "txtNoteCode";
            this.txtNoteCode.Size = new System.Drawing.Size(80, 21);
            this.txtNoteCode.TabIndex = 21;
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.Location = new System.Drawing.Point(435, 30);
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.Size = new System.Drawing.Size(123, 21);
            this.dtpDateBegin.TabIndex = 25;
            // 
            // ckbCustomer
            // 
            this.ckbCustomer.AutoSize = true;
            this.ckbCustomer.Location = new System.Drawing.Point(166, 35);
            this.ckbCustomer.Name = "ckbCustomer";
            this.ckbCustomer.Size = new System.Drawing.Size(48, 16);
            this.ckbCustomer.TabIndex = 22;
            this.ckbCustomer.Text = "客户";
            this.ckbCustomer.UseVisualStyleBackColor = true;
            // 
            // ckbDateNote
            // 
            this.ckbDateNote.AutoSize = true;
            this.ckbDateNote.Location = new System.Drawing.Point(356, 36);
            this.ckbDateNote.Name = "ckbDateNote";
            this.ckbDateNote.Size = new System.Drawing.Size(72, 16);
            this.ckbDateNote.TabIndex = 24;
            this.ckbDateNote.Text = "送货日期";
            this.ckbDateNote.UseVisualStyleBackColor = true;
            // 
            // ctrlCompanyID
            // 
            this.ctrlCompanyID.CompanyID = 1;
            this.ctrlCompanyID.Location = new System.Drawing.Point(220, 32);
            this.ctrlCompanyID.Name = "ctrlCompanyID";
            this.ctrlCompanyID.Size = new System.Drawing.Size(130, 23);
            this.ctrlCompanyID.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pbar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 474);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(867, 31);
            this.panel2.TabIndex = 10;
            // 
            // pbar
            // 
            this.pbar.AutoSize = true;
            this.pbar.Location = new System.Drawing.Point(12, 6);
            this.pbar.Name = "pbar";
            this.pbar.PageInBlock = 10;
            this.pbar.PageIndex = 0;
            this.pbar.PageSize = 30;
            this.pbar.Size = new System.Drawing.Size(406, 27);
            this.pbar.TabIndex = 2;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnAlter,
            this.ColumnNoteCode,
            this.ColumnCompanyAbbName,
            this.ColumnPONo1,
            this.ColumnDateNote,
            this.ColumnMakerPsn,
            this.ColumnDeliverAddress,
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
            this.dgrdv.Location = new System.Drawing.Point(0, 60);
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
            this.dgrdv.Size = new System.Drawing.Size(867, 414);
            this.dgrdv.TabIndex = 11;
            // 
            // ColumnbtnAlter
            // 
            this.ColumnbtnAlter.HeaderText = "变更";
            this.ColumnbtnAlter.Name = "ColumnbtnAlter";
            this.ColumnbtnAlter.ReadOnly = true;
            this.ColumnbtnAlter.Text = "变更";
            this.ColumnbtnAlter.UseColumnTextForButtonValue = true;
            this.ColumnbtnAlter.Width = 54;
            // 
            // ColumnNoteCode
            // 
            this.ColumnNoteCode.DataPropertyName = "NoteCode";
            this.ColumnNoteCode.HeaderText = "送货单号";
            this.ColumnNoteCode.Name = "ColumnNoteCode";
            this.ColumnNoteCode.ReadOnly = true;
            // 
            // ColumnCompanyAbbName
            // 
            this.ColumnCompanyAbbName.DataPropertyName = "CompanyAbbName";
            this.ColumnCompanyAbbName.HeaderText = "客户";
            this.ColumnCompanyAbbName.Name = "ColumnCompanyAbbName";
            this.ColumnCompanyAbbName.ReadOnly = true;
            this.ColumnCompanyAbbName.Width = 80;
            // 
            // ColumnPONo1
            // 
            this.ColumnPONo1.DataPropertyName = "PONo";
            this.ColumnPONo1.HeaderText = "订单编号";
            this.ColumnPONo1.Name = "ColumnPONo1";
            this.ColumnPONo1.ReadOnly = true;
            this.ColumnPONo1.Width = 80;
            // 
            // ColumnDateNote
            // 
            this.ColumnDateNote.DataPropertyName = "DateNote";
            this.ColumnDateNote.HeaderText = "日期";
            this.ColumnDateNote.Name = "ColumnDateNote";
            this.ColumnDateNote.ReadOnly = true;
            this.ColumnDateNote.Width = 80;
            // 
            // ColumnMakerPsn
            // 
            this.ColumnMakerPsn.DataPropertyName = "MakerPsn";
            this.ColumnMakerPsn.HeaderText = "制单人";
            this.ColumnMakerPsn.Name = "ColumnMakerPsn";
            this.ColumnMakerPsn.ReadOnly = true;
            this.ColumnMakerPsn.Width = 66;
            // 
            // ColumnDeliverAddress
            // 
            this.ColumnDeliverAddress.DataPropertyName = "DeliverAddress";
            this.ColumnDeliverAddress.HeaderText = "送货地";
            this.ColumnDeliverAddress.Name = "ColumnDeliverAddress";
            this.ColumnDeliverAddress.ReadOnly = true;
            this.ColumnDeliverAddress.Width = 180;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.ReadOnly = true;
            // 
            // FrmSaleDeliverAlter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 505);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSaleDeliverAlter";
            this.Text = "FrmSaleDeliverAlter";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.CheckBox ckbNoteCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNoteCode;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.CheckBox ckbCustomer;
        private System.Windows.Forms.CheckBox ckbDateNote;
        private JERPApp.Define.General.CtrlCustomer ctrlCompanyID;
        private System.Windows.Forms.Panel panel2;
        private JCommon.PagebreakNav pbar;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnAlter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNoteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyAbbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPONo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMakerPsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeliverAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
    }
}