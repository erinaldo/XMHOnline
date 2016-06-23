using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Account
{
    public partial class FrmExpenseAccountCheck : Form
    {
        public FrmExpenseAccountCheck()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accAccount = new JERPData.Finance.ExpenseAccount();
            this.accExpenseTypes = new JERPData.Finance.ExpenseType();
            this.SetColumnSrc();
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);      
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }
        private JERPData.Finance.ExpenseAccount   accAccount;
        private JERPData.Finance.ExpenseType  accExpenseTypes;
        private DataTable dtblAccountAMT, dtblExpenseTypes;

        public void AccountCheck()
        {
            this.LoadData();
        }

        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnExpenseTypeID  .Name)
            {

                object objExpenseTypeID = this.dgrdv[this.ColumnExpenseTypeID.Name, irow].Value;
                if ((objExpenseTypeID != DBNull.Value) && (objExpenseTypeID != null))
                {
                    decimal BalanceAMT = 0;
                    this.accAccount.GetParmExpenseAccountBalanceAMT((int)objExpenseTypeID,
                        ref BalanceAMT);
                    this.dgrdv[this.ColumnBalanceAMT.Name, irow].Value = BalanceAMT;
                }
            }
        }

        private void SetColumnSrc()
        {
          
            this.dtblExpenseTypes = this.accExpenseTypes.GetDataExpenseType ().Tables[0];
            this.ColumnExpenseTypeID.DataSource = this.dtblExpenseTypes;
            this.ColumnExpenseTypeID.ValueMember = "ExpenseTypeID";
            this.ColumnExpenseTypeID.DisplayMember = "ExpenseTypeName";


        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblAccountAMT = new DataTable();
            this.dtblAccountAMT.Columns.Add("ExpenseTypeID", typeof(int));
            this.dtblAccountAMT.Columns.Add("BalanceAMT", typeof(decimal));
            this.dtblAccountAMT.Columns.Add("CheckAMT", typeof(decimal));
            this.dtblAccountAMT.Columns["ExpenseTypeID"].Unique = true;
            this.dgrdv.DataSource = this.dtblAccountAMT;

        }
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                grow.ErrorText = string.Empty;
                if ((grow.Cells[this.ColumnExpenseTypeID.Name].Value == DBNull.Value)
                    || (grow.Cells[this.ColumnCheckAMT.Name].Value == DBNull.Value))
                {
                    grow.ErrorText = "此行输入不全面";
                }
            }
        }
        private bool ValidateData()
        {
            if (this.dtblAccountAMT.Select("CheckAMT is  null or ExpenseTypeID is null", "").Length > 0)
            {
                MessageBox.Show("填写不正确");
                return false;
            }
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            DialogResult rut = MessageBox.Show("将对账目进行保存，确认否?", "保存确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rut == DialogResult.No) return;
            string errormsg=string.Empty ;
            bool flag = false;
            foreach (DataRow drow in this.dtblAccountAMT.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow["CheckAMT"] == DBNull.Value) continue;
                flag=this.accAccount.InsertExpenseAccountForAdjust  (ref errormsg,
                    drow["ExpenseTypeID"],
                    drow["CheckAMT"],
                    JERPBiz.Frame.UserBiz.PsnID);
                if (!flag)
                {
                    MessageBox.Show(errormsg);
                }
            }
            this.LoadData();
            MessageBox.Show("成功保存当前账目盘点");
        }
    }
}