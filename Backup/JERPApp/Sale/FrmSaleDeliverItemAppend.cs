using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmSaleDeliverItemAppend : Form
    {
        public FrmSaleDeliverItemAppend()
        {
            InitializeComponent();
            this.dgrdvItem.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdvItem;
            this.accPlanItems = new JERPData.Product.SaleDeliverPlanItems();
            this.accBranchSotre = new JERPData.Product.BranchStore();
            this.accStore = new JERPData.Product.Store();
            this.SetColumnSrc();
            this.dgrdvItem.CellMouseClick += new DataGridViewCellMouseEventHandler(dgrdv_CellMouseClick);
            this.dgrdvItem.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdvItem_DataBindingComplete);
            this.dgrdvItem.CellValueChanged += new DataGridViewCellEventHandler(dgrdvItem_CellValueChanged);
            this.btnAdd.Click += new EventHandler(btnAdd_Click);
           
        }

   
        private JERPData.Product.SaleDeliverPlanItems accPlanItems; 
        private JERPData.Product.BranchStore accBranchSotre;
        private JERPData.Product.Store accStore; 
        private DataTable dtblItems,dtblBranchStore;        
        private void SetColumnSrc()
        {
            this.dtblBranchStore = this.accBranchSotre.GetDataBranchStore().Tables[0];
            this.ColumnBranchStoreID.DataSource = this.dtblBranchStore;
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
        private decimal GetStoreQty(int PrdID, int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryQty(PrdID, BranchStoreID, ref rut);
            return rut;
        }
        public void DeliverItemAppend(long SaleDeliverPlanNoteID,long NoteID)
        {
            this.dtblItems = this.accPlanItems.GetDataSaleDeliverPlanItemsForDeliver(SaleDeliverPlanNoteID,NoteID ).Tables[0];           
            this.dtblItems.Columns.Add("DeliverQty", typeof(decimal));
            this.dtblItems.Columns.Add("BranchStoreID", typeof(int)); 
            this.dtblItems.Columns.Add("InventoryQty", typeof(decimal)); 
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                drow["BranchStoreID"] = this.GetDefaultBranchStoreID((int)drow["PrdID"]);
                if (drow["BranchStoreID"] != DBNull.Value)
                {
                    drow["InventoryQty"] = this.GetStoreQty((int)drow["PrdID"], (int)drow["BranchStoreID"]);
                }
            }
            this.dgrdvItem.DataSource = this.dtblItems;
        }
        public delegate void AffterAppendDelegate(DataRow drow);
        private AffterAppendDelegate affterAppend;
        public event AffterAppendDelegate AffterAppend
        {
            add
            {
                affterAppend += value;
            }
            remove
            {
                affterAppend -= value;
            }
        }      
        void dgrdv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvItem.Columns[icol].DataPropertyName == "DeliverQty")
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (this.dgrdvItem[icol, irow].Value == DBNull.Value)
                    {
                        this.dgrdvItem[icol, irow].Value = this.dgrdvItem[this.ColumnNonFinishedQty.Name, irow].Value;
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    this.dgrdvItem[icol, irow].Value = DBNull.Value;
                
                }
            }
           
        } 
        void dgrdvItem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdvItem.Rows)
            {
               
                object objQuantity = grow.Cells[this.ColumnDeliverQty.Name].Value;
                object objInventory = grow.Cells[this.ColumnInventoryQty.Name].Value;
                if ((objQuantity != DBNull.Value) && (objInventory != DBNull.Value))
                {
                    grow.ErrorText = ((decimal)objQuantity > (decimal)objInventory) ? "库存不足" : string.Empty;
                }

            }
        }
        void dgrdvItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvItem.Columns[icol].Name == this.ColumnBranchStoreID.Name)
            {
                object objPrdID = this.dtblItems.DefaultView[irow]["PrdID"];
                object objBranchStoreID = this.dgrdvItem[this.ColumnBranchStoreID.Name, irow].Value;
                if ((objBranchStoreID != DBNull.Value)
                    && (objBranchStoreID != null))
                {
                    this.dgrdvItem[this.ColumnInventoryQty.Name, irow].Value = this.GetStoreQty((int)objPrdID, (int)objBranchStoreID);
                }
            }
        }
        bool ValidateData()
        {

            DataRow[] drows = this.dtblItems.Select("(DeliverQty is not null)and (BranchStoreID is not null)");
            if (drows.Length == 0)
            {
                MessageBox.Show("未选择任何项");
                return false;
            }
            drows = this.dtblItems.Select("DeliverQty>InventoryQty");
            if (drows.Length > 0)
            {
                MessageBox.Show("出库数不能小于库存数");
                return false;
            }
            return true;
        }
        void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
             DialogResult rul = MessageBox.Show("将进行保存入账一经确认不能变更！", "保存确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (rul == DialogResult.No) return;            
             foreach (DataRow drow in this.dtblItems .Select ("(DeliverQty is not null)and (BranchStoreID is not null)"))
             {
                 if (this.affterAppend != null) this.affterAppend(drow);
             }
             this.Close();
        }
    }
}