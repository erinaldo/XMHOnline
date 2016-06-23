using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.OtherRes
{
    public partial class FrmPrdNew : Form
    {
        public FrmPrdNew()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accPrds = new JERPData.OtherRes .Product ();
            this.accUnits = new JERPData.General.Unit();  
            this.SetColumnSrc();  
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnImport.Click += new EventHandler(btnImport_Click); 
            this.dgrdv.RowEnter += new DataGridViewCellEventHandler(dgrdv_RowEnter);
             
        }

     
        private JERPData.OtherRes  .Product  accPrds;
        private JERPData.General.Unit accUnits;  
        private DataTable dtblProduct,dtblUnits ;
        private JCommon.FrmExcelImport frmImport; 
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
        public  void NewPrd()
        { 
            this.dtblProduct = this.accPrds.GetDataProductByPrdID (this.ctrlPrdTypeID .PrdTypeID).Tables[0];
            this.dtblProduct.Columns["UnitID"].DefaultValue = 1; 
            this.dgrdv.DataSource = this.dtblProduct; 
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
                
                    new DataColumn ("产品名称",typeof (string)),  
                    new DataColumn ("型号及规格",typeof (string)),         
                    new DataColumn ("单位",typeof (string)),       
                    new DataColumn ("供应商",typeof (string)),                    
                    new DataColumn ("成本价",typeof (decimal)),
                    new DataColumn ("最小包装",typeof (decimal)) 
                };
                this.frmImport.SetImportColumn(columns, "产品名称不能为空，单位不填默认为PCS");
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
              
            ; 
            DataRow drowNew = this.dtblProduct.NewRow();

            drowNew["PrdName"] = drow["产品名称"]; 
            drowNew["PrdSpec"] = drow["型号及规格"]; 
            drowNew["MinPackingQty"] = drow["最小包装"];
            drowNew["Supplier"] = drow["供应商"];
            drowNew["CostPrice"] = drow["成本价"]; 
            drowNew["UnitID"] = this.GetUnitID(UnitName); 
            this.dtblProduct.Rows.Add(drowNew);
        }

        void frmImport_AffterSave()
        {
            this.SetColumnSrc();
        }
        private bool ValidateData()
        { 
            DataRow[] drows = this.dtblProduct.Select("PrdName is null", "");
            if (drows.Length > 0)
            {
                MessageBox.Show("产品名称不能为空");
                return false;
            }
            return true;
        }
    
        void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            DialogResult rul = MessageBox.Show("即将新增当前产品,可以在产品定义或工程设置里进行变更！", "新增确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            string errormsg = string.Empty;
            bool flag = false;
            foreach (DataRow drow in this.dtblProduct.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                
                object objPrdID = DBNull.Value;
                flag = this.accPrds.InsertProduct (
                        ref errormsg,
                        ref objPrdID,
                        this.ctrlPrdTypeID .PrdTypeID, 
                        drow["PrdName"],
                        drow["PrdSpec"],
                        drow["AssistantCode"],
                        drow["UnitID"],
                        drow["CostPrice"],
                        drow["MinPackingQty"],
                        drow["Supplier"]);
                if (!flag)
                {
                    drow.RowError = errormsg;
                }
            }
            this.dgrdv.Refresh();
            MessageBox.Show("成功新增了当前类别的耗材");
            if (this.affterSave != null) this.affterSave();
           
        }

    }
}