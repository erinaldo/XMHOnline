namespace JERPApp.Finance.Report.Bill
{
    partial class FrmWageNote
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
            this.txtDateEnd = new System.Windows.Forms.TextBox();
            this.txtDateBegin = new System.Windows.Forms.TextBox();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.btnExport = new System.Windows.Forms.Button();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnPsnCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPsnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStaticWage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPositionWage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLaborWage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtDateEnd);
            this.panel1.Controls.Add(this.txtDateBegin);
            this.panel1.Controls.Add(this.txtMonth);
            this.panel1.Controls.Add(this.txtYear);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 61);
            this.panel1.TabIndex = 2;
            // 
            // txtDateEnd
            // 
            this.txtDateEnd.Location = new System.Drawing.Point(410, 36);
            this.txtDateEnd.Name = "txtDateEnd";
            this.txtDateEnd.ReadOnly = true;
            this.txtDateEnd.Size = new System.Drawing.Size(110, 21);
            this.txtDateEnd.TabIndex = 47;
            // 
            // txtDateBegin
            // 
            this.txtDateBegin.Location = new System.Drawing.Point(256, 35);
            this.txtDateBegin.Name = "txtDateBegin";
            this.txtDateBegin.ReadOnly = true;
            this.txtDateBegin.Size = new System.Drawing.Size(110, 21);
            this.txtDateBegin.TabIndex = 46;
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(155, 37);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.ReadOnly = true;
            this.txtMonth.Size = new System.Drawing.Size(47, 21);
            this.txtMonth.TabIndex = 45;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(33, 36);
            this.txtYear.Name = "txtYear";
            this.txtYear.ReadOnly = true;
            this.txtYear.Size = new System.Drawing.Size(75, 21);
            this.txtYear.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(375, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 43;
            this.label4.Text = "截止";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 41;
            this.label3.Text = "开始";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(132, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 39;
            this.label5.Text = "月";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 37;
            this.label8.Text = "年";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(412, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "工资发放单";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 497);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(958, 33);
            this.panel2.TabIndex = 3;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(9, 6);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(244, 21);
            this.ctrlQFind.TabIndex = 7;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(259, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "输出打印";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPsnCode,
            this.ColumnPsnName,
            this.ColumnStaticWage,
            this.ColumnPositionWage,
            this.ColumnLaborWage});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 61);
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
            this.dgrdv.Size = new System.Drawing.Size(958, 436);
            this.dgrdv.TabIndex = 4;
            // 
            // ColumnPsnCode
            // 
            this.ColumnPsnCode.DataPropertyName = "PsnCode";
            this.ColumnPsnCode.HeaderText = "员工";
            this.ColumnPsnCode.Name = "ColumnPsnCode";
            this.ColumnPsnCode.ReadOnly = true;
            this.ColumnPsnCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPsnCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnPsnCode.Width = 60;
            // 
            // ColumnPsnName
            // 
            this.ColumnPsnName.DataPropertyName = "PsnName";
            this.ColumnPsnName.HeaderText = "姓名";
            this.ColumnPsnName.Name = "ColumnPsnName";
            this.ColumnPsnName.ReadOnly = true;
            this.ColumnPsnName.Width = 60;
            // 
            // ColumnStaticWage
            // 
            this.ColumnStaticWage.DataPropertyName = "StaticWage";
            this.ColumnStaticWage.HeaderText = "固定";
            this.ColumnStaticWage.Name = "ColumnStaticWage";
            this.ColumnStaticWage.ReadOnly = true;
            this.ColumnStaticWage.Width = 60;
            // 
            // ColumnPositionWage
            // 
            this.ColumnPositionWage.DataPropertyName = "PositionWage";
            this.ColumnPositionWage.HeaderText = "岗位";
            this.ColumnPositionWage.Name = "ColumnPositionWage";
            this.ColumnPositionWage.ReadOnly = true;
            this.ColumnPositionWage.Width = 60;
            // 
            // ColumnLaborWage
            // 
            this.ColumnLaborWage.DataPropertyName = "LaborWage";
            this.ColumnLaborWage.HeaderText = "劳务";
            this.ColumnLaborWage.Name = "ColumnLaborWage";
            this.ColumnLaborWage.ReadOnly = true;
            this.ColumnLaborWage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnLaborWage.Width = 60;
            // 
            // FrmWageNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 530);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmWageNote";
            this.Text = "工资发放单";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private JCommon.MyDataGridView dgrdv;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDateBegin;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPsnCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPsnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStaticWage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPositionWage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLaborWage;
        private System.Windows.Forms.TextBox txtDateEnd;
    }
}