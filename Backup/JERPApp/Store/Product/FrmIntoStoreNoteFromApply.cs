using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product
{
    public partial class FrmIntoStoreNoteFromApply : Form
    {
        public FrmIntoStoreNoteFromApply()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.dtpDateNote.Value = DateTime.Now.Date;
            this.accItems = new JERPData.Product.IntoStoreItems();
            this.accNotes = new JERPData.Product.IntoStoreNotes();
            this.accStore = new JERPData.Product.Store();
            this.accBranchSotre = new JERPData.Product.BranchStore();
            this.accWorkingSheets = new JERPData.Manufacture.WorkingSheets();
            this.accPrds = new JERPData.Product.Product();
            this.accPlans = new JERPData.Product.IntoStoreItemPlans();
            this.accBoxItems = new JERPData.Packing.BoxItems();
            this.BoxEntity = new JERPBiz.Packing.BoxEntity();
            this.accPackingSheets = new JERPData.Packing.WorkingSheets();
            this.SetColumnSrc();
            this.btnSave.Click += new EventHandler(btnSave_Click);
            foreach (DataGridViewColumn col in this.dgrdv.Columns)
            {
                col.ReadOnly = true;
            }
            this.ColumnCheckedFlag.ReadOnly = false;
            this.ColumnQuantity.ReadOnly = false;
        }

        private JERPData.Product.IntoStoreNotes accNotes;
        private JERPData.Product.IntoStoreItems accItems;
        private JERPData.Product.IntoStoreItemPlans accPlans;
        private JERPData.Packing.BoxItems accBoxItems;
        private JERPBiz.Packing.BoxEntity BoxEntity;
        private JERPData.Product.Store accStore;
        private JERPData.Product.Product accPrds;

        private JERPData.Manufacture.WorkingSheets accWorkingSheets;
        private JERPData.Packing.WorkingSheets accPackingSheets;
        private JERPData.Product.BranchStore accBranchSotre;
        private DataTable dtblItems, dtblBranchStores;
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
        private void SetColumnSrc()
        {

            this.dtblBranchStores = this.accBranchSotre.GetDataBranchStore().Tables[0];
            this.ColumnBranchStoreID.DataSource = this.dtblBranchStores;
            this.ColumnBranchStoreID.ValueMember = "BranchStoreID";
            this.ColumnBranchStoreID.DisplayMember = "BranchStoreName";
        }

        private object GetDefaultBranchStoreID(int PrdID)
        {
            int rut = 1;
            this.accStore.GetParmStoreDefaultBranchStoreID(PrdID, ref rut);
            if (rut > -1)
            {
                return rut;
            }
            return DBNull.Value;
        }

        private decimal GetCostPrice(int PrdID)
        {
            decimal rut = 0;
            this.accPrds.GetParmProductCostPrice(PrdID, ref rut);
            return rut;
        }
        public void New()
        {
            this.dtblItems = this.accPlans.GetDataIntoStoreItemPlansNonIntoStore().Tables[0];
            this.dtblItems.Columns.Add("CheckedFlag", typeof(bool));
            this.dtblItems.Columns.Add("BranchStoreID", typeof(int));
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                drow["CheckedFlag"] = true;
                drow["BranchStoreID"]=this.GetDefaultBranchStoreID ((int)drow["PrdID"]);
            }
            this.dgrdv .DataSource =this.dtblItems ;
        }
        bool ValidateData()
        {
            bool flag = true;
            DataRow[] drows = this.dtblItems.Select("CheckedFlag=1");
            if (drows.Length == 0)
            {
                MessageBox.Show("未存在任何明细项");
                return false;
            }
            drows = this.dtblItems.Select("CheckedFlag=1 and BranchStoreID is null");
            if (drows.Length > 0)
            {
                MessageBox.Show("存在没有库位项");
            }
            return flag;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            DialogResult rul = MessageBox.Show("将进行保存入账一经入账不能变更！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            string errormsg = string.Empty;
            bool flag = false;
            long NoteID = -1;
            string NoteCode = string.Empty;
            object objNoteID = DBNull.Value;
            object objNoteCode = DBNull.Value;
            flag = this.accNotes.InsertIntoStoreNotes(ref errormsg, ref objNoteID, ref objNoteCode,
                this.dtpDateNote.Value.Date,
                JERPBiz.Frame.UserBiz.PsnID,
                this.rchMemo.Text);
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            NoteID = (long)objNoteID;
            NoteCode = objNoteCode.ToString();
            decimal Quantity, CostPrice, CostAMT = 0;
            int PrdID, BranchStoreID;
            DataTable dtblBoxItems;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                PrdID = (int)drow["PrdID"];
                BranchStoreID = (int)drow["BranchStoreID"];
                CostPrice = this.GetCostPrice(PrdID);
                Quantity = (decimal)drow["Quantity"];
                CostAMT += CostPrice * Quantity;
                this.accItems.InsertIntoStoreItems(ref errormsg,
                   NoteID,
                   drow["WorkingSheetID"],
                   PrdID,
                   Quantity,
                   BranchStoreID,
                   CostPrice,
                   drow["Memo"]);
                this.accPlans.UpdateIntoStoreItemPlansForIntoStore(ref errormsg, drow["ItemID"]);
                //入库
                this.accStore.InsertStoreForIntoStore(ref errormsg,
                         JERPBiz.Finance.NoteNameParm.PrdIntoStoreNoteNameID,
                          NoteID,
                          NoteCode,
                          PrdID,
                          BranchStoreID,
                          Quantity,
                          CostPrice);
                if (drow["WorkingSheetID"] != DBNull.Value)
                {
                    this.accWorkingSheets.UpdateWorkingSheetsForAppendFinishedQty(ref errormsg,
                        drow["WorkingSheetID"],
                        Quantity);
                }
                if (drow["BoxCode"] != DBNull.Value)
                {
                    this.BoxEntity .LoadData (drow["BoxCode"].ToString ());
                    if (this.BoxEntity.WorkingSheetID > -1)
                    {
                        this.accPackingSheets.UpdateWorkingSheetsForAppendFinishedQty(ref errormsg,
                            this.BoxEntity.WorkingSheetID,
                            Quantity); 
                    }
                    dtblBoxItems = this.accBoxItems.GetDataBoxItemsByBoxCode(drow["BoxCode"].ToString()).Tables[0];
                    foreach (DataRow drowBoxItem in dtblBoxItems.Rows)
                    {
                        if(drowBoxItem["WorkingSheetID"]==DBNull .Value )continue ;
                        this.accWorkingSheets.UpdateWorkingSheetsForAppendFinishedQty(
                            ref errormsg,
                            drowBoxItem["WorkingSheetID"],
                            1);
                    }
                }

            } 
            MessageBox.Show("成功保存并入账当前单据");
            if (this.affterSave != null) this.affterSave();
            this.New();

        }

    }
}