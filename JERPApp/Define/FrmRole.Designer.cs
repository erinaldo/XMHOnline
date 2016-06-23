namespace JERPApp.Define
{
    partial class FrmRole
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.dgrdv = new JCommon.MyDataGridView();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlQFind = new JCommon.CtrlGridQuickFind();
            this.RoleNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectKeyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleValueSetColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.UserSetColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.cMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(570, 33);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(247, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "系统角色设置";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(397, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(83, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "输出Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dgrdv
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F);
            this.dgrdv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoleNameColumn,
            this.SubjectKeyColumn,
            this.DescriptionColumn,
            this.RoleValueSetColumn,
            this.UserSetColumn});
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 33);
            this.dgrdv.Name = "dgrdv";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgrdv.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(570, 446);
            this.dgrdv.TabIndex = 1;
            this.dgrdv.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgrdv_UserDeletingRow);
            this.dgrdv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrdv_CellDoubleClick);
            this.dgrdv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrdv_CellEndEdit);
            this.dgrdv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrdv_CellContentClick);
            // 
            // cMenu
            // 
            this.cMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mRefresh});
            this.cMenu.Name = "cMenu";
            this.cMenu.Size = new System.Drawing.Size(95, 26);
            // 
            // mRefresh
            // 
            this.mRefresh.Name = "mRefresh";
            this.mRefresh.Size = new System.Drawing.Size(94, 22);
            this.mRefresh.Text = "刷新";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.ctrlQFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 479);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(570, 32);
            this.panel2.TabIndex = 2;
            // 
            // ctrlQFind
            // 
            this.ctrlQFind.Location = new System.Drawing.Point(0, 5);
            this.ctrlQFind.Name = "ctrlQFind";
            this.ctrlQFind.SeachGridView = null;
            this.ctrlQFind.Size = new System.Drawing.Size(366, 27);
            this.ctrlQFind.TabIndex = 0;
            // 
            // RoleNameColumn
            // 
            this.RoleNameColumn.DataPropertyName = "RoleName";
            this.RoleNameColumn.HeaderText = "角色名称";
            this.RoleNameColumn.Name = "RoleNameColumn";
            this.RoleNameColumn.Width = 78;
            // 
            // SubjectKeyColumn
            // 
            this.SubjectKeyColumn.DataPropertyName = "SubjectKey";
            this.SubjectKeyColumn.HeaderText = "主题词";
            this.SubjectKeyColumn.Name = "SubjectKeyColumn";
            this.SubjectKeyColumn.Width = 66;
            // 
            // DescriptionColumn
            // 
            this.DescriptionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DescriptionColumn.DataPropertyName = "Description";
            this.DescriptionColumn.HeaderText = "角色描述";
            this.DescriptionColumn.Name = "DescriptionColumn";
            this.DescriptionColumn.ReadOnly = true;
            this.DescriptionColumn.Width = 200;
            // 
            // RoleValueSetColumn
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.RoleValueSetColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.RoleValueSetColumn.HeaderText = "权限设置";
            this.RoleValueSetColumn.Name = "RoleValueSetColumn";
            this.RoleValueSetColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RoleValueSetColumn.Text = "权限设置";
            this.RoleValueSetColumn.UseColumnTextForLinkValue = true;
            this.RoleValueSetColumn.Width = 80;
            // 
            // UserSetColumn
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.UserSetColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.UserSetColumn.HeaderText = "用户管理";
            this.UserSetColumn.Name = "UserSetColumn";
            this.UserSetColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UserSetColumn.Text = "用户管理";
            this.UserSetColumn.UseColumnTextForLinkValue = true;
            this.UserSetColumn.Width = 80;
            // 
            // FrmRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 511);
            this.Controls.Add(this.dgrdv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F);
            this.Name = "FrmRole";
            this.Text = "FrmRole";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.cMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private JCommon.MyDataGridView dgrdv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mRefresh;
        private System.Windows.Forms.Panel panel2;
        private JCommon.CtrlGridQuickFind ctrlQFind;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectKeyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionColumn;
        private System.Windows.Forms.DataGridViewLinkColumn RoleValueSetColumn;
        private System.Windows.Forms.DataGridViewLinkColumn UserSetColumn;
    }
}