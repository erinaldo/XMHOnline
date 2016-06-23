using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmWIP : Form
    {
        public FrmWIP()
        {
            InitializeComponent();
            this.dgrdvSchedule.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdvSchedule;
            this.dgrdvWIP.AutoGenerateColumns = false;
            this.accWIP = new JERPData.Manufacture.WIP ();
            this.accManufSchedules = new JERPData.Manufacture.ManufSchedules();
            this.SetPermit();
        }
        private JERPData.Manufacture.WIP  accWIP;
        private JERPData.Manufacture.ManufSchedules accManufSchedules;
        private FrmWIPOper frmOper;
        private DataTable dtblWIP,dtblSchedule;
        private string whereclause = string.Empty;
        private string iniwhereclause = "and (OutSrcCompanyID is  null)";
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(243);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(244);
            if (this.enableBrowse)
            {
                this.whereclause = this.iniwhereclause;
                this.LoadData();
                this.dgrdvWIP.ContextMenuStrip = this.cMenu;
                this.dgrdvSchedule.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.pbar.OnPageIndexChanged += new EventHandler(pbar_OnPageIndexChanged);
                this.ctrlNoteSearch.AffterSearch += new JCommon.ctrlNoteSearch.AffterSearchDelegate(ctrlNoteSearch_AffterSearch);
                foreach (DataGridViewColumn col in this.dgrdvWIP.Columns)
                {
                    col.ReadOnly = true;
                }
            }           
            this.ColumnbtnAlter.Visible  = this.enableSave;
            this.ColumnbtnCreate.Visible = this.enableSave;
            if (this.enableSave)
            {
                this.dgrdvSchedule.CellContentClick += new DataGridViewCellEventHandler(dgrdvSchedule_CellContentClick);
                this.dgrdvWIP.CellContentClick += new DataGridViewCellEventHandler(dgrdvWIP_CellContentClick);
            }
        }

      

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvSchedule)
            {
                this.LoadSchedule();
            }
            if(this.cMenu .SourceControl ==this.dgrdvWIP )
            {
                this.whereclause = this.iniwhereclause;
                this.LoadAlter();

            }
        }

        
        void ctrlNoteSearch_AffterSearch(string whereclause)
        {
            this.whereclause =this.iniwhereclause +whereclause;
            this.LoadAlter();
        }
      
        private void LoadAlter()
        {
            int cnt = 0;
            this.dtblWIP = this.accWIP.GetDataWIPDescPagesFreeSearch(1, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdvWIP.DataSource = this.dtblWIP;
            this.pbar.Init(1, cnt);
        }
        private void LoadSchedule()
        {
            this.dtblSchedule = this.accManufSchedules.GetDataManufSchedulesNonFinished().Tables[0];
            this.dgrdvSchedule.DataSource = this.dtblSchedule;
            this.pageSchedule.Text = "未登记[" + this.dtblSchedule.Rows.Count.ToString() + "]";
        }
        private void LoadData()
        {
            this.LoadSchedule();        
            this.LoadAlter();
        }

        void pbar_OnPageIndexChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            this.dtblWIP = this.accWIP.GetDataWIPDescPagesFreeSearch (this.pbar .PageIndex, this.pbar.PageSize, ref cnt, this.whereclause).Tables[0];
            this.dgrdvWIP.DataSource = this.dtblWIP;
        }

        void dgrdvWIP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvWIP.Columns[icol].Name == this.ColumnbtnAlter.Name)
            {
                long WIPID = (long)this.dtblWIP.DefaultView[irow]["WIPID"];
                if (frmOper == null)
                {
                    frmOper = new FrmWIPOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += this.LoadData;
                }
                frmOper.Edit(WIPID);
                frmOper.ShowDialog();
            }
        }

        void dgrdvSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvSchedule.Columns[icol].Name == this.ColumnbtnCreate.Name)
            {
                long ManufScheduleID = (long)this.dtblSchedule.DefaultView[irow]["ManufScheduleID"];
                if (frmOper == null)
                {
                    frmOper = new FrmWIPOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += this.LoadData;
                }
                frmOper.New(ManufScheduleID);
                frmOper.ShowDialog();
            }
        }
 

    }
}