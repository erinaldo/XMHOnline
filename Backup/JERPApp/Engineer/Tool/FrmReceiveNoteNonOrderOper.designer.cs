namespace JERPApp.Engineer.Tool
{
    partial class FrmReceiveNoteNonOrderOper
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlInvoiceTypeID = new JERPApp.Define.Finance.CtrlInvoiceType();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ctrlQCPsnID = new JERPApp.Define.Hr.CtrlPersonnel();
            this.ctrlSettleTypeID = new JERPApp.Define.Finance.CtrlSettleType();
            this.label7 = new System.Windows.Forms.Label();
            this.ctrlPriceTypeID = new JERPApp.Define.Finance.CtrlPriceType();
            this.label6 = new System.Windows.Forms.Label();
            this.ctrlMoneyTypeID = new JERPApp.Define.Finance.CtrlMoneyType();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDateNote = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrlCompanyID = new JERPApp.Define.General.CtrlSupplierForTool();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoteCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.rchMemo = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnPriceQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPriceUnitID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlInvoiceTypeID);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.ctrlQCPsnID);
            this.panel1.Controls.Add(this.ctrlSettleTypeID);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.ctrlPriceTypeID);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.ctrlMoneyTypeID);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dtpDateNote);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ctrlCompanyID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNoteCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(863, 67);
            this.panel1.TabIndex = 2;
            // 
            // ctrlInvoiceTypeID
            // 
            this.ctrlInvoiceTypeID.InvoiceTypeID = 1;
            this.ctrlInvoiceTypeID.Location = new System.Drawing.Point(763, 38);
            this.ctrlInvoiceTypeID.Name = "ctrlInvoiceTypeID";
            this.ctrlInvoiceTypeID.Size = new System.Drawing.Size(97, 23);
            this.ctrlInvoiceTypeID.TabIndex = 117;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(704, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 116;
            this.label11.Text = "发票类型";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(713, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 115;
            this.label10.Text = "签收人";
            // 
            // ctrlQCPsnID
            // 
            this.ctrlQCPsnID.AutoSize = true;
            this.ctrlQCPsnID.Location = new System.Drawing.Point(760, 10);
            this.ctrlQCPsnID.Name = "ctrlQCPsnID";
            this.ctrlQCPsnID.PsnID = -1;
            this.ctrlQCPsnID.Size = new System.Drawing.Size(100, 23);
            this.ctrlQCPsnID.TabIndex = 114;
            // 
            // ctrlSettleTypeID
            // 
            this.ctrlSettleTypeID.Location = new System.Drawing.Point(385, 39);
            this.ctrlSettleTypeID.Name = "ctrlSettleTypeID";
            this.ctrlSettleTypeID.SettleTypeID = 1;
            this.ctrlSettleTypeID.Size = new System.Drawing.Size(122, 23);
            this.ctrlSettleTypeID.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(328, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "结算类型";
            // 
            // ctrlPriceTypeID
            // 
            this.ctrlPriceTypeID.Location = new System.Drawing.Point(572, 39);
            this.ctrlPriceTypeID.Name = "ctrlPriceTypeID";
            this.ctrlPriceTypeID.PriceTypeID = 1;
            this.ctrlPriceTypeID.Size = new System.Drawing.Size(129, 23);
            this.ctrlPriceTypeID.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(513, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "单价类型";
            // 
            // ctrlMoneyTypeID
            // 
            this.ctrlMoneyTypeID.AutoSize = true;
            this.ctrlMoneyTypeID.Location = new System.Drawing.Point(214, 39);
            this.ctrlMoneyTypeID.MoneyTypeID = 1;
            this.ctrlMoneyTypeID.Name = "ctrlMoneyTypeID";
            this.ctrlMoneyTypeID.Size = new System.Drawing.Size(108, 23);
            this.ctrlMoneyTypeID.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "币种";
            // 
            // dtpDateNote
            // 
            this.dtpDateNote.Location = new System.Drawing.Point(243, 12);
            this.dtpDateNote.Name = "dtpDateNote";
            this.dtpDateNote.Size = new System.Drawing.Size(113, 21);
            this.dtpDateNote.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "制单日期";
            // 
            // ctrlCompanyID
            // 
            this.ctrlCompanyID.CompanyID = -1;
            this.ctrlCompanyID.Location = new System.Drawing.Point(55, 39);
            this.ctrlCompanyID.Name = "ctrlCompanyID";
            this.ctrlCompanyID.Size = new System.Drawing.Size(115, 23);
            this.ctrlCompanyID.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "供应商";
            // 
            // txtNoteCode
            // 
            this.txtNoteCode.Location = new System.Drawing.Point(55, 12);
            this.txtNoteCode.Name = "txtNoteCode";
            this.txtNoteCode.Size = new System.Drawing.Size(115, 21);
            this.txtNoteCode.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "送货单号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(382, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "无订单治具采购收货";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.rchMemo);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 467);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(863, 34);
            this.panel2.TabIndex = 3;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(774, 7);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "新增";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(674, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存入账";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // rchMemo
            // 
            this.rchMemo.Location = new System.Drawing.Point(43, 6);
            this.rchMemo.Name = "rchMemo";
            this.rchMemo.Size = new System.Drawing.Size(586, 24);
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
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnQuantity,
            this.ColumnUnitName,
            this.ColumnPriceQty,
            this.ColumnPriceUnitID,
            this.ColumnPrice,
            this.ColumnMemo});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 67);
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
            this.dgrdv.Size = new System.Drawing.Size(863, 400);
            this.dgrdv.TabIndex = 4;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdID";
            this.ColumnPrdCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnPrdCode.HeaderText = "治具编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdID";
            this.ColumnPrdName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnPrdName.HeaderText = "治具名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            this.ColumnPrdName.Width = 80;
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdID";
            this.ColumnPrdSpec.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnPrdSpec.HeaderText = "治具规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            this.ColumnPrdSpec.Width = 90;
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
            this.ColumnUnitName.DataPropertyName = "PrdID";
            this.ColumnUnitName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnUnitName.HeaderText = "单位";
            this.ColumnUnitName.Name = "ColumnUnitName";
            this.ColumnUnitName.ReadOnly = true;
            this.ColumnUnitName.Width = 54;
            // 
            // ColumnPriceQty
            // 
            this.ColumnPriceQty.DataPropertyName = "PriceQty";
            this.ColumnPriceQty.HeaderText = "价格数量";
            this.ColumnPriceQty.Name = "ColumnPriceQty";
            this.ColumnPriceQty.Width = 80;
            // 
            // ColumnPriceUnitID
            // 
            this.ColumnPriceUnitID.DataPropertyName = "PriceUnitID";
            this.ColumnPriceUnitID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnPriceUnitID.HeaderText = "价格单位";
            this.ColumnPriceUnitID.Name = "ColumnPriceUnitID";
            this.ColumnPriceUnitID.Width = 80;
            // 
            // ColumnPrice
            // 
            this.ColumnPrice.DataPropertyName = "Price";
            this.ColumnPrice.HeaderText = "单价";
            this.ColumnPrice.Name = "ColumnPrice";
            this.ColumnPrice.Width = 66;
            // 
            // ColumnMemo
            // 
            this.ColumnMemo.DataPropertyName = "Memo";
            this.ColumnMemo.HeaderText = "备注";
            this.ColumnMemo.Name = "ColumnMemo";
            // 
            // FrmReceiveNoteNonOrderOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 501);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReceiveNoteNonOrderOper";
            this.Text = "无订单治具采购收货";
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
        private System.Windows.Forms.Label label7;
        private JERPApp.Define.Finance.CtrlPriceType ctrlPriceTypeID;
        private System.Windows.Forms.Label label6;
        private JERPApp.Define.Finance.CtrlMoneyType ctrlMoneyTypeID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDateNote;
        private System.Windows.Forms.Label label4;
        private JERPApp.Define.General.CtrlSupplierForTool ctrlCompanyID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNoteCode;
        private JERPApp.Define.Finance.CtrlSettleType ctrlSettleTypeID;
        private System.Windows.Forms.Panel panel2;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox rchMemo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private JERPApp.Define.Hr.CtrlPersonnel ctrlQCPsnID;
        private JERPApp.Define.Finance.CtrlInvoiceType ctrlInvoiceTypeID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPriceQty;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnPriceUnitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMemo;
    }
}