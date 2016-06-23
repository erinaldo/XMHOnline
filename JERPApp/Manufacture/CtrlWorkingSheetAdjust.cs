using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class CtrlWorkingSheetAdjust : UserControl 
    {
        public CtrlWorkingSheetAdjust()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accWorkingSheets = new JERPData.Manufacture.WorkingSheets();
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
        }
        private JERPData.Manufacture.WorkingSheets accWorkingSheets;
        private DataTable dtblWorkingSheets;
        private FrmWorkingSheetAdjustOper frmOper; 
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnAdjust.Name)
            {
                long WorkingSheetID=(long)this.dtblWorkingSheets .DefaultView [irow]["WorkingSheetID"];
                if (frmOper == null)
                {
                    frmOper = new FrmWorkingSheetAdjustOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this.ParentForm );
                    frmOper.AffterSave += this.LoadData;
                }
                frmOper.WorkingSheetAdjust(WorkingSheetID);
                frmOper.ShowDialog();
            }
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        public  void LoadData()
        {
            this.dtblWorkingSheets = this.accWorkingSheets.GetDataWorkingSheetsNonFinished().Tables[0];
            this.dgrdv.DataSource = this.dtblWorkingSheets;

        }
    }
}