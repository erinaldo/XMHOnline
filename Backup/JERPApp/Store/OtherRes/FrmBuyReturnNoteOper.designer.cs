namespace JERPApp.Store.OtherRes
{
    partial class FrmBuyReturnNoteOper
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlMoneyTypeID = new JERPApp.Define.Finance.CtrlMoneyType();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrlCompanyID = new JERPApp.Define.General.CtrlSupplierForOtherRes();
            this.ctrlDeliverPsnID = new JERPApp.Define.Hr.CtrlPersonnel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlReturnHandleTypeID = new JERPApp.Define.General.CtrlReturnHandleType();
            this.tpkDateNote = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCapReturnNoteCode = new System.Windows.Forms.Label();
            this.txtNoteCode = new System.Windows.Forms.TextBox();
            this.lblCapDateReturn = new System.Windows.Forms.Label();
            this.lblCapMemo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNonAdd = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.rchMemo = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgrdvItem = new JCommon.MyDataGridView();
            this.ColumnReceiveNoteCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBranchStoreID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnInventoryQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvItem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlMoneyTypeID);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ctrlCompanyID);
            this.panel1.Controls.Add(this.ctrlDeliverPsnID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ctrlReturnHandleTypeID);
            this.panel1.Controls.Add(this.tpkDateNote);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblCapReturnNoteCode);
            this.panel1.Controls.Add(this.txtNoteCode);
            this.panel1.Controls.Add(this.lblCapDateReturn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(824, 62);
            this.panel1.TabIndex = 0;
            // 
            // ctrlMoneyTypeID
            // 
            this.ctrlMoneyTypeID.AutoSize = true;
            this.ctrlMoneyTypeID.Location = new System.Drawing.Point(499, 33);
            this.ctrlMoneyTypeID.MoneyTypeID = 1;
            this.ctrlMoneyTypeID.Name = "ctrlMoneyTypeID";
            this.ctrlMoneyTypeID.Size = new System.Drawing.Size(105, 23);
            this.ctrlMoneyTypeID.TabIndex = 131;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(464, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 130;
            this.label4.Text = "币种";
            // 
            // ctrlCompanyID
            // 
            this.ctrlCompanyID.CompanyID = -1;
            this.ctrlCompanyID.Location = new System.Drawing.Point(66, 36);
            this.ctrlCompanyID.Name = "ctrlCompanyID";
            this.ctrlCompanyID.Size = new System.Drawing.Size(195, 23);
            this.ctrlCompanyID.TabIndex = 129;
            // 
            // ctrlDeliverPsnID
            // 
            this.ctrlDeliverPsnID.AutoSize = true;
            this.ctrlDeliverPsnID.Location = new System.Drawing.Point(669, 31);
            this.ctrlDeliverPsnID.Name = "ctrlDeliverPsnID";
            this.ctrlDeliverPsnID.PsnID = -1;
            this.ctrlDeliverPsnID.Size = new System.Drawing.Size(120, 23);
            this.ctrlDeliverPsnID.TabIndex = 128;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(612, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 127;
            this.label3.Text = "送货人";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 125;
            this.label2.Text = "处理方式";
            // 
            // ctrlReturnHandleTypeID
            // 
            this.ctrlReturnHandleTypeID.AutoSize = true;
            this.ctrlReturnHandleTypeID.Location = new System.Drawing.Point(338, 33);
            this.ctrlReturnHandleTypeID.Name = "ctrlReturnHandleTypeID";
            this.ctrlReturnHandleTypeID.ReturnHandleTypeID = 1;
            this.ctrlReturnHandleTypeID.Size = new System.Drawing.Size(119, 23);
            this.ctrlReturnHandleTypeID.TabIndex = 124;
            // 
            // tpkDateNote
            // 
            this.tpkDateNote.Location = new System.Drawing.Point(669, 5);
            this.tpkDateNote.Name = "tpkDateNote";
            this.tpkDateNote.Size = new System.Drawing.Size(120, 21);
            this.tpkDateNote.TabIndex = 121;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 105;
            this.label5.Text = "供应商";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(321, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "耗材采购退货单";
            // 
            // lblCapReturnNoteCode
            // 
            this.lblCapReturnNoteCode.AutoSize = true;
            this.lblCapReturnNoteCode.Location = new System.Drawing.Point(7, 18);
            this.lblCapReturnNoteCode.Name = "lblCapReturnNoteCode";
            this.lblCapReturnNoteCode.Size = new System.Drawing.Size(53, 12);
            this.lblCapReturnNoteCode.TabIndex = 0;
            this.lblCapReturnNoteCode.Text = "退货单号";
            // 
            // txtNoteCode
            // 
            this.txtNoteCode.Location = new System.Drawing.Point(66, 9);
            this.txtNoteCode.Name = "txtNoteCode";
            this.txtNoteCode.ReadOnly = true;
            this.txtNoteCode.Size = new System.Drawing.Size(119, 21);
            this.txtNoteCode.TabIndex = 100;
            // 
            // lblCapDateReturn
            // 
            this.lblCapDateReturn.AutoSize = true;
            this.lblCapDateReturn.Location = new System.Drawing.Point(607, 13);
            this.lblCapDateReturn.Name = "lblCapDateReturn";
            this.lblCapDateReturn.Size = new System.Drawing.Size(53, 12);
            this.lblCapDateReturn.TabIndex = 2;
            this.lblCapDateReturn.Text = "退货日期";
            // 
            // lblCapMemo
            // 
            this.lblCapMemo.AutoSize = true;
            this.lblCapMemo.Location = new System.Drawing.Point(8, 19);
            this.lblCapMemo.Name = "lblCapMemo";
            this.lblCapMemo.Size = new System.Drawing.Size(29, 12);
            this.lblCapMemo.TabIndex = 16;
            this.lblCapMemo.Text = "备注";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNonAdd);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.rchMemo);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.lblCapMemo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 430);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(824, 35);
            this.panel2.TabIndex = 1;
            // 
            // btnNonAdd
            // 
            this.btnNonAdd.Location = new System.Drawing.Point(554, 6);
            this.btnNonAdd.Name = "btnNonAdd";
            this.btnNonAdd.Size = new System.Drawing.Size(76, 23);
            this.btnNonAdd.TabIndex = 122;
            this.btnNonAdd.Text = "+无送货项";
            this.btnNonAdd.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(472, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 23);
            this.btnAdd.TabIndex = 121;
            this.btnAdd.Text = "+送货项";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // rchMemo
            // 
            this.rchMemo.Location = new System.Drawing.Point(55, 3);
            this.rchMemo.Name = "rchMemo";
            this.rchMemo.Size = new System.Drawing.Size(402, 28);
            this.rchMemo.TabIndex = 119;
            this.rchMemo.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(658, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "保存入账";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // dgrdvItem
            // 
            this.dgrdvItem.AllowUserToAddRows = false;
            this.dgrdvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnReceiveNoteCode,
            this.ColumnPONo,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnBranchStoreID,
            this.ColumnInventoryQty,
            this.ColumnQuantity,
            this.ColumnUnitName,
            this.ColumnPrice,
            this.ColumnMemo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvItem.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrdvItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvItem.Location = new System.Drawing.Point(0, 62);
            this.dgrdvItem.Name = "dgrdvItem";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdvItem.RowHeadersWidth = 40;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdvItem.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvItem.RowTemplate.Height = 23;
            this.dgrdvItem.Size = new System.Drawing.Size(824, 368);
            this.dgrdvItem.TabIndex = 2;
            // 
            // ColumnReceiveNoteCode
            // 
            this.ColumnReceiveNoteCode.DataPropertyName = "ReceiveNoteCode";
            this.ColumnReceiveNoteCode.HeaderText = "送货单号";
            this.ColumnReceiveNoteCode.Name = "ColumnReceiveNoteCode";
            this.ColumnReceiveNoteCode.ReadOnly = true;
            this.ColumnReceiveNoteCode.Width = 80;
            // 
            // ColumnPONo
            // 
            this.ColumnPONo.DataPropertyName = "PONo";
            this.ColumnPONo.HeaderText = "订单编号";
            this.ColumnPONo.Name = "ColumnPONo";
            this.ColumnPONo.Width = 80;
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.HeaderText = "产品名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            this.ColumnPrdName.ReadOnly = true;
            this.ColumnPrdName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            this.ColumnPrdSpec.HeaderText = "型号及规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            this.ColumnPrdSpec.ReadOnly = true;
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
            this.ColumnInventoryQty.Width = 54;
            // 
            // ColumnQuantity
            // 
            this.ColumnQuantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle1.Format = "#,##0.####";
            this.ColumnQuantity.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnQuantity.HeaderText = "数量";
            this.ColumnQuantity.Name = "ColumnQuantity";
            this.ColumnQuantity.Width = 54;
            // 
            // ColumnUnitName
            // 
            this.ColumnUnitName.DataPropertyName = "UnitName";
            this.ColumnUnitName.HeaderText = "单位";
            this.ColumnUnitName.Name = "ColumnUnitName";
            this.ColumnUnitName.ReadOnly = true;
            this.ColumnUnitName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnUnitName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnUnitName.Width = 54;
            // 
            // ColumnPrice
            // 
            this.ColumnPrice.DataPropertyName = "Price";
            this.ColumnPrice.HeaderText = "单价";
            this.ColumnPrice.Name = "ColumnPrice";
            this.ColumnPrice.Visible = false;
            this.ColumnPrice.Width = 60;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            // 
            // FrmBuyReturnNoteOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 465);
            this.Controls.Add(this.dgrdvItem);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBuyReturnNoteOper";
            this.Text = "耗材采购退货单";
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
        private System.Windows.Forms.Label lblCapReturnNoteCode;
        private System.Windows.Forms.TextBox txtNoteCode;
        private System.Windows.Forms.Label lblCapDateReturn;
        private System.Windows.Forms.Label lblCapMemo;
        private System.Windows.Forms.Button btnSave;
        private JCommon.MyDataGridView dgrdvItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rchMemo;
        private System.Windows.Forms.DateTimePicker tpkDateNote;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private JERPApp.Define.General.CtrlReturnHandleType ctrlReturnHandleTypeID;
        private JERPApp.Define.Hr.CtrlPersonnel ctrlDeliverPsnID;
        private System.Windows.Forms.Label label3;
        private JERPApp.Define.General.CtrlSupplierForOtherRes ctrlCompanyID;
        private JERPApp.Define.Finance.CtrlMoneyType ctrlMoneyTypeID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnNonAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceiveNoteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnBranchStoreID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInventoryQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
    }
}