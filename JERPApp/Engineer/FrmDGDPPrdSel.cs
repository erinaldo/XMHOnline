using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer
{
    public partial class FrmDGDPPrdSel : Form
    {
        public FrmDGDPPrdSel()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accPrds = new JERPData.Product.ComProduct();
            this.accUnits = new JERPData.General.Unit();
            this.accProductTypePro = new JERPData.Product.DPPrdTypePro();
            this.accDPPrdType = new JERPData.Product.DPPrdTypePro();
            this.SetPermit();
        }


        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存


        private JERPData.Product.ComProduct accPrds;
        private JERPData.General.Unit accUnits;

        private DataTable dtbliniProduct, dtblProduct, dtblUnits, dtbManuPrdType1, dtbManuPrdType2, dtbManuPrdType3, dtbManuPrdType4;

        //类型
        private JERPData.Product.DPPrdTypePro accDPPrdType;
        //属性
        private JERPData.Product.DPPrdTypePro accProductTypePro;

        //private DataTable dtblPrdType;



        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(28);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(29);
            if (this.enableBrowse)
            {
                this.SetColumnSrc();
                this.LoadData();
                this.FormClosed += new FormClosedEventHandler(FrmProduct_FormClosed);
            }
            if (this.enableSave)
            {
                this.SetManuPrdType1Src("车削系统", 0);
                cmbMenuPrdType1.SelectedIndex = -1;

                this.dgrdv.ContextMenuStrip = this.cMenu;
         
                this.cmbMenuPrdType1.SelectedIndexChanged += new EventHandler(cmbMenuPrdType1_SelectedIndexChanged);
                this.cmbMenuPrdType2.SelectedIndexChanged += new EventHandler(cmbMenuPrdType2_SelectedIndexChanged);
                this.cmbMenuPrdType3.SelectedIndexChanged += new EventHandler(cmbMenuPrdType3_SelectedIndexChanged);
                this.cmbMenuPrdType4.SelectedIndexChanged += new EventHandler(cmbMenuPrdType4_SelectedIndexChanged);

                this.chkGetTypePro.Click += new EventHandler(chkGetTypePro_Click);

                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);

            }     
            //initDgrdv("FrmManuPrdDefine");

        }

        //初始化dgrdv控件，增加列
        private void initDgrdv(String name)
        {
            DataSet ds = accPrds.GetDataManuProductTypeProTable();

            for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            {

                DataGridViewComboBoxColumn colbox = new DataGridViewComboBoxColumn();
                DataRow datarow = ds.Tables[0].Rows[row];
                String fieldName = (String)datarow["FFieldName"];
                String fieldText = (String)datarow["FFieldText"];
                String type = (String)datarow["FType"];
                String TypeParentID = (String)datarow["FTypeParentID"];
                if (type.Equals("1"))
                {
                    colbox.HeaderText = fieldText;
                    colbox.Name = fieldName;
                    colbox.Visible = true;
                    colbox.DataPropertyName = fieldName;
                    colbox.DisplayIndex = dgrdv.Columns.Count + row + 1;

                    int TParentID = Int32.Parse(TypeParentID);
                    colbox.DataSource = this.accDPPrdType.GetDataDPPrdTypeProByParentID(TParentID).Tables[0];
                    colbox.ValueMember = "PrdTypeID";
                    colbox.DisplayMember = "PrdTypeName";
                    dgrdv.Columns.Add(colbox);
                }
             
            }
        }


        void cmbMenuPrdType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String name = cmbMenuPrdType1.Text;
            int parentID = Int32.Parse(cmbMenuPrdType1.SelectedValue.ToString());
            this.cmbMenuPrdType2.SelectedIndexChanged -= new EventHandler(cmbMenuPrdType2_SelectedIndexChanged);
            SetManuPrdType2Src(name, parentID);
            ClearCmbVaue(cmbMenuPrdType2);
            ClearCmbVaue(cmbMenuPrdType3);
            ClearCmbVaue(cmbMenuPrdType4);
            LoadData();
            this.cmbMenuPrdType2.SelectedIndexChanged += new EventHandler(cmbMenuPrdType2_SelectedIndexChanged);
        }

        void cmbMenuPrdType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String name = cmbMenuPrdType2.Text;
            int parentID = Int32.Parse(cmbMenuPrdType2.SelectedValue.ToString());
            this.cmbMenuPrdType3.SelectedIndexChanged -= new EventHandler(cmbMenuPrdType3_SelectedIndexChanged);
            SetManuPrdType3Src(name, parentID);
            ClearCmbVaue(cmbMenuPrdType3);
            ClearCmbVaue(cmbMenuPrdType4);
            LoadData();
            this.cmbMenuPrdType3.SelectedIndexChanged += new EventHandler(cmbMenuPrdType3_SelectedIndexChanged);
        }

        void cmbMenuPrdType3_SelectedIndexChanged(object sender, EventArgs e)
        {
            String name = cmbMenuPrdType3.Text;
            int parentID = Int32.Parse(cmbMenuPrdType3.SelectedValue.ToString());
            this.cmbMenuPrdType4.SelectedIndexChanged -= new EventHandler(cmbMenuPrdType4_SelectedIndexChanged);
            SetManuPrdType4Src(name, parentID);
            ClearCmbVaue(cmbMenuPrdType4);
            LoadData();
            this.cmbMenuPrdType4.SelectedIndexChanged += new EventHandler(cmbMenuPrdType4_SelectedIndexChanged);
        }


        void chkGetTypePro_Click(Object sender,EventArgs e) {
            this.LoadData();
        }

        private  void ClearCmbVaue(ComboBox cmbOject){
            cmbOject.SelectedIndex = -1;
            cmbOject.Text = "";
        }



        void cmbMenuPrdType4_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadData();
        }

        //设置部分列的来源
        private void SetColumnSrc()
        {
            this.dtblUnits = this.accUnits.GetDataUnit().Tables[0];
            this.ColumnUnitID.DataSource = this.dtblUnits;
            this.ColumnUnitID.ValueMember = "UnitID";
            this.ColumnUnitID.DisplayMember = "UnitName";

        }

        private void SetManuPrdType1Src(String name, int parentID)
        {
            if (name.Equals("") || parentID < 0) return ;

            this.dtbManuPrdType1 = this.accPrds.GetDataComPrdTypeByManuPrdTypeNameAndParentID(name, parentID).Tables[0];
            this.cmbMenuPrdType1.DataSource = this.dtbManuPrdType1;
            this.cmbMenuPrdType1.ValueMember = "PrdTypeID";
            this.cmbMenuPrdType1.DisplayMember = "PrdTypeName";

        }

        private void SetManuPrdType2Src(String name, int parentID)
        {
            if (name.Equals("") || parentID < 0) return;
            this.dtbManuPrdType2 = this.accPrds.GetDataComPrdTypeByParentID(parentID).Tables[0];
            this.cmbMenuPrdType2.DataSource = this.dtbManuPrdType2;
            this.cmbMenuPrdType2.ValueMember = "PrdTypeID";
            this.cmbMenuPrdType2.DisplayMember = "PrdTypeName";

        }
        private void SetManuPrdType3Src(String name, int parentID)
        {
            if (name.Equals("") || parentID < 0) return;
            this.dtbManuPrdType3 = this.accPrds.GetDataComPrdTypeByParentID(parentID).Tables[0];
            this.cmbMenuPrdType3.DataSource = this.dtbManuPrdType3;
            this.cmbMenuPrdType3.ValueMember = "PrdTypeID";
            this.cmbMenuPrdType3.DisplayMember = "PrdTypeName";
        }
        private void SetManuPrdType4Src(String name, int parentID)
        {
            if (name.Equals("") || parentID < 0) return;
            this.dtbManuPrdType4 = this.accPrds.GetDataProductByPrdTypeID(parentID).Tables[0];
            this.cmbMenuPrdType4.DataSource = this.dtbManuPrdType4;
            this.cmbMenuPrdType4.ValueMember = "PrdTypeID";
            this.cmbMenuPrdType4.DisplayMember = "PrdTypeName";
        }


        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }


        private void LoadData()
        {
            if (cmbMenuPrdType4.SelectedValue == null) return ;

            int PrdTypeID = Int32.Parse(cmbMenuPrdType4.SelectedValue.ToString());
            if ( PrdTypeID == 0) return;

            if (chkGetTypePro.Checked)
            {
                this.dtbliniProduct = this.accPrds.GetDataAllDGDPProductByPrdTypeID(PrdTypeID).Tables[0];   
            }
            else
            {
                this.dtbliniProduct = this.accPrds.GetDataDGProductByPrdTypeID(PrdTypeID).Tables[0];
            }
            //AddOtherCol(this.dtbliniProduct);//增加属性列

            //this.dtbliniProduct.Columns["PrdCode"].Unique = true;
            //this.dtbliniProduct.Columns["PrdCode"].AllowDBNull = false;
            this.dtbliniProduct.Columns["UnitID"].AllowDBNull = false;
            this.dtbliniProduct.Columns["UnitID"].DefaultValue = 1;// 

            this.dtblProduct = this.dtbliniProduct.Copy();
            this.dgrdv.DataSource = this.dtblProduct;

        }



        void FrmProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }
        public delegate void AffterSaveDelegate();
        private AffterSaveDelegate affterSave;
        public event AffterSaveDelegate AffterSave
        {
            add
            {
                affterSave += value;
            }
            remove
            {
                affterSave -= value;
            }
        }

        private void dgrdv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
           
        }

    }
}
