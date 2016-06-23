using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class CtrlPayableCashReceiptRpt : UserControl
    {
        public CtrlPayableCashReceiptRpt()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;

            this.accOutSrcOrder = new JERPData.Manufacture.OutSrcOrderNotes();
            this.accMtrOrder = new JERPData.Material.BuyOrderNotes();
            this.accOtherResOrder = new JERPData.OtherRes.BuyOrderNotes(); 
            this.accPrdOrderNotes = new JERPData.Product.BuyOrderNotes();
            this.accToolOrderNotes = new JERPData.Tool.BuyOrderNotes();

            this.accOutSrcReconciliation = new JERPData.Manufacture.OutSrcReconciliations();
            this.accPrdReconciliation = new JERPData.Product.BuyReconciliations();
            this.accMtrReconciliation = new JERPData.Material.BuyReconciliations();
            this.accOtherResReconciliation = new JERPData.OtherRes.BuyReconciliations();
            this.accToolReconciliation = new JERPData.Tool.BuyReconciliations();
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
        private string iniwhereclause = " and (SettleTypeID in(select SettleTypeID from finance.SettleType where CashSettleFlag=1))";

        private JERPData.Manufacture.OutSrcOrderNotes accOutSrcOrder;
        private JERPData.Material.BuyOrderNotes accMtrOrder;
        private JERPData.OtherRes.BuyOrderNotes accOtherResOrder; 
        private JERPData.Product.BuyOrderNotes accPrdOrderNotes;
        private JERPData.Tool.BuyOrderNotes accToolOrderNotes;

        private JERPData.Manufacture.OutSrcReconciliations accOutSrcReconciliation;
        private JERPData.Material.BuyReconciliations accMtrReconciliation;
        private JERPData.OtherRes.BuyReconciliations accOtherResReconciliation;
        private JERPData.Product.BuyReconciliations accPrdReconciliation;
        private JERPData.Tool.BuyReconciliations accToolReconciliation;

        private JERPApp.Supply.OutSrc.Report.Bill.FrmOutSrcOrderNote frmOutSrcOrder;
        private JERPApp.Supply.Material.Report.Bill.FrmBuyOrderNote frmMtrOrder;
        private JERPApp.Supply.OtherRes.Report.Bill.FrmBuyOrderNote frmOtherResOrder; 
        private JERPApp.Supply.Product.Report.Bill.FrmBuyOrderNote frmPrdOrder;
        private JERPApp.Engineer.Tool.Report.Bill.FrmBuyOrderNote frmToolOrder;

        private Bill.Manufacture.FrmOutSrcReconciliation frmOutSrcReconciliation;
        private Bill.Material.FrmBuyReconciliation frmMtrReconciliation;
        private Bill.OtherRes.FrmBuyReconciliation frmOtherReconciliation;
        private Bill.Product.FrmBuyReconciliation frmPrdReconciliation;
        private Bill.Tool.FrmBuyReconciliation frmToolReconciliation;
        private int iOutSrc = 0, iMtr = 1, iOtherRes = 2, iPrd =3, iTool = 4;
        private DataTable dtblNotes;
        private int iData = 8, iGrid = 7;
        public void LoadData()
        {
            this.btnSearch_Click(this, null);
        }
        private void LoadSerach()
        {       
            
            int TypeID = (int)this.cmbPayableType.SelectedValue;
            if (TypeID == iOutSrc)
            {
                this.dtblNotes = this.accOutSrcOrder.GetDataOutSrcOrderNotesReceiptRpt (this.whereclause).Tables[0];
            }
            if (TypeID ==iMtr )
            {
                this.dtblNotes = this.accMtrOrder.GetDataBuyOrderNotesReceiptRpt(this.whereclause).Tables[0];
            }
           
            if (TypeID == iTool )
            {
                this.dtblNotes = this.accToolOrderNotes .GetDataBuyOrderNotesReceiptRpt(this.whereclause).Tables[0];
            }
            if (TypeID == iOtherRes)
            {
                this.dtblNotes = this.accOtherResOrder .GetDataBuyOrderNotesReceiptRpt(this.whereclause).Tables[0];
            }
          
            while (this.dgrdv.ColumnCount > iGrid)
            {
                this.dgrdv.Columns.RemoveAt(iGrid);
            }
            DataGridViewLinkColumn lnk;
            DataRow drowNew = this.dtblNotes.NewRow();
            drowNew["MoneyTypeName"] = "合计";      
            drowNew["AdvanceAMT"] = this.dtblNotes.Compute("SUM(AdvanceAMT)", "");
            drowNew["DeliverAMT"] = this.dtblNotes.Compute("SUM(DeliverAMT)", "");
            drowNew["ReceiptAMT"] = this.dtblNotes.Compute("SUM(ReceiptAMT)", "");
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
        private void ShowOrderNote(long NoteID)
        {
            int TypeID = (int)this.cmbPayableType.SelectedValue;         
            if (TypeID == iOutSrc)
            {               
                if (frmOutSrcOrder == null)
                {
                    frmOutSrcOrder = new JERPApp.Supply.OutSrc.Report.Bill.FrmOutSrcOrderNote();
                    new FrmStyle(frmOutSrcOrder).SetPopFrmStyle(this);
                }
                frmOutSrcOrder.Detail(NoteID);
                frmOutSrcOrder.ShowDialog();
            }
            if (TypeID == iMtr)
            {
             
                if (frmMtrOrder == null)
                {
                    frmMtrOrder = new JERPApp.Supply.Material.Report.Bill.FrmBuyOrderNote();
                    new FrmStyle(frmMtrOrder).SetPopFrmStyle(this);
                }
                frmMtrOrder.Detail(NoteID);
                frmMtrOrder.ShowDialog();
            }
            if (TypeID == iOtherRes)
            {
              
                if (frmOtherResOrder == null)
                {
                    frmOtherResOrder = new JERPApp.Supply.OtherRes.Report.Bill.FrmBuyOrderNote();
                    new FrmStyle(frmOtherResOrder).SetPopFrmStyle(this);
                }
                frmOtherResOrder.Detail(NoteID);
                frmOtherResOrder.ShowDialog();
            }
            
            if (TypeID == iPrd)
            {
                
                if (frmPrdOrder == null)
                {
                    frmPrdOrder = new JERPApp.Supply.Product.Report.Bill.FrmBuyOrderNote();
                    new FrmStyle(frmPrdOrder).SetPopFrmStyle(this);
                }
                frmPrdOrder.Detail(NoteID);
                frmPrdOrder.ShowDialog();
            }
            if (TypeID == iTool)
            {
             
                if (frmToolOrder == null)
                {
                    frmToolOrder = new JERPApp.Engineer.Tool.Report.Bill.FrmBuyOrderNote();
                    new FrmStyle(frmToolOrder).SetPopFrmStyle(this);
                }
                frmToolOrder.Detail(NoteID);
                frmToolOrder.ShowDialog();
            }
        }
    
        private void ShowReceiptNote(long OrderNoteID,int SerialNo)
        {
            int TypeID = (int)this.cmbPayableType.SelectedValue;
            long ReconciliationID = -1;
            if (TypeID == iOutSrc)
            {
                this.accOutSrcReconciliation.GetParmOutSrcReconciliationsReconciliationIDByOutSrcOrderSerialNo (OrderNoteID,
                    SerialNo,
                    ref ReconciliationID);
                if (frmOutSrcReconciliation == null)
                {
                    frmOutSrcReconciliation = new JERPApp.Finance.Report.Bill.Manufacture.FrmOutSrcReconciliation();
                    new FrmStyle(frmOutSrcReconciliation).SetPopFrmStyle(this);
                }
                frmOutSrcReconciliation.DetailNote (ReconciliationID);
                frmOutSrcReconciliation.ShowDialog();
            }
            if (TypeID == iMtr)
            {
                this.accMtrReconciliation.GetParmBuyReconciliationsReconciliationIDByBuyOrderSerialNo (OrderNoteID,
                    SerialNo,
                    ref ReconciliationID);
                if (frmMtrReconciliation == null)
                {
                    frmMtrReconciliation = new JERPApp.Finance.Report.Bill.Material.FrmBuyReconciliation();
                    new FrmStyle(frmMtrReconciliation).SetPopFrmStyle(this);
                }
                frmMtrReconciliation.DetailNote (ReconciliationID);
                frmMtrReconciliation.ShowDialog();
            }
            if (TypeID == iOtherRes)
            {
                this.accOtherResReconciliation.GetParmBuyReconciliationsReconciliationIDByBuyOrderSerialNo (OrderNoteID,
                      SerialNo,
                      ref ReconciliationID);
                if (frmOtherReconciliation == null)
                {
                    frmOtherReconciliation = new JERPApp.Finance.Report.Bill.OtherRes.FrmBuyReconciliation();
                    new FrmStyle(frmOtherReconciliation).SetPopFrmStyle(this);
                }
                frmOtherReconciliation.DetailNote (ReconciliationID);
                frmOtherReconciliation.ShowDialog();
            } 
            if (TypeID == iPrd)
            {
                this.accPrdReconciliation.GetParmBuyReconciliationsReconciliationIDByBuyOrderSerialNo (OrderNoteID,
                   SerialNo,
                   ref ReconciliationID);
                if (frmPrdReconciliation == null)
                {
                    frmPrdReconciliation = new JERPApp.Finance.Report.Bill.Product.FrmBuyReconciliation();
                    new FrmStyle(frmPrdReconciliation).SetPopFrmStyle(this);
                }
                frmPrdReconciliation.DetailNote (ReconciliationID);
                frmPrdReconciliation.ShowDialog();
            }
            if (TypeID == iTool)
            {
                this.accToolReconciliation.GetParmBuyReconciliationsReconciliationIDByBuyOrderSerialNo (OrderNoteID, SerialNo,
                    ref ReconciliationID);
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
            this.whereclause = this.iniwhereclause;
            if (this.ckbDateNote.Checked)
            {
                this.whereclause +=" and (DateNote>='"+this.dtpDateBegin .Value .ToShortDateString ()+"' and DateNote<='"+this.dtpDateEnd .Value .ToShortDateString ()+"')";
            }           
            if (this.ckbSupplierFlag .Checked)
            {
                this.whereclause += " and (CompanyID=" + this.ctrlSupplierID.CompanyID + ")";
            }        
            this.LoadSerach ();

        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)||(irow==this.dgrdv .Rows .Count -1))return;
            long NoteID = (long)this.dtblNotes.DefaultView[irow]["NoteID"];
            if (this.dgrdv.Columns[icol].Name == this.ColumnNoteCode.Name)
            {
                this.ShowOrderNote(NoteID);
            }
            if (icol>=iGrid)
            {
                int SerialNo = int.Parse (this.dgrdv.Columns[icol].DataPropertyName);
                this.ShowReceiptNote(NoteID, SerialNo);
            }
            
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1","应付现结报告");
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