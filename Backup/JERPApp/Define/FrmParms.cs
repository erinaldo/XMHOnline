using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Define
{
    public partial class FrmParms : Form
    {
        public FrmParms()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlQFind.SeachGridView = this.dgrdv;
            this.accParms = new JERPData.General.Parms();
            this.SetPermit();
        }
        private JERPData.General.Parms accParms;
        private DataTable dtblParms;
        //权限码
        private bool enableBrowse = false;//浏览
        private bool enableSave = false;//保存
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(5);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(6);
            if (this.enableBrowse)
            {
                this.LoadData();
             
            }
            
            if (this.enableSave)
            {
             
                this.dgrdv.RowValidated += new DataGridViewCellEventHandler(dgrdv_RowValidated);
                this.dgrdv.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdv_DataBindingComplete);
            }
        }

        void dgrdv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdv.Rows)
            {
                grow.ErrorText = string.Empty;
                object objValue=grow .Cells [this.ColumnParmValue.Name ].Value ;
                if(objValue ==DBNull .Value )continue ;
                object objFlag=grow.Cells [this.ColumnIntFlag.Name ].Value;
                if ((objFlag !=DBNull .Value )&&((bool)objFlag))
                {
                    int i;
                    if(!int.TryParse (objValue .ToString (),out i))
                    {
                        grow.ErrorText = "整数值错误";
                    }
                    continue;
                }
                objFlag = grow.Cells[this.ColumnFloatFlag.Name].Value;
                if ((objFlag !=DBNull .Value )&&((bool)objFlag))
                {
                    decimal d;
                    if(!decimal .TryParse (objValue .ToString (),out d))
                    {
                        grow.ErrorText = "浮点数值错误";
                    }
                    continue;
                }
            }
        }

        private void LoadData()
        {
            this.dtblParms = this.accParms.GetDataParms().Tables[0];
            this.dgrdv.DataSource = this.dtblParms;
        }
    
        void dgrdv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow grow = this.dgrdv.CurrentRow;
            if (grow.ErrorText.Length > 0) return;
            if (grow.Index == -1) return;
            object ParmID = this.dtblParms.DefaultView[grow.Index]["ParmID"];
            object objParmValue = grow.Cells[this.ColumnParmValue.Name].Value;
            string errormsg = string.Empty;
            this.accParms.UpdateParms(ref errormsg,
                           ParmID,
                           objParmValue);
        }

    
    }
}