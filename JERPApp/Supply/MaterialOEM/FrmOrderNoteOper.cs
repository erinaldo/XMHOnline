using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.MaterialOEM
{
    public partial class FrmOrderNoteOper : Form
    {
        public FrmOrderNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Material.OEMOrderItems();
            this.accNotes = new JERPData.Material.OEMOrderNotes();
            this.accPrds = new JERPData.Product.Product();
            this.NoteEntity = new JERPBiz.Material.OEMOrderNoteEntity();
            this.printer = new JERPBiz.Material.OEMOrderNotePrintHelper();
            this.accRoadReserve = new JERPData.Material.OEMRoadStoreReserve();
            this.ctrlCompanyID.AffterSelected += new JERPApp.Define.General.CtrlCustomer.AffterSelectedDelegate(ctrlCompanyID_AffterSelected);
            this.dtblPrds = this.accPrds.GetDataProductForMaterial().Tables[0];
            this.dgrdv .CellEnter +=new DataGridViewCellEventHandler(dgrdv_CellEnter);
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
            this.btnAddItem.Click += new EventHandler(btnAddItem_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click); 
            this.btnSafeStore.Click += new EventHandler(btnSafeStore_Click);
            this.btnExport .Click +=new EventHandler(btnExport_Click);
            this.btnAddPrd.Click += new EventHandler(btnAddPrd_Click);
        }

        private JERPData.Material.OEMOrderNotes accNotes;
        private JERPData.Material.OEMOrderItems accItems;
        private JERPData.Material.OEMRoadStoreReserve accRoadReserve;
        private JERPData.Product.Product accPrds;
        private JERPBiz.Material.OEMOrderNoteEntity NoteEntity;
        private JERPBiz.Material.OEMOrderNotePrintHelper printer;
        private FrmOrderItemFromPlan frmFromPlan;
        private FrmOrderItemFromSafeStore frmFromStore;
        private JERPApp.Define.Material.FrmProduct frmPrd;
        private JERPApp.Define.Material.FrmProduct frmAddPrd;
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
     
        private long noteID = -1;
        private long NoteID
        {
            get
            {
                return this.noteID;
            }
            set
            {
                this.noteID = value;
                this.ctrlCompanyID.Enabled = (value==-1);
                this.btnDelete.Enabled = (value > -1);
                this.dtpDateNote.Enabled = (value== -1);
                
            }
        }
       

        void ctrlCompanyID_AffterSelected()
        {
            this.ctrlCompanyID.Enabled = false;
        }
        private void RoadReserveAdjust(int PrdID)
        {
            string errormsg=string.Empty ;
            this.accRoadReserve.UpdateOEMRoadStoreReserveForAdjustStore(ref errormsg,
                this.ctrlCompanyID.CompanyID,
                PrdID);
        }

        private void LoadItems()
        {
            this.dtblItems = this.accItems.GetDataOEMOrderItemsByNoteID(this.NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
            this.dtblItems.Columns["PrdID"].AllowDBNull = false;
            this.dtblItems.Columns["PrdID"].Unique = true;
            this.dtblItems.Columns["Quantity"].AllowDBNull = false; 
            
        }
        public void NewNote()
        {
            this.NoteID = -1;
            this.ctrlCompanyID.CompanyID = -1;
            this.ctrlCompanyID.Enabled = true;
            this.dtpDateNote.Value = DateTime.Now.Date;
            this.txtNoteCode.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
            this.LoadItems();
        }
        public void EditNote(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity.NoteCode ;
            this.ctrlCompanyID.CompanyID = this.NoteEntity.CompanyID;
            this.dtpDateNote.Value = this.NoteEntity.DateNote;
            this.rchMemo.Text = this.NoteEntity.Memo  ;
            this.LoadItems();
        }

        void btnNew_Click(object sender, EventArgs e)
        {
            this.NewNote();
        }

       
        

        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblItems .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["ItemID"] == DBNull.Value)
            {           
                return;
            }
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accItems .DeleteOEMOrderItems(ref ErrorMsg,
                    drow["ItemID"]);
                if (flag)
                {
                    this.RoadReserveAdjust((int)drow["PrdID"]);
                }
                else
                {
                    
                    MessageBox.Show(ErrorMsg );
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
     
        private bool SaveNote()
        {
            bool flag = false;
            string errormsg = string.Empty;
            if (this.NoteID == -1)
            {
                object objNoteID = DBNull.Value;
                object objNoteCode = DBNull.Value;
                flag = this.accNotes.InsertOEMOrderNotes(ref errormsg,
                    ref objNoteID,
                    ref objNoteCode ,
                    this.dtpDateNote.Value.Date,
                    this.ctrlCompanyID.CompanyID,
                    JERPBiz.Frame.UserBiz.PsnID,
                    this.rchMemo.Text);
                if (flag)
                {
                    this.NoteID = (long)objNoteID;
                    this.txtNoteCode.Text = objNoteCode.ToString();
                }
            }
            else
            {
                flag=this.accNotes .UpdateOEMOrderNotes (ref errormsg ,this.NoteID ,
                    JERPBiz.Frame.UserBiz.PsnID,
                    this.rchMemo.Text);              
            }
            if (!flag)
            {              
                MessageBox.Show(errormsg);
            }
            return flag;

        }
        void SaveItem()
        {
            foreach (DataRow drow in this.dtblItems.Rows )
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState ==DataRowState.Unchanged) continue;
                string ErrorMsg=string.Empty;
		        object  objItemID=drow["ItemID"];
                bool flag = false;
                if (objItemID == DBNull.Value)
                {
                    flag = this.accItems.InsertOEMOrderItems(ref ErrorMsg,
                         ref objItemID,
                         this.NoteID ,
                         drow["PrdID"],
                         drow["Quantity"],
                         drow["DateTarget"],
                         drow["Memo"]);
                    if (flag)
                    {
                        drow["ItemID"] = objItemID;
                        drow.AcceptChanges();
                    }
                }
                else
                {
                    flag=this.accItems.UpdateOEMOrderItems(ref ErrorMsg,
			            drow["ItemID"],
			            drow["PrdID"],
			            drow["Quantity"],
			            drow["DateTarget"],
                        drow["Memo"]);
		                if(flag)
		                {
                            //在途预留之调整
                            this.RoadReserveAdjust((int)drow["PrdID"]);
			                drow.AcceptChanges ();
		                }
                }
                if (!flag)
                {
                 
                    MessageBox.Show(ErrorMsg);
                }
            
            }
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.SaveNote())
            {
                this.SaveItem();
                if (this.affterSave != null) this.affterSave();
                MessageBox.Show("成功保存当前订单");
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
              DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
              if (rul == DialogResult.Yes)
              {
                  string errormsg=string.Empty ;
                  bool flag=this.accNotes.DeleteOEMOrderNotes(ref errormsg, this.NoteID);
                  if (!flag)
                  {
                      MessageBox.Show(errormsg, "出借啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      return;
                  }
                  if (this.affterSave != null) this.affterSave();
                  this.Close();
              }
        }
        void btnExport_Click(object sender, EventArgs e)
        {

            FrmMsg.Show("正在生成打印文档，请稍候......");
            this.printer.ExportToExcel(this.NoteID);
            FrmMsg.Hide();
        }

        void btnAddItem_Click(object sender, EventArgs e)
        {
            if (this.ctrlCompanyID.CompanyID > -1)
            {
                DataRow[] drowItems = this.dtblItems.Select("", "", DataViewRowState.CurrentRows);
                if (frmFromPlan == null)
                {
                    frmFromPlan = new FrmOrderItemFromPlan();
                    frmFromPlan.AffterSave += new FrmOrderItemFromPlan.AffterSaveDelegate(frmFromPlan_AffterSave);
                    new FrmStyle(frmFromPlan).SetPopFrmStyle(this);
                }
                frmFromPlan.OrderFromPlan(this.ctrlCompanyID .CompanyID,drowItems );
                frmFromPlan.ShowDialog();
            }
        }

        void frmFromPlan_AffterSave(DataRow drowPlan)
        {

            DataRow[] drows = this.dtblItems.Select("PrdID=" + drowPlan["PrdID"].ToString());
            if (drows.Length > 0)return ;
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["PrdID"] = drowPlan["PrdID"];
            drowNew["PrdCode"] = drowPlan["PrdCode"];
            drowNew["PrdName"] = drowPlan["PrdName"];
            drowNew["PrdSpec"] = drowPlan["PrdSpec"];
            drowNew["Model"] = drowPlan["Model"];
            drowNew["Manufacturer"] = drowPlan["Manufacturer"];
            drowNew["UnitName"] = drowPlan["UnitName"];
            drowNew["Quantity"] = drowPlan["NonFinishedQty"]; 
            this.dtblItems.Rows.Add(drowNew);
           
        }
        void btnSafeStore_Click(object sender, EventArgs e)
        {
            if (frmFromStore == null)
            {
                this.frmFromStore = new FrmOrderItemFromSafeStore();
                new FrmStyle(this.frmFromStore).SetPopFrmStyle(this);
                this.frmFromStore.AffterSave += new FrmOrderItemFromSafeStore.AffterSaveDelegate(frmFromStore_AffterSave);
            }
            DataTable dtblNonOrders = new DataTable();
            dtblNonOrders.Columns.Add("PrdID", typeof(int));
            dtblNonOrders.Columns.Add("Quantity", typeof(decimal));
            DataRow[] drowItems = this.dtblItems.Select("ItemID is null", "", DataViewRowState.CurrentRows);
            foreach (DataRow drowItem in drowItems)
            {
                int PrdID = (int)drowItem["PrdID"];
                decimal Quantity = (decimal)drowItem["Quantity"];
                DataRow[] drowNonPO = dtblNonOrders.Select("PrdID=" + PrdID.ToString());
                if (drowNonPO.Length > 0)
                {
                    drowNonPO[0]["Quantity"] = (decimal)drowNonPO[0]["Quantity"] + Quantity;
                }
                else
                {
                    dtblNonOrders.Rows.Add(PrdID, Quantity);
                }

            }
            frmFromStore.ItemFromStore(this.ctrlCompanyID.CompanyID ,dtblNonOrders.Select("Quantity>0"));
            frmFromStore.ShowDialog();
        }

        void frmFromStore_AffterSave(DataRow drowStore)
        {
            int PrdID = (int)drowStore["PrdID"];
            decimal Quantity = (decimal)drowStore["RequireQty"];
            DataRow[] drowItems = this.dtblItems.Select("PrdID=" + PrdID.ToString());
            DataRow drowItem;
            if (drowItems.Length > 0)
            {
                drowItem = drowItems[0];
                drowItem["Quantity"] = (decimal)drowItem["Quantity"] + Quantity;
            }
            else
            {
                drowItem = this.dtblItems.NewRow();
                drowItem["PrdID"] = PrdID;
                drowItem["PrdCode"] = drowStore["PrdCode"];
                drowItem["PrdName"] = drowStore["PrdName"];
                drowItem["PrdSpec"] = drowStore["PrdSpec"];
                drowItem["Model"] = drowStore["Model"];
                drowItem["Manufacturer"] = drowStore["Manufacturer"];
                drowItem["UnitName"] = drowStore["UnitName"];
                drowItem["Quantity"] = Quantity;
                drowItem["DateTarget"] = drowStore["DateTarget"];  
                this.dtblItems.Rows.Add(drowItem);
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
                    this.frmGridPrd.AddGridColumn("PrdCode", "物料编号", 80);
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
            int PrdID = (int)drow["PrdID"];
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            grow.Cells[this.ColumnPrdID.Name].Value = PrdID;
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnManufacturer.Name].Value = drow["Manufacturer"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"];

        }
        void dgrdv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (irow == 0) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnDateTarget.Name)
            {
                if (this.dgrdv[icol, irow].Value == DBNull.Value)
                {
                    this.dgrdv[icol, irow].Value = this.dgrdv[icol, irow - 1].Value;
                }
            }
        }
        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if ((this.dgrdv.Columns[icol].DataPropertyName == "PrdCode")
               || (this.dgrdv.Columns[icol].DataPropertyName == "PrdName")
               || (this.dgrdv.Columns[icol].DataPropertyName == "PrdSpec")
               || (this.dgrdv.Columns[icol].DataPropertyName == "Model")
               || (this.dgrdv.Columns[icol].DataPropertyName == "Manufacturer"))
            {
 
                
                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (this.frmPrd == null)
                {
                    this.frmPrd = new JERPApp.Define.Material.FrmProduct();
                    new FrmStyle(this.frmPrd).SetPopFrmStyle(this);
                    this.frmPrd.AffterSelected += new JERPApp.Define.Material.FrmProduct.AffterSelectedDelegate(frmPrd_AffterSelected);
                }
                this.frmPrd.ShowDialog();
            }
          
           
        }
        void frmPrd_AffterSelected(DataRow drow)
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            int PrdID = (int)drow["PrdID"];
            grow.Cells[this.ColumnPrdID.Name].Value = PrdID;
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnManufacturer.Name].Value = drow["Manufacturer"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"]; 
            this.frmPrd.Close();
        }
 void btnAddPrd_Click(object sender, EventArgs e)
        {
            if (frmAddPrd == null)
            {
                this.frmAddPrd = new JERPApp.Define.Material.FrmProduct();
                new FrmStyle(this.frmAddPrd).SetPopFrmStyle(this);
                this.frmAddPrd.AffterSelected += new JERPApp.Define.Material.FrmProduct.AffterSelectedDelegate(frmAddPrd_AffterSelected);
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
            drowNew["Quantity"] = 0;
            this.dtblItems.Rows.Add(drowNew);
        }
    }
}