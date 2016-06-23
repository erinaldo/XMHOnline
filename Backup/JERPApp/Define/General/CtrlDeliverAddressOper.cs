using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.General
{
    public partial class CtrlDeliverAddressOper : UserControl
    {
        public CtrlDeliverAddressOper()
        {
            InitializeComponent();
            this.accDeliverAddress = new JERPData.General.DeliverAddress();
            this.dgrdv.AutoGenerateColumns = false;
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
        }

        private JERPData.General.DeliverAddress accDeliverAddress;
        private DataTable dtblAddress;
        public void DeliverAddressOper(int CompanyID)
        {
            this.dtblAddress = this.accDeliverAddress.GetDataDeliverAddressByCompanyID(CompanyID).Tables[0];          
            this.dtblAddress.Columns["Address"].AllowDBNull = false;
            this.dtblAddress.Columns["Address"].Unique  = true;
            this.dgrdv.DataSource = this.dtblAddress;
        }

        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblAddress .DefaultView[irow].Row;
            if (drow["DeliverAddressID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
          
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，系统不提倡此操作，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {

                flag = this.accDeliverAddress.DeleteDeliverAddress (ref errormsg, drow["DeliverAddressID"]);
                if (!flag)
                {
                    MessageBox.Show(errormsg);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        public void Save(int CompanyID)
        {
            string errormsg = string.Empty;
            bool flag = false;
            foreach (DataRow drow in this.dtblAddress.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow["DeliverAddressID"] == DBNull.Value)
                {
                    object objDeliverAddressID = DBNull.Value;
                    flag=this.accDeliverAddress.InsertDeliverAddress(ref errormsg,
                        ref objDeliverAddressID,
                        CompanyID,
                        drow["Address"],
                        drow["Linkman"],
                        drow["Telephone"],
                        drow["Fax"]);
                    if (flag)
                    {
                        drow["DeliverAddressID"] = objDeliverAddressID;
                    }
                }
                else
                {
                    flag = this.accDeliverAddress.UpdateDeliverAddress(
                        ref errormsg,
                        drow["DeliverAddressID"],
                        drow["Address"],
                        drow["Linkman"],
                        drow["Telephone"],
                        drow["Fax"]);
                }
            }

        }
  
    }
}
