using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class FrmOutSrcStoreCheckConfirm : Form
    {
        public FrmOutSrcStoreCheckConfirm()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false; 
            this.accStore = new JERPData.Material.OutSrcStore(); 
            this.NoteEntity = new JERPBiz.Material.OutSrcStoreCheckNoteEntity();
            this.accItems = new JERPData.Material.OutSrcStoreCheckItems();
            this.accNotes = new JERPData.Material.OutSrcStoreCheckNotes(); 
            this.accStoreReserve = new JERPData.Material.OutSrcStoreReserve();
            this.ctrlQFind.SeachGridView = this.dgrdv;  
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }
         
        private JERPData.Material.OutSrcStore accStore; 
        private JERPData.Material.OutSrcStoreCheckItems accItems;
        private JERPData.Material.OutSrcStoreCheckNotes accNotes;
        private JERPBiz.Material.OutSrcStoreCheckNoteEntity NoteEntity; 
        JERPData.Material.OutSrcStoreReserve accStoreReserve; 
        private DataTable dtblItems;
        private long noteid = -1;
        private long NoteID
        {
            get
            {
                return this.noteid;
            }
            set
            {
                this.noteid = value;
            }
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
        public void Confirm(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToString();
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;
            this.txtCheckPersons.Text = this.NoteEntity.CheckPersons;
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.LoadItems();

        }
       
        private   void LoadItems()
        {
            this.dtblItems = this.accItems .GetDataOutSrcStoreCheckItemsByNoteID (this.NoteID ).Tables[0];
             this.dgrdv.DataSource = this.dtblItems;
        }
         
 
        void btnSave_Click(object sender, EventArgs e)
        {
            
            DialogResult rsl = MessageBox.Show("将进行保存并入账?一经保存此盘点单不能变更，但可以再次盘点",
               "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rsl == DialogResult.No) return;
            string errormsg=string .Empty ;
            bool flag = false;
            flag = this.accNotes.UpdateOutSrcStoreCheckNotesForConfirm (
                ref errormsg,
                this.NoteID ,
                JERPBiz.Frame.UserBiz.PsnID);
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            } 
            int PrdID;
            int CompanyID = this.NoteEntity.CompanyID;
            foreach (DataRow drow in this.dtblItems.Rows )
            {
                PrdID = (int)drow["PrdID"];
                if (drow["CheckQty"] == DBNull.Value)
                {
                    this.accItems.DeleteOutSrcStoreCheckItems(ref errormsg,
                        drow["ItemID"]);
                    continue;
                } 
                if (drow["InitQty"]!=DBNull .Value )
                {
                    this.accStore.InsertOutSrcStoreForInitStore(
                        ref errormsg,
                        JERPBiz.Material.OutSrcStoreNoteName.StoreCheckNoteNameID,
                        JERPBiz.Material.OutSrcStoreNoteName.StoreCheckNoteName,
                        this.NoteID,
                        this.txtNoteCode .Text ,
                        PrdID,
                        CompanyID,
                        drow["InitQty"],
                        drow["CostPrice"]);
                }
                if (drow["SurplusQty"]!=DBNull .Value )
                { 
                    this.accStore.InsertOutSrcStoreForCheckIntoStore(ref errormsg,
                        JERPBiz.Material.OutSrcStoreNoteName.StoreCheckNoteNameID,
                        JERPBiz.Material.OutSrcStoreNoteName.StoreCheckNoteName,
                        this.NoteID,
                        this.txtNoteCode.Text,
                        PrdID,
                        CompanyID,
                        drow["SurplusQty"],
                        drow["CostPrice"]);
                }
                if (drow["LostQty"] != DBNull.Value)
                { 
                    this.accStore.InsertOutSrcStoreForCheckOutStore (ref errormsg,
                        JERPBiz.Material.OutSrcStoreNoteName.StoreCheckNoteNameID,
                        JERPBiz.Material.OutSrcStoreNoteName.StoreCheckNoteName,
                        this.NoteID,
                        this.txtNoteCode.Text,
                        PrdID,
                        CompanyID,
                        drow["LostQty"],
                        drow["CostPrice"]);

                }
                //委外预留
                this.accStoreReserve.UpdateOutSrcStoreReserveForAdjustStore(ref errormsg,
                CompanyID,
                PrdID);
               
            } 
            MessageBox.Show("成功保存并入账当前盘点单");
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }
    }
}