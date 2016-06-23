using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Config
{
    public partial class FrmExpress : Form
    {
        private static FrmExpress frmBill;
        private  FrmExpress()
        {
            InitializeComponent();
            this.btnExport .Click +=new EventHandler(btnExport_Click);
            this.ctrlCustomer.AffterSelected += new JERPApp.Define.General.CtrlCustomer.AffterSelectedDelegate(ctrlCustomer_AffterSelected);
            this.btnFromCustomer.Click += new EventHandler(btnFromCustomer_Click);
            this.btnFromSupplier.Click += new EventHandler(btnFromSupplier_Click);
        }

        void ctrlCustomer_AffterSelected()
        {
            this.ctrlDeliverAddress.LoadData(this.ctrlCustomer.CompanyID);
        }
        public static   void ExpressPrint()
        {
            if (frmBill == null)
            {
                frmBill = new FrmExpress();
                frmBill.StartPosition = FormStartPosition.CenterParent;             
            }
            frmBill.ShowDialog ();
        }
     
        void btnFromSupplier_Click(object sender, EventArgs e)
        {
            this.txtCompanyName.Text = this.ctrlSupplier.CompanyAllName;
            this.txtAddress.Text = this.ctrlSupplier.Address;
            this.txtLinkman.Text = this.ctrlSupplier.Linkman;
            this.txtTelephone.Text = this.ctrlSupplier.Telephone;
        }

        void btnFromCustomer_Click(object sender, EventArgs e)
        {
            this.txtCompanyName.Text = this.ctrlCustomer.CompanyAllName;
            this.txtAddress.Text = this.ctrlDeliverAddress.Address ;
            this.txtLinkman.Text = this.ctrlDeliverAddress.Linkman;
            this.txtTelephone.Text = this.ctrlDeliverAddress.Telephone;
        }

        void btnExport_Click(object sender, EventArgs e)
        {
            int copies;
            if(!int.TryParse (this.txtCopies .Text ,out copies ))
            {
                MessageBox .Show ("份数格式出错!");
            }
            FrmMsg.Show("正在生成Excel文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"ExpressBill.xlt");
            for (int i = 1; i <= excel.GetSheetsCount(); i++)
            {
                if (excel.GetSheetName(i).Trim() != this.ctrlExpress.CompanyName  )
                {
                    excel.DeleteSheet(i);
                    i--;
                }
            }
            excel.SetCurSheet(this.ctrlExpress.CompanyName );
            if (this.ctrlExpress.CompanyName!= string.Empty)
            {
                excel.SetCellVal(this.ctrlExpress.CompanyName, this.txtCompanyName.Text);
            }
            if (this.ctrlExpress.ReceiveAddressCellName   != string.Empty)
            {
                excel.SetCellVal(this.ctrlExpress.ReceiveAddressCellName  , this.txtAddress.Text);
            }
            if (this.ctrlExpress.LinkmanCellName  != string.Empty)
            {
                excel.SetCellVal(this.ctrlExpress.LinkmanCellName , this.txtLinkman.Text);
            }
            if (this.ctrlExpress.TelephoneCellName  != string.Empty)
            {
                excel.SetCellVal(this.ctrlExpress.TelephoneCellName, this.txtTelephone.Text);
            }
            excel.Printer = JERPBiz.Config.ConfigInfo.GetNotePrinter();
            excel.PrintCurSheet(copies);
            FrmMsg.Hide();
           
        }
    }
}