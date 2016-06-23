using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer
{
    public partial class FrmDevelopSchedule : Form
    {
        public FrmDevelopSchedule()
        {
            InitializeComponent();
            this.dgrdvNonSchedule.AutoGenerateColumns = false;
            this.ctrlQNonSchedule.SeachGridView = this.dgrdvNonSchedule;
            this.accSchedule = new JERPData.Technology.DevelopSchedules();
            this.accPsn = new JERPData.Hr.Personnel();
            this.accPrds = new JERPData.Product.Product();
            this.SetPermit();
        }

      
        private JERPData.Technology.DevelopSchedules   accSchedule;
        private JERPData.Hr .Personnel   accPsn;
        private JERPData.Product.Product accPrds;
        private JCommon.FrmImgBrowse frmImgBrowse;
        private DataTable dtblNonSchedules;  //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(314);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(315);
            if (this.enableBrowse)
            {
                //加载数据
                LoadData(); 
                this.tabMain.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.dgrdvNonSchedule.CellContentClick += new DataGridViewCellEventHandler(dgrdvNonSchedule_CellContentClick);
            }

            this.btnPrdSave.Enabled = this.enableSave;
            this.btnPsnSave.Enabled = this.enableSave;
            if (this.enableSave)
            {
               this.btnPsnSave .Click +=new EventHandler(btnPsnSave_Click);
               this.btnPrdSave.Click += new EventHandler(btnPrdSave_Click);
            }


        }

        void dgrdvNonSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            int PrdID = (int)this.dtblNonSchedules .DefaultView[irow]["PrdID"];
            if (this.dgrdvNonSchedule.Columns[icol].Name == this.ColumnImgCount.Name)
            {
                if (frmImgBrowse == null)
                {
                    frmImgBrowse = new JCommon.FrmImgBrowse();
                    frmImgBrowse.ReadOnly = true;
                    new FrmStyle(frmImgBrowse).SetPopFrmStyle(this);
                }
                frmImgBrowse.Browse(JERPData.ServerParameter.ERPFileFolder + @"\Product\PrdImg\" + PrdID.ToString());
                frmImgBrowse.ShowDialog();

            }
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void LoadNonSchedule()
        {
            this.dtblNonSchedules = this.accPrds.GetDataProductNonDevelopSchedule().Tables[0];
            this.dgrdvNonSchedule.DataSource = this.dtblNonSchedules;
            this.pageNonSchedule.Text = "未作排程[" + this.dtblNonSchedules.Rows.Count.ToString() + "]";
        }
        private void LoadPrdSchedule()
        {

            TabPage page;
            JERPApp.Define.Technology.CtrlDevelopScheduleOperForPrd ctrlSchedulePrd;
            this.tabPrd.TabPages.Clear();
            DataTable dtblPrds = this.accPrds.GetDataProductForDevelopSchedule().Tables[0];
            foreach (DataRow drow in dtblPrds.Rows)
            {
                page = new TabPage();
                page.Tag = drow["PrdID"];
                page.Text = drow["PrdCode"].ToString();
                ctrlSchedulePrd = new JERPApp.Define.Technology.CtrlDevelopScheduleOperForPrd();
                ctrlSchedulePrd.ScheduleOper((int)drow["PrdID"]);
                ctrlSchedulePrd.Enabled = this.enableSave;
                page.Controls.Add(ctrlSchedulePrd);
                ctrlSchedulePrd.Dock = DockStyle.Fill;
                this.tabPrd.TabPages.Add(page);
            }
            this.ctrlTabNavPrd.NavTabControl = this.tabPrd;
            this.pagePrdSchedule.Text = "产品排程[" + tabPrd.TabCount .ToString () + "]";
        }
        private void LoadPsnSchedule()
        {
            TabPage page;
            JERPApp.Define.Technology.CtrlDevelopScheduleOperForPsn ctrlSchedulePsn;
            if (this.tabPsn.TabCount == 0)
            {

                DataTable dtblPsns = this.accPsn.GetDataPersonnelForEngineer().Tables[0];
                foreach (DataRow drow in dtblPsns.Rows)
                {
                    page = new TabPage();
                    page.Tag = drow["PsnID"];
                    page.Text = drow["PsnName"].ToString();
                    ctrlSchedulePsn = new JERPApp.Define.Technology.CtrlDevelopScheduleOperForPsn();
                    ctrlSchedulePsn.ScheduleOper((int)drow["PsnID"]);
                    ctrlSchedulePsn.Enabled = this.enableSave;
                    page.Controls.Add(ctrlSchedulePsn);
                    ctrlSchedulePsn.Dock = DockStyle.Fill;
                    this.tabPsn.TabPages.Add(page);
                }
                this.ctrlTabNavPsn.NavTabControl = this.tabPsn;
            }
            else
            {
                for (int j = 0; j < this.tabPsn.TabCount; j++)
                {
                    page = this.tabPsn.TabPages[j];
                    ctrlSchedulePsn = (JERPApp.Define.Technology.CtrlDevelopScheduleOperForPsn)page.Controls[0];
                    ctrlSchedulePsn.ScheduleOper((int)page.Tag);
                }
            }
            this.pagePsnSchedule.Text = "人员排程[" + this.tabPsn.TabCount.ToString() + "]";
        }
        private  void LoadData()
        {
            this.LoadNonSchedule();
            this.LoadPrdSchedule();
            this.LoadPsnSchedule();
           
            
        }
        void btnPsnSave_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在进行保存中....");
            JERPApp.Define .Technology.CtrlDevelopScheduleOperForPsn  ctrlSchedule;
            foreach (TabPage page in this.tabPsn.TabPages)
            {
                ctrlSchedule = (JERPApp.Define.Technology.CtrlDevelopScheduleOperForPsn)page.Controls[0];
                ctrlSchedule.Save();
            }
            FrmMsg.Hide();
            MessageBox.Show("成功进行排期保存..");
            this.LoadData();
        }

        void btnPrdSave_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在进行保存中....");
            JERPApp.Define.Technology.CtrlDevelopScheduleOperForPrd ctrlSchedule;
            foreach (TabPage page in this.tabPrd .TabPages)
            {
                ctrlSchedule = (JERPApp.Define.Technology.CtrlDevelopScheduleOperForPrd)page.Controls[0];
                ctrlSchedule.Save();
            }
            FrmMsg.Hide();
            MessageBox.Show("成功进行排期保存..");
            this.LoadData();
        }
    }
}