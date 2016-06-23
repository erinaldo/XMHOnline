using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Define
{
    public partial class FrmRevenueType : Form
    {
   
        public FrmRevenueType()
        {
            InitializeComponent();
            this.accRevenueType = new JERPData.Finance.RevenueType();
            this.dgrdv.AutoGenerateColumns = false;
            this.SetPermit();

        }
        private DataTable dtblRevenueType;
        private JERPData.Finance.RevenueType accRevenueType;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(65);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(66);
            if (this.enableBrowse)
            {
                //加载数据
                LoadData();
                this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            }
            this.dgrdv.AllowUserToAddRows = enableSave;
            this.dgrdv.ReadOnly = !enableSave;
            if (this.enableSave)
            {
                this.dgrdv.RowValidated += new DataGridViewCellEventHandler(dgrdv_RowValidated);

            }
        }

        private void LoadData()
        {
            this.dtblRevenueType = this.accRevenueType.GetDataRevenueType().Tables[0];          
            this.dtblRevenueType.Columns["RevenueTypeName"].AllowDBNull = false;
            this.dtblRevenueType.Columns["RevenueTypeName"].Unique = true;
            this.dtblRevenueType.Columns["LockFlag"].DefaultValue= false; 
            this.dgrdv.DataSource = this.dtblRevenueType;
        }

        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv .Rows )
            {
                if (grow.IsNewRow) continue;
                grow.Cells[this.ColumnRevenueTypeName.Name].ReadOnly = (bool)grow.Cells[this.ColumnLockFlag.Name].Value;
                
            }
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
                drow = this.dtblRevenueType.DefaultView[irow].Row;
            }
            catch 
            {
                return;
            }
            if (drow == null) return;
            if (drow.RowState == DataRowState.Unchanged) return;
            string errormsg = string.Empty;
            if (drow["RevenueTypeID"] == DBNull.Value)
            {
                object objRevenueTypeID =DBNull .Value ;
                flag = this.accRevenueType.InsertRevenueType(ref errormsg, ref objRevenueTypeID,
                        drow["RevenueTypeName"]);
                if (flag)
                {
                    drow["RevenueTypeID"] = objRevenueTypeID;
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
                flag=this.accRevenueType.UpdateRevenueType(ref errormsg,
                             drow["RevenueTypeID"],
                             drow["RevenueTypeName"]);
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