using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class CtrlOEMOutStoreNoteOper : UserControl
    {
        public CtrlOEMOutStoreNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accItems = new JERPData.Material.OEMOutStoreItems();
            this.accNotes = new JERPData.Material.OEMOutStoreNotes();
            this.accStore = new JERPData.Material.OEMStore();
            this.accReplenishPlans = new JERPData.Material.OEMOutStoreReplenishPlans();
            this.accStoreReserve = new JERPData.Material.OEMStoreReserve();
            this.printhelper = new JERPBiz.Material.OEMOutStoreNotePrintHelper();
            this.btnExport.Click += new EventHandler(btnExport_Click);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);        
        }

   
        private JERPData.Material.OEMOutStoreItems accItems;
        private JERPData.Material.OEMOutStoreNotes accNotes;
        private JERPData.Material.OEMOutStoreReplenishPlans accReplenishPlans;
        private DataTable dtblItems;
        private JERPData.Material.OEMStore accStore;
        private JERPData.Material.OEMStoreReserve accStoreReserve;
        private JERPBiz.Material.OEMOutStoreNotePrintHelper printhelper;
        private decimal GetStoreQty(int CustomerID, int PrdID)
        {
            decimal rut = 0;
            this.accStore.GetParmOEMStoreInventoryQty (CustomerID , PrdID, ref rut);
            return rut;
        }
        private decimal GetReplenishQty(int CustomerID,int PrdID)
        {
            decimal rut = 0;
            this.accReplenishPlans.GetParmOEMOutStoreReplenishPlansQuantity (CustomerID,PrdID, ref rut);
            return rut;
        }
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
              
                object objQuantity = grow.Cells[this.ColumnQuantity.Name].Value;
                object objInventory = grow.Cells[this.ColumnInventoryQty.Name].Value;
                if ((objQuantity != DBNull.Value) && (objInventory != DBNull.Value))
                {
                    grow.ErrorText = ((decimal)objQuantity > (decimal)objInventory) ? "库存不足" : string.Empty;
                }

            }
        } 

        public void NoteOper()
        {
            this.dtblItems = this.accItems.GetDataOEMOutStoreItemsByNoteID(-1).Tables[0];
            this.dtblItems.Columns.Add("RequireQty", typeof(decimal));
            this.dtblItems.Columns.Add("ReplenishQty", typeof(decimal));
            this.dtblItems.Columns.Add("InventoryQty", typeof(decimal));
            this.dgrdv.DataSource = this.dtblItems;
        }
        public void AppendItem(DataRow drowBom)
        {
            int PrdID = (int)drowBom["PrdID"];
            int CustomerID = (int)drowBom["CustomerID"];
            DataRow[] drowItems  = this.dtblItems.Select("PrdID=" + PrdID.ToString()+" and CompanyID="+CustomerID .ToString ());
            DataRow drowItem;
            if (drowItems.Length == 0)
            {
                drowItem = this.dtblItems.NewRow();
                drowItem["PrdID"] = PrdID;
                drowItem["CompanyID"] = CustomerID;
                drowItem["PrdCode"] = drowBom["PrdCode"];
                drowItem["PrdName"] = drowBom["PrdName"];
                drowItem["PrdSpec"] = drowBom["PrdSpec"];
                drowItem["Manufacturer"] = drowBom["Manufacturer"];
                drowItem["UnitName"] = drowBom["UnitName"];
                drowItem["RequireQty"] = drowBom["RequireQty"];
                drowItem["ReplenishQty"] = this.GetReplenishQty(CustomerID, PrdID);
                drowItem["Quantity"] = (decimal)drowItem["RequireQty"]+(decimal )drowItem["ReplenishQty"];
                drowItem["CompanyAbbName"] = drowBom["Customer"];
                drowItem["InventoryQty"] = this.GetStoreQty(CustomerID, PrdID);
            }
            else
            {
                drowItem = drowItems[0];
                drowItem["RequireQty"] = (decimal)drowItem["RequireQty"] + (decimal)drowBom ["RequireQty"];
                drowItem["Quantity"] = drowItem["RequireQty"];
            }
            if (drowItems.Length == 0)
            {
                this.dtblItems.Rows.Add(drowItem);
            }

        }
        public int RowCount
        {
            get
            {
                return this.dgrdv.RowCount;
            }
        }
        public  bool ValidateData(out string ErrorMsg)
        {
            ErrorMsg = string.Empty;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue; 
                drow["InventoryQty"] = this.GetStoreQty((int)drow["CompanyID"], (int)drow["PrdID"]); 
            } 
            DataRow[] drows = this.dtblItems.Select("Quantity>InventoryQty", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                ErrorMsg ="对不起,当前客供库存存在不足,不能出库";
                return false;
            }
            return true;
        }
      
        public void Save()
        {
            string errormsg = string.Empty; 
            bool flag = false;
            long NoteID = -1;
            string NoteCode = string.Empty;
            object objNoteID = DBNull.Value;
            object objNoteCode = DBNull.Value;
            flag = this.accNotes.InsertOEMOutStoreNotes (ref errormsg,
                ref objNoteID,
                ref objNoteCode,
                DateTime.Now,
                JERPBiz.Frame.UserBiz.PsnID,
                "生产领料");
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            NoteID = (long)objNoteID;
            NoteCode = objNoteCode.ToString();
            decimal Quantity, RequireQty, ReplenishQty;
            int PrdID,CustomerID; 
            foreach (DataRow drow in this.dtblItems.Rows)
            {
              
                       
                PrdID = (int)drow["PrdID"];
                CustomerID = (int)drow["CompanyID"];
                RequireQty = (decimal)drow["RequireQty"];
                ReplenishQty = (decimal)drow["ReplenishQty"];
                Quantity =(drow["Quantity"]==DBNull .Value )?0: (decimal)drow["Quantity"];
               this.accItems.InsertOEMOutStoreItems(ref errormsg,
                   NoteID,
                   PrdID,
                   Quantity,
                   CustomerID ,
                   DBNull .Value);
                //出库
                this.accStore.InsertOEMStoreForOutStore (ref errormsg,
                          JERPApp .Store .MaterialOEM.Report .Bill .FrmBizBill .OutStoreNoteID ,
                          JERPApp .Store .MaterialOEM .Report .Bill .FrmBizBill .OutStoreNoteName ,
                          NoteID,
                          NoteCode,
                          PrdID,
                          CustomerID ,
                          Quantity );
                //预留出
                this.accStoreReserve.SaveOEMStoreReserveSubReserve (ref errormsg,
                    CustomerID ,
                    PrdID,
                    Quantity);
                //先假定完成的是扣除部分
                this.accReplenishPlans.UpdateOEMOutStoreReplenishPlansForFinishedQty (ref errormsg,
                    CustomerID ,
                    PrdID,
                    ReplenishQty );
                if (ReplenishQty + RequireQty > Quantity)
                {
                    this.accReplenishPlans.SaveOEMOutStoreReplenishPlans (ref errormsg,
                        CustomerID ,
                        PrdID,
                        ReplenishQty + RequireQty - Quantity);
                }
            }

        }
        void btnExport_Click(object sender, EventArgs e)
        { 
            FrmMsg.Show("正在生成打印文档，请稍候......");
            this.printhelper.ExportToExcel(this.dtblItems.Select());
            FrmMsg.Hide(); 
        }
    }
}
