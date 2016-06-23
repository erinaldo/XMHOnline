using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Material
{
    public partial class CtrlBuyerSetting : UserControl
    {
        public CtrlBuyerSetting()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv; 
            this.accPrdXBuyer = new JERPData.Product.ProductXBuyer();
            this.accPrds = new JERPData.Product.Product(); 
            this.ctrlQFind.BeforeFilter += this.LoadData;
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemBuyer.Click += new EventHandler(mItemBuyer_Click);
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
        }
        private JERPData.Product.Product accPrds;
        private JERPData.Product.ProductXBuyer accPrdXBuyer;
        private DataTable dtblPrds;
        private JERPApp.Engineer.FrmBuyer frmBuyer;
        private JERPApp.Engineer.FrmBatchBuyer frmBatchBuer;
        public delegate void AffterRefreshDelegate();
        private AffterRefreshDelegate affterRefresh;
        public event AffterRefreshDelegate AffterRefresh
        {
            add
            {
                affterRefresh += value;
            }
            remove
            {
                affterRefresh -= value;
            }
        }
        public void LoadData()
        {
            this.dtblPrds = this.accPrds.GetDataProductForBuyerSetting ().Tables[0];
            this.dgrdv.DataSource = this.dtblPrds;

        }
        public int Count
        {
            get
            {
                return this.dtblPrds.Rows.Count;
            }
        }
        private string GetBuyer(int PrdID)
        {
            string buyer = string.Empty;
            this.accPrds.GetParmProductBuyer(PrdID, ref buyer);
            if (buyer == string.Empty) return "Œ¥…Ë÷√";
            return buyer;
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            object objPrdID = this.dtblPrds.DefaultView[irow]["PrdID"];
            if ((objPrdID == null) || (objPrdID == DBNull.Value)) return;
            string errormsg = string.Empty;
            if (this.dgrdv.Columns[icol].Name == this.ColumnBuyer.Name)
            {

                if (frmBuyer == null)
                {
                    frmBuyer = new JERPApp.Engineer.FrmBuyer();
                    new FrmStyle(frmBuyer).SetPopFrmStyle(this.ParentForm);
                }
                this.frmBuyer.Buyer((int)objPrdID);
                this.frmBuyer.ShowDialog();
                this.dgrdv[icol, irow].Value = this.GetBuyer((int)objPrdID);
            }
          

        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
            if (this.affterRefresh != null) this.affterRefresh();
        }
        void frmBatchBuer_AffterSave(DataRow[] drowBuyers, bool BuyFlag)
        {
            DataRow drow;
            string errormsg = string.Empty;
            for (int irow = 0; irow < this.dgrdv.Rows.Count; irow++)
            {
                if (this.dgrdv.Rows[irow].Selected)
                {
                    drow = this.dtblPrds.DefaultView[irow].Row;
                    if (drow["PrdID"] == DBNull.Value) continue;
                    foreach (DataRow drowBuyer in drowBuyers)
                    {
                        this.accPrdXBuyer.SaveProductXBuyer(ref errormsg,
                            drow["PrdID"],
                            drowBuyer["PsnID"],
                            BuyFlag);
                    }
                    drow["Buyer"] = this.GetBuyer((int)drow["PrdID"]);
                }
            }
            this.frmBatchBuer.Close();
        }

        void mItemBuyer_Click(object sender, EventArgs e)
        {
            if (frmBatchBuer == null)
            {
                frmBatchBuer = new JERPApp.Engineer.FrmBatchBuyer();
                new FrmStyle(frmBatchBuer).SetPopFrmStyle(this.ParentForm );
                frmBatchBuer.AffterSave += new JERPApp.Engineer.FrmBatchBuyer.AffterSaveDelegate(frmBatchBuer_AffterSave);
            }
            frmBatchBuer.BatchBuyer();
            frmBatchBuer.ShowDialog();
        }

    }
}
