namespace JERPApp.Sale
{
    partial class FrmBeforeCustomerOper
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateRegister = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrlSalePsnID = new JERPApp.Define.Hr.CtrlPersonnel();
            this.ctrlRegisterPsnID = new JERPApp.Define.Hr.CtrlPersonnel();
            this.ctrlSourceTypeID = new JERPApp.Define.General.CtrlCustomerSourceType();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtLinkman = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtWecast = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtQQ = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.ctrlProcessTypeID = new JERPApp.Define.General.CtrlCustomerProcessType();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpDateContact = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.txtResultContact = new System.Windows.Forms.TextBox();
            this.dtpDateNextContact = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnSame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "注册时间";
            // 
            // dtpDateRegister
            // 
            this.dtpDateRegister.Location = new System.Drawing.Point(72, 7);
            this.dtpDateRegister.Name = "dtpDateRegister";
            this.dtpDateRegister.Size = new System.Drawing.Size(128, 21);
            this.dtpDateRegister.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "注册人";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "跟进人";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "来源类别";
            // 
            // ctrlSalePsnID
            // 
            this.ctrlSalePsnID.AutoSize = true;
            this.ctrlSalePsnID.Location = new System.Drawing.Point(274, 34);
            this.ctrlSalePsnID.Name = "ctrlSalePsnID";
            this.ctrlSalePsnID.PsnID = -1;
            this.ctrlSalePsnID.Size = new System.Drawing.Size(122, 23);
            this.ctrlSalePsnID.TabIndex = 4;
            // 
            // ctrlRegisterPsnID
            // 
            this.ctrlRegisterPsnID.AutoSize = true;
            this.ctrlRegisterPsnID.Location = new System.Drawing.Point(70, 34);
            this.ctrlRegisterPsnID.Name = "ctrlRegisterPsnID";
            this.ctrlRegisterPsnID.PsnID = -1;
            this.ctrlRegisterPsnID.Size = new System.Drawing.Size(130, 23);
            this.ctrlRegisterPsnID.TabIndex = 3;
            // 
            // ctrlSourceTypeID
            // 
            this.ctrlSourceTypeID.Location = new System.Drawing.Point(274, 5);
            this.ctrlSourceTypeID.Name = "ctrlSourceTypeID";
            this.ctrlSourceTypeID.Size = new System.Drawing.Size(122, 23);
            this.ctrlSourceTypeID.SourceTypeID = 1;
            this.ctrlSourceTypeID.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "客户名称";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(70, 66);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(130, 21);
            this.txtCompanyName.TabIndex = 5;
            // 
            // txtLinkman
            // 
            this.txtLinkman.Location = new System.Drawing.Point(297, 63);
            this.txtLinkman.Name = "txtLinkman";
            this.txtLinkman.Size = new System.Drawing.Size(99, 21);
            this.txtLinkman.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(250, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "联系人";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(274, 90);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(122, 21);
            this.txtMobile.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(219, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "手机";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(70, 93);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(130, 21);
            this.txtTelephone.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "电话";
            // 
            // txtWecast
            // 
            this.txtWecast.Location = new System.Drawing.Point(275, 117);
            this.txtWecast.Name = "txtWecast";
            this.txtWecast.Size = new System.Drawing.Size(122, 21);
            this.txtWecast.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(220, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "微信";
            // 
            // txtQQ
            // 
            this.txtQQ.Location = new System.Drawing.Point(69, 120);
            this.txtQQ.Name = "txtQQ";
            this.txtQQ.Size = new System.Drawing.Size(131, 21);
            this.txtQQ.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "QQ";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(70, 147);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(130, 21);
            this.txtEmail.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 156);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "Email";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(70, 176);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(327, 38);
            this.txtAddress.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 185);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 22;
            this.label12.Text = "地址";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 220);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 24;
            this.label13.Text = "备注";
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(69, 220);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(327, 36);
            this.txtMemo.TabIndex = 13;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(211, 362);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "登记保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(322, 362);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 26;
            this.btnNew.Text = "新增";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // ctrlProcessTypeID
            // 
            this.ctrlProcessTypeID.Location = new System.Drawing.Point(72, 262);
            this.ctrlProcessTypeID.Name = "ctrlProcessTypeID";
            this.ctrlProcessTypeID.ProcessTypeID = 1;
            this.ctrlProcessTypeID.Size = new System.Drawing.Size(128, 23);
            this.ctrlProcessTypeID.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 267);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 28;
            this.label14.Text = "跟单状态";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(209, 267);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 29;
            this.label15.Text = "联系时间";
            // 
            // dtpDateContact
            // 
            this.dtpDateContact.Location = new System.Drawing.Point(274, 262);
            this.dtpDateContact.Name = "dtpDateContact";
            this.dtpDateContact.Size = new System.Drawing.Size(128, 21);
            this.dtpDateContact.TabIndex = 30;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 306);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 31;
            this.label16.Text = "联络结果";
            // 
            // txtResultContact
            // 
            this.txtResultContact.Location = new System.Drawing.Point(72, 289);
            this.txtResultContact.Multiline = true;
            this.txtResultContact.Name = "txtResultContact";
            this.txtResultContact.Size = new System.Drawing.Size(327, 36);
            this.txtResultContact.TabIndex = 32;
            // 
            // dtpDateNextContact
            // 
            this.dtpDateNextContact.Location = new System.Drawing.Point(72, 331);
            this.dtpDateNextContact.Name = "dtpDateNextContact";
            this.dtpDateNextContact.Size = new System.Drawing.Size(128, 21);
            this.dtpDateNextContact.TabIndex = 34;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(13, 337);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 33;
            this.label17.Text = "下次联络";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(204, 154);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 117;
            this.label18.Text = "网址";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(239, 147);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(158, 21);
            this.txtURL.TabIndex = 116;
            // 
            // btnSame
            // 
            this.btnSame.Location = new System.Drawing.Point(206, 64);
            this.btnSame.Name = "btnSame";
            this.btnSame.Size = new System.Drawing.Size(27, 23);
            this.btnSame.TabIndex = 118;
            this.btnSame.Text = "...";
            this.btnSame.UseVisualStyleBackColor = true;
            // 
            // FrmBeforeCustomerOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 412);
            this.Controls.Add(this.btnSame);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.dtpDateNextContact);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtResultContact);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dtpDateContact);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.ctrlProcessTypeID);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtWecast);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtQQ);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtLinkman);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ctrlSourceTypeID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ctrlSalePsnID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctrlRegisterPsnID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDateRegister);
            this.Controls.Add(this.label1);
            this.Name = "FrmBeforeCustomerOper";
            this.Text = "客户登记";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateRegister;
        private System.Windows.Forms.Label label2;
        private JERPApp.Define.Hr.CtrlPersonnel ctrlRegisterPsnID;
        private JERPApp.Define.Hr.CtrlPersonnel ctrlSalePsnID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private JERPApp.Define.General.CtrlCustomerSourceType ctrlSourceTypeID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtLinkman;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtWecast;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtQQ;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private JERPApp.Define.General.CtrlCustomerProcessType ctrlProcessTypeID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpDateContact;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtResultContact;
        private System.Windows.Forms.DateTimePicker dtpDateNextContact;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnSame;
    }
}