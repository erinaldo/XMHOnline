using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Supply
{
    public partial class FrmSupplier : Form
    {
        public FrmSupplier()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accSuppliers = new JERPData.General.Supplier ();
            this.SetPermit();
        }
        private JERPData.General .Supplier accSuppliers;
        private DataTable dtblSupplier;
        private JCommon.FrmExcelImport frmImport;
        private FrmSupplierOper frmOper;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(13);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(14);
            if (this.enableBrowse)
            {
                this.ctrlQFind.SeachGridView = this.dgrdv;
                this.btnExport .Click +=new EventHandler(btnExport_Click);
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                //加载数据
                LoadData();
            }          
            this.btnImport.Enabled = this.enableSave;
            this.ColumnbtnEdit.Visible = this.enableSave;
            this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
            if (this.enableSave)
            {
                
                this.btnImport .Click +=new EventHandler(btnImport_Click);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
 
            }

        
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnbtnEdit.Name)
            {
                int CompanyID = (int)this.dtblSupplier.DefaultView[irow]["CompanyID"];
                if (frmOper == null)
                {
                    frmOper = new FrmSupplierOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += this.LoadData;
                }
                frmOper.Edit(CompanyID);
                frmOper.ShowDialog();
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnURL .Name)
            {
                System.Diagnostics.Process.Start(this.dgrdv[icol,irow].Value .ToString ());
            }
        }

        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmOper == null)
            {
                frmOper = new FrmSupplierOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += this.LoadData;
            }
            frmOper.New();
            frmOper.ShowDialog();
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
            this.dtblSupplier = this.accSuppliers.GetDataSupplier().Tables[0];
            this.dgrdv.DataSource = this.dtblSupplier;
        }
        bool GetBool(string BoolInfor)
        {
            return (BoolInfor == "是");
        }
        void btnImport_Click(object sender, EventArgs e)
        {
            if (this.frmImport == null)
            {
                this.frmImport = new JCommon.FrmExcelImport();
                new FrmStyle(frmImport).SetPopFrmStyle(this);
                this.frmImport.ImportHandle += new JCommon.FrmExcelImport.ImportDelegate(frmImport_ImportHandle);
                this.frmImport.AffterSave += new JCommon.FrmExcelImport.AffterSaveDelegate(frmImport_AffterSave);
                DataColumn[] columns = new DataColumn[] {
                    new DataColumn ("编号",typeof (string)),
                    new DataColumn ("简称",typeof (string)),  
                    new DataColumn ("全名",typeof (string)),   
                    new DataColumn ("法人",typeof (string)),       
                    new DataColumn ("备注",typeof (string)),      
                    new DataColumn ("联系人",typeof (string)),  
                    new DataColumn ("电话",typeof (string)),    
                    new DataColumn ("手机",typeof (string)),    
                    new DataColumn ("传真",typeof (string)),    
                    new DataColumn ("QQ",typeof (string)),
                    new DataColumn ("微信",typeof (string)),  
                    new DataColumn ("银行信息",typeof (string)),  
                    new DataColumn ("Email",typeof(string)),     
                    new DataColumn ("网址",typeof(string)),     
                    new DataColumn ("地址",typeof (string)),  
                    new DataColumn ("原料",typeof (string)), 
                    new DataColumn ("产品",typeof (string)),                   
                    new DataColumn ("委外",typeof (string)),
                    new DataColumn ("耗材",typeof (string)), 
                    new DataColumn ("方案",typeof (string)),
                    new DataColumn ("治具",typeof (string))
                };
                this.frmImport.SetImportColumn(columns, "供应商简称不能重复,且必填;\n采购、委外,是供应商类型，填'是',其他的当成是否");
            }
            this.frmImport.ShowDialog();

        }

        void frmImport_AffterSave()
        {
            frmImport.Close();
            this.LoadData();
        }
        private int GetCompanyID(string CompanyCode)
        {
            int rut = -1;
            this.accSuppliers.GetParmSupplierCompanyID(CompanyCode, ref rut);
            return rut;
        }
        void frmImport_ImportHandle(DataRow drow, out bool flag, out string msg)
        {
            flag = true;
            msg = "成功!";
            //检查一下有没有这个简称
            int CompanyID = this.GetCompanyID(drow["编号"].ToString());
            if (CompanyID > -1)
            {
                msg = "已存在此编号";
                flag = false;
                return;

            }
            string errormsg=string.Empty ;
            object objCompanyID = DBNull.Value;
            this.accSuppliers .InsertSupplier (
                ref errormsg ,
                ref objCompanyID ,
                drow["编号"],
                drow["简称"],
                drow["全名"], 
                drow["法人"],
                this.GetBool(drow["原料"].ToString()),
                this.GetBool(drow["产品"].ToString()), 
                this.GetBool(drow["耗材"].ToString()),
                this.GetBool(drow["治具"].ToString()),
                this.GetBool(drow["委外"].ToString()),
                this.GetBool(drow["方案"].ToString()),
                drow["联系人"] ,
                drow["电话"] ,
                drow["手机"],
                drow["传真"],
                drow["QQ"],
                drow["微信"],
                drow["Email"],
                drow["网址"],
                drow["地址"],
                drow["银行信息"],
                drow["备注"]
                );
         
        }

    
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "供应商");
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