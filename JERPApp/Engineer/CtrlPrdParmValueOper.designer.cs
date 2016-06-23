namespace JERPApp.Engineer
{
    partial class CtrlPrdParmValueOper
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnParmTypeID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnParmValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemValues = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlTempletID = new JERPApp.Define.Product.CtrlParmTemplet();
            this.btnTemplet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrdv
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dgrdv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnParmTypeID,
            this.ColumnParmValue,
            this.ColumnItemValues});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(165)))), ((int)(((byte)(198)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
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
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(580, 159);
            this.dgrdv.TabIndex = 2;
            // 
            // ColumnParmTypeID
            // 
            this.ColumnParmTypeID.DataPropertyName = "ParmTypeID";
            this.ColumnParmTypeID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnParmTypeID.HeaderText = "参数类型";
            this.ColumnParmTypeID.Name = "ColumnParmTypeID";
            this.ColumnParmTypeID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnParmTypeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnParmTypeID.Width = 130;
            // 
            // ColumnParmValue
            // 
            this.ColumnParmValue.DataPropertyName = "ParmValue";
            this.ColumnParmValue.HeaderText = "参数值";
            this.ColumnParmValue.Name = "ColumnParmValue";
            this.ColumnParmValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnParmValue.Width = 500;
            // 
            // ColumnItemValues
            // 
            this.ColumnItemValues.HeaderText = "ItemValues";
            this.ColumnItemValues.Name = "ColumnItemValues";
            this.ColumnItemValues.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTemplet);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ctrlTempletID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 159);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 26);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "模板";
            // 
            // ctrlTempletID
            // 
            this.ctrlTempletID.Location = new System.Drawing.Point(54, 2);
            this.ctrlTempletID.Name = "ctrlTempletID";
            this.ctrlTempletID.Size = new System.Drawing.Size(138, 23);
            this.ctrlTempletID.TabIndex = 3;
            this.ctrlTempletID.TempletID = 1;
            // 
            // btnTemplet
            // 
            this.btnTemplet.Location = new System.Drawing.Point(203, 1);
            this.btnTemplet.Name = "btnTemplet";
            this.btnTemplet.Size = new System.Drawing.Size(53, 23);
            this.btnTemplet.TabIndex = 5;
            this.btnTemplet.Text = "生成";
            this.btnTemplet.UseVisualStyleBackColor = true;
            // 
            // CtrlParmValueOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel1);
            this.Name = "CtrlParmValueOper";
            this.Size = new System.Drawing.Size(580, 185);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnParmTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnParmValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemValues;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTemplet;
        private System.Windows.Forms.Label label2;
        private JERPApp.Define.Product.CtrlParmTemplet ctrlTempletID;
    }
}
