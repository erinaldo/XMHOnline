using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.OtherRes
{
    public partial class FrmBuyReplenishNoteOper : Form
    {
        public FrmBuyReplenishNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.OtherRes .BuyReplenishItems();
            this.accNotes = new JERPData.OtherRes.BuyReplenishNotes();
            this.accStore = new JERPData.OtherRes.Store();
            this.accBranchSotre = new JERPData.OtherRes.BranchStore();
            this.accReplenishPlans = new JERPData.OtherRes.BuyReplenishPlans();
            this.accPrds = new JERPData.OtherRes.Product();
            this.btnAddPlan.Click += new EventHandler(btnAddPlan_Click);
            this.dgrdv .CellContextMenuStripNeeded +=new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.SetColumnSrc();
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
            this.btnAddPrd .Click +=new EventHandler(btnAddPrd_Click);
        }

        private JERPData.OtherRes.BuyReplenishNotes accNotes;
        private JERPData.OtherRes.BuyReplenishItems accItems;
        private JERPData.OtherRes.BuyReplenishPlans accReplenishPlans;
        private JERPData.OtherRes.Store accStore;
        private JERPData.OtherRes.Product accPrds;
        private JERPData.OtherRes.BranchStore accBranchSotre;
        private JERPApp.Define.OtherRes.FrmProduct frmPrd;
        private JERPApp.Define.OtherRes.FrmProduct frmAddPrd;
        private JCommon.FrmGridFind frmGridPrd;
        private FrmBuyReplenishPlanAppend frmAppend;
        private DataTable dtblItems, dtblPrds, dtblBranchStores;
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
        private decimal GetCostPrice(int PrdID)
        {
            decimal rut = 0;
            this.accPrds.GetParmProductCostPrice(PrdID, ref rut);
            return rut;
        }
        public void NewNote()
        {
          
            this.tpkDateNote .Value = DateTime.Now.Date;            
            this.txtNoteCode.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
            this.dtblItems = this.accItems.GetDataBuyReplenishItemsByNoteID(-1).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
            this.dtblItems.Columns["PrdID"].AllowDBNull = false; 
            this.dtblItems.Columns["BranchStoreID"].AllowDBNull = false;
            this.dtblItems.Columns["Quantity"].AllowDBNull = false;
            this.ctrlSupplierID.Enabled = true;
        }
        void btnAddPlan_Click(object sender, EventArgs e)
        {
            if (frmAppend == null)
            {
                frmAppend = new FrmBuyReplenishPlanAppend();
                new FrmStyle(frmAppend).SetPopFrmStyle(this);
                frmAppend.AffterAppend += new FrmBuyReplenishPlanAppend.AffterAppendDelegate(frmAppend_AffterAppend);
            }
            DataRow[] drows = this.dtblItems.Select("", "", DataViewRowState.CurrentRows);
            frmAppend.AppendOper(this.ctrlSupplierID.CompanyID, drows);
            frmAppend.ShowDialog();
        }
        void frmAppend_AffterAppend(DataRow drowPlan)
        {
            DataRow[] drows = this.dtblItems.Select("PrdID=" + drowPlan["PrdID"].ToString(), "", DataViewRowState.CurrentRows);
            if (drows.Length > 0) return;
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["PrdID"] = drowPlan["PrdID"];
            drowNew["PrdName"] = drowPlan["PrdName"];
            drowNew["PrdSpec"] = drowPlan["PrdSpec"];
            drowNew["UnitName"] = drowPlan["UnitName"];
            drowNew["BranchStoreID"] = this.GetDefaultBranchStoreID((int)drowPlan["PrdID"]);
            drowNew["Quantity"] = drowPlan["NonFinishedQty"];
            this.dtblItems.Rows.Add(drowNew);
            this.ctrlSupplierID.Enabled = false;
        }
        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
             if ((this.dgrdv.Columns[icol].DataPropertyName == "PrdName")
                ||(this.dgrdv.Columns[icol].DataPropertyName == "PrdSpec")
		)
             {
                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (frmPrd == null)
                {
                    this.frmPrd = new JERPApp.Define.OtherRes .FrmProduct();
                    new FrmStyle(this.frmPrd).SetPopFrmStyle(this);
                    this.frmPrd.AffterSelected += new JERPApp.Define.OtherRes.FrmProduct.AffterSelectedDelegate(frmPrd_AffterSelected);
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
            grow.Cells[this.ColumnBranchStoreID.Name].Value = this.GetDefaultBranchStoreID(PrdID);
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
            drowNew["UnitName"] = drow["UnitName"];
            drowNew["Quantity"] = 0;
            drowNew["BranchStoreID"] = this.GetDefaultBranchStoreID(PrdID);
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
            grow.Cells[this.ColumnBranchStoreID.Name].Value =
                      this.GetDefaultBranchStoreID(PrdID);
        }
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int icol = e.ColumnIndex; ;
            int irow = e.RowIndex;
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
            
        }

        bool ValidateData()
        {
            bool flag = true;
            DataRow[] drows = this.dtblItems.Select("", "", DataViewRowState.CurrentRows);
            if (drows.Length == 0)
            {
                MessageBox.Show("未存在任何明细项");
                return false;
            }
            return flag;
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
            flag = this.accNotes.InsertBuyReplenishNotes(ref errormsg, ref objNoteID,
                this.txtNoteCode.Text ,
                this.tpkDateNote .Value.Date,
                this.ctrlSupplierID .CompanyID ,
                this.ctrlQCPsnID.PsnID ,
                JERPBiz.Frame.UserBiz.PsnID,
                this.rchMemo.Text);
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }         
            NoteID = (long)objNoteID;
            object objItemID = DBNull.Value;
            foreach (DataRow drow in this.dtblItems.Rows )
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                int PrdID = (int)drow["PrdID"];
                int BranchStoreID = (int)drow["BranchStoreID"];
                decimal CostPrice = this.GetCostPrice(PrdID);
                decimal Quantity=(decimal)drow["Quantity"];
                flag = this.accItems.InsertBuyReplenishItems(ref errormsg,
                   ref objItemID,
                   NoteID,
                   PrdID ,
                   Quantity ,
                   BranchStoreID ,
                   CostPrice);
                //入库
                this.accStore.InsertStoreForIntoStore (ref errormsg,
                         JERPBiz.Finance.NoteNameParm.OtherResBuyReplenishNoteNameID,
                          NoteID,
                          this.txtNoteCode .Text ,
                          PrdID,
                          BranchStoreID ,
                          Quantity,
                          CostPrice);
                this.accReplenishPlans.UpdateBuyReplenishPlansForAppFinishedQty(
                    ref errormsg,
                    this.ctrlSupplierID.CompanyID,
                    PrdID,
                    Quantity);
              
               
            }
            MessageBox.Show("成功保存并入账当前单据");
            if (this.affterSave != null) this.affterSave();
            this.NewNote();
               
          
        }

 

    }
}