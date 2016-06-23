using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Common.Report
{
    public partial class FrmFile : Form
    {
        public FrmFile()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accUser = new JERPData.Frame.Users();
            this.ctrlFileBrowse.ReadOnly = true;
            this.SetPermit();
        }
        private JERPData.Frame.Users accUser;
        private DataTable dtblUser;
        //È¨ÏÞÂë 
        private bool enableBrowse = false;//±£´æ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(345);
            if (this.enableBrowse)
            {
              
                this.LoadData();
                this.dgrdv.RowEnter +=new DataGridViewCellEventHandler(dgrdv_RowEnter);
            }
          

        }

        void dgrdv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnPsnName.Name)
            {               
                this.LoadFile(irow); 
            }
        }
        private void LoadData()
        {
            this.dtblUser = this.accUser.GetDataUsers().Tables[0];
            this.dgrdv.DataSource = this.dtblUser;
        }
        private void LoadFile(int irow)
        { 
            short UserID = (short)this.dtblUser.DefaultView[irow]["UserID"];
            string dir = JERPData.ServerParameter.ERPFileFolder + @"\UserFile\" + UserID.ToString();
            if (System.IO.Directory.Exists(dir))
            {
                this.ctrlFileBrowse.Browse(dir);
            }
            else
            {
                this.ctrlFileBrowse.Clear();
            }

        }
    }
}