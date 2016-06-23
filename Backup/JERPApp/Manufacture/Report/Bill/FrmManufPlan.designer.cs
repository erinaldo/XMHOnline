namespace JERPApp.Manufacture.Report.Bill
{
    partial class FrmManufPlan
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
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPrdSpec = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrdName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrdCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCompanyCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDateNote = new System.Windows.Forms.TextBox();
            this.txtDateTarget = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(620, 37);
            this.txtModel.Name = "txtModel";
            this.txtModel.ReadOnly = true;
            this.txtModel.Size = new System.Drawing.Size(110, 21);
            this.txtModel.TabIndex = 88;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(585, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 87;
            this.label10.Text = "机型";
            // 
            // txtPrdSpec
            // 
            this.txtPrdSpec.Location = new System.Drawing.Point(452, 36);
            this.txtPrdSpec.Name = "txtPrdSpec";
            this.txtPrdSpec.ReadOnly = true;
            this.txtPrdSpec.Size = new System.Drawing.Size(132, 21);
            this.txtPrdSpec.TabIndex = 86;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(393, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 85;
            this.label8.Text = "产品规格";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(771, 36);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.Size = new System.Drawing.Size(70, 21);
            this.txtQuantity.TabIndex = 84;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(736, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 83;
            this.label6.Text = "数量";
            // 
            // txtPrdName
            // 
            this.txtPrdName.Location = new System.Drawing.Point(256, 36);
            this.txtPrdName.Name = "txtPrdName";
            this.txtPrdName.ReadOnly = true;
            this.txtPrdName.Size = new System.Drawing.Size(132, 21);
            this.txtPrdName.TabIndex = 82;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 81;
            this.label4.Text = "产品名称";
            // 
            // txtPrdCode
            // 
            this.txtPrdCode.Location = new System.Drawing.Point(71, 37);
            this.txtPrdCode.Name = "txtPrdCode";
            this.txtPrdCode.ReadOnly = true;
            this.txtPrdCode.Size = new System.Drawing.Size(120, 21);
            this.txtPrdCode.TabIndex = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 79;
            this.label2.Text = "产品编号";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCompanyCode);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtDateNote);
            this.panel1.Controls.Add(this.txtDateTarget);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtModel);
            this.panel1.Controls.Add(this.txtPrdSpec);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPrdCode);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtQuantity);
            this.panel1.Controls.Add(this.txtPrdName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 65);
            this.panel1.TabIndex = 89;
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.Location = new System.Drawing.Point(585, 7);
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.ReadOnly = true;
            this.txtCompanyCode.Size = new System.Drawing.Size(87, 21);
            this.txtCompanyCode.TabIndex = 94;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(550, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 93;
            this.label7.Text = "客户";
            // 
            // txtDateNote
            // 
            this.txtDateNote.Location = new System.Drawing.Point(71, 10);
            this.txtDateNote.Name = "txtDateNote";
            this.txtDateNote.ReadOnly = true;
            this.txtDateNote.Size = new System.Drawing.Size(120, 21);
            this.txtDateNote.TabIndex = 92;
            // 
            // txtDateTarget
            // 
            this.txtDateTarget.Location = new System.Drawing.Point(737, 7);
            this.txtDateTarget.Name = "txtDateTarget";
            this.txtDateTarget.ReadOnly = true;
            this.txtDateTarget.Size = new System.Drawing.Size(104, 21);
            this.txtDateTarget.TabIndex = 91;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(678, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 90;
            this.label5.Text = "交货日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 89;
            this.label3.Text = "计划日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(392, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "生产计划";
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 65);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(852, 468);
            this.tabMain.TabIndex = 90;
            // 
            // FrmManufPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 533);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmManufPlan";
            this.Text = "生产计划";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPrdSpec;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrdName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrdCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCompanyCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDateNote;
        private System.Windows.Forms.TextBox txtDateTarget;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabMain;
    }
}