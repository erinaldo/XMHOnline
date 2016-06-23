using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class CtrlReceivableCashReceiptRpt : UserControl
    {
        public CtrlReceivableCashReceiptRpt()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accNotes = new JERPData.Product.SaleOrderNotes();
            this.accReconciliations = new JERPData.Product.SaleReconciliations();
            int Year=DateTime .Now .Year ;
            int Month=DateTime .Now .Month ;
            this.dtpDateBegin.Value = new DateTime(Year, Month, 1);
            this.dtpDateEnd.Value = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));           
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.btnExport.Click += new EventHandler(btnExport_Click);
        }

     
        private string whereclause = string.Empty;
        private string iniwhereclause = " and (SettleTypeID in(select SettleTypeID from finance.SettleType where CashSettleFlag=1))";
        private JERPData.Product.SaleOrderNotes accNotes;
        private JERPData.Product.SaleReconciliations accReconciliations;
        private JERPApp.Sale .Report.Bill.FrmSaleOrderNote  frmDetail;
        private JERPApp.Finance.Report.Bill.Product.FrmSaleReconciliation frmReconciliation;
        private DataTable dtblNotes;
        private int iData = 11, iGrid = 10;
        public void LoadData()
        {
            this.btnSearch_Click(this, null);
        }
        private  void LoadSearch()
        {
          
            this.dtblNotes = this.accNotes.GetDataSaleOrderNotesReceiptRpt(this.whereclause).Tables[0];
            while (this.dgrdv.ColumnCount > iGrid)
            {
                this.dgrdv.Columns.RemoveAt(iGrid);
            }
            DataGridViewLinkColumn lnk;
            DataRow drowNew = this.dtblNotes.NewRow();
            drowNew["MoneyTypeName"] = "合计";
            drowNew["TotalAMT"] = this.dtblNotes.Compute("SUM(TotalAMT)", "");
            drowNew["AdvanceAMT"] = this.dtblNotes.Compute("SUM(AdvanceAMT)", "");
            drowNew["DeliverNoteAMT"] = this.dtblNotes.Compute("SUM(DeliverNoteAMT)", "");
            drowNew["FinishedAMT"] = this.dtblNotes.Compute("SUM(FinishedAMT)", "");
            string columnname = string.Empty;
            for (int j = iData; j < this.dtblNotes.Columns.Count; j++)
            {
                columnname = this.dtblNotes.Columns[j].ColumnName;
                lnk = new DataGridViewLinkColumn();
                lnk.Width = 60;
                lnk.HeaderText =columnname + "批";
                lnk.DataPropertyName = columnname;
                lnk.DefaultCellStyle.Format = "#,###.####";
                this.dgrdv.Columns.Add(lnk);
                drowNew[columnname] = this.dtblNotes.Compute("SUM([" + columnname + "])", "");
            }
            this.dtblNotes.Rows.Add(drowNew);
            this.dgrdv.DataSource = this.dtblNotes;
           
        }
     
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                object objDeliverNoteAMT = grow.Cells[this.ColumnDeliverNoteAMT.Name].Value;
                object objFinishedAMT = grow.Cells[this.ColumnFinishedAMT.Name].Value;
                grow.ErrorText = string.Empty;
                if ((objDeliverNoteAMT != DBNull.Value)
                    && (objFinishedAMT != DBNull.Value))
                {
                    if((decimal)objDeliverNoteAMT >(decimal)objFinishedAMT)
                    {
                        grow .ErrorText ="收据未开完!";
                    }
                }
               
            }
        }
        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = this.iniwhereclause;
            if (this.ckbDateNote.Checked)
            {
                this.whereclause +=" and (DateNote>='"+this.dtpDateBegin .Value .ToShortDateString ()+"' and DateNote<='"+this.dtpDateEnd .Value .ToShortDateString ()+"')";
            }           
            if (this.ckbCustomer.Checked)
            {
                this.whereclause += " and (CompanyID=" + this.ctrlCustomerID.CompanyID + ")";
            }
            if (this.ckbFinished.Checked)
            {

                if (this.radFinishedFlag.Checked)
                {
                    this.whereclause += " and (FinishedFlag=1)";
                }
                else
                {
                    this.whereclause += " and (FinishedFlag=0)";
                }
            }
            if (this.ckbReceiptNonFinished .Checked)
            {

                if (this.radReceiptNonFinished .Checked)
                {
                    this.whereclause += " and (DeliverNoteAMT>FinishedAMT)";
                }
                else
                {
                    this.whereclause += " and (DeliverNoteAMT<=FinishedAMT)";
                }
            }
            this.LoadSearch ();

        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)||(irow==this.dgrdv .Rows .Count -1))return;
            long NoteID = (long)this.dtblNotes.DefaultView[irow]["NoteID"];
            if (this.dgrdv.Columns[icol].Name == this.ColumnNoteCode.Name)
            {
               
                if (frmDetail == null)
                {
                    frmDetail = new JERPApp.Sale.Report.Bill.FrmSaleOrderNote();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this.ParentForm );
                }
                frmDetail.Detail(NoteID);
                frmDetail.ShowDialog();
            }
            if (icol>=iGrid)
            {
                int SerialNo = int.Parse (this.dgrdv.Columns[icol].DataPropertyName);
                long ReconciliationID = -1;
                this.accReconciliations.GetParmSaleReconciliationsReconciliationIDBySaleOrderSerialNo (NoteID, SerialNo,
                    ref ReconciliationID);
                if (frmReconciliation == null)
                {
                    frmReconciliation = new JERPApp.Finance.Report.Bill.Product.FrmSaleReconciliation();
                    new FrmStyle(frmReconciliation).SetPopFrmStyle(this.ParentForm);                    
                }
                frmReconciliation.DetailNote (ReconciliationID);
                frmReconciliation.ShowDialog();
            }
            
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1","应收现结报告");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, true);
            FrmMsg.Hide();
            excel.Show();
        }

    }
}