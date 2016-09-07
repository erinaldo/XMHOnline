using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer
{
    public partial class FrmCommonProductOper : Form
    {
        public FrmCommonProductOper()
        {
            InitializeComponent();
            this.accComPrd = new JERPData.Product.ComProduct();
            this.accManuProcessNew = new JERPData.Product.ManuProcessNew();
            //this.PrdEntity = new JERPBiz.Product.ProductEntity();
            this.printhelper = new JERPBiz.Product.BOMPrintHelper();
            //this.accManufProcess = new JERPData.Manufacture.ManufProcess();
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnExport.Click += new EventHandler(btnExport_Click);
            this.btnClose.Click += new EventHandler(btnClose_Click);

            //工序新增和保存
            this.btnManufProcessAppend.Click += new EventHandler(btnManufProcessAppend_Click);
            this.btnSaveProcess.Click += new EventHandler(btnSaveProcess_Click);

            //物料新增和保存
            this.btnMaxPrdCode.Click += new EventHandler(btnMaxPrdCode_Click);
            this.ctrlPrdTypeID.AllowDefine();
            this.FormClosed += new FormClosedEventHandler(FrmProductOper_FormClosed);
            hideTab();//隐藏其它的TAB
            init();
        }

        private void hideTab()
        {
            this.tabMain.TabPages.Remove(this.tabMain.TabPages["tabPackage"]);
            this.tabMain.TabPages.Remove(this.tabMain.TabPages["pageProcess"]);
            this.tabMain.TabPages.Remove(this.tabMain.TabPages["pageSetBom"]);
            this.tabMain.TabPages.Remove(this.tabMain.TabPages["pageDevelop"]);
            this.tabMain.TabPages.Remove(this.tabMain.TabPages["pageFile"]);
            this.tabMain.TabPages.Remove(this.tabMain.TabPages["pageImg"]);
            //for (int i = 1; i < this.tabMain.TabPages.Count; i++)
            //{
            //    this.tabMain.TabPages.Remove(this.tabMain.TabPages[i]);
            //    Console.WriteLine(i);
            //}
        }

        private JERPData.Product.ManuProcessNew accManuProcessNew;
        //private JERPBiz.Product.DGProductEntity dGProductEntity;
        //private JERPBiz.Product.DPProductEntity dPProductEntity;
        private JERPBiz.Product.ProductEntity productEntity;
        private JERPData.Product.ComProduct accComPrd;
        private JERPBiz.Product.BOMPrintHelper printhelper;
        //private JERPData.Manufacture.ManufProcess accManufProcess;
        //private FrmManufProcessAppend frmManufProcessAppend;
        private FrmMaxPrdCode frmMaxPrdCode;
        //private FrmPrdDelete frmDelete;

        private DataTable dtblProcessNew;
        private JERPData.Product.ProcessNew accProcessNew;
        private JERPApp.Define.Manufacture.FrmFinishedProcessNew frmAddProess;


        private DataTable dtbliniProcessNewItems, dtblProcessNewItems;

        private void init() {
            productEntity = new JERPBiz.Product.ProductEntity();
            this.dgrdvProcess.AutoGenerateColumns = false;//控件的不根据datasource自动产生列
            accProcessNew = new JERPData.Product.ProcessNew();
            SetColumnSrc();
        }


        private int prdid = -1;
        private int PrdID
        {
            get
            {
                return this.prdid;
            }
            set
            {
                this.prdid = value;
                //this.btnDelete.Enabled = (value > -1);
                //this.btnExport.Enabled = (value > -1);
                //this.ctrlFile.ReadOnly = (value == -1);
                //this.ctrlImg.ReadOnly = (value == -1);
                //this.ctrlManufImg.ReadOnly = (value == -1);
                //this.btnManufProcessAppend.Enabled = (value > -1);
                //if (value == -1)
                //{
                //    this.ctrlFile.Clear();
                //    this.ctrlImg.Clear();
                //    this.ctrlManufImg.Clear();
                //}
                //else
                //{
                //    string dir = JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdFile\" + value.ToString();
                //    if (!System.IO.Directory.Exists(dir))
                //    {
                //        System.IO.Directory.CreateDirectory(dir);

                //    }
                //    this.ctrlFile.Browse(dir);
                //    dir = JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdImg\" + value.ToString();
                //    if (!System.IO.Directory.Exists(dir))
                //    {
                //        System.IO.Directory.CreateDirectory(dir);

                //    }
                //    this.ctrlImg.Browse(dir);
                //    dir = JERPData.ServerParameter.ERPFileFolder + @"\Product\ManufImg\" + value.ToString();
                //    if (!System.IO.Directory.Exists(dir))
                //    {
                //        System.IO.Directory.CreateDirectory(dir);
                //    }

                //    this.ctrlManufImg.Browse(dir);
                //}
            }
        }
        //private void AppendBOMOper(DataRow drowManufProcess)
        //{
        //    TabPage page = new TabPage();
        //    page.Text = drowManufProcess["SerialNo"].ToString() + drowManufProcess["ProcessTypeName"].ToString();
        //    CtrlBOMOper ctrlBOMOper = new CtrlBOMOper();
        //    ctrlBOMOper.BomOper((long)drowManufProcess["ManufProcessID"]);
        //    ctrlBOMOper.AffterDelete += new CtrlBOMOper.AffterDeleteDelegate(ctrlBOMOper_AffterDelete);
        //    page.Controls.Add(ctrlBOMOper);
        //    ctrlBOMOper.Dock = DockStyle.Fill;
        //    this.tabBOM.TabPages.Add(page);
        //}

        //void ctrlBOMOper_AffterDelete(object sender)
        //{
        //    Control ctrl = (Control)sender;
        //    TabPage page = (TabPage)ctrl.Parent;
        //    this.tabBOM.TabPages.Remove(page);
        //}

        private void SetColumnSrc()
        {
            this.dtblProcessNew = this.accProcessNew.GetDataProcessNew().Tables[0];
            this.ProcessID.DataSource = this.dtblProcessNew;
            this.ProcessID.ValueMember = "ProcessID";
            this.ProcessID.DisplayMember = "ProcessName";

        }

        void btnManufProcessAppend_Click(object sender, EventArgs e)
        {
            if (frmAddProess == null)
            {
                frmAddProess = new JERPApp.Define.Manufacture.FrmFinishedProcessNew();
                new FrmStyle(frmAddProess).SetPopFrmStyle(this);
                frmAddProess.AffterSelected += new JERPApp.Define.Manufacture.FrmFinishedProcessNew.AffterSelectedDelegate(frmAddProess_AffterSelected);
            }
            frmAddProess.ShowDialog();
        }

        void frmAddProess_AffterSelected(DataRow drow)
        {
            int ProcessID = (int)drow["ProcessID"];
            if (this.dtblProcessNewItems != null)
            {
                if (this.dtblProcessNewItems.Select("ProcessID=" + ProcessID.ToString(), "", DataViewRowState.CurrentRows).Length > 0) return;
            }
            DataRow drowNew = this.dtblProcessNewItems.NewRow();
            drowNew["ProcessID"] = ProcessID;
            drowNew["ProcessTempIndex"] = this.dtblProcessNewItems.Rows.Count + 1;
            drowNew["ProcessCode"] = drow["ProcessCode"];
            drowNew["ProcessName"] = drow["ProcessName"];
            drowNew["MachineProcessName"] = drow["MachineProcessName"];
            drowNew["ModelProcessName"] = drow["ModelProcessName"];
            drowNew["ToolProcessName"] = drow["ToolProcessName"];

            drowNew["ModeMachineTime"] = drow["ModeMachineTime"];
            drowNew["TimeCost"] = drow["TimeCost"];
            drowNew["MoneyCost"] = drow["MoneyCost"];
            drowNew["ProcessMemo"] = drow["ProcessMemo"];
            this.dtblProcessNewItems.Rows.Add(drowNew);
        }
        private void SetOtherInfor()
        {
            //显示工序
            showProcess();

            //DataTable dtblManufProcess = this.accManufProcess.GetDataManufProcessByPrdID(this.PrdID).Tables[0];
            //this.tabBOM.TabPages.Clear();
            //foreach (DataRow drow in dtblManufProcess.Rows)
            //{
            //    this.AppendBOMOper(drow);

            //}
            //this.ctrlPrdPackingOper.PrdPackingType(this.PrdID);
            //this.ctrlParmValueOper.ParmValueOper(this.PrdID);
            //this.ctrlSupplierPrdCode.SupplierPrdCode(this.PrdID);
            //this.ctrlPrdBuyer.PrdBuyer(this.PrdID);
            //this.ctrlPrdSetOper.PrdSetOper(this.PrdID);
            //this.ctrlPrdDevelopProcessOper.DevelopProcessOper(this.PrdID);

        }

        private void showProcess() {
            this.dtbliniProcessNewItems = this.accManuProcessNew.GetDataManuProcessNewByPrdIDUnion(this.PrdID).Tables[0];
           this.dtblProcessNewItems = dtbliniProcessNewItems.Copy();
           this.dgrdvProcess.DataSource = dtblProcessNewItems;
        }


        public void New()
        {
            this.PrdID = -1;

            this.txtPrdCode.Text = string.Empty;
            this.txtPrdName.Text = string.Empty;
            this.txtPrdSpec.Text = string.Empty;
            this.txtSurface.Text = string.Empty;
            this.txtMinPackingQty.Text = string.Empty;

            this.txtModel.Text = string.Empty;
            this.txtICSolution.Text = string.Empty;
            this.txtPrdWeight.Text = string.Empty;
            this.ckbSaleFlag.Checked = false;
            this.txtManufacturer.Text = string.Empty;
            this.txtDWGNo.Text = string.Empty;
            this.txtAssistantCode.Text = string.Empty;

            this.txtRegisterPsn.Text = JERPBiz.Frame.UserBiz.PsnName;
            this.txtVersionCode.Text = string.Empty;
            this.txtFileCode.Text = string.Empty;
            this.txtURL.Text = string.Empty;
            this.dtpDateRegister.Value = DateTime.Now.Date;
            this.rchVersionRecord.Text = string.Empty;
            this.ctrlUnitID.UnitID = 1;

            this.ckbStopFlag.Checked = false;
            this.rchMemo.Text = string.Empty;
            //this.SetOtherInfor();
        }

        public void Edit(int PrdID)
        {
            this.PrdID = PrdID;
            this.productEntity.LoadData(PrdID);
            this.ctrlPrdTypeID.PrdTypeID = this.productEntity.PrdTypeID;
            this.txtPrdCode.Text = this.productEntity.PrdCode;
            this.txtPrdName.Text = this.productEntity.PrdName;
            this.txtPrdSpec.Text = this.productEntity.PrdSpec;
            //this.txtSurface.Text = this.PrdEntity.Surface;
            //this.txtModel.Text = this.PrdEntity.Model;
            //this.txtManufacturer.Text = this.PrdEntity.Manufacturer;
            //this.txtDWGNo.Text = this.PrdEntity.DWGNo;
            //this.txtAssistantCode.Text = this.PrdEntity.AssistantCode;
            //this.ckbTaxfreeFlag.Checked = this.PrdEntity.TaxfreeFlag;
            //this.ckbRohsFlag.Checked = this.PrdEntity.RohsFlag;
            //this.ckbRohsRequireFlag.Checked = this.PrdEntity.RohsRequireFlag;
            //this.txtMinPackingQty.Text = string.Empty;
            //if (this.PrdEntity.MinPackingQty > 0)
            //{
            //    this.txtMinPackingQty.Text = string.Format("{0:0.######}", this.PrdEntity.MinPackingQty);
            //}

            //this.txtICSolution.Text = this.PrdEntity.ICSolution;
            //this.txtPrdWeight.Text = string.Empty;
            //if (this.PrdEntity.PrdWeight > 0)
            //{
            //    this.txtPrdWeight.Text = string.Format("{0:0.######}", this.PrdEntity.PrdWeight);
            //}

            //this.txtRegisterPsn.Text = this.PrdEntity.RegisterPsn;
            //this.ckbSaleFlag.Checked = this.PrdEntity.SaleFlag;
            //this.ctrlUnitID.UnitID = this.PrdEntity.UnitID;
            //this.txtVersionCode.Text = this.PrdEntity.VersionCode;
            //this.txtFileCode.Text = this.PrdEntity.FileCode;
            //if (this.PrdEntity.DateRegister != DateTime.MinValue)
            //{
            //    this.dtpDateRegister.Value = this.PrdEntity.DateRegister;
            //}
            //this.rchVersionRecord.Text = this.PrdEntity.VersionRecord;
            //this.txtURL.Text = this.PrdEntity.URL;
            //this.rchMemo.Text = this.PrdEntity.Memo;
            //this.ckbStopFlag.Checked = this.PrdEntity.StopFlag;
            this.SetOtherInfor();
        }

        private void btnSaveProcess_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            Boolean flag = false;

            foreach (DataRow drow in this.dtblProcessNewItems.Rows)
            {
                if (drow.RowState == DataRowState.Deleted)
                {
                    Object ID = drow["ID", DataRowVersion.Original];//获取已删除值的写法    
                    if (ID != DBNull.Value)
                    {
                        string errormsg = string.Empty;
                        flag = this.accManuProcessNew.DeleteManuProcessNew(ref errormsg, ID, this.PrdID);
                        if (!flag)
                        {
                            MessageBox.Show(errormsg);
                        }
                    }
                    continue;
                }
                if (drow.RowState == DataRowState.Unchanged) continue;
                this.SaveRow(drow);
                drow.AcceptChanges();
            }
            MessageBox.Show("成功保存");
        }


        private void SaveRow(DataRow drow) {
            string errormsg = string.Empty;
            Boolean flag = false;
            Object ID = drow["ID"];
            if (ID == DBNull.Value){
                flag = this.accManuProcessNew.InsertManuProcessNew(
                    ref errormsg,
                    ref ID,
                    this.PrdID,
                    drow["ProcessTempIndex"],
                    drow["ProcessID"],
                    drow["ModeMachineTime"],
                    drow["TimeCost"],
                    2,
                    drow["MoneyCost"],
                    null,
                    drow["ProcessMemo"]);
                if (!flag)
                {
                    MessageBox.Show(errormsg);
                }
            }else{
                flag = this.accManuProcessNew.UpdateManuProcessNew(
                     ref errormsg,
                     ID,
                    this.PrdID,
                    drow["ProcessTempIndex"],
                    drow["ProcessID"],
                    drow["ModeMachineTime"],
                    drow["TimeCost"],
                    2,
                    drow["MoneyCost"],
                    null,
                    drow["ProcessMemo"]);
                if (!flag)
                {
                    MessageBox.Show(errormsg);
                }
            }
            
        }


        private bool ValidateData()
        {
            if (this.PrdID == -1)
            {
                MessageBox.Show("该物料不存在!");
                return false;
            } 
            return true;
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

        void btnMaxPrdCode_Click(object sender, EventArgs e)
        {
            if (frmMaxPrdCode == null)
            {
                frmMaxPrdCode = new FrmMaxPrdCode();
                new FrmStyle(frmMaxPrdCode).SetPopFrmStyle(this);
            }
            frmMaxPrdCode.ShowDialog();
        }


        void btnNew_Click(object sender, EventArgs e)
        {
            this.New();
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            //if (frmDelete == null)
            //{
            //    frmDelete = new FrmPrdDelete();
            //    new FrmStyle(frmDelete).SetPopFrmStyle(this);
            //    frmDelete.AffterSave += new FrmPrdDelete.AffterSaveDelegate(frmDelete_AffterSave);
            //}
            //frmDelete.PrdDelete(this.PrdID);
            //frmDelete.ShowDialog();
        }

        void frmDelete_AffterSave()
        {
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }
        private int GetPrdID(string PrdCode)
        {
            int PrdID = -1;
            this.accComPrd.GetParmProductPrdID(PrdCode, ref PrdID);
            return PrdID;
        }
        void btnSave_Click(object sender, EventArgs e)
        { 

        }

        void FrmProductOper_FormClosed(object sender, FormClosedEventArgs e)
        {
            string errormsg = string.Empty;
            if (this.PrdID > -1)
            {
                //this.accPrd.UpdateProductForFileCount(ref errormsg,
                //    this.PrdID,
                //    this.ctrlFile.Count);
                //this.accPrd.UpdateProductForImgCount(ref errormsg,
                //    this.PrdID,
                //    this.ctrlImg.Count);
                //this.accPrd.UpdateProductForManufImgCount(ref errormsg,
                //    this.PrdID,
                //    this.ctrlManufImg.Count);
            }
        }
        //关闭窗体
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //输出打印
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            this.printhelper.ExportToExcel(this.PrdID);
            FrmMsg.Hide();
        }
    }



    //void btnSave_Click(object sender, EventArgs e)
    //{
    //    bool flag = false;
    //    string errormsg = string.Empty;
    //    if (this.txtPrdCode.Text == string.Empty)
    //    {
    //        MessageBox.Show("产品编号");
    //        return;
    //    }
    //    object objMinPackingQty = DBNull.Value;
    //    decimal MinPackingQty = 0;
    //    if (decimal.TryParse(this.txtMinPackingQty.Text, out MinPackingQty))
    //    {
    //        objMinPackingQty = MinPackingQty;
    //    }
    //    object objPrdWeight = DBNull.Value;
    //    decimal PrdWeight;
    //    if (decimal.TryParse(this.txtPrdWeight.Text, out PrdWeight))
    //    {
    //        objPrdWeight = PrdWeight;
    //    }
    //    if (this.PrdID == -1)
    //    {

    //        if (this.GetPrdID(this.txtPrdCode.Text) > -1)
    //        {
    //            MessageBox.Show("此产品编号已存在....");
    //            return;
    //        }
    //        object objPrdID = DBNull.Value;
    //        flag = this.accComPrd.InsertProduct(
    //                ref errormsg,
    //                ref objPrdID,
    //                this.ctrlPrdTypeID.PrdTypeID,
    //                this.txtPrdCode.Text,
    //                this.txtPrdName.Text,
    //                this.txtPrdSpec.Text,
    //                this.txtModel.Text,
    //                this.txtSurface.Text,
    //                this.txtManufacturer.Text,
    //                this.txtAssistantCode.Text,
    //                this.txtDWGNo.Text,
    //                this.ckbTaxfreeFlag.Checked,
    //                this.ckbRohsFlag.Checked,
    //                this.ckbRohsRequireFlag.Checked,
    //                this.txtICSolution.Text,
    //                objPrdWeight,
    //                this.ckbSaleFlag.Checked,
    //               this.ctrlUnitID.UnitID,
    //               this.dtpDateRegister.Value.Date,
    //               this.txtFileCode.Text,
    //               this.txtRegisterPsn.Text,
    //               this.txtVersionCode.Text,
    //               this.rchVersionRecord.Text,
    //               objMinPackingQty,
    //               this.txtURL.Text,
    //               this.rchMemo.Text,
    //               this.ckbStopFlag.Checked);
    //        if (flag)
    //        {
    //            this.PrdID = (int)objPrdID;
    //            MessageBox.Show("成功新增当前产品");
    //            this.ctrlPrdSetOper.PrdSetOper(this.PrdID);
    //            this.ctrlPrdPackingOper.PrdPackingType(this.PrdID);
    //        }

    //    }
    //    else
    //    {

    //        if ((this.GetPrdID(this.txtPrdCode.Text) > -1) && (this.GetPrdID(this.txtPrdCode.Text) != this.PrdID))
    //        {
    //            MessageBox.Show("此产品已存在....");
    //            return;
    //        }
    //        flag = this.accComPrd.UpdateProduct(
    //                ref errormsg,
    //                this.PrdID,
    //                this.ctrlPrdTypeID.PrdTypeID,
    //                this.txtPrdCode.Text,
    //                this.txtPrdName.Text,
    //                this.txtPrdSpec.Text,
    //                this.txtModel.Text,
    //                this.txtSurface.Text,
    //                this.txtManufacturer.Text,
    //                this.txtAssistantCode.Text,
    //                this.txtDWGNo.Text,
    //                this.ckbTaxfreeFlag.Checked,
    //                this.ckbRohsFlag.Checked,
    //                this.ckbRohsRequireFlag.Checked,
    //                this.txtICSolution.Text,
    //                objPrdWeight,
    //                this.ckbSaleFlag.Checked,
    //                this.ctrlUnitID.UnitID,
    //                this.dtpDateRegister.Value.Date,
    //                this.txtFileCode.Text,
    //                this.txtRegisterPsn.Text,
    //                this.txtVersionCode.Text,
    //                this.rchVersionRecord.Text,
    //                objMinPackingQty,
    //                this.txtURL.Text,
    //                this.rchMemo.Text,
    //                this.ckbStopFlag.Checked);
    //        if (flag)
    //        {
    //            MessageBox.Show("成功变更了当前产品");

    //        }
    //    }
    //    if (flag)
    //    {
    //        CtrlBOMOper ctrlBomOper;
    //        foreach (TabPage page in this.tabBOM.TabPages)
    //        {
    //            ctrlBomOper = (CtrlBOMOper)page.Controls[0];
    //            ctrlBomOper.Save();
    //        }
    //        this.ctrlParmValueOper.Save(this.PrdID);
    //        this.ctrlSupplierPrdCode.Save(this.PrdID);
    //        this.ctrlPrdBuyer.Save(this.PrdID);

    //        this.ctrlPrdDevelopProcessOper.Save(this.PrdID);
    //        this.ctrlPrdPackingOper.Save();
    //        this.ctrlPrdSetOper.Save();
    //    }
    //    else
    //    {
    //        MessageBox.Show(errormsg);
    //    }
    //    if (this.affterSave != null) this.affterSave();

    //}

}
