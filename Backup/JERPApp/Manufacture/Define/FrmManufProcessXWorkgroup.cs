using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Define
{
    public partial class FrmManufProcessXWorkgroup : Form 
    {
        public FrmManufProcessXWorkgroup()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
          
            this.accXWorkgroup = new JERPData.Manufacture.ManufProcessXWorkgroup();
            this.accWorkgroup = new JERPData.Manufacture.Workgroup ();
            for (int i = 0; i < iGrid; i++)
            {
                this.dgrdv.Columns[i].ReadOnly = true;
            }
            this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            this.SetPermit();
        }

     
        private JERPData.Manufacture.ManufProcessXWorkgroup accXWorkgroup;
        private JERPData.Manufacture.Workgroup  accWorkgroup;
        private DataTable dtblXWorkgroup,dtblInitXWorkgroup,dtblWorkgroup;
        private int iGrid = 7;
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存           

        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(711);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(712);
            if (this.enableBrowse)
            { 
                this.ctrlQFind.BeforeFilter += new JCommon.CtrlGridFind.BeforeFilterDelegate(ctrlQFind_BeforeFilter);
                this.dgrdv.ContextMenuStrip = this.cMenu;
                this.mItemRefresh.Click += new EventHandler(mItemRefresh_Click);
                this.LoadData();
                this.dgrdv.CellValueChanged += new DataGridViewCellEventHandler(dgrdv_CellValueChanged);
            }
            if (this.enableSave)
            {
                this.btnSave.Click += new EventHandler(btnSave_Click);
            }
        }
       
        private void LoadData()
        {
            this.dtblInitXWorkgroup = this.accXWorkgroup.GetDataManufProcessXWorkgroup().Tables[0];
            while(this.dgrdv.ColumnCount > iGrid )
            {
                this.dgrdv.Columns.RemoveAt(iGrid );
            }
            this.dtblWorkgroup = this.accWorkgroup.GetDataWorkgroup ().Tables[0];
            DataGridViewTextBoxColumn txt;
            foreach (DataRow drow in this.dtblWorkgroup.Rows)
            {
                txt = new DataGridViewTextBoxColumn();
                txt.DataPropertyName = drow["WorkgroupID"].ToString();
                txt.HeaderText = drow["WorkgroupName"].ToString();
                txt.Width = 80;
                this.dgrdv.Columns.Add(txt);
            }
            this.dtblXWorkgroup = this.dtblInitXWorkgroup.Copy();
            this.dgrdv.DataSource = this.dtblXWorkgroup;
            this.ctrlQFind.SeachGridView = this.dgrdv;
         
            
           
        }
        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int cnt = 0;
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                grow.ErrorText = string.Empty;
                if ((grow.Cells[this.ColumnSettingFlag.Name].Value != DBNull.Value)
                    && ((bool)grow.Cells[this.ColumnSettingFlag.Name].Value == false))
                {
                    cnt++;
                    grow.ErrorText = "未设";
                }
            }
            this.lblNonSetting.Text = "未设[" + cnt.ToString() + "]";
        }

        void dgrdv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if (icol >= 7)
            {
                bool SettingFlag = false;
                for (int j = 7; j < this.dgrdv.ColumnCount; j++)
                {
                    if (this.dgrdv[j, irow].Value != DBNull.Value)
                    {
                        SettingFlag = true;
                        break;
                    }
                }
                this.dgrdv[this.ColumnSettingFlag.Name, irow].Value = SettingFlag;
            }
        }

        void mItemRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        void ctrlQFind_BeforeFilter()
        {
            this.dtblXWorkgroup = this.dtblInitXWorkgroup.Copy();
            this.dgrdv.DataSource = this.dtblXWorkgroup;
        }
       
        void btnSave_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在保存中，请稍候...");
            string columnname = string.Empty;
            string errormsg=string.Empty ; 
            foreach (DataRow drow in this.dtblXWorkgroup .Rows)
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                foreach (DataRow drowColumn in this.dtblWorkgroup.Rows)
                {
                    columnname = drowColumn["WorkgroupID"].ToString();
                    this.accXWorkgroup.SaveManufProcessXWorkgroup(
                        ref errormsg,
                        drow["ManufProcessID"],
                        columnname,
                        drow[columnname]);

                }
            }
            this.dtblInitXWorkgroup = this.accXWorkgroup.GetDataManufProcessXWorkgroup().Tables[0];
            FrmMsg.Hide();
            MessageBox.Show("成功保存当前产能设置");
        }

   

    }
}
