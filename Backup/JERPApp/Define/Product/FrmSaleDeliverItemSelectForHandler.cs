using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class FrmSaleDeliverItemSelectForHandler : Form
    {
        public FrmSaleDeliverItemSelectForHandler()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.lnkSearch.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkSearch_LinkClicked);
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.accDeliverItems = new JERPData.Product.SaleDeliverItems();
        }
        private JERPData.Product.SaleDeliverItems accDeliverItems;
        private DataTable dtblItems;
        private FrmSaleDeliverItemSearchForHandler frmSearch;
        public delegate void AffterConfirmDelegate(DataRow drow);
        private AffterConfirmDelegate affterSelect;
        public event AffterConfirmDelegate AffterSelect
        {
            add
            {
                affterSelect += value;
            }
            remove
            {
                affterSelect -= value;
            }
        }    
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnSelect.Name)
            {
                DataRow drow = this.dtblItems.DefaultView[irow].Row;
                if (this.affterSelect != null)
                {
                    this.affterSelect(drow);
                }
            }
        }

        void lnkSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmSearch == null)
            {
                frmSearch = new FrmSaleDeliverItemSearchForHandler();
                new FrmStyle(frmSearch).SetPopFrmStyle(this);
                frmSearch.AffterSearch += new FrmSaleDeliverItemSearchForHandler.AffterSearchDelegate(frmSearch_AffterSearch);
            }
            frmSearch.ShowDialog();
        }
        void frmSearch_AffterSearch(string whereclause)
        {
            whereclause += " and (SalePsnID=" + JERPBiz.Frame.UserBiz.PsnID.ToString() + ")";
            this.dtblItems = this.accDeliverItems.GetDataSaleDeliverItemsByFreeSearch(whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
    }
}