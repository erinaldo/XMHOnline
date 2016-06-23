using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Define
{
    public partial class FrmMoneyType : Form
    {
        private DataTable dtblMoneyType;
        private JERPData.Finance.MoneyType accMoneyType;
        public FrmMoneyType()
        {
            InitializeComponent();
            this.accMoneyType = new JERPData.Finance.MoneyType();
            this.dgrdv.AutoGenerateColumns = false;
            this.SetPermit();
          
        }
      
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(15);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(16);
            if (this.enableBrowse)
            {
                //加载数据
                LoadData();
               
            }
            this.dgrdv.AllowUserToAddRows = enableSave;
            this.dgrdv.ReadOnly = !enableSave;           
            if (this.enableSave)
            {               
                this.dgrdv .UserDeletingRow +=new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
                this.btnSave .Click +=new EventHandler(btnSave_Click);
            }


        }
        private void LoadData()
        {
            this.dtblMoneyType = this.accMoneyType.GetDataMoneyType().Tables[0];
            this.dtblMoneyType.Columns["MoneyTypeCode"].AllowDBNull = false;
            this.dtblMoneyType.Columns["MoneyTypeCode"].Unique  = true;
            this.dtblMoneyType.Columns["MoneyTypeName"].AllowDBNull = false;
            this.dtblMoneyType.Columns["MoneyTypeName"].Unique = true;
            this.dtblMoneyType.Columns["MainMoneyFlag"].DefaultValue  = false;
            this.dtblMoneyType.Columns["ExchangeRate"].DefaultValue = 1;
            this.dgrdv.DataSource = this.dtblMoneyType;
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
        bool ValidateData()
        {

            DataRow[] drows = this.dtblMoneyType.Select("MainMoneyFlag=1", "", DataViewRowState.CurrentRows);
            if (drows.Length != 1)
            {
                MessageBox.Show("对不起,本币不能为空,且仅一个");
                return false;
            }

            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;
            bool flag = true;
            string errormsg = string.Empty;
            foreach (DataRow drow in this.dtblMoneyType.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow["MoneyTypeID"] == DBNull.Value)
                {
                    object objMoneyTypeID = 0;
                    flag = this.accMoneyType.InsertMoneyType(
                            ref errormsg,
                            ref objMoneyTypeID,
                            drow["MoneyTypeCode"],
                            drow["MoneyTypeName"],
                            drow["MainMoneyFlag"],
                            drow["ExchangeRate"]);
                    if (flag)
                    {
                        drow["MoneyTypeID"] = objMoneyTypeID;
                    }
                }
                else
                {
                    flag = this.accMoneyType.UpdateMoneyType(
                            ref errormsg,
                          drow["MoneyTypeID"],
                          drow["MoneyTypeCode"],
                          drow["MoneyTypeName"],
                          drow["MainMoneyFlag"],
                          drow["ExchangeRate"]);
                }
                if (flag)
                {
                    drow.AcceptChanges();
                }
                else
                {
                    MessageBox.Show(errormsg);
                }
            }
            MessageBox.Show("成功保存当前设置");
        }

        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblMoneyType  .DefaultView[irow].Row;
            if (drow["MoneyTypeID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
            int  MoneyTypeID = (int)drow["MoneyTypeID"];
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {

                flag = this.accMoneyType.DeleteMoneyType(ref errormsg,MoneyTypeID);
                if (!flag)
                {
                   MessageBox .Show (errormsg );
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
    
    }
}