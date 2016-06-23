using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material.Report
{
    public partial class FrmOutSrcInventoryRecord : Form
    {
        public FrmOutSrcInventoryRecord()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlGridQuickQFind.SeachGridView = this.dgrdv;
            this.accStore = new JERPData.Material.OutSrcStore();
            this.dtpDateBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.dtpDateEnd.Value = DateTime.Now;           
            this.dtpDateBegin.ValueChanged += new EventHandler(dtpDateBegin_ValueChanged);
            this.dtpDateEnd.ValueChanged += new EventHandler(dtpDateEnd_ValueChanged);
            this.btnExplore.Click += new EventHandler(btnExplore_Click);
        }
        Report.Bill.FrmOutSrcStoreCheckNote frmCheckNote;
        Report.Bill.FrmOutSrcSupplyNote frmSupplyNote;
        Report.Bill.FrmOutSrcRecycleNote frmRecycleNote;
        JERPApp.Store.MaterialOEM.Report.Bill.FrmOutSrcRecycleNote frmOEMRecycleNote;
        private JERPData.Material.OutSrcStore accStore;
        private DataTable dtblStore;
        private int PrdID = -1, SupplierID = -1;
        void dtpDateEnd_ValueChanged(object sender, EventArgs e)
        {
            this.LoadData();
        }

        void dtpDateBegin_ValueChanged(object sender, EventArgs e)
        {
            this.LoadData();
        }      
       
        public void StoreRecord(int SupplierID, int PrdID, DateTime DateBegin,DateTime DateEnd)
        {
            this.SupplierID = SupplierID;
            this.PrdID = PrdID;
            this.dtpDateBegin.Value = DateBegin;
            this.dtpDateEnd.Value = DateEnd ;           
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblStore = this.accStore.GetDataOutSrcStoreRecord (
                this.SupplierID ,
                PrdID , 
             this.dtpDateBegin.Value, 
             this.dtpDateEnd.Value).Tables [0];
            this.dgrdv.DataSource = this.dtblStore;
        }
        private void ShowNoteForm(int NoteNameID,long NoteID)
        {
          
            if (NoteNameID == JERPBiz.Material.OutSrcStoreNoteName.StoreCheckNoteNameID)
            {
                if (frmCheckNote == null)
                {
                    frmCheckNote = new JERPApp.Store.Material.Report.Bill.FrmOutSrcStoreCheckNote();
                    new FrmStyle(frmCheckNote).SetPopFrmStyle(this);
                }
                frmCheckNote.DetailNote(NoteID);
                frmCheckNote.ShowDialog();
            }
            if (NoteNameID == JERPBiz.Material.OutSrcStoreNoteName.OutSrcSupplyNoteNameID)
            {
                if (frmSupplyNote == null)
                {
                    frmSupplyNote = new JERPApp.Store.Material.Report.Bill.FrmOutSrcSupplyNote();
                    new FrmStyle(frmSupplyNote).SetPopFrmStyle(this);
                    
                }
                frmSupplyNote.DetailNote(NoteID);
                frmSupplyNote.ShowDialog();
            }
            if (NoteNameID == JERPBiz.Material.OutSrcStoreNoteName.OutSrcRecycleNoteNameID)
            {
                if (frmRecycleNote == null)
                {
                    frmRecycleNote = new JERPApp.Store.Material.Report.Bill.FrmOutSrcRecycleNote();
                    new FrmStyle(frmRecycleNote).SetPopFrmStyle(this);
                }
                frmRecycleNote.DetailNote(NoteID);
                frmRecycleNote.ShowDialog();
            }
            if (NoteNameID == JERPBiz.Material.OutSrcStoreNoteName.OutSrcRecycleOEMNoteNameID)
            {
                if (frmOEMRecycleNote == null)
                {
                    frmOEMRecycleNote = new JERPApp.Store.MaterialOEM.Report.Bill.FrmOutSrcRecycleNote();
                    new FrmStyle(frmOEMRecycleNote).SetPopFrmStyle(this);
                }
                frmOEMRecycleNote.DetailNote(NoteID);
                frmOEMRecycleNote.ShowDialog();
            }
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnNoteName .Name)
            {
                DataRow drow = this.dtblStore.DefaultView[irow].Row;
                if (drow["NoteNameID"] == DBNull.Value) return;
                if (drow["NoteID"] == DBNull.Value) return;
                int NoteNameID = (int)drow["NoteNameID"];
                long NoteID = (long)drow["NoteID"];
                this.ShowNoteForm(NoteNameID, NoteID);
            }
        }
        void btnExplore_Click(object sender, EventArgs e)
        {
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "物料委外库存记录");
               excel.SetCellVal("A3", "起始日期:" +this.dtpDateBegin.Value .ToString ()
               + " 截止日期:" +this.dtpDateEnd.Value.ToString());
            int rowIndex = 4;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.Show();
        }

    }
}