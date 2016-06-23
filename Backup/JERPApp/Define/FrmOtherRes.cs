using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define
{
    public partial class FrmOtherRes : Form
    {
        public FrmOtherRes()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accPrds = new JERPData.OtherRes .Product ();
            this.accUnits = new JERPData.General.Unit();  
            this.SetPermit();
        }

     
        private JERPData.OtherRes  .Product  accPrds;
        private JERPData.General.Unit accUnits;  
        private DataTable dtblProduct,dtblUnits;
        private JCommon.FrmExcelImport frmImport;
        private JCommon.FrmFileBrowse frmFileBrowse;
        private JCommon.FrmImgBrowse frmImgBrowse;
        private JERPApp.Define.OtherRes .FrmPrdType frmPrdType;
      
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(451);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(452);
            if (this.enableBrowse)
            {  
                this.ctrlQFind.SeachGridView = this.dgrdv;
                this.ctrlQFind.BeforeFilter += this.LoadData;
                this.ctrlPrdTypeID.AffterSelected += this.LoadData;
                this.ctrlPrdTypeID.BeforeSelected += new JERPApp.Define.OtherRes.CtrlPrdTypeTree.BeforeSelectDelegate(ctrlPrdTypeID_BeforeSelected);
                this.SetColumnSrc();          
                this.FormClosed +=new FormClosedEventHandler(FrmProduct_FormClosed);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.LoadData();
            }         
            this.btnImport.Enabled = this.enableSave;           
            if (this.enableSave)
            {
                this.ctrlPrdTypeID.AllowDefine();
                this.btnSave.Click += new EventHandler(btnSave_Click);
                this.btnImport.Click += new EventHandler(btnImport_Click);
                this.dgrdv.RowEnter += new DataGridViewCellEventHandler(dgrdv_RowEnter);
                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
                this.btnExport.Click += new EventHandler(btnExport_Click);
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                
            }
        }
        void ctrlPrdTypeID_BeforeSelected(out bool CancelFlag)
        {

            foreach (DataRow drow in this.dtblProduct.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                DialogResult rul = MessageBox.Show("存在未保存的项,是否需要保存再选择?", "操作提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rul == DialogResult.OK)
                {
                    CancelFlag = true;
                }
                else
                {
                    CancelFlag = false;
                }
                return;
            }
            CancelFlag = false;
        }
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }


        void mItemAlterType_Click(object sender, EventArgs e)
        {

            if (frmPrdType == null)
            {
                frmPrdType = new JERPApp.Define.OtherRes.FrmPrdType();
                new FrmStyle(frmPrdType).SetPopFrmStyle(this);
                frmPrdType.AffterSelected += this.frmPrdType_AffterSelected;
            }
            frmPrdType.ShowDialog();
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

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            object objPrdID = this.dtblProduct.DefaultView[irow]["PrdID"];
            if ((objPrdID == null) || (objPrdID == DBNull.Value)) return;
            string errormsg = string.Empty;          
            if (this.dgrdv.Columns[icol].Name == this.ColumnFileCount .Name)
            {
                if (frmFileBrowse == null)
                {
                    frmFileBrowse = new JCommon.FrmFileBrowse();
                    frmFileBrowse.ReadOnly = !this.enableSave ;
                    new FrmStyle(frmFileBrowse).SetPopFrmStyle(this);

                }
                frmFileBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\OtherRes\PrdFile\" + objPrdID.ToString());
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
                frmImgBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\OtherRes\PrdImg\" + objPrdID.ToString());
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
            bool flag = false;
            DataRow drow = this.dtblProduct .DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["PrdID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accPrds.DeleteProduct (ref ErrorMsg,
                    drow["PrdID"]);
                if (!flag)
                {
                    
                    MessageBox.Show(ErrorMsg );
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
       

    
        private void SetColumnSrc()
        { 
           
            this.dtblUnits = this.accUnits.GetDataUnit().Tables[0];
            this.ColumnUnitID.DataSource = this.dtblUnits;
            this.ColumnUnitID.ValueMember = "UnitID";
            this.ColumnUnitID.DisplayMember = "UnitName";

        }
       
        private void LoadData()
        { 
           this.dtblProduct = this.accPrds.GetDataProductByPrdTypeID(this.ctrlPrdTypeID.PrdTypeID).Tables[0];        
            this.dtblProduct.Columns["PrdName"].AllowDBNull = false;
            this.dtblProduct.Columns["UnitID"].AllowDBNull = false;
            this.dtblProduct.Columns["UnitID"].DefaultValue = 1;// 
            this.dgrdv.DataSource = this.dtblProduct;
       
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
                    new DataColumn ("产品名称",typeof (string)), 
                    new DataColumn ("型号及规格",typeof (string)), 
                    new DataColumn ("助记码",typeof (string)), 
                    new DataColumn ("单位",typeof (string)),     
                    new DataColumn ("供应商",typeof (string)),                    
                    new DataColumn ("成本价",typeof (decimal)),
                    new DataColumn ("最小包装",typeof (decimal))  
                };
                this.frmImport.SetImportColumn(columns, "产品名称，单位不填默认为PCS");
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
            DataRow drowNew = this.dtblProduct.NewRow();
            drowNew["PrdName"] = drow["产品名称"];
            drowNew["PrdSpec"] = drow["型号及规格"];
            drowNew["AssistantCode"] = drow["助记码"];  
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
            if (this.ctrlPrdTypeID.PrdTypeID == -1)
            {
                MessageBox.Show("产品类型不能为空");
                return false;
            }
            DataRow[] drows = this.dtblProduct.Select("PrdName is null", "");
            if (drows.Length > 0)
            {
                MessageBox.Show("产品名称不能为空");
                return false;
            }
            return true;
        }
        private void  SaveRow(int PrdTypeID,DataRow drow)
        {
            string errormsg = string.Empty;
            bool flag = false;    
            if (drow["PrdID"] == DBNull.Value)
            { 
                object objPrdID = DBNull.Value;
                flag = this.accPrds.InsertProduct (
                        ref errormsg,
                        ref objPrdID,
                        PrdTypeID, 
                        drow["PrdName"],
                        drow["PrdSpec"],
                        drow["AssistantCode"],
                        drow["UnitID"],
                        drow["CostPrice"],
                        drow["MinPackingQty"],
                        drow["Supplier"]);
                if (flag)
                {
                    drow["PrdID"] = objPrdID;
                    drow.AcceptChanges();
                    return;
                }

            }
            else
            { 
                flag = this.accPrds.UpdateProduct (
                        ref errormsg,
                        drow["PrdID"],
                        PrdTypeID, 
                        drow["PrdName"],  
                        drow["PrdSpec"],
                        drow["AssistantCode"],
                        drow["UnitID"],
                        drow["CostPrice"],
                        drow["MinPackingQty"],
                        drow["Supplier"]);

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
            MessageBox.Show("成功保存了耗材定义");
        }

    }
}