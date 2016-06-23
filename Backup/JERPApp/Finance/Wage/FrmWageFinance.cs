using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Wage
{
    public partial class FrmWageFinance : Form
    {
        public FrmWageFinance()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accItems = new JERPData.Finance.WageItems();
            this.accNotes = new JERPData.Finance.WageNotes();
            this.NoteEntity = new JERPBiz.Finance.WageNoteEntity();
            this.accWageType = new JERPData.Finance.OtherWageType();
            this.accCashAccount = new JERPData.Finance.CashAccount();
            this.accBankAccount = new JERPData.Finance.BankAccount();
            this.accExpenseAccount = new JERPData.Finance.ExpenseAccount();
            this.MoneyTypeParm = new JERPBiz.Finance.MoneyTypeParm();
            this.SetPermit();
        }        
        private JERPData.Finance.WageNotes accNotes;
        private JERPData.Finance.WageItems accItems;
        private JERPBiz.Finance.WageNoteEntity NoteEntity;
        private JERPData.Finance.OtherWageType accWageType;
        private JERPData.Finance.CashAccount accCashAccount;
        private JERPData.Finance.BankAccount accBankAccount;
        private JERPData.Finance.ExpenseAccount accExpenseAccount;
        private JERPBiz.Finance.MoneyTypeParm MoneyTypeParm;
        private DataTable dtblItems,dtblWageType;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存     
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(621);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(622);
            if (this.enableBrowse)
            {
                this.CreateColumn();
                this.LoadData();
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            }
            this.ColumnbtnFinance.Visible = this.enableSave;     
            if (this.enableSave)
            {
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            }
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
      
      
        private void CreateColumn()
        {
            this.dtblWageType = this.accWageType.GetDataOtherWageType().Tables[0];
            DataGridViewTextBoxColumn txtcol;          
            foreach (DataRow drow in this.dtblWageType.Rows)
            {
                txtcol = new DataGridViewTextBoxColumn();
                txtcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                txtcol.DataPropertyName = drow["WageTypeName"].ToString();
                txtcol.HeaderText = drow["WageTypeName"].ToString();
                txtcol.DefaultCellStyle.Format = "0.#####"; 
                this.dgrdv.Columns.Add(txtcol);
            }
            txtcol = new DataGridViewTextBoxColumn();
            txtcol.Width = 60;
            txtcol.DataPropertyName = "TotalWage";
            txtcol.HeaderText = "合计";
            txtcol.DefaultCellStyle.Format  = "0.#####";      
            this.dgrdv.Columns.Add(txtcol);
            this.ctrlQFind.SeachGridView = this.dgrdv;
        }
       
        public void LoadData()
        {  
            this.dtblItems = this.accItems.GetDataWageItemsPivotWageTypeForFinance().Tables[0];         
            this.dgrdv.DataSource = this.dtblItems;
           
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnFinance.Name)
            {
                DialogResult rut = MessageBox.Show("即将当前员工进行工资结算,请注意结算方式，确认否?", "结算确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rut == DialogResult.No) return;
                DataRow drow = this.dtblItems.DefaultView[irow].Row;
                int BankID = JERPApp.Define.Finance.FrmSettleAMTType.GetBankID();
                int MainMoneyTypeID = this.MoneyTypeParm.GetMainMoneyTypeID();
                string errormsg=string.Empty ;
                this.accItems.UpdateWageItemsForFinance(ref errormsg,
                    drow["ItemID"],
                    BankID,
                    JERPBiz.Frame.UserBiz.PsnID);
                if (BankID == -1)
                {
                    //现金账
                    this.accCashAccount.InsertCashAccountForCredit(
                        ref errormsg,
                        "支付员工[" + drow["PsnName"].ToString () + "]工资",
                        MainMoneyTypeID,
                        drow["TotalWage"],
                        JERPBiz.Frame.UserBiz.PsnID);
                }
                else
                {
                    //银行存款
                    this.accBankAccount.InsertBankAccountForCredit(
                        ref errormsg,
                        "支付员工[" + drow["PsnName"].ToString() + "]工资",
                        BankID,
                        MainMoneyTypeID,
                        drow["TotalWage"],
                        JERPBiz.Frame.UserBiz.PsnID);
                }
                //员工薪酬
                this.accExpenseAccount.InsertExpenseAccountForDebit(
                    ref errormsg,
                   "支付员工[" + drow["PsnName"].ToString() + "]工资",
                    JERPBiz.Finance.ExpenseTypeParm.WageExpense,
                   drow["TotalWage"],
                    JERPBiz.Frame.UserBiz.PsnID);
     
                MessageBox.Show("成功保存当前送货单");
                this.dtblItems.Rows.Remove(drow);
            }
        }
      
    
    
      
    }
}