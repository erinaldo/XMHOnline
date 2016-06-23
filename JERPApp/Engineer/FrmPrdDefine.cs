using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer
{
    public partial class FrmPrdDefine : Form
    {
        public FrmPrdDefine()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accPrds = new JERPData.Product.Product ();
            this.accUnits = new JERPData.General.Unit();
            this.accSupplierPrdCode = new JERPData.Product.SupplierPrdCode();
            this.accPrdXBuyer = new JERPData.Product.ProductXBuyer();
            this.SetPermit();
        }

     
        private JERPData.Product .Product  accPrds;
        private JERPData.General.Unit accUnits;  
        private DataTable dtbliniProduct,dtblProduct,dtblUnits;
        private JCommon.FrmExcelImport frmImport;
        private JCommon.FrmFileBrowse frmFileBrowse;
        private JCommon.FrmImgBrowse frmImgBrowse;
        private JERPApp.Define.Product.FrmPrdType frmPrdType;
        private JERPData.Product.SupplierPrdCode accSupplierPrdCode;
        private JERPData.Product.ProductXBuyer accPrdXBuyer;
        private FrmPrdSetOper frmPrdSetOper;
        private FrmSupplierPrdCode frmSupplierPrdCode;
        private FrmBuyer frmBuyer;
        private FrmBatchSupplier frmBatchSupplier;
        private FrmBatchBuyer frmBatchBuer;
        private FrmPrdDelete frmDelete;
        private FrmMaxPrdCode frmMaxPrdCode; 
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(23);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(24);
            if (this.enableBrowse)
            {
                this.SetColumnSrc();
                this.LoadData();
                this.ctrlQFind.SeachGridView = this.dgrdv;
                this.ctrlQFind.BeforeFilter += new JCommon.CtrlGridFind.BeforeFilterDelegate(ctrlQFind_BeforeFilter);
                this.ctrlPrdTypeID.AffterSelected += this.LoadData;
                this.ctrlPrdTypeID.BeforeSelected += new JERPApp.Define.Product.CtrlPrdTypeTree.BeforeSelectDelegate(ctrlPrdTypeID_BeforeSelected);       
                this.FormClosed +=new FormClosedEventHandler(FrmProduct_FormClosed);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
             
                
            }         
            this.btnImport.Enabled = this.enableSave; 
            if (this.enableSave)
            {
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemPrdType.Click += new EventHandler(mItemPrdType_Click);
                this.mItemSupplier.Click += new EventHandler(mItemSupplier_Click);
                this.mItemBuyer.Click += new EventHandler(mItemBuyer_Click);
                this.mItemMaxPrdCode.Click += new EventHandler(mItemMaxPrdCode_Click);
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.ctrlPrdTypeID.AllowDefine();
                this.btnSave.Click += new EventHandler(btnSave_Click); 
                this.btnImport.Click += new EventHandler(btnImport_Click);
                this.dgrdv.RowEnter += new DataGridViewCellEventHandler(dgrdv_RowEnter);
                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
                this.btnExport.Click += new EventHandler(btnExport_Click);
              
            }
        }

        void ctrlQFind_BeforeFilter()
        {
            this.dtblProduct = this.dtbliniProduct.Copy();
            this.dgrdv.DataSource = this.dtblProduct;
        }

        
      

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        void mItemSupplier_Click(object sender, EventArgs e)
        {
            if (frmBatchSupplier == null)
            {
                frmBatchSupplier = new FrmBatchSupplier();
                new FrmStyle(frmBatchSupplier).SetPopFrmStyle(this);
                frmBatchSupplier.AffterSave += new FrmBatchSupplier.AffterSaveDelegate(frmBatchSupplier_AffterSave);
            }
            frmBatchSupplier.BatchSupplier();
            frmBatchSupplier.ShowDialog();
        }

       

        void mItemBuyer_Click(object sender, EventArgs e)
        {
            if (frmBatchBuer == null)
            {
                frmBatchBuer = new FrmBatchBuyer();
                new FrmStyle(frmBatchBuer).SetPopFrmStyle(this);
                frmBatchBuer.AffterSave += new FrmBatchBuyer.AffterSaveDelegate(frmBatchBuer_AffterSave);
            }
            frmBatchBuer.BatchBuyer();
            frmBatchBuer.ShowDialog();
        }

        void mItemPrdType_Click(object sender, EventArgs e)
        {
            if (frmPrdType == null)
            {
                frmPrdType = new JERPApp.Define.Product.FrmPrdType();
                new FrmStyle(frmPrdType).SetPopFrmStyle(this);
                frmPrdType.AffterSelected += new JERPApp.Define.Product.FrmPrdType.AffterSelectedDelegate(frmPrdType_AffterSelected);
            }
            frmPrdType.ShowDialog();
        }


        void frmBatchSupplier_AffterSave(DataRow[] drowSuppliers, bool SettingFlag)
        {
            DataRow drow;
            string errormsg = string.Empty;
            for (int irow = 0; irow < this.dgrdv.Rows.Count - 1; irow++)
            {
                if (this.dgrdv.Rows[irow].Selected)
                {
                    drow = this.dtblProduct.DefaultView[irow].Row;
                    if (drow["PrdID"] == DBNull.Value) continue;
                    foreach (DataRow drowSupplier in drowSuppliers)
                    {
                        if (SettingFlag)
                        {
                            this.accSupplierPrdCode.UpdateSupplierPrdCodeForSupplier(ref errormsg,
                                drow["PrdID"],
                                drowSupplier["CompanyID"]);

                        }
                        else
                        {
                            this.accSupplierPrdCode.UpdateSupplierPrdCodeCancelSupplier(
                                ref errormsg,
                                drow["PrdID"],
                                drowSupplier["CompanyID"]);
                        }
                    }
                    drow["Supplier"] = this.GetSupplier((int)drow["PrdID"]);
                }
            }
            this.frmBatchSupplier.Close();
        }
        

        void frmBatchBuer_AffterSave(DataRow[] drowBuyers, bool BuyFlag)
        {
            DataRow drow;
            string errormsg = string.Empty;
            for (int irow = 0; irow < this.dgrdv.Rows.Count - 1; irow++)
            {
                if (this.dgrdv.Rows[irow].Selected)
                {
                    drow = this.dtblProduct.DefaultView[irow].Row;
                    if (drow["PrdID"] == DBNull.Value) continue;
                    foreach (DataRow drowBuyer in drowBuyers)
                    {
                        this.accPrdXBuyer.SaveProductXBuyer(ref errormsg,
                            drow["PrdID"],
                            drowBuyer["PsnID"],
                            BuyFlag);
                    }
                    drow["Buyer"] = this.GetBuyer ((int)drow["PrdID"]);
                }
            }
            this.frmBatchBuer .Close();
        }

        void frmPrdType_AffterSelected()
        {
            int PrdTypeID = this.frmPrdType.PrdTypeID;
            for (int irow = 0; irow < this.dgrdv.Rows.Count-1; irow++)
            {
                if (this.dgrdv.Rows[irow].Selected)
                {
                    this.SaveRow(PrdTypeID,this.dtblProduct.DefaultView[irow].Row);
                }
            }
            MessageBox.Show("成功变换当前选中行的类别");
            this.LoadData();
            frmPrdType.Close();
        }

        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "类型:"+this.ctrlPrdTypeID .PrdTypeName );
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, false);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.Show();
            FrmMsg.Hide();
        }
        private string GetSupplier(int PrdID)
        {
            string supplier = string.Empty;
            this.accPrds.GetParmProductSupplier(PrdID, ref supplier);
            if (supplier == string.Empty) return "未设置";
            return supplier;
        }
        private string GetBuyer(int PrdID)
        {
            string buyer = string.Empty;
            this.accPrds.GetParmProductBuyer(PrdID, ref buyer);
            if (buyer == string.Empty) return "未设置";
            return buyer;
        }
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            object objPrdID = this.dtblProduct.DefaultView[irow]["PrdID"];
            if ((objPrdID == null) || (objPrdID == DBNull.Value)) return;
            string errormsg = string.Empty;
            if (this.dgrdv.Columns[icol].Name == this.ColumnSupplier.Name)
            {
                
                if (frmSupplierPrdCode  == null)
                {
                    frmSupplierPrdCode = new FrmSupplierPrdCode();
                    new FrmStyle(frmSupplierPrdCode).SetPopFrmStyle(this); 
                }
                this.frmSupplierPrdCode .SupplierPrdCode((int)objPrdID);
                this.frmSupplierPrdCode.ShowDialog();

                this.dgrdv[icol, irow].Value = this.GetSupplier((int)objPrdID) ;
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnBuyer .Name)
            {

                if (frmBuyer  == null)
                {
                    frmBuyer = new FrmBuyer();
                    new FrmStyle(frmBuyer).SetPopFrmStyle(this);
                }
                this.frmBuyer.Buyer ((int)objPrdID);
                this.frmBuyer.ShowDialog();
                this.dgrdv[icol, irow].Value = this.GetBuyer ((int)objPrdID);
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnPrdSetCount .Name)
            {
                if (frmPrdSetOper  == null)
                {
                    frmPrdSetOper = new FrmPrdSetOper();
                    new FrmStyle(frmPrdSetOper).SetPopFrmStyle(this);
                    frmPrdSetOper.AffterSave += new FrmPrdSetOper.AffterSaveDelegate(frmSetBomOper_AffterSave);
                }
                frmPrdSetOper.PrdSetBomOper((int)objPrdID);
                frmPrdSetOper.ShowDialog();
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnFileCount .Name)
            {
                if (frmFileBrowse == null)
                {
                    frmFileBrowse = new JCommon.FrmFileBrowse();
                    frmFileBrowse.ReadOnly = !this.enableSave ;
                    new FrmStyle(frmFileBrowse).SetPopFrmStyle(this);

                }
                frmFileBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdFile\" + objPrdID.ToString());
                frmFileBrowse.ShowDialog();
                this.dgrdv[icol, irow].Value = frmFileBrowse.Count;
                this.accPrds.UpdateProductForFileCount(
                    ref errormsg,
                    objPrdID,
                    frmFileBrowse.Count);
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnImgCount .Name)
            {
                if (frmImgBrowse == null)
                {
                    frmImgBrowse = new JCommon.FrmImgBrowse();
                    frmImgBrowse.ReadOnly = !this.enableSave ;
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

        void frmSetBomOper_AffterSave(int SetPrdCount)
        {
            this.dgrdv.CurrentCell.Value = SetPrdCount;
        }

 
        void dgrdv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow <1) || (icol == -1)) return;
            object objUnitID = this.dgrdv[this.ColumnUnitID.Name, irow].Value;
            if ((objUnitID == null) || (objUnitID == DBNull.Value))
            {
                this.dgrdv[this.ColumnUnitID.Name, irow].Value = this.dgrdv[this.ColumnUnitID.Name, irow - 1].Value;
            }
             
        
        }  
        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index; 
            DataRow drow = this.dtblProduct .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["PrdID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
            if (this.frmDelete == null)
            {
                this.frmDelete = new FrmPrdDelete();
                new FrmStyle(frmDelete).SetPopFrmStyle(this); 
            }
            this.frmDelete.PrdDelete((int)drow["PrdID"]);
            this.frmDelete.ShowDialog();
            if (!this.frmDelete.DeleteFlag)
            {
                e.Cancel = true;
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
       

    
        private void SetColumnSrc()
        { 
            this.dtblUnits = this.accUnits.GetDataUnit().Tables[0];
            this.ColumnUnitID.DataSource = this.dtblUnits;
            this.ColumnUnitID.ValueMember = "UnitID";
            this.ColumnUnitID.DisplayMember = "UnitName";

        }
       
        private void LoadData()
        { 

           this.dtbliniProduct  = this.accPrds.GetDataProductByPrdTypeID  (this.ctrlPrdTypeID .PrdTypeID).Tables[0];
           this.dtbliniProduct.Columns["PrdCode"].Unique = true;
           this.dtbliniProduct.Columns["PrdCode"].AllowDBNull = false;
           this.dtbliniProduct.Columns["UnitID"].AllowDBNull = false;
           this.dtbliniProduct.Columns["UnitID"].DefaultValue = 1;// 
           this.dtbliniProduct.Columns["TaxfreeFlag"].DefaultValue = true;
           this.dtbliniProduct.Columns["SaleFlag"].DefaultValue = false;
           this.dtbliniProduct.Columns["RohsFlag"].DefaultValue = false;
           this.dtbliniProduct.Columns["RohsRequireFlag"].DefaultValue = false;

           this.dtblProduct = this.dtbliniProduct.Copy();
            this.dgrdv.DataSource = this.dtblProduct;
       
        }
      
        private int GetPrdID(string PrdCode)
        {
            int rut = -1;
            this.accPrds.GetParmProductPrdID(PrdCode, ref rut);
            return rut;
            
        }
  
        void FrmProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }
     
       
        void btnImport_Click(object sender, EventArgs e)
        {
           
            if (this.frmImport == null)
            {
                this.frmImport = new JCommon.FrmExcelImport();
                new FrmStyle(frmImport).SetPopFrmStyle(this);
                this.frmImport.AffterSave += new JCommon.FrmExcelImport.AffterSaveDelegate(frmImport_AffterSave);
                this.frmImport.ImportHandle += new JCommon.FrmExcelImport.ImportDelegate(frmImport_ImportHandle);
                DataColumn[] columns=new DataColumn[] {      
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
        bool GetBool(string BoolInfor)
        {
            return (BoolInfor == "是");
        }
        int GetUnitID(string UnitName)
        {
            int UnitID=1;
            this.accUnits.GetParmUnitUnitID(ref UnitID, UnitName);
            return UnitID;
        }      

        void frmImport_ImportHandle(DataRow drow, out bool flag, out string msg)
        {
            flag = true;
            msg = "成功!";
            object objPrdID=DBNull .Value ;
            string UnitName="PCS";
            if (drow["单位"]!=DBNull .Value )
            {
                UnitName = drow["单位"].ToString ();
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

        void frmImport_AffterSave()
        {
            this.SetColumnSrc();
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
        private void  SaveRow(int PrdTypeID,DataRow drow)
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
                        drow["Model"], 
                        drow["Surface"], 
                        drow["Manufacturer"],
                        drow["AssistantCode"],
                        drow["DWGNo"],
                        drow["TaxfreeFlag"],
                        drow["RohsFlag"],
                        drow["RohsRequireFlag"],
                        drow["PrdWeight"],
                        drow["SaleFlag"],
                        drow["UnitID"], 
                        drow["MinPackingQty"],
                        drow["URL"],
                        drow["Memo"],
                        drow["StopFlag"]);
                if (flag)
                {
                    drow["PrdID"] = objPrdID;
                    drow.AcceptChanges();
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
                        drow["Model"], 
                        drow["Surface"], 
                        drow["Manufacturer"],
                        drow["AssistantCode"],
                        drow["DWGNo"],
                        drow["TaxfreeFlag"],
                        drow["RohsFlag"],
                        drow["RohsRequireFlag"],
                        drow["PrdWeight"],
                        drow["SaleFlag"],
                        drow["UnitID"], 
                        drow["MinPackingQty"],
                        drow["URL"],
                        drow["Memo"],
                        drow["StopFlag"]);

            }
            if (flag)
            {
                drow.AcceptChanges();
            }
            else
            {
                MessageBox.Show(errormsg);
            }
             
        }

        void mItemMaxPrdCode_Click(object sender, EventArgs e)
        {
            if (frmMaxPrdCode == null)
            {
                frmMaxPrdCode = new FrmMaxPrdCode();
                new FrmStyle(frmMaxPrdCode).SetPopFrmStyle(this);                
            } 
            frmMaxPrdCode.ShowDialog();
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

        


        void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return; 
            foreach (DataRow drow in this.dtblProduct.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                this.SaveRow (this.ctrlPrdTypeID.PrdTypeID, drow);
                drow.AcceptChanges();
            }
            MessageBox.Show("成功保存了产品定义");
        }

    }
}