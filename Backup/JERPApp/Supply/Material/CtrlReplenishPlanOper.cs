using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Material
{
    public partial class CtrlReplenishPlanOper : UserControl
    {
        public CtrlReplenishPlanOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.accPrds = new JERPData.Product.Product();
            this.dtblPrds = this.accPrds.GetDataProduct().Tables[0];
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);

            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.accReplenishPlan = new JERPData.Material .BuyReplenishPlans();
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv .CellContextMenuStripNeeded +=new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.btnSave .Click +=new EventHandler(btnSave_Click);
            this.btnPrd.Click += new EventHandler(btnPrd_Click);
        }


        private JERPData.Material .BuyReplenishPlans accReplenishPlan;
        private JERPData.Product.Product accPrds;
        private JCommon.FrmGridFind frmGridPrd;
        private JERPApp.Define.Material.FrmProduct frmAddPrd;
        private JERPApp.Define.Material.FrmProduct frmPrd;
        private DataTable dtblPlans,dtblPrds;
        private int CompanyID = -1;
        public  void ReplenishPlan(int CompanyID)
        {
            this.CompanyID = CompanyID;
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblPlans = this.accReplenishPlan.GetDataBuyReplenishPlansForReplenish (this.CompanyID).Tables[0];
            this.dgrdv.DataSource = this.dtblPlans;
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        void dgrdv_CellQuery(DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnAssistantCode.Name)
            {
                string AssistantCode = this.dgrdv[icol, irow].FormattedValue.ToString();
                if (AssistantCode == string.Empty) return;
                if (this.frmGridPrd == null)
                {
                    this.frmGridPrd = new JCommon.FrmGridFind();
                    this.frmGridPrd.AddGridColumn("PrdCode", "原料编号", 100);
                    this.frmGridPrd.AddGridColumn("PrdName", "原料名称", 100);
                    this.frmGridPrd.AddGridColumn("PrdSpec", "型号及规格", 120);
                    this.frmGridPrd.AddGridColumn("Model", "机型", 66);
                    this.frmGridPrd.AddGridColumn("Manufacturer", "品牌", 66);
                    this.frmGridPrd.AddGridColumn("AssistantCode", "助记码", 66);
                    this.frmGridPrd.AffterSelected += frmGridPrd_AffterSelected;

                }
                this.frmGridPrd.Query(this.dtblPrds, "AssistantCode", this.dgrdv.CurrentCell);

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
            grow.Cells[this.ColumnManufacturer.Name].Value = drow["Manufacturer"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"];
        }
        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if ((this.dgrdv.Columns[icol].DataPropertyName == "PrdCode")
                ||(this.dgrdv.Columns[icol].DataPropertyName == "PrdName")
                || (this.dgrdv.Columns[icol].DataPropertyName == "PrdSpec")
                || (this.dgrdv.Columns[icol].DataPropertyName == "Model")
                || (this.dgrdv.Columns[icol].DataPropertyName == "Manufacturer"))
            {
                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (frmPrd == null)
                {
                    frmPrd = new JERPApp.Define.Material.FrmProduct();
                    new FrmStyle(frmPrd).SetPopFrmStyle(this);
                    frmPrd.AffterSelected += frmPrd_AffterSelected;
                }
                frmPrd.ShowDialog();
            }
        }

        void frmPrd_AffterSelected(DataRow drow)
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            grow.Cells[this.ColumnPrdID.Name].Value = drow["PrdID"];
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnManufacturer.Name].Value = drow["Manufacturer"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"];
            frmPrd.Close();
        }

        void btnPrd_Click(object sender, EventArgs e)
        {
              if (frmAddPrd == null)
                {
                    frmAddPrd = new JERPApp.Define.Material .FrmProduct();
                    new FrmStyle(frmAddPrd).SetPopFrmStyle(this);
                    frmAddPrd.AffterSelected += new JERPApp.Define.Material  .FrmProduct.AffterSelectedDelegate(frmAddPrd_AffterSelected);
                }
                frmAddPrd.ShowDialog();
            
        } 
        void frmAddPrd_AffterSelected(DataRow drow)
        {
            if (this.dtblPlans.Select("PrdID=" + drow["PrdID"].ToString(), "", DataViewRowState.CurrentRows).Length > 0)
            {
                MessageBox.Show("已存在此原料");
                return;
            }
            DataRow drowNew = this.dtblPlans.NewRow();
            drowNew["PrdID"] = drow["PrdID"];
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["Model"] = drow["Model"];
            drowNew["Manufacturer"] = drow["Manufacturer"];
            drowNew["UnitName"] = drow["UnitName"];
            this.dtblPlans.Rows.Add(drowNew);
        }
        private void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblPlans .DefaultView[irow].Row;
            if (drow["ID"] == DBNull.Value) return;
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {

                flag = this.accReplenishPlan.DeleteBuyReplenishPlans(ref errormsg, 
                    drow["ID"]);
                if (!flag)
                {
                    e.Cancel = true;
                    MessageBox.Show(errormsg);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            object objID = DBNull.Value;
            bool flag = false;
            foreach (DataRow drow in this.dtblPlans .Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue; 
                if (drow["ID"] == DBNull.Value)
                {
                    objID = DBNull.Value;
                    flag = this.accReplenishPlan.InsertBuyReplenishPlans (
                        ref errormsg, 
                        ref objID ,
                        this.CompanyID ,
                        drow["PrdID"],
                        drow["Quantity"]);
                    if (flag)
                    {
                        drow["ID"] = objID;
                    }
                }
                else
                {
                    flag=this.accReplenishPlan.UpdateBuyReplenishPlans  (
                        ref errormsg, 
                        drow["ID"],
                        drow["PrdID"],
                        drow["Quantity"]);
                    
                }
                drow.AcceptChanges();
            }
            MessageBox.Show("成功保存当前补货计划");
        }

      
    }
}
