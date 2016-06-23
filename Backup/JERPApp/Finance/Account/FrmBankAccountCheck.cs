using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Account
{
    public partial class FrmBankAccountCheck : Form
    {
        public FrmBankAccountCheck()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accCashAMT = new JERPData.Finance.BankAccount();
            this.accBank = new JERPData.Finance.Bank();
            this.accMoneyTypes = new JERPData.Finance.MoneyType();
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.SetColumnSrc();
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }
        private JERPData.Finance.BankAccount  accCashAMT;
        private JERPData.Finance.Bank accBank;
        private JERPData.Finance.MoneyType accMoneyTypes;
        private DataTable dtblAccountAMT, dtblBank,dtblMoneyTypes;
        public void AccountCheck()
        {
            this.LoadData();
        }

        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if ((this.dgrdv.Columns[icol].Name == this.ColumnMoneyTypeID.Name)
                ||(this.dgrdv.Columns[icol].Name == this.ColumnBankID.Name))
            {
                object objBankID = this.dgrdv[this.ColumnBankID.Name, irow].Value;
                object objMoneyTypeID = this.dgrdv[this.ColumnMoneyTypeID.Name, irow].Value;
                if ((objMoneyTypeID != DBNull.Value) && (objMoneyTypeID != null)
                    && (objBankID != DBNull.Value) && (objBankID != null))
                {
                    decimal BalanceAMT = 0;
                    this.accCashAMT.GetParmBankAccountBalanceAMT  ((int)objBankID ,(int)objMoneyTypeID,
                        ref BalanceAMT);
                    this.dgrdv[this.ColumnBalanceAMT.Name, irow].Value = BalanceAMT;
                }
            }
        }

        private void SetColumnSrc()
        {
            this.dtblBank = this.accBank.GetDataBank().Tables[0];
            this.dtblBank.Columns.Add("exp", typeof(string), "ISNULL(BankName,'')+ISNULL(BankCode,'')");
            this.ColumnBankID.DataSource = this.dtblBank;
            this.ColumnBankID.ValueMember = "BankID";
            this.ColumnBankID.DisplayMember = "exp";
          
            this.dtblMoneyTypes = this.accMoneyTypes.GetDataMoneyType().Tables[0];
            this.dtblMoneyTypes.Columns.Add("exp", typeof(string), "ISNULL(MoneyTypeCode,'')+' '+ISNULL(MoneyTypeName,'')");
            this.ColumnMoneyTypeID.DataSource = this.dtblMoneyTypes;
            this.ColumnMoneyTypeID.ValueMember = "MoneyTypeID";
            this.ColumnMoneyTypeID.DisplayMember = "exp";


        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblAccountAMT = new DataTable();
            this.dtblAccountAMT.Columns.Add("BankID", typeof(int));
            this.dtblAccountAMT.Columns.Add("MoneyTypeID", typeof(int));
            this.dtblAccountAMT.Columns.Add("BalanceAMT", typeof(decimal));
            this.dtblAccountAMT.Columns.Add("CheckAMT", typeof(decimal));

            this.dgrdv.DataSource = this.dtblAccountAMT;

        }
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                grow.ErrorText = string.Empty;
                if ((grow.Cells[this.ColumnBankID.Name].Value == DBNull.Value)
                    ||(grow.Cells[this.ColumnMoneyTypeID.Name].Value == DBNull.Value)
                    || (grow.Cells[this.ColumnCheckAMT.Name].Value == DBNull.Value))
                {
                    grow.ErrorText = "此行输入不全面";
                }
            }
        }
        private bool ValidateData()
        {
            if (this.dtblAccountAMT.Select("BankID is null or CheckAMT is  null or MoneyTypeID is null", "").Length > 0)
            {
                MessageBox.Show("填写不正确");
                return false;
            }
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            DialogResult rut = MessageBox.Show("将对银行存款款进行保存，确认否?", "保存确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rut == DialogResult.No) return;
            string errormsg=string.Empty ;
            bool flag = false;
            foreach (DataRow drow in this.dtblAccountAMT.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow["CheckAMT"] == DBNull.Value) continue;
                flag=this.accCashAMT.InsertBankAccountForAdjust (ref errormsg,
                    drow["BankID"],
                    drow["MoneyTypeID"],
                    drow["CheckAMT"],
                    JERPBiz.Frame.UserBiz.PsnID);
                if (!flag)
                {
                    MessageBox.Show(errormsg);
                }
            }
            this.LoadData();
            MessageBox.Show("成功保存当前预付款盘点");
        }
    }
}