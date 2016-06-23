using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Boxing
{
    public partial class FrmBoxDetail : Form
    {
        public FrmBoxDetail()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accBoxes = new JERPData.Packing.Boxes();
            this.PrintHelper = new JERPBiz.Packing.BoxPrinterHelper();
            this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
            this.btnExport.Click += new EventHandler(btnExport_Click);
        }

    
    
        private JERPData.Packing.Boxes accBoxes;
        private JERPBiz.Packing.BoxPrinterHelper PrintHelper;
        private DataTable dtblBoxes;
        private int PrdID = -1;
        public void Detail(int PrdID)
        {
            this.PrdID = PrdID;
            int cnt=0;
            this.dtblBoxes = this.accBoxes.GetDataBoxesDescPagesByPrdID(1, this.pbar.PageSize, ref cnt, PrdID).Tables[0];
            this.dtblBoxes.Columns.Add("CheckedFlag", typeof(bool));
            this.dgrdv.DataSource = this.dtblBoxes ;
            this.pbar.Init(1, cnt);
        }
        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblBoxes = this.accBoxes.GetDataBoxesDescPagesByPrdID(this.pbar .PageIndex , this.pbar.PageSize, ref cnt, this.PrdID).Tables[0];
            this.dtblBoxes.Columns.Add("CheckedFlag", typeof(bool));
            this.dgrdv.DataSource = this.dtblBoxes;
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            DataRow[] drows = this.dtblBoxes.Select("CheckedFlag=1", "BoxCode");
            if (drows.Length == 0) return;
            this.PrintHelper.Export(drows);
        }

    }
}