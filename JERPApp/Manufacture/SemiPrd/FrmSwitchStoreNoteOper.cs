using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.SemiPrd
{
    public partial class FrmSwitchStoreNoteOper : Form
    {
        public FrmSwitchStoreNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.SemiPrd .SwitchStoreItems();
            this.accNotes = new JERPData.SemiPrd.SwitchStoreNotes();
            this.accStore = new JERPData.SemiPrd.Store();
            this.accManufProcess = new JERPData.Manufacture.ManufProcess();
            this.accPrds = new JERPData.Product.Product();
            this.accWorkingSheets = new JERPData.Manufacture.WorkingSheets();
            this.SetColumnSrc();
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.dgrdv .CellContextMenuStripNeeded +=new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }

        private JERPData.SemiPrd.SwitchStoreNotes accNotes;
        private JERPData.SemiPrd.SwitchStoreItems accItems;
        private JERPData.SemiPrd.Store accStore;
        private JERPData.Product.Product accPrds;
        private JERPApp.Define.Product.FrmManufPrd  frmPrd;
        private JERPData.Manufacture.WorkingSheets accWorkingSheets;
        private JERPData.Manufacture.ManufProcess  accManufProcess;
        private DataTable dtblItems, dtblPrds, dtblWorkingSheets;
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

            this.dtblWorkingSheets = this.accWorkingSheets.GetDataWorkingSheetsLastRecord  (500).Tables[0];
            if (this.dtblWorkingSheets.Rows.Count > 0)
            { 
                DataRow drowNew = this.dtblWorkingSheets.NewRow();
                drowNew["WorkingSheetID"] = DBNull.Value;
                drowNew["WorkingSheetCode"] = " ";
                this.dtblWorkingSheets.Rows.InsertAt(drowNew, 0);
            }          
            this.ColumnWorkingSheetCode.DataSource = this.dtblWorkingSheets;
            this.ColumnWorkingSheetCode.ValueMember = "WorkingSheetID";
            this.ColumnWorkingSheetCode.DisplayMember = "WorkingSheetCode";

            this.dtblPrds = this.accPrds.GetDataProductForManufPrd ().Tables[0];
            this.ColumnPrdCode.DataSource = this.dtblPrds;
            this.ColumnPrdCode.ValueMember = "PrdID";
            this.ColumnPrdCode.DisplayMember = "PrdCode";

            this.ColumnPrdName.DataSource = this.dtblPrds;
            this.ColumnPrdName.ValueMember = "PrdID";
            this.ColumnPrdName.DisplayMember = "PrdName";

            this.ColumnPrdSpec.DataSource = this.dtblPrds;
            this.ColumnPrdSpec.ValueMember = "PrdID";
            this.ColumnPrdSpec.DisplayMember = "PrdSpec";

            this.ColumnModel.DataSource = this.dtblPrds;
            this.ColumnModel.ValueMember = "PrdID";
            this.ColumnModel.DisplayMember = "Model";

            this.ColumnUnitName.DataSource = this.dtblPrds;
            this.ColumnUnitName.ValueMember = "PrdID";
            this.ColumnUnitName.DisplayMember = "UnitName";

            this.ColumnFromManufProcessID.ValueMember = "ManufProcessID";
            this.ColumnFromManufProcessID.DisplayMember = "PrdStatus";


            this.ColumnToManufProcessID.ValueMember = "ManufProcessID";
            this.ColumnToManufProcessID.DisplayMember = "PrdStatus";
        }
     
   
       
        public void NewNote()
        {
          
            this.dtpDateNote.Value = DateTime.Now.Date;  
            this.rchMemo.Text = string.Empty;
            this.dtblItems = this.accItems.GetDataSwitchStoreItemsByNoteID(-1).Tables[0];
            this.dtblItems.Columns.Add("InventoryQty", typeof(decimal));
            this.dgrdv.DataSource = this.dtblItems;
          
        }
        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].DataPropertyName == "PrdID")
            {
                if (this.dgrdv[icol, irow].ReadOnly == true) return;
                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (frmPrd == null)
                {
                    this.frmPrd = new JERPApp.Define.Product.FrmManufPrd();
                    new FrmStyle(this.frmPrd).SetPopFrmStyle(this);
                    this.frmPrd.AffterSelected += frmPrd_AffterSelected;
                }
                this.frmPrd.ShowDialog();
            }
        }
        void frmPrd_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"];
            this.dgrdv.CurrentCell.Value = PrdID;
            this.frmPrd.Close();
        }


        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int icol = e.ColumnIndex; ;
            int irow = e.RowIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].DataPropertyName == "WorkingSheetID")
            {
                object objWorkingSheetID = this.dgrdv[icol, irow].Value;
                if((objWorkingSheetID != null)&& (objWorkingSheetID != DBNull.Value))
                {
                    DataRow[] drows = this.dtblWorkingSheets.Select("WorkingSheetID=" + objWorkingSheetID.ToString());
                    if (drows.Length == 0) return;
                    foreach (DataGridViewColumn col in this.dgrdv.Columns)
                    {
                        if (col.DataPropertyName == "PrdID")
                        {
                            this.dgrdv[col.Name, irow].Value = drows[0]["PrdID"]; 
                        }
                    }

                }
            }
            if (this.dgrdv.Columns[icol].DataPropertyName == "PrdID")
            {
                object objPrdID = this.dgrdv[icol, irow].Value;
                if ((objPrdID != null) && (objPrdID != DBNull.Value))
                {
                    DataTable dtblFromProcess = this.accManufProcess.GetDataManufProcessByPrdID((int)objPrdID).Tables[0];
                    DataTable dtblToProcess = dtblFromProcess.Copy();
                    DataGridViewComboBoxCell cmb = (DataGridViewComboBoxCell)this.dgrdv[this.ColumnFromManufProcessID.Name, irow];
                    cmb.Value = DBNull.Value;
                    cmb.DataSource = dtblFromProcess;
                    if (dtblFromProcess.Rows.Count > 0)
                    {
                        cmb.Value = dtblFromProcess.Rows[0]["ManufProcessID"];
                    }
                    cmb = (DataGridViewComboBoxCell)this.dgrdv[this.ColumnToManufProcessID.Name, irow];
                    cmb.Value = DBNull.Value;
                    cmb.DataSource = dtblToProcess;
                    if (dtblToProcess.Rows.Count > 0)
                    {
                        cmb.Value = dtblToProcess.Rows[0]["ManufProcessID"];
                    }
                }
            }
            if (this.dgrdv.Columns[icol].DataPropertyName == "FromManufProcessID")
            {
                object objManufProcessID = this.dgrdv[icol, irow].Value;
                if ((objManufProcessID != null) && (objManufProcessID != DBNull.Value))
                {
                    this.dgrdv[this.ColumnInventoryQty.Name, irow].Value = this.GetInventoryQty((long)objManufProcessID);
                }
            }

        }
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                bool flag = (grow.Cells[this.ColumnWorkingSheetCode.Name].Value != DBNull.Value);
                foreach (DataGridViewColumn col in this.dgrdv.Columns)
                {
                    if (col.DataPropertyName == "PrdID")
                    {
                        grow.Cells[col.Name].ReadOnly = flag;
                    }
                } 
                if ((grow.Cells[this.ColumnFromManufProcessID.Name].Value == DBNull.Value)
                    ||(grow.Cells[this.ColumnToManufProcessID.Name].Value == DBNull.Value))
                {
                    grow.ErrorText = "工序不能为空";
                    continue;
                }
                if (grow.Cells[this.ColumnFromManufProcessID.Name].Value.ToString() == grow.Cells[this.ColumnToManufProcessID.Name].Value.ToString())
                {
                    grow.ErrorText = "转出转入工序不能相同";
                    continue;
                }
                if (grow.Cells[this.ColumnQuantity.Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "数量不能为空";
                    continue;
                } 
                object objInventoryQty = grow.Cells[this.ColumnInventoryQty.Name].Value;
                object objQauntity = grow.Cells[this.ColumnQuantity.Name].Value;
                if ((objInventoryQty != null)
                    && (objQauntity != null)
                    && (objInventoryQty != DBNull.Value)
                    && (objQauntity != DBNull.Value))
                {
                    if ((decimal)objQauntity > (decimal)objInventoryQty)
                    {
                        grow.ErrorText = "库存不足";
                        continue;
                    }
                }
            }
        }
        private decimal GetInventoryQty(long ManufProcessID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryQty(ManufProcessID, ref rut);
            return rut;
        }

        bool ValidateData()
        {
           
            DataRow[] drows = this.dtblItems.Select("", "", DataViewRowState.CurrentRows);
            if (drows.Length == 0)
            {
                MessageBox.Show("未存在任何明细项");
                return false;
            }
            drows = this.dtblItems.Select("ManufProcessID is null or Quantity is null", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("存在工序或数量不足!");
                return false;
            }
            drows = this.dtblItems.Select("Quantity>InventoryQty", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("存在库存不足记录");
                return false;
            }
            return true ;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
             DialogResult rul = MessageBox.Show("将进行保存入账一经入账不能变更！需要保存吗？", "入账确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            string errormsg = string.Empty;
            bool flag = false;
            long NoteID = -1;
            string NoteCode = string.Empty;
            object objNoteID = DBNull.Value; 
            flag = this.accNotes.InsertSwitchStoreNotes(ref errormsg, ref objNoteID,
                this.dtpDateNote.Value.Date,
                JERPBiz.Frame.UserBiz.PsnID,
                this.rchMemo.Text);
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }           
            NoteID = (long)objNoteID; 
            foreach (DataRow drow in this.dtblItems.Rows )
            {
                if (drow.RowState == DataRowState.Deleted) continue; 
                this.accItems.InsertSwitchStoreItems(ref errormsg,
                   NoteID,
                   drow["WorkingSheetID"],
                   drow["FromManufProcessID"],
                   drow["ToManufProcessID"],
                   drow["Quantity"],
                   drow["Memo"]);   
                //出账
                this.accStore.SaveStoreForOutStore (ref errormsg,
                   drow["FromManufProcessID"],
                   drow["Quantity"]);
                this.accStore.SaveStoreForIntoStore(ref errormsg,
                  drow["ToManufProcessID"],
                  drow["Quantity"]);
               
            }
           
            MessageBox.Show("成功保存并入账当前单据");
            if (this.affterSave != null) this.affterSave();
            this.NewNote();              
         
        }

 

    }
}