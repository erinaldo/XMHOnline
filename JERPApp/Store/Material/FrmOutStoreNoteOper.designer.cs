namespace JERPApp.Store.Material
{
    partial class FrmOutStoreNoteOper
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageStore = new System.Windows.Forms.TabPage();
            this.pageOEMStore = new System.Windows.Forms.TabPage();
            this.ctrlOutStoreOper = new JERPApp.Store.Material.CtrlOutStoreNoteOper();
            this.ctrlOutOEMStoreItemOper = new JERPApp.Store.Material.CtrlOEMOutStoreNoteOper();
            this.panel2.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pageStore.SuspendLayout();
            this.pageOEMStore.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 585);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(836, 31);
            this.panel2.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存并入账";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pageStore);
            this.tabMain.Controls.Add(this.pageOEMStore);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(836, 585);
            this.tabMain.TabIndex = 12;
            // 
            // pageStore
            // 
            this.pageStore.Controls.Add(this.ctrlOutStoreOper);
            this.pageStore.Location = new System.Drawing.Point(4, 22);
            this.pageStore.Name = "pageStore";
            this.pageStore.Padding = new System.Windows.Forms.Padding(3);
            this.pageStore.Size = new System.Drawing.Size(828, 559);
            this.pageStore.TabIndex = 0;
            this.pageStore.Text = "采购库";
            this.pageStore.UseVisualStyleBackColor = true;
            // 
            // pageOEMStore
            // 
            this.pageOEMStore.Controls.Add(this.ctrlOutOEMStoreItemOper);
            this.pageOEMStore.Location = new System.Drawing.Point(4, 22);
            this.pageOEMStore.Name = "pageOEMStore";
            this.pageOEMStore.Padding = new System.Windows.Forms.Padding(3);
            this.pageOEMStore.Size = new System.Drawing.Size(828, 559);
            this.pageOEMStore.TabIndex = 1;
            this.pageOEMStore.Text = "客供库";
            this.pageOEMStore.UseVisualStyleBackColor = true;
            // 
            // ctrlOutStoreOper
            // 
            this.ctrlOutStoreOper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlOutStoreOper.Location = new System.Drawing.Point(3, 3);
            this.ctrlOutStoreOper.Name = "ctrlOutStoreOper";
            this.ctrlOutStoreOper.Size = new System.Drawing.Size(822, 553);
            this.ctrlOutStoreOper.TabIndex = 2;
            // 
            // ctrlOutOEMStoreItemOper
            // 
            this.ctrlOutOEMStoreItemOper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlOutOEMStoreItemOper.Location = new System.Drawing.Point(3, 3);
            this.ctrlOutOEMStoreItemOper.Name = "ctrlOutOEMStoreItemOper";
            this.ctrlOutOEMStoreItemOper.Size = new System.Drawing.Size(822, 553);
            this.ctrlOutOEMStoreItemOper.TabIndex = 2;
            // 
            // FrmOutStoreNoteOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 616);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel2);
            this.Name = "FrmOutStoreNoteOper";
            this.Text = "生产领料单";
            this.panel2.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.pageStore.ResumeLayout(false);
            this.pageOEMStore.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageStore;
        private System.Windows.Forms.TabPage pageOEMStore;
        private CtrlOutStoreNoteOper ctrlOutStoreOper;
        private CtrlOEMOutStoreNoteOper ctrlOutOEMStoreItemOper;
    }
}