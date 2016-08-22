using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace JERPApp.Store.Product
{
    public partial class FrmBranchStoreMoveNoteOper : Form
    {
        public FrmBranchStoreMoveNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false; 
            this.accItems = new JERPData.Product.BranchStoreMoveItems();
            this.accNotes = new JERPData.Product.BranchStoreMoveNotes();
            this.accPrds = new JERPData.Product.Product ();
            this.accStore = new JERPData.Product.Store();
            this.dtblPrds = this.accPrds.GetDataProductForFinishedPrd().Tables[0];
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.ctrlOutBranchStoreID.AffterSelected += ctrlOutBranchStoreID_AffterSelected;
            this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery); 
            this.btnAddPrd.Click += new EventHandler(btnAddPrd_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnBox.Click += new EventHandler(btnBox_Click);
        }

       
        private JERPData.Product.Store accStore;     
        private JERPData.Product.BranchStoreMoveNotes accNotes;
        private JERPData.Product.BranchStoreMoveItems accItems;
        private JERPData.Product.Product accPrds;
        private JERPApp.Define.Product.FrmFinishedPrd frmPrd;
        private JERPApp.Define.Product.FrmFinishedPrd frmAddPrd;
        private JERPApp.Define.Packing.FrmBoxFromBarcode frmBox;
        private JCommon.FrmGridFind frmGridPrd;
        private DataTable dtblItems,dtblPrds;
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
        
    
        public void NewNote()
        {
            this.dtpDateNote.Value = DateTime.Now.Date;
            this.txtNoteCode.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
            this.dtblItems = this.accItems.GetDataBranchStoreMoveItemsByNoteID(-1).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
            this.dtblItems.Columns["PrdID"].AllowDBNull = false;
            this.dtblItems.Columns["PrdID"].Unique = true;
            this.dtblItems.Columns["Quantity"].AllowDBNull = false;
            this.dtblItems.Columns.Add("InventoryQty", typeof(decimal));
 
        }


        private decimal GetInventoryQty(int PrdID)
        {
            decimal inventoryQty = 0;
            this.accStore.GetParmStoreInventoryQty(PrdID, this.ctrlOutBranchStoreID.BranchStoreID,
                ref inventoryQty);
            return inventoryQty;
        }
        void ctrlOutBranchStoreID_AffterSelected()
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                object objPrdID = grow.Cells[this.ColumnPrdCode.Name].Value;
                if (objPrdID == DBNull.Value) continue;
                grow.Cells[this.ColumnInventoryQty.Name].Value = this.GetInventoryQty((int)objPrdID);

            }
        }
        void dgrdv_CellQuery(DataGridViewCellEventArgs e)
        { 
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnAssistantCode.Name)
            {
               
                if (this.frmGridPrd == null)
                {
                    this.frmGridPrd = new JCommon.FrmGridFind();
                    this.frmGridPrd.AddGridColumn("PrdCode", "产品编号", 100);
                    this.frmGridPrd.AddGridColumn("PrdName", "产品名称", 120);
                    this.frmGridPrd.AddGridColumn("PrdSpec", "产品规格", 100);
                    this.frmGridPrd.AddGridColumn("Model", "型号", 66);
                    this.frmGridPrd.AddGridColumn("AssistantCode", "助记码", 66);
                    this.frmGridPrd.AffterSelected += frmGridPrd_AffterSelected;

                }
                this.frmGridPrd.Query(this.dtblPrds, "AssistantCode", this.dgrdv.CurrentCell);
                

            }
        }
        void frmGridPrd_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"];
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            grow.Cells[this.ColumnPrdID.Name].Value = PrdID;
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"];

        }
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].DataPropertyName == "PrdID")
            {
                object objPrdID = this.dgrdv[icol, irow].Value;
                if (objPrdID == DBNull.Value) return;
                this.dgrdv[this.ColumnInventoryQty.Name, irow].Value = this.GetInventoryQty((int)objPrdID);
            }
        }

        void btnBox_Click(object sender, EventArgs e)
        {
            if (frmBox == null)
            {
                frmBox = new JERPApp.Define.Packing.FrmBoxFromBarcode();
                new FrmStyle(frmBox).SetPopFrmStyle(this);
                frmBox.AffterSelect += new JERPApp.Define.Packing.FrmBoxFromBarcode.AffterConfirmDelegate(frmBox_AffterSelect);
            }
            frmBox.New(new Hashtable ());
            frmBox.ShowDialog();
        }

        void frmBox_AffterSelect(DataRow drowBox)
        {
            DataRow[] drowItems = this.dtblItems.Select("PrdID=" + drowBox["PrdID"].ToString(), "", DataViewRowState.CurrentRows);
            DataRow drowItem;
            if (drowItems.Length == 0)
            {
                drowItem = this.dtblItems.NewRow();
                drowItem["PrdID"] = drowBox["PrdID"];
                drowItem["PrdCode"] = drowBox["PrdCode"];
                drowItem["PrdName"] = drowBox["PrdName"];
                drowItem["PrdSpec"] = drowBox["PrdSpec"];
                drowItem["Model"] = drowBox["Model"];
                drowItem["InventoryQty"] = this.GetInventoryQty((int)drowBox["PrdID"]);
                drowItem["Quantity"] = drowBox["Quantity"];
                drowItem["UnitName"] = drowBox["UnitName"];
                this.dtblItems.Rows.Add(drowItem);
            }
            else
            {
                drowItem = drowItems[0];
                if (drowItem["Quantity"] == DBNull.Value)
                {
                    drowItem["Quantity"] = drowBox["Quantity"];
                }
                else
                { 
                    drowItem["Quantity"] =(decimal) drowItem["Quantity"]+(decimal)drowBox["Quantity"];
                }
            }
        }

        bool ValidateData()
        {
            if (this.ctrlIntoBranchStoreID.BranchStoreID == this.ctrlOutBranchStoreID.BranchStoreID)
            {
                MessageBox.Show("对不起,调拨之间的库位不能相同!");
                return false;
            }
            DataRow[] drows = this.dtblItems.Select("Quantity>InventoryQty", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("对不起,当前库存存在不足,不能出货");
                return false;
            }
            return true;
        }
        private decimal GetCostPrice(int PrdID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryPrice(PrdID, this.ctrlOutBranchStoreID.BranchStoreID, ref rut);
            return rut;
        }

        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if ((this.dgrdv.Columns[icol].DataPropertyName == "PrdCode")
               || (this.dgrdv.Columns[icol].DataPropertyName == "PrdName")
               || (this.dgrdv.Columns[icol].DataPropertyName == "PrdSpec")
               || (this.dgrdv.Columns[icol].DataPropertyName == "Model"))
            {

              
                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (frmPrd == null)
                {
                    this.frmPrd = new JERPApp.Define.Product.FrmFinishedPrd();
                    new FrmStyle(this.frmPrd).SetPopFrmStyle(this);
                    this.frmPrd.AffterSelected += frmPrd_AffterSelected;
                }
                this.frmPrd.ShowDialog();
            }
        }

        void frmPrd_AffterSelected(DataRow drow)
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            int PrdID = (int)drow["PrdID"];
            grow.Cells[this.ColumnPrdID.Name].Value = drow["PrdID"];
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"]; 
            grow.Cells[this.ColumnInventoryQty.Name].Value = this.GetInventoryQty(PrdID);
            frmPrd.Close();

        }
        void btnAddPrd_Click(object sender, EventArgs e)
        {
            if (frmAddPrd == null)
            {
                this.frmAddPrd = new JERPApp.Define.Product.FrmFinishedPrd ();
                new FrmStyle(this.frmAddPrd).SetPopFrmStyle(this);
                this.frmAddPrd.AffterSelected += frmAddPrd_AffterSelected;
            }
            this.frmAddPrd.ShowDialog();
        }
        void frmAddPrd_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"];
            if (this.dtblItems.Select("PrdID=" + PrdID.ToString(), "", DataViewRowState.CurrentRows).Length > 0)
            {
                return;
            }
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["PrdID"] = PrdID;
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["Model"] = drow["Model"];
            drowNew["UnitName"] = drow["UnitName"]; 
            drowNew["Quantity"] = 0;
            drowNew["InventoryQty"] = this.GetInventoryQty (PrdID);
            this.dtblItems.Rows.Add(drowNew);

        }
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                decimal Quantity = (decimal)grow.Cells[this.ColumnQuantity.Name].Value;
                decimal Inventory = (decimal)grow.Cells[this.ColumnInventoryQty.Name].Value;
                grow.ErrorText = (Quantity > Inventory) ? "库存不足" : string.Empty;

            }
        }
    
      
        void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult rul = MessageBox.Show("将进行保存入账一经入账不能变更！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            if (ValidateData() == false) return;
            bool flag = false;
            string errormsg = string.Empty;
            long NoteID=-1;
            string NoteCode=string.Empty ;
            object objNoteID = DBNull.Value;
            object objNoteCode = DBNull.Value;
            flag = this.accNotes.InsertBranchStoreMoveNotes(ref errormsg,
                ref objNoteID,
                ref objNoteCode,
                this.dtpDateNote.Value.Date,
                this.ctrlIntoBranchStoreID.BranchStoreID,
                this.ctrlOutBranchStoreID.BranchStoreID,
                JERPBiz.Frame.UserBiz.PsnID,
                this.rchMemo.Text);
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            NoteID =(long)objNoteID ;
            NoteCode =objNoteCode .ToString ();
            this.txtNoteCode.Text = NoteCode;
            foreach (DataRow drow in this.dtblItems.Rows )
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                string ErrorMsg = string.Empty;
                object objItemID = DBNull.Value;
                decimal CostPrice = this.GetCostPrice((int)drow["PrdID"]); 
                flag = this.accItems.InsertBranchStoreMoveItems(ref ErrorMsg,
                     ref objItemID,
                     NoteID,
                     drow["PrdID"],
                     drow["Quantity"],
                     CostPrice);
                if (flag)
                {
                    drow["ItemID"] = objItemID;
                    //转出
                    this.accStore.InsertStoreForOutStore(ref errormsg,
                         JERPBiz.Finance.NoteNameParm.PrdBranchStoreMoveNoteNameID,
                         NoteID ,
                         NoteCode ,
                        drow["PrdID"],
                        this.ctrlOutBranchStoreID.BranchStoreID,
                        drow["Quantity"],
                        CostPrice );
                    //转入
                    this.accStore.InsertStoreForIntoStore(ref errormsg,
                         JERPBiz.Finance.NoteNameParm.PrdBranchStoreMoveNoteNameID,
                       NoteID ,
                       NoteCode ,
                       drow["PrdID"],
                       this.ctrlIntoBranchStoreID .BranchStoreID,
                       drow["Quantity"],
                       CostPrice);
                }

            }         
           
            MessageBox.Show("成功保存并入账当前单据");
            if (this.affterSave != null) this.affterSave();
            this.NewNote();
        }

    
    }
}