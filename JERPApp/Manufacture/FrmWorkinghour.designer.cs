namespace JERPApp.Manufacture
{
    partial class FrmWorkinghour
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDateManuf = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddBatch = new System.Windows.Forms.Button();
            this.ctrlWorkgroupID = new JERPApp.Define.Manufacture.CtrlWorkgroup();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddPsn = new System.Windows.Forms.Button();
            this.ctrlPsnID = new JERPApp.Define.Hr.CtrlPersonnel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnPsnCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPsnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctrlShiftID = new JERPApp.Define.Manufacture.CtrlShift();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpDateManuf);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 37);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "生产日期";
            // 
            // dtpDateManuf
            // 
            this.dtpDateManuf.Location = new System.Drawing.Point(66, 9);
            this.dtpDateManuf.Name = "dtpDateManuf";
            this.dtpDateManuf.Size = new System.Drawing.Size(128, 21);
            this.dtpDateManuf.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(346, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "工时统计";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlShiftID);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnAddBatch);
            this.panel2.Controls.Add(this.ctrlWorkgroupID);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnAddPsn);
            this.panel2.Controls.Add(this.ctrlPsnID);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 427);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(774, 31);
            this.panel2.TabIndex = 4;
            // 
            // btnAddBatch
            // 
            this.btnAddBatch.Location = new System.Drawing.Point(538, 3);
            this.btnAddBatch.Name = "btnAddBatch";
            this.btnAddBatch.Size = new System.Drawing.Size(50, 23);
            this.btnAddBatch.TabIndex = 8;
            this.btnAddBatch.Text = "+多人";
            this.btnAddBatch.UseVisualStyleBackColor = true;
            // 
            // ctrlWorkgroupID
            // 
            this.ctrlWorkgroupID.AutoSize = true;
            this.ctrlWorkgroupID.Location = new System.Drawing.Point(271, 4);
            this.ctrlWorkgroupID.Name = "ctrlWorkgroupID";
            this.ctrlWorkgroupID.Size = new System.Drawing.Size(142, 23);
            this.ctrlWorkgroupID.TabIndex = 7;
            this.ctrlWorkgroupID.WorkgroupID = -1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(236, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "区域";
            // 
            // btnAddPsn
            // 
            this.btnAddPsn.Location = new System.Drawing.Point(189, 5);
            this.btnAddPsn.Name = "btnAddPsn";
            this.btnAddPsn.Size = new System.Drawing.Size(41, 23);
            this.btnAddPsn.TabIndex = 5;
            this.btnAddPsn.Text = "+人";
            this.btnAddPsn.UseVisualStyleBackColor = true;
            // 
            // ctrlPsnID
            // 
            this.ctrlPsnID.AutoSize = true;
            this.ctrlPsnID.Location = new System.Drawing.Point(56, 5);
            this.ctrlPsnID.Name = "ctrlPsnID";
            this.ctrlPsnID.PsnID = -1;
            this.ctrlPsnID.Size = new System.Drawing.Size(127, 23);
            this.ctrlPsnID.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "人员";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(595, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPsnCode,
            this.ColumnPsnName});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 37);
            this.dgrdv.Name = "dgrdv";
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
            this.dgrdv.Size = new System.Drawing.Size(774, 390);
            this.dgrdv.TabIndex = 5;
            // 
            // ColumnPsnCode
            // 
            this.ColumnPsnCode.DataPropertyName = "PsnCode";
            this.ColumnPsnCode.HeaderText = "工号";
            this.ColumnPsnCode.Name = "ColumnPsnCode";
            this.ColumnPsnCode.ReadOnly = true;
            this.ColumnPsnCode.Width = 66;
            // 
            // ColumnPsnName
            // 
            this.ColumnPsnName.DataPropertyName = "PsnName";
            this.ColumnPsnName.HeaderText = "姓名";
            this.ColumnPsnName.Name = "ColumnPsnName";
            this.ColumnPsnName.ReadOnly = true;
            this.ColumnPsnName.Width = 66;
            // 
            // ctrlShiftID
            // 
            this.ctrlShiftID.AutoSize = true;
            this.ctrlShiftID.Location = new System.Drawing.Point(455, 4);
            this.ctrlShiftID.Name = "ctrlShiftID";
            this.ctrlShiftID.ShiftID = 1;
            this.ctrlShiftID.Size = new System.Drawing.Size(77, 23);
            this.ctrlShiftID.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(419, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "班次";
            // 
            // FrmWorkinghour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 458);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmWorkinghour";
            this.Text = "FrmWorkinghour";
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddPsn;
        private JERPApp.Define.Hr.CtrlPersonnel ctrlPsnID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPsnCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPsnName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDateManuf;
        private System.Windows.Forms.Button btnAddBatch;
        private JERPApp.Define.Manufacture.CtrlWorkgroup ctrlWorkgroupID;
        private System.Windows.Forms.Label label4;
        private JERPApp.Define.Manufacture.CtrlShift ctrlShiftID;
        private System.Windows.Forms.Label label5;
    }
}