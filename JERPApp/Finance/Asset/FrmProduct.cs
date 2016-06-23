using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Asset
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accProduct = new JERPData.Asset.Product();
            this.SetPermit();
        }
        private JERPData.Asset.Product accProduct;
        private FrmPrdRepair frmRepair;
        private DataTable dtblProduct;
        private JCommon.FrmExcelImport frmImport;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(688);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(689);
            if (this.enableBrowse)
            {
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.btnExport .Click +=new EventHandler(btnExport_Click);
                this.LoadData();
            }
            this.btnImport.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.btnSave.Click += new EventHandler(btnSave_Click);
                this.btnImport.Click += new EventHandler(btnImport_Click);              
                this.dgrdv.UserDeletingRow += new DataGridViewRowCancelEventHandler(dgrdv_UserDeletingRow);
            }
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnDateLastRepair.Name)
            {
                object objPrdID = this.dtblProduct.DefaultView[irow]["PrdID"];
                if (objPrdID == DBNull.Value) return;
                if (frmRepair == null)
                {
                    frmRepair = new FrmPrdRepair();
                    new FrmStyle(frmRepair).SetPopFrmStyle(this);
                    frmRepair.AffterSave += new FrmPrdRepair.AffterSaveDelegate(frmRepair_AffterSave);
                }
                frmRepair.RepairRecord((int)objPrdID);
                frmRepair.ShowDialog();
            }
        }

        void frmRepair_AffterSave(int PrdID,object objDateLastRepair)
        {
            string errormsg=string.Empty ;
            this.accProduct.UpdateProductForRepair(ref errormsg,
                PrdID,
                objDateLastRepair);
            this.dgrdv.CurrentCell.Value  = objDateLastRepair;
        }


        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblProduct  = this.accProduct .GetDataProduct ().Tables[0];   
            this.dgrdv.DataSource = this.dtblProduct ;

        }
        void dgrdv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int irow = e.Row.Index;
            bool flag = false;
            DataRow drow = this.dtblProduct.DefaultView[irow].Row;
            string ErrorMsg = string.Empty;
            if (drow["PrdID"] == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
            DialogResult rul = MessageBox.Show("你的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                flag = this.accProduct .DeleteProduct (ref ErrorMsg,
                    drow["PrdID"]);
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
        void btnImport_Click(object sender, EventArgs e)
        {

            if (this.frmImport == null)
            {
                this.frmImport = new JCommon.FrmExcelImport();
                new FrmStyle(frmImport).SetPopFrmStyle(this);
                this.frmImport.ImportHandle += new JCommon.FrmExcelImport.ImportDelegate(frmImport_ImportHandle);
                DataColumn[] columns = new DataColumn[] {
                    new DataColumn ("资产编号",typeof (string)),
                    new DataColumn ("资产名称",typeof (string)),                     
                    new DataColumn ("使用人",typeof (string)),                   
                    new DataColumn ("责任人",typeof (string)),                      
                    new DataColumn ("存放地",typeof (string)),   
                    new DataColumn ("存放状态",typeof (string)),                    
                    new DataColumn ("采购日期",typeof (DateTime)),   
                    new DataColumn ("存放状态",typeof (string)),                      
                    new DataColumn ("价值",typeof (decimal)),                     
                    new DataColumn ("净残值",typeof (decimal)), 
                    new DataColumn ("累积折旧",typeof (decimal))
                };
                this.frmImport.SetImportColumn(columns, "产品编号不能为空，单位不填默认为台");
            }
            this.frmImport.ShowDialog();

        }
        private int GetPrdID(string PrdCode)
        {
            int rut = -1;
            this.accProduct.GetParmPrdID(PrdCode, ref rut);
            return rut;

        }
        void frmImport_ImportHandle(DataRow drow, out bool flag, out string msg)
        {
            flag = true;
            msg = "成功!";
            object objPrdID = DBNull.Value;
           
            int PrdID = this.GetPrdID (drow["资产编号"].ToString());
            if (PrdID > -1)
            {
                flag = false;
                msg = "已存在此编号";
                return;
            } 
            DataRow drowNew = this.dtblProduct .NewRow();
            drowNew["PrdCode"] = drow["资产编号"];
            drowNew["PrdName"] = drow["资产名称"];
            drowNew["UserName"] = drow["使用人"];
            drowNew["ResponsiblePsnName"] = drow["责任人"];
            drowNew["DepositPlace"] = drow["存放地"];
            drowNew["DepositStatus"] = drow["存放状态"];
            drowNew["DatePurchase"] = drow["采购日期"];
            drowNew["Cost"] = drow["价值"];
            drowNew["Salvage"] = drow["净残值"];
            drowNew["AccumDepreciate"] = drow["累积折旧"];
            this.dtblProduct .Rows.Add(drowNew);
        }
        private bool ValidateData()
        {
           
            DataRow[] drows = this.dtblProduct.Select("PrdCode is null", "");
            if (drows.Length > 0)
            {
                MessageBox.Show("资产编号不能为空");
                return false;
            }
            return true;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            string errormsg = string.Empty;
            bool flag = false;
            foreach (DataRow drow in this.dtblProduct .Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                if (drow["PrdID"] == DBNull.Value)
                {
                    object objPrdID = DBNull.Value;
                    flag = this.accProduct .InsertProduct (
                        ref errormsg,
                        ref objPrdID,
                        drow["PrdCode"],
                        drow["PrdName"],
                        drow["UserName"],
                        drow["ResponsiblePsnName"],
                        drow["DepositPlace"],
                        drow["DepositStatus"],
                        drow["DatePurchase"],
                        drow["Cost"],
                        drow["Salvage"],
                        drow["AccumDepreciate"]);
                    if (flag)
                    {
                        drow["PrdID"] = objPrdID;
                        drow.AcceptChanges();
                    }

                }
                else
                {
                    if (this.GetPrdID(drow["PrdCode"].ToString()) != (int)drow["PrdID"])
                    {
                        drow.RowError = "此编号已被别的资产使用";
                        continue;
                    }
                    else
                    {
                        flag = this.accProduct .UpdateProduct (
                                ref errormsg,
                                drow["PrdID"],
                                drow["PrdCode"],
                                drow["PrdName"],
                                drow["UserName"],
                                drow["ResponsiblePsnName"],
                                drow["DepositPlace"],
                                drow["DepositStatus"],
                                drow["DatePurchase"],
                                drow["Cost"],
                                drow["Salvage"],
                                drow["AccumDepreciate"]);
                    }
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
            MessageBox.Show("成功保存了资产定义");
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "资产一览");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, true);
            FrmMsg.Hide();
            excel.Show();
        }

    }
}