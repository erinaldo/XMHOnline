using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Receivable
{
    public partial class FrmExpressReconciliationOper : Form
    {
        public FrmExpressReconciliationOper()
        {
            InitializeComponent();
            this.accReconciliations = new JERPData.Product.ExpressReconciliations();
            this.accReceiptNotes = new JERPData.Product.SaleReceiptNotes();
            this.ReconciliationEntity = new JERPBiz.Product.ExpressReconciliationEntity();
            this.printerhelper = new JERPBiz.Product.ExpressReconciliationPrintHelper();


            this.dgrdvReceipt.AutoGenerateColumns = false;        
          
            this.dgrdvReceipt.UserDeletedRow += new DataGridViewRowEventHandler(dgrdvReceipt_UserDeletedRow);
            this.dgrdvReceipt.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdvReceipt_UserDeletingRow);
            this.dgrdvReceipt.MouseClick += new MouseEventHandler(dgrdvReceipt_MouseClick);

            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.FormClosed += new FormClosedEventHandler(FrmExpressReconciliationOper_FormClosed);
            this.btnExport.Click += this.btnExplore_Click;
        }
        private JERPData.Product.ExpressReconciliations accReconciliations;
        private JERPData.Product.SaleReceiptNotes accReceiptNotes;
        private JERPBiz.Product.ExpressReconciliationEntity ReconciliationEntity;
        private JERPApp .Define .Product .FrmSaleReceiptNoteForExpressReconciliation  frmReceipt;
        private JERPBiz.Product.ExpressReconciliationPrintHelper printerhelper;
        private DataTable dtblReceiptNotes;
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
        private long reconciliationid = -1;
        private long ReconciliationID
        {
            get
            {
                return this.reconciliationid;
            }
            set
            {
                this.reconciliationid = value;
                this.btnDelete.Enabled = (value > -1);
            }
        }
        
        public void Edit(long ReconciliationID)
        {
            this.ReconciliationID = ReconciliationID;
            this.ReconciliationEntity.LoadData(ReconciliationID);
            this.txtReconciliationName.Text = this.ReconciliationEntity.ReconciliationName;
            this.txtReconciliationCode.Text = this.ReconciliationEntity.ReconciliationCode;
            this.txtCompanyName.Text = this.ReconciliationEntity.CompanyName;
         
            this.txtYear.Text = this.ReconciliationEntity.Year.ToString();
            this.txtMonth.Text = this.ReconciliationEntity.Month.ToString();
            this.txtDateNote.Text = this.ReconciliationEntity.DateNote.ToShortDateString();
            this.txtMoneyTypeName.Text = this.ReconciliationEntity.MoneyTypeName;
           
            this.LoadReceiptNotes();
          
        }
      
    
        private void LoadReceiptNotes()
        {
            this.dtblReceiptNotes = this.accReceiptNotes.GetDataSaleReceiptNotesByExpressReconciliationID (this.ReconciliationID).Tables[0];
            this.dgrdvReceipt.DataSource = this.dtblReceiptNotes;
            int cnt = 0;
            this.accReceiptNotes.GetParmSaleReceiptNotesCountForExpressReconciliation(this.ReconciliationID, ref cnt);
            this.pageSaleReceipt.Text = "销售收据:" + cnt.ToString();

            object objTotalAMT = this.dtblReceiptNotes.Compute("SUM(Amount)", "");
            this.txtTotalAMT.Text = string.Format("{0:0.####}", objTotalAMT);


        }
      
      
     
        private void SaveAMT()
        {
            string errormsg=string.Empty ;
            this.accReconciliations.UpdateExpressReconciliationsForAMT  (ref errormsg, this.ReconciliationID );
          

        }
        void dgrdvReceipt_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            object objItemID = this.dtblReceiptNotes.DefaultView[irow]["ItemID"];
            if (objItemID == DBNull.Value)
            {
                return;
            }
            string errormsg = string.Empty;
            bool flag = this.accReceiptNotes.UpdateSaleReceiptNotesCancelExpressReconciliation  (
                ref errormsg, objItemID);
            if (!flag)
            {

                MessageBox.Show(errormsg);
                e.Cancel = true;
            }
           
        }
        void dgrdvReceipt_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.LoadReceiptNotes();
        }
        void dgrdvReceipt_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                if (this.ReconciliationID > -1)
                {
                    if (frmReceipt == null)
                    {
                        frmReceipt = new JERPApp.Define.Product.FrmSaleReceiptNoteForExpressReconciliation();
                        new FrmStyle(frmReceipt).SetPopFrmStyle(this);
                        frmReceipt.AffterConfirm  += this.LoadReceiptNotes;
                    }
                    frmReceipt.LoadReconciliaion (this.ReconciliationID);
                    frmReceipt.ShowDialog();
                }
            }
        }
        void frmReceipt_AffterEnter()
        {
            this.LoadReceiptNotes();        
        }




        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            bool flag = false;
            flag = this.accReconciliations.UpdateExpressReconciliations(ref errormsg, this.ReconciliationID,this.txtReconciliationName.Text);
            if (flag)
            {
                MessageBox.Show("成功保存对账单信息");
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }
        void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rut = MessageBox.Show("你将删除当前对账单及明细，你的删除将不能恢复，确认否?", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rut == DialogResult.Yes)
            {
                string errormsg = string.Empty;
                bool flag = false;
                flag = this.accReconciliations.DeleteExpressReconciliations(ref errormsg, this.ReconciliationID);
                if (flag)
                {
                    MessageBox.Show("删除当前对账单及明细！");
                }
                else
                {
                    MessageBox.Show(errormsg);
                }
              
                this.Close();
            }
        }
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            this.SaveAMT();
            long[] IDList = new long[] { this.ReconciliationID };
            this.printerhelper.ExportToExcel(IDList);
            FrmMsg.Hide();
        }
    
        void FrmExpressReconciliationOper_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.ReconciliationID > -1)
            {
                this.SaveAMT  ();
               if (this.affterSave != null) this.affterSave();
            }
        }
    }
}