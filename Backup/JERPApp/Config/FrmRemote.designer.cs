namespace JERPApp.Config
{
    partial class FrmRemote
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageSQL = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.rchSQL = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnExcSql = new System.Windows.Forms.Button();
            this.dgrdvQuery = new JCommon.MyDataGridView();
            this.pageOper = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lsbSrcName = new System.Windows.Forms.CheckedListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSchedule = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ckbAll = new System.Windows.Forms.CheckBox();
            this.btnBatchClear = new System.Windows.Forms.Button();
            this.dgrdv = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTop = new System.Windows.Forms.TextBox();
            this.radTop = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtSql = new System.Windows.Forms.RichTextBox();
            this.btnExcute = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.treeFold = new System.Windows.Forms.TreeView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtBackupName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBackup = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabMain.SuspendLayout();
            this.pageSQL.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvQuery)).BeginInit();
            this.pageOper.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pageSQL);
            this.tabMain.Controls.Add(this.pageOper);
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 38);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(800, 511);
            this.tabMain.TabIndex = 0;
            // 
            // pageSQL
            // 
            this.pageSQL.Controls.Add(this.splitContainer2);
            this.pageSQL.Location = new System.Drawing.Point(4, 21);
            this.pageSQL.Name = "pageSQL";
            this.pageSQL.Padding = new System.Windows.Forms.Padding(3);
            this.pageSQL.Size = new System.Drawing.Size(792, 486);
            this.pageSQL.TabIndex = 0;
            this.pageSQL.Text = "脚本执行";
            this.pageSQL.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.rchSQL);
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgrdvQuery);
            this.splitContainer2.Size = new System.Drawing.Size(786, 480);
            this.splitContainer2.SplitterDistance = 307;
            this.splitContainer2.TabIndex = 3;
            // 
            // rchSQL
            // 
            this.rchSQL.AcceptsTab = true;
            this.rchSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchSQL.HideSelection = false;
            this.rchSQL.Location = new System.Drawing.Point(0, 0);
            this.rchSQL.Margin = new System.Windows.Forms.Padding(0);
            this.rchSQL.Name = "rchSQL";
            this.rchSQL.Size = new System.Drawing.Size(786, 274);
            this.rchSQL.TabIndex = 0;
            this.rchSQL.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPaste);
            this.panel2.Controls.Add(this.btnExcSql);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 274);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 33);
            this.panel2.TabIndex = 5;
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(5, 7);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(75, 23);
            this.btnPaste.TabIndex = 3;
            this.btnPaste.Text = "粘贴";
            this.btnPaste.UseVisualStyleBackColor = true;
            // 
            // btnExcSql
            // 
            this.btnExcSql.Location = new System.Drawing.Point(86, 7);
            this.btnExcSql.Name = "btnExcSql";
            this.btnExcSql.Size = new System.Drawing.Size(93, 23);
            this.btnExcSql.TabIndex = 2;
            this.btnExcSql.Text = "脚本执行";
            this.btnExcSql.UseVisualStyleBackColor = true;
            // 
            // dgrdvQuery
            // 
            this.dgrdvQuery.AllowUserToAddRows = false;
            this.dgrdvQuery.AllowUserToDeleteRows = false;
            this.dgrdvQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrdvQuery.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrdvQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdvQuery.Location = new System.Drawing.Point(0, 0);
            this.dgrdvQuery.Name = "dgrdvQuery";
            this.dgrdvQuery.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrdvQuery.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgrdvQuery.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgrdvQuery.RowTemplate.Height = 23;
            this.dgrdvQuery.Size = new System.Drawing.Size(786, 169);
            this.dgrdvQuery.TabIndex = 0;
            // 
            // pageOper
            // 
            this.pageOper.Controls.Add(this.splitContainer1);
            this.pageOper.Location = new System.Drawing.Point(4, 21);
            this.pageOper.Name = "pageOper";
            this.pageOper.Padding = new System.Windows.Forms.Padding(3);
            this.pageOper.Size = new System.Drawing.Size(792, 486);
            this.pageOper.TabIndex = 1;
            this.pageOper.Text = "数据操作";
            this.pageOper.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lsbSrcName);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgrdv);
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Panel2.Controls.Add(this.panel6);
            this.splitContainer1.Size = new System.Drawing.Size(786, 480);
            this.splitContainer1.SplitterDistance = 257;
            this.splitContainer1.TabIndex = 1;
            // 
            // lsbSrcName
            // 
            this.lsbSrcName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsbSrcName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbSrcName.Font = new System.Drawing.Font("宋体", 9F);
            this.lsbSrcName.FormattingEnabled = true;
            this.lsbSrcName.Location = new System.Drawing.Point(0, 26);
            this.lsbSrcName.Margin = new System.Windows.Forms.Padding(0);
            this.lsbSrcName.Name = "lsbSrcName";
            this.lsbSrcName.Size = new System.Drawing.Size(257, 418);
            this.lsbSrcName.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.cmbSchedule);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(257, 26);
            this.panel3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "架构";
            // 
            // cmbSchedule
            // 
            this.cmbSchedule.FormattingEnabled = true;
            this.cmbSchedule.Location = new System.Drawing.Point(38, 2);
            this.cmbSchedule.MaxDropDownItems = 32;
            this.cmbSchedule.Name = "cmbSchedule";
            this.cmbSchedule.Size = new System.Drawing.Size(121, 20);
            this.cmbSchedule.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ckbAll);
            this.panel4.Controls.Add(this.btnBatchClear);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 454);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(257, 26);
            this.panel4.TabIndex = 0;
            // 
            // ckbAll
            // 
            this.ckbAll.AutoSize = true;
            this.ckbAll.Location = new System.Drawing.Point(6, 5);
            this.ckbAll.Name = "ckbAll";
            this.ckbAll.Size = new System.Drawing.Size(48, 16);
            this.ckbAll.TabIndex = 3;
            this.ckbAll.Text = "全选";
            this.ckbAll.UseVisualStyleBackColor = true;
            // 
            // btnBatchClear
            // 
            this.btnBatchClear.Location = new System.Drawing.Point(174, 3);
            this.btnBatchClear.Name = "btnBatchClear";
            this.btnBatchClear.Size = new System.Drawing.Size(75, 23);
            this.btnBatchClear.TabIndex = 0;
            this.btnBatchClear.Text = "批量清除";
            this.btnBatchClear.UseVisualStyleBackColor = true;
            // 
            // dgrdv
            // 
            this.dgrdv.AllowUserToAddRows = false;
            this.dgrdv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdv.Location = new System.Drawing.Point(0, 26);
            this.dgrdv.Name = "dgrdv";
            this.dgrdv.RowTemplate.Height = 23;
            this.dgrdv.Size = new System.Drawing.Size(525, 428);
            this.dgrdv.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.txtTop);
            this.panel5.Controls.Add(this.radTop);
            this.panel5.Controls.Add(this.radAll);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(525, 26);
            this.panel5.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "条";
            // 
            // txtTop
            // 
            this.txtTop.Location = new System.Drawing.Point(138, 2);
            this.txtTop.Name = "txtTop";
            this.txtTop.Size = new System.Drawing.Size(41, 21);
            this.txtTop.TabIndex = 2;
            this.txtTop.Text = "200";
            // 
            // radTop
            // 
            this.radTop.AutoSize = true;
            this.radTop.Checked = true;
            this.radTop.Location = new System.Drawing.Point(90, 5);
            this.radTop.Name = "radTop";
            this.radTop.Size = new System.Drawing.Size(47, 16);
            this.radTop.TabIndex = 1;
            this.radTop.TabStop = true;
            this.radTop.Text = "最后";
            this.radTop.UseVisualStyleBackColor = true;
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Location = new System.Drawing.Point(13, 4);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(71, 16);
            this.radAll.TabIndex = 0;
            this.radAll.Text = "全部数据";
            this.radAll.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtSql);
            this.panel6.Controls.Add(this.btnExcute);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 454);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(525, 26);
            this.panel6.TabIndex = 2;
            // 
            // txtSql
            // 
            this.txtSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSql.ForeColor = System.Drawing.Color.Red;
            this.txtSql.Location = new System.Drawing.Point(23, 0);
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(454, 26);
            this.txtSql.TabIndex = 2;
            this.txtSql.Text = "";
            // 
            // btnExcute
            // 
            this.btnExcute.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExcute.Location = new System.Drawing.Point(477, 0);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(48, 26);
            this.btnExcute.TabIndex = 1;
            this.btnExcute.Text = "执行!";
            this.btnExcute.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "条件";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.treeFold);
            this.tabPage1.Controls.Add(this.panel7);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 486);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "备份";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // treeFold
            // 
            this.treeFold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFold.Location = new System.Drawing.Point(3, 3);
            this.treeFold.Name = "treeFold";
            this.treeFold.Size = new System.Drawing.Size(786, 446);
            this.treeFold.TabIndex = 4;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtBackupName);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.btnBackup);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(3, 449);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(786, 34);
            this.panel7.TabIndex = 6;
            // 
            // txtBackupName
            // 
            this.txtBackupName.Location = new System.Drawing.Point(52, 6);
            this.txtBackupName.Name = "txtBackupName";
            this.txtBackupName.Size = new System.Drawing.Size(184, 21);
            this.txtBackupName.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "文件名";
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(242, 6);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(90, 23);
            this.btnBackup.TabIndex = 5;
            this.btnBackup.Text = "备份";
            this.btnBackup.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 38);
            this.panel1.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(68, 10);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(165, 21);
            this.txtPassword.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "操作密码:";
            // 
            // FrmRemote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 549);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmRemote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库远程维护";
            this.tabMain.ResumeLayout(false);
            this.pageSQL.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdvQuery)).EndInit();
            this.pageOper.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdv)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageSQL;
        private System.Windows.Forms.TabPage pageOper;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckedListBox lsbSrcName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSchedule;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox ckbAll;
        private System.Windows.Forms.Button btnBatchClear;
        private System.Windows.Forms.DataGridView dgrdv;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTop;
        private System.Windows.Forms.RadioButton radTop;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RichTextBox txtSql;
        private System.Windows.Forms.Button btnExcute;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnExcSql;
        private System.Windows.Forms.RichTextBox rchSQL;
        private JCommon.MyDataGridView dgrdvQuery;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView treeFold;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBackupName;
    }
}