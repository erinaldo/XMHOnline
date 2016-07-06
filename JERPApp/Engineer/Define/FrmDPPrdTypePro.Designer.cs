namespace JERPApp.Engineer.Define
{
    partial class FrmDPPrdTypePro
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgrdv = new JCommon.MyDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctrlParentID = new JERPApp.Define.Product.CtrlDPTypeTreePro();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemAlterType = new System.Windows.Forms.ToolStripMenuItem();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.panel1.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrdv
            // 
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.类型});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdv.Location = new System.Drawing.Point(216, 0);
            this.dgrdv.Name = "dgrdv";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(332, 455);
            this.dgrdv.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(216, 454);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 46);
            this.panel1.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(183, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // ctrlParentID
            // 
            this.ctrlParentID.Location = new System.Drawing.Point(0, 0);
            this.ctrlParentID.Name = "ctrlParentID";
            this.ctrlParentID.Size = new System.Drawing.Size(210, 500);
            this.ctrlParentID.TabIndex = 7;
            // 
            // cMenu
            // 
            this.cMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemAlterType});
            this.cMenu.Name = "cMenu";
            this.cMenu.Size = new System.Drawing.Size(125, 26);
            // 
            // mItemAlterType
            // 
            this.mItemAlterType.Name = "mItemAlterType";
            this.mItemAlterType.Size = new System.Drawing.Size(124, 22);
            this.mItemAlterType.Text = "变更父级";
            // 
            // 序号
            // 
            this.序号.DataPropertyName = "PrdTypeCode";
            this.序号.HeaderText = "属性类别编码";
            this.序号.Name = "序号";
            // 
            // 类型
            // 
            this.类型.DataPropertyName = "PrdTypeName";
            this.类型.HeaderText = "属性类别名称";
            this.类型.Name = "类型";
            this.类型.Width = 150;
            // 
            // FrmDPPrdTypePro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 503);
            this.Controls.Add(this.ctrlParentID);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel1);
            this.Name = "FrmDPPrdTypePro";
            this.Text = "刀片属性类别";
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private JERPApp.Define.Product.CtrlDPTypeTreePro ctrlParentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 类型;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemAlterType;
    }
}