using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            this.SetPermit();
        }

        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存


        private JERPData.Product.ManuProduct accPrds;
        private JERPData.General.Unit accUnits;
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
            DataSet ds = accPrds.GetTypePro();
            //String[] FieldNames = new String[] { "FieldName","Type" ,"FieldType" ,"FieldText"};
            for(int row= 0;row < ds.Tables[0].Rows.Count;row ++){
                DataGridViewComboBoxColumn colbox = new DataGridViewComboBoxColumn();
                DataRow datarow=  ds.Tables[0].Rows[row];
                String fieldName = (String) datarow["FieldName"];
                String fieldText = (String) datarow["FieldText"];
                String type = (String) datarow["Type"];
                String TypeParentID = (String)datarow["TypeParentID"];
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
            for (int irow = 0; irow < this.dgrdv.Rows.Count - 1; irow++)
            {
                if (this.dgrdv.Rows[irow].Selected)
                {
                    this.SaveRow(PrdTypeID, this.dtblProduct.DefaultView[irow].Row);
                }
            }
            MessageBox.Show("成功变换当前选中行的类别");
            this.LoadData();
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

        ////增加类型的
        //private void AddOtherCol(DataTable dt) {
        //    DataSet ds = accPrds.GetTypePro();
        //    //String[] FieldNames = new String[] { "FieldName","Type" ,"FieldType" ,"FieldText"};
        //    for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
        //    {
        //        DataRow datarow = ds.Tables[0].Rows[row];
        //        String fieldName = (String)datarow["FieldName"];
        //        String type = (String)datarow["Type"];
        //        if (type.Equals("1"))
        //        {
        //            dt.Columns.Add(fieldName, typeof(int));
        //        }
        //    }
        //}

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
                drow.AcceptChanges();
            }
            MessageBox.Show("成功保存了产品定义");
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
                         -1,
                         drow["ProType2"],
                         drow["ProType3"],
                         -1,
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
                        0//drow["StopFlag"]
                        );
            }
            if (flag)
            {
                drow.AcceptChanges();
                //增加属性
                this.accProductTypePro.UpdateManuProductTypePro(
                     ref errormsg,
                     drow["PrdID"],
                     -1,
                     drow["ProType2"],
                     drow["ProType3"],
                     -1,
                     -1,
                     -1,
                     -1
                    );
            }
            else
            {
                MessageBox.Show(errormsg);
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
                    new DataColumn ("型号",typeof (string)),                     
                    new DataColumn ("封装/表面处理",typeof (string)),                     
                    new DataColumn ("品牌",typeof (string)),    
                    new DataColumn ("单位",typeof (string)),            
                    new DataColumn ("销售",typeof (string)),                    
                    new DataColumn ("助记码",typeof (string)),                     
                    new DataColumn ("图号",typeof (string)),   
                    new DataColumn ("最小包装",typeof (decimal)),
                    new DataColumn ("网址",typeof (string)),
                    new DataColumn ("备注",typeof (string)),
                    new DataColumn ("停用",typeof (string)),                                
                    new DataColumn ("保税料",typeof (string)),    
                    new DataColumn ("Rohs合格",typeof (string)),    
                    new DataColumn ("Rohs要求",typeof (string)),   
                    new DataColumn ("单重",typeof (decimal))      
                };
                this.frmImport.SetImportColumn(columns, "产品编号不能为空，单位不填默认为PCS,保税料,Rohs填是或不填");
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
            bool SaleFlag = this.GetBool(drow["销售"].ToString());
            bool TaxfreeFlag = this.GetBool(drow["保税料"].ToString());
            bool RohsFlag = this.GetBool(drow["Rohs合格"].ToString());
            bool RohsRequireFlag = this.GetBool(drow["Rohs要求"].ToString());
            bool StopFlag = this.GetBool(drow["停用"].ToString());
            DataRow drowNew = this.dtblProduct.NewRow();
            drowNew["PrdCode"] = drow["产品编号"];
            drowNew["PrdName"] = drow["产品名称"];
            drowNew["PrdSpec"] = drow["产品规格"];
            drowNew["Model"] = drow["型号"];
            drowNew["Surface"] = drow["封装/表面处理"];
            drowNew["Manufacturer"] = drow["品牌"];
            drowNew["DWGNo"] = drow["图号"];
            drowNew["AssistantCode"] = drow["助记码"];
            drowNew["MinPackingQty"] = drow["最小包装"];
            drowNew["PrdWeight"] = drow["单重"];
            drowNew["SaleFlag"] = SaleFlag;
            drowNew["TaxfreeFlag"] = TaxfreeFlag;
            drowNew["RohsFlag"] = RohsFlag;
            drowNew["RohsRequireFlag"] = RohsRequireFlag;
            drowNew["UnitID"] = this.GetUnitID(UnitName);
            drowNew["URL"] = drow["网址"];
            drowNew["Memo"] = drow["备注"];
            drowNew["StopFlag"] = StopFlag;
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
    }
}
