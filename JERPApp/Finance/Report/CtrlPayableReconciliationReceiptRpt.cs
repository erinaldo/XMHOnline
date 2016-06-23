using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class CtrlPayableReconciliationReceiptRpt : UserControl
    {
        public CtrlPayableReconciliationReceiptRpt()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;

            this.accOutSrcReconciliations = new JERPData.Manufacture.OutSrcReconciliations();
            this.accMtrReconciliations = new JERPData.Material.BuyReconciliations();
            this.accOtherResReconciliations = new JERPData.OtherRes.BuyReconciliations(); 
            this.accPrdReconciliations = new JERPData.Product.BuyReconciliations();
            this.accToolReconciliations = new JERPData.Tool.BuyReconciliations();

            this.accOutSrcReceipt = new JERPData.Manufacture.OutSrcReceiptNotes();
            this.accPrdReceipt = new JERPData.Product.BuyReceiptNotes();
            this.accMtrReceipt = new JERPData.Material.BuyReceiptNotes();
            this.accOtherResReceipt = new JERPData.OtherRes.BuyReceiptNotes(); 
            this.accToolReceipt = new JERPData.Tool.BuyReceiptNotes();
            DataTable dtblType = new DataTable();
            dtblType.Columns.Add("TypeID", typeof(int));
            dtblType.Columns.Add("TypeName", typeof(string));
            dtblType.Rows.Add(iOutSrc, "委外加工");
            dtblType.Rows.Add(iMtr, "原料采购");
            dtblType.Rows.Add(iOtherRes, "耗材采购"); 
            dtblType.Rows.Add(iPrd, "产品采购");
            dtblType.Rows.Add(iTool, "治具采购");
            this.cmbPayableType.DataSource = dtblType;
            this.cmbPayableType.ValueMember = "TypeID";
            this.cmbPayableType.DisplayMember = "TypeName";
            this.cmbPayableType.SelectedIndex = 0;


            int Year=DateTime .Now .Year ;
            int Month=DateTime .Now .Month ;
            this.dtpDateBegin.Value = new DateTime(Year, Month, 1);
            this.dtpDateEnd.Value = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));           
            this.btnSearch.Click += new EventHandler(btnSearch_Click);           
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.btnExport.Click += new EventHandler(btnExport_Click);
        }

     
        private string whereclause = string.Empty;
   
        private JERPData.Manufacture.OutSrcReconciliations accOutSrcReconciliations;
        private JERPData.Material.BuyReconciliations accMtrReconciliations;
        private JERPData.OtherRes.BuyReconciliations accOtherResReconciliations; 
        private JERPData.Product.BuyReconciliations accPrdReconciliations;
        private JERPData.Tool.BuyReconciliations accToolReconciliations;

        private JERPData.Manufacture.OutSrcReceiptNotes accOutSrcReceipt;
        private JERPData.Material.BuyReceiptNotes accMtrReceipt;
        private JERPData.OtherRes.BuyReceiptNotes accOtherResReceipt; 
        private JERPData.Product.BuyReceiptNotes accPrdReceipt;
        private JERPData.Tool.BuyReceiptNotes accToolReceipt;

        private Bill.Manufacture.FrmOutSrcReconciliation frmOutSrcReconciliation;
        private Bill.Material.FrmBuyReconciliation frmMtrReconciliation;
        private Bill.OtherRes.FrmBuyReconciliation frmOtherResReconciliation; 
        private Bill.Product.FrmBuyReconciliation frmPrdReconciliation;
        private Bill.Tool.FrmBuyReconciliation frmToolReconciliation;

        private Bill.Manufacture.FrmOutSrcReceiptNote frmOutSrcReceipt;
        private Bill.Material.FrmBuyReceiptNote frmMtrReceipt;
        private Bill.OtherRes.FrmBuyReceiptNote frmOtherReceipt; 
        private Bill.Product.FrmBuyReceiptNote frmPrdReceipt;
        private Bill.Tool.FrmBuyReceiptNote frmToolReceipt;
        private int iOutSrc = 0, iMtr = 1, iOtherRes = 2,   iPrd = 3, iTool = 4;
        private DataTable dtblNotes;
        private int iData = 8, iGrid = 7;
        public void LoadData()
        {
            this.btnSearch_Click(this, null);
        }
        private  void LoadSearch()
        {
            int TypeID = (int)this.cmbPayableType.SelectedValue;
            if (TypeID == iOutSrc)
            {
                this.dtblNotes = this.accOutSrcReconciliations.GetDataOutSrcReconciliationsReceiptRpt (this.whereclause).Tables[0];
            }
            if (TypeID ==iMtr )
            {
                this.dtblNotes = this.accMtrReconciliations.GetDataBuyReconciliationsReceiptRpt(this.whereclause).Tables[0];
            } 
            if (TypeID == iPrd )
            {
                this.dtblNotes = this.accPrdReconciliations .GetDataBuyReconciliationsReceiptRpt(this.whereclause).Tables[0];
            }
            if (TypeID == iTool )
            {
                this.dtblNotes = this.accToolReconciliations.GetDataBuyReconciliationsReceiptRpt(this.whereclause).Tables[0];
            }
            if (TypeID == iOtherRes)
            {
                this.dtblNotes = this.accOtherResReconciliations .GetDataBuyReconciliationsReceiptRpt(this.whereclause).Tables[0];
            }
          
            while (this.dgrdv.ColumnCount > iGrid)
            {
                this.dgrdv.Columns.RemoveAt(iGrid);
            }
            DataGridViewLinkColumn lnk;
            DataRow drowNew = this.dtblNotes.NewRow();
            drowNew["MoneyTypeName"] = "合计";
            drowNew["TotalAMT"] = this.dtblNotes.Compute("SUM(TotalAMT)", "");
            drowNew["FinishedAMT"] = this.dtblNotes.Compute("SUM(FinishedAMT)", "");
            drowNew["NonFinishedAMT"] = this.dtblNotes.Compute("SUM(NonFinishedAMT)", "");
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
        private void ShowReceiptNote(long ReconciliationID,int SerialNo)
        {
            int TypeID = (int)this.cmbPayableType.SelectedValue;
            long NoteID = -1;
            if (TypeID == iOutSrc)
            {
                this.accOutSrcReceipt.GetParmOutSrcReceiptNotesNoteIDByReconciliationSerialNo (ReconciliationID,
                    SerialNo,
                    ref NoteID);
                if (frmOutSrcReceipt == null)
                {
                    frmOutSrcReceipt = new JERPApp.Finance.Report.Bill.Manufacture.FrmOutSrcReceiptNote();
                    new FrmStyle(frmOutSrcReceipt).SetPopFrmStyle(this);
                }
                frmOutSrcReceipt.Detail(NoteID);
                frmOutSrcReceipt.ShowDialog();
            }
            if (TypeID == iMtr)
            {
                this.accMtrReceipt.GetParmBuyReceiptNotesNoteIDByReconciliationSerialNo (ReconciliationID,
                    SerialNo,
                    ref NoteID);
                if (frmMtrReceipt == null)
                {
                    frmMtrReceipt = new JERPApp.Finance.Report.Bill.Material.FrmBuyReceiptNote();
                    new FrmStyle(frmMtrReceipt).SetPopFrmStyle(this);
                }
                frmMtrReceipt.Detail(NoteID);
                frmMtrReceipt.ShowDialog();
            }
            if (TypeID == iOtherRes)
            {
                this.accOtherResReceipt.GetParmBuyReceiptNotesNoteIDByReconciliationSerialNo(ReconciliationID,
                      SerialNo,
                      ref NoteID);
                if (frmOtherReceipt == null)
                {
                    frmOtherReceipt = new JERPApp.Finance.Report.Bill.OtherRes.FrmBuyReceiptNote();
                    new FrmStyle(frmOtherReceipt).SetPopFrmStyle(this);
                }
                frmOtherReceipt.Detail(NoteID);
                frmOtherReceipt.ShowDialog();
            } 
            if (TypeID == iPrd)
            {
                this.accPrdReceipt.GetParmBuyReceiptNotesNoteIDByReconciliationSerialNo(ReconciliationID,
                   SerialNo,
                   ref NoteID);
                if (frmPrdReceipt == null)
                {
                    frmPrdReceipt = new JERPApp.Finance.Report.Bill.Product.FrmBuyReceiptNote();
                    new FrmStyle(frmPrdReceipt).SetPopFrmStyle(this);
                }
                frmPrdReceipt.Detail(NoteID);
                frmPrdReceipt.ShowDialog();
            }
            if (TypeID == iTool)
            {
                this.accToolReceipt.GetParmBuyReceiptNotesNoteIDByReconciliationSerialNo(ReconciliationID, SerialNo,
                    ref NoteID);
                if (frmToolReceipt == null)
                {
                    frmToolReceipt = new JERPApp.Finance.Report.Bill.Tool.FrmBuyReceiptNote();
                    new FrmStyle(frmToolReceipt).SetPopFrmStyle(this);
                }
                frmToolReceipt.Detail(NoteID);
                frmToolReceipt.ShowDialog();
            }
        }
        private void ShowReconciliation(long ReconciliationID)
        {
            int TypeID = (int)this.cmbPayableType.SelectedValue;
            if (TypeID == iOutSrc)
            {
               
                if (frmOutSrcReconciliation == null)
                {
                    frmOutSrcReconciliation = new JERPApp.Finance.Report.Bill.Manufacture.FrmOutSrcReconciliation();
                    new FrmStyle(frmOutSrcReconciliation).SetPopFrmStyle(this);
                }
                frmOutSrcReconciliation.DetailNote(ReconciliationID);
                frmOutSrcReconciliation.ShowDialog();
            }
            if (TypeID == iMtr)
            {
                
                if (frmMtrReconciliation == null)
                {
                    frmMtrReconciliation = new JERPApp.Finance.Report.Bill.Material.FrmBuyReconciliation();
                    new FrmStyle(frmMtrReconciliation).SetPopFrmStyle(this);
                }
                frmMtrReconciliation.DetailNote(ReconciliationID);
                frmMtrReconciliation.ShowDialog();
            }
            if (TypeID == iOtherRes)
            {              
                if (frmOtherResReconciliation == null)
                {
                    frmOtherResReconciliation = new JERPApp.Finance.Report.Bill.OtherRes.FrmBuyReconciliation();
                    new FrmStyle(frmOtherResReconciliation).SetPopFrmStyle(this);
                }
                frmOtherResReconciliation.DetailNote(ReconciliationID);
                frmOtherResReconciliation.ShowDialog();
            }
            
            if (TypeID == iPrd)
            {
              
                if (frmPrdReconciliation == null)
                {
                    frmPrdReconciliation = new JERPApp.Finance.Report.Bill.Product.FrmBuyReconciliation();
                    new FrmStyle(frmPrdReconciliation).SetPopFrmStyle(this);
                }
                frmPrdReconciliation.DetailNote(ReconciliationID);
                frmPrdReconciliation.ShowDialog();
            }
            if (TypeID == iTool)
            {               
                if (frmToolReconciliation == null)
                {
                    frmToolReconciliation = new JERPApp.Finance.Report.Bill.Tool.FrmBuyReconciliation();
                    new FrmStyle(frmToolReconciliation).SetPopFrmStyle(this);
                }
                frmToolReconciliation.DetailNote(ReconciliationID);
                frmToolReconciliation.ShowDialog();
            }
        }
    
        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = string.Empty;
            if (this.ckbDateNote.Checked)
            {
                this.whereclause +=" and (DateNote>='"+this.dtpDateBegin .Value .ToShortDateString ()+"' and DateNote<='"+this.dtpDateEnd .Value .ToShortDateString ()+"')";
            }           
            if (this.ckbSupplierFlag .Checked)
            {
                this.whereclause += " and (CompanyID=" + this.ctrlSupplierID.CompanyID + ")";
            }        
            this.LoadSearch ();

        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)||(irow==this.dgrdv .Rows .Count -1))return;
            long ReconciliationID = (long)this.dtblNotes.DefaultView[irow]["ReconciliationID"];
            if (this.dgrdv.Columns[icol].Name == this.ColumnDateNote.Name)
            {
                this.ShowReconciliation(ReconciliationID);
            }
            if (icol>=iGrid)
            {
                int SerialNo = int.Parse (this.dgrdv.Columns[icol].DataPropertyName);
                this.ShowReceiptNote(ReconciliationID, SerialNo);
            }
            
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1","应付月结报告");
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