using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Define
{
    public partial class FrmBank : Form
    {
      
        public FrmBank()
        {
            InitializeComponent();
            this.accBank = new JERPData.Finance .Bank();
            this.dgrdv.AutoGenerateColumns = false;
            this.SetPermit();

        }
        private JERPData.Finance.Bank accBank;
        private DataTable dtblBanks;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(17);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(18);
            if (this.enableBrowse)
            {
                //加载数据
                LoadData();
            }
            this.dgrdv.AllowUserToAddRows = enableSave;
            this.dgrdv.AllowUserToDeleteRows = enableSave;
            this.dgrdv.ReadOnly = !enableSave;
            if (this.enableSave)
            {
                this.dgrdv.RowValidated += new DataGridViewCellEventHandler(dgrdv_RowValidated);
                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);

            }


        }
       
        private void LoadData()
        {
            this.dtblBanks = this.accBank.GetDataBank().Tables[0];           
            this.dtblBanks.Columns["BankCode"].AllowDBNull = false;
            this.dtblBanks.Columns["BankName"].AllowDBNull = false;
            UniqueConstraint c = new UniqueConstraint("c", new DataColumn[] { this.dtblBanks .Columns["BankCode"],
            this.dtblBanks .Columns ["BankName"]});
            this.dtblBanks.Constraints.Add(c);
            this.dgrdv.DataSource = this.dtblBanks;
        }

       
  

        void dgrdv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
          
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            bool flag = false;
            DataRow drow = null;
            try
            {
                drow = this.dtblBanks.DefaultView[irow].Row;
            }
            catch 
            {
                return;
            }
            if (drow == null) return;
            if (drow.RowState == DataRowState.Unchanged) return;
            string errormsg = string.Empty;
            if (drow["BankID"] == DBNull.Value)
            {
                object objBankID =DBNull .Value ;
                flag = this.accBank.InsertBank(ref errormsg, ref objBankID,
                        drow["BankName"],
                        drow["BankCode"]);
                if (flag)
                {
                    drow["BankID"] = objBankID;
                    if(this.affterSave !=null) this.affterSave ();
                }
                else
                {
                    MessageBox.Show(errormsg);
                    this.LoadData();
                }
            }
            else
            {
                flag=this.accBank.UpdateBank(ref errormsg,
                        drow["BankID"],
                        drow["BankName"],
                        drow["BankCode"]);
                if (flag)
                {
                    if (this.affterSave != null) this.affterSave();
                }
                else
                {
                    MessageBox.Show(errormsg);
                    this.LoadData();
                }

            }
        }     

        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblBanks  .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["BankID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }

            int  BankID = (int)drow["BankID"];
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accBank.DeleteBank(ref ErrorMsg,
                    BankID);
                if (flag)
                {
                    if (this.affterSave != null)
                    {
                        this.affterSave();
                    }
                }
                else
                {
                   MessageBox .Show (ErrorMsg );
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        public delegate void AffterSaveDelegate();
        private AffterSaveDelegate affterSave;
        public event AffterSaveDelegate AffterSave
        {
            add
            {
                affterSave += value;
            }
            remove
            {
                affterSave -= value;
            }
        }
    }
}