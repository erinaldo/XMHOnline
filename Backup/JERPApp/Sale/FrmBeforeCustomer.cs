using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
namespace JERPApp.Sale
{
    public partial class FrmBeforeCustomer : Form
    {
        public FrmBeforeCustomer()
        {
            InitializeComponent();
            this.dgrdvMy.AutoGenerateColumns = false;
            this.dgrdvPublic.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdvMy;
            this.accCustomer = new JERPData.General.PotentialCustomer();
            this.accParms = new JERPData.General.Parms();
            this.SetPermit();
            this.Shown += new EventHandler(FrmBeforeCustomer_Shown);
        }

        private JERPData.General.PotentialCustomer accCustomer;
        private JERPData.General.Parms accParms;
        private DataTable dtblMyCustomer,dtblPublicCustomer;
        private delegate void FlushClient();//代理
        private FrmBeforeCustomerOper frmOper;
        private FrmCustomerSwitch frmSwitch;
        private Thread TreadMessage;
        private int iDelayDays;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(633);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(634);
            if (this.enableBrowse)
            {
                string istr=string.Empty ;
                this.accParms.GetParmParmsParmValue(3,
                    ref istr);
                this.iDelayDays = 30;
                if (istr !="-1" )
                {
                    iDelayDays = int.Parse(istr);
                }
             
                //加载数据
                this.LoadMyData();
                this.LoadPublicData();
                //设置信息
                this.dgrdvMy.ContextMenuStrip = this.cMenu;
                this.dgrdvPublic.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
            }
            this.lnkNew.Enabled = this.enableSave;
            this.ColumnbtnEdit.Visible = this.enableSave;
            this.ColumnbtnShare .Visible = this.enableSave;
            this.ColumnbtnCatch.Visible  = this.enableSave;           
            if (this.enableSave)
            {
                this.dgrdvPublic.CellContentClick += new DataGridViewCellEventHandler(dgrdvPublic_CellContentClick);
                this.lnkNew.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNew_LinkClicked);
                this.dgrdvMy.CellContentClick += new DataGridViewCellEventHandler(dgrdvMy_CellContentClick);
               
            }
        }

        void FrmBeforeCustomer_Shown(object sender, EventArgs e)
        {
            this.TreadMessage = new Thread(new ThreadStart(this.SetMessageInfo));
            this.TreadMessage.IsBackground = true;

            this.TreadMessage.Start();
        }
        void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadPublicData();
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            if (this.cMenu.SourceControl == this.dgrdvMy)
            {
                this.LoadMyData();
            }
            if (this.cMenu.SourceControl == this.dgrdvPublic)
            {
                this.LoadPublicData();
            }
        }

        void dgrdvMy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            int CompanyID = (int)this.dtblMyCustomer.DefaultView[irow]["CompanyID"];
            if (this.dgrdvMy.Columns[icol].Name == this.ColumnbtnEdit.Name)
            {             
                if (frmOper == null)
                {
                    frmOper = new FrmBeforeCustomerOper();
                    new FrmStyle(frmOper).SetPopFrmStyle(this);
                    frmOper.AffterSave += this.LoadMyData;
                }
                frmOper.Edit(CompanyID);
                frmOper.ShowDialog();
            }
           
            if (this.dgrdvMy.Columns[icol].Name == this.ColumnbtnShare.Name)
            {
                DialogResult rul = MessageBox.Show("即将当前客户放入公共池,共享资源共同成长！", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rul == DialogResult.Yes)
                {
                    string errormsg = string.Empty;
                    this.accCustomer.UpdatePotentialCustomerForSalePsn(ref errormsg,
                        CompanyID,
                        -1);
                    this.LoadMyData();
                    this.LoadPublicData();
                }
            }
            if (this.dgrdvMy.Columns[icol].Name == this.ColumnbtnSuccess .Name)
            {
                if (frmSwitch == null)
                {
                    frmSwitch = new FrmCustomerSwitch();
                    new FrmStyle(frmSwitch).SetPopFrmStyle(this);
                    frmSwitch.AffterSave += this.LoadMyData;
                }
                frmSwitch.Switch(CompanyID);
                frmSwitch.ShowDialog();
            }
        }

        void lnkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmOper == null)
            {
                frmOper = new FrmBeforeCustomerOper();
                new FrmStyle(frmOper).SetPopFrmStyle(this);
                frmOper.AffterSave += this.LoadMyData;
            }
            frmOper.New();
            frmOper.ShowDialog();
        }
       
        private void LoadMyData()
        {
            this.dtblMyCustomer = this.accCustomer.GetDataPotentialCustomerBySalePsnID(JERPBiz.Frame.UserBiz.PsnID).Tables[0];
            foreach (DataRow drow in this.dtblMyCustomer.Rows)
            {
                drow.RowError = string.Empty;
                if (drow["DateBegin"] == DBNull.Value) continue;
                if (((DateTime)drow["DateBegin"]).Date.AddDays(Convert.ToDouble(this.iDelayDays)) < DateTime.Now.Date)
                {
                    drow.RowError = "追加超时";
                }
            }
            this.dgrdvMy.DataSource = this.dtblMyCustomer;
        }
        private void LoadPublicData()
        {
            this.dtblPublicCustomer = this.accCustomer.GetDataPotentialCustomerForPublic().Tables[0];
            this.dgrdvPublic.DataSource = this.dtblPublicCustomer;
          
        }

        //内部交流信息
        private void SetMessageInfo()
        {
            while (true)
            {
                ThreadFunction();
                Thread.Sleep(6000);
            }
        }
        private void ThreadFunction()
        {
            if (this.dgrdvPublic .InvokeRequired)//等待异步
            {
                FlushClient fc = new FlushClient(ThreadFunction);
                this.Invoke(fc);//通过代理调用刷新方法
            }
            else
            {
                this.LoadPublicData();
            }
        }
        private bool GetAllowAlterSalePsnFlag(int CompanyID)
        {
            int salepsnid=-1;
            this.accCustomer.GetParmPotentialCustomerSalePsnID(CompanyID, ref salepsnid);
            return  (salepsnid == -1) ;
        }
        void dgrdvPublic_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvPublic.Columns[icol].Name == this.ColumnbtnCatch.Name)
            {
                int CompanyID =(int) this.dtblPublicCustomer.DefaultView[irow]["CompanyID"];
                if (this.GetAllowAlterSalePsnFlag(CompanyID))
                {
                    string errormsg = string.Empty;
                    this.accCustomer.UpdatePotentialCustomerForSalePsn(
                        ref errormsg,
                        CompanyID,
                        JERPBiz.Frame.UserBiz.PsnID);
                    this.dgrdvPublic.Rows.RemoveAt(irow);
                    this.LoadMyData();
                }
            }
        }

    
    }
}