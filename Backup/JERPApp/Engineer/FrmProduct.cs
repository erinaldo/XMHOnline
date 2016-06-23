using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer
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
        private DataTable dtblIniPrds,dtblPrds;
        private FrmPrdClone frmClone;
        private FrmProductOper frmOper;
        private FrmPrdSetOper frmPrdSetOper;
        private FrmBOMMove frmBOMRemove;
        private JCommon.FrmFileBrowse frmFileBrowse;
        private JCommon.FrmImgBrowse frmImgBrowse;
        private string whereclause = string.Empty;
        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private bool enableSave = false;//±£´æ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(69);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(70);
            if (this.enableBrowse)
            {
               
                this.ctrlPrdTypeID.AffterSelected += new JERPApp.Define.Product.CtrlPrdTypeTree.AffterSelectDelegate(ctrlPrdTypeID_AffterSelected); 
                this.ctrlQFind .BeforeFilter +=new JCommon.CtrlGridFind.BeforeFilterDelegate(ctrlQFind_BeforeFilter);
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
            }
            this.lnkNew.Enabled = this.enableSave; 
            this.lnkClone.Enabled = this.enableSave;
            this.lnkRemove.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.lnkRemove.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkRemove_LinkClicked);
                this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.lnkClone.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkClone_LinkClicked);
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            }
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
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

        void ctrlPrdTypeID_AffterSelected()
        {
            this.whereclause = " and (PrdTypeID=" + this.ctrlPrdTypeID.PrdTypeID.ToString() + ")";
            this.LoadData();
        }

        void lnkRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmBOMRemove == null)
            {
                frmBOMRemove = new FrmBOMMove();
                new FrmStyle(frmBOMRemove).SetPopFrmStyle(this);               
            }
            frmBOMRemove.ShowDialog();
        }

      
        void lnkClone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmClone == null)
            {
                frmClone = new FrmPrdClone();
                new FrmStyle(frmClone).SetPopFrmStyle(this);
                frmClone.Click += new EventHandler(frmClone_Click);
            }
            frmClone.ShowDialog();
        }

        void frmClone_Click(object sender, EventArgs e)
        {
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
                if (this.GetParentFlag ((int)drow["PrdID"]))
                {
                    drow["Mark"] = global::JERPApp.Properties.Resources.plus;
                }
                else
                {
                    drow["Mark"] = global::JERPApp.Properties.Resources.subtract;
                }
            }
            this.dtblPrds  = this.dtblIniPrds .Copy();
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
             
                if (this.frmOper == null)
                {
                    this.frmOper = new FrmProductOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    this.frmOper.AffterSave += this.LoadData;
                }
                this.frmOper.Edit (PrdID);
                this.frmOper.ShowDialog();
            } 
            if (this.dgrdv.Columns[icol].Name == this.ColumnPrdSetCount.Name)
            {
                if (frmPrdSetOper == null)
                {
                    frmPrdSetOper = new FrmPrdSetOper();
                    new FrmStyle(frmPrdSetOper).SetPopFrmStyle(this);
                    frmPrdSetOper.AffterSave += new FrmPrdSetOper.AffterSaveDelegate(frmSetBomOper_AffterSave);
                }
                frmPrdSetOper.PrdSetBomOper(PrdID );
                frmPrdSetOper.ShowDialog();
            }
            string errormsg = string.Empty;
            if (this.dgrdv.Columns[icol].Name == this.ColumnFileCount .Name)
            {
                if (frmFileBrowse == null)
                {
                    frmFileBrowse = new JCommon.FrmFileBrowse();
                    frmFileBrowse.ReadOnly = !this.enableSave ;
                    new FrmStyle(frmFileBrowse).SetPopFrmStyle(this);

                }
                frmFileBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdFile\" + PrdID.ToString());
                frmFileBrowse.ShowDialog();
                this.dgrdv[icol, irow].Value = frmFileBrowse.Count;
                this.accPrds.UpdateProductForFileCount(
                    ref errormsg,
                    PrdID,
                    frmFileBrowse.Count);
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnImgCount .Name)
            {
                if (frmImgBrowse == null)
                {
                    frmImgBrowse = new JCommon.FrmImgBrowse();
                    frmImgBrowse.ReadOnly =!this.enableSave ;
                    new FrmStyle(frmImgBrowse).SetPopFrmStyle(this);
                }
                frmImgBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdImg\" + PrdID.ToString());
                frmImgBrowse.ShowDialog();
                this.dgrdv[icol, irow].Value = frmImgBrowse.Count;
                this.accPrds.UpdateProductForImgCount(ref errormsg,
                    PrdID,
                    frmImgBrowse.Count);
            }
        }
        void frmSetBomOper_AffterSave(int SetPrdCount)
        {
            this.dgrdv.CurrentCell.Value = SetPrdCount;
        }
        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.frmOper == null)
            {
                this.frmOper = new FrmProductOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                this.frmOper.AffterSave += this.LoadData;
            }
            this.frmOper.New();
            this.frmOper.ShowDialog();
        }


    }
}