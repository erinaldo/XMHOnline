namespace JERPApp.Common
{
    partial class FrmMessage
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lnkRecord = new System.Windows.Forms.LinkLabel();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAddPsn = new System.Windows.Forms.Button();
            this.ctrlToPsnID = new JERPApp.Define.Hr.CtrlUserPsn();
            this.txtToPsns = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rchMsgContent = new System.Windows.Forms.RichTextBox();
            this.rchBoard = new System.Windows.Forms.RichTextBox();
            this.cMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ckbAllPsnFlag = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.cMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 28);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(311, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "信息中心";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ckbAllPsnFlag);
            this.panel2.Controls.Add(this.lnkRecord);
            this.panel2.Controls.Add(this.btnSend);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnAddPsn);
            this.panel2.Controls.Add(this.ctrlToPsnID);
            this.panel2.Controls.Add(this.txtToPsns);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.rchMsgContent);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 483);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(668, 81);
            this.panel2.TabIndex = 1;
            // 
            // lnkRecord
            // 
            this.lnkRecord.AutoSize = true;
            this.lnkRecord.Location = new System.Drawing.Point(8, 38);
            this.lnkRecord.Name = "lnkRecord";
            this.lnkRecord.Size = new System.Drawing.Size(29, 12);
            this.lnkRecord.TabIndex = 8;
            this.lnkRecord.TabStop = true;
            this.lnkRecord.Text = "内容";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(580, 33);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(85, 40);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.Location = new System.Drawing.Point(634, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(31, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "-";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnAddPsn
            // 
            this.btnAddPsn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddPsn.Location = new System.Drawing.Point(207, 5);
            this.btnAddPsn.Name = "btnAddPsn";
            this.btnAddPsn.Size = new System.Drawing.Size(32, 23);
            this.btnAddPsn.TabIndex = 5;
            this.btnAddPsn.Text = "+";
            this.btnAddPsn.UseVisualStyleBackColor = true;
            // 
            // ctrlToPsnID
            // 
            this.ctrlToPsnID.AutoSize = true;
            this.ctrlToPsnID.Location = new System.Drawing.Point(46, 6);
            this.ctrlToPsnID.Name = "ctrlToPsnID";
            this.ctrlToPsnID.PsnID = 1;
            this.ctrlToPsnID.Size = new System.Drawing.Size(107, 23);
            this.ctrlToPsnID.TabIndex = 4;
            // 
            // txtToPsns
            // 
            this.txtToPsns.Location = new System.Drawing.Point(241, 6);
            this.txtToPsns.Name = "txtToPsns";
            this.txtToPsns.ReadOnly = true;
            this.txtToPsns.Size = new System.Drawing.Size(387, 21);
            this.txtToPsns.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "接受人";
            // 
            // rchMsgContent
            // 
            this.rchMsgContent.Location = new System.Drawing.Point(46, 35);
            this.rchMsgContent.Name = "rchMsgContent";
            this.rchMsgContent.Size = new System.Drawing.Size(528, 38);
            this.rchMsgContent.TabIndex = 1;
            this.rchMsgContent.Text = "";
            // 
            // rchBoard
            // 
            this.rchBoard.BackColor = System.Drawing.SystemColors.Window;
            this.rchBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchBoard.Location = new System.Drawing.Point(0, 28);
            this.rchBoard.Name = "rchBoard";
            this.rchBoard.Size = new System.Drawing.Size(668, 455);
            this.rchBoard.TabIndex = 2;
            this.rchBoard.Text = "";
            // 
            // cMenu
            // 
            this.cMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemRefresh});
            this.cMenu.Name = "cMenu";
            this.cMenu.Size = new System.Drawing.Size(99, 26);
            // 
            // mItemRefresh
            // 
            this.mItemRefresh.Name = "mItemRefresh";
            this.mItemRefresh.Size = new System.Drawing.Size(98, 22);
            this.mItemRefresh.Text = "刷新";
            // 
            // ckbAllPsnFlag
            // 
            this.ckbAllPsnFlag.AutoSize = true;
            this.ckbAllPsnFlag.Location = new System.Drawing.Point(159, 8);
            this.ckbAllPsnFlag.Name = "ckbAllPsnFlag";
            this.ckbAllPsnFlag.Size = new System.Drawing.Size(48, 16);
            this.ckbAllPsnFlag.TabIndex = 9;
            this.ckbAllPsnFlag.Text = "全体";
            this.ckbAllPsnFlag.UseVisualStyleBackColor = true;
            // 
            // FrmMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 564);
            this.Controls.Add(this.rchBoard);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMessage";
            this.Text = "FrmMessage";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.cMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rchBoard;
        private System.Windows.Forms.TextBox txtToPsns;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rchMsgContent;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAddPsn;
        private JERPApp.Define.Hr.CtrlUserPsn ctrlToPsnID;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ContextMenuStrip cMenu;
        private System.Windows.Forms.ToolStripMenuItem mItemRefresh;
        private System.Windows.Forms.LinkLabel lnkRecord;
        private System.Windows.Forms.CheckBox ckbAllPsnFlag;
    }
}