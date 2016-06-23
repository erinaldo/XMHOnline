using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Tool
{
    public partial class FrmUpgrade : Form
    {
        public FrmUpgrade()
        {
            InitializeComponent();
            this.accPrds = new JERPData.Tool.Product ();
            this.btnUpgrade.Click += new EventHandler(btnUpgrade_Click);
        }

        private JERPData.Tool .Product  accPrds;
        private long OldPrdID = -1;
        public delegate void AffterSaveDelegate();
        private AffterSaveDelegate affterSave;
        public event AffterSaveDelegate AffterSave
        {
            add
            {
                affterSave += value;
            }
            remove
            {
                affterSave -= value;
            }
        }
        public  void UpgradeDie(long OldPrdID, string OldPrdCode)
        {
            this.OldPrdID = OldPrdID;
            this.txtOldPrdCode.Text = OldPrdCode;
            this.txtNewPrdCode.Text = OldPrdCode;
        }

        void btnUpgrade_Click(object sender, EventArgs e)
        {
             DialogResult rul = MessageBox.Show("将进行治具升级一级升级旧治具停止工作！是,确认;否,取消", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (rul == DialogResult.Yes)
             {
                 string errormsg = string.Empty;
                 bool flag=false;
                 flag=this.accPrds.InsertProductForUpgrade (ref errormsg,
                     this.OldPrdID, this.txtNewPrdCode.Text);
                 if (flag)
                 {
                     if (this.affterSave != null) this.affterSave();
                     this.Close();
                 }
                 else
                 {
                     MessageBox.Show(errormsg);
                 }
             }
        }
    }
}