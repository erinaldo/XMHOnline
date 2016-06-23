namespace JERPApp.Define.Product
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnbtnSelect = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAssistantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnlnkImgs = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkNew = new System.Windows.Forms.LinkLabel();
            this.ctrlQFind = new JCommon.CtrlGridFind();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ctrlPrdTypeID = new JERPApp.Define.Product.CtrlPrdTypeTree();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ckbManufacturer = new System.Windows.Forms.CheckBox();
            this.txtAssistantCode = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.ckbAssistantCode = new System.Windows.Forms.CheckBox();
            this.ckbModel = new System.Windows.Forms.CheckBox();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.txtPrdSpec = new System.Windows.Forms.TextBox();
            this.ckbPrdSpec = new System.Windows.Forms.CheckBox();
            this.txtPrdName = new System.Windows.Forms.TextBox();
            this.ckbPrdName = new System.Windows.Forms.CheckBox();
            this.txtPrdCode = new System.Windows.Forms.TextBox();
            this.ckbPrdCode = new System.Windows.Forms.CheckBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.panel1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgrdv);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(854, 522);
            this.splitContainer1.SplitterDistance = 174;
            this.splitContainer1.TabIndex = 12;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnSelect,
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnManufacturer,
            this.ColumnAssistantCode,
            this.ColumnlnkImgs});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 0);
            this.dgrdv.Name = "dgrdv";
            this.dgrdv.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(676, 493);
            this.dgrdv.TabIndex = 8;
            // 
            // ColumnbtnSelect
            // 
            this.ColumnbtnSelect.HeaderText = "选择";
            this.ColumnbtnSelect.Name = "ColumnbtnSelect";
            this.ColumnbtnSelect.ReadOnly = true;
            this.ColumnbtnSelect.Text = "选择";
            this.ColumnbtnSelect.UseColumnTextForButtonValue = true;
            this.ColumnbtnSelect.Width = 54;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.HeaderText = "产品编号";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.ReadOnly = true;
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.HeaderText = "产品名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            this.ColumnPrdName.ReadOnly = true;
            this.ColumnPrdName.Width = 130;
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdSpec.DefaultCellStyle = dataGridViewCellStyle5;
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
            // ColumnManufacturer
            // 
            this.ColumnManufacturer.DataPropertyName = "Manufacturer";
            this.ColumnManufacturer.HeaderText = "品牌";
            this.ColumnManufacturer.Name = "ColumnManufacturer";
            this.ColumnManufacturer.ReadOnly = true;
            this.ColumnManufacturer.Width = 66;
            // 
            // ColumnAssistantCode
            // 
            this.ColumnAssistantCode.DataPropertyName = "AssistantCode";
            this.ColumnAssistantCode.HeaderText = "助记码";
            this.ColumnAssistantCode.Name = "ColumnAssistantCode";
            this.ColumnAssistantCode.ReadOnly = true;
            this.ColumnAssistantCode.Width = 66;
            // 
            // ColumnlnkImgs
            // 
            this.ColumnlnkImgs.DataPropertyName = "ImgCount";
            this.ColumnlnkImgs.HeaderText = "图片";
            this.ColumnlnkImgs.Name = "ColumnlnkImgs";
            this.ColumnlnkImgs.ReadOnly = true;
            this.ColumnlnkImgs.Text = "";
            this.ColumnlnkImgs.Width = 54;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlQFind);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 493);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(676, 29);
            this.panel1.TabIndex = 9;
            // 
            // lnkNew
            // 
            this.lnkNew.AutoSize = true;
            this.lnkNew.Location = new System.Drawing.Point(138, 224);
            this.lnkNew.Name = "lnkNew";
            this.lnkNew.Size = new System.Drawing.Size(29, 12);
            this.lnkNew.TabIndex = 2;
            this.lnkNew.TabStop = true;
            this.lnkNew.Text = "新增";
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(12, 5);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(331, 21);
            this.ctrlQFind.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ctrlPrdTypeID);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lnkNew);
            this.splitContainer2.Panel2.Controls.Add(this.btnSearch);
            this.splitContainer2.Panel2.Controls.Add(this.ckbManufacturer);
            this.splitContainer2.Panel2.Controls.Add(this.txtAssistantCode);
            this.splitContainer2.Panel2.Controls.Add(this.txtModel);
            this.splitContainer2.Panel2.Controls.Add(this.ckbAssistantCode);
            this.splitContainer2.Panel2.Controls.Add(this.ckbModel);
            this.splitContainer2.Panel2.Controls.Add(this.txtManufacturer);
            this.splitContainer2.Panel2.Controls.Add(this.txtPrdSpec);
            this.splitContainer2.Panel2.Controls.Add(this.ckbPrdSpec);
            this.splitContainer2.Panel2.Controls.Add(this.txtPrdName);
            this.splitContainer2.Panel2.Controls.Add(this.ckbPrdName);
            this.splitContainer2.Panel2.Controls.Add(this.txtPrdCode);
            this.splitContainer2.Panel2.Controls.Add(this.ckbPrdCode);
            this.splitContainer2.Size = new System.Drawing.Size(174, 522);
            this.splitContainer2.SplitterDistance = 276;
            this.splitContainer2.TabIndex = 3;
            // 
            // ctrlPrdTypeID
            // 
            this.ctrlPrdTypeID.AutoSize = true;
            this.ctrlPrdTypeID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPrdTypeID.Location = new System.Drawing.Point(0, 0);
            this.ctrlPrdTypeID.Name = "ctrlPrdTypeID";
            this.ctrlPrdTypeID.Size = new System.Drawing.Size(174, 276);
            this.ctrlPrdTypeID.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(5, 219);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // ckbManufacturer
            // 
            this.ckbManufacturer.AutoSize = true;
            this.ckbManufacturer.Location = new System.Drawing.Point(82, 150);
            this.ckbManufacturer.Name = "ckbManufacturer";
            this.ckbManufacturer.Size = new System.Drawing.Size(48, 16);
            this.ckbManufacturer.TabIndex = 17;
            this.ckbManufacturer.Text = "品牌";
            this.ckbManufacturer.UseVisualStyleBackColor = true;
            // 
            // txtAssistantCode
            // 
            this.txtAssistantCode.Location = new System.Drawing.Point(69, 197);
            this.txtAssistantCode.Name = "txtAssistantCode";
            this.txtAssistantCode.Size = new System.Drawing.Size(98, 21);
            this.txtAssistantCode.TabIndex = 11;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(5, 172);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(72, 21);
            this.txtModel.TabIndex = 16;
            // 
            // ckbAssistantCode
            // 
            this.ckbAssistantCode.AutoSize = true;
            this.ckbAssistantCode.Location = new System.Drawing.Point(8, 202);
            this.ckbAssistantCode.Name = "ckbAssistantCode";
            this.ckbAssistantCode.Size = new System.Drawing.Size(60, 16);
            this.ckbAssistantCode.TabIndex = 10;
            this.ckbAssistantCode.Text = "助记码";
            this.ckbAssistantCode.UseVisualStyleBackColor = true;
            // 
            // ckbModel
            // 
            this.ckbModel.AutoSize = true;
            this.ckbModel.Location = new System.Drawing.Point(5, 150);
            this.ckbModel.Name = "ckbModel";
            this.ckbModel.Size = new System.Drawing.Size(48, 16);
            this.ckbModel.TabIndex = 15;
            this.ckbModel.Text = "机型";
            this.ckbModel.UseVisualStyleBackColor = true;
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Location = new System.Drawing.Point(82, 172);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(85, 21);
            this.txtManufacturer.TabIndex = 9;
            // 
            // txtPrdSpec
            // 
            this.txtPrdSpec.Location = new System.Drawing.Point(8, 123);
            this.txtPrdSpec.Name = "txtPrdSpec";
            this.txtPrdSpec.Size = new System.Drawing.Size(159, 21);
            this.txtPrdSpec.TabIndex = 14;
            // 
            // ckbPrdSpec
            // 
            this.ckbPrdSpec.AutoSize = true;
            this.ckbPrdSpec.Location = new System.Drawing.Point(8, 101);
            this.ckbPrdSpec.Name = "ckbPrdSpec";
            this.ckbPrdSpec.Size = new System.Drawing.Size(72, 16);
            this.ckbPrdSpec.TabIndex = 13;
            this.ckbPrdSpec.Text = "物料规格";
            this.ckbPrdSpec.UseVisualStyleBackColor = true;
            // 
            // txtPrdName
            // 
            this.txtPrdName.Location = new System.Drawing.Point(5, 74);
            this.txtPrdName.Name = "txtPrdName";
            this.txtPrdName.Size = new System.Drawing.Size(162, 21);
            this.txtPrdName.TabIndex = 12;
            // 
            // ckbPrdName
            // 
            this.ckbPrdName.AutoSize = true;
            this.ckbPrdName.Location = new System.Drawing.Point(8, 55);
            this.ckbPrdName.Name = "ckbPrdName";
            this.ckbPrdName.Size = new System.Drawing.Size(72, 16);
            this.ckbPrdName.TabIndex = 11;
            this.ckbPrdName.Text = "物料名称";
            this.ckbPrdName.UseVisualStyleBackColor = true;
            // 
            // txtPrdCode
            // 
            this.txtPrdCode.Location = new System.Drawing.Point(8, 30);
            this.txtPrdCode.Name = "txtPrdCode";
            this.txtPrdCode.Size = new System.Drawing.Size(159, 21);
            this.txtPrdCode.TabIndex = 10;
            // 
            // ckbPrdCode
            // 
            this.ckbPrdCode.AutoSize = true;
            this.ckbPrdCode.Location = new System.Drawing.Point(5, 9);
            this.ckbPrdCode.Name = "ckbPrdCode";
            this.ckbPrdCode.Size = new System.Drawing.Size(72, 16);
            this.ckbPrdCode.TabIndex = 9;
            this.ckbPrdCode.Text = "物料编号";
            this.ckbPrdCode.UseVisualStyleBackColor = true;
            // 
            // FrmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 522);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmProduct";
            this.Text = "产品选择";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAssistantCode;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnlnkImgs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lnkNew;
        private JCommon.CtrlGridFind ctrlQFind;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private CtrlPrdTypeTree ctrlPrdTypeID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox ckbManufacturer;
        private System.Windows.Forms.TextBox txtAssistantCode;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.CheckBox ckbAssistantCode;
        private System.Windows.Forms.CheckBox ckbModel;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.TextBox txtPrdSpec;
        private System.Windows.Forms.CheckBox ckbPrdSpec;
        private System.Windows.Forms.TextBox txtPrdName;
        private System.Windows.Forms.CheckBox ckbPrdName;
        private System.Windows.Forms.TextBox txtPrdCode;
        private System.Windows.Forms.CheckBox ckbPrdCode;
    }
}