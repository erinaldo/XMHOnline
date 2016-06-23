
namespace JERPApp.Define.Product
{
    partial class CtrlPrdType
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放客供资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region 组件设计器生成的代码
        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码变更器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtPrdTypeName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearch.Location = new System.Drawing.Point(269, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(43, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "...";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtPrdTypeName
            // 
            this.txtPrdTypeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrdTypeName.Location = new System.Drawing.Point(0, 0);
            this.txtPrdTypeName.Name = "txtPrdTypeName";
            this.txtPrdTypeName.ReadOnly = true;
            this.txtPrdTypeName.Size = new System.Drawing.Size(269, 21);
            this.txtPrdTypeName.TabIndex = 1;
            // 
            // CtrlPrdType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPrdTypeName);
            this.Controls.Add(this.btnSearch);
            this.Name = "CtrlPrdType";
            this.Size = new System.Drawing.Size(312, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtPrdTypeName;

    }
}