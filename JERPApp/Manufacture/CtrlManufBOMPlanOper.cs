using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class CtrlManufBOMPlanOper : UserControl
    {
        public CtrlManufBOMPlanOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accBOM = new JERPData.Product.BOM();
            this.prdEntity = new JERPBiz.Product.ProductEntity();
            this.accPrds = new JERPData.Product.Product();
            this.accSourceType = new JERPData.Product.SourceType(); 
            this.ManufProcessEntity = new JERPBiz.Manufacture.ManufProcessEntity(); 
            this.BOMPlanHelper = new JERPBiz.Manufacture.BOMPlanHelper();
            this.accBOMPlans = new JERPData.Manufacture.BOMPlans();
            this.dgrdv.CellContextMenuStripNeeded +=dgrdv_CellContextMenuStripNeeded;
            this.btnBatchImport.Click += new EventHandler(btnBatchImport_Click);
            this.btnAdd.Click += new EventHandler(btnAdd_Click); 
            this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);         
            this.btnRefresh.Click += new EventHandler(btnRefresh_Click);
            this.ckbOutSrcFlag.CheckedChanged += new EventHandler(ckbOutSrcFlag_CheckedChanged);
            
            this.SetColumnDataSrc();
            this.ctrlSupplierID.AffterSelected += this.SetBOMStoreQty;
        }
        private JERPBiz.Manufacture .BOMPlanHelper BOMPlanHelper;
      
        private JERPBiz.Product.ProductEntity prdEntity;
        private JERPData.Product.Product accPrds;
        private JERPData.Product.BOM accBOM; 
        private JERPData.Product.SourceType accSourceType;  
        private JCommon.FrmExcelImport frmImport;
        private JERPApp.Define.Product.FrmProduct frmPrd;
        private JERPApp.Define.Product.FrmProduct frmPrdAlter;
        private JERPBiz.Manufacture.ManufProcessEntity ManufProcessEntity; 
        private JERPData.Manufacture.BOMPlans accBOMPlans;
        private DataTable dtblSourceType; 
        private int GetDefaultSourceTypeID(int PrdID)
        {
            int rut = 1;
            this.accBOM.GetParmBOMDefaultSourceTypeID(PrdID, ref rut);
            return rut;
        }
        private void SetColumnDataSrc()
        { 
            this.dtblSourceType = this.accSourceType.GetDataSourceType().Tables[0]; 
            foreach (DataRow drow in this.dtblSourceType.Select("SourceTypeID>3"))
            {
                this.dtblSourceType.Rows.Remove(drow);
            }
            this.ColumnSourceTypeID.DataSource = this.dtblSourceType;
            this.ColumnSourceTypeID.ValueMember = "SourceTypeID";
            this.ColumnSourceTypeID.DisplayMember = "SourceTypeName";            
          
        }
        private DataTable dtblBom;
        private long ManufPlanID = -1; 
        private int CustomerID=-1;
        private long ManufProcessID = -1;
        private int PrdID = -1;
        public decimal ManufQty = 0;                 
        private void LoadBom()
        {
          
            this.dtblBom = this.accBOM.GetDataBOMForManufRequire (this.ManufProcessID ).Tables[0];
            this.dtblBom.Columns["AssemblyQty"].DefaultValue = 1;
            this.dtblBom.Columns["LossRate"].DefaultValue = 0;
            this.dtblBom.Columns.Add("RequireQty", typeof(decimal));
            this.dtblBom.Columns.Add("OutSrcStoreQty", typeof(decimal));
            this.dtblBom.Columns.Add("StoreQty", typeof(decimal));
            this.dtblBom.Columns.Add("RoadStoreQty", typeof(decimal));
            this.dtblBom.Columns.Add("PlanQty", typeof(decimal));
            this.dgrdv.DataSource = this.dtblBom;
        }
     

        private void SetBOMStoreQty(DataRow drowBom)
        {
            int PrdID = (int)drowBom["PrdID"];
            decimal AssemblyQty=1,LossRate=0,RequireQty = 0, OutSrcStoreQty = 0, StoreQty = 0, RoadStoreQty = 0, PlanQty = 0;
            int SourceTypeID = (int)drowBom["SourceTypeID"]; 
            if (drowBom["LossRate"] != DBNull.Value)
            {
                LossRate = (decimal)drowBom["LossRate"];
            } 
            if (drowBom["AssemblyQty"] != DBNull.Value)
            {
                AssemblyQty = (decimal)drowBom["AssemblyQty"];
            }
            RequireQty =Convert.ToInt32 (this.ManufQty * AssemblyQty * (1 + LossRate));      
            if (this.ctrlSupplierID.CompanyID > -1)
            {
               OutSrcStoreQty  = this.BOMPlanHelper .GetOutSrcAvailabelQty(this.ctrlSupplierID .CompanyID,PrdID);
            }
          
            StoreQty = this.BOMPlanHelper.GetStoreAvailableQty(PrdID);
            RoadStoreQty = this.BOMPlanHelper.GetRoadAvailableQty(PrdID); 
            if ((SourceTypeID == 3)&&(this.CustomerID  >-1))
            {
                StoreQty = this.BOMPlanHelper.GetOEMStoreAvailableQty(this.CustomerID,PrdID );
                RoadStoreQty = this.BOMPlanHelper.GetOEMRoadAvailableQty(this.CustomerID,PrdID );
            }
            PlanQty = RequireQty - OutSrcStoreQty - StoreQty - RoadStoreQty;
            if (PlanQty < 0)
            {
                PlanQty = 0;
            }
            drowBom["RequireQty"] = RequireQty;
            drowBom["OutSrcStoreQty"] = OutSrcStoreQty;
            drowBom["StoreQty"] = StoreQty;
            drowBom["RoadStoreQty"] = RoadStoreQty;
            drowBom["PlanQty"] = PlanQty;
            
        }
        private void SetBOMStoreQty()
        {
            if (this.dtblBom == null) return;
            foreach (DataRow drow in this.dtblBom.Select ("PrdID>-1","",DataViewRowState.CurrentRows ))
            {
                this.SetBOMStoreQty(drow);
            }
            
        }
       
        public void BOMPlanOper(long ManufPlanID,long ManufProcessID)
        {
            this.ManufPlanID = ManufPlanID; 
            this.ManufProcessID = ManufProcessID; 
            this.ManufProcessEntity.LoadData(ManufProcessID);
            this.PrdID = this.ManufProcessEntity.PrdID;
            this.txtPrdStatus.Text = this.ManufProcessEntity.PrdStatus;
            this.ckbOutSrcFlag.Checked = this.ManufProcessEntity.OutSrcFlag;    
            this.ctrlSupplierID.Enabled = (this.ckbOutSrcFlag.Checked);
            if (this.ckbOutSrcFlag.Checked)
            {
                this.ctrlSupplierID.CompanyID = this.ManufProcessEntity.OutSrcCompanyID;
            }
            else
            {
                this.ctrlSupplierID.CompanyID = -1;
            }
            this.LoadBom();
        }
        public void ComputeBOM(decimal ManufQty, int CustomerID)
        {
            this.ManufQty = ManufQty; 
            this.CustomerID = CustomerID;
            this.SetBOMStoreQty();
        }
        void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadBom();
            this.SetBOMStoreQty();
        }

        void ckbOutSrcFlag_CheckedChanged(object sender, EventArgs e)
        {
            this.ctrlSupplierID .Enabled =(this.ckbOutSrcFlag .Checked );
            if (this.ctrlSupplierID.Enabled == false)
            {
                this.ctrlSupplierID.CompanyID = -1;
            }
        }

      
    

        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {               
                grow.ErrorText = string.Empty;
              
                int PrdID = (int)grow.Cells[this.ColumnPrdID.Name].Value;
                if (PrdID ==-1)
                {
                    grow.ErrorText = "不存在此物料";
                    continue;
                }        
                if (grow.Cells[this.ColumnPrdID.Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "物料不能为空";
                    continue;
                }
                if (grow.Cells[this.ColumnSourceTypeID .Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "来源方式不能为空";
                    continue;
                }
                if (grow.Cells[this.ColumnAssemblyQty .Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "用量不能为空";
                    continue;
                }
                
            }
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.frmPrd  == null)
            {
                this.frmPrd = new JERPApp.Define.Product.FrmProduct();
                new FrmStyle(this.frmPrd).SetPopFrmStyle(this.ParentForm);
                this.frmPrd.AllowAppendFlag = true;
                this.frmPrd .AffterSelected+=new JERPApp.Define.Product.FrmProduct.AffterSelectedDelegate(frmPrd_AffterSelected);
            }
            this.frmPrd.ShowDialog(); 
        }
        private bool GetParentFlag(int PrdID)
        {
            bool flag = false;
            this.accPrds.GetParmProductParentFlag(PrdID, ref flag);
            return flag;
        }
        void frmPrd_AffterSelected(DataRow drow)
        {
            if (this.dtblBom.Select("PrdID=" + drow["PrdID"].ToString(), "", DataViewRowState.CurrentRows).Length > 0)
            {
                MessageBox.Show("已存在此物料");
                return;
            }
            if (this.GetAllowChildFlag((int)drow["PrdID"]) == false)
            {
                MessageBox.Show("对不起,此物料为当前部品的上级部品,不能增加");
                return;
            }
            DataRow drowNew = this.dtblBom.NewRow(); 
            drowNew["PrdID"] = drow["PrdID"];
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["Model"] = drow["Model"];
            drowNew["Manufacturer"] = drow["Manufacturer"];
            drowNew["UnitName"] = drow["UnitName"];
            drowNew["AssemblyQty"] = 1;
            drowNew["SourceTypeID"] =this.GetDefaultSourceTypeID ((int)drow["PrdID"]); 
            bool ParentFlag = this.GetParentFlag((int)drow["PrdID"]); 
            if (ParentFlag)
            {
                drowNew["SourceTypeID"] = 1;
            }
            this.SetBOMStoreQty(drowNew);
            this.dtblBom.Rows.Add(drowNew); 
        }
        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].DataPropertyName == "PrdID")
            {

                object objPrdID = this.dgrdv[icol, irow].Value;
                if ( (objPrdID != null)&&(objPrdID != DBNull.Value))
                {
                    if (this.GetAllowChildFlag((int)objPrdID) == false)
                    {
                        MessageBox.Show("此物料为本物料的上一级物料，不能设置");
                        this.dgrdv[icol, irow].Value = DBNull.Value;
                    }
                    this.dgrdv[this.ColumnSourceTypeID.Name, irow].Value =
                        this.GetDefaultSourceTypeID((int)objPrdID);
                    bool ParentFlag = this.GetParentFlag((int)objPrdID);
                    this.dgrdv[this.ColumnParentFlag.Name, irow].Value = ParentFlag;
                    if (ParentFlag)
                    {
                       this.dgrdv[this.ColumnSourceTypeID.Name, irow].Value = 1;
                    }
                    this.SetBOMStoreQty(this.dtblBom.DefaultView[irow].Row);
                }
            }
            if (this.dgrdv.Columns[icol].DataPropertyName == "SourceTypeID")
            {
                this.SetBOMStoreQty(this.dtblBom.DefaultView[irow].Row);
            }
       
        }
       
 
        void dgrdv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return; 
            if ((this.dgrdv.Columns[icol].DataPropertyName == "PrdCode")
                ||(this.dgrdv.Columns[icol].DataPropertyName == "PrdName")
                 ||(this.dgrdv.Columns[icol].DataPropertyName == "PrdSpec")
                 ||(this.dgrdv.Columns[icol].DataPropertyName == "Model")
                 ||(this.dgrdv.Columns[icol].DataPropertyName == "Manufacturer")
                )
            {
                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (this.frmPrdAlter  == null)
                {
                    this.frmPrdAlter = new JERPApp.Define.Product.FrmProduct();
                    this.frmPrdAlter.AllowAppendFlag = true;
                    new FrmStyle(this.frmPrdAlter).SetPopFrmStyle(this.ParentForm);
                    this.frmPrdAlter.AffterSelected +=this.frmPrdAlter_AffterSelected;
                }
                this.frmPrdAlter .ShowDialog();
            }
        } 
        void frmPrdAlter_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"];
            if (this.dtblBom.Select("PrdID=" +PrdID.ToString(), "", DataViewRowState.CurrentRows).Length > 0)
            {
                MessageBox.Show("已存在此物料");
                return;
            }
            if (this.GetAllowChildFlag(PrdID) == false)
            {
                MessageBox.Show("对不起，此物料是本物料的父级物料，不能变更");
                return;
            }
           DataGridViewRow grow = this.dgrdv.CurrentRow;
           grow.Cells [this.ColumnPrdID .Name ].Value  =PrdID;
           grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
           grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
           grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
           grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
           grow.Cells[this.ColumnManufacturer.Name].Value = drow["Manufacturer"];
           grow.Cells[this.ColumnUnitName .Name].Value = drow["UnitName"];
         
           bool ParentFlag = this.GetParentFlag(PrdID);
           grow.Cells[this.ColumnParentFlag.Name].Value = ParentFlag;
           grow.Cells[this.ColumnSourceTypeID.Name].Value = this.GetDefaultSourceTypeID(PrdID);
           if (ParentFlag)
           { 
               grow.Cells[this.ColumnSourceTypeID .Name].Value = 1;
           }
           this.SetBOMStoreQty(this.dtblBom.DefaultView[grow.Index].Row);
           this.frmPrdAlter.Close();
        }
       

        private int GetPrdID(string PrdCode,string PrdName,string PrdSpec)
        {
            int PrdID = -1;
            this.accPrds.GetParmProductPrdID(PrdCode, ref PrdID);
            if (PrdID > -1) return PrdID;
            this.accPrds.GetParmProductPrdIDFromOtherInfor(PrdName, PrdSpec, ref PrdID);
            return PrdID;
        }
       
        private int GetSourceTypeID(string SourceTypeName)
        {
            int rut = 0;
            this.accSourceType.GetParmSourceTypeSourceTypeID(SourceTypeName, ref rut);
            return rut;
        }
        private bool GetAllowChildFlag(int PrdID)
        {
            bool flag = false;
            this.accPrds.GetParmProductAllowChildrenFlag(this.PrdID, PrdID, ref flag);
            return flag;
        }
        void btnBatchImport_Click(object sender, EventArgs e)
        {            
            string errormsg = string.Empty;        
            if (this.frmImport == null)
            {
                frmImport = new JCommon.FrmExcelImport();
                new FrmStyle(frmImport).SetPopFrmStyle(this.ParentForm);
                DataColumn[] columns = new DataColumn[]{    
                    new DataColumn ("物料编号",typeof (string)), 
                    new DataColumn ("物料名称",typeof (string)), 
                    new DataColumn ("物料规格",typeof (string)), 
                    new DataColumn ("单位",typeof (string)), 
                    new DataColumn ("用量",typeof (decimal)),                                               
                    new DataColumn ("损耗率%",typeof (decimal)),       
                    new DataColumn ("备注",typeof (string)),                            
                    new DataColumn ("来源方式",typeof (string)) 
                };

                frmImport.SetImportColumn(columns, "[物料编号]或名称及规格不能为空 \n[用量]非空整数;损耗率%" +
                    "\n来源方式:生产;采购;");
                frmImport.ImportHandle += new JCommon.FrmExcelImport.ImportDelegate(frmImport_ImportHandle);
                frmImport.AffterSave += new JCommon.FrmExcelImport.AffterSaveDelegate(frmImport_AffterSave);
            }
            frmImport.ShowDialog();
        }
        void frmImport_AffterSave()
        {
            MessageBox.Show("导入完成，请检查数据有没有出错的行，再点保存!");
            this.frmImport.Close();
        } 
        void frmImport_ImportHandle(DataRow drow, out bool flag, out string msg)
        {
            flag = true;
            msg = string.Empty;
            string errormsg = string.Empty; 
            int PrdID = this.GetPrdID(drow["物料编号"].ToString(),drow["物料名称"].ToString (),drow["物料规格"].ToString ()) ;
            if (PrdID > -1)
            {
                if (this.dtblBom.Select("PrdID=" + PrdID.ToString(), "", DataViewRowState.CurrentRows).Length  > 0)
                {
                    flag = false;
                    msg = "已存在此物料";
                    return;
                }
            }
            
            decimal AssemblyQty = (decimal)drow["用量"];
               object objID = DBNull.Value;
            decimal LossRate = 0;
            if (drow["损耗率%"] != DBNull.Value)
            {
                LossRate = (decimal)drow["损耗率%"] / 100;
            }          
            DataRow drowNew = this.dtblBom.NewRow(); 
            drowNew["PrdID"] = PrdID; 
            drowNew["PrdCode"] = drow["物料编号"];
            drowNew["PrdName"] = drow["物料名称"];
            drowNew["PrdSpec"] = drow["物料规格"];
            this.prdEntity.LoadData(PrdID);
            drowNew["Model"] = this.prdEntity.Model ;
            drowNew["Manufacturer"] = this.prdEntity.Manufacturer;
            drowNew["UnitName"] = this.prdEntity.UnitName ;
            drowNew["AssemblyQty"] = AssemblyQty;
            string SourceTypeName = drow["来源方式"].ToString();
            if (SourceTypeName == string.Empty)
            {
                if (this.GetParentFlag(PrdID))
                {
                    SourceTypeName = "生产";
                }
                else
                {
                    SourceTypeName = "采购";
                }
            }
            drowNew["SourceTypeID"]=this.GetSourceTypeID (SourceTypeName);  
            drowNew["LossRate"] = LossRate;  
            drowNew["Memo"] = drow["备注"]; 
            this.SetBOMStoreQty(drowNew);
            this.dtblBom.Rows.Add(drowNew);
          
        }
        public  bool ValidateData()
        {
            if ((this.ckbOutSrcFlag.Checked) && (this.ctrlSupplierID.CompanyID == -1))
            {
                return false;
            }
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                if (grow.ErrorText != string.Empty)
                { 
                    return false;

                }
            } 
            return true;
        }
       
        public void Save()
        {  
            if (this.ValidateData() == false) return;
            string errormsg = string.Empty; 
            int SourceTypeID;
            decimal   RequireQty,   LossRate;  
            foreach (DataRow drowBom in this.dtblBom.Rows)            
            {
                if (drowBom.RowState == DataRowState.Deleted) continue;
                SourceTypeID = (int)drowBom["SourceTypeID"];
                if (SourceTypeID >3) continue;  //1:生产;2,采购;3,客供,4,供应商自备
                PrdID = (int)drowBom["PrdID"];
                LossRate = 0;
                if (drowBom["LossRate"] != DBNull.Value)
                {
                    LossRate = (decimal)drowBom["LossRate"];
                }
                RequireQty =Convert.ToInt32 (ManufQty  * (decimal)drowBom["AssemblyQty"] * (1 + LossRate));
                //委外处理
                this.BOMPlanHelper.BOMOutSrcHandle(this.ctrlSupplierID .CompanyID ,PrdID,ref RequireQty);
                if (RequireQty <= 0) continue;
                if ((SourceTypeID < 3)||(this.CustomerID <0))
                {
                    this.BOMPlanHelper.BOMHandle(this.CustomerID, PrdID, RequireQty, SourceTypeID );
                }
                if ((SourceTypeID == 3)&&(CustomerID >-1))
                {
                    this.BOMPlanHelper .BOMOEMHandle (this.CustomerID, PrdID, RequireQty);
                }
                if (this.ManufPlanID > -1)
                {
                    //保存物料
                    this.accBOMPlans.InsertBOMPlans(ref errormsg,
                        this.ManufPlanID,
                        this.ManufProcessID,
                        PrdID,
                        drowBom["AssemblyQty"],
                        drowBom["LossRate"],
                        SourceTypeID,
                        RequireQty,
                        drowBom["StoreQty"],
                        drowBom["OutSrcStoreQty"],
                        drowBom["RoadStoreQty"],
                        drowBom["PlanQty"]);
                }
            }
         
        }
      
 
      

   
    }
}