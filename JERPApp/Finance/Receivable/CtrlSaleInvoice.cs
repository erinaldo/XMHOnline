using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Receivable
{
    public partial class CtrlSaleInvoice : UserControl
    {
        public CtrlSaleInvoice()
        {
            InitializeComponent();

            this.dgrdvNonInvoice.AutoGenerateColumns = false;
            this.ctrlQDeliver.SeachGridView = this.dgrdvNonInvoice;
            this.dgrdvInvoice.AutoGenerateColumns = false;
            this.ctrlQInvoice.SeachGridView = this.dgrdvInvoice;

            this.accInvoices = new JERPData.Product.SaleInvoices();
            this.accDeliverItems = new JERPData.Product.SaleDeliverItems();

            this.dgrdvNonInvoice.ContextMenuStrip = this.cMenu;
            this.dgrdvInvoice.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);

            this.dgrdvNonInvoice.CellContentClick += new DataGridViewCellEventHandler(dgrdvNonInvoice_CellContentClick);
            this.dgrdvInvoice.CellContentClick += new DataGridViewCellEventHandler(dgrdvInvoice_CellContentClick);
        }

        private JERPData.Product.SaleInvoices accInvoices;
        private JERPData.Product.SaleDeliverItems accDeliverItems;
        private DataTable dtblNonInvoices, dtblInvoices;
        private FrmSaleInvoiceOper frmOper;
        private Report.Bill.Product.FrmSaleInvoice frmDetail;
        public delegate void AffterRefreshDelegate(int count);
        private AffterRefreshDelegate affterRefresh;
        public event AffterRefreshDelegate AffterRefresh
        {
            add
            {
                affterRefresh += value;
            }
            remove
            {
                affterRefresh -= value;
            }
        }
        public void LoadData()
        {
            this.dtblNonInvoices = this.accDeliverItems.GetDataSaleDeliverItemsNonInvoicePivotMonthAMT().Tables[0];
            while (this.dgrdvNonInvoice.ColumnCount > 4)
            {
                this.dgrdvNonInvoice.Columns.RemoveAt(4);
            }
            DataGridViewLinkColumn lncol;
            string columnname = string.Empty;
            for (int j = 8; j < this.dtblNonInvoices.Columns.Count; j++)
            {
                columnname = this.dtblNonInvoices.Columns[j].ColumnName;
                lncol = new DataGridViewLinkColumn();
                lncol.DataPropertyName = columnname;
                lncol.HeaderText = columnname;
                lncol.Width = 70;

                this.dgrdvNonInvoice.Columns.Add(lncol);
            }
            this.dgrdvNonInvoice.DataSource = this.dtblNonInvoices;  
            this.dtblInvoices = this.accInvoices.GetDataSaleInvoicesNonConfirm().Tables[0];
            this.dgrdvInvoice.DataSource = this.dtblInvoices; 
            if (this.affterRefresh != null) this.affterRefresh(this.dtblNonInvoices .Rows .Count);
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        void dgrdvNonInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvNonInvoice.Columns[icol].GetType().Equals(typeof(DataGridViewLinkColumn)))
            {

                DataRow drow = this.dtblNonInvoices.DefaultView[irow].Row;
                int CompanyID = (int)drow["CompanyID"];
                int FinanceAddressID = (int)drow["FinanceAddressID"];
                int MoneyTypeID = (int)drow["MoneyTypeID"];
                int InvoiceTypeID = (int)drow["InvoiceTypeID"];
                string columnname = this.dgrdvNonInvoice.Columns[icol].DataPropertyName;
                int Year = int.Parse(columnname.Split('-')[0]);
                int Month = int.Parse(columnname.Split('-')[1]);
                long InvoiceID = -1;
                this.accInvoices.GetParmSaleInvoicesInvoiceID(
                    Year, Month,
                    CompanyID,
                    FinanceAddressID,
                    MoneyTypeID,
                    InvoiceTypeID,
                    ref InvoiceID);
                DialogResult rut;
                if (InvoiceID > -1)
                {
                    rut = MessageBox.Show("本月的此类发票已制定,是否加入此发票单?是,加入此单，否，新增发票", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rut == DialogResult.No)
                    {
                        InvoiceID = -1;
                    }

                }
                if (InvoiceID == -1)
                {
                    string InvoiceName = Year.ToString() + "年" + Month.ToString() + "月" +
                    "发票单";
                    DateTime DateSettle = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
                    rut = MessageBox.Show("您将生成当前发票单，确认否?", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rut == DialogResult.Yes)
                    {
                        string errormsg = string.Empty;
                        bool flag = false;
                        object objInvoiceID = DBNull.Value;
                        flag = this.accInvoices.InsertSaleInvoices(ref errormsg,
                            ref objInvoiceID,
                            InvoiceName,
                            Year,
                            Month,
                            DateTime.Now.Date,
                            CompanyID,
                            FinanceAddressID,
                            MoneyTypeID,
                            InvoiceTypeID,
                            JERPBiz.Frame.UserBiz.PsnID);
                        if (flag)
                        {
                            InvoiceID = (long)objInvoiceID;
                        }
                        else
                        {
                            MessageBox.Show(errormsg, "出错啦!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                if (InvoiceID > -1)
                {
                    this.InvoiceEdit(InvoiceID);
                }
            }
        }  
        private void InvoiceEdit(long InvoiceID)
        {

            if (this.frmOper == null)
            {
                this.frmOper = new FrmSaleInvoiceOper();
                new FrmStyle(this.frmOper).SetPopFrmStyle(this.ParentForm );
                this.frmOper.AffterSave += this.LoadData ;

            }
            this.frmOper.Edit(InvoiceID);
            this.frmOper.ShowDialog();
        }
        void dgrdvInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            long InvoiceID = (long)this.dtblInvoices.DefaultView[irow]["InvoiceID"];
            if (this.dgrdvInvoice.Columns[icol].Name == this.ColumnbtnEdit.Name)
            {
                this.InvoiceEdit(InvoiceID);
            }
            if (this.dgrdvInvoice.Columns[icol].Name == this.ColumnInvoiceCode.Name)
            {
                if (this.frmDetail == null)
                {
                    this.frmDetail = new JERPApp.Finance.Report.Bill.Product.FrmSaleInvoice();
                    new FrmStyle(this.frmDetail).SetPopFrmStyle(this.ParentForm);

                }
                this.frmDetail.DetailNote(InvoiceID);
                this.frmDetail.ShowDialog();
            }
        }
    }
}
