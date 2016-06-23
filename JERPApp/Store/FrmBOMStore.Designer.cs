namespace JERPApp.Store
{
    partial class FrmBOMStore
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
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPrdCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrdSpec = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrdName = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMtrStoreQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrdStoreQty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtMinPackingQty = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtSurface = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUnitName = new System.Windows.Forms.TextBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ctrlBOMStore = new JERPApp.Define.Product.CtrlBOMStore();
            this.panel2.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Location = new System.Drawing.Point(786, 2);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.ReadOnly = true;
            this.txtManufacturer.Size = new System.Drawing.Size(80, 21);
            this.txtManufacturer.TabIndex = 91;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(739, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 90;
            this.label10.Text = "品牌";
            // 
            // txtPrdCode
            // 
            this.txtPrdCode.Location = new System.Drawing.Point(72, 3);
            this.txtPrdCode.Name = "txtPrdCode";
            this.txtPrdCode.ReadOnly = true;
            this.txtPrdCode.Size = new System.Drawing.Size(119, 21);
            this.txtPrdCode.TabIndex = 83;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(377, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 87;
            this.label3.Text = "产品规格";
            // 
            // txtPrdSpec
            // 
            this.txtPrdSpec.Location = new System.Drawing.Point(436, 3);
            this.txtPrdSpec.Name = "txtPrdSpec";
            this.txtPrdSpec.ReadOnly = true;
            this.txtPrdSpec.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrdSpec.Size = new System.Drawing.Size(156, 21);
            this.txtPrdSpec.TabIndex = 86;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 82;
            this.label1.Text = "产品编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 84;
            this.label2.Text = "产品名称";
            // 
            // txtPrdName
            // 
            this.txtPrdName.Location = new System.Drawing.Point(256, 3);
            this.txtPrdName.Name = "txtPrdName";
            this.txtPrdName.ReadOnly = true;
            this.txtPrdName.Size = new System.Drawing.Size(115, 21);
            this.txtPrdName.TabIndex = 85;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(633, 2);
            this.txtModel.Name = "txtModel";
            this.txtModel.ReadOnly = true;
            this.txtModel.Size = new System.Drawing.Size(90, 21);
            this.txtModel.TabIndex = 89;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(598, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 88;
            this.label15.Text = "机型";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtMtrStoreQty);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtPrdStoreQty);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtSupplier);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.txtMinPackingQty);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.txtSurface);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtUnitName);
            this.panel2.Controls.Add(this.txtManufacturer);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtModel);
            this.panel2.Controls.Add(this.txtPrdCode);
            this.panel2.Controls.Add(this.txtPrdName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtPrdSpec);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(956, 58);
            this.panel2.TabIndex = 92;
            // 
            // txtMtrStoreQty
            // 
            this.txtMtrStoreQty.Location = new System.Drawing.Point(786, 30);
            this.txtMtrStoreQty.Name = "txtMtrStoreQty";
            this.txtMtrStoreQty.ReadOnly = true;
            this.txtMtrStoreQty.Size = new System.Drawing.Size(80, 21);
            this.txtMtrStoreQty.TabIndex = 126;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(739, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 125;
            this.label5.Text = "原料库";
            // 
            // txtPrdStoreQty
            // 
            this.txtPrdStoreQty.Location = new System.Drawing.Point(647, 31);
            this.txtPrdStoreQty.Name = "txtPrdStoreQty";
            this.txtPrdStoreQty.ReadOnly = true;
            this.txtPrdStoreQty.Size = new System.Drawing.Size(76, 21);
            this.txtPrdStoreQty.TabIndex = 124;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(600, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 123;
            this.label4.Text = "成品库";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(436, 29);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(156, 21);
            this.txtSupplier.TabIndex = 122;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(387, 35);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 12);
            this.label19.TabIndex = 121;
            this.label19.Text = "供应商";
            // 
            // txtMinPackingQty
            // 
            this.txtMinPackingQty.Location = new System.Drawing.Point(321, 29);
            this.txtMinPackingQty.Name = "txtMinPackingQty";
            this.txtMinPackingQty.ReadOnly = true;
            this.txtMinPackingQty.Size = new System.Drawing.Size(63, 21);
            this.txtMinPackingQty.TabIndex = 120;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(255, 36);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 119;
            this.label18.Text = "最小包装数";
            // 
            // txtSurface
            // 
            this.txtSurface.Location = new System.Drawing.Point(72, 30);
            this.txtSurface.Name = "txtSurface";
            this.txtSurface.ReadOnly = true;
            this.txtSurface.Size = new System.Drawing.Size(91, 21);
            this.txtSurface.TabIndex = 118;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(13, 37);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(59, 12);
            this.label24.TabIndex = 117;
            this.label24.Text = "封装/表面";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(164, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 115;
            this.label12.Text = "单位";
            // 
            // txtUnitName
            // 
            this.txtUnitName.Location = new System.Drawing.Point(199, 30);
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.ReadOnly = true;
            this.txtUnitName.Size = new System.Drawing.Size(48, 21);
            this.txtUnitName.TabIndex = 116;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 58);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(956, 536);
            this.tabMain.TabIndex = 93;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ctrlBOMStore);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(948, 510);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "生产物料";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ctrlBOMStore
            // 
            this.ctrlBOMStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlBOMStore.Location = new System.Drawing.Point(3, 3);
            this.ctrlBOMStore.Name = "ctrlBOMStore";
            this.ctrlBOMStore.Size = new System.Drawing.Size(942, 504);
            this.ctrlBOMStore.TabIndex = 0;
            // 
            // FrmBOMStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 594);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel2);
            this.Name = "FrmBOMStore";
            this.Text = "物料库存";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPrdCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrdSpec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrdName;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSurface;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtUnitName;
        private System.Windows.Forms.TextBox txtPrdStoreQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtMinPackingQty;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtMtrStoreQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private JERPApp.Define.Product.CtrlBOMStore ctrlBOMStore;
    }
}