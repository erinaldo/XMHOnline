using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Payable.Tool
{
    public partial class FrmReconciliation : Form
    {
        public FrmReconciliation()
        {
            InitializeComponent(); 
            this.dgrdvMonthSettle.AutoGenerateColumns = false;
            this.dgrdvReceive.AutoGenerateColumns = false; 
            this.dgrdvReconciliation.AutoGenerateColumns = false;
            this.ctrlQReconciliation.SeachGridView = this.dgrdvReconciliation;          
            this.ctrlQReceive.SeachGridView = this.dgrdvReceive; 
            this.accReconciliations = new JERPData.Tool.BuyReconciliations(); 
            this.accReceiveNotes = new JERPData.Tool.BuyReceiveNotes();
            this.accReceiveItems = new JERPData.Tool.BuyReceiveItems();
            this.SetPermit();
        }
        private JERPData.Tool.BuyReconciliations accReconciliations;  
        private JERPData.Tool.BuyReceiveNotes accReceiveNotes;
        private JERPData.Tool.BuyReceiveItems accReceiveItems;
        private DataTable dtblMonthSettle, dtblReceiveNote, dtblReconciliations;
        private FrmReconciliationOper frmOper;
        private FrmReconciliationCashOper frmCashOper; 
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存  
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(358);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(359);
            if (this.enableBrowse)
            {
                this.dgrdvMonthSettle.ContextMenuStrip = this.cMenu;
                this.dgrdvReconciliation.ContextMenuStrip = this.cMenu;
                this.dgrdvReceive.ContextMenuStrip = this.cMenu; 
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.lnkRefreshAll.LinkClicked +=new LinkLabelLinkClickedEventHandler(lnkRefreshAll_LinkClicked);
                this.LoadMonthSettle();
                this.LoadReconciliation();
                this.LoadReceive(); 
            }
            this.ColumnBtnEdit.Visible = this.enableSave; 
            this.ColumnbtnBuy.Visible = this.enableSave;
            this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
            if (this.enableSave)
            {
              
                this.dgrdvReceive.CellContentClick += new DataGridViewCellEventHandler(dgrdvReceive_CellContentClick); 
                this.dgrdvReconciliation.CellContentClick += new DataGridViewCellEventHandler(dgrdvReconciliation_CellContentClick);
            }
        }

        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmOper == null)
            {
                frmOper = new FrmReconciliationOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += this.LoadReconciliation;
                frmOper.AffterSave += this.LoadMonthSettle;
            }
            frmOper.New();
            frmOper.ShowDialog();
        }
        private void Edit(long ReconciliationID)
        {
            if (frmOper == null)
            {
                frmOper = new FrmReconciliationOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += this.LoadReconciliation;
                frmOper.AffterSave += this.LoadMonthSettle;
            }
            frmOper.Edit(ReconciliationID);
            frmOper.ShowDialog();
        }
        private void CashEdit(long ReconciliationID)
        {
            if (frmCashOper == null)
            {
                frmCashOper = new FrmReconciliationCashOper();
                new FrmStyle(frmCashOper).SetPopFrmStyle(this);
                frmCashOper.AffterSave += this.LoadReconciliation;
                frmCashOper.AffterSave += this.LoadReceive; 
            }
            frmCashOper.Edit(ReconciliationID);
            frmCashOper.ShowDialog();
        }
     
        void dgrdvReceive_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvReceive.Columns[icol].Name == this.ColumnbtnBuy.Name)
            {
                int Year = DateTime.Now.Year;
                int Month = DateTime.Now.Month;
                DataRow drow = this.dtblReceiveNote.DefaultView[irow].Row ;
                string ReconciliationName = Year.ToString() + "年" +Month.ToString() + "月" +
                 "现结对账单";
                DateTime DateSettle = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
                DialogResult rut = MessageBox.Show("您将生成当前对账单，确认否?", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rut == DialogResult.No) return;
                string errormsg = string.Empty;
                object objReconciliationID = DBNull.Value;
                bool flag = this.accReconciliations.InsertBuyReconciliations(ref errormsg,
                    ref objReconciliationID,
                    DBNull .Value ,
                    ReconciliationName,
                    Year,
                    Month, 
                    DateTime.Now.Date,
                    drow["CompanyID"],
                    drow["BuyOrderNoteID"],
                    true,
                    drow["MoneyTypeID"],
                    drow["SettleTypeID"],
                    DateSettle,
                    JERPBiz.Frame.UserBiz.PsnID);
                if (flag)
                {
                    
                    this.CashEdit((long)objReconciliationID); 
                }
                else
                {
                    MessageBox.Show(errormsg, "出错啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                     
            }
        }


        void lnkRefreshAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.LoadReceive(); 
            this.LoadReconciliation();
            this.LoadMonthSettle ();
        }

        private void LoadMonthSettle()
        {
            this.dtblMonthSettle = this.accReceiveItems .GetDataBuyReceiveItemsNonReconciliationPivotMonthAMT ().Tables[0];
            while (this.dgrdvMonthSettle.ColumnCount > 3)
            {
                this.dgrdvMonthSettle.Columns.RemoveAt(3);
            }
            DataGridViewTextBoxColumn txt;
            string columnname = string.Empty;
            for (int j = 3; j < this.dtblMonthSettle.Columns.Count; j++)
            {
                columnname = this.dtblMonthSettle.Columns[j].ColumnName;
                txt = new DataGridViewTextBoxColumn();
                txt.DataPropertyName = columnname;
                txt.HeaderText = columnname;
                txt.Width = 70;
                this.dgrdvMonthSettle.Columns.Add(txt);
            }
            this.dgrdvMonthSettle.DataSource = this.dtblMonthSettle;
            this.ctrlQMonthSettle  .SeachGridView = this.dgrdvMonthSettle;
            this.pageMonthSettle.Text = "月结对账[" + this.dtblMonthSettle.Rows.Count + "]";
        }
        private void LoadReceive()
        {

            this.dtblReceiveNote = this.accReceiveNotes.GetDataBuyReceiveNotesNeedReconciliation ().Tables[0];
            this.dgrdvReceive.DataSource = this.dtblReceiveNote;
            this.pageReceive.Text = "现结送货[" + dtblReceiveNote.Rows.Count.ToString() + "]";
        }
        
        private void LoadReconciliation()
        {
            this.dtblReconciliations = this.accReconciliations.GetDataBuyReconciliationsNonSettleAMT ().Tables[0];
            this.dgrdvReconciliation.DataSource = this.dtblReconciliations;
            this.pageReconciliation.Text = "对账变更[" + this.dtblReconciliations.Rows.Count.ToString() + "]";
        }       
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvReconciliation)
            {
                this.LoadReconciliation();
            }
            if (this.cMenu.SourceControl == this.dgrdvMonthSettle)
            {
                this.LoadMonthSettle();
            } 
            
        }


        void dgrdvReconciliation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long ReconciliationID = (long)this.dtblReconciliations.DefaultView[irow]["ReconciliationID"];
            bool CashSettleFlag = (bool)this.dtblReconciliations.DefaultView[irow]["CashSettleFlag"];
            if (this.dgrdvReconciliation.Columns[icol].Name == this.ColumnBtnEdit.Name)
            {
                if (CashSettleFlag)
                {
                    this.CashEdit(ReconciliationID);
                }
                else
                {
                    this.Edit(ReconciliationID);
                }
            }
 
        }

      

    }
}