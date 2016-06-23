using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Define
{
    public partial class FrmWorkinghourType : Form
    {
    
        public FrmWorkinghourType()
        {
            InitializeComponent();
            this.accWorkinghourType = new JERPData.Manufacture.WorkinghourType();
            this.dgrdv.AutoGenerateColumns = false;
            this.SetPermit();
        }
        private DataTable dtblWorkingTypes;
        private JERPData.Manufacture.WorkinghourType accWorkinghourType;
        private void LoadData()
        {
            this.dtblWorkingTypes = this.accWorkinghourType.GetDataWorkinghourType().Tables[0];        
            this.dtblWorkingTypes.Columns["WorkinghourTypeName"].AllowDBNull = false;
            this.dtblWorkingTypes.Columns["WorkinghourTypeName"].Unique = true;
            this.dgrdv.DataSource = this.dtblWorkingTypes;
        }

        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private bool enableSave = false;//±£´æ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(103);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(104);
            if (this.enableBrowse)
            {
                this.LoadData();
            }
            this.dgrdv.ReadOnly = !enableSave;
            this.dgrdv.AllowUserToAddRows = enableSave ;
            if (this.enableSave)
            {
                this.FormClosed += new FormClosedEventHandler(FrmWorkinghourType_FormClosed);
                this.dgrdv.RowValidated +=new DataGridViewCellEventHandler(dgrdv_RowValidated);            
             }
        }

        void FrmWorkinghourType_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.affterSave != null) this.affterSave();
        }

        void dgrdv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
          
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            bool flag = false;
            DataRow drow = null;
            try
            {
                drow = this.dtblWorkingTypes.DefaultView[irow].Row;
            }
            catch 
            {
                return;
            }
            if (drow == null) return;
            string errormsg = string.Empty;
            if (drow["WorkinghourTypeID"] == DBNull.Value)
            {
                object objWorkinghourTypeID =DBNull .Value ;
                flag = this.accWorkinghourType.InsertWorkinghourType(ref errormsg,
                        ref objWorkinghourTypeID,                
                        drow["WorkinghourTypeName"],
                        drow["LaborPrice"]);
                if (flag)
                {
                    drow["WorkinghourTypeID"] = objWorkinghourTypeID;
                }
                else
                {
                    MessageBox.Show(errormsg);
                }
            }
            else
            {
                flag=this.accWorkinghourType.UpdateWorkinghourType(ref errormsg,
                        drow["WorkinghourTypeID"],
                        drow["WorkinghourTypeName"],
                        drow["LaborPrice"]);
                if (!flag)
                {
                    MessageBox.Show(errormsg);
                }

            }
        }     
        public delegate void AffterSaveDelegate();
        private AffterSaveDelegate affterSave;
        public event AffterSaveDelegate AffterSave
        {
            add
            {
                affterSave += value;
            }
            remove
            {
                affterSave -= value;
            }
        }
    }
}