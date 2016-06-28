namespace JERPApp.Engineer.Define
{
    partial class FrmManuPrdTypeRelation
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
            this.dgrdv = new JCommon.MyDataGridView();
            this.btnDel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescTypeID = new System.Windows.Forms.TextBox();
            this.txtSrcTypeID = new System.Windows.Forms.TextBox();
            this.txtDescTypeName = new System.Windows.Forms.TextBox();
            this.btnDescType = new System.Windows.Forms.Button();
            this.txtSrcTypeName = new System.Windows.Forms.TextBox();
            this.btnSrcType = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.columnSel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnSrcTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSrcTypeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSrcTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescTypeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.panel1.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnSel,
            this.ColumnSrcTypeID,
            this.ColumnSrcTypeCode,
            this.ColumnSrcTypeName,
            this.ColumnDescTypeID,
            this.ColumnDescTypeCode,
            this.ColumnDescTypeName});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Location = new System.Drawing.Point(25, 163);
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
            this.dgrdv.Size = new System.Drawing.Size(546, 339);
            this.dgrdv.TabIndex = 0;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(455, 528);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(74, 31);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDescTypeID);
            this.panel1.Controls.Add(this.txtSrcTypeID);
            this.panel1.Controls.Add(this.txtDescTypeName);
            this.panel1.Controls.Add(this.btnDescType);
            this.panel1.Controls.Add(this.txtSrcTypeName);
            this.panel1.Controls.Add(this.btnSrcType);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Location = new System.Drawing.Point(25, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(546, 131);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "请添加刀杆刀片的对应关系";
            // 
            // txtDescTypeID
            // 
            this.txtDescTypeID.Location = new System.Drawing.Point(339, 92);
            this.txtDescTypeID.Name = "txtDescTypeID";
            this.txtDescTypeID.Size = new System.Drawing.Size(25, 21);
            this.txtDescTypeID.TabIndex = 6;
            this.txtDescTypeID.Visible = false;
            // 
            // txtSrcTypeID
            // 
            this.txtSrcTypeID.Enabled = false;
            this.txtSrcTypeID.Location = new System.Drawing.Point(339, 49);
            this.txtSrcTypeID.Name = "txtSrcTypeID";
            this.txtSrcTypeID.Size = new System.Drawing.Size(25, 21);
            this.txtSrcTypeID.TabIndex = 5;
            this.txtSrcTypeID.Visible = false;
            // 
            // txtDescTypeName
            // 
            this.txtDescTypeName.Enabled = false;
            this.txtDescTypeName.Location = new System.Drawing.Point(128, 92);
            this.txtDescTypeName.Name = "txtDescTypeName";
            this.txtDescTypeName.Size = new System.Drawing.Size(190, 21);
            this.txtDescTypeName.TabIndex = 4;
            // 
            // btnDescType
            // 
            this.btnDescType.Location = new System.Drawing.Point(30, 92);
            this.btnDescType.Name = "btnDescType";
            this.btnDescType.Size = new System.Drawing.Size(75, 25);
            this.btnDescType.TabIndex = 3;
            this.btnDescType.Text = "选择刀片";
            this.btnDescType.UseVisualStyleBackColor = true;
            // 
            // txtSrcTypeName
            // 
            this.txtSrcTypeName.Enabled = false;
            this.txtSrcTypeName.Location = new System.Drawing.Point(128, 49);
            this.txtSrcTypeName.Name = "txtSrcTypeName";
            this.txtSrcTypeName.Size = new System.Drawing.Size(190, 21);
            this.txtSrcTypeName.TabIndex = 2;
            // 
            // btnSrcType
            // 
            this.btnSrcType.Location = new System.Drawing.Point(30, 49);
            this.btnSrcType.Name = "btnSrcType";
            this.btnSrcType.Size = new System.Drawing.Size(75, 25);
            this.btnSrcType.TabIndex = 1;
            this.btnSrcType.Text = "选择刀杠";
            this.btnSrcType.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(415, 67);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 36);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "确认添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // cMenu
            // 
            this.cMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemRefresh});
            this.cMenu.Name = "cMenu";
            this.cMenu.Size = new System.Drawing.Size(101, 26);
            // 
            // mItemRefresh
            // 
            this.mItemRefresh.Name = "mItemRefresh";
            this.mItemRefresh.Size = new System.Drawing.Size(100, 22);
            this.mItemRefresh.Text = "刷新";
            // 
            // columnSel
            // 
            this.columnSel.DataPropertyName = "CheckedFlag";
            this.columnSel.HeaderText = "选择";
            this.columnSel.Name = "columnSel";
            this.columnSel.Width = 60;
            // 
            // ColumnSrcTypeID
            // 
            this.ColumnSrcTypeID.DataPropertyName = "PrdIDSrc";
            this.ColumnSrcTypeID.HeaderText = "刀杠ID";
            this.ColumnSrcTypeID.Name = "ColumnSrcTypeID";
            this.ColumnSrcTypeID.ReadOnly = true;
            this.ColumnSrcTypeID.Visible = false;
            // 
            // ColumnSrcTypeCode
            // 
            this.ColumnSrcTypeCode.DataPropertyName = "SrcTypeCode";
            this.ColumnSrcTypeCode.HeaderText = "刀杠编码";
            this.ColumnSrcTypeCode.Name = "ColumnSrcTypeCode";
            this.ColumnSrcTypeCode.ReadOnly = true;
            this.ColumnSrcTypeCode.Visible = false;
            // 
            // ColumnSrcTypeName
            // 
            this.ColumnSrcTypeName.DataPropertyName = "SrcTypeName";
            this.ColumnSrcTypeName.HeaderText = "刀杠类型";
            this.ColumnSrcTypeName.Name = "ColumnSrcTypeName";
            this.ColumnSrcTypeName.ReadOnly = true;
            this.ColumnSrcTypeName.Width = 120;
            // 
            // ColumnDescTypeID
            // 
            this.ColumnDescTypeID.DataPropertyName = "PrdIDDesc";
            this.ColumnDescTypeID.HeaderText = "刀片ID";
            this.ColumnDescTypeID.Name = "ColumnDescTypeID";
            this.ColumnDescTypeID.ReadOnly = true;
            this.ColumnDescTypeID.Visible = false;
            // 
            // ColumnDescTypeCode
            // 
            this.ColumnDescTypeCode.DataPropertyName = "DescTypeCode";
            this.ColumnDescTypeCode.HeaderText = "刀片编码";
            this.ColumnDescTypeCode.Name = "ColumnDescTypeCode";
            this.ColumnDescTypeCode.ReadOnly = true;
            this.ColumnDescTypeCode.Visible = false;
            // 
            // ColumnDescTypeName
            // 
            this.ColumnDescTypeName.DataPropertyName = "DescTypeName";
            this.ColumnDescTypeName.HeaderText = "刀片类型";
            this.ColumnDescTypeName.Name = "ColumnDescTypeName";
            this.ColumnDescTypeName.ReadOnly = true;
            this.ColumnDescTypeName.Width = 120;
            // 
            // FrmManuPrdTypeRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 582);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.dgrdv);
            this.Name = "FrmManuPrdTypeRelation";
            this.Text = "刀杠刀片对应关系";
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDescTypeName;
        private System.Windows.Forms.Button btnDescType;
        private System.Windows.Forms.TextBox txtSrcTypeName;
        private System.Windows.Forms.Button btnSrcType;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.TextBox txtDescTypeID;
        private System.Windows.Forms.TextBox txtSrcTypeID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnSel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSrcTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSrcTypeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSrcTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescTypeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescTypeName;

    }
}