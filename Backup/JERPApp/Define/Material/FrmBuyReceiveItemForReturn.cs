using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Material
{
    public partial class FrmBuyReceiveItemForReturn : Form
    {
        public FrmBuyReceiveItemForReturn()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accReceiveItem = new JERPData.Material.BuyReceiveItems();
            this.ctrlBetweenDate.DateBegin = DateTime.Now.AddDays(-30).Date;
            this.ctrlBetweenDate.DateEnd = DateTime.Now.AddDays (1).Date;
            this.ctrlBetweenDate.AffterEnter  +=this.LoadData ;
            this.dgrdv .CellContentClick +=new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            
        }
        private JERPData.Material.BuyReceiveItems accReceiveItem;
        private DataTable dtblItems;
        private int CompanyID = -1;
        private int MoneyTypeID = -1;
        public void BuyReceiveForReturn(int CompanyID,int MoneyTypeID)
        {
            this.CompanyID = CompanyID;
            this.MoneyTypeID = MoneyTypeID;
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblItems = this.accReceiveItem.GetDataBuyReceiveItemsForReturn(this.CompanyID,this.MoneyTypeID , this.ctrlBetweenDate.DateBegin.Date,
               this.ctrlBetweenDate.DateEnd.Date).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
        public delegate void AffterSelectDelegate(DataRow drow);
        private AffterSelectDelegate affterSelect;
        public event AffterSelectDelegate AffterSelect
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
                if (this.affterSelect != null) this.affterSelect(this.dtblItems.DefaultView[irow].Row);
               
            }
        }
    }
}