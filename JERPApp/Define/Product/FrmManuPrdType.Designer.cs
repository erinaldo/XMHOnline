namespace JERPApp.Define.Product
{
    partial class FrmManuPrdType
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
            this.ctrlCommonTypeTree = new JERPApp.Define.Product.CtrlCommonTypeTree();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlCommonTypeTree
            // 
            this.ctrlCommonTypeTree.AutoSize = true;
            this.ctrlCommonTypeTree.Location = new System.Drawing.Point(0, 2);
            this.ctrlCommonTypeTree.Name = "ctrlCommonTypeTree";
            this.ctrlCommonTypeTree.Size = new System.Drawing.Size(391, 470);
            this.ctrlCommonTypeTree.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Location = new System.Drawing.Point(0, 479);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(391, 31);
            this.panel1.TabIndex = 1;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(4, 3);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(93, 25);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // FrmManuPrdType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 512);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ctrlCommonTypeTree);
            this.Name = "FrmManuPrdType";
            this.Text = "FrmManuPrdType";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtrlCommonTypeTree ctrlCommonTypeTree;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConfirm;
    }
}