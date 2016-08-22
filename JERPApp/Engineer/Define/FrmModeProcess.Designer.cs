namespace JERPApp.Engineer.Define
{
    partial class FrmModeProcess
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
            this.ModelProcessID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelProcessCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelProcessMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrdv
            // 
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ModelProcessID,
            this.ModelProcessCode,
            this.ModelProcessName,
            this.ModelProcessMemo});
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
            this.dgrdv.Size = new System.Drawing.Size(476, 759);
            this.dgrdv.TabIndex = 1;
            // 
            // ModelProcessID
            // 
            this.ModelProcessID.DataPropertyName = "ModelProcessID";
            this.ModelProcessID.HeaderText = "ID";
            this.ModelProcessID.Name = "ModelProcessID";
            this.ModelProcessID.Visible = false;
            // 
            // ModelProcessCode
            // 
            this.ModelProcessCode.DataPropertyName = "ModelProcessCode";
            this.ModelProcessCode.HeaderText = "代码";
            this.ModelProcessCode.Name = "ModelProcessCode";
            this.ModelProcessCode.Width = 60;
            // 
            // ModelProcessName
            // 
            this.ModelProcessName.DataPropertyName = "ModelProcessName";
            this.ModelProcessName.HeaderText = "名称";
            this.ModelProcessName.Name = "ModelProcessName";
            this.ModelProcessName.Width = 120;
            // 
            // ModelProcessMemo
            // 
            this.ModelProcessMemo.DataPropertyName = "ModelProcessMemo";
            this.ModelProcessMemo.HeaderText = "备注";
            this.ModelProcessMemo.Name = "ModelProcessMemo";
            this.ModelProcessMemo.Width = 150;
            // 
            // FrmModeProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 759);
            this.Controls.Add(this.dgrdv);
            this.Name = "FrmModeProcess";
            this.Text = "FrmModeProcess";
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelProcessID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelProcessCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelProcessMemo;
    }
}