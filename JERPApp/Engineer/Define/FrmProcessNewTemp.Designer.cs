namespace JERPApp.Engineer.Define
{
    partial class FrmProcessNewTemp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlQFind = new JCommon.CtrlGridFind();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtProcessTempId = new System.Windows.Forms.TextBox();
            this.txtProcessMemo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProcessTempCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTimeCost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtModeMachineTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProcessTempName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgrdvItems = new JCommon.MyDataGridView();
            this.ProcessTempIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessTempId2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MachineProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModeMachineTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoneyCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgrdvNotes = new JCommon.MyDataGridView();
            this.ProcessTempId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessTempCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessTempName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvNotes)).BeginInit();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlQFind);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dgrdvNotes);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1142, 751);
            this.panel1.TabIndex = 0;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(3, 704);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(296, 21);
            this.ctrlQFind.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtProcessTempId);
            this.panel2.Controls.Add(this.txtProcessMemo);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtProcessTempCode);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtTimeCost);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtModeMachineTime);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnSel);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnCheck);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnDel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtProcessTempName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dgrdvItems);
            this.panel2.Location = new System.Drawing.Point(318, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(821, 745);
            this.panel2.TabIndex = 1;
            // 
            // txtProcessTempId
            // 
            this.txtProcessTempId.Location = new System.Drawing.Point(53, 3);
            this.txtProcessTempId.Name = "txtProcessTempId";
            this.txtProcessTempId.Size = new System.Drawing.Size(60, 21);
            this.txtProcessTempId.TabIndex = 17;
            this.txtProcessTempId.Visible = false;
            // 
            // txtProcessMemo
            // 
            this.txtProcessMemo.Location = new System.Drawing.Point(142, 112);
            this.txtProcessMemo.Multiline = true;
            this.txtProcessMemo.Name = "txtProcessMemo";
            this.txtProcessMemo.Size = new System.Drawing.Size(470, 46);
            this.txtProcessMemo.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(72, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "备注";
            // 
            // txtProcessTempCode
            // 
            this.txtProcessTempCode.Location = new System.Drawing.Point(142, 35);
            this.txtProcessTempCode.Name = "txtProcessTempCode";
            this.txtProcessTempCode.Size = new System.Drawing.Size(125, 21);
            this.txtProcessTempCode.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "模板代码";
            // 
            // txtTimeCost
            // 
            this.txtTimeCost.Enabled = false;
            this.txtTimeCost.Location = new System.Drawing.Point(442, 75);
            this.txtTimeCost.Name = "txtTimeCost";
            this.txtTimeCost.Size = new System.Drawing.Size(125, 21);
            this.txtTimeCost.TabIndex = 12;
            this.txtTimeCost.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(360, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "总人工耗时";
            // 
            // txtModeMachineTime
            // 
            this.txtModeMachineTime.Enabled = false;
            this.txtModeMachineTime.Location = new System.Drawing.Point(142, 75);
            this.txtModeMachineTime.Name = "txtModeMachineTime";
            this.txtModeMachineTime.Size = new System.Drawing.Size(125, 21);
            this.txtModeMachineTime.TabIndex = 10;
            this.txtModeMachineTime.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "总调机时间";
            // 
            // btnSel
            // 
            this.btnSel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSel.Location = new System.Drawing.Point(74, 157);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(51, 23);
            this.btnSel.TabIndex = 8;
            this.btnSel.Text = "添加";
            this.btnSel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(117, 701);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(660, 701);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 6;
            this.btnCheck.Text = "审核";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(284, 701);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(492, 701);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 4;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "工序明细";
            // 
            // txtProcessTempName
            // 
            this.txtProcessTempName.Location = new System.Drawing.Point(442, 35);
            this.txtProcessTempName.Name = "txtProcessTempName";
            this.txtProcessTempName.Size = new System.Drawing.Size(170, 21);
            this.txtProcessTempName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(360, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "模板名称";
            // 
            // dgrdvItems
            // 
            this.dgrdvItems.AllowUserToAddRows = false;
            this.dgrdvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessTempIndex,
            this.ProcessTempId2,
            this.ProcessID,
            this.MachineProcessName,
            this.ModelProcessName,
            this.ToolProcessName,
            this.ModeMachineTime,
            this.TimeCost,
            this.MoneyCost});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvItems.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdvItems.Location = new System.Drawing.Point(12, 186);
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
            this.dgrdvItems.Size = new System.Drawing.Size(806, 489);
            this.dgrdvItems.TabIndex = 0;
            // 
            // ProcessTempIndex
            // 
            this.ProcessTempIndex.DataPropertyName = "ProcessTempIndex";
            this.ProcessTempIndex.HeaderText = "序号";
            this.ProcessTempIndex.Name = "ProcessTempIndex";
            this.ProcessTempIndex.Width = 60;
            // 
            // ProcessTempId2
            // 
            this.ProcessTempId2.DataPropertyName = "ProcessTempId";
            this.ProcessTempId2.HeaderText = "模板ID";
            this.ProcessTempId2.Name = "ProcessTempId2";
            this.ProcessTempId2.Visible = false;
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
            // 
            // TimeCost
            // 
            this.TimeCost.DataPropertyName = "TimeCost";
            this.TimeCost.HeaderText = "人工耗时";
            this.TimeCost.Name = "TimeCost";
            // 
            // MoneyCost
            // 
            this.MoneyCost.DataPropertyName = "MoneyCost";
            this.MoneyCost.HeaderText = "成本";
            this.MoneyCost.Name = "MoneyCost";
            // 
            // dgrdvNotes
            // 
            this.dgrdvNotes.AllowUserToAddRows = false;
            this.dgrdvNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvNotes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessTempId,
            this.ProcessTempCode,
            this.ProcessTempName});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvNotes.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvNotes.Location = new System.Drawing.Point(3, 3);
            this.dgrdvNotes.Name = "dgrdvNotes";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvNotes.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvNotes.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdvNotes.RowTemplate.Height = 23;
            this.dgrdvNotes.Size = new System.Drawing.Size(309, 675);
            this.dgrdvNotes.TabIndex = 0;
            // 
            // ProcessTempId
            // 
            this.ProcessTempId.DataPropertyName = "ProcessTempId";
            this.ProcessTempId.HeaderText = "ID";
            this.ProcessTempId.Name = "ProcessTempId";
            this.ProcessTempId.ReadOnly = true;
            this.ProcessTempId.Visible = false;
            // 
            // ProcessTempCode
            // 
            this.ProcessTempCode.DataPropertyName = "ProcessTempCode";
            this.ProcessTempCode.HeaderText = "模板代码";
            this.ProcessTempCode.Name = "ProcessTempCode";
            this.ProcessTempCode.ReadOnly = true;
            // 
            // ProcessTempName
            // 
            this.ProcessTempName.DataPropertyName = "ProcessTempName";
            this.ProcessTempName.HeaderText = "模板名称";
            this.ProcessTempName.Name = "ProcessTempName";
            this.ProcessTempName.ReadOnly = true;
            this.ProcessTempName.Width = 200;
            // 
            // cMenu
            // 
            this.cMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemRefresh});
            this.cMenu.Name = "cMenu";
            this.cMenu.Size = new System.Drawing.Size(153, 48);
            // 
            // mItemRefresh
            // 
            this.mItemRefresh.Name = "mItemRefresh";
            this.mItemRefresh.Size = new System.Drawing.Size(152, 22);
            this.mItemRefresh.Text = "刷新";
            // 
            // FrmProcessNewTemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 752);
            this.Controls.Add(this.panel1);
            this.Name = "FrmProcessNewTemp";
            this.Text = "工序模板";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvNotes)).EndInit();
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProcessTempName;
        private System.Windows.Forms.Label label1;
        private JCommon.MyDataGridView dgrdvItems;
        private JCommon.MyDataGridView dgrdvNotes;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private JCommon.CtrlGridFind ctrlQFind;
        private System.Windows.Forms.TextBox txtTimeCost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtModeMachineTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProcessTempCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProcessMemo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProcessTempId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessTempIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessTempId2;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProcessID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToolProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModeMachineTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoneyCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessTempId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessTempCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessTempName;

    }
}