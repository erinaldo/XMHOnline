namespace JERPApp.Define.OtherRes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnbtnSelect = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAssistantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnlnkImgs = new System.Windows.Forms.DataGridViewLinkColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ctrlPrdTypeID = new JERPApp.Define.OtherRes.CtrlPrdTypeTree();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtAssistantCode = new System.Windows.Forms.TextBox();
            this.ckbAssistantCode = new System.Windows.Forms.CheckBox();
            this.txtPrdSpec = new System.Windows.Forms.TextBox();
            this.ckbPrdSpec = new System.Windows.Forms.CheckBox();
            this.txtPrdName = new System.Windows.Forms.TextBox();
            this.ckbPrdName = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkNew = new System.Windows.Forms.LinkLabel();
            this.ctrlQFind = new JCommon.CtrlGridFind();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnbtnSelect,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnAssistantCode,
            this.ColumnlnkImgs});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 0);
            this.dgrdv.Name = "dgrdv";
            this.dgrdv.ReadOnly = true;
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
            this.dgrdv.Size = new System.Drawing.Size(589, 493);
            this.dgrdv.TabIndex = 1;
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
            this.ColumnPrdSpec.HeaderText = "型号及规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            this.ColumnPrdSpec.ReadOnly = true;
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
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
            this.splitContainer1.Size = new System.Drawing.Size(733, 522);
            this.splitContainer1.SplitterDistance = 140;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.splitContainer2.Panel2.Controls.Add(this.txtAssistantCode);
            this.splitContainer2.Panel2.Controls.Add(this.ckbAssistantCode);
            this.splitContainer2.Panel2.Controls.Add(this.txtPrdSpec);
            this.splitContainer2.Panel2.Controls.Add(this.ckbPrdSpec);
            this.splitContainer2.Panel2.Controls.Add(this.txtPrdName);
            this.splitContainer2.Panel2.Controls.Add(this.ckbPrdName);
            this.splitContainer2.Size = new System.Drawing.Size(140, 522);
            this.splitContainer2.SplitterDistance = 341;
            this.splitContainer2.TabIndex = 1;
            // 
            // ctrlPrdTypeID
            // 
            this.ctrlPrdTypeID.AutoSize = true;
            this.ctrlPrdTypeID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPrdTypeID.Location = new System.Drawing.Point(0, 0);
            this.ctrlPrdTypeID.Name = "ctrlPrdTypeID";
            this.ctrlPrdTypeID.Size = new System.Drawing.Size(140, 341);
            this.ctrlPrdTypeID.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(4, 148);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 21;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtAssistantCode
            // 
            this.txtAssistantCode.Location = new System.Drawing.Point(4, 120);
            this.txtAssistantCode.Name = "txtAssistantCode";
            this.txtAssistantCode.Size = new System.Drawing.Size(121, 21);
            this.txtAssistantCode.TabIndex = 17;
            // 
            // ckbAssistantCode
            // 
            this.ckbAssistantCode.AutoSize = true;
            this.ckbAssistantCode.Location = new System.Drawing.Point(3, 98);
            this.ckbAssistantCode.Name = "ckbAssistantCode";
            this.ckbAssistantCode.Size = new System.Drawing.Size(60, 16);
            this.ckbAssistantCode.TabIndex = 15;
            this.ckbAssistantCode.Text = "助记码";
            this.ckbAssistantCode.UseVisualStyleBackColor = true;
            // 
            // txtPrdSpec
            // 
            this.txtPrdSpec.Location = new System.Drawing.Point(3, 71);
            this.txtPrdSpec.Name = "txtPrdSpec";
            this.txtPrdSpec.Size = new System.Drawing.Size(121, 21);
            this.txtPrdSpec.TabIndex = 20;
            // 
            // ckbPrdSpec
            // 
            this.ckbPrdSpec.AutoSize = true;
            this.ckbPrdSpec.Location = new System.Drawing.Point(3, 49);
            this.ckbPrdSpec.Name = "ckbPrdSpec";
            this.ckbPrdSpec.Size = new System.Drawing.Size(72, 16);
            this.ckbPrdSpec.TabIndex = 19;
            this.ckbPrdSpec.Text = "物料规格";
            this.ckbPrdSpec.UseVisualStyleBackColor = true;
            // 
            // txtPrdName
            // 
            this.txtPrdName.Location = new System.Drawing.Point(4, 22);
            this.txtPrdName.Name = "txtPrdName";
            this.txtPrdName.Size = new System.Drawing.Size(120, 21);
            this.txtPrdName.TabIndex = 18;
            // 
            // ckbPrdName
            // 
            this.ckbPrdName.AutoSize = true;
            this.ckbPrdName.Location = new System.Drawing.Point(3, 3);
            this.ckbPrdName.Name = "ckbPrdName";
            this.ckbPrdName.Size = new System.Drawing.Size(72, 16);
            this.ckbPrdName.TabIndex = 16;
            this.ckbPrdName.Text = "物料名称";
            this.ckbPrdName.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlQFind);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 493);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 29);
            this.panel1.TabIndex = 4;
            // 
            // lnkNew
            // 
            this.lnkNew.AutoSize = true;
            this.lnkNew.Location = new System.Drawing.Point(95, 153);
            this.lnkNew.Name = "lnkNew";
            this.lnkNew.Size = new System.Drawing.Size(29, 12);
            this.lnkNew.TabIndex = 11;
            this.lnkNew.TabStop = true;
            this.lnkNew.Text = "新增";
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(12, 5);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(313, 21);
            this.ctrlQFind.TabIndex = 1;
            // 
            // FrmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 522);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmProduct";
            this.Text = "耗材选择";
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private JCommon.CtrlGridFind ctrlQFind;
        private System.Windows.Forms.LinkLabel lnkNew;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnbtnSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAssistantCode;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnlnkImgs;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private CtrlPrdTypeTree ctrlPrdTypeID;
        private System.Windows.Forms.TextBox txtAssistantCode;
        private System.Windows.Forms.CheckBox ckbAssistantCode;
        private System.Windows.Forms.TextBox txtPrdSpec;
        private System.Windows.Forms.CheckBox ckbPrdSpec;
        private System.Windows.Forms.TextBox txtPrdName;
        private System.Windows.Forms.CheckBox ckbPrdName;
        private System.Windows.Forms.Button btnSearch;
    }
}