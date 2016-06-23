using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Define
{
    public partial class FrmPriceType : Form
    {
        private DataTable dtblPriceTypes;
        private JERPData.Finance .PriceType accPriceType;
        public FrmPriceType()
        {
            InitializeComponent();
            this.accPriceType = new JERPData.Finance .PriceType();
            this.dgrdv.AutoGenerateColumns = false;
            this.SetPermit();

        }
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(55);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(56);
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
            this.dtblPriceTypes = this.accPriceType.GetDataPriceType().Tables[0];           
            this.dtblPriceTypes.Columns["PriceTypeCode"].AllowDBNull = false;
            this.dtblPriceTypes.Columns["PriceTypeCode"].Unique  = true;
            this.dtblPriceTypes.Columns["PriceTypeName"].AllowDBNull = false;
            this.dtblPriceTypes.Columns["PriceTypeName"].Unique = true;
            this.dtblPriceTypes.Columns["TaxRate"].DefaultValue = 0;
            this.dgrdv.DataSource = this.dtblPriceTypes;
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
                drow = this.dtblPriceTypes.DefaultView[irow].Row;
            }
            catch 
            {
                return;
            }
            if (drow == null) return;
            if (drow.RowState == DataRowState.Unchanged) return;
            string errormsg = string.Empty;
            if (drow["PriceTypeID"] == DBNull.Value)
            {
                object objPriceTypeID =DBNull .Value ;
                flag = this.accPriceType.InsertPriceType(ref errormsg, ref objPriceTypeID,
                        drow["PriceTypeCode"],
                        drow["PriceTypeName"],
                        drow["TaxRate"]);
                if (flag)
                {
                    drow["PriceTypeID"] = objPriceTypeID;
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
                flag=this.accPriceType.UpdatePriceType(ref errormsg,
                             drow["PriceTypeID"],
                             drow["PriceTypeCode"],
                             drow["PriceTypeName"],
                             drow["TaxRate"]);
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
            DataRow drow = this.dtblPriceTypes  .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["PriceTypeID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }

            int  PriceTypeID = (int)drow["PriceTypeID"];
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accPriceType.DeletePriceType(ref ErrorMsg,
                    PriceTypeID);
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