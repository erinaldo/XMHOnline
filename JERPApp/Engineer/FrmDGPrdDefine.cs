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
    public partial class FrmDGPrdDefine : Form
    {
        private static int m_DGType = 1;
        private static int DB_Type = 10;
        private static int m_DPType = 2;
        private static String TBNAME = "prd.Product_XMH";//另外加的部分
        private static String TBNAME_T = "Product_XMH";//另外加的部分
        private static String TBDEFINENAME = "prd.DGProDefine";//自定义字段定义部分
        private static String TBDEFINESAVENAME = "prd.DGProductPro";//自定义字段保存部分

        public FrmDGPrdDefine()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accPrd = new JERPData.Product.Product();
            this.accPrd_XMH = new JERPData.Product.Product_XMH();
            this.accData = new JERPData.Product.DGProDefine();
            this.accUnits = new JERPData.General.Unit();
            this.accDGPrdTypePro = new JERPData.Product.DGPrdTypePro();
            this.accOtherPrds = new JERPData.Product.OtherProducePro();
            this.accPrdType = new JERPData.Product.PrdType();
            this.accDGPrdTyprPro = new JERPData.Product.DGPrdTypePro();
            this.ctrlPrdTypeID.InitiaParam(m_DGType);
            initSql();
            this.SetPermit();
        }

        private void initSql()
        {
            M_SQL = getDGSQLDefine();
        }

        //权限码_
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存


        //private JERPData.Product.ComProduct accPrds;

        private JERPData.Product.Product accPrd;
        private JERPData.Product.Product_XMH accPrd_XMH;
        private JERPData.Product.DGProDefine accData;

        private JERPData.General.Unit accUnits;
        //private JERPData.General.ComPrdType accProType;

        private DataTable dtbliniProduct, dtblProduct, dtblUnits, dtblDPType;

        //类型
        private JERPData.Product.OtherProducePro accOtherPrds;

        //刀杠类型
        private JERPData.Product.DGPrdTypePro accDGPrdTypePro;

        //刀片类型
        private JERPData.Product.PrdType accPrdType;

        //属性
        private JERPData.Product.DGPrdTypePro accDGPrdTyprPro;

        private static String M_SQL = String.Empty;
        private static String M_PRE = "t1";


        //自定义相关的字段
        List<JERPBiz.Product.DGProDefineEntity> dgProDefineEntityList = new List<JERPBiz.Product.DGProDefineEntity>();

        //private DataTable dtblPrdType;

        //private JERPApp.Define.Product.FrmManuPrdType frmPrdType;
        private JERPApp.Define.Product.FrmPrdType frmPrdType;    

        private JCommon.FrmExcelImport frmImport;
        private JCommon.FrmImgBrowse frmImgBrowse;

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
            initDgrdv();
            //initDgrdvPro();//初始化其它属性字段
        }


        //初始化dgrdv控件，增加列
        private void initDgrdv()
        {
            DataSet ds = accDGPrdTypePro.GetDataDGProAndProTypeDefine();
            //String[] FieldNames = new String[] { "FieldName","Type" ,"FieldType" ,"FieldText"};
            for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            {
                DataGridViewComboBoxColumn colbox = new DataGridViewComboBoxColumn();
                DataRow datarow = ds.Tables[0].Rows[row];
                String fieldName = datarow["FFieldName"].ToString();
                String fieldText = datarow["FFieldText"].ToString();
                String Fvisable = datarow["Fvisable"].ToString();
                //String FTypeSrcID = (String)datarow["FTypeSrcID"];
                String FTypeSrcID = datarow["PrdTypeID"].ToString();

                if (!fieldName.Equals("PrdID"))
                {
                    if (Fvisable.Equals("1"))
                    {
                        colbox.HeaderText = fieldText;
                        colbox.Name = fieldName;
                        colbox.Visible = true;
                        colbox.DataPropertyName = fieldName;
                        colbox.DisplayIndex = dgrdv.Columns.Count + row + 1;

                        int TypeSrcID = Int32.Parse(FTypeSrcID);
                        colbox.DataSource = this.accDGPrdTyprPro.GetDataDGPrdTypeProByParentID(TypeSrcID).Tables[0];
                        colbox.ValueMember = "PrdTypeID";
                        colbox.DisplayMember = "PrdTypeName";
                        dgrdv.Columns.Add(colbox);
                    }
                    else
                    {

                        colbox.HeaderText = fieldText;
                        colbox.Name = fieldName;
                        colbox.Visible = false;
                        colbox.DataPropertyName = fieldName;
                        dgrdv.Columns.Add(colbox);
                    }

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
            Boolean flag = accPrd.DeleteProduct(ref errorMsg, drow["PrdID"]);
            if (flag)
            {
                accPrd_XMH.DeleteProduct_XMH(ref errorMsg, drow["PrdID"]); //删除特殊属性
                accDGPrdTypePro.DeleteDGProductPro(ref errorMsg, drow["PrdID"]); //删除相关属性
            }
            else {
                e.Cancel = true;
                return;
            }
            MessageBox.Show("删除成功。");
           
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
                frmPrdType = new JERPApp.Define.Product.FrmPrdType();
                new FrmStyle(frmPrdType).SetPopFrmStyle(this);
                frmPrdType.M_type = m_DGType;
                frmPrdType.AffterSelected += new JERPApp.Define.Product.FrmPrdType.AffterSelectedDelegate(frmPrdType_AffterSelected);
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
                    //this.ChangeManuPrdType(ref flag, ref errormsg, PrdTypeID, this.dtblProduct.DefaultView[irow].Row["PrdID"]);
                    try
                    {
                        this.SaveRow(PrdTypeID, this.dtblProduct.DefaultView[irow].Row);
                        flag = true;
                    }
                    catch (Exception ex)
                    {
                        flag = false;
                    }
                }
            }
            if (flag)
            {

                MessageBox.Show("成功变换当前选中行的类别");
                this.LoadData();
            }
            else
            {
                MessageBox.Show("变换类别失败:" + errormsg);
            }
            frmPrdType.Close();
        }


        //设置部分列的来源
        private void SetColumnSrc()
        {
            //单位来源
            this.dtblUnits = this.accUnits.GetDataUnit().Tables[0];
            this.ColumnUnitID.DataSource = this.dtblUnits;
            this.ColumnUnitID.ValueMember = "UnitID";
            this.ColumnUnitID.DisplayMember = "UnitName";

            //刀片类型来源
            this.dtblDPType = this.accPrdType.GetDataPrdTypeByType(m_DPType).Tables[0];
            this.ColumnDPType.DataSource = this.dtblDPType;
            this.ColumnDPType.ValueMember = "PrdTypeID";
            this.ColumnDPType.DisplayMember = "PrdTypeName";


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
            
            String sWhere = " where  " + M_PRE + ".PrdTypeID" + " = " + this.ctrlPrdTypeID.PrdTypeID;
            String sql = M_SQL + sWhere ;    
            this.dtbliniProduct = this.accPrd_XMH.GetDataProduct_XMHBySql(sql).Tables[0];

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
            if (this.dgrdv.Columns[icol].Name == this.ColumnImgCount.Name)
            {
                if (frmImgBrowse == null)
                {
                    frmImgBrowse = new JCommon.FrmImgBrowse();
                    frmImgBrowse.ReadOnly = !this.enableSave;
                    new FrmStyle(frmImgBrowse).SetPopFrmStyle(this);
                }
                frmImgBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdImg\" + objPrdID.ToString());
                frmImgBrowse.ShowDialog();
                this.dgrdv[icol, irow].Value = frmImgBrowse.Count;
                this.accPrd.UpdateProductForImgCount(ref errormsg,
                    objPrdID,
                    frmImgBrowse.Count);
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            bool isSvae = false;
            if (ValidateData() == false) return;
            foreach (DataRow drow in this.dtblProduct.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                this.SaveRow(this.ctrlPrdTypeID.PrdTypeID, drow);
                isSvae = true;
            }
            if (isSvae)
            {
                MessageBox.Show("成保存了产品定义");
            }
            else
            {
                MessageBox.Show("产品定义未变更，不需要保存");
            }
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

        //private void ChangeManuPrdType(ref bool flag, ref String errormsg, int PrdTypeID, Object PrdID)
        //{
        //    if (PrdID == DBNull.Value) return;
        //    flag = this.accPrd.UpdateProductForPrdTypeID(ref errormsg, PrdID, PrdTypeID);

        //}

        private void SaveRow(int PrdTypeID, DataRow drow)
        {
            string errormsg = string.Empty;
            bool flag = false;
            int oldprdid = this.GetPrdID(drow["PrdCode"].ToString());
            Object ID = DBNull.Value;
            if (drow["PrdID"] == DBNull.Value)
            {
                if (oldprdid > -1)
                {
                    drow.RowError = "对不起，此编号已存在";
                    return;
                }
                object objPrdID = DBNull.Value;
                flag = this.accPrd.InsertProductForImport(
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
                        drow["DWGNo"],
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
                    EditProduct_XMH(ref errormsg, objPrdID, drow);
                    drow["PrdID"] = objPrdID;
                    drow.AcceptChanges();
                    //属性
                    DGProductPro(ref errormsg, ref ID,objPrdID, drow);
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
                    flag = this.accPrd.UpdateProductForImport(
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
                    if (flag)
                    {
                        EditProduct_XMH(ref errormsg, drow["PrdID"], drow);
                        DGProductPro(ref errormsg, ref ID,drow["PrdID"],  drow);
                        drow.AcceptChanges();
                    }
            }
            
        }

        private void EditProduct_XMH(ref string errormsg ,Object objPrdID ,DataRow drow)
        {
            if (drow[TBNAME_T + "PrdID"] == null || drow[TBNAME_T + "PrdID"].ToString().Equals(""))
            {
                accPrd_XMH.InsertProduct_XMH(
                ref errormsg,
                objPrdID,
                drow[TBNAME_T + "DPType"],
                drow[TBNAME_T + "JMPrice"],
                drow[TBNAME_T + "PFPrice"],
                drow[TBNAME_T + "HYPrice"],
                drow[TBNAME_T + "LSPrice"],
                drow[TBNAME_T + "CustomCode"],
                drow[TBNAME_T + "Brand"],
                drow[TBNAME_T + "CustomFlag"]
                );
            }
            else {
                accPrd_XMH.UpdateProduct_XMH(
                ref errormsg,
                drow[TBNAME_T + "PrdID"],
                drow[TBNAME_T + "DPType"],
                drow[TBNAME_T + "JMPrice"],
                drow[TBNAME_T + "PFPrice"],
                drow[TBNAME_T + "HYPrice"],
                drow[TBNAME_T + "LSPrice"],
                drow[TBNAME_T + "CustomCode"],
                drow[TBNAME_T + "Brand"],
                drow[TBNAME_T + "CustomFlag"]
                );
            }
        }


        private void DGProductPro(ref string errormsg, ref Object ID, Object objPrdID , DataRow drow)
        {


            if (this.accDGPrdTypePro.GetDataDGProductByPrdID((int)objPrdID) == null || this.accDGPrdTypePro.GetDataDGProductByPrdID((int)objPrdID).Tables[0].Rows.Count == 0)
            {
                this.accDGPrdTypePro.InsertDGProductPro(
                    ref errormsg,
                    ref ID,
                    drow["PrdID"],
                    drow["ProType1"],
                    drow["ProType2"],
                    drow["ProType3"],
                    drow["ProType4"],
                    drow["ProType5"],
                    drow["ProType6"],
                    drow["ProType7"],
                    drow["ProType8"],
                    drow["ProType9"],
                    drow["ProType10"],
                    DBNull.Value,
                    DBNull.Value,
                    DBNull.Value,
                    DBNull.Value,
                    DBNull.Value
                    );
            }
            else
            {
                //增加属性
                this.accDGPrdTypePro.UpdateDGProductPro(
                    ref errormsg,
                    drow["PrdID"],
                    drow["ProType1"],
                    drow["ProType2"],
                    drow["ProType3"],
                    drow["ProType4"],
                    drow["ProType5"],
                    drow["ProType6"],
                    drow["ProType7"],
                    drow["ProType8"],
                    drow["ProType9"],
                    drow["ProType10"],
                    DBNull.Value,
                    DBNull.Value,
                    DBNull.Value,
                    DBNull.Value,
                    DBNull.Value
                        );
            }
        }

        private int GetPrdID(string PrdCode)
        {
            int rut = -1;
            this.accPrd.GetParmProductPrdID(PrdCode, ref rut);
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


                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic = getColumns();
                int count = dic.Count;
                DataColumn[] columns = new DataColumn[count];
                int i = 0;
                foreach (KeyValuePair<string, string> kv in dic)
                {
                    columns[i] = new DataColumn(kv.Value, typeof(string));
                    i++;
                }
                //DataColumn[] columns = new DataColumn[] {      
                //    new DataColumn ("产品编号",typeof (string)),
                //    new DataColumn ("产品名称",typeof (string)),              
                //    new DataColumn ("产品规格",typeof (string)),                 
                //    new DataColumn ("单位",typeof (string)),            
                //    new DataColumn ("助记码",typeof (string)),                     
                //    new DataColumn ("客户产品",typeof (string)),   
                //    new DataColumn ("备注",typeof (string)),

                //    new DataColumn ("刀片R角",typeof (string)),                                
                //    new DataColumn ("刀片左右手",typeof (string)),    
                //    new DataColumn ("排屑槽",typeof (string)),    
                //    new DataColumn ("被加工材料/刀片材质",typeof (string))
                //};
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

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic = getColumns();
            int count = dic.Count;
            DataColumn[] columns = new DataColumn[count];
            foreach (KeyValuePair<string, string> kv in dic)
            {

                if (kv.Key.Equals("UnitID"))
                {
                    drowNew[kv.Key] = this.GetUnitID(UnitName);
                }
                else if (kv.Key.Equals("Product_XMHCustomFlag"))
                {
                    drowNew[kv.Key] = CustomFlag;
                }
                else if (kv.Key.Equals("Product_XMHDPType"))
                {
                    int DPType = getChildPrdTypeIDByName(kv.Value.ToString());
                    drowNew[kv.Key] = DPType;
                }
                else if (kv.Key.Equals("ProType1"))
                {
                    drowNew[kv.Key] = GetPrdIDByNamePrdType(drow[kv.Value].ToString(), 1); ;
                }
                else if (kv.Key.Equals("ProType2"))
                {
                    drowNew[kv.Key] = GetPrdIDByNamePrdType(drow[kv.Value].ToString(), 2); ;
                }
                else if (kv.Key.Equals("ProType3"))
                {
                    drowNew[kv.Key] = GetPrdIDByNamePrdType(drow[kv.Value].ToString(), 3); ;
                }
                else if (kv.Key.Equals("ProType4"))
                {
                    drowNew[kv.Key] = GetPrdIDByNamePrdType(drow[kv.Value].ToString(), 4); ;
                }
                else if (kv.Key.Equals("ProType5"))
                {
                    drowNew[kv.Key] = GetPrdIDByNamePrdType(drow[kv.Value].ToString(), 5); ;
                }
                else if (kv.Key.Equals("ProType6"))
                {
                    drowNew[kv.Key] = GetPrdIDByNamePrdType(drow[kv.Value].ToString(), 16);
                }
                else if (kv.Key.Equals("ProType7"))
                {
                    drowNew[kv.Key] = GetPrdIDByNamePrdType(drow[kv.Value].ToString(), 17);
                }
                else if (kv.Key.Equals("ProType8"))
                {
                    drowNew[kv.Key] = GetPrdIDByNamePrdType(drow[kv.Value].ToString(), 18);
                }
                else if (kv.Key.Equals("ProType9"))
                {
                    drowNew[kv.Key] = GetPrdIDByNamePrdType(drow[kv.Value].ToString(), 19); ;
                }
                else if (kv.Key.Equals("ProType10"))
                {
                    drowNew[kv.Key] = GetPrdIDByNamePrdType(drow[kv.Value].ToString(), 20); ;
                }
                else
                {
                    drowNew[kv.Key] = drow[kv.Value];
                }
            }
            //drowNew["PrdCode"] = drow["产品编号"];
            //drowNew["PrdName"] = drow["产品名称"];
            //drowNew["PrdSpec"] = drow["产品规格"];
            //drowNew["UnitID"] = this.GetUnitID(UnitName);
            //drowNew["AssistantCode"] = drow["助记码"];
            //drowNew["Memo"] = drow["备注"];
            //drowNew["CustomFlag"] = CustomFlag;

            //drowNew["ProType1"] = GetPrdTypeID(drow["刀片R角"].ToString(), 71);
            //drowNew["ProType2"] = GetPrdTypeID(drow["刀片左右手"].ToString(),114);
            //drowNew["ProType3"] = GetPrdTypeID(drow["排屑槽"].ToString(), 73);
            //drowNew["ProType4"] = GetPrdTypeID(drow["被加工材料/刀片材质"].ToString(), 72);
            //drowNew["StopFlag"] = StopFlag;
            this.dtblProduct.Rows.Add(drowNew);
        }


        //列字段机对应的列名
        private Dictionary<string, string> getColumns()
        {
            int count = dgrdv.ColumnCount;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            for (int i = 0; i < count; i++)
            {
                DataGridViewColumn col = dgrdv.Columns[i];
                if (col.Visible)
                {
                    dic.Add(col.DataPropertyName, col.HeaderText);
                }
            }

            return dic;
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


        int getChildPrdTypeIDByName(string TypeName)
        {
            int PrdTypeID = -1;
            DataSet data = this.accPrdType.GetDataPrdType();

            if (data.Tables[0] != null && data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow datarow in data.Tables[0].Rows)
                {
                    if (datarow["PrdTypeName"].Equals(TypeName))
                    {
                        PrdTypeID = (Int32)datarow["PrdTypeID"];
                        break;
                    }
                }
            }
            return PrdTypeID;
        }

        int GetPrdIDByNamePrdType(String prdName, int prdTypeID)
        {
            int PrdID = -1; 
            DataSet data = this.accDGPrdTypePro.GetDataDGPrdTypeProByPrdTypeNameAndParentID( prdName,prdTypeID);
            if (data.Tables[0] != null && data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow datarow in data.Tables[0].Rows)
                {
                    PrdID = (Int32)datarow["PrdTypeID"];
                }
            }
            return PrdID;
        }

        private void dgrdv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //String columnName = this.dgrdv.Columns[e.ColumnIndex].HeaderText;
            //this.dgrdv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
            //MessageBox.Show("第" + e.RowIndex + "行，列" + columnName +"错误，请重新选择");
        }

        //查询脚本
        private String getDGSQLDefine(){
            string[] ColNames= JERPData.CommonTool.getTableColumns(TBNAME);
            string Sel = JERPData.CommonTool.getSelCol("t2", TBNAME,ColNames);
            String Sel2 = getDefineSel("t3",GetDefineColumns());
            return " select " + M_PRE + ".*  " + Sel + Sel2
               + " from prd.Product " + M_PRE
               + " left join " + TBNAME + " t2  on t1.PrdID = t2.PrdID "
               + " left join " + TBDEFINESAVENAME + " t3 on t1.PrdID = t3.PrdID ";
        }



        //把一个数组变为查询脚本，可以通用
        private String getDefineSel(String pre,String[] columns) { 
            StringBuilder sBuilter = new StringBuilder();
            foreach(String col in columns){
                if (col != null && col != "")
                {
                    sBuilter.Append("," + pre + "." + col);
                }
            }
            return sBuilter.ToString();
        
        } 

        //所有显示的字段值
        private String[] GetDefineColumns()
        { 
            List<JERPBiz.Product.DGProDefineEntity> dgProDefineEntityList = GetDefineObjs();
            String[] Fields = new String[dgProDefineEntityList.Count];
            int count = 0 ;
            foreach (JERPBiz.Product.DGProDefineEntity dgProDefineEntity in dgProDefineEntityList) {

                if (dgProDefineEntity.Fvisable.ToString().Equals("1")) {
                    Fields[count] = dgProDefineEntity.FFieldName.ToString();
                    count++;
                }
            }
            return Fields;
        }
        //自定义字段对象
        private List<JERPBiz.Product.DGProDefineEntity> GetDefineObjs()
        {
            JERPBiz.Product.DGProDefineEntity dgProDefineEntity = null;
            DataTable dt = accData.GetDataDGProDefine().Tables[0];

            foreach (DataRow drow in dt.Rows){
                dgProDefineEntity = new JERPBiz.Product.DGProDefineEntity();
                int fid  = (int) drow["Fid"];
                dgProDefineEntity.LoadData(fid);
                dgProDefineEntityList.Add(dgProDefineEntity);
            }
            return dgProDefineEntityList;
        }

    }
}
