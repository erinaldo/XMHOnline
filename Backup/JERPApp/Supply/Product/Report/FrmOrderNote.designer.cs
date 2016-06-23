namespace JERPApp.Supply.Product.Report
{
    partial class FrmOrderNote
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
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.ckbDateNote = new System.Windows.Forms.CheckBox();
            this.txtNoteCode = new System.Windows.Forms.TextBox();
            this.ckbNoteCode = new System.Windows.Forms.CheckBox();
            this.ctrlSupplierID = new JERPApp.Define.General.CtrlSupplierForProduct();
            this.ckbSupplier = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckbStatus = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radNonConfirmFlag = new System.Windows.Forms.RadioButton();
            this.radNonFinishedFlag = new System.Windows.Forms.RadioButton();
            this.radFinishedFlag = new System.Windows.Forms.RadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pbar = new JCommon.PagebreakNav();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnlnkNoteCode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnConfirmPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ckbMakerPsn = new System.Windows.Forms.CheckBox();
            this.ctrlMakerPsnID = new JERPApp.Define.Hr.CtrlPersonnel();
            this.ctrlConfirmPsnID = new JERPApp.Define.Hr.CtrlPersonnel();
            this.ckbConfirmPsn = new System.Windows.Forms.CheckBox();
            this.panel7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ctrlConfirmPsnID);
            this.panel7.Controls.Add(this.ckbConfirmPsn);
            this.panel7.Controls.Add(this.ctrlMakerPsnID);
            this.panel7.Controls.Add(this.ckbMakerPsn);
            this.panel7.Controls.Add(this.groupBox1);
            this.panel7.Controls.Add(this.ckbStatus);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.btnSearch);
            this.panel7.Controls.Add(this.dtpDateEnd);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.dtpDateBegin);
            this.panel7.Controls.Add(this.ckbDateNote);
            this.panel7.Controls.Add(this.txtNoteCode);
            this.panel7.Controls.Add(this.ckbNoteCode);
            this.panel7.Controls.Add(this.ctrlSupplierID);
            this.panel7.Controls.Add(this.ckbSupplier);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(860, 101);
            this.panel7.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(695, 69);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Location = new System.Drawing.Point(644, 33);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(126, 21);
            this.dtpDateEnd.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(621, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "到";
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.Location = new System.Drawing.Point(489, 34);
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.Size = new System.Drawing.Size(126, 21);
            this.dtpDateBegin.TabIndex = 5;
            // 
            // ckbDateNote
            // 
            this.ckbDateNote.AutoSize = true;
            this.ckbDateNote.Location = new System.Drawing.Point(401, 37);
            this.ckbDateNote.Name = "ckbDateNote";
            this.ckbDateNote.Size = new System.Drawing.Size(90, 16);
            this.ckbDateNote.TabIndex = 4;
            this.ckbDateNote.Text = "下单日期 从";
            this.ckbDateNote.UseVisualStyleBackColor = true;
            // 
            // txtNoteCode
            // 
            this.txtNoteCode.Location = new System.Drawing.Point(260, 35);
            this.txtNoteCode.Name = "txtNoteCode";
            this.txtNoteCode.Size = new System.Drawing.Size(124, 21);
            this.txtNoteCode.TabIndex = 3;
            // 
            // ckbNoteCode
            // 
            this.ckbNoteCode.AutoSize = true;
            this.ckbNoteCode.Location = new System.Drawing.Point(187, 37);
            this.ckbNoteCode.Name = "ckbNoteCode";
            this.ckbNoteCode.Size = new System.Drawing.Size(72, 16);
            this.ckbNoteCode.TabIndex = 2;
            this.ckbNoteCode.Text = "订单编号";
            this.ckbNoteCode.UseVisualStyleBackColor = true;
            // 
            // ctrlSupplierID
            // 
            this.ctrlSupplierID.CompanyID = 1;
            this.ctrlSupplierID.Location = new System.Drawing.Point(57, 35);
            this.ctrlSupplierID.Name = "ctrlSupplierID";
            this.ctrlSupplierID.Size = new System.Drawing.Size(124, 23);
            this.ctrlSupplierID.TabIndex = 1;
            // 
            // ckbSupplier
            // 
            this.ckbSupplier.AutoSize = true;
            this.ckbSupplier.Location = new System.Drawing.Point(3, 38);
            this.ckbSupplier.Name = "ckbSupplier";
            this.ckbSupplier.Size = new System.Drawing.Size(60, 16);
            this.ckbSupplier.TabIndex = 0;
            this.ckbSupplier.Text = "供应商";
            this.ckbSupplier.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(389, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "产品采购订单";
            // 
            // ckbStatus
            // 
            this.ckbStatus.AutoSize = true;
            this.ckbStatus.Location = new System.Drawing.Point(401, 73);
            this.ckbStatus.Name = "ckbStatus";
            this.ckbStatus.Size = new System.Drawing.Size(48, 16);
            this.ckbStatus.TabIndex = 10;
            this.ckbStatus.Text = "状态";
            this.ckbStatus.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radFinishedFlag);
            this.groupBox1.Controls.Add(this.radNonFinishedFlag);
            this.groupBox1.Controls.Add(this.radNonConfirmFlag);
            this.groupBox1.Location = new System.Drawing.Point(476, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 35);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // radNonConfirmFlag
            // 
            this.radNonConfirmFlag.AutoSize = true;
            this.radNonConfirmFlag.Checked = true;
            this.radNonConfirmFlag.Location = new System.Drawing.Point(7, 15);
            this.radNonConfirmFlag.Name = "radNonConfirmFlag";
            this.radNonConfirmFlag.Size = new System.Drawing.Size(59, 16);
            this.radNonConfirmFlag.TabIndex = 0;
            this.radNonConfirmFlag.TabStop = true;
            this.radNonConfirmFlag.Text = "未审核";
            this.radNonConfirmFlag.UseVisualStyleBackColor = true;
            // 
            // radNonFinishedFlag
            // 
            this.radNonFinishedFlag.AutoSize = true;
            this.radNonFinishedFlag.Location = new System.Drawing.Point(68, 14);
            this.radNonFinishedFlag.Name = "radNonFinishedFlag";
            this.radNonFinishedFlag.Size = new System.Drawing.Size(59, 16);
            this.radNonFinishedFlag.TabIndex = 1;
            this.radNonFinishedFlag.Text = "未完成";
            this.radNonFinishedFlag.UseVisualStyleBackColor = true;
            // 
            // radFinishedFlag
            // 
            this.radFinishedFlag.AutoSize = true;
            this.radFinishedFlag.Location = new System.Drawing.Point(131, 14);
            this.radFinishedFlag.Name = "radFinishedFlag";
            this.radFinishedFlag.Size = new System.Drawing.Size(59, 16);
            this.radFinishedFlag.TabIndex = 2;
            this.radFinishedFlag.Text = "已完成";
            this.radFinishedFlag.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.pbar);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 480);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(860, 30);
            this.panel6.TabIndex = 7;
            // 
            // pbar
            // 
            this.pbar.AutoSize = true;
            this.pbar.Location = new System.Drawing.Point(3, 3);
            this.pbar.Name = "pbar";
            this.pbar.PageInBlock = 10;
            this.pbar.PageIndex = 1;
            this.pbar.PageSize = 30;
            this.pbar.Size = new System.Drawing.Size(406, 27);
            this.pbar.TabIndex = 3;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnlnkNoteCode,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.ColumnConfirmPsn,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 101);
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
            this.dgrdv.Size = new System.Drawing.Size(860, 379);
            this.dgrdv.TabIndex = 10;
            // 
            // ColumnlnkNoteCode
            // 
            this.ColumnlnkNoteCode.DataPropertyName = "NoteCode";
            this.ColumnlnkNoteCode.HeaderText = "订单编号";
            this.ColumnlnkNoteCode.Name = "ColumnlnkNoteCode";
            this.ColumnlnkNoteCode.ReadOnly = true;
            this.ColumnlnkNoteCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnlnkNoteCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "CompanyAbbName";
            this.dataGridViewTextBoxColumn14.HeaderText = "供应商";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "DateNote";
            this.dataGridViewTextBoxColumn15.HeaderText = "日期";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 80;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "MakerPsn";
            this.dataGridViewTextBoxColumn16.HeaderText = "制单人";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Width = 66;
            // 
            // ColumnConfirmPsn
            // 
            this.ColumnConfirmPsn.DataPropertyName = "ConfirmPsn";
            this.ColumnConfirmPsn.HeaderText = "审核人";
            this.ColumnConfirmPsn.Name = "ColumnConfirmPsn";
            this.ColumnConfirmPsn.ReadOnly = true;
            this.ColumnConfirmPsn.Width = 66;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "MoneyTypeName";
            this.dataGridViewTextBoxColumn17.HeaderText = "币种";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 54;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "SettleTypeName";
            this.dataGridViewTextBoxColumn18.HeaderText = "结算方式";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 78;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "PriceTypeName";
            this.dataGridViewTextBoxColumn19.HeaderText = "单价类型";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Width = 78;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "InvoiceTypeName";
            this.dataGridViewTextBoxColumn20.HeaderText = "发票类型";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Width = 80;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "DeliverAddress";
            this.dataGridViewTextBoxColumn21.HeaderText = "交货地";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.Width = 160;
            // 
            // ckbMakerPsn
            // 
            this.ckbMakerPsn.AutoSize = true;
            this.ckbMakerPsn.Location = new System.Drawing.Point(3, 73);
            this.ckbMakerPsn.Name = "ckbMakerPsn";
            this.ckbMakerPsn.Size = new System.Drawing.Size(60, 16);
            this.ckbMakerPsn.TabIndex = 12;
            this.ckbMakerPsn.Text = "制单人";
            this.ckbMakerPsn.UseVisualStyleBackColor = true;
            // 
            // ctrlMakerPsnID
            // 
            this.ctrlMakerPsnID.AutoSize = true;
            this.ctrlMakerPsnID.Location = new System.Drawing.Point(57, 68);
            this.ctrlMakerPsnID.Name = "ctrlMakerPsnID";
            this.ctrlMakerPsnID.PsnID = -1;
            this.ctrlMakerPsnID.Size = new System.Drawing.Size(124, 23);
            this.ctrlMakerPsnID.TabIndex = 13;
            // 
            // ctrlConfirmPsnID
            // 
            this.ctrlConfirmPsnID.AutoSize = true;
            this.ctrlConfirmPsnID.Location = new System.Drawing.Point(260, 66);
            this.ctrlConfirmPsnID.Name = "ctrlConfirmPsnID";
            this.ctrlConfirmPsnID.PsnID = -1;
            this.ctrlConfirmPsnID.Size = new System.Drawing.Size(124, 23);
            this.ctrlConfirmPsnID.TabIndex = 15;
            // 
            // ckbConfirmPsn
            // 
            this.ckbConfirmPsn.AutoSize = true;
            this.ckbConfirmPsn.Location = new System.Drawing.Point(187, 74);
            this.ckbConfirmPsn.Name = "ckbConfirmPsn";
            this.ckbConfirmPsn.Size = new System.Drawing.Size(60, 16);
            this.ckbConfirmPsn.TabIndex = 14;
            this.ckbConfirmPsn.Text = "审核人";
            this.ckbConfirmPsn.UseVisualStyleBackColor = true;
            // 
            // FrmOrderNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 510);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Name = "FrmOrderNote";
            this.Text = "FrmOrderNote";
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.CheckBox ckbDateNote;
        private System.Windows.Forms.TextBox txtNoteCode;
        private System.Windows.Forms.CheckBox ckbNoteCode;
        private JERPApp.Define.General.CtrlSupplierForProduct ctrlSupplierID;
        private System.Windows.Forms.CheckBox ckbSupplier;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radFinishedFlag;
        private System.Windows.Forms.RadioButton radNonFinishedFlag;
        private System.Windows.Forms.RadioButton radNonConfirmFlag;
        private System.Windows.Forms.CheckBox ckbStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private JCommon.PagebreakNav pbar;
        private System.Windows.Forms.CheckBox ckbMakerPsn;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnlnkNoteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnConfirmPsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private JERPApp.Define.Hr.CtrlPersonnel ctrlConfirmPsnID;
        private System.Windows.Forms.CheckBox ckbConfirmPsn;
        private JERPApp.Define.Hr.CtrlPersonnel ctrlMakerPsnID;
    }
}