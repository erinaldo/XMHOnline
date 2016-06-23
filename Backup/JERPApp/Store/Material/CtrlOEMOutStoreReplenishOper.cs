using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class CtrlOEMOutStoreReplenishOper : UserControl
    {
        public CtrlOEMOutStoreReplenishOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false; 
            this.accItems = new JERPData.Material.OEMOutStoreItems();
            this.accNotes = new JERPData.Material.OEMOutStoreNotes();
            this.accStore = new JERPData.Material.OEMStore();
            this.accReplenishPlans = new JERPData.Material.OEMOutStoreReplenishPlans();
            this.accStoreReserve = new JERPData.Material.OEMStoreReserve();
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemExport.Click += new EventHandler(mItemExport_Click); 
            this.dgrdv .CellMouseClick +=new DataGridViewCellMouseEventHandler(dgrdv_CellMouseClick);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);        
        }


        private JERPData.Material.OEMOutStoreItems accItems;
        private JERPData.Material.OEMOutStoreNotes accNotes;
        private JERPData.Material.OEMOutStoreReplenishPlans accReplenishPlans;
        private DataTable dtblItems;
        private JERPData.Material.OEMStore accStore;
        private JERPData.Material.OEMStoreReserve accStoreReserve; 
        private decimal GetStoreQty(int CustomerID, int PrdID)
        {
            decimal rut = 0;
            this.accStore.GetParmOEMStoreInventoryQty (CustomerID , PrdID, ref rut);
            return rut;
        }
        void dgrdv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnQuantity.Name )
            {

                if (e.Button == MouseButtons.Left)
                {
                    object objQuantity = this.dgrdv[icol, irow].Value;
                    if (objQuantity == DBNull.Value)
                    {
                        object objReplenishQty = this.dgrdv [this.ColumnReplenishQty.Name,irow].Value;
                        object objInventory =this.dgrdv [this.ColumnInventoryQty.Name,irow].Value;
                        if ((objReplenishQty != DBNull.Value) && (objInventory != DBNull.Value))
                        {
                            this.dgrdv[icol, irow].Value = ((decimal)objReplenishQty > (decimal)objInventory) ? objInventory : objReplenishQty;
                        }
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    this.dgrdv[icol, irow].Value = DBNull.Value;
                }
            }
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
            this.dtblItems = this.accReplenishPlans .GetDataOEMOutStoreReplenishPlans ().Tables[0]; 
            this.dtblItems.Columns.Add("ReplenishQty", typeof(decimal));
            this.dtblItems.Columns.Add("InventoryQty", typeof(decimal));
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                drow["ReplenishQty"] = drow["Quantity"];
                drow["Quantity"] = DBNull.Value;
                drow["InventoryQty"] = this.GetStoreQty((int)drow["CompanyID"], (int)drow["PrdID"]);
            }
            this.dgrdv.DataSource = this.dtblItems;
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
            if (this.dtblItems.Select("Quantity is not null", "", DataViewRowState.CurrentRows).Length == 0)
            {
                return;
            }
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
            decimal Quantity,  ReplenishQty;
            int PrdID,CustomerID; 
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow["Quantity"] == DBNull.Value) continue;
                       
                PrdID = (int)drow["PrdID"];
                CustomerID = (int)drow["CompanyID"];
                ReplenishQty = (decimal)drow["ReplenishQty"];
                Quantity = (decimal)drow["Quantity"];
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
                if (ReplenishQty> Quantity)
                {
                    this.accReplenishPlans.SaveOEMOutStoreReplenishPlans (ref errormsg,
                        CustomerID ,
                        PrdID,
                        ReplenishQty  - Quantity);
                }
            }

        }

        void mItemExport_Click(object sender, EventArgs e)
        { 
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "客供库生产补料单");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}
