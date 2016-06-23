using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Boxing
{
    public partial class FrmBoxItemDetail : Form
    {
        public FrmBoxItemDetail()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQChecked.SeachGridView = this.dgrdv;
            this.accBoxItem = new JERPData.Packing.BoxItems();
            this.PrintHelper = new JERPBiz.Packing.BoxItemPrinterHelper();
            this.btnExport.Click += new EventHandler(btnExport_Click);
        }

        private JERPData.Packing.BoxItems accBoxItem;
        private DataTable dtblBoxItem;
        private JERPBiz.Packing.BoxItemPrinterHelper PrintHelper;
        public void Detail(int PrdID,DateTime DateCreate)
        {
            this.dtblBoxItem = this.accBoxItem.GetDataBoxItemsByPrdAndDay (PrdID ,DateCreate ).Tables[0];
            this.dtblBoxItem.Columns.Add("CheckedFlag", typeof(bool));
            this.dgrdv.DataSource = this.dtblBoxItem;
        }

        void btnExport_Click(object sender, EventArgs e)
        {
            DataRow[] drows = this.dtblBoxItem.Select("CheckedFlag=1", "");
            if (drows.Length == 0) return;
            this.PrintHelper.Export(drows);
        }
    }
}