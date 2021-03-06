﻿namespace JERPApp.Engineer
{
    partial class FrmCommonProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlCommonTypeTree1 = new JERPApp.Define.Product.CtrlCommonTypeTree();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ctrlPrdTypeID = new JERPApp.Define.Product.CtrlPrdTypeTree();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ckbPrdCode = new System.Windows.Forms.CheckBox();
            this.txtPrdSpec = new System.Windows.Forms.TextBox();
            this.ckbManufacturer = new System.Windows.Forms.CheckBox();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.ckbPrdSpec = new System.Windows.Forms.CheckBox();
            this.txtPrdName = new System.Windows.Forms.TextBox();
            this.txtAssistantCode = new System.Windows.Forms.TextBox();
            this.ckbModel = new System.Windows.Forms.CheckBox();
            this.ckbPrdName = new System.Windows.Forms.CheckBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.ckbAssistantCode = new System.Windows.Forms.CheckBox();
            this.txtPrdCode = new System.Windows.Forms.TextBox();
            this.dgrdv = new JCommon.MyDataGridView();
            this.ColumnMark = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnPrdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAssistantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMinPackingQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdSetCount = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnFileCount = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnImgCount = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnSaleFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnDWGNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrdID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlQFind = new JCommon.CtrlGridFind();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.panel2.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ctrlCommonTypeTree1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 43);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(466, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "工程设置";
            // 
            // ctrlCommonTypeTree1
            // 
            this.ctrlCommonTypeTree1.AutoSize = true;
            this.ctrlCommonTypeTree1.Location = new System.Drawing.Point(52, 151);
            this.ctrlCommonTypeTree1.Name = "ctrlCommonTypeTree1";
            this.ctrlCommonTypeTree1.Size = new System.Drawing.Size(64, 320);
            this.ctrlCommonTypeTree1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 43);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgrdv);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1010, 713);
            this.splitContainer1.SplitterDistance = 194;
            this.splitContainer1.TabIndex = 4;
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
            this.splitContainer2.Panel2.Controls.Add(this.btnSearch);
            this.splitContainer2.Panel2.Controls.Add(this.ckbPrdCode);
            this.splitContainer2.Panel2.Controls.Add(this.txtPrdSpec);
            this.splitContainer2.Panel2.Controls.Add(this.ckbManufacturer);
            this.splitContainer2.Panel2.Controls.Add(this.txtManufacturer);
            this.splitContainer2.Panel2.Controls.Add(this.ckbPrdSpec);
            this.splitContainer2.Panel2.Controls.Add(this.txtPrdName);
            this.splitContainer2.Panel2.Controls.Add(this.txtAssistantCode);
            this.splitContainer2.Panel2.Controls.Add(this.ckbModel);
            this.splitContainer2.Panel2.Controls.Add(this.ckbPrdName);
            this.splitContainer2.Panel2.Controls.Add(this.txtModel);
            this.splitContainer2.Panel2.Controls.Add(this.ckbAssistantCode);
            this.splitContainer2.Panel2.Controls.Add(this.txtPrdCode);
            this.splitContainer2.Size = new System.Drawing.Size(194, 713);
            this.splitContainer2.SplitterDistance = 427;
            this.splitContainer2.TabIndex = 2;
            // 
            // ctrlPrdTypeID
            // 
            this.ctrlPrdTypeID.AutoSize = true;
            this.ctrlPrdTypeID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPrdTypeID.Location = new System.Drawing.Point(0, 0);
            this.ctrlPrdTypeID.Name = "ctrlPrdTypeID";
            this.ctrlPrdTypeID.Size = new System.Drawing.Size(194, 427);
            this.ctrlPrdTypeID.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(7, 220);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "检索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // ckbPrdCode
            // 
            this.ckbPrdCode.AutoSize = true;
            this.ckbPrdCode.Location = new System.Drawing.Point(7, 4);
            this.ckbPrdCode.Name = "ckbPrdCode";
            this.ckbPrdCode.Size = new System.Drawing.Size(72, 16);
            this.ckbPrdCode.TabIndex = 18;
            this.ckbPrdCode.Text = "物料编号";
            this.ckbPrdCode.UseVisualStyleBackColor = true;
            // 
            // txtPrdSpec
            // 
            this.txtPrdSpec.Location = new System.Drawing.Point(8, 119);
            this.txtPrdSpec.Name = "txtPrdSpec";
            this.txtPrdSpec.Size = new System.Drawing.Size(159, 21);
            this.txtPrdSpec.TabIndex = 27;
            // 
            // ckbManufacturer
            // 
            this.ckbManufacturer.AutoSize = true;
            this.ckbManufacturer.Location = new System.Drawing.Point(86, 146);
            this.ckbManufacturer.Name = "ckbManufacturer";
            this.ckbManufacturer.Size = new System.Drawing.Size(48, 16);
            this.ckbManufacturer.TabIndex = 30;
            this.ckbManufacturer.Text = "品牌";
            this.ckbManufacturer.UseVisualStyleBackColor = true;
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Location = new System.Drawing.Point(86, 168);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(85, 21);
            this.txtManufacturer.TabIndex = 19;
            // 
            // ckbPrdSpec
            // 
            this.ckbPrdSpec.AutoSize = true;
            this.ckbPrdSpec.Location = new System.Drawing.Point(8, 97);
            this.ckbPrdSpec.Name = "ckbPrdSpec";
            this.ckbPrdSpec.Size = new System.Drawing.Size(72, 16);
            this.ckbPrdSpec.TabIndex = 26;
            this.ckbPrdSpec.Text = "物料规格";
            this.ckbPrdSpec.UseVisualStyleBackColor = true;
            // 
            // txtPrdName
            // 
            this.txtPrdName.Location = new System.Drawing.Point(5, 70);
            this.txtPrdName.Name = "txtPrdName";
            this.txtPrdName.Size = new System.Drawing.Size(162, 21);
            this.txtPrdName.TabIndex = 24;
            // 
            // txtAssistantCode
            // 
            this.txtAssistantCode.Location = new System.Drawing.Point(69, 193);
            this.txtAssistantCode.Name = "txtAssistantCode";
            this.txtAssistantCode.Size = new System.Drawing.Size(98, 21);
            this.txtAssistantCode.TabIndex = 23;
            // 
            // ckbModel
            // 
            this.ckbModel.AutoSize = true;
            this.ckbModel.Location = new System.Drawing.Point(5, 146);
            this.ckbModel.Name = "ckbModel";
            this.ckbModel.Size = new System.Drawing.Size(48, 16);
            this.ckbModel.TabIndex = 28;
            this.ckbModel.Text = "机型";
            this.ckbModel.UseVisualStyleBackColor = true;
            // 
            // ckbPrdName
            // 
            this.ckbPrdName.AutoSize = true;
            this.ckbPrdName.Location = new System.Drawing.Point(8, 51);
            this.ckbPrdName.Name = "ckbPrdName";
            this.ckbPrdName.Size = new System.Drawing.Size(72, 16);
            this.ckbPrdName.TabIndex = 22;
            this.ckbPrdName.Text = "物料名称";
            this.ckbPrdName.UseVisualStyleBackColor = true;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(8, 168);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(72, 21);
            this.txtModel.TabIndex = 29;
            // 
            // ckbAssistantCode
            // 
            this.ckbAssistantCode.AutoSize = true;
            this.ckbAssistantCode.Location = new System.Drawing.Point(3, 198);
            this.ckbAssistantCode.Name = "ckbAssistantCode";
            this.ckbAssistantCode.Size = new System.Drawing.Size(60, 16);
            this.ckbAssistantCode.TabIndex = 20;
            this.ckbAssistantCode.Text = "助记码";
            this.ckbAssistantCode.UseVisualStyleBackColor = true;
            // 
            // txtPrdCode
            // 
            this.txtPrdCode.Location = new System.Drawing.Point(8, 26);
            this.txtPrdCode.Name = "txtPrdCode";
            this.txtPrdCode.Size = new System.Drawing.Size(159, 21);
            this.txtPrdCode.TabIndex = 21;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AllowUserToDeleteRows = false;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMark,
            this.ColumnPrdCode,
            this.ColumnPrdName,
            this.ColumnPrdSpec,
            this.ColumnModel,
            this.ColumnAssistantCode,
            this.ColumnUnitName,
            this.ColumnMinPackingQty,
            this.ColumnPrdSetCount,
            this.ColumnFileCount,
            this.ColumnImgCount,
            this.ColumnSaleFlag,
            this.ColumnDWGNo,
            this.ColumnPrdID});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdv.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 0);
            this.dgrdv.Name = "dgrdv";
            this.dgrdv.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(812, 679);
            this.dgrdv.TabIndex = 2;
            // 
            // ColumnMark
            // 
            this.ColumnMark.DataPropertyName = "Mark";
            this.ColumnMark.Frozen = true;
            this.ColumnMark.HeaderText = "±";
            this.ColumnMark.Name = "ColumnMark";
            this.ColumnMark.ReadOnly = true;
            this.ColumnMark.Width = 25;
            // 
            // ColumnPrdCode
            // 
            this.ColumnPrdCode.DataPropertyName = "PrdCode";
            this.ColumnPrdCode.Frozen = true;
            this.ColumnPrdCode.HeaderText = "物料编码";
            this.ColumnPrdCode.Name = "ColumnPrdCode";
            this.ColumnPrdCode.ReadOnly = true;
            this.ColumnPrdCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPrdCode.Width = 120;
            // 
            // ColumnPrdName
            // 
            this.ColumnPrdName.DataPropertyName = "PrdName";
            this.ColumnPrdName.Frozen = true;
            this.ColumnPrdName.HeaderText = "物料名称";
            this.ColumnPrdName.Name = "ColumnPrdName";
            this.ColumnPrdName.ReadOnly = true;
            // 
            // ColumnPrdSpec
            // 
            this.ColumnPrdSpec.DataPropertyName = "PrdSpec";
            this.ColumnPrdSpec.Frozen = true;
            this.ColumnPrdSpec.HeaderText = "物料规格";
            this.ColumnPrdSpec.Name = "ColumnPrdSpec";
            this.ColumnPrdSpec.ReadOnly = true;
            // 
            // ColumnModel
            // 
            this.ColumnModel.DataPropertyName = "Model";
            this.ColumnModel.HeaderText = "机型";
            this.ColumnModel.Name = "ColumnModel";
            this.ColumnModel.ReadOnly = true;
            this.ColumnModel.Width = 66;
            // 
            // ColumnAssistantCode
            // 
            this.ColumnAssistantCode.DataPropertyName = "AssistantCode";
            this.ColumnAssistantCode.HeaderText = "助记码";
            this.ColumnAssistantCode.Name = "ColumnAssistantCode";
            this.ColumnAssistantCode.ReadOnly = true;
            // 
            // ColumnUnitName
            // 
            this.ColumnUnitName.DataPropertyName = "UnitName";
            this.ColumnUnitName.HeaderText = "单位";
            this.ColumnUnitName.Name = "ColumnUnitName";
            this.ColumnUnitName.ReadOnly = true;
            this.ColumnUnitName.Width = 54;
            // 
            // ColumnMinPackingQty
            // 
            this.ColumnMinPackingQty.DataPropertyName = "MinPackingQty";
            this.ColumnMinPackingQty.HeaderText = "最小包装";
            this.ColumnMinPackingQty.Name = "ColumnMinPackingQty";
            this.ColumnMinPackingQty.ReadOnly = true;
            this.ColumnMinPackingQty.Width = 80;
            // 
            // ColumnPrdSetCount
            // 
            this.ColumnPrdSetCount.DataPropertyName = "PrdSetCount";
            dataGridViewCellStyle7.NullValue = "0";
            this.ColumnPrdSetCount.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColumnPrdSetCount.HeaderText = "套料";
            this.ColumnPrdSetCount.Name = "ColumnPrdSetCount";
            this.ColumnPrdSetCount.ReadOnly = true;
            this.ColumnPrdSetCount.Width = 54;
            // 
            // ColumnFileCount
            // 
            this.ColumnFileCount.DataPropertyName = "FileCount";
            dataGridViewCellStyle8.NullValue = "0";
            this.ColumnFileCount.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColumnFileCount.HeaderText = "文件";
            this.ColumnFileCount.Name = "ColumnFileCount";
            this.ColumnFileCount.ReadOnly = true;
            this.ColumnFileCount.Width = 54;
            // 
            // ColumnImgCount
            // 
            this.ColumnImgCount.DataPropertyName = "ImgCount";
            dataGridViewCellStyle9.NullValue = "0";
            this.ColumnImgCount.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColumnImgCount.HeaderText = "图片";
            this.ColumnImgCount.Name = "ColumnImgCount";
            this.ColumnImgCount.ReadOnly = true;
            this.ColumnImgCount.Width = 54;
            // 
            // ColumnSaleFlag
            // 
            this.ColumnSaleFlag.DataPropertyName = "SaleFlag";
            this.ColumnSaleFlag.HeaderText = "销售";
            this.ColumnSaleFlag.Name = "ColumnSaleFlag";
            this.ColumnSaleFlag.ReadOnly = true;
            this.ColumnSaleFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSaleFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnSaleFlag.Width = 54;
            // 
            // ColumnDWGNo
            // 
            this.ColumnDWGNo.DataPropertyName = "DWGNo";
            this.ColumnDWGNo.HeaderText = "图号";
            this.ColumnDWGNo.Name = "ColumnDWGNo";
            this.ColumnDWGNo.ReadOnly = true;
            // 
            // ColumnPrdID
            // 
            this.ColumnPrdID.DataPropertyName = "PrdID";
            this.ColumnPrdID.HeaderText = "PrdID";
            this.ColumnPrdID.Name = "ColumnPrdID";
            this.ColumnPrdID.ReadOnly = true;
            this.ColumnPrdID.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 679);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(812, 34);
            this.panel2.TabIndex = 3;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(32, 8);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(331, 21);
            this.ctrlQFind.TabIndex = 0;
            // 
            // cMenu
            // 
            this.cMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemRefresh});
            this.cMenu.Name = "cMenu";
            this.cMenu.Size = new System.Drawing.Size(101, 26);
            // 
            // mItemRefresh
            // 
            this.mItemRefresh.Name = "mItemRefresh";
            this.mItemRefresh.Size = new System.Drawing.Size(100, 22);
            this.mItemRefresh.Text = "刷新";
            // 
            // FrmCommonProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 756);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCommonProduct";
            this.Text = "FrmCommonProduct";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox ckbPrdCode;
        private System.Windows.Forms.TextBox txtPrdSpec;
        private System.Windows.Forms.CheckBox ckbManufacturer;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.CheckBox ckbPrdSpec;
        private System.Windows.Forms.TextBox txtPrdName;
        private System.Windows.Forms.TextBox txtAssistantCode;
        private System.Windows.Forms.CheckBox ckbModel;
        private System.Windows.Forms.CheckBox ckbPrdName;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.CheckBox ckbAssistantCode;
        private System.Windows.Forms.TextBox txtPrdCode;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.DataGridViewImageColumn ColumnMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAssistantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMinPackingQty;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnPrdSetCount;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnFileCount;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnImgCount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnSaleFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDWGNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrdID;
        private System.Windows.Forms.Panel panel2;
        private JCommon.CtrlGridFind ctrlQFind;
        private JERPApp.Define.Product.CtrlCommonTypeTree ctrlCommonTypeTree1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private JERPApp.Define.Product.CtrlPrdTypeTree ctrlPrdTypeID;
    }
}