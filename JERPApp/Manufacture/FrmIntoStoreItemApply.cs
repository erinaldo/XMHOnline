using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmIntoStoreItemApply : Form
    {
        public FrmIntoStoreItemApply()
        {
            InitializeComponent();
            this.dgrdvPlan.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdvPlan;
            this.dgrdvIntoStore.AutoGenerateColumns = false;
            this.accItems = new JERPData.Product.IntoStoreItemPlans();   
            this.SetPermit();
        }       
        private JERPData.Product.IntoStoreItemPlans accItems;   
        private JERPApp.Define.Packing.FrmBoxFromBarcode frmBox;
        private DataTable dtblPlans, dtblIntoStores;
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(525);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(526);
            if (this.enableBrowse)
            {
                this.dgrdvIntoStore.ContextMenuStrip = this.cMenu;
                this.dgrdvPlan.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.LoadPlan();
                this.LoadIntoStore();
                this.ctrlWorkingSheetID.AffterSelected += new JERPApp.Define.Manufacture.CtrlWorkingSheetForFinishedPrd.AffterSelectedDelegate(ctrlWorkingSheetID_AffterSelected);
                this.dgrdvPlan.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdvPlan_UserDeletingRow);
                this.lnkRefreshAll.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkRefreshAll_LinkClicked);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
            }
            this.btnFromBox.Enabled = this.enableSave; 
            this.btnAppend .Enabled = this.enableSave; 
            if (this.enableSave)
            {
                this.btnAppend.Click += new EventHandler(btnAppend_Click);
                this.btnFromBox.Click += new EventHandler(btnFromBox_Click);
            }
        }

        void ctrlWorkingSheetID_AffterSelected()
        {
            this.ctrlPrdID.PrdID = this.ctrlWorkingSheetID.PrdID;
        }

        void dgrdvPlan_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index; 
            bool flag = false;
            DataRow drow = this.dtblPlans .DefaultView[irow].Row;
            if (drow["ItemID"] != DBNull.Value)
            {
                string errormsg = string.Empty;
                DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rul == DialogResult.Yes)
                {
                    flag = this.accItems.DeleteIntoStoreItemPlans (ref errormsg, drow["ItemID"]);
                    if (flag)
                    {
                        MessageBox.Show("成功删除当前记录");
                    }
                    else
                    {
                        MessageBox.Show(errormsg);
                        e.Cancel = true;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        } 
        void btnFromBox_Click(object sender, EventArgs e)
        {
            if (frmBox == null)
            {
                frmBox = new JERPApp.Define.Packing.FrmBoxFromBarcode();
                new FrmStyle(frmBox).SetPopFrmStyle(this);
                frmBox.AffterSelect += new JERPApp.Define.Packing.FrmBoxFromBarcode.AffterConfirmDelegate(frmBox_AffterSelect);
            }
            frmBox.New(new System.Collections.Hashtable());
            frmBox.ShowDialog();
        }

        void frmBox_AffterSelect(DataRow drowBox)
        {
            string errormsg = string.Empty;
            object objItemID=DBNull .Value ;
            bool flag = this.accItems.InsertIntoStoreItemPlans(
                ref errormsg,
                ref objItemID,
                DBNull.Value,
                drowBox["BoxCode"],
                drowBox["PrdID"],
                drowBox["Quantity"],
                DBNull.Value);
            if (flag)
            {
                DataRow drowNew = this.dtblPlans.NewRow();
                drowNew["ItemID"] = objItemID;
                drowNew["PrdID"] = drowBox["PrdID"];
                drowNew["BoxCode"] = drowBox["BoxCode"];
                drowNew["PrdCode"] = drowBox["PrdCode"];
                drowNew["PrdName"] = drowBox["PrdName"];
                drowNew["PrdSpec"] = drowBox["PrdSpec"];
                drowNew["Model"] = drowBox["Model"];
                drowNew["Quantity"] = drowBox["Quantity"];
                drowNew["UnitName"] = drowBox["UnitName"];

                this.dtblPlans.Rows.Add(drowNew);
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }

        void btnAppend_Click(object sender, EventArgs e)
        {
            if (this.ctrlPrdID.PrdID == -1)
            {
                MessageBox.Show("对不起，产品不能为空");
                return;
            }
            decimal Quantity;
            if(!decimal.TryParse (this.txtQuantity .Text,out Quantity ))
            {
                MessageBox.Show("对不起，数量格式出错");
                return;
            }
            if(Quantity<=0)
            {
                MessageBox.Show("对不起，数量不能小于或等于0");
                return;
            }
            string errormsg = string.Empty;
            bool flag = false;
            object objItemID=DBNull .Value ;
            flag = this.accItems.InsertIntoStoreItemPlans(
                ref errormsg,
                ref objItemID,
                this.ctrlWorkingSheetID.WorkingSheetID,
                DBNull.Value,
                this.ctrlPrdID.PrdID,
                Quantity,
                this.txtMemo.Text);
            if (flag)
            {
                DataRow drowNew = this.dtblPlans.NewRow();
                drowNew["ItemID"] = objItemID;
                drowNew["WorkingSheetID"] = this.ctrlWorkingSheetID.WorkingSheetID;
                drowNew["PrdID"] = this.ctrlPrdID.PrdID;
                drowNew["WorkingSheetCode"] = this.ctrlWorkingSheetID.WorkingSheetCode;
                drowNew["PrdCode"] = this.ctrlPrdID.PrdEntity.PrdCode;
                drowNew["PrdName"] = this.ctrlPrdID.PrdEntity.PrdName;
                drowNew["PrdSpec"] = this.ctrlPrdID.PrdEntity.PrdSpec;
                drowNew["Model"] = this.ctrlPrdID.PrdEntity.Model;
                drowNew["Quantity"] = Quantity;
                drowNew["UnitName"] = this.ctrlPrdID.PrdEntity.UnitName;
                drowNew["Memo"] = this.txtMemo.Text;
                this.dtblPlans.Rows.Add(drowNew);
            }
            else
            {
                MessageBox.Show(errormsg);
            }
            this.ctrlPrdID.PrdID = -1;
            this.ctrlWorkingSheetID.WorkingSheetID = -1;
            this.txtQuantity.Text = string.Empty;
        }

        void lnkRefreshAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.LoadPlan();
            this.LoadIntoStore();
        } 
        public void LoadPlan()
        { 
            this.dtblPlans = this.accItems.GetDataIntoStoreItemPlansNonIntoStore ().Tables[0];
            this.dgrdvPlan.DataSource = this.dtblPlans; 
         
        }
        public void LoadIntoStore()
        {
            int cnt=0;
            this.dtblIntoStores  = this.accItems.GetDataIntoStoreItemPlansIntoStoreDescPages(1, this.pbar.PageSize, ref cnt).Tables[0];
            this.dgrdvIntoStore.DataSource = this.dtblIntoStores;
            this.pbar.Init(1, cnt);
        }

        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblIntoStores  = this.accItems.GetDataIntoStoreItemPlansIntoStoreDescPages(this.pbar .PageIndex , this.pbar.PageSize, ref cnt).Tables[0];
            this.dgrdvIntoStore.DataSource = this.dtblIntoStores;
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvPlan )
            {
                this.LoadPlan ();
            }
            if (this.cMenu.SourceControl == this.dgrdvIntoStore )
            {
                this.LoadIntoStore ();
            }
           
        } 
     

    }
}