using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Tool
{
    public partial class FrmRepairNew : Form
    {
        public FrmRepairNew()
        {
            InitializeComponent();
            this.accPrds = new JERPData.Tool.Product ();
            this.accRecords = new JERPData.Tool .RepairRecords();
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }

        private JERPData.Tool.Product  accPrds;
        private JERPData.Tool.RepairRecords accRecords;
        private int PrdID = -1;
        public void NewRepair(int PrdID)
        {

            this.PrdID = PrdID;
            this.dtpDateRepair.Value = DateTime.Now.Date;
            this.rchMemo.Text = string.Empty;
        }
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
        void btnSave_Click(object sender, EventArgs e)
        {
             DialogResult rul = MessageBox.Show("保存当前记录！是,确认;否,取消", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (rul == DialogResult.Yes)
             {
                 string errormsg=string.Empty ;
                 bool flag=this.accRecords.InsertRepairRecords (ref errormsg, this.PrdID , this.dtpDateRepair.Value.Date,
                     this.ctrlPsnID.PsnID, this.rchMemo.Text);
                 flag= this.accPrds.UpdateProductForRepair  (ref errormsg, this.PrdID );
                 if (flag)
                 {
                     if (this.affterSave != null) this.affterSave();
                     this.Close();
                 }
                 
             }
        }
    }
}