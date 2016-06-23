using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class FrmPrdForDevelopSchedule : Form
    {
        public FrmPrdForDevelopSchedule()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accPrds = new JERPData.Product.Product();
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
         
            this.LoadData();
        }

        private JERPData.Product.Product accPrds;
        private JCommon.FrmFileBrowse frmFileBrowse;
        private JCommon.FrmImgBrowse frmImgBrowse;
        private DataTable dtblPrds;
        private void LoadData()
        {
            
          this.dtblPrds = this.accPrds.GetDataProductForDevelopSchedule ().Tables[0];            
            this.dgrdv.DataSource = this.dtblPrds;
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
            DataRow drow=this.dtblPrds .DefaultView [irow].Row ;
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnSelect.Name)
            {          
                if (this.affterSelected != null) this.affterSelected(drow);
            }
            int PrdID = (int)drow["PrdID"];
            string dir = string.Empty;
            if (this.dgrdv.Columns[icol].Name == this.ColumnlnkFiles.Name)
            {
                dir = JERPData.ServerParameter.ERPFileFolder + @"\Engineer\Product\" + PrdID.ToString() + @"\File";
                if (this.frmFileBrowse == null)
                {
                    this.frmFileBrowse = new JCommon.FrmFileBrowse();
                    new FrmStyle(this.frmFileBrowse).SetPopFrmStyle(this);
                    this.frmFileBrowse.ReadOnly = true;
                }
                this.frmFileBrowse.Browse(dir);
                this.frmFileBrowse.ShowDialog();
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnlnkImgs.Name)
            {
                dir = JERPData.ServerParameter.ERPFileFolder + @"\Engineer\Product\" + PrdID.ToString() + @"\Image";
                if (this.frmImgBrowse == null)
                {
                    this.frmImgBrowse = new JCommon.FrmImgBrowse();
                    new FrmStyle(this.frmImgBrowse).SetPopFrmStyle(this);
                    this.frmImgBrowse.ReadOnly = true;
                }
                this.frmImgBrowse.Browse(dir);
                this.frmImgBrowse.ShowDialog();
            }

        }

    }
}