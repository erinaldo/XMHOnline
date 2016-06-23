namespace JERPApp.Manufacture
{
    partial class FrmManufPlanFromPrdBackupOrder
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label13 = new System.Windows.Forms.Label();
            this.radBuyFlag = new System.Windows.Forms.RadioButton();
            this.radManufFlag = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblUnitName = new System.Windows.Forms.Label();
            this.rchMemo = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateTarget = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radPrdStore = new System.Windows.Forms.RadioButton();
            this.ctrlCompanyID = new JERPApp.Define.General.CtrlCustomer();
            this.ctrlPrdID = new JERPApp.Define.Product.CtrlFinishedPrd();
            this.label4 = new System.Windows.Forms.Label();
            this.dgrdvPacking = new JCommon.MyDataGridView();
            this.radMtrStore = new System.Windows.Forms.RadioButton();
            this.ColumnPackingTypeID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateTarget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvPacking)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(285, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 56;
            this.label13.Text = "处理方式";
            // 
            // radBuyFlag
            // 
            this.radBuyFlag.AutoSize = true;
            this.radBuyFlag.Location = new System.Drawing.Point(401, 80);
            this.radBuyFlag.Name = "radBuyFlag";
            this.radBuyFlag.Size = new System.Drawing.Size(71, 16);
            this.radBuyFlag.TabIndex = 57;
            this.radBuyFlag.Text = "直接采购";
            this.radBuyFlag.UseVisualStyleBackColor = true;
            // 
            // radManufFlag
            // 
            this.radManufFlag.AutoSize = true;
            this.radManufFlag.Checked = true;
            this.radManufFlag.Location = new System.Drawing.Point(344, 79);
            this.radManufFlag.Name = "radManufFlag";
            this.radManufFlag.Size = new System.Drawing.Size(47, 16);
            this.radManufFlag.TabIndex = 58;
            this.radManufFlag.TabStop = true;
            this.radManufFlag.Text = "生产";
            this.radManufFlag.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1, 315);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 23);
            this.btnSave.TabIndex = 61;
            this.btnSave.Text = "计划生成";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 62;
            this.label2.Text = "数量";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(206, 45);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(74, 21);
            this.txtQuantity.TabIndex = 63;
            // 
            // lblUnitName
            // 
            this.lblUnitName.AutoSize = true;
            this.lblUnitName.Location = new System.Drawing.Point(286, 50);
            this.lblUnitName.Name = "lblUnitName";
            this.lblUnitName.Size = new System.Drawing.Size(29, 12);
            this.lblUnitName.TabIndex = 64;
            this.lblUnitName.Text = "单位";
            // 
            // rchMemo
            // 
            this.rchMemo.Location = new System.Drawing.Point(5, 126);
            this.rchMemo.Name = "rchMemo";
            this.rchMemo.Size = new System.Drawing.Size(627, 56);
            this.rchMemo.TabIndex = 73;
            this.rchMemo.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 72;
            this.label3.Text = "备注";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 70;
            this.label1.Text = "交货日期";
            // 
            // dtpDateTarget
            // 
            this.dtpDateTarget.CustomFormat = "yyyy-MM-dd H:m";
            this.dtpDateTarget.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTarget.Location = new System.Drawing.Point(387, 42);
            this.dtpDateTarget.Name = "dtpDateTarget";
            this.dtpDateTarget.Size = new System.Drawing.Size(132, 21);
            this.dtpDateTarget.TabIndex = 74;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 88;
            this.label6.Text = "客户";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 90;
            this.label5.Text = "入库类型";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radMtrStore);
            this.groupBox1.Controls.Add(this.radPrdStore);
            this.groupBox1.Location = new System.Drawing.Point(75, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(127, 29);
            this.groupBox1.TabIndex = 89;
            this.groupBox1.TabStop = false;
            // 
            // radPrdStore
            // 
            this.radPrdStore.AutoSize = true;
            this.radPrdStore.Checked = true;
            this.radPrdStore.Location = new System.Drawing.Point(7, 11);
            this.radPrdStore.Name = "radPrdStore";
            this.radPrdStore.Size = new System.Drawing.Size(47, 16);
            this.radPrdStore.TabIndex = 0;
            this.radPrdStore.TabStop = true;
            this.radPrdStore.Text = "成品";
            this.radPrdStore.UseVisualStyleBackColor = true;
            // 
            // ctrlCompanyID
            // 
            this.ctrlCompanyID.CompanyID = -1;
            this.ctrlCompanyID.Location = new System.Drawing.Point(41, 45);
            this.ctrlCompanyID.Name = "ctrlCompanyID";
            this.ctrlCompanyID.Size = new System.Drawing.Size(126, 23);
            this.ctrlCompanyID.TabIndex = 87;
            // 
            // ctrlPrdID
            // 
            this.ctrlPrdID.AutoSize = true;
            this.ctrlPrdID.Location = new System.Drawing.Point(1, 12);
            this.ctrlPrdID.Name = "ctrlPrdID";
            this.ctrlPrdID.PrdID = -1;
            this.ctrlPrdID.Size = new System.Drawing.Size(631, 29);
            this.ctrlPrdID.TabIndex = 65;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 92;
            this.label4.Text = "包装计划";
            // 
            // dgrdvPacking
            // 
            this.dgrdvPacking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvPacking.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPackingTypeID,
            this.ColumnQuantity,
            this.ColumnDateTarget,
            this.ColumnMemo});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvPacking.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdvPacking.Location = new System.Drawing.Point(5, 200);
            this.dgrdvPacking.Name = "dgrdvPacking";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvPacking.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvPacking.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdvPacking.RowTemplate.Height = 23;
            this.dgrdvPacking.Size = new System.Drawing.Size(627, 109);
            this.dgrdvPacking.TabIndex = 0;
            // 
            // radMtrStore
            // 
            this.radMtrStore.AutoSize = true;
            this.radMtrStore.Location = new System.Drawing.Point(60, 11);
            this.radMtrStore.Name = "radMtrStore";
            this.radMtrStore.Size = new System.Drawing.Size(47, 16);
            this.radMtrStore.TabIndex = 1;
            this.radMtrStore.Text = "原料";
            this.radMtrStore.UseVisualStyleBackColor = true;
            // 
            // ColumnPackingTypeID
            // 
            this.ColumnPackingTypeID.DataPropertyName = "PackingTypeID";
            this.ColumnPackingTypeID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnPackingTypeID.HeaderText = "包装类型";
            this.ColumnPackingTypeID.Name = "ColumnPackingTypeID";
            // 
            // ColumnQuantity
            // 
            this.ColumnQuantity.DataPropertyName = "Quantity";
            this.ColumnQuantity.HeaderText = "数量";
            this.ColumnQuantity.Name = "ColumnQuantity";
            this.ColumnQuantity.Width = 66;
            // 
            // ColumnDateTarget
            // 
            this.ColumnDateTarget.DataPropertyName = "DateTarget";
            this.ColumnDateTarget.HeaderText = "交货日期";
            this.ColumnDateTarget.Name = "ColumnDateTarget";
            this.ColumnDateTarget.Width = 80;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            this.ColumnMemo.Width = 200;
            // 
            // FrmManufPlanFromPrdBackupOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 350);
            this.Controls.Add(this.dgrdvPacking);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ctrlCompanyID);
            this.Controls.Add(this.dtpDateTarget);
            this.Controls.Add(this.rchMemo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlPrdID);
            this.Controls.Add(this.lblUnitName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.radBuyFlag);
            this.Controls.Add(this.radManufFlag);
            this.Name = "FrmManufPlanFromPrdBackupOrder";
            this.Text = "成品备库下单";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvPacking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton radBuyFlag;
        private System.Windows.Forms.RadioButton radManufFlag;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblUnitName;
        private JERPApp.Define.Product.CtrlFinishedPrd ctrlPrdID;
        private System.Windows.Forms.RichTextBox rchMemo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateTarget;
        private System.Windows.Forms.Label label6;
        private JERPApp.Define.General.CtrlCustomer ctrlCompanyID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radPrdStore;
        private JCommon.MyDataGridView dgrdvPacking;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radMtrStore;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnPackingTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateTarget;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
    }
}