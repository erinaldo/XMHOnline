using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Tool
{
    public partial class FrmReceiveNoteNonOrderOper : Form
    {
        public FrmReceiveNoteNonOrderOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Tool.BuyReceiveItems();
            this.accNotes = new JERPData.Tool.BuyReceiveNotes();
            this.accPrds = new JERPData.Tool.Product();
            this.accUnits = new JERPData.General.Unit();
            this.printhelper = new JERPBiz.Tool.BuyReceiveNotePrintHelper();
            this.SetColumnSrc();           
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
        }

        private JERPBiz.Tool.BuyReceiveNotePrintHelper printhelper;
        private JERPData.Tool.BuyReceiveNotes accNotes;
        private JERPData.Tool.BuyReceiveItems accItems;
        private JERPData.Tool.Product accPrds;
        private JERPData.General.Unit accUnits;
        private DataTable dtblItems,dtblPrds,dtblUnits;
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
            this.dtblPrds = this.accPrds.GetDataProduct().Tables[0];
            this.ColumnPrdCode.DataSource = this.dtblPrds;
            this.ColumnPrdCode.ValueMember = "PrdID";
            this.ColumnPrdCode.DisplayMember = "PrdCode";

            this.ColumnPrdName.DataSource = this.dtblPrds;
            this.ColumnPrdName.ValueMember = "PrdID";
            this.ColumnPrdName.DisplayMember = "PrdName";

            this.ColumnPrdSpec.DataSource = this.dtblPrds;
            this.ColumnPrdSpec.ValueMember = "PrdID";
            this.ColumnPrdSpec.DisplayMember = "PrdSpec";

            this.ColumnUnitName.DataSource = this.dtblPrds ;
            this.ColumnUnitName.ValueMember = "PrdID";
            this.ColumnUnitName.DisplayMember = "UnitName";

            this.dtblUnits = this.accUnits.GetDataUnit().Tables[0];
            this.ColumnPriceUnitID.DataSource = this.dtblUnits;
            this.ColumnPriceUnitID.ValueMember = "UnitID";
            this.ColumnPriceUnitID.DisplayMember = "UnitName";

          
        }

        public void NewNote()
        {
         
            this.dtpDateNote.Value = DateTime.Now.Date;
            this.txtNoteCode.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
            this.dtblItems = this.accItems.GetDataBuyReceiveItemsByNoteID(-1).Tables[0];        
            this.dgrdv.DataSource = this.dtblItems;
        }
      

        void btnNew_Click(object sender, EventArgs e)
        {
            this.NewNote();
        }
        private bool ValidateData()
        {
            if (this.ctrlCompanyID.CompanyID == -1)
            {
                MessageBox.Show("供应商不能为空");
                return false;
            }
            if (this.dtblItems.Select("", "").Length == 0)
            {
                MessageBox.Show("没有任何明细记录");
                return false;
            }
            if (this.dtblItems.Select("Quantity is null  or PriceQty is null","",
                DataViewRowState .CurrentRows ).Length > 0)
            {
                MessageBox.Show("记录未填全,不能保存");
                return false;
            }
            return true;
        }
      
        private object GetUnitID(int PrdID)
        {
            DataRow[] drows = this.dtblPrds.Select("PrdID=" + PrdID.ToString());
            if (drows.Length > 0)
            {
                return drows[0]["UnitID"];
            }
            return DBNull.Value;
        }
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].DataPropertyName == "PrdID")
            {
                object objPrdID = this.dgrdv[icol, irow].Value;
                if ((objPrdID != null) || (objPrdID != DBNull.Value))
                {
                     this.dgrdv[this.ColumnPriceUnitID.Name, irow].Value = this.GetUnitID((int)objPrdID);
                }
            }
            if ((this.dgrdv.Columns[icol].Name == this.ColumnPriceUnitID.Name)
                || (this.dgrdv.Columns[icol].Name == this.ColumnQuantity.Name))
            {
                object objPriceUnitID = this.dgrdv[this.ColumnPriceUnitID.Name, irow].Value;
                object objPrdID = this.dgrdv[this.ColumnPrdCode.Name, irow].Value;
                object objUnitID = this.GetUnitID((int)objPrdID);
                if (objPriceUnitID.ToString() == objUnitID.ToString())
                {
                    this.dgrdv[this.ColumnPriceQty.Name, irow].Value = this.dgrdv[this.ColumnQuantity.Name, irow].Value;
                }
            }
        }
       
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                if ((grow.Cells[this.ColumnPrdCode.Name].Value == DBNull.Value)
                    || (grow.Cells[this.ColumnPriceQty.Name].Value == DBNull.Value)
                    || (grow.Cells[this.ColumnPriceUnitID.Name].Value == DBNull.Value)
                    || (grow.Cells[this.ColumnQuantity.Name].Value == DBNull.Value))
                {
                    grow.ErrorText = "记录未填全";
                }
                else
                {
                    grow.ErrorText = string.Empty;
                }

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            DialogResult rul = MessageBox.Show("将进行保存入账一经确认不能变更！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            bool flag = false;
            string errormsg = string.Empty;
            long NoteID = -1;
            object objNoteID = DBNull.Value;
            decimal TotalAMT = 0;
            foreach (DataRow drow in this.dtblItems.Select("Price is not null", "", DataViewRowState.CurrentRows))
            {
                TotalAMT += (decimal)drow["PriceQty"] * (decimal)drow["Price"];
            }
            flag = this.accNotes.InsertBuyReceiveNotes(
               ref errormsg,
               ref objNoteID,
               this.txtNoteCode.Text,
               this.dtpDateNote.Value.Date,
               DBNull .Value,
               this.ctrlCompanyID.CompanyID,
               this.ctrlMoneyTypeID.MoneyTypeID,
               this.ctrlSettleTypeID .SettleTypeID ,
               this.ctrlPriceTypeID .PriceTypeID ,
               this.ctrlInvoiceTypeID .InvoiceTypeID ,
               this.ctrlQCPsnID.PsnID,
               TotalAMT,
               JERPBiz.Frame.UserBiz.PsnID,
               this.rchMemo.Text);
            if (!flag)
            {
                MessageBox.Show(errormsg, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NoteID = (long)objNoteID;          
            //明细
            object objItemID = DBNull.Value;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                 this.accItems.InsertBuyReceiveItemsNonOrder (ref errormsg, ref objItemID,
                    NoteID,
                    drow["PrdID"],
                    drow["Quantity"],
                    drow["PriceQty"],
                    drow["PriceUnitID"],
                    drow["Price"]);            
              
            }
            rul = MessageBox.Show("成功进行采购收货,需要输出打印吗?", "打印确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                this.printhelper.ExportToExcel(NoteID);
                this.accNotes.UpdateBuyReceiveNotesForPrint(ref errormsg, NoteID, JERPBiz.Frame.UserBiz.PsnID);
            }
            if (this.affterSave != null) this.affterSave();
            this.NewNote();

        }

   
 

     

    }
}