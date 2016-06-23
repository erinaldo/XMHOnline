using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product
{
    public partial class FrmRepairDeliverNoteOper : Form
    {
        public FrmRepairDeliverNoteOper()
        {
            InitializeComponent();
            this.accNotes = new JERPData.Product.RepairDeliverNotes();
            this.accItems = new JERPData.Product.RepairDeliverItems(); 
            this.NoteEntity = new JERPBiz.Product.RepairDeliverNoteEntity();
            this.printhelper = new JERPBiz.Product.RepairDeliverPrintHelper();
            this.dgrdvItem.AutoGenerateColumns = false;   
            this.btnSave .Click +=new EventHandler(btnSave_Click);   
        }

   

        private JERPData.Product.RepairDeliverNotes accNotes;
        private JERPData.Product.RepairDeliverItems accItems;
        private JERPBiz.Product.RepairDeliverNoteEntity NoteEntity;
        private JERPBiz.Product.RepairDeliverPrintHelper printhelper;
        private DataTable dtblItems;  
        private long NoteID=-1; 
        public void ConfirmOper(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;
            this.txtDeliverAddress.Text = this.NoteEntity.DeliverAddress;
            this.txtExpressRequire.Text = this.NoteEntity.ExpressRequire;
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.dtblItems = this.accItems.GetDataRepairDeliverItemsByNoteID(this.NoteID).Tables[0];
            this.dgrdvItem.DataSource = this.dtblItems;
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
       
        private void btnSave_Click(object sender, EventArgs e)
        {
           
            DialogResult rul = MessageBox.Show("将进行维修审核出货一经确认不能变更！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            bool flag = false;
            string errormsg = string.Empty;
            flag = this.accNotes.UpdateRepairDeliverNotesForConfirm(
                ref errormsg,
                this.NoteID,
                this.ctrlDeliverTypeID.DeliverTypeID,
                this.txtExpressRequire.Text,
                this.ctrlDeliverPsnID.PsnID,
                JERPBiz.Frame.UserBiz.PsnID);
            if (!flag)
            {
                MessageBox.Show(errormsg,"操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.affterSave != null) this.affterSave();
            rul = MessageBox.Show("成功进行出货审核，是否需要输出打印？", "打印确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                this.printhelper.ExportToExcel(NoteID);
            }
            this.Close();
        }

   
      
    }
}