using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmRepairItem : Form  
    {
        public FrmRepairItem()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accRepairItems = new JERPData.Product.RepairItems();
            this.accCustomer = new JERPData.General.Customer();
            this.accPrds = new JERPData.Product.Product();
            this.dtblPrds = this.accPrds.GetDataProductForFinishedPrd ().Tables[0];
            this.SetPermit();
        }
        private JERPData.Product.RepairItems accRepairItems;
        private JERPData.General.Customer accCustomer;
        private JERPApp.Define.Product.FrmFinishedPrd frmPrd;
        private JERPData.Product.Product accPrds;
        private JCommon.FrmGridFind frmGridPrd; 
        private DataTable dtblItems,dtblPrds,dtblCustomer; 
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(455);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(456);
            if (this.enableBrowse)
            {
                this.SetColumnSrc();
                //加载数据
                this.LoadData();
                this.dgrdv.ContextMenuStrip  = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            } 
            if (this.enableSave)
            {
                this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
               this.btnSave .Click +=new EventHandler(btnSave_Click);
               this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
            }
        }


        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                grow.ErrorText = string.Empty;
                if (grow.Cells[this.ColumnPrdID.Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "产品不能为空";
                    continue;
                }
                if (grow.Cells[this.ColumnCompanyID.Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "客户不能为空";
                }
            }
        }
        private void SetColumnSrc()
        {
            this.dtblCustomer = this.accCustomer.GetDataCustomer().Tables[0];
            this.dtblCustomer.Columns.Add("Exp", typeof(string), "ISNULL(AssistantCode,'')+ISNULL(CompanyAbbName,'')");
            this.ColumnCompanyID.DataSource = this.dtblCustomer;
            this.ColumnCompanyID.ValueMember = "CompanyID";
            this.ColumnCompanyID.DisplayMember = "Exp";

        }
        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblItems.DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["RepairItemID"] == DBNull.Value)
            {
                return;
            }
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accRepairItems.DeleteRepairItems (ref ErrorMsg,
                    drow["RepairItemID"]);
                if (!flag)
                {

                    MessageBox.Show(ErrorMsg);
                } 
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void LoadData()
        {
            this.dtblItems = this.accRepairItems.GetDataRepairItemsNonDeliverApply   ().Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }

        void dgrdv_CellQuery(DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnAssistantCode.Name)
            {

                if (this.frmGridPrd == null)
                {
                    this.frmGridPrd = new JCommon.FrmGridFind();
                    this.frmGridPrd.AddGridColumn("PrdCode", "产品编号", 100);
                    this.frmGridPrd.AddGridColumn("PrdName", "产品名称", 100);
                    this.frmGridPrd.AddGridColumn("PrdSpec", "产品规格", 120);
                    this.frmGridPrd.AddGridColumn("Model", "机型", 66);
                    this.frmGridPrd.AddGridColumn("AssistantCode", "助记码", 66);
                    this.frmGridPrd.AffterSelected += frmGridPrd_AffterSelected;

                }
                this.frmGridPrd.Query(this.dtblPrds , "AssistantCode", this.dgrdv.CurrentCell);
            }
        }
        void frmGridPrd_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"];
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            grow.Cells[this.ColumnPrdID.Name].Value = PrdID;
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"]; 
        }

        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return; 
            if ((this.dgrdv.Columns[icol].DataPropertyName == "PrdCode")
             || (this.dgrdv.Columns[icol].DataPropertyName == "PrdName")
             || (this.dgrdv.Columns[icol].DataPropertyName == "PrdSpec")
             || (this.dgrdv.Columns[icol].DataPropertyName == "Model"))
            {

                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (frmPrd == null)
                {
                    this.frmPrd = new JERPApp.Define.Product.FrmFinishedPrd();
                    new FrmStyle(this.frmPrd).SetPopFrmStyle(this);
                    this.frmPrd.AffterSelected += frmPrd_AffterSelected;
                }
                this.frmPrd.ShowDialog();
            }

        } 
        void frmPrd_AffterSelected(DataRow drow)
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            int PrdID = (int)drow["PrdID"];
            grow.Cells[this.ColumnPrdID.Name].Value = drow["PrdID"];
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"]; 
            this.frmPrd.Close();
        }
        private bool ValidateData()
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.ErrorText != string.Empty)
                {
                    MessageBox.Show("存在记录未全项");
                    return false;
                }
            }
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        { 
            if (this.ValidateData() == false) return;
            string errormsg = string.Empty;
            bool flag = false;
            object objRepairItemID = DBNull.Value;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow["RepairItemID"] == DBNull.Value)
                {
                    objRepairItemID = DBNull.Value;
                    flag = this.accRepairItems.InsertRepairItems(
                        ref errormsg,
                        ref objRepairItemID,
                        drow["DateReceive"],
                        drow["CompanyID"],
                        drow["PrdID"],
                        drow["Amount"],
                        drow["DateTarget"],
                        drow["Memo"],
                        JERPBiz.Frame.UserBiz.PsnID);
                }
                else
                {
                    this.accRepairItems.UpdateRepairItems (ref errormsg,
                        drow["RepairItemID"],
                        drow["DateReceive"],
                        drow["CompanyID"],
                        drow["PrdID"],
                        drow["Amount"],
                        drow["DateTarget"],
                        drow["Memo"],
                        JERPBiz.Frame.UserBiz.PsnID);
                }
                drow.AcceptChanges();
            }
            MessageBox.Show("成功保存当前产品维修项");
        }
     
    }
}