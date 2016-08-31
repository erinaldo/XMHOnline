namespace JERPApp.Engineer.Define
{
    partial class FrmManuCommonPrdType
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
            this.ctrlCommonTypeTree1 = new JERPApp.Define.Product.CtrlCommonTypeTree();
            this.SuspendLayout();
            // 
            // ctrlCommonTypeTree1
            // 
            this.ctrlCommonTypeTree1.AutoSize = true;
            this.ctrlCommonTypeTree1.Location = new System.Drawing.Point(154, 140);
            this.ctrlCommonTypeTree1.Name = "ctrlCommonTypeTree1";
            this.ctrlCommonTypeTree1.Size = new System.Drawing.Size(209, 324);
            this.ctrlCommonTypeTree1.TabIndex = 0;
            // 
            // FrmManuCommonPrdType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 497);
            this.Controls.Add(this.ctrlCommonTypeTree1);
            this.Name = "FrmManuCommonPrdType";
            this.Text = "FrmManuCommonPrdType";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JERPApp.Define.Product.CtrlCommonTypeTree ctrlCommonTypeTree1;



    }
}