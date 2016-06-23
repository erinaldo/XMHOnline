namespace JERPApp.Define.Technology
{
    partial class CtrlDevelopScheduleOperForPrd
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnAddDate = new System.Windows.Forms.Button();
            this.dtpDateSchedule = new System.Windows.Forms.DateTimePicker();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnPrdStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateTarget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPsnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPrdSpec = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrdName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrdCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrlDevelopProcessID = new JERPApp.Define.Technology.CtrlDevelopProcessForSchedule();
            this.ctrlPsnID = new JERPApp.Define.Hr.CtrlEngineerPsn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlPsnID);
            this.panel1.Controls.Add(this.ctrlDevelopProcessID);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnAddDate);
            this.panel1.Controls.Add(this.dtpDateSchedule);
            this.panel1.Controls.Add(this.btnAddItem);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 176);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 26);
            this.panel1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(207, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "负责人";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(638, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(60, 23);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "输出";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnAddDate
            // 
            this.btnAddDate.Location = new System.Drawing.Point(569, 2);
            this.btnAddDate.Name = "btnAddDate";
            this.btnAddDate.Size = new System.Drawing.Size(61, 23);
            this.btnAddDate.TabIndex = 7;
            this.btnAddDate.Text = "+日期";
            this.btnAddDate.UseVisualStyleBackColor = true;
            // 
            // dtpDateSchedule
            // 
            this.dtpDateSchedule.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateSchedule.Location = new System.Drawing.Point(443, 3);
            this.dtpDateSchedule.Name = "dtpDateSchedule";
            this.dtpDateSchedule.Size = new System.Drawing.Size(120, 21);
            this.dtpDateSchedule.TabIndex = 6;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(380, 2);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(57, 23);
            this.btnAddItem.TabIndex = 5;
            this.btnAddItem.Text = "+项";
            this.btnAddItem.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "开发流程";
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPrdStatus,
            this.ColumnDateTarget,
            this.ColumnPsnName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 29);
            this.dgrdv.Name = "dgrdv";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(831, 147);
            this.dgrdv.TabIndex = 1;
            // 
            // ColumnPrdStatus
            // 
            this.ColumnPrdStatus.DataPropertyName = "PrdStatus";
            this.ColumnPrdStatus.HeaderText = "开发流程";
            this.ColumnPrdStatus.Name = "ColumnPrdStatus";
            this.ColumnPrdStatus.ReadOnly = true;
            this.ColumnPrdStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdStatus.Width = 80;
            // 
            // ColumnDateTarget
            // 
            this.ColumnDateTarget.DataPropertyName = "DateTarget";
            dataGridViewCellStyle1.Format = "M-d";
            this.ColumnDateTarget.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnDateTarget.HeaderText = "交期";
            this.ColumnDateTarget.Name = "ColumnDateTarget";
            this.ColumnDateTarget.ReadOnly = true;
            this.ColumnDateTarget.Width = 70;
            // 
            // ColumnPsnName
            // 
            this.ColumnPsnName.DataPropertyName = "PsnName";
            this.ColumnPsnName.HeaderText = "负责人";
            this.ColumnPsnName.Name = "ColumnPsnName";
            this.ColumnPsnName.ReadOnly = true;
            this.ColumnPsnName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPsnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnPsnName.Width = 66;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtPrdSpec);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtPrdName);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtPrdCode);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(831, 29);
            this.panel2.TabIndex = 2;
            // 
            // txtPrdSpec
            // 
            this.txtPrdSpec.Location = new System.Drawing.Point(374, 3);
            this.txtPrdSpec.Name = "txtPrdSpec";
            this.txtPrdSpec.ReadOnly = true;
            this.txtPrdSpec.Size = new System.Drawing.Size(134, 21);
            this.txtPrdSpec.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(321, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "产品规格";
            // 
            // txtPrdName
            // 
            this.txtPrdName.Location = new System.Drawing.Point(231, 3);
            this.txtPrdName.Name = "txtPrdName";
            this.txtPrdName.ReadOnly = true;
            this.txtPrdName.Size = new System.Drawing.Size(90, 21);
            this.txtPrdName.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "产品名称";
            // 
            // txtPrdCode
            // 
            this.txtPrdCode.Location = new System.Drawing.Point(60, 3);
            this.txtPrdCode.Name = "txtPrdCode";
            this.txtPrdCode.ReadOnly = true;
            this.txtPrdCode.Size = new System.Drawing.Size(111, 21);
            this.txtPrdCode.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "产品编号";
            // 
            // ctrlDevelopProcessID
            // 
            this.ctrlDevelopProcessID.DevelopProcessID = ((long)(-1));
            this.ctrlDevelopProcessID.Location = new System.Drawing.Point(63, 2);
            this.ctrlDevelopProcessID.Name = "ctrlDevelopProcessID";
            this.ctrlDevelopProcessID.Size = new System.Drawing.Size(138, 23);
            this.ctrlDevelopProcessID.TabIndex = 15;
            // 
            // ctrlPsnID
            // 
            this.ctrlPsnID.AutoSize = true;
            this.ctrlPsnID.Location = new System.Drawing.Point(254, 2);
            this.ctrlPsnID.Name = "ctrlPsnID";
            this.ctrlPsnID.PsnID = -1;
            this.ctrlPsnID.Size = new System.Drawing.Size(120, 23);
            this.ctrlPsnID.TabIndex = 16;
            // 
            // CtrlDevelopScheduleOperForPrd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CtrlDevelopScheduleOperForPrd";
            this.Size = new System.Drawing.Size(831, 202);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddDate;
        private System.Windows.Forms.DateTimePicker dtpDateSchedule;
        private System.Windows.Forms.Button btnAddItem;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtPrdCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrdSpec;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrdName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateTarget;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPsnName;
        private CtrlDevelopProcessForSchedule ctrlDevelopProcessID;
        private JERPApp.Define.Hr.CtrlEngineerPsn ctrlPsnID;
    }
}
