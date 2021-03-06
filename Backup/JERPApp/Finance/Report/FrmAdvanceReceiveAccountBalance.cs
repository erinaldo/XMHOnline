using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmAdvanceReceiveAccountBalance : Form
    {
        public FrmAdvanceReceiveAccountBalance()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accAccount = new JERPData.Finance.AdvanceReceiveAccount();
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.btnExport.Click += new EventHandler(btnExport_Click);
        }
    
        private JERPData.Finance.AdvanceReceiveAccount accAccount;
        private DataTable dtblBalance;
        private FrmAdvanceReceiveAccountRecord frmRecord;
        public void LoadData()
        {
            this.dtblBalance = this.accAccount.GetDataAdvanceReceiveAccount().Tables[0];
            this.dgrdv.DataSource = this.dtblBalance;
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnBalanceAMT.Name)
            {
                int CompanyID = (int)this.dtblBalance.DefaultView[irow]["CompanyID"];
                int MoneyTypeID=(int)this.dtblBalance .DefaultView [irow]["MoneyTypeID"];
                if (frmRecord == null)
                {
                    frmRecord = new FrmAdvanceReceiveAccountRecord();
                    new FrmStyle(frmRecord).SetPopFrmStyle(this);                  
                }
                frmRecord.LoadRecord(CompanyID,MoneyTypeID);
                frmRecord.ShowDialog();
            }
        }

        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", this.Text);
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