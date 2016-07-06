namespace JERPApp.Engineer.Define
{
    partial class FrmDPPrdType
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemAlterType = new System.Windows.Forms.ToolStripMenuItem();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ctrlParentID = new JERPApp.Define.Product.CtrlCommonTypeTree();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.cMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(217, 455);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 46);
            this.panel1.TabIndex = 1;
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
            // dgrdv
            // 
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.类型});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Location = new System.Drawing.Point(217, 1);
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
            this.dgrdv.Size = new System.Drawing.Size(332, 455);
            this.dgrdv.TabIndex = 3;
            // 
            // ctrlParentID
            // 
            this.ctrlParentID.AutoSize = true;
            this.ctrlParentID.Location = new System.Drawing.Point(2, 3);
            this.ctrlParentID.Name = "ctrlParentID";
            this.ctrlParentID.Size = new System.Drawing.Size(213, 498);
            this.ctrlParentID.TabIndex = 0;
            // 
            // 序号
            // 
            this.序号.DataPropertyName = "PrdTypeCode";
            this.序号.HeaderText = "刀片类别编码";
            this.序号.Name = "序号";
            // 
            // 类型
            // 
            this.类型.DataPropertyName = "PrdTypeName";
            this.类型.HeaderText = "刀片类型名称";
            this.类型.Name = "类型";
            this.类型.Width = 150;
            // 
            // FrmDPPrdType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 500);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.ctrlParentID);
            this.Controls.Add(this.panel1);
            this.Name = "FrmDPPrdType";
            this.Text = "刀片类别建立";
            this.panel1.ResumeLayout(false);
            this.cMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JERPApp.Define.Product.CtrlCommonTypeTree ctrlParentID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemAlterType;
        private System.Windows.Forms.Button btnSave;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 类型;
    }
}