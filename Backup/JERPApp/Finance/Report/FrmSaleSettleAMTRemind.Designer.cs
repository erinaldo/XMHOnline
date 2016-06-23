namespace JERPApp.Finance.Report
{
    partial class FrmSaleSettleAMTRemind
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDateDiff = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgrdvCustomer = new JCommon.MyDataGridView();
            this.ColumnCheckedFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReconciliationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalePsn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnYear1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSettleTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPriceTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotalAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFinishedAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNonFinishedAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCustomerExplore = new System.Windows.Forms.Button();
            this.ctrlCustomerFind = new JCommon.CtrlGridQuickFind();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgrdvExpress = new JCommon.MyDataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnExpressExport = new System.Windows.Forms.Button();
            this.ctrlExpressFind = new JCommon.CtrlGridQuickFind();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvCustomer)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvExpress)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtDateDiff);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 37);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "天";
            // 
            // txtDateDiff
            // 
            this.txtDateDiff.Location = new System.Drawing.Point(38, 13);
            this.txtDateDiff.Name = "txtDateDiff";
            this.txtDateDiff.Size = new System.Drawing.Size(43, 21);
            this.txtDateDiff.TabIndex = 3;
            this.txtDateDiff.Text = "30";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "提前";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(455, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "销售结款预警";
            // 
            // dgrdvCustomer
            // 
            this.dgrdvCustomer.AllowUserToAddRows = false;
            this.dgrdvCustomer.AllowUserToDeleteRows = false;
            this.dgrdvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCheckedFlag,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.ColumnReconciliationName,
            this.dataGridViewTextBoxColumn3,
            this.ColumnSalePsn,
            this.ColumnYear1,
            this.ColumnMonth,
            this.dataGridViewTextBoxColumn6,
            this.ColumnSettleTypeName,
            this.ColumnPriceTypeName,
            this.ColumnTotalAMT,
            this.ColumnFinishedAMT,
            this.ColumnNonFinishedAMT});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvCustomer.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdvCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvCustomer.Location = new System.Drawing.Point(3, 3);
            this.dgrdvCustomer.Name = "dgrdvCustomer";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvCustomer.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdvCustomer.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdvCustomer.RowTemplate.Height = 23;
            this.dgrdvCustomer.Size = new System.Drawing.Size(964, 371);
            this.dgrdvCustomer.TabIndex = 12;
            // 
            // ColumnCheckedFlag
            // 
            this.ColumnCheckedFlag.DataPropertyName = "CheckedFlag";
            this.ColumnCheckedFlag.HeaderText = "选择";
            this.ColumnCheckedFlag.Name = "ColumnCheckedFlag";
            this.ColumnCheckedFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnCheckedFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnCheckedFlag.Width = 54;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ReconciliationCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "对账单号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 78;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DateSettle";
            this.dataGridViewTextBoxColumn2.HeaderText = "结算日期";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 78;
            // 
            // ColumnReconciliationName
            // 
            this.ColumnReconciliationName.DataPropertyName = "ReconciliationName";
            this.ColumnReconciliationName.HeaderText = "对账单名称";
            this.ColumnReconciliationName.Name = "ColumnReconciliationName";
            this.ColumnReconciliationName.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CompanyAbbName";
            this.dataGridViewTextBoxColumn3.HeaderText = "客户";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // ColumnSalePsn
            // 
            this.ColumnSalePsn.DataPropertyName = "SalePsn";
            this.ColumnSalePsn.HeaderText = "业务";
            this.ColumnSalePsn.Name = "ColumnSalePsn";
            this.ColumnSalePsn.Width = 66;
            // 
            // ColumnYear1
            // 
            this.ColumnYear1.DataPropertyName = "Year";
            this.ColumnYear1.HeaderText = "年";
            this.ColumnYear1.Name = "ColumnYear1";
            this.ColumnYear1.Width = 40;
            // 
            // ColumnMonth
            // 
            this.ColumnMonth.DataPropertyName = "Month";
            this.ColumnMonth.HeaderText = "月";
            this.ColumnMonth.Name = "ColumnMonth";
            this.ColumnMonth.Width = 30;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "MoneyTypeName";
            this.dataGridViewTextBoxColumn6.HeaderText = "币种";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 54;
            // 
            // ColumnSettleTypeName
            // 
            this.ColumnSettleTypeName.DataPropertyName = "SettleTypeName";
            this.ColumnSettleTypeName.HeaderText = "结算方式";
            this.ColumnSettleTypeName.Name = "ColumnSettleTypeName";
            this.ColumnSettleTypeName.Width = 80;
            // 
            // ColumnPriceTypeName
            // 
            this.ColumnPriceTypeName.DataPropertyName = "PriceTypeName";
            this.ColumnPriceTypeName.HeaderText = "单价类型";
            this.ColumnPriceTypeName.Name = "ColumnPriceTypeName";
            this.ColumnPriceTypeName.Width = 80;
            // 
            // ColumnTotalAMT
            // 
            this.ColumnTotalAMT.DataPropertyName = "TotalAMT";
            this.ColumnTotalAMT.HeaderText = "金额";
            this.ColumnTotalAMT.Name = "ColumnTotalAMT";
            this.ColumnTotalAMT.Width = 66;
            // 
            // ColumnFinishedAMT
            // 
            this.ColumnFinishedAMT.DataPropertyName = "FinishedAMT";
            this.ColumnFinishedAMT.HeaderText = "已结";
            this.ColumnFinishedAMT.Name = "ColumnFinishedAMT";
            this.ColumnFinishedAMT.Width = 66;
            // 
            // ColumnNonFinishedAMT
            // 
            this.ColumnNonFinishedAMT.DataPropertyName = "NonFinishedAMT";
            this.ColumnNonFinishedAMT.HeaderText = "未结";
            this.ColumnNonFinishedAMT.Name = "ColumnNonFinishedAMT";
            this.ColumnNonFinishedAMT.Width = 66;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 37);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(978, 432);
            this.tabMain.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgrdvCustomer);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(970, 406);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "客户结款";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCustomerExplore);
            this.panel2.Controls.Add(this.ctrlCustomerFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 374);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(964, 29);
            this.panel2.TabIndex = 12;
            // 
            // btnCustomerExplore
            // 
            this.btnCustomerExplore.Location = new System.Drawing.Point(267, 2);
            this.btnCustomerExplore.Name = "btnCustomerExplore";
            this.btnCustomerExplore.Size = new System.Drawing.Size(77, 25);
            this.btnCustomerExplore.TabIndex = 4;
            this.btnCustomerExplore.Text = "输出打印";
            this.btnCustomerExplore.UseVisualStyleBackColor = true;
            // 
            // ctrlCustomerFind
            // 
            this.ctrlCustomerFind.Location = new System.Drawing.Point(3, 5);
            this.ctrlCustomerFind.Name = "ctrlCustomerFind";
            this.ctrlCustomerFind.SeachGridView = null;
            this.ctrlCustomerFind.Size = new System.Drawing.Size(244, 21);
            this.ctrlCustomerFind.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgrdvExpress);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(970, 406);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "代收结款";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgrdvExpress
            // 
            this.dgrdvExpress.AllowUserToAddRows = false;
            this.dgrdvExpress.AllowUserToDeleteRows = false;
            this.dgrdvExpress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvExpress.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvExpress.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvExpress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvExpress.Location = new System.Drawing.Point(3, 3);
            this.dgrdvExpress.Name = "dgrdvExpress";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvExpress.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdvExpress.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdvExpress.RowTemplate.Height = 23;
            this.dgrdvExpress.Size = new System.Drawing.Size(964, 371);
            this.dgrdvExpress.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnExpressExport);
            this.panel3.Controls.Add(this.ctrlExpressFind);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 374);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(964, 29);
            this.panel3.TabIndex = 13;
            // 
            // btnExpressExport
            // 
            this.btnExpressExport.Location = new System.Drawing.Point(267, 1);
            this.btnExpressExport.Name = "btnExpressExport";
            this.btnExpressExport.Size = new System.Drawing.Size(77, 25);
            this.btnExpressExport.TabIndex = 4;
            this.btnExpressExport.Text = "输出打印";
            this.btnExpressExport.UseVisualStyleBackColor = true;
            // 
            // ctrlExpressFind
            // 
            this.ctrlExpressFind.Location = new System.Drawing.Point(3, 5);
            this.ctrlExpressFind.Name = "ctrlExpressFind";
            this.ctrlExpressFind.SeachGridView = null;
            this.ctrlExpressFind.Size = new System.Drawing.Size(244, 21);
            this.ctrlExpressFind.TabIndex = 0;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "CheckedFlag";
            this.dataGridViewCheckBoxColumn1.HeaderText = "选择";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.Width = 54;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ReconciliationCode";
            this.dataGridViewTextBoxColumn4.HeaderText = "对账单号";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 78;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DateSettle";
            this.dataGridViewTextBoxColumn5.HeaderText = "结算日期";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 78;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ReconciliationName";
            this.dataGridViewTextBoxColumn7.HeaderText = "对账单名称";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "CompanyName";
            this.dataGridViewTextBoxColumn8.HeaderText = "快递公司";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Year";
            this.dataGridViewTextBoxColumn10.HeaderText = "年";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 40;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Month";
            this.dataGridViewTextBoxColumn11.HeaderText = "月";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 30;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "MoneyTypeName";
            this.dataGridViewTextBoxColumn12.HeaderText = "币种";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 54;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "TotalAMT";
            this.dataGridViewTextBoxColumn15.HeaderText = "金额";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Width = 66;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "FinishedAMT";
            this.dataGridViewTextBoxColumn16.HeaderText = "已结";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Width = 66;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "NonFinishedAMT";
            this.dataGridViewTextBoxColumn17.HeaderText = "未结";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Width = 66;
            // 
            // FrmSaleSettleAMTRemind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 469);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSaleSettleAMTRemind";
            this.Text = "FrmSaleSettleAMTRemind";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvCustomer)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvExpress)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDateDiff;
        private JCommon.MyDataGridView dgrdvCustomer;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheckedFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReconciliationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalePsn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnYear1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSettleTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPriceTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFinishedAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNonFinishedAMT;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCustomerExplore;
        private JCommon.CtrlGridQuickFind ctrlCustomerFind;
        private System.Windows.Forms.TabPage tabPage2;
        private JCommon.MyDataGridView dgrdvExpress;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnExpressExport;
        private JCommon.CtrlGridQuickFind ctrlExpressFind;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
    }
}