namespace JERPApp.Engineer
{
    partial class FrmDGDPPrdSel
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
            this.cmbMenuPrdType1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMenuPrdType4 = new System.Windows.Forms.ComboBox();
            this.cmbMenuPrdType3 = new System.Windows.Forms.ComboBox();
            this.cmbMenuPrdType2 = new System.Windows.Forms.ComboBox();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnAssistantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdCodeSrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCustomFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.chkGetTypePro = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbMenuPrdType1
            // 
            this.cmbMenuPrdType1.FormattingEnabled = true;
            this.cmbMenuPrdType1.Location = new System.Drawing.Point(38, 48);
            this.cmbMenuPrdType1.Name = "cmbMenuPrdType1";
            this.cmbMenuPrdType1.Size = new System.Drawing.Size(205, 20);
            this.cmbMenuPrdType1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkGetTypePro);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbMenuPrdType4);
            this.panel1.Controls.Add(this.cmbMenuPrdType3);
            this.panel1.Controls.Add(this.cmbMenuPrdType2);
            this.panel1.Controls.Add(this.cmbMenuPrdType1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1188, 109);
            this.panel1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(887, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "刀杆型号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(631, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "刀杆类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "机床类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "系统类型";
            // 
            // cmbMenuPrdType4
            // 
            this.cmbMenuPrdType4.FormattingEnabled = true;
            this.cmbMenuPrdType4.Location = new System.Drawing.Point(816, 48);
            this.cmbMenuPrdType4.Name = "cmbMenuPrdType4";
            this.cmbMenuPrdType4.Size = new System.Drawing.Size(205, 20);
            this.cmbMenuPrdType4.TabIndex = 3;
            // 
            // cmbMenuPrdType3
            // 
            this.cmbMenuPrdType3.FormattingEnabled = true;
            this.cmbMenuPrdType3.Location = new System.Drawing.Point(567, 48);
            this.cmbMenuPrdType3.Name = "cmbMenuPrdType3";
            this.cmbMenuPrdType3.Size = new System.Drawing.Size(205, 20);
            this.cmbMenuPrdType3.TabIndex = 2;
            // 
            // cmbMenuPrdType2
            // 
            this.cmbMenuPrdType2.FormattingEnabled = true;
            this.cmbMenuPrdType2.Location = new System.Drawing.Point(309, 48);
            this.cmbMenuPrdType2.Name = "cmbMenuPrdType2";
            this.cmbMenuPrdType2.Size = new System.Drawing.Size(205, 20);
            this.cmbMenuPrdType2.TabIndex = 1;
            // 
            // dgrdv
            // 
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnUnitID,
            this.ColumnAssistantCode,
            this.ColumnPrdCodeSrc,
            this.ColumnCustomFlag,
            this.ColumnMemo});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 109);
            this.dgrdv.Name = "dgrdv";
            this.dgrdv.ReadOnly = true;
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
            this.dgrdv.Size = new System.Drawing.Size(1188, 587);
            this.dgrdv.TabIndex = 2;
            this.dgrdv.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgrdv_DataError);
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.Frozen = true;
            this.ColumnPrdCode.HeaderText = "产品编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.ReadOnly = true;
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.Frozen = true;
            this.ColumnPrdName.HeaderText = "产品名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            this.ColumnPrdName.ReadOnly = true;
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            this.ColumnPrdSpec.Frozen = true;
            this.ColumnPrdSpec.HeaderText = "产品规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            this.ColumnPrdSpec.ReadOnly = true;
            // 
            // ColumnUnitID
            // 
            this.ColumnUnitID.DataPropertyName = "UnitID";
            this.ColumnUnitID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnUnitID.HeaderText = "单位";
            this.ColumnUnitID.Name = "ColumnUnitID";
            this.ColumnUnitID.ReadOnly = true;
            this.ColumnUnitID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnUnitID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnUnitID.Width = 54;
            // 
            // ColumnAssistantCode
            // 
            this.ColumnAssistantCode.DataPropertyName = "AssistantCode";
            this.ColumnAssistantCode.HeaderText = "助记码";
            this.ColumnAssistantCode.Name = "ColumnAssistantCode";
            this.ColumnAssistantCode.ReadOnly = true;
            // 
            // ColumnPrdCodeSrc
            // 
            this.ColumnPrdCodeSrc.DataPropertyName = "PrdCodeSrc";
            this.ColumnPrdCodeSrc.HeaderText = "对应产品编号";
            this.ColumnPrdCodeSrc.Name = "ColumnPrdCodeSrc";
            this.ColumnPrdCodeSrc.ReadOnly = true;
            this.ColumnPrdCodeSrc.Visible = false;
            // 
            // ColumnCustomFlag
            // 
            this.ColumnCustomFlag.DataPropertyName = "CustomFlag";
            this.ColumnCustomFlag.HeaderText = "客户产品";
            this.ColumnCustomFlag.Name = "ColumnCustomFlag";
            this.ColumnCustomFlag.ReadOnly = true;
            this.ColumnCustomFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnCustomFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.ReadOnly = true;
            this.ColumnMemo.Width = 180;
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
            // chkGetTypePro
            // 
            this.chkGetTypePro.AutoSize = true;
            this.chkGetTypePro.Location = new System.Drawing.Point(1064, 51);
            this.chkGetTypePro.Name = "chkGetTypePro";
            this.chkGetTypePro.Size = new System.Drawing.Size(72, 16);
            this.chkGetTypePro.TabIndex = 8;
            this.chkGetTypePro.Text = "带出刀片";
            this.chkGetTypePro.UseVisualStyleBackColor = true;
            // 
            // FrmManuPrdSel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 696);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel1);
            this.Name = "FrmManuPrdSel";
            this.Text = "商品选择";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMenuPrdType1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMenuPrdType4;
        private System.Windows.Forms.ComboBox cmbMenuPrdType3;
        private System.Windows.Forms.ComboBox cmbMenuPrdType2;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnUnitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAssistantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCodeSrc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCustomFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.CheckBox chkGetTypePro;
    }
}