using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply.Material
{
    public partial class FrmSupplierPrdCode : Form
    {
        public FrmSupplierPrdCode()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accPrds = new JERPData.Product.Product  ();
            this.accSupplierPrdCode = new JERPData.Product .SupplierPrdCode();  
            this.SetPermit();
        }

     
        private JERPData.Product.Product   accPrds;
        private JERPData.Product .SupplierPrdCode accSupplierPrdCode;
        private DataTable dtblPrds, dtblSupplierPrdCode;
        private JERPApp.Define.Material.FrmProduct  frmPrd;
        private JERPApp.Define.Material.FrmProduct frmPrdAppend;
        private JCommon.FrmExcelImport frmImport;
        private JCommon.FrmGridFind frmGridPrd;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(224);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(225);
            if (this.enableBrowse)
            {
                this.dgrdv.CellQuery += new JCommon.MyDataGridView.CellQueryDelegate(dgrdv_CellQuery);
                this.ctrlQFind.SeachGridView = this.dgrdv;
                this.dtblPrds = this.accPrds.GetDataProductForMaterial().Tables[0];
                this.FormClosed +=new FormClosedEventHandler(FrmMaterial_FormClosed);
                this.btnAdd.Click += new EventHandler(btnAdd_Click);
                this.LoadData();
            }         
            this.btnImport.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.ctrlSupplierID.AffterSelected += this.LoadData;
                this.btnSave.Click += new EventHandler(btnSave_Click);
                this.btnImport.Click += new EventHandler(btnImport_Click);
                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
                this.dgrdv.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(dgrdv_CellContextMenuStripNeeded);
            }
        }
        void dgrdv_CellQuery(DataGridViewCellEventArgs e)
        { 

            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnAssistantCode.Name)
            {
                
                if (this.frmGridPrd == null)
                {
                    this.frmGridPrd = new JCommon.FrmGridFind();
                    this.frmGridPrd.AddGridColumn("PrdCode", "物料编号", 80);
                    this.frmGridPrd.AddGridColumn("PrdName", "物料名称", 100);
                    this.frmGridPrd.AddGridColumn("PrdSpec", "物料规格", 100);
                    this.frmGridPrd.AddGridColumn("Model", "型号", 66);
                    this.frmGridPrd.AddGridColumn("Manufacturer", "品牌", 66);
                    this.frmGridPrd.AddGridColumn("AssistantCode", "助记码", 66);
                    this.frmGridPrd.AffterSelected += frmGridPrd_AffterSelected;

                }
                this.frmGridPrd.Query(this.dtblPrds, "AssistantCode", this.dgrdv.CurrentCell);


            }
        }
        void frmGridPrd_AffterSelected(DataRow drow)
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            grow.Cells[this.ColumnPrdID.Name].Value = drow["PrdID"];
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnManufacturer.Name].Value = drow["Manufacturer"];
        }
    
        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblPrds .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["ID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accSupplierPrdCode .DeleteSupplierPrdCode (ref ErrorMsg,
                    drow["ID"]);
                if (!flag)
                {                    
                    MessageBox.Show(ErrorMsg);
                }
            }
            else
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
      
        private void LoadData()
        {
            this.dtblSupplierPrdCode   = this.accSupplierPrdCode .GetDataSupplierPrdCodeByCompanyID(this.ctrlSupplierID .CompanyID).Tables[0];
            this.dtblSupplierPrdCode.Columns["PrdID"].Unique = true;
            this.dtblSupplierPrdCode.Columns["PrdID"].AllowDBNull = false;
            this.dgrdv.DataSource = this.dtblSupplierPrdCode;
       
        }
        
        private int GetPrdID(string PrdCode)
        {
            int rut = -1;
            this.accPrds.GetParmProductPrdID (PrdCode, ref rut);
            return rut;
            
        }
  
        void FrmMaterial_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }
        void btnImport_Click(object sender, EventArgs e)
        {
           
            if (this.frmImport == null)
            {
                this.frmImport = new JCommon.FrmExcelImport();
                new FrmStyle(frmImport).SetPopFrmStyle(this); 
                this.frmImport.ImportHandle += new JCommon.FrmExcelImport.ImportDelegate(frmImport_ImportHandle);
                DataColumn[] columns=new DataColumn[] {
                    new DataColumn ("物料编号",typeof (string)),
                    new DataColumn ("物料名称",typeof (string)),
                    new DataColumn ("物料规格",typeof (string)),
                    new DataColumn ("型号",typeof (string)),
                    new DataColumn ("品牌",typeof (string)),
                    new DataColumn ("供应商料号",typeof (string))
                };
                this.frmImport.SetImportColumn(columns, "物料编号不能为空");
            }
            this.frmImport.ShowDialog();

        }
        
        void frmImport_ImportHandle(DataRow drow, out bool flag, out string msg)
        {
            flag = true;
            msg = "成功!";
            object objPrdID=DBNull .Value ;            
            int PrdID = this.GetPrdID(drow["物料编号"].ToString());
            if (PrdID == -1)
            {
                flag = false;
                msg = "不存在此物料";
                return;
            }
            if (this.dtblSupplierPrdCode.Select("PrdID=" + PrdID.ToString()).Length > 0)
            {
                flag = false;
                msg = "已存在此物料";
                return;
            }
          
          
            DataRow drowNew = this.dtblSupplierPrdCode .NewRow();
            drowNew["PrdID"] =PrdID ;
            drowNew["PrdCode"] = drow["物料编号"];
            drowNew["PrdName"] = drow["物料名称"];
            drowNew["PrdSpec"] = drow["物料规格"];
            drowNew["Model"] = drow["型号"];
            drowNew["Manufacturer"] = drow["品牌"];           
            drowNew["SupplierPrdCode"] = drow["供应商料号"];
            this.dtblSupplierPrdCode.Rows.Add(drowNew);
        }

        private bool ValidateData()
        {
            if (this.ctrlSupplierID.CompanyID  == -1)
            {
                MessageBox.Show("供应商不能为空");
                return false;
            }
          
            return true;
        }
        void btnAdd_Click(object sender, EventArgs e)
        {
            if (frmPrdAppend == null)
            {
                frmPrdAppend = new JERPApp.Define.Material.FrmProduct();
                new FrmStyle(frmPrdAppend).SetPopFrmStyle (this);
                frmPrdAppend.AffterSelected +=frmPrdAppend_AffterSelected;
            }
            frmPrdAppend.Show();
        }

        void frmPrdAppend_AffterSelected(DataRow drow)
        {
            DataRow[] drows = this.dtblSupplierPrdCode.Select("PrdID=" + drow["PrdID"].ToString(), "", DataViewRowState.CurrentRows);
            if (drows.Length > 0)
            {
                MessageBox.Show("此产品已存在");
                return;
            }
            DataRow drowNew = this.dtblSupplierPrdCode.NewRow();
            drowNew["PrdID"] = drow["PrdID"];
            drowNew["PrdCode"] = drow["PrdCode"];
            drowNew["PrdName"] = drow["PrdName"];
            drowNew["PrdSpec"] = drow["PrdSpec"];
            drowNew["Model"] = drow["Model"];
            drowNew["Manufacturer"] = drow["Manufacturer"];       
            this.dtblSupplierPrdCode.Rows.Add(drowNew);
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
                ||(this.dgrdv.Columns[icol].DataPropertyName == "Manufacturer"))
            { 
                this.dgrdv.CurrentCell = this.dgrdv[icol, irow];
                if (frmPrd == null)
                {
                    this.frmPrd = new JERPApp.Define.Material.FrmProduct();
                    new FrmStyle(this.frmPrd).SetPopFrmStyle(this);
                    this.frmPrd.AffterSelected += new JERPApp.Define.Material.FrmProduct.AffterSelectedDelegate(frmPrd_AffterSelected);
                }
                this.frmPrd.ShowDialog();
            }
        }

        void frmPrd_AffterSelected(DataRow drow)
        {
            int PrdID = (int)drow["PrdID"];  
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            grow.Cells[this.ColumnPrdID.Name].Value = PrdID;
            grow.Cells[this.ColumnPrdCode.Name].Value = drow["PrdCode"];
            grow.Cells[this.ColumnPrdName.Name].Value = drow["PrdName"];
            grow.Cells[this.ColumnPrdSpec.Name].Value = drow["PrdSpec"];
            grow.Cells[this.ColumnModel.Name].Value = drow["Model"];
            grow.Cells[this.ColumnManufacturer.Name].Value = drow["Manufacturer"];  
            this.frmPrd.Close();
        }
 
       
        void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            string errormsg = string.Empty;
            bool flag = false;
            foreach (DataRow drow in this.dtblSupplierPrdCode .Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow["SupplierPrdCode"] == DBNull.Value) continue;
                if (drow["ID"] == DBNull.Value)
                {
                    object objID = DBNull.Value;
                    flag = this.accSupplierPrdCode .InsertSupplierPrdCode (
                            ref errormsg,
                            ref objID,                          
                            drow["PrdID"],
                            this.ctrlSupplierID .CompanyID ,
                            drow["SupplierPrdCode"]);

                    if (flag)
                    {
                        drow["ID"] = objID;
                        drow.AcceptChanges();
                    }
                   
                }
                else
                {
                  
                        flag = this.accSupplierPrdCode .UpdateSupplierPrdCode  (
                                ref errormsg,
                                drow["ID"],
                                this.ctrlSupplierID .CompanyID ,
                                drow["PrdID"],
                                drow["SupplierPrdCode"]);     
                   
                }
                if (flag)
                {
                    
                    drow.AcceptChanges();
                    this.accPrds.UpdateProductForSupplierPrdCode(ref errormsg, drow["PrdID"]);
                }
                else
                {
                    MessageBox.Show(errormsg);
                }

            }
            MessageBox.Show("成功保存了原料编码");
        }

    }
}