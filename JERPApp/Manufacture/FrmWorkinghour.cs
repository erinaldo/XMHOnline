using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmWorkinghour : Form
    {
        public FrmWorkinghour()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.accWorkinghour = new JERPData.Manufacture.Workinghour();
            this.accWorkinghourType = new JERPData.Manufacture.WorkinghourType();
            this.accBatchPsn = new JERPData.Manufacture.WorkgroupXPsn();
            this.SetPermit();
        }
        private JERPData.Manufacture.Workinghour accWorkinghour;
        private JERPData.Manufacture.WorkinghourType accWorkinghourType;
        private JERPData.Manufacture.WorkgroupXPsn accBatchPsn;
        private DataTable dtblWorkinghour, dtblWorkinghourType;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(360);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(361);
            if (this.enableBrowse)
            {
                this.dtpDateManuf.Value = DateTime.Now.Date;
                this.CreateColumns();
                this.LoadData();
                this.dtpDateManuf.ValueChanged += new EventHandler(dtpDateManuf_ValueChanged);
            }
            this.btnAddPsn.Enabled = this.enableSave;
            this.btnAddBatch.Enabled = this.enableSave;
            this.btnSave.Enabled = this.enableSave;
            if (this.enableSave)
            {
                this.btnSave.Click += new EventHandler(btnSave_Click);
                this.btnAddPsn.Click += new EventHandler(btnAddPsn_Click);
                this.btnAddBatch.Click += new EventHandler(btnAddBatch_Click);
            }
        }

        private void CreateColumns()
        {
            this.dtblWorkinghourType = this.accWorkinghourType.GetDataWorkinghourType().Tables[0];
            DataGridViewTextBoxColumn txtcol;
            foreach (DataRow drow in this.dtblWorkinghourType.Rows)
            {
                txtcol = new DataGridViewTextBoxColumn();
                txtcol.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                txtcol.HeaderText = drow["WorkinghourTypeName"].ToString();
                txtcol.DataPropertyName = drow["WorkinghourTypeID"].ToString();
                this.dgrdv.Columns.Add(txtcol);
            }
        }
        private void LoadData()
        {
            this.dtblWorkinghour = this.accWorkinghour.GetDataWorkinghourForSetting(this.dtpDateManuf.Value.Date).Tables[0];
            this.dgrdv.DataSource = this.dtblWorkinghour;
        }

        void dtpDateManuf_ValueChanged(object sender, EventArgs e)
        {
            this.LoadData();
        }
        private void AddPsn(int PsnID, string PsnCode, string PsnName)
        {
            if (PsnID == -1) return;
            DataRow[] drows = this.dtblWorkinghour.Select("PsnID=" +PsnID.ToString());
            if (drows.Length > 0)return;           
            DataRow drowNew = this.dtblWorkinghour.NewRow();
            drowNew["PsnID"] = PsnID;
            drowNew["PsnCode"] = PsnCode;
            drowNew["PsnName"] = PsnName;
            this.dtblWorkinghour.Rows.Add(drowNew);

        }
        void btnAddPsn_Click(object sender, EventArgs e)
        {
            this.AddPsn(this.ctrlPsnID.PsnID, this.ctrlPsnID.PsnCode, this.ctrlPsnID.PsnName);
        }

        void btnAddBatch_Click(object sender, EventArgs e)
        {
            DataTable dtblPsns = this.accBatchPsn.GetDataWorkgroupXPsnForDailyWorking (this.ctrlWorkgroupID.WorkgroupID,this.ctrlShiftID .ShiftID ).Tables[0];
            foreach (DataRow drow in dtblPsns.Rows)
            {
                this.AddPsn((int)drow["PsnID"], drow["PsnCode"].ToString(), drow["PsnName"].ToString());
            }
        }


        void btnSave_Click(object sender, EventArgs e)
        {
          
            string errormsg = string.Empty;
            bool flag = false;
            int  WorkinghourTypeID =-1;
            foreach (DataRow drow in this.dtblWorkinghour.Rows)
            {
                if (drow.RowState == DataRowState.Unchanged) continue;
                foreach (DataRow drowColumn in this.dtblWorkinghourType.Rows)
                {
                    WorkinghourTypeID = (int)drowColumn["WorkinghourTypeID"];
                   flag= this.accWorkinghour.SaveWorkinghour(ref errormsg, this.dtpDateManuf.Value.Date,
                        drow["PsnID"],
                        WorkinghourTypeID,
                        drow[WorkinghourTypeID.ToString()]);
                   if (!flag)
                   {
                       MessageBox.Show(errormsg);
                   }
                }
            }
            MessageBox.Show("成功进行数据保存");
        }
    }
}