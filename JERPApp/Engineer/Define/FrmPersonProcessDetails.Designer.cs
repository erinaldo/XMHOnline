namespace JERPApp.Engineer.Define
{
    partial class FrmPersonProcessDetails
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
            this.btnSel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgrdvItems = new JCommon.MyDataGridView();
            this.ProcessTempIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkingDayID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MachineProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModeMachineTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoneyCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalTimeCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalMoneyCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.lblWorkingDayID = new System.Windows.Forms.Label();
            this.lblPsnName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSel
            // 
            this.btnSel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSel.Location = new System.Drawing.Point(74, 3);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(51, 23);
            this.btnSel.TabIndex = 11;
            this.btnSel.Text = "添加";
            this.btnSel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "工序明细";
            // 
            // dgrdvItems
            // 
            this.dgrdvItems.AllowUserToAddRows = false;
            this.dgrdvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessTempIndex,
            this.WorkingDayID,
            this.ProcessID,
            this.MachineProcessName,
            this.ModelProcessName,
            this.ToolProcessName,
            this.ModeMachineTime,
            this.TimeCost,
            this.MoneyCost,
            this.TimeCount,
            this.TotalTimeCost,
            this.TotalMoneyCost,
            this.ProcessMemo});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvItems.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdvItems.Location = new System.Drawing.Point(12, 32);
            this.dgrdvItems.Name = "dgrdvItems";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvItems.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdvItems.RowTemplate.Height = 23;
            this.dgrdvItems.Size = new System.Drawing.Size(1090, 489);
            this.dgrdvItems.TabIndex = 9;
            // 
            // ProcessTempIndex
            // 
            this.ProcessTempIndex.DataPropertyName = "ProcessTempIndex";
            this.ProcessTempIndex.HeaderText = "序号";
            this.ProcessTempIndex.Name = "ProcessTempIndex";
            this.ProcessTempIndex.Width = 60;
            // 
            // WorkingDayID
            // 
            this.WorkingDayID.DataPropertyName = "WorkingDayID";
            this.WorkingDayID.HeaderText = "模板ID";
            this.WorkingDayID.Name = "WorkingDayID";
            this.WorkingDayID.Visible = false;
            // 
            // ProcessID
            // 
            this.ProcessID.DataPropertyName = "ProcessID";
            this.ProcessID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProcessID.HeaderText = "工序名称";
            this.ProcessID.Name = "ProcessID";
            this.ProcessID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProcessID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // MachineProcessName
            // 
            this.MachineProcessName.DataPropertyName = "MachineProcessName";
            this.MachineProcessName.HeaderText = "机台";
            this.MachineProcessName.Name = "MachineProcessName";
            this.MachineProcessName.ReadOnly = true;
            // 
            // ModelProcessName
            // 
            this.ModelProcessName.DataPropertyName = "ModelProcessName";
            this.ModelProcessName.HeaderText = "磨具";
            this.ModelProcessName.Name = "ModelProcessName";
            this.ModelProcessName.ReadOnly = true;
            // 
            // ToolProcessName
            // 
            this.ToolProcessName.DataPropertyName = "ToolProcessName";
            this.ToolProcessName.HeaderText = "工具";
            this.ToolProcessName.Name = "ToolProcessName";
            this.ToolProcessName.ReadOnly = true;
            // 
            // ModeMachineTime
            // 
            this.ModeMachineTime.DataPropertyName = "ModeMachineTime";
            this.ModeMachineTime.HeaderText = "调机时间";
            this.ModeMachineTime.Name = "ModeMachineTime";
            this.ModeMachineTime.Width = 80;
            // 
            // TimeCost
            // 
            this.TimeCost.DataPropertyName = "TimeCost";
            this.TimeCost.HeaderText = "人工耗时";
            this.TimeCost.Name = "TimeCost";
            this.TimeCost.Width = 80;
            // 
            // MoneyCost
            // 
            this.MoneyCost.DataPropertyName = "MoneyCost";
            this.MoneyCost.HeaderText = "成本";
            this.MoneyCost.Name = "MoneyCost";
            this.MoneyCost.Width = 60;
            // 
            // TimeCount
            // 
            this.TimeCount.DataPropertyName = "TimeCount";
            this.TimeCount.HeaderText = "次数";
            this.TimeCount.Name = "TimeCount";
            this.TimeCount.Width = 60;
            // 
            // TotalTimeCost
            // 
            this.TotalTimeCost.DataPropertyName = "TotalTimeCost";
            this.TotalTimeCost.HeaderText = "总人工耗时";
            this.TotalTimeCost.Name = "TotalTimeCost";
            // 
            // TotalMoneyCost
            // 
            this.TotalMoneyCost.DataPropertyName = "TotalMoneyCost";
            this.TotalMoneyCost.HeaderText = "总成本";
            this.TotalMoneyCost.Name = "TotalMoneyCost";
            // 
            // ProcessMemo
            // 
            this.ProcessMemo.DataPropertyName = "ProcessMemo";
            this.ProcessMemo.HeaderText = "备注";
            this.ProcessMemo.Name = "ProcessMemo";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(334, 534);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(677, 534);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(91, 23);
            this.btnCancle.TabIndex = 13;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            // 
            // lblWorkingDayID
            // 
            this.lblWorkingDayID.AutoSize = true;
            this.lblWorkingDayID.Location = new System.Drawing.Point(631, 8);
            this.lblWorkingDayID.Name = "lblWorkingDayID";
            this.lblWorkingDayID.Size = new System.Drawing.Size(0, 12);
            this.lblWorkingDayID.TabIndex = 14;
            this.lblWorkingDayID.Visible = false;
            // 
            // lblPsnName
            // 
            this.lblPsnName.AutoSize = true;
            this.lblPsnName.Location = new System.Drawing.Point(332, 9);
            this.lblPsnName.Name = "lblPsnName";
            this.lblPsnName.Size = new System.Drawing.Size(0, 12);
            this.lblPsnName.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "姓名：";
            // 
            // FrmPersonProcessDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 569);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPsnName);
            this.Controls.Add(this.lblWorkingDayID);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgrdvItems);
            this.Name = "FrmPersonProcessDetails";
            this.Text = "工序明细";
            this.Load += new System.EventHandler(this.FrmPersonProcessDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.Label label2;
        private JCommon.MyDataGridView dgrdvItems;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Label lblWorkingDayID;
        private System.Windows.Forms.Label lblPsnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessTempIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkingDayID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProcessID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToolProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModeMachineTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoneyCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalTimeCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalMoneyCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessMemo;
        private System.Windows.Forms.Label label1;
    }
}