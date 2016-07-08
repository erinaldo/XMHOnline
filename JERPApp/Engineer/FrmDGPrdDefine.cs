﻿using System;
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
        private static int m_flag = 1;
        private static int m_Type = 10;
        public FrmDGPrdDefine()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accPrds = new JERPData.Product.ComProduct();
            this.accPrdsP = new JERPData.Product.Product();
            this.accUnits = new JERPData.General.Unit();
            this.accDGPJPrdTyprPro = new JERPData.Product.DGPJPrdTyprPro();
            this.accProType = new JERPData.General.ComPrdType();
            this.accOtherPrds = new JERPData.Product.OtherProducePro();
            this.accDGPrdTyprPro = new JERPData.Product.DGPrdTyprPro();
            this.ctrlPrdTypeID.InitiaParam(m_flag);
            this.SetPermit();
        }

        //权限码_
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存


        private JERPData.Product.ComProduct accPrds;
        private JERPData.Product.Product accPrdsP;
        private JERPData.General.Unit accUnits;
        private JERPData.General.ComPrdType accProType;

        private DataTable dtbliniProduct, dtblProduct, dtblUnits, dtblDPType;

        //类型
        private JERPData.Product.OtherProducePro accOtherPrds;

        //类型
        private JERPData.Product.DGPrdTyprPro accDGPrdTyprPro;
        //属性
        private JERPData.Product.DGPJPrdTyprPro accDGPJPrdTyprPro;



        //private DataTable dtblPrdType;

        private JERPApp.Define.Product.FrmManuPrdType frmPrdType;
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

        }

        //初始化dgrdv控件，增加列
        private void initDgrdv()
        {
            DataSet ds = accOtherPrds.GetDataOtherProductProByFType(m_Type);
            //String[] FieldNames = new String[] { "FieldName","Type" ,"FieldType" ,"FieldText"};
            for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            {
                DataGridViewComboBoxColumn colbox = new DataGridViewComboBoxColumn();
                DataRow datarow = ds.Tables[0].Rows[row];
                String fieldName = (String)datarow["FFieldName"];
                String fieldText = (String)datarow["FFieldText"];
                String Fvisable = (String)datarow["Fvisable"];
                String FTypeSrcID = (String)datarow["FTypeSrcID"];
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
                        colbox.DataSource = this.accDGPJPrdTyprPro.GetDataProductByPrdTypeID(TypeSrcID).Tables[0];
                        colbox.ValueMember = "PrdID";
                        colbox.DisplayMember = "PrdName";
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
            Boolean flag = accPrds.DeleteProduct(ref errorMsg, drow["PrdID"]);
            if (!flag)
            {
                e.Cancel = true;
                return;
            }
            e.Cancel = true;
            MessageBox.Show("删除成功。");
            accDGPrdTyprPro.DeleteDGProductPro(ref errorMsg, drow["PrdID"]); //删除相关属性
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
                    this.ChangeManuPrdType(ref flag, ref errormsg, PrdTypeID, this.dtblProduct.DefaultView[irow].Row["PrdID"]);
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
            this.dtblUnits = this.accUnits.GetDataUnit().Tables[0];
            this.ColumnUnitID.DataSource = this.dtblUnits;
            this.ColumnUnitID.ValueMember = "UnitID";
            this.ColumnUnitID.DisplayMember = "UnitName";


            this.dtblDPType = this.accPrds.GetDataComPrdTypeDPType().Tables[0];
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

            this.dtbliniProduct = this.accPrds.GetDataDGProductByPrdTypeID(this.ctrlPrdTypeID.PrdTypeID).Tables[0];

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
                this.accPrds.UpdateProductForImgCount(ref errormsg,
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

        private void ChangeManuPrdType(ref bool flag, ref String errormsg, int PrdTypeID, Object PrdID)
        {
            if (PrdID == DBNull.Value) return;
            flag = this.accPrds.UpdateComProductForPrdTypeID(ref errormsg, PrdID, PrdTypeID);
        }

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
                        drow["DWGNo"],
                        0,//drow["TaxfreeFlag"],
                        0,//drow["RohsFlag"],
                        0,//drow["RohsRequireFlag"],
                        0,//drow["PrdWeight"],
                        0,//drow["SaleFlag"],
                        drow["UnitID"],
                        drow["DPType"],
                        drow["JMPrice"],
                        drow["PFPrice"],
                        drow["HYPrice"],
                        drow["LSPrice"],
                        drow["CustomCode"],
                        drow["Brand"],
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
                    this.accDGPrdTyprPro.InsertDGProductPro(
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
                         drow["ProType11"],
                         drow["ProType12"],
                         drow["ProType13"],
                         drow["ProType14"],
                         drow["ProType15"]
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
                        drow["DPType"],
                        drow["JMPrice"],
                        drow["PFPrice"],
                        drow["HYPrice"],
                        drow["LSPrice"],
                        drow["CustomCode"],
                        drow["Brand"],
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
                    this.accDGPrdTyprPro.InsertDGProductPro(
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
                         drow["ProType11"],
                         drow["ProType12"],
                         drow["ProType13"],
                         drow["ProType14"],
                         drow["ProType15"]
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
                else if (kv.Key.Equals("CustomFlag"))
                {
                    drowNew[kv.Key] = CustomFlag;
                }
                else if (kv.Key.Equals("DPType"))
                {
                    int DPType = getChildPrdTypeIDByName(drow[kv.Value].ToString());
                    drowNew[kv.Key] = DPType;
                }
                else if (kv.Key.Equals("ProType1"))
                {
                    drowNew[kv.Key] = GetPrdIDByNamePrdType(drow[kv.Value].ToString(), 24); ;
                }
                else if (kv.Key.Equals("ProType2"))
                {
                    drowNew[kv.Key] = GetPrdIDByNamePrdType(drow[kv.Value].ToString(), 25); ;
                }
                else if (kv.Key.Equals("ProType3"))
                {
                    drowNew[kv.Key] = GetPrdIDByNamePrdType(drow[kv.Value].ToString(), 26); ;
                }
                else if (kv.Key.Equals("ProType4"))
                {
                    drowNew[kv.Key] = GetPrdIDByNamePrdType(drow[kv.Value].ToString(), 27); ;
                }
                else if (kv.Key.Equals("ProType5"))
                {
                    drowNew[kv.Key] = GetPrdIDByNamePrdType(drow[kv.Value].ToString(), 28); ;
                }
                else if (kv.Key.Equals("ProType6"))
                {
                    drowNew[kv.Key] = GetPrdIDByNamePrdType(drow[kv.Value].ToString(), 29);
                }
                else if (kv.Key.Equals("ProType7"))
                {
                    drowNew[kv.Key] = GetPrdIDByNamePrdType(drow[kv.Value].ToString(), 30);
                }
                else if (kv.Key.Equals("ProType8"))
                {
                    drowNew[kv.Key] = GetPrdIDByNamePrdType(drow[kv.Value].ToString(), 31);
                }
                else if (kv.Key.Equals("ProType9"))
                {
                    drowNew[kv.Key] = GetPrdIDByNamePrdType(drow[kv.Value].ToString(), 32); ;
                }
                else if (kv.Key.Equals("ProType10"))
                {
                    drowNew[kv.Key] = GetPrdIDByNamePrdType(drow[kv.Value].ToString(), 33); ;
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
            DataSet data = this.accPrds.GetDataComPrdTypeDPType();
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



        int GetPrdTypeID(string TypeName, int patentID)
        {
            int PrdTypeID = -1;
            DataSet data = this.accProType.GetDataManuPrdTypeByManuPrdTypeNameAndParentID(TypeName, patentID);
            if (data.Tables[0] != null && data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow datarow in data.Tables[0].Rows)
                {
                    PrdTypeID = (Int32)datarow[0];
                }
            }
            return PrdTypeID;
        }

        int GetPrdIDByNamePrdType(String prdName, int prdTypeID)
        {
            int PrdID = -1;
            DataSet data = this.accPrdsP.GetDataProductByPrdTypeIDAndPrdName(prdTypeID, prdName);
            if (data.Tables[0] != null && data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow datarow in data.Tables[0].Rows)
                {
                    PrdID = (Int32)datarow["PrdID"];
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

    }
}
