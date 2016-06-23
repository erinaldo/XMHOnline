namespace JERPApp.Common
{
    partial class FrmMessageRecord
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckbDateMsg = new System.Windows.Forms.CheckBox();
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.ckbFromPsn = new System.Windows.Forms.CheckBox();
            this.ckbToPsn = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnDateMsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFromPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnToPsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMsgContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReceiveFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.btnExport = new System.Windows.Forms.Button();
            this.ctrlToPsnID = new JERPApp.Define.Hr.CtrlUserPsn();
            this.ctrlFromPsnID = new JERPApp.Define.Hr.CtrlUserPsn();
            this.ckbReceiveFlag = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radNoReceiveFlag = new System.Windows.Forms.RadioButton();
            this.radReceiveFlag = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.ckbReceiveFlag);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.ctrlToPsnID);
            this.panel1.Controls.Add(this.ckbToPsn);
            this.panel1.Controls.Add(this.ctrlFromPsnID);
            this.panel1.Controls.Add(this.ckbFromPsn);
            this.panel1.Controls.Add(this.dtpDateEnd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpDateBegin);
            this.panel1.Controls.Add(this.ckbDateMsg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 55);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 513);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(668, 27);
            this.panel2.TabIndex = 1;
            // 
            // ckbDateMsg
            // 
            this.ckbDateMsg.AutoSize = true;
            this.ckbDateMsg.Checked = true;
            this.ckbDateMsg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbDateMsg.Location = new System.Drawing.Point(3, 12);
            this.ckbDateMsg.Name = "ckbDateMsg";
            this.ckbDateMsg.Size = new System.Drawing.Size(48, 16);
            this.ckbDateMsg.TabIndex = 0;
            this.ckbDateMsg.Text = "日期";
            this.ckbDateMsg.UseVisualStyleBackColor = true;
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.CustomFormat = "yyyy-MM-dd hh:mm:s";
            this.dtpDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateBegin.Location = new System.Drawing.Point(58, 6);
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.Size = new System.Drawing.Size(153, 21);
            this.dtpDateBegin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "到";
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.CustomFormat = "yyyy-MM-dd hh:mm:s";
            this.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateEnd.Location = new System.Drawing.Point(256, 6);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(152, 21);
            this.dtpDateEnd.TabIndex = 3;
            // 
            // ckbFromPsn
            // 
            this.ckbFromPsn.AutoSize = true;
            this.ckbFromPsn.Location = new System.Drawing.Point(2, 38);
            this.ckbFromPsn.Name = "ckbFromPsn";
            this.ckbFromPsn.Size = new System.Drawing.Size(60, 16);
            this.ckbFromPsn.TabIndex = 4;
            this.ckbFromPsn.Text = "发送人";
            this.ckbFromPsn.UseVisualStyleBackColor = true;
            // 
            // ckbToPsn
            // 
            this.ckbToPsn.AutoSize = true;
            this.ckbToPsn.Location = new System.Drawing.Point(169, 38);
            this.ckbToPsn.Name = "ckbToPsn";
            this.ckbToPsn.Size = new System.Drawing.Size(60, 16);
            this.ckbToPsn.TabIndex = 6;
            this.ckbToPsn.Text = "接收人";
            this.ckbToPsn.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(482, 33);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDateMsg,
            this.ColumnFromPsn,
            this.ColumnToPsn,
            this.ColumnMsgContent,
            this.ColumnReceiveFlag});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 55);
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
            this.dgrdv.Size = new System.Drawing.Size(668, 458);
            this.dgrdv.TabIndex = 2;
            // 
            // ColumnDateMsg
            // 
            this.ColumnDateMsg.DataPropertyName = "DateMsg";
            dataGridViewCellStyle5.Format = "yyyy-MM-dd hh:mm:s";
            this.ColumnDateMsg.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnDateMsg.HeaderText = "日期";
            this.ColumnDateMsg.Name = "ColumnDateMsg";
            this.ColumnDateMsg.ReadOnly = true;
            this.ColumnDateMsg.Width = 120;
            // 
            // ColumnFromPsn
            // 
            this.ColumnFromPsn.DataPropertyName = "FromPsn";
            this.ColumnFromPsn.HeaderText = "发送人";
            this.ColumnFromPsn.Name = "ColumnFromPsn";
            this.ColumnFromPsn.ReadOnly = true;
            this.ColumnFromPsn.Width = 66;
            // 
            // ColumnToPsn
            // 
            this.ColumnToPsn.DataPropertyName = "ToPsn";
            this.ColumnToPsn.HeaderText = "接收人";
            this.ColumnToPsn.Name = "ColumnToPsn";
            this.ColumnToPsn.ReadOnly = true;
            this.ColumnToPsn.Width = 66;
            // 
            // ColumnMsgContent
            // 
            this.ColumnMsgContent.DataPropertyName = "MsgContent";
            this.ColumnMsgContent.HeaderText = "内容";
            this.ColumnMsgContent.Name = "ColumnMsgContent";
            this.ColumnMsgContent.ReadOnly = true;
            this.ColumnMsgContent.Width = 300;
            // 
            // ColumnReceiveFlag
            // 
            this.ColumnReceiveFlag.DataPropertyName = "ReceiveFlag";
            this.ColumnReceiveFlag.HeaderText = "接收";
            this.ColumnReceiveFlag.Name = "ColumnReceiveFlag";
            this.ColumnReceiveFlag.ReadOnly = true;
            this.ColumnReceiveFlag.Width = 54;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(3, 6);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(287, 21);
            this.ctrlQFind.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(296, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "输出Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // ctrlToPsnID
            // 
            this.ctrlToPsnID.AutoSize = true;
            this.ctrlToPsnID.Location = new System.Drawing.Point(225, 33);
            this.ctrlToPsnID.Name = "ctrlToPsnID";
            this.ctrlToPsnID.PsnID = 1;
            this.ctrlToPsnID.Size = new System.Drawing.Size(104, 23);
            this.ctrlToPsnID.TabIndex = 7;
            // 
            // ctrlFromPsnID
            // 
            this.ctrlFromPsnID.AutoSize = true;
            this.ctrlFromPsnID.Location = new System.Drawing.Point(58, 33);
            this.ctrlFromPsnID.Name = "ctrlFromPsnID";
            this.ctrlFromPsnID.PsnID = 1;
            this.ctrlFromPsnID.Size = new System.Drawing.Size(104, 23);
            this.ctrlFromPsnID.TabIndex = 5;
            // 
            // ckbReceiveFlag
            // 
            this.ckbReceiveFlag.AutoSize = true;
            this.ckbReceiveFlag.Location = new System.Drawing.Point(335, 38);
            this.ckbReceiveFlag.Name = "ckbReceiveFlag";
            this.ckbReceiveFlag.Size = new System.Drawing.Size(48, 16);
            this.ckbReceiveFlag.TabIndex = 9;
            this.ckbReceiveFlag.Text = "已收";
            this.ckbReceiveFlag.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radReceiveFlag);
            this.panel3.Controls.Add(this.radNoReceiveFlag);
            this.panel3.Location = new System.Drawing.Point(387, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(89, 21);
            this.panel3.TabIndex = 10;
            // 
            // radNoReceiveFlag
            // 
            this.radNoReceiveFlag.AutoSize = true;
            this.radNoReceiveFlag.Checked = true;
            this.radNoReceiveFlag.Location = new System.Drawing.Point(4, 4);
            this.radNoReceiveFlag.Name = "radNoReceiveFlag";
            this.radNoReceiveFlag.Size = new System.Drawing.Size(35, 16);
            this.radNoReceiveFlag.TabIndex = 0;
            this.radNoReceiveFlag.TabStop = true;
            this.radNoReceiveFlag.Text = "否";
            this.radNoReceiveFlag.UseVisualStyleBackColor = true;
            // 
            // radReceiveFlag
            // 
            this.radReceiveFlag.AutoSize = true;
            this.radReceiveFlag.Location = new System.Drawing.Point(45, 4);
            this.radReceiveFlag.Name = "radReceiveFlag";
            this.radReceiveFlag.Size = new System.Drawing.Size(35, 16);
            this.radReceiveFlag.TabIndex = 1;
            this.radReceiveFlag.Text = "是";
            this.radReceiveFlag.UseVisualStyleBackColor = true;
            // 
            // FrmMessageRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 540);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMessageRecord";
            this.Text = "历史记录";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.CheckBox ckbDateMsg;
        private System.Windows.Forms.Panel panel2;
        private JERPApp.Define.Hr.CtrlUserPsn ctrlFromPsnID;
        private System.Windows.Forms.CheckBox ckbFromPsn;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private JERPApp.Define.Hr.CtrlUserPsn ctrlToPsnID;
        private System.Windows.Forms.CheckBox ckbToPsn;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Button btnExport;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFromPsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnToPsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMsgContent;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnReceiveFlag;
        private System.Windows.Forms.CheckBox ckbReceiveFlag;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radNoReceiveFlag;
        private System.Windows.Forms.RadioButton radReceiveFlag;
    }
}