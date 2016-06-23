using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Define
{
    public partial class FrmExpenseType : Form
    {
   
        public FrmExpenseType()
        {
            InitializeComponent();
            this.accExpenseType = new JERPData.Finance.ExpenseType();
            this.dgrdv.AutoGenerateColumns = false;
            this.SetPermit();

        }
        private DataTable dtblExpenseType;
        private JERPData.Finance.ExpenseType accExpenseType;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(67);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(68);
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
            this.dtblExpenseType = this.accExpenseType.GetDataExpenseType().Tables[0];          
            this.dtblExpenseType.Columns["ExpenseTypeName"].AllowDBNull = false;
            this.dtblExpenseType.Columns["ExpenseTypeName"].Unique = true;
            this.dtblExpenseType.Columns["LockFlag"].DefaultValue= false; 
            this.dgrdv.DataSource = this.dtblExpenseType;
        }

        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv .Rows )
            {
                if (grow.IsNewRow) continue;
                grow.Cells[this.ColumnExpenseTypeName.Name].ReadOnly = (bool)grow.Cells[this.ColumnLockFlag.Name].Value;
                
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
                drow = this.dtblExpenseType.DefaultView[irow].Row;
            }
            catch 
            {
                return;
            }
            if (drow == null) return;
            if (drow.RowState == DataRowState.Unchanged) return;
            string errormsg = string.Empty;
            if (drow["ExpenseTypeID"] == DBNull.Value)
            {
                object objExpenseTypeID =DBNull .Value ;
                flag = this.accExpenseType.InsertExpenseType(ref errormsg, ref objExpenseTypeID,
                        drow["ExpenseTypeName"]);
                if (flag)
                {
                    drow["ExpenseTypeID"] = objExpenseTypeID;
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
                flag=this.accExpenseType.UpdateExpenseType(ref errormsg,
                             drow["ExpenseTypeID"],
                             drow["ExpenseTypeName"]);
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