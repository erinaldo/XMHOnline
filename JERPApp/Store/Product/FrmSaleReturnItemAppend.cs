using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Product
{
    public partial class FrmSaleReturnItemAppend : Form
    {
        public FrmSaleReturnItemAppend()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accPrds = new JERPData.Product.Product();
            this.accItems = new JERPData.Product.SaleReturnItems();
            this.dtblPrds = this.accPrds.GetDataProductForFinishedPrd().Tables[0];
            this.Shown += new EventHandler(FrmSaleReturnItemAppend_Shown);
            this.btnAdd .Click +=new EventHandler(btnAdd_Click);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
            this.btnAddPrd.Click += new EventHandler(btnAddPrd_Click);
        }

        private JERPData.Product.Product accPrds;
        private JERPData.Product.SaleReturnItems accItems;
        private JERPApp.Define.Product.FrmProduct frmPrd;
        private JERPApp.Define.Product.FrmFinishedPrd frmAddPrd; 
        private JCommon.FrmGridFind frmGridPrd;
        private DataTable dtblPrds,dtblItems;
        public delegate void AffterAppendDelegate(DataRow drow);
        private AffterAppendDelegate affterAppend;
        public event AffterAppendDelegate AffterAppend
        {
            add
            {
                affterAppend += value;
            }
            remove
            {
                affterAppend -= value;
            }
        }
        private int ReturnHandleTypeID = -1;
        public void ReturnAppend(int ReturnHandleTypeID)
        {
            this.ReturnHandleTypeID = ReturnHandleTypeID;
            this.dtblItems = this.accItems.GetDataSaleReturnItemsByNoteID(-1).Tables[0];
            this.dtblItems.Columns["PrdID"].Unique  = true;
            this.dgrdv.DataSource = this.dtblItems;
            
        }
       
        void FrmSaleReturnItemAppend_Shown(object sender, EventArgs e)
        {         
            this.ColumnPrice .Visible = (ReturnHandleTypeID > 1);
        }
        bool ValidateData()
        {

            DataRow[] drows = this.dtblItems.Select("", "", DataViewRowState.CurrentRows);
            if (drows.Length == 0)
            {
                MessageBox.Show("不存任何记录");
                return false;
            }
            string sqls="PrdID is null or Quantity is null";
            if (this.ReturnHandleTypeID > 1)
            {
                sqls += " or Price is null";
            }
            drows = this.dtblItems.Select(sqls, "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("存在输入不全记录");
                return false;
            }         
            return true;
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
                    frmPrd = new JERPApp.Define.Product.FrmProduct();
                    new FrmStyle(frmPrd).SetPopFrmStyle(this);
                    frmPrd.AffterSelected += new JERPApp.Define.Product.FrmProduct.AffterSelectedDelegate(frmPrd_AffterSelected);
                }
                frmPrd.ShowDialog();
            }
        }

        void frmPrd_AffterSelected(DataRow drow)
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            int PrdID = (int)drow["PrdID"];
            grow.Cells[this.ColumnPrdID.Name].Value = PrdID;
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"]; 
            this.frmPrd.Close();
        }
        void btnAddPrd_Click(object sender, EventArgs e)
        {
            if (frmAddPrd == null)
            {
                this.frmAddPrd = new JERPApp.Define.Product.FrmFinishedPrd();
                new FrmStyle(this.frmAddPrd).SetPopFrmStyle(this);
                this.frmAddPrd.AffterSelected += frmAddPrd_AffterSelected;
            }
            this.frmAddPrd.ShowDialog();
        }
        void frmAddPrd_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"];
            if (this.dtblItems.Select("PrdID=" + PrdID.ToString(), "", DataViewRowState.CurrentRows).Length > 0)
            {
                return;
            }
            DataRow drowNew = this.dtblItems.NewRow();
            drowNew["PrdID"] = PrdID;
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["Model"] = drow["Model"];
            drowNew["UnitName"] = drow["UnitName"]; 
            drowNew["Quantity"] = 0;         
            this.dtblItems.Rows.Add(drowNew);

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
                    this.frmGridPrd.AddGridColumn("PrdName", "产品名称", 120);
                    this.frmGridPrd.AddGridColumn("PrdSpec", "产品规格", 100);
                    this.frmGridPrd.AddGridColumn("Model", "型号", 66);
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
            grow.Cells[this.ColumnUnitName.Name].Value = drow["UnitName"];

        }

        
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                grow.ErrorText = string.Empty;
                if (grow.Cells[this.ColumnPrdCode.Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "产品不能为空";
                    continue;
                }
                if (grow.Cells[this.ColumnQuantity.Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "数量不能为空";
                    continue;
                }
                if (this.ReturnHandleTypeID > 1)
                {
                   
                    if (grow.Cells[this.ColumnPrice.Name].Value == DBNull.Value)
                    {
                        grow.ErrorText = "单价不能为空";
                        continue;
                    }
                }
            }
        }

       
        void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;         
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue; 
                if (this.affterAppend != null) this.affterAppend(drow);
            }
            this.Close();
        }

    }
}