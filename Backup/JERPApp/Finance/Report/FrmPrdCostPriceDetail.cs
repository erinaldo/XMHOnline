using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Report
{
    public partial class FrmPrdCostPriceDetail : Form
    {
        public FrmPrdCostPriceDetail()
        {
            InitializeComponent();
            this.accPrd = new JERPData.Product.Product();
            this.PrdEntity = new JERPBiz.Product.ProductEntity();
            this.printhelper = new JERPBiz.Product.BOMPrintHelper();
            this.btnExport.Click += new EventHandler(btnExport_Click);
            this.Shown += new EventHandler(FrmProductDetail_Shown);
         
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
            this.txtPrdCode.Text = this.PrdEntity.PrdCode;
            this.txtPrdName.Text = this.PrdEntity.PrdName;
            this.txtPrdSpec.Text = this.PrdEntity.PrdSpec  ;
            this.txtModel.Text = this.PrdEntity.Model;
            this.txtCostPrice.Text = string.Format ("{0:0.####}",this.PrdEntity.CostPrice);
      
            this.ckbSaleFlag.Checked = this.PrdEntity.SaleFlag;
            this.txtUnitName.Text = this.PrdEntity.UnitName;
            this.txtVersionCode.Text = this.PrdEntity.VersionCode;
            this.txtFileCode.Text = this.PrdEntity.FileCode;
            if (this.PrdEntity.DateRegister != DateTime.MinValue)
            {
                this.txtDateRegister .Text  = this.PrdEntity.DateRegister.ToShortDateString ();
            }
            this.rchVersionRecord.Text = this.PrdEntity.VersionRecord;
               
            this.ctrlParmValue.PrdParm(this.PrdID);
            this.ctrlPrdManufProcess.PrdManufProcess(this.PrdID);
            this.ctrlPrdPacking.PrdPackingType(this.PrdID);
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
        }
          void FrmProductDetail_Shown(object sender, EventArgs e)
        {
            this.ctrlPrdBOM.PrdBom(this.PrdID);
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