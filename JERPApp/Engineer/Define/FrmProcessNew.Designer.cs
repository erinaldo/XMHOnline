namespace JERPApp.Engineer.Define
{
    partial class FrmProcessNew
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
            this.ProcessID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModeMachineTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UseMachineID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ModelID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ToolsID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MoneyCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfirmPsnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDatetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifyDatetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctrlQFind = new JCommon.CtrlGridFind();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.panel2.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrdv
            // 
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessID,
            this.ProcessCode,
            this.ProcessName,
            this.ModeMachineTime,
            this.TimeCost,
            this.TimeTypeID,
            this.UseMachineID,
            this.ModelID,
            this.ToolsID,
            this.MoneyCost,
            this.ConfirmPsnID,
            this.ProcessMemo,
            this.CreateDatetime,
            this.ModifyDatetime});
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
            this.dgrdv.Size = new System.Drawing.Size(1144, 661);
            this.dgrdv.TabIndex = 0;
            // 
            // ProcessID
            // 
            this.ProcessID.DataPropertyName = "ProcessID";
            this.ProcessID.HeaderText = "工序ID";
            this.ProcessID.Name = "ProcessID";
            this.ProcessID.Visible = false;
            // 
            // ProcessCode
            // 
            this.ProcessCode.DataPropertyName = "ProcessCode";
            this.ProcessCode.HeaderText = "工序代码";
            this.ProcessCode.Name = "ProcessCode";
            // 
            // ProcessName
            // 
            this.ProcessName.DataPropertyName = "ProcessName";
            this.ProcessName.HeaderText = "工序名称";
            this.ProcessName.Name = "ProcessName";
            // 
            // ModeMachineTime
            // 
            this.ModeMachineTime.DataPropertyName = "ModeMachineTime";
            this.ModeMachineTime.HeaderText = "调机时间";
            this.ModeMachineTime.Name = "ModeMachineTime";
            // 
            // TimeCost
            // 
            this.TimeCost.DataPropertyName = "TimeCost";
            this.TimeCost.HeaderText = "人工耗时";
            this.TimeCost.Name = "TimeCost";
            // 
            // TimeTypeID
            // 
            this.TimeTypeID.DataPropertyName = "TimeTypeID";
            this.TimeTypeID.HeaderText = "时间单位";
            this.TimeTypeID.Name = "TimeTypeID";
            this.TimeTypeID.Visible = false;
            // 
            // UseMachineID
            // 
            this.UseMachineID.DataPropertyName = "UseMachineID";
            this.UseMachineID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UseMachineID.HeaderText = "机台";
            this.UseMachineID.Name = "UseMachineID";
            this.UseMachineID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UseMachineID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ModelID
            // 
            this.ModelID.DataPropertyName = "ModelID";
            this.ModelID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ModelID.HeaderText = "磨具";
            this.ModelID.Name = "ModelID";
            this.ModelID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ModelID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ToolsID
            // 
            this.ToolsID.DataPropertyName = "ToolsID";
            this.ToolsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToolsID.HeaderText = "工具";
            this.ToolsID.Name = "ToolsID";
            this.ToolsID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ToolsID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // MoneyCost
            // 
            this.MoneyCost.DataPropertyName = "MoneyCost";
            this.MoneyCost.HeaderText = "成本";
            this.MoneyCost.Name = "MoneyCost";
            // 
            // ConfirmPsnID
            // 
            this.ConfirmPsnID.DataPropertyName = "ConfirmPsnID";
            this.ConfirmPsnID.HeaderText = "审核人";
            this.ConfirmPsnID.Name = "ConfirmPsnID";
            this.ConfirmPsnID.Visible = false;
            // 
            // ProcessMemo
            // 
            this.ProcessMemo.DataPropertyName = "ProcessMemo";
            this.ProcessMemo.HeaderText = "备注";
            this.ProcessMemo.Name = "ProcessMemo";
            this.ProcessMemo.Width = 200;
            // 
            // CreateDatetime
            // 
            this.CreateDatetime.DataPropertyName = "CreateDatetime";
            this.CreateDatetime.HeaderText = "创建时间";
            this.CreateDatetime.Name = "CreateDatetime";
            this.CreateDatetime.Visible = false;
            // 
            // ModifyDatetime
            // 
            this.ModifyDatetime.DataPropertyName = "ModifyDatetime";
            this.ModifyDatetime.HeaderText = "修改时间";
            this.ModifyDatetime.Name = "ModifyDatetime";
            this.ModifyDatetime.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnImport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 661);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1144, 35);
            this.panel2.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(445, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
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
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(997, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "新增";
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
            // FrmProcessNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 696);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Name = "FrmProcessNew";
            this.Text = "生产工序";
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Panel panel2;
        private JCommon.CtrlGridFind ctrlQFind;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModeMachineTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeTypeID;
        private System.Windows.Forms.DataGridViewComboBoxColumn UseMachineID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ModelID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ToolsID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoneyCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfirmPsnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDatetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifyDatetime;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.Button btnSave;
    }
}