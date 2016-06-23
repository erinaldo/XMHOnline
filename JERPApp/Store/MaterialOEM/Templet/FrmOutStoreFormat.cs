using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.MaterialOEM.Templet
{
    public partial class FrmOutStoreFormat : Form
    {
        public FrmOutStoreFormat()
        {
            InitializeComponent();
            ToolTip tip = new ToolTip();
            tip.SetToolTip(this.btnAdd, "加明细");
            this.dgrdv.AutoGenerateColumns = false;
            this.fileHelper = new JCommon.ServerFileHelper();
            this.accFieldTitle = new JERPData.Material.OEMOutStoreFieldTitle();
            this.SetPermit();
        }
         
        JERPData.Material.OEMOutStoreFieldTitle accFieldTitle; 
        FrmOutStoreFormatOper frmOper;

        private JCommon.ServerFileHelper fileHelper;
        private DataTable dtblFieldTitles;

        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存          

        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(541);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(542);
            if (this.enableBrowse)
            {
                this.LoadData();
            }
          
            if (this.enableSave)
            {
                this.btnAdd.Click += new EventHandler(btnAdd_Click);
                this.btnSave.Click += new EventHandler(btnSave_Click);  
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick); 
                this.lnkDownload.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkDowload_LinkClicked);
                this.lnkUpload.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkUpload_LinkClicked);
            }
        }

     
        private void LoadData()
        {
            this.dtblFieldTitles = this.accFieldTitle.GetDataOEMOutStoreFieldTitle ().Tables[0];
            this.dgrdv.DataSource = this.dtblFieldTitles;
        }

        void lnkDowload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            FrmMsg.Show("正在下载中，请稍候.....");
            this.fileHelper.DownloadFile(JERPData.ServerParameter.TempletFolder + "MtrOEMOutStoreNote.xlt",
                "领料单格式.xlt");
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
            this.fileHelper.UploadFile(JERPData.ServerParameter.TempletFolder + "MtrOEMOutStoreNote.xlt", ClientFilePath);
            FrmMsg.Hide();

        }
 

    
        void btnSave_Click(object sender, EventArgs e)
        {
          
            string errormsg = string.Empty;
            foreach (DataRow drow in this.dtblFieldTitles.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                if (drow.RowState == DataRowState.Unchanged) continue;
                this.accFieldTitle.UpdateOEMOutStoreFieldTitle(ref errormsg,
               drow["FieldTitleID"], drow["FieldTitle"], drow["ColumnName"], drow["SerialNoFlag"]);
            }
            MessageBox.Show("成功保存当前设置");
        }
     
        void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.frmOper == null)
            {
                this.frmOper = new FrmOutStoreFormatOper();
                new FrmStyle(this.frmOper).SetPopFrmStyle(this);
                this.frmOper.AffterSave += this.LoadData;
            }
            this.frmOper.NewFieldTitle();
            this.frmOper.ShowDialog();
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnBtnEdit.Name)
            {
                long FieldTitleID = (long)this.dtblFieldTitles.DefaultView[irow]["FieldTitleID"];
                if (this.frmOper == null)
                {
                    this.frmOper = new FrmOutStoreFormatOper();
                    new FrmStyle(this.frmOper).SetPopFrmStyle(this);
                    this.frmOper.AffterSave +=this.LoadData ;
                }
                this.frmOper.EditFieldTitle(FieldTitleID);
                this.frmOper.ShowDialog();
            }
        }
 
    }
}