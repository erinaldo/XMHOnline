using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product
{
    public partial class FrmIntoStoreNoteFromBox : Form
    {
        public FrmIntoStoreNoteFromBox()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
          
            this.BoxEntity = new JERPBiz.Packing.BoxEntity();
            this.accBoxs = new JERPData.Packing.Boxes();
            this.accBoxItems = new JERPData.Packing.BoxItems();
            this.accItems = new JERPData.Product.IntoStoreItems();
            this.accNotes = new JERPData.Product.IntoStoreNotes();
            this.accPrd = new JERPData.Product.Product();
            this.accStore = new JERPData.Product.Store();

            this.accWorkingSheets = new JERPData.Manufacture.WorkingSheets();
            this.accPackingSheets = new JERPData.Packing.WorkingSheets();
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
        }

        private JERPBiz.Packing.BoxEntity BoxEntity;
        private JERPData.Packing.Boxes accBoxs;
        private JERPData.Packing.BoxItems accBoxItems;
        private JERPData.Product.IntoStoreNotes accNotes;
        private JERPData.Product.IntoStoreItems accItems;
        private JERPData.Product.Product accPrd;
        private JERPData.Product.Store accStore;
        private JERPData.Manufacture.WorkingSheets accWorkingSheets;
        private JERPData.Packing.WorkingSheets accPackingSheets;
        private DataTable dtblBoxes, dtblItems;
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
        public void New()
        {
            this.dtpDateNote.Value = DateTime.Now.Date;
            this.rchMemo.Text = string.Empty;
            this.dtblItems = this.accItems.GetDataIntoStoreItemsByNoteID(-1).Tables[0];

            this.dtblBoxes = this.accBoxs.GetDataBoxesByBoxCode(string.Empty).Tables[0];
            this.dtblBoxes.Columns.Add("ExistFlag", typeof(bool));
            this.dgrdv.DataSource = this.dtblBoxes;
        }
        private decimal GetCostPrice(int PrdID)
        {
            decimal rut = 0;
            this.accPrd.GetParmProductCostPrice(PrdID, ref rut);
            return rut;
        }
      
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                grow.ErrorText = string.Empty;
                object objExistFlag = grow.Cells[this.ColumnExistFlag.Name].Value;
                if (objExistFlag != DBNull.Value)
                {
                    if ((bool)objExistFlag == false)
                    {
                        grow.ErrorText = "箱号不存在";
                        continue;
                    }
                }
               
            }
        }
        private int GetBoxCodeCount(string BoxCode)
        {
            int cnt = 0;
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                if (grow.Cells[this.ColumnBoxCode.Name].Value.ToString() == BoxCode)
                {
                    cnt++;
                    continue;
                }
            }
            return cnt;
        }
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnBoxCode.Name)
            {
                string BoxCode = this.dgrdv[icol, irow].Value.ToString();
                int cnt = this.GetBoxCodeCount(BoxCode);
                if (cnt > 1)
                {
                    BoxCode = string.Empty;
                    this.dgrdv[icol, irow].Value = BoxCode;
                }
                bool Existflag = false;
                this.accBoxs.GetParmBoxesExistFlag(BoxCode, ref Existflag);
                this.dgrdv[this.ColumnExistFlag.Name, irow].Value = Existflag;
                this.BoxEntity.LoadData(BoxCode);
                this.dgrdv[this.ColumnPrdID.Name, irow].Value = this.BoxEntity.PrdID;
                this.dgrdv[this.ColumnPrdCode.Name, irow].Value = this.BoxEntity.PrdCode;
                this.dgrdv[this.ColumnPrdName.Name, irow].Value = this.BoxEntity.PrdName;
                this.dgrdv[this.ColumnPrdSpec.Name, irow].Value = this.BoxEntity.PrdSpec;
                this.dgrdv[this.ColumnModel.Name, irow].Value = this.BoxEntity.Model;
                this.dgrdv[this.ColumnQuantity.Name, irow].Value = this.BoxEntity.Quantity;
            }
        }
        private bool ValidateData()
        {
            if (this.ctrlBranchStoreID.BranchStoreID == -1)
            {
                MessageBox.Show("库位不能为空");
                return false;
            }
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                if (grow.ErrorText != string.Empty)
                {
                    MessageBox.Show("存在箱号不符");
                    return false;

                }
            }
            return true;
        }
        private void AppendBoxingItem(string BoxCode)
        {
            DataTable dtblBoxItems = this.accBoxItems.GetDataBoxItemsByBoxCode(BoxCode).Tables[0];
            if (dtblBoxItems.Rows.Count == 0) return;
            int PrdID = -1; 
            DataRow[] drowItems;
            DataRow drowItem;
            foreach (DataRow drowBoxItem in dtblBoxItems.Rows)
            {
                PrdID = (int)drowBoxItem["PrdID"];
                if (drowBoxItem["WorkingSheetID"] == DBNull.Value)
                {
                    drowItems = this.dtblItems.Select("PrdID=" + PrdID.ToString() + " and WorkingSheetID is null");
                }
                else
                {
                 
                    drowItems = this.dtblItems.Select("WorkingSheetID=" + drowBoxItem["WorkingSheetID"].ToString());
                }
               
                if (drowItems.Length > 0)
                {
                    drowItem = drowItems[0];
                    drowItem["Quantity"] = (decimal)drowItem["Quantity"] + 1;
                }
                else
                {
                    drowItem = this.dtblItems.NewRow();
                    drowItem["WorkingSheetID"] = drowBoxItem["WorkingSheetID"];
                    drowItem["PrdID"] = PrdID;
                    drowItem["Quantity"] = 1;
                    this.dtblItems.Rows.Add(drowItem);
                }
            }
        }

        void btnNew_Click(object sender, EventArgs e)
        {
            this.New();
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            DialogResult rul = MessageBox.Show("将进行保存入账一经入账不能变更！", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
          
            string errormsg = string.Empty;
            this.dtblItems.Clear();
            int PrdID = -1;
            decimal Quantity = 0;
            foreach (DataRow drow in this.dtblBoxes.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                this.AppendBoxingItem(drow["BoxCode"].ToString());
            } 
            if (this.dtblItems.Rows.Count == 0)
            {
                MessageBox.Show("对不起所扫外箱,没有任何产品");
                return;
            }
            bool flag = false;
            long NoteID = -1;
            string NoteCode = string.Empty;
            object objNoteID = -1;
            object objNoteCode = string.Empty;
            flag = this.accNotes.InsertIntoStoreNotes(ref errormsg,
                ref objNoteID,
                ref objNoteCode,
                DateTime.Now.Date,
                JERPBiz.Frame.UserBiz.PsnID,
                string.Empty);
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            NoteID = (long)objNoteID;
            NoteCode = objNoteCode.ToString();
            int BranchStoreID = this.ctrlBranchStoreID.BranchStoreID;
            decimal CostPrice = 0;
            int PackingQty = 0;
            //这里弄的是包装
            foreach (DataRow drow in this.dtblBoxes.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow["WorkingSheetID"] != DBNull.Value)
                {
                    PackingQty = this.accBoxItems.GetDataBoxItemsByBoxCode(drow["BoxCode"].ToString()).Tables[0].Rows.Count;
                    this.accPackingSheets.UpdateWorkingSheetsForAppendFinishedQty(ref errormsg,
                        drow["WorkingSheetID"], PackingQty);
                }
            }
            foreach (DataRow drow in this.dtblItems.Rows)
            {

                PrdID = (int)drow["PrdID"];
                Quantity = (decimal)drow["Quantity"];
                CostPrice = this.GetCostPrice(PrdID);
                this.accItems.InsertIntoStoreItems(ref errormsg,
                    NoteID,
                    drow["WorkingSheetID"],
                    PrdID,
                    Quantity,
                    BranchStoreID,
                    CostPrice,
                    string.Empty);
                //入库
                this.accStore.InsertStoreForIntoStore(ref errormsg,
                     JERPBiz.Finance.NoteNameParm.PrdIntoStoreNoteNameID,
                      NoteID,
                      NoteCode,
                      PrdID,
                      BranchStoreID,
                      Quantity,
                      CostPrice);
                //弄批号完成
                if (drow["WorkingSheetID"] != DBNull.Value)
                {
                    this.accWorkingSheets.UpdateWorkingSheetsForAppendFinishedQty(ref errormsg,
                        drow["WorkingSheetID"],
                        Quantity);
                }
            }
            MessageBox.Show("成功保存当入库");
            if (this.affterSave != null) this.affterSave();
            this.New();
        }
    }
}