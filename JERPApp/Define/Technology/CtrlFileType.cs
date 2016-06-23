using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define.Technology
{
    public partial class CtrlFileType : UserControl
    {
       
        public CtrlFileType()
        {
            InitializeComponent();
            this.accFileType = new JERPData.Technology.FileType();
            this.RefreshData();
            new ToolTip().SetToolTip(this.cmbItem, "ÓÒ½¡ÐÂÔö");
            this.cmbItem.MouseDown += new MouseEventHandler(cmbItem_MouseDown);
            this.cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
        }
        private JERPData.Technology.FileType accFileType;
        private DataTable dtblFileTypes;
        FrmFileType frmDefine = null;
        void cmbItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (frmDefine == null)
                {
                    frmDefine = new FrmFileType();
                    new FrmStyle(frmDefine).SetPopFrmStyle(this);
                    frmDefine.AffterSave += new FrmFileType.AffterSaveDelegate(frmDefine_AffterSave);
                }
                frmDefine.ShowDialog();
            }
        }

        void frmDefine_AffterSave()
        {
            this.RefreshData();
        }
        public  void RefreshData()
        {
            this.dtblFileTypes = this.accFileType.GetDataFileType().Tables[0];
            JCommon.Others.SetCtrlBindSrc(this.cmbItem, this.dtblFileTypes, "FileTypeID", "FileTypeName");
        }
        public int FileTypeID
        {
            get
            {
                if (this.cmbItem.SelectedIndex == -1) return -1;              
                return (int)this.cmbItem.SelectedValue;
               
            }
            set
            {
                this.cmbItem.SelectedValue = value;
            }
        }
        public string  FileTypeName
        {
            get
            {
                DataRow[] rows = this.dtblFileTypes.Select("FileTypeID=" + this.FileTypeID.ToString());
                if (rows.Length == 0) return string.Empty;
                return rows[0]["FileTypeName"].ToString();
            }

        }
      
       
        public delegate void AffterSelectedDelegate();
        private AffterSelectedDelegate affterSelected;
        public event AffterSelectedDelegate AffterSelected
        {
            add
            {
                affterSelected += value;
            }
            remove
            {
                affterSelected -= value;
            }
        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.affterSelected != null) this.affterSelected();
        }
      
    }
}
