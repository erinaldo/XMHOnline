namespace JERPApp.Dispatcher
{
    partial class FrmPostageNoteOper
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
            this.txtNoteCode = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.dtpDateNote = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rchMemo = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ctrlExpressID = new JERPApp.Define.General.CtrlExpress();
            this.radCashFlag = new System.Windows.Forms.RadioButton();
            this.radPayableFlag = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(195, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "快递单登记";
            // 
            // txtNoteCode
            // 
            this.txtNoteCode.Location = new System.Drawing.Point(61, 74);
            this.txtNoteCode.Name = "txtNoteCode";
            this.txtNoteCode.Size = new System.Drawing.Size(195, 21);
            this.txtNoteCode.TabIndex = 4;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(322, 74);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(114, 21);
            this.txtAmount.TabIndex = 5;
            // 
            // dtpDateNote
            // 
            this.dtpDateNote.Location = new System.Drawing.Point(322, 43);
            this.dtpDateNote.Name = "dtpDateNote";
            this.dtpDateNote.Size = new System.Drawing.Size(114, 21);
            this.dtpDateNote.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(61, 201);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "登记保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "快递公司";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "快递单号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(263, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "快递费";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "备注";
            // 
            // rchMemo
            // 
            this.rchMemo.Location = new System.Drawing.Point(61, 108);
            this.rchMemo.Name = "rchMemo";
            this.rchMemo.Size = new System.Drawing.Size(375, 48);
            this.rchMemo.TabIndex = 13;
            this.rchMemo.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(263, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "制单日期";
            // 
            // ctrlExpressID
            // 
            this.ctrlExpressID.AutoSize = true;
            this.ctrlExpressID.CompanyID = -1;
            this.ctrlExpressID.Location = new System.Drawing.Point(61, 41);
            this.ctrlExpressID.Name = "ctrlExpressID";
            this.ctrlExpressID.Size = new System.Drawing.Size(195, 23);
            this.ctrlExpressID.TabIndex = 15;
            // 
            // radCashFlag
            // 
            this.radCashFlag.AutoSize = true;
            this.radCashFlag.ForeColor = System.Drawing.Color.Blue;
            this.radCashFlag.Location = new System.Drawing.Point(66, 172);
            this.radCashFlag.Name = "radCashFlag";
            this.radCashFlag.Size = new System.Drawing.Size(47, 16);
            this.radCashFlag.TabIndex = 21;
            this.radCashFlag.Text = "已付";
            this.radCashFlag.UseVisualStyleBackColor = true;
            // 
            // radPayableFlag
            // 
            this.radPayableFlag.AutoSize = true;
            this.radPayableFlag.Checked = true;
            this.radPayableFlag.ForeColor = System.Drawing.Color.Blue;
            this.radPayableFlag.Location = new System.Drawing.Point(119, 172);
            this.radPayableFlag.Name = "radPayableFlag";
            this.radPayableFlag.Size = new System.Drawing.Size(47, 16);
            this.radPayableFlag.TabIndex = 20;
            this.radPayableFlag.TabStop = true;
            this.radPayableFlag.Text = "月结";
            this.radPayableFlag.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "付款状态";
            // 
            // FrmPostageNoteOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 236);
            this.Controls.Add(this.radCashFlag);
            this.Controls.Add(this.radPayableFlag);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctrlExpressID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rchMemo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpDateNote);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtNoteCode);
            this.Controls.Add(this.label1);
            this.Name = "FrmPostageNoteOper";
            this.Text = "快递单登记";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoteCode;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.DateTimePicker dtpDateNote;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rchMemo;
        private System.Windows.Forms.Label label7;
        private JERPApp.Define.General.CtrlExpress ctrlExpressID;
        private System.Windows.Forms.RadioButton radCashFlag;
        private System.Windows.Forms.RadioButton radPayableFlag;
        private System.Windows.Forms.Label label3;
    }
}