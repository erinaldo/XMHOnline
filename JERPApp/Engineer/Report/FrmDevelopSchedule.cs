using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Report
{
    public partial class FrmDevelopSchedule : Form
    {
        public FrmDevelopSchedule()
        {
            InitializeComponent();
            this.accSchedule = new JERPData.Technology.DevelopSchedules();
            this.accPsn = new JERPData.Hr.Personnel();
            this.accPrds = new JERPData.Product.Product();
            this.SetPermit();
        }

      
        private JERPData.Technology.DevelopSchedules   accSchedule;
        private JERPData.Hr .Personnel   accPsn;
        private JERPData.Product.Product accPrds;
        private DataTable dtblPrds;  //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(318);
            if (this.enableBrowse)
            {

           
                //加载数据
                LoadData();
             
                this.tabMain.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
               
            }



        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private  void LoadData()
        {
           
        
            TabPage page;
            JERPApp.Define.Technology.CtrlDevelopScheduleForPrd  ctrlSchedulePrd;
            JERPApp.Define.Technology.CtrlDevelopScheduleForPsn  ctrlSchedulePsn;
          
            this.tabPrd.TabPages.Clear();
            this.dtblPrds = this.accPrds.GetDataProductForDevelopSchedule().Tables[0];
            foreach (DataRow drow in this.dtblPrds.Rows)
            {
                page = new TabPage();
                page.Tag = drow["PrdID"];
                page.Text = drow["PrdCode"].ToString();
                ctrlSchedulePrd = new JERPApp.Define.Technology.CtrlDevelopScheduleForPrd();
                ctrlSchedulePrd.Schedule((int)drow["PrdID"]);
                page.Controls.Add(ctrlSchedulePrd);               
                ctrlSchedulePrd.Dock = DockStyle.Fill;
                this.tabPrd.TabPages.Add(page);
            }
            this.ctrlTabNavPrd .NavTabControl = this.tabPrd ;
            if (this.tabPsn.TabCount == 0)
            {

                DataTable dtblPsns = this.accPsn .GetDataPersonnelForEngineer().Tables[0];
                foreach (DataRow drow in dtblPsns.Rows)
                {
                    page = new TabPage();
                    page.Tag = drow["PsnID"];
                    page.Text = drow["PsnName"].ToString();

                    ctrlSchedulePsn = new JERPApp.Define.Technology.CtrlDevelopScheduleForPsn();
                    ctrlSchedulePsn.Schedule ((int)drow["PsnID"]);
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
                    ctrlSchedulePsn = (JERPApp.Define.Technology.CtrlDevelopScheduleForPsn)page.Controls[0];
                    ctrlSchedulePsn.Schedule ((int)page .Tag);
                }
            }
            
        }
  
    }
}