namespace JERPApp.Common.Report
{
    partial class FrmDiary
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckbPsnFlag = new System.Windows.Forms.CheckBox();
            this.ctrlPsnID = new JERPApp.Define.Hr.CtrlPersonnel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ctrlBetweenDate = new JCommon.CtrlBetweenDate();
            this.label1 = new System.Windows.Forms.Label();
            this.ckbDateReportFlag = new System.Windows.Forms.CheckBox();
            this.ckbDiaryTitleFlag = new System.Windows.Forms.CheckBox();
            this.txtDiaryTitle = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pbar = new JCommon.PagebreakNav();
            this.dgrdv = new JCommon.MyDataGridView();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnbtnDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnDateDiary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDiaryTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDiaryTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPsnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCloseFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ctrlDiaryTypeID = new JERPApp.Define.General.CtrlDiaryType();
            this.ckbDiaryTypeFlag = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlDiaryTypeID);
            this.panel1.Controls.Add(this.ckbDiaryTypeFlag);
            this.panel1.Controls.Add(this.ckbPsnFlag);
            this.panel1.Controls.Add(this.ctrlPsnID);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.ctrlBetweenDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ckbDateReportFlag);
            this.panel1.Controls.Add(this.ckbDiaryTitleFlag);
            this.panel1.Controls.Add(this.txtDiaryTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 68);
            this.panel1.TabIndex = 0;
            // 
            // ckbPsnFlag
            // 
            this.ckbPsnFlag.AutoSize = true;
            this.ckbPsnFlag.Location = new System.Drawing.Point(541, 43);
            this.ckbPsnFlag.Name = "ckbPsnFlag";
            this.ckbPsnFlag.Size = new System.Drawing.Size(48, 16);
            this.ckbPsnFlag.TabIndex = 6;
            this.ckbPsnFlag.Text = "姓名";
            this.ckbPsnFlag.UseVisualStyleBackColor = true;
            // 
            // ctrlPsnID
            // 
            this.ctrlPsnID.AutoSize = true;
            this.ctrlPsnID.Location = new System.Drawing.Point(595, 38);
            this.ctrlPsnID.Name = "ctrlPsnID";
            this.ctrlPsnID.PsnID = -1;
            this.ctrlPsnID.Size = new System.Drawing.Size(114, 23);
            this.ctrlPsnID.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(720, 36);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(52, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // ctrlBetweenDate
            // 
            this.ctrlBetweenDate.DateBegin = new System.DateTime(2014, 11, 24, 0, 0, 0, 0);
            this.ctrlBetweenDate.DateEnd = new System.DateTime(2014, 11, 24, 0, 0, 0, 0);
            this.ctrlBetweenDate.Location = new System.Drawing.Point(219, 36);
            this.ctrlBetweenDate.Name = "ctrlBetweenDate";
            this.ctrlBetweenDate.Size = new System.Drawing.Size(323, 29);
            this.ctrlBetweenDate.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(370, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "日志记录";
            // 
            // ckbDateReportFlag
            // 
            this.ckbDateReportFlag.AutoSize = true;
            this.ckbDateReportFlag.Location = new System.Drawing.Point(199, 46);
            this.ckbDateReportFlag.Name = "ckbDateReportFlag";
            this.ckbDateReportFlag.Size = new System.Drawing.Size(15, 14);
            this.ckbDateReportFlag.TabIndex = 2;
            this.ckbDateReportFlag.UseVisualStyleBackColor = true;
            // 
            // ckbDiaryTitleFlag
            // 
            this.ckbDiaryTitleFlag.AutoSize = true;
            this.ckbDiaryTitleFlag.Location = new System.Drawing.Point(5, 17);
            this.ckbDiaryTitleFlag.Name = "ckbDiaryTitleFlag";
            this.ckbDiaryTitleFlag.Size = new System.Drawing.Size(48, 16);
            this.ckbDiaryTitleFlag.TabIndex = 0;
            this.ckbDiaryTitleFlag.Text = "标题";
            this.ckbDiaryTitleFlag.UseVisualStyleBackColor = true;
            // 
            // txtDiaryTitle
            // 
            this.txtDiaryTitle.Location = new System.Drawing.Point(59, 12);
            this.txtDiaryTitle.Name = "txtDiaryTitle";
            this.txtDiaryTitle.Size = new System.Drawing.Size(131, 21);
            this.txtDiaryTitle.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pbar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 463);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(780, 27);
            this.panel3.TabIndex = 4;
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
            this.pbar.TabIndex = 0;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnDetail,
            this.ColumnDateDiary,
            this.ColumnDiaryTypeName,
            this.ColumnDiaryTitle,
            this.ColumnPsnName,
            this.ColumnCloseFlag});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 68);
            this.dgrdv.Name = "dgrdv";
            this.dgrdv.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(780, 395);
            this.dgrdv.TabIndex = 5;
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
            // ColumnbtnDetail
            // 
            this.ColumnbtnDetail.HeaderText = "详细";
            this.ColumnbtnDetail.Name = "ColumnbtnDetail";
            this.ColumnbtnDetail.ReadOnly = true;
            this.ColumnbtnDetail.Text = "详细";
            this.ColumnbtnDetail.UseColumnTextForButtonValue = true;
            this.ColumnbtnDetail.Width = 66;
            // 
            // ColumnDateDiary
            // 
            this.ColumnDateDiary.DataPropertyName = "DateDiary";
            this.ColumnDateDiary.HeaderText = "日期";
            this.ColumnDateDiary.Name = "ColumnDateDiary";
            this.ColumnDateDiary.ReadOnly = true;
            // 
            // ColumnDiaryTypeName
            // 
            this.ColumnDiaryTypeName.DataPropertyName = "DiaryTypeName";
            this.ColumnDiaryTypeName.HeaderText = "类型";
            this.ColumnDiaryTypeName.Name = "ColumnDiaryTypeName";
            this.ColumnDiaryTypeName.ReadOnly = true;
            this.ColumnDiaryTypeName.Width = 80;
            // 
            // ColumnDiaryTitle
            // 
            this.ColumnDiaryTitle.DataPropertyName = "DiaryTitle";
            this.ColumnDiaryTitle.HeaderText = "标题";
            this.ColumnDiaryTitle.Name = "ColumnDiaryTitle";
            this.ColumnDiaryTitle.ReadOnly = true;
            this.ColumnDiaryTitle.Width = 200;
            // 
            // ColumnPsnName
            // 
            this.ColumnPsnName.DataPropertyName = "PsnName";
            this.ColumnPsnName.HeaderText = "姓名";
            this.ColumnPsnName.Name = "ColumnPsnName";
            this.ColumnPsnName.ReadOnly = true;
            this.ColumnPsnName.Width = 66;
            // 
            // ColumnCloseFlag
            // 
            this.ColumnCloseFlag.DataPropertyName = "CloseFlag";
            this.ColumnCloseFlag.HeaderText = "关闭";
            this.ColumnCloseFlag.Name = "ColumnCloseFlag";
            this.ColumnCloseFlag.ReadOnly = true;
            this.ColumnCloseFlag.Width = 54;
            // 
            // ctrlDiaryTypeID
            // 
            this.ctrlDiaryTypeID.AutoSize = true;
            this.ctrlDiaryTypeID.DiaryTypeID = 1;
            this.ctrlDiaryTypeID.Location = new System.Drawing.Point(59, 40);
            this.ctrlDiaryTypeID.Name = "ctrlDiaryTypeID";
            this.ctrlDiaryTypeID.Size = new System.Drawing.Size(131, 23);
            this.ctrlDiaryTypeID.TabIndex = 10;
            // 
            // ckbDiaryTypeFlag
            // 
            this.ckbDiaryTypeFlag.AutoSize = true;
            this.ckbDiaryTypeFlag.Location = new System.Drawing.Point(6, 44);
            this.ckbDiaryTypeFlag.Name = "ckbDiaryTypeFlag";
            this.ckbDiaryTypeFlag.Size = new System.Drawing.Size(48, 16);
            this.ckbDiaryTypeFlag.TabIndex = 9;
            this.ckbDiaryTypeFlag.Text = "类型";
            this.ckbDiaryTypeFlag.UseVisualStyleBackColor = true;
            // 
            // FrmDiary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 490);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "FrmDiary";
            this.Text = "FrmDiary";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private JCommon.CtrlBetweenDate ctrlBetweenDate;
        private System.Windows.Forms.CheckBox ckbDateReportFlag;
        private System.Windows.Forms.CheckBox ckbDiaryTitleFlag;
        private System.Windows.Forms.TextBox txtDiaryTitle;
        private System.Windows.Forms.Panel panel3;
        private JCommon.PagebreakNav pbar;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.CheckBox ckbPsnFlag;
        private JERPApp.Define.Hr.CtrlPersonnel ctrlPsnID;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateDiary;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDiaryTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDiaryTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPsnName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCloseFlag;
        private JERPApp.Define.General.CtrlDiaryType ctrlDiaryTypeID;
        private System.Windows.Forms.CheckBox ckbDiaryTypeFlag;
    }
}