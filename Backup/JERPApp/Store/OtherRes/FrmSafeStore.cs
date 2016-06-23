using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.OtherRes
{
    public partial class FrmSafeStore : Form
    {
        public FrmSafeStore()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false; 
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accSafeStore = new JERPData.OtherRes.SafeStore();
            this.SetPermit();
        }

        private JERPData.OtherRes.SafeStore accSafeStore;
        private DataTable dtblPrds;
        private int Year = 1;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {

            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(487);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(488);
            if (this.enableBrowse)
            {
                DateTime now = DateTime.Now;
                this.Year = now.Year;
                if (now.Month == 1)
                {
                    this.Year = this.Year - 1;
                }
               LoadData();
               this.btnExplore.Click += new EventHandler(btnExplore_Click);
            }
            this.btnSave.Enabled  = this.enableSave;
            if (this.enableSave)
            {
                this.btnSave.Click += new EventHandler(btnSave_Click);               

            }
        }

        private void LoadData()
        {
            this.dtblPrds  = this.accSafeStore .GetDataSafeStoreForSetting (this.Year).Tables[0];
            this.dgrdv.DataSource = this.dtblPrds;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            foreach (DataRow drow in this.dtblPrds.Rows)
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                this.accSafeStore .SaveSafeStore (ref errormsg,
                               drow["PrdID"],
                               drow["SafeStoreQty"]);
            }
            this.dtblPrds.AcceptChanges();
            MessageBox.Show("成功保存当前安全库存");
        }

      
        void btnExplore_Click(object sender, EventArgs e)
        {
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "耗材安全库存");
            excel.SetCellVal("A2", "年份:" +this.Year .ToString ());
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.Show();
        }   

     
    }
}