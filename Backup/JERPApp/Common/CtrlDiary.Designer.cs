namespace JERPApp.Common
{
    partial class CtrlDiary
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnDateDiary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDiaryTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDiaryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radClose = new System.Windows.Forms.RadioButton();
            this.radNonClose = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rchDiaryContent = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctrlFileBrowse = new JCommon.CtrlFileBrowse();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtpDateDiary = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInfor = new System.Windows.Forms.Label();
            this.ckbCloseFlag = new System.Windows.Forms.CheckBox();
            this.txtDiaryTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgrdv);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(914, 587);
            this.splitContainer1.SplitterDistance = 269;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDateDiary,
            this.ColumnDiaryTitle,
            this.ColumnDiaryID});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 33);
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
            this.dgrdv.RowHeadersWidth = 20;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(269, 524);
            this.dgrdv.TabIndex = 2;
            // 
            // ColumnDateDiary
            // 
            this.ColumnDateDiary.DataPropertyName = "DateDiary";
            this.ColumnDateDiary.HeaderText = "日期";
            this.ColumnDateDiary.Name = "ColumnDateDiary";
            this.ColumnDateDiary.ReadOnly = true;
            this.ColumnDateDiary.Width = 80;
            // 
            // ColumnDiaryTitle
            // 
            this.ColumnDiaryTitle.DataPropertyName = "DiaryTitle";
            this.ColumnDiaryTitle.HeaderText = "标题";
            this.ColumnDiaryTitle.Name = "ColumnDiaryTitle";
            this.ColumnDiaryTitle.ReadOnly = true;
            this.ColumnDiaryTitle.Width = 150;
            // 
            // ColumnDiaryID
            // 
            this.ColumnDiaryID.DataPropertyName = "DiaryID";
            this.ColumnDiaryID.HeaderText = "DiaryID";
            this.ColumnDiaryID.Name = "ColumnDiaryID";
            this.ColumnDiaryID.ReadOnly = true;
            this.ColumnDiaryID.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 557);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(269, 30);
            this.panel2.TabIndex = 1;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(3, 6);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(244, 21);
            this.ctrlQFind.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radClose);
            this.panel1.Controls.Add(this.radNonClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 33);
            this.panel1.TabIndex = 0;
            // 
            // radClose
            // 
            this.radClose.AutoSize = true;
            this.radClose.Location = new System.Drawing.Point(129, 6);
            this.radClose.Name = "radClose";
            this.radClose.Size = new System.Drawing.Size(59, 16);
            this.radClose.TabIndex = 4;
            this.radClose.Text = "已解决";
            this.radClose.UseVisualStyleBackColor = true;
            // 
            // radNonClose
            // 
            this.radNonClose.AutoSize = true;
            this.radNonClose.Checked = true;
            this.radNonClose.Location = new System.Drawing.Point(64, 7);
            this.radNonClose.Name = "radNonClose";
            this.radNonClose.Size = new System.Drawing.Size(59, 16);
            this.radNonClose.TabIndex = 3;
            this.radNonClose.TabStop = true;
            this.radNonClose.Text = "未解决";
            this.radNonClose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "问题状态";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(641, 524);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rchDiaryContent);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(633, 498);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "内容";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rchDiaryContent
            // 
            this.rchDiaryContent.AcceptsTab = true;
            this.rchDiaryContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchDiaryContent.Location = new System.Drawing.Point(3, 3);
            this.rchDiaryContent.Name = "rchDiaryContent";
            this.rchDiaryContent.Size = new System.Drawing.Size(627, 492);
            this.rchDiaryContent.TabIndex = 2;
            this.rchDiaryContent.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctrlFileBrowse);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(633, 498);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "文件";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ctrlFileBrowse
            // 
            this.ctrlFileBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlFileBrowse.Location = new System.Drawing.Point(3, 3);
            this.ctrlFileBrowse.Name = "ctrlFileBrowse";
            this.ctrlFileBrowse.ReadOnly = false;
            this.ctrlFileBrowse.Size = new System.Drawing.Size(627, 492);
            this.ctrlFileBrowse.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnDelete);
            this.panel4.Controls.Add(this.btnNew);
            this.panel4.Controls.Add(this.btnSave);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 557);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(641, 30);
            this.panel4.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(517, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(436, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "新增";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(213, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtpDateDiary);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.lblInfor);
            this.panel3.Controls.Add(this.ckbCloseFlag);
            this.panel3.Controls.Add(this.txtDiaryTitle);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(641, 33);
            this.panel3.TabIndex = 0;
            // 
            // dtpDateDiary
            // 
            this.dtpDateDiary.Location = new System.Drawing.Point(350, 7);
            this.dtpDateDiary.Name = "dtpDateDiary";
            this.dtpDateDiary.Size = new System.Drawing.Size(106, 21);
            this.dtpDateDiary.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(319, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "日期";
            // 
            // lblInfor
            // 
            this.lblInfor.AutoSize = true;
            this.lblInfor.ForeColor = System.Drawing.Color.Blue;
            this.lblInfor.Location = new System.Drawing.Point(535, 12);
            this.lblInfor.Name = "lblInfor";
            this.lblInfor.Size = new System.Drawing.Size(59, 12);
            this.lblInfor.TabIndex = 3;
            this.lblInfor.Text = "编辑中...";
            // 
            // ckbCloseFlag
            // 
            this.ckbCloseFlag.AutoSize = true;
            this.ckbCloseFlag.Location = new System.Drawing.Point(459, 11);
            this.ckbCloseFlag.Name = "ckbCloseFlag";
            this.ckbCloseFlag.Size = new System.Drawing.Size(72, 16);
            this.ckbCloseFlag.TabIndex = 2;
            this.ckbCloseFlag.Text = "问题关闭";
            this.ckbCloseFlag.UseVisualStyleBackColor = true;
            // 
            // txtDiaryTitle
            // 
            this.txtDiaryTitle.Location = new System.Drawing.Point(40, 7);
            this.txtDiaryTitle.Name = "txtDiaryTitle";
            this.txtDiaryTitle.Size = new System.Drawing.Size(273, 21);
            this.txtDiaryTitle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "标题";
            // 
            // CtrlDiary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CtrlDiary";
            this.Size = new System.Drawing.Size(914, 587);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtDiaryTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckbCloseFlag;
        private System.Windows.Forms.RichTextBox rchDiaryContent;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblInfor;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DateTimePicker dtpDateDiary;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private JCommon.CtrlFileBrowse ctrlFileBrowse;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateDiary;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDiaryTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDiaryID;
        private System.Windows.Forms.RadioButton radClose;
        private System.Windows.Forms.RadioButton radNonClose;
    }
}