using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace JERPApp.Manufacture.Report
{
    public partial class FrmToolStatus : Form
    {
        public FrmToolStatus()
        {
            InitializeComponent();
         
            this.dgrdv.AutoGenerateColumns = false;
            this.accPrds = new JERPData.Tool .Product(); 
            this.frmFileBrowse = new JCommon.FrmFileBrowse();
            new FrmStyle(this.frmFileBrowse).SetPopFrmStyle(this);
            this.frmImgBrowse = new JCommon.FrmImgBrowse();
            new FrmStyle(this.frmImgBrowse).SetPopFrmStyle(this);
            this.frmImgBrowse.ReadOnly = true;
            this.frmFileBrowse.ReadOnly = true;
            this.SetPermit();
        }
        private JERPData.Tool.Product  accPrds; 
        private JCommon.FrmFileBrowse frmFileBrowse;
        private JCommon.FrmImgBrowse frmImgBrowse;
        private DataTable dtblPrds;      
        private bool enableBrowse = false;
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(411);
            if (this.enableBrowse)
            {
                this.ctrlQFind .SeachGridView = this.dgrdv ;               
                this.LoadData();
                this.btnExport.Click += new EventHandler(btnExport_Click);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            }
       
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            int PrdID = (int)this.dtblPrds.DefaultView[irow]["PrdID"];          
            if (this.dgrdv.Columns[icol].Name == this.ColumnlnkFile .Name)
            {
                string filedir = JERPData.ServerParameter.ERPFileFolder + @"\Tool\File\" + PrdID.ToString();
             
                this.frmFileBrowse.Browse(filedir);
                this.frmFileBrowse.ShowDialog();
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnlnkImg.Name)
            {
                string imgdir = JERPData.ServerParameter.ERPFileFolder + @"\Tool\Image\" + PrdID.ToString();
                this.frmImgBrowse .Browse(imgdir);
                this.frmImgBrowse.ShowDialog();
            }
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "模具状态一览表");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv , ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, false);
            excel.Show();
            FrmMsg.Hide();
        }     
        private void LoadData()
        {
            this.dtblPrds  = this.accPrds.GetDataProduct ().Tables[0];      
            this.dgrdv.DataSource = this.dtblPrds;
        }      
     
    }
}