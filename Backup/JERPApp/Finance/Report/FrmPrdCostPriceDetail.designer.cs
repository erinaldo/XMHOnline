namespace JERPApp.Finance.Report
{
    partial class FrmPrdCostPriceDetail
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.rchVersionRecord = new System.Windows.Forms.RichTextBox();
            this.txtPrdSpec = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrdName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrdCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFileCode = new System.Windows.Forms.TextBox();
            this.txtVersionCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDateRegister = new System.Windows.Forms.TextBox();
            this.txtCostPrice = new System.Windows.Forms.TextBox();
            this.txtUnitName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ckbSaleFlag = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ctrlPrdBOM = new JERPApp.Finance.Report.CtrlPrdBOM();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ctrlPrdPacking = new JERPApp.Engineer.Report.CtrlPrdPacking();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.ctrlPrdManufProcess = new JERPApp.Finance.Report.CtrlPrdManufProcess();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctrlParmValue = new JERPApp.Engineer.Report.CtrlPrdParmValue();
            this.pageFile = new System.Windows.Forms.TabPage();
            this.ctrlFile = new JCommon.CtrlFileBrowse();
            this.pageImg = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctrlImg = new JCommon.CtrlImgBrowse();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ctrlManufImg = new JCommon.CtrlImgBrowse();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.pageFile.SuspendLayout();
            this.pageImg.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.rchVersionRecord);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 609);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(973, 28);
            this.panel1.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(684, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 26;
            this.btnExport.Text = "输出Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "变更履历";
            // 
            // rchVersionRecord
            // 
            this.rchVersionRecord.Location = new System.Drawing.Point(71, 2);
            this.rchVersionRecord.Name = "rchVersionRecord";
            this.rchVersionRecord.Size = new System.Drawing.Size(456, 24);
            this.rchVersionRecord.TabIndex = 17;
            this.rchVersionRecord.Text = "";
            // 
            // txtPrdSpec
            // 
            this.txtPrdSpec.Location = new System.Drawing.Point(505, 3);
            this.txtPrdSpec.Name = "txtPrdSpec";
            this.txtPrdSpec.ReadOnly = true;
            this.txtPrdSpec.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrdSpec.Size = new System.Drawing.Size(189, 21);
            this.txtPrdSpec.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(470, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "规格";
            // 
            // txtPrdName
            // 
            this.txtPrdName.Location = new System.Drawing.Point(306, 3);
            this.txtPrdName.Name = "txtPrdName";
            this.txtPrdName.ReadOnly = true;
            this.txtPrdName.Size = new System.Drawing.Size(148, 21);
            this.txtPrdName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "产品名称";
            // 
            // txtPrdCode
            // 
            this.txtPrdCode.Location = new System.Drawing.Point(62, 3);
            this.txtPrdCode.Name = "txtPrdCode";
            this.txtPrdCode.ReadOnly = true;
            this.txtPrdCode.Size = new System.Drawing.Size(161, 21);
            this.txtPrdCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "产品编号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(603, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "作成时间";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(247, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "文件编号";
            // 
            // txtFileCode
            // 
            this.txtFileCode.Location = new System.Drawing.Point(306, 30);
            this.txtFileCode.Name = "txtFileCode";
            this.txtFileCode.ReadOnly = true;
            this.txtFileCode.Size = new System.Drawing.Size(167, 21);
            this.txtFileCode.TabIndex = 13;
            // 
            // txtVersionCode
            // 
            this.txtVersionCode.Location = new System.Drawing.Point(526, 28);
            this.txtVersionCode.Name = "txtVersionCode";
            this.txtVersionCode.ReadOnly = true;
            this.txtVersionCode.Size = new System.Drawing.Size(71, 21);
            this.txtVersionCode.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(479, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "版本号";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtModel);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtDateRegister);
            this.panel2.Controls.Add(this.txtCostPrice);
            this.panel2.Controls.Add(this.txtUnitName);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.ckbSaleFlag);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtPrdCode);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtPrdSpec);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtVersionCode);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtFileCode);
            this.panel2.Controls.Add(this.txtPrdName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(973, 59);
            this.panel2.TabIndex = 21;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(731, 3);
            this.txtModel.Name = "txtModel";
            this.txtModel.ReadOnly = true;
            this.txtModel.Size = new System.Drawing.Size(86, 21);
            this.txtModel.TabIndex = 100;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(696, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 99;
            this.label6.Text = "机型";
            // 
            // txtDateRegister
            // 
            this.txtDateRegister.Location = new System.Drawing.Point(662, 28);
            this.txtDateRegister.Name = "txtDateRegister";
            this.txtDateRegister.ReadOnly = true;
            this.txtDateRegister.Size = new System.Drawing.Size(88, 21);
            this.txtDateRegister.TabIndex = 36;
            // 
            // txtCostPrice
            // 
            this.txtCostPrice.Location = new System.Drawing.Point(62, 30);
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.ReadOnly = true;
            this.txtCostPrice.Size = new System.Drawing.Size(66, 21);
            this.txtCostPrice.TabIndex = 35;
            // 
            // txtUnitName
            // 
            this.txtUnitName.Location = new System.Drawing.Point(175, 30);
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.ReadOnly = true;
            this.txtUnitName.Size = new System.Drawing.Size(48, 21);
            this.txtUnitName.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "成本价";
            // 
            // ckbSaleFlag
            // 
            this.ckbSaleFlag.AutoSize = true;
            this.ckbSaleFlag.Enabled = false;
            this.ckbSaleFlag.Location = new System.Drawing.Point(823, 8);
            this.ckbSaleFlag.Name = "ckbSaleFlag";
            this.ckbSaleFlag.Size = new System.Drawing.Size(48, 16);
            this.ckbSaleFlag.TabIndex = 8;
            this.ckbSaleFlag.Text = "销售";
            this.ckbSaleFlag.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(142, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 25;
            this.label12.Text = "单位";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Controls.Add(this.tabPage6);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.pageFile);
            this.tabMain.Controls.Add(this.pageImg);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 59);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(973, 550);
            this.tabMain.TabIndex = 23;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ctrlPrdBOM);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(965, 524);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "物料清单";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ctrlPrdBOM
            // 
            this.ctrlPrdBOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPrdBOM.Location = new System.Drawing.Point(3, 3);
            this.ctrlPrdBOM.Name = "ctrlPrdBOM";
            this.ctrlPrdBOM.Size = new System.Drawing.Size(959, 518);
            this.ctrlPrdBOM.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ctrlPrdPacking);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(965, 524);
            this.tabPage3.TabIndex = 5;
            this.tabPage3.Text = "包装";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ctrlPrdPacking
            // 
            this.ctrlPrdPacking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPrdPacking.Location = new System.Drawing.Point(3, 3);
            this.ctrlPrdPacking.Name = "ctrlPrdPacking";
            this.ctrlPrdPacking.Size = new System.Drawing.Size(959, 518);
            this.ctrlPrdPacking.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.ctrlPrdManufProcess);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(965, 524);
            this.tabPage6.TabIndex = 7;
            this.tabPage6.Text = "工序";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // ctrlPrdManufProcess
            // 
            this.ctrlPrdManufProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPrdManufProcess.Location = new System.Drawing.Point(3, 3);
            this.ctrlPrdManufProcess.Name = "ctrlPrdManufProcess";
            this.ctrlPrdManufProcess.Size = new System.Drawing.Size(959, 518);
            this.ctrlPrdManufProcess.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctrlParmValue);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(965, 524);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "技术参数";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ctrlParmValue
            // 
            this.ctrlParmValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlParmValue.Location = new System.Drawing.Point(3, 3);
            this.ctrlParmValue.Name = "ctrlParmValue";
            this.ctrlParmValue.Size = new System.Drawing.Size(959, 518);
            this.ctrlParmValue.TabIndex = 0;
            // 
            // pageFile
            // 
            this.pageFile.Controls.Add(this.ctrlFile);
            this.pageFile.Location = new System.Drawing.Point(4, 22);
            this.pageFile.Name = "pageFile";
            this.pageFile.Padding = new System.Windows.Forms.Padding(3);
            this.pageFile.Size = new System.Drawing.Size(965, 524);
            this.pageFile.TabIndex = 13;
            this.pageFile.Text = "文件";
            this.pageFile.UseVisualStyleBackColor = true;
            // 
            // ctrlFile
            // 
            this.ctrlFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlFile.Location = new System.Drawing.Point(3, 3);
            this.ctrlFile.Name = "ctrlFile";
            this.ctrlFile.ReadOnly = false;
            this.ctrlFile.Size = new System.Drawing.Size(959, 518);
            this.ctrlFile.TabIndex = 0;
            // 
            // pageImg
            // 
            this.pageImg.Controls.Add(this.splitContainer2);
            this.pageImg.Location = new System.Drawing.Point(4, 22);
            this.pageImg.Name = "pageImg";
            this.pageImg.Padding = new System.Windows.Forms.Padding(3);
            this.pageImg.Size = new System.Drawing.Size(965, 524);
            this.pageImg.TabIndex = 14;
            this.pageImg.Text = "图片";
            this.pageImg.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(959, 518);
            this.splitContainer2.SplitterDistance = 552;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctrlImg);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 518);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "常用图";
            // 
            // ctrlImg
            // 
            this.ctrlImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlImg.Location = new System.Drawing.Point(3, 17);
            this.ctrlImg.Name = "ctrlImg";
            this.ctrlImg.ReadOnly = false;
            this.ctrlImg.Size = new System.Drawing.Size(546, 498);
            this.ctrlImg.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ctrlManufImg);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(403, 518);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "生产图";
            // 
            // ctrlManufImg
            // 
            this.ctrlManufImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlManufImg.Location = new System.Drawing.Point(3, 17);
            this.ctrlManufImg.Name = "ctrlManufImg";
            this.ctrlManufImg.ReadOnly = false;
            this.ctrlManufImg.Size = new System.Drawing.Size(397, 498);
            this.ctrlManufImg.TabIndex = 1;
            // 
            // FrmPrdCostPriceDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 637);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmPrdCostPriceDetail";
            this.Text = "产品详情";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.pageFile.ResumeLayout(false);
            this.pageImg.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrdSpec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrdName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrdCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rchVersionRecord;
        private System.Windows.Forms.TextBox txtVersionCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFileCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox ckbSaleFlag;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private CtrlPrdBOM ctrlPrdBOM;
        private JERPApp.Engineer.Report.CtrlPrdParmValue ctrlParmValue;
        private System.Windows.Forms.TextBox txtDateRegister;
        private System.Windows.Forms.TextBox txtCostPrice;
        private System.Windows.Forms.TextBox txtUnitName;
        private System.Windows.Forms.TabPage tabPage3;
        private JERPApp.Engineer.Report.CtrlPrdPacking ctrlPrdPacking;
        private System.Windows.Forms.TabPage tabPage6;
        private CtrlPrdManufProcess ctrlPrdManufProcess;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage pageFile;
        private JCommon.CtrlFileBrowse ctrlFile;
        private System.Windows.Forms.TabPage pageImg;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private JCommon.CtrlImgBrowse ctrlImg;
        private System.Windows.Forms.GroupBox groupBox2;
        private JCommon.CtrlImgBrowse ctrlManufImg;
    }
}