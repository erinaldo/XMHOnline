namespace JERPApp.Engineer.Define
{
    partial class FrmMachineProcess
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
            this.MachineProcessID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MachineProcessCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MachineProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MachineProcessMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrdv
            // 
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MachineProcessID,
            this.MachineProcessCode,
            this.MachineProcessName,
            this.MachineProcessMemo});
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
            this.dgrdv.Size = new System.Drawing.Size(549, 761);
            this.dgrdv.TabIndex = 0;
            // 
            // MachineProcessID
            // 
            this.MachineProcessID.DataPropertyName = "MachineProcessID";
            this.MachineProcessID.HeaderText = "ID";
            this.MachineProcessID.Name = "MachineProcessID";
            this.MachineProcessID.Visible = false;
            // 
            // MachineProcessCode
            // 
            this.MachineProcessCode.DataPropertyName = "MachineProcessCode";
            this.MachineProcessCode.HeaderText = "代码";
            this.MachineProcessCode.Name = "MachineProcessCode";
            this.MachineProcessCode.Width = 60;
            // 
            // MachineProcessName
            // 
            this.MachineProcessName.DataPropertyName = "MachineProcessName";
            this.MachineProcessName.HeaderText = "名称";
            this.MachineProcessName.Name = "MachineProcessName";
            this.MachineProcessName.Width = 120;
            // 
            // MachineProcessMemo
            // 
            this.MachineProcessMemo.DataPropertyName = "MachineProcessMemo";
            this.MachineProcessMemo.HeaderText = "备注";
            this.MachineProcessMemo.Name = "MachineProcessMemo";
            this.MachineProcessMemo.Width = 150;
            // 
            // FrmMachineProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 761);
            this.Controls.Add(this.dgrdv);
            this.Name = "FrmMachineProcess";
            this.Text = "工序机台";
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineProcessID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineProcessCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineProcessMemo;
    }
}