using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class CtrlOutSrcSupplyItemOper : UserControl 
    {
        public CtrlOutSrcSupplyItemOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Material.OutSrcSupplyItems(); 
            this.accStore = new JERPData.Material.Store();
            this.accOutSrcStore = new JERPData.Material.OutSrcStore(); 
            this.accBranchSotre = new JERPData.Material.BranchStore();
            this.accStorePlace = new JERPData.Material.StorePlace();
            this.accPrds = new JERPData.Product.Product(); ;
            this.accOutSrcStore = new JERPData.Material.OutSrcStore();
            this.printhelper = new JERPBiz.Material.OutStoreNotePrintHelper();
            this.SetColumnSrc();
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            foreach (DataGridViewColumn col in this.dgrdv.Columns)
            {
                col.ReadOnly = true;
            }
            this.ColumnBranchStoreID.ReadOnly = false; 
            this.ColumnQuantity.ReadOnly = false;

            this.dtblItems = this.accItems.GetDataOutSrcSupplyItemsByNoteID(-1).Tables[0];
            this.dtblItems.Columns.Add("StoreQty", typeof(decimal));
            
            this.dgrdv.DataSource = this.dtblItems;
         
        }

        private JERPData.Material.OutSrcSupplyItems accItems; 
        private JERPData.Product.Product accPrds;
        private JERPData.Material.BranchStore accBranchSotre; 
        private DataTable dtblBranchStores,dtblItems;
        private JERPData.Material.Store accStore;
        private JERPBiz.Material.OutStoreNotePrintHelper printhelper;
        private JERPData.Material.OutSrcStore accOutSrcStore;
        private JERPData.Material.StorePlace accStorePlace;
        private int companyid = -1;
        public int CompanyID
        {
            get
            {
                return this.companyid;
            }
            set
            {
                this.companyid = value;
            }
        }
        private string GetStorePlace(int PrdID, int BranchStoreID)
        {
            string rut = string.Empty;
            this.accStorePlace.GetParmStorePlace(BranchStoreID, PrdID,ref rut );
            return rut;
        }
        private decimal GetStoreQty(int PrdID,int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryQty  (PrdID,BranchStoreID,ref rut);
            return rut;
        } 
        private decimal GetLastNonFinishedQty(int PrdID)
        {
            decimal rut = 0;
            this.accItems.GetParmOutSrcSupplyItemsLastNonFinishedQty(this.CompanyID,
                PrdID, ref rut);
            return rut;
        }
  
        private decimal GetOutSrcStoreQty(int PrdID)
        {
            decimal rut = 0;
            this.accOutSrcStore.GetParmOutSrcStoreInventoryQty(this.CompanyID, PrdID, ref rut);
            return rut;
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
        private string GetBranchStoreName(int BranchStoreID)
        {
            DataRow[] drows = this.dtblBranchStores.Select("BranchStoreID=" + BranchStoreID.ToString());
            if (drows.Length > 0)
            {
                return drows[0]["BranchStoreName"].ToString();
            }
            return string.Empty;
        }
        private decimal GetQuantity(object objMinPackingQty, decimal PlanQty)
        {
            if (objMinPackingQty == DBNull.Value) return PlanQty;
            if ((decimal)objMinPackingQty <= 0) return PlanQty;
            return Math.Ceiling(PlanQty / (decimal)objMinPackingQty) * (decimal)objMinPackingQty;
        }
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            int PrdID = (int)this.dtblItems.DefaultView[irow]["PrdID"];
            if (this.dgrdv.Columns[icol].Name == this.ColumnBranchStoreID.Name)
            {
                object objBranchStoreID = this.dgrdv[this.ColumnBranchStoreID.Name, irow].Value;
                if (objBranchStoreID != DBNull.Value)
                {
                    this.dgrdv[this.ColumnStoreQty.Name, irow].Value = this.GetStoreQty(PrdID, (int)objBranchStoreID);
                    this.dgrdv[this.ColumnBranchStoreName.Name, irow].Value = this.dgrdv[this.ColumnBranchStoreID.Name, irow].FormattedValue;
                    this.dgrdv[this.ColumnStorePlace.Name, irow].Value = this.GetStorePlace(PrdID, (int)objBranchStoreID);
                }
                
            } 
        }
   
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {               
                grow.ErrorText = string.Empty;
                object objQuantity = grow.Cells[this.ColumnQuantity.Name].Value; 
                object objInventory = grow.Cells[this.ColumnStoreQty .Name].Value; 
                decimal Quantity = (objQuantity != DBNull.Value) ? (decimal)objQuantity : 0; 
                decimal InventoryQty = (objInventory != DBNull.Value) ? (decimal)objInventory : 0;
                if (InventoryQty <Quantity )
                {
                    grow.ErrorText = "库存不足";
                    continue;
                }              
                object objBranchStoreID = grow.Cells[this.ColumnBranchStoreID.Name].Value; 
                if ((objBranchStoreID == DBNull.Value) )
                {
                    grow.ErrorText = "未设任何库位";
                    continue;
                }
            }
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
         
            foreach (DataRow drowItem in this.dtblItems.Rows)
            {
                int PrdID = (int)drowItem["PrdID"];
                drowItem["LastNonFinishedQty"] = this.GetLastNonFinishedQty(PrdID);
                drowItem["OutSrcInventoryQty"] = this.GetOutSrcStoreQty(PrdID);
                if (drowItem["BranchStoreID"] != DBNull.Value)
                {
                    drowItem["StoreQty"] = this.GetStoreQty(PrdID, (int)drowItem["BranchStoreID"]);
                }
            }
        }
         
        public void ClearItems()
        {
            this.dtblItems.Clear();
        }
        public void Edit(long NoteID)
        {
           
            DataTable dtblTmp = this.accItems.GetDataOutSrcSupplyItemsByNoteID(NoteID).Tables[0];
            this.AppendItems(dtblTmp.Select(), false);
        }
        public void AppendItems(DataRow[] drowBoms,bool NewFlag)
        {
            foreach (DataRow drow in drowBoms)
            {
                this.AppendItem(drow,NewFlag);
            }
            decimal RequireQty, LastNonFinishedQty, OutSrcInventoryQty,  Quantity;
            foreach (DataRow drowItem in this.dtblItems.Rows)
            {
                int PrdID = (int)drowItem["PrdID"];              
                RequireQty = Convert .ToInt32 ((decimal)drowItem["RequireQty"]);
                LastNonFinishedQty = this.GetLastNonFinishedQty (PrdID);
                drowItem["LastNonFinishedQty"] = LastNonFinishedQty ;
                OutSrcInventoryQty = this.GetOutSrcStoreQty(PrdID);
                drowItem["OutSrcInventoryQty"] = OutSrcInventoryQty;
                if (NewFlag)
                {
                    Quantity = (OutSrcInventoryQty >= RequireQty + LastNonFinishedQty) ? 0 : (RequireQty + LastNonFinishedQty - OutSrcInventoryQty);
                    if (Quantity > 0)
                    {
                        Quantity = this.GetQuantity(drowItem["MinPackingQty"], Quantity);
                    }
                    drowItem["Quantity"] = Quantity;
                } 
                if (drowItem["BranchStoreID"] != DBNull.Value)
                {
                    drowItem["StoreQty"] = this.GetStoreQty(PrdID, (int)drowItem["BranchStoreID"]);
                }
            }
        }
        public  void AppendItem(DataRow drowBom,bool NewFlag)
        {
            int PrdID=(int)drowBom["PrdID"]; 
            DataRow[] drowItems = this.dtblItems.Select("PrdID=" + PrdID.ToString());
            DataRow drowItem; 
            object objBranchStoreID;
            if (drowItems.Length == 0)
            {
                drowItem = this.dtblItems.NewRow();
                drowItem["PrdID"] = PrdID;
                drowItem["PrdCode"] = drowBom["PrdCode"];
                drowItem["PrdName"] = drowBom["PrdName"];
                drowItem["PrdSpec"] = drowBom["PrdSpec"];
                drowItem["Manufacturer"] = drowBom["Manufacturer"];
                drowItem["Model"] = drowBom["Model"];
                drowItem["UnitName"] = drowBom["UnitName"];
                drowItem["MinPackingQty"] = drowBom["MinPackingQty"]; 
                drowItem["RequireQty"] = drowBom["RequireQty"];
                if (NewFlag)
                {
                    objBranchStoreID = this.GetDefaultBranchStoreID(PrdID);
                    drowItem["BranchStoreID"] = objBranchStoreID;
                    if (objBranchStoreID != DBNull.Value)
                    {
                        drowItem["StorePlace"] = this.GetStorePlace(PrdID, (int)objBranchStoreID);
                        drowItem["BranchStoreName"] = this.GetBranchStoreName ((int)objBranchStoreID);
                    }
                }
                else
                {
                    drowItem["ItemID"] = drowBom["ItemID"];
                    drowItem["Quantity"] = drowBom["Quantity"];
                    drowItem["BranchStoreID"] = drowBom["BranchStoreID"];
                    drowItem["BranchStoreName"] = drowBom["BranchStoreName"];
                    drowItem["StorePlace"] = drowBom["StorePlace"];
                }
               
                this.dtblItems.Rows.Add(drowItem);
            }
            else
            {
                drowItem = drowItems[0];
                drowItem["RequireQty"] = (decimal) drowItem["RequireQty"]+(decimal)drowBom["RequireQty"];
                
            }
        }
        public bool ValidateData()
        {
            if (this.dtblItems.Rows.Count == 0)
            {
                MessageBox.Show("对不起,没有发送任何物料!");
                return false;
            }
            if (this.dtblItems.Select("Quantity>StoreQty").Length > 0)
            {
                MessageBox.Show("发料数不能大于库存数");
                return false;
            }
            return true;
        }
        public void Export()
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            this.printhelper.ExportToExcel(this.dtblItems.Select());
            FrmMsg.Hide(); 
        }
        public void Save(long NoteID)
        {
            string errormsg = string.Empty;
            bool flag = false;
            object objItemID = DBNull.Value;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow["ItemID"] == DBNull.Value)
                {
                    objItemID = DBNull.Value;
                    flag = this.accItems.InsertOutSrcSupplyItems(ref errormsg,
                        ref objItemID,
                        NoteID,
                        drow["PrdID"],
                        drow["RequireQty"],
                        drow["MinPackingQty"],
                        drow["Quantity"],
                        drow["BranchStoreID"]
                        );
                    if (flag)
                    {
                        drow["ItemID"] = objItemID;
                    }
                }
                else
                {
                 
                    flag = this.accItems.UpdateOutSrcSupplyItems(ref errormsg,
                        drow["ItemID"],
                        drow["Quantity"],
                        drow["BranchStoreID"]);
                    
                }
            }
        }
 

    }
}