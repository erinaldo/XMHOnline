namespace JERPApp.Supply.Product
{
    partial class FrmOrderNoteOper
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlDeliverAddress = new JERPApp.Define.Product.CtrlBuyOrderDeliverAddress();
            this.dpkDateNote = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lnkFile = new System.Windows.Forms.LinkLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ctrlInvoiceTypeID = new JERPApp.Define.Finance.CtrlInvoiceType();
            this.txtExpressRequire = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ctrlDeliverTypeID = new JERPApp.Define.General.CtrlDeliverType();
            this.label9 = new System.Windows.Forms.Label();
            this.ctrlPriceTypeID = new JERPApp.Define.Finance.CtrlPriceType();
            this.ctrlSettleTypeID = new JERPApp.Define.Finance.CtrlSettleType();
            this.ctrlMoneyTypeID = new JERPApp.Define.Finance.CtrlMoneyType();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlCompanyID = new JERPApp.Define.General.CtrlSupplierForProduct();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNoteCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddPrd = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.rchMemo = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAssistantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPlanQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMinPackingQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateTarget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSupplierPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlDeliverAddress);
            this.panel1.Controls.Add(this.dpkDateNote);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lnkFile);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.ctrlInvoiceTypeID);
            this.panel1.Controls.Add(this.txtExpressRequire);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.ctrlDeliverTypeID);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.ctrlPriceTypeID);
            this.panel1.Controls.Add(this.ctrlSettleTypeID);
            this.panel1.Controls.Add(this.ctrlMoneyTypeID);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ctrlCompanyID);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtNoteCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 90);
            this.panel1.TabIndex = 2;
            // 
            // ctrlDeliverAddress
            // 
            this.ctrlDeliverAddress.DeliverAddress = "";
            this.ctrlDeliverAddress.Location = new System.Drawing.Point(232, 39);
            this.ctrlDeliverAddress.Name = "ctrlDeliverAddress";
            this.ctrlDeliverAddress.Size = new System.Drawing.Size(207, 23);
            this.ctrlDeliverAddress.TabIndex = 108;
            // 
            // dpkDateNote
            // 
            this.dpkDateNote.Location = new System.Drawing.Point(264, 12);
            this.dpkDateNote.Name = "dpkDateNote";
            this.dpkDateNote.Size = new System.Drawing.Size(112, 21);
            this.dpkDateNote.TabIndex = 107;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 106;
            this.label4.Text = "制单日期";
            // 
            // lnkFile
            // 
            this.lnkFile.AutoSize = true;
            this.lnkFile.Location = new System.Drawing.Point(787, 20);
            this.lnkFile.Name = "lnkFile";
            this.lnkFile.Size = new System.Drawing.Size(53, 12);
            this.lnkFile.TabIndex = 105;
            this.lnkFile.TabStop = true;
            this.lnkFile.Text = "相关文件";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(187, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 104;
            this.label10.Text = "交货地";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(604, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 103;
            this.label11.Text = "发票类型";
            // 
            // ctrlInvoiceTypeID
            // 
            this.ctrlInvoiceTypeID.InvoiceTypeID = 1;
            this.ctrlInvoiceTypeID.Location = new System.Drawing.Point(663, 63);
            this.ctrlInvoiceTypeID.Name = "ctrlInvoiceTypeID";
            this.ctrlInvoiceTypeID.Size = new System.Drawing.Size(136, 23);
            this.ctrlInvoiceTypeID.TabIndex = 102;
            // 
            // txtExpressRequire
            // 
            this.txtExpressRequire.Location = new System.Drawing.Point(508, 39);
            this.txtExpressRequire.Name = "txtExpressRequire";
            this.txtExpressRequire.Size = new System.Drawing.Size(136, 21);
            this.txtExpressRequire.TabIndex = 101;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(449, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 100;
            this.label12.Text = "物流指定";
            // 
            // ctrlDeliverTypeID
            // 
            this.ctrlDeliverTypeID.DeliverTypeID = 1;
            this.ctrlDeliverTypeID.Location = new System.Drawing.Point(704, 35);
            this.ctrlDeliverTypeID.Name = "ctrlDeliverTypeID";
            this.ctrlDeliverTypeID.Size = new System.Drawing.Size(136, 23);
            this.ctrlDeliverTypeID.TabIndex = 99;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(648, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 98;
            this.label9.Text = "送货方式";
            // 
            // ctrlPriceTypeID
            // 
            this.ctrlPriceTypeID.Location = new System.Drawing.Point(463, 66);
            this.ctrlPriceTypeID.Name = "ctrlPriceTypeID";
            this.ctrlPriceTypeID.PriceTypeID = 1;
            this.ctrlPriceTypeID.Size = new System.Drawing.Size(133, 23);
            this.ctrlPriceTypeID.TabIndex = 97;
            // 
            // ctrlSettleTypeID
            // 
            this.ctrlSettleTypeID.Location = new System.Drawing.Point(264, 66);
            this.ctrlSettleTypeID.Name = "ctrlSettleTypeID";
            this.ctrlSettleTypeID.SettleTypeID = 1;
            this.ctrlSettleTypeID.Size = new System.Drawing.Size(134, 23);
            this.ctrlSettleTypeID.TabIndex = 96;
            // 
            // ctrlMoneyTypeID
            // 
            this.ctrlMoneyTypeID.AutoSize = true;
            this.ctrlMoneyTypeID.Location = new System.Drawing.Point(56, 66);
            this.ctrlMoneyTypeID.MoneyTypeID = 1;
            this.ctrlMoneyTypeID.Name = "ctrlMoneyTypeID";
            this.ctrlMoneyTypeID.Size = new System.Drawing.Size(128, 23);
            this.ctrlMoneyTypeID.TabIndex = 95;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(404, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 94;
            this.label6.Text = "单价类型";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(199, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 93;
            this.label5.Text = "结算方式";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 92;
            this.label3.Text = "币种";
            // 
            // ctrlCompanyID
            // 
            this.ctrlCompanyID.CompanyID = -1;
            this.ctrlCompanyID.Location = new System.Drawing.Point(55, 37);
            this.ctrlCompanyID.Name = "ctrlCompanyID";
            this.ctrlCompanyID.Size = new System.Drawing.Size(129, 23);
            this.ctrlCompanyID.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "供应商";
            // 
            // txtNoteCode
            // 
            this.txtNoteCode.Location = new System.Drawing.Point(55, 12);
            this.txtNoteCode.Name = "txtNoteCode";
            this.txtNoteCode.ReadOnly = true;
            this.txtNoteCode.Size = new System.Drawing.Size(104, 21);
            this.txtNoteCode.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "订单编号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(412, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "产品采购订单";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddPrd);
            this.panel2.Controls.Add(this.btnAddItem);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.rchMemo);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 497);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(924, 33);
            this.panel2.TabIndex = 3;
            // 
            // btnAddPrd
            // 
            this.btnAddPrd.Location = new System.Drawing.Point(508, 7);
            this.btnAddPrd.Name = "btnAddPrd";
            this.btnAddPrd.Size = new System.Drawing.Size(64, 23);
            this.btnAddPrd.TabIndex = 14;
            this.btnAddPrd.Text = "+产品";
            this.btnAddPrd.UseVisualStyleBackColor = true;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(427, 6);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddItem.TabIndex = 7;
            this.btnAddItem.Text = "+采购计划";
            this.btnAddItem.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(803, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(729, 6);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "新增";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(642, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // rchMemo
            // 
            this.rchMemo.Location = new System.Drawing.Point(43, 6);
            this.rchMemo.Name = "rchMemo";
            this.rchMemo.Size = new System.Drawing.Size(374, 24);
            this.rchMemo.TabIndex = 1;
            this.rchMemo.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "备注";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgrdv
            // 
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnAssistantCode,
            this.ColumnPlanQty,
            this.ColumnMinPackingQty,
            this.ColumnQuantity,
            this.ColumnUnitName,
            this.ColumnPrice,
            this.ColumnDateTarget,
            this.ColumnMemo,
            this.ColumnSupplierPrdCode,
            this.ColumnPrdID});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 90);
            this.dgrdv.Name = "dgrdv";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(924, 407);
            this.dgrdv.TabIndex = 4;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.HeaderText = "产品编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.ReadOnly = true;
            this.ColumnPrdCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnPrdCode.Width = 120;
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
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdSpec.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnPrdSpec.HeaderText = "产品规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            this.ColumnPrdSpec.ReadOnly = true;
            this.ColumnPrdSpec.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdSpec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnModel
            // 
            this.ColumnModel.DataPropertyName = "Model";
            this.ColumnModel.HeaderText = "机型";
            this.ColumnModel.Name = "ColumnModel";
            this.ColumnModel.ReadOnly = true;
            this.ColumnModel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnModel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnModel.Width = 80;
            // 
            // ColumnAssistantCode
            // 
            this.ColumnAssistantCode.HeaderText = "助记码";
            this.ColumnAssistantCode.Name = "ColumnAssistantCode";
            this.ColumnAssistantCode.Width = 66;
            // 
            // ColumnPlanQty
            // 
            this.ColumnPlanQty.DataPropertyName = "PlanQty";
            this.ColumnPlanQty.HeaderText = "计划数";
            this.ColumnPlanQty.Name = "ColumnPlanQty";
            this.ColumnPlanQty.ReadOnly = true;
            this.ColumnPlanQty.Width = 66;
            // 
            // ColumnMinPackingQty
            // 
            this.ColumnMinPackingQty.DataPropertyName = "MinPackingQty";
            this.ColumnMinPackingQty.HeaderText = "最小包装";
            this.ColumnMinPackingQty.Name = "ColumnMinPackingQty";
            this.ColumnMinPackingQty.ReadOnly = true;
            this.ColumnMinPackingQty.Width = 80;
            // 
            // ColumnQuantity
            // 
            this.ColumnQuantity.DataPropertyName = "Quantity";
            this.ColumnQuantity.HeaderText = "数量";
            this.ColumnQuantity.Name = "ColumnQuantity";
            this.ColumnQuantity.Width = 60;
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
            this.ColumnPrice.Width = 60;
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
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnMemo.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            // 
            // ColumnSupplierPrdCode
            // 
            this.ColumnSupplierPrdCode.DataPropertyName = "SupplierPrdCode";
            this.ColumnSupplierPrdCode.HeaderText = "供应商料号";
            this.ColumnSupplierPrdCode.Name = "ColumnSupplierPrdCode";
            this.ColumnSupplierPrdCode.Width = 90;
            // 
            // ColumnPrdID
            // 
            this.ColumnPrdID.DataPropertyName = "PrdID";
            this.ColumnPrdID.HeaderText = "PrdID";
            this.ColumnPrdID.Name = "ColumnPrdID";
            this.ColumnPrdID.Visible = false;
            // 
            // FrmOrderNoteOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 530);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmOrderNoteOper";
            this.Text = "产品采购订单";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoteCode;
        private System.Windows.Forms.Panel panel2;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox rchMemo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Label label7;
        private JERPApp.Define.General.CtrlSupplierForProduct ctrlCompanyID;
        private System.Windows.Forms.LinkLabel lnkFile;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private JERPApp.Define.Finance.CtrlInvoiceType ctrlInvoiceTypeID;
        private System.Windows.Forms.TextBox txtExpressRequire;
        private System.Windows.Forms.Label label12;
        private JERPApp.Define.General.CtrlDeliverType ctrlDeliverTypeID;
        private System.Windows.Forms.Label label9;
        private JERPApp.Define.Finance.CtrlPriceType ctrlPriceTypeID;
        private JERPApp.Define.Finance.CtrlSettleType ctrlSettleTypeID;
        private JERPApp.Define.Finance.CtrlMoneyType ctrlMoneyTypeID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private JERPApp.Define.Product.CtrlBuyOrderDeliverAddress ctrlDeliverAddress;
        private System.Windows.Forms.DateTimePicker dpkDateNote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddPrd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAssistantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPlanQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMinPackingQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateTarget;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSupplierPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdID;
    }
}