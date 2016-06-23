using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accCustomers = new JERPData.General.Customer();
            this.accArea = new JERPData.General.Area();
            this.accPsns = new JERPData.Hr.Personnel();
            this.accCustomerType = new JERPData.General.CustomerType();
            this.accDeliverAddress = new JERPData.General.DeliverAddress();
            this.accFinanceAddress = new JERPData.General.FinanceAddress();
            this.dtblPsns = this.accPsns.GetDataPersonnel().Tables[0];
            this.SetPermit();
        }
        private JERPData.General .Customer accCustomers;
        private FrmCustomerOper frmOper;
        private DataTable dtblCustomer;
        private JCommon.FrmExcelImport frmImport;
        private JERPData.General.Area accArea;
        private JERPData.Hr.Personnel accPsns;
        private JERPData.General.CustomerType accCustomerType;
        private JERPData.General.DeliverAddress accDeliverAddress;
        private JERPData.General.FinanceAddress accFinanceAddress;
        private FrmHandlePsnAlter frmHandlerAlter;
        private FrmSalePsnAlter frmSalePsnAlter;
        private DataTable dtblPsns;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(11);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(12);
            if (this.enableBrowse)
            {
                this.ctrlQFind.SeachGridView = this.dgrdv;
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.ctrlQFind.BeforeFilter += this.LoadData;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                //加载数据
                LoadData();
                this.btnExport .Click +=new EventHandler(btnExport_Click);
            }
            this.lnkNew.Enabled = this.enableSave;
            this.ColumnBtnEdit.Visible = this.enableSave;
            this.btnImport.Enabled = this.enableSave;
            this.lnkAlterHandler.Enabled = this.enableSave;
            this.lnkAlterSaler.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.lnkAlterSaler.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkAlterSaler_LinkClicked);
                this.lnkAlterHandler.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkAlterHandler_LinkClicked);
                this.FormClosed += new FormClosedEventHandler(FrmCustomer_FormClosed);
                this.btnImport .Click +=new EventHandler(btnImport_Click);
                this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            }
        }

        void lnkAlterHandler_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmHandlerAlter == null)
            {
                frmHandlerAlter = new FrmHandlePsnAlter();
                new FrmStyle(frmHandlerAlter).SetPopFrmStyle(this);
                frmHandlerAlter.AffterSave += this.LoadData;
            }
            frmHandlerAlter.HandlerPsnAlter();
            frmHandlerAlter.ShowDialog();
        }

        void lnkAlterSaler_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmSalePsnAlter == null)
            {
                frmSalePsnAlter = new FrmSalePsnAlter();
                new FrmStyle(frmSalePsnAlter).SetPopFrmStyle(this);
                frmSalePsnAlter.AffterSave += this.LoadData;
            }
            frmSalePsnAlter.SalePsnAlter();
            frmSalePsnAlter.ShowDialog();
        }

        void FrmCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
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
        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        { 
            this.dtblCustomer = this.accCustomers.GetDataCustomer().Tables[0];         
            this.dgrdv.DataSource = this.dtblCustomer;
        }
        private int GetAreaID(string AreaName)
        {
            int AreaID = -1;
            this.accArea.GetParmAreaAreaID(AreaName, ref AreaID);
            return AreaID;
        }
        private int GetCustomerTypeID(string CutomerTypeName)
        {
            int rut = -1;
            this.accCustomerType.GetParmCustomerTypeID(CutomerTypeName, ref rut);
            return rut;
        }
        private bool GetBool(string BoolInfor)
        {

            return (BoolInfor == "是");
        }
        private int GetPsnID(string PsnName)
        {
             
            DataRow[] drows = this.dtblPsns.Select("PsnName='" + PsnName + "'");
            if (drows.Length > 0)
            {
                return (int)drows[0]["PsnID"];
            }
            return -1;
        }

        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmOper == null)
            {
                frmOper = new FrmCustomerOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += this.LoadData;
            }
            frmOper.New();
            frmOper.ShowDialog();
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnBtnEdit.Name)
            {
                int CompanyID=(int)this.dtblCustomer.DefaultView [irow].Row["CompanyID"];
                if (frmOper == null)
                {
                    frmOper = new FrmCustomerOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += this.LoadData;
                }
                frmOper.Edit(CompanyID);
                frmOper.ShowDialog();
            } 
            if (this.dgrdv.Columns[icol].Name == this.ColumnURL.Name)
            {
                System.Diagnostics.Process.Start(this.dgrdv[icol, irow].Value.ToString());
            }
        }
        void btnImport_Click(object sender, EventArgs e)
        {
            if (this.frmImport == null)
            {
                this.frmImport = new JCommon.FrmExcelImport();
                new FrmStyle(frmImport).SetPopFrmStyle(this);
                this.frmImport.AffterSave += this.LoadData;
                this.frmImport.ImportHandle += new JCommon.FrmExcelImport.ImportDelegate(frmImport_ImportHandle);
                DataColumn[] columns = new DataColumn[] {
                    new DataColumn ("区域",typeof (string)),
                    new DataColumn ("编号",typeof (string)),
                    new DataColumn ("简称",typeof (string)),   
                    new DataColumn ("全称",typeof (string)), 
                    new DataColumn ("助记码",typeof (string)), 
                    new DataColumn ("客户类型",typeof (string)), 
                    new DataColumn ("法人",typeof (string)), 
                    new DataColumn ("注册时间",typeof (DateTime)), 
                    new DataColumn ("业务员",typeof (string)), 
                    new DataColumn ("跟单员",typeof (string)),  
                    new DataColumn ("联系人",typeof (string)), 
                    new DataColumn ("电话",typeof (string)),  
                    new DataColumn ("手机",typeof (string)),  
                    new DataColumn ("传真",typeof (string)),
                    new DataColumn ("QQ",typeof (string)),   
                    new DataColumn ("微信",typeof (string)),   
                    new DataColumn ("Email",typeof (string)),   
                    new DataColumn ("网址",typeof (string)),     
                    new DataColumn ("送货地址",typeof (string)),  
                    new DataColumn ("结算地址",typeof (string)),    
                    new DataColumn ("银行信息",typeof (string)),  
                    new DataColumn ("信用额度",typeof (decimal)), 
                    new DataColumn ("备注",typeof (string))
                };
                this.frmImport.SetImportColumn(columns,
                    "编号，简称,全称不能为空,公司客户，是或者否，未填以否算,如果出现多个送货地或结算地请用回车区别;\n业务员及跟单员用的是工号");
            }
            this.frmImport.ShowDialog();

        }

        void frmImport_ImportHandle(DataRow drow, out bool flag, out string msg)
        {
            flag = true;
            msg = "成功!";
            object objCompanyID = DBNull.Value;
            int SalePsnID = this.GetPsnID(drow["业务员"].ToString());
            if (SalePsnID == -1)
            {
                flag = false;
                msg = "业务员不存在";
                return;
            }
            int HandlePsnID = this.GetPsnID(drow["跟单员"].ToString());
            if (HandlePsnID == -1)
            {
                flag = false;
                msg = "跟单员不存在";
                return;
            }
            int CustomerTypeID = this.GetCustomerTypeID(drow["客户类型"].ToString());
            if (CustomerTypeID == -1)
            {
                flag = false;
                msg = "客户类型不存在";
                return;
            }
            flag = this.accCustomers.InsertCustomer (ref msg,
                ref objCompanyID,
                drow["编号"],
                drow["简称"],
                drow["全称"],
                drow["助记码"],
                drow["法人"],
                CustomerTypeID,
                drow["注册时间"],
                this.GetAreaID (drow["区域"].ToString ()),
                SalePsnID,
                HandlePsnID,
                drow["联系人"],
                drow["电话"],
                drow["手机"],
                drow["传真"],
                drow["QQ"],
                drow["微信"],
                drow["Email"],
                drow["网址"],
                drow["银行信息"],
                drow["信用额度"],
                drow["备注"]);
            string  Address = drow["送货地址"].ToString();
            string[] AddressList;
            string errormsg=string.Empty ;
            object objAddressID=DBNull .Value ;
            string[] spit = new string[]{@"
"};
            if (Address != string.Empty)
            {
                AddressList = Address.Split(spit, StringSplitOptions.RemoveEmptyEntries);
               for (int i = 0; i < AddressList.Length; i++)
               {
                   this.accDeliverAddress.InsertDeliverAddress(
                       ref errormsg,
                       ref objAddressID,
                       objCompanyID,
                       AddressList[i],
                       DBNull.Value,
                       DBNull.Value,
                       DBNull .Value );
               }
            }
            Address = drow["结算地址"].ToString();
            if (Address != string.Empty)
            {
                AddressList = Address.Split(spit, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < AddressList.Length; i++)
                {
                    this.accFinanceAddress.InsertFinanceAddress (
                        ref errormsg,
                        ref objAddressID,
                        objCompanyID,
                        AddressList[i],
                        DBNull.Value,
                        DBNull.Value,
                        DBNull .Value );
                }
            }
            this.accCustomers.UpdateCustomerForAddress(ref errormsg, objCompanyID);

        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "客户列表");
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