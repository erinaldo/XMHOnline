using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmAccountBookBalance : Form
    {
        public FrmAccountBookBalance()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accAccountBook = new JERPData.Finance.AccountBook();
            this.SetPermit();
        }
        private JERPData.Finance.AccountBook accAccountBook;
        private FrmAdvancePayingAccountBalance frmAdvancePayingBalance;
        private FrmAdvanceReceiveAccountBalance frmAdvanceReceiveBalance;
        private FrmExpressPayableAccountBalance frmExpressPayableBalance;
        private FrmExpressReceivableAccountBalance frmExpressReceivableBalance;
        private FrmPayableAccountBalance frmPayableBalance;
        private FrmReceivableAccountBalance frmReceivableBalance;
        private FrmBankAccountBalance frmBankBalance;
        private FrmCashAccountBalance frmCashBalance;
        private FrmMtrStoreBalance frmMtrBalance;
        private FrmOtherResStoreBalance frmOtherResBalance; 
        private FrmPrdStoreBalance frmPrdBalance;
        private FrmExpenseAccountRpt frmExpenseRpt;
        private FrmRevenueAccountRpt frmRevenuRpt;
        private FrmExpenseAccountAllRecord frmExpenseRecord;
        private FrmRevenueAccountAllRecord frmRevenueRecord;
        private int iCash = 1;
        private int iBank = 2;
        private int iReceivable = 3;
        private int iExpressReceivable = 4;
        private int iAdvPaying = 5;
        private int iPrdStore = 6;
        private int iMtrStore = 7;
        private int iOtherResStore = 8; 
        private int iAdvReceive = 9;
        private int iPayable = 10;
        private int iExpressPayable = 11;
        private int iExpenseMonth = 12;
        private int iRevenueMonth = 13;
        private int iExpenseYear = 15;
        private int iRevenueYear = 16;
        private DataTable dtblAccountBook;
        //权限码
        private bool enableBrowse = false;//浏览 
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(281);
            if (this.enableBrowse)
            {
                this.LoadData();
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                for (int j = 0; j < this.dgrdv.Columns.Count; j++)
                {
                    this.dgrdv.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                this.btnExport.Click += new EventHandler(btnExport_Click);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            }
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblAccountBook = this.accAccountBook.GetDataAccountBookBalance().Tables[0];         
            this.dgrdv.DataSource = this.dtblAccountBook;
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if(this.dgrdv .Columns[icol].GetType ().Equals (typeof (DataGridViewLinkColumn )))
            {
                DataRow drow=this.dtblAccountBook .DefaultView [irow].Row ;
                int AccountTypeID=(int)drow["AccountTypeID"];
                if(AccountTypeID ==this.iCash )
                {
                    if(frmCashBalance ==null)
                    {
                        frmCashBalance =new FrmCashAccountBalance ();
                        new FrmStyle (frmCashBalance ).SetPopFrmStyle (this );                      
                    }
                    frmCashBalance.LoadData  ();
                    frmCashBalance .ShowDialog ();
                }
                if(AccountTypeID ==this.iBank  )
                {
                    if(frmBankBalance ==null)
                    {
                        frmBankBalance =new FrmBankAccountBalance ();
                        new FrmStyle (frmBankBalance ).SetPopFrmStyle (this );                      
                    }
                    frmBankBalance.LoadData();
                    frmBankBalance .ShowDialog ();
                }
                if(AccountTypeID ==this.iReceivable   )
                {
                    if(frmReceivableBalance  ==null)
                    {
                        frmReceivableBalance =new FrmReceivableAccountBalance ();
                        new FrmStyle (frmReceivableBalance ).SetPopFrmStyle (this );                      
                    }
                    frmReceivableBalance.LoadData();
                    frmReceivableBalance .ShowDialog ();
                }
                if(AccountTypeID ==this.iExpressReceivable   )
                {
                    if(frmExpressReceivableBalance  ==null)
                    {
                        frmExpressReceivableBalance =new FrmExpressReceivableAccountBalance ();
                        new FrmStyle (frmExpressReceivableBalance ).SetPopFrmStyle (this );                      
                    }
                    frmExpressReceivableBalance.LoadData  ();
                    frmExpressReceivableBalance .ShowDialog ();
                }
                if(AccountTypeID ==this.iAdvPaying)
                {
                    if(frmAdvancePayingBalance   ==null)
                    {
                        frmAdvancePayingBalance =new FrmAdvancePayingAccountBalance ();
                        new FrmStyle (frmAdvancePayingBalance ).SetPopFrmStyle (this );                      
                    }
                    frmAdvancePayingBalance.LoadData();
                    frmAdvancePayingBalance .ShowDialog ();
                }
                if (AccountTypeID == this.iPrdStore)
                {
                    if (frmPrdBalance == null)
                    {
                        frmPrdBalance = new FrmPrdStoreBalance();
                        new FrmStyle(frmPrdBalance).SetPopFrmStyle(this);
                    }
                    frmPrdBalance.LoadData();
                    frmPrdBalance.ShowDialog();
                }
                if (AccountTypeID == this.iMtrStore)
                {
                    if (frmMtrBalance == null)
                    {
                        frmMtrBalance = new FrmMtrStoreBalance();
                        new FrmStyle(frmMtrBalance).SetPopFrmStyle(this);
                    }
                    frmMtrBalance.LoadData();
                    frmMtrBalance.ShowDialog();
                }
                if (AccountTypeID == this.iOtherResStore)
                {
                    if (frmOtherResBalance == null)
                    {
                        frmOtherResBalance = new FrmOtherResStoreBalance();
                        new FrmStyle(frmOtherResBalance).SetPopFrmStyle(this);
                    }
                    frmOtherResBalance.LoadData();
                    frmOtherResBalance.ShowDialog();
                }
                
                if(AccountTypeID ==this.iAdvReceive)
                {
                    if(frmAdvanceReceiveBalance   ==null)
                    {
                        frmAdvanceReceiveBalance =new FrmAdvanceReceiveAccountBalance ();
                        new FrmStyle (frmAdvanceReceiveBalance ).SetPopFrmStyle (this );                      
                    }
                    frmAdvanceReceiveBalance.LoadData();
                    frmAdvanceReceiveBalance .ShowDialog ();
                }
                if(AccountTypeID ==this.iPayable )
                {
                    if(frmPayableBalance    ==null)
                    {
                        frmPayableBalance =new FrmPayableAccountBalance ();
                        new FrmStyle (frmPayableBalance ).SetPopFrmStyle (this );                      
                    }
                    frmPayableBalance.LoadData  ();
                    frmPayableBalance .ShowDialog ();
                }
                if(AccountTypeID ==this.iExpressPayable  )
                {
                    if(frmExpressPayableBalance==null)
                    {
                        frmExpressPayableBalance =new FrmExpressPayableAccountBalance ();
                        new FrmStyle (frmExpressPayableBalance ).SetPopFrmStyle (this );                      
                    }
                    frmExpressPayableBalance.LoadData();
                    frmExpressPayableBalance .ShowDialog ();
                }
                if (AccountTypeID == this.iExpenseMonth)
                {
                    if (frmExpenseRecord  == null)
                    {
                        frmExpenseRecord = new FrmExpenseAccountAllRecord();
                        new FrmStyle(frmExpenseRecord).SetPopFrmStyle(this);
                    }
                    frmExpenseRecord.AccountRecord (DateTime .Now .Year ,DateTime .Now .Month);
                    frmExpenseRecord.ShowDialog();
                }
                if (AccountTypeID == this.iRevenueMonth)
                {
                    if (frmRevenueRecord == null)
                    {
                        frmRevenueRecord = new FrmRevenueAccountAllRecord();
                        new FrmStyle(frmRevenueRecord).SetPopFrmStyle(this);
                    }
                    frmRevenueRecord.AccountRecord(DateTime.Now.Year, DateTime.Now.Month);
                    frmRevenueRecord.ShowDialog();
                }
                if (AccountTypeID == this.iExpenseYear)
                {
                    if (frmExpenseRpt == null)
                    {
                        frmExpenseRpt = new FrmExpenseAccountRpt();
                        new FrmStyle(frmExpenseRpt).SetPopFrmStyle(this);
                    }
                    frmExpenseRpt.LoadData();
                    frmExpenseRpt .ShowDialog ();
                }
                if (AccountTypeID == this.iRevenueYear)
                {
                    if (frmRevenuRpt == null)
                    {
                        frmRevenuRpt = new FrmRevenueAccountRpt();
                        new FrmStyle(frmRevenuRpt).SetPopFrmStyle(this);
                    }
                    frmRevenuRpt.LoadData();
                    frmRevenuRpt.ShowDialog();
                }
            }
        }


        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "账目一览表");
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