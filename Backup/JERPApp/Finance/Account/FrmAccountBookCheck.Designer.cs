namespace JERPApp.Finance.Account
{
    partial class FrmAccountBookCheck
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
            this.btnCash = new System.Windows.Forms.Button();
            this.btnBank = new System.Windows.Forms.Button();
            this.btnReceivable = new System.Windows.Forms.Button();
            this.btnExpressReceivable = new System.Windows.Forms.Button();
            this.btnExpressPayable = new System.Windows.Forms.Button();
            this.btnPayable = new System.Windows.Forms.Button();
            this.btnExpense = new System.Windows.Forms.Button();
            this.btnRevenue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(158, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "账目盘点";
            // 
            // btnCash
            // 
            this.btnCash.Location = new System.Drawing.Point(25, 42);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(75, 23);
            this.btnCash.TabIndex = 1;
            this.btnCash.Text = "现金";
            this.btnCash.UseVisualStyleBackColor = true;
            // 
            // btnBank
            // 
            this.btnBank.Location = new System.Drawing.Point(117, 42);
            this.btnBank.Name = "btnBank";
            this.btnBank.Size = new System.Drawing.Size(75, 23);
            this.btnBank.TabIndex = 2;
            this.btnBank.Text = "银行存款";
            this.btnBank.UseVisualStyleBackColor = true;
            // 
            // btnReceivable
            // 
            this.btnReceivable.Location = new System.Drawing.Point(25, 79);
            this.btnReceivable.Name = "btnReceivable";
            this.btnReceivable.Size = new System.Drawing.Size(75, 23);
            this.btnReceivable.TabIndex = 3;
            this.btnReceivable.Text = "应收账款";
            this.btnReceivable.UseVisualStyleBackColor = true;
            // 
            // btnExpressReceivable
            // 
            this.btnExpressReceivable.Location = new System.Drawing.Point(117, 79);
            this.btnExpressReceivable.Name = "btnExpressReceivable";
            this.btnExpressReceivable.Size = new System.Drawing.Size(75, 23);
            this.btnExpressReceivable.TabIndex = 4;
            this.btnExpressReceivable.Text = "代收账款";
            this.btnExpressReceivable.UseVisualStyleBackColor = true;
            // 
            // btnExpressPayable
            // 
            this.btnExpressPayable.Location = new System.Drawing.Point(305, 79);
            this.btnExpressPayable.Name = "btnExpressPayable";
            this.btnExpressPayable.Size = new System.Drawing.Size(75, 23);
            this.btnExpressPayable.TabIndex = 7;
            this.btnExpressPayable.Text = "应付运费";
            this.btnExpressPayable.UseVisualStyleBackColor = true;
            // 
            // btnPayable
            // 
            this.btnPayable.Location = new System.Drawing.Point(213, 79);
            this.btnPayable.Name = "btnPayable";
            this.btnPayable.Size = new System.Drawing.Size(75, 23);
            this.btnPayable.TabIndex = 6;
            this.btnPayable.Text = "应付账款";
            this.btnPayable.UseVisualStyleBackColor = true;
            // 
            // btnExpense
            // 
            this.btnExpense.Location = new System.Drawing.Point(117, 108);
            this.btnExpense.Name = "btnExpense";
            this.btnExpense.Size = new System.Drawing.Size(75, 23);
            this.btnExpense.TabIndex = 14;
            this.btnExpense.Text = "费用";
            this.btnExpense.UseVisualStyleBackColor = true;
            // 
            // btnRevenue
            // 
            this.btnRevenue.Location = new System.Drawing.Point(25, 108);
            this.btnRevenue.Name = "btnRevenue";
            this.btnRevenue.Size = new System.Drawing.Size(75, 23);
            this.btnRevenue.TabIndex = 13;
            this.btnRevenue.Text = "收入";
            this.btnRevenue.UseVisualStyleBackColor = true;
            // 
            // FrmAccountBookCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 157);
            this.Controls.Add(this.btnExpense);
            this.Controls.Add(this.btnRevenue);
            this.Controls.Add(this.btnExpressPayable);
            this.Controls.Add(this.btnPayable);
            this.Controls.Add(this.btnExpressReceivable);
            this.Controls.Add(this.btnReceivable);
            this.Controls.Add(this.btnBank);
            this.Controls.Add(this.btnCash);
            this.Controls.Add(this.label1);
            this.Name = "FrmAccountBookCheck";
            this.Text = "FrmAccountBookCheck";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCash;
        private System.Windows.Forms.Button btnBank;
        private System.Windows.Forms.Button btnReceivable;
        private System.Windows.Forms.Button btnExpressReceivable;
        private System.Windows.Forms.Button btnExpressPayable;
        private System.Windows.Forms.Button btnPayable;
        private System.Windows.Forms.Button btnExpense;
        private System.Windows.Forms.Button btnRevenue;
    }
}