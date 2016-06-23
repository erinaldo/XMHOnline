namespace JERPApp.Engineer.Tool
{
    partial class FrmProduct
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlPrdTypeID = new JERPApp.Define.Tool.CtrlPrdType();
            this.label1 = new System.Windows.Forms.Label();
            this.dgrdv = new JCommon.MyDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.ColumnPrdTypeID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnResponsiblePsnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPostionID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnDateBatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMaxManufQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMaxRepairQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnManufQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRepairedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRepairedCnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStopFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnbtnFile = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnbtnImg = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ctrlPrdTypeID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1065, 35);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "类型";
            // 
            // ctrlPrdTypeID
            // 
            this.ctrlPrdTypeID.InsertAllRowFlag = false;
            this.ctrlPrdTypeID.Location = new System.Drawing.Point(39, 9);
            this.ctrlPrdTypeID.Name = "ctrlPrdTypeID";
            this.ctrlPrdTypeID.PrdTypeID = 1;
            this.ctrlPrdTypeID.Size = new System.Drawing.Size(143, 23);
            this.ctrlPrdTypeID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(459, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "治具设置";
            // 
            // dgrdv
            // 
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPrdTypeID,
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnUnitName,
            this.ColumnManufacturer,
            this.ColumnResponsiblePsnName,
            this.ColumnPostionID,
            this.ColumnDateBatch,
            this.ColumnMaxManufQty,
            this.ColumnMaxRepairQty,
            this.ColumnManufQty,
            this.ColumnRepairedQty,
            this.ColumnRepairedCnt,
            this.ColumnStopFlag,
            this.ColumnbtnFile,
            this.ColumnbtnImg});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 35);
            this.dgrdv.Name = "dgrdv";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(1065, 511);
            this.dgrdv.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnImport);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 546);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1065, 32);
            this.panel2.TabIndex = 5;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(498, 6);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "批量导入";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(579, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "输出打印";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(253, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(3, 6);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(244, 21);
            this.ctrlQFind.TabIndex = 0;
            // 
            // ColumnPrdTypeID
            // 
            this.ColumnPrdTypeID.DataPropertyName = "PrdTypeID";
            this.ColumnPrdTypeID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnPrdTypeID.HeaderText = "类型";
            this.ColumnPrdTypeID.Name = "ColumnPrdTypeID";
            this.ColumnPrdTypeID.Width = 66;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.HeaderText = "治具编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.HeaderText = "治具名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            this.ColumnPrdSpec.HeaderText = "治具规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            // 
            // ColumnUnitName
            // 
            this.ColumnUnitName.DataPropertyName = "UnitID";
            this.ColumnUnitName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnUnitName.HeaderText = "单位";
            this.ColumnUnitName.Name = "ColumnUnitName";
            this.ColumnUnitName.Width = 54;
            // 
            // ColumnManufacturer
            // 
            this.ColumnManufacturer.DataPropertyName = "Manufacturer";
            this.ColumnManufacturer.HeaderText = "品牌";
            this.ColumnManufacturer.Name = "ColumnManufacturer";
            this.ColumnManufacturer.Width = 80;
            // 
            // ColumnResponsiblePsnName
            // 
            this.ColumnResponsiblePsnName.DataPropertyName = "ResponsiblePsnName";
            this.ColumnResponsiblePsnName.HeaderText = "责任人";
            this.ColumnResponsiblePsnName.Name = "ColumnResponsiblePsnName";
            this.ColumnResponsiblePsnName.Width = 60;
            // 
            // ColumnPostionID
            // 
            this.ColumnPostionID.DataPropertyName = "PositionID";
            this.ColumnPostionID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColumnPostionID.HeaderText = "储位";
            this.ColumnPostionID.Name = "ColumnPostionID";
            this.ColumnPostionID.Width = 70;
            // 
            // ColumnDateBatch
            // 
            this.ColumnDateBatch.DataPropertyName = "DateBatch";
            this.ColumnDateBatch.HeaderText = "量产时间";
            this.ColumnDateBatch.Name = "ColumnDateBatch";
            this.ColumnDateBatch.Width = 78;
            // 
            // ColumnMaxManufQty
            // 
            this.ColumnMaxManufQty.DataPropertyName = "MaxManufQty";
            this.ColumnMaxManufQty.HeaderText = "最大产量";
            this.ColumnMaxManufQty.Name = "ColumnMaxManufQty";
            this.ColumnMaxManufQty.Width = 40;
            // 
            // ColumnMaxRepairQty
            // 
            this.ColumnMaxRepairQty.DataPropertyName = "MaxRepairQty";
            this.ColumnMaxRepairQty.HeaderText = "保养参数";
            this.ColumnMaxRepairQty.Name = "ColumnMaxRepairQty";
            this.ColumnMaxRepairQty.Width = 40;
            // 
            // ColumnManufQty
            // 
            this.ColumnManufQty.DataPropertyName = "ManufQty";
            this.ColumnManufQty.HeaderText = "生产累积";
            this.ColumnManufQty.Name = "ColumnManufQty";
            this.ColumnManufQty.Width = 40;
            // 
            // ColumnRepairedQty
            // 
            this.ColumnRepairedQty.DataPropertyName = "RepairedQty";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnRepairedQty.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnRepairedQty.HeaderText = "保养后累积";
            this.ColumnRepairedQty.Name = "ColumnRepairedQty";
            this.ColumnRepairedQty.Width = 55;
            // 
            // ColumnRepairedCnt
            // 
            this.ColumnRepairedCnt.DataPropertyName = "RepairedCnt";
            this.ColumnRepairedCnt.HeaderText = "保养次数";
            this.ColumnRepairedCnt.Name = "ColumnRepairedCnt";
            this.ColumnRepairedCnt.Width = 40;
            // 
            // ColumnStopFlag
            // 
            this.ColumnStopFlag.DataPropertyName = "StopFlag";
            this.ColumnStopFlag.HeaderText = "停产";
            this.ColumnStopFlag.Name = "ColumnStopFlag";
            this.ColumnStopFlag.Width = 45;
            // 
            // ColumnbtnFile
            // 
            this.ColumnbtnFile.DataPropertyName = "FileCount";
            dataGridViewCellStyle2.NullValue = "0";
            this.ColumnbtnFile.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnbtnFile.HeaderText = "文件";
            this.ColumnbtnFile.Name = "ColumnbtnFile";
            this.ColumnbtnFile.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnbtnFile.Text = "";
            this.ColumnbtnFile.Width = 45;
            // 
            // ColumnbtnImg
            // 
            this.ColumnbtnImg.DataPropertyName = "ImgCount";
            dataGridViewCellStyle3.NullValue = "0";
            this.ColumnbtnImg.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnbtnImg.HeaderText = "图片";
            this.ColumnbtnImg.Name = "ColumnbtnImg";
            this.ColumnbtnImg.ReadOnly = true;
            this.ColumnbtnImg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnbtnImg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnbtnImg.Text = "";
            this.ColumnbtnImg.Width = 45;
            // 
            // FrmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 578);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmProduct";
            this.Text = "FrmProduct";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Panel panel2;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label2;
        private JERPApp.Define.Tool.CtrlPrdType ctrlPrdTypeID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnPrdTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnResponsiblePsnName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnPostionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateBatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMaxManufQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMaxRepairQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnManufQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRepairedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRepairedCnt;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnStopFlag;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnbtnFile;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnbtnImg;
    }
}