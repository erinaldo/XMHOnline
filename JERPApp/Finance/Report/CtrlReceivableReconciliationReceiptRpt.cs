using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class CtrlReceivableReconciliationReceiptRpt : UserControl
    {
        public CtrlReceivableReconciliationReceiptRpt()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accReconciliations = new JERPData.Product.SaleReconciliations();
            this.accReceiptNotes = new JERPData.Product.SaleReceiptNotes();
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
        private JERPData.Product.SaleReconciliations accReconciliations;
        private JERPData.Product.SaleReceiptNotes accReceiptNotes;
        private JERPApp.Finance.Report.Bill.Product.FrmSaleReconciliation frmReconciliation;
        private JERPApp.Finance.Report.Bill.Product.FrmSaleReceiptNote frmReceiptNote;
        private DataTable dtblReconciliations;
        private int iData = 9, iGrid = 8;
        public void LoadData()
        {
            this.btnSearch_Click(this, null);
        }
        private  void LoadSearch()
        {
          
            this.dtblReconciliations = this.accReconciliations.GetDataSaleReconciliationsReceiptRpt (this.whereclause).Tables[0];
            while (this.dgrdv.ColumnCount > iGrid)
            {
                this.dgrdv.Columns.RemoveAt(iGrid);
            }
            DataGridViewLinkColumn lnk;
            DataRow drowNew = this.dtblReconciliations.NewRow();
            drowNew["MoneyTypeName"] = "合计";
            drowNew["TotalAMT"] = this.dtblReconciliations.Compute("SUM(TotalAMT)", "");
            drowNew["FinishedAMT"] = this.dtblReconciliations.Compute("SUM(FinishedAMT)", "");
            drowNew["NonFinishedAMT"] = this.dtblReconciliations.Compute("SUM(NonFinishedAMT)", "");
            string columnname = string.Empty;
            for (int j = iData; j < this.dtblReconciliations.Columns.Count; j++)
            {
                columnname = this.dtblReconciliations.Columns[j].ColumnName;
                lnk = new DataGridViewLinkColumn();
                lnk.Width = 60;
                lnk.HeaderText =columnname + "批";
                lnk.DataPropertyName = columnname;
                lnk.DefaultCellStyle.Format = "#,###.####";
                this.dgrdv.Columns.Add(lnk);
                drowNew[columnname] = this.dtblReconciliations.Compute("SUM([" + columnname + "])", "");
            }
            this.dtblReconciliations.Rows.Add(drowNew);
            this.dgrdv.DataSource = this.dtblReconciliations;
           
        }
     
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {            
                object objNonFinishedAMT = grow.Cells[this.ColumnNonFinishedAMT.Name].Value;
                grow.ErrorText = string.Empty;
                if (objNonFinishedAMT != DBNull.Value)
                {
                    if ((decimal)objNonFinishedAMT >0)
                    {
                        grow .ErrorText ="收据未开完!";
                    }
                }
               
            }
        }
        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = string.Empty;
            if (this.ckbDateNote.Checked)
            {
                this.whereclause +=" and (DateNote>='"+this.dtpDateBegin .Value .ToShortDateString ()+"' and DateNote<='"+this.dtpDateEnd .Value .ToShortDateString ()+"')";
            }           
            if (this.ckbCustomer.Checked)
            {
                this.whereclause += " and (CompanyID=" + this.ctrlCustomerID.CompanyID + ")";
            }
            
            if (this.ckbReceiptNonFinished .Checked)
            {

                if (this.radReceiptNonFinished .Checked)
                {
                    this.whereclause += " and (NonFinishedAMT>0)";
                }
                else
                {
                    this.whereclause += " and (NonFinishedAMT=0)";
                }
            }
            this.LoadSearch();

        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)||(irow==this.dgrdv .Rows .Count -1))return;
            long ReconciliationID = (long)this.dtblReconciliations.DefaultView[irow]["ReconciliationID"];
            if (this.dgrdv.Columns[icol].Name == this.ColumnReconciliationCode .Name)
            {

                if (frmReconciliation == null)
                {
                    frmReconciliation = new JERPApp.Finance.Report.Bill.Product.FrmSaleReconciliation();
                    new FrmStyle(frmReconciliation).SetPopFrmStyle(this.ParentForm);
                }
                frmReconciliation.DetailNote(ReconciliationID);
                frmReconciliation.ShowDialog();
            }
            if (icol>=iGrid)
            {
                int SerialNo = int.Parse (this.dgrdv.Columns[icol].DataPropertyName);
                long ReceiptNoteID = -1;
                this.accReceiptNotes.GetParmSaleReceiptNotesNoteIDByReconciliationSerialNo (ReconciliationID, SerialNo,
                    ref ReceiptNoteID);
                if (frmReceiptNote == null)
                {
                    frmReceiptNote = new JERPApp.Finance.Report.Bill.Product.FrmSaleReceiptNote();
                    new FrmStyle(frmReceiptNote).SetPopFrmStyle(this.ParentForm);                    
                }
                frmReceiptNote.Detail(ReceiptNoteID);
                frmReceiptNote.ShowDialog();
            }
            
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1","应收月结报告");
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