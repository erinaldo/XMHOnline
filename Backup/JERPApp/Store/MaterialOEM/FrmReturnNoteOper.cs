using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.MaterialOEM
{
    public partial class FrmReturnNoteOper : Form
    {
        public FrmReturnNoteOper()
        {
            InitializeComponent();
            this.accNotes = new JERPData.Material .OEMReturnNotes();
            this.accItems = new JERPData.Material.OEMReturnItems();
            this.accPrds = new JERPData.Product.Product ();
            this.accStore = new JERPData.Material.OEMStore();
            this.accStoreReserve = new JERPData.Material.OEMStoreReserve();
            this.dgrdvItem.AutoGenerateColumns = false;
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.ctrlCompanyID .AffterSelected +=ctrlCompanyID_AffterSelected; 
            this.dgrdvItem.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdvItem_DataBindingComplete);
            this.dgrdvItem.CellValueChanged += new DataGridViewCellEventHandler(dgrdvItem_CellValueChanged);
            this.dgrdvItem.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdvItem_CellContextMenuStripNeeded);
            this.dgrdvItem.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdvItem_CellQuery);
            this.dtblPrds = this.accPrds.GetDataProductForMaterial().Tables[0];
            this.btnAddPrd.Click += new EventHandler(btnAddPrd_Click);
        }

       
        private JERPData.Material.OEMReturnNotes accNotes;
        private JERPData.Material.OEMReturnItems accItems;
        private JERPData.Product.Product  accPrds;
        private JERPData.Material.OEMStore accStore;
        private JERPData.Material.OEMStoreReserve accStoreReserve;
        private JERPApp.Define.Material.FrmProduct frmPrd;
        private JERPApp.Define.Material.FrmProduct frmAddPrd;
        private JCommon.FrmGridFind frmGridPrd;
        private DataTable dtblItems,dtblPrds;
        private long noteID;
        private long NoteID
        {
            get
            {
                 return this.noteID;
            } 
            set
            {
                this.noteID = value;               
                this.btnSave.Enabled = (value > -1);
                
            }
        } 
        void ctrlCompanyID_AffterSelected()
        {
            foreach (DataGridViewRow grow in this.dgrdvItem .Rows)
            {
                if (grow.IsNewRow) continue;
                object objPrdID = grow.Cells[this.ColumnPrdCode.Name].Value;
                if (objPrdID == DBNull.Value) continue;
                grow.Cells[this.ColumnInventoryQty.Name].Value = this.GetStoreQty ((int)objPrdID);

            }
        }
    
        public void NewNote()
        {
            this.ctrlCompanyID.CompanyID = -1;
            this.ctrlCompanyID.Enabled = true;
            this.tpkDateNote.Value = DateTime.Now.Date;
            this.txtNoteCode.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
            this.dtblItems = this.accItems.GetDataOEMReturnItemsByNoteID(-1).Tables[0];
            this.dtblItems.Columns["PrdID"].AllowDBNull = false;
            this.dtblItems.Columns["Quantity"].AllowDBNull = false;
            this.dtblItems.Columns.Add("InventoryQty", typeof(decimal));
            this.dgrdvItem.DataSource = this.dtblItems;
        }
        //单据保存
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
        private decimal GetStoreQty(int PrdID)
        {
            decimal rut = 0;
            this.accStore.GetParmOEMStoreInventoryQty(this.ctrlCompanyID.CompanyID, PrdID, ref rut);
            return rut;
        }

        void dgrdvItem_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if ((this.dgrdvItem.Columns[icol].DataPropertyName == "PrdCode")
                 || (this.dgrdvItem.Columns[icol].DataPropertyName == "PrdName")
                 || (this.dgrdvItem.Columns[icol].DataPropertyName == "PrdSpec")
                 || (this.dgrdvItem.Columns[icol].DataPropertyName == "Model")
                 || (this.dgrdvItem.Columns[icol].DataPropertyName == "Manufacturer"))
            {

                this.dgrdvItem.CurrentCell = this.dgrdvItem[icol, irow];
                if (frmPrd == null)
                {
                    this.frmPrd = new JERPApp.Define.Material.FrmProduct();
                    new FrmStyle(this.frmPrd).SetPopFrmStyle(this);
                    this.frmPrd.AffterSelected += frmPrd_AffterSelected;
                }
                this.frmPrd.ShowDialog();
            }
        }

        void frmPrd_AffterSelected(DataRow drow)
        {
            DataGridViewRow grow = this.dgrdvItem .CurrentRow;
            int PrdID = (int)drow["PrdID"];
            grow.Cells[this.ColumnPrdID.Name].Value = PrdID;
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnManufacturer.Name].Value = drow["Manufacturer"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"];  
            grow.Cells[this.ColumnInventoryQty.Name].Value = this.GetStoreQty((int)drow["PrdID"]);
            frmPrd.Close();
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
            drowNew["Quantity"] = 0;
            drowNew["InventoryQty"] = this.GetStoreQty(PrdID);
            this.dtblItems.Rows.Add(drowNew);

        }
        void dgrdvItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvItem.Columns[icol].DataPropertyName == "PrdID")
            {
                object objPrdID = this.dgrdvItem[icol , irow].Value;            
                if ((objPrdID != DBNull.Value)
                    && (objPrdID != null))
                {
                    this.dgrdvItem[this.ColumnInventoryQty.Name, irow].Value = this.GetStoreQty((int)objPrdID);
                }
            }
        }
        void dgrdvItem_CellQuery(DataGridViewCellEventArgs e)
        { 
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvItem.Columns[icol].Name == this.ColumnAssistantCode.Name)
            {
               
                if (this.frmGridPrd == null)
                {
                    this.frmGridPrd = new JCommon.FrmGridFind();
                    this.frmGridPrd.AddGridColumn("PrdCode", "物料编号", 100);
                    this.frmGridPrd.AddGridColumn("PrdName", "物料名称", 100);
                    this.frmGridPrd.AddGridColumn("PrdSpec", "物料规格", 100);
                    this.frmGridPrd.AddGridColumn("Model", "型号", 66);
                    this.frmGridPrd.AddGridColumn("Manufacturer", "品牌", 66);
                    this.frmGridPrd.AddGridColumn("AssistantCode", "助记码", 66);
                    this.frmGridPrd.AffterSelected += frmGridPrd_AffterSelected;

                }
                this.frmGridPrd.Query(this.dtblPrds, "AssistantCode", this.dgrdvItem.CurrentCell);
                

            }
        }
        void frmGridPrd_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"];
            DataGridViewRow grow = this.dgrdvItem .CurrentRow;
            grow.Cells[this.ColumnPrdID.Name].Value = PrdID;
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnManufacturer.Name].Value = drow["Manufacturer"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"];

        }
        void dgrdvItem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdvItem.Rows)
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
        private bool ValidateData()
        {
            if (this.ctrlCompanyID.CompanyID == -1)
            {
                MessageBox.Show("对不起,未选择客户");
                return false ;
            }       
            DataRow[] drows = this.dtblItems.Select("", "", DataViewRowState.CurrentRows);
            if (drows.Length == 0)
            {
                MessageBox.Show("没有任何记录,不能保存");
                return false;
            }
            drows = this.dtblItems.Select("PrdID is null or Quantity is null", "", DataViewRowState.CurrentRows);
            if (drows.Length >0)
            {
                MessageBox.Show("存在未完成项");
                return false;
            }
            drows = this.dtblItems.Select("Quantity>InventoryQty", "", DataViewRowState.CurrentRows);
            if (drows.Length >0)
            {
                MessageBox.Show("对不起,当前库存存在不足,不能出货");
                return false;           
            }
            return true;
        }
      
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            DialogResult rul = MessageBox.Show("将进行保存入账, 一经确认不能变更！", "保存确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                bool flag = false;
                string errormsg = string.Empty;
                object objNoteID = DBNull.Value;
                object objNoteCode = DBNull.Value;
                flag = this.accNotes.InsertOEMReturnNotes (ref errormsg, ref objNoteID,
                    ref objNoteCode ,
                    this.tpkDateNote .Value.Date,
                    this.ctrlCompanyID.CompanyID,
                    JERPBiz.Frame.UserBiz.PsnID,
                    this.rchMemo.Text);
                if (!flag)
                {
                    MessageBox.Show(errormsg);
                    return;
                }
                long NoteID = (long)objNoteID;
                string NoteCode = objNoteCode.ToString();
                this.txtNoteCode.Text = NoteCode;
                foreach (DataRow drow in this.dtblItems.Rows )
                {
                    if (drow.RowState == DataRowState.Deleted) continue;
                    object objItemID = DBNull.Value;
                    flag = this.accItems.InsertOEMReturnItems (ref errormsg,
                        NoteID,
                        drow["PrdID"],
                        drow["Quantity"],
                        drow["Memo"]);
                    if (flag)
                    {
                          //出库
                        this.accStore.InsertOEMStoreForOutStore(ref errormsg,
                            Report.Bill.FrmBizBill.ReturnNoteID,
                            Report.Bill.FrmBizBill.ReturnNoteNoteName,
                            NoteID,
                            NoteCode,
                            drow["PrdID"],
                            this.ctrlCompanyID.CompanyID,
                            drow["Quantity"]);      
                        //预留减
                        this.accStoreReserve.SaveOEMStoreReserveSubReserve (ref errormsg,
                            this.ctrlCompanyID.CompanyID,
                            drow["PrdID"],
                            drow["Quantity"]);
                    }
                }
               
                MessageBox.Show("成功保存并入账当前单据");
                if (this.affterSave != null) this.affterSave();
                this.NewNote();
            }

        }       
  
    
    }
}