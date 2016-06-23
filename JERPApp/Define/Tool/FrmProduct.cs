using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Tool
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accPrds = new JERPData.Tool.Product();
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.ctrlPrdTypeID.AffterSelected += this.LoadData;
            this.ctrlPrdTypeID.InsertAllRowFlag = true;
            this.ctrlQFind.BeforeFilter += this.LoadData;
            this.LoadData();
        }

        private JERPData.Tool .Product accPrds;
        private DataTable dtblPrds;
        private JCommon.FrmImgBrowse frmImgBrowse;
        private void LoadData()
        {
            if (this.ctrlPrdTypeID.PrdTypeID == -1)
            {
                this.dtblPrds = this.accPrds.GetDataProduct().Tables[0];
            }
            else
            {
                this.dtblPrds = this.accPrds.GetDataProductByPrdTypeID(this.ctrlPrdTypeID.PrdTypeID).Tables[0];
            }
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
                if(this.affterSelected != null) this.affterSelected(drow);
            }
            int PrdID = (int)drow["PrdID"];
            string dir = string.Empty;
            if (this.dgrdv.Columns[icol].Name == this.ColumnImgCount.Name)
            {
                dir = JERPData.ServerParameter.ERPFileFolder + @"\Engineer\ToolImg\" + PrdID.ToString();
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