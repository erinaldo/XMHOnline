using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Report
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accPrds = new JERPData.Product.Product();
            this.SetPermit();
        }
        private JERPData.Product.Product accPrds;
        private DataTable dtblIniPrds, dtblPrds;
        private FrmProductDetail frmDetail;
        private JCommon.FrmFileBrowse frmFileBrowse;
        private JCommon.FrmImgBrowse frmImgBrowse;
        private FrmPrdSet frmPrdSet;
        private string whereclause = string.Empty;
        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(71);
            if (this.enableBrowse)
            {
                this.ctrlPrdTypeID.AffterSelected += new JERPApp.Define.Product.CtrlPrdTypeTree.AffterSelectDelegate(ctrlPrdTypeID_AffterSelected);
                this.ctrlQFind.BeforeFilter += new JCommon.CtrlGridFind.BeforeFilterDelegate(ctrlQFind_BeforeFilter);
                this.btnSearch.Click += new EventHandler(btnSearch_Click); 
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            }
         
        }

      
        void ctrlQFind_BeforeFilter()
        {
            this.dtblPrds = this.dtblIniPrds.Copy();
            this.dgrdv.DataSource = this.dtblPrds;
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
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        void ctrlPrdTypeID_AffterSelected()
        {
            this.whereclause = " and (PrdTypeID=" + this.ctrlPrdTypeID.PrdTypeID.ToString() + ")";
            this.LoadData();
        }

        private bool GetParentFlag(int PrdID)
        {
            bool flag = false;
            this.accPrds.GetParmProductParentFlag(PrdID, ref flag);
            return flag;
        }
        private void LoadData()
        {
            this.dtblIniPrds = this.accPrds.GetDataProductByFreeSearch(this.whereclause).Tables[0];
            this.dtblIniPrds.Columns.Add("Mark", typeof(Image));
            foreach (DataRow drow in this.dtblIniPrds.Rows)
            {
                if (this.GetParentFlag((int)drow["PrdID"]))
                {
                    drow["Mark"] = global::JERPApp.Properties.Resources.plus;
                }
                else
                {
                    drow["Mark"] = global::JERPApp.Properties.Resources.subtract;
                }
            }
            this.dtblPrds = this.dtblIniPrds.Copy();
            this.dgrdv.DataSource = this.dtblPrds;

        }
       
       
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            int PrdID = (int)this.dtblPrds.DefaultView[irow]["PrdID"];
            if (this.dgrdv.Columns[icol].Name == this.ColumnMark.Name)
            {
               
                if (this.frmDetail == null)
                {
                    this.frmDetail = new FrmProductDetail();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);
                }
                this.frmDetail.PrdDetail (PrdID);
                this.frmDetail.ShowDialog();
            } 
            if (this.dgrdv.Columns[icol].Name == this.ColumnPrdSetCount .Name)
            {

                if (this.frmPrdSet  == null)
                {
                    this.frmPrdSet = new FrmPrdSet();
                    new FrmStyle(frmPrdSet).SetPopFrmStyle(this);
                }
                this.frmPrdSet.PrdSetBom (PrdID);
                this.frmPrdSet.ShowDialog();
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnFileCount .Name)
            {
                if (frmFileBrowse == null)
                {
                    frmFileBrowse = new JCommon.FrmFileBrowse();
                    frmFileBrowse.ReadOnly =true;
                    new FrmStyle(frmFileBrowse).SetPopFrmStyle(this);

                }
                frmFileBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdFile\" + PrdID.ToString());
                frmFileBrowse.ShowDialog();
            
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnImgCount .Name)
            {
                if (frmImgBrowse == null)
                {
                    frmImgBrowse = new JCommon.FrmImgBrowse();
                    frmImgBrowse.ReadOnly =true;
                    new FrmStyle(frmImgBrowse).SetPopFrmStyle(this);
                }
                frmImgBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdImg\" + PrdID.ToString());
                frmImgBrowse.ShowDialog();
              
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnURL .Name)
            {
                System.Diagnostics.Process.Start(this.dgrdv[icol, irow].Value.ToString());

            }
        }
       


    }
}