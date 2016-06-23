namespace JERPApp.Manufacture.Boxing
{
    partial class FrmBoxItemDetail
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
            this.btnExport = new System.Windows.Forms.Button();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ctrlQChecked = new JCommon.CtrlGridCheckBox();
            this.ColumnCheckedFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnChipsetCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBoxCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlQChecked);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 366);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(493, 28);
            this.panel1.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(84, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "标签打印";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCheckedFlag,
            this.ColumnBarcode,
            this.ColumnChipsetCode,
            this.ColumnBoxCode});
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
            this.dgrdv.Size = new System.Drawing.Size(493, 366);
            this.dgrdv.TabIndex = 0;
            // 
            // ctrlQChecked
            // 
            this.ctrlQChecked.CheckedFlag = false;
            this.ctrlQChecked.Location = new System.Drawing.Point(9, 3);
            this.ctrlQChecked.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlQChecked.Name = "ctrlQChecked";
            this.ctrlQChecked.SeachGridView = null;
            this.ctrlQChecked.Size = new System.Drawing.Size(52, 18);
            this.ctrlQChecked.TabIndex = 1;
            // 
            // ColumnCheckedFlag
            // 
            this.ColumnCheckedFlag.DataPropertyName = "CheckedFlag";
            this.ColumnCheckedFlag.HeaderText = "选择";
            this.ColumnCheckedFlag.Name = "ColumnCheckedFlag";
            this.ColumnCheckedFlag.Width = 54;
            // 
            // ColumnBarcode
            // 
            this.ColumnBarcode.DataPropertyName = "Barcode";
            this.ColumnBarcode.HeaderText = "标签";
            this.ColumnBarcode.Name = "ColumnBarcode";
            this.ColumnBarcode.ReadOnly = true;
            this.ColumnBarcode.Width = 160;
            // 
            // ColumnChipsetCode
            // 
            this.ColumnChipsetCode.DataPropertyName = "ChipsetCode";
            this.ColumnChipsetCode.HeaderText = "芯片编号";
            this.ColumnChipsetCode.Name = "ColumnChipsetCode";
            this.ColumnChipsetCode.ReadOnly = true;
            // 
            // ColumnBoxCode
            // 
            this.ColumnBoxCode.DataPropertyName = "BoxCode";
            this.ColumnBoxCode.HeaderText = "箱号";
            this.ColumnBoxCode.Name = "ColumnBoxCode";
            this.ColumnBoxCode.ReadOnly = true;
            this.ColumnBoxCode.Width = 120;
            // 
            // FrmBoxItemDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 394);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBoxItemDetail";
            this.Text = "产品标签";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Panel panel1;
        private JCommon.CtrlGridCheckBox ctrlQChecked;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheckedFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnChipsetCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBoxCode;
    }
}