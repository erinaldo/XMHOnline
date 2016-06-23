using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer
{
    public partial class FrmPrdSetOper : Form
    {
        public FrmPrdSetOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accBOM = new JERPData.Product.PrdSet ();
            this.prdEntity = new JERPBiz.Product.ProductEntity();
            this.accPrds = new JERPData.Product.Product();
            foreach (DataGridViewColumn col in this.dgrdv.Columns)
            {
                col.ReadOnly = true;
            }
            this.ColumnAssemblyQty.ReadOnly = false;
             this.dgrdv.CellContextMenuStripNeeded +=dgrdv_CellContextMenuStripNeeded;
            this.btnImport.Click += new EventHandler(btnImport_Click);
            this.btnAdd.Click += new EventHandler(btnAdd_Click);
            this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }

      
        private JERPBiz.Product.ProductEntity prdEntity;
        private JERPData.Product.Product accPrds;
        private JERPData.Product.PrdSet  accBOM; 
        private JCommon.FrmExcelImport frmImport;
        private JERPApp.Define.Product.FrmProduct frmPrd;
        private JERPApp.Define.Product.FrmProduct frmPrdAlter;     
        private DataTable dtblBom;
        public delegate void AffterSaveDelegate(int SetPrdCount);
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
        private int prdid = -1;
        private   int PrdID
        {
            get
            {
                return this.prdid;
            }
            set
            {
                this.prdid = value;
                this.btnImport.Enabled = (value > -1);
                this.btnAdd.Enabled = (value > -1);   

            }
        }
      
        private void LoadBom()
        {
          
            this.dtblBom = this.accBOM.GetDataPrdSetBySetPrdID (this.PrdID).Tables[0];
            this.dtblBom.Columns["AssemblyQty"].DefaultValue = 1; 
            this.dgrdv.DataSource = this.dtblBom;
        }    
        public void PrdSetBomOper(int PrdID)
        {           
            this.PrdID = PrdID;
            this.LoadBom();
        }

        void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadBom();
        }
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {               
                grow.ErrorText = string.Empty;
                if (grow.Cells[this.ColumnPrdID.Name].Value == DBNull.Value)
                {
                    grow.ErrorText = "物料不能为空";
                    continue;
                }
                int PrdID = (int)grow.Cells[this.ColumnPrdID.Name].Value;
                if (PrdID ==-1)
                {
                    grow.ErrorText = "不存在此物料";
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
                this.frmPrd.AllowAppendFlag = true;
                new FrmStyle(this.frmPrd).SetPopFrmStyle(this);
                this.frmPrd .AffterSelected+=new JERPApp.Define.Product.FrmProduct.AffterSelectedDelegate(frmPrd_AffterSelected);
            }
            this.frmPrd.ShowDialog(); 
        }
        void frmPrd_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"];
            if (this.dtblBom.Select("PrdID=" + PrdID.ToString(), "", DataViewRowState.CurrentRows).Length > 0)
            {
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
            this.dtblBom.Rows.Add(drowNew); 
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
                    new FrmStyle(this.frmPrdAlter).SetPopFrmStyle(this);
                    this.frmPrdAlter.AffterSelected += new JERPApp.Define.Product.FrmProduct.AffterSelectedDelegate(frmPrdAlter_AffterSelected);
                }
                this.frmPrdAlter .ShowDialog();
            }
        }
    
        void frmPrdAlter_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"];
            if (this.dtblBom.Select("PrdID=" + PrdID.ToString(),"",DataViewRowState.CurrentRows ).Length>0)
            {
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
           this.frmPrdAlter.Close();
        }
      
        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblBom.DefaultView[irow].Row;
            if (drow["ID"] == DBNull.Value)
            {
                return;
            }
            string errormsg = string.Empty;
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accBOM.DeletePrdSet(ref errormsg, drow["ID"]);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private int GetPrdID(string PrdCode,string PrdName,string PrdSpec)
        {
            int PrdID = -1;
            this.accPrds.GetParmProductPrdID(PrdCode, ref PrdID);
            if (PrdID > -1) return PrdID;
            this.accPrds.GetParmProductPrdIDFromOtherInfor(PrdName, PrdSpec, ref PrdID);
            return PrdID;
        }
       
       
        void btnImport_Click(object sender, EventArgs e)
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
                    new DataColumn ("用量",typeof (decimal)),       
                    new DataColumn ("单位",typeof (string))           
                };

                frmImport.SetImportColumn(columns, "[物料编号]或名称及规格不能为空 \n[用量]非空整数;损耗率%" +
                    "\n来源方式:生产;采购;客供;供应商自备;固定:是或否,空代表是");
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
            decimal AssemblyQty = (decimal)drow["用量"];
            object objID = DBNull.Value;
            if (PrdID > -1)
            {
                if (this.dtblBom.Select("PrdID=" + PrdID.ToString()).Length > 0)
                {
                    errormsg = "物料重复";
                    flag = false;
                }
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
            this.dtblBom.Rows.Add(drowNew);
          
        }
        private bool ValidateData()
        {

            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                if (grow.IsNewRow) continue;
                if (grow.ErrorText != string.Empty)
                {
                    MessageBox.Show("物料清单明细有误,不能保存清单");
                    return false;

                }
            }
            return true;
        }
       
        void btnSave_Click(object sender, EventArgs e)
        {
                      
            if (this.PrdID == -1) return;
            if (this.ValidateData() == false) return;
            string errormsg = string.Empty;
            bool flag = false;
            foreach (DataRow drow in this.dtblBom.Rows)            
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow["PrdID"] == DBNull.Value) continue;
                if (drow["ID"] == DBNull.Value)
                {
                    object objID = DBNull.Value;
                    flag = this.accBOM.InsertPrdSet(ref errormsg,
                        ref objID,
                        this.PrdID, 
                        drow["PrdID"],
                        drow["AssemblyQty"]);
                    if (flag)
                    {
                        drow["ID"] = objID;                       
                    }
                }
                else
                {
                    
                    flag = this.accBOM.UpdatePrdSet(
                        ref errormsg,
                        drow["ID"], 
                        drow["PrdID"],
                        drow["AssemblyQty"]); 
                }
                drow.AcceptChanges();
             
            }
            this.accPrds.UpdateProductForPrdSetCount(ref errormsg, this.PrdID);
            if (this.affterSave != null) this.affterSave(this.dtblBom.Rows.Count);
            MessageBox.Show("成功保存当前套料设置");
        } 
    }
}