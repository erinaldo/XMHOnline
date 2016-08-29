namespace JERPApp.Define.Manufacture
{
    partial class FrmFinishedProcessNew
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
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlQFind = new JCommon.CtrlGridFind();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dgrdv = new JCommon.MyDataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.ProcessID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSelect = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ProcessCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModeMachineTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MachineProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoneyCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfirmPsnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDatetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifyDatetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.cMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // mItemRefresh
            // 
            this.mItemRefresh.Name = "mItemRefresh";
            this.mItemRefresh.Size = new System.Drawing.Size(100, 22);
            this.mItemRefresh.Text = "刷新";
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(21, 20);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(296, 21);
            this.ctrlQFind.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 688);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1091, 55);
            this.panel2.TabIndex = 10;
            // 
            // cMenu
            // 
            this.cMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemRefresh});
            this.cMenu.Name = "cMenu";
            this.cMenu.Size = new System.Drawing.Size(101, 26);
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessID,
            this.btnSelect,
            this.ProcessCode,
            this.ProcessName,
            this.ModeMachineTime,
            this.TimeCost,
            this.TimeTypeID,
            this.MachineProcessName,
            this.ModelProcessName,
            this.ToolProcessName,
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
            this.dgrdv.Size = new System.Drawing.Size(1091, 743);
            this.dgrdv.TabIndex = 9;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(879, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭";
            // 
            // ProcessID
            // 
            this.ProcessID.DataPropertyName = "ProcessID";
            this.ProcessID.HeaderText = "工序ID";
            this.ProcessID.Name = "ProcessID";
            this.ProcessID.Visible = false;
            // 
            // btnSelect
            // 
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelect.HeaderText = "选择";
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.ReadOnly = true;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseColumnTextForButtonValue = true;
            this.btnSelect.Width = 54;
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
            // MachineProcessName
            // 
            this.MachineProcessName.DataPropertyName = "MachineProcessName";
            this.MachineProcessName.HeaderText = "机台";
            this.MachineProcessName.Name = "MachineProcessName";
            this.MachineProcessName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ModelProcessName
            // 
            this.ModelProcessName.DataPropertyName = "ModelProcessName";
            this.ModelProcessName.HeaderText = "磨具";
            this.ModelProcessName.Name = "ModelProcessName";
            this.ModelProcessName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ToolProcessName
            // 
            this.ToolProcessName.DataPropertyName = "ToolProcessName";
            this.ToolProcessName.HeaderText = "工具";
            this.ToolProcessName.Name = "ToolProcessName";
            this.ToolProcessName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            // FrmFinishedProcessNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 743);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgrdv);
            this.Name = "FrmFinishedProcessNew";
            this.Text = "FrmFinishedProcessNew";
            this.panel2.ResumeLayout(false);
            this.cMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private JCommon.CtrlGridFind ctrlQFind;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessID;
        private System.Windows.Forms.DataGridViewButtonColumn btnSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModeMachineTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToolProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoneyCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfirmPsnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDatetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifyDatetime;
    }
}