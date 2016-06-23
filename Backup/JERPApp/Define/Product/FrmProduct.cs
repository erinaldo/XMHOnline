using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accPrds = new JERPData.Product.Product();
            this.ctrlPrdTypeID.AffterSelected += new CtrlPrdTypeTree.AffterSelectDelegate(ctrlPrdTypeID_AffterSelected); 
            this.AllowAppendFlag = false;
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.ctrlQFind.BeforeFilter += new JCommon.CtrlGridFind.BeforeFilterDelegate(ctrlQFind_BeforeFilter);
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.lnkNew .LinkClicked +=new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
        }

      
        private JERPData.Product.Product accPrds;
        private JCommon.FrmImgBrowse frmImgBrowse;
        private FrmPrdNew frmNew; 
        private DataTable dtblIniPrds, dtblPrds;
        private string whereclause = string.Empty;
        private void LoadData()
        {
            this.dtblIniPrds = this.accPrds.GetDataProductByFreeSearch(this.whereclause).Tables[0];
            this.dtblPrds = this.dtblIniPrds.Copy();
            this.dgrdv.DataSource = this.dtblPrds; 
        }
        void ctrlPrdTypeID_AffterSelected()
        { 
            this.whereclause = " and (PrdTypeID=" + this.ctrlPrdTypeID.PrdTypeID.ToString() + ")";
            this.LoadData();
        }
        void ctrlQFind_BeforeFilter()
        {
            this.dtblPrds = this.dtblIniPrds.Copy();
            this.dgrdv.DataSource = this.dtblPrds;
        } 

     
        private bool allowappendflag = false;
        public bool AllowAppendFlag
        {
            get
            {
                return this.allowappendflag;
            }
            set
            {
                this.allowappendflag = value;
                this.lnkNew .Visible = value;
            }
        }
        void btnSearch_Click(object sender, EventArgs e)
        {
            this.whereclause = string.Empty;
            if (this.ckbPrdCode.Checked)
            {
                this.whereclause += "and (PrdCode like '%" + this.txtPrdCode.Text + "%')";
            }
            if (this.ckbPrdName.Checked)
            {
                this.whereclause += "and (PrdName like '%" + this.txtPrdName.Text + "%')";
            }
            if (this.ckbPrdSpec.Checked)
            {
                this.whereclause += "and (PrdSpec like '%" + this.txtPrdSpec.Text + "%')";
            }
            if (this.ckbModel.Checked)
            {
                this.whereclause += " and (Model like '%" + this.txtModel.Text + "%')";
            }
            if (this.ckbManufacturer.Checked)
            {
                this.whereclause += " and (Manufacturer like '%" + this.txtManufacturer.Text + "%')";
            }
            if (this.ckbAssistantCode.Checked)
            {
                this.whereclause += " and (AssistantCode like '%" + this.txtAssistantCode.Text + "%')";
            }
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
     

        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
            if (this.frmNew == null)
            {
                this.frmNew = new FrmPrdNew();
                new FrmStyle(frmNew).SetPopFrmStyle(this);
                frmNew.AffterSave += this.LoadData;                
            }
            frmNew.NewPrd();
            frmNew.ShowDialog();
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
            if (this.dgrdv.Columns[icol].Name == this.ColumnlnkImgs.Name)
            {
              
                dir = JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdImg\" + PrdID.ToString();
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