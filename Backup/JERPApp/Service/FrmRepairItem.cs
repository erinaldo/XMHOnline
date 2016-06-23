using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Service
{
    public partial class FrmRepairItem : Form  
    {
        public FrmRepairItem()
        {
            InitializeComponent();
            this.dgrdvNonApply.AutoGenerateColumns = false;
            this.ctrlQNonApply.SeachGridView = this.dgrdvNonApply;
            this.dgrdvCancelApply.AutoGenerateColumns = false;
            this.ctrlQCancelApply.SeachGridView = this.dgrdvCancelApply; 
            this.accRepairItems = new JERPData.Product.RepairItems();
            this.accNotes = new JERPData.Product.RepairDeliverNotes(); 
            this.SetPermit();
        }
        private JERPData.Product.RepairItems accRepairItems;   
        private JERPData.Product.RepairDeliverNotes accNotes;
        private DataTable dtblNonApply,dtblCancelApply; 
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(155);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(156);
            if (this.enableBrowse)
            {
                this.LoadNonApply();
                this.LoadCancelApply(); 
                this.dgrdvNonApply.ContextMenuStrip  = this.cMenu;
                this.dgrdvCancelApply.ContextMenuStrip = this.cMenu; 
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click); 
            } 
            if (this.enableSave)
            {
                this.dgrdvCancelApply.CellContentClick += new DataGridViewCellEventHandler(dgrdvCancelApply_CellContentClick);
                this.dgrdvNonApply.CellContentClick += new DataGridViewCellEventHandler(dgrdvNonApply_CellContentClick);
               
                this.btnSave .Click +=new EventHandler(btnSave_Click);
            }
        }

        private void LoadNonApply()
        {
            this.dtblNonApply = this.accRepairItems.GetDataRepairItemsNonDeliverApply().Tables[0];
            this.dgrdvNonApply.DataSource = this.dtblNonApply; 
        }
        private void LoadCancelApply()
        {
            this.dtblCancelApply = this.accRepairItems.GetDataRepairItemsNeedDeliver ().Tables[0];
            this.dgrdvCancelApply.DataSource = this.dtblCancelApply; 
        }
    
       
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvNonApply)
            {
                this.LoadNonApply();
            }
            if (this.cMenu.SourceControl == this.dgrdvCancelApply )
            {
                this.LoadCancelApply ();
            }
            
        }

        void dgrdvNonApply_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex ;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvNonApply.Columns[icol].Name == this.ColumnbtnApply.Name)
            {
                long RepairItemID = (long)this.dtblNonApply.DefaultView[irow]["RepairItemID"];
                string errormsg = string.Empty;
                bool flag = this.accRepairItems.UpdateRepairItemsForDeliverApply(ref errormsg,
                    RepairItemID,
                    DateTime.Now.Date,
                    JERPBiz.Frame.UserBiz.PsnID);
                if (flag)
                {
                    MessageBox.Show("成功申请当前维修项");
                    this.LoadNonApply();
                    this.LoadCancelApply();
                }
                else
                {
                    MessageBox.Show(errormsg);
                }
            }
        }

        void dgrdvCancelApply_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvCancelApply .Columns[icol].Name == this.ColumnbtnCancel .Name)
            {
                long RepairItemID = (long)this.dtblCancelApply .DefaultView[irow]["RepairItemID"];
                string errormsg = string.Empty;
                bool flag = this.accRepairItems.UpdateRepairItemsCancelDeliverApply (ref errormsg,
                    RepairItemID);
                if (flag)
                {
                    MessageBox.Show("成功取消申请维修项");
                    this.LoadCancelApply();
                    this.LoadNonApply();
                }
                else
                {
                    MessageBox.Show(errormsg);
                }
            }
        } 
        void btnSave_Click(object sender, EventArgs e)
        {  
            string errormsg = string.Empty; 
            object objRepairItemID = DBNull.Value;
            foreach (DataRow drow in this.dtblNonApply .Rows)
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow.RowState == DataRowState.Deleted) continue; 
                this.accRepairItems.UpdateRepairItemsForRepair  (ref errormsg,
                    drow["RepairItemID"],
                    drow["RepairPsns"],
                    drow["RepairStatus"]);
                drow.AcceptChanges();
            }
            MessageBox.Show("成功保存当前产品维修项");
        }
     
    }
}