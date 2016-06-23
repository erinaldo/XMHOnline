namespace JERPApp.Manufacture
{
    partial class FrmManufPlanFromSaleOrder
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.radBuyFlag = new System.Windows.Forms.RadioButton();
            this.radManufFlag = new System.Windows.Forms.RadioButton();
            this.rchMemo = new System.Windows.Forms.RichTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtStoreQty = new System.Windows.Forms.TextBox();
            this.txtNonHandleQty = new System.Windows.Forms.TextBox();
            this.txtPrdSpec = new System.Windows.Forms.TextBox();
            this.txtPrdName = new System.Windows.Forms.TextBox();
            this.txtPrdCode = new System.Windows.Forms.TextBox();
            this.txtPONo = new System.Windows.Forms.TextBox();
            this.txtHandlePsn = new System.Windows.Forms.TextBox();
            this.txtCompanyCode = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRequireQty = new System.Windows.Forms.TextBox();
            this.txtAppendQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRoadQty = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.dtpDateTarget = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.dgrdvPackingPlan = new JCommon.MyDataGridView();
            this.ColumnPackingTypeID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateTarget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvPackingPlan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "客户";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "跟单员";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(375, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "订单编号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "未处理";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "产品规格";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(193, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "产品名称";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "产品编号";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(192, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "有效库存";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(160, 209);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 12;
            this.label13.Text = "不足处理";
            // 
            // radBuyFlag
            // 
            this.radBuyFlag.AutoSize = true;
            this.radBuyFlag.Location = new System.Drawing.Point(276, 207);
            this.radBuyFlag.Name = "radBuyFlag";
            this.radBuyFlag.Size = new System.Drawing.Size(71, 16);
            this.radBuyFlag.TabIndex = 13;
            this.radBuyFlag.Text = "直接采购";
            this.radBuyFlag.UseVisualStyleBackColor = true;
            // 
            // radManufFlag
            // 
            this.radManufFlag.AutoSize = true;
            this.radManufFlag.Checked = true;
            this.radManufFlag.Location = new System.Drawing.Point(219, 206);
            this.radManufFlag.Name = "radManufFlag";
            this.radManufFlag.Size = new System.Drawing.Size(47, 16);
            this.radManufFlag.TabIndex = 14;
            this.radManufFlag.TabStop = true;
            this.radManufFlag.Text = "生产";
            this.radManufFlag.UseVisualStyleBackColor = true;
            // 
            // rchMemo
            // 
            this.rchMemo.Location = new System.Drawing.Point(9, 109);
            this.rchMemo.Name = "rchMemo";
            this.rchMemo.Size = new System.Drawing.Size(554, 50);
            this.rchMemo.TabIndex = 39;
            this.rchMemo.Text = "";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 96);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 38;
            this.label18.Text = "备注";
            // 
            // txtStoreQty
            // 
            this.txtStoreQty.Location = new System.Drawing.Point(249, 171);
            this.txtStoreQty.Name = "txtStoreQty";
            this.txtStoreQty.ReadOnly = true;
            this.txtStoreQty.Size = new System.Drawing.Size(93, 21);
            this.txtStoreQty.TabIndex = 27;
            // 
            // txtNonHandleQty
            // 
            this.txtNonHandleQty.Location = new System.Drawing.Point(65, 170);
            this.txtNonHandleQty.Name = "txtNonHandleQty";
            this.txtNonHandleQty.ReadOnly = true;
            this.txtNonHandleQty.Size = new System.Drawing.Size(121, 21);
            this.txtNonHandleQty.TabIndex = 26;
            // 
            // txtPrdSpec
            // 
            this.txtPrdSpec.Location = new System.Drawing.Point(66, 66);
            this.txtPrdSpec.Name = "txtPrdSpec";
            this.txtPrdSpec.ReadOnly = true;
            this.txtPrdSpec.Size = new System.Drawing.Size(120, 21);
            this.txtPrdSpec.TabIndex = 24;
            // 
            // txtPrdName
            // 
            this.txtPrdName.Location = new System.Drawing.Point(250, 41);
            this.txtPrdName.Name = "txtPrdName";
            this.txtPrdName.ReadOnly = true;
            this.txtPrdName.Size = new System.Drawing.Size(121, 21);
            this.txtPrdName.TabIndex = 23;
            // 
            // txtPrdCode
            // 
            this.txtPrdCode.Location = new System.Drawing.Point(66, 41);
            this.txtPrdCode.Name = "txtPrdCode";
            this.txtPrdCode.ReadOnly = true;
            this.txtPrdCode.Size = new System.Drawing.Size(121, 21);
            this.txtPrdCode.TabIndex = 22;
            // 
            // txtPONo
            // 
            this.txtPONo.Location = new System.Drawing.Point(429, 11);
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.ReadOnly = true;
            this.txtPONo.Size = new System.Drawing.Size(121, 21);
            this.txtPONo.TabIndex = 21;
            // 
            // txtHandlePsn
            // 
            this.txtHandlePsn.Location = new System.Drawing.Point(250, 12);
            this.txtHandlePsn.Name = "txtHandlePsn";
            this.txtHandlePsn.ReadOnly = true;
            this.txtHandlePsn.Size = new System.Drawing.Size(121, 21);
            this.txtHandlePsn.TabIndex = 20;
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.Location = new System.Drawing.Point(66, 13);
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.ReadOnly = true;
            this.txtCompanyCode.Size = new System.Drawing.Size(121, 21);
            this.txtCompanyCode.TabIndex = 19;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(13, 343);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "计划生成";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 40;
            this.label2.Text = "不足";
            // 
            // txtRequireQty
            // 
            this.txtRequireQty.Location = new System.Drawing.Point(66, 200);
            this.txtRequireQty.Name = "txtRequireQty";
            this.txtRequireQty.ReadOnly = true;
            this.txtRequireQty.Size = new System.Drawing.Size(84, 21);
            this.txtRequireQty.TabIndex = 41;
            // 
            // txtAppendQty
            // 
            this.txtAppendQty.Location = new System.Drawing.Point(406, 200);
            this.txtAppendQty.Name = "txtAppendQty";
            this.txtAppendQty.Size = new System.Drawing.Size(59, 21);
            this.txtAppendQty.TabIndex = 43;
            this.txtAppendQty.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(359, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 42;
            this.label5.Text = "+损耗";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(360, 179);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 44;
            this.label11.Text = "有效在途";
            // 
            // txtRoadQty
            // 
            this.txtRoadQty.Location = new System.Drawing.Point(419, 171);
            this.txtRoadQty.Name = "txtRoadQty";
            this.txtRoadQty.ReadOnly = true;
            this.txtRoadQty.Size = new System.Drawing.Size(108, 21);
            this.txtRoadQty.TabIndex = 45;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(193, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 67;
            this.label12.Text = "机型";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(250, 68);
            this.txtModel.Name = "txtModel";
            this.txtModel.ReadOnly = true;
            this.txtModel.Size = new System.Drawing.Size(121, 21);
            this.txtModel.TabIndex = 68;
            // 
            // dtpDateTarget
            // 
            this.dtpDateTarget.CustomFormat = "yyyy-MM-dd H:m";
            this.dtpDateTarget.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTarget.Location = new System.Drawing.Point(431, 68);
            this.dtpDateTarget.Name = "dtpDateTarget";
            this.dtpDateTarget.Size = new System.Drawing.Size(132, 21);
            this.dtpDateTarget.TabIndex = 73;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(375, 75);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 72;
            this.label14.Text = "交货日期";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(97, 343);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 23);
            this.btnCancel.TabIndex = 74;
            this.btnCancel.Text = "不作计划";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 232);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 94;
            this.label15.Text = "包装计划";
            // 
            // dgrdvPackingPlan
            // 
            this.dgrdvPackingPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvPackingPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dgrdvPackingPlan.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdvPackingPlan.Location = new System.Drawing.Point(14, 247);
            this.dgrdvPackingPlan.Name = "dgrdvPackingPlan";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvPackingPlan.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvPackingPlan.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdvPackingPlan.RowTemplate.Height = 23;
            this.dgrdvPackingPlan.Size = new System.Drawing.Size(573, 90);
            this.dgrdvPackingPlan.TabIndex = 0;
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
            // FrmManufPlanFromSaleOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 372);
            this.Controls.Add(this.dgrdvPackingPlan);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dtpDateTarget);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRoadQty);
            this.Controls.Add(this.txtAppendQty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRequireQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rchMemo);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.radBuyFlag);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.radManufFlag);
            this.Controls.Add(this.txtStoreQty);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNonHandleQty);
            this.Controls.Add(this.txtPrdSpec);
            this.Controls.Add(this.txtPrdName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrdCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPONo);
            this.Controls.Add(this.txtHandlePsn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCompanyCode);
            this.Name = "FrmManufPlanFromSaleOrder";
            this.Text = "客户订单计划";
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvPackingPlan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton radBuyFlag;
        private System.Windows.Forms.RadioButton radManufFlag;
        private System.Windows.Forms.TextBox txtStoreQty;
        private System.Windows.Forms.TextBox txtNonHandleQty;
        private System.Windows.Forms.TextBox txtPrdSpec;
        private System.Windows.Forms.TextBox txtPrdName;
        private System.Windows.Forms.TextBox txtPrdCode;
        private System.Windows.Forms.TextBox txtPONo;
        private System.Windows.Forms.TextBox txtHandlePsn;
        private System.Windows.Forms.TextBox txtCompanyCode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox rchMemo;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRequireQty;
        private System.Windows.Forms.TextBox txtAppendQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRoadQty;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.DateTimePicker dtpDateTarget;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label15;
        private JCommon.MyDataGridView dgrdvPackingPlan;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnPackingTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateTarget;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
    }
}