namespace JERPApp
{
    partial class FrmMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码变更器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.spMenu = new System.Windows.Forms.Splitter();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.treeMenu = new System.Windows.Forms.TreeView();
            this.imgTreeList = new System.Windows.Forms.ImageList(this.components);
            this.pnlMenu_top = new System.Windows.Forms.Panel();
            this.lblMenuCaption = new System.Windows.Forms.Label();
            this.pnlNotice = new System.Windows.Forms.Panel();
            this.otherMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLock = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SetNotePrinterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemExpress = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SetUserMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemShortcut = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mmItemCasio = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mItemRemote = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.tabForm = new JCommon.JTabControl();
            this.pctMenu = new System.Windows.Forms.PictureBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlTopMenu = new System.Windows.Forms.Panel();
            this.pctRemind = new System.Windows.Forms.PictureBox();
            this.pctOtherMenu = new System.Windows.Forms.PictureBox();
            this.pctQQ = new System.Windows.Forms.PictureBox();
            this.pnlMenu.SuspendLayout();
            this.pnlMenu_top.SuspendLayout();
            this.otherMenu.SuspendLayout();
            this.pnlNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctMenu)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctRemind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOtherMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctQQ)).BeginInit();
            this.SuspendLayout();
            // 
            // spMenu
            // 
            this.spMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(150)))), ((int)(((byte)(156)))));
            this.spMenu.Location = new System.Drawing.Point(200, 28);
            this.spMenu.Margin = new System.Windows.Forms.Padding(0);
            this.spMenu.MinExtra = 1;
            this.spMenu.Name = "spMenu";
            this.spMenu.Size = new System.Drawing.Size(1, 572);
            this.spMenu.TabIndex = 30;
            this.spMenu.TabStop = false;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.Controls.Add(this.treeMenu);
            this.pnlMenu.Controls.Add(this.pnlMenu_top);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 28);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(200, 572);
            this.pnlMenu.TabIndex = 29;
            // 
            // treeMenu
            // 
            this.treeMenu.BackColor = System.Drawing.Color.White;
            this.treeMenu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeMenu.ForeColor = System.Drawing.Color.Black;
            this.treeMenu.ImageIndex = 0;
            this.treeMenu.ImageList = this.imgTreeList;
            this.treeMenu.LineColor = System.Drawing.Color.Silver;
            this.treeMenu.Location = new System.Drawing.Point(0, 26);
            this.treeMenu.Margin = new System.Windows.Forms.Padding(0);
            this.treeMenu.Name = "treeMenu";
            this.treeMenu.SelectedImageIndex = 0;
            this.treeMenu.Size = new System.Drawing.Size(200, 546);
            this.treeMenu.TabIndex = 16;
            // 
            // imgTreeList
            // 
            this.imgTreeList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTreeList.ImageStream")));
            this.imgTreeList.TransparentColor = System.Drawing.Color.Red;
            this.imgTreeList.Images.SetKeyName(0, "frm.png");
            this.imgTreeList.Images.SetKeyName(1, "collapse.png");
            this.imgTreeList.Images.SetKeyName(2, "expland.png");
            // 
            // pnlMenu_top
            // 
            this.pnlMenu_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(150)))), ((int)(((byte)(156)))));
            this.pnlMenu_top.BackgroundImage = global::JERPApp.Properties.Resources.pnlnavbg;
            this.pnlMenu_top.Controls.Add(this.lblMenuCaption);
            this.pnlMenu_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu_top.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu_top.Name = "pnlMenu_top";
            this.pnlMenu_top.Size = new System.Drawing.Size(200, 26);
            this.pnlMenu_top.TabIndex = 17;
            // 
            // lblMenuCaption
            // 
            this.lblMenuCaption.AutoSize = true;
            this.lblMenuCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblMenuCaption.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMenuCaption.ForeColor = System.Drawing.Color.Black;
            this.lblMenuCaption.Location = new System.Drawing.Point(40, 7);
            this.lblMenuCaption.Name = "lblMenuCaption";
            this.lblMenuCaption.Size = new System.Drawing.Size(65, 12);
            this.lblMenuCaption.TabIndex = 0;
            this.lblMenuCaption.Text = "主功能选项";
            // 
            // pnlNotice
            // 
            this.pnlNotice.AutoScroll = true;
            this.pnlNotice.BackColor = System.Drawing.Color.White;
            this.pnlNotice.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlNotice.ForeColor = System.Drawing.Color.Black;
            this.pnlNotice.Location = new System.Drawing.Point(896, 54);
            this.pnlNotice.Margin = new System.Windows.Forms.Padding(0);
            this.pnlNotice.Name = "pnlNotice";
            this.pnlNotice.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.pnlNotice.Size = new System.Drawing.Size(133, 546);
            this.pnlNotice.TabIndex = 35;
            // 
            // otherMenu
            // 
            this.otherMenu.BackColor = System.Drawing.SystemColors.Control;
            this.otherMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemStyle,
            this.menuItemLock,
            this.toolStripSeparator1,
            this.SetNotePrinterMenuItem,
            this.mItemExpress,
            this.toolStripSeparator2,
            this.SetUserMenuItem,
            this.mItemShortcut,
            this.MenuItemHelp,
            this.mmItemCasio,
            this.mItemBackup,
            this.toolStripMenuItem1,
            this.mItemRemote});
            this.otherMenu.Name = "otherMenu";
            this.otherMenu.Size = new System.Drawing.Size(125, 242);
            // 
            // mItemStyle
            // 
            this.mItemStyle.Name = "mItemStyle";
            this.mItemStyle.Size = new System.Drawing.Size(124, 22);
            this.mItemStyle.Text = "风格设置";
            this.mItemStyle.Click += new System.EventHandler(this.mItemStyle_Click);
            // 
            // menuItemLock
            // 
            this.menuItemLock.Name = "menuItemLock";
            this.menuItemLock.Size = new System.Drawing.Size(124, 22);
            this.menuItemLock.Text = "系统锁定";
            this.menuItemLock.Click += new System.EventHandler(this.menuItemLock_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // SetNotePrinterMenuItem
            // 
            this.SetNotePrinterMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.SetNotePrinterMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.SetNotePrinterMenuItem.Name = "SetNotePrinterMenuItem";
            this.SetNotePrinterMenuItem.Size = new System.Drawing.Size(124, 22);
            this.SetNotePrinterMenuItem.Text = "打印设置";
            this.SetNotePrinterMenuItem.Click += new System.EventHandler(this.SetNotePrinterMenuItem_Click);
            // 
            // mItemExpress
            // 
            this.mItemExpress.Name = "mItemExpress";
            this.mItemExpress.Size = new System.Drawing.Size(124, 22);
            this.mItemExpress.Text = "快递打印";
            this.mItemExpress.Click += new System.EventHandler(this.mItemExpress_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(121, 6);
            // 
            // SetUserMenuItem
            // 
            this.SetUserMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.SetUserMenuItem.Name = "SetUserMenuItem";
            this.SetUserMenuItem.Size = new System.Drawing.Size(124, 22);
            this.SetUserMenuItem.Text = "登录设置";
            this.SetUserMenuItem.Click += new System.EventHandler(this.SetUserMenuItem_Click);
            // 
            // mItemShortcut
            // 
            this.mItemShortcut.Name = "mItemShortcut";
            this.mItemShortcut.Size = new System.Drawing.Size(124, 22);
            this.mItemShortcut.Text = "快捷设置";
            this.mItemShortcut.Click += new System.EventHandler(this.mItemShortcut_Click);
            // 
            // MenuItemHelp
            // 
            this.MenuItemHelp.Name = "MenuItemHelp";
            this.MenuItemHelp.Size = new System.Drawing.Size(124, 22);
            this.MenuItemHelp.Text = "关于我们";
            this.MenuItemHelp.Click += new System.EventHandler(this.MenuItemHelp_Click);
            // 
            // mmItemCasio
            // 
            this.mmItemCasio.Name = "mmItemCasio";
            this.mmItemCasio.Size = new System.Drawing.Size(124, 22);
            this.mmItemCasio.Text = "计算器";
            this.mmItemCasio.Click += new System.EventHandler(this.mmItemCasio_Click);
            // 
            // mItemBackup
            // 
            this.mItemBackup.Name = "mItemBackup";
            this.mItemBackup.Size = new System.Drawing.Size(124, 22);
            this.mItemBackup.Text = "备份设置";
            this.mItemBackup.Click += new System.EventHandler(this.mItemBackup_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 6);
            // 
            // mItemRemote
            // 
            this.mItemRemote.Name = "mItemRemote";
            this.mItemRemote.Size = new System.Drawing.Size(124, 22);
            this.mItemRemote.Text = "远程维护";
            this.mItemRemote.Click += new System.EventHandler(this.mItemRemote_Click);
            // 
            // pnlNav
            // 
            this.pnlNav.BackgroundImage = global::JERPApp.Properties.Resources.pnlnavbg;
            this.pnlNav.Controls.Add(this.tabForm);
            this.pnlNav.Controls.Add(this.pctMenu);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNav.Location = new System.Drawing.Point(201, 28);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(828, 26);
            this.pnlNav.TabIndex = 31;
            // 
            // tabForm
            // 
            this.tabForm.AutoSize = true;
            this.tabForm.BackColor = System.Drawing.Color.Transparent;
            this.tabForm.BackgroundImage = global::JERPApp.Properties.Resources.pnlnavbg;
            this.tabForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabForm.Location = new System.Drawing.Point(13, 0);
            this.tabForm.Name = "tabForm";
            this.tabForm.Size = new System.Drawing.Size(815, 27);
            this.tabForm.TabIndex = 36;
            // 
            // pctMenu
            // 
            this.pctMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pctMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pctMenu.Image = global::JERPApp.Properties.Resources.pnlnavleft;
            this.pctMenu.Location = new System.Drawing.Point(0, 0);
            this.pctMenu.Name = "pctMenu";
            this.pctMenu.Size = new System.Drawing.Size(13, 26);
            this.pctMenu.TabIndex = 35;
            this.pctMenu.TabStop = false;
            this.pctMenu.Click += new System.EventHandler(this.pctMenu_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = global::JERPApp.Properties.Resources.topmenubg;
            this.pnlTop.Controls.Add(this.pnlTopMenu);
            this.pnlTop.Controls.Add(this.pctRemind);
            this.pnlTop.Controls.Add(this.pctOtherMenu);
            this.pnlTop.Controls.Add(this.pctQQ);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1029, 28);
            this.pnlTop.TabIndex = 38;
            // 
            // pnlTopMenu
            // 
            this.pnlTopMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlTopMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlTopMenu.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTopMenu.Name = "pnlTopMenu";
            this.pnlTopMenu.Padding = new System.Windows.Forms.Padding(0, 1, 0, 2);
            this.pnlTopMenu.Size = new System.Drawing.Size(957, 28);
            this.pnlTopMenu.TabIndex = 1;
            // 
            // pctRemind
            // 
            this.pctRemind.BackColor = System.Drawing.Color.Transparent;
            this.pctRemind.Dock = System.Windows.Forms.DockStyle.Right;
            this.pctRemind.Image = global::JERPApp.Properties.Resources.remind;
            this.pctRemind.Location = new System.Drawing.Point(957, 0);
            this.pctRemind.Margin = new System.Windows.Forms.Padding(0);
            this.pctRemind.Name = "pctRemind";
            this.pctRemind.Padding = new System.Windows.Forms.Padding(2, 5, 0, 0);
            this.pctRemind.Size = new System.Drawing.Size(24, 28);
            this.pctRemind.TabIndex = 18;
            this.pctRemind.TabStop = false;
            // 
            // pctOtherMenu
            // 
            this.pctOtherMenu.BackColor = System.Drawing.Color.Transparent;
            this.pctOtherMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctOtherMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctOtherMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.pctOtherMenu.Image = ((System.Drawing.Image)(resources.GetObject("pctOtherMenu.Image")));
            this.pctOtherMenu.Location = new System.Drawing.Point(981, 0);
            this.pctOtherMenu.Margin = new System.Windows.Forms.Padding(0);
            this.pctOtherMenu.Name = "pctOtherMenu";
            this.pctOtherMenu.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.pctOtherMenu.Size = new System.Drawing.Size(24, 28);
            this.pctOtherMenu.TabIndex = 16;
            this.pctOtherMenu.TabStop = false;
            this.pctOtherMenu.Click += new System.EventHandler(this.pctOtherMenu_Click);
            // 
            // pctQQ
            // 
            this.pctQQ.BackColor = System.Drawing.Color.Transparent;
            this.pctQQ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctQQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctQQ.Dock = System.Windows.Forms.DockStyle.Right;
            this.pctQQ.Image = global::JERPApp.Properties.Resources.qq;
            this.pctQQ.Location = new System.Drawing.Point(1005, 0);
            this.pctQQ.Margin = new System.Windows.Forms.Padding(0);
            this.pctQQ.Name = "pctQQ";
            this.pctQQ.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.pctQQ.Size = new System.Drawing.Size(24, 28);
            this.pctQQ.TabIndex = 22;
            this.pctQQ.TabStop = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1029, 600);
            this.Controls.Add(this.pnlNotice);
            this.Controls.Add(this.pnlNav);
            this.Controls.Add(this.spMenu);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "天衣ERP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu_top.ResumeLayout(false);
            this.pnlMenu_top.PerformLayout();
            this.otherMenu.ResumeLayout(false);
            this.pnlNav.ResumeLayout(false);
            this.pnlNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctMenu)).EndInit();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctRemind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOtherMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctQQ)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter spMenu;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.PictureBox pctMenu;
        private JCommon.JTabControl tabForm;
        private System.Windows.Forms.Panel pnlNotice;
        private System.Windows.Forms.ContextMenuStrip otherMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemLock;
        private System.Windows.Forms.ToolStripMenuItem SetNotePrinterMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mItemStyle;
        private System.Windows.Forms.ToolStripMenuItem SetUserMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mItemShortcut;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem mmItemCasio;
        private System.Windows.Forms.ToolStripMenuItem mItemBackup;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mItemRemote;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mItemExpress;
        private System.Windows.Forms.TreeView treeMenu;
        private System.Windows.Forms.ImageList imgTreeList;
        private System.Windows.Forms.Panel pnlMenu_top;
        private System.Windows.Forms.Label lblMenuCaption;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlTopMenu;
        private System.Windows.Forms.PictureBox pctRemind;
        private System.Windows.Forms.PictureBox pctOtherMenu;
        private System.Windows.Forms.PictureBox pctQQ;
        

    }
}