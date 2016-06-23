namespace JERPApp.Sale
{
    partial class FrmSaleDeliverPlanOper
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCompanyAbbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPONo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExpressRequire = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCapDateReceive = new System.Windows.Forms.Label();
            this.tpkDateTarget = new System.Windows.Forms.DateTimePicker();
            this.lblCapMemo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.rchMemo = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgrdvItem = new JCommon.MyDataGridView();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCustomerRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInventoryQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAllowPlanQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFinishedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgrdvOrder = new JCommon.MyDataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.btnAdd = new System.Windows.Forms.Button();
            this.ctrlCkbAll = new JCommon.CtrlGridCheckBox();
            this.ctrlInvoiceTypeID = new JERPApp.Define.Finance.CtrlInvoiceType();
            this.ctrlPriceTypeID = new JERPApp.Define.Finance.CtrlPriceType();
            this.ctrlSettleTypeID = new JERPApp.Define.Finance.CtrlSettleType();
            this.ctrlMoneyTypeID = new JERPApp.Define.Finance.CtrlMoneyType();
            this.ctrlFinanceAddressID = new JERPApp.Define.General.CtrlFinanceAddress();
            this.ctrlDeliverAddressID = new JERPApp.Define.General.CtrlDeliverAddress();
            this.ctrlDeliverTypeID = new JERPApp.Define.General.CtrlDeliverType();
            this.ColumnCheckedFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvItem)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvOrder)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCompanyAbbName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.ctrlInvoiceTypeID);
            this.panel1.Controls.Add(this.ctrlPriceTypeID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ctrlSettleTypeID);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.ctrlMoneyTypeID);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.ctrlFinanceAddressID);
            this.panel1.Controls.Add(this.ctrlDeliverAddressID);
            this.panel1.Controls.Add(this.ctrlDeliverTypeID);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtPONo);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtExpressRequire);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblCapDateReceive);
            this.panel1.Controls.Add(this.tpkDateTarget);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(914, 88);
            this.panel1.TabIndex = 0;
            // 
            // txtCompanyAbbName
            // 
            this.txtCompanyAbbName.Location = new System.Drawing.Point(58, 33);
            this.txtCompanyAbbName.Name = "txtCompanyAbbName";
            this.txtCompanyAbbName.ReadOnly = true;
            this.txtCompanyAbbName.Size = new System.Drawing.Size(120, 21);
            this.txtCompanyAbbName.TabIndex = 154;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 153;
            this.label3.Text = "客户";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(594, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 152;
            this.label14.Text = "发票类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(369, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 149;
            this.label2.Text = "单价类型";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(162, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 147;
            this.label7.Text = "结算方式";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 145;
            this.label8.Text = "币种";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(594, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 139;
            this.label11.Text = "送货方式";
            // 
            // txtPONo
            // 
            this.txtPONo.Location = new System.Drawing.Point(58, 6);
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.ReadOnly = true;
            this.txtPONo.Size = new System.Drawing.Size(120, 21);
            this.txtPONo.TabIndex = 133;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 132;
            this.label9.Text = "订单编号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(522, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 131;
            this.label4.Text = "结算地";
            // 
            // txtExpressRequire
            // 
            this.txtExpressRequire.Location = new System.Drawing.Point(818, 6);
            this.txtExpressRequire.Name = "txtExpressRequire";
            this.txtExpressRequire.Size = new System.Drawing.Size(84, 21);
            this.txtExpressRequire.TabIndex = 129;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(759, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 128;
            this.label12.Text = "物流指定";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(194, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 121;
            this.label6.Text = "送货地";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(417, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "销售出货申请单";
            // 
            // lblCapDateReceive
            // 
            this.lblCapDateReceive.AutoSize = true;
            this.lblCapDateReceive.Location = new System.Drawing.Point(184, 13);
            this.lblCapDateReceive.Name = "lblCapDateReceive";
            this.lblCapDateReceive.Size = new System.Drawing.Size(53, 12);
            this.lblCapDateReceive.TabIndex = 2;
            this.lblCapDateReceive.Text = "出库日期";
            // 
            // tpkDateTarget
            // 
            this.tpkDateTarget.Location = new System.Drawing.Point(243, 9);
            this.tpkDateTarget.Name = "tpkDateTarget";
            this.tpkDateTarget.Size = new System.Drawing.Size(120, 21);
            this.tpkDateTarget.TabIndex = 3;
            // 
            // lblCapMemo
            // 
            this.lblCapMemo.AutoSize = true;
            this.lblCapMemo.Location = new System.Drawing.Point(19, 8);
            this.lblCapMemo.Name = "lblCapMemo";
            this.lblCapMemo.Size = new System.Drawing.Size(29, 12);
            this.lblCapMemo.TabIndex = 16;
            this.lblCapMemo.Text = "备注";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.rchMemo);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.lblCapMemo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 516);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(914, 30);
            this.panel2.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(816, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 23);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // rchMemo
            // 
            this.rchMemo.Location = new System.Drawing.Point(60, 1);
            this.rchMemo.Name = "rchMemo";
            this.rchMemo.Size = new System.Drawing.Size(596, 27);
            this.rchMemo.TabIndex = 20;
            this.rchMemo.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(726, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // dgrdvItem
            // 
            this.dgrdvItem.AllowUserToAddRows = false;
            this.dgrdvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnCustomerRef,
            this.ColumnInventoryQty,
            this.ColumnAllowPlanQty,
            this.ColumnQuantity,
            this.ColumnPrice,
            this.ColumnFinishedQty,
            this.dataGridViewTextBoxColumn5,
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
            this.dgrdvItem.Location = new System.Drawing.Point(0, 0);
            this.dgrdvItem.Name = "dgrdvItem";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdvItem.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvItem.RowTemplate.Height = 23;
            this.dgrdvItem.Size = new System.Drawing.Size(914, 210);
            this.dgrdvItem.TabIndex = 5;
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
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdSpec.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnPrdSpec.HeaderText = "产品规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            this.ColumnPrdSpec.ReadOnly = true;
            this.ColumnPrdSpec.Width = 80;
            // 
            // ColumnModel
            // 
            this.ColumnModel.DataPropertyName = "Model";
            this.ColumnModel.HeaderText = "机型";
            this.ColumnModel.Name = "ColumnModel";
            this.ColumnModel.ReadOnly = true;
            this.ColumnModel.Width = 80;
            // 
            // ColumnCustomerRef
            // 
            this.ColumnCustomerRef.DataPropertyName = "CustomerRef";
            this.ColumnCustomerRef.HeaderText = "客户料号";
            this.ColumnCustomerRef.Name = "ColumnCustomerRef";
            this.ColumnCustomerRef.Width = 80;
            // 
            // ColumnInventoryQty
            // 
            this.ColumnInventoryQty.DataPropertyName = "InventoryQty";
            this.ColumnInventoryQty.HeaderText = "库存";
            this.ColumnInventoryQty.Name = "ColumnInventoryQty";
            this.ColumnInventoryQty.ReadOnly = true;
            this.ColumnInventoryQty.Width = 66;
            // 
            // ColumnAllowPlanQty
            // 
            this.ColumnAllowPlanQty.DataPropertyName = "AllowPlanQty";
            this.ColumnAllowPlanQty.HeaderText = "可申请";
            this.ColumnAllowPlanQty.Name = "ColumnAllowPlanQty";
            this.ColumnAllowPlanQty.ReadOnly = true;
            this.ColumnAllowPlanQty.Width = 66;
            // 
            // ColumnQuantity
            // 
            this.ColumnQuantity.DataPropertyName = "Quantity";
            this.ColumnQuantity.HeaderText = "申请数";
            this.ColumnQuantity.Name = "ColumnQuantity";
            this.ColumnQuantity.Width = 66;
            // 
            // ColumnPrice
            // 
            this.ColumnPrice.DataPropertyName = "Price";
            this.ColumnPrice.HeaderText = "单价";
            this.ColumnPrice.Name = "ColumnPrice";
            this.ColumnPrice.Width = 54;
            // 
            // ColumnFinishedQty
            // 
            this.ColumnFinishedQty.DataPropertyName = "FinishedQty";
            this.ColumnFinishedQty.HeaderText = "送货";
            this.ColumnFinishedQty.Name = "ColumnFinishedQty";
            this.ColumnFinishedQty.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "UnitName";
            this.dataGridViewTextBoxColumn5.HeaderText = "单位";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.Width = 54;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 88);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgrdvOrder);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgrdvItem);
            this.splitContainer1.Size = new System.Drawing.Size(914, 428);
            this.splitContainer1.SplitterDistance = 214;
            this.splitContainer1.TabIndex = 6;
            // 
            // dgrdvOrder
            // 
            this.dgrdvOrder.AllowUserToAddRows = false;
            this.dgrdvOrder.AllowUserToDeleteRows = false;
            this.dgrdvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCheckedFlag,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvOrder.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdvOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvOrder.Location = new System.Drawing.Point(0, 0);
            this.dgrdvOrder.Name = "dgrdvOrder";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdvOrder.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgrdvOrder.RowTemplate.Height = 23;
            this.dgrdvOrder.Size = new System.Drawing.Size(914, 185);
            this.dgrdvOrder.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ctrlQFind);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.ctrlCkbAll);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 185);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(914, 29);
            this.panel3.TabIndex = 9;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(61, 3);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(287, 21);
            this.ctrlQFind.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(354, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "+加入";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // ctrlCkbAll
            // 
            this.ctrlCkbAll.CheckedFlag = false;
            this.ctrlCkbAll.Location = new System.Drawing.Point(7, 6);
            this.ctrlCkbAll.Margin = new System.Windows.Forms.Padding(0);
            this.ctrlCkbAll.Name = "ctrlCkbAll";
            this.ctrlCkbAll.SeachGridView = null;
            this.ctrlCkbAll.Size = new System.Drawing.Size(52, 18);
            this.ctrlCkbAll.TabIndex = 0;
            // 
            // ctrlInvoiceTypeID
            // 
            this.ctrlInvoiceTypeID.InvoiceTypeID = 1;
            this.ctrlInvoiceTypeID.Location = new System.Drawing.Point(653, 60);
            this.ctrlInvoiceTypeID.Name = "ctrlInvoiceTypeID";
            this.ctrlInvoiceTypeID.Size = new System.Drawing.Size(119, 23);
            this.ctrlInvoiceTypeID.TabIndex = 151;
            // 
            // ctrlPriceTypeID
            // 
            this.ctrlPriceTypeID.Location = new System.Drawing.Point(428, 60);
            this.ctrlPriceTypeID.Name = "ctrlPriceTypeID";
            this.ctrlPriceTypeID.PriceTypeID = 1;
            this.ctrlPriceTypeID.Size = new System.Drawing.Size(148, 23);
            this.ctrlPriceTypeID.TabIndex = 150;
            // 
            // ctrlSettleTypeID
            // 
            this.ctrlSettleTypeID.Location = new System.Drawing.Point(227, 62);
            this.ctrlSettleTypeID.Name = "ctrlSettleTypeID";
            this.ctrlSettleTypeID.SettleTypeID = 1;
            this.ctrlSettleTypeID.Size = new System.Drawing.Size(136, 23);
            this.ctrlSettleTypeID.TabIndex = 148;
            // 
            // ctrlMoneyTypeID
            // 
            this.ctrlMoneyTypeID.AutoSize = true;
            this.ctrlMoneyTypeID.Location = new System.Drawing.Point(58, 62);
            this.ctrlMoneyTypeID.MoneyTypeID = 1;
            this.ctrlMoneyTypeID.Name = "ctrlMoneyTypeID";
            this.ctrlMoneyTypeID.Size = new System.Drawing.Size(98, 23);
            this.ctrlMoneyTypeID.TabIndex = 146;
            // 
            // ctrlFinanceAddressID
            // 
            this.ctrlFinanceAddressID.FinanceAddressID = -1;
            this.ctrlFinanceAddressID.Location = new System.Drawing.Point(564, 33);
            this.ctrlFinanceAddressID.Name = "ctrlFinanceAddressID";
            this.ctrlFinanceAddressID.Size = new System.Drawing.Size(338, 23);
            this.ctrlFinanceAddressID.TabIndex = 142;
            // 
            // ctrlDeliverAddressID
            // 
            this.ctrlDeliverAddressID.DeliverAddressID = -1;
            this.ctrlDeliverAddressID.Location = new System.Drawing.Point(241, 33);
            this.ctrlDeliverAddressID.Name = "ctrlDeliverAddressID";
            this.ctrlDeliverAddressID.Size = new System.Drawing.Size(275, 23);
            this.ctrlDeliverAddressID.TabIndex = 141;
            // 
            // ctrlDeliverTypeID
            // 
            this.ctrlDeliverTypeID.DeliverTypeID = 1;
            this.ctrlDeliverTypeID.Location = new System.Drawing.Point(653, 7);
            this.ctrlDeliverTypeID.Name = "ctrlDeliverTypeID";
            this.ctrlDeliverTypeID.Size = new System.Drawing.Size(100, 23);
            this.ctrlDeliverTypeID.TabIndex = 140;
            // 
            // ColumnCheckedFlag
            // 
            this.ColumnCheckedFlag.DataPropertyName = "CheckedFlag";
            this.ColumnCheckedFlag.HeaderText = "选择";
            this.ColumnCheckedFlag.Name = "ColumnCheckedFlag";
            this.ColumnCheckedFlag.Width = 54;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PrdCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "产品编号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PrdName";
            this.dataGridViewTextBoxColumn2.HeaderText = "产品名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PrdSpec";
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn3.HeaderText = "产品规格";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Model";
            this.dataGridViewTextBoxColumn4.HeaderText = "机型";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "CustomerRef";
            this.dataGridViewTextBoxColumn6.HeaderText = "客户料号";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "InventoryQty";
            this.dataGridViewTextBoxColumn7.HeaderText = "库存";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 66;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "NonDeliverPlanQty";
            this.dataGridViewTextBoxColumn8.HeaderText = "未申请";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 66;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Price";
            this.dataGridViewTextBoxColumn9.HeaderText = "单价";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 54;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "UnitName";
            this.dataGridViewTextBoxColumn12.HeaderText = "单位";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn12.Width = 54;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Memo";
            this.dataGridViewTextBoxColumn13.HeaderText = "备注";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // FrmSaleDeliverPlanOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 546);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSaleDeliverPlanOper";
            this.Text = "销售出货申请单";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvItem)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvOrder)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCapDateReceive;
        private System.Windows.Forms.DateTimePicker tpkDateTarget;
        private System.Windows.Forms.Label lblCapMemo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox rchMemo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtExpressRequire;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private JCommon.MyDataGridView dgrdvItem;
        private System.Windows.Forms.TextBox txtPONo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private JERPApp.Define.General.CtrlDeliverType ctrlDeliverTypeID;
        private JERPApp.Define.General.CtrlFinanceAddress ctrlFinanceAddressID;
        private JERPApp.Define.General.CtrlDeliverAddress ctrlDeliverAddressID;
        private System.Windows.Forms.Label label14;
        private JERPApp.Define.Finance.CtrlInvoiceType ctrlInvoiceTypeID;
        private JERPApp.Define.Finance.CtrlPriceType ctrlPriceTypeID;
        private System.Windows.Forms.Label label2;
        private JERPApp.Define.Finance.CtrlSettleType ctrlSettleTypeID;
        private System.Windows.Forms.Label label7;
        private JERPApp.Define.Finance.CtrlMoneyType ctrlMoneyTypeID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtCompanyAbbName;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private JCommon.MyDataGridView dgrdvOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCustomerRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInventoryQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAllowPlanQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFinishedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
        private System.Windows.Forms.Panel panel3;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private System.Windows.Forms.Button btnAdd;
        private JCommon.CtrlGridCheckBox ctrlCkbAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheckedFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
    }
}