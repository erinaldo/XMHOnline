using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store
{
    public partial class FrmStore : Form
    {
        public FrmStore()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accBoms = new JERPData.Product.BOM();
            this.SetPermit();
        }
        private JERPData.Product.BOM   accBoms;
        private DataTable dtblStores; 
        private FrmBOMStore  frmDetail;
        private JCommon.FrmFileBrowse frmFileBrowse;
        private JCommon.FrmImgBrowse frmImgBrowse; 
        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(654);
            if (this.enableBrowse)
            {
                this.ctrlPrdTypeID.AffterSelected += this.LoadData;
                this.ctrlQFind.BeforeFilter += this.LoadData;
                this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
                this.LoadData();
                this.btnExport.Click += new EventHandler(btnExport_Click);
            }
         
        }

        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "终合库存");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
 
        private void LoadData()
        {
            
            this.dtblStores = this.accBoms.GetDataBOMStoreByPrdTypeID  (this.ctrlPrdTypeID .PrdTypeID ).Tables[0];
            this.dtblStores.Columns.Add("Mark", typeof(Image));
            foreach (DataRow drow in this.dtblStores.Rows)
            {
                if ((bool)drow["ParentFlag"])
                {
                    drow["Mark"] = global::JERPApp.Properties.Resources.plus;
                }
                else
                {
                    drow["Mark"] = global::JERPApp.Properties.Resources.subtract;
                }
            }
            this.dgrdv.DataSource = this.dtblStores;
        }
       
       
        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            int PrdID = (int)this.dtblStores.DefaultView[irow]["PrdID"];
            if ((this.dgrdv.Columns[icol].Name == this.ColumnMark.Name) )
            {
               
                if (this.frmDetail == null)
                {
                    this.frmDetail = new FrmBOMStore();
                    new FrmStyle(frmDetail).SetPopFrmStyle(this);
                }
                this.frmDetail.BOMStore  (PrdID);
                this.frmDetail.ShowDialog();
            }  
            if (this.dgrdv.Columns[icol].Name == this.ColumnFileCount .Name)
            {
                if (frmFileBrowse == null)
                {
                    frmFileBrowse = new JCommon.FrmFileBrowse();
                    frmFileBrowse.ReadOnly =true;
                    new FrmStyle(frmFileBrowse).SetPopFrmStyle(this);

                }
                frmFileBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdFile\" + PrdID.ToString());
                frmFileBrowse.ShowDialog();
            
            }
            if (this.dgrdv.Columns[icol].Name == this.ColumnImgCount .Name)
            {
                if (frmImgBrowse == null)
                {
                    frmImgBrowse = new JCommon.FrmImgBrowse();
                    frmImgBrowse.ReadOnly =true;
                    new FrmStyle(frmImgBrowse).SetPopFrmStyle(this);
                }
                frmImgBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdImg\" + PrdID.ToString());
                frmImgBrowse.ShowDialog();
              
            }
        }
       


    }
}