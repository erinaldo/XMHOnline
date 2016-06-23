namespace JERPApp.Engineer
{
    partial class FrmManufProcessOper
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
            this.dgrdv = new JCommon.MyDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlProcessTempletID = new JERPApp.Define.Manufacture.CtrlProcessTemplet();
            this.ColumnSerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProcessTypeID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnOutSrcFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnOutSrcCompanyID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMouldCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrdv
            // 
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSerialNo,
            this.ColumnProcessTypeID,
            this.ColumnOutSrcFlag,
            this.ColumnOutSrcCompanyID,
            this.ColumnMemo,
            this.ColumnMouldCode});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 0);
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
            this.dgrdv.Size = new System.Drawing.Size(650, 415);
            this.dgrdv.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ctrlProcessTempletID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 415);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 27);
            this.panel1.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(295, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(226, 2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(63, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "加载";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "模板";
            // 
            // ctrlProcessTempletID
            // 
            this.ctrlProcessTempletID.Location = new System.Drawing.Point(52, 3);
            this.ctrlProcessTempletID.Name = "ctrlProcessTempletID";
            this.ctrlProcessTempletID.Size = new System.Drawing.Size(168, 23);
            this.ctrlProcessTempletID.TabIndex = 0;
            this.ctrlProcessTempletID.TempletID = 1;
            // 
            // ColumnSerialNo
            // 
            this.ColumnSerialNo.DataPropertyName = "SerialNo";
            this.ColumnSerialNo.HeaderText = "序号";
            this.ColumnSerialNo.Name = "ColumnSerialNo";
            this.ColumnSerialNo.Width = 66;
            // 
            // ColumnProcessTypeID
            // 
            this.ColumnProcessTypeID.DataPropertyName = "ProcessTypeID";
            this.ColumnProcessTypeID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnProcessTypeID.HeaderText = "工序";
            this.ColumnProcessTypeID.Name = "ColumnProcessTypeID";
            // 
            // ColumnOutSrcFlag
            // 
            this.ColumnOutSrcFlag.DataPropertyName = "OutSrcFlag";
            this.ColumnOutSrcFlag.HeaderText = "委外";
            this.ColumnOutSrcFlag.Name = "ColumnOutSrcFlag";
            this.ColumnOutSrcFlag.Width = 54;
            // 
            // ColumnOutSrcCompanyID
            // 
            this.ColumnOutSrcCompanyID.DataPropertyName = "OutSrcCompanyID";
            this.ColumnOutSrcCompanyID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnOutSrcCompanyID.HeaderText = "委外商";
            this.ColumnOutSrcCompanyID.Name = "ColumnOutSrcCompanyID";
            this.ColumnOutSrcCompanyID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnOutSrcCompanyID.Width = 80;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnMemo.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnMemo.HeaderText = "参数及说明";
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.Width = 120;
            // 
            // ColumnMouldCode
            // 
            this.ColumnMouldCode.DataPropertyName = "MouldCode";
            this.ColumnMouldCode.HeaderText = "模具号";
            this.ColumnMouldCode.Name = "ColumnMouldCode";
            this.ColumnMouldCode.Width = 80;
            // 
            // FrmManufProcessOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 442);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel1);
            this.Name = "FrmManufProcessOper";
            this.Text = "工序管理";
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label1;
        private JERPApp.Define.Manufacture.CtrlProcessTemplet ctrlProcessTempletID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSerialNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnProcessTypeID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnOutSrcFlag;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnOutSrcCompanyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMouldCode;
    }
}
