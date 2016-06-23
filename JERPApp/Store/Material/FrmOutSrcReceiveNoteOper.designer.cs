namespace JERPApp.Store.Material
{
    partial class FrmOutSrcReceiveNoteOper
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放客供资源，为 true；否则为 false。</param>
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
        /// 使用代码变更器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPONo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCompanyAbbName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrlQCPsnID = new JERPApp.Define.Hr.CtrlPersonnel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNoteCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCapDateReceive = new System.Windows.Forms.Label();
            this.tpkDateNote = new System.Windows.Forms.DateTimePicker();
            this.lblCapMemo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rchMemo = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgrdvItem = new JCommon.MyDataGridView();
            this.ColumnWorkingSheetCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNonFinishedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReceiveQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBranchStoreID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnIntoMtrStoreFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvItem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPONo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtCompanyAbbName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ctrlQCPsnID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNoteCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblCapDateReceive);
            this.panel1.Controls.Add(this.tpkDateNote);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1005, 64);
            this.panel1.TabIndex = 0;
            // 
            // txtPONo
            // 
            this.txtPONo.Location = new System.Drawing.Point(69, 34);
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.ReadOnly = true;
            this.txtPONo.Size = new System.Drawing.Size(122, 21);
            this.txtPONo.TabIndex = 115;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 114;
            this.label5.Text = "订单编号";
            // 
            // txtCompanyAbbName
            // 
            this.txtCompanyAbbName.Location = new System.Drawing.Point(254, 34);
            this.txtCompanyAbbName.Name = "txtCompanyAbbName";
            this.txtCompanyAbbName.ReadOnly = true;
            this.txtCompanyAbbName.Size = new System.Drawing.Size(114, 21);
            this.txtCompanyAbbName.TabIndex = 113;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 112;
            this.label4.Text = "供应商";
            // 
            // ctrlQCPsnID
            // 
            this.ctrlQCPsnID.AutoSize = true;
            this.ctrlQCPsnID.Location = new System.Drawing.Point(629, 29);
            this.ctrlQCPsnID.Name = "ctrlQCPsnID";
            this.ctrlQCPsnID.PsnID = 1;
            this.ctrlQCPsnID.Size = new System.Drawing.Size(109, 23);
            this.ctrlQCPsnID.TabIndex = 111;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(581, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 110;
            this.label3.Text = "签收人";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 109;
            this.label2.Text = "送货单号";
            // 
            // txtNoteCode
            // 
            this.txtNoteCode.Location = new System.Drawing.Point(69, 7);
            this.txtNoteCode.Name = "txtNoteCode";
            this.txtNoteCode.Size = new System.Drawing.Size(122, 21);
            this.txtNoteCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(433, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "委外收货单";
            // 
            // lblCapDateReceive
            // 
            this.lblCapDateReceive.AutoSize = true;
            this.lblCapDateReceive.Location = new System.Drawing.Point(392, 39);
            this.lblCapDateReceive.Name = "lblCapDateReceive";
            this.lblCapDateReceive.Size = new System.Drawing.Size(53, 12);
            this.lblCapDateReceive.TabIndex = 2;
            this.lblCapDateReceive.Text = "收货日期";
            // 
            // tpkDateNote
            // 
            this.tpkDateNote.Location = new System.Drawing.Point(454, 31);
            this.tpkDateNote.Name = "tpkDateNote";
            this.tpkDateNote.Size = new System.Drawing.Size(120, 21);
            this.tpkDateNote.TabIndex = 3;
            // 
            // lblCapMemo
            // 
            this.lblCapMemo.AutoSize = true;
            this.lblCapMemo.Location = new System.Drawing.Point(12, 11);
            this.lblCapMemo.Name = "lblCapMemo";
            this.lblCapMemo.Size = new System.Drawing.Size(29, 12);
            this.lblCapMemo.TabIndex = 16;
            this.lblCapMemo.Text = "备注";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rchMemo);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.lblCapMemo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 589);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1005, 30);
            this.panel2.TabIndex = 1;
            // 
            // rchMemo
            // 
            this.rchMemo.Location = new System.Drawing.Point(47, 3);
            this.rchMemo.Name = "rchMemo";
            this.rchMemo.Size = new System.Drawing.Size(738, 24);
            this.rchMemo.TabIndex = 20;
            this.rchMemo.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(804, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "保存入账";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // dgrdvItem
            // 
            this.dgrdvItem.AllowUserToAddRows = false;
            this.dgrdvItem.AllowUserToDeleteRows = false;
            this.dgrdvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnWorkingSheetCode,
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnPrdStatus,
            this.ColumnQuantity,
            this.ColumnNonFinishedQty,
            this.ColumnReceiveQty,
            this.ColumnUnitName,
            this.ColumnBranchStoreID,
            this.ColumnIntoMtrStoreFlag});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvItem.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvItem.Location = new System.Drawing.Point(0, 64);
            this.dgrdvItem.Name = "dgrdvItem";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdvItem.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdvItem.RowTemplate.Height = 23;
            this.dgrdvItem.Size = new System.Drawing.Size(1005, 525);
            this.dgrdvItem.TabIndex = 6;
            // 
            // ColumnWorkingSheetCode
            // 
            this.ColumnWorkingSheetCode.DataPropertyName = "WorkingSheetCode";
            this.ColumnWorkingSheetCode.HeaderText = "生产批号";
            this.ColumnWorkingSheetCode.Name = "ColumnWorkingSheetCode";
            this.ColumnWorkingSheetCode.ReadOnly = true;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.HeaderText = "物料编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.ReadOnly = true;
            this.ColumnPrdCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.HeaderText = "物料名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            this.ColumnPrdName.ReadOnly = true;
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdSpec.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnPrdSpec.HeaderText = "物料规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            this.ColumnPrdSpec.ReadOnly = true;
            // 
            // ColumnModel
            // 
            this.ColumnModel.DataPropertyName = "Model";
            this.ColumnModel.HeaderText = "机型";
            this.ColumnModel.Name = "ColumnModel";
            this.ColumnModel.Width = 66;
            // 
            // ColumnPrdStatus
            // 
            this.ColumnPrdStatus.DataPropertyName = "PrdStatus";
            this.ColumnPrdStatus.HeaderText = "加工类型";
            this.ColumnPrdStatus.Name = "ColumnPrdStatus";
            this.ColumnPrdStatus.ReadOnly = true;
            this.ColumnPrdStatus.Width = 80;
            // 
            // ColumnQuantity
            // 
            this.ColumnQuantity.DataPropertyName = "Quantity";
            this.ColumnQuantity.HeaderText = "订单数";
            this.ColumnQuantity.Name = "ColumnQuantity";
            this.ColumnQuantity.ReadOnly = true;
            this.ColumnQuantity.Width = 66;
            // 
            // ColumnNonFinishedQty
            // 
            this.ColumnNonFinishedQty.DataPropertyName = "NonFinishedQty";
            dataGridViewCellStyle2.Format = "#,##0.####";
            this.ColumnNonFinishedQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnNonFinishedQty.HeaderText = "欠数";
            this.ColumnNonFinishedQty.Name = "ColumnNonFinishedQty";
            this.ColumnNonFinishedQty.ReadOnly = true;
            this.ColumnNonFinishedQty.Width = 60;
            // 
            // ColumnReceiveQty
            // 
            this.ColumnReceiveQty.DataPropertyName = "ReceiveQty";
            dataGridViewCellStyle3.Format = "#,##0.####";
            this.ColumnReceiveQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnReceiveQty.HeaderText = "到货";
            this.ColumnReceiveQty.Name = "ColumnReceiveQty";
            this.ColumnReceiveQty.Width = 60;
            // 
            // ColumnUnitName
            // 
            this.ColumnUnitName.DataPropertyName = "UnitName";
            this.ColumnUnitName.HeaderText = "单位";
            this.ColumnUnitName.Name = "ColumnUnitName";
            this.ColumnUnitName.ReadOnly = true;
            this.ColumnUnitName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnUnitName.Width = 54;
            // 
            // ColumnBranchStoreID
            // 
            this.ColumnBranchStoreID.DataPropertyName = "BranchStoreID";
            this.ColumnBranchStoreID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnBranchStoreID.HeaderText = "材料库位";
            this.ColumnBranchStoreID.Name = "ColumnBranchStoreID";
            this.ColumnBranchStoreID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnBranchStoreID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnBranchStoreID.Width = 80;
            // 
            // ColumnIntoMtrStoreFlag
            // 
            this.ColumnIntoMtrStoreFlag.DataPropertyName = "IntoMtrStoreFlag";
            this.ColumnIntoMtrStoreFlag.HeaderText = "MtrIntoStoreFlag";
            this.ColumnIntoMtrStoreFlag.Name = "ColumnIntoMtrStoreFlag";
            this.ColumnIntoMtrStoreFlag.Visible = false;
            this.ColumnIntoMtrStoreFlag.Width = 54;
            // 
            // FrmOutSrcReceiveNoteOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 619);
            this.Controls.Add(this.dgrdvItem);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmOutSrcReceiveNoteOper";
            this.Text = "委外收货单";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCapDateReceive;
        private System.Windows.Forms.DateTimePicker tpkDateNote;
        private System.Windows.Forms.Label lblCapMemo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNoteCode;
        private System.Windows.Forms.RichTextBox rchMemo;
        private JERPApp.Define.Hr.CtrlPersonnel ctrlQCPsnID;
        private System.Windows.Forms.Label label3;
        private JCommon.MyDataGridView dgrdvItem;
        private System.Windows.Forms.TextBox txtPONo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCompanyAbbName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWorkingSheetCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNonFinishedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceiveQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnBranchStoreID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIntoMtrStoreFlag;
    }
}