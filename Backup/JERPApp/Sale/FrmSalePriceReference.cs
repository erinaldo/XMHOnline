using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace JERPApp.Sale
{
    public partial class FrmSalePriceReference : Form
    {
        public FrmSalePriceReference()
        {
            InitializeComponent();
            this.accPrds = new JERPData.Product.Product();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.SetPermit();
        }
        private JERPData.Product.Product accPrds;
        private DataTable dtblPrds;
        private JCommon.FrmFileBrowse frmFileBrowse;
        private JCommon.FrmImgBrowse frmImgBrowse;
    
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(668);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(669);
            if (this.enableBrowse)
            {
                LoadData();
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            }
            this.btnSave.Enabled = this.enableSave;
            if (this.enableSave)
            {
                foreach (DataGridViewColumn col in this.dgrdv.Columns)
                {
                    col.ReadOnly = true;
                }
                this.ColumnSalePrice.ReadOnly = false;               
                this.btnSave.Click += new EventHandler(btnSave_Click);
            }
        }

      
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if((irow==-1)||(icol==-1))return;
            DataRow drow = this.dtblPrds.DefaultView[irow].Row;          
            if (this.dgrdv.Columns[icol].Name == this.ColumnSalePriceFileCount .Name)
            {
                if (frmFileBrowse == null)
                {
                    frmFileBrowse = new JCommon.FrmFileBrowse();
                    frmFileBrowse.ReadOnly = !this.enableSave ;
                    new FrmStyle(frmFileBrowse).SetPopFrmStyle(this);

                }
                frmFileBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdSaleFile\" + drow["PrdID"].ToString());
                frmFileBrowse.ShowDialog();
                this.dgrdv[icol, irow].Value = frmFileBrowse.Count;
                string errormsg = string.Empty;
                this.accPrds.UpdateProductForSalePriceFileCount (
                    ref errormsg,
                    drow["PrdID"],
                    frmFileBrowse.Count);
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnImgCount .Name)
            {
                if (frmImgBrowse == null)
                {
                    frmImgBrowse = new JCommon.FrmImgBrowse();
                    frmImgBrowse.ReadOnly = true;
                    new FrmStyle(frmImgBrowse).SetPopFrmStyle(this);
                }
                frmImgBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdImg\" + drow["PrdID"].ToString());
                frmImgBrowse.ShowDialog();
            
            }
        }

        
        private void LoadData()
        {
            this.dtblPrds  = this.accPrds.GetDataProductForFinishedPrd().Tables[0];
            this.dgrdv.DataSource = this.dtblPrds ;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            FrmMsg.Show("正在保存中，请稍候....");
            foreach (DataRow drow in this.dtblPrds.Rows)
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                this.accPrds.UpdateProductForSalePrice(ref errormsg, drow["PrdID"],
                    drow["SalePrice"]);
            }
            FrmMsg.Hide();
        }

     
   
       
    }
}