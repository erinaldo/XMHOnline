namespace JERPApp.Engineer
{
    partial class FrmPrdClone
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlPrdSrcID = new JERPApp.Define.Product.CtrlProduct();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrdCode = new System.Windows.Forms.TextBox();
            this.txtPrdName = new System.Windows.Forms.TextBox();
            this.txtPrdSpec = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFileCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtVersionCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRegisterPsn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateRegister = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.rchVersionRecord = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ckbSaleFlag = new System.Windows.Forms.CheckBox();
            this.ctrlUnitID = new JERPApp.Define.General.CtrlUnit();
            this.label11 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.ctrlPrdTypeID = new JERPApp.Define.Product.CtrlPrdType();
            this.label4 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrdWeight = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtICSolution = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtMinPackingQty = new System.Windows.Forms.TextBox();
            this.ckbRohsFlag = new System.Windows.Forms.CheckBox();
            this.ckbRohsRequireFlag = new System.Windows.Forms.CheckBox();
            this.ckbTaxfreeFlag = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAssistantCode = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDWGNo = new System.Windows.Forms.TextBox();
            this.ckbStopFlag = new System.Windows.Forms.CheckBox();
            this.rchMemo = new System.Windows.Forms.RichTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSurface = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(545, 358);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "新增保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(626, 358);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // ctrlPrdSrcID
            // 
            this.ctrlPrdSrcID.AutoSize = true;
            this.ctrlPrdSrcID.Location = new System.Drawing.Point(6, 20);
            this.ctrlPrdSrcID.Name = "ctrlPrdSrcID";
            this.ctrlPrdSrcID.PrdID = -1;
            this.ctrlPrdSrcID.Size = new System.Drawing.Size(664, 30);
            this.ctrlPrdSrcID.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctrlPrdSrcID);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(684, 56);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "源产品";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(266, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "产品编号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(458, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "产品名称";
            // 
            // txtPrdCode
            // 
            this.txtPrdCode.Location = new System.Drawing.Point(325, 16);
            this.txtPrdCode.Name = "txtPrdCode";
            this.txtPrdCode.Size = new System.Drawing.Size(127, 21);
            this.txtPrdCode.TabIndex = 5;
            // 
            // txtPrdName
            // 
            this.txtPrdName.Location = new System.Drawing.Point(517, 17);
            this.txtPrdName.Name = "txtPrdName";
            this.txtPrdName.Size = new System.Drawing.Size(168, 21);
            this.txtPrdName.TabIndex = 6;
            // 
            // txtPrdSpec
            // 
            this.txtPrdSpec.Location = new System.Drawing.Point(65, 47);
            this.txtPrdSpec.Name = "txtPrdSpec";
            this.txtPrdSpec.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrdSpec.Size = new System.Drawing.Size(152, 21);
            this.txtPrdSpec.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "规    格";
            // 
            // txtFileCode
            // 
            this.txtFileCode.Location = new System.Drawing.Point(66, 133);
            this.txtFileCode.Name = "txtFileCode";
            this.txtFileCode.Size = new System.Drawing.Size(219, 21);
            this.txtFileCode.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(292, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 32;
            this.label8.Text = "版本号";
            // 
            // txtVersionCode
            // 
            this.txtVersionCode.Location = new System.Drawing.Point(340, 134);
            this.txtVersionCode.Name = "txtVersionCode";
            this.txtVersionCode.Size = new System.Drawing.Size(342, 21);
            this.txtVersionCode.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 30;
            this.label7.Text = "文件编号";
            // 
            // txtRegisterPsn
            // 
            this.txtRegisterPsn.Location = new System.Drawing.Point(251, 160);
            this.txtRegisterPsn.Name = "txtRegisterPsn";
            this.txtRegisterPsn.Size = new System.Drawing.Size(100, 21);
            this.txtRegisterPsn.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 29;
            this.label2.Text = "作成人";
            // 
            // dtpDateRegister
            // 
            this.dtpDateRegister.Location = new System.Drawing.Point(65, 161);
            this.dtpDateRegister.Name = "dtpDateRegister";
            this.dtpDateRegister.Size = new System.Drawing.Size(132, 21);
            this.dtpDateRegister.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "作成时间";
            // 
            // rchVersionRecord
            // 
            this.rchVersionRecord.Location = new System.Drawing.Point(63, 188);
            this.rchVersionRecord.Name = "rchVersionRecord";
            this.rchVersionRecord.Size = new System.Drawing.Size(607, 40);
            this.rchVersionRecord.TabIndex = 36;
            this.rchVersionRecord.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(559, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 37;
            this.label12.Text = "单位";
            // 
            // ckbSaleFlag
            // 
            this.ckbSaleFlag.AutoSize = true;
            this.ckbSaleFlag.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ckbSaleFlag.Location = new System.Drawing.Point(328, 78);
            this.ckbSaleFlag.Name = "ckbSaleFlag";
            this.ckbSaleFlag.Size = new System.Drawing.Size(48, 16);
            this.ckbSaleFlag.TabIndex = 26;
            this.ckbSaleFlag.Text = "销售";
            this.ckbSaleFlag.UseVisualStyleBackColor = true;
            // 
            // ctrlUnitID
            // 
            this.ctrlUnitID.AutoSize = true;
            this.ctrlUnitID.Location = new System.Drawing.Point(615, 45);
            this.ctrlUnitID.Name = "ctrlUnitID";
            this.ctrlUnitID.Size = new System.Drawing.Size(67, 23);
            this.ctrlUnitID.TabIndex = 28;
            this.ctrlUnitID.UnitID = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 208);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 38;
            this.label11.Text = "变更履历";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(5, 25);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 64;
            this.label19.Text = "类型";
            // 
            // ctrlPrdTypeID
            // 
            this.ctrlPrdTypeID.Location = new System.Drawing.Point(64, 18);
            this.ctrlPrdTypeID.Name = "ctrlPrdTypeID";
            this.ctrlPrdTypeID.PrdTypeID = 1;
            this.ctrlPrdTypeID.Size = new System.Drawing.Size(196, 23);
            this.ctrlPrdTypeID.TabIndex = 65;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(226, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 66;
            this.label4.Text = "机型";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(261, 45);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(105, 21);
            this.txtModel.TabIndex = 67;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(217, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 68;
            this.label9.Text = "单重Kg";
            // 
            // txtPrdWeight
            // 
            this.txtPrdWeight.Location = new System.Drawing.Point(261, 75);
            this.txtPrdWeight.Name = "txtPrdWeight";
            this.txtPrdWeight.Size = new System.Drawing.Size(63, 21);
            this.txtPrdWeight.TabIndex = 69;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(346, 107);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 76;
            this.label16.Text = "IC方案";
            // 
            // txtICSolution
            // 
            this.txtICSolution.Location = new System.Drawing.Point(396, 100);
            this.txtICSolution.Name = "txtICSolution";
            this.txtICSolution.Size = new System.Drawing.Size(88, 21);
            this.txtICSolution.TabIndex = 77;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(372, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 78;
            this.label10.Text = "品牌";
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Location = new System.Drawing.Point(419, 44);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(119, 21);
            this.txtManufacturer.TabIndex = 79;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(556, 76);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 91;
            this.label18.Text = "最小包装数";
            // 
            // txtMinPackingQty
            // 
            this.txtMinPackingQty.Location = new System.Drawing.Point(627, 71);
            this.txtMinPackingQty.Name = "txtMinPackingQty";
            this.txtMinPackingQty.Size = new System.Drawing.Size(55, 21);
            this.txtMinPackingQty.TabIndex = 92;
            // 
            // ckbRohsFlag
            // 
            this.ckbRohsFlag.AutoSize = true;
            this.ckbRohsFlag.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ckbRohsFlag.Location = new System.Drawing.Point(388, 78);
            this.ckbRohsFlag.Name = "ckbRohsFlag";
            this.ckbRohsFlag.Size = new System.Drawing.Size(72, 16);
            this.ckbRohsFlag.TabIndex = 95;
            this.ckbRohsFlag.Text = "Rohs合格";
            this.ckbRohsFlag.UseVisualStyleBackColor = true;
            // 
            // ckbRohsRequireFlag
            // 
            this.ckbRohsRequireFlag.AutoSize = true;
            this.ckbRohsRequireFlag.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ckbRohsRequireFlag.Location = new System.Drawing.Point(466, 78);
            this.ckbRohsRequireFlag.Name = "ckbRohsRequireFlag";
            this.ckbRohsRequireFlag.Size = new System.Drawing.Size(72, 16);
            this.ckbRohsRequireFlag.TabIndex = 96;
            this.ckbRohsRequireFlag.Text = "Rohs要求";
            this.ckbRohsRequireFlag.UseVisualStyleBackColor = true;
            // 
            // ckbTaxfreeFlag
            // 
            this.ckbTaxfreeFlag.AutoSize = true;
            this.ckbTaxfreeFlag.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ckbTaxfreeFlag.Location = new System.Drawing.Point(424, 164);
            this.ckbTaxfreeFlag.Name = "ckbTaxfreeFlag";
            this.ckbTaxfreeFlag.Size = new System.Drawing.Size(60, 16);
            this.ckbTaxfreeFlag.TabIndex = 97;
            this.ckbTaxfreeFlag.Text = "保税料";
            this.ckbTaxfreeFlag.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(196, 107);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 98;
            this.label15.Text = "助记码";
            // 
            // txtAssistantCode
            // 
            this.txtAssistantCode.Location = new System.Drawing.Point(246, 100);
            this.txtAssistantCode.Name = "txtAssistantCode";
            this.txtAssistantCode.Size = new System.Drawing.Size(88, 21);
            this.txtAssistantCode.TabIndex = 99;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 109);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 100;
            this.label14.Text = "图号";
            // 
            // txtDWGNo
            // 
            this.txtDWGNo.Location = new System.Drawing.Point(64, 100);
            this.txtDWGNo.Name = "txtDWGNo";
            this.txtDWGNo.Size = new System.Drawing.Size(128, 21);
            this.txtDWGNo.TabIndex = 101;
            // 
            // ckbStopFlag
            // 
            this.ckbStopFlag.AutoSize = true;
            this.ckbStopFlag.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ckbStopFlag.Location = new System.Drawing.Point(370, 164);
            this.ckbStopFlag.Name = "ckbStopFlag";
            this.ckbStopFlag.Size = new System.Drawing.Size(48, 16);
            this.ckbStopFlag.TabIndex = 102;
            this.ckbStopFlag.Text = "停产";
            this.ckbStopFlag.UseVisualStyleBackColor = true;
            // 
            // rchMemo
            // 
            this.rchMemo.Location = new System.Drawing.Point(63, 234);
            this.rchMemo.Name = "rchMemo";
            this.rchMemo.Size = new System.Drawing.Size(607, 40);
            this.rchMemo.TabIndex = 103;
            this.rchMemo.Text = "";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(4, 254);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 104;
            this.label17.Text = "备注";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtURL);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtSurface);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.rchMemo);
            this.groupBox2.Controls.Add(this.ckbStopFlag);
            this.groupBox2.Controls.Add(this.txtDWGNo);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtAssistantCode);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.ckbTaxfreeFlag);
            this.groupBox2.Controls.Add(this.ckbRohsRequireFlag);
            this.groupBox2.Controls.Add(this.ckbRohsFlag);
            this.groupBox2.Controls.Add(this.txtMinPackingQty);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txtManufacturer);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtICSolution);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtPrdWeight);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtModel);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.ctrlPrdTypeID);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.ctrlUnitID);
            this.groupBox2.Controls.Add(this.ckbSaleFlag);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.rchVersionRecord);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtpDateRegister);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtRegisterPsn);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtVersionCode);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtFileCode);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtPrdSpec);
            this.groupBox2.Controls.Add(this.txtPrdName);
            this.groupBox2.Controls.Add(this.txtPrdCode);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(11, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(694, 286);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "新产品";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(534, 98);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(148, 21);
            this.txtURL.TabIndex = 114;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(484, 105);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 113;
            this.label13.Text = "网址";
            // 
            // txtSurface
            // 
            this.txtSurface.Location = new System.Drawing.Point(96, 73);
            this.txtSurface.Name = "txtSurface";
            this.txtSurface.Size = new System.Drawing.Size(115, 21);
            this.txtSurface.TabIndex = 111;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 82);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(83, 12);
            this.label21.TabIndex = 110;
            this.label21.Text = "封装/表面处理";
            // 
            // FrmPrdClone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 393);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmPrdClone";
            this.Text = "通过复制新增";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private JERPApp.Define.Product.CtrlProduct ctrlPrdSrcID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrdCode;
        private System.Windows.Forms.TextBox txtPrdName;
        private System.Windows.Forms.TextBox txtPrdSpec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFileCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtVersionCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRegisterPsn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateRegister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rchVersionRecord;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox ckbSaleFlag;
        private JERPApp.Define.General.CtrlUnit ctrlUnitID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label19;
        private JERPApp.Define.Product.CtrlPrdType ctrlPrdTypeID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPrdWeight;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtICSolution;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtMinPackingQty;
        private System.Windows.Forms.CheckBox ckbRohsFlag;
        private System.Windows.Forms.CheckBox ckbRohsRequireFlag;
        private System.Windows.Forms.CheckBox ckbTaxfreeFlag;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtAssistantCode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDWGNo;
        private System.Windows.Forms.CheckBox ckbStopFlag;
        private System.Windows.Forms.RichTextBox rchMemo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSurface;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label13;
    }
}