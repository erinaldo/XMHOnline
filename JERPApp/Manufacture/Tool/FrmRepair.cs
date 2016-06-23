using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Tool
{
    public partial class FrmRepair : Form
    {
        public FrmRepair()
        {
            InitializeComponent();
            this.dgrdvRepair.AutoGenerateColumns = false;
            this.dgrdvUpgrade.AutoGenerateColumns = false;
            this.accPrds = new JERPData.Tool.Product();
            this.SetPermit();
        }
        private JERPData.Tool.Product  accPrds;
        private DataTable dtblRepair, dtblUpgrade;
        private FrmRepairRecord frmRecord;
        private FrmRepairNew frmRepair;
        private FrmUpgrade frmUpgrade;
        private bool enableBrowse = false;
        private bool enableSave = false;
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(407);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(408);
            if (this.enableBrowse)
            {
                this.ctrlQFind.SeachGridView = this.dgrdvRepair;
                this.ctrlFindUpgrade.SeachGridView = this.dgrdvUpgrade;
                this.LoadDataRepair ();
                this.LoadDataUpgrade();
                this.btnExportRepair.Click += new EventHandler(btnExportRepair_Click);
                this.btnExportUpgrade.Click += new EventHandler(btnExportUpgrade_Click);
                this.dgrdvRepair.ContextMenuStrip = this.cMenu;
                this.dgrdvUpgrade.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            }
            this.ColumnBtnRepair .Visible = this.enableSave;
            this.ColumnbtnUpgrade.Visible = this.enableSave;
            if (this.enableSave)
            {             
                this.dgrdvRepair.CellContentClick += new DataGridViewCellEventHandler(dgrdvRepair_CellContentClick);
                this.dgrdvUpgrade.CellContentClick += new DataGridViewCellEventHandler(dgrdvUpgrade_CellContentClick);
            }
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadDataRepair();
            this.LoadDataUpgrade();
        }

        void dgrdvUpgrade_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int icol = e.ColumnIndex;
            int irow = e.RowIndex;
            if ((icol == -1) || (irow == -1)) return;
            long PrdID = (long)this.dtblUpgrade.DefaultView[irow]["PrdID"];
            if (this.dgrdvUpgrade.Columns[icol].Name == this.ColumnbtnUpgrade.Name)
            {              
                string PrdCode=this.dtblUpgrade .DefaultView [irow]["PrdCode"].ToString ();
                if (this.frmUpgrade == null)
                {
                    this.frmUpgrade = new FrmUpgrade();
                    new FrmStyle(this.frmUpgrade).SetPopFrmStyle(this);
                    this.frmUpgrade.AffterSave += this.LoadDataUpgrade;
                }
                this.frmUpgrade.UpgradeDie(PrdID, PrdCode);
                this.frmUpgrade.ShowDialog();
            }

            if (this.dgrdvUpgrade.Columns[icol].Name == this.ColumnbtnStop.Name)
            {
                 DialogResult rul = MessageBox.Show("将进行治具停止工作！是,确认;否,取消", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (rul == DialogResult.Yes)
                 {
                     string errormsg=string.Empty ;
                     this.accPrds .UpdateProductForStop(ref errormsg, PrdID);
                     MessageBox.Show("成功进行治具终止工作,再工作请到工程定义上变更");
                     this.LoadDataUpgrade();
                 }
            }
        }

        void dgrdvRepair_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int icol = e.ColumnIndex;
            int irow = e.RowIndex;
            if ((icol == -1) || (irow == -1)) return;
            int PrdID = (int)this.dtblRepair .DefaultView[irow]["PrdID"];
            if (this.dgrdvRepair.Columns[icol].Name == this.ColumnBtnRepair.Name)
            {
                if (frmRepair == null)
                {
                    frmRepair = new FrmRepairNew();
                    new FrmStyle(frmRepair).SetPopFrmStyle(this);
                    frmRepair.AffterSave += this.LoadDataRepair;

                }
                frmRepair.NewRepair(PrdID);
                frmRepair.ShowDialog();
            }
            if (this.dgrdvRepair.Columns[icol].Name == this.ColumnRepairedCnt .Name)
            {
                if (frmRecord == null)
                {
                    frmRecord = new FrmRepairRecord();
                    new FrmStyle(frmRecord).SetPopFrmStyle(this);                    
                }
                frmRecord.RepairRecord(PrdID);
                frmRecord.ShowDialog();
            }
        }
     

        private void LoadDataUpgrade()
        {
            this.dtblUpgrade = this.accPrds.GetDataProductForApplyUpgrade ().Tables[0];
            this.dgrdvUpgrade.DataSource = this.dtblUpgrade;
        }
        private void LoadDataRepair()
        {
            this.dtblRepair  = this.accPrds .GetDataProductForApplyRepair().Tables[0];
            this.dgrdvRepair.DataSource = this.dtblRepair ;           
        }

        void btnExportRepair_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter .TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "治具保养清单");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdvRepair, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, false);
            excel.Show();
            FrmMsg.Hide();

        }

        void btnExportUpgrade_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(JERPData.ServerParameter.TempletFolder + @"GeneralShowSheet.xlt");
            excel.SetCellVal("D1", "治具升级清单");
            int rowIndex = 3;
            int colIndex = 1;
            excel.ImportGridData(this.dgrdvUpgrade, ref rowIndex, ref colIndex, true, true);
            excel.SetRangeInnerBorder(3, 1, rowIndex, colIndex);
            excel.SetRangeAutoFit(3, 1, rowIndex, colIndex, true, false);
            excel.Show();
            FrmMsg.Hide();
        }
    }
}