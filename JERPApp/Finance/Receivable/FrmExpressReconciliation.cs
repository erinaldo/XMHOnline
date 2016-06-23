using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Receivable
{
    public partial class FrmExpressReconciliation : Form
    {
        public FrmExpressReconciliation()
        {
            InitializeComponent();          
            this.dgrdvReconciliation.AutoGenerateColumns = false;
            this.ctrlQReconciliation.SeachGridView = this.dgrdvReconciliation;
            this.dgrdvReceipt.AutoGenerateColumns = false;
            this.accReconciliations = new JERPData.Product.ExpressReconciliations();
            this.printer = new JERPBiz.Product.ExpressReconciliationPrintHelper();
            this.accSaleReceiptNotes = new JERPData.Product.SaleReceiptNotes();
            this.SetPermit();
        }
        private JERPData.Product.ExpressReconciliations accReconciliations;
        private JERPBiz.Product.ExpressReconciliationPrintHelper  printer;
        private JERPData.Product.SaleReceiptNotes accSaleReceiptNotes;
        private DataTable dtblReceipts, dtblReconciliations;
        private FrmExpressReconciliationOper frmOper;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableCreate = false;//保存  
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(735);
            this.enableCreate = JERPBiz.Frame.PermitHelper.EnableFunction(736);
            this.ColumnBtnEdit.Visible = this.enableCreate;
            if (this.enableBrowse)
            {
                this.dgrdvReceipt.ContextMenuStrip = this.cMenu; 
                this.dgrdvReconciliation.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.LoadReceipt();
                this.LoadReconciliation();
            }
            if (this.enableCreate)
            {
                this.dgrdvReceipt.CellContentClick += new DataGridViewCellEventHandler(dgrdvReceipt_CellContentClick);
                this.dgrdvReconciliation.CellContentClick += new DataGridViewCellEventHandler(dgrdvReconciliation_CellContentClick);
            }
        }
        private void EditReconciliation(long ReconciliationID)
        {
            if (frmOper == null)
            {
                frmOper = new FrmExpressReconciliationOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += this.LoadReconciliation;
                frmOper.AffterSave += this.LoadReceipt;
            }
            frmOper.Edit(ReconciliationID);
            frmOper.ShowDialog();
        }
        void dgrdvReceipt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvReceipt.Columns[icol].GetType().Equals(typeof(DataGridViewLinkColumn)))
            {

                DataRow drow = this.dtblReceipts.DefaultView[irow].Row;
                int CompanyID = (int)drow["ExpressCompanyID"];
                int MoneyTypeID = (int)drow["MoneyTypeID"];                
            
                string columnname = this.dgrdvReceipt.Columns[icol].DataPropertyName;
                int Year = int.Parse (columnname.Split('-')[0]);
                int Month=int.Parse (columnname .Split ('-')[1]);
                long ReconciliationID = -1;
                this.accReconciliations.GetParmExpressReconciliationsReconciliationID(
                    Year, Month, 
                    CompanyID,
                    MoneyTypeID,
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
                    rut = MessageBox.Show("您将生成当前对账单，确认否?", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rut == DialogResult.Yes)
                    {
                        string errormsg = string.Empty;
                        object objReconciliationID = DBNull.Value;
                        bool flag = this.accReconciliations.InsertExpressReconciliations(ref errormsg, ref objReconciliationID,
                            ReconciliationName,
                            Year, Month,
                            DateTime.Now.Date,
                            CompanyID,
                            MoneyTypeID,
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
                    this.EditReconciliation(ReconciliationID);
                }
              
            }
        }
        private void LoadReceipt()
        {
            this.dtblReceipts = this.accSaleReceiptNotes.GetDataSaleReceiptNotesNonExpressReconciliationPivotMonthAMT ().Tables[0];
            while (this.dgrdvReceipt.ColumnCount > 2)
            {
                this.dgrdvReceipt.Columns.RemoveAt(2);
            }
            DataGridViewLinkColumn lncol;
            string columnname = string.Empty;
            for (int j = 4; j < this.dtblReceipts.Columns.Count; j++)
            {
                columnname = this.dtblReceipts.Columns[j].ColumnName;
                lncol = new DataGridViewLinkColumn();
                lncol.DataPropertyName = columnname;
                lncol.HeaderText = columnname;
                lncol.Width = 70;
                this.dgrdvReceipt.Columns.Add(lncol);
            }
            this.dgrdvReceipt.DataSource = this.dtblReceipts;
            this.ctrlQReceipt.SeachGridView = this.dgrdvReceipt;
            this.pageReceipt.Text = "对账单制定[" + this.dtblReceipts.Rows.Count + "]";
        }
        private void LoadReconciliation()
        {
            this.dtblReconciliations = this.accReconciliations.GetDataExpressReconciliationsNonReceipt().Tables[0];
            this.dgrdvReconciliation.DataSource = this.dtblReconciliations;
            this.pageReconciliation.Text = "对账单变更[" + this.dtblReconciliations.Rows.Count.ToString() + "]";
        }       
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvReconciliation)
            {
                this.LoadReconciliation();
            }
            if (this.cMenu.SourceControl == this.dgrdvReceipt)
            {
                this.LoadReceipt();
            }
        }


        void dgrdvReconciliation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long ReconciliationID = (long)this.dtblReconciliations.DefaultView[irow]["ReconciliationID"];
            if (this.dgrdvReconciliation.Columns[icol].Name == this.ColumnBtnEdit.Name)
            {
                this.EditReconciliation(ReconciliationID);
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