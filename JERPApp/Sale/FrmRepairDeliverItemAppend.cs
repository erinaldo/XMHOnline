using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmRepairDeliverItemAppend : Form
    {
        public FrmRepairDeliverItemAppend()
        {
            InitializeComponent();
            this.dgrdvItem.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdvItem;
            this.accRepairItems = new JERPData.Product.RepairItems();
            this.dgrdvItem.CellContentClick += new DataGridViewCellEventHandler(dgrdvItem_CellContentClick);
        }

        private JERPData.Product.RepairItems accRepairItems;         
        private DataTable dtblRepairItems ;      
        public void DeliverItemAppend(int CompanyID,DataRow[] drowItems)
        {
            this.dtblRepairItems = this.accRepairItems.GetDataRepairItemsForDeliver (CompanyID).Tables[0];
            foreach (DataRow drowItem in drowItems)
            {
                DataRow[] drows = this.dtblRepairItems.Select("RepairItemID=" + drowItem["RepairItemID"].ToString());
                if (drows.Length > 0)
                {
                    this.dtblRepairItems.Rows.Remove(drows[0]);
                }
            }
            this.dgrdvItem.DataSource = this.dtblRepairItems;
        }
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

        void dgrdvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvItem.Columns[icol].Name == this.ColumnbtnAdd.Name)
            {
                if (this.affterAppend != null) this.affterAppend(this.dtblRepairItems.DefaultView[irow].Row);
            }
        }

   
    }
}