namespace JERPApp.Store.Material.Templet
{
    partial class FrmOutStoreFormat
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
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnSerialNoFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnFieldTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnlnkFieldMsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBtnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lnkUpload = new System.Windows.Forms.LinkLabel();
            this.lnkDownload = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(242, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "领料单格式";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkUpload);
            this.panel1.Controls.Add(this.lnkDownload);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 32);
            this.panel1.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 470);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(564, 26);
            this.panel2.TabIndex = 22;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(111, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 102;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(5, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(51, 23);
            this.btnAdd.TabIndex = 100;
            this.btnAdd.Text = "+列";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSerialNoFlag,
            this.ColumnFieldTitle,
            this.ColumnColumnName,
            this.ColumnlnkFieldMsg,
            this.ColumnBtnEdit});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 32);
            this.dgrdv.Name = "dgrdv";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(564, 438);
            this.dgrdv.TabIndex = 60;
            // 
            // ColumnSerialNoFlag
            // 
            this.ColumnSerialNoFlag.DataPropertyName = "SerialNoFlag";
            this.ColumnSerialNoFlag.HeaderText = "序号列";
            this.ColumnSerialNoFlag.Name = "ColumnSerialNoFlag";
            this.ColumnSerialNoFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSerialNoFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnSerialNoFlag.Width = 66;
            // 
            // ColumnFieldTitle
            // 
            this.ColumnFieldTitle.DataPropertyName = "FieldTitle";
            this.ColumnFieldTitle.HeaderText = "列标题";
            this.ColumnFieldTitle.Name = "ColumnFieldTitle";
            // 
            // ColumnColumnName
            // 
            this.ColumnColumnName.DataPropertyName = "ColumnName";
            this.ColumnColumnName.HeaderText = "Excel列名";
            this.ColumnColumnName.Name = "ColumnColumnName";
            // 
            // ColumnlnkFieldMsg
            // 
            this.ColumnlnkFieldMsg.DataPropertyName = "FieldMsg";
            this.ColumnlnkFieldMsg.HeaderText = "字段信息";
            this.ColumnlnkFieldMsg.Name = "ColumnlnkFieldMsg";
            this.ColumnlnkFieldMsg.ReadOnly = true;
            this.ColumnlnkFieldMsg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnBtnEdit
            // 
            this.ColumnBtnEdit.HeaderText = "变更";
            this.ColumnBtnEdit.Name = "ColumnBtnEdit";
            this.ColumnBtnEdit.Text = "变更";
            this.ColumnBtnEdit.UseColumnTextForButtonValue = true;
            this.ColumnBtnEdit.Width = 54;
            // 
            // lnkUpload
            // 
            this.lnkUpload.AutoSize = true;
            this.lnkUpload.Location = new System.Drawing.Point(117, 17);
            this.lnkUpload.Name = "lnkUpload";
            this.lnkUpload.Size = new System.Drawing.Size(77, 12);
            this.lnkUpload.TabIndex = 14;
            this.lnkUpload.TabStop = true;
            this.lnkUpload.Text = "格式文档上载";
            // 
            // lnkDownload
            // 
            this.lnkDownload.AutoSize = true;
            this.lnkDownload.Location = new System.Drawing.Point(3, 17);
            this.lnkDownload.Name = "lnkDownload";
            this.lnkDownload.Size = new System.Drawing.Size(77, 12);
            this.lnkDownload.TabIndex = 13;
            this.lnkDownload.TabStop = true;
            this.lnkDownload.Text = "格式文档下载";
            // 
            // FrmOutStoreFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 496);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmOutStoreFormat";
            this.Text = "领料单格式";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAdd;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnSerialNoFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFieldTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnlnkFieldMsg;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnBtnEdit;
        private System.Windows.Forms.LinkLabel lnkUpload;
        private System.Windows.Forms.LinkLabel lnkDownload;
    }
}