using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Define
{
    public partial class FrmPieceworkPrice : Form
    {
    
        public FrmPieceworkPrice()
        {
            InitializeComponent();
            this.accProcessType = new JERPData.Manufacture.ProcessType();
            this.accUnit = new JERPData.General.Unit();
            this.dgrdv.AutoGenerateColumns = false;
            this.SetPermit();
        }
        private DataTable dtblWorkingTypes,dtblUnits;

        private JERPData.Manufacture.ProcessType accProcessType;
        private JERPData.General.Unit accUnit;
        private void SetColumnSrc()
        {
            this.dtblUnits = this.accUnit.GetDataUnit().Tables[0];
            this.ColumnUnitID.DataSource = this.dtblUnits;
            this.ColumnUnitID.ValueMember = "UnitID";
            this.ColumnUnitID.DisplayMember = "UnitName";
        }
        private void LoadData()
        {
            this.dtblWorkingTypes = this.accProcessType.GetDataProcessType().Tables[0];        
            this.dgrdv.DataSource = this.dtblWorkingTypes;
        }

        //È¨ÏÞÂë
        private bool enableBrowse = false;//ä¯ÀÀ
        private bool enableSave = false;//±£´æ
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(105);
            this.enableSave = JERPBiz.Frame.PermitHelper.EnableFunction(106);
            if (this.enableBrowse)
            {
                this.SetColumnSrc();
                this.LoadData();
            }          
            if (this.enableSave)
            {
                 this.dgrdv.RowValidated +=new DataGridViewCellEventHandler(dgrdv_RowValidated);            
            }
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
            flag=this.accProcessType.UpdateProcessTypeForLablorPrice  (ref errormsg,
                    drow["ProcessTypeID"],
                    drow["LaborPrice"],
                    drow["ReworkLaborPrice"],
                    drow["UnitID"]);
            if (!flag)
            {
                MessageBox.Show(errormsg);
            }
        }     
       
    }
}