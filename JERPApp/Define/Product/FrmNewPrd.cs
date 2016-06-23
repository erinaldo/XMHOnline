using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Product
{
    public partial class FrmPrdNew : Form
    {
        public FrmPrdNew()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accPrds = new JERPData.Product.Product ();
            this.accUnits = new JERPData.General.Unit();  
            this.SetColumnSrc();  
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnImport.Click += new EventHandler(btnImport_Click); 
            this.dgrdv.RowEnter += new DataGridViewCellEventHandler(dgrdv_RowEnter);
             
        }

     
        private JERPData.Product .Product  accPrds;
        private JERPData.General.Unit accUnits;  
        private DataTable dtblProduct,dtblUnits;
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
            this.ctrlPrdTypeID.PrdTypeID = -1;
            this.dtblProduct = this.accPrds.GetDataProductByPrdID (-1).Tables[0];
            this.dtblProduct.Columns["UnitID"].DefaultValue = 1;  
            this.dtblProduct.Columns["SaleFlag"].DefaultValue = false;
            this.dtblProduct.Columns["StopFlag"].DefaultValue = false ;
            this.dgrdv.DataSource = this.dtblProduct; 
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
                DataColumn[] columns=new DataColumn[] {      
                    new DataColumn ("产品编号",typeof (string)),
                    new DataColumn ("产品名称",typeof (string)),             
                    new DataColumn ("产品规格",typeof (string)),                 
                    new DataColumn ("型号",typeof (string)),                
                    new DataColumn ("封装/表面处理",typeof (string)),        
                    new DataColumn ("品牌",typeof (string)),    
                    new DataColumn ("单位",typeof (string)),      
                    new DataColumn ("销售",typeof (string)),                              
                    new DataColumn ("图号",typeof (string)),                    
                    new DataColumn ("助记码",typeof (string)),   
                    new DataColumn ("供应商",typeof (string)),                    
                    new DataColumn ("成本价",typeof (decimal)),
                    new DataColumn ("最小包装",typeof (decimal)),
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
            drowNew["Supplier"] = drow["供应商"];
            drowNew["CostPrice"] = drow["成本价"];
            drowNew["PrdWeight"] = drow["单重"]; 
            drowNew["SaleFlag"] = SaleFlag;
            drowNew["TaxfreeFlag"] = TaxfreeFlag;
            drowNew["RohsFlag"] = RohsFlag;
            drowNew["RohsRequireFlag"] = RohsRequireFlag;
            drowNew["UnitID"] = this.GetUnitID(UnitName);
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
                int oldprdid = this.GetPrdID(drow["PrdCode"].ToString());
                if (oldprdid > -1)
                {
                    drow.RowError = "对不起，此编号已存在";
                    return;
                }
                object objPrdID = DBNull.Value;
                flag = this.accPrds.InsertProductForImport(
                        ref errormsg,
                        ref objPrdID,
                        this.ctrlPrdTypeID .PrdTypeID  ,
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
                if (!flag)
                {
                    drow.RowError = errormsg;
                }
            }
            this.dgrdv.Refresh();
            MessageBox.Show("成功新增了当前类别的产品");
            if (this.affterSave != null) this.affterSave();
           
        }

    }
}