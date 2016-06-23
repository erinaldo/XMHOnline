using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Receivable
{
    public partial class FrmSaleReconciliation : Form
    {
        public FrmSaleReconciliation()
        {
            InitializeComponent(); 
            this.dgrdvMonthSettle.AutoGenerateColumns = false;
            this.dgrdvDeliver.AutoGenerateColumns = false;
            this.dgrdvRepair.AutoGenerateColumns = false;
            this.dgrdvReconciliation.AutoGenerateColumns = false;
            this.ctrlQReconciliation.SeachGridView = this.dgrdvReconciliation;          
            this.ctrlQDeliver.SeachGridView = this.dgrdvDeliver;
            this.ctrlQRepair.SeachGridView = this.dgrdvRepair;
            this.accReconciliations = new JERPData.Product.SaleReconciliations();
            this.printer = new JERPBiz.Product.SaleReconciliationPrintHelper();
            this.accDeliverNotes = new JERPData.Product.SaleDeliverNotes();
            this.accRepairNotes = new JERPData.Product.RepairDeliverNotes();
            this.SetPermit();
        }
        private JERPData.Product.SaleReconciliations accReconciliations; 
        private JERPBiz.Product.SaleReconciliationPrintHelper  printer;
        private JERPData.Product.SaleDeliverNotes accDeliverNotes;
        private JERPData.Product.RepairDeliverNotes accRepairNotes;
        private DataTable dtblMonthSettle, dtblDeliverNote, dtblRepairNote, dtblReconciliations;
        private FrmSaleReconciliationOper frmOper;
        private FrmSaleReconciliationCashOper frmCashOper;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存  
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(239);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(240);
            if (this.enableBrowse)
            {
                this.dgrdvMonthSettle.ContextMenuStrip = this.cMenu;
                this.dgrdvReconciliation.ContextMenuStrip = this.cMenu;
                this.dgrdvDeliver.ContextMenuStrip = this.cMenu;
                this.dgrdvRepair.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.lnkRefreshAll.LinkClicked +=new LinkLabelLinkClickedEventHandler(lnkRefreshAll_LinkClicked);
                this.LoadMonthSettle();
                this.LoadReconciliation();
                this.LoadDeliver();
                this.LoadRepair();
            }
            this.ColumnBtnEdit.Visible = this.enableSave;
            this.ColumnbtnRepair.Visible = this.enableSave;
            this.ColumnbtnSale.Visible = this.enableSave;
            if (this.enableSave)
            {
                this.dgrdvRepair.CellContentClick += new DataGridViewCellEventHandler(dgrdvRepair_CellContentClick);
                this.dgrdvDeliver.CellContentClick += new DataGridViewCellEventHandler(dgrdvDeliver_CellContentClick);
                this.dgrdvMonthSettle.CellContentClick += new DataGridViewCellEventHandler(dgrdvMonthSettle_CellContentClick);
                this.dgrdvReconciliation.CellContentClick += new DataGridViewCellEventHandler(dgrdvReconciliation_CellContentClick);
            }
        }
        private void Edit(long ReconciliationID)
        {
            if (frmOper == null)
            {
                frmOper = new FrmSaleReconciliationOper();
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
                frmCashOper = new FrmSaleReconciliationCashOper();
                new FrmStyle(frmCashOper).SetPopFrmStyle(this);
                frmCashOper.AffterSave += this.LoadReconciliation;
                frmCashOper.AffterSave += this.LoadDeliver;
                frmCashOper.AffterSave += this.LoadRepair;
            }
            frmCashOper.Edit(ReconciliationID);
            frmCashOper.ShowDialog();
        }
        void dgrdvMonthSettle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvMonthSettle.Columns[icol].GetType().Equals(typeof(DataGridViewLinkColumn)))
            {

                DataRow drow = this.dtblMonthSettle.DefaultView[irow].Row;
                int CompanyID = (int)drow["CompanyID"];
                int FinanceAddressID = (int)drow["FinanceAddressID"];
                int MoneyTypeID = (int)drow["MoneyTypeID"];
                int SettleTypeID = (int)drow["SettleTypeID"];
                string columnname = this.dgrdvMonthSettle.Columns[icol].DataPropertyName;
                int Year = int.Parse (columnname.Split('-')[0]);
                int Month=int.Parse (columnname .Split ('-')[1]);
                long ReconciliationID = -1;
                this.accReconciliations.GetParmSaleReconciliationsReconciliationID(
                    Year, Month, CompanyID,
                    FinanceAddressID,
                    MoneyTypeID,
                    SettleTypeID,
                    ref ReconciliationID);
                DialogResult rut;
                if (ReconciliationID > -1)
                {
                    rut = MessageBox.Show("本月的此类对账单已制定?是加入此单，否，新增对账单", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rut == DialogResult.No)
                    {
                        ReconciliationID = -1;
                    }

                }
                if (ReconciliationID == -1)
                {
                    string ReconciliationName = Year.ToString() + "年" + Month.ToString() + "月" +
                 "对账单";
                    DateTime DateSettle = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
                    rut = MessageBox.Show("您将生成当前对账单，确认否?", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rut == DialogResult.Yes)
                    {
                        string errormsg = string.Empty;
                        object objReconciliationID = DBNull.Value;
                        bool flag = this.accReconciliations.InsertSaleReconciliations(ref errormsg, ref objReconciliationID,
                            ReconciliationName,
                            Year, Month, DateTime.Now.Date,
                            DBNull .Value ,
                            CompanyID,
                            FinanceAddressID,
                            MoneyTypeID,
                            SettleTypeID,
                            DateSettle,
                            JERPBiz.Frame.UserBiz.PsnID);
                        if (flag)
                        {
                            ReconciliationID = (long)objReconciliationID;
                        }
                        else
                        {
                            MessageBox.Show(errormsg, "出错啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                if (ReconciliationID >-1)
                {
                    this.Edit(ReconciliationID);
                }
              
            }
        }
        void dgrdvRepair_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvRepair.Columns[icol].Name == this.ColumnbtnRepair.Name)
            {
                int Year = DateTime.Now.Year;
                int Month = DateTime.Now.Month;
                DataRow drow = this.dtblRepairNote .DefaultView[irow].Row;
                string ReconciliationName = Year.ToString() + "年" + Month.ToString() + "月" +
                 "现结对账单";
                DateTime DateSettle = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
                DialogResult rut = MessageBox.Show("您将生成当前对账单，确认否?", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rut == DialogResult.No) return;
                string errormsg = string.Empty;
                object objReconciliationID = DBNull.Value;
                bool flag = this.accReconciliations.InsertSaleReconciliations(ref errormsg,
                    ref objReconciliationID,
                    ReconciliationName,
                    Year,
                    Month,
                    DateTime.Now.Date,
                    DBNull .Value ,
                    drow["CompanyID"],
                    drow["FinanceAddressID"],
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
        void dgrdvDeliver_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvDeliver.Columns[icol].Name == this.ColumnbtnSale.Name)
            {
                int Year = DateTime.Now.Year;
                int Month = DateTime.Now.Month;
                DataRow drow = this.dtblDeliverNote.DefaultView[irow].Row ;
                string ReconciliationName = Year.ToString() + "年" +Month.ToString() + "月" +
                 "现结对账单";
                DateTime DateSettle = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
                DialogResult rut = MessageBox.Show("您将生成当前对账单，确认否?", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rut == DialogResult.No) return;
                string errormsg = string.Empty;
                object objReconciliationID = DBNull.Value;
                bool flag = this.accReconciliations.InsertSaleReconciliations(ref errormsg,
                    ref objReconciliationID,
                    ReconciliationName,
                    Year,
                    Month, 
                    DateTime.Now.Date,
                    drow["SaleOrderNoteID"],
                    drow["CompanyID"],
                    drow["FinanceAddressID"],
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
            this.LoadDeliver();
            this.LoadRepair ();
            this.LoadReconciliation();
            this.LoadMonthSettle ();
        }

        private void LoadMonthSettle()
        {
            this.dtblMonthSettle = this.accReconciliations.GetDataSaleReconciliationsForCreatePivotMonthAMT().Tables[0];
            while (this.dgrdvMonthSettle.ColumnCount > 4)
            {
                this.dgrdvMonthSettle.Columns.RemoveAt(4);
            }
            DataGridViewLinkColumn lncol;
            string columnname = string.Empty;
            for (int j = 8; j < this.dtblMonthSettle.Columns.Count; j++)
            {
                columnname = this.dtblMonthSettle.Columns[j].ColumnName;
                lncol = new DataGridViewLinkColumn();
                lncol.DataPropertyName = columnname;
                lncol.HeaderText = columnname;
                lncol.Width = 70;
                this.dgrdvMonthSettle.Columns.Add(lncol);
            }
            this.dgrdvMonthSettle.DataSource = this.dtblMonthSettle;
            this.ctrlQMonthSettle  .SeachGridView = this.dgrdvMonthSettle;
            this.pageMonthSettle.Text = "月结对账[" + this.dtblMonthSettle.Rows.Count + "]";
        }
        private void LoadDeliver()
        {

            this.dtblDeliverNote = this.accDeliverNotes.GetDataSaleDeliverNotesNeedReconciliation ().Tables[0];
            this.dgrdvDeliver.DataSource = this.dtblDeliverNote;
            this.pageDeliver.Text = "现结送货[" + dtblDeliverNote.Rows.Count.ToString() + "]";
        }
        private void LoadRepair()
        {
            this.dtblRepairNote = this.accRepairNotes.GetDataRepairDeliverNotesNeedReconciliation ().Tables[0];
            this.dgrdvRepair.DataSource = this.dtblRepairNote;
            this.pageRepair.Text = "现结维修[" + this.dtblRepairNote.Rows.Count.ToString() + "]";
        }
        private void LoadReconciliation()
        {
            this.dtblReconciliations = this.accReconciliations.GetDataSaleReconciliationsNonReceipt().Tables[0];
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
            if (this.cMenu.SourceControl == this.dgrdvDeliver )
            {
                this.LoadDeliver ();
            }
            if (this.cMenu.SourceControl == this.dgrdvRepair )
            {
                this.LoadRepair ();
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

            if (this.dgrdvReconciliation.Columns[icol].Name == this.ColumnbtnExport.Name)
            {
                FrmMsg.Show("正在输出Excel文档,请稍候....");
                long[] IDList = new long[] { ReconciliationID };
                this.printer .ExportToExcel(IDList);
                FrmMsg.Hide();
            }
        }

      

    }
}