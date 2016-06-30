namespace JERPApp.Engineer
{
    partial class FrmManuPrdDefine
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlQFind = new JCommon.CtrlGridFind();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemPrdType = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlPrdTypeID = new JERPApp.Define.Product.CtrlCommonTypeTree();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnAssistantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdCodeSrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCustomFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.panel2.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.dgrdv.Location = new System.Drawing.Point(176, 0);
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
            this.dgrdv.Size = new System.Drawing.Size(1018, 624);
            this.dgrdv.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnImport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(176, 624);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1018, 35);
            this.panel2.TabIndex = 6;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(20, 8);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(296, 21);
            this.ctrlQFind.TabIndex = 5;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(692, 8);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "输出Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(408, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(582, 8);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Excel导入";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // cMenu
            // 
            this.cMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemRefresh,
            this.mItemPrdType});
            this.cMenu.Name = "cMenu";
            this.cMenu.Size = new System.Drawing.Size(125, 48);
            // 
            // mItemRefresh
            // 
            this.mItemRefresh.Name = "mItemRefresh";
            this.mItemRefresh.Size = new System.Drawing.Size(124, 22);
            this.mItemRefresh.Text = "刷新";
            // 
            // mItemPrdType
            // 
            this.mItemPrdType.Name = "mItemPrdType";
            this.mItemPrdType.Size = new System.Drawing.Size(124, 22);
            this.mItemPrdType.Text = "变更类型";
            // 
            // ctrlPrdTypeID
            // 
            this.ctrlPrdTypeID.AutoSize = true;
            this.ctrlPrdTypeID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPrdTypeID.Location = new System.Drawing.Point(0, 0);
            this.ctrlPrdTypeID.Name = "ctrlPrdTypeID";
            this.ctrlPrdTypeID.Size = new System.Drawing.Size(176, 659);
            this.ctrlPrdTypeID.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlPrdTypeID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 659);
            this.panel1.TabIndex = 14;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.Frozen = true;
            this.ColumnPrdCode.HeaderText = "产品编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.Frozen = true;
            this.ColumnPrdName.HeaderText = "产品名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            this.ColumnPrdSpec.Frozen = true;
            this.ColumnPrdSpec.HeaderText = "产品规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            // 
            // ColumnUnitID
            // 
            this.ColumnUnitID.DataPropertyName = "UnitID";
            this.ColumnUnitID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnUnitID.HeaderText = "单位";
            this.ColumnUnitID.Name = "ColumnUnitID";
            this.ColumnUnitID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnUnitID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnUnitID.Width = 54;
            // 
            // ColumnAssistantCode
            // 
            this.ColumnAssistantCode.DataPropertyName = "AssistantCode";
            this.ColumnAssistantCode.HeaderText = "助记码";
            this.ColumnAssistantCode.Name = "ColumnAssistantCode";
            // 
            // ColumnPrdCodeSrc
            // 
            this.ColumnPrdCodeSrc.DataPropertyName = "PrdCodeSrc";
            this.ColumnPrdCodeSrc.HeaderText = "对应产品编号";
            this.ColumnPrdCodeSrc.Name = "ColumnPrdCodeSrc";
            this.ColumnPrdCodeSrc.Visible = false;
            // 
            // ColumnCustomFlag
            // 
            this.ColumnCustomFlag.DataPropertyName = "CustomFlag";
            this.ColumnCustomFlag.HeaderText = "客户产品";
            this.ColumnCustomFlag.Name = "ColumnCustomFlag";
            this.ColumnCustomFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnCustomFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.Width = 180;
            // 
            // FrmManuPrdDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 659);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmManuPrdDefine";
            this.Text = "FrmManuPrdDefine";
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.cMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Panel panel2;
        private JCommon.CtrlGridFind ctrlQFind;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.ToolStripMenuItem mItemPrdType;
        private JERPApp.Define.Product.CtrlCommonTypeTree ctrlPrdTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnUnitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAssistantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCodeSrc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCustomFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.Panel panel1;
    }
}