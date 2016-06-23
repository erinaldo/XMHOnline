namespace JERPApp.Common
{
    partial class FrmMeeting
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.lnkNew = new System.Windows.Forms.LinkLabel();
            this.ctrlBetweenDate = new JCommon.CtrlBetweenDate();
            this.label1 = new System.Windows.Forms.Label();
            this.ckbDateReportFlag = new System.Windows.Forms.CheckBox();
            this.ckbMeetingTitleFlag = new System.Windows.Forms.CheckBox();
            this.txtReportTitle = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pbar = new JCommon.PagebreakNav();
            this.dgrdv = new JCommon.MyDataGridView();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnbtnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnDateMeeting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMeetingTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMeetingPsns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMeetingContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.lnkNew);
            this.panel1.Controls.Add(this.ctrlBetweenDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ckbDateReportFlag);
            this.panel1.Controls.Add(this.ckbMeetingTitleFlag);
            this.panel1.Controls.Add(this.txtReportTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 68);
            this.panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(619, 36);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // lnkNew
            // 
            this.lnkNew.AutoSize = true;
            this.lnkNew.Location = new System.Drawing.Point(700, 44);
            this.lnkNew.Name = "lnkNew";
            this.lnkNew.Size = new System.Drawing.Size(53, 12);
            this.lnkNew.TabIndex = 1;
            this.lnkNew.TabStop = true;
            this.lnkNew.Text = "新增会议";
            // 
            // ctrlBetweenDate
            // 
            this.ctrlBetweenDate.DateBegin = new System.DateTime(2014, 11, 24, 0, 0, 0, 0);
            this.ctrlBetweenDate.DateEnd = new System.DateTime(2014, 11, 24, 0, 0, 0, 0);
            this.ctrlBetweenDate.Location = new System.Drawing.Point(290, 36);
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
            this.label1.Text = "会议记录";
            // 
            // ckbDateReportFlag
            // 
            this.ckbDateReportFlag.AutoSize = true;
            this.ckbDateReportFlag.Location = new System.Drawing.Point(236, 46);
            this.ckbDateReportFlag.Name = "ckbDateReportFlag";
            this.ckbDateReportFlag.Size = new System.Drawing.Size(48, 16);
            this.ckbDateReportFlag.TabIndex = 2;
            this.ckbDateReportFlag.Text = "日期";
            this.ckbDateReportFlag.UseVisualStyleBackColor = true;
            // 
            // ckbMeetingTitleFlag
            // 
            this.ckbMeetingTitleFlag.AutoSize = true;
            this.ckbMeetingTitleFlag.Location = new System.Drawing.Point(3, 46);
            this.ckbMeetingTitleFlag.Name = "ckbMeetingTitleFlag";
            this.ckbMeetingTitleFlag.Size = new System.Drawing.Size(48, 16);
            this.ckbMeetingTitleFlag.TabIndex = 0;
            this.ckbMeetingTitleFlag.Text = "主题";
            this.ckbMeetingTitleFlag.UseVisualStyleBackColor = true;
            // 
            // txtReportTitle
            // 
            this.txtReportTitle.Location = new System.Drawing.Point(57, 41);
            this.txtReportTitle.Name = "txtReportTitle";
            this.txtReportTitle.Size = new System.Drawing.Size(173, 21);
            this.txtReportTitle.TabIndex = 1;
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
            this.pbar.PageIndex = 0;
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
            this.ColumnbtnEdit,
            this.ColumnDateMeeting,
            this.ColumnMeetingTitle,
            this.ColumnMeetingPsns,
            this.ColumnMeetingContent});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 68);
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
            // ColumnbtnEdit
            // 
            this.ColumnbtnEdit.HeaderText = "变更";
            this.ColumnbtnEdit.Name = "ColumnbtnEdit";
            this.ColumnbtnEdit.ReadOnly = true;
            this.ColumnbtnEdit.Text = "变更";
            this.ColumnbtnEdit.UseColumnTextForButtonValue = true;
            this.ColumnbtnEdit.Width = 66;
            // 
            // ColumnDateMeeting
            // 
            this.ColumnDateMeeting.DataPropertyName = "DateMeeting";
            this.ColumnDateMeeting.HeaderText = "日期";
            this.ColumnDateMeeting.Name = "ColumnDateMeeting";
            this.ColumnDateMeeting.ReadOnly = true;
            // 
            // ColumnMeetingTitle
            // 
            this.ColumnMeetingTitle.DataPropertyName = "MeetingTitle";
            this.ColumnMeetingTitle.HeaderText = "主题";
            this.ColumnMeetingTitle.Name = "ColumnMeetingTitle";
            this.ColumnMeetingTitle.ReadOnly = true;
            this.ColumnMeetingTitle.Width = 200;
            // 
            // ColumnMeetingPsns
            // 
            this.ColumnMeetingPsns.DataPropertyName = "MeetingPsns";
            this.ColumnMeetingPsns.HeaderText = "与会";
            this.ColumnMeetingPsns.Name = "ColumnMeetingPsns";
            this.ColumnMeetingPsns.ReadOnly = true;
            // 
            // ColumnMeetingContent
            // 
            this.ColumnMeetingContent.DataPropertyName = "MeetingContent";
            this.ColumnMeetingContent.HeaderText = "内容";
            this.ColumnMeetingContent.Name = "ColumnMeetingContent";
            this.ColumnMeetingContent.ReadOnly = true;
            this.ColumnMeetingContent.Width = 250;
            // 
            // FrmMeeting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 490);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMeeting";
            this.Text = "FrmMeeting";
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
        private System.Windows.Forms.LinkLabel lnkNew;
        private System.Windows.Forms.Button btnSearch;
        private JCommon.CtrlBetweenDate ctrlBetweenDate;
        private System.Windows.Forms.CheckBox ckbDateReportFlag;
        private System.Windows.Forms.CheckBox ckbMeetingTitleFlag;
        private System.Windows.Forms.TextBox txtReportTitle;
        private System.Windows.Forms.Panel panel3;
        private JCommon.PagebreakNav pbar;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateMeeting;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMeetingTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMeetingPsns;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMeetingContent;
    }
}