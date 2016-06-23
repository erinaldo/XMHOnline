namespace JERPApp.Store.Product
{
    partial class FrmSaleReplenishNoteOper
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCompanyAbbName = new System.Windows.Forms.TextBox();
            this.ctrlDeliverAddressID = new JERPApp.Define.General.CtrlDeliverAddress();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ctrlDeliverPsnID = new JERPApp.Define.Hr.CtrlPersonnel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNoteCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCapDateReceive = new System.Windows.Forms.Label();
            this.tpkDateNote = new System.Windows.Forms.DateTimePicker();
            this.lblCapMemo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rchMemo = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgrdvItem = new JCommon.MyDataGridView();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBranchStoreID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnInventoryQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReplenishQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFromBox = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvItem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCompanyAbbName);
            this.panel1.Controls.Add(this.ctrlDeliverAddressID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.ctrlDeliverPsnID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNoteCode);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblCapDateReceive);
            this.panel1.Controls.Add(this.tpkDateNote);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 64);
            this.panel1.TabIndex = 0;
            // 
            // txtCompanyAbbName
            // 
            this.txtCompanyAbbName.Location = new System.Drawing.Point(219, 33);
            this.txtCompanyAbbName.Name = "txtCompanyAbbName";
            this.txtCompanyAbbName.ReadOnly = true;
            this.txtCompanyAbbName.Size = new System.Drawing.Size(131, 21);
            this.txtCompanyAbbName.TabIndex = 126;
            // 
            // ctrlDeliverAddressID
            // 
            this.ctrlDeliverAddressID.DeliverAddressID = -1;
            this.ctrlDeliverAddressID.Location = new System.Drawing.Point(404, 34);
            this.ctrlDeliverAddressID.Name = "ctrlDeliverAddressID";
            this.ctrlDeliverAddressID.Size = new System.Drawing.Size(366, 23);
            this.ctrlDeliverAddressID.TabIndex = 125;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(356, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 124;
            this.label3.Text = "送货地";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(619, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 119;
            this.label6.Text = "送货人";
            // 
            // ctrlDeliverPsnID
            // 
            this.ctrlDeliverPsnID.AutoSize = true;
            this.ctrlDeliverPsnID.Location = new System.Drawing.Point(666, 5);
            this.ctrlDeliverPsnID.Name = "ctrlDeliverPsnID";
            this.ctrlDeliverPsnID.PsnID = -1;
            this.ctrlDeliverPsnID.Size = new System.Drawing.Size(104, 23);
            this.ctrlDeliverPsnID.TabIndex = 118;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 109;
            this.label2.Text = "补货单号";
            // 
            // txtNoteCode
            // 
            this.txtNoteCode.Location = new System.Drawing.Point(63, 7);
            this.txtNoteCode.Name = "txtNoteCode";
            this.txtNoteCode.Size = new System.Drawing.Size(120, 21);
            this.txtNoteCode.TabIndex = 110;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 105;
            this.label5.Text = "客户";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(355, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "产品销售补货单";
            // 
            // lblCapDateReceive
            // 
            this.lblCapDateReceive.AutoSize = true;
            this.lblCapDateReceive.Location = new System.Drawing.Point(1, 41);
            this.lblCapDateReceive.Name = "lblCapDateReceive";
            this.lblCapDateReceive.Size = new System.Drawing.Size(53, 12);
            this.lblCapDateReceive.TabIndex = 2;
            this.lblCapDateReceive.Text = "制单日期";
            // 
            // tpkDateNote
            // 
            this.tpkDateNote.Location = new System.Drawing.Point(63, 33);
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
            this.panel2.Controls.Add(this.btnFromBox);
            this.panel2.Controls.Add(this.rchMemo);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.lblCapMemo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 516);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(802, 30);
            this.panel2.TabIndex = 1;
            // 
            // rchMemo
            // 
            this.rchMemo.Location = new System.Drawing.Point(47, 2);
            this.rchMemo.Name = "rchMemo";
            this.rchMemo.Size = new System.Drawing.Size(517, 27);
            this.rchMemo.TabIndex = 20;
            this.rchMemo.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(684, 3);
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
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnBranchStoreID,
            this.ColumnInventoryQty,
            this.ColumnQuantity,
            this.ColumnReplenishQty,
            this.ColumnUnitName,
            this.ColumnMemo1});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvItem.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgrdvItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvItem.Location = new System.Drawing.Point(0, 64);
            this.dgrdvItem.Name = "dgrdvItem";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdvItem.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgrdvItem.RowTemplate.Height = 23;
            this.dgrdvItem.Size = new System.Drawing.Size(802, 452);
            this.dgrdvItem.TabIndex = 6;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.HeaderText = "产品编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.ReadOnly = true;
            this.ColumnPrdCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.HeaderText = "产品名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            this.ColumnPrdName.ReadOnly = true;
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdSpec.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColumnPrdSpec.HeaderText = "产品规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            this.ColumnPrdSpec.ReadOnly = true;
            // 
            // ColumnModel
            // 
            this.ColumnModel.DataPropertyName = "Model";
            this.ColumnModel.HeaderText = "机型";
            this.ColumnModel.Name = "ColumnModel";
            this.ColumnModel.ReadOnly = true;
            this.ColumnModel.Width = 80;
            // 
            // ColumnBranchStoreID
            // 
            this.ColumnBranchStoreID.DataPropertyName = "BranchStoreID";
            this.ColumnBranchStoreID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnBranchStoreID.HeaderText = "库位";
            this.ColumnBranchStoreID.Name = "ColumnBranchStoreID";
            this.ColumnBranchStoreID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnBranchStoreID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnBranchStoreID.Width = 80;
            // 
            // ColumnInventoryQty
            // 
            this.ColumnInventoryQty.DataPropertyName = "InventoryQty";
            this.ColumnInventoryQty.HeaderText = "库存";
            this.ColumnInventoryQty.Name = "ColumnInventoryQty";
            this.ColumnInventoryQty.ReadOnly = true;
            this.ColumnInventoryQty.Width = 60;
            // 
            // ColumnQuantity
            // 
            this.ColumnQuantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle8.Format = "#,##0.####";
            this.ColumnQuantity.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColumnQuantity.HeaderText = "欠数";
            this.ColumnQuantity.Name = "ColumnQuantity";
            this.ColumnQuantity.ReadOnly = true;
            this.ColumnQuantity.Width = 60;
            // 
            // ColumnReplenishQty
            // 
            this.ColumnReplenishQty.DataPropertyName = "ReplenishQty";
            dataGridViewCellStyle9.Format = "#,##0.####";
            this.ColumnReplenishQty.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColumnReplenishQty.HeaderText = "补货";
            this.ColumnReplenishQty.Name = "ColumnReplenishQty";
            this.ColumnReplenishQty.Width = 60;
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
            // ColumnMemo1
            // 
            this.ColumnMemo1.DataPropertyName = "Memo";
            this.ColumnMemo1.HeaderText = "备注";
            this.ColumnMemo1.Name = "ColumnMemo1";
            // 
            // btnFromBox
            // 
            this.btnFromBox.Location = new System.Drawing.Point(585, 4);
            this.btnFromBox.Name = "btnFromBox";
            this.btnFromBox.Size = new System.Drawing.Size(75, 23);
            this.btnFromBox.TabIndex = 21;
            this.btnFromBox.Text = "+扫箱";
            this.btnFromBox.UseVisualStyleBackColor = true;
            // 
            // FrmSaleReplenishNoteOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 546);
            this.Controls.Add(this.dgrdvItem);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSaleReplenishNoteOper";
            this.Text = "产品销售补货单";
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNoteCode;
        private System.Windows.Forms.RichTextBox rchMemo;
        private System.Windows.Forms.Label label6;
        private JERPApp.Define.Hr.CtrlPersonnel ctrlDeliverPsnID;
        private JERPApp.Define.General.CtrlDeliverAddress ctrlDeliverAddressID;
        private System.Windows.Forms.Label label3;
        private JCommon.MyDataGridView dgrdvItem;
        private System.Windows.Forms.TextBox txtCompanyAbbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnBranchStoreID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInventoryQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReplenishQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo1;
        private System.Windows.Forms.Button btnFromBox;
    }
}