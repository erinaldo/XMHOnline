using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Receivable.Templet
{
    public partial class FrmRepairInvoiceFormat : Form
    {
        public FrmRepairInvoiceFormat()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accFormat = new JERPData.Product.RepairInvoiceFormat();
            this.fileHelper = new JCommon.ServerFileHelper();
            this.LoadData();
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.dgrdv.ContextMenuStrip = this.cMenu;
            this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.lnkDownload.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkDowload_LinkClicked);
            this.lnkUpload.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkUpload_LinkClicked);
            this.FormClosed += new FormClosedEventHandler(FrmRepairReconciliationFormat_FormClosed);
        }
        JERPData.Product.RepairInvoiceFormat accFormat;

        private JCommon .ServerFileHelper  fileHelper;
        FrmRepairInvoiceFormatOper frmOper;
        FrmRepairInvoiceFormatCopy frmCopy;
        private DataTable dtblFormat; 

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
         

            this.dtblFormat = this.accFormat.GetDataRepairInvoiceFormat().Tables[0];
            this.dgrdv.DataSource = this.dtblFormat;
        }
        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmOper == null)
            {
                frmOper = new FrmRepairInvoiceFormatOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += new FrmRepairInvoiceFormatOper.AffterSaveDelegate(frmOper_AffterSave);
            }
            frmOper.NewFormat();
            frmOper.ShowDialog();
        }

        void frmOper_AffterSave()
        {
            this.LoadData();
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
                    frmOper = new FrmRepairInvoiceFormatOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += new FrmRepairInvoiceFormatOper.AffterSaveDelegate(frmOper_AffterSave);
                }
                frmOper.EditFormat(FormatID);
                frmOper.ShowDialog();
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnBtnCopy.Name)
            {
                if (frmCopy  == null)
                {
                    frmCopy = new FrmRepairInvoiceFormatCopy();
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
            this.fileHelper.DownloadFile(JERPData.ServerParameter.TempletFolder + "RepairInvoice.xlt",
                "维修发票单格式.xlt" );
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
            this.fileHelper.UploadFile(JERPData.ServerParameter.TempletFolder + "RepairInvoice.xlt", ClientFilePath);
            FrmMsg.Hide();
           
        }
        void FrmRepairReconciliationFormat_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }
    }
}