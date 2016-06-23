using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Report
{
    public partial class FrmProductDetail : Form
    {
        public FrmProductDetail()
        {
            InitializeComponent();
            this.accPrd = new JERPData.Product.Product();
            this.PrdEntity = new JERPBiz.Product.ProductEntity();
            this.printhelper = new JERPBiz.Product.BOMPrintHelper();
            this.ctrlFile.ReadOnly = true;
            this.ctrlImg.ReadOnly = true;
            this.ctrlManufImg.ReadOnly = true;
            this.lnkURL.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkURL_LinkClicked);
            this.btnExport.Click += new EventHandler(btnExport_Click);
        }

        private JERPBiz.Product.ProductEntity PrdEntity;
        private JERPData.Product.Product accPrd;
        private JERPBiz.Product.BOMPrintHelper printhelper; 
        private int prdid = -1;
        private int PrdID
        {
            get
            {
                return this.prdid;
            }
            set
            {
                this.prdid = value;
            }
        }     
       
        public void PrdDetail(int PrdID)
        {
            this.PrdID = PrdID;
            this.PrdEntity.LoadData(PrdID);
            this.txtPrdTypeName.Text = this.PrdEntity.PrdTypeName;
            this.txtPrdCode.Text = this.PrdEntity.PrdCode;
            this.txtPrdName.Text = this.PrdEntity.PrdName;
            this.txtPrdSpec.Text = this.PrdEntity.PrdSpec;
            this.txtModel.Text = this.PrdEntity.Model;
            this.txtSurface.Text = this.PrdEntity.Surface;
            this.txtManufacturer.Text = this.PrdEntity.Manufacturer;
            this.txtDWGNo.Text = this.PrdEntity.DWGNo;
            this.txtAssistantCode.Text = this.PrdEntity.AssistantCode;
            this.txtICSolution.Text = this.PrdEntity.ICSolution;
            this.ckbTaxfressFlag.Checked = this.PrdEntity.TaxfreeFlag;
            this.ckbRohsFlag.Checked = this.PrdEntity.RohsFlag;
            this.ckbRohsRequireFlag.Checked = this.PrdEntity.RohsRequireFlag;
            this.txtMinPackingQty.Text = string.Empty; 
            if (this.PrdEntity.MinPackingQty > 0)
            {
                this.txtMinPackingQty.Text = string.Format("{0:0.######}", this.PrdEntity.MinPackingQty);
            }
         
            this.txtPrdWeight.Text = string.Empty;
            if (this.PrdEntity.PrdWeight > 0)
            {
                this.txtPrdWeight.Text = string.Format("{0:0.######}", this.PrdEntity.PrdWeight);
            }        
            this.txtRegisterPsn.Text = this.PrdEntity.RegisterPsn;
            this.ckbSaleFlag.Checked = this.PrdEntity.SaleFlag;
            this.txtUnitName.Text = this.PrdEntity.UnitName;
            this.txtVersionCode.Text = this.PrdEntity.VersionCode;
            this.txtFileCode.Text = this.PrdEntity.FileCode;
            if (this.PrdEntity.DateRegister != DateTime.MinValue)
            {
                this.txtDateRegister .Text  = this.PrdEntity.DateRegister.ToShortDateString ();
            }
            this.rchVersionRecord.Text = this.PrdEntity.VersionRecord;
            this.lnkURL.Text = this.PrdEntity.URL;
            this.rchMemo.Text = this.PrdEntity.Memo;
            this.ckbStopFlag.Checked = this.PrdEntity.StopFlag;               
            this.ctrlParmValue.PrdParm(this.PrdID);
            this.ctrlSupplierPrdCode.SupplierPrdCode(this.PrdID);
            this.ctrlBuyer.PrdBuyer(this.PrdID);
            this.ctrlPrdManufProcess.PrdManufProcess(this.PrdID);
            this.ctrlPrdPacking.PrdPackingType(this.PrdID);          
            this.ctrlPrdBOM.PrdBom(this.PrdID);
            this.ctrlPrdSet.PrdSetBom(this.PrdID); 
            this.ctrlPrdDevelopProcess.PrdDevelopProcess(this.PrdID);
            string dir = JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdFile\" + this.PrdID.ToString();
            if (!System.IO.Directory.Exists(dir))
            {
                this.ctrlFile.Clear();
            }
            else
            {
                this.ctrlFile.Browse(dir);
            }
            dir = JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdImg\" + this.PrdID.ToString();
            if (!System.IO.Directory.Exists(dir))
            {
                this.ctrlImg.Clear();
            }
            else
            {
                this.ctrlImg.Browse(dir);
            }
            dir = JERPData.ServerParameter.ERPFileFolder + @"\Product\ManufImg\" + this.PrdID.ToString();
            if (!System.IO.Directory.Exists(dir))
            {
                this.ctrlManufImg.Clear();
            }
            else
            {
                this.ctrlManufImg.Browse(dir);
            }

            this.ctrlManufImg.Browse(dir);
          
        }

        void lnkURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(this.lnkURL .Text);
        }

        //输出打印
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            this.printhelper.ExportToExcel(this.PrdID);
            FrmMsg.Hide();
        }
    }

}