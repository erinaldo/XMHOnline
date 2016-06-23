namespace JERPApp.Service.Report
{
    partial class FrmRepairItemRecord
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ctrlCompanyID = new JERPApp.Define.General.CtrlCustomer();
            this.ckbCustomer = new System.Windows.Forms.CheckBox();
            this.dtpDeliverEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDeliverBegin = new System.Windows.Forms.DateTimePicker();
            this.ckbDateDeliver = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExplore = new System.Windows.Forms.Button();
            this.dgrdv = new JCommon.MyDataGridView();
            this.dtpReceiveEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpReceiveBegin = new System.Windows.Forms.DateTimePicker();
            this.ckbDateReceive = new System.Windows.Forms.CheckBox();
            this.ctrlPrdID = new JERPApp.Define.Product.CtrlFinishedPrd();
            this.ckbPrd = new System.Windows.Forms.CheckBox();
            this.pbar = new JCommon.PagebreakNav();
            this.ColumnDateReceive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateDeliver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDeliverNoteCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCompanyAbbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRepairPsns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRepairStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateFinished = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlPrdID);
            this.panel1.Controls.Add(this.ckbPrd);
            this.panel1.Controls.Add(this.dtpReceiveEnd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpReceiveBegin);
            this.panel1.Controls.Add(this.ckbDateReceive);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.ctrlCompanyID);
            this.panel1.Controls.Add(this.ckbCustomer);
            this.panel1.Controls.Add(this.dtpDeliverEnd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpDeliverBegin);
            this.panel1.Controls.Add(this.ckbDateDeliver);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 59);
            this.panel1.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(909, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // ctrlCompanyID
            // 
            this.ctrlCompanyID.CompanyID = 1;
            this.ctrlCompanyID.Location = new System.Drawing.Point(761, 30);
            this.ctrlCompanyID.Name = "ctrlCompanyID";
            this.ctrlCompanyID.Size = new System.Drawing.Size(116, 23);
            this.ctrlCompanyID.TabIndex = 8;
            // 
            // ckbCustomer
            // 
            this.ckbCustomer.AutoSize = true;
            this.ckbCustomer.Location = new System.Drawing.Point(700, 35);
            this.ckbCustomer.Name = "ckbCustomer";
            this.ckbCustomer.Size = new System.Drawing.Size(48, 16);
            this.ckbCustomer.TabIndex = 7;
            this.ckbCustomer.Text = "客户";
            this.ckbCustomer.UseVisualStyleBackColor = true;
            // 
            // dtpDeliverEnd
            // 
            this.dtpDeliverEnd.Location = new System.Drawing.Point(870, 3);
            this.dtpDeliverEnd.Name = "dtpDeliverEnd";
            this.dtpDeliverEnd.Size = new System.Drawing.Size(142, 21);
            this.dtpDeliverEnd.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(847, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "到";
            // 
            // dtpDeliverBegin
            // 
            this.dtpDeliverBegin.Location = new System.Drawing.Point(698, 2);
            this.dtpDeliverBegin.Name = "dtpDeliverBegin";
            this.dtpDeliverBegin.Size = new System.Drawing.Size(142, 21);
            this.dtpDeliverBegin.TabIndex = 4;
            // 
            // ckbDateDeliver
            // 
            this.ckbDateDeliver.AutoSize = true;
            this.ckbDateDeliver.Location = new System.Drawing.Point(619, 8);
            this.ckbDateDeliver.Name = "ckbDateDeliver";
            this.ckbDateDeliver.Size = new System.Drawing.Size(72, 16);
            this.ckbDateDeliver.TabIndex = 3;
            this.ckbDateDeliver.Text = "送货日期";
            this.ckbDateDeliver.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(473, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "维修记录";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pbar);
            this.panel2.Controls.Add(this.btnExplore);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 571);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1015, 29);
            this.panel2.TabIndex = 8;
            // 
            // btnExplore
            // 
            this.btnExplore.Location = new System.Drawing.Point(886, 1);
            this.btnExplore.Name = "btnExplore";
            this.btnExplore.Size = new System.Drawing.Size(77, 25);
            this.btnExplore.TabIndex = 4;
            this.btnExplore.Text = "输出打印";
            this.btnExplore.UseVisualStyleBackColor = true;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDateReceive,
            this.ColumnDateDeliver,
            this.ColumnDeliverNoteCode,
            this.ColumnCompanyAbbName,
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnAmount,
            this.ColumnMemo,
            this.ColumnRepairPsns,
            this.ColumnRepairStatus,
            this.ColumnDateFinished});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 59);
            this.dgrdv.Name = "dgrdv";
            this.dgrdv.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(1015, 512);
            this.dgrdv.TabIndex = 9;
            // 
            // dtpReceiveEnd
            // 
            this.dtpReceiveEnd.Location = new System.Drawing.Point(262, 4);
            this.dtpReceiveEnd.Name = "dtpReceiveEnd";
            this.dtpReceiveEnd.Size = new System.Drawing.Size(142, 21);
            this.dtpReceiveEnd.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "到";
            // 
            // dtpReceiveBegin
            // 
            this.dtpReceiveBegin.Location = new System.Drawing.Point(90, 3);
            this.dtpReceiveBegin.Name = "dtpReceiveBegin";
            this.dtpReceiveBegin.Size = new System.Drawing.Size(142, 21);
            this.dtpReceiveBegin.TabIndex = 11;
            // 
            // ckbDateReceive
            // 
            this.ckbDateReceive.AutoSize = true;
            this.ckbDateReceive.Checked = true;
            this.ckbDateReceive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbDateReceive.Location = new System.Drawing.Point(11, 9);
            this.ckbDateReceive.Name = "ckbDateReceive";
            this.ckbDateReceive.Size = new System.Drawing.Size(72, 16);
            this.ckbDateReceive.TabIndex = 10;
            this.ckbDateReceive.Text = "接单日期";
            this.ckbDateReceive.UseVisualStyleBackColor = true;
            // 
            // ctrlPrdID
            // 
            this.ctrlPrdID.AutoSize = true;
            this.ctrlPrdID.Location = new System.Drawing.Point(63, 27);
            this.ctrlPrdID.Name = "ctrlPrdID";
            this.ctrlPrdID.PrdID = -1;
            this.ctrlPrdID.Size = new System.Drawing.Size(631, 29);
            this.ctrlPrdID.TabIndex = 15;
            // 
            // ckbPrd
            // 
            this.ckbPrd.AutoSize = true;
            this.ckbPrd.Location = new System.Drawing.Point(9, 33);
            this.ckbPrd.Name = "ckbPrd";
            this.ckbPrd.Size = new System.Drawing.Size(48, 16);
            this.ckbPrd.TabIndex = 14;
            this.ckbPrd.Text = "产品";
            this.ckbPrd.UseVisualStyleBackColor = true;
            // 
            // pbar
            // 
            this.pbar.AutoSize = true;
            this.pbar.Location = new System.Drawing.Point(7, 2);
            this.pbar.Name = "pbar";
            this.pbar.PageInBlock = 10;
            this.pbar.PageIndex = 0;
            this.pbar.PageSize = 100;
            this.pbar.Size = new System.Drawing.Size(406, 27);
            this.pbar.TabIndex = 5;
            // 
            // ColumnDateReceive
            // 
            this.ColumnDateReceive.DataPropertyName = "DateReceive";
            this.ColumnDateReceive.HeaderText = "接单日期";
            this.ColumnDateReceive.Name = "ColumnDateReceive";
            this.ColumnDateReceive.ReadOnly = true;
            this.ColumnDateReceive.Width = 80;
            // 
            // ColumnDateDeliver
            // 
            this.ColumnDateDeliver.DataPropertyName = "DateDeliver";
            this.ColumnDateDeliver.HeaderText = "送货日期";
            this.ColumnDateDeliver.Name = "ColumnDateDeliver";
            this.ColumnDateDeliver.ReadOnly = true;
            this.ColumnDateDeliver.Width = 80;
            // 
            // ColumnDeliverNoteCode
            // 
            this.ColumnDeliverNoteCode.DataPropertyName = "DeliverNoteCode";
            this.ColumnDeliverNoteCode.HeaderText = "送货单号";
            this.ColumnDeliverNoteCode.Name = "ColumnDeliverNoteCode";
            this.ColumnDeliverNoteCode.ReadOnly = true;
            this.ColumnDeliverNoteCode.Width = 80;
            // 
            // ColumnCompanyAbbName
            // 
            this.ColumnCompanyAbbName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnCompanyAbbName.DataPropertyName = "CompanyAbbName";
            this.ColumnCompanyAbbName.HeaderText = "客户";
            this.ColumnCompanyAbbName.Name = "ColumnCompanyAbbName";
            this.ColumnCompanyAbbName.ReadOnly = true;
            this.ColumnCompanyAbbName.Width = 66;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.HeaderText = "产品编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.ReadOnly = true;
            this.ColumnPrdCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnPrdCode.Width = 80;
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.HeaderText = "产品名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            this.ColumnPrdName.ReadOnly = true;
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdSpec.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnPrdSpec.HeaderText = "产品规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            this.ColumnPrdSpec.ReadOnly = true;
            this.ColumnPrdSpec.Width = 80;
            // 
            // ColumnModel
            // 
            this.ColumnModel.DataPropertyName = "Model";
            this.ColumnModel.HeaderText = "机型";
            this.ColumnModel.Name = "ColumnModel";
            this.ColumnModel.ReadOnly = true;
            this.ColumnModel.Width = 80;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.DataPropertyName = "Amount";
            this.ColumnAmount.HeaderText = "金额";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.ReadOnly = true;
            this.ColumnAmount.Width = 66;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.ReadOnly = true;
            // 
            // ColumnRepairPsns
            // 
            this.ColumnRepairPsns.DataPropertyName = "RepairPsns";
            this.ColumnRepairPsns.HeaderText = "维修人员";
            this.ColumnRepairPsns.Name = "ColumnRepairPsns";
            this.ColumnRepairPsns.ReadOnly = true;
            this.ColumnRepairPsns.Width = 80;
            // 
            // ColumnRepairStatus
            // 
            this.ColumnRepairStatus.DataPropertyName = "RepairStatus";
            this.ColumnRepairStatus.HeaderText = "维修状态";
            this.ColumnRepairStatus.Name = "ColumnRepairStatus";
            this.ColumnRepairStatus.ReadOnly = true;
            // 
            // ColumnDateFinished
            // 
            this.ColumnDateFinished.DataPropertyName = "DateFinished";
            this.ColumnDateFinished.HeaderText = "完成日期";
            this.ColumnDateFinished.Name = "ColumnDateFinished";
            this.ColumnDateFinished.ReadOnly = true;
            this.ColumnDateFinished.Width = 80;
            // 
            // FrmRepairItemRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 600);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmRepairItemRecord";
            this.Text = "FrmRepairItemRecord";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExplore;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Button btnSearch;
        private JERPApp.Define.General.CtrlCustomer ctrlCompanyID;
        private System.Windows.Forms.CheckBox ckbCustomer;
        private System.Windows.Forms.DateTimePicker dtpDeliverEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDeliverBegin;
        private System.Windows.Forms.CheckBox ckbDateDeliver;
        private System.Windows.Forms.DateTimePicker dtpReceiveEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpReceiveBegin;
        private System.Windows.Forms.CheckBox ckbDateReceive;
        private JERPApp.Define.Product.CtrlFinishedPrd ctrlPrdID;
        private System.Windows.Forms.CheckBox ckbPrd;
        private JCommon.PagebreakNav pbar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateReceive;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateDeliver;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeliverNoteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompanyAbbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRepairPsns;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRepairStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateFinished;
    }
}