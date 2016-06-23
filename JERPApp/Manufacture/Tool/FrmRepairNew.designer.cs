namespace JERPApp.Manufacture.Tool
{
    partial class FrmRepairNew
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
            this.dtpDateRepair = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlPsnID = new JERPApp.Define.Hr.CtrlPersonnel();
            this.label3 = new System.Windows.Forms.Label();
            this.rchMemo = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "保养日期";
            // 
            // dtpDateRepair
            // 
            this.dtpDateRepair.Location = new System.Drawing.Point(76, 12);
            this.dtpDateRepair.Name = "dtpDateRepair";
            this.dtpDateRepair.Size = new System.Drawing.Size(171, 21);
            this.dtpDateRepair.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "负责人员";
            // 
            // ctrlPsnID
            // 
            this.ctrlPsnID.Location = new System.Drawing.Point(76, 44);
            this.ctrlPsnID.Name = "ctrlPsnID";
            this.ctrlPsnID.PsnID = -1;
            this.ctrlPsnID.Size = new System.Drawing.Size(171, 22);
            this.ctrlPsnID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "备注";
            // 
            // rchMemo
            // 
            this.rchMemo.Location = new System.Drawing.Point(76, 72);
            this.rchMemo.Name = "rchMemo";
            this.rchMemo.Size = new System.Drawing.Size(268, 70);
            this.rchMemo.TabIndex = 5;
            this.rchMemo.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(76, 149);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保养";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // FrmDieRepairNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 181);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rchMemo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctrlPsnID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDateRepair);
            this.Controls.Add(this.label1);
            this.Name = "FrmDieRepairNew";
            this.Text = "保养记录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateRepair;
        private System.Windows.Forms.Label label2;
        private JERPApp.Define.Hr.CtrlPersonnel ctrlPsnID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rchMemo;
        private System.Windows.Forms.Button btnSave;
    }
}