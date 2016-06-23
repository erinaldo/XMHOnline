namespace JERPApp.Finance.Report
{
    partial class CtrlPrdManufProcess
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnPrdStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLastCostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMtrCostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProcessCostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPrdStatus,
            this.ColumnLastCostPrice,
            this.ColumnMtrCostPrice,
            this.ColumnProcessCostPrice,
            this.ColumnCostPrice});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 0);
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
            this.dgrdv.Size = new System.Drawing.Size(354, 150);
            this.dgrdv.TabIndex = 3;
            // 
            // ColumnPrdStatus
            // 
            this.ColumnPrdStatus.DataPropertyName = "PrdStatus";
            this.ColumnPrdStatus.HeaderText = "工序";
            this.ColumnPrdStatus.Name = "ColumnPrdStatus";
            this.ColumnPrdStatus.ReadOnly = true;
            // 
            // ColumnLastCostPrice
            // 
            this.ColumnLastCostPrice.DataPropertyName = "LastCostPrice";
            this.ColumnLastCostPrice.HeaderText = "前工序成本";
            this.ColumnLastCostPrice.Name = "ColumnLastCostPrice";
            this.ColumnLastCostPrice.ReadOnly = true;
            // 
            // ColumnMtrCostPrice
            // 
            this.ColumnMtrCostPrice.DataPropertyName = "MtrCostPrice";
            this.ColumnMtrCostPrice.HeaderText = "原料成本";
            this.ColumnMtrCostPrice.Name = "ColumnMtrCostPrice";
            this.ColumnMtrCostPrice.ReadOnly = true;
            this.ColumnMtrCostPrice.Width = 80;
            // 
            // ColumnProcessCostPrice
            // 
            this.ColumnProcessCostPrice.DataPropertyName = "ProcessCostPrice";
            this.ColumnProcessCostPrice.HeaderText = "工序成本";
            this.ColumnProcessCostPrice.Name = "ColumnProcessCostPrice";
            this.ColumnProcessCostPrice.ReadOnly = true;
            this.ColumnProcessCostPrice.Width = 80;
            // 
            // ColumnCostPrice
            // 
            this.ColumnCostPrice.DataPropertyName = "CostPrice";
            this.ColumnCostPrice.HeaderText = "半成品价";
            this.ColumnCostPrice.Name = "ColumnCostPrice";
            this.ColumnCostPrice.ReadOnly = true;
            this.ColumnCostPrice.Width = 80;
            // 
            // CtrlPrdManufProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgrdv);
            this.Name = "CtrlPrdManufProcess";
            this.Size = new System.Drawing.Size(354, 150);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLastCostPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMtrCostPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProcessCostPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCostPrice;
    }
}
