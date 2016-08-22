namespace JERPApp.Engineer.Define
{
    partial class FrmToolProcess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ToolProcessID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolProcessCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolProcessMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrdv
            // 
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ToolProcessID,
            this.ToolProcessCode,
            this.ToolProcessName,
            this.ToolProcessMemo});
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
            this.dgrdv.Size = new System.Drawing.Size(461, 773);
            this.dgrdv.TabIndex = 1;
            // 
            // ToolProcessID
            // 
            this.ToolProcessID.DataPropertyName = "ToolProcessID";
            this.ToolProcessID.HeaderText = "ID";
            this.ToolProcessID.Name = "ToolProcessID";
            this.ToolProcessID.Visible = false;
            // 
            // ToolProcessCode
            // 
            this.ToolProcessCode.DataPropertyName = "ToolProcessCode";
            this.ToolProcessCode.HeaderText = "代码";
            this.ToolProcessCode.Name = "ToolProcessCode";
            this.ToolProcessCode.Width = 60;
            // 
            // ToolProcessName
            // 
            this.ToolProcessName.DataPropertyName = "ToolProcessName";
            this.ToolProcessName.HeaderText = "名称";
            this.ToolProcessName.Name = "ToolProcessName";
            this.ToolProcessName.Width = 120;
            // 
            // ToolProcessMemo
            // 
            this.ToolProcessMemo.DataPropertyName = "ToolProcessMemo";
            this.ToolProcessMemo.HeaderText = "备注";
            this.ToolProcessMemo.Name = "ToolProcessMemo";
            this.ToolProcessMemo.Width = 150;
            // 
            // FrmToolProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 773);
            this.Controls.Add(this.dgrdv);
            this.Name = "FrmToolProcess";
            this.Text = "工具工序";
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToolProcessID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToolProcessCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToolProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToolProcessMemo;
    }
}