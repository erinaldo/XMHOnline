namespace JERPApp.Store.OtherRes.Report
{
    partial class FrmDeptPrdReport
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExplore = new System.Windows.Forms.Button();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDateEnd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDateBegin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDeptName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIntoQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIntoAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDeptQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDeptAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExplore);
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 514);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(906, 29);
            this.panel2.TabIndex = 2;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.txtDateEnd);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDateBegin);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtDeptName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(906, 54);
            this.panel1.TabIndex = 3;
            // 
            // txtDateEnd
            // 
            this.txtDateEnd.Location = new System.Drawing.Point(369, 30);
            this.txtDateEnd.Name = "txtDateEnd";
            this.txtDateEnd.ReadOnly = true;
            this.txtDateEnd.Size = new System.Drawing.Size(100, 21);
            this.txtDateEnd.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(310, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 35;
            this.label4.Text = "截止日期";
            // 
            // txtDateBegin
            // 
            this.txtDateBegin.Location = new System.Drawing.Point(208, 30);
            this.txtDateBegin.Name = "txtDateBegin";
            this.txtDateBegin.ReadOnly = true;
            this.txtDateBegin.Size = new System.Drawing.Size(100, 21);
            this.txtDateBegin.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "开始日期";
            // 
            // txtDeptName
            // 
            this.txtDeptName.Location = new System.Drawing.Point(43, 30);
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.ReadOnly = true;
            this.txtDeptName.Size = new System.Drawing.Size(100, 21);
            this.txtDeptName.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "部门";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(376, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 14);
            this.label1.TabIndex = 30;
            this.label1.Text = "耗材部门领用报告";
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnUnitName,
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
            this.dgrdv.Size = new System.Drawing.Size(906, 460);
            this.dgrdv.TabIndex = 4;
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
            this.ColumnPrdSpec.HeaderText = "型号及规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            this.ColumnPrdSpec.ReadOnly = true;
            // 
            // ColumnUnitName
            // 
            this.ColumnUnitName.DataPropertyName = "UnitName";
            this.ColumnUnitName.HeaderText = "单位";
            this.ColumnUnitName.Name = "ColumnUnitName";
            this.ColumnUnitName.ReadOnly = true;
            this.ColumnUnitName.Width = 54;
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
            // FrmDeptPrdReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 543);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmDeptPrdReport";
            this.Text = "耗材部门领用明细";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExplore;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDateEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDateBegin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDeptName;
        private System.Windows.Forms.Label label2;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIntoQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIntoAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeptQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeptAMT;
    }
}