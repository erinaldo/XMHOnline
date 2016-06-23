using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.SemiPrd
{
    public partial class FrmReportLossNoteOper : Form
    {
        public FrmReportLossNoteOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.SemiPrd .ReportLossItems();
            this.accNotes = new JERPData.SemiPrd.ReportLossNotes();
            this.accWorkingSheet = new JERPData.Manufacture.WorkingSheets();
            this.accManufProcess = new JERPData.Manufacture.ManufProcess();
            this.accPrds = new JERPData.Product.Product();
            this.accBadType = new JERPData.Product.BadType();
            this.accStore = new JERPData.SemiPrd.Store();
            this.SetColumnSrc();
            this.btnSave.Click += new EventHandler(btnSave_Click);           
            this.dgrdv.DataBindingComplete +=new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
        }


        private JERPData.SemiPrd.ReportLossNotes accNotes;
        private JERPData.SemiPrd.ReportLossItems accItems;
        private JERPData.Product.BadType accBadType;
        private JERPData.Manufacture.WorkingSheets accWorkingSheet;
        private JERPData.Manufacture.ManufProcess accManufProcess;
        private JERPData.Product.Product accPrds;
        private JERPData.SemiPrd.Store accStore;
        private DataTable dtblItems,dtblPrds,dtblWorkingSheet,dtblBadTypes;
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
            this.dtblWorkingSheet = this.accWorkingSheet.GetDataWorkingSheetsLastRecord(500).Tables[0];
            if (this.dtblWorkingSheet.Rows.Count > 0)
            {
                DataRow drowNew = this.dtblWorkingSheet.NewRow();
                drowNew["WorkingSheetID"] = DBNull.Value;
                drowNew["WorkingSheetCode"] = string.Empty;
                this.dtblWorkingSheet.Rows.InsertAt(drowNew, 0);
            }
            this.ColumnWorkingSheetCode.DataSource = this.dtblWorkingSheet;
            this.ColumnWorkingSheetCode.ValueMember = "WorkingSheetID";
            this.ColumnWorkingSheetCode.DisplayMember = "WorkingSheetCode";

            this.dtblPrds = this.accPrds.GetDataProductForManufPrd().Tables[0];

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

            this.ColumnManufProcessID.ValueMember = "ManufProcessID";
            this.ColumnManufProcessID.DisplayMember = "PrdStatus";

            this.dtblBadTypes = this.accBadType.GetDataBadType().Tables[0];
            this.ColumnBadTypeID.DataSource = this.dtblBadTypes;
            this.ColumnBadTypeID.ValueMember = "BadTypeID";
            this.ColumnBadTypeID.DisplayMember = "BadTypeName";
        }
        public void NewNote()
        {
          
            this.dtpDateNote.Value = DateTime.Now.Date;   
            this.rchMemo.Text = string.Empty;            
            this.dtblItems = this.accItems.GetDataReportLossItemsByNoteID(-1).Tables[0];
            this.dtblItems.Columns .Add("InventoryQty", typeof(decimal));
            this.dgrdv.DataSource = this.dtblItems;
           
        }
        private decimal GetInventoryQty(long ManufProcessID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryQty(ManufProcessID, ref rut);
            return rut;
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
                grow.ErrorText = string.Empty;
                if (grow.Cells[this.ColumnManufProcessID.Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "工序不能为空";
                    continue;
                }
                if (grow.Cells[this.ColumnBadTypeID .Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "不良类型不能为空";
                    continue;
                }
                if (grow.Cells[this.ColumnQuantity .Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "数量不能为空";
                    continue;
                }
                object objInventoryQty = grow.Cells[this.ColumnInventoryQty.Name].Value;
                object objQauntity = grow.Cells[this.ColumnQuantity.Name].Value;
                if ((objInventoryQty !=null)
                    && (objQauntity != null) 
                    &&(objInventoryQty != DBNull.Value)
                    && (objQauntity != DBNull.Value))
                {
                    if ((decimal)objQauntity > (decimal)objInventoryQty)
                    {
                        grow.ErrorText = "库存不足";
                        continue ;
                    }
                }

            }
        }

        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].DataPropertyName == "WorkingSheetID")
            {
                object objWorkingSheetID = this.dgrdv[icol, irow].Value;
                if (objWorkingSheetID == DBNull.Value) return;
                DataRow[] drows = this.dtblWorkingSheet.Select("WorkingSheetID=" + objWorkingSheetID.ToString());
                if (drows.Length == 0) return;               
                foreach (DataGridViewColumn col in this.dgrdv.Columns)
                {
                    if (col.DataPropertyName == "PrdID")
                    {
                        this.dgrdv[col.Name, irow].Value = drows[0]["PrdID"];
                    }
                }
              
            }
            if (this.dgrdv.Columns[icol].DataPropertyName == "PrdID")
            {
                object objPrdID = this.dgrdv[icol, irow].Value;
                if ((objPrdID != null) && (objPrdID != DBNull.Value))
                {
                    DataTable dtblProcess = this.accManufProcess.GetDataManufProcessByPrdID((int)objPrdID).Tables[0];
                    DataGridViewComboBoxCell cmb = (DataGridViewComboBoxCell)this.dgrdv[this.ColumnManufProcessID.Name, irow];
                    cmb.Value = DBNull.Value;
                    cmb.DataSource = dtblProcess;
                    if (dtblProcess.Rows.Count > 0)
                    {
                        cmb.Value = dtblProcess.Rows[0]["ManufProcessID"];
                    }
                }
            }
            if (this.dgrdv.Columns[icol].DataPropertyName == "ManufProcessID")
            {
                object objManufProcessID = this.dgrdv[icol, irow].Value;
                if ((objManufProcessID != null) && (objManufProcessID != DBNull.Value))
                {
                    this.dgrdv[this.ColumnInventoryQty.Name, irow].Value = this.GetInventoryQty((long)objManufProcessID);
                }
            }
        }
        private decimal GetCostPrice(long ManufProcessID)
        {
            decimal rut = 0;
            this.accManufProcess.GetParmManufProcessCostPrice(ManufProcessID, ref rut);
            return rut;
        }
       
        bool ValidateData()
        {

            DataRow[] drows = this.dtblItems.Select("", "", DataViewRowState.CurrentRows);
            if(drows .Length ==0)
            {
                MessageBox.Show("没有任何记录!");
                return false;
            }
            drows = this.dtblItems.Select("ManufProcessID is null or BadTypeID is null or Quantity is null", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("有记录数量、工序、不良原因未输入");
                return false;
            }
            drows = this.dtblItems.Select("Quantity>InventoryQty", "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("存在库存不足记录");
                return false;
            }
            return true;
        }
      
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
             DialogResult rul = MessageBox.Show("将进行保存入账一经入账不能变更！", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            string errormsg = string.Empty;
            bool flag = false;
            long NoteID = -1; 
            object objNoteID = DBNull.Value;
            flag = this.accNotes.InsertReportLossNotes(ref errormsg, 
                ref objNoteID,
                this.dtpDateNote.Value.Date,
                JERPBiz.Frame.UserBiz.PsnID,
                this.txtQC .Text ,
                this.txtConfirmPsns .Text ,
                this.rchMemo.Text);
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            NoteID = (long)objNoteID;
            decimal CostPrice = 0;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                CostPrice = this.GetCostPrice((long)drow["ManufProcessID"]);
                this.accItems.InsertReportLossItems(ref errormsg,
                   NoteID ,
                   drow["WorkingSheetID"] ,
                   drow["ManufProcessID"] ,
                   drow["BadTypeID"],
                   drow["Quantity"],
                   CostPrice ,
                   drow["Memo"]);
                //半成品库
                this.accStore.SaveStoreForOutStore(
                    ref errormsg,
                    drow["ManufProcessID"],
                    drow["Quantity"]);
              
            }
       
            MessageBox.Show("成功保存并入账当前单据");
            if (this.affterSave != null) this.affterSave();
            this.NewNote();
               
            
        }

 

    }
}