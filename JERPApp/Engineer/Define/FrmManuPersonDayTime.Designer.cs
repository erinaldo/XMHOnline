namespace JERPApp.Engineer.Define
{
    partial class FrmManuPersonDayTime
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlQFind = new JCommon.CtrlGridFind();
            this.chkProcess = new System.Windows.Forms.CheckBox();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.dgrdv = new JCommon.MyDataGridView();
            this.PsnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PsnCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PsnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.OtherTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnProcessDetails = new System.Windows.Forms.DataGridViewButtonColumn();
            this.WorkingMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpDateManuf = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlQFind);
            this.panel1.Controls.Add(this.chkProcess);
            this.panel1.Controls.Add(this.btnCancle);
            this.panel1.Controls.Add(this.btnAddPerson);
            this.panel1.Controls.Add(this.dgrdv);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.dtpDateManuf);
            this.panel1.Location = new System.Drawing.Point(4, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 641);
            this.panel1.TabIndex = 2;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(3, 609);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(296, 21);
            this.ctrlQFind.TabIndex = 7;
            // 
            // chkProcess
            // 
            this.chkProcess.AutoSize = true;
            this.chkProcess.Location = new System.Drawing.Point(471, 12);
            this.chkProcess.Name = "chkProcess";
            this.chkProcess.Size = new System.Drawing.Size(72, 16);
            this.chkProcess.TabIndex = 6;
            this.chkProcess.Text = "明细工序";
            this.chkProcess.UseVisualStyleBackColor = true;
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(631, 609);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 5;
            this.btnCancle.Text = "关闭";
            this.btnCancle.UseVisualStyleBackColor = true;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPerson.Location = new System.Drawing.Point(205, 8);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(75, 23);
            this.btnAddPerson.TabIndex = 4;
            this.btnAddPerson.Text = "选择人员";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PsnID,
            this.PsnCode,
            this.PsnName,
            this.WorkType,
            this.WorkTime,
            this.OtherTime,
            this.TotalTime,
            this.btnProcessDetails,
            this.WorkingMemo});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Location = new System.Drawing.Point(8, 37);
            this.dgrdv.Name = "dgrdv";
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
            this.dgrdv.Size = new System.Drawing.Size(775, 553);
            this.dgrdv.TabIndex = 3;
            // 
            // PsnID
            // 
            this.PsnID.DataPropertyName = "PsnID";
            this.PsnID.HeaderText = "员工ID";
            this.PsnID.Name = "PsnID";
            this.PsnID.Visible = false;
            // 
            // PsnCode
            // 
            this.PsnCode.DataPropertyName = "PsnCode";
            this.PsnCode.HeaderText = "工号";
            this.PsnCode.Name = "PsnCode";
            // 
            // PsnName
            // 
            this.PsnName.DataPropertyName = "PsnName";
            this.PsnName.HeaderText = "姓名";
            this.PsnName.Name = "PsnName";
            // 
            // WorkType
            // 
            this.WorkType.DataPropertyName = "WorkType";
            this.WorkType.HeaderText = "班组";
            this.WorkType.Name = "WorkType";
            this.WorkType.Visible = false;
            // 
            // WorkTime
            // 
            this.WorkTime.ContextMenuStrip = this.cMenu;
            this.WorkTime.DataPropertyName = "WorkTime";
            this.WorkTime.HeaderText = "工作时间(分)";
            this.WorkTime.Name = "WorkTime";
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
            // OtherTime
            // 
            this.OtherTime.DataPropertyName = "OtherTime";
            this.OtherTime.HeaderText = "其它耗时";
            this.OtherTime.Name = "OtherTime";
            this.OtherTime.Visible = false;
            // 
            // TotalTime
            // 
            this.TotalTime.DataPropertyName = "TotalTime";
            this.TotalTime.HeaderText = "总工作时间";
            this.TotalTime.Name = "TotalTime";
            this.TotalTime.Visible = false;
            // 
            // btnProcessDetails
            // 
            this.btnProcessDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessDetails.HeaderText = "工序明细";
            this.btnProcessDetails.Name = "btnProcessDetails";
            this.btnProcessDetails.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnProcessDetails.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnProcessDetails.Text = "编辑";
            this.btnProcessDetails.UseColumnTextForButtonValue = true;
            // 
            // WorkingMemo
            // 
            this.WorkingMemo.DataPropertyName = "WorkingMemo";
            this.WorkingMemo.HeaderText = "备注";
            this.WorkingMemo.Name = "WorkingMemo";
            this.WorkingMemo.Width = 300;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(431, 607);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // dtpDateManuf
            // 
            this.dtpDateManuf.Location = new System.Drawing.Point(28, 10);
            this.dtpDateManuf.Name = "dtpDateManuf";
            this.dtpDateManuf.Size = new System.Drawing.Size(149, 21);
            this.dtpDateManuf.TabIndex = 2;
            this.dtpDateManuf.ValueChanged += new System.EventHandler(this.dtpDateManuf_ValueChanged);
            // 
            // FrmManuPersonDayTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 648);
            this.Controls.Add(this.panel1);
            this.Name = "FrmManuPersonDayTime";
            this.Text = "人员日产能计划表";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddPerson;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DateTimePicker dtpDateManuf;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.CheckBox chkProcess;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private JCommon.CtrlGridFind ctrlQFind;
        private System.Windows.Forms.DataGridViewTextBoxColumn PsnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PsnCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PsnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkType;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn OtherTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalTime;
        private System.Windows.Forms.DataGridViewButtonColumn btnProcessDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkingMemo;
    }
}