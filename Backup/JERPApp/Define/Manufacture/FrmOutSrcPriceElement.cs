using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Manufacture
{
    public partial class FrmOutSrcPriceElement : Form
    {
        public FrmOutSrcPriceElement()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accOutSrcPrice = new JERPData.Manufacture.OutSrcPriceNotes();
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.LoadData();
        }

        private JERPData.Manufacture.OutSrcPriceNotes accOutSrcPrice;
        private DataTable dtblElement;
        private void LoadData()
        {
            this.dtblElement = this.accOutSrcPrice.GetDataOutSrcPriceNotesLastElement().Tables[0];
            this.dgrdv.DataSource = this.dtblElement;
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        public delegate void AffterSelectedDelegate(DataRow drow);
        private AffterSelectedDelegate affterSelected;
        public event AffterSelectedDelegate AffterSelected
        {
            add
            {
                affterSelected += value;
            }
            remove
            {
                affterSelected -= value;
            }
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnSelect.Name)
            {
                DataRow drow = this.dtblElement.DefaultView[irow].Row;
                if (this.affterSelected != null) this.affterSelected(drow);
                this.Close();
            }
        }

    }
}