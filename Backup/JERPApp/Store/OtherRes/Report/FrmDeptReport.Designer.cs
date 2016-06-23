namespace JERPApp.Store.OtherRes.Report
{
    partial class FrmDeptReport
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
            this.ctrlBetweenDate = new JCommon.CtrlBetweenDate();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExplore = new System.Windows.Forms.Button();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnDeptName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnOutQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIntoQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIntoAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDeptQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDeptAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlBetweenDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 54);
            this.panel1.TabIndex = 0;
            // 
            // ctrlBetweenDate
            // 
            this.ctrlBetweenDate.DateBegin = new System.DateTime(2014, 3, 13, 0, 0, 0, 0);
            this.ctrlBetweenDate.DateEnd = new System.DateTime(2014, 3, 13, 0, 0, 0, 0);
            this.ctrlBetweenDate.Location = new System.Drawing.Point(7, 25);
            this.ctrlBetweenDate.Name = "ctrlBetweenDate";
            this.ctrlBetweenDate.Size = new System.Drawing.Size(323, 29);
            this.ctrlBetweenDate.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(297, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 30;
            this.label1.Text = "部门报告";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExplore);
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 495);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(654, 29);
            this.panel2.TabIndex = 1;
            // 
            // btnExplore
            // 
            this.btnExplore.Location = new System.Drawing.Point(257, 1);
            this.btnExplore.Name = "btnExplore";
            this.btnExplore.Size = new System.Drawing.Size(77, 25);
            this.btnExplore.TabIndex = 4;
            this.btnExplore.Text = "输出打印";
            this.btnExplore.UseVisualStyleBackColor = true;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(7, 3);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(244, 21);
            this.ctrlQFind.TabIndex = 2;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDeptName,
            this.ColumnOutQty,
            this.ColumnOutAMT,
            this.ColumnIntoQty,
            this.ColumnIntoAMT,
            this.ColumnDeptQty,
            this.ColumnDeptAMT});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 54);
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
            this.dgrdv.Size = new System.Drawing.Size(654, 441);
            this.dgrdv.TabIndex = 2;
            // 
            // ColumnDeptName
            // 
            this.ColumnDeptName.DataPropertyName = "DeptName";
            this.ColumnDeptName.HeaderText = "部门";
            this.ColumnDeptName.Name = "ColumnDeptName";
            this.ColumnDeptName.ReadOnly = true;
            // 
            // ColumnOutQty
            // 
            this.ColumnOutQty.DataPropertyName = "OutQty";
            this.ColumnOutQty.HeaderText = "领用数量";
            this.ColumnOutQty.Name = "ColumnOutQty";
            this.ColumnOutQty.ReadOnly = true;
            this.ColumnOutQty.Width = 80;
            // 
            // ColumnOutAMT
            // 
            this.ColumnOutAMT.DataPropertyName = "OutAMT";
            this.ColumnOutAMT.HeaderText = "领用金额";
            this.ColumnOutAMT.Name = "ColumnOutAMT";
            this.ColumnOutAMT.ReadOnly = true;
            this.ColumnOutAMT.Width = 80;
            // 
            // ColumnIntoQty
            // 
            this.ColumnIntoQty.DataPropertyName = "IntoQty";
            this.ColumnIntoQty.HeaderText = "入库数量";
            this.ColumnIntoQty.Name = "ColumnIntoQty";
            this.ColumnIntoQty.ReadOnly = true;
            this.ColumnIntoQty.Width = 80;
            // 
            // ColumnIntoAMT
            // 
            this.ColumnIntoAMT.DataPropertyName = "IntoAMT";
            this.ColumnIntoAMT.HeaderText = "入库金额";
            this.ColumnIntoAMT.Name = "ColumnIntoAMT";
            this.ColumnIntoAMT.ReadOnly = true;
            this.ColumnIntoAMT.Width = 80;
            // 
            // ColumnDeptQty
            // 
            this.ColumnDeptQty.DataPropertyName = "DeptQty";
            this.ColumnDeptQty.HeaderText = "部门数量";
            this.ColumnDeptQty.Name = "ColumnDeptQty";
            this.ColumnDeptQty.ReadOnly = true;
            this.ColumnDeptQty.Width = 80;
            // 
            // ColumnDeptAMT
            // 
            this.ColumnDeptAMT.DataPropertyName = "DeptAMT";
            this.ColumnDeptAMT.HeaderText = "部门金额";
            this.ColumnDeptAMT.Name = "ColumnDeptAMT";
            this.ColumnDeptAMT.ReadOnly = true;
            this.ColumnDeptAMT.Width = 80;
            // 
            // FrmDeptReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 524);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmDeptReport";
            this.Text = "FrmDeptReport";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private JCommon.CtrlBetweenDate ctrlBetweenDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Button btnExplore;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnDeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIntoQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIntoAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeptQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeptAMT;
    }
}