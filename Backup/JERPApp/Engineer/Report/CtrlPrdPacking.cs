using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Report
{
    public partial class CtrlPrdPacking : UserControl
    {
        public CtrlPrdPacking()
        {
            InitializeComponent();
            this.accPackingType = new JERPData.Product.PackingType();
        }
        private JERPData.Product.PackingType accPackingType;
        private DataTable dtblPackingType;
        public void PrdPackingType(int PrdID)
        {
            this.tabMain.TabPages.Clear();
            this.dtblPackingType = this.accPackingType.GetDataPackingTypeByPrdID(PrdID).Tables[0];
            foreach (DataRow drow in this.dtblPackingType.Rows)
            {
                int PackingTypeID = (int)drow["PackingTypeID"];
                JERPApp.Define.Product.CtrlPackingType ctrl = new JERPApp.Define.Product.CtrlPackingType();
                ctrl.LoadPacking(PackingTypeID);
                ctrl.Dock = DockStyle.Fill;
                TabPage page = new TabPage();
                page.Text = drow["PackingTypeName"].ToString();
                page.Controls.Add(ctrl);
                this.tabMain.TabPages.Add(page);

            }
        }
    }
}
