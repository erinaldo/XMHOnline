using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Templet
{
    public partial class FrmInstructFormat : Form
    {
        public FrmInstructFormat()
        {
            InitializeComponent();
            ToolTip tip = new ToolTip();
            tip.SetToolTip(this.btnAdd, "加明细");
            this.dgrdv.AutoGenerateColumns = false;
            this.accFormat = new JERPData.Manufacture.InstructFormat();
            this.accFieldTitle = new JERPData.Manufacture.InstructFieldTitle();
            this.FormatEntity = new JERPBiz.Manufacture.InstructFormatEntity();
            this.fileHelper = new JCommon.ServerFileHelper();
            this.SetPermit();
          
        }

        JERPData.Manufacture.InstructFormat accFormat;
        JERPData.Manufacture.InstructFieldTitle accFieldTitle;
        JERPBiz.Manufacture.InstructFormatEntity FormatEntity;
        private JCommon.ServerFileHelper fileHelper;
        FrmInstructFieldTitle frmTitle;       
        private DataTable dtblFieldTitles;
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存          
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(591);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(592);
            if (this.enableBrowse)
            {
                this.LoadData();
            }
            this.btnAdd.Enabled = this.enableSave;
            this.btnSave.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.lnkDownload.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkDownload_LinkClicked);
                this.lnkUpload .LinkClicked +=new LinkLabelLinkClickedEventHandler(lnkUpload_LinkClicked);
                this.btnAdd.Click += new EventHandler(btnAdd_Click);
                this.btnSave.Click += new EventHandler(btnSave_Click);
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.dgrdv.RowValidated += new DataGridViewCellEventHandler(dgrdv_RowValidated);
            }
        }

        public void LoadData()
        {
           
            this.FormatEntity.LoadData(); 
            this.txtDateInstructCellName.Text = this.FormatEntity.DateInstructCellName ;  
            this.txtMakerPsnCellName.Text = this.FormatEntity.MakerPsnCellName;
            this.txtItemRowIndex.Text = (this.FormatEntity.ItemRowIndex > 0) ? this.FormatEntity.ItemRowIndex.ToString() : string .Empty;
            this.txtItemRowCount.Text = (this.FormatEntity.ItemRowCount > 0) ? this.FormatEntity.ItemRowCount.ToString() : string.Empty;
       
            this.LoadItem();
        }
        private void LoadItem()
        {
            this.dtblFieldTitles = this.accFieldTitle.GetDataInstructFieldTitle().Tables[0];
            this.dgrdv.DataSource = this.dtblFieldTitles;
        } 
        void dgrdv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            DataRow drow = null;
            try
            {
                drow=this.dtblFieldTitles.DefaultView[irow].Row;
            }
            catch 
            { 
                return; 
            }
            if (drow == null) return;
            string errormsg=string.Empty ;
            this.accFieldTitle.UpdateInstructFieldTitle(ref errormsg,
                drow["FieldTitleID"], drow["FieldTitle"], drow["ColumnName"], drow["SerialNoFlag"]);
         
        }

        void lnkDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 

            FrmMsg.Show("正在下载中，请稍候.....");
            this.fileHelper.DownloadFile(JERPData.ServerParameter.TempletFolder + "Instruct.xlt",
                "制令单格式.xlt");
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
            this.fileHelper.UploadFile(JERPData.ServerParameter.TempletFolder + "Instruct.xlt", ClientFilePath);
            FrmMsg.Hide();

        }
    
        void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string errormsg = string.Empty; 
            flag = this.accFormat.SaveInstructFormat (ref errormsg, 
            this.txtDateInstructCellName .Text , 
            this.txtMakerPsnCellName.Text,
            this.txtItemRowIndex.Text,
            this.txtItemRowCount.Text); 
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            else
            {
                MessageBox.Show("成功保存当前系统记录");  
            } 
        }
      
        void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.frmTitle == null)
            {
                this.frmTitle = new FrmInstructFieldTitle();
                new FrmStyle(this.frmTitle).SetPopFrmStyle(this);
                this.frmTitle.AffterSave += new FrmInstructFieldTitle.AffterSaveDelegate(frmTitle_AffterSave);
            }
            this.frmTitle.NewFieldTitle();
            this.frmTitle.ShowDialog();
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnBtnEdit.Name)
            {
                long FieldTitleID = (long)this.dtblFieldTitles.DefaultView[irow]["FieldTitleID"];
                if (this.frmTitle == null)
                {
                    this.frmTitle = new FrmInstructFieldTitle();
                    new FrmStyle(this.frmTitle).SetPopFrmStyle(this);
                    this.frmTitle.AffterSave += new FrmInstructFieldTitle.AffterSaveDelegate(frmTitle_AffterSave);
                }
                this.frmTitle.EditFieldTitle(FieldTitleID);
                this.frmTitle.ShowDialog();
            }
        }

        void frmTitle_AffterSave()
        {
            this.LoadItem();
        } 
    }
}