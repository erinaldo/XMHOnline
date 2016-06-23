using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class FrmOutStoreNoteAppOper : Form
    {
        public FrmOutStoreNoteAppOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Material.OutStoreItems();
            this.accNotes = new JERPData.Material.OutStoreNotes();
            this.accStore = new JERPData.Material.Store();
            this.accStoreReserve = new JERPData.Material.StoreReserve();
            this.accBranchSotre = new JERPData.Material.BranchStore(); 
            this.accPrds = new JERPData.Product.Product(); 
            this.accExpenseAccount = new JERPData.Finance.ExpenseAccount(); 
            this.SetColumnSrc();
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnAddPrd.Click += new EventHandler(btnAddPrd_Click);
        }

     

        private JERPData.Material.OutStoreNotes accNotes;
        private JERPData.Material.OutStoreItems accItems;
        private JERPData.Product.Product accPrds; 
        private JERPData.Material.BranchStore accBranchSotre;
        private DataTable dtblPrds,dtblItems,dtblBranchStores;
        private JERPData.Material.Store accStore;
        private JERPData.Material.StoreReserve accStoreReserve; 
        private JCommon.FrmGridFind frmGridPrd;

        private JERPData.Finance.ExpenseAccount accExpenseAccount;
        private JERPApp.Define.Material.FrmProduct frmPrd;
        private JERPApp.Define.Material.FrmProduct frmAddPrd;
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
        private decimal GetStoreQty(int PrdID,int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryQty (PrdID,BranchStoreID,ref rut);
            return rut;
        }
        
        private decimal GetCostPrice(int PrdID, int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryPrice(PrdID,BranchStoreID , ref rut);
            return rut;
        }

        private void SetColumnSrc()
        {
            this.dtblPrds = this.accPrds.GetDataProductForMaterial().Tables[0];
         

            this.dtblBranchStores = this.accBranchSotre.GetDataBranchStore().Tables[0];
            this.ColumnBranchStoreID.DataSource = this.dtblBranchStores;
            this.ColumnBranchStoreID.ValueMember = "BranchStoreID";
            this.ColumnBranchStoreID.DisplayMember = "BranchStoreName";
 

        }

 
        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if ((this.dgrdv.Columns[icol].Name  == this.ColumnPrdCode.Name )
                ||(this.dgrdv.Columns[icol].Name  == this.ColumnPrdName.Name )
                ||(this.dgrdv.Columns[icol].Name  == this.ColumnPrdSpec.Name )
                ||(this.dgrdv.Columns[icol].Name  == this.ColumnModel .Name )
                ||(this.dgrdv.Columns[icol].Name  == this.ColumnManufacturer .Name ))
            {
                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (frmPrd == null)
                {
                    frmPrd = new JERPApp.Define.Material.FrmProduct();
                    new FrmStyle(frmPrd).SetPopFrmStyle(this);
                    frmPrd.AffterSelected += new JERPApp.Define.Material.FrmProduct.AffterSelectedDelegate(frmPrd_AffterSelected);
                }
                frmPrd.ShowDialog();
            }
        }

        void frmPrd_AffterSelected(DataRow drow)
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            grow.Cells[this.ColumnPrdID.Name].Value = drow["PrdID"];
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel .Name].Value = drow["Model"];
            grow.Cells[this.ColumnManufacturer.Name].Value = drow["Manufacturer"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"];
            object objBranchStoreID = this.GetDefaultBranchStoreID((int)drow["PrdID"]);
            grow.Cells[this.ColumnBranchStoreID.Name].Value = objBranchStoreID;
            if (objBranchStoreID != DBNull.Value)
            {
                grow.Cells[this.ColumnInventoryQty.Name].Value = this.GetStoreQty((int)drow["PrdID"], (int)objBranchStoreID);
            }
            this.frmPrd.Close();
        }
        void btnAddPrd_Click(object sender, EventArgs e)
        {
            if (frmAddPrd == null)
            {
                this.frmAddPrd = new JERPApp.Define.Material.FrmProduct();
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
            drowNew["Manufacturer"] = drow["Manufacturer"];
            drowNew["UnitName"] = drow["UnitName"]; 
            drowNew["BranchStoreID"] = this.GetDefaultBranchStoreID(PrdID);
            if (drowNew["BranchStoreID"] != DBNull.Value)
            {
                drowNew["InventoryQty"] = this.GetStoreQty(PrdID, (int)drowNew["BranchStoreID"]);
            }
            drowNew["Quantity"] = 0;
            this.dtblItems.Rows.Add(drowNew);

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


        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].DataPropertyName == "PrdID")
            {
                object objPrdID = this.dgrdv[icol, irow].Value;
                if (objPrdID == DBNull.Value) return;
                object objBranchStoreID = this.dgrdv[this.ColumnBranchStoreID.Name, irow].Value;
                if (objBranchStoreID == DBNull.Value)
                {
                    objBranchStoreID = this.GetDefaultBranchStoreID((int)objPrdID);
                    this.dgrdv[this.ColumnBranchStoreID.Name, irow].Value = objBranchStoreID;
                }
                if ( (objBranchStoreID != null)&&(objBranchStoreID != DBNull.Value))
                {
                    this.dgrdv[this.ColumnInventoryQty.Name, irow].Value = this.GetStoreQty((int)objPrdID, (int)objBranchStoreID);
                    
                    return;
                }
                           
            
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnBranchStoreID.Name)
            {
                object objBranchStoreID = this.dgrdv[this.ColumnBranchStoreID.Name, irow].Value;
                if (objBranchStoreID == DBNull.Value) return;
                object objPrdID = this.dgrdv[this.ColumnPrdID .Name, irow].Value;
                if (objPrdID == DBNull.Value) return;             
                this.dgrdv[this.ColumnInventoryQty.Name, irow].Value = this.GetStoreQty((int)objPrdID , (int)objBranchStoreID);
               
            }
          
           
        }
   
       
        public void NewNote()
        {
          
            this.dtpDateNote.Value = DateTime.Now.Date; 
            this.rchMemo.Text = string.Empty;
            this.dtblItems = this.accItems.GetDataOutStoreItemsByNoteID(-1).Tables[0];
            this.dtblItems.Columns.Add("InventoryQty", typeof(decimal));
            this.dgrdv.DataSource = this.dtblItems; 
          
        }

        void btnNew_Click(object sender, EventArgs e)
        {
            this.NewNote();
        }
 
        
        private bool ValidateData()
        {
            DataRow[] drows = this.dtblItems.Select("Quantity is null");
            if (drows.Length > 0)
            {
                MessageBox.Show("存在数量为空项");
                return false;
            }
            drows= this.dtblItems.Select("BranchStoreID is null");
            if (drows.Length > 0)
            {
                MessageBox.Show("对不起,未设置任何库位");
                return false;
            }
            drows = this.dtblItems.Select("Quantity>InventoryQty");
            if (drows.Length > 0)
            {
                MessageBox.Show("对不起,当前库存存在不足,不能出货");
                return false;
            }  
         
            return true;
        }
       

        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                object objQuantity = grow.Cells[this.ColumnQuantity.Name].Value;
                object objInventory = grow.Cells[this.ColumnInventoryQty.Name].Value;
                if ((objQuantity != DBNull.Value) && (objInventory != DBNull.Value))
                {
                    grow.ErrorText = ((decimal)objQuantity > (decimal)objInventory) ? "库存不足" : string.Empty;
                }
               
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
                    this.frmGridPrd.AddGridColumn("PrdCode", "物料编号", 100);
                    this.frmGridPrd.AddGridColumn("PrdName", "物料名称", 100);
                    this.frmGridPrd.AddGridColumn("PrdSpec", "物料规格", 100);
                    this.frmGridPrd.AddGridColumn("Model", "机型", 66);
                    this.frmGridPrd.AddGridColumn("Manufacturer", "品牌", 66);
                    this.frmGridPrd.AddGridColumn("AssistantCode", "助记码", 66);
                    this.frmGridPrd.AffterSelected += frmGridPrd_AffterSelected;

                }

                this.frmGridPrd.Query(this.dtblPrds, "AssistantCode", this.dgrdv.CurrentCell);
                

            }
        }
        void frmGridPrd_AffterSelected(DataRow drow)
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow; 
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdID"];
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
            flag = this.accNotes.InsertOutStoreNotes  (ref errormsg, 
                ref objNoteID, 
                ref objNoteCode,
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
            int PrdID;
            decimal Quantity = 0, TotalAMT = 0;
            object objCostPrice = DBNull.Value;
            foreach (DataRow drow in this.dtblItems.Rows )
            {
                if (drow["Quantity"] == DBNull.Value) continue;
                objCostPrice = DBNull.Value;
                PrdID = (int)drow["PrdID"];
                Quantity = (decimal)drow["Quantity"]; 
                objCostPrice = this.GetCostPrice(PrdID,(int)drow["BranchStoreID"]);
                TotalAMT += Quantity * (decimal)objCostPrice; 
                flag = this.accItems.InsertOutStoreItems(ref errormsg,
                   NoteID,
                   PrdID,
                   Quantity,
                   drow["BranchStoreID"], 
                   objCostPrice );
                
                //出库
                this.accStore.InsertStoreForOutStore(ref errormsg,
                         JERPBiz.Finance.NoteNameParm.MtrOutStoreNoteNameID,
                          NoteID,
                          NoteCode,
                          PrdID,
                          drow["BranchStoreID"],
                          Quantity,
                          objCostPrice);
                //预留出
                this.accStoreReserve.SaveStoreReserveForSubReserve(ref errormsg,
                    PrdID,
                    Quantity);
               
                         
            }
            if (TotalAMT > 0)
            {
                //生产领料单
                this.accExpenseAccount.InsertExpenseAccountForDebit(
                    ref errormsg,
                    "原料领料单[" + NoteCode + "]",
                    JERPBiz.Finance.ExpenseTypeParm.MtrExpense,
                    TotalAMT,
                    JERPBiz.Frame.UserBiz.PsnID);
            }          
           
            MessageBox.Show("成功保存并入账当前单据");
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }
 

    }
}