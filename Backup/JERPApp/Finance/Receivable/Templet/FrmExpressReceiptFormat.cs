using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Receivable.Templet
{
    public partial class FrmExpressReceiptFormat : Form
    {
        public FrmExpressReceiptFormat()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accFormat = new JERPData.Product.ExpressReceiptFormat();
            this.fileHelper = new JCommon.ServerFileHelper();
            this.SetPermit();
        }
        JERPData.Product.ExpressReceiptFormat accFormat;
        private JCommon .ServerFileHelper  fileHelper;
        FrmExpressReceiptFormatOper frmOper;
        FrmExpressReceiptFormatCopy frmCopy;
        private DataTable dtblFormat;
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存          
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(733);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(734);
            if (this.enableBrowse)
            {
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.LoadData();

            }
            this.lnkNew .Enabled = this.enableSave;
            this.ColumnBtnCopy.Visible  = this.enableSave;
            this.ColumnBtnEdit.Visible = this.enableSave;
            this.lnkDownload.Enabled = this.enableSave;
            this.lnkUpload.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.lnkDownload.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkDowload_LinkClicked);
                this.lnkUpload.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkUpload_LinkClicked);
            }
        }
      

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadData()
        {
            this.dtblFormat = this.accFormat.GetDataExpressReceiptFormat().Tables[0];
            this.dgrdv.DataSource = this.dtblFormat;
        }
        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmOper == null)
            {
                frmOper = new FrmExpressReceiptFormatOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += this.LoadData;
            }
            frmOper.NewFormat();
            frmOper.ShowDialog();
        }

     
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            int FormatID = (int)this.dtblFormat.DefaultView[irow]["FormatID"];
            if (this.dgrdv.Columns[icol].Name == this.ColumnBtnEdit.Name)
            {
                if (frmOper == null)
                {
                    frmOper = new FrmExpressReceiptFormatOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += this.LoadData;
                }
                frmOper.EditFormat(FormatID);
                frmOper.ShowDialog();
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnBtnCopy.Name)
            {
                if (frmCopy  == null)
                {
                    frmCopy = new FrmExpressReceiptFormatCopy();
                    new FrmStyle(frmCopy).SetPopFrmStyle(this);
                    frmCopy.AffterSave += this.LoadData;
                }
                frmCopy.NewFromCopy(FormatID);
                frmCopy.ShowDialog();
            }
        }

    
        void lnkDowload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMsg.Show("正在下载中，请稍候.....");
            this.fileHelper.DownloadFile(JERPData.ServerParameter.TempletFolder + "ExpressReceiptNote.xlt",
                "代收收据单格式.xlt" );
            FrmMsg.Hide();
          
        }
   
        void lnkUpload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "模版文件(*.xlt)|*.xlt";
            DialogResult rlg = dlg.ShowDialog();
            if (rlg == DialogResult.Cancel) return;
            string ClientFilePath = dlg.FileName;
            FrmMsg.Show("正在上载中，请稍候.....");
            this.fileHelper.UploadFile(JERPData.ServerParameter.TempletFolder + "ExpressReceiptNote.xlt", ClientFilePath);
            FrmMsg.Hide();
           
        }
     
    }
}