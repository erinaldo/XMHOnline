using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.OtherRes
{
    public partial class FrmStorePlace : Form
    {
        public FrmStorePlace()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accBranchStore = new JERPData.OtherRes.BranchStore();
            this.accStorePlace = new JERPData.OtherRes.StorePlace();
            this.SetPermit();
        }
        private JERPData.OtherRes.StorePlace accStorePlace;
        private JERPData.OtherRes.BranchStore accBranchStore;
        private DataTable dtblBranchStore, dtblStorePlace;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(112);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(113);
            if (this.enableBrowse)
            {
                this.CreateColumns();
                //加载数据
                this.ctrlPrdTypeID.AffterSelected += this.LoadData;
                LoadData();
               
            }
            this.btnSave.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.btnSave.Click += new EventHandler(btnSave_Click);
                this.btnExport .Click +=new EventHandler(btnExport_Click);
            }

        }
        private void CreateColumns()
        {
            this.dtblBranchStore = this.accBranchStore.GetDataBranchStore().Tables[0];
            DataGridViewTextBoxColumn txtcol;
            foreach (DataRow drow in this.dtblBranchStore.Rows)
            {
                txtcol = new DataGridViewTextBoxColumn();
                txtcol.Width = 80;
                txtcol.DataPropertyName = drow["BranchStoreID"].ToString();
                txtcol.HeaderText = drow["BranchStoreName"].ToString();
                this.dgrdv.Columns.Add(txtcol);
            }
            this.ctrlQFind.SeachGridView = this.dgrdv;
        }
        private void LoadData()
        {
            this.dtblStorePlace = this.accStorePlace.GetDataStorePlaceForSetting(this.ctrlPrdTypeID.PrdTypeID).Tables[0];
            this.dgrdv.DataSource = this.dtblStorePlace;
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;          
            foreach (DataRow drow in this.dtblStorePlace.Rows)
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                int PrdID=(int)drow["PrdID"];
                foreach (DataRow drowBranchStore in this.dtblBranchStore.Rows)
                {
                    int BranchStoreID=(int) drowBranchStore["BranchStoreID"];
                    string columnname =BranchStoreID.ToString();
                    object objPlace = drow[columnname];
                    if (objPlace == DBNull.Value)
                    {
                        this.accStorePlace.DeleteStorePlace(ref errormsg, BranchStoreID, PrdID);
                    }
                    else
                    {
                        this.accStorePlace.SaveStorePlace(ref errormsg, BranchStoreID, PrdID, objPlace);
                    }
                }
              
            }
            this.dtblStorePlace.AcceptChanges();
            MessageBox .Show ("成功保存当前设置");
        }
        void btnExport_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "耗材存放位置一览");
            excel.SetCellVal("A2", "类别:" + this.ctrlPrdTypeID.PrdTypeName);
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdv, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            FrmMsg.Hide();
            excel.Show();
        }
    }
}