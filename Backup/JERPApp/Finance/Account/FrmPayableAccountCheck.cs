using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Account
{
    public partial class FrmPayableAccountCheck : Form
    {
        public FrmPayableAccountCheck()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accPayableAMT = new JERPData.Finance.PayableAccount();
            this.accMoneyTypes = new JERPData.Finance.MoneyType();
            this.accSupplier = new JERPData.General.Supplier();
            this.SetColumnSrc();
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }
        private JERPData.Finance.PayableAccount accPayableAMT;
        private JERPData.Finance.MoneyType accMoneyTypes;
        private JERPData.General.Supplier  accSupplier;
        private DataTable dtblAccount,dtblSupplier, dtblMoneyTypes;
        public void AccountCheck()
        {
            this.LoadData();
        }

        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if ((this.dgrdv.Columns[icol].Name == this.ColumnCompanyID.Name)
                || (this.dgrdv.Columns[icol].Name == this.ColumnMoneyTypeID.Name))
            {
                object objCompanyID = this.dgrdv[this.ColumnCompanyID.Name, irow].Value;
                object objMoneyTypeID = this.dgrdv[this.ColumnMoneyTypeID.Name, irow].Value;
                if ((objCompanyID != DBNull.Value) && (objCompanyID != null)
                    && (objMoneyTypeID != DBNull.Value) && (objMoneyTypeID != null))
                {
                    decimal BalanceAMT = 0;
                    this.accPayableAMT.GetParmPayableAccountBalanceAMT((int)objCompanyID, (int)objMoneyTypeID,
                        ref BalanceAMT);
                    this.dgrdv[this.ColumnBalanceAMT.Name, irow].Value = BalanceAMT;
                }
            }
        }

        private void SetColumnSrc()
        {
            this.dtblSupplier = this.accSupplier.GetDataSupplier ().Tables[0];
            this.dtblSupplier .Columns .Add ("exp",typeof (string),"ISNULL(CompanyCode,'')+' '+ISNULL(CompanyAbbName,'')");
            this.ColumnCompanyID.DataSource = this.dtblSupplier;
            this.ColumnCompanyID.ValueMember = "CompanyID";
            this.ColumnCompanyID.DisplayMember = "exp";

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
            this.dtblAccount = new DataTable();
            this.dtblAccount.Columns.Add("CompanyID", typeof(int));
            this.dtblAccount.Columns.Add("MoneyTypeID", typeof(int));
            this.dtblAccount.Columns.Add("BalanceAMT", typeof(decimal));
            this.dtblAccount.Columns.Add("CheckAMT", typeof(decimal));
            this.dtblAccount.Columns["MoneyTypeID"].DefaultValue = 1;
            this.dtblAccount.Constraints.Add(new UniqueConstraint(new DataColumn[] {this.dtblAccount .Columns ["CompanyID"],
                    this.dtblAccount .Columns ["MoneyTypeID"] }, false));
            this.dgrdv.DataSource = this.dtblAccount;
            
        }
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                grow.ErrorText = string.Empty;
                if ((grow.Cells[this.ColumnCompanyID.Name].Value == DBNull.Value)
                    || (grow.Cells[this.ColumnMoneyTypeID.Name].Value == DBNull.Value)
                    || (grow.Cells[this.ColumnCheckAMT.Name].Value == DBNull.Value))
                {
                    grow.ErrorText = "此行输入不全面";
                }
            }
        }
        private bool ValidateData()
        {
            if (this.dtblAccount.Select("CheckAMT is  null or CompanyID is null or MoneyTypeID is null", "").Length > 0)
            {
                MessageBox.Show("填写不正确");
                return false;
            }
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            DialogResult rut = MessageBox.Show("将对预收款进行保存，确认否?", "保存确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rut == DialogResult.No) return;
            string errormsg=string.Empty ;
            bool flag = false;
            foreach (DataRow drow in this.dtblAccount.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow["CheckAMT"] == DBNull.Value) continue;
                flag=this.accPayableAMT.InsertPayableAccountForAdjust (ref errormsg,
                    drow["CompanyID"],
                    drow["MoneyTypeID"],
                    drow["CheckAMT"],
                    JERPBiz.Frame.UserBiz.PsnID);
                if (!flag)
                {
                    MessageBox.Show(errormsg);
                }
            }
            this.LoadData();
            MessageBox.Show("成功保存当前应付款盘点");
        }
    }
}