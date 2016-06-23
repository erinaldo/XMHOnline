using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.OtherRes
{
    public partial class FrmOutStoreNoteOper : Form
    {
        public FrmOutStoreNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.OtherRes.OutStoreItems();
            this.accNotes = new JERPData.OtherRes.OutStoreNotes();
            this.accStore = new JERPData.OtherRes.Store();
            this.accBranchSotre = new JERPData.OtherRes.BranchStore();
            this.accPrds = new JERPData.OtherRes.Product();
            this.SetColumnSrc();
            this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery); 
            this.btnAddPrd.Click += new EventHandler(btnAddPrd_Click);
        }

      
        private JERPData.OtherRes.OutStoreNotes accNotes;
        private JERPData.OtherRes.OutStoreItems accItems;
        private JERPData.OtherRes.Product accPrds;
        private JERPData.OtherRes.BranchStore accBranchSotre;
        private JERPApp.Define.OtherRes.FrmProduct frmPrd;
        private JERPApp.Define.OtherRes.FrmProduct frmAddPrd;
        private JCommon.FrmGridFind frmGridPrd;
        private DataTable dtblItems, dtblPrds, dtblBranchStores;
        private JERPData.OtherRes.Store accStore;
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

            this.dtblPrds = this.accPrds.GetDataProduct ().Tables[0]; 

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

        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if ((this.dgrdv.Columns[icol].DataPropertyName == "PrdName")
               || (this.dgrdv.Columns[icol].DataPropertyName == "PrdSpec")
       )
            {

                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (frmPrd == null)
                {
                    this.frmPrd = new JERPApp.Define.OtherRes.FrmProduct();
                    new FrmStyle(this.frmPrd).SetPopFrmStyle(this);
                    this.frmPrd.AffterSelected += new JERPApp.Define.OtherRes .FrmProduct.AffterSelectedDelegate(frmPrd_AffterSelected);
                }
                this.frmPrd.ShowDialog();
            }
        }

        void frmPrd_AffterSelected(DataRow drow)
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            int PrdID = (int)drow["PrdID"];
            grow.Cells[this.ColumnPrdID.Name].Value = drow["PrdID"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"]; 
            object objBranchStoreID = this.GetDefaultBranchStoreID(PrdID);
            this.dgrdv.CurrentRow.Cells[this.ColumnBranchStoreID.Name].Value = objBranchStoreID;
            if (objBranchStoreID != DBNull.Value)
            {
                grow.Cells[this.ColumnInventoryQty.Name].Value = this.GetStoreQty(PrdID, (int)objBranchStoreID);

            }
            frmPrd.Close();

        }
        void btnAddPrd_Click(object sender, EventArgs e)
        {
            if (frmAddPrd == null)
            {
                this.frmAddPrd = new JERPApp.Define.OtherRes.FrmProduct();
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
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"]; 
            drowNew["Quantity"] = 0;
            drowNew["BranchStoreID"] = this.GetDefaultBranchStoreID(PrdID);
            if (drowNew["BranchStoreID"] != DBNull.Value)
            {
                drowNew["InventoryQty"] = this.GetStoreQty(PrdID, (int)drowNew["BranchStoreID"]);
            }
            this.dtblItems.Rows.Add(drowNew);

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
                    this.frmGridPrd.AddGridColumn("PrdName", "产品名称", 100);
                    this.frmGridPrd.AddGridColumn("PrdSpec", "型号及规格", 120);   
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
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"];
            object objBranchStoreID = this.GetDefaultBranchStoreID(PrdID);
            grow.Cells[this.ColumnBranchStoreID.Name].Value = objBranchStoreID;
            if (objBranchStoreID != DBNull.Value)
            {

                grow.Cells[this.ColumnInventoryQty.Name].Value = this.GetStoreQty(PrdID, (int)objBranchStoreID);
            }

        }
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].DataPropertyName == "PrdID")
            {
                object objPrdID = this.dgrdv[icol, irow].Value;
                if ((objPrdID != null) && (objPrdID != DBNull.Value))
                {
                    this.dgrdv[this.ColumnBranchStoreID.Name, irow].Value =
                        this.GetDefaultBranchStoreID((int)objPrdID);
                }
            }
            if ((this.dgrdv.Columns[icol].DataPropertyName == "PrdID")
                || (this.dgrdv.Columns[icol].Name == this.ColumnBranchStoreID.Name))
            {
                object objPrdID = this.dgrdv[this.ColumnPrdID .Name, irow].Value;
                object objBranchStoreID = this.dgrdv[this.ColumnBranchStoreID.Name, irow].Value;
                if ((objPrdID != DBNull.Value)
                    && (objPrdID != null)
                    && (objBranchStoreID != DBNull.Value)
                    && (objBranchStoreID != null))
                {
                    this.dgrdv[this.ColumnInventoryQty.Name, irow].Value = this.GetStoreQty ((int)objPrdID, (int)objBranchStoreID);
                }
            }
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
        public void NewNote()
        {
          
            this.dtpDateNote.Value = DateTime.Now.Date;
            this.txtNoteCode.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
            this.dtblItems = this.accItems.GetDataOutStoreItemsByNoteID(-1).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
            this.dtblItems.Columns["PrdID"].AllowDBNull = false; 
            this.dtblItems.Columns["BranchStoreID"].AllowDBNull = false; 
            this.dtblItems.Columns.Add("InventoryQty", typeof(decimal));
        }

        bool ValidateData()
        {

            DataRow[] drows = this.dtblItems.Select("Quantity is not null", "", DataViewRowState.CurrentRows);
            if (drows.Length == 0)
            {
                MessageBox.Show("未存在任何明细项");
                return false;
            }
            drows = this.dtblItems.Select("Quantity>InventoryQty", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("对不起，存在库存不足项");
                return false;
            }
            return true;
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
            flag = this.accNotes.InsertOutStoreNotes(ref errormsg, ref objNoteID, ref objNoteCode,
                this.dtpDateNote.Value.Date,
                this.ctrlDeptID .DeptID ,                
                JERPBiz.Frame.UserBiz.PsnID,
                this.rchMemo.Text);
            if (!flag)
            {
                MessageBox .Show (errormsg );
                return;
            }
            NoteID = (long)objNoteID;
            NoteCode = objNoteCode.ToString();
            this.txtNoteCode.Text = NoteCode;
            object objItemID = DBNull.Value;
            foreach (DataRow drow in this.dtblItems.Rows )
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                int PrdID = (int)drow["PrdID"];
                int BranchStoreID = (int)drow["BranchStoreID"];
                decimal CostPrice = this.GetCostPrice(PrdID,BranchStoreID );
                flag = this.accItems.InsertOutStoreItems(ref errormsg,
                   ref objItemID,
                   NoteID,
                   PrdID ,
                   drow["Quantity"],
                   BranchStoreID ,
                   CostPrice,
                   drow["Memo"]);
              
                //领用
                this.accStore.InsertStoreForOutStore(ref errormsg,
                         JERPBiz.Finance.NoteNameParm.OtherResOutStoreNoteNameID,
                          NoteID,
                          NoteCode,
                          PrdID ,
                          BranchStoreID ,
                          drow["Quantity"],
                          CostPrice);
                 
             
                                   
            }              
            MessageBox.Show("成功保存并入账当前单据");
            if (this.affterSave != null) this.affterSave();
            this.NewNote();

            
        }

 

    }
}