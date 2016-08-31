using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer
{
    public partial class FrmCommonProduct : Form
    {
        public FrmCommonProduct()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accComPrds = new JERPData.Product.ComProduct();
            this.SetPermit();
        }

        private JERPData.Product.ComProduct accComPrds;
        private DataTable dtblIniComPrds, dtblComPrds;
        //private FrmPrdClone frmClone;
        private FrmCommonProductOper frmComOper;
        //private FrmPrdSetOper frmPrdSetOper;
        //private FrmBOMMove frmBOMRemove;
        private JCommon.FrmFileBrowse frmFileBrowse;
        private JCommon.FrmImgBrowse frmImgBrowse;
        private string whereclause = string.Empty;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(102);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(103);
            if (this.enableBrowse)
            {
                this.ctrlPrdTypeID.AffterSelected += new JERPApp.Define.Product.CtrlCommonTypeTree.AffterSelectDelegate(ctrlPrdTypeID_AffterSelected);
                this.ctrlQFind.BeforeFilter += new JCommon.CtrlGridFind.BeforeFilterDelegate(ctrlQFind_BeforeFilter);
                this.btnSearch.Click += new EventHandler(btnSearch_Click);
            }
            //this.lnkNew.Enabled = this.enableSave;
            //this.lnkClone.Enabled = this.enableSave;
            //this.lnkRemove.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            }
        }

        void ctrlPrdTypeID_AffterSelected()
        {
            this.whereclause = " and (PrdTypeID=" + this.ctrlPrdTypeID.PrdTypeID.ToString() + ")";
            this.LoadData();
        }


        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            int PrdID = (int)this.dtblComPrds.DefaultView[irow]["PrdID"];
            if (this.dgrdv.Columns[icol].Name == this.ColumnMark.Name)
            {

                if (this.frmComOper == null)
                {
                    this.frmComOper = new FrmCommonProductOper();
                    new FrmStyle(frmComOper).SetPopFrmStyle(this);
                    this.frmComOper.AffterSave += this.LoadData;
                }
                this.frmComOper.Edit(PrdID);
                this.frmComOper.ShowDialog();
            }
            //if (this.dgrdv.Columns[icol].Name == this.ColumnPrdSetCount.Name)
            //{
            //    if (frmPrdSetOper == null)
            //    {
            //        frmPrdSetOper = new FrmPrdSetOper();
            //        new FrmStyle(frmPrdSetOper).SetPopFrmStyle(this);
            //        frmPrdSetOper.AffterSave += new FrmPrdSetOper.AffterSaveDelegate(frmSetBomOper_AffterSave);
            //    }
            //    frmPrdSetOper.PrdSetBomOper(PrdID);
            //    frmPrdSetOper.ShowDialog();
            //}
            string errormsg = string.Empty;
            if (this.dgrdv.Columns[icol].Name == this.ColumnFileCount.Name)
            {
                if (frmFileBrowse == null)
                {
                    frmFileBrowse = new JCommon.FrmFileBrowse();
                    frmFileBrowse.ReadOnly = !this.enableSave;
                    new FrmStyle(frmFileBrowse).SetPopFrmStyle(this);

                }
                frmFileBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdFile\" + PrdID.ToString());
                frmFileBrowse.ShowDialog();
                this.dgrdv[icol, irow].Value = frmFileBrowse.Count;
                this.accComPrds.UpdateDGProductForImgCount(
                    ref errormsg,
                    PrdID,
                    frmFileBrowse.Count);
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnImgCount.Name)
            {
                if (frmImgBrowse == null)
                {
                    frmImgBrowse = new JCommon.FrmImgBrowse();
                    frmImgBrowse.ReadOnly = !this.enableSave;
                    new FrmStyle(frmImgBrowse).SetPopFrmStyle(this);
                }
                frmImgBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdImg\" + PrdID.ToString());
                frmImgBrowse.ShowDialog();
                this.dgrdv[icol, irow].Value = frmImgBrowse.Count;
                this.accComPrds.UpdateProductForImgCount(ref errormsg,
                    PrdID,
                    frmImgBrowse.Count);
            }
        }

        private void LoadData()
        {
            this.dtblIniComPrds = this.accComPrds.GetDataComProductByFreeSearch(this.whereclause).Tables[0];
            this.dtblIniComPrds.Columns.Add("Mark", typeof(Image));
            foreach (DataRow drow in this.dtblIniComPrds.Rows)
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
            this.dtblComPrds = this.dtblIniComPrds.Copy();
            this.dgrdv.DataSource = this.dtblComPrds;

        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }


        private bool GetParentFlag(int PrdID)
        {
            bool flag = false;
            this.accComPrds.GetParmComProductParentFlag(PrdID, ref flag);
            return flag;
        }

        void ctrlQFind_BeforeFilter()
        {
            this.dtblComPrds = this.dtblIniComPrds.Copy();
            this.dgrdv.DataSource = this.dtblComPrds;
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

    }
}
