namespace JERPApp.Manufacture.Report.Bill
{
    partial class FrmWorkingSheet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPONo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtWorkingSheetCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrdSpec = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrdName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCompanyCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrdCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDateTarget = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.dgrdvSchedule = new JCommon.MyDataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgrdvOutSrc = new JCommon.MyDataGridView();
            this.ColumnPrdStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutSrcSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFinishedQty = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnNonFinishedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateTarget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnlnkBOM = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLinkColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnBOMFinishedQty1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvSchedule)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvOutSrc)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPONo);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtModel);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtWorkingSheetCode);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtPrdSpec);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtQuantity);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtPrdName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtCompanyCode);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtPrdCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 53);
            this.panel1.TabIndex = 0;
            // 
            // txtPONo
            // 
            this.txtPONo.Location = new System.Drawing.Point(578, 4);
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.ReadOnly = true;
            this.txtPONo.Size = new System.Drawing.Size(90, 21);
            this.txtPONo.TabIndex = 80;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(521, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 79;
            this.label11.Text = "订单编号";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(611, 30);
            this.txtModel.Name = "txtModel";
            this.txtModel.ReadOnly = true;
            this.txtModel.Size = new System.Drawing.Size(110, 21);
            this.txtModel.TabIndex = 78;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(576, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 77;
            this.label10.Text = "机型";
            // 
            // txtWorkingSheetCode
            // 
            this.txtWorkingSheetCode.Location = new System.Drawing.Point(62, 5);
            this.txtWorkingSheetCode.Name = "txtWorkingSheetCode";
            this.txtWorkingSheetCode.ReadOnly = true;
            this.txtWorkingSheetCode.Size = new System.Drawing.Size(120, 21);
            this.txtWorkingSheetCode.TabIndex = 76;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 75;
            this.label9.Text = "生产批号";
            // 
            // txtPrdSpec
            // 
            this.txtPrdSpec.Location = new System.Drawing.Point(443, 29);
            this.txtPrdSpec.Name = "txtPrdSpec";
            this.txtPrdSpec.ReadOnly = true;
            this.txtPrdSpec.Size = new System.Drawing.Size(132, 21);
            this.txtPrdSpec.TabIndex = 74;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(384, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 73;
            this.label8.Text = "产品规格";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(762, 29);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.Size = new System.Drawing.Size(70, 21);
            this.txtQuantity.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(727, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "数量";
            // 
            // txtPrdName
            // 
            this.txtPrdName.Location = new System.Drawing.Point(247, 29);
            this.txtPrdName.Name = "txtPrdName";
            this.txtPrdName.ReadOnly = true;
            this.txtPrdName.Size = new System.Drawing.Size(132, 21);
            this.txtPrdName.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "产品名称";
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.Location = new System.Drawing.Point(247, 5);
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.ReadOnly = true;
            this.txtCompanyCode.Size = new System.Drawing.Size(90, 21);
            this.txtCompanyCode.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "客户";
            // 
            // txtPrdCode
            // 
            this.txtPrdCode.Location = new System.Drawing.Point(62, 30);
            this.txtPrdCode.Name = "txtPrdCode";
            this.txtPrdCode.ReadOnly = true;
            this.txtPrdCode.Size = new System.Drawing.Size(120, 21);
            this.txtPrdCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "产品编号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(383, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "生产制令单";
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(38, 6);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.ReadOnly = true;
            this.txtMemo.Size = new System.Drawing.Size(412, 21);
            this.txtMemo.TabIndex = 72;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 71;
            this.label7.Text = "备注";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtDateTarget);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.txtMemo);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 467);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(848, 30);
            this.panel2.TabIndex = 1;
            // 
            // txtDateTarget
            // 
            this.txtDateTarget.Location = new System.Drawing.Point(523, 3);
            this.txtDateTarget.Name = "txtDateTarget";
            this.txtDateTarget.ReadOnly = true;
            this.txtDateTarget.Size = new System.Drawing.Size(104, 21);
            this.txtDateTarget.TabIndex = 74;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(468, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 73;
            this.label5.Text = "交货日期";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(757, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "输出打印";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // dgrdvSchedule
            // 
            this.dgrdvSchedule.AllowUserToAddRows = false;
            this.dgrdvSchedule.AllowUserToDeleteRows = false;
            this.dgrdvSchedule.ColumnHeadersHeight = 41;
            this.dgrdvSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPrdStatus,
            this.ColumnOutSrcSupplier,
            this.ColumnQuantity,
            this.ColumnFinishedQty,
            this.ColumnNonFinishedQty,
            this.ColumnDateTarget,
            this.ColumnlnkBOM});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvSchedule.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgrdvSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvSchedule.Location = new System.Drawing.Point(0, 0);
            this.dgrdvSchedule.Name = "dgrdvSchedule";
            this.dgrdvSchedule.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvSchedule.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvSchedule.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdvSchedule.RowTemplate.Height = 23;
            this.dgrdvSchedule.Size = new System.Drawing.Size(848, 298);
            this.dgrdvSchedule.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 53);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgrdvSchedule);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgrdvOutSrc);
            this.splitContainer1.Size = new System.Drawing.Size(848, 414);
            this.splitContainer1.SplitterDistance = 298;
            this.splitContainer1.TabIndex = 3;
            // 
            // dgrdvOutSrc
            // 
            this.dgrdvOutSrc.AllowUserToAddRows = false;
            this.dgrdvOutSrc.AllowUserToDeleteRows = false;
            this.dgrdvOutSrc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdvOutSrc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewLinkColumn1,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.ColumnBOMFinishedQty1,
            this.dataGridViewTextBoxColumn8});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvOutSrc.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdvOutSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvOutSrc.Location = new System.Drawing.Point(0, 0);
            this.dgrdvOutSrc.Name = "dgrdvOutSrc";
            this.dgrdvOutSrc.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvOutSrc.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvOutSrc.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgrdvOutSrc.RowTemplate.Height = 23;
            this.dgrdvOutSrc.Size = new System.Drawing.Size(848, 112);
            this.dgrdvOutSrc.TabIndex = 4;
            // 
            // ColumnPrdStatus
            // 
            this.ColumnPrdStatus.DataPropertyName = "PrdStatus";
            this.ColumnPrdStatus.HeaderText = "工序";
            this.ColumnPrdStatus.Name = "ColumnPrdStatus";
            this.ColumnPrdStatus.ReadOnly = true;
            this.ColumnPrdStatus.Width = 80;
            // 
            // ColumnOutSrcSupplier
            // 
            this.ColumnOutSrcSupplier.DataPropertyName = "OutSrcSupplier";
            this.ColumnOutSrcSupplier.HeaderText = "委外商";
            this.ColumnOutSrcSupplier.Name = "ColumnOutSrcSupplier";
            this.ColumnOutSrcSupplier.ReadOnly = true;
            this.ColumnOutSrcSupplier.Width = 66;
            // 
            // ColumnQuantity
            // 
            this.ColumnQuantity.DataPropertyName = "Quantity";
            this.ColumnQuantity.HeaderText = "数量";
            this.ColumnQuantity.Name = "ColumnQuantity";
            this.ColumnQuantity.ReadOnly = true;
            this.ColumnQuantity.Width = 60;
            // 
            // ColumnFinishedQty
            // 
            this.ColumnFinishedQty.DataPropertyName = "FinishedQty";
            this.ColumnFinishedQty.HeaderText = "完成";
            this.ColumnFinishedQty.Name = "ColumnFinishedQty";
            this.ColumnFinishedQty.ReadOnly = true;
            this.ColumnFinishedQty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnFinishedQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnFinishedQty.Width = 60;
            // 
            // ColumnNonFinishedQty
            // 
            this.ColumnNonFinishedQty.DataPropertyName = "NonFinishedQty";
            this.ColumnNonFinishedQty.HeaderText = "欠数";
            this.ColumnNonFinishedQty.Name = "ColumnNonFinishedQty";
            this.ColumnNonFinishedQty.ReadOnly = true;
            this.ColumnNonFinishedQty.Width = 60;
            // 
            // ColumnDateTarget
            // 
            this.ColumnDateTarget.DataPropertyName = "DateTarget";
            dataGridViewCellStyle1.Format = "MM-dd H:m";
            this.ColumnDateTarget.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnDateTarget.HeaderText = "完成时间";
            this.ColumnDateTarget.Name = "ColumnDateTarget";
            this.ColumnDateTarget.ReadOnly = true;
            this.ColumnDateTarget.Width = 80;
            // 
            // ColumnlnkBOM
            // 
            this.ColumnlnkBOM.HeaderText = "物料";
            this.ColumnlnkBOM.Name = "ColumnlnkBOM";
            this.ColumnlnkBOM.ReadOnly = true;
            this.ColumnlnkBOM.Text = "物料";
            this.ColumnlnkBOM.UseColumnTextForLinkValue = true;
            this.ColumnlnkBOM.Width = 54;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PrdStatus";
            this.dataGridViewTextBoxColumn1.HeaderText = "工序";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CompanyAbbName";
            this.dataGridViewTextBoxColumn3.HeaderText = "委外商";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 66;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn4.HeaderText = "订单数";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 66;
            // 
            // dataGridViewLinkColumn1
            // 
            this.dataGridViewLinkColumn1.DataPropertyName = "FinishedQty";
            this.dataGridViewLinkColumn1.HeaderText = "完成";
            this.dataGridViewLinkColumn1.Name = "dataGridViewLinkColumn1";
            this.dataGridViewLinkColumn1.ReadOnly = true;
            this.dataGridViewLinkColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLinkColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NonFinishedQty";
            this.dataGridViewTextBoxColumn5.HeaderText = "欠数";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 60;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "DateEnd";
            dataGridViewCellStyle5.Format = "MM-dd H:m";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn6.HeaderText = "交期";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "BOMRequireFlag";
            this.dataGridViewTextBoxColumn7.HeaderText = "需物料";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn7.Width = 66;
            // 
            // ColumnBOMFinishedQty1
            // 
            this.ColumnBOMFinishedQty1.DataPropertyName = "BOMFinishedQty";
            this.ColumnBOMFinishedQty1.HeaderText = "已发料";
            this.ColumnBOMFinishedQty1.Name = "ColumnBOMFinishedQty1";
            this.ColumnBOMFinishedQty1.ReadOnly = true;
            this.ColumnBOMFinishedQty1.Width = 66;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "BOMNonFinishedQty";
            this.dataGridViewTextBoxColumn8.HeaderText = "未发料";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 66;
            // 
            // FrmWorkingSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 497);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmWorkingSheet";
            this.Text = "生产制令单";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvSchedule)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvOutSrc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrdName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCompanyCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrdCode;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private JCommon.MyDataGridView dgrdvSchedule;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtPrdSpec;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtWorkingSheetCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPONo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private JCommon.MyDataGridView dgrdvOutSrc;
        private System.Windows.Forms.TextBox txtDateTarget;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutSrcSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnFinishedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNonFinishedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateTarget;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnlnkBOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewLinkColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBOMFinishedQty1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}