using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer
{
    public partial class FrmManuPrdDefine : Form
    {
        public FrmManuPrdDefine()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accPrds = new JERPData.Product.ManuProduct();
            this.accUnits = new JERPData.General.Unit();
            this.accManuPrdType = new JERPData.Product.ManuPrdType();
            this.accProductTypePro = new JERPData.Product.ManuProductTypePro();
            this.accProType = new JERPData.General.PrdProType();
            this.SetPermit();
        }

        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存


        private JERPData.Product.ManuProduct accPrds;
        private JERPData.General.Unit accUnits;
        private JERPData.General.PrdProType accProType;

        private DataTable dtbliniProduct, dtblProduct, dtblUnits;

        //类型
        private JERPData.Product.ManuPrdType accManuPrdType;
        //属性
        private JERPData.Product.ManuProductTypePro accProductTypePro;

        //private DataTable dtblPrdType;

        private JERPApp.Define.Product.FrmManuPrdType frmPrdType;
        private JCommon.FrmExcelImport frmImport;

        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(13);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(14);
            if (this.enableBrowse)
            {
                this.SetColumnSrc();
                this.LoadData();
                this.ctrlQFind.SeachGridView = this.dgrdv;
                this.ctrlQFind.BeforeFilter += new JCommon.CtrlGridFind.BeforeFilterDelegate(ctrlQFind_BeforeFilter);
                this.ctrlPrdTypeID.AffterSelected += this.LoadData;
                this.ctrlPrdTypeID.BeforeSelected += new JERPApp.Define.Product.CtrlCommonTypeTree.BeforeSelectDelegate(ctrlPrdTypeID_BeforeSelected);
                this.FormClosed += new FormClosedEventHandler(FrmProduct_FormClosed);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);


            }
            this.btnImport.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemPrdType.Click += new EventHandler(mItemPrdType_Click);

                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.ctrlPrdTypeID.AllowDefine();
                this.btnSave.Click += new EventHandler(btnSave_Click);
                this.btnImport.Click += new EventHandler(btnImport_Click);
                this.dgrdv.RowEnter += new DataGridViewCellEventHandler(dgrdv_RowEnter);
                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
                this.btnExport.Click += new EventHandler(btnExport_Click);

            }

            initDgrdv("FrmManuPrdDefine");

        }

        //初始化dgrdv控件，增加列
        private void initDgrdv(String name) {
            DataSet ds = accPrds.GetDataManuProductTypeProTable();
            //String[] FieldNames = new String[] { "FieldName","Type" ,"FieldType" ,"FieldText"};
            for(int row= 0;row < ds.Tables[0].Rows.Count;row ++){
                DataGridViewComboBoxColumn colbox = new DataGridViewComboBoxColumn();
                DataRow datarow=  ds.Tables[0].Rows[row];
                String fieldName = (String) datarow["FFieldName"];
                String fieldText = (String) datarow["FFieldText"];
                String type = (String) datarow["FType"];
                String TypeParentID = (String)datarow["FTypeParentID"];
                if (type.Equals("1")){
                    colbox.HeaderText = fieldText ;
                    colbox.Name  = fieldName;  
                    colbox.Visible = true;
                    colbox.DataPropertyName = fieldName;
                    colbox.DisplayIndex = dgrdv.Columns.Count+row+1;

                    int TParentID = Int32.Parse(TypeParentID);
                    colbox.DataSource = this.accManuPrdType.GetDataPrdTypeByParentID(TParentID).Tables[0];
                    colbox.ValueMember = "ManuPrdTypeID";
                    colbox.DisplayMember = "ManuPrdTypeName";
                    dgrdv.Columns.Add(colbox);


                }
            }
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

        void dgrdv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow < 1) || (icol == -1)) return;
            object objUnitID = this.dgrdv[this.ColumnUnitID.Name, irow].Value;
            if ((objUnitID == null) || (objUnitID == DBNull.Value))
            {
                this.dgrdv[this.ColumnUnitID.Name, irow].Value = this.dgrdv[this.ColumnUnitID.Name, irow - 1].Value;
            }


        }
        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            DataRow drow = this.dtblProduct.DefaultView[irow].Row;
            if (drow["PrdID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
            string errorMsg = String.Empty;
            Boolean flag = accPrds.DeleteProduct(ref errorMsg, drow["PrdID"]);
            if (!flag)
            {
                e.Cancel = true;
                return;
            }
            e.Cancel = true;
            MessageBox.Show("删除成功。");
            accProductTypePro.DeleteManuProductTypePro(ref errorMsg, drow["PrdID"]); //删除相关属性
        }

        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "类型:" + this.ctrlPrdTypeID.PrdTypeName);
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, false);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.Show();
            FrmMsg.Hide();
        }

        void mItemPrdType_Click(object sender, EventArgs e)
        {
            if (frmPrdType == null)
            {
                frmPrdType = new JERPApp.Define.Product.FrmManuPrdType();
                new FrmStyle(frmPrdType).SetPopFrmStyle(this);
                frmPrdType.AffterSelected += new JERPApp.Define.Product.FrmManuPrdType.AffterSelectedDelegate(frmPrdType_AffterSelected);
            }
            frmPrdType.ShowDialog();
        }


        void frmPrdType_AffterSelected()
        {
            int PrdTypeID = this.frmPrdType.PrdTypeID;
            DataGridViewCell cuCell = this.dgrdv.CurrentCell;
            //if(cuCell != null && cuCell.RowIndex >=0 && cuCell.ColumnIndex >=0 )
            //{
            //    Debug.WriteLine(cuCell.RowIndex + ":" + cuCell.ColumnIndex );
            //}
            bool flag = false;
            String errormsg = String.Empty; 
            for (int irow = 0; irow < this.dgrdv.Rows.Count - 1; irow++)
            {
                if (this.dgrdv.Rows[irow].Selected)
                {
                    this.ChangeManuPrdType(ref flag, ref errormsg , PrdTypeID, this.dtblProduct.DefaultView[irow].Row["PrdID"]);
                }
            }
            if (flag)
            {

                MessageBox.Show("成功变换当前选中行的类别");
                this.LoadData();
            }
            else {
                MessageBox.Show("变换类别失败:" + errormsg);
            }
            frmPrdType.Close();
        }


        //设置部分列的来源
        private void SetColumnSrc()
        {
            this.dtblUnits = this.accUnits.GetDataUnit().Tables[0];
            this.ColumnUnitID.DataSource = this.dtblUnits;
            this.ColumnUnitID.ValueMember = "UnitID";
            this.ColumnUnitID.DisplayMember = "UnitName";

        }

        void ctrlQFind_BeforeFilter()
        {
            this.dtblProduct = this.dtbliniProduct.Copy();
            this.dgrdv.DataSource = this.dtblProduct;
        }

        void FrmProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }

        void ctrlPrdTypeID_BeforeSelected(out bool CancelFlag)
        {
            if (this.dtblProduct.Select("", "", DataViewRowState.ModifiedCurrent).Length > 0)
            {
                DialogResult rul = MessageBox.Show("存在未保存的项,是否需要保存再选择?", "操作提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rul == DialogResult.OK)
                {
                    CancelFlag = true;
                    return;
                }
                CancelFlag = false;
                return;
            }
            CancelFlag = false;
        }



        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }


        private void LoadData()
        {

            this.dtbliniProduct = this.accPrds.GetDataProductByPrdTypeID(this.ctrlPrdTypeID.PrdTypeID).Tables[0];

            //AddOtherCol(this.dtbliniProduct);//增加属性列

            this.dtbliniProduct.Columns["PrdCode"].Unique = true;
            this.dtbliniProduct.Columns["PrdCode"].AllowDBNull = false;
            this.dtbliniProduct.Columns["UnitID"].AllowDBNull = false;
            this.dtbliniProduct.Columns["UnitID"].DefaultValue = 1;// 

            this.dtblProduct = this.dtbliniProduct.Copy();
            this.dgrdv.DataSource = this.dtblProduct;

        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            object objPrdID = this.dtblProduct.DefaultView[irow]["PrdID"];
            if ((objPrdID == null) || (objPrdID == DBNull.Value)) return;
            string errormsg = string.Empty;
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            foreach (DataRow drow in this.dtblProduct.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                this.SaveRow(this.ctrlPrdTypeID.PrdTypeID, drow);
            }
            MessageBox.Show("成保存了产品定义");
        }

        private bool ValidateData()
        {
            if (this.ctrlPrdTypeID.PrdTypeID == -1)
            {
                MessageBox.Show("产品类型不能为空");
                return false;
            }
            DataRow[] drows = this.dtblProduct.Select("PrdCode is null", "");
            if (drows.Length > 0)
            {
                MessageBox.Show("产品编号不能为空");
                return false;
            }
            return true;
        }

        private void ChangeManuPrdType(ref bool flag,ref String errormsg, int PrdTypeID, Object PrdID)
        {
            if (PrdID == DBNull.Value) return;
            flag = this.accPrds.UpdateManuProductForPrdTypeID(ref errormsg, PrdID, PrdTypeID);
        }

        private void SaveRow(int PrdTypeID, DataRow drow)
        {
            string errormsg = string.Empty;
            bool flag = false;
            int oldprdid = this.GetPrdID(drow["PrdCode"].ToString());
            if (drow["PrdID"] == DBNull.Value)
            {
                if (oldprdid > -1)
                {
                    drow.RowError = "对不起，此编号已存在";
                    return;
                }
                object objPrdID = DBNull.Value;
                flag = this.accPrds.InsertProductForImport(
                        ref errormsg,
                        ref objPrdID,
                        PrdTypeID,
                        drow["PrdCode"],
                        drow["PrdName"],
                        drow["PrdSpec"],
                        "",//drow["Model"],
                        "",//drow["Surface"],
                        "",//drow["Manufacturer"],
                        drow["AssistantCode"],
                        0,//drow["DWGNo"],
                        0,//drow["TaxfreeFlag"],
                        0,//drow["RohsFlag"],
                        0,//drow["RohsRequireFlag"],
                        0,//drow["PrdWeight"],
                        0,//drow["SaleFlag"],
                        drow["UnitID"],
                        0,//drow["MinPackingQty"],
                        drow["URL"],
                        drow["Memo"],
                        drow["CustomFlag"],
                        0//drow["StopFlag"]
                        );
                if (flag)
                {
                    drow["PrdID"] = objPrdID;
                    drow.AcceptChanges();
                    //增加属性
                    this.accProductTypePro.InsertManuProductTypePro(
                         ref errormsg,
                         drow["PrdID"],
                         drow["ProType1"],
                         drow["ProType2"],
                         drow["ProType3"],
                         drow["ProType4"],
                         -1,
                         -1,
                         -1
                        );
                    return;
                }
            }
            else
            {

                if ((oldprdid > -1) && (oldprdid != (int)drow["PrdID"]))
                {
                    drow.RowError = "此编号已被别的产品使用";
                    return;
                }
                flag = this.accPrds.UpdateProductForImport(
                        ref errormsg,
                        drow["PrdID"],
                        PrdTypeID,
                        drow["PrdCode"],
                        drow["PrdName"],
                        drow["PrdSpec"],
                        "",//drow["Model"],
                        "",//drow["Surface"],
                        "",//drow["Manufacturer"],
                        drow["AssistantCode"],
                        0,//drow["DWGNo"],
                        0,//drow["TaxfreeFlag"],
                        0,//drow["RohsFlag"],
                        0,//drow["RohsRequireFlag"],
                        0,//drow["PrdWeight"],
                        0,//drow["SaleFlag"],
                        drow["UnitID"],
                        0,//drow["MinPackingQty"],
                        drow["URL"],
                        drow["Memo"],
                        drow["CustomFlag"],
                        0//drow["StopFlag"]
                        );
                if (flag)
                {
                    drow.AcceptChanges();
                    //增加属性
                    this.accProductTypePro.UpdateManuProductTypePro(
                         ref errormsg,
                         drow["PrdID"],
                         drow["ProType1"],
                         drow["ProType2"],
                         drow["ProType3"],
                         drow["ProType4"],
                         -1,
                         -1,
                         -1
                        );
                }
            }
        }

        private int GetPrdID(string PrdCode)
        {
            int rut = -1;
            this.accPrds.GetParmProductPrdID(PrdCode, ref rut);
            return rut;

        }

        void btnImport_Click(object sender, EventArgs e)
        {

            if (this.frmImport == null)
            {
                this.frmImport = new JCommon.FrmExcelImport();
                new FrmStyle(frmImport).SetPopFrmStyle(this);
                this.frmImport.AffterSave += new JCommon.FrmExcelImport.AffterSaveDelegate(frmImport_AffterSave);
                this.frmImport.ImportHandle += new JCommon.FrmExcelImport.ImportDelegate(frmImport_ImportHandle);
                DataColumn[] columns = new DataColumn[] {      
                    new DataColumn ("产品编号",typeof (string)),
                    new DataColumn ("产品名称",typeof (string)),              
                    new DataColumn ("产品规格",typeof (string)),                 
                    new DataColumn ("单位",typeof (string)),            
                    new DataColumn ("助记码",typeof (string)),                     
                    new DataColumn ("客户产品",typeof (string)),   
                    new DataColumn ("备注",typeof (string)),

                    new DataColumn ("刀片R角",typeof (string)),                                
                    new DataColumn ("刀片左右手",typeof (string)),    
                    new DataColumn ("排屑槽",typeof (string)),    
                    new DataColumn ("被加工材料/刀片材质",typeof (string))
                };
                this.frmImport.SetImportColumn(columns, "产品编号不能为空，单位不填默认为PCS");
            }
            this.frmImport.ShowDialog();

        }
        void frmImport_AffterSave()
        {
            this.SetColumnSrc();
        }

        void frmImport_ImportHandle(DataRow drow, out bool flag, out string msg)
        {
            flag = true;
            msg = "成功!";
            object objPrdID = DBNull.Value;
            string UnitName = "PCS";
            if (drow["单位"] != DBNull.Value)
            {
                UnitName = drow["单位"].ToString();
            }
            int PrdID = this.GetPrdID(drow["产品编号"].ToString());
            if (PrdID > -1)
            {
                flag = false;
                msg = "已存在此编号";
                return;
            }
            bool CustomFlag = this.GetBool(drow["客户产品"].ToString());
            //bool StopFlag = this.GetBool(drow["停用"].ToString());
            DataRow drowNew = this.dtblProduct.NewRow();
            drowNew["PrdCode"] = drow["产品编号"];
            drowNew["PrdName"] = drow["产品名称"];
            drowNew["PrdSpec"] = drow["产品规格"];
            drowNew["UnitID"] = this.GetUnitID(UnitName);
            drowNew["AssistantCode"] = drow["助记码"];
            drowNew["Memo"] = drow["备注"];
            drowNew["CustomFlag"] = CustomFlag;

            drowNew["ProType1"] = GetPrdTypeID(drow["刀片R角"].ToString(), 71);
            drowNew["ProType2"] = GetPrdTypeID(drow["刀片左右手"].ToString(),114);
            drowNew["ProType3"] = GetPrdTypeID(drow["排屑槽"].ToString(), 73);
            drowNew["ProType4"] = GetPrdTypeID(drow["被加工材料/刀片材质"].ToString(), 72);

            //drowNew["StopFlag"] = StopFlag;
            this.dtblProduct.Rows.Add(drowNew);
        }

        bool GetBool(string BoolInfor)
        {
            return (BoolInfor == "是");
        }

        int GetUnitID(string UnitName)
        {
            int UnitID = 1;
            this.accUnits.GetParmUnitUnitID(ref UnitID, UnitName);
            return UnitID;
        }

        int GetPrdTypeID(string TypeName ,int patentID)
        {
            int PrdTypeID = -1;
            DataSet data =  this.accProType.GetDataManuPrdTypeByManuPrdTypeNameAndParentID(TypeName,patentID);
            if (data.Tables[0] != null && data.Tables[0].Rows.Count > 0)
            { 
                foreach (DataRow  datarow in data.Tables[0].Rows ){
                    PrdTypeID = (Int32)datarow[0];
                }
            }
            return PrdTypeID;
        }      
    }
}
