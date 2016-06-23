namespace JERPApp.Manufacture.SemiPrd.Report
{
    partial class FrmPrdInventory
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
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnSerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProcessTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWorkingPositionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutSrcSupplier = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnInventoryQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSerialNo,
            this.ColumnProcessTypeName,
            this.ColumnWorkingPositionName,
            this.ColumnOutSrcSupplier,
            this.ColumnInventoryQty});
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
            this.dgrdv.Size = new System.Drawing.Size(455, 463);
            this.dgrdv.TabIndex = 0;
            // 
            // ColumnSerialNo
            // 
            this.ColumnSerialNo.DataPropertyName = "SerialNo";
            this.ColumnSerialNo.HeaderText = "序号";
            this.ColumnSerialNo.Name = "ColumnSerialNo";
            this.ColumnSerialNo.ReadOnly = true;
            this.ColumnSerialNo.Width = 54;
            // 
            // ColumnProcessTypeName
            // 
            this.ColumnProcessTypeName.DataPropertyName = "ProcessTypeName";
            this.ColumnProcessTypeName.HeaderText = "工序名称";
            this.ColumnProcessTypeName.Name = "ColumnProcessTypeName";
            this.ColumnProcessTypeName.ReadOnly = true;
            // 
            // ColumnWorkingPositionName
            // 
            this.ColumnWorkingPositionName.DataPropertyName = "WorkingPositionName";
            this.ColumnWorkingPositionName.HeaderText = "默认位置";
            this.ColumnWorkingPositionName.Name = "ColumnWorkingPositionName";
            this.ColumnWorkingPositionName.ReadOnly = true;
            this.ColumnWorkingPositionName.Width = 80;
            // 
            // ColumnOutSrcSupplier
            // 
            this.ColumnOutSrcSupplier.DataPropertyName = "OutSrcSupplier";
            this.ColumnOutSrcSupplier.HeaderText = "默认委外商";
            this.ColumnOutSrcSupplier.Name = "ColumnOutSrcSupplier";
            this.ColumnOutSrcSupplier.ReadOnly = true;
            this.ColumnOutSrcSupplier.Width = 80;
            // 
            // ColumnInventoryQty
            // 
            this.ColumnInventoryQty.DataPropertyName = "InventoryQty";
            this.ColumnInventoryQty.HeaderText = "在产数";
            this.ColumnInventoryQty.Name = "ColumnInventoryQty";
            this.ColumnInventoryQty.ReadOnly = true;
            this.ColumnInventoryQty.Width = 66;
            // 
            // FrmPrdInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 463);
            this.Controls.Add(this.dgrdv);
            this.Name = "FrmPrdInventory";
            this.Text = "生成进程";
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProcessTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWorkingPositionName;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnOutSrcSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInventoryQty;
    }
}