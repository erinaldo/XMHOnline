using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Tool
{
    public partial class FrmBuyReceiveItemSelect : Form
    {
        public FrmBuyReceiveItemSelect()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.lnkSearch.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkSearch_LinkClicked);
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.accDeliverItems = new JERPData.Tool.BuyReceiveItems();
        }
        private JERPData.Tool.BuyReceiveItems accDeliverItems;
        private DataTable dtblItems;
        private FrmBuyReceiveItemSearch frmSearch;
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
                frmSearch = new FrmBuyReceiveItemSearch();
                new FrmStyle(frmSearch).SetPopFrmStyle(this);
                frmSearch.AffterSearch += new FrmBuyReceiveItemSearch.AffterSearchDelegate(frmSearch_AffterSearch);
            }
            frmSearch.ShowDialog();
        }
        void frmSearch_AffterSearch(string whereclause)
        {
            this.dtblItems = this.accDeliverItems.GetDataBuyReceiveItemsByFreeSearch(whereclause).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
    }
}