using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace JERPApp.Store.Material.Templet
{
    public partial class FrmOutSrcSupplyFormat : Form
    {
        public FrmOutSrcSupplyFormat()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accFormat = new JERPData.Material.OutSrcSupplyFormat();
            this.fileHelper = new JCommon.ServerFileHelper();
            this.SetPermit();
        }
        JERPData.Material.OutSrcSupplyFormat accFormat;
        FrmOutSrcSupplyFormatOper frmOper;
        FrmOutSrcSupplyFormatCopy frmCopy;
        private JCommon .ServerFileHelper  fileHelper;
        private DataTable dtblFormat;
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存          
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(645);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(646);
            if (this.enableBrowse)
            {
                this.LoadData();
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            }
            this.lnkNew.Enabled = enableSave;
            this.ColumnBtnEdit.Visible = enableSave;
            this.ColumnBtnCopy.Visible = enableSave;
            this.lnkDownload.Enabled = enableSave;
            this.lnkUpload.Enabled = enableSave;
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
            this.dtblFormat = this.accFormat.GetDataOutSrcSupplyFormat().Tables[0];
            this.dgrdv.DataSource = this.dtblFormat;
        }
        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmOper == null)
            {
                frmOper = new FrmOutSrcSupplyFormatOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += new FrmOutSrcSupplyFormatOper.AffterSaveDelegate(frmOper_AffterSave);
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
                    frmOper = new FrmOutSrcSupplyFormatOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += new FrmOutSrcSupplyFormatOper.AffterSaveDelegate(frmOper_AffterSave);
                }
                frmOper.EditFormat(FormatID);
                frmOper.ShowDialog();
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnBtnCopy.Name)
            {
                if (frmCopy == null)
                {
                    frmCopy = new FrmOutSrcSupplyFormatCopy();
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
            this.fileHelper.DownloadFile(JERPData.ServerParameter.TempletFolder + "MtrOutSrcSupplyNote.xlt",
                "委外发料单格式.xlt");
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
            this.fileHelper.UploadFile(JERPData.ServerParameter.TempletFolder + "MtrOutSrcSupplyNote.xlt", ClientFilePath);
           FrmMsg.Hide();

        }
    }
}